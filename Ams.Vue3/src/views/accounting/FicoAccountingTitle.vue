<!--
 * @Descripttion: 会计科目/fico_accounting_title
 * @Version: 0.24.614.30042
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 16:53:13
 * @column：39
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="公司代码" prop="mb003">
        <el-select filterable clearable   v-model="queryParams.mb003" :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="mb004">
        <el-select filterable clearable   v-model="queryParams.mb004" :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目编号" prop="mb006">
        <el-input v-model="queryParams.mb006" :placeholder="$t('btn.enterSearchPrefix')+'科目编号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="短文本" prop="mb011">
        <el-input v-model="queryParams.mb011" :placeholder="$t('btn.enterSearchPrefix')+'短文本'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['fico:accountingtitle:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:accountingtitle:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:accountingtitle:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:accountingtitle:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoAccountingTitle/importTemplate"
                  importUrl="/Accounting/FicoAccountingTitle/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:accountingtitle:export']">
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
      <el-table-column prop="mb002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb002')"/>
      <el-table-column prop="mb003" label="公司代码" align="center" v-if="columns.showColumn('mb003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mb003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb004" label="币种" align="center" v-if="columns.showColumn('mb004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.mb004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb005" label="语言Key" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb005')"/>
      <el-table-column prop="mb006" label="科目编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb006')"/>
      <el-table-column prop="mb007" label="科目表" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb007')"/>
      <el-table-column prop="mb008" label="BS类别" align="center" v-if="columns.showColumn('mb008')">
        <template #default="scope">
          <dict-tag :options=" options.sys_bs_type " :value="scope.row.mb008"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb009" label="PL类别" align="center" v-if="columns.showColumn('mb009')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pl_type " :value="scope.row.mb009"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb010" label="统驭类别" align="center" v-if="columns.showColumn('mb010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_conrol_title " :value="scope.row.mb010"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb011" label="短文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb011')"/>
      <el-table-column prop="mb012" label="长文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb012')"/>
      <el-table-column prop="mb013" label="附加文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb013')"/>
      <el-table-column prop="mb014" label="科目组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb014')"/>
      <el-table-column prop="mb015" label="冻结" align="center" v-if="columns.showColumn('mb015')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.mb015"  />
        </template>
      </el-table-column>
      <el-table-column prop="isDeleted" label="软删除" align="center" v-if="columns.showColumn('isDeleted')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_deleted " :value="scope.row.isDeleted"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:accountingtitle:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:accountingtitle:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改会计科目对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="mb002">
              <el-input   v-model="form.mb002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司代码" prop="mb003">
              <el-select filterable clearable   v-model="form.mb003"  :placeholder="$t('btn.selectPrefix')+'公司代码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="币种" prop="mb004">
              <el-select filterable clearable   v-model="form.mb004"  :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="语言Key" prop="mb005">
              <el-input   v-model="form.mb005" :placeholder="$t('btn.enterPrefix')+'语言Key'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目编号" prop="mb006">
              <el-input   v-model="form.mb006" :placeholder="$t('btn.enterPrefix')+'科目编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目表" prop="mb007">
              <el-input   v-model="form.mb007" :placeholder="$t('btn.enterPrefix')+'科目表'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="BS类别" prop="mb008">
              <el-select filterable clearable   v-model="form.mb008"  :placeholder="$t('btn.selectPrefix')+'BS类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_bs_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="PL类别" prop="mb009">
              <el-select filterable clearable   v-model="form.mb009"  :placeholder="$t('btn.selectPrefix')+'PL类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pl_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="统驭类别" prop="mb010">
              <el-select filterable clearable   v-model="form.mb010"  :placeholder="$t('btn.selectPrefix')+'统驭类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_conrol_title" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="短文本" prop="mb011">
              <el-input   v-model="form.mb011" :placeholder="$t('btn.enterPrefix')+'短文本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="长文本" prop="mb012">
              <el-input   v-model="form.mb012" :placeholder="$t('btn.enterPrefix')+'长文本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="80"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="附加文本" prop="mb013">
              <el-input   v-model="form.mb013" :placeholder="$t('btn.enterPrefix')+'附加文本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="120"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目组" prop="mb014">
              <el-input   v-model="form.mb014" :placeholder="$t('btn.enterPrefix')+'科目组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="冻结" prop="mb015">
              <el-radio-group v-model="form.mb015">
                <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
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

<script setup name="ficoaccountingtitle">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoAccountingTitle,
 addFicoAccountingTitle, delFicoAccountingTitle, 
 updateFicoAccountingTitle,getFicoAccountingTitle, 
 } 
from '@/api/accounting/ficoaccountingtitle.js'
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
  mb003: undefined,
  //是否查询（1是）
  mb004: undefined,
  //是否查询（1是）
  mb006: undefined,
  //是否查询（1是）
  mb011: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mb002', label: '集团' },
  { visible: true, prop: 'mb003', label: '公司代码' },
  { visible: true, prop: 'mb004', label: '币种' },
  { visible: true, prop: 'mb005', label: '语言Key' },
  { visible: true, prop: 'mb006', label: '科目编号' },
  { visible: true, prop: 'mb007', label: '科目表' },
  { visible: true, prop: 'mb008', label: 'BS类别' },
  { visible: false, prop: 'mb009', label: 'PL类别' },
  { visible: false, prop: 'mb010', label: '统驭类别' },
  { visible: false, prop: 'mb011', label: '短文本' },
  { visible: false, prop: 'mb012', label: '长文本' },
  { visible: false, prop: 'mb013', label: '附加文本' },
  { visible: false, prop: 'mb014', label: '科目组' },
  { visible: false, prop: 'mb015', label: '冻结' },
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
  { dictType: "sql_corp_list" },
  { dictType: "sql_global_currency" },
  { dictType: "sys_bs_type" },
  { dictType: "sys_pl_type" },
  { dictType: "sys_conrol_title" },
  { dictType: "sys_freeze_flag" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从会计科目/fico_accounting_title表记录数据
function getList(){
  loading.value = true
  listFicoAccountingTitle(queryParams).then(res => {
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
    mb002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb003: [{ required: true, message: "公司代码"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb004: [{ required: true, message: "币种"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb006: [{ required: true, message: "科目编号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb015: [{ required: true, message: "冻结"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_currency: [],
    // BS类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_bs_type: [],
    // PL类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pl_type: [],
    // 统驭类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_conrol_title: [],
    // 冻结 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_freeze_flag: [],
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
    mb002: null,
    mb003: [],
    mb004: [],
    mb005: null,
    mb006: null,
    mb007: null,
    mb008: [],
    mb009: [],
    mb010: [],
    mb011: null,
    mb012: null,
    mb013: null,
    mb014: null,
    mb015: 0,
    isDeleted: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'会计科目'
  opertype.value = 1
  form.value.mb003= []
  form.value.mb004= []
  form.value.mb008= []
  form.value.mb009= []
  form.value.mb010= []
  form.value.mb015= 0
  form.value.isDeleted= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoAccountingTitle(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '会计科目'
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
        updateFicoAccountingTitle(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoAccountingTitle(form.value).then((res) => {
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
      return delFicoAccountingTitle(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<会计科目.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoAccountingTitle/export', { ...queryParams })
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