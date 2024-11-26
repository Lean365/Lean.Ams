<!--
 * @Descripttion: 数据库/gen_database
 * @Version: 0.24.614.28099
 * @Author: Lean365(Davis.Ching) 
 * @Date: 2024/9/5 15:42:56
 * @column：41
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item :label="$t('gencode.dbName')" prop="dbName">
            <el-select
              v-model="queryParams.dbName"
              clearable
              :placeholder="$t('btn.selectSearchPrefix') + $t('gencode.dbName') + $t('btn.selectSearchSuffix')"
              @change="handledbName">
              <el-option v-for="item in dbList" :key="item" :label="item" :value="item" />
            </el-select>
          </el-form-item>
          <el-form-item :label="$t('gencode.tableName')">
            <el-select-v2
              filterable
              clearable
              v-model="queryParams.tableName"
              :options="tbList.map((item) => ({ label: item.label, value: item.value }))"
              :placeholder="$t('btn.selectSearchPrefix') + $t('gencode.tableName') + $t('btn.selectSearchSuffix')">
            </el-select-v2>
            <!-- <el-select v-model="queryParams.tableName" clearable
              :placeholder="$t('btn.selectSearchPrefix')+$t('gencode.tableName')+$t('btn.selectSearchSuffix')"
              @change="handletableName">
              <el-option v-for="item in tbList.map(item => item.tableName)" :key="value" :label="label"
                :value="value" />
            </el-select> -->
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
        <el-button class="btn-add" v-hasPermi="['fico:profitcenter:add']" plain icon="plus" @click="handleAdd">
          {{ $t('database.newTable') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:profitcenter:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('database.editTable') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:profitcenter:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('database.deleteTable') }}
        </el-button>
      </el-col>
      <!-- <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:profitcenter:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('database.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoProfitCenter/importTemplate"
                  importUrl="/Accounting/FicoProfitCenter/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
</el-dropdown>
</el-col>
<el-col :span="1.5">
  <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:profitcenter:export']">
    {{ $t('database.export') }}
  </el-button>
</el-col> -->
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table
      border
      height="600px"
      :data="dataList"
      v-loading="loading"
      ref="table"
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="tableId" :label="$t('database.tableId')" align="center" v-if="columns.showColumn('tableId')"> </el-table-column>
      <el-table-column prop="tableName" :label="$t('database.tableName')" align="center" v-if="columns.showColumn('tableName')"> </el-table-column>
      <el-table-column prop="dbColumnName" :label="$t('database.columnName')" align="center" v-if="columns.showColumn('dbColumnName')">
        <template #default="scope">
          <el-input v-model="scope.row.dbColumnName" v-show="scope.row.isEdit" show-word-limit maxlength="40"></el-input>
          <span v-show="!scope.row.isEdit">{{ scope.row.dbColumnName }}</span>
        </template>
      </el-table-column>

      <el-table-column
        prop="columnDescription"
        :label="$t('database.columnDescription')"
        align="center"
        v-if="columns.showColumn('columnDescription')">
        <template #default="scope">
          <el-input v-model="scope.row.columnDescription" v-show="scope.row.isEdit" show-word-limit maxlength="40"></el-input>
          <span v-show="!scope.row.isEdit">{{ scope.row.columnDescription }}</span>
        </template>
      </el-table-column>

      <el-table-column prop="dataType" :label="$t('database.dataType')" align="center" v-if="columns.showColumn('dataType')">
        <template #default="scope">
          <el-select v-model="scope.row.dataType" v-show="scope.row.isEdit" style="width: 100px" @change="checkDataType">
            <el-option label="bigint" value="bigint" />
            <el-option label="bigint" value="bigint" />
            <el-option label="char" value="char" />
            <el-option label="datetime" value="datetime" />
            <el-option label="decimal" value="decimal" />
            <el-option label="int" value="int" />
            <el-option label="nvarchar" value="nvarchar" />
            <el-option label="nvarchar(max)" value="nvarchar(max)" />
            <el-option label="text" value="text" />
            <el-option label="uniqueidentifier" value="uniqueidentifier" />
            <el-option label="varchar" value="varchar" />
            <el-option label="varchar(max)" value="varchar(max)" />
          </el-select>
          <span v-show="!scope.row.isEdit">{{ scope.row.dataType }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="isPrimarykey" :label="$t('database.isPrimarykey')" align="center" v-if="columns.showColumn('isPrimarykey')">
        <template #default="scope">
          <el-select v-model="scope.row.isPrimarykey" v-show="scope.row.isEdit" style="width: 100px" @change="checkDataType">
            <el-option label="false" value="false" />
            <el-option label="true" value="true" />
          </el-select>
          <span v-show="!scope.row.isEdit">{{ scope.row.isPrimarykey }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="isIdentity" :label="$t('database.isIdentity')" align="center" v-if="columns.showColumn('isIdentity')">
        <template #default="scope">
          <el-select v-model="scope.row.isIdentity" v-show="scope.row.isEdit" style="width: 100px" @change="checkDataType">
            <el-option label="false" value="false" />
            <el-option label="true" value="true" />
          </el-select>
          <span v-show="!scope.row.isEdit">{{ scope.row.isIdentity }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="defaultValue" :label="$t('database.defaultValue')" align="center" v-if="columns.showColumn('defaultValue')">
        <template #default="scope">
          <el-input v-model="scope.row.defaultValue" v-show="scope.row.isEdit" show-word-limit maxlength="40"></el-input>
          <span v-show="!scope.row.isEdit">{{ scope.row.defaultValue }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="length" :label="$t('database.length')" align="center" v-if="columns.showColumn('length')">
        <template #default="scope">
          <el-input-number
            v-model="scope.row.length"
            v-show="scope.row.isEdit"
            :step="1"
            :style="{ width: '120px' }"
            :max="5000"
            :min="0"></el-input-number>
          <span v-show="!scope.row.isEdit">{{ scope.row.length }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="decimalDigits" :label="$t('database.decimalDigits')" align="center" v-if="columns.showColumn('decimalDigits')">
        <template #default="scope">
          <el-input-number
            v-model="scope.row.decimalDigits"
            v-show="scope.row.isEdit"
            :step="1"
            :style="{ width: '120px' }"
            :max="5"
            :min="0"></el-input-number>
          <span v-show="!scope.row.isEdit">{{ scope.row.decimalDigits }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="isNullable" :label="$t('database.isNullable')" align="center" v-if="columns.showColumn('isNullable')">
        <template #default="scope">
          <el-select v-model="scope.row.isNullable" v-show="scope.row.isEdit" style="width: 100px" @change="checkDataType">
            <el-option label="false" value="false" />
            <el-option label="true" value="true" />
          </el-select>
          <span v-show="!scope.row.isEdit">{{ scope.row.isNullable }}</span>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button
              class="btn-edit"
              plain
              size="small"
              icon="edit"
              :title="$t('btn.edit')"
              v-hasPermi="['fico:profitcenter:edit']"
              @click="handleUpdate(scope.row)"></el-button>
            <el-button
              class="btn-delete"
              plain
              size="small"
              icon="check"
              :title="$t('btn.save')"
              v-hasPermi="['fico:profitcenter:delete']"
              @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改利润中心对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto"> </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ficoprofitcenter">
import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listDbList, listTbList, queryColumnInfo, listColumnInfo } from '@/api/tool/database.js'
//防抖处理函数 import { debounce } from 'lodash';
import { debounce } from 'lodash'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 数据库数据
const dbList = ref([])

// 数据表数据
const tbList = ref([])
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
  sort: 'tableName',
  sortType: 'asc',
  //是否查询（1是）
  tableName: undefined,
  //是否查询（1是）
  mq004: undefined,
  //是否查询（1是）
  mq010: undefined
})
//字段显示控制
const columns = ref([
  { visible: false, prop: 'tableId', label: proxy.$t('database.tableId') },

  { visible: true, prop: 'tableName', label: proxy.$t('database.tableName') },
  { visible: true, prop: 'dbColumnName', label: proxy.$t('database.columnName') },
  { visible: true, prop: 'columnDescription', label: proxy.$t('database.columnDescription') },
  { visible: true, prop: 'dataType', label: proxy.$t('database.dataType') },
  { visible: true, prop: 'isPrimarykey', label: proxy.$t('database.isPrimarykey') },
  { visible: true, prop: 'isIdentity', label: proxy.$t('database.isIdentity') },
  { visible: true, prop: 'defaultValue', label: proxy.$t('database.defaultValue') },
  { visible: true, prop: 'length', label: proxy.$t('database.length') },
  { visible: true, prop: 'decimalDigits', label: proxy.$t('database.decimalDigits') },
  { visible: true, prop: 'isNullable', label: proxy.$t('database.isNullable') }
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
  { dictType: 'sql_corp_list' },
  { dictType: 'sql_global_currency' },
  { dictType: 'sys_locked_flag' },
  { dictType: 'sys_is_status' },
  { dictType: 'sys_is_deleted' }
]
getDbList()

/** 查询数据库 */
function getDbList() {
  listDbList().then((res) => {
    dbList.value = res.data.dbList

    console.log(res.data)
  })
  // if (queryParams.dbName !== '') {
  //   listDbList(queryParams).then((res) => {
  //     dbTableList.value = res.data.result
  //     total.value = res.data.totalNum
  //   })
  // }
  //getTbList()
}
/** 查询数据表 */
function getTbList() {
  // listTbList(queryParams).then((res) => {
  //   tbList.value = res.data.tbList
  // })
  if (queryParams.dbName !== '') {
    listTbList(queryParams).then((res) => {
      tbList.value = res.data.result.map((db) => ({
        label: db.description,
        value: db.name
      }))
    })
  }
}
function handledbName() {
  getTbList()
}
function handletableName() {
  console.log(queryParams.dbName, queryParams.tableName)

  listColumnInfo(queryParams.dbName, queryParams.tableName).then((res) => {
    dataList.value = res.data.result
    total.value = res.data.totalNum
    total.value = res.data.total
  })
}
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从利润中心 / fico_profit_center表记录数据
function getList() {
  loading.value = true
  listColumnInfo(queryParams.dbName, queryParams.tableName).then((res) => {
    const { code, data } = res
    if (code == 200) {
      dataList.value = data

      total.value = data.totalNum
      loading.value = false
    }
    console.log(res)
  })
}

// 查询
function handleQuery() {
  queryParams.pageNum = 1
  getList()
}

// 重置查询操作
function resetQuery() {
  proxy.resetForm('queryRef')

  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.id)
  single.value = selection.length != 1

  multiple.value = !selection.length
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
    id: [{ required: true, message: 'ID' + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
    tableName: [{ required: true, message: '利润中心' + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
    mq010: [{ required: true, message: '名称' + proxy.$t('btn.isEmpty'), trigger: 'blur' }]
  },
  //字典名称
  options: {
    // 控制范围 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_corp_list: [],
    // 货币 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sql_global_currency: [],
    // 锁定标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_locked_flag: [],
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_is_status: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_is_deleted: []
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
    dbName: null,
    tableName: null,
    mq004: [],
    mq005: null,
    mq006: null,
    mq007: 0,
    mq008: null,
    mq009: [],
    mq010: null,
    mq011: null,

    mq012: null,
    mq013: null,
    mq014: null,
    mq015: null,
    mq016: [],
    mq017: [],
    remark: null
  }
  proxy.resetForm('formRef')
}

// 添加按钮操作
function handleAdd() {
  reset()
  open.value = true
  title.value = proxy.$t('btn.add') + ' ' + '利润中心'
  opertype.value = 1
  form.value.mq004 = []
  form.value.mq005 = new Date()
  form.value.mq006 = new Date()
  form.value.mq007 = 0
  form.value.mq009 = []
  form.value.mq016 = 0
  form.value.mq017 = 0
}
// 修改按钮操作
function handleUpdate(row) {
  row.isEdit = true
  // const id = row.id || ids.value
  // getFicoProfitCenter(id).then((res) => {
  //   const { code, data } = res
  //   if (code == 200) {
  //     open.value = true
  //     title.value = proxy.$t('btn.edit') + " " + '利润中心'
  //     opertype.value = 2

  //     form.value = {
  //       ...data,
  //     }
  //   }
  // })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs['formRef'].validate((valid) => {
    if (valid) {
      if (form.value.id != undefined && opertype.value === 2) {
        updateFicoProfitCenter(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoProfitCenter(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.tipAddSucceed'))
          open.value = false
          getList()
        })
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  row.isEdit = false
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
    .$confirm(proxy.$t('common.tipConfirmExport') + '<利润中心.xlsx>', proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: 'warning'
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoProfitCenter/export', { ...queryParams })
    })
}

//handleQuery()
</script>
