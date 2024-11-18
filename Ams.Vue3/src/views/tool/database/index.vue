<!--
 * @Descripttion: 数据库/database
 * @Version: 0.24.614.28099
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 15:43:04
 * @column：43
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">

          <el-form-item :label="$t('gendatabase.dbName')" prop="dbName">
            <el-select v-model="queryParams.dbName" clearable
              :placeholder="$t('btn.selectSearchPrefix')+$t('gencode.dbName')+$t('btn.selectSearchSuffix')"
              @change="handleTableQuery">
              <el-option v-for="item in dbList" :key="item" :label="item" :value="item" />
            </el-select>
          </el-form-item>
          <el-form-item :label="$t('gendatabase.tableName')" prop="tableName">
            <el-select filterable clearable v-model="queryParams.tableName"
              :placeholder="$t('btn.selectSearchPrefix')+$t('gendatabase.tableName')+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in  dbTableList" :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue"></el-option>
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
        <el-button class="btn-add" v-hasPermi="['fico:bank:add']" plain icon="plus" @click="handleNewTable">
          {{ $t('gendatabase.newTable') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:bank:edit']" plain icon="edit"
          @click="handleEditTable">
          {{ $t('gendatabase.editTable') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:bank:delete']" plain icon="delete"
          @click="handleDeleteTable">
          {{ $t('gendatabase.deleteTable') }}
        </el-button>
      </el-col>

      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="600px" :data="dataList" v-loading="loading" ref="table"
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')" />
      <el-table-column prop="mc002" label="集团" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc002')" />
      <el-table-column prop="mc003" label="关联对象" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc003')" />
      <el-table-column prop="mc004" label="银行代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc004')" />
      <el-table-column prop="mc005" label="银行名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc005')" />
      <el-table-column prop="mc006" label="分行名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc006')" />

      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:bank:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['fico:bank:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改银行对话框 -->
  </div>
</template>

<script setup name="ficobank">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import { listDbTable, codeGetDBList, importTable } from '@/api/tool/gen'
  import newTable from './newTable'
  //防抖处理函数 import { debounce } from 'lodash';
  import { debounce } from 'lodash';
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 数据库数据
  const dbList = ref([])
  //表数据
  const dbTableList = ref([])
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
    sort: 'dbName',
    sortType: 'asc',
    //是否查询（1是）
    dbName: undefined,
    //是否查询（1是）
    tableName: undefined,

  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mc002', label: '集团' },
    { visible: true, prop: 'mc003', label: '关联对象' },
    { visible: true, prop: 'mc004', label: '银行代码' },
    { visible: true, prop: 'mc005', label: '银行名称' },
    { visible: true, prop: 'mc006', label: '分行名称' },
    { visible: true, prop: 'mc007', label: '银行所在国' },
    { visible: true, prop: 'mc008', label: '所在州省' },
    { visible: false, prop: 'mc009', label: '所在市' },
    { visible: false, prop: 'mc010', label: '所在县' },
    { visible: false, prop: 'mc011', label: '地址1' },
    { visible: false, prop: 'mc012', label: '地址2' },
    { visible: false, prop: 'mc013', label: '地址3' },
    { visible: false, prop: 'mc014', label: '邮政编码' },
    { visible: false, prop: 'mc015', label: '地址号码' },
    { visible: false, prop: 'mc016', label: '银行账号' },
    { visible: false, prop: 'mc017', label: '持有人' },
    { visible: false, prop: 'mc018', label: 'SWIFT代码' },
    { visible: false, prop: 'mc019', label: '交易冻结' },
    { visible: false, prop: 'remark', label: '备注说明' },
  ])
  // 记录数
  const total = ref(0)
  //定义数据变量
  const dataList = ref([])
  //查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])





  //API获取从银行/fico_bank表记录数据


  function getList() {


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
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.id);
    single.value = selection.length != 1
    multiple.value = !selection.length;
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
    //正则表达式
    rules: {
      id: [{ required: true, message: "ID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc002: [{ required: true, message: "集团" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc004: [{ required: true, message: "银行代码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc005: [{ required: true, message: "银行名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc019: [{ required: true, message: "交易冻结" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    //字典名称
    options: {
      // 银行所在国 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_global_country: [],
      // 交易冻结 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_freeze_flag: [],
      // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
      mc002: null,
      mc003: null,
      mc004: null,
      mc005: null,
      mc006: null,
      mc007: [],
      mc008: [],
      mc009: null,
      mc010: null,
      mc011: null,
      mc012: null,
      mc013: null,
      mc014: null,
      mc015: null,
      mc016: null,
      mc017: null,
      mc018: null,
      mc019: 0,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleNewTable() {
    router.push({
      name: 'newTable'
    })

  }
  // 修改按钮操作
  function handleEditTable(row) {
    reset()
    const id = row.id || ids.value

  }

  // 添加&修改 表单提交
  function handleNewColumn() {


  }

  // 删除按钮操作
  function handleDeleteTable(row) {
    const Ids = row.id || ids.value


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