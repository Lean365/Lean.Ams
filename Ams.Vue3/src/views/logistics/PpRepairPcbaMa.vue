<!--
 * @Descripttion: 修理/pp_repair_pcba_ma
 * @Version: 0.24.621.29056
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 16:10:27
 * @column：30
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="生产日期">
        <el-date-picker
          v-model="dateRangeMga002" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产机种" prop="mga003">
        <el-input v-model="queryParams.mga003" :placeholder="$t('btn.enterSearchPrefix')+'生产机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产订单" prop="mga004">
        <el-input v-model="queryParams.mga004" :placeholder="$t('btn.enterSearchPrefix')+'生产订单'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产LOT" prop="mga005">
        <el-input v-model="queryParams.mga005" :placeholder="$t('btn.enterSearchPrefix')+'生产LOT'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['pp:repairpcbama:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:repairpcbama:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:repairpcbama:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:repairpcbama:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpRepairPcbaMa/importTemplate"
                  importUrl="/Logistics/PpRepairPcbaMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:repairpcbama:export']">
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain  icon="view" size="small" @click="rowClick(scope.row)" :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="mga002" label="生产日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mga002')"/>
      <el-table-column prop="mga003" label="生产机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mga003')"/>
      <el-table-column prop="mga004" label="生产订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mga004')"/>
      <el-table-column prop="mga005" label="生产LOT" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mga005')"/>
      <el-table-column prop="mga006" label="订单台数" align="center" v-if="columns.showColumn('mga006')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:repairpcbama:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:repairpcbama:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppRepairPcbaSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID"/>
        <el-table-column prop="parentId" label="父ID"/>
        <el-table-column prop="mha003" label="批次"/>
        <el-table-column prop="mha004" label="板别">
          <template #default="scope">
            <dict-tag :options=" options.sql_pcb_type " :value="scope.row.mha004"  />
          </template>
        </el-table-column>
        <el-table-column prop="mha005" label="Lot数"/>
        <el-table-column prop="mha006" label="当日生产数"/>
        <el-table-column prop="mha007" label="累计完成数"/>
        <el-table-column prop="mha008" label="生产组别"/>
        <el-table-column prop="mha009" label="卡号"/>
        <el-table-column prop="mha010" label="不良症状"/>
        <el-table-column prop="mha011" label="检出工程">
          <template #default="scope">
            <dict-tag :options=" options.sql_insp_eng " :value="scope.row.mha011"  />
          </template>
        </el-table-column>
        <el-table-column prop="mha012" label="不良原因"/>
        <el-table-column prop="mha013" label="不良数量"/>
        <el-table-column prop="mha014" label="累计不良台数"/>
        <el-table-column prop="mha015" label="责任归属">
          <template #default="scope">
            <dict-tag :options=" options.sql_resp_bel " :value="scope.row.mha015"  />
          </template>
        </el-table-column>
        <el-table-column prop="mha016" label="不良性质">
          <template #default="scope">
            <dict-tag :options=" options.sql_bad_prop " :value="scope.row.mha016"  />
          </template>
        </el-table-column>
        <el-table-column prop="mha017" label="序列号"/>
        <el-table-column prop="mha018" label="修理">
          <template #default="scope">
            <dict-tag :options=" options.sql_repair_list " :value="scope.row.mha018"  />
          </template>
        </el-table-column>
        <el-table-column prop="remark" label="备注"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改修理对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="mga002">
              <el-date-picker v-model="form.mga002" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产机种" prop="mga003">
              <el-input   v-model="form.mga003" :placeholder="$t('btn.enterPrefix')+'生产机种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产订单" prop="mga004">
              <el-input   v-model="form.mga004" :placeholder="$t('btn.enterPrefix')+'生产订单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产LOT" prop="mga005">
              <el-input   v-model="form.mga005" :placeholder="$t('btn.enterPrefix')+'生产LOT'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="订单台数" prop="mga006">
              <el-input-number v-model.number="form.mga006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'订单台数'+$t('btn.enterSuffix')" />
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


    <!-- 子表信息 -->
        <el-divider content-position="center">修理明细</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpRepairPcbaSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpRepairPcbaSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppRepairPcbaSlvList" :row-class-name="rowPpRepairPcbaSlvIndex" @selection-change="handlePpRepairPcbaSlvSelectionChange" ref="PpRepairPcbaSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="批次" align="center" prop="mha003">
            <template #default="scope">
              <el-input v-model="scope.row.mha003" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="板别" prop="mha004">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mha004" :placeholder="$t('btn.enterPrefix')+'板别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="Lot数" align="center" prop="mha005" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mha005" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="当日生产数" align="center" prop="mha006" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mha006" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当日生产数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="累计完成数" align="center" prop="mha007" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mha007" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计完成数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生产组别" align="center" prop="mha008">
            <template #default="scope">
              <el-input v-model="scope.row.mha008" :placeholder="$t('btn.enterPrefix')+'生产组别'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="卡号" align="center" prop="mha009">
            <template #default="scope">
              <el-input v-model="scope.row.mha009" :placeholder="$t('btn.enterPrefix')+'卡号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良症状" align="center" prop="mha010">
            <template #default="scope">
              <el-input v-model="scope.row.mha010" :placeholder="$t('btn.enterPrefix')+'不良症状'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="检出工程" prop="mha011">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mha011" :placeholder="$t('btn.enterPrefix')+'检出工程'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_insp_eng" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="不良原因" align="center" prop="mha012">
            <template #default="scope">
              <el-input v-model="scope.row.mha012" :placeholder="$t('btn.enterPrefix')+'不良原因'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良数量" align="center" prop="mha013" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mha013" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="累计不良台数" align="center" prop="mha014" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mha014" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计不良台数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="责任归属" prop="mha015">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mha015" :placeholder="$t('btn.enterPrefix')+'责任归属'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_resp_bel" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="不良性质" prop="mha016">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mha016" :placeholder="$t('btn.enterPrefix')+'不良性质'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_bad_prop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="序列号" align="center" prop="mha017">
            <template #default="scope">
              <el-input v-model="scope.row.mha017" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="修理" prop="mha018">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mha018" :placeholder="$t('btn.enterPrefix')+'修理'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_repair_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
        </el-table>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="pprepairpcbama">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpRepairPcbaMa,
 addPpRepairPcbaMa, delPpRepairPcbaMa, 
 updatePpRepairPcbaMa,getPpRepairPcbaMa, 
 } 
from '@/api/logistics/pprepairpcbama.js'
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
  sort: 'Mga002',
  sortType: 'desc',
  //是否查询（1是）
  mga002: undefined,
  //是否查询（1是）
  mga003: undefined,
  //是否查询（1是）
  mga004: undefined,
  //是否查询（1是）
  mga005: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mga002', label: '生产日期' },
  { visible: true, prop: 'mga003', label: '生产机种' },
  { visible: true, prop: 'mga004', label: '生产订单' },
  { visible: true, prop: 'mga005', label: '生产LOT' },
  { visible: true, prop: 'mga006', label: '订单台数' },
  { visible: true, prop: 'remark', label: '备注' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
// 生产日期时间范围
const dateRangeMga002 = ref([])

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
//API获取从修理/pp_repair_pcba_ma表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMga002.value, 'Mga002');
  loading.value = true
  listPpRepairPcbaMa(queryParams).then(res => {
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
  // 生产日期时间范围
  dateRangeMga002.value = []
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
    mga004: [{ required: true, message: "生产订单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mga006: [{ required: true, message: "订单台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
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
    mga002: null,
    mga003: null,
    mga004: null,
    mga005: null,
    mga006: 0,
    remark: null,
  };
  ppRepairPcbaSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'修理'
  opertype.value = 1
  form.value.mga002= new Date()
  form.value.mga006= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpRepairPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '修理'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppRepairPcbaSlvList.value = res.data.ppRepairPcbaSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppRepairPcbaSlvNav = ppRepairPcbaSlvList.value
      if (form.value.id != undefined && opertype.value === 2) {
        updatePpRepairPcbaMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpRepairPcbaMa(form.value).then((res) => {
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
      return delPpRepairPcbaMa(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<修理.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpRepairPcbaMa/export', { ...queryParams })
    })
}

/*********************修理明细子表信息*************************/
const ppRepairPcbaSlvList = ref([])
const checkedPpRepairPcbaSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 修理明细序号 */
function rowPpRepairPcbaSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 修理明细添加按钮操作 */
function handleAddPpRepairPcbaSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.mha003 = null;
  //obj.mha004 = null;
  //obj.mha005 = null;
  //obj.mha006 = null;
  //obj.mha007 = null;
  //obj.mha008 = null;
  //obj.mha009 = null;
  //obj.mha010 = null;
  //obj.mha011 = null;
  //obj.mha012 = null;
  //obj.mha013 = null;
  //obj.mha014 = null;
  //obj.mha015 = null;
  //obj.mha016 = null;
  //obj.mha017 = null;
  //obj.mha018 = null;
  //obj.remark = null;
  ppRepairPcbaSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpRepairPcbaSlvSelectionChange(selection) {
  checkedPpRepairPcbaSlv.value = selection.map(item => item.index)
}

/** 修理明细删除按钮操作 */
function handleDeletePpRepairPcbaSlv() {
  if(checkedPpRepairPcbaSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的修理明细数据')
  } else {
    const PpRepairPcbaSlvs = ppRepairPcbaSlvList.value;
    const checkedPpRepairPcbaSlvs = checkedPpRepairPcbaSlv.value;
    ppRepairPcbaSlvList.value = PpRepairPcbaSlvs.filter(function(item) {
      return checkedPpRepairPcbaSlvs.indexOf(item.index) == -1
    });
  }
}

/** 修理明细详情 */
function rowClick(row) {
  const id = row.id || ids.value
  getPpRepairPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppRepairPcbaSlvList.value = data.ppRepairPcbaSlvNav
    }
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