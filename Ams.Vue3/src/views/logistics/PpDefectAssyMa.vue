<!--
 * @Descripttion: 不良/pp_defect_assy_ma
 * @Version: 0.24.682.31110
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/11/12 17:19:09
 * @column：33
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="生产订单" prop="mea002">
        <el-select-v2 filterable clearable  v-model="queryParams.mea002" 
              :options="options.sql_moc_oph.map(item =>({label: item.dictLabel, value: item.dictValue}))" 
              :placeholder="$t('btn.selectSearchPrefix')+'生产订单'+$t('btn.selectSearchSuffix')">
        </el-select-v2>
      </el-form-item>
      <el-form-item label="生产批次" prop="mea004">
        <el-input v-model="queryParams.mea004" :placeholder="$t('btn.enterSearchPrefix')+'生产批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产机种" prop="mea005">
        <el-input v-model="queryParams.mea005" :placeholder="$t('btn.enterSearchPrefix')+'生产机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产日期">
        <el-date-picker
          v-model="dateRangeMea006" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产班组" prop="mea007">
        <el-input v-model="queryParams.mea007" :placeholder="$t('btn.enterSearchPrefix')+'生产班组'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['pp:defectassyma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:defectassyma:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:defectassyma:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:defectassyma:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpDefectAssyMa/importTemplate"
                  importUrl="/Logistics/PpDefectAssyMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:defectassyma:export']">
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
      <el-table-column prop="mea002" label="生产订单" align="center" v-if="columns.showColumn('mea002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_oph " :value="scope.row.mea002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mea003" label="订单数量" align="center" v-if="columns.showColumn('mea003')"/>
      <el-table-column prop="mea004" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mea004')"/>
      <el-table-column prop="mea005" label="生产机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mea005')"/>
      <el-table-column prop="mea006" label="生产日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mea006')"/>
      <el-table-column prop="mea007" label="生产班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mea007')"/>
      <el-table-column prop="mea008" label="生产实绩" align="center" v-if="columns.showColumn('mea008')"/>
      <el-table-column prop="mea009" label="无不良数" align="center" v-if="columns.showColumn('mea009')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:defectassyma:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:defectassyma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppDefectAssySlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID"/>
        <el-table-column prop="parentId" label="父ID"/>
        <el-table-column prop="mfa003" label="不良类别">
          <template #default="scope">
            <dict-tag :options=" options.sql_bad_dist " :value="scope.row.mfa003"  />
          </template>
        </el-table-column>
        <el-table-column prop="mfa004" label="不良数量"/>
        <el-table-column prop="mfa005" label="不良总数"/>
        <el-table-column prop="mfa006" label="不良状况"/>
        <el-table-column prop="mfa007" label="不良个所"/>
        <el-table-column prop="mfa008" label="不良原因"/>
        <el-table-column prop="remark" label="备注"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改不良对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="生产订单" prop="mea002">
              <el-select-v2 filterable clearable   v-model="form.mea002"  :placeholder="$t('btn.selectPrefix')+'生产订单'+$t('btn.selectSuffix')"
		:options="options.sql_moc_oph.map(item =>({label: item.dictLabel, value: item.dictValue}))">
              </el-select-v2>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="订单数量" prop="mea003">
              <el-input-number v-model.number="form.mea003" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'订单数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="mea004">
              <el-input   v-model="form.mea004" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产机种" prop="mea005">
              <el-input   v-model="form.mea005" :placeholder="$t('btn.enterPrefix')+'生产机种'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="mea006">
              <el-date-picker v-model="form.mea006" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班组" prop="mea007">
              <el-input   v-model="form.mea007" :placeholder="$t('btn.enterPrefix')+'生产班组'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="生产实绩" prop="mea008">
              <el-input-number v-model.number="form.mea008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'生产实绩'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="无不良数" prop="mea009">
              <el-input-number v-model.number="form.mea009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'无不良数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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
        <el-divider content-position="center">不良明细</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpDefectAssySlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpDefectAssySlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppDefectAssySlvList" :row-class-name="rowPpDefectAssySlvIndex" @selection-change="handlePpDefectAssySlvSelectionChange" ref="PpDefectAssySlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="不良类别" prop="mfa003">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mfa003" :placeholder="$t('btn.enterPrefix')+'不良类别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_bad_dist" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="不良数量" align="center" prop="mfa004" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mfa004" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良总数" align="center" prop="mfa005" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mfa005" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良总数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良状况" align="center" prop="mfa006">
            <template #default="scope">
              <el-input v-model="scope.row.mfa006" :placeholder="$t('btn.enterPrefix')+'不良状况'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良个所" align="center" prop="mfa007">
            <template #default="scope">
              <el-input v-model="scope.row.mfa007" :placeholder="$t('btn.enterPrefix')+'不良个所'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良原因" align="center" prop="mfa008">
            <template #default="scope">
              <el-input v-model="scope.row.mfa008" :placeholder="$t('btn.enterPrefix')+'不良原因'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
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

<script setup name="ppdefectassyma">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpDefectAssyMa,
 addPpDefectAssyMa, delPpDefectAssyMa, 
 updatePpDefectAssyMa,getPpDefectAssyMa, 
 } 
from '@/api/logistics/ppdefectassyma.js'
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
  sort: 'Mea006',
  sortType: 'desc',
  //生产订单,是否查询（1是）
  mea002: undefined,
  //生产批次,是否查询（1是）
  mea004: undefined,
  //生产机种,是否查询（1是）
  mea005: undefined,
  //生产日期,是否查询（1是）
  mea006: undefined,
  //生产班组,是否查询（1是）
  mea007: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mea002', label: '生产订单' },
  { visible: true, prop: 'mea003', label: '订单数量' },
  { visible: true, prop: 'mea004', label: '生产批次' },
  { visible: true, prop: 'mea005', label: '生产机种' },
  { visible: true, prop: 'mea006', label: '生产日期' },
  { visible: true, prop: 'mea007', label: '生产班组' },
  { visible: true, prop: 'mea008', label: '生产实绩' },
  { visible: false, prop: 'mea009', label: '无不良数' },
  { visible: false, prop: 'remark', label: '备注' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
// 生产日期时间范围
const dateRangeMea006 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_moc_oph" },
  { dictType: "sql_bad_dist" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从不良/pp_defect_assy_ma表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMea006.value, 'Mea006');
  loading.value = true
  listPpDefectAssyMa(queryParams).then(res => {
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
  // 生产日期时间范围
  dateRangeMea006.value = []
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
    mea002: [{ required: true, message: "生产订单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mea003: [{ required: true, message: "订单数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mea008: [{ required: true, message: "生产实绩"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mea009: [{ required: true, message: "无不良数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 生产订单 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_moc_oph: [],
    // 不良类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_bad_dist: [],
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
    mea002: [],
    mea003: 0,
    mea004: null,
    mea005: null,
    mea006: null,
    mea007: null,
    mea008: 0,
    mea009: 0,
    remark: null,
  };
  ppDefectAssySlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'不良'
  opertype.value = 1
  form.value.mea002= []
  form.value.mea003= 0
  form.value.mea006= new Date()
  form.value.mea008= 0
  form.value.mea009= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpDefectAssyMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '不良'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppDefectAssySlvList.value = res.data.ppDefectAssySlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppDefectAssySlvNav = ppDefectAssySlvList.value
      if (form.value.id != undefined && opertype.value === 2) {
        updatePpDefectAssyMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpDefectAssyMa(form.value).then((res) => {
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
      return delPpDefectAssyMa(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<不良.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpDefectAssyMa/export', { ...queryParams })
    })
}

/*********************不良明细子表信息*************************/
const ppDefectAssySlvList = ref([])
const checkedPpDefectAssySlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 不良明细序号 */
function rowPpDefectAssySlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 不良明细添加按钮操作 */
function handleAddPpDefectAssySlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.mfa003 = null;
  //obj.mfa004 = null;
  //obj.mfa005 = null;
  //obj.mfa006 = null;
  //obj.mfa007 = null;
  //obj.mfa008 = null;
  //obj.remark = null;
  ppDefectAssySlvList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpDefectAssySlvSelectionChange(selection) {
  checkedPpDefectAssySlv.value = selection.map(item => item.index)
}

/** 不良明细删除按钮操作 */
function handleDeletePpDefectAssySlv() {
  if(checkedPpDefectAssySlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的不良明细数据')
  } else {
    const PpDefectAssySlvs = ppDefectAssySlvList.value;
    const checkedPpDefectAssySlvs = checkedPpDefectAssySlv.value;
    ppDefectAssySlvList.value = PpDefectAssySlvs.filter(function(item) {
      return checkedPpDefectAssySlvs.indexOf(item.index) == -1
    });
  }
}

/** 不良明细详情 */
function rowClick(row) {
  const id = row.id || ids.value
  getPpDefectAssyMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppDefectAssySlvList.value = data.ppDefectAssySlvNav
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