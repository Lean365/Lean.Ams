<!--
 * @Descripttion: (用户在线时长/DurationLog)
 * @Author: (admin)
 * @Date: (2024-03-27)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-row :gutter="15" class="mb10">
        <el-col :lg="24">
          <el-form-item label="Id" prop="userId">
            <el-input v-model.number="queryParams.userId"
              :placeholder="$t('btn.enterSearchPrefix')+'User ID'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item :label="$t('ploginlog.ipaddr')" prop="userIP">
            <el-input v-model="queryParams.userIP"
              :placeholder="$t('btn.enterSearchPrefix')+$t('ploginlog.ipaddr')+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item :label="$t('ploginlog.loginTime')">
            <el-date-picker v-model="dateRangeCreateTime" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
        </el-col>
        <el-col :lg="24" :offset="12">
          <el-form-item>
            <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
            <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['DurationLog:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table :data="dataList" v-loading="loading" ref="table" border header-cell-class-name="el-table-header-cell"
      highlight-current-row @sort-change="sortChange">
      <el-table-column prop="id" label="Id" v-if="columns.showColumn('id')" />
      <el-table-column prop="userId" label="ID" align="center" v-if="columns.showColumn('userId')" />
      <el-table-column prop="nickName" :label="$t('ploginlog.userName')" align="center" />
      <el-table-column prop="platform" :label="$t('ploginlog.platform')" align="center" />
      <el-table-column prop="onlineTime" :label="$t('ploginlog.duration')" align="center"
        v-if="columns.showColumn('onlineTime')" />
      <el-table-column prop="todayOnlineTime" :label="$t('ploginlog.todayDuration')" align="center"
        v-if="columns.showColumn('onlineTime')" />
      <el-table-column prop="loginTime" :label="$t('ploginlog.loginTime')" width="170" :show-overflow-tooltip="true"
        v-if="columns.showColumn('loginTime')" />
      <el-table-column prop="location" :label="$t('psms.location')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('location')" />
      <el-table-column prop="userIP" :label="$t('ploginlog.ipaddr')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('userIP')" />
      <el-table-column prop="remark" :label="$t('common.tipRemarks')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="140" align="center">
        <template #default="scope">
          <el-button type="danger" plain size="small" icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['DurationLog:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />
  </div>
</template>

<script setup name="DurationLog">
  import { listDurationLog, delDurationLog } from '@/api/monitor/duration.js'
  const { proxy } = getCurrentInstance()
  const ids = ref([])
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    sort: 'Id',
    sortType: 'desc',
    userId: undefined,
    userIP: undefined
  })
  const columns = ref([
    { visible: false, prop: 'id', label: 'Id' },
    { visible: true, prop: 'userId', label: 'UserId' },
    { visible: true, prop: 'onlineTime', label: proxy.$t('ploginlog.duration') },
    { visible: true, prop: 'createTime', label: proxy.$t('ploginlog.loginTime') },
    { visible: true, prop: 'location', label: proxy.$t('psms.location') },
    { visible: true, prop: 'userIP', label: proxy.$t('ploginlog.ipaddr') },
    { visible: true, prop: 'remark', label: proxy.$t('common.tipRemarks') }
  ])
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
  // 结束时间时间范围
  const dateRangeCreateTime = ref([])

  var dictParams = []

  function getList() {
    proxy.addDateRange(queryParams, dateRangeCreateTime.value, 'LoginTime')
    loading.value = true
    listDurationLog(queryParams).then((res) => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
      }
    })
  }

  // 查询
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }

  // 重置查询操作
  function resetQuery() {
    proxy.resetForm('queryRef')
    handleQuery()
  }
  // 自定义排序
  function sortChange(column) {
    var sort = undefined
    var sortType = undefined

    if (column.prop != null && column.order != null) {
      sort = column.prop
      sortType = column.order
    }
    queryParams.sort = sort
    queryParams.sortType = sortType
    handleQuery()
  }

  /*************** form操作 ***************/
  const formRef = ref()
  const title = ref('')
  // 操作类型 1、add 2、edit 3、view
  const opertype = ref(0)
  const open = ref(false)
  const state = reactive({
    single: true,
    multiple: true,
    form: {},
    rules: {
      id: [{ required: true, message: 'Id' + proxy.$t('btn.isEmpty'), trigger: 'blur', type: 'number' }],
      userId: [{ required: true, message: 'User Id' + proxy.$t('btn.isEmpty'), trigger: 'blur', type: 'number' }],
      onlineTime: [{ required: true, message: proxy.$t('ploginlog.duration') + proxy.$t('btn.isEmpty'), trigger: 'blur', type: 'number' }]
    },
    options: {}
  })

  const { form, rules, options, single, multiple } = toRefs(state)

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.id || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delDurationLog(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }

  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + "<DurationLog.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/monitor/DurationLog/export', { ...queryParams })
      })
  }

  handleQuery()
</script>