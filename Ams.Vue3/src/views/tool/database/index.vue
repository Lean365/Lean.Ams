<!--
 * @Descripttion: 不良统计/pp_defect_total
 * @Version: 0.24.682.31110
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/11/12 17:19:12
 * @column：36
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item :label="$t('database.databaseName')" prop="dbName">
            <el-select
              v-model="queryParams.dbName"
              clearable
              :placeholder="$t('btn.selectSearchPrefix') + $t('database.databaseName') + $t('btn.selectSearchSuffix')">
              <el-option v-for="item in dbList" :key="item" :label="item" :value="item" />
            </el-select>
          </el-form-item>
          <el-form-item :label="$t('database.tableName')">
            <el-input
              v-model="queryParams.tableName"
              clearable
              :placeholder="$t('btn.enterSearchPrefix') + $t('database.tableName') + $t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['pp:defecttotal:add']" plain icon="plus" @click="handleAdd">
          {{ $t('menu.toolNewDataTable') }}
        </el-button>
      </el-col>
      <!-- <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:defecttotal:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col> -->
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:defecttotal:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>

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
      <el-table-column prop="name" :label="$t('database.tableName')" align="left" v-if="columns.showColumn('name')" />
      <el-table-column prop="description" :label="$t('database.tableDescription')" align="left" v-if="columns.showColumn('description')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button
              class="btn-view"
              plain
              size="small"
              icon="view"
              :title="$t('btn.view')"
              v-hasPermi="['pp:defecttotal:view']"
              @click="handleView(scope.row)"></el-button>
            <el-button
              class="btn-edit"
              plain
              size="small"
              icon="edit"
              :title="$t('btn.edit')"
              v-hasPermi="['pp:defecttotal:edit']"
              @click="handleUpdate(scope.row)"></el-button>
            <el-button
              class="btn-delete"
              plain
              size="small"
              icon="delete"
              :title="$t('btn.delete')"
              v-hasPermi="['pp:defecttotal:delete']"
              @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改不良统计对话框 -->
  </div>
</template>

<script setup name="database">
import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listDataBases, listDataTables } from '@/api/tool/database'

//获取当前组件实例
const { proxy } = getCurrentInstance()
//定义路由
const router = useRouter()
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
  dbName: undefined,
  //数据表名称,是否查询（1是）
  tableName: undefined
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'tableId', label: proxy.$t('database.tableId') },
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
getDbList()
/** 查询表数据 */
function getDbList() {
  listDataBases().then((res) => {
    dbList.value = res.data.dbList
  })
  // if (queryParams.dbName !== '') {
  //   listDbTable(queryParams).then((res) => {
  //     dbTableList.value = res.data.result
  //     total.value = res.data.totalNum
  //   })
  // }
}
//API获取从不良统计/pp_defect_total表记录数据
function getList() {
  //console.log(queryParams)
  if (queryParams.dbName !== undefined && queryParams.dbName !== '') {
    loading.value = true
    listDataTables(queryParams).then((res) => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
      }
      //console.log(queryParams)
    })
  } else {
    dataList.value = ''
    total.value = ''
    // proxy.$modal.msgError(proxy.$t('database.selectDatabaseName') + ',' + proxy.$t('btn.select')) + '!'
  }
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
//定义对话框打开或关闭
const open = ref(false)
//reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效

// 重置表单
function reset() {}

// 添加按钮操作
function handleAdd() {
  router.push({ path: 'newTable' })
}

// 修改按钮操作
function handleView(row) {
  //router.push({ path: 'viewTable' })
  const name = row.name
  var hasPermi = proxy.$auth.hasPermiAnd(['tool:database:view', 'tool:database:list'])
  if (hasPermi) {
    router.push({ path: 'viewTable', query: { dbName: queryParams.dbName, tableName: name } })
  } else {
    proxy.$modal.msgError(proxy.$t('prole.noPermission'))
  }
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
// 修改按钮操作
function handleUpdate(row) {
  const name = row.name
  var hasPermi = proxy.$auth.hasPermiAnd(['tool:database:edit', 'tool:database:list'])
  if (hasPermi) {
    router.push({ path: 'editTable', query: { dbName: queryParams.dbName, tableName: name } })
  } else {
    proxy.$modal.msgError(proxy.$t('prole.noPermission'))
  }
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

// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)

handleQuery()
</script>
