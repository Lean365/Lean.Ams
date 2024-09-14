<!--
 * @Descripttion: 生产工单/pp_master_prodorder
 * @Version: 0.24.620.21354
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 12:05:47
 * @column：36
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="生产工厂" prop="mc002">
        <el-select filterable clearable   v-model="queryParams.mc002" :placeholder="$t('btn.selectSearchPrefix')+'生产工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="订单类型" prop="mc003">
        <el-select filterable clearable   v-model="queryParams.mc003" :placeholder="$t('btn.selectSearchPrefix')+'订单类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_mo_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="订单号码" prop="mc004">
        <el-input v-model="queryParams.mc004" :placeholder="$t('btn.enterSearchPrefix')+'订单号码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="mc005">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_moc_marb" :loading="loading" v-model="queryParams.mc005" :placeholder="$t('btn.selectSearchPrefix')+'物料'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_moc_marb " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="状态" prop="mc012">
        <el-select filterable clearable   v-model="queryParams.mc012" :placeholder="$t('btn.selectSearchPrefix')+'状态'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_comp_status " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:masterprodorder:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:masterprodorder:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:masterprodorder:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:masterprodorder:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpMasterProdorder/importTemplate"
                  importUrl="/Logistics/PpMasterProdorder/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:masterprodorder:export']">
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
      <el-table-column prop="mc002" label="生产工厂" align="center" v-if="columns.showColumn('mc002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mc002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc003" label="订单类型" align="center" v-if="columns.showColumn('mc003')">
        <template #default="scope">
          <dict-tag :options=" options.sys_mo_type " :value="scope.row.mc003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc004" label="订单号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc004')"/>
      <el-table-column prop="mc005" label="物料" align="center" v-if="columns.showColumn('mc005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_marb " :value="scope.row.mc005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc006" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc006')"/>
      <el-table-column prop="mc007" label="工单数量" align="center" v-if="columns.showColumn('mc007')"/>
      <el-table-column prop="mc008" label="生产数量" align="center" v-if="columns.showColumn('mc008')"/>
      <el-table-column prop="mc009" label="订单日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc009')"/>
      <el-table-column prop="mc010" label="工艺路线" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc010')"/>
      <el-table-column prop="mc011" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc011')"/>
      <el-table-column prop="mc012" label="状态" align="center" v-if="columns.showColumn('mc012')">
        <template #default="scope">
          <dict-tag :options=" options.sql_comp_status " :value="scope.row.mc012"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:masterprodorder:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:masterprodorder:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改生产工单对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="生产工厂" prop="mc002">
              <el-select filterable clearable   v-model="form.mc002"  :placeholder="$t('btn.selectPrefix')+'生产工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="订单类型" prop="mc003">
              <el-select filterable clearable   v-model="form.mc003"  :placeholder="$t('btn.selectPrefix')+'订单类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_mo_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="订单号码" prop="mc004">
              <el-input   v-model="form.mc004" :placeholder="$t('btn.enterPrefix')+'订单号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="7"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mc005">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_moc_marb" 
              :loading="loading" v-model="form.mc005"  :placeholder="$t('btn.selectPrefix')+'物料'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_moc_marb" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="生产批次" prop="mc006">
              <el-input   v-model="form.mc006" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单数量" prop="mc007">
              <el-input-number v-model.number="form.mc007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工单数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产数量" prop="mc008">
              <el-input-number v-model.number="form.mc008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'生产数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单日期" prop="mc009">
              <el-date-picker v-model="form.mc009" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工艺路线" prop="mc010">
              <el-input   v-model="form.mc010" :placeholder="$t('btn.enterPrefix')+'工艺路线'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="mc011">
              <el-input   v-model="form.mc011" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="状态" prop="mc012">
              <el-select filterable clearable   v-model="form.mc012"  :placeholder="$t('btn.selectPrefix')+'状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_comp_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
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

<script setup name="ppmasterprodorder">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpMasterProdorder,
 addPpMasterProdorder, delPpMasterProdorder, 
 updatePpMasterProdorder,getPpMasterProdorder, 
 } 
from '@/api/logistics/ppmasterprodorder.js'
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
  sort: 'Mc004',
  sortType: 'asc',
  //是否查询（1是）
  mc002: undefined,
  //是否查询（1是）
  mc003: undefined,
  //是否查询（1是）
  mc004: undefined,
  //是否查询（1是）
  mc005: undefined,
  //是否查询（1是）
  mc012: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mc002', label: '生产工厂' },
  { visible: true, prop: 'mc003', label: '订单类型' },
  { visible: true, prop: 'mc004', label: '订单号码' },
  { visible: true, prop: 'mc005', label: '物料' },
  { visible: true, prop: 'mc006', label: '生产批次' },
  { visible: true, prop: 'mc007', label: '工单数量' },
  { visible: true, prop: 'mc008', label: '生产数量' },
  { visible: false, prop: 'mc009', label: '订单日期' },
  { visible: false, prop: 'mc010', label: '工艺路线' },
  { visible: false, prop: 'mc011', label: '序列号' },
  { visible: false, prop: 'mc012', label: '状态' },
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
//定义远程搜索变量
const remotequeryList_sql_moc_marb=ref([])
//定义远程搜索变量
const remotequery_sql_moc_marb=ref([])
//远程字典参数
var remotedictParams_sql_moc_marb = [
    { dictType: "sql_moc_marb" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_moc_marb).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_moc_marb.value = element.list
      })
      //console.log(remotequeryList_sql_moc_marb)
    })
  })
//远程搜索
const remoteMethod_sql_moc_marb = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_moc_marb.value = remotequeryList_sql_moc_marb.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_moc_marb(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_moc_marb.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_moc_marb = debounce((query) => {
    let arr = remotequeryList_sql_moc_marb.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_moc_marb.value = arr.slice(0, 5)
      addFilterOptions_sql_moc_marb(query)
    } else {
      remotequery_sql_moc_marb.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_moc_marb =debounce((dictValue) => {
    let target = remotequeryList_sql_moc_marb.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_moc_marb.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_moc_marb.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sys_mo_type" },
  { dictType: "sql_moc_marb" },
  { dictType: "sql_comp_status" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从生产工单/pp_master_prodorder表记录数据
function getList(){
  loading.value = true
  listPpMasterProdorder(queryParams).then(res => {
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
    mc002: [{ required: true, message: "生产工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mc003: [{ required: true, message: "订单类型"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mc012: [{ required: true, message: "状态"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
  },
//字典名称
  options: {
    // 生产工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 订单类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_mo_type: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_moc_marb: [],
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_comp_status: [],
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
    mc002: [],
    mc003: [],
    mc004: null,
    mc005: [],
    mc006: null,
    mc007: 0,
    mc008: 0,
    mc009: null,
    mc010: null,
    mc011: null,
    mc012: [],
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'生产工单'
  opertype.value = 1
  form.value.mc002= []
  form.value.mc003= []
  form.value.mc005= []
  form.value.mc007= 0
  form.value.mc008= 0
  form.value.mc009= new Date()
  form.value.mc012= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpMasterProdorder(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '生产工单'
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
        updatePpMasterProdorder(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpMasterProdorder(form.value).then((res) => {
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
      return delPpMasterProdorder(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<生产工单.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpMasterProdorder/export', { ...queryParams })
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