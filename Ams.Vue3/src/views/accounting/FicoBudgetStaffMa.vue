<!--
 * @Descripttion: 人员预算/fico_budget_staff_ma
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/29 13:30:17
 * @column：28
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="财年" prop="fbsLfgja">
        <el-select filterable clearable   v-model="queryParams.fbsLfgja" :placeholder="$t('btn.selectSearchPrefix')+'财年'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司" prop="fbsBukrs">
        <el-select filterable clearable   v-model="queryParams.fbsBukrs" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="部门" prop="fbsAbtnr">
        <el-select filterable clearable   v-model="queryParams.fbsAbtnr" :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_name " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetstaffma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetstaffma:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetstaffma:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetstaffma:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetStaffMa/importTemplate"
                  importUrl="/Accounting/FicoBudgetStaffMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetstaffma:export']">
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain  icon="view" size="small" @click="rowClick(scope.row)" :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="fbsSfId" label="ID" align="center" v-if="columns.showColumn('fbsSfId')"/>
      <el-table-column prop="fbsLfgja" label="财年" align="center" v-if="columns.showColumn('fbsLfgja')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.fbsLfgja"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbsBukrs" label="公司" align="center" v-if="columns.showColumn('fbsBukrs')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.fbsBukrs"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbsAbtnr" label="部门" align="center" v-if="columns.showColumn('fbsAbtnr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_name " :value="scope.row.fbsAbtnr"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetstaffma:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetstaffma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ficoBudgetStaffSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="fbssSfId" label="ID"/>
        <el-table-column prop="fbssParentSfId" label="父ID"/>
        <el-table-column prop="fbssLfmon" label="年月"/>
        <el-table-column prop="fbssFipls" label="科目"/>
        <el-table-column prop="fbssStext" label="名称"/>
        <el-table-column prop="fbssChgty" label="类别"/>
        <el-table-column prop="fbssKeper" label="保有"/>
        <el-table-column prop="fbssNoper" label="现有"/>
        <el-table-column prop="fbssAnper" label="预算"/>
        <el-table-column prop="fbssAktiv" label="启用"/>
        <el-table-column prop="fbssFrgzu" label="审核"/>
        <el-table-column prop="fbssAutna" label="审核人员"/>
        <el-table-column prop="fbssFrgdt" label="审核日期"/>
        <el-table-column prop="fbssAbskz" label="撤消人员"/>
        <el-table-column prop="fbssAbgda" label="撤消日期"/>
        <el-table-column prop="remark" label="备注说明"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改人员预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="财年" prop="fbsLfgja">
              <el-select filterable clearable   v-model="form.fbsLfgja"  :placeholder="$t('btn.selectPrefix')+'财年'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司" prop="fbsBukrs">
              <el-select filterable clearable   v-model="form.fbsBukrs"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="部门" prop="fbsAbtnr">
              <el-select filterable clearable   v-model="form.fbsAbtnr"  :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_name" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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


    <!-- 子表信息 -->
        <el-divider content-position="center">人员预算</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddFicoBudgetStaffSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeleteFicoBudgetStaffSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ficoBudgetStaffSlvList" :row-class-name="rowFicoBudgetStaffSlvIndex" @selection-change="handleFicoBudgetStaffSlvSelectionChange" ref="FicoBudgetStaffSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="年月" align="center" prop="fbssLfmon">
            <template #default="scope">
              <el-input v-model="scope.row.fbssLfmon" :placeholder="$t('btn.enterPrefix')+'年月'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="科目" align="center" prop="fbssFipls">
            <template #default="scope">
              <el-input v-model="scope.row.fbssFipls" :placeholder="$t('btn.enterPrefix')+'科目'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="名称" align="center" prop="fbssStext">
            <template #default="scope">
              <el-input v-model="scope.row.fbssStext" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="类别" align="center" prop="fbssChgty">
            <template #default="scope">
              <el-input v-model="scope.row.fbssChgty" :placeholder="$t('btn.enterPrefix')+'类别'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="保有" align="center" prop="fbssKeper" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbssKeper" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="现有" align="center" prop="fbssNoper" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbssNoper" controls-position="right" :placeholder="$t('btn.enterPrefix')+'现有'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预算" align="center" prop="fbssAnper" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbssAnper" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="启用" align="center" prop="fbssAktiv" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbssAktiv" controls-position="right" :placeholder="$t('btn.enterPrefix')+'启用'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="审核" align="center" prop="fbssFrgzu" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbssFrgzu" controls-position="right" :placeholder="$t('btn.enterPrefix')+'审核'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="审核人员" align="center" prop="fbssAutna">
            <template #default="scope">
              <el-input v-model="scope.row.fbssAutna" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="审核日期" align="center" prop="fbssFrgdt">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.fbssFrgdt" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="撤消人员" align="center" prop="fbssAbskz">
            <template #default="scope">
              <el-input v-model="scope.row.fbssAbskz" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="撤消日期" align="center" prop="fbssAbgda">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.fbssAbgda" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="备注说明" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
        </el-table>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ficobudgetstaffma">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetStaffMa,
 addFicoBudgetStaffMa, delFicoBudgetStaffMa, 
 updateFicoBudgetStaffMa,getFicoBudgetStaffMa, 
 } 
from '@/api/accounting/ficobudgetstaffma.js'
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
  sort: 'FbsLfgja',
  sortType: 'desc',
//是否查询（1是）
  fbsLfgja: undefined,
//是否查询（1是）
  fbsBukrs: undefined,
//是否查询（1是）
  fbsAbtnr: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbsSfId', label: 'ID' },
  { visible: true, prop: 'fbsLfgja', label: '财年' },
  { visible: true, prop: 'fbsBukrs', label: '公司' },
  { visible: true, prop: 'fbsAbtnr', label: '部门' },
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
  { dictType: "sql_attr_list" },
  { dictType: "sql_ymdt_list" },
  { dictType: "sql_dept_name" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从人员预算/fico_budget_staff_ma表记录数据
function getList(){
  loading.value = true
  listFicoBudgetStaffMa(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.fbsSfId);
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
  rules: {
    fbsSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 财年 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ymdt_list: [],
    // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_name: [],
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
    fbsSfId: 0,
    fbsLfgja: null,
    fbsBukrs: null,
    fbsAbtnr: null,
    rEF01: null,
    rEF02: null,
    rEF03: null,
    rEF04: 0,
    rEF05: 0,
    rEF06: 0,
    uDF01: null,
    uDF02: null,
    uDF03: null,
    uDF04: null,
    uDF05: null,
    uDF06: null,
    uDF51: 0,
    uDF52: 0,
    uDF53: 0,
    uDF54: 0,
    uDF55: 0,
    uDF56: 0,
    isDeleted: 0,
    remark: null,
    createBy: null,
    createTime: null,
    updateBy: null,
    updateTime: null,
  };
  ficoBudgetStaffSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'人员预算'
  opertype.value = 1
  form.value.fbsLfgja= []
  form.value.fbsBukrs= []
  form.value.fbsAbtnr= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbsSfId || ids.value
  getFicoBudgetStaffMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '人员预算'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ficoBudgetStaffSlvList.value = res.data.ficoBudgetStaffSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ficoBudgetStaffSlvNav = ficoBudgetStaffSlvList.value
      if (form.value.fbsSfId != undefined && opertype.value === 2) {
        updateFicoBudgetStaffMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetStaffMa(form.value).then((res) => {
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
  const Ids = row.fbsSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetStaffMa(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<人员预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetStaffMa/export', { ...queryParams })
    })
}

/*********************人员预算子表信息*************************/
const ficoBudgetStaffSlvList = ref([])
const checkedFicoBudgetStaffSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 人员预算序号 */
function rowFicoBudgetStaffSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 人员预算添加按钮操作 */
function handleAddFicoBudgetStaffSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.fbssLfmon = null;
  //obj.fbssFipls = null;
  //obj.fbssStext = null;
  //obj.fbssChgty = null;
  //obj.fbssKeper = null;
  //obj.fbssNoper = null;
  //obj.fbssAnper = null;
  //obj.fbssAktiv = null;
  //obj.fbssFrgzu = null;
  //obj.fbssAutna = null;
  //obj.fbssFrgdt = null;
  //obj.fbssAbskz = null;
  //obj.fbssAbgda = null;
  //obj.remark = null;
  ficoBudgetStaffSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handleFicoBudgetStaffSlvSelectionChange(selection) {
  checkedFicoBudgetStaffSlv.value = selection.map(item => item.index)
}

/** 人员预算删除按钮操作 */
function handleDeleteFicoBudgetStaffSlv() {
  if(checkedFicoBudgetStaffSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的人员预算数据')
  } else {
    const FicoBudgetStaffSlvs = ficoBudgetStaffSlvList.value;
    const checkedFicoBudgetStaffSlvs = checkedFicoBudgetStaffSlv.value;
    ficoBudgetStaffSlvList.value = FicoBudgetStaffSlvs.filter(function(item) {
      return checkedFicoBudgetStaffSlvs.indexOf(item.index) == -1
    });
  }
}

/** 人员预算详情 */
function rowClick(row) {
  const id = row.fbsSfId || ids.value
  getFicoBudgetStaffMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ficoBudgetStaffSlvList.value = data.ficoBudgetStaffSlvNav
    }
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