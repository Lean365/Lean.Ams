<!--
 * @Descripttion: 修理明细/pp_repair_pcba_slv
 * @Version: 0.24.621.29885
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 16:38:47
 * @column：42
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
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
        <el-button class="btn-add" v-hasPermi="['pp:repairpcbaslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:repairpcbaslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:repairpcbaslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:repairpcbaslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpRepairPcbaSlv/importTemplate"
                  importUrl="/Logistics/PpRepairPcbaSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:repairpcbaslv:export']">
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
      <el-table-column prop="mha003" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mha003')"/>
      <el-table-column prop="mha004" label="板别" align="center" v-if="columns.showColumn('mha004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_type " :value="scope.row.mha004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mha005" label="Lot数" align="center" v-if="columns.showColumn('mha005')"/>
      <el-table-column prop="mha006" label="当日生产数" align="center" v-if="columns.showColumn('mha006')"/>
      <el-table-column prop="mha007" label="累计完成数" align="center" v-if="columns.showColumn('mha007')"/>
      <el-table-column prop="mha008" label="生产组别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mha008')"/>
      <el-table-column prop="mha009" label="卡号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mha009')"/>
      <el-table-column prop="mha010" label="不良症状" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mha010')"/>
      <el-table-column prop="mha011" label="检出工程" align="center" v-if="columns.showColumn('mha011')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_eng " :value="scope.row.mha011"  />
        </template>
      </el-table-column>
      <el-table-column prop="mha012" label="不良原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mha012')"/>
      <el-table-column prop="mha013" label="不良数量" align="center" v-if="columns.showColumn('mha013')"/>
      <el-table-column prop="mha014" label="累计不良台数" align="center" v-if="columns.showColumn('mha014')"/>
      <el-table-column prop="mha015" label="责任归属" align="center" v-if="columns.showColumn('mha015')">
        <template #default="scope">
          <dict-tag :options=" options.sql_resp_bel " :value="scope.row.mha015"  />
        </template>
      </el-table-column>
      <el-table-column prop="mha016" label="不良性质" align="center" v-if="columns.showColumn('mha016')">
        <template #default="scope">
          <dict-tag :options=" options.sql_bad_prop " :value="scope.row.mha016"  />
        </template>
      </el-table-column>
      <el-table-column prop="mha017" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mha017')"/>
      <el-table-column prop="mha018" label="修理" align="center" v-if="columns.showColumn('mha018')">
        <template #default="scope">
          <dict-tag :options=" options.sql_repair_list " :value="scope.row.mha018"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:repairpcbaslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:repairpcbaslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改修理明细对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="parentId">
              <el-input v-model.number="form.parentId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="mha003">
              <el-input   v-model="form.mha003" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="板别" prop="mha004">
              <el-select filterable clearable   v-model="form.mha004"  :placeholder="$t('btn.selectPrefix')+'板别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="Lot数" prop="mha005">
              <el-input-number v-model.number="form.mha005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当日生产数" prop="mha006">
              <el-input-number v-model.number="form.mha006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当日生产数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计完成数" prop="mha007">
              <el-input-number v-model.number="form.mha007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计完成数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产组别" prop="mha008">
              <el-input   v-model="form.mha008" :placeholder="$t('btn.enterPrefix')+'生产组别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="卡号" prop="mha009">
              <el-input   v-model="form.mha009" :placeholder="$t('btn.enterPrefix')+'卡号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良症状" prop="mha010">
              <el-input   v-model="form.mha010" :placeholder="$t('btn.enterPrefix')+'不良症状'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检出工程" prop="mha011">
              <el-select filterable clearable   v-model="form.mha011"  :placeholder="$t('btn.selectPrefix')+'检出工程'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_eng" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="不良原因" prop="mha012">
              <el-input   v-model="form.mha012" :placeholder="$t('btn.enterPrefix')+'不良原因'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="不良数量" prop="mha013">
              <el-input-number v-model.number="form.mha013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计不良台数" prop="mha014">
              <el-input-number v-model.number="form.mha014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计不良台数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="责任归属" prop="mha015">
              <el-select filterable clearable   v-model="form.mha015"  :placeholder="$t('btn.selectPrefix')+'责任归属'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_resp_bel" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="不良性质" prop="mha016">
              <el-select filterable clearable   v-model="form.mha016"  :placeholder="$t('btn.selectPrefix')+'不良性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_bad_prop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="序列号" prop="mha017">
              <el-input   v-model="form.mha017" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="修理" prop="mha018">
              <el-select filterable clearable   v-model="form.mha018"  :placeholder="$t('btn.selectPrefix')+'修理'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_repair_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
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


      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="pprepairpcbaslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpRepairPcbaSlv,
 addPpRepairPcbaSlv, delPpRepairPcbaSlv, 
 updatePpRepairPcbaSlv,getPpRepairPcbaSlv, 
 } 
from '@/api/logistics/pprepairpcbaslv.js'
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
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'mha003', label: '批次' },
  { visible: true, prop: 'mha004', label: '板别' },
  { visible: true, prop: 'mha005', label: 'Lot数' },
  { visible: true, prop: 'mha006', label: '当日生产数' },
  { visible: true, prop: 'mha007', label: '累计完成数' },
  { visible: true, prop: 'mha008', label: '生产组别' },
  { visible: false, prop: 'mha009', label: '卡号' },
  { visible: false, prop: 'mha010', label: '不良症状' },
  { visible: false, prop: 'mha011', label: '检出工程' },
  { visible: false, prop: 'mha012', label: '不良原因' },
  { visible: false, prop: 'mha013', label: '不良数量' },
  { visible: false, prop: 'mha014', label: '累计不良台数' },
  { visible: false, prop: 'mha015', label: '责任归属' },
  { visible: false, prop: 'mha016', label: '不良性质' },
  { visible: false, prop: 'mha017', label: '序列号' },
  { visible: false, prop: 'mha018', label: '修理' },
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

//字典参数
var dictParams = [
  { dictType: "sql_pcb_type" },
  { dictType: "sql_insp_eng" },
  { dictType: "sql_resp_bel" },
  { dictType: "sql_bad_prop" },
  { dictType: "sql_repair_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从修理明细/pp_repair_pcba_slv表记录数据
function getList(){
  loading.value = true
  listPpRepairPcbaSlv(queryParams).then(res => {
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
    mha005: [{ required: true, message: "Lot数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mha006: [{ required: true, message: "当日生产数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mha007: [{ required: true, message: "累计完成数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mha013: [{ required: true, message: "不良数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mha014: [{ required: true, message: "累计不良台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 板别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_type: [],
    // 检出工程 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_insp_eng: [],
    // 责任归属 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_resp_bel: [],
    // 不良性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_bad_prop: [],
    // 修理 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_repair_list: [],
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
    mha003: null,
    mha004: [],
    mha005: 0,
    mha006: 0,
    mha007: 0,
    mha008: null,
    mha009: null,
    mha010: null,
    mha011: [],
    mha012: null,
    mha013: 0,
    mha014: 0,
    mha015: [],
    mha016: [],
    mha017: null,
    mha018: [],
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'修理明细'
  opertype.value = 1
  form.value.mha004= []
  form.value.mha005= 0
  form.value.mha006= 0
  form.value.mha007= 0
  form.value.mha011= []
  form.value.mha013= 0
  form.value.mha014= 0
  form.value.mha015= []
  form.value.mha016= []
  form.value.mha018= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpRepairPcbaSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '修理明细'
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
        updatePpRepairPcbaSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpRepairPcbaSlv(form.value).then((res) => {
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
      return delPpRepairPcbaSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<修理明细.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpRepairPcbaSlv/export', { ...queryParams })
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