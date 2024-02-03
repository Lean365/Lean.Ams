<!--
 * @Descripttion: (从客诉管理/qm_complaints_slave)
 * @Version: (0.24.390.30666)
 * @Author: (Lean365)
 * @Date: (2024/1/25 17:05:54)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['qm:complaintsslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['qm:complaintsslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['qm:complaintsslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['qm:complaintsslave:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table
      :data="dataList" height="650"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="40" align="center"/>
      <el-table-column prop="qmcsSFID" label="SFID" align="center" v-if="columns.showColumn('qmcsSFID')"/>
      <el-table-column prop="qmcsIssuesNo" label="外部客诉No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsIssuesNo')"/>
      <el-table-column prop="qmcsLine" label="班组" align="center" v-if="columns.showColumn('qmcsLine')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.qmcsLine"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmcsProcessingDate" label="处理日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qmcsProcessingDate')"/>
      <el-table-column prop="qmcsDescription" label="问题描述" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsDescription')"/>
      <el-table-column prop="qmcsCauseAnalysis" label="原因分析" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsCauseAnalysis')"/>
      <el-table-column prop="qmcsOperator" label="作业员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsOperator')"/>
      <el-table-column prop="qmcsStation" label="工位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsStation')"/>
      <el-table-column prop="qmcsLot" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsLot')"/>
      <el-table-column prop="qmcsMeasures" label="改善对策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsMeasures')"/>
      <el-table-column prop="qmcsReformDocs" label="改善文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcsReformDocs')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:complaintsslave:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:complaintsslave:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改从客诉管理对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="qmcsSFID">
              <el-input v-model.number="form.qmcsSFID" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部客诉No." prop="qmcsIssuesNo">
              <el-input clearable v-model="form.qmcsIssuesNo" :placeholder="$t('btn.enter')+'外部客诉No.'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组" prop="qmcsLine">
              <el-select clearable filterable v-model="form.qmcsLine"  :placeholder="$t('btn.select')+'班组'">
                <el-option
                  v-for="item in options.sql_line_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理日期" prop="qmcsProcessingDate">
              <el-date-picker v-model="form.qmcsProcessingDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="问题描述" prop="qmcsDescription">
              <el-input type="textarea" v-model="form.qmcsDescription" :placeholder="$t('btn.enter')+'问题描述'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="原因分析" prop="qmcsCauseAnalysis">
              <el-input type="textarea" v-model="form.qmcsCauseAnalysis" :placeholder="$t('btn.enter')+'原因分析'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="作业员" prop="qmcsOperator">
              <el-input clearable v-model="form.qmcsOperator" :placeholder="$t('btn.enter')+'作业员'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="工位" prop="qmcsStation">
              <el-input type="textarea" v-model="form.qmcsStation" :placeholder="$t('btn.enter')+'工位'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="qmcsLot">
              <el-input clearable v-model="form.qmcsLot" :placeholder="$t('btn.enter')+'批次'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="改善对策" prop="qmcsMeasures">
              <el-input type="textarea" v-model="form.qmcsMeasures" :placeholder="$t('btn.enter')+'改善对策'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="改善文件" prop="qmcsReformDocs">
              <UploadFile v-model="form.qmcsReformDocs" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'自定义A'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'自定义B'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'自定义C'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'自定义D'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'自定义E'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'自定义F'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义1'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义2'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义3'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义4'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义5'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义6'"  :disabled="true"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.Onboarding')" name="second">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.annex')" name="fourth">
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
          <el-tab-pane :label="$t('ptabs.sale')" name="tenth">
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
          <el-tab-pane :label="$t('ptabs.customization')" name="14th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="15th">
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

<script setup name="complaintsslave">
//后台操作函数
import { listComplaintsSlave,
 addComplaintsSlave, delComplaintsSlave, 
 updateComplaintsSlave,getComplaintsSlave, 
 } 
from '@/api/logistics/complaintsslave.js'
//
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
  pageSize: 20,
  sort: '',
  sortType: 'asc',
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qmcsSFID', label: 'SFID' },
  { visible: true, prop: 'qmcsIssuesNo', label: '外部客诉No.' },
  { visible: true, prop: 'qmcsLine', label: '班组' },
  { visible: true, prop: 'qmcsProcessingDate', label: '处理日期' },
  { visible: true, prop: 'qmcsDescription', label: '问题描述' },
  { visible: true, prop: 'qmcsCauseAnalysis', label: '原因分析' },
  { visible: true, prop: 'qmcsOperator', label: '作业员' },
  { visible: true, prop: 'qmcsStation', label: '工位' },
  { visible: false, prop: 'qmcsLot', label: '批次' },
  { visible: false, prop: 'qmcsMeasures', label: '改善对策' },
  { visible: false, prop: 'qmcsReformDocs', label: '改善文件' },
  { visible: false, prop: 'remark', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
  { visible: false, prop: 'updateBy', label: '更新者' },
  { visible: false, prop: 'updateTime', label: '更新时间' },
])
// 记录数
const total = ref(0)
//定义从设变表格数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
//输入日时间范围
//字典参数
var dictParams = [
  { dictType: "sql_line_list" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从从客诉管理/qm_complaints_slave表记录数据
function getList(){
  loading.value = true
  listComplaintsSlave(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.qmcsSFID);
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
    qmcsSFID: [{ required: true, message: 'SFID'+ proxy.$t('btn.empty'), trigger: "blur" }],
    qmcsIssuesNo: [{ required: true, message: '外部客诉No.'+ proxy.$t('btn.empty'), trigger: "blur"     }],
  },
  options: {
    // 班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_list: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.390.30666)
// @Author: (Lean365)
// @Date: (2024/1/25 17:05:54)



// 重置表单
function reset() {
  form.value = {
    qmcsSFID: 0,
    qmcsIssuesNo: null,
    qmcsLine: null,
    qmcsProcessingDate: null,
    qmcsDescription: null,
    qmcsCauseAnalysis: null,
    qmcsOperator: null,
    qmcsStation: null,
    qmcsLot: null,
    qmcsMeasures: null,
    qmcsReformDocs: null,
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
  title.value = proxy.$t('btn.add')+'从客诉管理'
  opertype.value = 1
  form.value.qmcsLine= []
  form.value.qmcsProcessingDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qmcsSFID || ids.value
  getComplaintsSlave(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ '从客诉管理'
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

      if (form.value.qmcsSFID != undefined && opertype.value === 2) {
        updateComplaintsSlave(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addComplaintsSlave(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.qmcsSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delComplaintsSlave(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
    })
}



// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"从客诉管理", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/logistics/ComplaintsSlave/export', { ...queryParams })
    })
}


// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.390.30666)
// @Author: (Lean365)
// @Date: (2024/1/25 17:05:54)

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