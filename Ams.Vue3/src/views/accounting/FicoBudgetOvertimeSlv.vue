<!--
 * @Descripttion: 加班预算/fico_budget_overtime_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/29 13:30:23
 * @column：46
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetovertimeslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetovertimeslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetovertimeslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetovertimeslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetOvertimeSlv/importTemplate"
                  importUrl="/Accounting/FicoBudgetOvertimeSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetovertimeslv:export']">
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
      <el-table-column prop="fbosSfId" label="ID" align="center" v-if="columns.showColumn('fbosSfId')"/>
      <el-table-column prop="fbosParentSfId" label="父ID" align="center" v-if="columns.showColumn('fbosParentSfId')"/>
      <el-table-column prop="fbosLfmon" label="年月" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosLfmon')"/>
      <el-table-column prop="fbosFipls" label="科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosFipls')"/>
      <el-table-column prop="fbosStext" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosStext')"/>
      <el-table-column prop="fbosRewok" label="必要工数" align="center" v-if="columns.showColumn('fbosRewok')"/>
      <el-table-column prop="fbosKeper" label="保有人数" align="center" v-if="columns.showColumn('fbosKeper')"/>
      <el-table-column prop="fbosInper" label="间接人数" align="center" v-if="columns.showColumn('fbosInper')"/>
      <el-table-column prop="fbosWotnr" label="上班天数" align="center" v-if="columns.showColumn('fbosWotnr')"/>
      <el-table-column prop="fbosPsoak" label="加班事由" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosPsoak')"/>
      <el-table-column prop="fbosKewok" label="保有工数" align="center" v-if="columns.showColumn('fbosKewok')"/>
      <el-table-column prop="fbosAbsvar" label="工数差异" align="center" v-if="columns.showColumn('fbosAbsvar')"/>
      <el-table-column prop="fbosStdaz" label="投入加班" align="center" v-if="columns.showColumn('fbosStdaz')"/>
      <el-table-column prop="fbosZmgen" label="平均投入加班" align="center" v-if="columns.showColumn('fbosZmgen')"/>
      <el-table-column prop="fbosInBearz" label="间接加班" align="center" v-if="columns.showColumn('fbosInBearz')"/>
      <el-table-column prop="fbosToBearz" label="投入总加班" align="center" v-if="columns.showColumn('fbosToBearz')"/>
      <el-table-column prop="fbosAktiv" label="启用标记" align="center" v-if="columns.showColumn('fbosAktiv')"/>
      <el-table-column prop="fbosFrgzu" label="审核" align="center" v-if="columns.showColumn('fbosFrgzu')"/>
      <el-table-column prop="fbosAutna" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosAutna')"/>
      <el-table-column prop="fbosFrgdt" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbosFrgdt')"/>
      <el-table-column prop="fbosAbskz" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosAbskz')"/>
      <el-table-column prop="fbosAbgda" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbosAbgda')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetovertimeslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetovertimeslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改加班预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="fbosParentSfId">
              <el-input v-model.number="form.fbosParentSfId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')"  show-word-limit maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="fbosLfmon">
              <el-input v-model="form.fbosLfmon" :placeholder="$t('btn.enterPrefix')+'年月'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="fbosFipls">
              <el-input v-model="form.fbosFipls" :placeholder="$t('btn.enterPrefix')+'科目'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="fbosStext">
              <el-input v-model="form.fbosStext" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="必要工数" prop="fbosRewok">
              <el-input-number v-model.number="form.fbosRewok" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'必要工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="保有人数" prop="fbosKeper">
              <el-input-number v-model.number="form.fbosKeper" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="fbosInper">
              <el-input-number v-model.number="form.fbosInper" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="上班天数" prop="fbosWotnr">
              <el-input-number v-model.number="form.fbosWotnr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上班天数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="加班事由" prop="fbosPsoak">
              <el-input v-model="form.fbosPsoak" :placeholder="$t('btn.enterPrefix')+'加班事由'+$t('btn.enterSuffix')"  show-word-limit maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="保有工数" prop="fbosKewok">
              <el-input-number v-model.number="form.fbosKewok" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工数差异" prop="fbosAbsvar">
              <el-input-number v-model.number="form.fbosAbsvar" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工数差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入加班" prop="fbosStdaz">
              <el-input-number v-model.number="form.fbosStdaz" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="平均投入加班" prop="fbosZmgen">
              <el-input-number v-model.number="form.fbosZmgen" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'平均投入加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接加班" prop="fbosInBearz">
              <el-input-number v-model.number="form.fbosInBearz" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入总加班" prop="fbosToBearz">
              <el-input-number v-model.number="form.fbosToBearz" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入总加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用标记" prop="fbosAktiv">
              <el-input-number v-model.number="form.fbosAktiv" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'启用标记'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="审核" prop="fbosFrgzu">
              <el-input-number v-model.number="form.fbosFrgzu" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'审核'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="fbosAutna">
              <el-input v-model="form.fbosAutna" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="fbosFrgdt">
              <el-date-picker v-model="form.fbosFrgdt" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="fbosAbskz">
              <el-input v-model="form.fbosAbskz" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="fbosAbgda">
              <el-date-picker v-model="form.fbosAbgda" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ficobudgetovertimeslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetOvertimeSlv,
 addFicoBudgetOvertimeSlv, delFicoBudgetOvertimeSlv, 
 updateFicoBudgetOvertimeSlv,getFicoBudgetOvertimeSlv, 
 } 
from '@/api/accounting/ficobudgetovertimeslv.js'
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
  sort: 'FbosLfmon',
  sortType: 'desc',
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbosSfId', label: 'ID' },
  { visible: true, prop: 'fbosParentSfId', label: '父ID' },
  { visible: true, prop: 'fbosLfmon', label: '年月' },
  { visible: true, prop: 'fbosFipls', label: '科目' },
  { visible: true, prop: 'fbosStext', label: '名称' },
  { visible: true, prop: 'fbosRewok', label: '必要工数' },
  { visible: true, prop: 'fbosKeper', label: '保有人数' },
  { visible: true, prop: 'fbosInper', label: '间接人数' },
  { visible: false, prop: 'fbosWotnr', label: '上班天数' },
  { visible: false, prop: 'fbosPsoak', label: '加班事由' },
  { visible: false, prop: 'fbosKewok', label: '保有工数' },
  { visible: false, prop: 'fbosAbsvar', label: '工数差异' },
  { visible: false, prop: 'fbosStdaz', label: '投入加班' },
  { visible: false, prop: 'fbosZmgen', label: '平均投入加班' },
  { visible: false, prop: 'fbosInBearz', label: '间接加班' },
  { visible: false, prop: 'fbosToBearz', label: '投入总加班' },
  { visible: false, prop: 'fbosAktiv', label: '启用标记' },
  { visible: false, prop: 'fbosFrgzu', label: '审核' },
  { visible: false, prop: 'fbosAutna', label: '审核人员' },
  { visible: false, prop: 'fbosFrgdt', label: '审核日期' },
  { visible: false, prop: 'fbosAbskz', label: '撤消人员' },
  { visible: false, prop: 'fbosAbgda', label: '撤消日期' },
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
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从加班预算/fico_budget_overtime_slv表记录数据
function getList(){
  loading.value = true
  listFicoBudgetOvertimeSlv(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.fbosSfId);
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
    fbosSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
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
    fbosSfId: 0,
    fbosParentSfId: 0,
    fbosLfmon: null,
    fbosFipls: null,
    fbosStext: null,
    fbosRewok: 0,
    fbosKeper: 0,
    fbosInper: 0,
    fbosWotnr: 0,
    fbosPsoak: null,
    fbosKewok: 0,
    fbosAbsvar: 0,
    fbosStdaz: 0,
    fbosZmgen: 0,
    fbosInBearz: 0,
    fbosToBearz: 0,
    fbosAktiv: 0,
    fbosFrgzu: 0,
    fbosAutna: null,
    fbosFrgdt: null,
    fbosAbskz: null,
    fbosAbgda: null,
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
  title.value = proxy.$t('btn.add')+" "+'加班预算'
  opertype.value = 1
  form.value.fbosRewok= 0
  form.value.fbosKeper= 0
  form.value.fbosInper= 0
  form.value.fbosWotnr= 0
  form.value.fbosKewok= 0
  form.value.fbosAbsvar= 0
  form.value.fbosStdaz= 0
  form.value.fbosZmgen= 0
  form.value.fbosInBearz= 0
  form.value.fbosToBearz= 0
  form.value.fbosAktiv= 0
  form.value.fbosFrgzu= 0
  form.value.fbosFrgdt= new Date()
  form.value.fbosAbgda= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbosSfId || ids.value
  getFicoBudgetOvertimeSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '加班预算'
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

      if (form.value.fbosSfId != undefined && opertype.value === 2) {
        updateFicoBudgetOvertimeSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetOvertimeSlv(form.value).then((res) => {
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
  const Ids = row.fbosSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetOvertimeSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<加班预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetOvertimeSlv/export', { ...queryParams })
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