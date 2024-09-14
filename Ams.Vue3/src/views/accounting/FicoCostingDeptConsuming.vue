<!--
 * @Descripttion: 部门消耗/fico_costing_dept_consuming
 * @Version: 0.24.619.29178
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 16:51:22
 * @column：47
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="期间" prop="ml002">
        <el-select filterable clearable   v-model="queryParams.ml002" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="ml003">
        <el-select filterable clearable   v-model="queryParams.ml003" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司代码" prop="ml004">
        <el-select filterable clearable   v-model="queryParams.ml004" :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="ml013">
        <el-input v-model="queryParams.ml013" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['fico:costingdeptconsuming:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:costingdeptconsuming:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:costingdeptconsuming:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:costingdeptconsuming:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoCostingDeptConsuming/importTemplate"
                  importUrl="/Accounting/FicoCostingDeptConsuming/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:costingdeptconsuming:export']">
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
      <el-table-column prop="ml002" label="期间" align="center" v-if="columns.showColumn('ml002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.ml002"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml003" label="年月" align="center" v-if="columns.showColumn('ml003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.ml003"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml004" label="公司代码" align="center" v-if="columns.showColumn('ml004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.ml004"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml005" label="统计类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml005')"/>
      <el-table-column prop="ml006" label="成本科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml006')"/>
      <el-table-column prop="ml007" label="科目代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml007')"/>
      <el-table-column prop="ml008" label="科目分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml008')"/>
      <el-table-column prop="ml009" label="预算" align="center" v-if="columns.showColumn('ml009')"/>
      <el-table-column prop="ml010" label="实际" align="center" v-if="columns.showColumn('ml010')"/>
      <el-table-column prop="ml011" label="差异" align="center" v-if="columns.showColumn('ml011')"/>
      <el-table-column prop="ml012" label="工厂" align="center" v-if="columns.showColumn('ml012')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.ml012"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml013" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml013')"/>
      <el-table-column prop="ml014" label="仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml014')"/>
      <el-table-column prop="ml015" label="移动类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml015')"/>
      <el-table-column prop="ml016" label="物料凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml016')"/>
      <el-table-column prop="ml017" label="项目明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml017')"/>
      <el-table-column prop="ml018" label="数量" align="center" v-if="columns.showColumn('ml018')"/>
      <el-table-column prop="ml019" label="币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml019')"/>
      <el-table-column prop="ml020" label="金额" align="center" v-if="columns.showColumn('ml020')"/>
      <el-table-column prop="ml021" label="预留单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml021')"/>
      <el-table-column prop="ml022" label="预留明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml022')"/>
      <el-table-column prop="ml023" label="领用日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ml023')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:costingdeptconsuming:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:costingdeptconsuming:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改部门消耗对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="期间" prop="ml002">
              <el-select filterable clearable   v-model="form.ml002"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="ml003">
              <el-select filterable clearable   v-model="form.ml003"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司代码" prop="ml004">
              <el-select filterable clearable   v-model="form.ml004"  :placeholder="$t('btn.selectPrefix')+'公司代码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="统计类别" prop="ml005">
              <el-input   v-model="form.ml005" :placeholder="$t('btn.enterPrefix')+'统计类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本科目" prop="ml006">
              <el-input   v-model="form.ml006" :placeholder="$t('btn.enterPrefix')+'成本科目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="ml007">
              <el-input   v-model="form.ml007" :placeholder="$t('btn.enterPrefix')+'科目代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目分类" prop="ml008">
              <el-input   v-model="form.ml008" :placeholder="$t('btn.enterPrefix')+'科目分类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="ml009">
              <el-input-number v-model.number="form.ml009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="ml010">
              <el-input-number v-model.number="form.ml010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="ml011">
              <el-input-number v-model.number="form.ml011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="ml012">
              <el-select filterable clearable   v-model="form.ml012"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料" prop="ml013">
              <el-input   v-model="form.ml013" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="ml014">
              <el-input   v-model="form.ml014" :placeholder="$t('btn.enterPrefix')+'仓库'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动类型" prop="ml015">
              <el-input   v-model="form.ml015" :placeholder="$t('btn.enterPrefix')+'移动类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料凭证" prop="ml016">
              <el-input   v-model="form.ml016" :placeholder="$t('btn.enterPrefix')+'物料凭证'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="项目明细" prop="ml017">
              <el-input   v-model="form.ml017" :placeholder="$t('btn.enterPrefix')+'项目明细'+$t('btn.enterSuffix')"  show-word-limit   maxlength="5"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="ml018">
              <el-input-number v-model.number="form.ml018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="ml019">
              <el-input   v-model="form.ml019" :placeholder="$t('btn.enterPrefix')+'币种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额" prop="ml020">
              <el-input-number v-model.number="form.ml020" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留单" prop="ml021">
              <el-input   v-model="form.ml021" :placeholder="$t('btn.enterPrefix')+'预留单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留明细" prop="ml022">
              <el-input   v-model="form.ml022" :placeholder="$t('btn.enterPrefix')+'预留明细'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="领用日期" prop="ml023">
              <el-date-picker v-model="form.ml023" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ficocostingdeptconsuming">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoCostingDeptConsuming,
 addFicoCostingDeptConsuming, delFicoCostingDeptConsuming, 
 updateFicoCostingDeptConsuming,getFicoCostingDeptConsuming, 
 } 
from '@/api/accounting/ficocostingdeptconsuming.js'
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
  sort: 'Ml003',
  sortType: 'desc',
  //是否查询（1是）
  ml002: undefined,
  //是否查询（1是）
  ml003: undefined,
  //是否查询（1是）
  ml004: undefined,
  //是否查询（1是）
  ml013: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'ml002', label: '期间' },
  { visible: true, prop: 'ml003', label: '年月' },
  { visible: true, prop: 'ml004', label: '公司代码' },
  { visible: true, prop: 'ml005', label: '统计类别' },
  { visible: true, prop: 'ml006', label: '成本科目' },
  { visible: true, prop: 'ml007', label: '科目代码' },
  { visible: true, prop: 'ml008', label: '科目分类' },
  { visible: false, prop: 'ml009', label: '预算' },
  { visible: false, prop: 'ml010', label: '实际' },
  { visible: false, prop: 'ml011', label: '差异' },
  { visible: false, prop: 'ml012', label: '工厂' },
  { visible: false, prop: 'ml013', label: '物料' },
  { visible: false, prop: 'ml014', label: '仓库' },
  { visible: false, prop: 'ml015', label: '移动类型' },
  { visible: false, prop: 'ml016', label: '物料凭证' },
  { visible: false, prop: 'ml017', label: '项目明细' },
  { visible: false, prop: 'ml018', label: '数量' },
  { visible: false, prop: 'ml019', label: '币种' },
  { visible: false, prop: 'ml020', label: '金额' },
  { visible: false, prop: 'ml021', label: '预留单' },
  { visible: false, prop: 'ml022', label: '预留明细' },
  { visible: false, prop: 'ml023', label: '领用日期' },
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
  { dictType: "sql_attr_list" },
  { dictType: "sql_ymdt_list" },
  { dictType: "sql_corp_list" },
  { dictType: "sql_plant_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从部门消耗/fico_costing_dept_consuming表记录数据
function getList(){
  loading.value = true
  listFicoCostingDeptConsuming(queryParams).then(res => {
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
    ml002: [{ required: true, message: "期间"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ml003: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ml004: [{ required: true, message: "公司代码"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ml012: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ml013: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
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
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ymdt_list: [],
    // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
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
    ml002: [],
    ml003: [],
    ml004: [],
    ml005: null,
    ml006: null,
    ml007: null,
    ml008: null,
    ml009: 0,
    ml010: 0,
    ml011: 0,
    ml012: [],
    ml013: null,
    ml014: null,
    ml015: null,
    ml016: null,
    ml017: null,
    ml018: 0,
    ml019: null,
    ml020: 0,
    ml021: null,
    ml022: null,
    ml023: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'部门消耗'
  opertype.value = 1
  form.value.ml002= []
  form.value.ml003= []
  form.value.ml004= []
  form.value.ml009= 0
  form.value.ml010= 0
  form.value.ml011= 0
  form.value.ml012= []
  form.value.ml018= 0
  form.value.ml020= 0
  form.value.ml023= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoCostingDeptConsuming(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '部门消耗'
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
        updateFicoCostingDeptConsuming(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoCostingDeptConsuming(form.value).then((res) => {
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
      return delFicoCostingDeptConsuming(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<部门消耗.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoCostingDeptConsuming/export', { ...queryParams })
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