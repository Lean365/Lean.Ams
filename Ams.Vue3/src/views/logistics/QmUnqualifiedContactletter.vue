<!--
 * @Descripttion: 不合格联络/qm_unqualified_contactletter
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/19 15:07:53
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="检查员" prop="qucdInspector">
        <el-select filterable clearable   v-model="queryParams.qucdInspector" :placeholder="$t('btn.selectSearchPrefix')+'检查员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_inspector_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="班组" prop="qucdLine">
        <el-input v-model="queryParams.qucdLine" :placeholder="$t('btn.enterSearchPrefix')+'班组'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="订单" prop="qucdOrder">
        <el-input v-model="queryParams.qucdOrder" :placeholder="$t('btn.enterSearchPrefix')+'订单'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="qucdModels">
        <el-input v-model="queryParams.qucdModels" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="qucdMaterial">
        <el-input v-model="queryParams.qucdMaterial" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="仕向" prop="qucdRegion">
        <el-input v-model="queryParams.qucdRegion" :placeholder="$t('btn.enterSearchPrefix')+'仕向'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="查验日期">
        <el-date-picker
          v-model="dateRangeQucdCheckDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="批次" prop="qucdProLot">
        <el-input v-model="queryParams.qucdProLot" :placeholder="$t('btn.enterSearchPrefix')+'批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="序号" prop="qucdProSerial">
        <el-input v-model="queryParams.qucdProSerial" :placeholder="$t('btn.enterSearchPrefix')+'序号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="级别" prop="qucdJudgmentLevel">
        <el-select filterable clearable   v-model="queryParams.qucdJudgmentLevel" :placeholder="$t('btn.selectSearchPrefix')+'级别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_bad " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="发行号码" prop="qucdIssueno">
        <el-input v-model="queryParams.qucdIssueno" :placeholder="$t('btn.enterSearchPrefix')+'发行号码'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['qm:unqualifiedcontactletter:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:unqualifiedcontactletter:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:unqualifiedcontactletter:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:unqualifiedcontactletter:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmUnqualifiedContactletter/importTemplate"
                  importUrl="/Logistics/QmUnqualifiedContactletter/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:unqualifiedcontactletter:export']">
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
      <el-table-column prop="qucdSFID" label="SFID" align="center" v-if="columns.showColumn('qucdSFID')"/>
      <el-table-column prop="qucdInspector" label="检查员" align="center" v-if="columns.showColumn('qucdInspector')">
        <template #default="scope">
          <dict-tag :options=" options.sql_inspector_list " :value="scope.row.qucdInspector"  />
        </template>
      </el-table-column>
      <el-table-column prop="qucdLine" label="班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdLine')"/>
      <el-table-column prop="qucdOrder" label="订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdOrder')"/>
      <el-table-column prop="qucdModels" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdModels')"/>
      <el-table-column prop="qucdMaterial" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdMaterial')"/>
      <el-table-column prop="qucdRegion" label="仕向" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdRegion')"/>
      <el-table-column prop="qucdCheckDate" label="查验日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qucdCheckDate')"/>
      <el-table-column prop="qucdProLot" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdProLot')"/>
      <el-table-column prop="qucdProSerial" label="序号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdProSerial')"/>
      <el-table-column prop="qucdRejectQty" label="验退数" align="center" v-if="columns.showColumn('qucdRejectQty')"/>
      <el-table-column prop="qucdJudgmentLevel" label="级别" align="center" v-if="columns.showColumn('qucdJudgmentLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_bad " :value="scope.row.qucdJudgmentLevel"  />
        </template>
      </el-table-column>
      <el-table-column prop="qucdCheckNotes" label="判定说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdCheckNotes')"/>
      <el-table-column prop="qucdIssueno" label="发行号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qucdIssueno')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column prop="qucdFileUrl" label="附件" align="center" v-if="columns.showColumn('qucdFileUrl')">
        <template #default="scope">
          <ImagePreview :src="scope.row.qucdFileUrl"></ImagePreview>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:unqualifiedcontactletter:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:unqualifiedcontactletter:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改不合格联络对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="qucdSFID">
              <el-input v-model.number="form.qucdSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查员" prop="qucdInspector">
              <el-select filterable clearable   v-model="form.qucdInspector"  :placeholder="$t('btn.selectPrefix')+'检查员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_inspector_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="班组" prop="qucdLine">
              <el-input v-model="form.qucdLine" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单" prop="qucdOrder">
              <el-input v-model="form.qucdOrder" :placeholder="$t('btn.enterPrefix')+'订单'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="qucdModels">
              <el-input v-model="form.qucdModels" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="qucdMaterial">
              <el-input v-model="form.qucdMaterial" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仕向" prop="qucdRegion">
              <el-input v-model="form.qucdRegion" :placeholder="$t('btn.enterPrefix')+'仕向'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="查验日期" prop="qucdCheckDate">
              <el-date-picker v-model="form.qucdCheckDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="qucdProLot">
              <el-input v-model="form.qucdProLot" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序号" prop="qucdProSerial">
              <el-input v-model="form.qucdProSerial" :placeholder="$t('btn.enterPrefix')+'序号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="验退数" prop="qucdRejectQty">
              <el-input-number v-model.number="form.qucdRejectQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验退数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="级别" prop="qucdJudgmentLevel">
              <el-select filterable clearable   v-model="form.qucdJudgmentLevel"  :placeholder="$t('btn.selectPrefix')+'级别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_bad" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="判定说明" prop="qucdCheckNotes">
              <el-input type="textarea" v-model="form.qucdCheckNotes" :placeholder="$t('btn.enterPrefix')+'判定说明'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行号码" prop="qucdIssueno">
              <el-input v-model="form.qucdIssueno" :placeholder="$t('btn.enterPrefix')+'发行号码'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enterPrefix')+'自定义A'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input v-model="form.uDF02" :placeholder="$t('btn.enterPrefix')+'自定义B'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input v-model="form.uDF03" :placeholder="$t('btn.enterPrefix')+'自定义C'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input v-model="form.uDF04" :placeholder="$t('btn.enterPrefix')+'自定义D'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input v-model="form.uDF05" :placeholder="$t('btn.enterPrefix')+'自定义E'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input v-model="form.uDF06" :placeholder="$t('btn.enterPrefix')+'自定义F'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.isDeletedOptions" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="附件" prop="qucdFileUrl">
              <UploadImage v-model="form.qucdFileUrl" :data="{ uploadType: 1 }" />
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

<script setup name="qmunqualifiedcontactletter">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmUnqualifiedContactletter,
 addQmUnqualifiedContactletter, delQmUnqualifiedContactletter, 
 updateQmUnqualifiedContactletter,getQmUnqualifiedContactletter, 
 } 
from '@/api/logistics/qmunqualifiedcontactletter.js'
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
//是否查询（1是）
  qucdInspector: undefined,
//是否查询（1是）
  qucdLine: undefined,
//是否查询（1是）
  qucdOrder: undefined,
//是否查询（1是）
  qucdModels: undefined,
//是否查询（1是）
  qucdMaterial: undefined,
//是否查询（1是）
  qucdRegion: undefined,
//是否查询（1是）
  qucdCheckDate: undefined,
//是否查询（1是）
  qucdProLot: undefined,
//是否查询（1是）
  qucdProSerial: undefined,
//是否查询（1是）
  qucdJudgmentLevel: undefined,
//是否查询（1是）
  qucdIssueno: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qucdSFID', label: 'SFID' },
  { visible: true, prop: 'qucdInspector', label: '检查员' },
  { visible: true, prop: 'qucdLine', label: '班组' },
  { visible: true, prop: 'qucdOrder', label: '订单' },
  { visible: true, prop: 'qucdModels', label: '机种' },
  { visible: true, prop: 'qucdMaterial', label: '物料' },
  { visible: true, prop: 'qucdRegion', label: '仕向' },
  { visible: true, prop: 'qucdCheckDate', label: '查验日期' },
  { visible: false, prop: 'qucdProLot', label: '批次' },
  { visible: false, prop: 'qucdProSerial', label: '序号' },
  { visible: false, prop: 'qucdRejectQty', label: '验退数' },
  { visible: false, prop: 'qucdJudgmentLevel', label: '级别' },
  { visible: false, prop: 'qucdCheckNotes', label: '判定说明' },
  { visible: false, prop: 'qucdIssueno', label: '发行号码' },
  { visible: false, prop: 'remark', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
  { visible: false, prop: 'updateBy', label: '更新者' },
  { visible: false, prop: 'updateTime', label: '更新时间' },
  { visible: false, prop: 'qucdFileUrl', label: '附件' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
// 查验日期时间范围
const dateRangeQucdCheckDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_inspector_list" },
  { dictType: "sys_insp_bad" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从不合格联络/qm_unqualified_contactletter表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQucdCheckDate.value, 'QucdCheckDate');
  loading.value = true
  listQmUnqualifiedContactletter(queryParams).then(res => {
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
  // 查验日期时间范围
  dateRangeQucdCheckDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qucdSFID);
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
    qucdSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    qucdInspector: [{ required: true, message: "检查员"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qucdLine: [{ required: true, message: "班组"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qucdOrder: [{ required: true, message: "订单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qucdMaterial: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qucdCheckDate: [{ required: true, message: "查验日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qucdRejectQty: [{ required: true, message: "验退数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qucdJudgmentLevel: [{ required: true, message: "级别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qucdCheckNotes: [{ required: true, message: "判定说明"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 检查员 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_inspector_list: [],
    // 级别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_bad: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
isDeletedOptions: [],
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
    qucdSFID: 0,
    qucdInspector: null,
    qucdLine: null,
    qucdOrder: null,
    qucdModels: null,
    qucdMaterial: null,
    qucdRegion: null,
    qucdCheckDate: null,
    qucdProLot: null,
    qucdProSerial: null,
    qucdRejectQty: 0,
    qucdJudgmentLevel: null,
    qucdCheckNotes: null,
    qucdIssueno: null,
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
    qucdFileUrl: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'不合格联络'
  opertype.value = 1
  form.value.qucdInspector= []
  form.value.qucdCheckDate= new Date()
  form.value.qucdRejectQty= 0
  form.value.qucdJudgmentLevel= []
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qucdSFID || ids.value
  getQmUnqualifiedContactletter(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '不合格联络'
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

      if (form.value.qucdSFID != undefined && opertype.value === 2) {
        updateQmUnqualifiedContactletter(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmUnqualifiedContactletter(form.value).then((res) => {
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
  const Ids = row.qucdSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delQmUnqualifiedContactletter(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<不合格联络.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmUnqualifiedContactletter/export', { ...queryParams })
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