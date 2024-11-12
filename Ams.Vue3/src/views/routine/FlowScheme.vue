<!--
 * @Descripttion: 流程/flow_scheme
 * @Version: 0.24.670.19947
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/10/31 11:32:52
 * @column：14
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="流程编号" prop="schemeCode">
        <el-input v-model="queryParams.schemeCode" :placeholder="$t('btn.enterSearchPrefix')+'流程编号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="流程名称" prop="schemeName">
        <el-input v-model="queryParams.schemeName" :placeholder="$t('btn.enterSearchPrefix')+'流程名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="流程类型" prop="schemeType">
        <el-select filterable clearable  v-model="queryParams.schemeType" :placeholder="$t('btn.selectSearchPrefix')+'流程类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flow_state " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="表单类型" prop="frmType">
        <el-select filterable clearable  v-model="queryParams.frmType" :placeholder="$t('btn.selectSearchPrefix')+'表单类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flow_state " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['flow:scheme:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['flow:scheme:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['flow:scheme:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['flow:scheme:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/FlowScheme/importTemplate"
                  importUrl="/Routine/FlowScheme/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['flow:scheme:export']">
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
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="schemeCode" label="流程编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeCode')"/>
      <el-table-column prop="schemeName" label="流程名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeName')"/>
      <el-table-column prop="schemeType" label="流程类型" align="center" v-if="columns.showColumn('schemeType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flow_state " :value="scope.row.schemeType"  />
        </template>
      </el-table-column>
      <el-table-column prop="schemeVersion" label="流程版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeVersion')"/>
      <el-table-column prop="schemeCanUser" label="流程使用人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeCanUser')"/>
      <el-table-column prop="schemeContent" label="流程内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('schemeContent')"/>
      <el-table-column prop="frmId" label="表单Id" align="center" v-if="columns.showColumn('frmId')"/>
      <el-table-column prop="frmType" label="表单类型" align="center" v-if="columns.showColumn('frmType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flow_state " :value="scope.row.frmType"  />
        </template>
      </el-table-column>
      <el-table-column prop="authorizeType" label="权限类型" align="center" v-if="columns.showColumn('authorizeType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flow_state " :value="scope.row.authorizeType"  />
        </template>
      </el-table-column>
      <el-table-column prop="deptId" label="所属部门" align="center" v-if="columns.showColumn('deptId')"/>
      <el-table-column prop="isActive" label="激活标识" align="center" v-if="columns.showColumn('isActive')"/>
      <el-table-column prop="isStatus" label="状态标识" align="center" v-if="columns.showColumn('isStatus')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flow_state " :value="scope.row.isStatus"  />
        </template>
      </el-table-column>
      <el-table-column prop="sortingNum" label="排序" align="center" v-if="columns.showColumn('sortingNum')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['flow:scheme:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['flow:scheme:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改流程对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="流程编号" prop="schemeCode">
              <el-input   v-model="form.schemeCode" :placeholder="$t('btn.enterPrefix')+'流程编号'+$t('btn.enterSuffix')"  show-word-limit  maxlength="64"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程名称" prop="schemeName">
              <el-input   v-model="form.schemeName" :placeholder="$t('btn.enterPrefix')+'流程名称'+$t('btn.enterSuffix')"  show-word-limit  maxlength="64"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程类型" prop="schemeType">
              <el-select filterable clearable   v-model="form.schemeType"  :placeholder="$t('btn.selectPrefix')+'流程类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flow_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程版本" prop="schemeVersion">
              <el-input   v-model="form.schemeVersion" :placeholder="$t('btn.enterPrefix')+'流程版本'+$t('btn.enterSuffix')"  show-word-limit  maxlength="64"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="流程使用人" prop="schemeCanUser">
              <el-input   v-model="form.schemeCanUser" :placeholder="$t('btn.enterPrefix')+'流程使用人'+$t('btn.enterSuffix')"  show-word-limit  maxlength="64"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="流程内容" prop="schemeContent">
              <el-input type="textarea" v-model="form.schemeContent" :placeholder="$t('btn.enterPrefix')+'流程内容'+$t('btn.enterSuffix')" show-word-limit maxlength="2147483647"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="表单Id" prop="frmId">
              <el-input   v-model.number="form.frmId" :placeholder="$t('btn.enterPrefix')+'表单Id'+$t('btn.enterSuffix')"  show-word-limit  maxlength="19"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="表单类型" prop="frmType">
              <el-select filterable clearable   v-model="form.frmType"  :placeholder="$t('btn.selectPrefix')+'表单类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flow_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="权限类型" prop="authorizeType">
              <el-select filterable clearable   v-model="form.authorizeType"  :placeholder="$t('btn.selectPrefix')+'权限类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flow_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="所属部门" prop="deptId">
              <el-input   v-model.number="form.deptId" :placeholder="$t('btn.enterPrefix')+'所属部门'+$t('btn.enterSuffix')"  show-word-limit  maxlength="19"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="激活标识" prop="isActive">
              <el-input-number v-model.number="form.isActive" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'激活标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="状态标识" prop="isStatus">
              <el-radio-group v-model="form.isStatus">
                <el-radio v-for="item in options.sys_flow_state" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="排序" prop="sortingNum">
              <el-input-number v-model.number="form.sortingNum" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'排序'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
        </el-row>
</el-tab-pane>


          <el-tab-pane :label="$t('ptabs.onboarding')" name="second">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.attachment')" name="fourth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.content')" name="fifth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.trade')" name="sixth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.bank')" name="seventh">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.contact')" name="eighth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>

          <el-tab-pane :label="$t('ptabs.purchase')" name="ninth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.sales')" name="tenth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.production')" name="11th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.warehouse')" name="12th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.accounting')" name="13th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.incoming')" name="14th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.outgoing')" name="15th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.customization')" name="16th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.oper')" name="17th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
        </el-tabs>


      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="flowscheme">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFlowScheme,
 addFlowScheme, delFlowScheme, 
 updateFlowScheme,getFlowScheme, 
 } 
from '@/api/routine/flowscheme.js'
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
  //流程编号,是否查询（1是）
  schemeCode: undefined,
  //流程名称,是否查询（1是）
  schemeName: undefined,
  //流程类型,是否查询（1是）
  schemeType: undefined,
  //表单类型,是否查询（1是）
  frmType: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'schemeCode', label: '流程编号' },
  { visible: true, prop: 'schemeName', label: '流程名称' },
  { visible: true, prop: 'schemeType', label: '流程类型' },
  { visible: true, prop: 'schemeVersion', label: '流程版本' },
  { visible: true, prop: 'schemeCanUser', label: '流程使用人' },
  { visible: true, prop: 'schemeContent', label: '流程内容' },
  { visible: true, prop: 'frmId', label: '表单Id' },
  { visible: false, prop: 'frmType', label: '表单类型' },
  { visible: false, prop: 'authorizeType', label: '权限类型' },
  { visible: false, prop: 'deptId', label: '所属部门' },
  { visible: false, prop: 'isActive', label: '激活标识' },
  { visible: false, prop: 'isStatus', label: '状态标识' },
  { visible: false, prop: 'sortingNum', label: '排序' },
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
  { dictType: "sys_flow_state" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从流程/flow_scheme表记录数据
function getList(){
  loading.value = true
  listFlowScheme(queryParams).then(res => {
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
    frmType: [{ required: true, message: "表单类型"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    isStatus: [{ required: true, message: "状态标识"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    sortingNum: [{ required: true, message: "排序"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 流程类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_flow_state: [],
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
    schemeCode: null,
    schemeName: null,
    schemeType: [],
    schemeVersion: null,
    schemeCanUser: null,
    schemeContent: null,
    frmId: 0,
    frmType: [],
    authorizeType: [],
    deptId: 0,
    isActive: 0,
    isStatus: 0,
    sortingNum: 0,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'流程'
  opertype.value = 1
  form.value.schemeType= []
  form.value.frmType= 0
  form.value.authorizeType= 0
  form.value.isActive= 0
  form.value.isStatus= 0
  form.value.sortingNum= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFlowScheme(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '流程'
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
        updateFlowScheme(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFlowScheme(form.value).then((res) => {
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
  const Ids = row.id || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFlowScheme(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<流程.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/FlowScheme/export', { ...queryParams })
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