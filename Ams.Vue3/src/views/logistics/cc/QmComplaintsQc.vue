<!--
 * @Descripttion: QC客诉/qm_complaints_qc
 * @Version: 0.24.620.25140
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 15:13:49
 * @column：42
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂代码" prop="mb002">
        <el-select filterable clearable   v-model="queryParams.mb002" :placeholder="$t('btn.selectSearchPrefix')+'工厂代码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客诉No." prop="mb003">
        <el-input v-model="queryParams.mb003" :placeholder="$t('btn.enterSearchPrefix')+'客诉No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="外部客诉No." prop="mb004">
        <el-input v-model="queryParams.mb004" :placeholder="$t('btn.enterSearchPrefix')+'外部客诉No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="客户" prop="mb005">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_cus_list" :loading="loading" v-model="queryParams.mb005" :placeholder="$t('btn.selectSearchPrefix')+'客户'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="机种" prop="mb006">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_sap_model" :loading="loading" v-model="queryParams.mb006" :placeholder="$t('btn.selectSearchPrefix')+'机种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_sap_model " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="mb007">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list" :loading="loading" v-model="queryParams.mb007" :placeholder="$t('btn.selectSearchPrefix')+'物料'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="接收日期">
        <el-date-picker
          v-model="dateRangeMb010" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
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
        <el-button class="btn-add" v-hasPermi="['qm:complaintsqc:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:complaintsqc:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:complaintsqc:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:complaintsqc:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmComplaintsQc/importTemplate"
                  importUrl="/Logistics/QmComplaintsQc/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:complaintsqc:export']">
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
      <el-table-column prop="mb002" label="工厂代码" align="center" v-if="columns.showColumn('mb002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mb002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb003" label="客诉No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb003')"/>
      <el-table-column prop="mb004" label="外部客诉No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb004')"/>
      <el-table-column prop="mb005" label="客户" align="center" v-if="columns.showColumn('mb005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.mb005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb006" label="机种" align="center" v-if="columns.showColumn('mb006')">
        <template #default="scope">
          <dict-tag :options=" options.sql_sap_model " :value="scope.row.mb006"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb007" label="物料" align="center" v-if="columns.showColumn('mb007')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.mb007"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb008" label="仕向" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb008')"/>
      <el-table-column prop="mb009" label="订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb009')"/>
      <el-table-column prop="mb010" label="接收日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mb010')"/>
      <el-table-column prop="mb011" label="数量" align="center" v-if="columns.showColumn('mb011')"/>
      <el-table-column prop="mb012" label="投诉事项" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb012')"/>
      <el-table-column prop="mb013" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb013')"/>
      <el-table-column prop="mb014" label="参考文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb014')"/>
      <el-table-column prop="mb015" label="症状" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb015')"/>
      <el-table-column prop="mb016" label="分析" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb016')"/>
      <el-table-column prop="mb017" label="承认部门" align="center" v-if="columns.showColumn('mb017')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_name " :value="scope.row.mb017"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb018" label="承认日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mb018')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:complaintsqc:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:complaintsqc:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改QC客诉对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂代码" prop="mb002">
              <el-select filterable clearable   v-model="form.mb002"  :placeholder="$t('btn.selectPrefix')+'工厂代码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客诉No." prop="mb003">
              <el-input   v-model="form.mb003" :placeholder="$t('btn.enterPrefix')+'客诉No.'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部客诉No." prop="mb004">
              <el-input   v-model="form.mb004" :placeholder="$t('btn.enterPrefix')+'外部客诉No.'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户" prop="mb005">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_cus_list" 
              :loading="loading" v-model="form.mb005"  :placeholder="$t('btn.selectPrefix')+'客户'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="机种" prop="mb006">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_sap_model" 
              :loading="loading" v-model="form.mb006"  :placeholder="$t('btn.selectPrefix')+'机种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_sap_model" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料" prop="mb007">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list" 
              :loading="loading" v-model="form.mb007"  :placeholder="$t('btn.selectPrefix')+'物料'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_mats_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="仕向" prop="mb008">
              <el-input   v-model="form.mb008" :placeholder="$t('btn.enterPrefix')+'仕向'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单" prop="mb009">
              <el-input   v-model="form.mb009" :placeholder="$t('btn.enterPrefix')+'订单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="接收日期" prop="mb010">
              <el-date-picker v-model="form.mb010" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="数量" prop="mb011">
              <el-input-number v-model.number="form.mb011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投诉事项" prop="mb012">
              <el-input  type="textarea"  v-model="form.mb012" :placeholder="$t('btn.enterPrefix')+'投诉事项'+$t('btn.enterSuffix')"  show-word-limit maxlength="8000" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="mb013">
              <el-input   v-model="form.mb013" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="参考文件" prop="mb014">
              <UploadFile v-model="form.mb014" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="症状" prop="mb015">
              <el-input  type="textarea"  v-model="form.mb015" :placeholder="$t('btn.enterPrefix')+'症状'+$t('btn.enterSuffix')"  show-word-limit maxlength="8000" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分析" prop="mb016">
              <el-input  type="textarea"  v-model="form.mb016" :placeholder="$t('btn.enterPrefix')+'分析'+$t('btn.enterSuffix')"  show-word-limit maxlength="8000" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认部门" prop="mb017">
              <el-select filterable clearable   v-model="form.mb017"  :placeholder="$t('btn.selectPrefix')+'承认部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_name" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="承认日期" prop="mb018">
              <el-date-picker v-model="form.mb018" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="qmcomplaintsqc">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmComplaintsQc,
 addQmComplaintsQc, delQmComplaintsQc, 
 updateQmComplaintsQc,getQmComplaintsQc, 
 } 
from '@/api/logistics/qmcomplaintsqc.js'
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
  sort: 'Mb010',
  sortType: 'desc',
  //是否查询（1是）
  mb002: undefined,
  //是否查询（1是）
  mb003: undefined,
  //是否查询（1是）
  mb004: undefined,
  //是否查询（1是）
  mb005: undefined,
  //是否查询（1是）
  mb006: undefined,
  //是否查询（1是）
  mb007: undefined,
  //是否查询（1是）
  mb010: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mb002', label: '工厂代码' },
  { visible: true, prop: 'mb003', label: '客诉No.' },
  { visible: true, prop: 'mb004', label: '外部客诉No.' },
  { visible: true, prop: 'mb005', label: '客户' },
  { visible: true, prop: 'mb006', label: '机种' },
  { visible: true, prop: 'mb007', label: '物料' },
  { visible: true, prop: 'mb008', label: '仕向' },
  { visible: false, prop: 'mb009', label: '订单' },
  { visible: false, prop: 'mb010', label: '接收日期' },
  { visible: false, prop: 'mb011', label: '数量' },
  { visible: false, prop: 'mb012', label: '投诉事项' },
  { visible: false, prop: 'mb013', label: '序列号' },
  { visible: false, prop: 'mb014', label: '参考文件' },
  { visible: false, prop: 'mb015', label: '症状' },
  { visible: false, prop: 'mb016', label: '分析' },
  { visible: false, prop: 'mb017', label: '承认部门' },
  { visible: false, prop: 'mb018', label: '承认日期' },
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
//定义远程搜索变量
const remotequeryList_sql_cus_list=ref([])
//定义远程搜索变量
const remotequery_sql_cus_list=ref([])
//远程字典参数
var remotedictParams_sql_cus_list = [
    { dictType: "sql_cus_list" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_cus_list).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_cus_list.value = element.list
      })
      //console.log(remotequeryList_sql_cus_list)
    })
  })
//远程搜索
const remoteMethod_sql_cus_list = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_cus_list.value = remotequeryList_sql_cus_list.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_cus_list(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_cus_list.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_cus_list = debounce((query) => {
    let arr = remotequeryList_sql_cus_list.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_cus_list.value = arr.slice(0, 5)
      addFilterOptions_sql_cus_list(query)
    } else {
      remotequery_sql_cus_list.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_cus_list =debounce((dictValue) => {
    let target = remotequeryList_sql_cus_list.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_cus_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_cus_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
//定义远程搜索变量
const remotequeryList_sql_sap_model=ref([])
//定义远程搜索变量
const remotequery_sql_sap_model=ref([])
//远程字典参数
var remotedictParams_sql_sap_model = [
    { dictType: "sql_sap_model" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_sap_model).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_sap_model.value = element.list
      })
      //console.log(remotequeryList_sql_sap_model)
    })
  })
//远程搜索
const remoteMethod_sql_sap_model = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_sap_model.value = remotequeryList_sql_sap_model.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_sap_model(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_sap_model.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_sap_model = debounce((query) => {
    let arr = remotequeryList_sql_sap_model.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_sap_model.value = arr.slice(0, 5)
      addFilterOptions_sql_sap_model(query)
    } else {
      remotequery_sql_sap_model.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_sap_model =debounce((dictValue) => {
    let target = remotequeryList_sql_sap_model.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_sap_model.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_sap_model.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
//定义远程搜索变量
const remotequeryList_sql_mats_list=ref([])
//定义远程搜索变量
const remotequery_sql_mats_list=ref([])
//远程字典参数
var remotedictParams_sql_mats_list = [
    { dictType: "sql_mats_list" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_mats_list).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_mats_list.value = element.list
      })
      //console.log(remotequeryList_sql_mats_list)
    })
  })
//远程搜索
const remoteMethod_sql_mats_list = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_mats_list.value = remotequeryList_sql_mats_list.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_mats_list(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_mats_list.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_mats_list = debounce((query) => {
    let arr = remotequeryList_sql_mats_list.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_mats_list.value = arr.slice(0, 5)
      addFilterOptions_sql_mats_list(query)
    } else {
      remotequery_sql_mats_list.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_mats_list =debounce((dictValue) => {
    let target = remotequeryList_sql_mats_list.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_mats_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_mats_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
// 接收日期时间范围
const dateRangeMb010 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sql_cus_list" },
  { dictType: "sql_sap_model" },
  { dictType: "sql_mats_list" },
  { dictType: "sql_dept_name" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从QC客诉/qm_complaints_qc表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMb010.value, 'Mb010');
  loading.value = true
  listQmComplaintsQc(queryParams).then(res => {
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
  // 接收日期时间范围
  dateRangeMb010.value = []
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
    mb002: [{ required: true, message: "工厂代码"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb003: [{ required: true, message: "客诉No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb004: [{ required: true, message: "外部客诉No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb005: [{ required: true, message: "客户"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb011: [{ required: true, message: "数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 工厂代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 客户 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_cus_list: [],
    // 机种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_sap_model: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_mats_list: [],
    // 承认部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_name: [],
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
    mb002: [],
    mb003: null,
    mb004: null,
    mb005: [],
    mb006: [],
    mb007: [],
    mb008: null,
    mb009: null,
    mb010: null,
    mb011: 0,
    mb012: null,
    mb013: null,
    mb014: null,
    mb015: null,
    mb016: null,
    mb017: [],
    mb018: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'QC客诉'
  opertype.value = 1
  form.value.mb002= []
  form.value.mb005= []
  form.value.mb006= []
  form.value.mb007= []
  form.value.mb010= new Date()
  form.value.mb011= 0
  form.value.mb017= []
  form.value.mb018= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getQmComplaintsQc(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ 'QC客诉'
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
        updateQmComplaintsQc(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmComplaintsQc(form.value).then((res) => {
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
      return delQmComplaintsQc(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<QC客诉.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmComplaintsQc/export', { ...queryParams })
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