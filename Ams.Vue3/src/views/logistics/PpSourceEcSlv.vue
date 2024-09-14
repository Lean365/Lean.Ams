<!--
 * @Descripttion: 从源设变/pp_source_ec_slv
 * @Version: 0.24.619.30682
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 17:08:51
 * @column：44
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="设变No." prop="zb003">
        <el-input v-model="queryParams.zb003" :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="完成品" prop="zb004">
        <el-input v-model="queryParams.zb004" :placeholder="$t('btn.enterSearchPrefix')+'完成品'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['pp:sourceecslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:sourceecslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:sourceecslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:sourceecslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpSourceEcSlv/importTemplate"
                  importUrl="/Logistics/PpSourceEcSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:sourceecslv:export']">
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
      <el-table-column prop="zb002" label="父ID" align="center" v-if="columns.showColumn('zb002')"/>
      <el-table-column prop="zb003" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb003')"/>
      <el-table-column prop="zb004" label="完成品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb004')"/>
      <el-table-column prop="zb005" label="上阶" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb005')"/>
      <el-table-column prop="zb006" label="旧物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb006')"/>
      <el-table-column prop="zb007" label="品名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb007')"/>
      <el-table-column prop="zb008" label="数量" align="center" v-if="columns.showColumn('zb008')"/>
      <el-table-column prop="zb009" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb009')"/>
      <el-table-column prop="zb010" label="新物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb010')"/>
      <el-table-column prop="zb011" label="品名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb011')"/>
      <el-table-column prop="zb012" label="数量" align="center" v-if="columns.showColumn('zb012')"/>
      <el-table-column prop="zb013" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb013')"/>
      <el-table-column prop="zb014" label="BOM番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb014')"/>
      <el-table-column prop="zb015" label="互换性" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb015')"/>
      <el-table-column prop="zb016" label="区分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb016')"/>
      <el-table-column prop="zb017" label="安排指示" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb017')"/>
      <el-table-column prop="zb018" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb018')"/>
      <el-table-column prop="zb019" label="BOM生效" :show-overflow-tooltip="true"  v-if="columns.showColumn('zb019')"/>
      <el-table-column prop="zb020" label="处理标记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zb020')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:sourceecslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:sourceecslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改从源设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="zb002">
              <el-input   v-model.number="form.zb002" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')"  show-word-limit   maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="zb003">
              <el-input   v-model="form.zb003" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完成品" prop="zb004">
              <el-input   v-model="form.zb004" :placeholder="$t('btn.enterPrefix')+'完成品'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上阶" prop="zb005">
              <el-input   v-model="form.zb005" :placeholder="$t('btn.enterPrefix')+'上阶'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料" prop="zb006">
              <el-input   v-model="form.zb006" :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="品名" prop="zb007">
              <el-input   v-model="form.zb007" :placeholder="$t('btn.enterPrefix')+'品名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="zb008">
              <el-input-number v-model.number="form.zb008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="zb009">
              <el-input   v-model="form.zb009" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="zb010">
              <el-input   v-model="form.zb010" :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="品名" prop="zb011">
              <el-input   v-model="form.zb011" :placeholder="$t('btn.enterPrefix')+'品名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="zb012">
              <el-input-number v-model.number="form.zb012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="zb013">
              <el-input   v-model="form.zb013" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="BOM番号" prop="zb014">
              <el-input   v-model="form.zb014" :placeholder="$t('btn.enterPrefix')+'BOM番号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="互换性" prop="zb015">
              <el-input   v-model="form.zb015" :placeholder="$t('btn.enterPrefix')+'互换性'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="区分" prop="zb016">
              <el-input   v-model="form.zb016" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安排指示" prop="zb017">
              <el-input   v-model="form.zb017" :placeholder="$t('btn.enterPrefix')+'安排指示'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品处理" prop="zb018">
              <el-input   v-model="form.zb018" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="BOM生效" prop="zb019">
              <el-date-picker v-model="form.zb019" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理标记" prop="zb020">
              <el-input   v-model="form.zb020" :placeholder="$t('btn.enterPrefix')+'处理标记'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
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

<script setup name="ppsourceecslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpSourceEcSlv,
 addPpSourceEcSlv, delPpSourceEcSlv, 
 updatePpSourceEcSlv,getPpSourceEcSlv, 
 } 
from '@/api/logistics/ppsourceecslv.js'
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
  sort: 'Zb004',
  sortType: 'asc',
  //是否查询（1是）
  zb003: undefined,
  //是否查询（1是）
  zb004: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'zb002', label: '父ID' },
  { visible: true, prop: 'zb003', label: '设变No.' },
  { visible: true, prop: 'zb004', label: '完成品' },
  { visible: true, prop: 'zb005', label: '上阶' },
  { visible: true, prop: 'zb006', label: '旧物料' },
  { visible: true, prop: 'zb007', label: '品名' },
  { visible: true, prop: 'zb008', label: '数量' },
  { visible: false, prop: 'zb009', label: '位置' },
  { visible: false, prop: 'zb010', label: '新物料' },
  { visible: false, prop: 'zb011', label: '品名' },
  { visible: false, prop: 'zb012', label: '数量' },
  { visible: false, prop: 'zb013', label: '位置' },
  { visible: false, prop: 'zb014', label: 'BOM番号' },
  { visible: false, prop: 'zb015', label: '互换性' },
  { visible: false, prop: 'zb016', label: '区分' },
  { visible: false, prop: 'zb017', label: '安排指示' },
  { visible: false, prop: 'zb018', label: '旧品处理' },
  { visible: false, prop: 'zb019', label: 'BOM生效' },
  { visible: false, prop: 'zb020', label: '处理标记' },
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
]

//API获取从从源设变/pp_source_ec_slv表记录数据
function getList(){
  loading.value = true
  listPpSourceEcSlv(queryParams).then(res => {
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
    zb002: [{ required: true, message: "父ID"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    zb003: [{ required: true, message: "设变No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    zb004: [{ required: true, message: "完成品"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    zb008: [{ required: true, message: "数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    zb012: [{ required: true, message: "数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
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
    zb002: 0,
    zb003: null,
    zb004: null,
    zb005: null,
    zb006: null,
    zb007: null,
    zb008: 0,
    zb009: null,
    zb010: null,
    zb011: null,
    zb012: 0,
    zb013: null,
    zb014: null,
    zb015: null,
    zb016: null,
    zb017: null,
    zb018: null,
    zb019: null,
    zb020: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'从源设变'
  opertype.value = 1
  form.value.zb008= 0
  form.value.zb012= 0
  form.value.zb019= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpSourceEcSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '从源设变'
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
        updatePpSourceEcSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpSourceEcSlv(form.value).then((res) => {
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
      return delPpSourceEcSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<从源设变.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpSourceEcSlv/export', { ...queryParams })
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