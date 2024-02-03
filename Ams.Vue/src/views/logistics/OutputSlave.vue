<!--
 * @Descripttion: (oph从表/pp_output_slave)
 * @Version: (0.24.387.20459)
 * @Author: (Lean365)
 * @Date: (2024/1/22 11:22:39)
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
        <el-button type="primary" v-hasPermi="['pp:outputslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:outputslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:outputslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputslave:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="logistics/OutputSlave/importTemplate"
                  importUrl="/logistics/OutputSlave/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputslave:export']">
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
      <el-table-column prop="posSfid" label="SFID" align="center" v-if="columns.showColumn('posSfid')"/>
      <el-table-column prop="posParentSfid" label="父SFID" align="center" v-if="columns.showColumn('posParentSfid')"/>
      <el-table-column prop="posProductionTime" label="生产时段" align="center" v-if="columns.showColumn('posProductionTime')">
        <template #default="scope">
          <dict-tag :options=" options.app_phase_time " :value="scope.row.posProductionTime"  />
        </template>
      </el-table-column>
      <el-table-column prop="posRealOutput" label="实际产能" align="center" v-if="columns.showColumn('posRealOutput')"/>
      <el-table-column prop="posDownTime" label="停线时间" align="center" v-if="columns.showColumn('posDownTime')"/>
      <el-table-column prop="posDownTimeReasons" label="停线原因" align="center" v-if="columns.showColumn('posDownTimeReasons')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_stop " :value="scope.row.posDownTimeReasons"  />
        </template>
      </el-table-column>
      <el-table-column prop="posDownTimeDescription" label="停线说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('posDownTimeDescription')"/>
      <el-table-column prop="posUnfinishedReasons" label="未达成原因" align="center" v-if="columns.showColumn('posUnfinishedReasons')">
        <template #default="scope">
          <dict-tag :options=" options.sql_non_conf " :value="scope.row.posUnfinishedReasons"  />
        </template>
      </el-table-column>
      <el-table-column prop="posUnfinishedDescription" label="未达成说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('posUnfinishedDescription')"/>
      <el-table-column prop="posRealWorkhours" label="实际工数" align="center" v-if="columns.showColumn('posRealWorkhours')"/>
      <el-table-column prop="posInputsWorkhours" label="投入工数" align="center" v-if="columns.showColumn('posInputsWorkhours')"/>
      <el-table-column prop="posRealWorkinghoursDiff" label="工时差异" align="center" v-if="columns.showColumn('posRealWorkinghoursDiff')"/>
      <el-table-column prop="posRealOutputDiff" label="产能差异" align="center" v-if="columns.showColumn('posRealOutputDiff')"/>
      <el-table-column prop="posAchievedRate" label="达成率" align="center" v-if="columns.showColumn('posAchievedRate')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:outputslave:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:outputslave:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改oph从表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="posSfid">
              <el-input v-model.number="form.posSfid" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="父SFID" prop="posParentSfid">
              <el-input v-model.number="form.posParentSfid" :placeholder="$t('btn.enter')+'父SFID'"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产时段" prop="posProductionTime">
              <el-select clearable filterable v-model="form.posProductionTime"  :placeholder="$t('btn.select')+'生产时段'">
                <el-option
                  v-for="item in options.app_phase_time" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实际产能" prop="posRealOutput">
              <el-input-number v-model.number="form.posRealOutput" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'实际产能'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="停线时间" prop="posDownTime">
              <el-input-number v-model.number="form.posDownTime" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'停线时间'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线原因" prop="posDownTimeReasons">
              <el-select clearable filterable v-model="form.posDownTimeReasons"  :placeholder="$t('btn.select')+'停线原因'">
                <el-option
                  v-for="item in options.sql_line_stop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线说明" prop="posDownTimeDescription">
              <el-input v-model="form.posDownTimeDescription" :placeholder="$t('btn.enter')+'停线说明'"  />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成原因" prop="posUnfinishedReasons">
              <el-select clearable filterable v-model="form.posUnfinishedReasons"  :placeholder="$t('btn.select')+'未达成原因'">
                <el-option
                  v-for="item in options.sql_non_conf" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成说明" prop="posUnfinishedDescription">
              <el-input v-model="form.posUnfinishedDescription" :placeholder="$t('btn.enter')+'未达成说明'"  />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实际工数" prop="posRealWorkhours">
              <el-input-number v-model.number="form.posRealWorkhours" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'实际工数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入工数" prop="posInputsWorkhours">
              <el-input-number v-model.number="form.posInputsWorkhours" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'投入工数'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工时差异" prop="posRealWorkinghoursDiff">
              <el-input-number v-model.number="form.posRealWorkinghoursDiff" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'工时差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产能差异" prop="posRealOutputDiff">
              <el-input-number v-model.number="form.posRealOutputDiff" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'产能差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="达成率" prop="posAchievedRate">
              <el-input-number v-model.number="form.posAchievedRate" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'达成率'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enter')+'自定义A'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input v-model="form.uDF02" :placeholder="$t('btn.enter')+'自定义B'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input v-model="form.uDF03" :placeholder="$t('btn.enter')+'自定义C'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input v-model="form.uDF04" :placeholder="$t('btn.enter')+'自定义D'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input v-model="form.uDF05" :placeholder="$t('btn.enter')+'自定义E'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input v-model="form.uDF06" :placeholder="$t('btn.enter')+'自定义F'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input v-model="form.uDF51" :placeholder="$t('btn.enter')+'自定义1'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input v-model="form.uDF52" :placeholder="$t('btn.enter')+'自定义2'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input v-model="form.uDF53" :placeholder="$t('btn.enter')+'自定义3'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input v-model="form.uDF54" :placeholder="$t('btn.enter')+'自定义4'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input v-model="form.uDF55" :placeholder="$t('btn.enter')+'自定义5'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input v-model="form.uDF56" :placeholder="$t('btn.enter')+'自定义6'"  :disabled="true" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input v-model.number="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'说明'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'"  :disabled="true" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'"  :disabled="true" />
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
          <el-tab-pane :label="$t('ptabs.customization')" name="ninth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="tenth">
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

<script setup name="outputslave">
//后台操作函数
import { listOutputSlave,
 addOutputSlave, delOutputSlave, 
 updateOutputSlave,getOutputSlave, 
 } 
from '@/api/logistics/outputslave.js'
//
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
  pageSize: 20,
  sort: '',
  sortType: 'asc',
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'posSfid', label: 'SFID' },
  { visible: true, prop: 'posParentSfid', label: '父SFID' },
  { visible: true, prop: 'posProductionTime', label: '生产时段' },
  { visible: true, prop: 'posRealOutput', label: '实际产能' },
  { visible: true, prop: 'posDownTime', label: '停线时间' },
  { visible: true, prop: 'posDownTimeReasons', label: '停线原因' },
  { visible: true, prop: 'posDownTimeDescription', label: '停线说明' },
  { visible: true, prop: 'posUnfinishedReasons', label: '未达成原因' },
  { visible: false, prop: 'posUnfinishedDescription', label: '未达成说明' },
  { visible: false, prop: 'posRealWorkhours', label: '实际工数' },
  { visible: false, prop: 'posInputsWorkhours', label: '投入工数' },
  { visible: false, prop: 'posRealWorkinghoursDiff', label: '工时差异' },
  { visible: false, prop: 'posRealOutputDiff', label: '产能差异' },
  { visible: false, prop: 'posAchievedRate', label: '达成率' },
  { visible: false, prop: 'remark', label: '说明' },
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
  { dictType: "app_phase_time" },
  { dictType: "sql_line_stop" },
  { dictType: "sql_non_conf" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从oph从表/pp_output_slave表记录数据
function getList(){
  loading.value = true
  listOutputSlave(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.posSfid);
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
    posSfid: [{ required: true, message: 'SFID'+ proxy.$t('btn.empty'), trigger: "blur" }],
    posParentSfid: [{ required: true, message: '父SFID'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
    posRealOutput: [{ required: true, message: '实际产能'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
    posDownTime: [{ required: true, message: '停线时间'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
    posRealWorkhours: [{ required: true, message: '实际工数'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 生产时段 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_phase_time: [],
    // 停线原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_stop: [],
    // 未达成原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_non_conf: [],
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
    posSfid: 0,
    posParentSfid: 0,
    posProductionTime: null,
    posRealOutput: 0,
    posDownTime: 0,
    posDownTimeReasons: null,
    posDownTimeDescription: null,
    posUnfinishedReasons: null,
    posUnfinishedDescription: null,
    posRealWorkhours: 0,
    posInputsWorkhours: 0,
    posRealWorkinghoursDiff: 0,
    posRealOutputDiff: 0,
    posAchievedRate: 0,
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
  title.value = proxy.$t('btn.add')+'oph从表'
  opertype.value = 1
  form.value.posProductionTime= []
  form.value.posRealOutput= 0
  form.value.posDownTime= 0
  form.value.posDownTimeReasons= []
  form.value.posUnfinishedReasons= []
  form.value.posRealWorkhours= 0
  form.value.posInputsWorkhours= 0
  form.value.posRealWorkinghoursDiff= 0
  form.value.posRealOutputDiff= 0
  form.value.posAchievedRate= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.posSfid || ids.value
  getOutputSlave(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ 'oph从表'
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

      if (form.value.posSfid != undefined && opertype.value === 2) {
        updateOutputSlave(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addOutputSlave(form.value).then((res) => {
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
  const Ids = row.posSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delOutputSlave(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
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
    .$confirm(proxy.$t('common.confirmExport')+"oph从表", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/logistics/OutputSlave/export', { ...queryParams })
    })
}

//自定义统计函数
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