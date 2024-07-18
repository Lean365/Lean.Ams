<!--
 * @Descripttion: 部门消耗/fico_dept_consuming
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/16 11:47:09
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="年月" prop="dcYm">
        <el-select filterable clearable   v-model="queryParams.dcYm" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ficoym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司代码" prop="dcCorpCode">
        <el-select filterable clearable   v-model="queryParams.dcCorpCode" :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工厂" prop="dcPlant">
        <el-select filterable clearable   v-model="queryParams.dcPlant" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-dropdown trigger="click" v-hasPermi="['fico:deptconsuming:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoDeptConsuming/importTemplate"
                  importUrl="/Accounting/FicoDeptConsuming/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:deptconsuming:export']">
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
      <el-table-column prop="dcSFID" label="SFID" align="center" v-if="columns.showColumn('dcSFID')"/>
      <el-table-column prop="dcFy" label="期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcFy')"/>
      <el-table-column prop="dcYm" label="年月" align="center" v-if="columns.showColumn('dcYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ficoym_list " :value="scope.row.dcYm"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcCorpCode" label="公司代码" align="center" v-if="columns.showColumn('dcCorpCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.dcCorpCode"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcCorpName" label="公司名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCorpName')"/>
      <el-table-column prop="dcExpCategory" label="统计类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcExpCategory')"/>
      <el-table-column prop="dcCostCode" label="成本代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCostCode')"/>
      <el-table-column prop="dcCostName" label="成本名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCostName')"/>
      <el-table-column prop="dcTitleCode" label="科目代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleCode')"/>
      <el-table-column prop="dcTitleName" label="科目名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleName')"/>
      <el-table-column prop="dcTitleNote" label="科目分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleNote')"/>
      <el-table-column prop="dcBudgetAmt" label="预算" align="center" v-if="columns.showColumn('dcBudgetAmt')"/>
      <el-table-column prop="dcActualAmt" label="实际" align="center" v-if="columns.showColumn('dcActualAmt')"/>
      <el-table-column prop="dcDiffAmt" label="差异" align="center" v-if="columns.showColumn('dcDiffAmt')"/>
      <el-table-column prop="dcPlant" label="工厂" align="center" v-if="columns.showColumn('dcPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.dcPlant"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcMateriel" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMateriel')"/>
      <el-table-column prop="dcStorageLocation" label="仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcStorageLocation')"/>
      <el-table-column prop="dcMoveType" label="移动类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMoveType')"/>
      <el-table-column prop="dcMaterielDoc" label="物料凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMaterielDoc')"/>
      <el-table-column prop="dcMaterielDocDetails" label="凭证明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMaterielDocDetails')"/>
      <el-table-column prop="dcUseQty" label="数量" align="center" v-if="columns.showColumn('dcUseQty')"/>
      <el-table-column prop="dcUseAmt" label="金额" align="center" v-if="columns.showColumn('dcUseAmt')"/>
      <el-table-column prop="dcReserveDoc" label="预留单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcReserveDoc')"/>
      <el-table-column prop="dcAccountant" label="预留明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcAccountant')"/>
      <el-table-column prop="dcBalanceDate" label="登录日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('dcBalanceDate')"/>
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

<script setup name="ficodeptconsuming">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoDeptConsuming,
 
getFicoDeptConsuming, 
 } 
from '@/api/accounting/ficodeptconsuming.js'
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
  dcYm: undefined,
//是否查询（1是）
  dcCorpCode: undefined,
//是否查询（1是）
  dcPlant: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'dcSFID', label: 'SFID' },
  { visible: true, prop: 'dcFy', label: '期间' },
  { visible: true, prop: 'dcYm', label: '年月' },
  { visible: true, prop: 'dcCorpCode', label: '公司代码' },
  { visible: true, prop: 'dcCorpName', label: '公司名称' },
  { visible: true, prop: 'dcExpCategory', label: '统计类别' },
  { visible: true, prop: 'dcCostCode', label: '成本代码' },
  { visible: true, prop: 'dcCostName', label: '成本名称' },
  { visible: false, prop: 'dcTitleCode', label: '科目代码' },
  { visible: false, prop: 'dcTitleName', label: '科目名称' },
  { visible: false, prop: 'dcTitleNote', label: '科目分类' },
  { visible: false, prop: 'dcBudgetAmt', label: '预算' },
  { visible: false, prop: 'dcActualAmt', label: '实际' },
  { visible: false, prop: 'dcDiffAmt', label: '差异' },
  { visible: false, prop: 'dcPlant', label: '工厂' },
  { visible: false, prop: 'dcMateriel', label: '物料' },
  { visible: false, prop: 'dcStorageLocation', label: '仓库' },
  { visible: false, prop: 'dcMoveType', label: '移动类型' },
  { visible: false, prop: 'dcMaterielDoc', label: '物料凭证' },
  { visible: false, prop: 'dcMaterielDocDetails', label: '凭证明细' },
  { visible: false, prop: 'dcUseQty', label: '数量' },
  { visible: false, prop: 'dcUseAmt', label: '金额' },
  { visible: false, prop: 'dcReserveDoc', label: '预留单' },
  { visible: false, prop: 'dcAccountant', label: '预留明细' },
  { visible: false, prop: 'dcBalanceDate', label: '登录日期' },
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
  { dictType: "sys_plant_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从部门消耗/fico_dept_consuming表记录数据
function getList(){
  loading.value = true
  listFicoDeptConsuming(queryParams).then(res => {
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
    dcSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    dcFy: [{ required: true, message: "期间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcYm: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    dcCorpCode: [{ required: true, message: "公司代码"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    dcCorpName: [{ required: true, message: "公司名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcExpCategory: [{ required: true, message: "统计类别"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcCostCode: [{ required: true, message: "成本代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcCostName: [{ required: true, message: "成本名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcTitleCode: [{ required: true, message: "科目代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcTitleName: [{ required: true, message: "科目名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcTitleNote: [{ required: true, message: "科目分类"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcBudgetAmt: [{ required: true, message: "预算"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcActualAmt: [{ required: true, message: "实际"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcDiffAmt: [{ required: true, message: "差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcPlant: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    dcMateriel: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcStorageLocation: [{ required: true, message: "仓库"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcMoveType: [{ required: true, message: "移动类型"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcMaterielDoc: [{ required: true, message: "物料凭证"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcMaterielDocDetails: [{ required: true, message: "凭证明细"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcUseQty: [{ required: true, message: "数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcUseAmt: [{ required: true, message: "金额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcReserveDoc: [{ required: true, message: "预留单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcAccountant: [{ required: true, message: "预留明细"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcBalanceDate: [{ required: true, message: "登录日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ficoym_list: [],
    // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_plant_list: [],
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
    dcSFID: 0,
    dcFy: null,
    dcYm: null,
    dcCorpCode: null,
    dcCorpName: null,
    dcExpCategory: null,
    dcCostCode: null,
    dcCostName: null,
    dcTitleCode: null,
    dcTitleName: null,
    dcTitleNote: null,
    dcBudgetAmt: 0,
    dcActualAmt: 0,
    dcDiffAmt: 0,
    dcPlant: null,
    dcMateriel: null,
    dcStorageLocation: null,
    dcMoveType: null,
    dcMaterielDoc: null,
    dcMaterielDocDetails: null,
    dcUseQty: 0,
    dcUseAmt: 0,
    dcReserveDoc: null,
    dcAccountant: null,
    dcBalanceDate: null,
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

      if (form.value.dcSFID != undefined && opertype.value === 2) {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<部门消耗.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoDeptConsuming/export', { ...queryParams })
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