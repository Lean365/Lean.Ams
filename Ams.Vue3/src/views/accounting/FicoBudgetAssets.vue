<!--
 * @Descripttion: 资产预算/fico_budget_assets
 * @Version: 0.24.619.28301
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 15:46:44
 * @column：45
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="部门ID" prop="deptId">
        <el-select filterable clearable   v-model="queryParams.deptId" :placeholder="$t('btn.selectSearchPrefix')+'部门ID'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="期间" prop="mg004">
        <el-select filterable clearable   v-model="queryParams.mg004" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="mg005">
        <el-select filterable clearable   v-model="queryParams.mg005" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司" prop="mg006">
        <el-select filterable clearable   v-model="queryParams.mg006" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button class="btn-add" v-hasPermi="['fico:budgetassets:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
       <el-col :span="1.5">
        <el-button type="info" plain icon="sort" @click="toggleExpandAll">{{ $t('btn.expand') }}/{{  $t('btn.collapse')
          }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetassets:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetassets:export']">
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
      <el-table-column prop="mg004" label="期间" align="center" v-if="columns.showColumn('mg004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mg004" />
        </template>
      </el-table-column>
      <el-table-column prop="mg005" label="年月" align="center" v-if="columns.showColumn('mg005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mg005" />
        </template>
      </el-table-column>
      <el-table-column prop="mg006" label="公司" align="center" v-if="columns.showColumn('mg006')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mg006" />
        </template>
      </el-table-column>
      <el-table-column prop="mg007" label="科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg007')"/>
      <el-table-column prop="mg008" label="类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg008')"/>
      <el-table-column prop="mg009" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg009')"/>
      <el-table-column prop="mg010" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg010')"/>
      <el-table-column prop="mg011" label="年限" align="center" v-if="columns.showColumn('mg011')"/>
      <el-table-column prop="mg012" label="预算" align="center" v-if="columns.showColumn('mg012')"/>
      <el-table-column prop="mg013" label="实际" align="center" v-if="columns.showColumn('mg013')"/>
      <el-table-column prop="mg014" label="差异" align="center" v-if="columns.showColumn('mg014')"/>
      <el-table-column prop="mg015" label="折旧" align="center" v-if="columns.showColumn('mg015')"/>
      <el-table-column prop="mg016" label="启用" align="center" v-if="columns.showColumn('mg016')"/>
      <el-table-column prop="mg017" label="审核标志" align="center" v-if="columns.showColumn('mg017')"/>
      <el-table-column prop="mg018" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg018')"/>
      <el-table-column prop="mg019" label="审核日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg019')"/>
      <el-table-column prop="mg020" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg020')"/>
      <el-table-column prop="mg021" label="撤消日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg021')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>

      <el-table-column :label="$t('btn.operation')" align="center" width="140">
        <template #default="scope">
          <el-button v-hasPermi="['fico:budgetassets:edit']" class="btn-edit" icon="edit" size="small" :title="$t('btn.edit')" 
            @click="handleUpdate(scope.row)"></el-button>      
          <el-button v-hasPermi="['fico:budgetassets:delete']" class="btn-delete" icon="delete" size="small" :title="$t('btn.delete')"  
            @click="handleDelete(scope.row)"></el-button>
        </template>      
      </el-table-column>
    </el-table>

    <!-- 添加或修改资产预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row :gutter="20">
    
          <el-col :lg="24">
            <el-form-item :label="$t('common.tipParentId')" prop="parentId">
              <el-cascader
                class="w100"
                :options="dataList"
                :props="{ checkStrictly: true, value: 'id', label: 'mg007', emitPath: false }"
                :placeholder="$t('common.tipPreviousName')"
                clearable
                v-model="form.parentId"
              >
                <template #default="{ node, data }">
                  <span>{{ data.mg007 }}</span>
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
            <el-form-item label="期间" prop="mg004">
              <el-select filterable clearable   v-model="form.mg004"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="mg005">
              <el-select filterable clearable   v-model="form.mg005"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司" prop="mg006">
              <el-select filterable clearable   v-model="form.mg006"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="mg007">
              <el-input  v-model="form.mg007" :placeholder="$t('btn.enterPrefix')+'科目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="mg008">
              <el-input  v-model="form.mg008" :placeholder="$t('btn.enterPrefix')+'类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="mg009">
              <el-input  v-model="form.mg009" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="mg010">
              <el-input  v-model="form.mg010" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="250" />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="年限" prop="mg011">
              <el-input-number v-model.number="form.mg011" controls-position="right" :placeholder="$t('btn.enterPrefix')+'年限'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="mg012">
              <el-input-number v-model.number="form.mg012" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="mg013">
              <el-input-number v-model.number="form.mg013" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="mg014">
              <el-input-number v-model.number="form.mg014" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折旧" prop="mg015">
              <el-input-number v-model.number="form.mg015" controls-position="right" :placeholder="$t('btn.enterPrefix')+'折旧'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="启用" prop="mg016">
              <el-input-number v-model.number="form.mg016" controls-position="right" :placeholder="$t('btn.enterPrefix')+'启用'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>
    
          <el-col :lg="12">
            <el-form-item label="审核标志" prop="mg017">
              <el-input-number v-model.number="form.mg017" controls-position="right" :placeholder="$t('btn.enterPrefix')+'审核标志'+$t('btn.enterSuffix')"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="mg018">
              <el-input  v-model="form.mg018" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="mg019">
              <el-date-picker v-model="form.mg019" type="datetime" :placeholder="$t('btn.selectPrefix')+'审核日期'+$t('btn.selectSuffix')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="mg020">
              <el-input  v-model="form.mg020" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="mg021">
              <el-date-picker v-model="form.mg021" type="datetime" :placeholder="$t('btn.selectPrefix')+'撤消日期'+$t('btn.selectSuffix')"></el-date-picker>
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

<script setup name="ficobudgetassets">
  import '@/assets/styles/btn-custom.scss'
import { treelistFicoBudgetAssets, listFicoBudgetAssets, 
 addFicoBudgetAssets, delFicoBudgetAssets, updateFicoBudgetAssets,getFicoBudgetAssets,
 } from '@/api/accounting/ficobudgetassets.js'
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
  sort: 'Mg004',
  sortType: 'desc',
  //是否查询（1是）
  deptId: undefined,
  //是否查询（1是）
  mg004: undefined,
  //是否查询（1是）
  mg005: undefined,
  //是否查询（1是）
  mg006: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'deptId', label: '部门ID' },
  { visible: true, prop: 'mg004', label: '期间' },
  { visible: true, prop: 'mg005', label: '年月' },
  { visible: true, prop: 'mg006', label: '公司' },
  { visible: true, prop: 'mg007', label: '科目' },
  { visible: true, prop: 'mg008', label: '类别' },
  { visible: false, prop: 'mg009', label: '名称' },
  { visible: false, prop: 'mg010', label: '说明' },
  { visible: false, prop: 'mg011', label: '年限' },
  { visible: false, prop: 'mg012', label: '预算' },
  { visible: false, prop: 'mg013', label: '实际' },
  { visible: false, prop: 'mg014', label: '差异' },
  { visible: false, prop: 'mg015', label: '折旧' },
  { visible: false, prop: 'mg016', label: '启用' },
  { visible: false, prop: 'mg017', label: '审核标志' },
  { visible: false, prop: 'mg018', label: '审核人员' },
  { visible: false, prop: 'mg019', label: '审核日期' },
  { visible: false, prop: 'mg020', label: '撤消人员' },
  { visible: false, prop: 'mg021', label: '撤消日期' },
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
//API获取从资产预算/fico_budget_assets表记录数据
function getList(){
  loading.value = true
  treelistFicoBudgetAssets(queryParams).then(res => {
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
    deptId: [{ required: true, message: "部门ID不能为空", trigger: "change", type: "number" }],
    mg004: [{ required: true, message: "期间不能为空", trigger: "change" }],
    mg005: [{ required: true, message: "年月不能为空", trigger: "change" }],
    mg006: [{ required: true, message: "公司不能为空", trigger: "change" }],
    mg011: [{ required: true, message: "年限不能为空", trigger: "blur", type: "number" }],
    mg012: [{ required: true, message: "预算不能为空", trigger: "blur" }],
    mg013: [{ required: true, message: "实际不能为空", trigger: "blur" }],
    mg014: [{ required: true, message: "差异不能为空", trigger: "blur" }],
    mg015: [{ required: true, message: "折旧不能为空", trigger: "blur" }],
    mg016: [{ required: true, message: "启用不能为空", trigger: "blur", type: "number" }],
    mg017: [{ required: true, message: "审核标志不能为空", trigger: "blur", type: "number" }],
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
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    mg004: [],
    mg005: [],
    mg006: [],
    mg007: null,
    mg008: null,
    mg009: null,
    mg010: null,
    mg011: 0,
    mg012: 0,
    mg013: 0,
    mg014: 0,
    mg015: 0,
    mg016: 0,
    mg017: 0,
    mg018: null,
    mg019: null,
    mg020: null,
    mg021: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}

// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'资产预算'
  opertype.value = 1
  form.value.deptId= []
  form.value.mg004= []
  form.value.mg005= []
  form.value.mg006= []
  form.value.mg011= 0
  form.value.mg012= 0
  form.value.mg013= 0
  form.value.mg014= 0
  form.value.mg015= 0
  form.value.mg016= 0
  form.value.mg017= 0
  form.value.mg019= new Date()
  form.value.mg021= new Date()
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoBudgetAssets(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '资产预算'
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
        updateFicoBudgetAssets(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addFicoBudgetAssets(form.value).then((res) => {
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
      return delFicoBudgetAssets(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<资产预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetAssets/export', { ...queryParams })
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