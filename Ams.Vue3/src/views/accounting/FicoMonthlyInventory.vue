<!--
 * @Descripttion: 月度存货/fico_monthly_inventory
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/16 11:45:33
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="miPlant">
        <el-select filterable clearable   v-model="queryParams.miPlant" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="miYm">
        <el-select filterable clearable   v-model="queryParams.miYm" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ficoym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估类" prop="miValType">
        <el-select filterable clearable   v-model="queryParams.miValType" :placeholder="$t('btn.selectSearchPrefix')+'评估类'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_val_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-dropdown trigger="click" v-hasPermi="['fico:monthlyinventory:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoMonthlyInventory/importTemplate"
                  importUrl="/Accounting/FicoMonthlyInventory/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:monthlyinventory:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="600px"
      :data="dataList"
      v-loading="loading"
      ref="table"
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      >
      <el-table-column prop="miSFID" label="SFID" align="center" v-if="columns.showColumn('miSFID')"/>
      <el-table-column prop="miPlant" label="工厂" align="center" v-if="columns.showColumn('miPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.miPlant"  />
        </template>
      </el-table-column>
      <el-table-column prop="miFy" label="期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('miFy')"/>
      <el-table-column prop="miYm" label="年月" align="center" v-if="columns.showColumn('miYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ficoym_list " :value="scope.row.miYm"  />
        </template>
      </el-table-column>
      <el-table-column prop="miItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('miItem')"/>
      <el-table-column prop="miValType" label="评估类" align="center" v-if="columns.showColumn('miValType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_val_type " :value="scope.row.miValType"  />
        </template>
      </el-table-column>
      <el-table-column prop="miPriceControl" label="价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('miPriceControl')"/>
      <el-table-column prop="miMovingAverage" label="移动平均价" align="center" v-if="columns.showColumn('miMovingAverage')"/>
      <el-table-column prop="miPerUnit" label="Per单位" align="center" v-if="columns.showColumn('miPerUnit')"/>
      <el-table-column prop="miLocalCcy" label="币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('miLocalCcy')"/>
      <el-table-column prop="miInventoryQty" label="库存" align="center" v-if="columns.showColumn('miInventoryQty')"/>
      <el-table-column prop="miInventoryAmount" label="金额" align="center" v-if="columns.showColumn('miInventoryAmount')"/>
      <el-table-column prop="miBalancedate" label="登录日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('miBalancedate')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

  </div>
</template>

<script setup name="ficomonthlyinventory">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoMonthlyInventory,
 
getFicoMonthlyInventory, 
 } 
from '@/api/accounting/ficomonthlyinventory.js'
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
  miPlant: undefined,
//是否查询（1是）
  miYm: undefined,
//是否查询（1是）
  miValType: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'miSFID', label: 'SFID' },
  { visible: true, prop: 'miPlant', label: '工厂' },
  { visible: true, prop: 'miFy', label: '期间' },
  { visible: true, prop: 'miYm', label: '年月' },
  { visible: true, prop: 'miItem', label: '物料' },
  { visible: true, prop: 'miValType', label: '评估类' },
  { visible: true, prop: 'miPriceControl', label: '价格控制' },
  { visible: true, prop: 'miMovingAverage', label: '移动平均价' },
  { visible: false, prop: 'miPerUnit', label: 'Per单位' },
  { visible: false, prop: 'miLocalCcy', label: '币种' },
  { visible: false, prop: 'miInventoryQty', label: '库存' },
  { visible: false, prop: 'miInventoryAmount', label: '金额' },
  { visible: false, prop: 'miBalancedate', label: '登录日期' },
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
  { dictType: "sys_plant_list" },
  { dictType: "sql_ficoym_list" },
  { dictType: "sys_val_type" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从月度存货/fico_monthly_inventory表记录数据
function getList(){
  loading.value = true
  listFicoMonthlyInventory(queryParams).then(res => {
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
function resetQuery(){
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
    miSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    miPlant: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    miFy: [{ required: true, message: "期间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    miYm: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    miItem: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    miValType: [{ required: true, message: "评估类"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    miPriceControl: [{ required: true, message: "价格控制"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    miMovingAverage: [{ required: true, message: "移动平均价"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    miPerUnit: [{ required: true, message: "Per单位"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    miLocalCcy: [{ required: true, message: "币种"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    miInventoryQty: [{ required: true, message: "库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    miInventoryAmount: [{ required: true, message: "金额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    miBalancedate: [{ required: true, message: "登录日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_plant_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ficoym_list: [],
    // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_val_type: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_deleted: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    miSFID: 0,
    miPlant: null,
    miFy: null,
    miYm: null,
    miItem: null,
    miValType: null,
    miPriceControl: null,
    miMovingAverage: 0,
    miPerUnit: 0,
    miLocalCcy: null,
    miInventoryQty: 0,
    miInventoryAmount: 0,
    miBalancedate: null,
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

      if (form.value.miSFID != undefined && opertype.value === 2) {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<月度存货.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoMonthlyInventory/export', { ...queryParams })
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