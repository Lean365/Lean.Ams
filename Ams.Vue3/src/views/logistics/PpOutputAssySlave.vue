<!--
 * @Descripttion: 组立明细/pp_output_assy_slave
 * @Version: 0.24.615.18388
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/6 10:14:01
 * @column：38
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
        <el-button class="btn-add" v-hasPermi="['pp:outputassyslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:outputassyslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:outputassyslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputassyslave:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpOutputAssySlave/importTemplate"
                  importUrl="/Logistics/PpOutputAssySlave/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputassyslave:export']">
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
      <el-table-column prop="parentId" label="父SfId" align="center" v-if="columns.showColumn('parentId')"/>
      <el-table-column prop="mmb002" label="生产时段" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmb002')"/>
      <el-table-column prop="mmb003" label="实际产能" align="center" v-if="columns.showColumn('mmb003')"/>
      <el-table-column prop="mmb004" label="停线时间" align="center" v-if="columns.showColumn('mmb004')"/>
      <el-table-column prop="mmb005" label="停线" align="center" v-if="columns.showColumn('mmb005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_stop " :value="scope.row.mmb005" split="," />
        </template>
      </el-table-column>
      <el-table-column prop="mmb006" label="停线说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmb006')"/>
      <el-table-column prop="mmb007" label="未达成" align="center" v-if="columns.showColumn('mmb007')">
        <template #default="scope">
          <dict-tag :options=" options.sql_non_conf " :value="scope.row.mmb007" split="," />
        </template>
      </el-table-column>
      <el-table-column prop="mmb008" label="未达成说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mmb008')"/>
      <el-table-column prop="mmb009" label="实际工数" align="center" v-if="columns.showColumn('mmb009')"/>
      <el-table-column prop="mmb010" label="投入工数" align="center" v-if="columns.showColumn('mmb010')"/>
      <el-table-column prop="mmb011" label="工时差异" align="center" v-if="columns.showColumn('mmb011')"/>
      <el-table-column prop="mmb012" label="产能差异" align="center" v-if="columns.showColumn('mmb012')"/>
      <el-table-column prop="mmb013" label="达成率" align="center" v-if="columns.showColumn('mmb013')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:outputassyslave:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:outputassyslave:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改组立明细对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父SfId" prop="parentId">
              <el-input   v-model.number="form.parentId" :placeholder="$t('btn.enterPrefix')+'父SfId'+$t('btn.enterSuffix')"  show-word-limit   maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产时段" prop="mmb002">
              <el-input   v-model="form.mmb002" :placeholder="$t('btn.enterPrefix')+'生产时段'+$t('btn.enterSuffix')"  show-word-limit   maxlength="11"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实际产能" prop="mmb003">
              <el-input-number v-model.number="form.mmb003" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际产能'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="停线时间" prop="mmb004">
              <el-input-number v-model.number="form.mmb004" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'停线时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线" prop="mmb005">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip  v-model="form.mmb005Checked"  :placeholder="$t('btn.selectPrefix')+'停线'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_line_stop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="停线说明" prop="mmb006">
              <el-input   v-model="form.mmb006" :placeholder="$t('btn.enterPrefix')+'停线说明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成" prop="mmb007">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip  v-model="form.mmb007Checked"  :placeholder="$t('btn.selectPrefix')+'未达成'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_non_conf" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="未达成说明" prop="mmb008">
              <el-input   v-model="form.mmb008" :placeholder="$t('btn.enterPrefix')+'未达成说明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实际工数" prop="mmb009">
              <el-input-number v-model.number="form.mmb009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入工数" prop="mmb010">
              <el-input-number v-model.number="form.mmb010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工时差异" prop="mmb011">
              <el-input-number v-model.number="form.mmb011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工时差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产能差异" prop="mmb012">
              <el-input-number v-model.number="form.mmb012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'产能差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="达成率" prop="mmb013">
              <el-input-number v-model.number="form.mmb013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'达成率'+$t('btn.enterSuffix')" />
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

<script setup name="ppoutputassyslave">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpOutputAssySlave,
 addPpOutputAssySlave, delPpOutputAssySlave, 
 updatePpOutputAssySlave,getPpOutputAssySlave, 
 } 
from '@/api/logistics/ppoutputassyslave.js'
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
  { visible: true, prop: 'parentId', label: '父SfId' },
  { visible: true, prop: 'mmb002', label: '生产时段' },
  { visible: true, prop: 'mmb003', label: '实际产能' },
  { visible: true, prop: 'mmb004', label: '停线时间' },
  { visible: true, prop: 'mmb005', label: '停线' },
  { visible: true, prop: 'mmb006', label: '停线说明' },
  { visible: true, prop: 'mmb007', label: '未达成' },
  { visible: false, prop: 'mmb008', label: '未达成说明' },
  { visible: false, prop: 'mmb009', label: '实际工数' },
  { visible: false, prop: 'mmb010', label: '投入工数' },
  { visible: false, prop: 'mmb011', label: '工时差异' },
  { visible: false, prop: 'mmb012', label: '产能差异' },
  { visible: false, prop: 'mmb013', label: '达成率' },
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
  { dictType: "sql_line_stop" },
  { dictType: "sql_non_conf" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从组立明细/pp_output_assy_slave表记录数据
function getList(){
  loading.value = true
  listPpOutputAssySlave(queryParams).then(res => {
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
    parentId: [{ required: true, message: "父SfId"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mmb002: [{ required: true, message: "生产时段"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mmb003: [{ required: true, message: "实际产能"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mmb004: [{ required: true, message: "停线时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mmb009: [{ required: true, message: "实际工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mmb010: [{ required: true, message: "投入工数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mmb011: [{ required: true, message: "工时差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mmb012: [{ required: true, message: "产能差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mmb013: [{ required: true, message: "达成率"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 停线 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_stop: [],
    // 未达成 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_non_conf: [],
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
    mmb002: null,
    mmb003: 0,
    mmb004: 0,
    mmb005: [],
    mmb006: null,
    mmb007: [],
    mmb008: null,
    mmb009: 0,
    mmb010: 0,
    mmb011: 0,
    mmb012: 0,
    mmb013: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'组立明细'
  opertype.value = 1
  form.value.mmb003= 0
  form.value.mmb004= 0
  form.value.mmb005= []
  form.value.mmb007= []
  form.value.mmb009= 0
  form.value.mmb010= 0
  form.value.mmb011= 0
  form.value.mmb012= 0
  form.value.mmb013= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpOutputAssySlave(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '组立明细'
      opertype.value = 2

      form.value = {
        ...data,
        mmb005Checked: data.mmb005 ? data.mmb005.split(',') : [],
        mmb007Checked: data.mmb007 ? data.mmb007.split(',') : [],
      }
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {
      form.value.mmb005 = form.value.mmb005Checked.toString();
      form.value.mmb007 = form.value.mmb007Checked.toString();

      if (form.value.id != undefined && opertype.value === 2) {
        updatePpOutputAssySlave(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpOutputAssySlave(form.value).then((res) => {
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
      return delPpOutputAssySlave(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<组立明细.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpOutputAssySlave/export', { ...queryParams })
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