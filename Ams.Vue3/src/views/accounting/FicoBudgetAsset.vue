<!--
 * @Descripttion: 资产预算/fico_budget_asset
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 16:26:07
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="公司" prop="fbaCorp">
        <el-select filterable clearable   v-model="queryParams.fbaCorp" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="部门" prop="fbaDept">
        <el-select filterable clearable   v-model="queryParams.fbaDept" :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="财年" prop="fbaFy">
        <el-select filterable clearable   v-model="queryParams.fbaFy" :placeholder="$t('btn.selectSearchPrefix')+'财年'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_fy_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="fbaFm">
        <el-select filterable clearable   v-model="queryParams.fbaFm" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目" prop="fbaTitle">
        <el-select filterable clearable   v-model="queryParams.fbaTitle" :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_recon_account " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="类别" prop="fbaClass">
        <el-select filterable clearable   v-model="queryParams.fbaClass" :placeholder="$t('btn.selectSearchPrefix')+'类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_assets_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="名称" prop="fbaName">
        <el-input v-model="queryParams.fbaName" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="启用" prop="fbaFlag">
        <el-select filterable clearable   v-model="queryParams.fbaFlag" :placeholder="$t('btn.selectSearchPrefix')+'启用'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_normal_whether " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="审核标志" prop="fbaAudit">
        <el-select filterable clearable   v-model="queryParams.fbaAudit" :placeholder="$t('btn.selectSearchPrefix')+'审核标志'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_audit_flag " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetasset:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetasset:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetasset:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetasset:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetAsset/importTemplate"
                  importUrl="/Accounting/FicoBudgetAsset/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetasset:export']">
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
          <dict-tag :options=" options.sql_fy_list " :value="scope.row.fbaFy"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaFm" label="年月" align="center" v-if="columns.showColumn('fbaFm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.fbaFm"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaTitle" label="科目" align="center" v-if="columns.showColumn('fbaTitle')">
        <template #default="scope">
          <dict-tag :options=" options.sql_recon_account " :value="scope.row.fbaTitle"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaClass" label="类别" align="center" v-if="columns.showColumn('fbaClass')">
        <template #default="scope">
          <dict-tag :options=" options.sys_assets_type " :value="scope.row.fbaClass"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaName" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbaName')"/>
      <el-table-column prop="fbaDesc" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbaDesc')"/>
      <el-table-column prop="fbaServiceLife" label="年限" align="center" v-if="columns.showColumn('fbaServiceLife')"/>
      <el-table-column prop="fbaBudgetAmount" label="预算" align="center" v-if="columns.showColumn('fbaBudgetAmount')"/>
      <el-table-column prop="fbaActualAmount" label="实际" align="center" v-if="columns.showColumn('fbaActualAmount')"/>
      <el-table-column prop="fbaDifferenceAmount" label="差异" align="center" v-if="columns.showColumn('fbaDifferenceAmount')"/>
      <el-table-column prop="fbaDepreciation" label="折旧" align="center" v-if="columns.showColumn('fbaDepreciation')"/>
      <el-table-column prop="fbaFlag" label="启用" align="center" v-if="columns.showColumn('fbaFlag')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.fbaFlag"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaAudit" label="审核标志" align="center" v-if="columns.showColumn('fbaAudit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_audit_flag " :value="scope.row.fbaAudit"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaAuditName" label="审核人员" align="center" v-if="columns.showColumn('fbaAuditName')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.fbaAuditName"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaAuditDate" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbaAuditDate')"/>
      <el-table-column prop="fbaUndoName" label="撤消人员" align="center" v-if="columns.showColumn('fbaUndoName')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.fbaUndoName"  />
        </template>
      </el-table-column>
      <el-table-column prop="fbaUndoDate" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('fbaUndoDate')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetasset:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetasset:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
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
              <el-input v-model.number="form.fbaSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司" prop="fbaCorp">
              <el-select filterable clearable   v-model="form.fbaCorp"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="部门" prop="fbaDept">
              <el-select filterable clearable   v-model="form.fbaDept"  :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="财年" prop="fbaFy">
              <el-select filterable clearable   v-model="form.fbaFy"  :placeholder="$t('btn.selectPrefix')+'财年'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_fy_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="fbaFm">
              <el-select filterable clearable   v-model="form.fbaFm"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="科目" prop="fbaTitle">
              <el-select filterable clearable   v-model="form.fbaTitle"  :placeholder="$t('btn.selectPrefix')+'科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_recon_account" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="类别" prop="fbaClass">
              <el-select filterable clearable   v-model="form.fbaClass"  :placeholder="$t('btn.selectPrefix')+'类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_assets_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="名称" prop="fbaName">
              <el-input v-model="form.fbaName" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="fbaDesc">
              <el-input v-model="form.fbaDesc" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="年限" prop="fbaServiceLife">
              <el-input-number v-model.number="form.fbaServiceLife" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'年限'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="fbaBudgetAmount">
              <el-input-number v-model.number="form.fbaBudgetAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="fbaActualAmount">
              <el-input-number v-model.number="form.fbaActualAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="fbaDifferenceAmount">
              <el-input-number v-model.number="form.fbaDifferenceAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折旧" prop="fbaDepreciation">
              <el-input-number v-model.number="form.fbaDepreciation" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'折旧'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用" prop="fbaFlag">
              <el-select filterable clearable   v-model="form.fbaFlag"  :placeholder="$t('btn.selectPrefix')+'启用'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_normal_whether" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="审核标志" prop="fbaAudit">
              <el-select filterable clearable   v-model="form.fbaAudit"  :placeholder="$t('btn.selectPrefix')+'审核标志'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_audit_flag" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="审核人员" prop="fbaAuditName">
              <el-select filterable clearable   v-model="form.fbaAuditName"  :placeholder="$t('btn.selectPrefix')+'审核人员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="审核日期" prop="fbaAuditDate">
              <el-date-picker v-model="form.fbaAuditDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="fbaUndoName">
              <el-select filterable clearable   v-model="form.fbaUndoName"  :placeholder="$t('btn.selectPrefix')+'撤消人员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="fbaUndoDate">
              <el-date-picker v-model="form.fbaUndoDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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
                <el-radio v-for="item in options.isDeletedOptions" :key="item.dictValue" :value="parseInt(item.dictValue)">
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

<script setup name="ficobudgetasset">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetAsset,
 addFicoBudgetAsset, delFicoBudgetAsset, 
 updateFicoBudgetAsset,getFicoBudgetAsset, 
 } 
from '@/api/accounting/ficobudgetasset.js'
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
  fbaCorp: undefined,
//是否查询（1是）
  fbaDept: undefined,
//是否查询（1是）
  fbaFy: undefined,
//是否查询（1是）
  fbaFm: undefined,
//是否查询（1是）
  fbaTitle: undefined,
//是否查询（1是）
  fbaClass: undefined,
//是否查询（1是）
  fbaName: undefined,
//是否查询（1是）
  fbaFlag: undefined,
//是否查询（1是）
  fbaAudit: undefined,
//是否查询（1是）
  fbaAuditDate: undefined,
//是否查询（1是）
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
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])



















// 审核日期时间范围
const dateRangeFbaAuditDate = ref([])



// 撤消日期时间范围
const dateRangeFbaUndoDate = ref([])




















//字典参数
var dictParams = [
  { dictType: "sys_crop_list" },
  { dictType: "sql_dept_list" },
  { dictType: "sql_fy_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sql_recon_account" },
  { dictType: "sys_assets_type" },
  { dictType: "sys_normal_whether" },
  { dictType: "sys_audit_flag" },
  { dictType: "sql_ec_group" },
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
  listFicoBudgetAsset(queryParams).then(res => {
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
    fbaSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    fbaCorp: [{ required: true, message: "公司"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    fbaDept: [{ required: true, message: "部门"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    fbaFy: [{ required: true, message: "财年"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    fbaFm: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    fbaTitle: [{ required: true, message: "科目"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    fbaClass: [{ required: true, message: "类别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    fbaName: [{ required: true, message: "名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbaDesc: [{ required: true, message: "说明"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbaServiceLife: [{ required: true, message: "年限"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    fbaBudgetAmount: [{ required: true, message: "预算"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbaActualAmount: [{ required: true, message: "实际"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbaDifferenceAmount: [{ required: true, message: "差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbaDepreciation: [{ required: true, message: "折旧"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    fbaFlag: [{ required: true, message: "启用"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    fbaAudit: [{ required: true, message: "审核标志"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
    // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // 财年 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_fy_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ym_list: [],
    // 科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_recon_account: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_assets_type: [],
    // 启用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_normal_whether: [],
    // 审核标志 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_audit_flag: [],
    // 审核人员 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ec_group: [],
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
    fbaSFID: 0,
    fbaCorp: null,
    fbaDept: null,
    fbaFy: null,
    fbaFm: null,
    fbaTitle: null,
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
  title.value = proxy.$t('btn.add')+" "+'资产预算'
  opertype.value = 1
  form.value.fbaCorp= []
  form.value.fbaDept= []
  form.value.fbaFy= []
  form.value.fbaFm= []
  form.value.fbaTitle= []
  form.value.fbaClass= []
  form.value.fbaServiceLife= 0
  form.value.fbaBudgetAmount= 0
  form.value.fbaActualAmount= 0
  form.value.fbaDifferenceAmount= 0
  form.value.fbaDepreciation= 0
  form.value.fbaFlag= 0
  form.value.fbaAudit= 0
  form.value.fbaAuditName= []
  form.value.fbaAuditDate= new Date()
  form.value.fbaUndoName= []
  form.value.fbaUndoDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.fbaSFID || ids.value
  getFicoBudgetAsset(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '资产预算'
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
        updateFicoBudgetAsset(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetAsset(form.value).then((res) => {
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
  const Ids = row.fbaSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetAsset(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<资产预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetAsset/export', { ...queryParams })
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