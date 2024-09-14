<!--
 * @Descripttion: 培训/routine_ehr_training_ma
 * @Version: 0.24.621.24558
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 15:13:49
 * @column：28
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工号" prop="mq002">
        <el-input v-model="queryParams.mq002" :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="姓名" prop="mq003">
        <el-input v-model="queryParams.mq003" :placeholder="$t('btn.enterSearchPrefix')+'姓名'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="年度" prop="mq004">
        <el-select filterable clearable   v-model="queryParams.mq004" :placeholder="$t('btn.selectSearchPrefix')+'年度'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrtrainingma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrtrainingma:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrtrainingma:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrtrainingma:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/RoutineEhrTrainingMa/importTemplate"
                  importUrl="/Routine/RoutineEhrTrainingMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehrtrainingma:export']">
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="mq002" label="工号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq002')"/>
      <el-table-column prop="mq003" label="姓名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq003')"/>
      <el-table-column prop="mq004" label="年度" align="center" v-if="columns.showColumn('mq004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mq004"  />
        </template>
      </el-table-column>
      <el-table-column prop="isDeleted" label="软删除" align="center" v-if="columns.showColumn('isDeleted')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehrtrainingma:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehrtrainingma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="routineEhrTrainingSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID"/>
        <el-table-column prop="parentId" label="父ID"/>
        <el-table-column prop="mr003" label="项目">
          <template #default="scope">
            <dict-tag :options=" options.sys_training_items " :value="scope.row.mr003"  />
          </template>
        </el-table-column>
        <el-table-column prop="mr004" label="内容"/>
        <el-table-column prop="mr005" label="目的"/>
        <el-table-column prop="mr006" label="分数"/>
        <el-table-column prop="mr007" label="结果">
          <template #default="scope">
            <dict-tag :options=" options.sys_training_results " :value="scope.row.mr007"  />
          </template>
        </el-table-column>
        <el-table-column prop="mr008" label="日期"/>
        <el-table-column prop="mr009" label="指导老师"/>
        <el-table-column prop="mr010" label="确认"/>
        <el-table-column prop="mr011" label="确认"/>
        <el-table-column prop="mr012" label="确认"/>
        <el-table-column prop="mr013" label="承认"/>
        <el-table-column prop="mr014" label="承认"/>
        <el-table-column prop="mr015" label="承认"/>
        <el-table-column prop="isDeleted" label="软删除"/>
        <el-table-column prop="remark" label="备注说明"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改培训对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工号" prop="mq002">
              <el-input   v-model="form.mq002" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="姓名" prop="mq003">
              <el-input   v-model="form.mq003" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年度" prop="mq004">
              <el-select filterable clearable   v-model="form.mq004"  :placeholder="$t('btn.selectPrefix')+'年度'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'软删除'+$t('btn.enterSuffix')" />
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
        <el-divider content-position="center">培训</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddRoutineEhrTrainingSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeleteRoutineEhrTrainingSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="routineEhrTrainingSlvList" :row-class-name="rowRoutineEhrTrainingSlvIndex" @selection-change="handleRoutineEhrTrainingSlvSelectionChange" ref="RoutineEhrTrainingSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="项目" prop="mr003">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mr003" :placeholder="$t('btn.enterPrefix')+'项目'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_training_items" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="内容" align="center" prop="mr004">
            <template #default="scope">
              <el-input v-model="scope.row.mr004" :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="目的" align="center" prop="mr005">
            <template #default="scope">
              <el-input v-model="scope.row.mr005" :placeholder="$t('btn.enterPrefix')+'目的'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="分数" align="center" prop="mr006" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mr006" controls-position="right" :placeholder="$t('btn.enterPrefix')+'分数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="结果" prop="mr007">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mr007" :placeholder="$t('btn.enterPrefix')+'结果'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_training_results" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="日期" align="center" prop="mr008">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mr008" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="指导老师" align="center" prop="mr009">
            <template #default="scope">
              <el-input v-model="scope.row.mr009" :placeholder="$t('btn.enterPrefix')+'指导老师'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="确认" align="center" prop="mr010">
            <template #default="scope">
              <el-input v-model="scope.row.mr010" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="确认" align="center" prop="mr011">
            <template #default="scope">
              <el-input v-model="scope.row.mr011" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="确认" align="center" prop="mr012">
            <template #default="scope">
              <el-input v-model="scope.row.mr012" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="承认" align="center" prop="mr013">
            <template #default="scope">
              <el-input v-model="scope.row.mr013" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="承认" align="center" prop="mr014">
            <template #default="scope">
              <el-input v-model="scope.row.mr014" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="承认" align="center" prop="mr015">
            <template #default="scope">
              <el-input v-model="scope.row.mr015" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="软删除" align="center" prop="isDeleted" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.isDeleted" controls-position="right" :placeholder="$t('btn.enterPrefix')+'软删除'+$t('btn.enterSuffix')" />
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

<script setup name="routineehrtrainingma">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrTrainingMa,
 addRoutineEhrTrainingMa, delRoutineEhrTrainingMa, 
 updateRoutineEhrTrainingMa,getRoutineEhrTrainingMa, 
 } 
from '@/api/routine/routineehrtrainingma.js'
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
  sort: 'Mq004',
  sortType: 'desc',
  //是否查询（1是）
  mq002: undefined,
  //是否查询（1是）
  mq003: undefined,
  //是否查询（1是）
  mq004: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mq002', label: '工号' },
  { visible: true, prop: 'mq003', label: '姓名' },
  { visible: true, prop: 'mq004', label: '年度' },
  { visible: false, prop: 'isDeleted', label: '软删除' },
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
  { dictType: "sys_training_items" },
  { dictType: "sys_training_results" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从培训/routine_ehr_training_ma表记录数据
function getList(){
  loading.value = true
  listRoutineEhrTrainingMa(queryParams).then(res => {
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
    mq002: [{ required: true, message: "工号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mq003: [{ required: true, message: "姓名"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 年度 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_training_items: [],
    // 结果 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_training_results: [],
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
    mq002: null,
    mq003: null,
    mq004: [],
    isDeleted: 0,
    remark: null,
  };
  routineEhrTrainingSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'培训'
  opertype.value = 1
  form.value.mq004= []
  form.value.isDeleted= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getRoutineEhrTrainingMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '培训'
      opertype.value = 2

      form.value = {
        ...data,
      }
      routineEhrTrainingSlvList.value = res.data.routineEhrTrainingSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.routineEhrTrainingSlvNav = routineEhrTrainingSlvList.value
      if (form.value.id != undefined && opertype.value === 2) {
        updateRoutineEhrTrainingMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addRoutineEhrTrainingMa(form.value).then((res) => {
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
      return delRoutineEhrTrainingMa(Ids)
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
      await proxy.downFile('/Routine/RoutineEhrTrainingMa/export', { ...queryParams })
    })
}

/*********************培训子表信息*************************/
const routineEhrTrainingSlvList = ref([])
const checkedRoutineEhrTrainingSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 培训序号 */
function rowRoutineEhrTrainingSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 培训添加按钮操作 */
function handleAddRoutineEhrTrainingSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.mr003 = null;
  //obj.mr004 = null;
  //obj.mr005 = null;
  //obj.mr006 = null;
  //obj.mr007 = null;
  //obj.mr008 = null;
  //obj.mr009 = null;
  //obj.mr010 = null;
  //obj.mr011 = null;
  //obj.mr012 = null;
  //obj.mr013 = null;
  //obj.mr014 = null;
  //obj.mr015 = null;
  //obj.isDeleted = null;
  //obj.remark = null;
  routineEhrTrainingSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handleRoutineEhrTrainingSlvSelectionChange(selection) {
  checkedRoutineEhrTrainingSlv.value = selection.map(item => item.index)
}

/** 培训删除按钮操作 */
function handleDeleteRoutineEhrTrainingSlv() {
  if(checkedRoutineEhrTrainingSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的培训数据')
  } else {
    const RoutineEhrTrainingSlvs = routineEhrTrainingSlvList.value;
    const checkedRoutineEhrTrainingSlvs = checkedRoutineEhrTrainingSlv.value;
    routineEhrTrainingSlvList.value = RoutineEhrTrainingSlvs.filter(function(item) {
      return checkedRoutineEhrTrainingSlvs.indexOf(item.index) == -1
    });
  }
}

/** 培训详情 */
function rowClick(row) {
  const id = row.id || ids.value
  getRoutineEhrTrainingMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      routineEhrTrainingSlvList.value = data.routineEhrTrainingSlvNav
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