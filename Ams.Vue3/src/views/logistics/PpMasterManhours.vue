<!--
 * @Descripttion: 标准工时/pp_master_manhours
 * @Version: 0.24.620.21805
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 13:31:00
 * @column：37
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="mb002">
        <el-select filterable clearable   v-model="queryParams.mb002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="mb003">
        <el-input v-model="queryParams.mb003" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种名" prop="mb004">
        <el-input v-model="queryParams.mb004" :placeholder="$t('btn.enterSearchPrefix')+'机种名'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料描述" prop="mb006">
        <el-input v-model="queryParams.mb006" :placeholder="$t('btn.enterSearchPrefix')+'物料描述'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="工作中心" prop="mb007">
        <el-select filterable clearable   v-model="queryParams.mb007" :placeholder="$t('btn.selectSearchPrefix')+'工作中心'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_work_center " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生效日期">
        <el-date-picker
          v-model="dateRangeMb013" 
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
        <el-button class="btn-add" v-hasPermi="['pp:mastermanhours:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:mastermanhours:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:mastermanhours:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:mastermanhours:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpMasterManhours/importTemplate"
                  importUrl="/Logistics/PpMasterManhours/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:mastermanhours:export']">
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
      <el-table-column prop="mb002" label="工厂" align="center" v-if="columns.showColumn('mb002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mb002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb003" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb003')"/>
      <el-table-column prop="mb004" label="机种名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb004')"/>
      <el-table-column prop="mb005" label="仕向别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb005')"/>
      <el-table-column prop="mb006" label="物料描述" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb006')"/>
      <el-table-column prop="mb007" label="工作中心" align="center" v-if="columns.showColumn('mb007')">
        <template #default="scope">
          <dict-tag :options=" options.sys_work_center " :value="scope.row.mb007"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb008" label="标准点数" align="center" v-if="columns.showColumn('mb008')"/>
      <el-table-column prop="mb009" label="Short单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb009')"/>
      <el-table-column prop="mb010" label="点数换算汇率" align="center" v-if="columns.showColumn('mb010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_short_convert " :value="scope.row.mb010"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb011" label="标准工时" align="center" v-if="columns.showColumn('mb011')"/>
      <el-table-column prop="mb012" label="工时单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb012')"/>
      <el-table-column prop="mb013" label="生效日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mb013')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:mastermanhours:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:mastermanhours:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改标准工时对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂" prop="mb002">
              <el-select filterable clearable   v-model="form.mb002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料" prop="mb003">
              <el-input   v-model="form.mb003" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种名" prop="mb004">
              <el-input   v-model="form.mb004" :placeholder="$t('btn.enterPrefix')+'机种名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仕向别" prop="mb005">
              <el-input   v-model="form.mb005" :placeholder="$t('btn.enterPrefix')+'仕向别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料描述" prop="mb006">
              <el-input   v-model="form.mb006" :placeholder="$t('btn.enterPrefix')+'物料描述'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工作中心" prop="mb007">
              <el-select filterable clearable   v-model="form.mb007"  :placeholder="$t('btn.selectPrefix')+'工作中心'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_work_center" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="标准点数" prop="mb008">
              <el-input-number v-model.number="form.mb008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'标准点数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Short单位" prop="mb009">
              <el-input   v-model="form.mb009" :placeholder="$t('btn.enterPrefix')+'Short单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="点数换算汇率" prop="mb010">
              <el-select filterable clearable   v-model="form.mb010"  :placeholder="$t('btn.selectPrefix')+'点数换算汇率'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_short_convert" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="标准工时" prop="mb011">
              <el-input-number v-model.number="form.mb011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'标准工时'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工时单位" prop="mb012">
              <el-input   v-model="form.mb012" :placeholder="$t('btn.enterPrefix')+'工时单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生效日期" prop="mb013">
              <el-date-picker v-model="form.mb013" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ppmastermanhours">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpMasterManhours,
 addPpMasterManhours, delPpMasterManhours, 
 updatePpMasterManhours,getPpMasterManhours, 
 } 
from '@/api/logistics/ppmastermanhours.js'
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
  sort: 'Mb003',
  sortType: 'asc',
  //是否查询（1是）
  mb002: undefined,
  //是否查询（1是）
  mb003: undefined,
  //是否查询（1是）
  mb004: undefined,
  //是否查询（1是）
  mb006: undefined,
  //是否查询（1是）
  mb007: undefined,
  //是否查询（1是）
  mb013: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mb002', label: '工厂' },
  { visible: true, prop: 'mb003', label: '物料' },
  { visible: true, prop: 'mb004', label: '机种名' },
  { visible: true, prop: 'mb005', label: '仕向别' },
  { visible: true, prop: 'mb006', label: '物料描述' },
  { visible: true, prop: 'mb007', label: '工作中心' },
  { visible: true, prop: 'mb008', label: '标准点数' },
  { visible: false, prop: 'mb009', label: 'Short单位' },
  { visible: false, prop: 'mb010', label: '点数换算汇率' },
  { visible: false, prop: 'mb011', label: '标准工时' },
  { visible: false, prop: 'mb012', label: '工时单位' },
  { visible: false, prop: 'mb013', label: '生效日期' },
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
// 生效日期时间范围
const dateRangeMb013 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sys_work_center" },
  { dictType: "sys_short_convert" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从标准工时/pp_master_manhours表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMb013.value, 'Mb013');
  loading.value = true
  listPpMasterManhours(queryParams).then(res => {
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
  // 生效日期时间范围
  dateRangeMb013.value = []
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
    mb002: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb003: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb008: [{ required: true, message: "标准点数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb010: [{ required: true, message: "点数换算汇率"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb011: [{ required: true, message: "标准工时"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 工作中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_work_center: [],
    // 点数换算汇率 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_short_convert: [],
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
    mb002: [],
    mb003: null,
    mb004: null,
    mb005: null,
    mb006: null,
    mb007: [],
    mb008: 0,
    mb009: null,
    mb010: [],
    mb011: 0,
    mb012: null,
    mb013: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'标准工时'
  opertype.value = 1
  form.value.mb002= []
  form.value.mb007= []
  form.value.mb008= 0
  form.value.mb010= 0
  form.value.mb011= 0
  form.value.mb013= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpMasterManhours(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '标准工时'
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
        updatePpMasterManhours(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpMasterManhours(form.value).then((res) => {
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
      return delPpMasterManhours(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<标准工时.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpMasterManhours/export', { ...queryParams })
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