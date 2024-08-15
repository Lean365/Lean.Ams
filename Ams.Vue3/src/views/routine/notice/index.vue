<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryRef" :inline="true" v-show="showSearch" label-width="68px">
      <el-form-item :label="$t('pnotice.noticeTitle')" prop="noticeTitle">
        <el-input v-model="queryParams.noticeTitle"
          :placeholder="$t('btn.enterSearchPrefix')+$t('pnotice.noticeTitle')+$t('btn.enterSearchSuffix')" clearable
          @keyup.enter="handleQuery" />
      </el-form-item>
      <el-form-item :label="$t('pnotice.noticeType')" prop="noticeType">
        <el-select v-model="queryParams.noticeType"
          :placeholder="$t('btn.selectSearchPrefix')+$t('pnotice.noticeType')+$t('btn.selectSearchSuffix')" clearable>
          <el-option v-for="dict in options.sys_notice_type" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="Search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="Refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="Plus" @click="handleAdd" v-hasPermi="['system:notice:add']"> {{
          $t('btn.add') }}</el-button>
      </el-col>

      <el-col :span="1.5">
        <el-button type="danger" plain icon="Delete" :disabled="multiple" @click="handleDelete"
          v-hasPermi="['system:notice:delete']">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['system:notice:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table height="650" v-loading="loading" :data="noticeList" @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column label="Id" align="center" prop="noticeId" />
      <el-table-column :label="$t('pnotice.noticeTitle')" prop="noticeTitle" :show-overflow-tooltip="true">
        <template #default="{ row }">
          <el-link type="primary" @click="handleOpenPre(row)">{{ row.noticeTitle }}</el-link>
        </template>
      </el-table-column>
      <el-table-column :label="$t('pnotice.noticeType')" align="center" prop="noticeType">
        <template #default="scope">
          <dict-tag :options="options.sys_notice_type" :value="scope.row.noticeType" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('pnotice.noticeFileUrl')" align="center" prop="fileUrl">
        <template #default="{ row }">
          <el-link :href="row.fileUrl" target="_blank">{{ row.fileUrl }}</el-link>
        </template>
      </el-table-column>
      <el-table-column :label="$t('common.tipIsStated')" align="center" prop="isStatus">
        <template #default="scope">
          <dict-tag :options="options.sys_notice_status" :value="scope.row.isStatus" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('pnotice.displayTime')">
        <template #default="scope">
          <div>{{ parseTime(scope.row.beginTime, 'YYYY-MM-DD') }}</div>
          <div>{{ parseTime(scope.row.endTime, 'YYYY-MM-DD') }}</div>

        </template>
      </el-table-column>
      <el-table-column :label="$t('pnotice.publisher')" align="center" prop="publisher" />
      <el-table-column :label="$t('common.tipCreateBy')" align="center" prop="createBy" />
      <el-table-column :label="$t('common.tipCreateTime')" align="center" prop="createTime">
        <template #default="scope">
          <span>{{ parseTime(scope.row.createTime, 'YYYY-MM-DD') }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" width="200">
        <template #default="scope">
          <el-button-group>
            <el-button plain size="small" type="info" icon="bell" @click="handleNotice(scope.row)"
              :title="$t('layout.headerNotice')" v-hasPermi="['system:notice:update']">
            </el-button>
            <el-button plain size="small" type="success" icon="Edit" @click="handleUpdate(scope.row)"
              :title="$t('btn.edit')" v-hasPermi="['system:notice:update']">
            </el-button>
            <el-button plain size="small" type="danger" icon="Delete" @click="handleDelete(scope.row)"
              :title="$t('btn.delete')" v-hasPermi="['system:notice:delete']">
            </el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>

    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <publishNoticeForm ref="publishRef" :options="options" @success="getList()"></publishNoticeForm>
    <zr-dialog :title="$t('btn.preview')" draggable v-model="openPreview" width="580px">
      <template v-if="info">
        <h2 style="text-align: center; margin-top: 0" class="mb10">{{ info.noticeTitle }}</h2>
        <div v-html="info.noticeContent"></div>

        <div class="n_right">{{ info.create_by }}</div>
        <div class="n_right">{{ dayjs(info.create_time).format('YYYY-MM-DD HH:mm') }}</div>
      </template>
      <template #footer>
        <el-button type="primary" @click="openPreview = false">{{ $t('btn.submit') }}</el-button>
      </template>
    </zr-dialog>
  </div>
</template>

<script setup name="notice">
  import publishNoticeForm from '@/views/components/form/publishNoticeForm.vue'

  import { listNotice, delNotice, sendNotice } from '@/api/routine/notice'
  import { getCurrentInstance } from 'vue'
  import dayjs from 'dayjs'

  const { proxy } = getCurrentInstance()
  const noticeList = ref([])

  const loading = ref(true)
  const showSearch = ref(true)
  const ids = ref([])
  const single = ref(true)
  const multiple = ref(true)
  const total = ref(0)

  const data = reactive({
    form: {},
    queryParams: {
      pageNum: 1,
      pageSize: 10,
      noticeTitle: undefined,
      createBy: undefined,
      status: undefined
    },
    options: {
      sys_notice_type: [],
      sys_notice_status: []
    }
  })

  proxy.getDicts(['sys_notice_type', 'sys_notice_status']).then((response) => {
    response.data.forEach((element) => {
      data.options[element.dictType] = element.list
    })
  })

  const { queryParams, options } = toRefs(data)

  /** 查询公告列表 */
  function getList() {
    loading.value = true
    listNotice(queryParams.value).then((response) => {
      noticeList.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
      //console.log(response)
    })
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.value.pageNum = 1
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    proxy.resetForm('queryRef')
    handleQuery()
  }
  /** 多选框选中数据 */
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.noticeId)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }
  /** 新增按钮操作 */
  function handleAdd() {
    proxy.$refs.publishRef.handleAdd()
  }
  /**修改按钮操作 */
  function handleUpdate(row) {
    proxy.$refs.publishRef.handleUpdate(row)
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const Ids = row.noticeId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delNotice(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }
  // 发送通知
  function handleNotice(row) {
    const noticeId = row.noticeId || ids.value
    sendNotice(noticeId).then((res) => {
      proxy.$modal.msgSuccess(proxy.$t('common.tipSendSucceed'))
    })
  }
  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + proxy.$t('pnotice.notice'), proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.confirm'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(async () => {
        await proxy.downFile('/system/Notice/export', { ...queryParams })
      })
  }
  const openPreview = ref(false)
  const info = ref(undefined)
  const handleOpenPre = function (row) {
    openPreview.value = true
    info.value = { ...row }
  }

  getList()
</script>
<style>
  .n_right {
    text-align: right;
    margin: 10px;
  }
</style>