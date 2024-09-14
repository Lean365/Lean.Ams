<!--
 * @Descripttion: 利润中心/fico_profit_center
 * @Version: 0.24.614.28099
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 15:42:56
 * @column：41
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="利润中心" prop="mq003">
        <el-input v-model="queryParams.mq003" :placeholder="$t('btn.enterSearchPrefix')+'利润中心'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="控制范围" prop="mq004">
        <el-select filterable clearable   v-model="queryParams.mq004" :placeholder="$t('btn.selectSearchPrefix')+'控制范围'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="名称" prop="mq010">
        <el-input v-model="queryParams.mq010" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['fico:profitcenter:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:profitcenter:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:profitcenter:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:profitcenter:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoProfitCenter/importTemplate"
                  importUrl="/Accounting/FicoProfitCenter/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:profitcenter:export']">
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
      <el-table-column prop="mq002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq002')"/>
      <el-table-column prop="mq003" label="利润中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq003')"/>
      <el-table-column prop="mq004" label="控制范围" align="center" v-if="columns.showColumn('mq004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mq004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mq005" label="开始生效日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mq005')"/>
      <el-table-column prop="mq006" label="有效截至日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mq006')"/>
      <el-table-column prop="mq007" label="部门" align="center" v-if="columns.showColumn('mq007')"/>
      <el-table-column prop="mq008" label="负责人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq008')"/>
      <el-table-column prop="mq009" label="货币" align="center" v-if="columns.showColumn('mq009')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.mq009"  />
        </template>
      </el-table-column>
      <el-table-column prop="mq010" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq010')"/>
      <el-table-column prop="mq011" label="长文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq011')"/>
      <el-table-column prop="mq012" label="利润中心说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq012')"/>
      <el-table-column prop="mq013" label="利润中心组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq013')"/>
      <el-table-column prop="mq014" label="权益类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq014')"/>
      <el-table-column prop="mq015" label="地区税务代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mq015')"/>
      <el-table-column prop="mq016" label="锁定标记" align="center" v-if="columns.showColumn('mq016')">
        <template #default="scope">
          <dict-tag :options=" options.sys_locked_flag " :value="scope.row.mq016"  />
        </template>
      </el-table-column>
      <el-table-column prop="mq017" label="状态" align="center" v-if="columns.showColumn('mq017')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.mq017"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:profitcenter:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:profitcenter:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改利润中心对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="mq002">
              <el-input v-model="form.mq002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="mq003">
              <el-input v-model="form.mq003" :placeholder="$t('btn.enterPrefix')+'利润中心'+$t('btn.enterSuffix')"  show-word-limit maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="控制范围" prop="mq004">
              <el-select filterable clearable   v-model="form.mq004"  :placeholder="$t('btn.selectPrefix')+'控制范围'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="开始生效日期" prop="mq005">
              <el-date-picker v-model="form.mq005" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效截至日期" prop="mq006">
              <el-date-picker v-model="form.mq006" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="部门" prop="mq007">
              <el-input-number v-model.number="form.mq007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'部门'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="负责人" prop="mq008">
              <el-input v-model="form.mq008" :placeholder="$t('btn.enterPrefix')+'负责人'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="货币" prop="mq009">
              <el-select filterable clearable   v-model="form.mq009"  :placeholder="$t('btn.selectPrefix')+'货币'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="名称" prop="mq010">
              <el-input v-model="form.mq010" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="长文本" prop="mq011">
              <el-input v-model="form.mq011" :placeholder="$t('btn.enterPrefix')+'长文本'+$t('btn.enterSuffix')"  show-word-limit maxlength="80"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心说明" prop="mq012">
              <el-input v-model="form.mq012" :placeholder="$t('btn.enterPrefix')+'利润中心说明'+$t('btn.enterSuffix')"  show-word-limit maxlength="120"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心组" prop="mq013">
              <el-input v-model="form.mq013" :placeholder="$t('btn.enterPrefix')+'利润中心组'+$t('btn.enterSuffix')"  show-word-limit maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="权益类型" prop="mq014">
              <el-input v-model="form.mq014" :placeholder="$t('btn.enterPrefix')+'权益类型'+$t('btn.enterSuffix')"  show-word-limit maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地区税务代码" prop="mq015">
              <el-input v-model="form.mq015" :placeholder="$t('btn.enterPrefix')+'地区税务代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="15"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="锁定标记" prop="mq016">
              <el-select filterable clearable   v-model="form.mq016"  :placeholder="$t('btn.selectPrefix')+'锁定标记'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_locked_flag" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="状态" prop="mq017">
              <el-select filterable clearable   v-model="form.mq017"  :placeholder="$t('btn.selectPrefix')+'状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_is_status" 
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

<script setup name="ficoprofitcenter">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoProfitCenter,
 addFicoProfitCenter, delFicoProfitCenter, 
 updateFicoProfitCenter,getFicoProfitCenter, 
 } 
from '@/api/accounting/ficoprofitcenter.js'
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
  sort: 'Mq003',
  sortType: 'asc',
  //是否查询（1是）
  mq003: undefined,
  //是否查询（1是）
  mq004: undefined,
  //是否查询（1是）
  mq010: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mq002', label: '集团' },
  { visible: true, prop: 'mq003', label: '利润中心' },
  { visible: true, prop: 'mq004', label: '控制范围' },
  { visible: true, prop: 'mq005', label: '开始生效日期' },
  { visible: true, prop: 'mq006', label: '有效截至日期' },
  { visible: true, prop: 'mq007', label: '部门' },
  { visible: true, prop: 'mq008', label: '负责人' },
  { visible: false, prop: 'mq009', label: '货币' },
  { visible: false, prop: 'mq010', label: '名称' },
  { visible: false, prop: 'mq011', label: '长文本' },
  { visible: false, prop: 'mq012', label: '利润中心说明' },
  { visible: false, prop: 'mq013', label: '利润中心组' },
  { visible: false, prop: 'mq014', label: '权益类型' },
  { visible: false, prop: 'mq015', label: '地区税务代码' },
  { visible: false, prop: 'mq016', label: '锁定标记' },
  { visible: false, prop: 'mq017', label: '状态' },
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
  { dictType: "sql_corp_list" },
  { dictType: "sql_global_currency" },
  { dictType: "sys_locked_flag" },
  { dictType: "sys_is_status" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从利润中心/fico_profit_center表记录数据
function getList(){
  loading.value = true
  listFicoProfitCenter(queryParams).then(res => {
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
    id: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    mq003: [{ required: true, message: "利润中心"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mq010: [{ required: true, message: "名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 控制范围 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
    // 货币 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_currency: [],
    // 锁定标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_locked_flag: [],
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_status: [],
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
    mq002: null,
    mq003: null,
    mq004: [],
    mq005: null,
    mq006: null,
    mq007: 0,
    mq008: null,
    mq009: [],
    mq010: null,
    mq011: null,
    mq012: null,
    mq013: null,
    mq014: null,
    mq015: null,
    mq016: [],
    mq017: [],
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'利润中心'
  opertype.value = 1
  form.value.mq004= []
  form.value.mq005= new Date()
  form.value.mq006= new Date()
  form.value.mq007= 0
  form.value.mq009= []
  form.value.mq016= 0
  form.value.mq017= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoProfitCenter(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '利润中心'
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
        updateFicoProfitCenter(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoProfitCenter(form.value).then((res) => {
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
      return delFicoProfitCenter(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<利润中心.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoProfitCenter/export', { ...queryParams })
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