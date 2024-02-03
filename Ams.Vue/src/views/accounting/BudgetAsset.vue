<!--
 * @Descripttion: (资产预算/fico_budget_asset)
 * @Version: (0.24.390.20476)
 * @Author: (Lean365)
 * @Date: (2024/1/25 13:57:42)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="公司" prop="fbaCorp">
        <el-select clearable filterable  v-model="queryParams.fbaCorp" :placeholder="$t('btn.select')+'公司'">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="部门" prop="fbaDept">
        <el-select clearable filterable  v-model="queryParams.fbaDept" :placeholder="$t('btn.select')+'部门'">
          <el-option v-for="item in  options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="fbaFm">
        <el-select clearable filterable  v-model="queryParams.fbaFm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ficoym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目" prop="fbaTitle">
        <el-select clearable filterable  v-model="queryParams.fbaTitle" :placeholder="$t('btn.select')+'科目'">
          <el-option v-for="item in  options.sql_recon_account " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="类别" prop="fbaClass">
        <el-select clearable filterable  v-model="queryParams.fbaClass" :placeholder="$t('btn.select')+'类别'">
          <el-option v-for="item in  options.app_exp_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="审核日期">
        <el-date-picker
          v-model="dateRangeFbaAuditDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="撤消日期">
        <el-date-picker
          v-model="dateRangeFbaUndoDate" 
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
        <el-button type="primary" v-hasPermi="['fico:budgetasset:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:budgetasset:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:budgetasset:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetasset:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="accounting/BudgetAsset/importTemplate"
                  importUrl="/accounting/BudgetAsset/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetasset:export']">
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
      <el-table-column prop="fbaSFID" label="SFID" align="center" v-if="columns.showColumn('fbaSFID')"/>
      <el-table-column prop="fbaCorp" label="公司" align="center" v-if="columns.showColumn('fbaCorp')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.fbaCorp"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaDept" label="部门" align="center" v-if="columns.showColumn('fbaDept')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.fbaDept"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaFy" label="财年" align="center" v-if="columns.showColumn('fbaFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.fbaFy"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaFm" label="年月" align="center" v-if="columns.showColumn('fbaFm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ficoym_list " :value="scope.row.fbaFm"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaTitle" label="科目" align="center" v-if="columns.showColumn('fbaTitle')">
        <template #default="scope">
          <dict-tag :options=" options.sql_recon_account " :value="scope.row.fbaTitle"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaClass" label="类别" align="center" v-if="columns.showColumn('fbaClass')">
        <template #default="scope">
          <dict-tag :options=" options.app_exp_type " :value="scope.row.fbaClass"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaName" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbaName')"/>
      <el-table-column prop="fbaDesc" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbaDesc')"/>
      <el-table-column prop="fbaServiceLife" label="年限" align="center" v-if="columns.showColumn('fbaServiceLife')"/>
      <el-table-column prop="fbaBudgetAmount" label="预算" align="center" v-if="columns.showColumn('fbaBudgetAmount')"/>
      <el-table-column prop="fbaActualAmount" label="实际" align="center" v-if="columns.showColumn('fbaActualAmount')"/>
      <el-table-column prop="fbaDifferenceAmount" label="差异" align="center" v-if="columns.showColumn('fbaDifferenceAmount')"/>
      <el-table-column prop="fbaDepreciation" label="折旧" align="center" v-if="columns.showColumn('fbaDepreciation')"/>
      <el-table-column prop="fbaFlag" label="启用" align="center" v-if="columns.showColumn('fbaFlag')"/>
      <el-table-column prop="fbaAudit" label="审核标志" align="center" v-if="columns.showColumn('fbaAudit')"/>
      <el-table-column prop="fbaAuditName" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbaAuditName')"/>
      <el-table-column prop="fbaAuditDate" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbaAuditDate')"/>
      <el-table-column prop="fbaUndoName" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbaUndoName')"/>
      <el-table-column prop="fbaUndoDate" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbaUndoDate')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetasset:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetasset:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改资产预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="fbaSFID">
              <el-input v-model.number="form.fbaSFID" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司" prop="fbaCorp">
              <el-select clearable filterable v-model="form.fbaCorp"  :placeholder="$t('btn.select')+'公司'">
                <el-option
                  v-for="item in options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="部门" prop="fbaDept">
              <el-select clearable filterable v-model="form.fbaDept"  :placeholder="$t('btn.select')+'部门'">
                <el-option
                  v-for="item in options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="财年" prop="fbaFy">
              <el-select clearable filterable v-model="form.fbaFy"  :placeholder="$t('btn.select')+'财年'">
                <el-option
                  v-for="item in options.sql_period_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="fbaFm">
              <el-select clearable filterable v-model="form.fbaFm"  :placeholder="$t('btn.select')+'年月'">
                <el-option
                  v-for="item in options.sql_ficoym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="科目" prop="fbaTitle">
              <el-select clearable filterable v-model="form.fbaTitle"  :placeholder="$t('btn.select')+'科目'">
                <el-option
                  v-for="item in options.sql_recon_account" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别" prop="fbaClass">
              <el-select clearable filterable v-model="form.fbaClass"  :placeholder="$t('btn.select')+'类别'">
                <el-option
                  v-for="item in options.app_exp_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="fbaName">
              <el-input clearable v-model="form.fbaName" :placeholder="$t('btn.enter')+'名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="fbaDesc">
              <el-input clearable v-model="form.fbaDesc" :placeholder="$t('btn.enter')+'说明'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="年限" prop="fbaServiceLife">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fbaServiceLife" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'年限'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="fbaBudgetAmount">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fbaBudgetAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'预算'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="fbaActualAmount">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fbaActualAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'实际'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="fbaDifferenceAmount">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fbaDifferenceAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'差异'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折旧" prop="fbaDepreciation">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fbaDepreciation" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'折旧'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用" prop="fbaFlag">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fbaFlag" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'启用'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="审核标志" prop="fbaAudit">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fbaAudit" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'审核标志'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="fbaAuditName">
              <el-input clearable v-model="form.fbaAuditName" :placeholder="$t('btn.enter')+'审核人员'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="fbaAuditDate">
              <el-date-picker v-model="form.fbaAuditDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="fbaUndoName">
              <el-input clearable v-model="form.fbaUndoName" :placeholder="$t('btn.enter')+'撤消人员'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="fbaUndoDate">
              <el-date-picker v-model="form.fbaUndoDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
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

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
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

<script setup name="budgetasset">
//后台操作函数
import { listBudgetAsset,
 addBudgetAsset, delBudgetAsset, 
 updateBudgetAsset,getBudgetAsset, 
 } 
from '@/api/accounting/budgetasset.js'
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
  fbaCorp: undefined,
  fbaDept: undefined,
  fbaFm: undefined,
  fbaTitle: undefined,
  fbaClass: undefined,
  fbaAuditDate: undefined,
  fbaUndoDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'fbaSFID', label: 'SFID' },
  { visible: true, prop: 'fbaCorp', label: '公司' },
  { visible: true, prop: 'fbaDept', label: '部门' },
  { visible: true, prop: 'fbaFy', label: '财年' },
  { visible: true, prop: 'fbaFm', label: '年月' },
  { visible: true, prop: 'fbaTitle', label: '科目' },
  { visible: true, prop: 'fbaClass', label: '类别' },
  { visible: true, prop: 'fbaName', label: '名称' },
  { visible: false, prop: 'fbaDesc', label: '说明' },
  { visible: false, prop: 'fbaServiceLife', label: '年限' },
  { visible: false, prop: 'fbaBudgetAmount', label: '预算' },
  { visible: false, prop: 'fbaActualAmount', label: '实际' },
  { visible: false, prop: 'fbaDifferenceAmount', label: '差异' },
  { visible: false, prop: 'fbaDepreciation', label: '折旧' },
  { visible: false, prop: 'fbaFlag', label: '启用' },
  { visible: false, prop: 'fbaAudit', label: '审核标志' },
  { visible: false, prop: 'fbaAuditName', label: '审核人员' },
  { visible: false, prop: 'fbaAuditDate', label: '审核日期' },
  { visible: false, prop: 'fbaUndoName', label: '撤消人员' },
  { visible: false, prop: 'fbaUndoDate', label: '撤消日期' },
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
// 审核日期时间范围
const dateRangeFbaAuditDate = ref([])
// 撤消日期时间范围
const dateRangeFbaUndoDate = ref([])
//字典参数
var dictParams = [
  { dictType: "sys_crop_list" },
  { dictType: "sql_dept_list" },
  { dictType: "sql_period_list" },
  { dictType: "sql_ficoym_list" },
  { dictType: "sql_recon_account" },
  { dictType: "app_exp_type" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从资产预算/fico_budget_asset表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeFbaAuditDate.value, 'FbaAuditDate');
  proxy.addDateRange(queryParams, dateRangeFbaUndoDate.value, 'FbaUndoDate');
  loading.value = true
  listBudgetAsset(queryParams).then(res => {
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
  dateRangeFbaAuditDate.value = []
  // 撤消日期时间范围
  dateRangeFbaUndoDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.fbaSFID);
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
    fbaSFID: [{ required: true, message: 'SFID'+ proxy.$t('btn.empty'), trigger: "blur" }],
    fbaCorp: [{ required: true, message: '公司'+ proxy.$t('btn.empty'), trigger: "change"     }],
    fbaDept: [{ required: true, message: '部门'+ proxy.$t('btn.empty'), trigger: "change"     }],
    fbaFy: [{ required: true, message: '财年'+ proxy.$t('btn.empty'), trigger: "change"     }],
    fbaFm: [{ required: true, message: '年月'+ proxy.$t('btn.empty'), trigger: "change"     }],
    fbaTitle: [{ required: true, message: '科目'+ proxy.$t('btn.empty'), trigger: "change"    , type: "number"  }],
    fbaClass: [{ required: true, message: '类别'+ proxy.$t('btn.empty'), trigger: "change"     }],
    fbaName: [{ required: true, message: '名称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    fbaDesc: [{ required: true, message: '说明'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    fbaServiceLife: [{ required: true, message: '年限'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
    fbaBudgetAmount: [{ required: true, message: '预算'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    fbaActualAmount: [{ required: true, message: '实际'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    fbaDifferenceAmount: [{ required: true, message: '差异'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    fbaDepreciation: [{ required: true, message: '折旧'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    fbaFlag: [{ required: true, message: '启用'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
    fbaAudit: [{ required: true, message: '审核标志'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
    // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // 财年 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_period_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ficoym_list: [],
    // 科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_recon_account: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_exp_type: [],
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
// @Version: (0.24.390.20476)
// @Author: (Lean365)
// @Date: (2024/1/25 13:57:42)



// 重置表单
function reset() {
  form.value = {
    fbaSFID: 0,
    fbaCorp: null,
    fbaDept: null,
    fbaFy: null,
    fbaFm: null,
    fbaTitle: 0,
    fbaClass: null,
    fbaName: null,
    fbaDesc: null,
    fbaServiceLife: 0,
    fbaBudgetAmount: 0,
    fbaActualAmount: 0,
    fbaDifferenceAmount: 0,
    fbaDepreciation: 0,
    fbaFlag: 0,
    fbaAudit: 0,
    fbaAuditName: null,
    fbaAuditDate: null,
    fbaUndoName: null,
    fbaUndoDate: null,
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
  title.value = proxy.$t('btn.add')+'资产预算'
  opertype.value = 1
  form.value.fbaCorp= []
  form.value.fbaDept= []
  form.value.fbaFy= []
  form.value.fbaFm= []
  form.value.fbaTitle= 0
  form.value.fbaClass= []
  form.value.fbaServiceLife= 0
  form.value.fbaBudgetAmount= 0
  form.value.fbaActualAmount= 0
  form.value.fbaDifferenceAmount= 0
  form.value.fbaDepreciation= 0
  form.value.fbaFlag= 0
  form.value.fbaAudit= 0
  form.value.fbaAuditDate= new Date()
  form.value.fbaUndoDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbaSFID || ids.value
  getBudgetAsset(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ '资产预算'
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

      if (form.value.fbaSFID != undefined && opertype.value === 2) {
        updateBudgetAsset(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addBudgetAsset(form.value).then((res) => {
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
  const Ids = row.fbaSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delBudgetAsset(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"资产预算", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/accounting/BudgetAsset/export', { ...queryParams })
    })
}


// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.390.20476)
// @Author: (Lean365)
// @Date: (2024/1/25 13:57:42)

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