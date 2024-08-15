<!--
 * @Descripttion: 人员预算/fico_budget_staff_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/9 13:28:59
 * @column：39
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="年月" prop="fbssYm">
        <el-select filterable clearable   v-model="queryParams.fbssYm" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目" prop="fbssTitle">
        <el-select filterable clearable   v-model="queryParams.fbssTitle" :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_budget_title " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="名称" prop="fbssClass">
        <el-input v-model="queryParams.fbssClass" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="类别" prop="fbssCategory">
        <el-select filterable clearable   v-model="queryParams.fbssCategory" :placeholder="$t('btn.selectSearchPrefix')+'类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_exp_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="启用" prop="fbssFlag">
        <el-radio-group v-model="queryParams.fbssFlag">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="审核" prop="fbssAudit">
        <el-radio-group v-model="queryParams.fbssAudit">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="审核日期">
        <el-date-picker
          v-model="dateRangeFbssAuditDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="撤消日期">
        <el-date-picker
          v-model="dateRangeFbssUndoDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetstaffslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetstaffslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetstaffslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetstaffslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetStaffSlv/importTemplate"
                  importUrl="/Accounting/FicoBudgetStaffSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetstaffslv:export']">
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
      <el-table-column prop="fbssSfId" label="ID" align="center" v-if="columns.showColumn('fbssSfId')"/>
      <el-table-column prop="fbssParentSfId" label="父ID" align="center" v-if="columns.showColumn('fbssParentSfId')"/>
      <el-table-column prop="fbssYm" label="年月" align="center" v-if="columns.showColumn('fbssYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.fbssYm"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbssTitle" label="科目" align="center" v-if="columns.showColumn('fbssTitle')">
        <template #default="scope">
          <dict-tag :options=" options.sql_budget_title " :value="scope.row.fbssTitle"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbssClass" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbssClass')"/>
      <el-table-column prop="fbssCategory" label="类别" align="center" v-if="columns.showColumn('fbssCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_exp_type " :value="scope.row.fbssCategory"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbssKeepPersonnel" label="保有" align="center" v-if="columns.showColumn('fbssKeepPersonnel')"/>
      <el-table-column prop="fbssNowPersonnel" label="现有" align="center" v-if="columns.showColumn('fbssNowPersonnel')"/>
      <el-table-column prop="fbssPersonnel" label="预算" align="center" v-if="columns.showColumn('fbssPersonnel')"/>
      <el-table-column prop="fbssFlag" label="启用" align="center" v-if="columns.showColumn('fbssFlag')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.fbssFlag"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbssAudit" label="审核" align="center" v-if="columns.showColumn('fbssAudit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.fbssAudit"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbssAuditName" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbssAuditName')"/>
      <el-table-column prop="fbssAuditDate" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbssAuditDate')"/>
      <el-table-column prop="fbssUndoName" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbssUndoName')"/>
      <el-table-column prop="fbssUndoDate" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbssUndoDate')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetstaffslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetstaffslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改人员预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="fbssParentSfId">
              <el-input v-model.number="form.fbssParentSfId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')"  show-word-limit maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="fbssYm">
              <el-select filterable clearable   v-model="form.fbssYm"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="科目" prop="fbssTitle">
              <el-select filterable clearable   v-model="form.fbssTitle"  :placeholder="$t('btn.selectPrefix')+'科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_budget_title" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="名称" prop="fbssClass">
              <el-input v-model="form.fbssClass" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="fbssCategory">
              <el-select filterable clearable   v-model="form.fbssCategory"  :placeholder="$t('btn.selectPrefix')+'类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_exp_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="保有" prop="fbssKeepPersonnel">
              <el-input-number v-model.number="form.fbssKeepPersonnel" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="现有" prop="fbssNowPersonnel">
              <el-input-number v-model.number="form.fbssNowPersonnel" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'现有'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="预算" prop="fbssPersonnel">
              <el-input-number v-model.number="form.fbssPersonnel" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用" prop="fbssFlag">
              <el-radio-group v-model="form.fbssFlag">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="审核" prop="fbssAudit">
              <el-radio-group v-model="form.fbssAudit">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="fbssAuditName">
              <el-input v-model="form.fbssAuditName" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="fbssAuditDate">
              <el-date-picker v-model="form.fbssAuditDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="fbssUndoName">
              <el-input v-model="form.fbssUndoName" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="fbssUndoDate">
              <el-date-picker v-model="form.fbssUndoDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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


      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ficobudgetstaffslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetStaffSlv,
 addFicoBudgetStaffSlv, delFicoBudgetStaffSlv, 
 updateFicoBudgetStaffSlv,getFicoBudgetStaffSlv, 
 } 
from '@/api/accounting/ficobudgetstaffslv.js'
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
  sort: 'FbssYm',
  sortType: 'desc',
//是否查询（1是）
  fbssYm: undefined,
//是否查询（1是）
  fbssTitle: undefined,
//是否查询（1是）
  fbssClass: undefined,
//是否查询（1是）
  fbssCategory: undefined,
//是否查询（1是）
  fbssFlag: undefined,
//是否查询（1是）
  fbssAudit: undefined,
//是否查询（1是）
  fbssAuditDate: undefined,
//是否查询（1是）
  fbssUndoDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbssSfId', label: 'ID' },
  { visible: true, prop: 'fbssParentSfId', label: '父ID' },
  { visible: true, prop: 'fbssYm', label: '年月' },
  { visible: true, prop: 'fbssTitle', label: '科目' },
  { visible: true, prop: 'fbssClass', label: '名称' },
  { visible: true, prop: 'fbssCategory', label: '类别' },
  { visible: true, prop: 'fbssKeepPersonnel', label: '保有' },
  { visible: true, prop: 'fbssNowPersonnel', label: '现有' },
  { visible: false, prop: 'fbssPersonnel', label: '预算' },
  { visible: false, prop: 'fbssFlag', label: '启用' },
  { visible: false, prop: 'fbssAudit', label: '审核' },
  { visible: false, prop: 'fbssAuditName', label: '审核人员' },
  { visible: false, prop: 'fbssAuditDate', label: '审核日期' },
  { visible: false, prop: 'fbssUndoName', label: '撤消人员' },
  { visible: false, prop: 'fbssUndoDate', label: '撤消日期' },
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
// 审核日期时间范围
const dateRangeFbssAuditDate = ref([])
// 撤消日期时间范围
const dateRangeFbssUndoDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_ym_list" },
  { dictType: "sql_budget_title" },
  { dictType: "sys_exp_type" },
  { dictType: "sys_is_status" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从人员预算/fico_budget_staff_slv表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeFbssAuditDate.value, 'FbssAuditDate');
  proxy.addDateRange(queryParams, dateRangeFbssUndoDate.value, 'FbssUndoDate');
  loading.value = true
  listFicoBudgetStaffSlv(queryParams).then(res => {
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
  // 审核日期时间范围
  dateRangeFbssAuditDate.value = []
  // 撤消日期时间范围
  dateRangeFbssUndoDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.fbssSfId);
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
    fbssSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ym_list: [],
    // 科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_budget_title: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_exp_type: [],
    // 启用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_status: [],
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
    fbssSfId: 0,
    fbssParentSfId: 0,
    fbssYm: null,
    fbssTitle: null,
    fbssClass: null,
    fbssCategory: null,
    fbssKeepPersonnel: 0,
    fbssNowPersonnel: 0,
    fbssPersonnel: 0,
    fbssFlag: 0,
    fbssAudit: 0,
    fbssAuditName: null,
    fbssAuditDate: null,
    fbssUndoName: null,
    fbssUndoDate: null,
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
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'人员预算'
  opertype.value = 1
  form.value.fbssYm= []
  form.value.fbssTitle= []
  form.value.fbssCategory= []
  form.value.fbssKeepPersonnel= 0
  form.value.fbssNowPersonnel= 0
  form.value.fbssPersonnel= 0
  form.value.fbssFlag= 0
  form.value.fbssAudit= 0
  form.value.fbssAuditDate= new Date()
  form.value.fbssUndoDate= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbssSfId || ids.value
  getFicoBudgetStaffSlv(id).then((res) => {
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

      if (form.value.fbssSfId != undefined && opertype.value === 2) {
        updateFicoBudgetStaffSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetStaffSlv(form.value).then((res) => {
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
  const Ids = row.fbssSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetStaffSlv(Ids)
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
      await proxy.downFile('/Accounting/FicoBudgetStaffSlv/export', { ...queryParams })
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