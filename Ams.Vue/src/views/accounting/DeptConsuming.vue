<!--
 * @Descripttion: (部门消耗/fico_dept_consuming)
 * @Version: (0.24.390.26084)
 * @Author: (Lean365)
 * @Date: (2024/1/25 14:46:50)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['fico:deptconsuming:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:deptconsuming:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:deptconsuming:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:deptconsuming:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="accounting/DeptConsuming/importTemplate"
                  importUrl="/accounting/DeptConsuming/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:deptconsuming:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table
      :data="dataList" height="650"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="40" align="center"/>
      <el-table-column prop="dcSFID" label="SFID" align="center" v-if="columns.showColumn('dcSFID')"/>
      <el-table-column prop="dcFy" label="期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcFy')"/>
      <el-table-column prop="dcYm" label="年月" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcYm')"/>
      <el-table-column prop="dcCorpCode" label="公司代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCorpCode')"/>
      <el-table-column prop="dcCorpName" label="公司名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCorpName')"/>
      <el-table-column prop="dcExpCategory" label="统计类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcExpCategory')"/>
      <el-table-column prop="dcCostCode" label="成本代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCostCode')"/>
      <el-table-column prop="dcCostName" label="成本名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcCostName')"/>
      <el-table-column prop="dcTitleCode" label="科目代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleCode')"/>
      <el-table-column prop="dcTitleName" label="科目名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleName')"/>
      <el-table-column prop="dcTitleNote" label="科目分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcTitleNote')"/>
      <el-table-column prop="dcBudgetAmt" label="预算" align="center" v-if="columns.showColumn('dcBudgetAmt')"/>
      <el-table-column prop="dcActualAmt" label="实际" align="center" v-if="columns.showColumn('dcActualAmt')"/>
      <el-table-column prop="dcDiffAmt" label="差异" align="center" v-if="columns.showColumn('dcDiffAmt')"/>
      <el-table-column prop="dcPlant" label="工厂" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcPlant')"/>
      <el-table-column prop="dcMateriel" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMateriel')"/>
      <el-table-column prop="dcStorageLocation" label="仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcStorageLocation')"/>
      <el-table-column prop="dcMoveType" label="移动类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMoveType')"/>
      <el-table-column prop="dcMaterielDoc" label="物料凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMaterielDoc')"/>
      <el-table-column prop="dcMaterielDocDetails" label="凭证明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcMaterielDocDetails')"/>
      <el-table-column prop="dcUseQty" label="数量" align="center" v-if="columns.showColumn('dcUseQty')"/>
      <el-table-column prop="dcUseAmt" label="金额" align="center" v-if="columns.showColumn('dcUseAmt')"/>
      <el-table-column prop="dcReserveDoc" label="预留单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcReserveDoc')"/>
      <el-table-column prop="dcAccountant" label="预留明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dcAccountant')"/>
      <el-table-column prop="dcBalanceDate" label="登录日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('dcBalanceDate')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:deptconsuming:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:deptconsuming:delete']" @click="handleDelete(scope.row)"></el-button>
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
            <el-form-item label="SFID" prop="dcSFID">
              <el-input v-model.number="form.dcSFID" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="dcFy">
              <el-input clearable v-model="form.dcFy" :placeholder="$t('btn.enter')+'期间'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="dcYm">
              <el-input clearable v-model="form.dcYm" :placeholder="$t('btn.enter')+'年月'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司代码" prop="dcCorpCode">
              <el-input clearable v-model="form.dcCorpCode" :placeholder="$t('btn.enter')+'公司代码'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司名称" prop="dcCorpName">
              <el-input clearable v-model="form.dcCorpName" :placeholder="$t('btn.enter')+'公司名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统计类别" prop="dcExpCategory">
              <el-input clearable v-model="form.dcExpCategory" :placeholder="$t('btn.enter')+'统计类别'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本代码" prop="dcCostCode">
              <el-input clearable v-model="form.dcCostCode" :placeholder="$t('btn.enter')+'成本代码'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本名称" prop="dcCostName">
              <el-input clearable v-model="form.dcCostName" :placeholder="$t('btn.enter')+'成本名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="dcTitleCode">
              <el-input clearable v-model="form.dcTitleCode" :placeholder="$t('btn.enter')+'科目代码'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称" prop="dcTitleName">
              <el-input clearable v-model="form.dcTitleName" :placeholder="$t('btn.enter')+'科目名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目分类" prop="dcTitleNote">
              <el-input clearable v-model="form.dcTitleNote" :placeholder="$t('btn.enter')+'科目分类'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="dcBudgetAmt">
              <el-input clearable v-model="form.dcBudgetAmt" :placeholder="$t('btn.enter')+'预算'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="dcActualAmt">
              <el-input clearable v-model="form.dcActualAmt" :placeholder="$t('btn.enter')+'实际'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="dcDiffAmt">
              <el-input clearable v-model="form.dcDiffAmt" :placeholder="$t('btn.enter')+'差异'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="dcPlant">
              <el-input clearable v-model="form.dcPlant" :placeholder="$t('btn.enter')+'工厂'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="dcMateriel">
              <el-input clearable v-model="form.dcMateriel" :placeholder="$t('btn.enter')+'物料'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="dcStorageLocation">
              <el-input clearable v-model="form.dcStorageLocation" :placeholder="$t('btn.enter')+'仓库'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动类型" prop="dcMoveType">
              <el-input clearable v-model="form.dcMoveType" :placeholder="$t('btn.enter')+'移动类型'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料凭证" prop="dcMaterielDoc">
              <el-input clearable v-model="form.dcMaterielDoc" :placeholder="$t('btn.enter')+'物料凭证'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="dcMaterielDocDetails">
              <el-input clearable v-model="form.dcMaterielDocDetails" :placeholder="$t('btn.enter')+'凭证明细'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="dcUseQty">
              <el-input clearable v-model="form.dcUseQty" :placeholder="$t('btn.enter')+'数量'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额" prop="dcUseAmt">
              <el-input clearable v-model="form.dcUseAmt" :placeholder="$t('btn.enter')+'金额'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留单" prop="dcReserveDoc">
              <el-input clearable v-model="form.dcReserveDoc" :placeholder="$t('btn.enter')+'预留单'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留明细" prop="dcAccountant">
              <el-input clearable v-model="form.dcAccountant" :placeholder="$t('btn.enter')+'预留明细'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="登录日期" prop="dcBalanceDate">
              <el-date-picker v-model="form.dcBalanceDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input clearable v-model.number="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'说明'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.Onboarding')" name="second">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.annex')" name="fourth">
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
          <el-tab-pane :label="$t('ptabs.sale')" name="tenth">
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
          <el-tab-pane :label="$t('ptabs.customization')" name="14th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="15th">
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

<script setup name="deptconsuming">
//后台操作函数
import { listDeptConsuming,
 addDeptConsuming, delDeptConsuming, 
 updateDeptConsuming,getDeptConsuming, 
 } 
from '@/api/accounting/deptconsuming.js'
//
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
  pageSize: 20,
  sort: '',
  sortType: 'asc',
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'dcSFID', label: 'SFID' },
  { visible: true, prop: 'dcFy', label: '期间' },
  { visible: true, prop: 'dcYm', label: '年月' },
  { visible: true, prop: 'dcCorpCode', label: '公司代码' },
  { visible: true, prop: 'dcCorpName', label: '公司名称' },
  { visible: true, prop: 'dcExpCategory', label: '统计类别' },
  { visible: true, prop: 'dcCostCode', label: '成本代码' },
  { visible: true, prop: 'dcCostName', label: '成本名称' },
  { visible: false, prop: 'dcTitleCode', label: '科目代码' },
  { visible: false, prop: 'dcTitleName', label: '科目名称' },
  { visible: false, prop: 'dcTitleNote', label: '科目分类' },
  { visible: false, prop: 'dcBudgetAmt', label: '预算' },
  { visible: false, prop: 'dcActualAmt', label: '实际' },
  { visible: false, prop: 'dcDiffAmt', label: '差异' },
  { visible: false, prop: 'dcPlant', label: '工厂' },
  { visible: false, prop: 'dcMateriel', label: '物料' },
  { visible: false, prop: 'dcStorageLocation', label: '仓库' },
  { visible: false, prop: 'dcMoveType', label: '移动类型' },
  { visible: false, prop: 'dcMaterielDoc', label: '物料凭证' },
  { visible: false, prop: 'dcMaterielDocDetails', label: '凭证明细' },
  { visible: false, prop: 'dcUseQty', label: '数量' },
  { visible: false, prop: 'dcUseAmt', label: '金额' },
  { visible: false, prop: 'dcReserveDoc', label: '预留单' },
  { visible: false, prop: 'dcAccountant', label: '预留明细' },
  { visible: false, prop: 'dcBalanceDate', label: '登录日期' },
  { visible: false, prop: 'remark', label: '说明' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
  { visible: false, prop: 'updateBy', label: '更新者' },
  { visible: false, prop: 'updateTime', label: '更新时间' },
])
// 记录数
const total = ref(0)
//定义从设变表格数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
//输入日时间范围
//字典参数
var dictParams = [
]
//字典加载
//API获取从部门消耗/fico_dept_consuming表记录数据
function getList(){
  loading.value = true
  listDeptConsuming(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.dcSFID);
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
    dcSFID: [{ required: true, message: 'SFID'+ proxy.$t('btn.empty'), trigger: "blur" }],
    dcFy: [{ required: true, message: '期间'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcYm: [{ required: true, message: '年月'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcCorpCode: [{ required: true, message: '公司代码'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcCorpName: [{ required: true, message: '公司名称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcExpCategory: [{ required: true, message: '统计类别'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcCostCode: [{ required: true, message: '成本代码'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcCostName: [{ required: true, message: '成本名称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcTitleCode: [{ required: true, message: '科目代码'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcTitleName: [{ required: true, message: '科目名称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcTitleNote: [{ required: true, message: '科目分类'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcBudgetAmt: [{ required: true, message: '预算'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcActualAmt: [{ required: true, message: '实际'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcDiffAmt: [{ required: true, message: '差异'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcPlant: [{ required: true, message: '工厂'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcMateriel: [{ required: true, message: '物料'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcStorageLocation: [{ required: true, message: '仓库'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcMoveType: [{ required: true, message: '移动类型'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcMaterielDoc: [{ required: true, message: '物料凭证'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcMaterielDocDetails: [{ required: true, message: '凭证明细'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcUseQty: [{ required: true, message: '数量'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcUseAmt: [{ required: true, message: '金额'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcReserveDoc: [{ required: true, message: '预留单'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcAccountant: [{ required: true, message: '预留明细'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    dcBalanceDate: [{ required: true, message: '登录日期'+ proxy.$t('btn.empty'), trigger: "blur"     }],
  },
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

// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.390.26084)
// @Author: (Lean365)
// @Date: (2024/1/25 14:46:50)



// 重置表单
function reset() {
  form.value = {
    dcSFID: 0,
    dcFy: null,
    dcYm: null,
    dcCorpCode: null,
    dcCorpName: null,
    dcExpCategory: null,
    dcCostCode: null,
    dcCostName: null,
    dcTitleCode: null,
    dcTitleName: null,
    dcTitleNote: null,
    dcBudgetAmt: 0,
    dcActualAmt: 0,
    dcDiffAmt: 0,
    dcPlant: null,
    dcMateriel: null,
    dcStorageLocation: null,
    dcMoveType: null,
    dcMaterielDoc: null,
    dcMaterielDocDetails: null,
    dcUseQty: 0,
    dcUseAmt: 0,
    dcReserveDoc: null,
    dcAccountant: null,
    dcBalanceDate: null,
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
  title.value = proxy.$t('btn.add')+'部门消耗'
  opertype.value = 1
  form.value.dcBudgetAmt= 0
  form.value.dcActualAmt= 0
  form.value.dcDiffAmt= 0
  form.value.dcUseQty= 0
  form.value.dcUseAmt= 0
  form.value.dcBalanceDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.dcSFID || ids.value
  getDeptConsuming(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ '部门消耗'
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

      if (form.value.dcSFID != undefined && opertype.value === 2) {
        updateDeptConsuming(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addDeptConsuming(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.dcSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delDeptConsuming(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
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
    .$confirm(proxy.$t('common.confirmExport')+"部门消耗", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/accounting/DeptConsuming/export', { ...queryParams })
    })
}


// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.390.26084)
// @Author: (Lean365)
// @Date: (2024/1/25 14:46:50)

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