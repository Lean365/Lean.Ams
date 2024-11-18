<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryForm" :inline="true" v-show="showSearch" label-width="auto">
      <el-form-item :label="$t('ptask.name')" prop="jobName">
        <el-input v-model="queryParams.jobName"
          :placeholder="$t('btn.enterSearchPrefix')+$t('ptask.name')+$t('btn.enterSearchSuffix')" clearable
          style="width: 240px" @keyup.enter="handleQuery" />
      </el-form-item>
      <el-form-item :label="$t('ptask.taskGroup')" prop="jobGroup">
        <el-select v-model="queryParams.jobGroup"
          :placeholder="$t('btn.enterSearchPrefix')+$t('ptask.taskGroup')+$t('btn.enterSearchSuffix')" clearable
          style="width: 240px">
          <el-option v-for="dict in jobGroupOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('common.tipIsStated')" prop="isStated">
        <el-select v-model="queryParams.isStated"
          :placeholder="$t('btn.selectSearchPrefix')+$t('common.tipIsStated')+$t('btn.selectSearchSuffix')" clearable
          style="width: 240px">
          <el-option v-for="dict in statusOptions" :key="dict.dictValue" :label="dict.dictLabel"
            :value="dict.dictValue" />
        </el-select>
      </el-form-item>
      <el-form-item :label="$t('btn.run')">
        <el-date-picker v-model="dateRange" value-format="YYYY-MM-DD HH:mm:ss" type="datetimerange" range-separator="-"
          :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
          :shortcuts="dateOptions"></el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="delete" plain icon="delete" :disabled="multiple" @click="handleDelete"
          v-hasPermi="['routine:task:delete']"> {{ $t('btn.delete') }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="empty" plain icon="delete" @click="handleClean" :disabled="total <= 0"
          v-hasPermi="['routine:task:empty']"> {{ $t('btn.empty') }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="export" plain icon="download" @click="handleExport" v-hasPermi="['routine:task:export']"> {{
          $t('btn.export') }}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table v-loading="loading" :data="TasksqzLogList" @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column label="ID" width="80" align="center" prop="TasksqzLogId" />
      <el-table-column :label="$t('ptask.name')" align="center" prop="jobName" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('ptask.taskGroup')" align="center" prop="jobGroup" :formatter="jobGroupFormat"
        :show-overflow-tooltip="true" />
      <el-table-column :label="$t('ptask.invokeTarget')" align="center" prop="invokeTarget"
        :show-overflow-tooltip="true" />
      <el-table-column :label="$t('ptask.taskMessage')" align="center" prop="jobMessage"
        :show-overflow-tooltip="true" />
      <el-table-column :label="$t('common.tipIsStated')" align="center" prop="isStated">
        <template #default="scope">
          <dict-tag :options="statusOptions" :value="scope.row.isStated" />
        </template>
      </el-table-column>
      <el-table-column :label="$t('ptask.elapsed')" align="center" prop="elapsed">
        <template #default="scope">
          <span
            :style="scope.row.elapsed < 1000 ? 'color:green' : scope.row.elapsed < 3000 ? 'color:orange' : 'color:red'">
            {{ Math.floor(scope.row.elapsed) / 1000 }} s
          </span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('common.tipCreateTime')" align="center" prop="createTime" width="180">
        <template #default="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" class-name="small-padding fixed-width">
        <template #default="scope">
          <el-button type="view" plain size="small" icon="view" @click="handleView(scope.row)"
            :title="$t('btn.details')"></el-button>
        </template>
      </el-table-column>
    </el-table>

    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 调度日志详细 -->
    <el-dialog :title="$t('ptask.task')+' '+$t('btn.log')" v-model="open" width="700px" append-to-body>
      <el-form ref="formRef" :model="form" label-width="100px">
        <el-row>
          <el-col :span="12">
            <el-form-item label="ID：">{{ form.TasksqzLogId }}</el-form-item>
            <el-form-item :label="$t('ptask.name')+'：'">{{ form.jobName }}</el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item :label="$t('ptask.taskGroup')+'：'">{{ form.jobGroup }}</el-form-item>
            <el-form-item :label="$t('common.tipCreateTime')+'：'">{{ form.createTime }}</el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item :label="$t('ptask.invokeTarget')+'：'">{{ form.invokeTarget }}</el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item :label="$t('ptask.taskMessage')+'：'">{{ form.jobMessage }}</el-form-item>
          </el-col>
          <el-col :span="24">
            <el-form-item :label="$t('common.tipIsStated')+'：'">
              <div v-if="form.isStated == 0">{{$t('ptask.Normal')}}</div>
              <div v-else-if="form.isStated == 1">{{$t('ptask.Failure')}}</div>
            </el-form-item>
          </el-col>
          <el-col :span="24" v-if="form.isStated == 1">
            <el-form-item label="$t('ptask.exception')+'：'">{{ form.exception }}</el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="open = false">{{$t('btn.close')}}</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="tasklog">
  import { listTasksqzLog, delTasksqzLog, exportTasksqzLog, cleanTasksqzLog } from '@/api/monitor/tasksqzlog'
  const { proxy } = getCurrentInstance()
  const route = useRoute()

  const loading = ref(true)
  const ids = ref([])
  const multiple = ref(true)
  const showSearch = ref(true)
  const total = ref(0)
  const TasksqzLogList = ref([])
  const open = ref(false)
  const dateRange = ref([])
  const statusOptions = ref([])
  const jobGroupOptions = ref([])
  const formRef = ref()

  const data = reactive({
    form: {},
    queryParams: {
      pageNum: 1,
      pageSize: 10,
      jobName: undefined,
      jobGroup: undefined,
      isStated: undefined,
      jobId: undefined
    }
  })

  const { form, queryParams } = toRefs(data)
  queryParams.value.jobId = route.query.jobId

  proxy.getDicts('sys_job_status').then((response) => {
    statusOptions.value = response.data
  })
  proxy.getDicts('sys_job_group').then((response) => {
    jobGroupOptions.value = response.data
  })

  /** 查询调度日志列表 */
  function getList() {
    loading.value = true
    listTasksqzLog(proxy.addDateRange(queryParams.value, dateRange.value)).then((response) => {
      TasksqzLogList.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }

  // 任务组名字典翻译
  function jobGroupFormat(row, column) {
    return proxy.selectDictLabel(jobGroupOptions.value, row.jobGroup)
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
  function reset() {
    form.value = {
      createTime: undefined,
      elapsed: 0,
      exception: undefined,
      invokeTarget: undefined,
      jobGroup: undefined,
      jobId: 0,
      TasksqzLogId: 0,
      jobMessage: undefined,
      jobName: undefined,
      isStated: undefined
    }
    proxy.resetForm('formRef')
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.TasksqzLogId)
    multiple.value = !selection.length
  }
  /** 详细按钮操作 */
  function handleView(row) {
    reset()
    open.value = true
    form.value = row
    console.log(row)
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const TasksqzLogIds = ids.value
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + TasksqzLogIds + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delTasksqzLog(TasksqzLogIds)
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
        return cleanTasksqzLog()
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipEmptySucceed'))
      })
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + "<" + proxy.$t('ptask.taskLog') + ".xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return exportTasksqzLog(queryParams.value)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }
  handleQuery()
</script>