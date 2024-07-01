<template>
  <div class="app-container">
    <!-- :model属性用于表单验证使用 比如下面的el-form-item 的 prop属性用于对表单值进行验证操作 -->
    <el-form :model="form" ref="formRef" label-width="100px" :rules="rules" @submit.prevent>
      <el-row class="mb10">
        <el-col :lg="24">
          <el-form-item :label="$t('particle.title')" prop="title">
            <el-input v-model="form.title"
              :placeholder="$t('btn.enterPrefix')+$t('particle.title')+$t('btn.enterSuffix')" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item prop="content" :label="$t('particle.content')">
            <MdEditor v-model="form.content" :theme="settingsStore.codeMode" :onUploadImg="onUploadImg" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item prop="abstractText" :label="$t('particle.abstractText')">
            <el-input v-model="form.abstractText" type="textarea" show-word-limit maxlength="100"
              :placeholder="$t('btn.enterPrefix')+$t('particle.abstractText')+$t('btn.enterSuffix')" />
          </el-form-item>
        </el-col>

        <el-col :lg="5">
          <el-form-item :label="$t('particle.type')" prop="categoryId">
            <el-cascader class="w100" :options="categoryOptions"
              :props="{ checkStrictly: true, value: 'categoryId', label: 'name', emitPath: false }"
              :placeholder="$t('btn.selectPrefix')+$t('particle.type')+$t('btn.selectSuffix')" clearable
              v-model="form.categoryId" />
          </el-form-item>
        </el-col>
        <el-col :lg="11">
          <el-form-item :label="$t('particle.tags')">
            <el-tag v-for="tag in form.dynamicTags" :key="tag" class="mr10" closable :disable-transitions="false"
              @close="handleCloseTag(tag)">
              {{ tag }}
            </el-tag>
            <el-input size="small" v-if="inputVisible" style="width: 150px" ref="inputRef" v-model="inputValue"
              show-word-limit maxlength="8" :placeholder="$t('particle.charactersNum')"
              @keyup.enter="handleInputConfirm" @blur="handleInputConfirm" />

            <el-button v-else class="button-new-tag" size="small" icon="plus" text
              @click="showInput">{{$t('btn.add')+$t('particle.tags')}}</el-button>
          </el-form-item>
        </el-col>
        <el-col :lg="8">
          <el-form-item :label="$t('particle.isPublic')">
            <template #label>
              <span>
                <el-tooltip :content="$t('particle.isPublicTip')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{$t('particle.isPublic')}}
              </span>
            </template>
            <el-switch v-model="form.isPublic" inline-prompt :active-value="1" :in-active-value="0"
              :active-text="$t('common.yes')" :inactive-text="$t('common.no')" />
          </el-form-item>
        </el-col>

        <el-col :lg="24">
          <el-form-item :label="$t('particle.coverUrl')">
            <UploadImage ref="uploadRef" v-model="form.coverUrl" :limit="1" :fileSize="15">
              <template #icon>
                <el-icon class="avatar-uploader-icon">
                  <plus />
                </el-icon>
              </template>
            </UploadImage>
          </el-form-item>
        </el-col>

        <div class="btn-wrap">
          <el-button type="success" icon="check" @click="handlePublish('1')">


            {{$t('ppublish.publish')+' '+$t('particle.article')}}</el-button>
          <el-button icon="Collection" @click="handlePublish('2')">
            {{$t('btn.save')+' '+$t('ppublish.draft')}}</el-button>
        </div>
      </el-row>
    </el-form>
  </div>
</template>
<script setup name="articlepublish">
  import { addArticle, updateArticle, getArticle } from '@/api/routine/article.js'
  import { treelistArticleCatalog } from '@/api/routine/articlecatalog.js'
  import useSettingsStore from '@/store/modules/settings'
  import { upload } from '@/api/common.js'
  import { MdEditor } from 'md-editor-v3'
  import 'md-editor-v3/lib/style.css'
  import '@fortawesome/fontawesome-free/css/all.min.css';
  const settingsStore = useSettingsStore()
  const { proxy } = getCurrentInstance()
  const route = useRoute()
  // 文章目录下拉框
  const categoryOptions = ref([])
  const inputVisible = ref(false)
  const inputValue = ref('')
  const formRef = ref()
  const inputRef = ref()
  const data = reactive({
    form: {
      dynamicTags: [],
      fmtType: 'markdown',
      tags: undefined,
      cid: undefined,
      content: undefined,
      status: undefined,
      categoryId: undefined,
      isPublic: 1,
      abstractText: undefined
    },
    rules: {
      title: [{ required: true, message: proxy.$t('particle.title') + proxy.$t('common.tipIsRequired'), trigger: 'blur' }],
      content: [{ required: true, message: proxy.$t('particle.content') + proxy.$t('common.tipIsRequired'), trigger: 'blur' }],
      abstractText: [{ required: true, message: proxy.$t('particle.abstractText') + proxy.$t('common.tipIsRequired'), trigger: 'blur' }]
    }
  })
  const { form, rules } = toRefs(data)

  const cid = route.query.cid
  form.value.cid = cid

  /** 查询菜单下拉树结构 */
  function getCategoryTreeselect() {
    treelistArticleCatalog({}).then((res) => {
      if (res.code == 200) {
        categoryOptions.value = res.data
      }
    })
  }

  // 将图片上传到服务器，返回地址替换到md中
  async function onUploadImg(files, callback) {
    const res = await Promise.all(
      Array.from(files).map((file) => {
        return new Promise((rev, rej) => {
          const form = new FormData()
          form.append('file', file)

          upload(form)
            .then((res) => rev(res))
            .catch((error) => rej(error))
        })
      })
    )

    callback(res.map((item) => item.data.url))
  }

  /** 提交按钮 */
  function handlePublish(status) {
    form.value.status = status
    form.value.tags = form.value.dynamicTags.toString()

    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.cid != undefined) {
          updateArticle(form.value).then((res) => {
            if (res.code == 200) {
              proxy.$modal.msgSuccess(proxy.$t('btn.edit') + ' ' + proxy.$t('particle.article') + ' ' + proxy.$t('ppublish.succeed'))
              proxy.$tab.closeOpenPage({ path: '/article/list' })
            } else {
              proxy.$modal.msgError(proxy.$t('btn.edit') + ' ' + proxy.$t('particle.article') + ' ' + proxy.$t('ppublish.failed'))
            }
          })
        } else {
          addArticle(form.value).then((res) => {
            if (res.code == 200) {
              proxy.$modal.msgSuccess(proxy.$t('ppublish.publish') + ' ' + proxy.$t('particle.article') + ' ' + proxy.$t('ppublish.succeed'))
              proxy.$tab.closeOpenPage({ path: '/article/list' })
            } else {
              proxy.$modal.msgError(proxy.$t('ppublish.publish') + ' ' + proxy.$t('particle.article') + ' ' + proxy.$t('ppublish.succeed'))
            }
          })
        }
      }
    })
  }
  function handleCloseTag(tag) {
    form.value.dynamicTags.splice(form.value.dynamicTags.indexOf(tag), 1)
  }

  const showInput = () => {
    if (form.value.dynamicTags.length >= 5) {
      proxy.$modal.msgError(proxy.$t('particle.tagsNum'))
      return
    }
    inputVisible.value = true
    nextTick(() => {
      inputRef.value.input.focus()
    })
  }
  // 标签确认
  function handleInputConfirm() {
    if (inputValue.value) {
      form.value.dynamicTags.push(inputValue.value)
    }
    inputVisible.value = false
    inputValue.value = ''
  }
  function getInfo(cid) {
    if (!cid || cid == undefined) return
    getArticle(cid).then((res) => {
      if (res.code == 200) {
        var data = res.data
        form.value = {
          ...data,
          dynamicTags: data.tags != null && data.tags.length > 0 ? data.tags.split(',') : []
        }
      }
    })
  }
  getInfo(cid)
  getCategoryTreeselect()
</script>
<style scoped>
  .app-container {
    position: relative;
  }

  .button-new-tag {
    padding-top: 0;
    padding-bottom: 0;
    width: 190px;
    margin-right: 10px;
    vertical-align: bottom;
  }

  .vue-treeselect {
    z-index: 1501;
  }



  .btn-wrap {
    z-index: 100;
    width: 100%;
    top: 0;
    /* background: #fff; */
    padding: 5px 20px;
    display: flex;
    align-items: center;
  }
</style>