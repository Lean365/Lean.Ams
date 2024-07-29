<!--
 * @Descripttion: 加班预算/fico_budget_overtime_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/29 9:28:52
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="科目" prop="fbosTitle">
        <el-select filterable clearable   v-model="queryParams.fbosTitle" :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_budget_title " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="名称" prop="fbosClass">
        <el-input v-model="queryParams.fbosClass" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="启用标记" prop="fbosFlag">
        <el-select filterable clearable   v-model="queryParams.fbosFlag" :placeholder="$t('btn.selectSearchPrefix')+'启用标记'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="审核" prop="fbosAudit">
        <el-select filterable clearable   v-model="queryParams.fbosAudit" :placeholder="$t('btn.selectSearchPrefix')+'审核'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="审核日期">
        <el-date-picker
          v-model="dateRangeFbosAuditDate" 
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetovertimeslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetovertimeslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetovertimeslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetovertimeslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetOvertimeSlv/importTemplate"
                  importUrl="/Accounting/FicoBudgetOvertimeSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetovertimeslv:export']">
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
      <el-table-column prop="fbosSfid" label="SFID" align="center" v-if="columns.showColumn('fbosSfid')"/>
      <el-table-column prop="fbosParentSfid" label="FbosParentSfid" align="center" v-if="columns.showColumn('fbosParentSfid')"/>
      <el-table-column prop="fbosTitle" label="科目" align="center" v-if="columns.showColumn('fbosTitle')">
        <template #default="scope">
          <dict-tag :options=" options.sql_budget_title " :value="scope.row.fbosTitle"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbosClass" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosClass')"/>
      <el-table-column prop="fbosRequiredst" label="必要工数" align="center" v-if="columns.showColumn('fbosRequiredst')"/>
      <el-table-column prop="fbosDirectEmployee" label="保有人数" align="center" v-if="columns.showColumn('fbosDirectEmployee')"/>
      <el-table-column prop="fbosIndirectEmployee" label="间接人数" align="center" v-if="columns.showColumn('fbosIndirectEmployee')"/>
      <el-table-column prop="fbosDays" label="上班天数" align="center" v-if="columns.showColumn('fbosDays')"/>
      <el-table-column prop="fbosContent" label="加班事由" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosContent')"/>
      <el-table-column prop="fbosRetainst" label="保有工数" align="center" v-if="columns.showColumn('fbosRetainst')"/>
      <el-table-column prop="fbosRetainstdiff" label="工数差异" align="center" v-if="columns.showColumn('fbosRetainstdiff')"/>
      <el-table-column prop="fbosOvertime" label="投入加班" align="center" v-if="columns.showColumn('fbosOvertime')"/>
      <el-table-column prop="fbosDirectovertime" label="平均投入加班" align="center" v-if="columns.showColumn('fbosDirectovertime')"/>
      <el-table-column prop="fbosIndirectovertime" label="间接加班" align="center" v-if="columns.showColumn('fbosIndirectovertime')"/>
      <el-table-column prop="fbosOvertimetotal" label="投入总加班" align="center" v-if="columns.showColumn('fbosOvertimetotal')"/>
      <el-table-column prop="fbosFlag" label="启用标记" align="center" v-if="columns.showColumn('fbosFlag')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.fbosFlag"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbosAudit" label="审核" align="center" v-if="columns.showColumn('fbosAudit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.fbosAudit"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbosAuditName" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosAuditName')"/>
      <el-table-column prop="fbosAuditDate" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbosAuditDate')"/>
      <el-table-column prop="fbosUndoName" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbosUndoName')"/>
      <el-table-column prop="fbosUndoDate" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbosUndoDate')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetovertimeslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetovertimeslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改加班预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="fbosSfid">
              <el-input v-model.number="form.fbosSfid" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="FbosParentSfid" prop="fbosParentSfid">
              <el-input v-model.number="form.fbosParentSfid" :placeholder="$t('btn.enterPrefix')+'FbosParentSfid'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="fbosTitle">
              <el-select filterable clearable   v-model="form.fbosTitle"  :placeholder="$t('btn.selectPrefix')+'科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_budget_title" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="名称" prop="fbosClass">
              <el-input v-model="form.fbosClass" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="必要工数" prop="fbosRequiredst">
              <el-input-number v-model.number="form.fbosRequiredst" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'必要工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="保有人数" prop="fbosDirectEmployee">
              <el-input-number v-model.number="form.fbosDirectEmployee" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="fbosIndirectEmployee">
              <el-input-number v-model.number="form.fbosIndirectEmployee" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="上班天数" prop="fbosDays">
              <el-input-number v-model.number="form.fbosDays" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上班天数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="加班事由" prop="fbosContent">
              <el-input v-model="form.fbosContent" :placeholder="$t('btn.enterPrefix')+'加班事由'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="保有工数" prop="fbosRetainst">
              <el-input-number v-model.number="form.fbosRetainst" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工数差异" prop="fbosRetainstdiff">
              <el-input-number v-model.number="form.fbosRetainstdiff" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工数差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入加班" prop="fbosOvertime">
              <el-input-number v-model.number="form.fbosOvertime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="平均投入加班" prop="fbosDirectovertime">
              <el-input-number v-model.number="form.fbosDirectovertime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'平均投入加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接加班" prop="fbosIndirectovertime">
              <el-input-number v-model.number="form.fbosIndirectovertime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入总加班" prop="fbosOvertimetotal">
              <el-input-number v-model.number="form.fbosOvertimetotal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入总加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用标记" prop="fbosFlag">
              <el-select filterable clearable   v-model="form.fbosFlag"  :placeholder="$t('btn.selectPrefix')+'启用标记'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="审核" prop="fbosAudit">
              <el-select filterable clearable   v-model="form.fbosAudit"  :placeholder="$t('btn.selectPrefix')+'审核'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="审核人员" prop="fbosAuditName">
              <el-input v-model="form.fbosAuditName" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="fbosAuditDate">
              <el-date-picker v-model="form.fbosAuditDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="fbosUndoName">
              <el-input v-model="form.fbosUndoName" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="fbosUndoDate">
              <el-date-picker v-model="form.fbosUndoDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
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

<script setup name="ficobudgetovertimeslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetOvertimeSlv,
 addFicoBudgetOvertimeSlv, delFicoBudgetOvertimeSlv, 
 updateFicoBudgetOvertimeSlv,getFicoBudgetOvertimeSlv, 
 } 
from '@/api/accounting/ficobudgetovertimeslv.js'
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
  fbosTitle: undefined,
//是否查询（1是）
  fbosClass: undefined,
//是否查询（1是）
  fbosFlag: undefined,
//是否查询（1是）
  fbosAudit: undefined,
//是否查询（1是）
  fbosAuditDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbosSfid', label: 'SFID' },
  { visible: true, prop: 'fbosParentSfid', label: 'FbosParentSfid' },
  { visible: true, prop: 'fbosTitle', label: '科目' },
  { visible: true, prop: 'fbosClass', label: '名称' },
  { visible: true, prop: 'fbosRequiredst', label: '必要工数' },
  { visible: true, prop: 'fbosDirectEmployee', label: '保有人数' },
  { visible: true, prop: 'fbosIndirectEmployee', label: '间接人数' },
  { visible: true, prop: 'fbosDays', label: '上班天数' },
  { visible: false, prop: 'fbosContent', label: '加班事由' },
  { visible: false, prop: 'fbosRetainst', label: '保有工数' },
  { visible: false, prop: 'fbosRetainstdiff', label: '工数差异' },
  { visible: false, prop: 'fbosOvertime', label: '投入加班' },
  { visible: false, prop: 'fbosDirectovertime', label: '平均投入加班' },
  { visible: false, prop: 'fbosIndirectovertime', label: '间接加班' },
  { visible: false, prop: 'fbosOvertimetotal', label: '投入总加班' },
  { visible: false, prop: 'fbosFlag', label: '启用标记' },
  { visible: false, prop: 'fbosAudit', label: '审核' },
  { visible: false, prop: 'fbosAuditName', label: '审核人员' },
  { visible: false, prop: 'fbosAuditDate', label: '审核日期' },
  { visible: false, prop: 'fbosUndoName', label: '撤消人员' },
  { visible: false, prop: 'fbosUndoDate', label: '撤消日期' },
  { visible: false, prop: 'remark', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
  { visible: false, prop: 'updateBy', label: '更新者' },
  { visible: false, prop: 'updateTime', label: '更新时间' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
// 审核日期时间范围
const dateRangeFbosAuditDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_budget_title" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从加班预算/fico_budget_overtime_slv表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeFbosAuditDate.value, 'FbosAuditDate');
  loading.value = true
  listFicoBudgetOvertimeSlv(queryParams).then(res => {
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
  // 审核日期时间范围
  dateRangeFbosAuditDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.fbosSfid);
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
    fbosSfid: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    fbosParentSfid: [{ required: true, message: "FbosParentSfid"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    fbosTitle: [{ required: true, message: "科目"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    fbosClass: [{ required: true, message: "名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosRequiredst: [{ required: true, message: "必要工数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosDirectEmployee: [{ required: true, message: "保有人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    fbosIndirectEmployee: [{ required: true, message: "间接人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    fbosDays: [{ required: true, message: "上班天数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    fbosContent: [{ required: true, message: "加班事由"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosRetainst: [{ required: true, message: "保有工数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosRetainstdiff: [{ required: true, message: "工数差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosOvertime: [{ required: true, message: "投入加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosDirectovertime: [{ required: true, message: "平均投入加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosIndirectovertime: [{ required: true, message: "间接加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosOvertimetotal: [{ required: true, message: "投入总加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbosFlag: [{ required: true, message: "启用标记"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    fbosAudit: [{ required: true, message: "审核"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_budget_title: [],
    // 启用标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_flag_list: [],
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
    fbosSfid: 0,
    fbosParentSfid: 0,
    fbosTitle: null,
    fbosClass: null,
    fbosRequiredst: 0,
    fbosDirectEmployee: 0,
    fbosIndirectEmployee: 0,
    fbosDays: 0,
    fbosContent: null,
    fbosRetainst: 0,
    fbosRetainstdiff: 0,
    fbosOvertime: 0,
    fbosDirectovertime: 0,
    fbosIndirectovertime: 0,
    fbosOvertimetotal: 0,
    fbosFlag: 0,
    fbosAudit: 0,
    fbosAuditName: null,
    fbosAuditDate: null,
    fbosUndoName: null,
    fbosUndoDate: null,
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
  title.value = proxy.$t('btn.add')+" "+'加班预算'
  opertype.value = 1
  form.value.fbosTitle= []
  form.value.fbosRequiredst= 0
  form.value.fbosDirectEmployee= 0
  form.value.fbosIndirectEmployee= 0
  form.value.fbosDays= 0
  form.value.fbosRetainst= 0
  form.value.fbosRetainstdiff= 0
  form.value.fbosOvertime= 0
  form.value.fbosDirectovertime= 0
  form.value.fbosIndirectovertime= 0
  form.value.fbosOvertimetotal= 0
  form.value.fbosFlag= 0
  form.value.fbosAudit= 0
  form.value.fbosAuditDate= new Date()
  form.value.fbosUndoDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbosSfid || ids.value
  getFicoBudgetOvertimeSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '加班预算'
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

      if (form.value.fbosSfid != undefined && opertype.value === 2) {
        updateFicoBudgetOvertimeSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetOvertimeSlv(form.value).then((res) => {
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
  const Ids = row.fbosSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetOvertimeSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<加班预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetOvertimeSlv/export', { ...queryParams })
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