<!--
 * @Descripttion: 销售价格/sd_selling_price
 * @Version: 0.24.620.27469
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 15:46:00
 * @column：40
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="md002">
        <el-select filterable clearable   v-model="queryParams.md002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="期间" prop="md003">
        <el-select filterable clearable   v-model="queryParams.md003" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="md004">
        <el-select filterable clearable   v-model="queryParams.md004" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="md005">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list" :loading="loading" v-model="queryParams.md005" :placeholder="$t('btn.selectSearchPrefix')+'物料'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="原币利润中心" prop="md010">
        <el-select filterable clearable   v-model="queryParams.md010" :placeholder="$t('btn.selectSearchPrefix')+'原币利润中心'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['sd:sellingprice:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sd:sellingprice:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sd:sellingprice:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sd:sellingprice:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/SdSellingPrice/importTemplate"
                  importUrl="/Logistics/SdSellingPrice/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['sd:sellingprice:export']">
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
      <el-table-column prop="md002" label="工厂" align="center" v-if="columns.showColumn('md002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.md002"  />
        </template>
      </el-table-column>
      <el-table-column prop="md003" label="期间" align="center" v-if="columns.showColumn('md003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.md003"  />
        </template>
      </el-table-column>
      <el-table-column prop="md004" label="年月" align="center" v-if="columns.showColumn('md004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.md004"  />
        </template>
      </el-table-column>
      <el-table-column prop="md005" label="物料" align="center" v-if="columns.showColumn('md005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.md005"  />
        </template>
      </el-table-column>
      <el-table-column prop="md006" label="物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md006')"/>
      <el-table-column prop="md007" label="原币价格" align="center" v-if="columns.showColumn('md007')"/>
      <el-table-column prop="md008" label="原币种" align="center" v-if="columns.showColumn('md008')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.md008"  />
        </template>
      </el-table-column>
      <el-table-column prop="md009" label="原币Per单位" align="center" v-if="columns.showColumn('md009')"/>
      <el-table-column prop="md010" label="原币利润中心" align="center" v-if="columns.showColumn('md010')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.md010"  />
        </template>
      </el-table-column>
      <el-table-column prop="md011" label="本币价格" align="center" v-if="columns.showColumn('md011')"/>
      <el-table-column prop="md012" label="本币种" align="center" v-if="columns.showColumn('md012')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.md012"  />
        </template>
      </el-table-column>
      <el-table-column prop="md013" label="本币Per单位" align="center" v-if="columns.showColumn('md013')"/>
      <el-table-column prop="md014" label="本币利润中心" align="center" v-if="columns.showColumn('md014')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.md014"  />
        </template>
      </el-table-column>
      <el-table-column prop="md015" label="生效日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md015')"/>
      <el-table-column prop="md016" label="失效日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md016')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['sd:sellingprice:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['sd:sellingprice:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改销售价格对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂" prop="md002">
              <el-select filterable clearable   v-model="form.md002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="期间" prop="md003">
              <el-select filterable clearable   v-model="form.md003"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="md004">
              <el-select filterable clearable   v-model="form.md004"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料" prop="md005">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list" 
              :loading="loading" v-model="form.md005"  :placeholder="$t('btn.selectPrefix')+'物料'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_mats_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料文本" prop="md006">
              <el-input   v-model="form.md006" :placeholder="$t('btn.enterPrefix')+'物料文本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币价格" prop="md007">
              <el-input-number v-model.number="form.md007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'原币价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币种" prop="md008">
              <el-select filterable clearable   v-model="form.md008"  :placeholder="$t('btn.selectPrefix')+'原币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="原币Per单位" prop="md009">
              <el-input-number v-model.number="form.md009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'原币Per单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币利润中心" prop="md010">
              <el-select filterable clearable   v-model="form.md010"  :placeholder="$t('btn.selectPrefix')+'原币利润中心'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="本币价格" prop="md011">
              <el-input-number v-model.number="form.md011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'本币价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币种" prop="md012">
              <el-select filterable clearable   v-model="form.md012"  :placeholder="$t('btn.selectPrefix')+'本币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="本币Per单位" prop="md013">
              <el-input-number v-model.number="form.md013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'本币Per单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币利润中心" prop="md014">
              <el-select filterable clearable   v-model="form.md014"  :placeholder="$t('btn.selectPrefix')+'本币利润中心'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="生效日期" prop="md015">
              <el-date-picker v-model="form.md015" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="失效日期" prop="md016">
              <el-date-picker v-model="form.md016" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="sdsellingprice">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listSdSellingPrice,
 addSdSellingPrice, delSdSellingPrice, 
 updateSdSellingPrice,getSdSellingPrice, 
 } 
from '@/api/logistics/sdsellingprice.js'
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
  sort: 'Md003',
  sortType: 'desc',
  //是否查询（1是）
  md002: undefined,
  //是否查询（1是）
  md003: undefined,
  //是否查询（1是）
  md004: undefined,
  //是否查询（1是）
  md005: undefined,
  //是否查询（1是）
  md010: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'md002', label: '工厂' },
  { visible: true, prop: 'md003', label: '期间' },
  { visible: true, prop: 'md004', label: '年月' },
  { visible: true, prop: 'md005', label: '物料' },
  { visible: true, prop: 'md006', label: '物料文本' },
  { visible: true, prop: 'md007', label: '原币价格' },
  { visible: true, prop: 'md008', label: '原币种' },
  { visible: false, prop: 'md009', label: '原币Per单位' },
  { visible: false, prop: 'md010', label: '原币利润中心' },
  { visible: false, prop: 'md011', label: '本币价格' },
  { visible: false, prop: 'md012', label: '本币种' },
  { visible: false, prop: 'md013', label: '本币Per单位' },
  { visible: false, prop: 'md014', label: '本币利润中心' },
  { visible: false, prop: 'md015', label: '生效日期' },
  { visible: false, prop: 'md016', label: '失效日期' },
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

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sql_attr_list" },
  { dictType: "sql_ymdt_list" },
  { dictType: "sql_mats_list" },
  { dictType: "sql_global_currency" },
  { dictType: "sql_prctr_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从销售价格/sd_selling_price表记录数据
function getList(){
  loading.value = true
  listSdSellingPrice(queryParams).then(res => {
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
    md007: [{ required: true, message: "原币价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md009: [{ required: true, message: "原币Per单位"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md011: [{ required: true, message: "本币价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md013: [{ required: true, message: "本币Per单位"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ymdt_list: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_mats_list: [],
    // 原币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_currency: [],
    // 原币利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_prctr_list: [],
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
    md002: [],
    md003: [],
    md004: [],
    md005: [],
    md006: null,
    md007: 0,
    md008: [],
    md009: 0,
    md010: [],
    md011: 0,
    md012: [],
    md013: 0,
    md014: [],
    md015: null,
    md016: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'销售价格'
  opertype.value = 1
  form.value.md002= []
  form.value.md003= []
  form.value.md004= []
  form.value.md005= []
  form.value.md007= 0
  form.value.md008= []
  form.value.md009= 0
  form.value.md010= []
  form.value.md011= 0
  form.value.md012= []
  form.value.md013= 0
  form.value.md014= []
  form.value.md015= new Date()
  form.value.md016= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getSdSellingPrice(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '销售价格'
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
        updateSdSellingPrice(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addSdSellingPrice(form.value).then((res) => {
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
      return delSdSellingPrice(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<销售价格.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/SdSellingPrice/export', { ...queryParams })
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