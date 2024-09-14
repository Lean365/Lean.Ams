<!--
 * @Descripttion: 资产预算/fico_budget_assets_ma
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/29 13:30:44
 * @column：28
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="期间" prop="fbaLfgja">
        <el-select filterable clearable   v-model="queryParams.fbaLfgja" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司" prop="fbaBukrs">
        <el-select filterable clearable   v-model="queryParams.fbaBukrs" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="部门" prop="fbaAbtnr">
        <el-select filterable clearable   v-model="queryParams.fbaAbtnr" :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetassetsma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetassetsma:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetassetsma:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetassetsma:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetAssetsMa/importTemplate"
                  importUrl="/Accounting/FicoBudgetAssetsMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetassetsma:export']">
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
      <el-table-column prop="fbaSfId" label="ID" align="center" v-if="columns.showColumn('fbaSfId')"/>
      <el-table-column prop="fbaLfgja" label="期间" align="center" v-if="columns.showColumn('fbaLfgja')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.fbaLfgja"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaBukrs" label="公司" align="center" v-if="columns.showColumn('fbaBukrs')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.fbaBukrs"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaAbtnr" label="部门" align="center" v-if="columns.showColumn('fbaAbtnr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_name " :value="scope.row.fbaAbtnr"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetassetsma:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetassetsma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ficoBudgetAssetsSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="fbasSfId" label="ID"/>
        <el-table-column prop="fbasParentSfId" label="父ID"/>
        <el-table-column prop="fbasLfmon" label="年月"/>
        <el-table-column prop="fbasFipls" label="科目"/>
        <el-table-column prop="fbasChgty" label="类别"/>
        <el-table-column prop="fbasStext" label="名称"/>
        <el-table-column prop="fbasFtext" label="说明"/>
        <el-table-column prop="fbasMaxdj" label="年限"/>
        <el-table-column prop="fbasAnval" label="预算"/>
        <el-table-column prop="fbasDmist" label="实际"/>
        <el-table-column prop="fbasBfaac" label="差异"/>
        <el-table-column prop="fbasBafaw" label="折旧"/>
        <el-table-column prop="fbasAktiv" label="启用"/>
        <el-table-column prop="fbasFrgzu" label="审核标志"/>
        <el-table-column prop="fbasAutna" label="审核人员"/>
        <el-table-column prop="fbasFrgdt" label="审核日期"/>
        <el-table-column prop="fbasAbskz" label="撤消人员"/>
        <el-table-column prop="fbasAbgda" label="撤消日期"/>
        <el-table-column prop="remark" label="备注说明"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改资产预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="期间" prop="fbaLfgja">
              <el-select filterable clearable   v-model="form.fbaLfgja"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司" prop="fbaBukrs">
              <el-select filterable clearable   v-model="form.fbaBukrs"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="部门" prop="fbaAbtnr">
              <el-select filterable clearable   v-model="form.fbaAbtnr"  :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
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
        <el-divider content-position="center">资产预算</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddFicoBudgetAssetsSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeleteFicoBudgetAssetsSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ficoBudgetAssetsSlvList" :row-class-name="rowFicoBudgetAssetsSlvIndex" @selection-change="handleFicoBudgetAssetsSlvSelectionChange" ref="FicoBudgetAssetsSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="年月" align="center" prop="fbasLfmon">
            <template #default="scope">
              <el-input v-model="scope.row.fbasLfmon" :placeholder="$t('btn.enterPrefix')+'年月'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="科目" align="center" prop="fbasFipls">
            <template #default="scope">
              <el-input v-model="scope.row.fbasFipls" :placeholder="$t('btn.enterPrefix')+'科目'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="类别" align="center" prop="fbasChgty">
            <template #default="scope">
              <el-input v-model="scope.row.fbasChgty" :placeholder="$t('btn.enterPrefix')+'类别'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="名称" align="center" prop="fbasStext">
            <template #default="scope">
              <el-input v-model="scope.row.fbasStext" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="fbasFtext">
            <template #default="scope">
              <el-input v-model="scope.row.fbasFtext" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="年限" align="center" prop="fbasMaxdj" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbasMaxdj" controls-position="right" :placeholder="$t('btn.enterPrefix')+'年限'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预算" align="center" prop="fbasAnval" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbasAnval" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="实际" align="center" prop="fbasDmist" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbasDmist" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="差异" align="center" prop="fbasBfaac" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbasBfaac" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="折旧" align="center" prop="fbasBafaw" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbasBafaw" controls-position="right" :placeholder="$t('btn.enterPrefix')+'折旧'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="启用" align="center" prop="fbasAktiv" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbasAktiv" controls-position="right" :placeholder="$t('btn.enterPrefix')+'启用'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="审核标志" align="center" prop="fbasFrgzu" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.fbasFrgzu" controls-position="right" :placeholder="$t('btn.enterPrefix')+'审核标志'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="审核人员" align="center" prop="fbasAutna">
            <template #default="scope">
              <el-input v-model="scope.row.fbasAutna" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="审核日期" align="center" prop="fbasFrgdt">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.fbasFrgdt" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="撤消人员" align="center" prop="fbasAbskz">
            <template #default="scope">
              <el-input v-model="scope.row.fbasAbskz" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="撤消日期" align="center" prop="fbasAbgda">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.fbasAbgda" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ficobudgetassetsma">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetAssetsMa,
 addFicoBudgetAssetsMa, delFicoBudgetAssetsMa, 
 updateFicoBudgetAssetsMa,getFicoBudgetAssetsMa, 
 } 
from '@/api/accounting/ficobudgetassetsma.js'
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
  sort: 'FbaLfgja',
  sortType: 'desc',
//是否查询（1是）
  fbaLfgja: undefined,
//是否查询（1是）
  fbaBukrs: undefined,
//是否查询（1是）
  fbaAbtnr: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbaSfId', label: 'ID' },
  { visible: true, prop: 'fbaLfgja', label: '期间' },
  { visible: true, prop: 'fbaBukrs', label: '公司' },
  { visible: true, prop: 'fbaAbtnr', label: '部门' },
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
  { dictType: "sql_corp_list" },
  { dictType: "sql_dept_name" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从资产预算/fico_budget_assets_ma表记录数据
function getList(){
  loading.value = true
  listFicoBudgetAssetsMa(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.fbaSfId);
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
    fbaSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
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
    fbaSfId: 0,
    fbaLfgja: null,
    fbaBukrs: null,
    fbaAbtnr: null,
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
  ficoBudgetAssetsSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'资产预算'
  opertype.value = 1
  form.value.fbaLfgja= []
  form.value.fbaBukrs= []
  form.value.fbaAbtnr= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbaSfId || ids.value
  getFicoBudgetAssetsMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '资产预算'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ficoBudgetAssetsSlvList.value = res.data.ficoBudgetAssetsSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ficoBudgetAssetsSlvNav = ficoBudgetAssetsSlvList.value
      if (form.value.fbaSfId != undefined && opertype.value === 2) {
        updateFicoBudgetAssetsMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetAssetsMa(form.value).then((res) => {
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
  const Ids = row.fbaSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetAssetsMa(Ids)
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
      await proxy.downFile('/Accounting/FicoBudgetAssetsMa/export', { ...queryParams })
    })
}

/*********************资产预算子表信息*************************/
const ficoBudgetAssetsSlvList = ref([])
const checkedFicoBudgetAssetsSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 资产预算序号 */
function rowFicoBudgetAssetsSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 资产预算添加按钮操作 */
function handleAddFicoBudgetAssetsSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.fbasLfmon = null;
  //obj.fbasFipls = null;
  //obj.fbasChgty = null;
  //obj.fbasStext = null;
  //obj.fbasFtext = null;
  //obj.fbasMaxdj = null;
  //obj.fbasAnval = null;
  //obj.fbasDmist = null;
  //obj.fbasBfaac = null;
  //obj.fbasBafaw = null;
  //obj.fbasAktiv = null;
  //obj.fbasFrgzu = null;
  //obj.fbasAutna = null;
  //obj.fbasFrgdt = null;
  //obj.fbasAbskz = null;
  //obj.fbasAbgda = null;
  //obj.remark = null;
  ficoBudgetAssetsSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handleFicoBudgetAssetsSlvSelectionChange(selection) {
  checkedFicoBudgetAssetsSlv.value = selection.map(item => item.index)
}

/** 资产预算删除按钮操作 */
function handleDeleteFicoBudgetAssetsSlv() {
  if(checkedFicoBudgetAssetsSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的资产预算数据')
  } else {
    const FicoBudgetAssetsSlvs = ficoBudgetAssetsSlvList.value;
    const checkedFicoBudgetAssetsSlvs = checkedFicoBudgetAssetsSlv.value;
    ficoBudgetAssetsSlvList.value = FicoBudgetAssetsSlvs.filter(function(item) {
      return checkedFicoBudgetAssetsSlvs.indexOf(item.index) == -1
    });
  }
}

/** 资产预算详情 */
function rowClick(row) {
  const id = row.fbaSfId || ids.value
  getFicoBudgetAssetsMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ficoBudgetAssetsSlvList.value = data.ficoBudgetAssetsSlvNav
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