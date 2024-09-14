<!--
 * @Descripttion: 招聘/routine_ehr_recruitment
 * @Version: 0.24.621.24558
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 15:16:55
 * @column：42
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="招聘日期">
        <el-date-picker
          v-model="dateRangeMn002" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="姓名" prop="mn003">
        <el-input v-model="queryParams.mn003" :placeholder="$t('btn.enterSearchPrefix')+'姓名'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="部门" prop="mn004">
        <el-select filterable clearable   v-model="queryParams.mn004" :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="聘用形式" prop="mn009">
        <el-select filterable clearable   v-model="queryParams.mn009" :placeholder="$t('btn.selectSearchPrefix')+'聘用形式'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrrecruitment:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrrecruitment:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrrecruitment:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrrecruitment:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/RoutineEhrRecruitment/importTemplate"
                  importUrl="/Routine/RoutineEhrRecruitment/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehrrecruitment:export']">
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
      <el-table-column prop="mn002" label="招聘日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mn002')"/>
      <el-table-column prop="mn003" label="姓名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mn003')"/>
      <el-table-column prop="mn004" label="部门" align="center" v-if="columns.showColumn('mn004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.mn004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mn005" label="职称" align="center" v-if="columns.showColumn('mn005')"/>
      <el-table-column prop="mn006" label="岗位" align="center" v-if="columns.showColumn('mn006')"/>
      <el-table-column prop="mn007" label="等级" align="center" v-if="columns.showColumn('mn007')"/>
      <el-table-column prop="mn008" label="职务" align="center" v-if="columns.showColumn('mn008')"/>
      <el-table-column prop="mn009" label="聘用形式" align="center" v-if="columns.showColumn('mn009')">
        <template #default="scope">
          <dict-tag :options=" options.sys_employ_term " :value="scope.row.mn009"  />
        </template>
      </el-table-column>
      <el-table-column prop="mn010" label="入职日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mn010')"/>
      <el-table-column prop="mn011" label="在职状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mn011')"/>
      <el-table-column prop="mn012" label="试用期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mn012')"/>
      <el-table-column prop="mn013" label="试用工资" align="center" v-if="columns.showColumn('mn013')"/>
      <el-table-column prop="mn014" label="合同期限" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mn014')"/>
      <el-table-column prop="mn015" label="转正工资" align="center" v-if="columns.showColumn('mn015')"/>
      <el-table-column prop="mn016" label="转正日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mn016')"/>
      <el-table-column prop="mn017" label="合同终止日" :show-overflow-tooltip="true"  v-if="columns.showColumn('mn017')"/>
      <el-table-column prop="mn018" label="合同起始日" :show-overflow-tooltip="true"  v-if="columns.showColumn('mn018')"/>
      <el-table-column prop="isDeleted" label="软删除" align="center" v-if="columns.showColumn('isDeleted')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehrrecruitment:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehrrecruitment:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改招聘对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="招聘日期" prop="mn002">
              <el-date-picker v-model="form.mn002" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="姓名" prop="mn003">
              <el-input   v-model="form.mn003" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="部门" prop="mn004">
              <el-select filterable clearable   v-model="form.mn004"  :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="职称" prop="mn005">
              <el-input-number v-model.number="form.mn005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'职称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="岗位" prop="mn006">
              <el-input-number v-model.number="form.mn006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'岗位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="等级" prop="mn007">
              <el-input-number v-model.number="form.mn007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'等级'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="职务" prop="mn008">
              <el-input-number v-model.number="form.mn008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'职务'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="聘用形式" prop="mn009">
              <el-select filterable clearable   v-model="form.mn009"  :placeholder="$t('btn.selectPrefix')+'聘用形式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_employ_term" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="入职日期" prop="mn010">
              <el-date-picker v-model="form.mn010" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="在职状态" prop="mn011">
              <el-input   v-model="form.mn011" :placeholder="$t('btn.enterPrefix')+'在职状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="试用期" prop="mn012">
              <el-input   v-model="form.mn012" :placeholder="$t('btn.enterPrefix')+'试用期'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="试用工资" prop="mn013">
              <el-input-number v-model.number="form.mn013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'试用工资'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同期限" prop="mn014">
              <el-input   v-model="form.mn014" :placeholder="$t('btn.enterPrefix')+'合同期限'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转正工资" prop="mn015">
              <el-input-number v-model.number="form.mn015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'转正工资'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转正日期" prop="mn016">
              <el-date-picker v-model="form.mn016" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同终止日" prop="mn017">
              <el-date-picker v-model="form.mn017" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同起始日" prop="mn018">
              <el-date-picker v-model="form.mn018" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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


      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="routineehrrecruitment">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrRecruitment,
 addRoutineEhrRecruitment, delRoutineEhrRecruitment, 
 updateRoutineEhrRecruitment,getRoutineEhrRecruitment, 
 } 
from '@/api/routine/routineehrrecruitment.js'
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
  sort: 'Mn002',
  sortType: 'desc',
  //是否查询（1是）
  mn002: undefined,
  //是否查询（1是）
  mn003: undefined,
  //是否查询（1是）
  mn004: undefined,
  //是否查询（1是）
  mn009: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mn002', label: '招聘日期' },
  { visible: true, prop: 'mn003', label: '姓名' },
  { visible: true, prop: 'mn004', label: '部门' },
  { visible: true, prop: 'mn005', label: '职称' },
  { visible: true, prop: 'mn006', label: '岗位' },
  { visible: true, prop: 'mn007', label: '等级' },
  { visible: true, prop: 'mn008', label: '职务' },
  { visible: false, prop: 'mn009', label: '聘用形式' },
  { visible: false, prop: 'mn010', label: '入职日期' },
  { visible: false, prop: 'mn011', label: '在职状态' },
  { visible: false, prop: 'mn012', label: '试用期' },
  { visible: false, prop: 'mn013', label: '试用工资' },
  { visible: false, prop: 'mn014', label: '合同期限' },
  { visible: false, prop: 'mn015', label: '转正工资' },
  { visible: false, prop: 'mn016', label: '转正日期' },
  { visible: false, prop: 'mn017', label: '合同终止日' },
  { visible: false, prop: 'mn018', label: '合同起始日' },
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
// 招聘日期时间范围
const dateRangeMn002 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_dept_list" },
  { dictType: "sys_employ_term" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从招聘/routine_ehr_recruitment表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMn002.value, 'Mn002');
  loading.value = true
  listRoutineEhrRecruitment(queryParams).then(res => {
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
  // 招聘日期时间范围
  dateRangeMn002.value = []
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
    mn002: [{ required: true, message: "招聘日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mn003: [{ required: true, message: "姓名"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mn004: [{ required: true, message: "部门"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    mn005: [{ required: true, message: "职称"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mn006: [{ required: true, message: "岗位"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mn007: [{ required: true, message: "等级"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mn008: [{ required: true, message: "职务"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mn013: [{ required: true, message: "试用工资"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mn015: [{ required: true, message: "转正工资"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // 聘用形式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_employ_term: [],
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
    mn002: null,
    mn003: null,
    mn004: [],
    mn005: 0,
    mn006: 0,
    mn007: 0,
    mn008: 0,
    mn009: [],
    mn010: null,
    mn011: null,
    mn012: null,
    mn013: 0,
    mn014: null,
    mn015: 0,
    mn016: null,
    mn017: null,
    mn018: null,
    isDeleted: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'招聘'
  opertype.value = 1
  form.value.mn002= new Date()
  form.value.mn004= 0
  form.value.mn005= 0
  form.value.mn006= 0
  form.value.mn007= 0
  form.value.mn008= 0
  form.value.mn009= []
  form.value.mn010= new Date()
  form.value.mn013= 0
  form.value.mn015= 0
  form.value.mn016= new Date()
  form.value.mn017= new Date()
  form.value.mn018= new Date()
  form.value.isDeleted= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getRoutineEhrRecruitment(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '招聘'
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
        updateRoutineEhrRecruitment(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addRoutineEhrRecruitment(form.value).then((res) => {
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
      return delRoutineEhrRecruitment(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<招聘.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/RoutineEhrRecruitment/export', { ...queryParams })
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