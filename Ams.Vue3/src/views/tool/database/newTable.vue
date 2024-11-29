<template>
  <el-form :model="form" :rules="rules" ref="formRef" label-width="auto">
    <el-steps :active="activeStep" finish-status="success" simple active-color="#ff4949" inactive-color="#eaeaea">
      <el-step :title="$t('database.databaseInfo')" icon="files"></el-step>
      <el-step :title="$t('database.tableInfo')" icon="memo"></el-step>
      <el-step :title="$t('database.fieldInfo')" icon="list"></el-step>
      <el-step :title="$t('database.visualization')" icon="DocumentCopy"></el-step>
    </el-steps>

    <div v-if="activeStep === 0">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24" :offset="2">
          <el-form-item :label="$t('database.databaseName')" prop="dbName">
            <el-select
              v-model="form.dbName"
              clearable
              :placeholder="$t('btn.selectSearchPrefix') + $t('database.databaseName') + $t('btn.selectSearchSuffix')">
              <el-option v-for="item in dbList" :key="item" :label="item" :value="item" />
            </el-select>
          </el-form-item>
          <el-form-item :label="$t('database.moduleName')" prop="moduleName">
            <el-select
              v-model="form.moduleName"
              clearable
              :placeholder="$t('btn.selectSearchPrefix') + $t('database.moduleName') + $t('btn.selectSearchSuffix')"
              @change="changeModuleName">
              <el-option v-for="item in sortedmoduleList" :key="item.value" :label="item.label" :value="item.value">
                <span class="fl">{{ item.label }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary)">{{ item.value }}</span>
              </el-option>
            </el-select>
            <!-- <span v-for="item in sortedmoduleList" :key="item.value">{{ item.label }},</span> -->
          </el-form-item>
          <el-col :lg="24" :offset="4">
            <el-button class="btn-add" @click="nextStep" :disabled="!form.dbName || !form.moduleName"> {{ $t('btn.nextStep') }}</el-button>
          </el-col>
        </el-col>
      </el-row>
    </div>

    <div v-if="activeStep === 1">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="8" :offset="8">
          <el-form-item :label="$t('database.tableName')" prop="tableName">
            <el-input
              v-model="form.tableName"
              :placeholder="$t('btn.enterPrefix') + $t('database.tableName') + $t('btn.enterSuffix')"
              show-word-limit
              maxlength="40"
              :minlength="6"
              @change="handleCheckTable"></el-input>
          </el-form-item>
        </el-col>
        <el-col :lg="8" :offset="8">
          <el-form-item :label="$t('database.tableDescription')" prop="tableDescription">
            <el-input
              v-model="form.tableDescription"
              :placeholder="$t('btn.enterPrefix') + $t('database.tableDescription') + $t('btn.enterSuffix')"
              show-word-limit
              maxlength="40"
              :minlength="3"></el-input>
          </el-form-item>
        </el-col>
        <el-col :lg="8" :offset="8">
          <span>
            {{ $t('database.memoCreateDatabaseA') }}
            <strong
              ><span :style="{ fontWeight: 'bold', color: 'red', fontStyle: 'italic' }">{{ form.dbName }}</span></strong
            >{{ $t('database.memoCreateDatabaseB') }}
            <strong
              ><span style="color: rgb(49, 4, 212)">{{ form.tableName }}</span></strong
            >{{ $t('database.memoCreateDatabaseC') }}
            <span :style="{ whiteSpace: 'pre-wrap', fontWeight: 'bold', color: 'green', fontStyle: 'italic', textDecoration: 'underline' }">{{
              form.tableDescription
            }}</span>
            <span :style="{ whiteSpace: 'pre-wrap', fontWeight: 'bold', color: 'red', fontStyle: 'italic', textDecoration: 'none' }">{{
              tipsTable
            }}</span>
          </span>
          <el-divider />
          <span> {{ $t('database.memoCreateDatabaseD') }} </span>
        </el-col>
      </el-row>
      <el-col :lg="8" :offset="12">
        <el-button type="warning" plain @click="prevStep">{{ $t('btn.prevStep') }}</el-button>
        <el-button class="btn-add" @click="nextStep" :disabled="!form.tableName || !form.tableDescription || tableCheck == 1">{{
          $t('btn.nextStep')
        }}</el-button>
      </el-col>
    </div>

    <div v-if="activeStep === 2">
      <!-- 工具区域 -->
      <el-row :gutter="15" class="mb10">
        <el-col :span="1.5">
          <el-button class="btn-add" v-hasPermi="['fico:profitcenter:add']" plain icon="plus" @click="handleNewColumn">
            {{ $t('database.newTable') }}
          </el-button>
        </el-col>
        <el-col :span="1.5">
          <el-button
            class="btn-view"
            :disabled="isPkDisabled"
            v-hasPermi="['fico:profitcenter:edit']"
            plain
            icon="plus"
            @click="handleNewPrimaryKey">
            {{ $t('database.newPk') }}
          </el-button>
        </el-col>
        <el-col :span="1.5">
          <el-button
            class="btn-import"
            :disabled="isNewBaseDisabled"
            v-hasPermi="['fico:profitcenter:delete']"
            plain
            icon="plus"
            @click="handleNewBaseColumn">
            {{ $t('database.newBaseColumn') }}
          </el-button>
        </el-col>

        <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
      </el-row>
      <el-table
        :data="tableData"
        ref="createTableRef"
        border
        height="650"
        row-key="id"
        v-drag-drop
        header-cell-class-name="el-table-header-cell"
        highlight-current-row>
        <el-table-column type="selection" width="55"></el-table-column>
        <el-table-column label="ID" prop="id" width="50"></el-table-column>
        <el-table-column :label="$t('database.columnName')" prop="columnName" width="300" align="center">
          <template #default="scope">
            <el-input v-model="scope.row.columnName" v-show="scope.row.editing" show-word-limit maxlength="40"></el-input>
            <span v-show="!scope.row.editing">{{ scope.row.columnName }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('database.dataType')" prop="type" align="center">
          <template #default="scope">
            <el-select
              v-model="scope.row.type"
              v-show="scope.row.editing"
              style="width: 140px"
              @change="checkDataType(scope.row.type, scope.$index)">
              <el-option v-for="item in dateTypeList" :key="item.value" :label="item.label" :value="item.value">
                <span class="fl">{{ item.label }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary)">{{ item.value }}</span>
              </el-option>
            </el-select>
            <span v-show="!scope.row.editing">{{ scope.row.type }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('database.length')" prop="length" align="center">
          <template #default="scope">
            <el-input-number
              lazy
              v-model="scope.row.length"
              :min="0"
              :max="9999"
              v-show="scope.row.editing"
              style="width: 120px"
              :disabled="isLength(scope.row.type)"
              @input="checkRange(scope.$index)"
              @change="checkRange(scope.$index)"></el-input-number>
            <span v-show="!scope.row.editing">{{ scope.row.length }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('database.decimalDigits')" prop="precision" align="center">
          <template #default="scope">
            <el-input-number
              lazy
              v-model="scope.row.precision"
              :min="0"
              :max="5"
              v-show="scope.row.editing"
              style="width: 120px"
              :disabled="!isPrecision(scope.row.type)"
              @input="checkRange(scope.$index)"
              @change="checkRange(scope.$index)"></el-input-number>
            <span v-show="!scope.row.editing">{{ scope.row.precision }}</span>
          </template>
        </el-table-column>

        <el-table-column :label="$t('database.isPrimarykey')" prop="primaryKey" width="120" align="center">
          <template #default="scope">
            <el-checkbox v-model="scope.row.primaryKey" :disabled="!isBigInt(scope.row.type)"></el-checkbox>
          </template>
        </el-table-column>
        <el-table-column :label="$t('database.isIdentity')" prop="autoIncrement" width="180" align="center">
          <template #default="scope">
            <el-checkbox v-model="scope.row.autoIncrement" :disabled="!isBigInt(scope.row.type)"></el-checkbox>
          </template>
        </el-table-column>

        <el-table-column :label="$t('database.isNullable')" prop="required" width="120" align="center">
          <template #default="scope">
            <el-checkbox v-model="scope.row.required" :disabled="isNullable(scope.row.type)"></el-checkbox>
          </template>
        </el-table-column>
        <el-table-column :label="$t('database.columnDescription')" prop="description" align="center">
          <template #default="scope">
            <el-input
              v-model="scope.row.description"
              v-show="scope.row.editing"
              show-word-limit
              maxlength="40"
              :disabled="scope.row.columnName === 'Id'"></el-input>
            <span v-show="!scope.row.editing">{{ scope.row.description }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('btn.operation')" width="160" prop="editing" align="center">
          <template #default="scope">
            <el-button-group>
              <el-button
                class="btn-delete"
                plain
                size="small"
                icon="delete"
                :title="$t('btn.delete')"
                v-hasPermi="['pp:defecttotal:delete']"
                v-if="scope.row.columnName !== 'Id'"
                @click="handleDelete(scope.row)"></el-button>
            </el-button-group>
          </template>
        </el-table-column>
      </el-table>

      <!-- {{ tableData }} -->
      <el-row :gutter="15" class="mb10">
        <el-col :lg="24" :offset="2">
          <span>
            {{ $t('database.memoCreateDatabaseE')
            }}<span :style="{ fontWeight: 'bold', color: 'green', fontStyle: 'italic', textDecoration: 'underline' }">{{
              $t('database.memoCreateDatabaseF')
            }}</span
            >{{ $t('database.memoCreateDatabaseG') }}
          </span>
        </el-col>
        <el-col :lg="24" :offset="12">
          <el-button type="warning" plain @click="prevStep">{{ $t('btn.prevStep') }}</el-button>
          <el-button class="btn-add" @click="nextStep" v-if="tableData.length > 1">{{ $t('btn.nextStep') }}</el-button>
          <!-- <el-button type="primary" @click="submitForm" v-if="tableData.length > 1">{{ $t('btn.preview') }}</el-button> -->
        </el-col>
      </el-row>
    </div>

    <div v-if="activeStep === 3">
      <el-row :gutter="2">
        <el-col :lg="24">
          <div class="scrollable-div">
            <highlightjs language="sql" :code="form.createTableSql"></highlightjs>
          </div>
          <!-- <pre v-highlight>          
          <code >            
            {{ form.createTableSql }}            
          </code>
        </pre> -->
          <!-- <code class="hljs" v-html="highlightedCode(form.createTableSql)"></code> -->
        </el-col>
        <el-col :lg="24" :offset="12">
          <el-button type="warning" plain @click="prevStep">{{ $t('btn.prevStep') }}</el-button>
          <el-button type="primary" @click="handleCopyForm" :disabled="isCopied" v-if="tableData.length > 1">{{ $t('btn.copy') }}</el-button>

          <el-button type="primary" @click="handleCreateTable" :disabled="isCreate" v-if="tableData.length > 1">{{
            $t('database.newTable')
          }}</el-button>
        </el-col>
      </el-row>
    </div>
  </el-form>
  <!-- 添加或修改资产类别对话框 -->
  <el-dialog :title="title" :lock-scroll="false" v-model="open">
    <el-row :gutter="20">
      <el-col :lg="24">
        <highlightjs language="sql" :code="form.createTableSql"></highlightjs>
      </el-col>
      <el-col :lg="24" :offset="12">
        <el-button type="primary" @click="handleCopyForm" :disabled="isCopied" v-if="tableData.length > 1">{{ $t('btn.copy') }}</el-button>
      </el-col>
    </el-row>
  </el-dialog>
</template>

<script setup>
// 引入我们封装的 表单拖拽函数
import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listDataBases, queryTableExists, addDataTable } from '@/api/tool/database'

import useClipboard from 'vue-clipboard3'

const { toClipboard } = useClipboard()
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 数据库数据
const dbList = ref([])
const tableCheck = ref(0)
const moduleList = ref([
  { value: 'am', label: '资产' },
  { value: 'fi', label: '管理会计' },
  { value: 'co', label: '财务会计' },
  { value: 'pp', label: '生产' },
  { value: 'sd', label: '销售' },
  { value: 'mm', label: '物料' },
  { value: 'qm', label: '质量' },
  { value: 'cs', label: '客服' },
  { value: 'hr', label: '人资' },
  { value: 'pm', label: '设备' },
  { value: 'ps', label: '项目' },
  { value: 'bw', label: '商务智能' },
  { value: 'wf', label: '工作流' },
  { value: 'is', label: '解决方案' },
  { value: 'les', label: '物流' },
  { value: 'tr', label: '资金' },
  { value: 'sem', label: '战略' }
])
// 按 value 排序
const sortedmoduleList = computed(() => {
  return [...moduleList.value].sort((a, b) => a.label.localeCompare(b.label))
})
const dateTypeList = ref([
  { value: 'bigint', label: 'bigint' },
  { value: 'decimal', label: 'decimal' },
  { value: 'int', label: 'int' },
  { value: 'nvarchar', label: 'nvarchar' },
  { value: 'varchar', label: 'varchar' },
  { value: 'char', label: 'char' },
  { value: 'text', label: 'text' },
  { value: 'datetime', label: 'datetime' },
  { value: 'nvarchar(max)', label: 'nvarchar(max)' },
  { value: 'varchar(max)', label: 'varchar(max)' },
  { value: 'uniqueidentifier', label: 'uniqueidentifier' }
])
const isBigInt = (type) => {
  return type === 'bigint'
}
const isNullable = (type) => {
  return type === 'bigint' || type === 'int' || type === 'decimal' || type === 'uniqueidentifier'
}
const isPrecision = (type) => {
  return type === 'decimal'
}
const isLength = (type) => {
  return (
    type === 'bigint' ||
    type === 'int' ||
    type === 'datetime' ||
    type === 'text' ||
    type === 'nvarchar(max)' ||
    type === 'varchar(max)' ||
    type === 'uniqueidentifier'
  )
}
// 使用 computed 属性来避免重复创建规则
const rules = computed(() => ({
  tableName: [
    { required: true, message: `${proxy.$t('btn.enterPrefix')}${proxy.$t('database.tableName')}`, trigger: 'blur' },
    { pattern: /^[a-z_]+$/, message: proxy.$t('database.patternTableName'), trigger: ['blur', 'input'] },
    { min: 6, message: proxy.$t('database.validTableName'), trigger: 'blur' }
  ],
  tableDescription: [
    { required: true, message: `${proxy.$t('btn.enterPrefix')}${proxy.$t('database.tableDescription')}`, trigger: 'blur' },
    {
      pattern:
        /^[\u2E80-\u2FDF\u3040-\u318F\u31A0-\u31BF\u31F0-\u31FF\u3400-\u4DB5\u4E00-\u9FFF\uA960-\uA97F\uAC00-\uD7FF][\u2E80-\u2FDF\u3040-\u318F\u31A0-\u31BF\u31F0-\u31FF\u3400-\u4DB5\u4E00-\u9FFF\uA960-\uA97F\uAC00-\uD7FFA-Z]*$/,
      message: proxy.$t('database.patternTableDescription'),
      trigger: 'blur'
    },
    { min: 3, message: proxy.$t('database.validTableDescription'), trigger: 'blur' }
  ]
}))
const state = reactive({
  form: {
    dbName: '',
    moduleName: '',
    tableName: '',
    tableDescription: '',
    createTableSql: ''
  }
})

// 将响应式对象转换成普通对象
const { form } = toRefs(state)

getDbList()
/** 查询表数据 */
function getDbList() {
  listDataBases()
    .then((res) => {
      dbList.value = res.data.dbList
    })
    .catch((err) => {
      console.error('获取数据库列表失败:', err)
      // 可以加入错误处理逻辑，比如提示用户
    })
}
const tipsTable = ref('')
const getTableExists = () => {
  //console.log(form.value.dbName, form.value.tableName)
  queryTableExists(form.value.tableName)
    .then((res) => {
      //console.log(data === true)

      tableCheck.value = res.data

      //console.log(tableCheck.value)
    })
    .catch((err) => {
      console.error('获取数据库列表失败:', err)
      // 可以加入错误处理逻辑，比如提示用户
    })
}

const handleCheckTable = () => {
  //console.log(tableExists.value)
  getTableExists()

  if (tableCheck.value === 1) {
    isCreate.value = true
    tipsTable.value = proxy.$t('database.tableExists')
  } else {
    isCreate.value = false
    tipsTable.value = proxy.$t('database.tableAvailable')
  }
  //console.log(tableCheck.value)
}
const changeModuleName = () => {
  if (form.value.moduleName) {
    form.value.tableName = `${form.value.moduleName}_`
  } else {
    form.value.tableName = ''
  }
}
const activeStep = ref(0)
//const dbName = ref(null)
//const tableName = ref('')

const formRef = ref(null)

//const tableDescription = ref('')
//const databases = ref([]); // Populate this with your database list
const tableData = reactive([
  {
    id: 1,
    columnName: 'Id',
    type: 'bigint',
    length: 0,
    precision: 0,
    primaryKey: true,
    autoIncrement: true,
    required: true,
    description: 'ID',
    editing: true
  }
])
// 生成唯一ID的函数
function generateUniqueId() {
  return tableData.length ? Math.max(...tableData.map((item) => item.id)) + 1 : 1
}
// 更新 id 的函数
function updateRowIds() {
  tableData.forEach((item, index) => {
    item.id = index + 1 // 重新分配 id 从1开始
    if (item.columnName.includes('Column_ID_')) {
      item.columnName = `Column_ID_${item.id}`
      item.description = `栏位描述_${item.id}`
    }
  })
}
const nextStep = () => {
  //console.log(tableData)
  formRef.value.validate((valid) => {
    if (valid) {
      if (activeStep.value < 3) {
        activeStep.value++
        if (activeStep.value === 3) {
          submitForm()
        }
      }
    } else {
      proxy.$modal.msgError(proxy.$t('database.validError'))
      return false
    }
  })
}

const prevStep = () => {
  if (activeStep.value > 0) {
    activeStep.value--
  }
}
const checkRange = ($index) => {
  if (tableData[$index].length + tableData[$index].precision > 38) {
    tableData[$index].length = 38 - tableData[$index].precision
    proxy.$modal.msgError(proxy.$t('database.dataRange'))
  }
}
//弹出层标题
const title = ref('')
//定义对话框打开或关闭
const open = ref(false)
const createTable = ref('')
const createTableRef = ref()
const msDescription = ref('')
const defaultValue = ref('')
const copyText = ref('')
const submitForm = () => {
  // 遍历 JSON 数据并赋值
  createTable.value = ''
  msDescription.value = ''
  defaultValue.value = ''
  // 遍历并处理数据

  tableData.forEach((item) => {
    if (item.type === 'bigint') {
      createTable.value = `${'[' + item.columnName + '] [' + item.type + '] NOT NULL,\n'}` //'[' + item.columnName + '] [' + item.type + '] NOT NULL,'
      msDescription.value += `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        item.description +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "', @level2type=N'COLUMN',@level2name=N'" +
        item.columnName +
        "'\nGO\n"
      }`
    }
    if (item.type === 'int') {
      //console.log('[' + item.columnName + '] [' + item.type + '] NOT NULL,')
      createTable.value += `${'[' + item.columnName + '] [' + item.type + '] NOT NULL,\n'}`
      msDescription.value += `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        item.description +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "', @level2type=N'COLUMN',@level2name=N'" +
        item.columnName +
        "'\nGO\n"
      }`
      defaultValue.value += `${'\nALTER TABLE [dbo].[' + form.value.tableName + "] ADD  DEFAULT ('0') FOR [" + item.columnName + ']\nGO\n'}`
    }
    if (item.type === 'decimal') {
      //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ',' + item.precision + ') NOT NULL,')
      createTable.value += `${'[' + item.columnName + '] [' + item.type + '] (' + item.length + ',' + item.precision + ') NOT NULL,\n'}`
      msDescription.value += `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        item.description +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "', @level2type=N'COLUMN',@level2name=N'" +
        item.columnName +
        "'\nGO\n"
      }`
      defaultValue.value += `${'\nALTER TABLE [dbo].[' + form.value.tableName + "] ADD  DEFAULT ('0') FOR [" + item.columnName + ']\nGO\n'}`
    }
    if (item.type === 'datetime') {
      //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ',' + item.precision + ') NOT NULL,')
      createTable.value += `${'[' + item.columnName + '] [' + item.type + ']  NULL,\n'}`
      msDescription.value += `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        item.description +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "', @level2type=N'COLUMN',@level2name=N'" +
        item.columnName +
        "'\nGO\n"
      }`
    }
    if (item.type === 'char') {
      //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ',' + item.precision + ') NOT NULL,')
      createTable.value += `${'[' + item.columnName + '] [' + item.type + '] (' + item.length + ') NULL,\n'}`
      msDescription.value += `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        item.description +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "', @level2type=N'COLUMN',@level2name=N'" +
        item.columnName +
        "'\nGO\n"
      }`
    }
    if (item.type === 'text') {
      //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ',' + item.precision + ') NOT NULL,')
      createTable.value += `${'[' + item.columnName + '] [' + item.type + '] NULL,\n'}`
      msDescription.value += `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        item.description +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "', @level2type=N'COLUMN',@level2name=N'" +
        item.columnName +
        "'\nGO\n"
      }`
    }
    if (item.type === 'uniqueidentifier') {
      //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ',' + item.precision + ') NOT NULL,')
      createTable.value += `${'[' + item.columnName + '] [' + item.type + ']  NOT NULL,\n'}`
      msDescription.value += `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        item.description +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "', @level2type=N'COLUMN',@level2name=N'" +
        item.columnName +
        "'\nGO\n"
      }`
    }
    if (item.type === 'varchar' || item.type === 'nvarchar') {
      if (item.required) {
        //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ') NOT NULL,')
        createTable.value += `${'[' + item.columnName + '] [' + item.type + '] (' + item.length + ') NOT NULL,\n'}`
        msDescription.value += `${
          "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
          "@value=N'" +
          item.description +
          "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
          form.value.tableName +
          "', @level2type=N'COLUMN',@level2name=N'" +
          item.columnName +
          "'\nGO\n"
        }`
      } else {
        //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ') NULL,')
        createTable.value += `${'[' + item.columnName + '] [' + item.type + '] (' + item.length + ') NULL,\n'}`
        msDescription.value += `${
          "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
          "@value=N'" +
          item.description +
          "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
          form.value.tableName +
          "', @level2type=N'COLUMN',@level2name=N'" +
          item.columnName +
          "'\nGO\n"
        }`
      }
    }
    if (item.type === 'varchar(max)' || item.type === 'nvarchar(max)') {
      const index = item.type.indexOf('(') // 找到分隔符的位置

      // 截取字符串
      const substring = index !== -1 ? item.type.substring(0, index) : originalString
      if (item.required) {
        //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ') NOT NULL,')
        createTable.value += `${'[' + item.columnName + '] [' + substring + '] (max) NOT NULL,\n'}`
        msDescription.value += `${
          "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
          "@value=N'" +
          item.description +
          "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
          form.value.tableName +
          "', @level2type=N'COLUMN',@level2name=N'" +
          item.columnName +
          "'\nGO\n"
        }`
      } else {
        //console.log('[' + item.columnName + '] [' + item.type + '] (' + item.length + ') NULL,')
        createTable.value += `${'[' + item.columnName + '] [' + substring + '] (max) NULL,\n'}`
        msDescription.value += `${
          "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
          "@value=N'" +
          item.description +
          "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
          form.value.tableName +
          "', @level2type=N'COLUMN',@level2name=N'" +
          item.columnName +
          "'\nGO\n"
        }`
      }
    }
    //console.log(createTable.value)
    // 在这里处理每个item
    form.value.createTableSql =
      '\nUSE [' +
      form.value.dbName +
      ']\nGO\n' +
      'CREATE TABLE [dbo].[' +
      form.value.tableName +
      '](\n' +
      createTable.value +
      'CONSTRAINT [PK_' +
      form.value.tableName +
      '_Id] PRIMARY KEY CLUSTERED \n' +
      '(\n' +
      '[Id] ASC\n' +
      ')WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\n) ON [PRIMARY]\nGO\n' +
      msDescription.value +
      `${
        "EXEC sys.sp_addextendedproperty @name=N'MS_Description', " +
        "@value=N'" +
        form.value.tableDescription +
        "', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" +
        form.value.tableName +
        "'\nGO\n"
      }` +
      defaultValue.value
    copyText.value = form.value.createTableSql
    //console.log('数据库创建成功:' + copyText.value.replace(/\nGO\n/g, '\n'))
  })
}
const createDataTable = () => {
  //console.log(form.value.createTableSql)
  addDataTable(form.value.createTableSql.replace(/\nGO\n/g, '\n'), form.value.tableName).then((res) => {
    //console.log(res)
    if (res.data === -1) {
      proxy.$modal.msgSuccess(proxy.$t('database.tableSuccess'))
    }
    if (res.data === -2) {
      proxy.$modal.msgError(proxy.$t('database.tableNotFound'))
    }
    if (res.data === 0) {
      proxy.$modal.msgError(proxy.$t('database.tableExists'))
    }
  })
}

// function highlightedCode(code) {
//   const result = hljs.highlightAuto(code || '\n')
//   return result.value || '&nbsp;'
// }
const isCopied = ref(false)
const isCreate = ref(false)

const handleCopyForm = async () => {
  try {
    //console.log(caches)
    await toClipboard(copyText.value)
    isCopied.value = true // Disable button after copying
    //open.value = false
    copyText.value = ''
    proxy.$modal.msgSuccess(proxy.$t('common.tipCopySucceed'))
  } catch (e) {
    //console.log(e)
    isCopied.value = false // Disable button after copying
    proxy.$modal.msgError(proxy.$t('layout.mybrowserNg'))
  }
}

// 监视 copyText 的变化
watch(copyText, (newText) => {
  if (newText) {
    isCopied.value = true
    handleCopyForm(newText) // 当 copyText 更新时复制到剪贴板
  }
})

const handleCreateTable = () => {
  createDataTable()
  isCreate.value = true
}
// const handleCopyForm = async () => {
//   try {
//     await navigator.clipboard.writeText(from.value.createTable)
//     proxy.$modal.msgSuccess(proxy.$t('common.tipCopySucceed'))
//   } catch (err) {
//     proxy.$modal.msgError(proxy.$t('common.tipOperationSucceed')) + err
//   }
// }
const handleNewColumn = () => {
  tableData.push({
    id: generateUniqueId(),
    columnName: `Column_ID_${tableData.length}`,
    description: `栏位描述_${tableData.length}`,
    primaryKey: false,
    autoIncrement: false,
    type: 'varchar',
    required: false,
    length: 10,
    precision: 0,
    editing: true
  })
  updateRowIds()
}
const checkDataType = (type, $index) => {
  console.log(type, $index)
  if (type === 'bigint') {
    ;(tableData[$index].length = 0),
      (tableData[$index].precision = 0),
      (tableData[$index].required = true),
      (tableData[$index].primaryKey = true),
      (tableData[$index].autoIncrement = true)
  }
  if (type === 'int') {
    ;(tableData[$index].length = 0),
      (tableData[$index].precision = 0),
      (tableData[$index].required = true),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'decimal') {
    ;(tableData[$index].length = 18),
      (tableData[$index].precision = 5),
      (tableData[$index].required = true),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'char') {
    ;(tableData[$index].length = 255),
      (tableData[$index].precision = 0),
      (tableData[$index].required = false),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'varchar') {
    ;(tableData[$index].length = 40),
      (tableData[$index].precision = 0),
      (tableData[$index].required = false),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'varchar(max)') {
    ;(tableData[$index].length = 0),
      (tableData[$index].precision = 0),
      (tableData[$index].required = false),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'datetime') {
    ;(tableData[$index].length = 0),
      (tableData[$index].precision = 0),
      (tableData[$index].required = false),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'nvarchar') {
    ;(tableData[$index].length = 40),
      (tableData[$index].precision = 0),
      (tableData[$index].required = false),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'nvarchar(max)') {
    ;(tableData[$index].length = 0),
      (tableData[$index].precision = 0),
      (tableData[$index].required = false),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'text') {
    ;(tableData[$index].length = 0),
      (tableData[$index].precision = 0),
      (tableData[$index].required = false),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
  if (type === 'uniqueidentifier') {
    ;(tableData[$index].length = 0),
      (tableData[$index].precision = 0),
      (tableData[$index].required = true),
      (tableData[$index].primaryKey = false),
      (tableData[$index].autoIncrement = false)
  }
}
const handleNewPrimaryKey = () => {
  tableData.push({
    id: generateUniqueId(),
    columnName: 'Id',
    description: 'ID',
    primaryKey: true,
    autoIncrement: true,
    type: 'bigint',
    required: true,
    length: 0,
    precision: 0
  })
}
const isPkDisabled = computed(() => {
  return tableData.some((item) => item.columnName === 'Id') // 判断是否有ID字段
})

const isNewBaseDisabled = computed(() => {
  return tableData.some((item) => item.columnName === 'Id') // 判断是否有ID字段
})
const handleNewBaseColumn = () => {
  addBaseColumn()
}
//const colIndex = tableData.length
// 增加通用基础列
function addBaseColumn() {
  const fileds = [
    {
      id: generateUniqueId(),
      columnName: 'Remark',
      description: '备注',
      primaryKey: false,
      autoIncrement: false,
      type: 'nvarchar',
      required: false,
      length: 500,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Ref01',
      description: '预留A',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 1,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Ref02',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 8,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Ref03',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 30,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Ref04',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'decimal',
      required: true,
      length: 18,
      precision: 5
    },
    {
      id: generateUniqueId(),
      columnName: 'Ref05',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'decimal',
      required: true,
      length: 18,
      precision: 5
    },
    {
      id: generateUniqueId(),
      columnName: 'Ref06',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'decimal',
      required: true,
      length: 18,
      precision: 5
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf01',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 100,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf02',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 100,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf03',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 200,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf04',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 300,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf05',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 400,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf06',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 500,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf51',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'int',
      required: true,
      length: 0,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf52',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'int',
      required: true,
      length: 0,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf53',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'int',
      required: true,
      length: 0,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf54',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'decimal',
      required: true,
      length: 18,
      precision: 5
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf55',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'decimal',
      required: true,
      length: 18,
      precision: 5
    },
    {
      id: generateUniqueId(),
      columnName: 'Udf56',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'decimal',
      required: true,
      length: 18,
      precision: 5
    },
    {
      id: generateUniqueId(),
      columnName: 'Is_deleted',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'int',
      required: true,
      length: 0,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Create_by',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 64,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Create_time',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'datetime',
      required: false,
      length: 0,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Update_by',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'varchar',
      required: false,
      length: 64,
      precision: 0
    },
    {
      id: generateUniqueId(),
      columnName: 'Update_time',
      description: '',
      primaryKey: false,
      autoIncrement: false,
      type: 'datetime',
      required: false,
      length: 0,
      precision: 0
    }
  ]
  generateUniqueId()
  fileds.forEach((m) => {
    tableData.push({
      id: generateUniqueId(),
      columnName: m.columnName,
      description: m.description,
      primaryKey: m.primaryKey,
      autoIncrement: m.autoIncrement,
      type: m.type,
      required: m.required,
      length: m.length,
      precision: m.precision,
      creator: m.creator,
      createTime: m.createTime,
      editing: m.editing
    })
    generateUniqueId()
  })
}
// 修改后的 handleDelete 函数
const handleDelete = (row) => {
  if (row.columnName === 'Id') {
    proxy.$modal.msgError('无法删除ID字段') // 提示用户不能删除ID字段
    return // 不执行删除逻辑
  }
  const index = tableData.findIndex((item) => item.id === row.id) // 获取当前行的索引
  if (index !== -1) {
    tableData.splice(index, 1) // 删除当前行
  }
  updateRowIds()
}
/*************** table column  回车代码 end *************/
// 拖动排序
</script>

<style scoped>
.draggable {
  background: burlywood;
}
/* 可以添加一些样式来美化代码块 */
.scrollable-div {
  width: 100%; /* 固定宽度 */
  height: 650px; /* 固定高度 */
  overflow: auto; /* 启用滚动条 */
  border: 1px solid #ccc; /* 可选：边框样式 */
}
</style>
