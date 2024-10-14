<!--
 * @Descripttion: 预算科目/fico_budget_accounting
 * @Version: 0.24.651.29609
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/10/12 16:36:02
 * @column：38
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="公司代码" prop="md004">
        <el-select filterable clearable   v-model="queryParams.md004" :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="预算科目" prop="md006">
        <el-input v-model="queryParams.md006" :placeholder="$t('btn.enterSearchPrefix')+'预算科目'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="币种" prop="md007">
        <el-select filterable clearable   v-model="queryParams.md007" :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="会计科目" prop="md008">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_accounting_title" :loading="loading" v-model="queryParams.md008" :placeholder="$t('btn.selectSearchPrefix')+'会计科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_accounting_title " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="名称" prop="md009">
        <el-input v-model="queryParams.md009" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="冻结" prop="md014">
        <el-radio-group v-model="queryParams.md014">
          <el-radio :value="-1">{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
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
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button class="btn-add" v-hasPermi="['fico:budgetaccounting:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
       <el-col :span="1.5">
        <el-button type="info" plain icon="sort" @click="toggleExpandAll">{{ $t('btn.expand') }}/{{  $t('btn.collapse')
          }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetaccounting:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetaccounting:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table 
      v-if="refreshTable"
      :data="dataList"
      v-loading="loading"
      ref="tableRef"
      border height="600px"
      highlight-current-row
      @selection-change="handleSelectionChange"
      :default-expand-all="isExpandAll"
      row-key="id"
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="parentId" label="父ID" align="center" v-if="columns.showColumn('parentId')"/>
      <el-table-column prop="md003" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md003')"/>
      <el-table-column prop="md004" label="公司代码" align="center" v-if="columns.showColumn('md004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.md004" />
        </template>
      </el-table-column>
      <el-table-column prop="md005" label="语言Key" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md005')"/>
      <el-table-column prop="md006" label="预算科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md006')"/>
      <el-table-column prop="md007" label="币种" align="center" v-if="columns.showColumn('md007')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.md007" />
        </template>
      </el-table-column>
      <el-table-column prop="md008" label="会计科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md008')"/>
      <el-table-column prop="md009" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md009')"/>
      <el-table-column prop="md010" label="长文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md010')"/>
      <el-table-column prop="md011" label="附加文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md011')"/>
      <el-table-column prop="md012" label="费用类型" align="center" v-if="columns.showColumn('md012')">
        <template #default="scope">
          <dict-tag :options=" options.sys_exp_type " :value="scope.row.md012" />
        </template>
      </el-table-column>
      <el-table-column prop="md013" label="统驭科目" align="center" v-if="columns.showColumn('md013')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mitkz_list " :value="scope.row.md013" />
        </template>
      </el-table-column>
      <el-table-column prop="md014" label="冻结" align="center" v-if="columns.showColumn('md014')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.md014" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>

      <el-table-column :label="$t('btn.operation')" align="center" width="140">
        <template #default="scope">
          <el-button v-hasPermi="['fico:budgetaccounting:edit']" class="btn-edit" icon="edit" size="small" :title="$t('btn.edit')" 
            @click="handleUpdate(scope.row)"></el-button>      
          <el-button v-hasPermi="['fico:budgetaccounting:delete']" class="btn-delete" icon="delete" size="small" :title="$t('btn.delete')"  
            @click="handleDelete(scope.row)"></el-button>
        </template>      
      </el-table-column>
    </el-table>

    <!-- 添加或修改预算科目对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row :gutter="20">
    
          <el-col :lg="24">
            <el-form-item :label="$t('common.tipParentId')" prop="parentId">
              <el-cascader
                class="w100"
                :options="dataList"
                :props="{ checkStrictly: true, value: 'id', label: 'md006', emitPath: false }"
                :placeholder="$t('common.tipPreviousName')"
                clearable
                v-model="form.parentId"
              >
                <template #default="{ node, data }">
                  <span>{{ data.md006 }}</span>
                  <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
                </template>
              </el-cascader>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团" prop="md003">
              <el-input  v-model="form.md003" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司代码" prop="md004">
              <el-select filterable clearable   v-model="form.md004"  :placeholder="$t('btn.selectPrefix')+'公司代码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="语言Key" prop="md005">
              <el-input  v-model="form.md005" :placeholder="$t('btn.enterPrefix')+'语言Key'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算科目" prop="md006">
              <el-input  v-model="form.md006" :placeholder="$t('btn.enterPrefix')+'预算科目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="md007">
              <el-select filterable clearable   v-model="form.md007"  :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="会计科目" prop="md008">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_accounting_title" 
              :loading="loading" v-model="form.md008"  :placeholder="$t('btn.selectPrefix')+'会计科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_accounting_title" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="md009">
              <el-input  v-model="form.md009" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="长文本" prop="md010">
              <el-input  v-model="form.md010" :placeholder="$t('btn.enterPrefix')+'长文本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="80" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="附加文本" prop="md011">
              <el-input  v-model="form.md011" :placeholder="$t('btn.enterPrefix')+'附加文本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="120" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="费用类型" prop="md012">
              <el-select filterable clearable   v-model="form.md012"  :placeholder="$t('btn.selectPrefix')+'费用类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_exp_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统驭科目" prop="md013">
              <el-select filterable clearable   v-model="form.md013"  :placeholder="$t('btn.selectPrefix')+'统驭科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_mitkz_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="冻结" prop="md014">
              <el-radio-group v-model="form.md014">
                <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :label="parseInt(item.dictValue)">{{item.dictLabel}}</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
          <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
        </div>
      </template>
    </el-dialog>

  </div>
</template>

<script setup name="ficobudgetaccounting">
  import '@/assets/styles/btn-custom.scss'
import { treelistFicoBudgetAccounting, listFicoBudgetAccounting, 
 addFicoBudgetAccounting, delFicoBudgetAccounting, updateFicoBudgetAccounting,getFicoBudgetAccounting,
 } from '@/api/accounting/ficobudgetaccounting.js'
//防抖处理函数 import { debounce } from 'lodash';
import { debounce } from 'lodash';
//获取当前组件实例
const { proxy } = getCurrentInstance()
//展开否
const isExpandAll = ref(false)
const refreshTable = ref(true)
function toggleExpandAll() {
  refreshTable.value = false
  isExpandAll.value = !isExpandAll.value
  nextTick(() => {
    refreshTable.value = true
  })
}

// 选中id数组
const ids = ref([])
//是否单选
const single = ref(true)
//是否多选
const multiple = ref(true)
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
  md004: undefined,
  //是否查询（1是）
  md006: undefined,
  //是否查询（1是）
  md007: undefined,
  //是否查询（1是）
  md008: undefined,
  //是否查询（1是）
  md009: undefined,
   //是否查询（1是）
  md014: -1,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'md003', label: '集团' },
  { visible: true, prop: 'md004', label: '公司代码' },
  { visible: true, prop: 'md005', label: '语言Key' },
  { visible: true, prop: 'md006', label: '预算科目' },
  { visible: true, prop: 'md007', label: '币种' },
  { visible: true, prop: 'md008', label: '会计科目' },
  { visible: false, prop: 'md009', label: '名称' },
  { visible: false, prop: 'md010', label: '长文本' },
  { visible: false, prop: 'md011', label: '附加文本' },
  { visible: false, prop: 'md012', label: '费用类型' },
  { visible: false, prop: 'md013', label: '统驭科目' },
  { visible: false, prop: 'md014', label: '冻结' },
  { visible: false, prop: 'remark', label: '备注' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

//定义远程搜索变量
const remotequeryList_sql_accounting_title=ref([])
//定义远程搜索变量
const remotequery_sql_accounting_title=ref([])
//远程字典参数
var remotedictParams_sql_accounting_title = [
    { dictType: "sql_accounting_title" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_accounting_title).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_accounting_title.value = element.list
      })
      //console.log(remotequeryList_sql_accounting_title)
    })
  })
//远程搜索
const remoteMethod_sql_accounting_title = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_accounting_title.value = remotequeryList_sql_accounting_title.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_accounting_title(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_accounting_title.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_accounting_title = debounce((query) => {
    let arr = remotequeryList_sql_accounting_title.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_accounting_title.value = arr.slice(0, 5)
      addFilterOptions_sql_accounting_title(query)
    } else {
      remotequery_sql_accounting_title.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_accounting_title =debounce((dictValue) => {
    let target = remotequeryList_sql_accounting_title.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_accounting_title.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_accounting_title.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
//字典参数
var dictParams = [
  { dictType: "sql_corp_list" },
  { dictType: "sql_global_currency" },
  { dictType: "sys_exp_type" },
  { dictType: "sql_mitkz_list" },
  { dictType: "sys_is_status" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从预算科目/fico_budget_accounting表记录数据
function getList(){
  loading.value = true
  treelistFicoBudgetAccounting(queryParams).then(res => {
    const { code, data } = res
    if (code == 200) {
      //dataList.value = res.data.result
      //total.value = res.data.totalNum
      dataList.value = res.data
      loading.value = false
    }
  })
    .catch(() => {
      loading.value = false
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
const title = ref("")// 操作类型 1、add 2、edit 3、view
//定义响应式变量
const opertype = ref(0)
//定义对话框打开或关闭
const open = ref(false)
//reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const state = reactive({
  form: {},
//正则表达式
  rules: {
    md003: [{ required: true, message: "集团不能为空", trigger: "blur" }],
    md004: [{ required: true, message: "公司代码不能为空", trigger: "change" }],
    md006: [{ required: true, message: "预算科目不能为空", trigger: "blur" }],
    md007: [{ required: true, message: "币种不能为空", trigger: "change" }],
    md008: [{ required: true, message: "会计科目不能为空", trigger: "blur" }],
    md009: [{ required: true, message: "名称不能为空", trigger: "blur" }],
    md014: [{ required: true, message: "冻结不能为空", trigger: "blur", type: "number" }],
  },
//字典名称
  options: {
    // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_currency: [],
    // 费用类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_exp_type: [],
    // 统驭科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_mitkz_list: [],
    // 冻结 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_status: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    parentId: 0,
    md003: null,
    md004: [],
    md005: null,
    md006: null,
    md007: [],
    md008: [],
    md009: null,
    md010: null,
    md011: null,
    md012: [],
    md013: [],
    md014: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}

// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'预算科目'
  opertype.value = 1
  form.value.md004= []
  form.value.md007= []
  form.value.md008= []
  form.value.md012= []
  form.value.md013= []
  form.value.md014= 0
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoBudgetAccounting(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '预算科目'
      opertype.value = 2

      form.value = {
      ...data,
      }
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {
      if (form.value.id != undefined && opertype.value === 2) {
        updateFicoBudgetAccounting(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoBudgetAccounting(form.value).then((res) => {
           proxy.$modal.msgSuccess(proxy.$t('common.tipAddSucceed'))
            open.value = false
            getList()
          })
          .catch(() => {})
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.id || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
  .then(function () {
      return delFicoBudgetAccounting(Ids)
  })
  .then(() => {
      getList()
 	proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
  })
  .catch(() => {})
}

// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.tipConfirmExport')+"<预算科目.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetAccounting/export', { ...queryParams })
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