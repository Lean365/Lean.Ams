<!--
 * @Descripttion: 进料检验/qm_incoming
 * @Version: 0.24.620.29565
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 16:45:51
 * @column：42
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="mf002">
        <el-select filterable clearable   v-model="queryParams.mf002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购订单" prop="mf003">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_marb_pur" :loading="loading" v-model="queryParams.mf003" :placeholder="$t('btn.selectSearchPrefix')+'采购订单'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_marb_pur " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="mf004">
        <el-input v-model="queryParams.mf004" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="检验日期">
        <el-date-picker
          v-model="dateRangeMf008" 
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
        <el-button class="btn-add" v-hasPermi="['qm:incoming:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:incoming:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:incoming:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:incoming:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmIncoming/importTemplate"
                  importUrl="/Logistics/QmIncoming/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:incoming:export']">
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
      <el-table-column prop="mf002" label="工厂" align="center" v-if="columns.showColumn('mf002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mf002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf003" label="采购订单" align="center" v-if="columns.showColumn('mf003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_marb_pur " :value="scope.row.mf003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf004" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf004')"/>
      <el-table-column prop="mf005" label="数量" align="center" v-if="columns.showColumn('mf005')"/>
      <el-table-column prop="mf006" label="进货日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mf006')"/>
      <el-table-column prop="mf007" label="检验员" align="center" v-if="columns.showColumn('mf007')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_list " :value="scope.row.mf007"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf008" label="检验日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mf008')"/>
      <el-table-column prop="mf009" label="检验项目" align="center" v-if="columns.showColumn('mf009')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_item " :value="scope.row.mf009"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf010" label="检验水准" align="center" v-if="columns.showColumn('mf010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_level " :value="scope.row.mf010"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf011" label="检验方式" align="center" v-if="columns.showColumn('mf011')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_method " :value="scope.row.mf011"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf012" label="抽样数" align="center" v-if="columns.showColumn('mf012')"/>
      <el-table-column prop="mf013" label="判定" align="center" v-if="columns.showColumn('mf013')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_judge " :value="scope.row.mf013"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf014" label="不良级别" align="center" v-if="columns.showColumn('mf014')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_bad " :value="scope.row.mf014"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf015" label="验退数" align="center" v-if="columns.showColumn('mf015')"/>
      <el-table-column prop="mf016" label="特记事项" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf016')"/>
      <el-table-column prop="mf017" label="验收数量" align="center" v-if="columns.showColumn('mf017')"/>
      <el-table-column prop="mf018" label="检验次数" align="center" v-if="columns.showColumn('mf018')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:incoming:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:incoming:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改进料检验对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂" prop="mf002">
              <el-select filterable clearable   v-model="form.mf002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购订单" prop="mf003">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_marb_pur" 
              :loading="loading" v-model="form.mf003"  :placeholder="$t('btn.selectPrefix')+'采购订单'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_marb_pur" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料" prop="mf004">
              <el-input   v-model="form.mf004" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="mf005">
              <el-input-number v-model.number="form.mf005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="进货日期" prop="mf006">
              <el-date-picker v-model="form.mf006" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验员" prop="mf007">
              <el-select filterable clearable   v-model="form.mf007"  :placeholder="$t('btn.selectPrefix')+'检验员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验日期" prop="mf008">
              <el-date-picker v-model="form.mf008" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验项目" prop="mf009">
              <el-select filterable clearable   v-model="form.mf009"  :placeholder="$t('btn.selectPrefix')+'检验项目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_item" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验水准" prop="mf010">
              <el-select filterable clearable   v-model="form.mf010"  :placeholder="$t('btn.selectPrefix')+'检验水准'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_level" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验方式" prop="mf011">
              <el-select filterable clearable   v-model="form.mf011"  :placeholder="$t('btn.selectPrefix')+'检验方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="抽样数" prop="mf012">
              <el-input-number v-model.number="form.mf012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'抽样数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="判定" prop="mf013">
              <el-select filterable clearable   v-model="form.mf013"  :placeholder="$t('btn.selectPrefix')+'判定'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_judge" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="不良级别" prop="mf014">
              <el-select filterable clearable   v-model="form.mf014"  :placeholder="$t('btn.selectPrefix')+'不良级别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_bad" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="验退数" prop="mf015">
              <el-input-number v-model.number="form.mf015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验退数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记事项" prop="mf016">
              <el-input type="textarea" v-model="form.mf016" :placeholder="$t('btn.enterPrefix')+'特记事项'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="验收数量" prop="mf017">
              <el-input-number v-model.number="form.mf017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验收数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检验次数" prop="mf018">
              <el-input-number v-model.number="form.mf018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检验次数'+$t('btn.enterSuffix')" />
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

<script setup name="qmincoming">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmIncoming,
 addQmIncoming, delQmIncoming, 
 updateQmIncoming,getQmIncoming, 
 } 
from '@/api/logistics/qmincoming.js'
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
  sort: 'Mf006',
  sortType: 'desc',
  //是否查询（1是）
  mf002: undefined,
  //是否查询（1是）
  mf003: undefined,
  //是否查询（1是）
  mf004: undefined,
  //是否查询（1是）
  mf008: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mf002', label: '工厂' },
  { visible: true, prop: 'mf003', label: '采购订单' },
  { visible: true, prop: 'mf004', label: '物料' },
  { visible: true, prop: 'mf005', label: '数量' },
  { visible: true, prop: 'mf006', label: '进货日期' },
  { visible: true, prop: 'mf007', label: '检验员' },
  { visible: true, prop: 'mf008', label: '检验日期' },
  { visible: false, prop: 'mf009', label: '检验项目' },
  { visible: false, prop: 'mf010', label: '检验水准' },
  { visible: false, prop: 'mf011', label: '检验方式' },
  { visible: false, prop: 'mf012', label: '抽样数' },
  { visible: false, prop: 'mf013', label: '判定' },
  { visible: false, prop: 'mf014', label: '不良级别' },
  { visible: false, prop: 'mf015', label: '验退数' },
  { visible: false, prop: 'mf016', label: '特记事项' },
  { visible: false, prop: 'mf017', label: '验收数量' },
  { visible: false, prop: 'mf018', label: '检验次数' },
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
const remotequeryList_sql_marb_pur=ref([])
//定义远程搜索变量
const remotequery_sql_marb_pur=ref([])
//远程字典参数
var remotedictParams_sql_marb_pur = [
    { dictType: "sql_marb_pur" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_marb_pur).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_marb_pur.value = element.list
      })
      //console.log(remotequeryList_sql_marb_pur)
    })
  })
//远程搜索
const remoteMethod_sql_marb_pur = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_marb_pur.value = remotequeryList_sql_marb_pur.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_marb_pur(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_marb_pur.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_marb_pur = debounce((query) => {
    let arr = remotequeryList_sql_marb_pur.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_marb_pur.value = arr.slice(0, 5)
      addFilterOptions_sql_marb_pur(query)
    } else {
      remotequery_sql_marb_pur.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_marb_pur =debounce((dictValue) => {
    let target = remotequeryList_sql_marb_pur.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_marb_pur.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_marb_pur.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
// 检验日期时间范围
const dateRangeMf008 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sql_marb_pur" },
  { dictType: "sql_insp_list" },
  { dictType: "sql_insp_item" },
  { dictType: "sys_insp_level" },
  { dictType: "sys_insp_method" },
  { dictType: "sys_insp_judge" },
  { dictType: "sys_insp_bad" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从进料检验/qm_incoming表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMf008.value, 'Mf008');
  loading.value = true
  listQmIncoming(queryParams).then(res => {
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
  // 检验日期时间范围
  dateRangeMf008.value = []
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
    mf002: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mf003: [{ required: true, message: "采购订单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mf005: [{ required: true, message: "数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mf012: [{ required: true, message: "抽样数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mf015: [{ required: true, message: "验退数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mf017: [{ required: true, message: "验收数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mf018: [{ required: true, message: "检验次数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 采购订单 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_marb_pur: [],
    // 检验员 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_insp_list: [],
    // 检验项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_insp_item: [],
    // 检验水准 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_level: [],
    // 检验方式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_method: [],
    // 判定 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_judge: [],
    // 不良级别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_bad: [],
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
    mf002: [],
    mf003: [],
    mf004: null,
    mf005: 0,
    mf006: null,
    mf007: [],
    mf008: null,
    mf009: [],
    mf010: [],
    mf011: [],
    mf012: 0,
    mf013: [],
    mf014: [],
    mf015: 0,
    mf016: null,
    mf017: 0,
    mf018: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'进料检验'
  opertype.value = 1
  form.value.mf002= []
  form.value.mf003= []
  form.value.mf005= 0
  form.value.mf006= new Date()
  form.value.mf007= []
  form.value.mf008= new Date()
  form.value.mf009= []
  form.value.mf010= []
  form.value.mf011= []
  form.value.mf012= 0
  form.value.mf013= []
  form.value.mf014= []
  form.value.mf015= 0
  form.value.mf017= 0
  form.value.mf018= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getQmIncoming(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '进料检验'
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
        updateQmIncoming(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmIncoming(form.value).then((res) => {
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
      return delQmIncoming(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<进料检验.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmIncoming/export', { ...queryParams })
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