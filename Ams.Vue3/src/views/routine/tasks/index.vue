<template>
  <div class="app-container">
    <el-form :model="queryParams" inline @submit.prevent ref="queryRef" v-show="searchToggle">
      <el-form-item prop="taskType">
        <el-select clearable v-model="queryParams.taskType"
          :placeholder="$t('btn.selectSearchPrefix')+$t('ptask.taskType')+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in options.taskTypeOptions" :key="item.dictValue" :label="item.dictLabel"
            :value="parseInt(item.dictValue)" />
        </el-select>
      </el-form-item>
      <el-form-item prop="name">
        <el-input v-model="queryParams.name"
          :placeholder="$t('btn.enterSearchPrefix')+$t('ptask.name')+$t('btn.enterSearchSuffix')" clearable
          @keyup.enter="handleQuery" @clear="handleQuery" />
      </el-form-item>
      <el-form-item prop="isStart">
        <el-radio-group v-model="queryParams.isStart" @change="handleQuery()">
          <el-radio-button value="">{{$t('common.all')}}</el-radio-button>
          <el-radio-button :value="item.dictValue" v-for="item in options.isStartOptions">{{ item.dictLabel
            }}</el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-form-item prop="viewSwitch">
        <el-radio-group v-model="viewSwitch">
          <el-radio-button value="1">{{$t('btn.grid')}}</el-radio-button>
          <el-radio-button value="2">{{$t('btn.card')}}</el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="handleReset">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row class="mb8" :gutter="20">
      <el-col :span="1.5">
        <el-button v-hasPermi="['routine:task:add']" plain type="primary" icon="plus" @click="handleCreate">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['routine:task:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button plain v-hasPermi="['routine:task:query']" type="info" icon="operation" @click="onJobLogView()">
          {{ $t('btn.log') }}
        </el-button>
      </el-col>
      <right-toolbar :showSearch="searchToggle" :columns="columns" @queryTable="handleQuery"></right-toolbar>
    </el-row>
    <el-table v-if="viewSwitch == 1" ref="tasks" v-loading="loading" :data="dataTasks" border row-key="id"
      @sort-change="handleSortable">
      <!-- <el-table-column type="index" :index="handleIndexCalc" label="#" align="center" /> -->
      <el-table-column prop="id" label="id" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('id')" />
      <el-table-column prop="name" :label="$t('ptask.name')" width="100" />
      <el-table-column prop="taskType" :label="$t('ptask.taskType')" align="center"
        v-if="columns.showColumn('taskType')">
        <template #default="scope">
          <dict-tag :options="options.taskTypeOptions" :value="scope.row.taskType" />
        </template>
      </el-table-column>
      <el-table-column prop="triggerType" :label="$t('ptask.triggerType')" align="center"
        v-if="columns.showColumn('triggerType')">
        <template #default="scope">
          <dict-tag :options="options.triggerTypeOptions" :value="scope.row.triggerType" />
        </template>
      </el-table-column>
      <el-table-column sortable prop="isStart" align="center" :label="$t('common.tipIsStated')" width="100">
        <template #default="scope">
          <dict-tag :value="scope.row.isStart" :options="options.isStartOptions"></dict-tag>
        </template>
      </el-table-column>
      <el-table-column prop="jobGroup" :show-overflow-tooltip="true" align="center" :label="$t('ptask.taskGroup')"
        width="80" v-if="columns.showColumn('jobGroup')" />
      <el-table-column prop="assemblyName" :label="$t('ptask.assemblyName')" v-if="columns.showColumn('assemblyName')"
        :show-overflow-tooltip="true" />
      <el-table-column prop="className" :label="$t('ptask.className')" v-if="columns.showColumn('className')" />
      <el-table-column prop="runTimes" align="center" :label="$t('ptask.runTimes')" width="80" />
      <el-table-column prop="intervalSecond" align="center" :label="$t('ptask.intervalSecond')+'(s)'"
        v-if="columns.showColumn('intervalSecond')" width="90" />
      <el-table-column prop="cron" align="center" :label="$t('ptask.cron')" v-if="columns.showColumn('cron')"
        :show-overflow-tooltip="true" />
      <el-table-column prop="remark" align="center" :label="$t('common.tipRemarks')" v-if="columns.showColumn('remark')"
        :show-overflow-tooltip="true" />
      <el-table-column prop="jobParams" :label="$t('ptask.taskParams')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('jobParams')" />
      <el-table-column prop="lastRunTime" :label="$t('ptask.lastRunTime')" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('lastRunTime')" />
      <el-table-column prop="apiUrl" :label="$t('ptask.apiUrl')" v-if="columns.showColumn('apiUrl')" />
      <el-table-column :label="$t('btn.operation')" width="200" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button plain type="info" size="small" icon="view" v-hasPermi="['routine:task:query']"
              @click="handleDetails(scope.row)" :title="$t('btn.details')">

            </el-button>
            <el-button plain type="info" size="small" icon="operation" v-hasPermi="['routine:task:query']"
              @click="handleJobLog(scope.row)" :title="$t('btn.log')">

            </el-button>

            <el-dropdown @command="handleCommand($event, scope.row)">
              <el-button class="ml5" size="small" type="more" :title="$t('btn.more')">

                <el-icon class="el-icon--right">
                  <arrow-down />
                </el-icon>
              </el-button>

              <template #dropdown>
                <el-dropdown-menu>
                  <div v-hasPermi="['routine:task:run']" v-if="scope.row.isStart">
                    <el-dropdown-item command="run">
                      <el-button type="run" plain size="small" icon="remove" :title="$t('btn.runOnce')">
                      </el-button>
                    </el-dropdown-item>
                  </div>
                  <div v-if="scope.row.isStart" v-hasPermi="['routine:task:stop']">
                    <el-dropdown-item command="stop">
                      <el-button type="stop" plain size="small" icon="video-pause" :title="$t('btn.stop')">

                      </el-button>
                    </el-dropdown-item>
                  </div>
                  <div v-if="!scope.row.isStart" v-hasPermi="['routine:task:start']">
                    <el-dropdown-item command="start">
                      <el-button type="start" plain size="small" icon="video-play" :title="$t('btn.start')">

                      </el-button>
                    </el-dropdown-item>
                  </div>
                  <div v-if="!scope.row.isStart" v-hasPermi="['routine:task:edit']">
                    <el-dropdown-item command="update">
                      <el-button type="edit" plain size="small" icon="edit" :title="$t('btn.edit')">

                      </el-button>
                    </el-dropdown-item>
                  </div>
                  <div v-if="!scope.row.isStart" v-hasPermi="['routine:task:delete']">
                    <el-dropdown-item command="delete">
                      <el-button type="delete" plain size="small" icon="delete" :title="$t('btn.delete')">

                      </el-button>
                    </el-dropdown-item>
                  </div>
                </el-dropdown-menu>

              </template>
            </el-dropdown>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>

    <el-row :gutter="20" v-if="viewSwitch == 2">
      <el-col v-for="item in dataTasks" :lg="8" :span="24">
        <el-card :body-style="{ padding: '15px 15px 0' }">
          <el-descriptions :column="1" :title="item.name" size="small" border>
            <el-descriptions-item :label="$t('ptask.taskType')">
              <dict-tag :options="options.taskTypeOptions" :value="item.taskType" />
            </el-descriptions-item>
            <el-descriptions-item :label="$t('ptask.triggerType')" width="90px">
              <dict-tag :options="options.triggerTypeOptions" :value="item.triggerType" />
            </el-descriptions-item>
            <el-descriptions-item :label="$t('common.tipIsStated')" width="90px">
              <dict-tag :options="options.isStartOptions" :value="item.isStart"></dict-tag>
            </el-descriptions-item>
            <el-descriptions-item :label="$t('ptask.taskGroup')" width="90px">
              {{ item.jobGroup }}
            </el-descriptions-item>
            <el-descriptions-item :label="$t('ptask.assemblyName')" width="90px">
              {{ item.assemblyName }}
            </el-descriptions-item>
            <el-descriptions-item :label="$t('ptask.lastRunTime')" width="90px">
              {{ item.lastRunTime }}
            </el-descriptions-item>
            <el-descriptions-item :label="$t('ptask.cron')" width="90px">
              {{ item.cron }}
            </el-descriptions-item>
            <el-descriptions-item :label="$t('ptask.runTimes')" width="90px">
              {{ item.runTimes }}
            </el-descriptions-item>
            <el-descriptions-item :label="$t('ptask.taskType')" width="90px">
              {{ item.apiUrl }}
            </el-descriptions-item>
          </el-descriptions>
          <div>
            <el-button text icon="view" v-hasPermi="['routine:task:query']" @click="handleDetails(item)">
              {{ $t('btn.details') }}
            </el-button>
            <el-button text icon="view" v-hasPermi="['routine:task:query']" @click="handleJobLog(item)">
              {{ $t('btn.log') }}
            </el-button>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <pagination v-model:total="total" v-model:page="queryParams.PageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <el-dialog :title="title" v-model="open" width="600px" draggable append-to-body>
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row>
          <el-col :lg="24" v-if="form.id">
            <el-form-item label="ID">
              <div>{{ form.id }}</div>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('ptask.name')" maxlength="200" prop="name">
              <el-input v-model="form.name" :placeholder="$t('btn.enterPrefix')+$t('ptask.name')+$t('btn.enterSuffix')"
                show-word-limit maxlength="40" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('ptask.triggerType')" prop="triggerType">
              <el-select v-model="form.triggerType"
                :placeholder="$t('btn.selectPrefix')+$t('ptask.triggerType')+$t('btn.selectSuffix')"
                style="width: 100%">
                <el-option v-for="item in options.triggerTypeOptions" :key="item.dictValue" :label="item.dictLabel"
                  :value="parseInt(item.dictValue)" />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('ptask.taskGroup')" maxlength="200" prop="jobGroup">
              <el-select v-model="form.jobGroup"
                :placeholder="$t('btn.selectPrefix')+$t('ptask.taskGroup')+$t('btn.selectSuffix')">
                <el-option v-for="dict in options.jobGroupOptions" :key="dict.dictValue" :label="dict.dictLabel"
                  :value="dict.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('ptask.taskType')" prop="taskType">
              <el-radio-group v-model="form.taskType">
                <el-radio :value="1">{{$t('ptask.runassemblyName')}}</el-radio>
                <el-radio :value="2">{{$t('ptask.runapiUrl')}}</el-radio>
                <el-radio :value="3">{{$t('ptask.runsqlText')}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24" v-if="form.taskType == 2">
            <el-form-item :label="$t('ptask.apiUrl')" prop="apiUrl">
              <el-input v-model="form.apiUrl"
                :placeholder="$t('btn.enterPrefix')+$t('ptask.apiUrl')+$t('btn.enterSuffix')">
                <template #prepend>
                  <el-select v-model="form.requestMethod" :placeholder="$t('ptask.apiUrlmethod')" style="width: 125px">
                    <el-option label="GET" value="GET" />
                    <el-option label="POST" value="POST" />
                  </el-select>
                </template>
              </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.taskType == 3">
            <el-form-item :label="$t('ptask.SQLScript')" prop="sqlText">
              <el-input :rows="5" type="textarea" v-model="form.sqlText"
                :placeholder="$t('btn.enter')+$t('ptask.SQLScript')"> </el-input>
            </el-form-item>
          </el-col>
          <template v-if="form.taskType == 1">
            <el-col :lg="24">
              <el-form-item :label="$t('ptask.assemblyName')" maxlength="200" prop="assemblyName">
                <el-input v-model="form.assemblyName"
                  :placeholder="$t('btn.enterPrefix')+$t('ptask.assemblyName')+$t('btn.enterSuffix')" show-word-limit
                  maxlength="80" />
              </el-form-item>
            </el-col>
            <el-col :lg="24">
              <el-form-item :label="$t('ptask.className')" maxlength="200" prop="className">
                <el-input v-model="form.className"
                  :placeholder="$t('btn.enterPrefix')+$t('ptask.className')+$t('btn.enterSuffix')" show-word-limit
                  maxlength="80" />
              </el-form-item>
            </el-col>
          </template>

          <el-col :lg="24">
            <el-form-item :label="$t('ptask.taskParams')" prop="jobParams">
              <template #label>
                <span>
                  <el-tooltip content="eg：{ token: abc123} or token=abc123&uid=1000" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{$t('ptask.taskParams')}}
                </span>
              </template>

              <el-input v-model="form.jobParams"
                :placeholder="$t('btn.enterPrefix')+$t('ptask.taskParams')+$t('btn.enterSuffix')" show-word-limit
                maxlength="180" />
            </el-form-item>
          </el-col>
          <el-col :lg="24" v-if="form.triggerType == 1">
            <el-form-item :label="$t('ptask.cron')" prop="cron">
              <el-input v-model="form.cron" :placeholder="$t('btn.enterPrefix')+$t('ptask.cron')+$t('btn.enterSuffix')">
                <template #append>
                  <el-button type="primary" @click="handleShowCron" style="width: 220px" align="center">
                    <el-icon>
                      <timer />
                    </el-icon>
                    {{$t('ptask.CronGen')}}
                  </el-button>
                </template>
              </el-input>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('btn.dateStart')" prop="beginTime">
              <template #label>
                <span>
                  <el-tooltip :content="$t('ptask.beginTimeMemo')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                  {{$t('btn.dateStart')}}
                </span>
              </template>
              <el-date-picker v-model="form.beginTime" style="width: 100%" type="date"
                :placeholder="$t('btn.selectPrefix')+$t('btn.dateStart')+$t('btn.selectSuffix')" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item :label="$t('btn.dateEnd')" prop="endTime">
              <el-date-picker v-model="form.endTime" style="width: 100%" type="date"
                :placeholder="$t('btn.selectPrefix')+$t('btn.dateEnd')+$t('btn.selectSuffix')" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item v-show="form.triggerType == 0" :label="$t('ptask.intervalSecond')" prop="intervalSecond">
              <el-input-number v-model="form.intervalSecond" :max="9999999999" step-strictly controls-position="right"
                :min="1" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('common.tipRemarks')" prop="remark">
              <el-input type="textarea" v-model="form.remark" show-word-limit maxlength="400" />
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item :label="$t('ptask.lastRunTime')" prop="lastRunTime">
              {{ form.lastRunTime }}
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer v-if="btnVisible">
        <div class="dialog-footer">
          <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>

    <el-dialog :title="$t('ptask.CronGen')" v-model="openCron" append-to-body destroy-on-close>
      <crontab ref="crontabRef" @hide="openCron = false" @fill="crontabFill" :expression="expression"></crontab>
    </el-dialog>

    <el-drawer :title="logTitle" v-model="drawer">
      <el-form :inline="true" @submit.prevent>
        <el-form-item>
          <el-date-picker v-model="logForm.beginTime" :placeholder="$t('btn.dateselect')" clearable type="date" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" icon="search" @click="handleJobLog">{{ $t('btn.search') }}</el-button>
        </el-form-item>
      </el-form>

      <el-timeline>
        <el-timeline-item :timestamp="item.createTime" placement="top" v-for="(item, i) in jobLogList" :key="i">
          <h4>{{ item.jobMessage }}</h4>
          <p style="color: red">{{ item.exception }}</p>
        </el-timeline-item>
      </el-timeline>
      <el-empty v-if="jobLogList.length <= 0"></el-empty>
    </el-drawer>
  </div>
</template>

<script setup name="job">
  import { queryTasks, getTasks, createTasks, updateTasks, deleteTasks, startTasks, stopTasks, runTasks, exportTasks } from '@/api/routine/tasksqz'
  import { listTasksqzLog } from '@/api/monitor/tasksqzlog'
  import Crontab from '@/components/Crontab'

  const router = useRouter()
  const { proxy } = getCurrentInstance()
  // 是否显示Cron表达式弹出层
  const openCron = ref(false)
  // 传入的表达式
  const expression = ref('')
  const drawer = ref(false)
  // 是否显示弹出层
  const open = ref(false)
  // 表单标题
  const title = ref('')
  // 显示搜索
  const searchToggle = ref(true)
  // 合计条数
  const total = ref(0)
  // 遮罩层
  const loading = ref(false)
  // 查询参数
  const queryParams = reactive({
    queryText: undefined,
    PageNum: 1,
    pageSize: 10,
    orderby: '',
    sort: '',
    taskType: undefined,
    isStart: ''
  })
  const columns = ref([
    // { visible: true, prop: 'name', label: '名称' },
    { visible: true, prop: 'taskType', label: proxy.$t('ptask.taskType') },
    { visible: true, prop: 'triggerType', label: proxy.$t('ptask.triggerType') },
    { visible: true, prop: 'jobGroup', label: proxy.$t('ptask.taskGroup') },
    { visible: true, prop: 'assemblyName', label: proxy.$t('ptask.assemblyName') },
    { visible: true, prop: 'className', label: proxy.$t('ptask.className') },
    { visible: true, prop: 'lastRunTime', label: proxy.$t('ptask.lastRunTime') },
    { visible: false, prop: 'remark', label: proxy.$t('common.tipRemarks') },
    { visible: false, prop: 'id', label: 'ID' },
    { visible: false, prop: 'cron', label: proxy.$t('ptask.cron') },
    // { visible: true, prop: 'runTimes', label: '运行次数' },
    // { visible: false, prop: 'beginTime', label: '开始时间' },
    // { visible: false, prop: 'endTime', label: '结束时间' },
    { visible: false, prop: 'intervalSecond', label: proxy.$t('ptask.intervalSecond') },
    // { visible: false, prop: 'isStart', label: '是否启动' },
    { visible: false, prop: 'jobParams', label: proxy.$t('ptask.taskParams') },
    { visible: false, prop: 'apiUrl', label: proxy.$t('ptask.apiUrl') }
    // { visible: false, prop: 'sqlText', label: 'sql脚本' }
  ])
  // 计划任务列表
  const dataTasks = ref([])
  // 任务日志列表
  const jobLogList = ref([])
  const logTitle = ref('')
  const formRef = ref(null)
  const queryRef = ref(null)
  const viewSwitch = ref(1)
  const state = reactive({
    form: {},
    // 表单校验
    rules: {
      name: [{ required: true, message: proxy.$t('ptask.name') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      jobGroup: [{ required: true, message: proxy.$t('ptask.taskGroup') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      assemblyName: [{ required: true, message: proxy.$t('ptask.assemblyName') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      className: [{ required: true, message: proxy.$t('ptask.className') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      triggerType: [{ required: true, message: proxy.$t('ptask.triggerType') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      apiUrl: [{ required: true, message: proxy.$t('ptask.apiUrl') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      cron: [{ required: true, message: proxy.$t('ptask.cron') + proxy.$t('btn.isEmpty'), trigger: 'change' }],
      beginTime: [{ required: false, message: proxy.$t('ptask.beginTime') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      endTime: [{ required: false, message: proxy.$t('ptask.endTime') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      intervalSecond: [{ message: proxy.$t('ptask.intervalSecond') + proxy.$t('btn.isEmpty'), type: 'number', trigger: 'blur' }],
      sqlText: [{ required: true, message: proxy.$t('ptask.SQLScript') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      requestMethod: [{ required: true, message: proxy.$t('ptask.requestMethod') + proxy.$t('btn.isEmpty'), trigger: 'blur' }]
    },
    options: {
      // 触发器类型
      triggerTypeOptions: [
        { dictLabel: proxy.$t('ptask.general'), dictValue: '0' },
        { dictLabel: proxy.$t('ptask.expression'), dictValue: '1' }
      ],
      taskTypeOptions: [
        { dictLabel: proxy.$t('ptask.runassemblyName'), dictValue: '1' },
        { dictLabel: proxy.$t('ptask.runapiUrl'), dictValue: '2', listClass: 'danger' },
        { dictLabel: proxy.$t('ptask.runsqlText'), dictValue: '3', listClass: 'info' }
      ],
      // 任务状态字典
      isStartOptions: [
        { dictLabel: proxy.$t('btn.running'), dictValue: '1', listClass: 'success' },
        { dictLabel: proxy.$t('btn.stopped'), dictValue: '0', listClass: 'danger' }
      ],
      // 任务组名字典
      jobGroupOptions: []
    }
  })
  // 按钮是否可见
  const btnVisible = ref(true)
  const { rules, form, options } = toRefs(state)

  /** 查询计划任务列表 */
  function getList() {
    loading.value = true
    queryTasks(queryParams).then((response) => {
      dataTasks.value = response.data.result
      total.value = response.data.totalNum
      loading.value = false
    })
  }
  function handleQuery() {
    getList()
  }
  /** 重置按钮操作 */
  function handleReset() {
    proxy.resetForm('queryRef')
    getList()
  }
  /** 新增按钮操作 */
  function handleCreate() {
    reset()
    btnVisible.value = true
    open.value = true
    title.value = proxy.$t('btn.add') + ' ' + proxy.$t('ptask.task')
  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    btnVisible.value = true
    getTasks(row.id).then((res) => {
      form.value = res.data
      open.value = true
      title.value = proxy.$t('btn.edit') + ' ' + proxy.$t('ptask.task')
    })
  }

  /** cron表达式按钮操作 */
  function handleShowCron() {
    expression.value = form.value.cron
    openCron.value = true
  }
  /** 确定后回传值 */
  function crontabFill(value) {
    form.value.cron = value
  }

  // 启动按钮
  function handleStart(row) {
    startTasks(row.id).then((response) => {
      if (response.code === 200) {
        proxy.$modal.msgSuccess(response.msg)
        open.value = false
        getList()
      }
    })
  }
  // 停止按钮
  function handleStop(row) {
    stopTasks(row.id).then((response) => {
      if (response.code === 200) {
        proxy.$modal.msgSuccess(response.msg)
        open.value = false
        getList()
      }
    })
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const jobInfo = row

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + jobInfo.name + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(() => {
        deleteTasks(jobInfo.id).then((response) => {
          if (response.code === 200) {
            getList()
            proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
          }
        })
      })
      .catch(function () { })
  }
  /* 立即执行一次 */
  function handleRun(row) {
    const jobInfo = row

    proxy
      .$confirm(proxy.$t('ptask.runOnceMemo') + jobInfo.name + proxy.$t('ptask.runOnceTaskMemo'), proxy.$t('btn.start') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then((res) => {
        runTasks(jobInfo.id).then((res) => {
          if (res.code === 200) {
            proxy.$modal.msgSuccess(proxy.$t('ptask.runCompleted'))
            getList()
          }
        })
      })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.id !== undefined) {
          updateTasks(form.value).then((response) => {
            if (response.code === 200) {
              proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
              open.value = false
              getList()
            }
          })
        } else {
          createTasks(form.value).then((response) => {
            if (response.code === 200) {
              proxy.$modal.msgSuccess(proxy.$t('common.tipAddSucceed'))
              open.value = false
              getList()
            }
          })
        }
      }
    })
  }
  // 排序操作
  function handleSortable(column) {
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
  // 表单重置
  function reset() {
    form.value = {
      id: undefined,
      name: undefined,
      jobGroup: undefined,
      assemblyName: 'Ams.Tasks',
      className: undefined,
      jobParams: undefined,
      triggerType: 1,
      beginTime: undefined,
      endTime: undefined,
      intervalSecond: 1,
      cron: undefined,
      taskType: 1,
      requestMethod: 'GET'
    }
    proxy.resetForm('formRef')
  }

  // 取消按钮
  function cancel() {
    open.value = false
    reset()
  }
  /** 导出按钮操作 */
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + "<" + proxy.$t('ptask.task') + ".xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(() => {
        return exportTasks()
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }

  getList()
  proxy.getDicts('sys_tasks_group').then((response) => {
    state.options.jobGroupOptions = response.data
  })

  watch(
    () => form.value.triggerType,
    (val) => {
      if (val == 0) {
        form.value.cron = ''
      }
    },
    {
      deep: true,
      immediate: true
    }
  )

  /** 任务日志 */

  const logForm = reactive({
    beginTime: undefined,
    jobId: undefined,
    title: undefined
  })
  function onJobLogView() {
    router.push({ path: '/monitor/log' })
  }
  /** 任务日志列表查询 */
  function handleJobLog(row) {
    if (undefined != row.id) {
      logForm.jobId = row.id
      logForm.title = row.name
    }

    drawer.value = true
    jobLogList.value = []
    logTitle.value = logForm.title
    listTasksqzLog(logForm).then((response) => {
      jobLogList.value = response.data.result
    })
  }
  function handleDetails(row) {
    reset()
    getTasks(row.id).then((res) => {
      form.value = res.data
      open.value = true
      title.value = proxy.$t('btn.details') + ' ' + proxy.$t('ptask.task')
      btnVisible.value = false
    })
  }

  function handleCommand(command, row) {
    console.log(command, row)
    switch (command) {
      case 'update':
        handleUpdate(row)
        break
      case 'start':
        handleStart(row)
        break
      case 'stop':
        handleStop(row)
        break
      case 'delete':
        handleDelete(row)
        break
      case 'run':
        handleRun(row)
        break
    }
  }
</script>