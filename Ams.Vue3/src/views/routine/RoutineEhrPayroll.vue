<!--
 * @Descripttion: 薪资/routine_ehr_payroll
 * @Version: 0.24.621.24558
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 15:20:02
 * @column：48
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="部门" prop="mk002">
        <el-select filterable clearable   v-model="queryParams.mk002" :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工号" prop="mk003">
        <el-input v-model="queryParams.mk003" :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="姓名" prop="mk004">
        <el-input v-model="queryParams.mk004" :placeholder="$t('btn.enterSearchPrefix')+'姓名'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrpayroll:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrpayroll:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrpayroll:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrpayroll:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/RoutineEhrPayroll/importTemplate"
                  importUrl="/Routine/RoutineEhrPayroll/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehrpayroll:export']">
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
      <el-table-column prop="mk002" label="部门" align="center" v-if="columns.showColumn('mk002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.mk002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mk003" label="工号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk003')"/>
      <el-table-column prop="mk004" label="姓名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk004')"/>
      <el-table-column prop="mk005" label="岗位" align="center" v-if="columns.showColumn('mk005')"/>
      <el-table-column prop="mk006" label="等级" align="center" v-if="columns.showColumn('mk006')"/>
      <el-table-column prop="mk007" label="薪别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk007')"/>
      <el-table-column prop="mk008" label="入职日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mk008')"/>
      <el-table-column prop="mk009" label="离职日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mk009')"/>
      <el-table-column prop="mk010" label="税别" align="center" v-if="columns.showColumn('mk010')"/>
      <el-table-column prop="mk011" label="基本工资" align="center" v-if="columns.showColumn('mk011')"/>
      <el-table-column prop="mk012" label="全勤" align="center" v-if="columns.showColumn('mk012')"/>
      <el-table-column prop="mk013" label="全勤否" align="center" v-if="columns.showColumn('mk013')"/>
      <el-table-column prop="mk014" label="职位津贴" align="center" v-if="columns.showColumn('mk014')"/>
      <el-table-column prop="mk015" label="职能调整" align="center" v-if="columns.showColumn('mk015')"/>
      <el-table-column prop="mk016" label="补助(夜霄，银行，其它)" align="center" v-if="columns.showColumn('mk016')"/>
      <el-table-column prop="mk017" label="其它津贴" align="center" v-if="columns.showColumn('mk017')"/>
      <el-table-column prop="mk018" label="保险" align="center" v-if="columns.showColumn('mk018')"/>
      <el-table-column prop="mk019" label="工龄" align="center" v-if="columns.showColumn('mk019')"/>
      <el-table-column prop="mk020" label="社保" align="center" v-if="columns.showColumn('mk020')"/>
      <el-table-column prop="mk021" label="奖金" align="center" v-if="columns.showColumn('mk021')"/>
      <el-table-column prop="mk022" label="加班" align="center" v-if="columns.showColumn('mk022')"/>
      <el-table-column prop="mk023" label="特殊津贴" align="center" v-if="columns.showColumn('mk023')"/>
      <el-table-column prop="nk024" label="伙食" align="center" v-if="columns.showColumn('nk024')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehrpayroll:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehrpayroll:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改薪资对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="ID" prop="id">
              <el-input   v-model.number="form.id" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')"  show-word-limit   maxlength="19"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="部门" prop="mk002">
              <el-select filterable clearable   v-model="form.mk002"  :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工号" prop="mk003">
              <el-input   v-model="form.mk003" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="姓名" prop="mk004">
              <el-input   v-model="form.mk004" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="岗位" prop="mk005">
              <el-input-number v-model.number="form.mk005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'岗位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="等级" prop="mk006">
              <el-input-number v-model.number="form.mk006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'等级'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="薪别" prop="mk007">
              <el-input   v-model="form.mk007" :placeholder="$t('btn.enterPrefix')+'薪别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="入职日期" prop="mk008">
              <el-date-picker v-model="form.mk008" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="离职日期" prop="mk009">
              <el-date-picker v-model="form.mk009" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="税别" prop="mk010">
              <el-input-number v-model.number="form.mk010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'税别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本工资" prop="mk011">
              <el-input-number v-model.number="form.mk011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基本工资'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="全勤" prop="mk012">
              <el-input-number v-model.number="form.mk012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'全勤'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="全勤否" prop="mk013">
              <el-input-number v-model.number="form.mk013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'全勤否'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="职位津贴" prop="mk014">
              <el-input-number v-model.number="form.mk014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'职位津贴'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="职能调整" prop="mk015">
              <el-input-number v-model.number="form.mk015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'职能调整'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="补助(夜霄，银行，其它)" prop="mk016">
              <el-input-number v-model.number="form.mk016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'补助(夜霄，银行，其它)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其它津贴" prop="mk017">
              <el-input-number v-model.number="form.mk017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其它津贴'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="保险" prop="mk018">
              <el-input-number v-model.number="form.mk018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保险'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="工龄" prop="mk019">
              <el-input-number v-model.number="form.mk019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工龄'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="社保" prop="mk020">
              <el-input-number v-model.number="form.mk020" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'社保'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="奖金" prop="mk021">
              <el-input-number v-model.number="form.mk021" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'奖金'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="加班" prop="mk022">
              <el-input-number v-model.number="form.mk022" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特殊津贴" prop="mk023">
              <el-input-number v-model.number="form.mk023" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'特殊津贴'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="伙食" prop="nk024">
              <el-input-number v-model.number="form.nk024" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'伙食'+$t('btn.enterSuffix')" />
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

<script setup name="routineehrpayroll">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrPayroll,
 addRoutineEhrPayroll, delRoutineEhrPayroll, 
 updateRoutineEhrPayroll,getRoutineEhrPayroll, 
 } 
from '@/api/routine/routineehrpayroll.js'
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
  sort: 'Mk003',
  sortType: 'asc',
  //是否查询（1是）
  mk002: undefined,
  //是否查询（1是）
  mk003: undefined,
  //是否查询（1是）
  mk004: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mk002', label: '部门' },
  { visible: true, prop: 'mk003', label: '工号' },
  { visible: true, prop: 'mk004', label: '姓名' },
  { visible: true, prop: 'mk005', label: '岗位' },
  { visible: true, prop: 'mk006', label: '等级' },
  { visible: true, prop: 'mk007', label: '薪别' },
  { visible: true, prop: 'mk008', label: '入职日期' },
  { visible: false, prop: 'mk009', label: '离职日期' },
  { visible: false, prop: 'mk010', label: '税别' },
  { visible: false, prop: 'mk011', label: '基本工资' },
  { visible: false, prop: 'mk012', label: '全勤' },
  { visible: false, prop: 'mk013', label: '全勤否' },
  { visible: false, prop: 'mk014', label: '职位津贴' },
  { visible: false, prop: 'mk015', label: '职能调整' },
  { visible: false, prop: 'mk016', label: '补助(夜霄，银行，其它)' },
  { visible: false, prop: 'mk017', label: '其它津贴' },
  { visible: false, prop: 'mk018', label: '保险' },
  { visible: false, prop: 'mk019', label: '工龄' },
  { visible: false, prop: 'mk020', label: '社保' },
  { visible: false, prop: 'mk021', label: '奖金' },
  { visible: false, prop: 'mk022', label: '加班' },
  { visible: false, prop: 'mk023', label: '特殊津贴' },
  { visible: false, prop: 'nk024', label: '伙食' },
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
  { dictType: "sql_dept_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从薪资/routine_ehr_payroll表记录数据
function getList(){
  loading.value = true
  listRoutineEhrPayroll(queryParams).then(res => {
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
    id: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mk002: [{ required: true, message: "部门"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    mk005: [{ required: true, message: "岗位"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mk006: [{ required: true, message: "等级"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mk010: [{ required: true, message: "税别"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mk011: [{ required: true, message: "基本工资"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mk019: [{ required: true, message: "工龄"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
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
    id: 0,
    mk002: [],
    mk003: null,
    mk004: null,
    mk005: 0,
    mk006: 0,
    mk007: null,
    mk008: null,
    mk009: null,
    mk010: 0,
    mk011: 0,
    mk012: 0,
    mk013: 0,
    mk014: 0,
    mk015: 0,
    mk016: 0,
    mk017: 0,
    mk018: 0,
    mk019: 0,
    mk020: 0,
    mk021: 0,
    mk022: 0,
    mk023: 0,
    nk024: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'薪资'
  opertype.value = 1
  form.value.mk002= 0
  form.value.mk005= 0
  form.value.mk006= 0
  form.value.mk008= new Date()
  form.value.mk009= new Date()
  form.value.mk010= 0
  form.value.mk011= 0
  form.value.mk012= 0
  form.value.mk013= 0
  form.value.mk014= 0
  form.value.mk015= 0
  form.value.mk016= 0
  form.value.mk017= 0
  form.value.mk018= 0
  form.value.mk019= 0
  form.value.mk020= 0
  form.value.mk021= 0
  form.value.mk022= 0
  form.value.mk023= 0
  form.value.nk024= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getRoutineEhrPayroll(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '薪资'
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
        updateRoutineEhrPayroll(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addRoutineEhrPayroll(form.value).then((res) => {
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
      return delRoutineEhrPayroll(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<薪资.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/RoutineEhrPayroll/export', { ...queryParams })
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