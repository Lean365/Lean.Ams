<!--
 * @Descripttion: 数据表/viewTable
 * @Version: 0.24.682.31110
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/11/12 17:19:12
 * @column：36
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->

    <!-- 工具区域 -->

    <!-- 数据区域 -->
    <el-table
      border
      height="750px"
      :data="dataList"
      v-loading="loading"
      ref="table"
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <!-- <el-table-column type="selection" width="50" align="center" /> -->
      <el-table-column prop="tableId" :label="$t('database.tableId')" align="center" v-if="columns.showColumn('tableId')"> </el-table-column>
      <el-table-column prop="tableName" :label="$t('database.tableName')" align="center" width="300" v-if="columns.showColumn('tableName')">
      </el-table-column>
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
      <!-- <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:profitcenter:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.save')"
              v-hasPermi="['fico:profitcenter:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column> -->
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改不良统计对话框 -->
  </div>
</template>

<script setup name="viewTable">
import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listDataBases, listDataTables, listDataColumns } from '@/api/tool/database'

//防抖处理函数 import { debounce } from 'lodash';
import { debounce } from 'lodash'
//获取当前组件实例
const { proxy } = getCurrentInstance()
//定义路由
const route = useRoute()
//标签页
const activeName = ref('first')
const handleClick = (tab, event) => {
  console.log(tab, event)
}
// 数据库数据
const dbList = ref([])
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
  sortType: 'desc',
  //数据库名称,是否查询（1是）
  dbName: route.query.dbName, //undefined,
  //数据表名称,是否查询（1是）
  tableName: route.query.tableName //undefined,
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

// const dbName = route.query.dbName
// const tableName = route.query.tableName
// queryParams.dbName = route.query.dbName
// queryParams.tableName = route.query.tableName

//API获取从不良统计/pp_defect_total表记录数据
function getList() {
  //console.log(queryParams)

  loading.value = true
  // listDataColumns(queryParams.dbName, queryParams.tableName).then((res) => {
  //   dataList.value = res.data.result
  //   total.value = res.data.totalNum
  // })
  listDataColumns(queryParams.dbName, queryParams.tableName).then((res) => {
    const { code, data } = res
    if (code == 200) {
      dataList.value = data
      total.value = data.length
      loading.value = false
    }
    //console.log(queryParams)
  })

  //if (queryParams.dbName !== undefined && queryParams.dbName !== '') {} else { proxy.$modal.msgError(proxy.$t('database.selectDatabaseName') + ',' + proxy.$t('btn.select')) + '!' }
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

// 关闭dialog
function cancel() {
  open.value = false
  reset()
}

// 重置表单
function reset() {}

// 添加按钮操作
function handleAdd() {}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  // getPpDefectTotal(id).then((res) => {
  //   const { code, data } = res
  //   if (code == 200) {
  //     open.value = true
  //     title.value = proxy.$t('btn.edit') + " " + '不良统计'
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
      // if (form.value.id != undefined && opertype.value === 2) {
      //   updatePpDefectTotal(form.value).then((res) => {
      //     proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
      //     open.value = false
      //     getList()
      //   })
      // } else {
      //   addPpDefectTotal(form.value).then((res) => {
      //     proxy.$modal.msgSuccess(proxy.$t('common.tipAddSucceed'))
      //     open.value = false
      //     getList()
      //   })
      // }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.id || ids.value

  // proxy
  //   .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
  //     confirmButtonText: proxy.$t('btn.submit'),
  //     cancelButtonText: proxy.$t('btn.cancel'),
  //     type: "warning",
  //   })
  //   .then(function () {
  //     return delPpDefectTotal(Ids)
  //   })
  //   .then(() => {
  //     getList()
  //     proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
  //   })
}

// 导出按钮操作
function handleExport() {
  // proxy
  //   .$confirm(proxy.$t('common.tipConfirmExport') + "<不良统计.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
  //     confirmButtonText: proxy.$t('btn.submit'),
  //     cancelButtonText: proxy.$t('btn.cancel'),
  //     type: "warning",
  //   })
  //   .then(async () => {
  //     await proxy.downFile('/Logistics/PpDefectTotal/export', { ...queryParams })
  //   })
}

// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)

handleQuery()
</script>
