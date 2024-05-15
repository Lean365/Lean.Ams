<!--
 * @Descripttion: (用户在线时长/UserOnlineLog)
 * @Author: (admin)
 * @Date: (2024-03-27)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item :label="$t('psms.userid')" prop="userId">
        <el-input v-model.number="queryParams.userId" :placeholder="$t('btn.enter')+$t('psms.userid')" />
      </el-form-item>
      <el-form-item :label="$t('psms.userIP')" prop="userIP">
        <el-input v-model="queryParams.userIP" :placeholder="$t('btn.enter')+$t('psms.userIP')" />
      </el-form-item>
      <el-form-item :label="$t('btn.datetime')">
        <el-date-picker v-model="dateRangeAddTime" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['useronlinelog:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table :data="dataList" v-loading="loading" ref="table" border header-cell-class-name="el-table-header-cell"
      highlight-current-row @sort-change="sortChange">
      <el-table-column prop="connnectionId" label="Id" v-if="columns.showColumn('id')" />
      <el-table-column prop="userid" :label="$t('psms.userid')" align="center" v-if="columns.showColumn('userId')" />
      <el-table-column prop="name" :label="$t('ploginlog.userName')" align="center" />
      <el-table-column prop="platform" :label="$t('ploginlog.platform')" align="center" />
      <el-table-column prop="onlineTime" :label="$t('ploginlog.duration')" align="center"
        v-if="columns.showColumn('onlineTime')" />
      <el-table-column prop="todayOnlineTime" :label="$t('ploginlog.todayDuration')" align="center"
        v-if="columns.showColumn('onlineTime')" />
      <el-table-column prop="loginTime" :label="$t('ploginlog.loginTime')" width="170" :show-overflow-tooltip="true"
        v-if="columns.showColumn('loginTime')" />
      <el-table-column prop="createTime" :label="$t('ploginlog.loginTime')" width="170" :show-overflow-tooltip="true"
        v-if="columns.showColumn('loginTime')" />
      <el-table-column prop="location" :label="$t('psms.location')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('location')" />
      <el-table-column prop="userIP" :label="$t('psms.userIP')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('userIP')" />
      <el-table-column prop="remark" :label="$t('layout.description')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button type="danger" plain size="small" icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['useronlinelog:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />
  </div>
</template>

<script setup name="onlinelog">
  import { listOnlineLog, delOnlineLog } from '@/api/monitor/onlinelog.js'
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
    { visible: true, prop: 'userId', label: '用户id' },
    { visible: true, prop: 'onlineTime', label: '在线时长(分)' },
    { visible: true, prop: 'loginTime', label: '登录时间' },
    { visible: true, prop: 'location', label: '地址位置' },
    { visible: true, prop: 'userIP', label: '用户IP' },
    { visible: true, prop: 'remark', label: '备注' }
  ])
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
  // 结束时间时间范围
  const dateRangeAddTime = ref([])

  var dictParams = []

  function getList() {
    proxy.addDateRange(queryParams, dateRangeAddTime.value, 'AddTime')
    loading.value = true
    listOnlineLog(queryParams).then((res) => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
        //console.log(dataList.value)
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
      id: [{ required: true, message: 'Id不能为空', trigger: 'blur', type: 'number' }],
      userId: [{ required: true, message: '用户id不能为空', trigger: 'blur', type: 'number' }],
      onlineTime: [{ required: true, message: '在线时长(分)不能为空', trigger: 'blur', type: 'number' }]
    },
    options: {}
  })

  const { form, rules, options, single, multiple } = toRefs(state)

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.id || ids.value

    proxy
      .$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？', '警告', {
        confirmButtonText: proxy.$t('common.ok'),
        cancelButtonText: proxy.$t('common.cancel'),
        type: 'warning'
      })
      .then(function () {
        return delOnlineLog(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess('删除成功')
      })
  }

  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm('是否确认导出用户在线时长数据项?', '警告', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(async () => {
        await proxy.downFile('/monitor/UserOnlineLog/export', { ...queryParams })
      })
  }

  handleQuery()
</script>