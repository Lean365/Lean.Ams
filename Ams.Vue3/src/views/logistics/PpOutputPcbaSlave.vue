<!--
 * @Descripttion: PCBA明细/pp_output_pcba_slave
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/29 12:09:28
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
        <el-button class="btn-add" v-hasPermi="['pp:outputpcbaslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:outputpcbaslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:outputpcbaslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputpcbaslave:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpOutputPcbaSlave/importTemplate"
                  importUrl="/Logistics/PpOutputPcbaSlave/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputpcbaslave:export']">
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
      <el-table-column prop="posSfId" label="ID" align="center" v-if="columns.showColumn('posSfId')"/>
      <el-table-column prop="posParentSfId" label="父SfId" align="center" v-if="columns.showColumn('posParentSfId')"/>
      <el-table-column prop="posLineName" label="班组" align="center" v-if="columns.showColumn('posLineName')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.posLineName"  />
        </template>
      </el-table-column>
      <el-table-column prop="posPcbaType" label="板别" align="center" v-if="columns.showColumn('posPcbaType')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_type " :value="scope.row.posPcbaType"  />
        </template>
      </el-table-column>
      <el-table-column prop="posPcbaSide" label="板面" align="center" v-if="columns.showColumn('posPcbaSide')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pcb_side " :value="scope.row.posPcbaSide"  />
        </template>
      </el-table-column>
      <el-table-column prop="posLotQty" label="Lot数" align="center" v-if="columns.showColumn('posLotQty')"/>
      <el-table-column prop="posRealOutput" label="生产实绩" align="center" v-if="columns.showColumn('posRealOutput')"/>
      <el-table-column prop="posRealTotal" label="累计生产数" align="center" v-if="columns.showColumn('posRealTotal')"/>
      <el-table-column prop="posPcbSerial" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('posPcbSerial')"/>
      <el-table-column prop="posPcbaStated" label="完成情况" align="center" v-if="columns.showColumn('posPcbaStated')">
        <template #default="scope">
          <dict-tag :options=" options.sql_comp_status " :value="scope.row.posPcbaStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="posProTime" label="生产工数" align="center" v-if="columns.showColumn('posProTime')"/>
      <el-table-column prop="posHandoffNum" label="切换次数" align="center" v-if="columns.showColumn('posHandoffNum')"/>
      <el-table-column prop="posHandoffTime" label="切换时间" align="center" v-if="columns.showColumn('posHandoffTime')"/>
      <el-table-column prop="posDownTime" label="切停机时间" align="center" v-if="columns.showColumn('posDownTime')"/>
      <el-table-column prop="posLossTime" label="损失工数" align="center" v-if="columns.showColumn('posLossTime')"/>
      <el-table-column prop="posMakeTime" label="投入工数" align="center" v-if="columns.showColumn('posMakeTime')"/>
      <el-table-column prop="posBadQty" label="不良台数" align="center" v-if="columns.showColumn('posBadQty')"/>
      <el-table-column prop="posManualLoss" label="手插仕损" align="center" v-if="columns.showColumn('posManualLoss')"/>
      <el-table-column prop="posRepairLoss" label="修正仕损" align="center" v-if="columns.showColumn('posRepairLoss')"/>
      <el-table-column prop="posDownTimeReasons" label="停线原因" align="center" v-if="columns.showColumn('posDownTimeReasons')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_stop " :value="scope.row.posDownTimeReasons"  />
        </template>
      </el-table-column>
      <el-table-column prop="posDownTimeDescription" label="停线备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('posDownTimeDescription')"/>
      <el-table-column prop="posMissingReasons" label="未达成原因" align="center" v-if="columns.showColumn('posMissingReasons')">
        <template #default="scope">
          <dict-tag :options=" options.sql_non_conf " :value="scope.row.posMissingReasons"  />
        </template>
      </el-table-column>
      <el-table-column prop="posMissingDescription" label="未达成备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('posMissingDescription')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:outputpcbaslave:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:outputpcbaslave:delete']" @click="handleDelete(scope.row)"></el-button>
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
            <el-form-item label="父SfId" prop="posParentSfId">
              <el-input v-model.number="form.posParentSfId" :placeholder="$t('btn.enterPrefix')+'父SfId'+$t('btn.enterSuffix')"  show-word-limit maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组" prop="posLineName">
              <el-select filterable clearable   v-model="form.posLineName"  :placeholder="$t('btn.selectPrefix')+'班组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_line_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="板别" prop="posPcbaType">
              <el-select filterable clearable   v-model="form.posPcbaType"  :placeholder="$t('btn.selectPrefix')+'板别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="Lot数" prop="posLotQty">
              <el-input-number v-model.number="form.posLotQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="生产实绩" prop="posRealOutput">
              <el-input-number v-model.number="form.posRealOutput" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'生产实绩'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计生产数" prop="posRealTotal">
              <el-input-number v-model.number="form.posRealTotal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计生产数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="序列号" prop="posPcbSerial">
              <el-input type="textarea" v-model="form.posPcbSerial" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" show-word-limit maxlength="2000"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完成情况" prop="posPcbaStated">
              <el-radio-group v-model="form.posPcbaStated">
                <el-radio v-for="item in options.sql_comp_status" :key="item.dictValue" :value="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="生产工数" prop="posProTime">
              <el-input-number v-model.number="form.posProTime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'生产工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="切换次数" prop="posHandoffNum">
              <el-input-number v-model.number="form.posHandoffNum" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切换次数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="切换时间" prop="posHandoffTime">
              <el-input-number v-model.number="form.posHandoffTime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切换时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="切停机时间" prop="posDownTime">
              <el-input-number v-model.number="form.posDownTime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切停机时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="损失工数" prop="posLossTime">
              <el-input-number v-model.number="form.posLossTime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'损失工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="投入工数" prop="posMakeTime">
              <el-input-number v-model.number="form.posMakeTime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="不良台数" prop="posBadQty">
              <el-input-number v-model.number="form.posBadQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良台数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="手插仕损" prop="posManualLoss">
              <el-input-number v-model.number="form.posManualLoss" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'手插仕损'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="修正仕损" prop="posRepairLoss">
              <el-input-number v-model.number="form.posRepairLoss" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'修正仕损'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="停线原因" prop="posDownTimeReasons">
              <el-select filterable clearable   v-model="form.posDownTimeReasons"  :placeholder="$t('btn.selectPrefix')+'停线原因'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_line_stop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="停线备注说明" prop="posDownTimeDescription">
              <el-input v-model="form.posDownTimeDescription" :placeholder="$t('btn.enterPrefix')+'停线备注说明'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未达成原因" prop="posMissingReasons">
              <el-select filterable clearable   v-model="form.posMissingReasons"  :placeholder="$t('btn.selectPrefix')+'未达成原因'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_non_conf" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="未达成备注说明" prop="posMissingDescription">
              <el-input v-model="form.posMissingDescription" :placeholder="$t('btn.enterPrefix')+'未达成备注说明'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
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

<script setup name="ppoutputpcbaslave">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpOutputPcbaSlave,
 addPpOutputPcbaSlave, delPpOutputPcbaSlave, 
 updatePpOutputPcbaSlave,getPpOutputPcbaSlave, 
 } 
from '@/api/logistics/ppoutputpcbaslave.js'
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
  { visible: true, prop: 'posSfId', label: 'ID' },
  { visible: true, prop: 'posParentSfId', label: '父SfId' },
  { visible: true, prop: 'posLineName', label: '班组' },
  { visible: true, prop: 'posPcbaType', label: '板别' },
  { visible: true, prop: 'posPcbaSide', label: '板面' },
  { visible: true, prop: 'posLotQty', label: 'Lot数' },
  { visible: true, prop: 'posRealOutput', label: '生产实绩' },
  { visible: true, prop: 'posRealTotal', label: '累计生产数' },
  { visible: false, prop: 'posPcbSerial', label: '序列号' },
  { visible: false, prop: 'posPcbaStated', label: '完成情况' },
  { visible: false, prop: 'posProTime', label: '生产工数' },
  { visible: false, prop: 'posHandoffNum', label: '切换次数' },
  { visible: false, prop: 'posHandoffTime', label: '切换时间' },
  { visible: false, prop: 'posDownTime', label: '切停机时间' },
  { visible: false, prop: 'posLossTime', label: '损失工数' },
  { visible: false, prop: 'posMakeTime', label: '投入工数' },
  { visible: false, prop: 'posBadQty', label: '不良台数' },
  { visible: false, prop: 'posManualLoss', label: '手插仕损' },
  { visible: false, prop: 'posRepairLoss', label: '修正仕损' },
  { visible: false, prop: 'posDownTimeReasons', label: '停线原因' },
  { visible: false, prop: 'posDownTimeDescription', label: '停线备注说明' },
  { visible: false, prop: 'posMissingReasons', label: '未达成原因' },
  { visible: false, prop: 'posMissingDescription', label: '未达成备注说明' },
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
  { dictType: "sql_line_list" },
  { dictType: "sql_pcb_type" },
  { dictType: "sys_pcb_side" },
  { dictType: "sql_comp_status" },
  { dictType: "sql_line_stop" },
  { dictType: "sql_non_conf" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从PCBA明细/pp_output_pcba_slave表记录数据
function getList(){
  loading.value = true
  listPpOutputPcbaSlave(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.posSfId);
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
  rules: {
    posSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_list: [],
    // 板别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_type: [],
    // 板面 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pcb_side: [],
    // 完成情况 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_comp_status: [],
    // 停线原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_stop: [],
    // 未达成原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_non_conf: [],
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
    posSfId: 0,
    posParentSfId: 0,
    posLineName: null,
    posPcbaType: null,
    posPcbaSide: null,
    posLotQty: 0,
    posRealOutput: 0,
    posRealTotal: 0,
    posPcbSerial: null,
    posPcbaStated: null,
    posProTime: 0,
    posHandoffNum: 0,
    posHandoffTime: 0,
    posDownTime: 0,
    posLossTime: 0,
    posMakeTime: 0,
    posBadQty: 0,
    posManualLoss: 0,
    posRepairLoss: 0,
    posDownTimeReasons: null,
    posDownTimeDescription: null,
    posMissingReasons: null,
    posMissingDescription: null,
    rEF01: null,
    rEF02: null,
    rEF03: null,
    rEF04: 0,
    rEF05: 0,
    rEF06: 0,
    uDF01: null,
    uDF02: null,
    uDF03: null,
    uDF04: null,
    uDF05: null,
    uDF06: null,
    uDF51: 0,
    uDF52: 0,
    uDF53: 0,
    uDF54: 0,
    uDF55: 0,
    uDF56: 0,
    isDeleted: 0,
    remark: null,
    createBy: null,
    createTime: null,
    updateBy: null,
    updateTime: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'PCBA明细'
  opertype.value = 1
  form.value.posLineName= []
  form.value.posPcbaType= []
  form.value.posPcbaSide= []
  form.value.posLotQty= 0
  form.value.posRealOutput= 0
  form.value.posRealTotal= 0
  form.value.posPcbaStated= 0
  form.value.posProTime= 0
  form.value.posHandoffNum= 0
  form.value.posHandoffTime= 0
  form.value.posDownTime= 0
  form.value.posLossTime= 0
  form.value.posMakeTime= 0
  form.value.posBadQty= 0
  form.value.posManualLoss= 0
  form.value.posRepairLoss= 0
  form.value.posDownTimeReasons= []
  form.value.posMissingReasons= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.posSfId || ids.value
  getPpOutputPcbaSlave(id).then((res) => {
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

      if (form.value.posSfId != undefined && opertype.value === 2) {
        updatePpOutputPcbaSlave(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpOutputPcbaSlave(form.value).then((res) => {
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
  const Ids = row.posSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpOutputPcbaSlave(Ids)
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
      await proxy.downFile('/Logistics/PpOutputPcbaSlave/export', { ...queryParams })
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