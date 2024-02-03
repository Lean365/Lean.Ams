<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @Author: (Lean365)
 * @Date: (2024/1/6 10:53:01)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>

      <el-form-item label="生产日期">
        <el-date-picker v-model="dateRangePomMfgDate" type="datetimerange" start-placeholder="开始日期"
          end-placeholder="结束日期" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产机种" prop="PomMfgModel">
        <el-select clearable filterable v-model="queryParams.PomMfgModel" :placeholder="$t('btn.select')+'生产机种'">
          <el-option v-for="item in  options.sql_moc_model " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['statistics:output:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->


    <el-table :data="dataList" border hight="200">
      <el-table-column prop="mfgDate" label="日期"></el-table-column>


      <el-table-column prop="mfgModel" label="机种"></el-table-column>

      <el-table-column prop="stdTime" label="ST"></el-table-column>
      <el-table-column prop="direct" label="直接"></el-table-column>

      <el-table-column prop="stdOutputQty" label="产能"></el-table-column>
      <el-table-column prop="realOutputQty" label="实绩"></el-table-column>
      <el-table-column prop="realWorkhours" label="工数"></el-table-column>
      <!-- <el-table-column prop="inputsWorkhours" label="投入"></el-table-column> -->
      <el-table-column prop="realWorktime" label="实绩ST"></el-table-column>
      <el-table-column prop="realWorkinghoursDiff" label="ST差异"></el-table-column>
      <el-table-column prop="realOutputDiff" label="台数差异"></el-table-column>
      <el-table-column prop="achievedRate" label="达成率">
        <template #default="scope">
          {{ scope.row. achievedRate}}%
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />



    <!-- 添加或修改oph主表对话框 -->

  </div>
</template>

<script setup name="monthmodeloutput">
  import {
    GetCountMonthModelOutput, GetExportMonthModelOutput
  }
    from '@/api/statistics/output.js'
  const { proxy } = getCurrentInstance()
  //字典参数
  var dictParams = [

    { dictType: "sql_moc_model" },

  ]
  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const state = reactive({
    single: true,
    multiple: true,
    form: {},
    rules: {

    },
    options: {
      // 生产班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_model: [],

    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)
  const ids = ref([])
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    sort: '',
    sortType: 'asc',
    mfgDate: undefined,
    stdOutputQty: undefined,
    realOutputQty: undefined,
    achievedRate: undefined,
  })


  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // 生产日期时间范围
  const dateRangePomMfgDate = ref([])

  function getList() {
    proxy.addDateRange(queryParams, dateRangePomMfgDate.value, 'PomMfgDate');
    loading.value = true
    GetCountMonthModelOutput(queryParams).then(res => {
      const { code, data } = res
      if (code == 200) {
        console.log(data)
        dataList.value = data

        loading.value = false
      }
    })
  }

  // 查询
  // 查询
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  // 重置查询操作
  function resetQuery() {
    // 生产日期时间范围
    dateRangePomMfgDate.value = []
    proxy.resetForm("queryRef")
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


  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.confirmExport') + proxy.$t('pstat.monthLineOph'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: 'warning'
      })
      .then(function () {
        return GetExportMonthModelOutput(queryParams)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }

  handleQuery()
</script>