<template>
  <div class="app-container">
    <el-form :model="queryParams" label-position="left" inline ref="queryForm" v-show="showSearch" @submit.prevent>
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item :label="$t('particle.title')" prop="title">
            <el-input v-model="queryParams.title" placeholder="请输入标题" />
          </el-form-item>
          <el-form-item :label="$t('particle.abstractText')" prop="abstractText">
            <el-input v-model="queryParams.abstractText" placeholder="请输入摘要" />
          </el-form-item>
          <el-form-item label="Id" prop="categoryId">
            <el-cascader class="w100" :options="categoryOptions"
              :props="{ checkStrictly: true, value: 'categoryId', label: 'name', emitPath: false }" placeholder="请选择分类"
              clearable v-model="queryParams.categoryId" />
          </el-form-item>
          <el-form-item :label="$t('btn.audit')+$t('common.tipIsStated')" prop="auditStatus">
            <el-radio-group v-model="queryParams.auditStatus" @change="handleQuery()">
              <el-radio-button value="">{{$t('common.all')}}</el-radio-button>
              <el-radio-button v-for="item in options.auditOptions" :key="item.dictValue" :value="item.dictValue">
                {{ item.dictLabel }}
              </el-radio-button>
            </el-radio-group>
          </el-form-item>
          <el-form-item :label="$t('common.tipIsStated')" prop=" isStatus">
            <el-radio-group v-model="queryParams.isStatus" @change="handleQuery()">
              <el-radio-button value="">{{$t('common.all')}}</el-radio-button>
              <el-radio-button v-for="item in options.sys_article_status" :key="item.dictValue" :value="item.dictValue">
                {{ item.dictLabel }}
              </el-radio-button>
            </el-radio-group>
          </el-form-item>
          <el-form-item :label="$t('particle.type')" prop="articleType">
            <el-radio-group v-model="queryParams.articleType" @change="handleQuery()">
              <el-radio-button value="">{{$t('common.all')}}</el-radio-button>
              <el-radio-button v-for="item in options.sys_article_type" :key="item.dictValue" :value="item.dictValue">
                {{ item.dictLabel }}
              </el-radio-button>
            </el-radio-group>
          </el-form-item>
          <el-form-item :label="$t('particle.isPublic')" prop="isPublic">
            <el-radio-group v-model="queryParams.isPublic" @change="handleQuery()">
              <el-radio-button value="">{{$t('common.all')}}</el-radio-button>
              <el-radio-button v-for="item in options.isPublicOptions" :key="item.dictValue" :value="item.dictValue">
                {{ item.dictLabel }}
              </el-radio-button>
            </el-radio-group>
          </el-form-item>
          <el-form-item :label="$t('particle.isTop')" prop="isTop">
            <el-radio-group v-model="queryParams.isTop" @change="handleQuery()">
              <el-radio-button value="">{{$t('common.all')}}</el-radio-button>
              <el-radio-button v-for="item in options.isPublicOptions" :key="item.dictValue" :value="item.dictValue">
                {{ item.dictLabel }}
              </el-radio-button>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24" :offset="12">
          <el-form-item>
            <el-button type="primary" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
            <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="success" :disabled="multiple" v-hasPermi="['article:audit']" plain icon="check" size="small"
          @click="handleAuditPass">
          {{$t('btn.audit')}}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['article:audit']" plain icon="close" size="small"
          @click="handleAuditReject">
          {{$t('btn.reject')}}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="primary" plain icon="plus" v-hasPermi="['system:article:add']" size="small"
          @click="handleAdd">{{$t('menu.routineArticlePublish')}}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="plus" v-hasPermi="['system:article:add']" size="small"
          @click="handleMonents">{{$t('menu.routineMomentPublish')}}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table :data="dataList" height="600px" v-loading="loading" @selection-change="handleSelectionChange"
      highlight-current-row @sort-change="sortChange" ref="table">
      <el-table-column type="selection" width="50" align="center" :selectable="checkSelectable" />
      <el-table-column prop="cid" label="文章信息" width="130">
        <template #default="{ row }">
          <div @click="handleView(row)">内容id：{{ row.cid }}</div>
          <div>作者：{{ row.authorName }}</div>
          <div>标签：{{ row.tags }}</div>
        </template>
      </el-table-column>
      <el-table-column :label="$t('particle.type')">
        <template #default="{ row }">
          <div v-if="row.ArticleCatalogNav">{{ row.ArticleCatalogNav.name }}</div>
        </template>
      </el-table-column>
      <el-table-column prop="title" :label="$t('particle.title')" width="120" :show-overflow-tooltip="true">
        <template #default="scope">
          <el-button link type="primary" @click="handleView(scope.row)">{{ scope.row.title }}</el-button>
        </template>
      </el-table-column>
      <el-table-column prop="coverUrl" :label="$t('particle.coverUrl')" width="90" :show-overflow-tooltip="true">
        <template #default="{ row }">
          <image-preview :src="row.coverUrl" split="," style="width: 40px" v-if="row.coverUrl"></image-preview>
        </template>
      </el-table-column>
      <!-- <el-table-column prop="authorName" label="作者" width="80"> </el-table-column> -->
      <!-- <el-table-column prop="fmt_type" label="编辑器类型" width="100"> </el-table-column> -->
      <!-- <el-table-column prop="tags" label="标签" width="100" :show-overflow-tooltip="true"> </el-table-column> -->
      <el-table-column prop="hits" :label="$t('particle.hits')" width="80" align="center" sortable> </el-table-column>
      <el-table-column prop="praiseNum" :label="$t('particle.praiseNum')" width="80" align="center" sortable>
      </el-table-column>
      <el-table-column prop="commentNum" :label="$t('particle.commentNum')" width="80" align="center" sortable>
      </el-table-column>
      <el-table-column prop="abstractText" :label="$t('particle.abstractText')"
        v-if="columns.showColumn('abstractText')"> </el-table-column>
      <el-table-column prop="isStatus" align="center" :label="$t('common.tipIsStated')" width="90">
        <template #default="scope">
          <el-tag :type="scope.row.isStatus == 2 ? 'danger' : 'success'">{{ scope.row.isStatus == 2 ?
            $t('ppublish.draft') : $t('ppublish.publish') }}
          </el-tag>
        </template>
      </el-table-column>
      <el-table-column prop="auditStatus" align="center" :label=" $t('btn.audit')" width="90">
        <template #default="scope">
          <dict-tag :options="options.auditOptions" :value="scope.row.auditStatus"> </dict-tag>
        </template>
      </el-table-column>
      <el-table-column :label="$t('particle.isTop')" prop="isTop" width="90" align="center"
        v-if="columns.showColumn('isTop')" sortable>
        <template #default="scope">
          <el-switch v-model="scope.row.isTop" inline-prompt disabled :active-text="$t('common.yes')"
            :inactive-text="$t('common.no')" :active-value="1" :inactive-value="0"></el-switch>
        </template>
      </el-table-column>
      <el-table-column :label="$t('particle.isPublic')" align="center" prop="isPublic" width="90">
        <template #default="scope">
          <el-switch v-model="scope.row.isPublic" inline-prompt :active-text="$t('common.yes')"
            :inactive-text="$t('common.no')" :active-value="1" :inactive-value="0" disabled></el-switch>
        </template>
      </el-table-column>
      <el-table-column prop="createTime" :label=" $t('common.tipCreateTime')" width="128" :show-overflow-tooltip="true">
        <template #default="scope">
          {{ showTime(scope.row.createTime) }}
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" width="130" fixed="right">
        <template #default="scope">
          <el-button-group>
            <el-button size="small" icon="view" @click="handleView(scope.row)"> </el-button>
            <el-button size="small" icon="edit" @click="handleUpdate(scope.row)" v-hasPermi="['system:article:update']"
              v-if="scope.row.articleType == 0">
            </el-button>
            <el-popconfirm :title="$t('btn.delete')" @confirm="handleDelete(scope.row)" style="margin-left: 10px">
              <template #reference>
                <el-button size="small" type="danger" icon="delete" v-hasPermi="['system:article:delete']"></el-button>
              </template>
            </el-popconfirm>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <el-dialog :title="previewInfo.title" v-model="showPreview">
      <image-preview :src="previewInfo.coverUrl" split="," style="height: 140px"
        v-if="previewInfo.coverUrl"></image-preview>
      <MdPreview show-code-row-number editorId="id1" :theme="settingsStore.codeMode"
        :modelValue="previewInfo.content" />
    </el-dialog>
  </div>
</template>
<script setup name="index">
  import { listArticle, delArticle, auditArticle, getArticle } from '@/api/routine/article.js'
  import { treelistArticleCatalog } from '@/api/routine/articlecatalog.js'
  import { MdPreview } from 'md-editor-v3'
  import { showTime } from '@/utils/index'
  import 'md-editor-v3/lib/preview.css'
  import useSettingsStore from '@/store/modules/settings'
  const settingsStore = useSettingsStore()
  const { proxy } = getCurrentInstance()
  const router = useRouter()
  // 选中mid数组数组
  const ids = ref([])
  // 非单选禁用
  const single = ref(true)
  // 非多个禁用
  const multiple = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 数据列表
  const dataList = ref([])
  // 总记录数
  const total = ref(0)

  // 文章目录下拉框
  const categoryOptions = ref([])
  const loading = ref(false)
  const data = reactive({
    form: {},
    queryParams: {
      sort: 'cid',
      sortType: 'desc',
      isStatus: -1,
      isPublic: '',
      isTop: '',
      articleType: '',
      auditStatus: ''
    },
    options: {
      isPublicOptions: [
        { dictLabel: proxy.$t('common.yes'), dictValue: '1' },
        { dictLabel: proxy.$t('common.no'), dictValue: '0', listClass: 'info' }
      ],
      auditOptions: [
        { dictLabel: proxy.$t('btn.passed'), dictValue: '1' },
        { dictLabel: proxy.$t('btn.failed'), dictValue: '0', listClass: 'info' },
        { dictLabel: proxy.$t('btn.pending'), dictValue: '2', listClass: 'danger' }
      ],
      // 评论权限
      sys_comment_permi: [],
      //文章状态
      sys_article_status: [],
      // 文章类型
      sys_article_type: []
    }
  })
  const columns = ref([
    { visible: false, prop: 'abstractText', label: proxy.$t('particle.abstractText') },
    { visible: false, prop: 'isTop', label: proxy.$t('particle.isTop') }
  ])
  const queryForm = ref()
  const { queryParams, options } = toRefs(data)

  // 自定义排序
  function sortChange(column) {
    if (column.prop == null || column.order == null) {
      queryParams.sort = undefined
      queryParams.sortType = undefined
    } else {
      queryParams.sort = column.prop
      queryParams.sortType = column.order
    }

    handleQuery()
  }

  proxy.getDicts(['sys_article_status', 'sys_article_type', 'sys_comment_permi']).then((response) => {
    response.data.forEach((element) => {
      data.options[element.dictType] = element.list
    })
  })

  /** 查询菜单下拉树结构 */
  function getCategoryTreeselect() {
    treelistArticleCatalog().then((res) => {
      if (res.code == 200) {
        categoryOptions.value = res.data
      }
    })
  }
  // 查询数据
  function getList() {
    loading.value = true
    listArticle(queryParams.value).then((res) => {
      loading.value = false
      if (res.code == 200) {
        dataList.value = res.data.result
        total.value = res.data.totalNum
      }
    })
  }

  /** 重置查询操作 */
  function resetQuery() {
    proxy.resetForm('queryForm')
    handleQuery()
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    getList()
  }

  /** 新增按钮操作 */
  function handleAdd() {
    router.push({ path: 'publish' })
  }

  function handleMonents() {
    router.push({ path: 'Moments' })
  }

  /** 删除按钮操作 */
  function handleDelete(row) {
    delArticle(row.cid).then((res) => {
      if (res.code == 200) {
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
        handleQuery()
      }
    })
  }

  /** 修改按钮操作 */
  function handleUpdate(row) {
    router.push({ path: '/article/publish', query: { cid: row.cid } })
  }
  // 详情
  const previewInfo = ref({})
  function handleView(row) {
    getArticle(row.cid).then((res) => {
      previewInfo.value = res.data
      showPreview.value = true
    })
  }
  // function handleTopChange(row) {
  //   topArticle({ cid: row.cid, isTop: row.isTop }).then((res) => {
  //     handleQuery()
  //   })
  // }
  // function handleChangePublic(row) {
  //   changeArticlePublic({ cid: row.cid, isPublic: row.isPublic }).then((res) => {
  //     handleQuery()
  //   })
  // }
  function checkSelectable(row) {
    return row.auditStatus == 0 ? true : false
  }
  /**
   * 审核通过
   * @param {审核} row
   */
  function handleAuditPass(row) {
    const id = row.cid || ids.value
    auditArticle('pass', id).then((res) => {
      const { code } = res
      if (code == 200) {
        proxy.$modal.msgSuccess(proxy.$t('common.tipAuditSucceed'))
      }
      getList()
    })
  }

  /**
   * 拒绝
   * @param {*} row
   */
  function handleAuditReject(row) {
    const id = row.cid || ids.value

    proxy.$prompt(proxy.$t('common.tipRejectReason'), proxy.$t('common.tip'), {}).then(({ value }) => {
      auditArticle('reject', id, { reason: value }).then((res) => {
        const { code } = res
        if (code == 200) {
          proxy.$modal.msgSuccess(proxy.$t('common.tipRejectSucceed'))
        }
        getList()
      })
    })
  }

  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.cid)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }

  const showPreview = ref(false)

  getCategoryTreeselect()
  handleQuery()
</script>