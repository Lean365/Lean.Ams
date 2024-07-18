<!--
 * @Descripttion: 预算实际明细/fico_budget_actual_cost
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/16 11:42:06
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="年月" prop="fbYm">
            <el-select filterable clearable v-model="queryParams.fbYm"
              :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_ficoym_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="公司代码" prop="fbCorpCode">
            <el-select filterable clearable v-model="queryParams.fbCorpCode"
              :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="统计类别" prop="fbExpCategory">
            <el-select filterable clearable v-model="queryParams.fbExpCategory"
              :placeholder="$t('btn.selectSearchPrefix')+'统计类别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_costs_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
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
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetactualcost:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoBudgetActualCost/importTemplate"
                  importUrl="/Accounting/FicoBudgetActualCost/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:budgetactualcost:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="600px" :data="dataList" v-loading="loading" ref="table"
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange">
      <el-table-column prop="fbSFID" label="SFID" align="center" v-if="columns.showColumn('fbSFID')" />
      <el-table-column prop="fbFy" label="期间" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbFy')" />
      <el-table-column prop="fbYm" label="年月" align="center" v-if="columns.showColumn('fbYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ficoym_list " :value="scope.row.fbYm" />
        </template>
      </el-table-column>
      <el-table-column prop="fbCorpCode" label="公司代码" align="center" v-if="columns.showColumn('fbCorpCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.fbCorpCode" />
        </template>
      </el-table-column>
      <el-table-column prop="fbCorpName" label="公司名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbCorpName')" />
      <el-table-column prop="fbExpCategory" label="统计类别" align="center" v-if="columns.showColumn('fbExpCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_costs_type " :value="scope.row.fbExpCategory" />
        </template>
      </el-table-column>
      <el-table-column prop="fbCostCode" label="成本代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbCostCode')" />
      <el-table-column prop="fbCostName" label="成本名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbCostName')" />
      <el-table-column prop="fbTitleCode" label="科目代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbTitleCode')" />
      <el-table-column prop="fbTitleName" label="科目名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbTitleName')" />
      <el-table-column prop="fbTitleNote" label="科目分类" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbTitleNote')" />
      <el-table-column prop="fbBudgetAmt" label="预算" align="center" v-if="columns.showColumn('fbBudgetAmt')" />
      <el-table-column prop="fbActualAmt" label="实际" align="center" v-if="columns.showColumn('fbActualAmt')" />
      <el-table-column prop="fbDiffAmt" label="差异" align="center" v-if="columns.showColumn('fbDiffAmt')" />
      <el-table-column prop="fbAccountant" label="会计人员" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbAccountant')" />
      <el-table-column prop="fbBalanceDate" label="日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbBalanceDate')" />
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createBy')" />
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateBy')" />
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateTime')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

  </div>
</template>

<script setup name="ficobudgetactualcost">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoBudgetActualCost,

    getFicoBudgetActualCost,
  }
    from '@/api/accounting/ficobudgetactualcost.js'
  import importData from '@/components/ImportData'
  //防抖处理函数 import { debounce } from 'lodash';
  import { debounce } from 'lodash';
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  //标签页
  const activeName = ref('first')
  const handleClick = (tab, event) => {
    console.log(tab, event)
  }
  //选中refId数组数组
  const ids = ref([])
  //是否加载动画
  const loading = ref(false)
  //显示搜索条件
  const showSearch = ref(true)
  //使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 56,
    sort: '',
    sortType: 'asc',
    //是否查询（1是）
    fbYm: undefined,
    //是否查询（1是）
    fbCorpCode: undefined,
    //是否查询（1是）
    fbExpCategory: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'fbSFID', label: 'SFID' },
    { visible: false, prop: 'fbFy', label: '期间' },
    { visible: true, prop: 'fbYm', label: '年月' },
    { visible: true, prop: 'fbCorpCode', label: '公司代码' },
    { visible: false, prop: 'fbCorpName', label: '公司名称' },
    { visible: true, prop: 'fbExpCategory', label: '统计类别' },
    { visible: true, prop: 'fbCostCode', label: '成本代码' },
    { visible: true, prop: 'fbCostName', label: '成本名称' },
    { visible: true, prop: 'fbTitleCode', label: '科目代码' },
    { visible: true, prop: 'fbTitleName', label: '科目名称' },
    { visible: true, prop: 'fbTitleNote', label: '科目分类' },
    { visible: true, prop: 'fbBudgetAmt', label: '预算' },
    { visible: true, prop: 'fbActualAmt', label: '实际' },
    { visible: true, prop: 'fbDiffAmt', label: '差异' },
    { visible: false, prop: 'fbAccountant', label: '会计人员' },
    { visible: false, prop: 'fbBalanceDate', label: '日期' },
    { visible: false, prop: 'remark', label: '说明' },
    { visible: false, prop: 'createBy', label: '创建者' },
    { visible: false, prop: 'createTime', label: '创建时间' },
    { visible: false, prop: 'updateBy', label: '更新者' },
    { visible: false, prop: 'updateTime', label: '更新时间' },
  ])
  // 记录数
  const total = ref(0)
  //定义数据变量
  const dataList = ref([])
  //查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
























  //字典参数
  var dictParams = [
    { dictType: "sql_ficoym_list" },
    { dictType: "sys_crop_list" },
    { dictType: "sys_costs_type" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从预算实际明细/fico_budget_actual_cost表记录数据
  function getList() {
    loading.value = true
    listFicoBudgetActualCost(queryParams).then(res => {
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
  //定义响应式变量
  const formRef = ref()
  //弹出层标题
  const title = ref('')

  // 操作类型 1、add 2、edit 3、view
  //定义响应式变量
  const opertype = ref(0)
  //定义对话框打开或关闭
  const open = ref(false)
  //reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const state = reactive({
    single: true,
    multiple: true,
    form: {},
    rules: {
      fbSFID: [{ required: true, message: "SFID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbFy: [{ required: true, message: "期间" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbYm: [{ required: true, message: "年月" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      fbCorpCode: [{ required: true, message: "公司代码" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      fbCorpName: [{ required: true, message: "公司名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbExpCategory: [{ required: true, message: "统计类别" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      fbCostCode: [{ required: true, message: "成本代码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbCostName: [{ required: true, message: "成本名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbTitleCode: [{ required: true, message: "科目代码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbTitleName: [{ required: true, message: "科目名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbTitleNote: [{ required: true, message: "科目分类" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbBudgetAmt: [{ required: true, message: "预算" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbActualAmt: [{ required: true, message: "实际" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbDiffAmt: [{ required: true, message: "差异" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbAccountant: [{ required: true, message: "会计人员" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      fbBalanceDate: [{ required: true, message: "日期" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ficoym_list: [],
      // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_crop_list: [],
      // 统计类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_costs_type: [],
      // 删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_deleted: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      fbSFID: 0,
      fbFy: null,
      fbYm: null,
      fbCorpCode: null,
      fbCorpName: null,
      fbExpCategory: null,
      fbCostCode: null,
      fbCostName: null,
      fbTitleCode: null,
      fbTitleName: null,
      fbTitleNote: null,
      fbBudgetAmt: 0,
      fbActualAmt: 0,
      fbDiffAmt: 0,
      fbAccountant: null,
      fbBalanceDate: null,
      isDeleted: 0,
      remark: null,
      createBy: null,
      createTime: null,
      updateBy: null,
      updateTime: null,
    };
    proxy.resetForm("formRef")
  }



  // 添加&修改 表单提交
  function submitForm() {
    proxy.$refs["formRef"].validate((valid) => {
      if (valid) {

        if (form.value.fbSFID != undefined && opertype.value === 2) {
        } else {
        }
      }
    })
  }



  // 导入数据成功处理
  const handleFileSuccess = (response) => {
    const { item1, item2 } = response.data
    var error = ''
    item2.forEach((item) => {
      error += item.storageMessage + ','
    })
    proxy.$alert(item1 + '<p>' + error + '</p>', proxy.$t('btn.importResults'), {
      dangerouslyUseHTMLString: true
    })
    getList()
  }

  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + "<预算实际明细.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoBudgetActualCost/export', { ...queryParams })
      })
  }


  // @Descripttion: (自定义函数/CustomFunctions)
  // @Functions: (assignValue,calculateValue,statisticValue)


  const getSummaries = (param) => {
    const { columns, data } = param;
    const sums = [];
    columns.forEach((column, index) => {
      if (index === 1) {
        sums[index] = '合计'
        return
      }
      //合计的索引
      // if (index === 2 || index === 3 || index === 4 || index === 5 || index === 6) {
      if (index === 6 || index === 7) {
        const values = data.map(item => Number(item[column.property]));
        if (!values.every(value => isNaN(value))) {
          sums[index] = values.reduce((prev, curr) => {
            const value = Number(curr)
            if (!isNaN(value)) {
              return (prev + curr)
            } else {
              return prev
            }
          }, 0)
          // sums[index] = (sums[index]).toFixed(2); 
          sums[index] = ThousandWithNumber(sums[index])// !!重点 要对结果进行转换
        }
      }

    })
    //加减运算
    //sums[8] = '未完成台数：' + ThousandWithNumber(formatNumber(sums[6]) - formatNumber(sums[7])).toString()
    //合计库存金额，数量*价格
    //sums[8] = ThousandWithNumber((data.reduce((sum, row) => sum + (row.mmMovingAvg * row.mmInventory / 1000.00), 0)).toFixed(2))// !!重点 要对结果进行转换
    return sums
  }
  //千分位转number
  const formatNumber = (val) => {
    if (val == null || val == 0) {
      return val = '0.00'
    } else {
      return val.replace(/,/g, '');
    }
  }
  // 千分位函数
  function ThousandWithNumber(value) {
    if (!value) return 0
    // 获取整数部分
    const wholePart = Math.trunc(value)
    // 梳理数据 -> 千分位
    const wholePartFormat = wholePart.toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1,')
    // 处理小数部分
    let decimalPart = ''
    // 将数值截取为小数部分和整数部分
    const valueArray = value.toString().split('.')
    if (valueArray.length === 2) { // 有小数部分
      decimalPart = valueArray[1].toString() // 取得小数部分
      return wholePartFormat + '.' + decimalPart
    }
    return wholePartFormat + decimalPart
  }
  handleQuery()
</script>