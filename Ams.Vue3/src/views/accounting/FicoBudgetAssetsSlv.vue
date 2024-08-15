<!--
 * @Descripttion: 资产预算/fico_budget_assets_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/9 13:23:49
 * @column：42
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="年月" prop="fbasYm">
        <el-select filterable clearable   v-model="queryParams.fbasYm" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目" prop="fbasTitle">
        <el-select filterable clearable   v-model="queryParams.fbasTitle" :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_budget_title " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="类别" prop="fbasClass">
        <el-select filterable clearable   v-model="queryParams.fbasClass" :placeholder="$t('btn.selectSearchPrefix')+'类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_exp_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="名称" prop="fbasName">
        <el-input v-model="queryParams.fbasName" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="启用" prop="fbasFlag">
        <el-radio-group v-model="queryParams.fbasFlag">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="审核标志" prop="fbasAudit">
        <el-radio-group v-model="queryParams.fbasAudit">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="审核日期">
        <el-date-picker
          v-model="dateRangeFbasAuditDate" 
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
          v-model="dateRangeFbasUndoDate" 
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetassetsslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetassetsslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetassetsslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetassetsslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetAssetsSlv/importTemplate"
                  importUrl="/Accounting/FicoBudgetAssetsSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetassetsslv:export']">
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
      <el-table-column prop="fbasSfId" label="ID" align="center" v-if="columns.showColumn('fbasSfId')"/>
      <el-table-column prop="fbasParentSfId" label="父ID" align="center" v-if="columns.showColumn('fbasParentSfId')"/>
      <el-table-column prop="fbasYm" label="年月" align="center" v-if="columns.showColumn('fbasYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.fbasYm"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbasTitle" label="科目" align="center" v-if="columns.showColumn('fbasTitle')">
        <template #default="scope">
          <dict-tag :options=" options.sql_budget_title " :value="scope.row.fbasTitle"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbasClass" label="类别" align="center" v-if="columns.showColumn('fbasClass')">
        <template #default="scope">
          <dict-tag :options=" options.sys_exp_type " :value="scope.row.fbasClass"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbasName" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbasName')"/>
      <el-table-column prop="fbasDesc" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbasDesc')"/>
      <el-table-column prop="fbasServiceLife" label="年限" align="center" v-if="columns.showColumn('fbasServiceLife')"/>
      <el-table-column prop="fbasBudgetAmount" label="预算" align="center" v-if="columns.showColumn('fbasBudgetAmount')"/>
      <el-table-column prop="fbasActualAmount" label="实际" align="center" v-if="columns.showColumn('fbasActualAmount')"/>
      <el-table-column prop="fbasDifferenceAmount" label="差异" align="center" v-if="columns.showColumn('fbasDifferenceAmount')"/>
      <el-table-column prop="fbasDepreciation" label="折旧" align="center" v-if="columns.showColumn('fbasDepreciation')"/>
      <el-table-column prop="fbasFlag" label="启用" align="center" v-if="columns.showColumn('fbasFlag')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.fbasFlag"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbasAudit" label="审核标志" align="center" v-if="columns.showColumn('fbasAudit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.fbasAudit"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbasAuditName" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbasAuditName')"/>
      <el-table-column prop="fbasAuditDate" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbasAuditDate')"/>
      <el-table-column prop="fbasUndoName" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbasUndoName')"/>
      <el-table-column prop="fbasUndoDate" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbasUndoDate')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetassetsslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetassetsslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改资产预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="fbasParentSfId">
              <el-input v-model.number="form.fbasParentSfId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')"  show-word-limit maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="fbasYm">
              <el-select filterable clearable   v-model="form.fbasYm"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="科目" prop="fbasTitle">
              <el-select filterable clearable   v-model="form.fbasTitle"  :placeholder="$t('btn.selectPrefix')+'科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_budget_title" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="类别" prop="fbasClass">
              <el-select filterable clearable   v-model="form.fbasClass"  :placeholder="$t('btn.selectPrefix')+'类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_exp_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="名称" prop="fbasName">
              <el-input v-model="form.fbasName" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="fbasDesc">
              <el-input v-model="form.fbasDesc" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')"  show-word-limit maxlength="250"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="年限" prop="fbasServiceLife">
              <el-input-number v-model.number="form.fbasServiceLife" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'年限'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="fbasBudgetAmount">
              <el-input-number v-model.number="form.fbasBudgetAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="fbasActualAmount">
              <el-input-number v-model.number="form.fbasActualAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="fbasDifferenceAmount">
              <el-input-number v-model.number="form.fbasDifferenceAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折旧" prop="fbasDepreciation">
              <el-input-number v-model.number="form.fbasDepreciation" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'折旧'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用" prop="fbasFlag">
              <el-radio-group v-model="form.fbasFlag">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="审核标志" prop="fbasAudit">
              <el-radio-group v-model="form.fbasAudit">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="fbasAuditName">
              <el-input v-model="form.fbasAuditName" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="fbasAuditDate">
              <el-date-picker v-model="form.fbasAuditDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="fbasUndoName">
              <el-input v-model="form.fbasUndoName" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="fbasUndoDate">
              <el-date-picker v-model="form.fbasUndoDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ficobudgetassetsslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetAssetsSlv,
 addFicoBudgetAssetsSlv, delFicoBudgetAssetsSlv, 
 updateFicoBudgetAssetsSlv,getFicoBudgetAssetsSlv, 
 } 
from '@/api/accounting/ficobudgetassetsslv.js'
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
  sort: 'FbasYm',
  sortType: 'desc',
//是否查询（1是）
  fbasYm: undefined,
//是否查询（1是）
  fbasTitle: undefined,
//是否查询（1是）
  fbasClass: undefined,
//是否查询（1是）
  fbasName: undefined,
//是否查询（1是）
  fbasFlag: undefined,
//是否查询（1是）
  fbasAudit: undefined,
//是否查询（1是）
  fbasAuditDate: undefined,
//是否查询（1是）
  fbasUndoDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbasSfId', label: 'ID' },
  { visible: true, prop: 'fbasParentSfId', label: '父ID' },
  { visible: true, prop: 'fbasYm', label: '年月' },
  { visible: true, prop: 'fbasTitle', label: '科目' },
  { visible: true, prop: 'fbasClass', label: '类别' },
  { visible: true, prop: 'fbasName', label: '名称' },
  { visible: true, prop: 'fbasDesc', label: '说明' },
  { visible: true, prop: 'fbasServiceLife', label: '年限' },
  { visible: false, prop: 'fbasBudgetAmount', label: '预算' },
  { visible: false, prop: 'fbasActualAmount', label: '实际' },
  { visible: false, prop: 'fbasDifferenceAmount', label: '差异' },
  { visible: false, prop: 'fbasDepreciation', label: '折旧' },
  { visible: false, prop: 'fbasFlag', label: '启用' },
  { visible: false, prop: 'fbasAudit', label: '审核标志' },
  { visible: false, prop: 'fbasAuditName', label: '审核人员' },
  { visible: false, prop: 'fbasAuditDate', label: '审核日期' },
  { visible: false, prop: 'fbasUndoName', label: '撤消人员' },
  { visible: false, prop: 'fbasUndoDate', label: '撤消日期' },
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
const dateRangeFbasAuditDate = ref([])
// 撤消日期时间范围
const dateRangeFbasUndoDate = ref([])

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
//API获取从资产预算/fico_budget_assets_slv表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeFbasAuditDate.value, 'FbasAuditDate');
  proxy.addDateRange(queryParams, dateRangeFbasUndoDate.value, 'FbasUndoDate');
  loading.value = true
  listFicoBudgetAssetsSlv(queryParams).then(res => {
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
  dateRangeFbasAuditDate.value = []
  // 撤消日期时间范围
  dateRangeFbasUndoDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.fbasSfId);
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
    fbasSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
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
    fbasSfId: 0,
    fbasParentSfId: 0,
    fbasYm: null,
    fbasTitle: null,
    fbasClass: null,
    fbasName: null,
    fbasDesc: null,
    fbasServiceLife: 0,
    fbasBudgetAmount: 0,
    fbasActualAmount: 0,
    fbasDifferenceAmount: 0,
    fbasDepreciation: 0,
    fbasFlag: 0,
    fbasAudit: 0,
    fbasAuditName: null,
    fbasAuditDate: null,
    fbasUndoName: null,
    fbasUndoDate: null,
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
  title.value = proxy.$t('btn.add')+" "+'资产预算'
  opertype.value = 1
  form.value.fbasYm= []
  form.value.fbasTitle= []
  form.value.fbasClass= []
  form.value.fbasServiceLife= 0
  form.value.fbasBudgetAmount= 0
  form.value.fbasActualAmount= 0
  form.value.fbasDifferenceAmount= 0
  form.value.fbasDepreciation= 0
  form.value.fbasFlag= 0
  form.value.fbasAudit= 0
  form.value.fbasAuditDate= new Date()
  form.value.fbasUndoDate= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbasSfId || ids.value
  getFicoBudgetAssetsSlv(id).then((res) => {
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

      if (form.value.fbasSfId != undefined && opertype.value === 2) {
        updateFicoBudgetAssetsSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetAssetsSlv(form.value).then((res) => {
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
  const Ids = row.fbasSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetAssetsSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<资产预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetAssetsSlv/export', { ...queryParams })
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