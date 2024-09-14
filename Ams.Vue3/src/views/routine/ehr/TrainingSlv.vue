<!--
 * @Descripttion: 培训/routine_ehr_training_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/9 17:22:49
 * @column：39
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="项目" prop="epTrainingItems">
        <el-select filterable clearable   v-model="queryParams.epTrainingItems" :placeholder="$t('btn.selectSearchPrefix')+'项目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_training_items " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="内容" prop="epTrainingContent">
        <el-input v-model="queryParams.epTrainingContent" :placeholder="$t('btn.enterSearchPrefix')+'内容'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="结果" prop="epTrainingResults">
        <el-select filterable clearable   v-model="queryParams.epTrainingResults" :placeholder="$t('btn.selectSearchPrefix')+'结果'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_training_results " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeEpTrainingDate" 
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrtrainingslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrtrainingslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrtrainingslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrtrainingslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/RoutineEhrTrainingSlv/importTemplate"
                  importUrl="/Routine/RoutineEhrTrainingSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehrtrainingslv:export']">
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
      <el-table-column prop="epSfId" label="ID" align="center" v-if="columns.showColumn('epSfId')"/>
      <el-table-column prop="epParentSfId" label="父ID" align="center" v-if="columns.showColumn('epParentSfId')"/>
      <el-table-column prop="epTrainingItems" label="项目" align="center" v-if="columns.showColumn('epTrainingItems')">
        <template #default="scope">
          <dict-tag :options=" options.sys_training_items " :value="scope.row.epTrainingItems"  />
        </template>
      </el-table-column>
      <el-table-column prop="epTrainingContent" label="内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epTrainingContent')"/>
      <el-table-column prop="epTrainingPurpose" label="目的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epTrainingPurpose')"/>
      <el-table-column prop="epTrainingScore" label="分数" align="center" v-if="columns.showColumn('epTrainingScore')"/>
      <el-table-column prop="epTrainingResults" label="结果" align="center" v-if="columns.showColumn('epTrainingResults')">
        <template #default="scope">
          <dict-tag :options=" options.sys_training_results " :value="scope.row.epTrainingResults"  />
        </template>
      </el-table-column>
      <el-table-column prop="epTrainingDate" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('epTrainingDate')"/>
      <el-table-column prop="epTrainingTeacher" label="指导老师" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epTrainingTeacher')"/>
      <el-table-column prop="epFirstConfirmer" label="确认" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epFirstConfirmer')"/>
      <el-table-column prop="epSecondConfirmer" label="确认" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epSecondConfirmer')"/>
      <el-table-column prop="epThirdConfirmer" label="确认" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epThirdConfirmer')"/>
      <el-table-column prop="epFourthApprover" label="承认" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epFourthApprover')"/>
      <el-table-column prop="epFifthApprover" label="承认" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epFifthApprover')"/>
      <el-table-column prop="epSixthApprover" label="承认" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epSixthApprover')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehrtrainingslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehrtrainingslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改培训对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="epParentSfId">
              <el-input v-model.number="form.epParentSfId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')"  show-word-limit maxlength="19"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="项目" prop="epTrainingItems">
              <el-select filterable clearable   v-model="form.epTrainingItems"  :placeholder="$t('btn.selectPrefix')+'项目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_training_items" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="内容" prop="epTrainingContent">
              <el-input type="textarea" v-model="form.epTrainingContent" :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')" show-word-limit maxlength="-1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="目的" prop="epTrainingPurpose">
              <el-input type="textarea" v-model="form.epTrainingPurpose" :placeholder="$t('btn.enterPrefix')+'目的'+$t('btn.enterSuffix')" show-word-limit maxlength="-1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="分数" prop="epTrainingScore">
              <el-input-number v-model.number="form.epTrainingScore" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'分数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="结果" prop="epTrainingResults">
              <el-select filterable clearable   v-model="form.epTrainingResults"  :placeholder="$t('btn.selectPrefix')+'结果'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_training_results" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="日期" prop="epTrainingDate">
              <el-date-picker v-model="form.epTrainingDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="指导老师" prop="epTrainingTeacher">
              <el-input v-model="form.epTrainingTeacher" :placeholder="$t('btn.enterPrefix')+'指导老师'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="确认" prop="epFirstConfirmer">
              <el-input v-model="form.epFirstConfirmer" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="确认" prop="epSecondConfirmer">
              <el-input v-model="form.epSecondConfirmer" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="确认" prop="epThirdConfirmer">
              <el-input v-model="form.epThirdConfirmer" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认" prop="epFourthApprover">
              <el-input v-model="form.epFourthApprover" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认" prop="epFifthApprover">
              <el-input v-model="form.epFifthApprover" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认" prop="epSixthApprover">
              <el-input v-model="form.epSixthApprover" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
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

<script setup name="routineehrtrainingslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrTrainingSlv,
 addRoutineEhrTrainingSlv, delRoutineEhrTrainingSlv, 
 updateRoutineEhrTrainingSlv,getRoutineEhrTrainingSlv, 
 } 
from '@/api/routine/routineehrtrainingslv.js'
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
  sort: 'EpTrainingDate',
  sortType: 'desc',
//是否查询（1是）
  epTrainingItems: undefined,
//是否查询（1是）
  epTrainingContent: undefined,
//是否查询（1是）
  epTrainingResults: undefined,
//是否查询（1是）
  epTrainingDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'epSfId', label: 'ID' },
  { visible: true, prop: 'epParentSfId', label: '父ID' },
  { visible: true, prop: 'epTrainingItems', label: '项目' },
  { visible: true, prop: 'epTrainingContent', label: '内容' },
  { visible: true, prop: 'epTrainingPurpose', label: '目的' },
  { visible: true, prop: 'epTrainingScore', label: '分数' },
  { visible: true, prop: 'epTrainingResults', label: '结果' },
  { visible: true, prop: 'epTrainingDate', label: '日期' },
  { visible: false, prop: 'epTrainingTeacher', label: '指导老师' },
  { visible: false, prop: 'epFirstConfirmer', label: '确认' },
  { visible: false, prop: 'epSecondConfirmer', label: '确认' },
  { visible: false, prop: 'epThirdConfirmer', label: '确认' },
  { visible: false, prop: 'epFourthApprover', label: '承认' },
  { visible: false, prop: 'epFifthApprover', label: '承认' },
  { visible: false, prop: 'epSixthApprover', label: '承认' },
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
// 日期时间范围
const dateRangeEpTrainingDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_training_items" },
  { dictType: "sys_training_results" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从培训/routine_ehr_training_slv表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEpTrainingDate.value, 'EpTrainingDate');
  loading.value = true
  listRoutineEhrTrainingSlv(queryParams).then(res => {
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
  // 日期时间范围
  dateRangeEpTrainingDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.epSfId);
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
    epSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_training_items: [],
    // 结果 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_training_results: [],
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
    epSfId: 0,
    epParentSfId: 0,
    epTrainingItems: 0,
    epTrainingContent: null,
    epTrainingPurpose: null,
    epTrainingScore: 0,
    epTrainingResults: null,
    epTrainingDate: null,
    epTrainingTeacher: null,
    epFirstConfirmer: null,
    epSecondConfirmer: null,
    epThirdConfirmer: null,
    epFourthApprover: null,
    epFifthApprover: null,
    epSixthApprover: null,
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
  title.value = proxy.$t('btn.add')+" "+'培训'
  opertype.value = 1
  form.value.epTrainingItems= 0
  form.value.epTrainingScore= 0
  form.value.epTrainingResults= []
  form.value.epTrainingDate= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.epSfId || ids.value
  getRoutineEhrTrainingSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '培训'
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

      if (form.value.epSfId != undefined && opertype.value === 2) {
        updateRoutineEhrTrainingSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addRoutineEhrTrainingSlv(form.value).then((res) => {
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
  const Ids = row.epSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delRoutineEhrTrainingSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<培训.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/RoutineEhrTrainingSlv/export', { ...queryParams })
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