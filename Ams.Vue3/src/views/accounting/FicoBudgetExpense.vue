<!--
 * @Descripttion: 费用预算/fico_budget_expense
 * @Version: 0.24.619.29178
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 16:57:41
 * @column：44
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="期间" prop="mh003">
        <el-select filterable clearable   v-model="queryParams.mh003" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="mh004">
        <el-select filterable clearable   v-model="queryParams.mh004" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司" prop="mh005">
        <el-select filterable clearable   v-model="queryParams.mh005" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目" prop="mh006">
        <el-select filterable clearable   v-model="queryParams.mh006" :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_budget_title " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetexpense:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetexpense:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetexpense:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetexpense:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetExpense/importTemplate"
                  importUrl="/Accounting/FicoBudgetExpense/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetexpense:export']">
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
      <el-table-column prop="deptId" label="部门ID" align="center" v-if="columns.showColumn('deptId')"/>
      <el-table-column prop="mh003" label="期间" align="center" v-if="columns.showColumn('mh003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mh003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mh004" label="年月" align="center" v-if="columns.showColumn('mh004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mh004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mh005" label="公司" align="center" v-if="columns.showColumn('mh005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mh005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mh006" label="科目" align="center" v-if="columns.showColumn('mh006')">
        <template #default="scope">
          <dict-tag :options=" options.sql_budget_title " :value="scope.row.mh006"  />
        </template>
      </el-table-column>
      <el-table-column prop="mh007" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mh007')"/>
      <el-table-column prop="mh008" label="明细科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mh008')"/>
      <el-table-column prop="mh009" label="明细名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mh009')"/>
      <el-table-column prop="mh010" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mh010')"/>
      <el-table-column prop="mh011" label="预算金额" align="center" v-if="columns.showColumn('mh011')"/>
      <el-table-column prop="mh012" label="实际发生" align="center" v-if="columns.showColumn('mh012')"/>
      <el-table-column prop="mh013" label="差异" align="center" v-if="columns.showColumn('mh013')"/>
      <el-table-column prop="mh014" label="启用标记" align="center" v-if="columns.showColumn('mh014')"/>
      <el-table-column prop="mh015" label="审核" align="center" v-if="columns.showColumn('mh015')"/>
      <el-table-column prop="mh016" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mh016')"/>
      <el-table-column prop="mh017" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mh017')"/>
      <el-table-column prop="mh018" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mh018')"/>
      <el-table-column prop="mh019" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mh019')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetexpense:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetexpense:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改费用预算对话框 -->
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
            <el-form-item label="部门ID" prop="deptId">
              <el-input   v-model.number="form.deptId" :placeholder="$t('btn.enterPrefix')+'部门ID'+$t('btn.enterSuffix')"  show-word-limit   maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="mh003">
              <el-select filterable clearable   v-model="form.mh003"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="mh004">
              <el-select filterable clearable   v-model="form.mh004"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司" prop="mh005">
              <el-select filterable clearable   v-model="form.mh005"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="科目" prop="mh006">
              <el-select filterable clearable   v-model="form.mh006"  :placeholder="$t('btn.selectPrefix')+'科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_budget_title" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="名称" prop="mh007">
              <el-input   v-model="form.mh007" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="明细科目" prop="mh008">
              <el-input   v-model="form.mh008" :placeholder="$t('btn.enterPrefix')+'明细科目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="明细名称" prop="mh009">
              <el-input   v-model="form.mh009" :placeholder="$t('btn.enterPrefix')+'明细名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="mh010">
              <el-input   v-model="form.mh010" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算金额" prop="mh011">
              <el-input-number v-model.number="form.mh011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际发生" prop="mh012">
              <el-input-number v-model.number="form.mh012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际发生'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="mh013">
              <el-input-number v-model.number="form.mh013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用标记" prop="mh014">
              <el-input-number v-model.number="form.mh014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'启用标记'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="审核" prop="mh015">
              <el-input-number v-model.number="form.mh015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'审核'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="mh016">
              <el-input   v-model="form.mh016" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="mh017">
              <el-date-picker v-model="form.mh017" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="mh018">
              <el-input   v-model="form.mh018" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="mh019">
              <el-date-picker v-model="form.mh019" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ficobudgetexpense">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetExpense,
 addFicoBudgetExpense, delFicoBudgetExpense, 
 updateFicoBudgetExpense,getFicoBudgetExpense, 
 } 
from '@/api/accounting/ficobudgetexpense.js'
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
  sort: 'Mh005',
  sortType: 'desc',
  //是否查询（1是）
  mh003: undefined,
  //是否查询（1是）
  mh004: undefined,
  //是否查询（1是）
  mh005: undefined,
  //是否查询（1是）
  mh006: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'deptId', label: '部门ID' },
  { visible: true, prop: 'mh003', label: '期间' },
  { visible: true, prop: 'mh004', label: '年月' },
  { visible: true, prop: 'mh005', label: '公司' },
  { visible: true, prop: 'mh006', label: '科目' },
  { visible: true, prop: 'mh007', label: '名称' },
  { visible: false, prop: 'mh008', label: '明细科目' },
  { visible: false, prop: 'mh009', label: '明细名称' },
  { visible: false, prop: 'mh010', label: '说明' },
  { visible: false, prop: 'mh011', label: '预算金额' },
  { visible: false, prop: 'mh012', label: '实际发生' },
  { visible: false, prop: 'mh013', label: '差异' },
  { visible: false, prop: 'mh014', label: '启用标记' },
  { visible: false, prop: 'mh015', label: '审核' },
  { visible: false, prop: 'mh016', label: '审核人员' },
  { visible: false, prop: 'mh017', label: '审核日期' },
  { visible: false, prop: 'mh018', label: '撤消人员' },
  { visible: false, prop: 'mh019', label: '撤消日期' },
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
  { dictType: "sql_attr_list" },
  { dictType: "sql_ymdt_list" },
  { dictType: "sql_corp_list" },
  { dictType: "sql_budget_title" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从费用预算/fico_budget_expense表记录数据
function getList(){
  loading.value = true
  listFicoBudgetExpense(queryParams).then(res => {
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
    mh003: [{ required: true, message: "期间"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mh004: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mh005: [{ required: true, message: "公司"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mh006: [{ required: true, message: "科目"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mh011: [{ required: true, message: "预算金额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mh012: [{ required: true, message: "实际发生"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mh013: [{ required: true, message: "差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mh014: [{ required: true, message: "启用标记"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mh015: [{ required: true, message: "审核"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ref04: [{ required: true, message: "预留1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ref05: [{ required: true, message: "预留2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ref06: [{ required: true, message: "预留3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    udf51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    udf52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    udf53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    udf54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    udf55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    udf56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ymdt_list: [],
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
    // 科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_budget_title: [],
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
    deptId: 0,
    mh003: [],
    mh004: [],
    mh005: [],
    mh006: [],
    mh007: null,
    mh008: null,
    mh009: null,
    mh010: null,
    mh011: 0,
    mh012: 0,
    mh013: 0,
    mh014: 0,
    mh015: 0,
    mh016: null,
    mh017: null,
    mh018: null,
    mh019: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'费用预算'
  opertype.value = 1
  form.value.mh003= []
  form.value.mh004= []
  form.value.mh005= []
  form.value.mh006= []
  form.value.mh011= 0
  form.value.mh012= 0
  form.value.mh013= 0
  form.value.mh014= 0
  form.value.mh015= 0
  form.value.mh017= new Date()
  form.value.mh019= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoBudgetExpense(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '费用预算'
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
        updateFicoBudgetExpense(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetExpense(form.value).then((res) => {
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
      return delFicoBudgetExpense(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<费用预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetExpense/export', { ...queryParams })
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