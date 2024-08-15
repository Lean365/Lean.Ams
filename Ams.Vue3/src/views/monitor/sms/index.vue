<!--
 * @Descripttion: (短信验证码记录/smsCode_log)
 * @Author: (zz)
 * @Date: (2023-11-19)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-row :gutter="15" class="mb10">
        <el-col :lg="24">
          <el-form-item :label="$t('psms.userid')" prop="userid">
            <el-input v-model.number="queryParams.userid"
              :placeholder="$t('btn.enterSearchPrefix')+$t('psms.userid')+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item :label="$t('psms.phoneNum')" prop="phoneNum">
            <el-input v-model.number="queryParams.phoneNum"
              :placeholder="$t('btn.enterSearchPrefix')+$t('psms.phoneNum')+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item :label="$t('psms.sendTime')">
            <el-date-picker v-model="dateRangeAddTime" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item :label="$t('psms.sendType')" prop="sendType">
            <el-select clearable v-model="queryParams.sendType"
              :placeholder="$t('btn.selectSearchPrefix')+$t('psms.sendType')+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in options.sendTypeOptions" :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary)">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
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
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['smscodelog:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table :data="dataList" v-loading="loading" ref="table" border header-cell-class-name="el-table-header-cell"
      highlight-current-row @sort-change="sortChange">
      <el-table-column prop="id" label="Id" align="center" width="170" v-if="columns.showColumn('id')" />
      <el-table-column prop="userid" :label="$t('psms.userid')" align="center" v-if="columns.showColumn('userid')" />
      <el-table-column prop="userIP" :label="$t('psms.userIP')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('userIP')" />
      <el-table-column prop="location" :label="$t('psms.location')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('userIP')" />
      <el-table-column prop="phoneNum" :label="$t('psms.phoneNum')" align="center"
        v-if="columns.showColumn('phoneNum')" />
      <el-table-column prop="smsCode" :label="$t('psms.smsCode')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('smsCode')" />
      <el-table-column prop="smsContent" :label="$t('psms.smsContent')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('smsContent')" />
      <el-table-column prop="createTime" :label="$t('psms.sendTime')" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column prop="sendType" :label="$t('psms.sendType')" align="center"
        v-if="columns.showColumn('sendType')">
        <template #default="scope">
          <dict-tag :options="options.sendTypeOptions" :value="scope.row.sendType" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" width="120">
        <template #default="scope">
          <el-button type="danger" plain size="small" icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['smscodelog:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />
  </div>
</template>

<script setup name="smslog">
  import { listSmsLog, delSmsLog } from '@/api/monitor/smslog.js'
  const { proxy } = getCurrentInstance()
  const ids = ref([])
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    sort: 'Id',
    sortType: 'desc',
    userid: undefined,
    phoneNum: undefined,
    addTime: undefined,
    sendType: undefined
  })
  const columns = ref([
    { visible: true, prop: 'id', label: 'Id' },
    { visible: true, prop: 'smsCode', label: proxy.$t('psms.smsCode') },
    { visible: true, prop: 'userid', label: proxy.$t('psms.userid') },
    { visible: true, prop: 'phoneNum', label: proxy.$t('psms.phoneNum') },
    { visible: true, prop: 'smsContent', label: proxy.$t('psms.smsContent') },
    { visible: true, prop: 'createTime', label: proxy.$t('psms.sendTime') },
    { visible: true, prop: 'userIP', label: proxy.$t('psms.userIP') },
    { visible: true, prop: 'sendType', label: proxy.$t('psms.sendType') }
  ])
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // 添加时间时间范围
  const dateRangeAddTime = ref([])

  var dictParams = []

  function getList() {
    proxy.addDateRange(queryParams, dateRangeAddTime.value, 'CreateTime')
    loading.value = true
    listSmsLog(queryParams).then((res) => {
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
    // 添加时间时间范围
    dateRangeAddTime.value = []
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

  const state = reactive({
    single: true,
    multiple: true,
    form: {},
    options: {
      // 发送类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sendTypeOptions: [{ dictLabel: proxy.$t('plogin.btnLogin'), dictValue: '1' }]
    }
  })

  const { form, options } = toRefs(state)

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.id || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }
  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + proxy.$t('psms.smsLog'), proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/system/SmscodeLog/export', { ...queryParams })
      })
  }

  handleQuery()
</script>