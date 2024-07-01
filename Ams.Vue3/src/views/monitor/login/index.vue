<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('ploginlog.ipaddr')" prop="ipaddr">
        <el-input v-model="queryParams.ipaddr"
          :placeholder="$t('btn.enterPrefix')+$t('ploginlog.ipaddr')+$t('btn.enterSuffix')" clearable
          @keyup.enter="handleQuery" />
      </el-form-item>
      <el-form-item :label="$t('ploginlog.userName')" prop="userName">
        <el-input v-model="queryParams.userName"
          :placeholder="$t('btn.enterPrefix')+$t('ploginlog.userName')+$t('btn.enterSuffix')" clearable
          @keyup.enter="handleQuery" />
      </el-form-item>
      <el-form-item :label="$t('ploginlog.isStated')" prop="isStated">
        <el-select v-model="queryParams.isStated"
          :placeholder="$t('btn.selectPrefix')+$t('ploginlog.isStated')+$t('btn.selectSuffix')" clearable>
          <el-option v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('ploginlog.loginTime')">
        <el-date-picker v-model="dateRange" type="daterange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"></el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" :disabled="multiple" @click="handleDelete"
          v-hasPermi="['monitor:logininfor:remove']" :title="$t('btn.delete')">{{$t('btn.delete')}}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="empty" plain icon="delete" @click="handleClean" v-hasPermi="['monitor:logininfor:remove']"
          :title="$t('btn.empty')">{{$t('btn.empty')}}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="export" plain icon="download" @click="handleExport" v-hasPermi="['system:logininfor:export']"
          :title="$t('btn.export')">{{$t('btn.export')}}</el-button>
      </el-col>
      <right-toolbar :showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <el-table v-loading="loading" :data="list" border @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column label="ID" align="center" prop="infoId" width="80" />
      <el-table-column :label="$t('ploginlog.userName')" align="center" prop="userName" />
      <el-table-column :label="$t('ploginlog.ipaddr')" align="center" prop="ipaddr" width="130">
        <template #default="{ row }">
          <div>{{ row.loginLocation }}</div>
          <div>{{ row.ipaddr }}</div>
        </template>
      </el-table-column>
      <!-- <el-table-column label="登录地点" align="center" prop="loginLocation"  /> -->
      <el-table-column :label="$t('ploginlog.browser')" align="center" prop="browser" />
      <el-table-column :label="$t('ploginlog.os')" align="center" prop="os" />
      <el-table-column :label="$t('ploginlog.isStated')" align="center" prop="isStated">
        <template #default="{ row }">
          <dict-tag :options="statusOptions" :value="row.isStated"></dict-tag>
        </template>
      </el-table-column>
      <el-table-column :label="$t('ploginlog.msg')" align="center" prop="msg" />
      <el-table-column :label="$t('ploginlog.loginTime')" align="center" prop="loginTime" width="180">
        <template #default="scope">
          <span>{{ scope.row.loginTime }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button type="danger" plain size="small" icon="delete" @click="handleDelete(scope.row)"
            :title="$t('btn.delete')"></el-button>
        </template>
      </el-table-column>
    </el-table>

    <pagination v-show="total > 0" :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />
  </div>
</template>

<script setup name="LoginLog">
  import { list as queryList, delLoginLog, cleanLoginLog, exportLoginLog } from '@/api/monitor/loginlog'
  import { showTime } from '@/utils'
  // 遮罩层
  const loading = ref(true)
  // 选中数组
  const ids = ref([])
  // 非多个禁用
  const multiple = ref(true)
  // 显示搜索条件
  const showSearch = ref(true)
  // 总条数
  const total = ref(0)
  // 表格数据
  const list = ref([])
  // 状态数据字典
  const statusOptions = ref([])
  // 日期范围
  const dateRange = ref([])
  // 查询参数
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    ipaddr: undefined,
    userName: undefined,
    status: undefined
  })

  const { proxy } = getCurrentInstance()
  /** 查询登录日志列表 */
  function getList() {
    loading.value = true
    queryList(proxy.addDateRange(queryParams, dateRange.value)).then((response) => {
      loading.value = false
      if (response.code == 200) {
        list.value = response.data.result
        total.value = response.data.totalNum
      } else {
        total.value = 0
        list.value = []
      }
    })
  }
  // 登录状态字典翻译
  function statusFormat(row, column) {
    return proxy.selectDictLabel(statusOptions.value, row.status)
  }
  getList()
  proxy.getDicts('sys_common_status').then((response) => {
    statusOptions.value = response.data
  })

  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    dateRange.value = []
    proxy.resetForm('queryForm')
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.infoId)
    multiple.value = !selection.length
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const infoIds = row.infoId || ids.value
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + infoIds + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delLoginLog(infoIds)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }
  /** 清空按钮操作 */
  function handleClean() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmEmpty'), proxy.$t('btn.empty') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return cleanLoginLog()
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipEmptySucceed'))
      })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + '<' + proxy.$t('ploginlog.loginLog') + '.xlsx>', proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return exportLoginLog(queryParams)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
</script>