<template>
  <!-- 添加或修改公告对话框 -->
  <zr-dialog :title="title" draggable v-model="open" width="580px">
    <el-form ref="noticeRef" :model="form" :rules="rules" label-width="auto">
      <el-row>
        <el-col :lg="24">
          <el-form-item :label="$t('pnotice.noticeTitle')" prop="noticeTitle">
            <el-input v-model="form.noticeTitle"
              :placeholder="$t('btn.enterPrefix')+$t('pnotice.noticeTitle')+$t('btn.enterSuffix')" />
          </el-form-item>
        </el-col>
        <el-col :lg="12">
          <el-form-item :label="$t('pnotice.noticeType')" prop="noticeType">
            <el-radio-group v-model="form.noticeType">
              <el-radio v-for="dict in props.options.sys_notice_type" :key="dict.dictValue"
                :value="parseInt(dict.dictValue)">{{
                dict.dictLabel
                }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('common.tipIsStated')">
            <el-radio-group v-model="form.isStatus">
              <el-radio v-for="dict in props.options.sys_notice_status" :key="dict.dictValue"
                :value="parseInt(dict.dictValue)">{{
                dict.dictLabel
                }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pnotice.publisher')" prop="publisher">
            <el-input v-model="form.publisher"
              :placeholder="$t('btn.enterPrefix')+$t('pnotice.publisher')+$t('btn.enterSuffix')" />
          </el-form-item>
        </el-col>
        <el-col :lg="12">
          <el-form-item :label="$t('btn.dateStart')" prop="beginTime">
            <el-date-picker v-model="form.beginTime" type="datetime" :placeholder="$t('btn.dateselect')">
            </el-date-picker>
          </el-form-item>
        </el-col>
        <el-col :lg="12">
          <el-form-item :label="$t('btn.dateEnd')" prop="endTime">
            <el-date-picker v-model="form.endTime" :disabled-date="disabledDate" type="datetime"
              :placeholder="$t('btn.dateselect')">
            </el-date-picker>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pnotice.noticeFileUrl')" prop="fileUrl">
            <UploadFile v-model="form.fileUrl" :data="{ uploadType: 1 }" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <editor v-model="form.noticeContent" :toolbarConfig="toolbarConfig" :min-height="196" />
        </el-col>
      </el-row>
    </el-form>
    <template #footer>
      <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
      <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
    </template>
  </zr-dialog>
</template>
<script setup>
  import { addNotice, updateNotice, getNotice } from '@/api/routine/notice'
  import dayjs from 'dayjs'
  import useUserStore from '@/store/modules/user'
  // 富文本组件
  import Editor from '@/components/Editor'
  const { proxy } = getCurrentInstance()
  const emit = defineEmits()
  const props = defineProps({
    options: {
      sys_notice_type: [],
      sys_notice_status: []
    }
  })

  const open = ref(false)
  const title = ref('')
  const data = reactive({
    form: {},
    rules: {
      noticeTitle: [{ required: true, message: proxy.$t('pnotice.noticeTitle') + proxy.$t('btn.empty'), trigger: 'blur' }],
      noticeType: [{ required: true, message: proxy.$t('pnotice.noticeType') + proxy.$t('btn.empty'), trigger: 'change' }],
      beginTime: [{ required: false, message: proxy.$t('btn.dateStart') + proxy.$t('btn.empty'), trigger: 'change' }],
      endTime: [{ required: false, message: proxy.$t('btn.dateEnd') + proxy.$t('btn.empty'), trigger: 'change' }]
    }
  })
  const { form, rules } = toRefs(data)

  const toolbarConfig = ref({
    toolbarKeys: [
      // 菜单 key
      'headerSelect',
      'bold', // 加粗
      'italic', // 斜体
      'through', // 删除线
      'underline', // 下划线
      'bulletedList', // 无序列表
      'numberedList', // 有序列表
      'color', // 文字颜色
      'uploadImage', // 上传图片
      'delIndent', // 缩进
      'indent', // 增进
      'insertLink', // 插入链接
      'fontSize', // 字体大小
      'clearStyle', // 清除格式
      'divider', // 分割线
      'insertTable', // 插入表格
      'justifyCenter', // 居中对齐
      'justifyJustify', // 两端对齐
      'justifyLeft', // 左对齐
      'justifyRight', // 右对齐
      'fullScreen' // 全屏
    ]
  })

  /** 取消按钮 */
  function cancel() {
    open.value = false
    reset()
  }
  /** 表单重置 */
  function reset() {
    form.value = {
      noticeId: undefined,
      noticeTitle: undefined,
      noticeType: 1,
      noticeContent: undefined,
      fileUrl: undefined,
      isStatus: 0,
      beginTime: undefined,
      endTime: undefined,
      publisher: undefined
    }
    proxy.resetForm('noticeRef')
  }

  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    open.value = true
    title.value = proxy.$t('btn.add') + ' ' + proxy.$t('pnotice.notice')

    form.value.publisher = useUserStore().name
  }
  /**修改按钮操作 */
  function handleUpdate(row) {
    reset()
    const noticeId = row.noticeId || ids.value
    getNotice(noticeId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit') + ' ' + proxy.$t('pnotice.notice')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['noticeRef'].validate((valid) => {
      if (valid) {
        if (form.value.noticeId != undefined) {
          updateNotice(form.value).then(() => {
            proxy.$modal.msgSuccess(proxy.$t('common.editSucceed'))
            open.value = false
            emit('success')
          })
        } else {
          addNotice(form.value).then(() => {
            proxy.$modal.msgSuccess(proxy.$t('common.addSucceed'))
            open.value = false
            emit('success')
          })
        }
      }
    })
  }
  function disabledDate(val) {
    var time = dayjs(form.value.beginTime).valueOf()

    return val.getTime() < time
  }
  defineExpose({
    handleAdd,
    handleUpdate
  })
</script>