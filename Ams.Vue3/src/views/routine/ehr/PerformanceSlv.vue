<!--
 * @Descripttion: 绩效/routine_ehr_performance_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/9 17:21:01
 * @column：45
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="考核项目" prop="epEvalItems">
        <el-select filterable clearable   v-model="queryParams.epEvalItems" :placeholder="$t('btn.selectSearchPrefix')+'考核项目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_eval_items " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="初评日期">
        <el-date-picker
          v-model="dateRangeEpFirstEvalDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="六次考评日期">
        <el-date-picker
          v-model="dateRangeEpSixthEvalDate" 
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrperformanceslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrperformanceslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrperformanceslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrperformanceslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/RoutineEhrPerformanceSlv/importTemplate"
                  importUrl="/Routine/RoutineEhrPerformanceSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehrperformanceslv:export']">
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
      <el-table-column prop="epEvalItems" label="考核项目" align="center" v-if="columns.showColumn('epEvalItems')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eval_items " :value="scope.row.epEvalItems"  />
        </template>
      </el-table-column>
      <el-table-column prop="epFirstEvalScore" label="初次评分" align="center" v-if="columns.showColumn('epFirstEvalScore')"/>
      <el-table-column prop="epFirstEvaluator" label="初评人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epFirstEvaluator')"/>
      <el-table-column prop="epFirstEvalDate" label="初评日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('epFirstEvalDate')"/>
      <el-table-column prop="epSecondEvalScore" label="二次评分" align="center" v-if="columns.showColumn('epSecondEvalScore')"/>
      <el-table-column prop="eSecondEvaluator" label="二次考评人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eSecondEvaluator')"/>
      <el-table-column prop="epSecondEvalDate" label="二次考评日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('epSecondEvalDate')"/>
      <el-table-column prop="epThirdEvalScore" label="三次评分" align="center" v-if="columns.showColumn('epThirdEvalScore')"/>
      <el-table-column prop="epThirdEvaluator" label="三次考评人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epThirdEvaluator')"/>
      <el-table-column prop="epThirdEvalDate" label="三次考评日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('epThirdEvalDate')"/>
      <el-table-column prop="epFourthEvalScore" label="四次评分" align="center" v-if="columns.showColumn('epFourthEvalScore')"/>
      <el-table-column prop="epFourthEvaluator" label="四次考评人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epFourthEvaluator')"/>
      <el-table-column prop="epFourthEvalDate" label="四次考评日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('epFourthEvalDate')"/>
      <el-table-column prop="epFifthEvalScore" label="五次评分" align="center" v-if="columns.showColumn('epFifthEvalScore')"/>
      <el-table-column prop="epFifthEvaluator" label="五次考评人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epFifthEvaluator')"/>
      <el-table-column prop="eFifthEvalDate" label="五次考评日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eFifthEvalDate')"/>
      <el-table-column prop="epSixthEvalScore" label="六次评分" align="center" v-if="columns.showColumn('epSixthEvalScore')"/>
      <el-table-column prop="epSixthEvaluator" label="六次考评人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('epSixthEvaluator')"/>
      <el-table-column prop="epSixthEvalDate" label="六次考评日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('epSixthEvalDate')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehrperformanceslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehrperformanceslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改绩效对话框 -->
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
            <el-form-item label="考核项目" prop="epEvalItems">
              <el-select filterable clearable   v-model="form.epEvalItems"  :placeholder="$t('btn.selectPrefix')+'考核项目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_eval_items" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="初次评分" prop="epFirstEvalScore">
              <el-input-number v-model.number="form.epFirstEvalScore" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'初次评分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="初评人" prop="epFirstEvaluator">
              <el-input v-model="form.epFirstEvaluator" :placeholder="$t('btn.enterPrefix')+'初评人'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="初评日期" prop="epFirstEvalDate">
              <el-date-picker v-model="form.epFirstEvalDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="二次评分" prop="epSecondEvalScore">
              <el-input-number v-model.number="form.epSecondEvalScore" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'二次评分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="二次考评人" prop="eSecondEvaluator">
              <el-input v-model="form.eSecondEvaluator" :placeholder="$t('btn.enterPrefix')+'二次考评人'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="二次考评日期" prop="epSecondEvalDate">
              <el-date-picker v-model="form.epSecondEvalDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="三次评分" prop="epThirdEvalScore">
              <el-input-number v-model.number="form.epThirdEvalScore" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'三次评分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="三次考评人" prop="epThirdEvaluator">
              <el-input v-model="form.epThirdEvaluator" :placeholder="$t('btn.enterPrefix')+'三次考评人'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="三次考评日期" prop="epThirdEvalDate">
              <el-date-picker v-model="form.epThirdEvalDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="四次评分" prop="epFourthEvalScore">
              <el-input-number v-model.number="form.epFourthEvalScore" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'四次评分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="四次考评人" prop="epFourthEvaluator">
              <el-input v-model="form.epFourthEvaluator" :placeholder="$t('btn.enterPrefix')+'四次考评人'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="四次考评日期" prop="epFourthEvalDate">
              <el-date-picker v-model="form.epFourthEvalDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="五次评分" prop="epFifthEvalScore">
              <el-input-number v-model.number="form.epFifthEvalScore" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'五次评分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="五次考评人" prop="epFifthEvaluator">
              <el-input v-model="form.epFifthEvaluator" :placeholder="$t('btn.enterPrefix')+'五次考评人'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="五次考评日期" prop="eFifthEvalDate">
              <el-date-picker v-model="form.eFifthEvalDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="六次评分" prop="epSixthEvalScore">
              <el-input-number v-model.number="form.epSixthEvalScore" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'六次评分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="六次考评人" prop="epSixthEvaluator">
              <el-input v-model="form.epSixthEvaluator" :placeholder="$t('btn.enterPrefix')+'六次考评人'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="六次考评日期" prop="epSixthEvalDate">
              <el-date-picker v-model="form.epSixthEvalDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="routineehrperformanceslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrPerformanceSlv,
 addRoutineEhrPerformanceSlv, delRoutineEhrPerformanceSlv, 
 updateRoutineEhrPerformanceSlv,getRoutineEhrPerformanceSlv, 
 } 
from '@/api/routine/routineehrperformanceslv.js'
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
  sort: 'EpFirstEvalDate',
  sortType: 'desc',
//是否查询（1是）
  epEvalItems: undefined,
//是否查询（1是）
  epFirstEvalDate: undefined,
//是否查询（1是）
  epSixthEvalDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'epSfId', label: 'ID' },
  { visible: true, prop: 'epParentSfId', label: '父ID' },
  { visible: true, prop: 'epEvalItems', label: '考核项目' },
  { visible: true, prop: 'epFirstEvalScore', label: '初次评分' },
  { visible: true, prop: 'epFirstEvaluator', label: '初评人' },
  { visible: true, prop: 'epFirstEvalDate', label: '初评日期' },
  { visible: true, prop: 'epSecondEvalScore', label: '二次评分' },
  { visible: true, prop: 'eSecondEvaluator', label: '二次考评人' },
  { visible: false, prop: 'epSecondEvalDate', label: '二次考评日期' },
  { visible: false, prop: 'epThirdEvalScore', label: '三次评分' },
  { visible: false, prop: 'epThirdEvaluator', label: '三次考评人' },
  { visible: false, prop: 'epThirdEvalDate', label: '三次考评日期' },
  { visible: false, prop: 'epFourthEvalScore', label: '四次评分' },
  { visible: false, prop: 'epFourthEvaluator', label: '四次考评人' },
  { visible: false, prop: 'epFourthEvalDate', label: '四次考评日期' },
  { visible: false, prop: 'epFifthEvalScore', label: '五次评分' },
  { visible: false, prop: 'epFifthEvaluator', label: '五次考评人' },
  { visible: false, prop: 'eFifthEvalDate', label: '五次考评日期' },
  { visible: false, prop: 'epSixthEvalScore', label: '六次评分' },
  { visible: false, prop: 'epSixthEvaluator', label: '六次考评人' },
  { visible: false, prop: 'epSixthEvalDate', label: '六次考评日期' },
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
// 初评日期时间范围
const dateRangeEpFirstEvalDate = ref([])
// 六次考评日期时间范围
const dateRangeEpSixthEvalDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_eval_items" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从绩效/routine_ehr_performance_slv表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEpFirstEvalDate.value, 'EpFirstEvalDate');
  proxy.addDateRange(queryParams, dateRangeEpSixthEvalDate.value, 'EpSixthEvalDate');
  loading.value = true
  listRoutineEhrPerformanceSlv(queryParams).then(res => {
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
  // 初评日期时间范围
  dateRangeEpFirstEvalDate.value = []
  // 六次考评日期时间范围
  dateRangeEpSixthEvalDate.value = []
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
    // 考核项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_eval_items: [],
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
    epEvalItems: 0,
    epFirstEvalScore: 0,
    epFirstEvaluator: null,
    epFirstEvalDate: null,
    epSecondEvalScore: 0,
    eSecondEvaluator: null,
    epSecondEvalDate: null,
    epThirdEvalScore: 0,
    epThirdEvaluator: null,
    epThirdEvalDate: null,
    epFourthEvalScore: 0,
    epFourthEvaluator: null,
    epFourthEvalDate: null,
    epFifthEvalScore: 0,
    epFifthEvaluator: null,
    eFifthEvalDate: null,
    epSixthEvalScore: 0,
    epSixthEvaluator: null,
    epSixthEvalDate: null,
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
  title.value = proxy.$t('btn.add')+" "+'绩效'
  opertype.value = 1
  form.value.epEvalItems= 0
  form.value.epFirstEvalScore= 0
  form.value.epFirstEvalDate= new Date()
  form.value.epSecondEvalScore= 0
  form.value.epSecondEvalDate= new Date()
  form.value.epThirdEvalScore= 0
  form.value.epThirdEvalDate= new Date()
  form.value.epFourthEvalScore= 0
  form.value.epFourthEvalDate= new Date()
  form.value.epFifthEvalScore= 0
  form.value.eFifthEvalDate= new Date()
  form.value.epSixthEvalScore= 0
  form.value.epSixthEvalDate= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.epSfId || ids.value
  getRoutineEhrPerformanceSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '绩效'
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
        updateRoutineEhrPerformanceSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addRoutineEhrPerformanceSlv(form.value).then((res) => {
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
      return delRoutineEhrPerformanceSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<绩效.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/RoutineEhrPerformanceSlv/export', { ...queryParams })
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