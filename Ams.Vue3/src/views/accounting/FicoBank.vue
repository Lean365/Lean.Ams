<!--
 * @Descripttion: 银行/fico_bank
 * @Version: 0.24.614.28099
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 15:43:04
 * @column：43
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="关联对象" prop="mc003">
        <el-input v-model="queryParams.mc003" :placeholder="$t('btn.enterSearchPrefix')+'关联对象'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="银行代码" prop="mc004">
        <el-input v-model="queryParams.mc004" :placeholder="$t('btn.enterSearchPrefix')+'银行代码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="银行名称" prop="mc005">
        <el-input v-model="queryParams.mc005" :placeholder="$t('btn.enterSearchPrefix')+'银行名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="分行名称" prop="mc006">
        <el-input v-model="queryParams.mc006" :placeholder="$t('btn.enterSearchPrefix')+'分行名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="银行所在国" prop="mc007">
        <el-select filterable clearable   v-model="queryParams.mc007" :placeholder="$t('btn.selectSearchPrefix')+'银行所在国'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="所在州省" prop="mc008">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" :loading="loading" v-model="queryParams.mc008" :placeholder="$t('btn.selectSearchPrefix')+'所在州省'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_global_state " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['fico:bank:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:bank:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:bank:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:bank:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBank/importTemplate"
                  importUrl="/Accounting/FicoBank/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:bank:export']">
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
      <el-table-column prop="mc002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc002')"/>
      <el-table-column prop="mc003" label="关联对象" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc003')"/>
      <el-table-column prop="mc004" label="银行代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc004')"/>
      <el-table-column prop="mc005" label="银行名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc005')"/>
      <el-table-column prop="mc006" label="分行名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc006')"/>
      <el-table-column prop="mc007" label="银行所在国" align="center" v-if="columns.showColumn('mc007')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.mc007"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc008" label="所在州省" align="center" v-if="columns.showColumn('mc008')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_state " :value="scope.row.mc008"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc009" label="所在市" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc009')"/>
      <el-table-column prop="mc010" label="所在县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc010')"/>
      <el-table-column prop="mc011" label="地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc011')"/>
      <el-table-column prop="mc012" label="地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc012')"/>
      <el-table-column prop="mc013" label="地址3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc013')"/>
      <el-table-column prop="mc014" label="邮政编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc014')"/>
      <el-table-column prop="mc015" label="地址号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc015')"/>
      <el-table-column prop="mc016" label="银行账号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc016')"/>
      <el-table-column prop="mc017" label="持有人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc017')"/>
      <el-table-column prop="mc018" label="SWIFT代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc018')"/>
      <el-table-column prop="mc019" label="交易冻结" align="center" v-if="columns.showColumn('mc019')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.mc019"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:bank:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:bank:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改银行对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="mc002">
              <el-input v-model="form.mc002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关联对象" prop="mc003">
              <el-input v-model="form.mc003" :placeholder="$t('btn.enterPrefix')+'关联对象'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行代码" prop="mc004">
              <el-input v-model="form.mc004" :placeholder="$t('btn.enterPrefix')+'银行代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="80"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行名称" prop="mc005">
              <el-input v-model="form.mc005" :placeholder="$t('btn.enterPrefix')+'银行名称'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分行名称" prop="mc006">
              <el-input v-model="form.mc006" :placeholder="$t('btn.enterPrefix')+'分行名称'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行所在国" prop="mc007">
              <el-select filterable clearable   v-model="form.mc007"  :placeholder="$t('btn.selectPrefix')+'银行所在国'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_country" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="所在州省" prop="mc008">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" 
              :loading="loading" v-model="form.mc008"  :placeholder="$t('btn.selectPrefix')+'所在州省'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="所在市" prop="mc009">
              <el-input v-model="form.mc009" :placeholder="$t('btn.enterPrefix')+'所在市'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="所在县" prop="mc010">
              <el-input v-model="form.mc010" :placeholder="$t('btn.enterPrefix')+'所在县'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址1" prop="mc011">
              <el-input v-model="form.mc011" :placeholder="$t('btn.enterPrefix')+'地址1'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址2" prop="mc012">
              <el-input v-model="form.mc012" :placeholder="$t('btn.enterPrefix')+'地址2'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址3" prop="mc013">
              <el-input v-model="form.mc013" :placeholder="$t('btn.enterPrefix')+'地址3'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮政编码" prop="mc014">
              <el-input v-model="form.mc014" :placeholder="$t('btn.enterPrefix')+'邮政编码'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址号码" prop="mc015">
              <el-input v-model="form.mc015" :placeholder="$t('btn.enterPrefix')+'地址号码'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行账号" prop="mc016">
              <el-input v-model="form.mc016" :placeholder="$t('btn.enterPrefix')+'银行账号'+$t('btn.enterSuffix')"  show-word-limit maxlength="21"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="持有人" prop="mc017">
              <el-input v-model="form.mc017" :placeholder="$t('btn.enterPrefix')+'持有人'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SWIFT代码" prop="mc018">
              <el-input v-model="form.mc018" :placeholder="$t('btn.enterPrefix')+'SWIFT代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="11"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="交易冻结" prop="mc019">
              <el-radio-group v-model="form.mc019">
                <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
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

<script setup name="ficobank">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBank,
 addFicoBank, delFicoBank, 
 updateFicoBank,getFicoBank, 
 } 
from '@/api/accounting/ficobank.js'
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
  sort: 'Mc004',
  sortType: 'asc',
  //是否查询（1是）
  mc003: undefined,
  //是否查询（1是）
  mc004: undefined,
  //是否查询（1是）
  mc005: undefined,
  //是否查询（1是）
  mc006: undefined,
  //是否查询（1是）
  mc007: undefined,
  //是否查询（1是）
  mc008: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mc002', label: '集团' },
  { visible: true, prop: 'mc003', label: '关联对象' },
  { visible: true, prop: 'mc004', label: '银行代码' },
  { visible: true, prop: 'mc005', label: '银行名称' },
  { visible: true, prop: 'mc006', label: '分行名称' },
  { visible: true, prop: 'mc007', label: '银行所在国' },
  { visible: true, prop: 'mc008', label: '所在州省' },
  { visible: false, prop: 'mc009', label: '所在市' },
  { visible: false, prop: 'mc010', label: '所在县' },
  { visible: false, prop: 'mc011', label: '地址1' },
  { visible: false, prop: 'mc012', label: '地址2' },
  { visible: false, prop: 'mc013', label: '地址3' },
  { visible: false, prop: 'mc014', label: '邮政编码' },
  { visible: false, prop: 'mc015', label: '地址号码' },
  { visible: false, prop: 'mc016', label: '银行账号' },
  { visible: false, prop: 'mc017', label: '持有人' },
  { visible: false, prop: 'mc018', label: 'SWIFT代码' },
  { visible: false, prop: 'mc019', label: '交易冻结' },
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
const remotequeryList_sql_global_state=ref([])
//定义远程搜索变量
const remotequery_sql_global_state=ref([])
//远程字典参数
var remotedictParams_sql_global_state = [
    { dictType: "sql_global_state" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_global_state).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_global_state.value = element.list
      })
      //console.log(remotequeryList_sql_global_state)
    })
  })
//远程搜索
const remoteMethod_sql_global_state = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_global_state.value = remotequeryList_sql_global_state.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_global_state(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_global_state.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_global_state = debounce((query) => {
    let arr = remotequeryList_sql_global_state.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_global_state.value = arr.slice(0, 5)
      addFilterOptions_sql_global_state(query)
    } else {
      remotequery_sql_global_state.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_global_state =debounce((dictValue) => {
    let target = remotequeryList_sql_global_state.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_global_state.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_global_state.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

//字典参数
var dictParams = [
  { dictType: "sql_global_country" },
  { dictType: "sys_freeze_flag" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从银行/fico_bank表记录数据
function getList(){
  loading.value = true
  listFicoBank(queryParams).then(res => {
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
    mc002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc004: [{ required: true, message: "银行代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc005: [{ required: true, message: "银行名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc019: [{ required: true, message: "交易冻结"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 银行所在国 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_country: [],
    // 交易冻结 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_freeze_flag: [],
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
    mc002: null,
    mc003: null,
    mc004: null,
    mc005: null,
    mc006: null,
    mc007: [],
    mc008: [],
    mc009: null,
    mc010: null,
    mc011: null,
    mc012: null,
    mc013: null,
    mc014: null,
    mc015: null,
    mc016: null,
    mc017: null,
    mc018: null,
    mc019: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'银行'
  opertype.value = 1
  form.value.mc007= []
  form.value.mc008= []
  form.value.mc019= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoBank(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '银行'
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
        updateFicoBank(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBank(form.value).then((res) => {
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
      return delFicoBank(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<银行.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBank/export', { ...queryParams })
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