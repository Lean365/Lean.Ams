<!--
 * @Descripttion: 考勤/routine_ehr_attendance
 * @Version: 0.24.621.24558
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 15:26:15
 * @column：44
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工号" prop="mg003">
        <el-input v-model="queryParams.mg003" :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="班别" prop="mg004">
        <el-select filterable clearable   v-model="queryParams.mg004" :placeholder="$t('btn.selectSearchPrefix')+'班别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_shifts_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeMg006" 
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrattendance:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrattendance:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrattendance:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrattendance:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/RoutineEhrAttendance/importTemplate"
                  importUrl="/Routine/RoutineEhrAttendance/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehrattendance:export']">
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="parentId" label="父ID" align="center" v-if="columns.showColumn('parentId')"/>
      <el-table-column prop="mg003" label="工号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg003')"/>
      <el-table-column prop="mg004" label="班别" align="center" v-if="columns.showColumn('mg004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_shifts_list " :value="scope.row.mg004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg005" label="假日别" align="center" v-if="columns.showColumn('mg005')"/>
      <el-table-column prop="mg006" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mg006')"/>
      <el-table-column prop="mg007" label="上班时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg007')"/>
      <el-table-column prop="mg008" label="下班时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg008')"/>
      <el-table-column prop="mg009" label="加班上班时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg009')"/>
      <el-table-column prop="mg010" label="加班下班时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg010')"/>
      <el-table-column prop="mg011" label="迟到分钟" align="center" v-if="columns.showColumn('mg011')"/>
      <el-table-column prop="mg012" label="迟到否" align="center" v-if="columns.showColumn('mg012')"/>
      <el-table-column prop="mg013" label="早退分钟" align="center" v-if="columns.showColumn('mg013')"/>
      <el-table-column prop="mg014" label="早退否" align="center" v-if="columns.showColumn('mg014')"/>
      <el-table-column prop="mg015" label="假日加班时数" align="center" v-if="columns.showColumn('mg015')"/>
      <el-table-column prop="mg016" label="异常" align="center" v-if="columns.showColumn('mg016')"/>
      <el-table-column prop="mg017" label="异常原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg017')"/>
      <el-table-column prop="mg018" label="已有请假信息" align="center" v-if="columns.showColumn('mg018')"/>
      <el-table-column prop="mg019" label="正常加班" align="center" v-if="columns.showColumn('mg019')"/>
      <el-table-column prop="mg020" label="节日加班" align="center" v-if="columns.showColumn('mg020')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehrattendance:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehrattendance:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改考勤对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="parentId">
              <el-input   v-model.number="form.parentId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')"  show-word-limit   maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工号" prop="mg003">
              <el-input   v-model="form.mg003" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="班别" prop="mg004">
              <el-select filterable clearable   v-model="form.mg004"  :placeholder="$t('btn.selectPrefix')+'班别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_shifts_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="假日别" prop="mg005">
              <el-input-number v-model.number="form.mg005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'假日别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="mg006">
              <el-date-picker v-model="form.mg006" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上班时间" prop="mg007">
              <el-input   v-model="form.mg007" :placeholder="$t('btn.enterPrefix')+'上班时间'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="下班时间" prop="mg008">
              <el-input   v-model="form.mg008" :placeholder="$t('btn.enterPrefix')+'下班时间'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="加班上班时间" prop="mg009">
              <el-input   v-model="form.mg009" :placeholder="$t('btn.enterPrefix')+'加班上班时间'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="加班下班时间" prop="mg010">
              <el-input   v-model="form.mg010" :placeholder="$t('btn.enterPrefix')+'加班下班时间'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="迟到分钟" prop="mg011">
              <el-input-number v-model.number="form.mg011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'迟到分钟'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="迟到否" prop="mg012">
              <el-input-number v-model.number="form.mg012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'迟到否'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="早退分钟" prop="mg013">
              <el-input-number v-model.number="form.mg013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'早退分钟'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="早退否" prop="mg014">
              <el-input-number v-model.number="form.mg014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'早退否'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="假日加班时数" prop="mg015">
              <el-input-number v-model.number="form.mg015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'假日加班时数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="异常" prop="mg016">
              <el-input-number v-model.number="form.mg016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'异常'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="异常原因" prop="mg017">
              <el-input   v-model="form.mg017" :placeholder="$t('btn.enterPrefix')+'异常原因'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="已有请假信息" prop="mg018">
              <el-input-number v-model.number="form.mg018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'已有请假信息'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="正常加班" prop="mg019">
              <el-input-number v-model.number="form.mg019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'正常加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="节日加班" prop="mg020">
              <el-input-number v-model.number="form.mg020" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'节日加班'+$t('btn.enterSuffix')" />
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

<script setup name="routineehrattendance">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrAttendance,
 addRoutineEhrAttendance, delRoutineEhrAttendance, 
 updateRoutineEhrAttendance,getRoutineEhrAttendance, 
 } 
from '@/api/routine/routineehrattendance.js'
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
  sort: '',
  sortType: 'asc',
  //是否查询（1是）
  mg003: undefined,
  //是否查询（1是）
  mg004: undefined,
  //是否查询（1是）
  mg006: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'mg003', label: '工号' },
  { visible: true, prop: 'mg004', label: '班别' },
  { visible: true, prop: 'mg005', label: '假日别' },
  { visible: true, prop: 'mg006', label: '日期' },
  { visible: true, prop: 'mg007', label: '上班时间' },
  { visible: true, prop: 'mg008', label: '下班时间' },
  { visible: false, prop: 'mg009', label: '加班上班时间' },
  { visible: false, prop: 'mg010', label: '加班下班时间' },
  { visible: false, prop: 'mg011', label: '迟到分钟' },
  { visible: false, prop: 'mg012', label: '迟到否' },
  { visible: false, prop: 'mg013', label: '早退分钟' },
  { visible: false, prop: 'mg014', label: '早退否' },
  { visible: false, prop: 'mg015', label: '假日加班时数' },
  { visible: false, prop: 'mg016', label: '异常' },
  { visible: false, prop: 'mg017', label: '异常原因' },
  { visible: false, prop: 'mg018', label: '已有请假信息' },
  { visible: false, prop: 'mg019', label: '正常加班' },
  { visible: false, prop: 'mg020', label: '节日加班' },
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
const dateRangeMg006 = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_shifts_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从考勤/routine_ehr_attendance表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMg006.value, 'Mg006');
  loading.value = true
  listRoutineEhrAttendance(queryParams).then(res => {
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
  dateRangeMg006.value = []
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
    parentId: [{ required: true, message: "父ID"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg003: [{ required: true, message: "工号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mg004: [{ required: true, message: "班别"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    mg005: [{ required: true, message: "假日别"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg011: [{ required: true, message: "迟到分钟"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg012: [{ required: true, message: "迟到否"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg013: [{ required: true, message: "早退分钟"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg014: [{ required: true, message: "早退否"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg015: [{ required: true, message: "假日加班时数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg016: [{ required: true, message: "异常"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg018: [{ required: true, message: "已有请假信息"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg019: [{ required: true, message: "正常加班"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mg020: [{ required: true, message: "节日加班"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 班别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_shifts_list: [],
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
    parentId: 0,
    mg003: null,
    mg004: [],
    mg005: 0,
    mg006: null,
    mg007: null,
    mg008: null,
    mg009: null,
    mg010: null,
    mg011: 0,
    mg012: 0,
    mg013: 0,
    mg014: 0,
    mg015: 0,
    mg016: 0,
    mg017: null,
    mg018: 0,
    mg019: 0,
    mg020: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'考勤'
  opertype.value = 1
  form.value.mg004= 0
  form.value.mg005= 0
  form.value.mg006= new Date()
  form.value.mg011= 0
  form.value.mg012= 0
  form.value.mg013= 0
  form.value.mg014= 0
  form.value.mg015= 0
  form.value.mg016= 0
  form.value.mg018= 0
  form.value.mg019= 0
  form.value.mg020= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getRoutineEhrAttendance(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '考勤'
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

      if (form.value.id != undefined && opertype.value === 2) {
        updateRoutineEhrAttendance(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addRoutineEhrAttendance(form.value).then((res) => {
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
      return delRoutineEhrAttendance(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<考勤.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/RoutineEhrAttendance/export', { ...queryParams })
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