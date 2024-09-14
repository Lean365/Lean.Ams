<!--
 * @Descripttion: PCBA明细/pp_output_pcba_slv
 * @Version: 0.24.621.29885
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 16:38:35
 * @column：47
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
        <el-button class="btn-add" v-hasPermi="['pp:outputpcbaslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:outputpcbaslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:outputpcbaslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputpcbaslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpOutputPcbaSlv/importTemplate"
                  importUrl="/Logistics/PpOutputPcbaSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputpcbaslv:export']">
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
      <el-table-column prop="mda003" label="班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mda003')"/>
      <el-table-column prop="mda004" label="板别" align="center" v-if="columns.showColumn('mda004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_type " :value="scope.row.mda004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mda005" label="板面" align="center" v-if="columns.showColumn('mda005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pcb_side " :value="scope.row.mda005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mda006" label="Lot数" align="center" v-if="columns.showColumn('mda006')"/>
      <el-table-column prop="mda007" label="生产实绩" align="center" v-if="columns.showColumn('mda007')"/>
      <el-table-column prop="mda008" label="累计生产数" align="center" v-if="columns.showColumn('mda008')"/>
      <el-table-column prop="mda009" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mda009')"/>
      <el-table-column prop="mda010" label="完成情况" align="center" v-if="columns.showColumn('mda010')">
        <template #default="scope">
          <dict-tag :options=" options.sql_comp_status " :value="scope.row.mda010"  />
        </template>
      </el-table-column>
      <el-table-column prop="mda011" label="总工数" align="center" v-if="columns.showColumn('mda011')"/>
      <el-table-column prop="mda012" label="切换次数" align="center" v-if="columns.showColumn('mda012')"/>
      <el-table-column prop="mda013" label="切换时间" align="center" v-if="columns.showColumn('mda013')"/>
      <el-table-column prop="mda014" label="切停机时间" align="center" v-if="columns.showColumn('mda014')"/>
      <el-table-column prop="mda015" label="修工数" align="center" v-if="columns.showColumn('mda015')"/>
      <el-table-column prop="mda016" label="投入工数" align="center" v-if="columns.showColumn('mda016')"/>
      <el-table-column prop="mda017" label="不良台数" align="center" v-if="columns.showColumn('mda017')"/>
      <el-table-column prop="mda018" label="手插仕损" align="center" v-if="columns.showColumn('mda018')"/>
      <el-table-column prop="mda019" label="修正仕损" align="center" v-if="columns.showColumn('mda019')"/>
      <el-table-column prop="mda020" label="停线原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mda020')"/>
      <el-table-column prop="mda021" label="停线备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mda021')"/>
      <el-table-column prop="mda022" label="未达成原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mda022')"/>
      <el-table-column prop="mda023" label="未达成备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mda023')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:outputpcbaslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:outputpcbaslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改PCBA明细对话框 -->
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
            <el-form-item label="班组" prop="mda003">
              <el-input   v-model="form.mda003" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="板别" prop="mda004">
              <el-select filterable clearable   v-model="form.mda004"  :placeholder="$t('btn.selectPrefix')+'板别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="板面" prop="mda005">
              <el-select filterable clearable   v-model="form.mda005"  :placeholder="$t('btn.selectPrefix')+'板面'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pcb_side" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="Lot数" prop="mda006">
              <el-input-number v-model.number="form.mda006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="生产实绩" prop="mda007">
              <el-input-number v-model.number="form.mda007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'生产实绩'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计生产数" prop="mda008">
              <el-input-number v-model.number="form.mda008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计生产数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="序列号" prop="mda009">
              <el-input type="textarea" v-model="form.mda009" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" show-word-limit maxlength="2000"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完成情况" prop="mda010">
              <el-select filterable clearable   v-model="form.mda010"  :placeholder="$t('btn.selectPrefix')+'完成情况'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_comp_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="总工数" prop="mda011">
              <el-input-number v-model.number="form.mda011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="切换次数" prop="mda012">
              <el-input-number v-model.number="form.mda012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切换次数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="切换时间" prop="mda013">
              <el-input-number v-model.number="form.mda013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切换时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="切停机时间" prop="mda014">
              <el-input-number v-model.number="form.mda014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切停机时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="修工数" prop="mda015">
              <el-input-number v-model.number="form.mda015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'修工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="投入工数" prop="mda016">
              <el-input-number v-model.number="form.mda016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="不良台数" prop="mda017">
              <el-input-number v-model.number="form.mda017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良台数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="手插仕损" prop="mda018">
              <el-input-number v-model.number="form.mda018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'手插仕损'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="修正仕损" prop="mda019">
              <el-input-number v-model.number="form.mda019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'修正仕损'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线原因" prop="mda020">
              <el-input   v-model="form.mda020" :placeholder="$t('btn.enterPrefix')+'停线原因'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线备注说明" prop="mda021">
              <el-input   v-model="form.mda021" :placeholder="$t('btn.enterPrefix')+'停线备注说明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成原因" prop="mda022">
              <el-input   v-model="form.mda022" :placeholder="$t('btn.enterPrefix')+'未达成原因'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成备注说明" prop="mda023">
              <el-input   v-model="form.mda023" :placeholder="$t('btn.enterPrefix')+'未达成备注说明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
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

<script setup name="ppoutputpcbaslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpOutputPcbaSlv,
 addPpOutputPcbaSlv, delPpOutputPcbaSlv, 
 updatePpOutputPcbaSlv,getPpOutputPcbaSlv, 
 } 
from '@/api/logistics/ppoutputpcbaslv.js'
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
  { visible: true, prop: 'mda003', label: '班组' },
  { visible: true, prop: 'mda004', label: '板别' },
  { visible: true, prop: 'mda005', label: '板面' },
  { visible: true, prop: 'mda006', label: 'Lot数' },
  { visible: true, prop: 'mda007', label: '生产实绩' },
  { visible: true, prop: 'mda008', label: '累计生产数' },
  { visible: false, prop: 'mda009', label: '序列号' },
  { visible: false, prop: 'mda010', label: '完成情况' },
  { visible: false, prop: 'mda011', label: '总工数' },
  { visible: false, prop: 'mda012', label: '切换次数' },
  { visible: false, prop: 'mda013', label: '切换时间' },
  { visible: false, prop: 'mda014', label: '切停机时间' },
  { visible: false, prop: 'mda015', label: '修工数' },
  { visible: false, prop: 'mda016', label: '投入工数' },
  { visible: false, prop: 'mda017', label: '不良台数' },
  { visible: false, prop: 'mda018', label: '手插仕损' },
  { visible: false, prop: 'mda019', label: '修正仕损' },
  { visible: false, prop: 'mda020', label: '停线原因' },
  { visible: false, prop: 'mda021', label: '停线备注说明' },
  { visible: false, prop: 'mda022', label: '未达成原因' },
  { visible: false, prop: 'mda023', label: '未达成备注说明' },
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
  { dictType: "sys_pcb_side" },
  { dictType: "sql_comp_status" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从PCBA明细/pp_output_pcba_slv表记录数据
function getList(){
  loading.value = true
  listPpOutputPcbaSlv(queryParams).then(res => {
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
    mda006: [{ required: true, message: "Lot数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda007: [{ required: true, message: "生产实绩"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda008: [{ required: true, message: "累计生产数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda011: [{ required: true, message: "总工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda012: [{ required: true, message: "切换次数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda013: [{ required: true, message: "切换时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda014: [{ required: true, message: "切停机时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda015: [{ required: true, message: "修工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda016: [{ required: true, message: "投入工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda017: [{ required: true, message: "不良台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda018: [{ required: true, message: "手插仕损"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mda019: [{ required: true, message: "修正仕损"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 板别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_type: [],
    // 板面 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pcb_side: [],
    // 完成情况 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    parentId: 0,
    mda003: null,
    mda004: [],
    mda005: [],
    mda006: 0,
    mda007: 0,
    mda008: 0,
    mda009: null,
    mda010: [],
    mda011: 0,
    mda012: 0,
    mda013: 0,
    mda014: 0,
    mda015: 0,
    mda016: 0,
    mda017: 0,
    mda018: 0,
    mda019: 0,
    mda020: null,
    mda021: null,
    mda022: null,
    mda023: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'PCBA明细'
  opertype.value = 1
  form.value.mda004= []
  form.value.mda005= []
  form.value.mda006= 0
  form.value.mda007= 0
  form.value.mda008= 0
  form.value.mda010= []
  form.value.mda011= 0
  form.value.mda012= 0
  form.value.mda013= 0
  form.value.mda014= 0
  form.value.mda015= 0
  form.value.mda016= 0
  form.value.mda017= 0
  form.value.mda018= 0
  form.value.mda019= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpOutputPcbaSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ 'PCBA明细'
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
        updatePpOutputPcbaSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpOutputPcbaSlv(form.value).then((res) => {
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
      return delPpOutputPcbaSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<PCBA明细.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpOutputPcbaSlv/export', { ...queryParams })
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