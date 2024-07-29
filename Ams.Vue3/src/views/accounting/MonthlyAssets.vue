<!--
 * @Descripttion: 固定资产/fico_monthly_assets
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/25 15:47:09
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="公司" prop="faCorp">
        <el-select filterable clearable   v-model="queryParams.faCorp" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="使用部门" prop="faDept">
        <el-select filterable clearable   v-model="queryParams.faDept" :placeholder="$t('btn.selectSearchPrefix')+'使用部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="资产类别" prop="faClassCode">
        <el-select filterable clearable   v-model="queryParams.faClassCode" :placeholder="$t('btn.selectSearchPrefix')+'资产类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_assets_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="资产编码" prop="faAssetNo">
        <el-input v-model="queryParams.faAssetNo" :placeholder="$t('btn.enterSearchPrefix')+'资产编码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="成本中心" prop="faCostCenter">
        <el-select filterable clearable   v-model="queryParams.faCostCenter" :placeholder="$t('btn.selectSearchPrefix')+'成本中心'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="资产简称" prop="faAssetShortName">
        <el-input v-model="queryParams.faAssetShortName" :placeholder="$t('btn.enterSearchPrefix')+'资产简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="资产全称" prop="faAssetFullName">
        <el-input v-model="queryParams.faAssetFullName" :placeholder="$t('btn.enterSearchPrefix')+'资产全称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="管理区分" prop="faAssetMana">
        <el-select filterable clearable   v-model="queryParams.faAssetMana" :placeholder="$t('btn.selectSearchPrefix')+'管理区分'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_assets_dist " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="faAssetCcy">
        <el-select filterable clearable   v-model="queryParams.faAssetCcy" :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="资本化日期">
        <el-date-picker
          v-model="dateRangeFaCapitalizedDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="报废日期">
        <el-date-picker
          v-model="dateRangeFaScrapDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="资产形态" prop="faEntity">
        <el-select filterable clearable   v-model="queryParams.faEntity" :placeholder="$t('btn.selectSearchPrefix')+'资产形态'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_assets_pattern " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="盘点人员" prop="faCheckedby">
        <el-input v-model="queryParams.faCheckedby" :placeholder="$t('btn.enterSearchPrefix')+'盘点人员'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="盘点日期">
        <el-date-picker
          v-model="dateRangeFaCheckedDate" 
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
        <el-button class="btn-add" v-hasPermi="['fico:monthlyassets:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:monthlyassets:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:monthlyassets:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:monthlyassets:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/MonthlyAssets/importTemplate"
                  importUrl="/Accounting/MonthlyAssets/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:monthlyassets:export']">
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
      <el-table-column prop="faSfid" label="SFID" align="center" v-if="columns.showColumn('faSfid')"/>
      <el-table-column prop="faCorp" label="公司" align="center" v-if="columns.showColumn('faCorp')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.faCorp"  />
        </template>
      </el-table-column>
      <el-table-column prop="faDept" label="使用部门" align="center" v-if="columns.showColumn('faDept')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.faDept"  />
        </template>
      </el-table-column>
      <el-table-column prop="faClassCode" label="资产类别" align="center" v-if="columns.showColumn('faClassCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_assets_type " :value="scope.row.faClassCode"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAssetNo" label="资产编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetNo')"/>
      <el-table-column prop="faCostCenter" label="成本中心" align="center" v-if="columns.showColumn('faCostCenter')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.faCostCenter"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAssetShortName" label="资产简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetShortName')"/>
      <el-table-column prop="faAssetFullName" label="资产全称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetFullName')"/>
      <el-table-column prop="faAssetUnit" label="单位" align="center" v-if="columns.showColumn('faAssetUnit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.faAssetUnit"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAssetQty" label="数量" align="center" v-if="columns.showColumn('faAssetQty')"/>
      <el-table-column prop="faAssetMana" label="管理区分" align="center" v-if="columns.showColumn('faAssetMana')">
        <template #default="scope">
          <dict-tag :options=" options.sys_assets_dist " :value="scope.row.faAssetMana"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAssetCcy" label="币种" align="center" v-if="columns.showColumn('faAssetCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.faAssetCcy"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAcquisitionPrice" label="购买价格" align="center" v-if="columns.showColumn('faAcquisitionPrice')"/>
      <el-table-column prop="faCapitalizedDate" label="资本化日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faCapitalizedDate')"/>
      <el-table-column prop="faDepreciationValue" label="折旧价值" align="center" v-if="columns.showColumn('faDepreciationValue')"/>
      <el-table-column prop="faScrapDate" label="报废日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faScrapDate')"/>
      <el-table-column prop="faScrapValue" label="报废价值" align="center" v-if="columns.showColumn('faScrapValue')"/>
      <el-table-column prop="faLocale" label="存放位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faLocale')"/>
      <el-table-column prop="faAssetUsed" label="使用年限" align="center" v-if="columns.showColumn('faAssetUsed')"/>
      <el-table-column prop="faAssetStop" label="是否停用" align="center" v-if="columns.showColumn('faAssetStop')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.faAssetStop"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAssetVender" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetVender')"/>
      <el-table-column prop="faAssetManufacturer" label="制造商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetManufacturer')"/>
      <el-table-column prop="faAssetVenderItem" label="供应商物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetVenderItem')"/>
      <el-table-column prop="faAssetManufacturerItem" label="制造商物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetManufacturerItem')"/>
      <el-table-column prop="faEntity" label="资产形态" align="center" v-if="columns.showColumn('faEntity')">
        <template #default="scope">
          <dict-tag :options=" options.sys_assets_pattern " :value="scope.row.faEntity"  />
        </template>
      </el-table-column>
      <el-table-column prop="faHaveorNot" label="资产存在否" align="center" v-if="columns.showColumn('faHaveorNot')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.faHaveorNot"  />
        </template>
      </el-table-column>
      <el-table-column prop="faCheckedby" label="盘点人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faCheckedby')"/>
      <el-table-column prop="faCheckedDate" label="盘点日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faCheckedDate')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:monthlyassets:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:monthlyassets:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改固定资产对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="faSfid">
              <el-input v-model.number="form.faSfid" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司" prop="faCorp">
              <el-select filterable clearable   v-model="form.faCorp"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="使用部门" prop="faDept">
              <el-select filterable clearable   v-model="form.faDept"  :placeholder="$t('btn.selectPrefix')+'使用部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="资产类别" prop="faClassCode">
              <el-select filterable clearable   v-model="form.faClassCode"  :placeholder="$t('btn.selectPrefix')+'资产类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_assets_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="资产编码" prop="faAssetNo">
              <el-input v-model="form.faAssetNo" :placeholder="$t('btn.enterPrefix')+'资产编码'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本中心" prop="faCostCenter">
              <el-select filterable clearable   v-model="form.faCostCenter"  :placeholder="$t('btn.selectPrefix')+'成本中心'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="资产简称" prop="faAssetShortName">
              <el-input v-model="form.faAssetShortName" :placeholder="$t('btn.enterPrefix')+'资产简称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资产全称" prop="faAssetFullName">
              <el-input v-model="form.faAssetFullName" :placeholder="$t('btn.enterPrefix')+'资产全称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位" prop="faAssetUnit">
              <el-select filterable clearable   v-model="form.faAssetUnit"  :placeholder="$t('btn.selectPrefix')+'单位'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_unit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="数量" prop="faAssetQty">
              <el-input-number v-model.number="form.faAssetQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="管理区分" prop="faAssetMana">
              <el-select filterable clearable   v-model="form.faAssetMana"  :placeholder="$t('btn.selectPrefix')+'管理区分'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_assets_dist" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="币种" prop="faAssetCcy">
              <el-select filterable clearable   v-model="form.faAssetCcy"  :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="购买价格" prop="faAcquisitionPrice">
              <el-input-number v-model.number="form.faAcquisitionPrice" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'购买价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资本化日期" prop="faCapitalizedDate">
              <el-date-picker v-model="form.faCapitalizedDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折旧价值" prop="faDepreciationValue">
              <el-input-number v-model.number="form.faDepreciationValue" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'折旧价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="报废日期" prop="faScrapDate">
              <el-date-picker v-model="form.faScrapDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="报废价值" prop="faScrapValue">
              <el-input-number v-model.number="form.faScrapValue" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'报废价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="存放位置" prop="faLocale">
              <el-input v-model="form.faLocale" :placeholder="$t('btn.enterPrefix')+'存放位置'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="使用年限" prop="faAssetUsed">
              <el-input-number v-model.number="form.faAssetUsed" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'使用年限'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="是否停用" prop="faAssetStop">
              <el-radio-group v-model="form.faAssetStop">
                <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商" prop="faAssetVender">
              <el-input v-model="form.faAssetVender" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="faAssetManufacturer">
              <el-input v-model="form.faAssetManufacturer" :placeholder="$t('btn.enterPrefix')+'制造商'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商物料" prop="faAssetVenderItem">
              <el-input v-model="form.faAssetVenderItem" :placeholder="$t('btn.enterPrefix')+'供应商物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商物料" prop="faAssetManufacturerItem">
              <el-input v-model="form.faAssetManufacturerItem" :placeholder="$t('btn.enterPrefix')+'制造商物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="资产形态" prop="faEntity">
              <el-select filterable clearable   v-model="form.faEntity"  :placeholder="$t('btn.selectPrefix')+'资产形态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_assets_pattern" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="资产存在否" prop="faHaveorNot">
              <el-select filterable clearable   v-model="form.faHaveorNot"  :placeholder="$t('btn.selectPrefix')+'资产存在否'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="盘点人员" prop="faCheckedby">
              <el-input v-model="form.faCheckedby" :placeholder="$t('btn.enterPrefix')+'盘点人员'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="盘点日期" prop="faCheckedDate">
              <el-date-picker v-model="form.faCheckedDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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
            <el-form-item label="备注" prop="remark">
              <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
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

<script setup name="monthlyassets">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listMonthlyAssets,
 addMonthlyAssets, delMonthlyAssets, 
 updateMonthlyAssets,getMonthlyAssets, 
 } 
from '@/api/accounting/monthlyassets.js'
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
  faCorp: undefined,
//是否查询（1是）
  faDept: undefined,
//是否查询（1是）
  faClassCode: undefined,
//是否查询（1是）
  faAssetNo: undefined,
//是否查询（1是）
  faCostCenter: undefined,
//是否查询（1是）
  faAssetShortName: undefined,
//是否查询（1是）
  faAssetFullName: undefined,
//是否查询（1是）
  faAssetMana: undefined,
//是否查询（1是）
  faAssetCcy: undefined,
//是否查询（1是）
  faCapitalizedDate: undefined,
//是否查询（1是）
  faScrapDate: undefined,
//是否查询（1是）
  faEntity: undefined,
//是否查询（1是）
  faCheckedby: undefined,
//是否查询（1是）
  faCheckedDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'faSfid', label: 'SFID' },
  { visible: true, prop: 'faCorp', label: '公司' },
  { visible: true, prop: 'faDept', label: '使用部门' },
  { visible: true, prop: 'faClassCode', label: '资产类别' },
  { visible: true, prop: 'faAssetNo', label: '资产编码' },
  { visible: true, prop: 'faCostCenter', label: '成本中心' },
  { visible: true, prop: 'faAssetShortName', label: '资产简称' },
  { visible: true, prop: 'faAssetFullName', label: '资产全称' },
  { visible: false, prop: 'faAssetUnit', label: '单位' },
  { visible: false, prop: 'faAssetQty', label: '数量' },
  { visible: false, prop: 'faAssetMana', label: '管理区分' },
  { visible: false, prop: 'faAssetCcy', label: '币种' },
  { visible: false, prop: 'faAcquisitionPrice', label: '购买价格' },
  { visible: false, prop: 'faCapitalizedDate', label: '资本化日期' },
  { visible: false, prop: 'faDepreciationValue', label: '折旧价值' },
  { visible: false, prop: 'faScrapDate', label: '报废日期' },
  { visible: false, prop: 'faScrapValue', label: '报废价值' },
  { visible: false, prop: 'faLocale', label: '存放位置' },
  { visible: false, prop: 'faAssetUsed', label: '使用年限' },
  { visible: false, prop: 'faAssetStop', label: '是否停用' },
  { visible: false, prop: 'faAssetVender', label: '供应商' },
  { visible: false, prop: 'faAssetManufacturer', label: '制造商' },
  { visible: false, prop: 'faAssetVenderItem', label: '供应商物料' },
  { visible: false, prop: 'faAssetManufacturerItem', label: '制造商物料' },
  { visible: false, prop: 'faEntity', label: '资产形态' },
  { visible: false, prop: 'faHaveorNot', label: '资产存在否' },
  { visible: false, prop: 'faCheckedby', label: '盘点人员' },
  { visible: false, prop: 'faCheckedDate', label: '盘点日期' },
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
// 资本化日期时间范围
const dateRangeFaCapitalizedDate = ref([])
// 报废日期时间范围
const dateRangeFaScrapDate = ref([])
// 盘点日期时间范围
const dateRangeFaCheckedDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_crop_list" },
  { dictType: "sql_dept_list" },
  { dictType: "sys_assets_type" },
  { dictType: "sql_prctr_list" },
  { dictType: "sys_unit_list" },
  { dictType: "sys_assets_dist" },
  { dictType: "sys_ccy_type" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_assets_pattern" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从固定资产/fico_monthly_assets表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeFaCapitalizedDate.value, 'FaCapitalizedDate');
  proxy.addDateRange(queryParams, dateRangeFaScrapDate.value, 'FaScrapDate');
  proxy.addDateRange(queryParams, dateRangeFaCheckedDate.value, 'FaCheckedDate');
  loading.value = true
  listMonthlyAssets(queryParams).then(res => {
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
  // 资本化日期时间范围
  dateRangeFaCapitalizedDate.value = []
  // 报废日期时间范围
  dateRangeFaScrapDate.value = []
  // 盘点日期时间范围
  dateRangeFaCheckedDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.faSfid);
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
    faSfid: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
    // 使用部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // 资产类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_assets_type: [],
    // 成本中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_prctr_list: [],
    // 单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_unit_list: [],
    // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_assets_dist: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ccy_type: [],
    // 是否停用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_flag_list: [],
    // 资产形态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_assets_pattern: [],
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
    faSfid: 0,
    faCorp: null,
    faDept: null,
    faClassCode: null,
    faAssetNo: null,
    faCostCenter: null,
    faAssetShortName: null,
    faAssetFullName: null,
    faAssetUnit: null,
    faAssetQty: 0,
    faAssetMana: 0,
    faAssetCcy: null,
    faAcquisitionPrice: 0,
    faCapitalizedDate: null,
    faDepreciationValue: 0,
    faScrapDate: null,
    faScrapValue: 0,
    faLocale: null,
    faAssetUsed: 0,
    faAssetStop: 0,
    faAssetVender: null,
    faAssetManufacturer: null,
    faAssetVenderItem: null,
    faAssetManufacturerItem: null,
    faEntity: 0,
    faHaveorNot: 0,
    faCheckedby: null,
    faCheckedDate: null,
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
  title.value = proxy.$t('btn.add')+" "+'固定资产'
  opertype.value = 1
  form.value.faCorp= []
  form.value.faDept= []
  form.value.faClassCode= []
  form.value.faCostCenter= []
  form.value.faAssetUnit= []
  form.value.faAssetQty= 0
  form.value.faAssetMana= 0
  form.value.faAssetCcy= []
  form.value.faAcquisitionPrice= 0
  form.value.faCapitalizedDate= new Date()
  form.value.faDepreciationValue= 0
  form.value.faScrapDate= new Date()
  form.value.faScrapValue= 0
  form.value.faAssetUsed= 0
  form.value.faAssetStop= 0
  form.value.faEntity= 0
  form.value.faHaveorNot= 0
  form.value.faCheckedDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.faSfid || ids.value
  getMonthlyAssets(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '固定资产'
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

      if (form.value.faSfid != undefined && opertype.value === 2) {
        updateMonthlyAssets(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addMonthlyAssets(form.value).then((res) => {
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
  const Ids = row.faSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delMonthlyAssets(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<固定资产.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/MonthlyAssets/export', { ...queryParams })
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