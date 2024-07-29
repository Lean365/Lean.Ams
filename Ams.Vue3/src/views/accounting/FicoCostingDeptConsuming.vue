<!--
 * @Descripttion: 部门消耗/fico_costing_dept_consuming
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 17:02:09
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="期间" prop="dcFy">
        <el-select filterable clearable   v-model="queryParams.dcFy" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_fy_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="dcYm">
        <el-select filterable clearable   v-model="queryParams.dcYm" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司代码" prop="dcCorpCode">
        <el-select filterable clearable   v-model="queryParams.dcCorpCode" :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工厂" prop="dcPlant">
        <el-select filterable clearable   v-model="queryParams.dcPlant" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="dcMateriel">
        <el-input v-model="queryParams.dcMateriel" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="仓库" prop="dcStorageLocation">
        <el-input v-model="queryParams.dcStorageLocation" :placeholder="$t('btn.enterSearchPrefix')+'仓库'+$t('btn.enterSearchSuffix')" />
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
      <el-table-column prop="dcSfid" label="SFID" align="center" v-if="columns.showColumn('dcSfid')"/>
      <el-table-column prop="dcFy" label="期间" align="center" v-if="columns.showColumn('dcFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_fy_list " :value="scope.row.dcFy"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcYm" label="年月" align="center" v-if="columns.showColumn('dcYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.dcYm"  />
        </template>
      </el-table-column>
      <el-table-column prop="dcCorpCode" label="公司代码" align="center" v-if="columns.showColumn('dcCorpCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.dcCorpCode"  />
        </template>
      </el-table-column>
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
      <el-table-column prop="dcPlant" label="工厂" align="center" v-if="columns.showColumn('dcPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.dcPlant"  />
        </template>
      </el-table-column>
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
            <el-form-item label="SFID" prop="dcSfid">
              <el-input v-model.number="form.dcSfid" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="dcFy">
              <el-select filterable clearable   v-model="form.dcFy"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_fy_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="dcYm">
              <el-select filterable clearable   v-model="form.dcYm"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司代码" prop="dcCorpCode">
              <el-select filterable clearable   v-model="form.dcCorpCode"  :placeholder="$t('btn.selectPrefix')+'公司代码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司名称" prop="dcCorpName">
              <el-input v-model="form.dcCorpName" :placeholder="$t('btn.enterPrefix')+'公司名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统计类别" prop="dcExpCategory">
              <el-input v-model="form.dcExpCategory" :placeholder="$t('btn.enterPrefix')+'统计类别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本代码" prop="dcCostCode">
              <el-input v-model="form.dcCostCode" :placeholder="$t('btn.enterPrefix')+'成本代码'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本名称" prop="dcCostName">
              <el-input v-model="form.dcCostName" :placeholder="$t('btn.enterPrefix')+'成本名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="dcTitleCode">
              <el-input v-model="form.dcTitleCode" :placeholder="$t('btn.enterPrefix')+'科目代码'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称" prop="dcTitleName">
              <el-input v-model="form.dcTitleName" :placeholder="$t('btn.enterPrefix')+'科目名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目分类" prop="dcTitleNote">
              <el-input v-model="form.dcTitleNote" :placeholder="$t('btn.enterPrefix')+'科目分类'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预算" prop="dcBudgetAmt">
              <el-input-number v-model.number="form.dcBudgetAmt" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际" prop="dcActualAmt">
              <el-input-number v-model.number="form.dcActualAmt" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异" prop="dcDiffAmt">
              <el-input-number v-model.number="form.dcDiffAmt" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="dcPlant">
              <el-select filterable clearable   v-model="form.dcPlant"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料" prop="dcMateriel">
              <el-input v-model="form.dcMateriel" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="dcStorageLocation">
              <el-input v-model="form.dcStorageLocation" :placeholder="$t('btn.enterPrefix')+'仓库'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动类型" prop="dcMoveType">
              <el-input v-model="form.dcMoveType" :placeholder="$t('btn.enterPrefix')+'移动类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料凭证" prop="dcMaterielDoc">
              <el-input v-model="form.dcMaterielDoc" :placeholder="$t('btn.enterPrefix')+'物料凭证'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="dcMaterielDocDetails">
              <el-input v-model="form.dcMaterielDocDetails" :placeholder="$t('btn.enterPrefix')+'凭证明细'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="dcUseQty">
              <el-input-number v-model.number="form.dcUseQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额" prop="dcUseAmt">
              <el-input-number v-model.number="form.dcUseAmt" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留单" prop="dcReserveDoc">
              <el-input v-model="form.dcReserveDoc" :placeholder="$t('btn.enterPrefix')+'预留单'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留明细" prop="dcAccountant">
              <el-input v-model="form.dcAccountant" :placeholder="$t('btn.enterPrefix')+'预留明细'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="登录日期" prop="dcBalanceDate">
              <el-date-picker v-model="form.dcBalanceDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

          <el-col :lg="24">
            <el-form-item label="说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')"/>
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
  sort: 'DcYm',
  sortType: 'desc',
//是否查询（1是）
  dcFy: undefined,
//是否查询（1是）
  dcYm: undefined,
//是否查询（1是）
  dcCorpCode: undefined,
//是否查询（1是）
  dcPlant: undefined,
//是否查询（1是）
  dcMateriel: undefined,
//是否查询（1是）
  dcStorageLocation: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'dcSfid', label: 'SFID' },
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
  { dictType: "sys_plant_list" },
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
  ids.value = selection.map((item) => item.dcSfid);
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
    dcSfid: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    dcFy: [{ required: true, message: "期间"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    dcYm: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    dcCorpCode: [{ required: true, message: "公司代码"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    dcCorpName: [{ required: true, message: "公司名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcExpCategory: [{ required: true, message: "统计类别"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcCostCode: [{ required: true, message: "成本代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcCostName: [{ required: true, message: "成本名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcTitleCode: [{ required: true, message: "科目代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcTitleName: [{ required: true, message: "科目名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcTitleNote: [{ required: true, message: "科目分类"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcBudgetAmt: [{ required: true, message: "预算"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcActualAmt: [{ required: true, message: "实际"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcDiffAmt: [{ required: true, message: "差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcPlant: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    dcMateriel: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcStorageLocation: [{ required: true, message: "仓库"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcMoveType: [{ required: true, message: "移动类型"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcMaterielDoc: [{ required: true, message: "物料凭证"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcMaterielDocDetails: [{ required: true, message: "凭证明细"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcUseQty: [{ required: true, message: "数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcUseAmt: [{ required: true, message: "金额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcReserveDoc: [{ required: true, message: "预留单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcAccountant: [{ required: true, message: "预留明细"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    dcBalanceDate: [{ required: true, message: "登录日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_fy_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ym_list: [],
    // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_plant_list: [],
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
    dcSfid: 0,
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
  title.value = proxy.$t('btn.add')+" "+'部门消耗'
  opertype.value = 1
  form.value.dcFy= []
  form.value.dcYm= []
  form.value.dcCorpCode= []
  form.value.dcBudgetAmt= 0
  form.value.dcActualAmt= 0
  form.value.dcDiffAmt= 0
  form.value.dcPlant= []
  form.value.dcUseQty= 0
  form.value.dcUseAmt= 0
  form.value.dcBalanceDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.dcSfid || ids.value
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

      if (form.value.dcSfid != undefined && opertype.value === 2) {
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
  const Ids = row.dcSfid || ids.value

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