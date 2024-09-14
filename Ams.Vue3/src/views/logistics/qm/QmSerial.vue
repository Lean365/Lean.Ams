<!--
 * @Descripttion: 序列号扫描/qm_serial
 * @Version: 0.24.620.29565
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 16:36:33
 * @column：45
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
        <el-button class="btn-add" v-hasPermi="['qm:serial:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:serial:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:serial:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:serial:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmSerial/importTemplate"
                  importUrl="/Logistics/QmSerial/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:serial:export']">
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
      <el-table-column prop="mk002" label="入库序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk002')"/>
      <el-table-column prop="mk003" label="入库日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mk003')"/>
      <el-table-column prop="mk004" label="入库数量" align="center" v-if="columns.showColumn('mk004')"/>
      <el-table-column prop="mk005" label="HinName" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk005')"/>
      <el-table-column prop="mk006" label="HinIp" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk006')"/>
      <el-table-column prop="mk007" label="HinMac" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk007')"/>
      <el-table-column prop="mk008" label="入库扫描" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk008')"/>
      <el-table-column prop="mk009" label="入库日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mk009')"/>
      <el-table-column prop="mk010" label="出货发票" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk010')"/>
      <el-table-column prop="mk011" label="运输方式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk011')"/>
      <el-table-column prop="mk012" label="出库序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk012')"/>
      <el-table-column prop="mk013" label="出库日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mk013')"/>
      <el-table-column prop="mk014" label="出库数量" align="center" v-if="columns.showColumn('mk014')"/>
      <el-table-column prop="mk015" label="区域仕向" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk015')"/>
      <el-table-column prop="mk016" label="HouName" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk016')"/>
      <el-table-column prop="mk017" label="HouIp" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk017')"/>
      <el-table-column prop="mk018" label="HouMac" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk018')"/>
      <el-table-column prop="mk019" label="出库扫描" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mk019')"/>
      <el-table-column prop="mk020" label="出库日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mk020')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="qsWerks" label="工厂" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qsWerks')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:serial:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:serial:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改序列号扫描对话框 -->
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
            <el-form-item label="入库序列号" prop="mk002">
              <el-input   v-model="form.mk002" :placeholder="$t('btn.enterPrefix')+'入库序列号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="入库日期" prop="mk003">
              <el-date-picker v-model="form.mk003" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="入库数量" prop="mk004">
              <el-input-number v-model.number="form.mk004" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'入库数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="HinName" prop="mk005">
              <el-input   v-model="form.mk005" :placeholder="$t('btn.enterPrefix')+'HinName'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="HinIp" prop="mk006">
              <el-input   v-model="form.mk006" :placeholder="$t('btn.enterPrefix')+'HinIp'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="HinMac" prop="mk007">
              <el-input   v-model="form.mk007" :placeholder="$t('btn.enterPrefix')+'HinMac'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="入库扫描" prop="mk008">
              <el-input   v-model="form.mk008" :placeholder="$t('btn.enterPrefix')+'入库扫描'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="入库日期" prop="mk009">
              <el-date-picker v-model="form.mk009" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出货发票" prop="mk010">
              <el-input   v-model="form.mk010" :placeholder="$t('btn.enterPrefix')+'出货发票'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="运输方式" prop="mk011">
              <el-input   v-model="form.mk011" :placeholder="$t('btn.enterPrefix')+'运输方式'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出库序列号" prop="mk012">
              <el-input   v-model="form.mk012" :placeholder="$t('btn.enterPrefix')+'出库序列号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出库日期" prop="mk013">
              <el-date-picker v-model="form.mk013" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="出库数量" prop="mk014">
              <el-input-number v-model.number="form.mk014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'出库数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="区域仕向" prop="mk015">
              <el-input   v-model="form.mk015" :placeholder="$t('btn.enterPrefix')+'区域仕向'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="HouName" prop="mk016">
              <el-input   v-model="form.mk016" :placeholder="$t('btn.enterPrefix')+'HouName'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="HouIp" prop="mk017">
              <el-input   v-model="form.mk017" :placeholder="$t('btn.enterPrefix')+'HouIp'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="HouMac" prop="mk018">
              <el-input   v-model="form.mk018" :placeholder="$t('btn.enterPrefix')+'HouMac'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出库扫描" prop="mk019">
              <el-input   v-model="form.mk019" :placeholder="$t('btn.enterPrefix')+'出库扫描'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出库日期" prop="mk020">
              <el-date-picker v-model="form.mk020" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="qsWerks">
              <el-input   v-model="form.qsWerks" :placeholder="$t('btn.enterPrefix')+'工厂'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
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

<script setup name="qmserial">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmSerial,
 addQmSerial, delQmSerial, 
 updateQmSerial,getQmSerial, 
 } 
from '@/api/logistics/qmserial.js'
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
  sortType: 'desc',
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mk002', label: '入库序列号' },
  { visible: true, prop: 'mk003', label: '入库日期' },
  { visible: true, prop: 'mk004', label: '入库数量' },
  { visible: true, prop: 'mk005', label: 'HinName' },
  { visible: true, prop: 'mk006', label: 'HinIp' },
  { visible: true, prop: 'mk007', label: 'HinMac' },
  { visible: true, prop: 'mk008', label: '入库扫描' },
  { visible: false, prop: 'mk009', label: '入库日期' },
  { visible: false, prop: 'mk010', label: '出货发票' },
  { visible: false, prop: 'mk011', label: '运输方式' },
  { visible: false, prop: 'mk012', label: '出库序列号' },
  { visible: false, prop: 'mk013', label: '出库日期' },
  { visible: false, prop: 'mk014', label: '出库数量' },
  { visible: false, prop: 'mk015', label: '区域仕向' },
  { visible: false, prop: 'mk016', label: 'HouName' },
  { visible: false, prop: 'mk017', label: 'HouIp' },
  { visible: false, prop: 'mk018', label: 'HouMac' },
  { visible: false, prop: 'mk019', label: '出库扫描' },
  { visible: false, prop: 'mk020', label: '出库日期' },
  { visible: false, prop: 'remark', label: '备注说明' },
  { visible: false, prop: 'qsWerks', label: '工厂' },
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
]

//API获取从序列号扫描/qm_serial表记录数据
function getList(){
  loading.value = true
  listQmSerial(queryParams).then(res => {
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
    mk004: [{ required: true, message: "入库数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mk014: [{ required: true, message: "出库数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
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
    mk002: null,
    mk003: null,
    mk004: 0,
    mk005: null,
    mk006: null,
    mk007: null,
    mk008: null,
    mk009: null,
    mk010: null,
    mk011: null,
    mk012: null,
    mk013: null,
    mk014: 0,
    mk015: null,
    mk016: null,
    mk017: null,
    mk018: null,
    mk019: null,
    mk020: null,
    remark: null,
    qsWerks: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'序列号扫描'
  opertype.value = 1
  form.value.mk003= new Date()
  form.value.mk004= 0
  form.value.mk009= new Date()
  form.value.mk013= new Date()
  form.value.mk014= 0
  form.value.mk020= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getQmSerial(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '序列号扫描'
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
        updateQmSerial(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmSerial(form.value).then((res) => {
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
      return delQmSerial(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<序列号扫描.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmSerial/export', { ...queryParams })
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