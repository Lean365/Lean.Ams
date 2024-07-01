<template>
  <div class="app-container">
    <!-- 查询区域 -->
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('poperlog.title')" prop="title">
        <el-input v-model="queryParams.title"
          :placeholder="$t('btn.enterPrefix')+$t('poperlog.title')+$t('btn.enterSuffix')" clearable
          @keyup.enter="handleQuery" />
      </el-form-item>
      <el-form-item :label="$t('poperlog.operName')" prop="operName">
        <el-input v-model="queryParams.operName"
          :placeholder="$t('btn.enterPrefix')+$t('poperlog.operName')+$t('btn.enterSuffix')" clearable
          @keyup.enter="handleQuery" />
      </el-form-item>
      <el-form-item :label="$t('poperlog.businessType')" prop="businessType">
        <el-select v-model="queryParams.businessType"
          :placeholder="$t('btn.selectPrefix')+$t('poperlog.businessType')+$t('btn.selectSuffix')" clearable>
          <el-option v-for="dict in options.sys_oper_type" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('common.tipIsStated')" prop="isStated">
        <el-select v-model="queryParams.isStated" :placeholder="$t('btn.select')+$t('common.tipIsStated')" clearable>
          <el-option v-for="dict in options.sys_common_status" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('poperlog.operParam')" prop="operParam">
        <el-input v-model="queryParams.operParam" :placeholder="$t('btn.enter')+$t('poperlog.operParam')" clearable
          @keyup.enter="handleQuery" />
      </el-form-item>
      <el-form-item :label="$t('poperlog.operTime')">
        <el-date-picker v-model="dateRange" type="datetimerange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')" :default-time="defaultTime"
          value-format="YYYY-MM-DD HH:mm:ss" :shortcuts="dateOptions"></el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleQuery">{{$t('btn.search')}}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{$t('btn.reset')}}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="danger" plain icon="delete" :disabled="multiple" @click="handleDelete"
          v-hasPermi="['monitor:operlog:remove']" :title="$t('btn.delete')">
          {{$t('btn.delete')}}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="empty" plain icon="brush" @click="handleClean" v-hasPermi="['monitor:operlog:remove']"
          :title="$t('btn.empty')">{{$t('btn.empty')}}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="export" plain icon="download" @click="handleExport" v-hasPermi="['system:operlog:export']"
          :title="$t('btn.export')">{{$t('btn.export')}}
        </el-button>
      </el-col>
      <right-toolbar :showSearch="showSearch" :columns="columns" @queryTable="getList"></right-toolbar>
    </el-row>
    <!-- 数据区域 -->
    <el-table height="600" v-loading="loading" border :data="list" @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column label="ID" align="center" prop="operId" width="60px" :show-overflow-tooltip="true"
        v-if="columns.showColumn('operId')" />
      <el-table-column :label="$t('poperlog.title')" align="center" prop="title" :show-overflow-tooltip="true"
        v-if="columns.showColumn('title')" />
      <el-table-column prop="businessType" :label="$t('poperlog.businessType')" align="center"
        v-if="columns.showColumn('businessType')">
        <template #default="scope">
          <dict-tag :options="options.sys_oper_type" :value="scope.row.businessType" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('poperlog.requestMethod')" align="center" prop="requestMethod"
        v-if="columns.showColumn('requestMethod')" />
      <el-table-column :label="$t('poperlog.operName')" align="center" prop="operName"
        v-if="columns.showColumn('operName')" />

      <el-table-column :label="$t('poperlog.operIp')" prop="operIp" width="120">
        <template #default="{ row }">
          <div>{{ row.operLocation }}</div>
          <div>{{ row.operIp }}</div>
        </template>
      </el-table-column>
      <el-table-column :label="$t('common.tipIsStated')" align="center" prop="isStated"
        v-if="columns.showColumn('isStated')">
        <template #default="{ row }">
          <dict-tag :options="options.sys_common_status" :value="row.isStated"></dict-tag>
        </template>
      </el-table-column>
      <el-table-column :label="$t('poperlog.elapsed')" align="center" prop="elapsed"
        v-if="columns.showColumn('elapsed')">
        <template #default="scope">
          <span
            :style="scope.row.elapsed < 1000 ? 'color:green' : scope.row.elapsed < 3000 ? 'color:orange' : 'color:red'">
            {{ scope.row.elapsed }} ms
          </span>
        </template>
      </el-table-column>

      <el-table-column :label="$t('poperlog.errorMsg')" prop="errorMsg" width="220"
        v-if="columns.showColumn('errorMsg')" />
      <el-table-column :label="$t('poperlog.operTime')" prop="operTime" width="100"
        v-if="columns.showColumn('operTime')">
        <template #default="scope">
          <span>{{ scope.row.operTime }}</span>
        </template>
      </el-table-column>

      <el-table-column prop="method" :label="$t('poperlog.method')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('method')" />
      <el-table-column prop="operParam" :label="$t('poperlog.operParam')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('operParam')" />
      <el-table-column prop="jsonResult" :label="$t('poperlog.jsonResult')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('jsonResult')" />
      <el-table-column :label="$t('btn.operation')" align="center" class-name="small-padding fixed-width" width="140">
        <template #default="scope">
          <el-button-group>
            <el-button type="view" size="small" plain icon="view" @click="handleView(scope.row, scope.index)"
              v-hasPermi="['monitor:operlog:query']" :title="$t('btn.details')">

            </el-button>
            <el-button type="danger" size="small" plain icon="delete" @click="handleDelete(scope.row)"
              v-hasPermi="['monitor:operlog:remove']" :title="$t('btn.delete')"> </el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>

    <pagination v-show="total > 0" :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 操作日志详细 -->
    <el-dialog :title="$t('btn.details')" v-model="open" width="700px" append-to-body>
      <el-form ref="formRef" :model="form" label-width="100px">
        <el-row>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.title')">{{ form.title }} </el-form-item>
            <el-form-item :label="$t('poperlog.operIp')">
              <el-tag>{{ form.operName }}</el-tag> {{ form.operIp }} / {{ form.operLocation }}
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.operIp')">{{ form.operUrl }}</el-form-item>
            <el-form-item :label="$t('poperlog.requestMethod')">{{ form.requestMethod }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.method')">{{ form.method }}</el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.businessType')">
              <dict-tag :options="options.sys_oper_type" :value="form.businessType" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('common.tipIsStated')">
              <dict-tag :options="options.sys_common_status" :value="form.isStated"></dict-tag>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('poperlog.operTime')">{{ parseTime(form.operTime) }}</el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.operParam">
            <el-form-item l:label="$t('poperlog.operParam')">
              <el-input type="textarea" rows="5" v-model="form.operParam"> </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.jsonResult">
            <el-form-item :label="$t('poperlog.jsonResult')">
              <el-input type="textarea" rows="10" v-model="form.jsonResult"> </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('poperlog.errorMsg')" v-if="form.isStated === 1">
              <div class="text-danger">{{ form.errorMsg }}</div>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <el-button icon="close" @click="open = false">{{$t('btn.close')}}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="operlog">

  import { list as listOperLog, delOperlog, cleanOperlog } from '@/api/monitor/operlog'
  import dayjs from 'dayjs'
  const { proxy } = getCurrentInstance()
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
  // 是否显示弹出层
  const open = ref(false)

  // 日期范围
  const dateRange = ref([dayjs().format('YYYY-MM-DD 00:00:00'), dayjs().format('YYYY-MM-DD 23:59:59')])
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  const state = reactive({
    form: {},
    queryParams: {
      pageNum: 1,
      pageSize: 20,
      title: undefined,
      operName: undefined,
      businessType: undefined,
      status: undefined,
      operParam: undefined
    },
    options: {
      //业务类型（0其它 1新增 2修改 3删除）选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      businessTypeOptions: [],
      statusOptions: []
    }
  })
  const columns = ref([
    { visible: false, prop: 'operId', label: 'ID' },
    { visible: true, prop: 'title', label: proxy.$t('poperlog.title') },
    { visible: true, prop: 'businessType', label: proxy.$t('poperlog.businessType') },
    { visible: true, prop: 'requestMethod', label: proxy.$t('poperlog.requestMethod') },
    // { visible: true, prop: 'operatorType', label: '操作类型' },
    { visible: true, prop: 'operName', label: proxy.$t('poperlog.operName') },
    // { visible: true, prop: 'deptName', label: '部门' },
    // { visible: true, prop: 'operUrl', label: '请求地址' },
    // { visible: true, prop: 'operIP', label: '请求IP' },
    { visible: true, prop: 'isStated', label: proxy.$t('common.tipIsStated') },
    // { visible: true, prop: 'operLocation', label: '操作人地址' },
    { visible: true, prop: 'operTime', label: proxy.$t('poperlog.operTime') },
    { visible: false, prop: 'method', label: proxy.$t('poperlog.method') },
    { visible: false, prop: 'operParam', label: proxy.$t('poperlog.operParam') },
    { visible: false, prop: 'jsonResult', label: proxy.$t('poperlog.jsonResult') },
    { visible: true, prop: 'errorMsg', label: proxy.$t('poperlog.errorMsg') },
    { visible: false, prop: 'elapsed', label: proxy.$t('poperlog.elapsed') }
  ])
  const { form, queryParams, options } = toRefs(state)
  var dictParams = [{ dictType: 'sys_oper_type' }, { dictType: 'sys_common_status' }]
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  /** 查询登录日志 */
  function getList() {
    loading.value = true
    listOperLog(proxy.addDateRange(queryParams.value, dateRange.value)).then((response) => {
      loading.value = false
      if (response.code == 200) {
        list.value = response.data.result
        total.value = response.data.totalNum
      } else {
        total.value = 0
        list.value = []
      }
      //console.log(response)
    })
  }
  // 操作日志状态字典翻译
  function statusFormat(row, column) {
    return proxy.selectDictLabel(sys_common_status.value, row.status)
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.value.pageNum = 1
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
    ids.value = selection.map((item) => item.operId)
    multiple.value = !selection.length
  }
  const formRef = ref()
  /** 重置操作表单 */
  function reset() {
    form.value = {
      operId: undefined,
      title: undefined,
      businessType: undefined,
      method: undefined,
      requestMethod: undefined,
      operatorType: undefined,
      deptName: undefined,
      operUrl: undefined,
      operIp: undefined,
      operLocation: undefined,
      operParam: undefined,
      jsonResult: undefined,
      status: 0,
      errorMsg: undefined,
      operTime: undefined,
      elapsed: 0
    }
    proxy.resetForm('formRef')
  }
  /** 详细按钮操作 */
  function handleView(row) {
    reset()
    open.value = true
    form.value = row
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const operIds = row.operId || ids.value
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + operIds + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delOperlog(operIds)
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
        type: 'warning'
      })
      .then(function () {
        return cleanOperlog()
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipEmptySucceed'))
      })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + proxy.$t('poperlog.operLog'), proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/monitor/OperLog/export', { ...queryParams.value })
      })
  }
  handleQuery()
</script>