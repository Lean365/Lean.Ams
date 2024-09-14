<!--
 * @Descripttion: 人员预算/fico_budget_staff
 * @Version: 0.24.619.29178
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 16:56:20
 * @column：42
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="财年" prop="mj004">
        <el-select filterable clearable   v-model="queryParams.mj004" :placeholder="$t('btn.selectSearchPrefix')+'财年'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="mj005">
        <el-select filterable clearable   v-model="queryParams.mj005" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司" prop="mj006">
        <el-select filterable clearable   v-model="queryParams.mj006" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目" prop="mj007">
        <el-input v-model="queryParams.mj007" :placeholder="$t('btn.enterSearchPrefix')+'科目'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetstaff:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
       <el-col :span="1.5">
        <el-button type="info" plain icon="sort" @click="toggleExpandAll">{{ $t('btn.expand') }}/{{  $t('btn.collapse')
          }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetstaff:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetstaff:export']">
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
      <el-table-column prop="deptId" label="部门ID" align="center" v-if="columns.showColumn('deptId')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.deptId" />
        </template>
      </el-table-column>
      <el-table-column prop="mj004" label="财年" align="center" v-if="columns.showColumn('mj004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mj004" />
        </template>
      </el-table-column>
      <el-table-column prop="mj005" label="年月" align="center" v-if="columns.showColumn('mj005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mj005" />
        </template>
      </el-table-column>
      <el-table-column prop="mj006" label="公司" align="center" v-if="columns.showColumn('mj006')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mj006" />
        </template>
      </el-table-column>
      <el-table-column prop="mj007" label="科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mj007')"/>
      <el-table-column prop="mj008" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mj008')"/>
      <el-table-column prop="mj009" label="类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mj009')"/>
      <el-table-column prop="mj010" label="保有" align="center" v-if="columns.showColumn('mj010')"/>
      <el-table-column prop="mj011" label="现有" align="center" v-if="columns.showColumn('mj011')"/>
      <el-table-column prop="mj012" label="预算" align="center" v-if="columns.showColumn('mj012')"/>
      <el-table-column prop="mj013" label="启用" align="center" v-if="columns.showColumn('mj013')"/>
      <el-table-column prop="mj014" label="审核" align="center" v-if="columns.showColumn('mj014')"/>
      <el-table-column prop="mj015" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mj015')"/>
      <el-table-column prop="mj016" label="审核日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mj016')"/>
      <el-table-column prop="mj017" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mj017')"/>
      <el-table-column prop="mj018" label="撤消日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mj018')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>

      <el-table-column :label="$t('btn.operation')" align="center" width="140">
        <template #default="scope">
          <el-button v-hasPermi="['fico:budgetstaff:edit']" class="btn-edit" icon="edit" size="small" :title="$t('btn.edit')" 
            @click="handleUpdate(scope.row)"></el-button>      
          <el-button v-hasPermi="['fico:budgetstaff:delete']" class="btn-delete" icon="delete" size="small" :title="$t('btn.delete')"  
            @click="handleDelete(scope.row)"></el-button>
        </template>      
      </el-table-column>
    </el-table>

    <!-- 添加或修改人员预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row :gutter="20">
    
          <el-col :lg="24">
            <el-form-item :label="$t('common.tipParentId')" prop="parentId">
              <el-cascader
                class="w100"
                :options="dataList"
                :props="{ checkStrictly: true, value: 'id', label: 'mj008', emitPath: false }"
                :placeholder="$t('common.tipPreviousName')"
                clearable
                v-model="form.parentId"
              >
                <template #default="{ node, data }">
                  <span>{{ data.mj008 }}</span>
                  <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
                </template>
              </el-cascader>
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="部门ID" prop="deptId">
              <el-select filterable clearable   v-model="form.deptId"  :placeholder="$t('btn.selectPrefix')+'部门ID'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="财年" prop="mj004">
              <el-select filterable clearable   v-model="form.mj004"  :placeholder="$t('btn.selectPrefix')+'财年'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="mj005">
              <el-select filterable clearable   v-model="form.mj005"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司" prop="mj006">
              <el-select filterable clearable   v-model="form.mj006"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="mj007">
              <el-input  v-model="form.mj007" :placeholder="$t('btn.enterPrefix')+'科目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="mj008">
              <el-input  v-model="form.mj008" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="mj009">
              <el-input  v-model="form.mj009" :placeholder="$t('btn.enterPrefix')+'类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="保有" prop="mj010">
              <el-input-number v-model.number="form.mj010" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="现有" prop="mj011">
              <el-input-number v-model.number="form.mj011" controls-position="right" :placeholder="$t('btn.enterPrefix')+'现有'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="预算" prop="mj012">
              <el-input-number v-model.number="form.mj012" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="启用" prop="mj013">
              <el-input-number v-model.number="form.mj013" controls-position="right" :placeholder="$t('btn.enterPrefix')+'启用'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="审核" prop="mj014">
              <el-input-number v-model.number="form.mj014" controls-position="right" :placeholder="$t('btn.enterPrefix')+'审核'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="mj015">
              <el-input  v-model="form.mj015" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="mj016">
              <el-date-picker v-model="form.mj016" type="datetime" :placeholder="$t('btn.selectPrefix')+'审核日期'+$t('btn.selectSuffix')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="mj017">
              <el-input  v-model="form.mj017" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="mj018">
              <el-date-picker v-model="form.mj018" type="datetime" :placeholder="$t('btn.selectPrefix')+'撤消日期'+$t('btn.selectSuffix')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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

<script setup name="ficobudgetstaff">
  import '@/assets/styles/btn-custom.scss'
import { treelistFicoBudgetStaff, listFicoBudgetStaff, 
 addFicoBudgetStaff, delFicoBudgetStaff, updateFicoBudgetStaff,getFicoBudgetStaff,
 } from '@/api/accounting/ficobudgetstaff.js'
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
  sort: 'Mj005',
  sortType: 'desc',
  //是否查询（1是）
  mj004: undefined,
  //是否查询（1是）
  mj005: undefined,
  //是否查询（1是）
  mj006: undefined,
  //是否查询（1是）
  mj007: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'deptId', label: '部门ID' },
  { visible: true, prop: 'mj004', label: '财年' },
  { visible: true, prop: 'mj005', label: '年月' },
  { visible: true, prop: 'mj006', label: '公司' },
  { visible: true, prop: 'mj007', label: '科目' },
  { visible: true, prop: 'mj008', label: '名称' },
  { visible: false, prop: 'mj009', label: '类别' },
  { visible: false, prop: 'mj010', label: '保有' },
  { visible: false, prop: 'mj011', label: '现有' },
  { visible: false, prop: 'mj012', label: '预算' },
  { visible: false, prop: 'mj013', label: '启用' },
  { visible: false, prop: 'mj014', label: '审核' },
  { visible: false, prop: 'mj015', label: '审核人员' },
  { visible: false, prop: 'mj016', label: '审核日期' },
  { visible: false, prop: 'mj017', label: '撤消人员' },
  { visible: false, prop: 'mj018', label: '撤消日期' },
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

//字典参数
var dictParams = [
  { dictType: "sql_dept_list" },
  { dictType: "sql_attr_list" },
  { dictType: "sql_ymdt_list" },
  { dictType: "sql_corp_list" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从人员预算/fico_budget_staff表记录数据
function getList(){
  loading.value = true
  treelistFicoBudgetStaff(queryParams).then(res => {
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
    id: [{ required: true, message: "ID不能为空", trigger: "blur", type: "number" }],
    mj004: [{ required: true, message: "财年不能为空", trigger: "change" }],
    mj005: [{ required: true, message: "年月不能为空", trigger: "change" }],
    mj006: [{ required: true, message: "公司不能为空", trigger: "change" }],
    mj007: [{ required: true, message: "科目不能为空", trigger: "blur" }],
    mj010: [{ required: true, message: "保有不能为空", trigger: "blur", type: "number" }],
    mj011: [{ required: true, message: "现有不能为空", trigger: "blur", type: "number" }],
    mj012: [{ required: true, message: "预算不能为空", trigger: "blur", type: "number" }],
    mj013: [{ required: true, message: "启用不能为空", trigger: "blur", type: "number" }],
    mj014: [{ required: true, message: "审核不能为空", trigger: "blur", type: "number" }],
    ref04: [{ required: true, message: "预留1不能为空", trigger: "blur" }],
    ref05: [{ required: true, message: "预留2不能为空", trigger: "blur" }],
    ref06: [{ required: true, message: "预留3不能为空", trigger: "blur" }],
    udf51: [{ required: true, message: "自定义1不能为空", trigger: "blur", type: "number" }],
    udf52: [{ required: true, message: "自定义2不能为空", trigger: "blur", type: "number" }],
    udf53: [{ required: true, message: "自定义3不能为空", trigger: "blur", type: "number" }],
    udf54: [{ required: true, message: "自定义4不能为空", trigger: "blur" }],
    udf55: [{ required: true, message: "自定义5不能为空", trigger: "blur" }],
    udf56: [{ required: true, message: "自定义6不能为空", trigger: "blur" }],
  },
//字典名称
  options: {
    // 部门ID 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // 财年 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ymdt_list: [],
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
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
    deptId: [],
    mj004: [],
    mj005: [],
    mj006: [],
    mj007: null,
    mj008: null,
    mj009: null,
    mj010: 0,
    mj011: 0,
    mj012: 0,
    mj013: 0,
    mj014: 0,
    mj015: null,
    mj016: null,
    mj017: null,
    mj018: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}

// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'人员预算'
  opertype.value = 1
  form.value.deptId= []
  form.value.mj004= []
  form.value.mj005= []
  form.value.mj006= []
  form.value.mj010= 0
  form.value.mj011= 0
  form.value.mj012= 0
  form.value.mj013= 0
  form.value.mj014= 0
  form.value.mj016= new Date()
  form.value.mj018= new Date()
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoBudgetStaff(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '人员预算'
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
        updateFicoBudgetStaff(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoBudgetStaff(form.value).then((res) => {
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
      return delFicoBudgetStaff(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<人员预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetStaff/export', { ...queryParams })
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