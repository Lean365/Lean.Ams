<!--
 * @Descripttion: (主客诉管理/qm_complaints_master)
 * @Version: (0.24.390.30666)
 * @Author: (Lean365)
 * @Date: (2024/1/25 17:38:17)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="客户" prop="qmcmCustomer">
        <el-select clearable filterable  v-model="queryParams.qmcmCustomer" :placeholder="$t('btn.select')+'客户'">
          <el-option v-for="item in  options.sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="机种" prop="qmcmModel">
        <el-input clearable v-model="queryParams.qmcmModel" :placeholder="$t('btn.enter')+'机种'" />
      </el-form-item>
      <el-form-item label="物料" prop="qmcmItem">
        <el-select filterable remote remote-show-suffix :remote-method="remoteMethod" clearable :loading="loading" 
           v-model="queryParams.qmcmItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  remotequery_sql_moc_item" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="接收日期">
        <el-date-picker
          v-model="dateRangeQmcmReceivingDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['qm:complaintsmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['qm:complaintsmaster:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['qm:complaintsmaster:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['qm:complaintsmaster:export']">
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
      <el-table-column prop="qmcmSFID" label="SFID" align="center" v-if="columns.showColumn('qmcmSFID')"/>
      <el-table-column prop="qmcmDocNo" label="客诉No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmDocNo')"/>
      <el-table-column prop="qmcmIssuesNo" label="外部客诉No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmIssuesNo')"/>
      <el-table-column prop="qmcmCustomer" label="客户" align="center" v-if="columns.showColumn('qmcmCustomer')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.qmcmCustomer"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmcmModel" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmModel')"/>
      <el-table-column prop="qmcmItem" label="物料" align="center" v-if="columns.showColumn('qmcmItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_item " :value="scope.row.qmcmItem"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmcmRegion" label="仕向" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmRegion')"/>
      <el-table-column prop="qmcmOrder" label="订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmOrder')"/>
      <el-table-column prop="qmcmReceivingDate" label="接收日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qmcmReceivingDate')"/>
      <el-table-column prop="qmcmFaultQty" label="数量" align="center" v-if="columns.showColumn('qmcmFaultQty')"/>
      <el-table-column prop="qmcmIssues" label="投诉事项" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmIssues')"/>
      <el-table-column prop="qmcmSerialno" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmSerialno')"/>
      <el-table-column prop="qmcmReferenceDocs" label="参考文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmReferenceDocs')"/>
      <el-table-column prop="qmcmFaultDescription" label="症状" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmFaultDescription')"/>
      <el-table-column prop="qmcmRootcauseanalysis" label="分析" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmcmRootcauseanalysis')"/>
      <el-table-column prop="qmcmAdmitDept" label="承认部门" align="center" v-if="columns.showColumn('qmcmAdmitDept')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.qmcmAdmitDept"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmcmAdmitDate" label="承认日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qmcmAdmitDate')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:complaintsmaster:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:complaintsmaster:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改主客诉管理对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="SFID" prop="qmcmSFID">
              <el-input-number v-model.number="form.qmcmSFID" controls-position="right" :placeholder="$t('btn.enter')+'SFID'" :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客诉No." prop="qmcmDocNo">
              <el-input clearable v-model="form.qmcmDocNo" :placeholder="$t('btn.enter')+'客诉No.'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部客诉No." prop="qmcmIssuesNo">
              <el-input clearable v-model="form.qmcmIssuesNo" :placeholder="$t('btn.enter')+'外部客诉No.'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户" prop="qmcmCustomer">
              <el-select clearable filterable v-model="form.qmcmCustomer"  :placeholder="$t('btn.select')+'客户'">
                <el-option
                  v-for="item in options.sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="qmcmModel">
              <el-input clearable v-model="form.qmcmModel" :placeholder="$t('btn.enter')+'机种'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="qmcmItem">
              <el-select filterable remote remote-show-suffix :remote-method="remoteMethod" clearable :loading="loading" 
                style="width: 360px"
                 v-model="form.qmcmItem" 
                 :placeholder="$t('btn.select')+'物料'">
                <el-option
                  v-for="item in  remotequery_sql_moc_item" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仕向" prop="qmcmRegion">
              <el-input clearable v-model="form.qmcmRegion" :placeholder="$t('btn.enter')+'仕向'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单" prop="qmcmOrder">
              <el-input clearable v-model="form.qmcmOrder" :placeholder="$t('btn.enter')+'订单'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="接收日期" prop="qmcmReceivingDate">
              <el-date-picker v-model="form.qmcmReceivingDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="数量" prop="qmcmFaultQty">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.qmcmFaultQty" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="投诉事项" prop="qmcmIssues">
              <el-input type="textarea" v-model="form.qmcmIssues" :placeholder="$t('btn.enter')+'投诉事项'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="qmcmSerialno">
              <el-input clearable v-model="form.qmcmSerialno" :placeholder="$t('btn.enter')+'序列号'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="参考文件" prop="qmcmReferenceDocs">
              <UploadFile v-model="form.qmcmReferenceDocs" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="症状" prop="qmcmFaultDescription">
              <el-input type="textarea" v-model="form.qmcmFaultDescription" :placeholder="$t('btn.enter')+'症状'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="分析" prop="qmcmRootcauseanalysis">
              <el-input type="textarea" v-model="form.qmcmRootcauseanalysis" :placeholder="$t('btn.enter')+'分析'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认部门" prop="qmcmAdmitDept">
              <el-select clearable filterable v-model="form.qmcmAdmitDept"  :placeholder="$t('btn.select')+'承认部门'">
                <el-option
                  v-for="item in options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认日期" prop="qmcmAdmitDate">
              <el-date-picker v-model="form.qmcmAdmitDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'自定义A'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'自定义B'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'自定义C'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'自定义D'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'自定义E'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'自定义F'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义1'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义2'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义3'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义4'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义5'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义6'"  :disabled="true"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'"/>
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

<script setup name="complaintsmaster">
//后台操作函数
import { listComplaintsMaster,
 addComplaintsMaster, delComplaintsMaster, 
 updateComplaintsMaster,getComplaintsMaster, 
 } 
from '@/api/logistics/complaintsmaster.js'
//
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
  qmcmCustomer: undefined,
  qmcmModel: undefined,
  qmcmItem: undefined,
  qmcmReceivingDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qmcmSFID', label: 'SFID' },
  { visible: true, prop: 'qmcmDocNo', label: '客诉No.' },
  { visible: true, prop: 'qmcmIssuesNo', label: '外部客诉No.' },
  { visible: true, prop: 'qmcmCustomer', label: '客户' },
  { visible: true, prop: 'qmcmModel', label: '机种' },
  { visible: true, prop: 'qmcmItem', label: '物料' },
  { visible: true, prop: 'qmcmRegion', label: '仕向' },
  { visible: true, prop: 'qmcmOrder', label: '订单' },
  { visible: false, prop: 'qmcmReceivingDate', label: '接收日期' },
  { visible: false, prop: 'qmcmFaultQty', label: '数量' },
  { visible: false, prop: 'qmcmIssues', label: '投诉事项' },
  { visible: false, prop: 'qmcmSerialno', label: '序列号' },
  { visible: false, prop: 'qmcmReferenceDocs', label: '参考文件' },
  { visible: false, prop: 'qmcmFaultDescription', label: '症状' },
  { visible: false, prop: 'qmcmRootcauseanalysis', label: '分析' },
  { visible: false, prop: 'qmcmAdmitDept', label: '承认部门' },
  { visible: false, prop: 'qmcmAdmitDate', label: '承认日期' },
  { visible: false, prop: 'remark', label: '备注' },
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
//定义远程搜索变量
const remotequeryList=ref([])
//定义远程搜索变量
const remotequery_sql_moc_item=ref([])

  //远程字典参数
  var remotedictParams = [

    { dictType: "sql_moc_item" },

  ]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams).then((response) => {
      response.data.forEach((element) => {
        remotequeryList.value = element.list
      })
      //console.log(remotequeryList)
    })
  })
//远程搜索
const remoteMethod = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_moc_item.value = remotequeryList.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_moc_item.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod = debounce((query) => {
    let arr = remotequeryList.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_moc_item.value = arr.slice(0, 5)
      addFilterOptions(query)
    } else {
      remotequery_sql_moc_item.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions =debounce((dictValue) => {
    let target = remotequeryList.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_moc_item.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_moc_item.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
// 接收日期时间范围
const dateRangeQmcmReceivingDate = ref([])
//字典参数
var dictParams = [
  { dictType: "sql_cus_list" },
  { dictType: "sql_moc_item" },
  { dictType: "sql_dept_list" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从主客诉管理/qm_complaints_master表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQmcmReceivingDate.value, 'QmcmReceivingDate');
  loading.value = true
  listComplaintsMaster(queryParams).then(res => {
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
  dateRangeQmcmReceivingDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qmcmSFID);
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
    qmcmSFID: [{ required: true, message: 'SFID'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
    qmcmDocNo: [{ required: true, message: '客诉No.'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmIssuesNo: [{ required: true, message: '外部客诉No.'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmCustomer: [{ required: true, message: '客户'+ proxy.$t('btn.empty'), trigger: "change"     }],
    qmcmModel: [{ required: true, message: '机种'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmItem: [{ required: true, message: '物料'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmRegion: [{ required: true, message: '仕向'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmReceivingDate: [{ required: true, message: '接收日期'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmFaultQty: [{ required: true, message: '数量'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
    qmcmSerialno: [{ required: true, message: '序列号'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmFaultDescription: [{ required: true, message: '症状'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmRootcauseanalysis: [{ required: true, message: '分析'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    qmcmAdmitDept: [{ required: true, message: '承认部门'+ proxy.$t('btn.empty'), trigger: "change"     }],
    qmcmAdmitDate: [{ required: true, message: '承认日期'+ proxy.$t('btn.empty'), trigger: "blur"     }],
  },
  options: {
    // 客户 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_cus_list: [],
    // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_moc_item: [],
    // 承认部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
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
// @Version: (0.24.390.30666)
// @Author: (Lean365)
// @Date: (2024/1/25 17:38:17)



// 重置表单
function reset() {
  form.value = {
    qmcmSFID: 0,
    qmcmDocNo: null,
    qmcmIssuesNo: null,
    qmcmCustomer: null,
    qmcmModel: null,
    qmcmItem: null,
    qmcmRegion: null,
    qmcmOrder: null,
    qmcmReceivingDate: null,
    qmcmFaultQty: 0,
    qmcmIssues: null,
    qmcmSerialno: null,
    qmcmReferenceDocs: null,
    qmcmFaultDescription: null,
    qmcmRootcauseanalysis: null,
    qmcmAdmitDept: null,
    qmcmAdmitDate: null,
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
  title.value = proxy.$t('btn.add')+'主客诉管理'
  opertype.value = 1
  form.value.qmcmCustomer= []
  form.value.qmcmReceivingDate= new Date()
  form.value.qmcmFaultQty= 0
  form.value.qmcmAdmitDept= []
  form.value.qmcmAdmitDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qmcmSFID || ids.value
  getComplaintsMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ '主客诉管理'
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

      if (form.value.qmcmSFID != undefined && opertype.value === 2) {
        updateComplaintsMaster(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addComplaintsMaster(form.value).then((res) => {
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
  const Ids = row.qmcmSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delComplaintsMaster(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
    })
}



// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"主客诉管理", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/logistics/ComplaintsMaster/export', { ...queryParams })
    })
}


// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.390.30666)
// @Author: (Lean365)
// @Date: (2024/1/25 17:38:17)

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