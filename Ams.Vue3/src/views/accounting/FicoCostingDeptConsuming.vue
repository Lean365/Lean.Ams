<!--
 * @Descripttion: 部门消耗/fico_costing_dept_consuming
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/9 12:03:53
 * @column：47
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="期间" prop="dcLfgja">
        <el-select filterable clearable   v-model="queryParams.dcLfgja" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_fy_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="dcLfmon">
        <el-select filterable clearable   v-model="queryParams.dcLfmon" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司代码" prop="dcBukrs">
        <el-select filterable clearable   v-model="queryParams.dcBukrs" :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="dcMatnr">
        <el-input v-model="queryParams.dcMatnr" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
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
      <el-table-column prop="dcSfId" label="ID" align="center" v-if="columns.showColumn('dcSfId')"/>
      <el-table-column prop="dcLfgja" label="期间" align="center" v-if="columns.showColumn('dcLfgja')">
        <template #default="scope">
          <dict-tag :options=" options.sql_fy_list " :value="scope.row.dcLfgja"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcLfmon" label="年月" align="center" v-if="columns.showColumn('dcLfmon')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.dcLfmon"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcBukrs" label="公司代码" align="center" v-if="columns.showColumn('dcBukrs')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.dcBukrs"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcStatyp" label="统计类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcStatyp')"/>
      <el-table-column prop="dcKtosl" label="成本科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcKtosl')"/>
      <el-table-column prop="dcKonto" label="科目代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcKonto')"/>
      <el-table-column prop="dcKotyp" label="科目分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcKotyp')"/>
      <el-table-column prop="dcAnval" label="预算" align="center" v-if="columns.showColumn('dcAnval')"/>
      <el-table-column prop="dcDmist" label="实际" align="center" v-if="columns.showColumn('dcDmist')"/>
      <el-table-column prop="dcBfaac" label="差异" align="center" v-if="columns.showColumn('dcBfaac')"/>
      <el-table-column prop="dcWerks" label="工厂" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcWerks')"/>
      <el-table-column prop="dcMatnr" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMatnr')"/>
      <el-table-column prop="dcLgort" label="仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcLgort')"/>
      <el-table-column prop="dcBwart" label="移动类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcBwart')"/>
      <el-table-column prop="dcMblnr" label="物料凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMblnr')"/>
      <el-table-column prop="dcZeile" label="项目明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcZeile')"/>
      <el-table-column prop="dcMenge" label="数量" align="center" v-if="columns.showColumn('dcMenge')"/>
      <el-table-column prop="dcWaers" label="币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcWaers')"/>
      <el-table-column prop="dcDmbtr" label="金额" align="center" v-if="columns.showColumn('dcDmbtr')"/>
      <el-table-column prop="dcRsnum" label="预留单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcRsnum')"/>
      <el-table-column prop="dcRspos" label="预留明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcRspos')"/>
      <el-table-column prop="dcBudat" label="领用日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('dcBudat')"/>
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
            <el-form-item label="期间" prop="dcLfgja">
              <el-select filterable clearable   v-model="form.dcLfgja"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_fy_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="dcLfmon">
              <el-select filterable clearable   v-model="form.dcLfmon"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司代码" prop="dcBukrs">
              <el-select filterable clearable   v-model="form.dcBukrs"  :placeholder="$t('btn.selectPrefix')+'公司代码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="统计类别" prop="dcStatyp">
              <el-input v-model="form.dcStatyp" :placeholder="$t('btn.enterPrefix')+'统计类别'+$t('btn.enterSuffix')"  show-word-limit maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本科目" prop="dcKtosl">
              <el-input v-model="form.dcKtosl" :placeholder="$t('btn.enterPrefix')+'成本科目'+$t('btn.enterSuffix')"  show-word-limit maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="dcKonto">
              <el-input v-model="form.dcKonto" :placeholder="$t('btn.enterPrefix')+'科目代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目分类" prop="dcKotyp">
              <el-input v-model="form.dcKotyp" :placeholder="$t('btn.enterPrefix')+'科目分类'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="dcAnval">
              <el-input-number v-model.number="form.dcAnval" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="dcDmist">
              <el-input-number v-model.number="form.dcDmist" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="dcBfaac">
              <el-input-number v-model.number="form.dcBfaac" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="dcWerks">
              <el-input v-model="form.dcWerks" :placeholder="$t('btn.enterPrefix')+'工厂'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="dcMatnr">
              <el-input v-model="form.dcMatnr" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="dcLgort">
              <el-input v-model="form.dcLgort" :placeholder="$t('btn.enterPrefix')+'仓库'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动类型" prop="dcBwart">
              <el-input v-model="form.dcBwart" :placeholder="$t('btn.enterPrefix')+'移动类型'+$t('btn.enterSuffix')"  show-word-limit maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料凭证" prop="dcMblnr">
              <el-input v-model="form.dcMblnr" :placeholder="$t('btn.enterPrefix')+'物料凭证'+$t('btn.enterSuffix')"  show-word-limit maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="项目明细" prop="dcZeile">
              <el-input v-model="form.dcZeile" :placeholder="$t('btn.enterPrefix')+'项目明细'+$t('btn.enterSuffix')"  show-word-limit maxlength="5"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="dcMenge">
              <el-input-number v-model.number="form.dcMenge" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="dcWaers">
              <el-input v-model="form.dcWaers" :placeholder="$t('btn.enterPrefix')+'币种'+$t('btn.enterSuffix')"  show-word-limit maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额" prop="dcDmbtr">
              <el-input-number v-model.number="form.dcDmbtr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留单" prop="dcRsnum">
              <el-input v-model="form.dcRsnum" :placeholder="$t('btn.enterPrefix')+'预留单'+$t('btn.enterSuffix')"  show-word-limit maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留明细" prop="dcRspos">
              <el-input v-model="form.dcRspos" :placeholder="$t('btn.enterPrefix')+'预留明细'+$t('btn.enterSuffix')"  show-word-limit maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="领用日期" prop="dcBudat">
              <el-date-picker v-model="form.dcBudat" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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
  sort: 'DcLfmon',
  sortType: 'desc',
//是否查询（1是）
  dcLfgja: undefined,
//是否查询（1是）
  dcLfmon: undefined,
//是否查询（1是）
  dcBukrs: undefined,
//是否查询（1是）
  dcMatnr: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'dcSfId', label: 'ID' },
  { visible: true, prop: 'dcLfgja', label: '期间' },
  { visible: true, prop: 'dcLfmon', label: '年月' },
  { visible: true, prop: 'dcBukrs', label: '公司代码' },
  { visible: true, prop: 'dcStatyp', label: '统计类别' },
  { visible: true, prop: 'dcKtosl', label: '成本科目' },
  { visible: true, prop: 'dcKonto', label: '科目代码' },
  { visible: true, prop: 'dcKotyp', label: '科目分类' },
  { visible: false, prop: 'dcAnval', label: '预算' },
  { visible: false, prop: 'dcDmist', label: '实际' },
  { visible: false, prop: 'dcBfaac', label: '差异' },
  { visible: false, prop: 'dcWerks', label: '工厂' },
  { visible: false, prop: 'dcMatnr', label: '物料' },
  { visible: false, prop: 'dcLgort', label: '仓库' },
  { visible: false, prop: 'dcBwart', label: '移动类型' },
  { visible: false, prop: 'dcMblnr', label: '物料凭证' },
  { visible: false, prop: 'dcZeile', label: '项目明细' },
  { visible: false, prop: 'dcMenge', label: '数量' },
  { visible: false, prop: 'dcWaers', label: '币种' },
  { visible: false, prop: 'dcDmbtr', label: '金额' },
  { visible: false, prop: 'dcRsnum', label: '预留单' },
  { visible: false, prop: 'dcRspos', label: '预留明细' },
  { visible: false, prop: 'dcBudat', label: '领用日期' },
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
  { dictType: "sql_fy_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sys_crop_list" },
  { dictType: "sys_is_deleted" },
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
  ids.value = selection.map((item) => item.dcSfId);
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
    dcSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_fy_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ym_list: [],
    // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
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
    dcSfId: 0,
    dcLfgja: null,
    dcLfmon: null,
    dcBukrs: null,
    dcStatyp: null,
    dcKtosl: null,
    dcKonto: null,
    dcKotyp: null,
    dcAnval: 0,
    dcDmist: 0,
    dcBfaac: 0,
    dcWerks: null,
    dcMatnr: null,
    dcLgort: null,
    dcBwart: null,
    dcMblnr: null,
    dcZeile: null,
    dcMenge: 0,
    dcWaers: null,
    dcDmbtr: 0,
    dcRsnum: null,
    dcRspos: null,
    dcBudat: null,
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
    remark: null,
    isDeleted: 0,
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
  title.value = proxy.$t('btn.add')+" "+'部门消耗'
  opertype.value = 1
  form.value.dcLfgja= []
  form.value.dcLfmon= []
  form.value.dcBukrs= []
  form.value.dcAnval= 0
  form.value.dcDmist= 0
  form.value.dcBfaac= 0
  form.value.dcMenge= 0
  form.value.dcDmbtr= 0
  form.value.dcBudat= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.dcSfId || ids.value
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

      if (form.value.dcSfId != undefined && opertype.value === 2) {
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
  const Ids = row.dcSfId || ids.value

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