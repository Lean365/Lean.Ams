<!--
 * @Descripttion: 顾客信息/sd_customer
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 13:49:23
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="销售组织" prop="scOrg">
            <el-select filterable clearable v-model="queryParams.scOrg"
              :placeholder="$t('btn.selectSearchPrefix')+'销售组织'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="行业类别" prop="scIndustryType">
            <el-select filterable clearable v-model="queryParams.scIndustryType"
              :placeholder="$t('btn.selectSearchPrefix')+'行业类别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="企业性质" prop="scEnterpriseNature">
            <el-select filterable clearable v-model="queryParams.scEnterpriseNature"
              :placeholder="$t('btn.selectSearchPrefix')+'企业性质'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="客户代码" prop="scCode">
            <el-input v-model="queryParams.scCode"
              :placeholder="$t('btn.enterSearchPrefix')+'客户代码'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="客户简称" prop="scAbbr">
            <el-input v-model="queryParams.scAbbr"
              :placeholder="$t('btn.enterSearchPrefix')+'客户简称'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="客户名称" prop="scName">
            <el-input v-model="queryParams.scName"
              :placeholder="$t('btn.enterSearchPrefix')+'客户名称'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="税号" prop="scTaxNo">
            <el-input v-model="queryParams.scTaxNo"
              :placeholder="$t('btn.enterSearchPrefix')+'税号'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="税别" prop="scTaxType">
            <el-select filterable clearable v-model="queryParams.scTaxType"
              :placeholder="$t('btn.selectSearchPrefix')+'税别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_tax_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="交易币种" prop="scCcy">
            <el-select filterable clearable v-model="queryParams.scCcy"
              :placeholder="$t('btn.selectSearchPrefix')+'交易币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="付款条件" prop="scPayTerms">
            <el-select filterable clearable v-model="queryParams.scPayTerms"
              :placeholder="$t('btn.selectSearchPrefix')+'付款条件'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_payment_terms " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="付款方式" prop="scPayMethod">
            <el-select filterable clearable v-model="queryParams.scPayMethod"
              :placeholder="$t('btn.selectSearchPrefix')+'付款方式'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_payment_method " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="统驭科目" prop="scRecAccount">
            <el-select filterable clearable v-model="queryParams.scRecAccount"
              :placeholder="$t('btn.selectSearchPrefix')+'统驭科目'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_recon_account " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="贸易条件" prop="scTradeTerms">
            <el-select filterable clearable v-model="queryParams.scTradeTerms"
              :placeholder="$t('btn.selectSearchPrefix')+'贸易条件'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_terms_trade " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="装运条件" prop="scShippingTerms">
            <el-select filterable clearable v-model="queryParams.scShippingTerms"
              :placeholder="$t('btn.selectSearchPrefix')+'装运条件'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_cond_shipment " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="客户等级" prop="scCustomerGrade">
            <el-select filterable clearable v-model="queryParams.scCustomerGrade"
              :placeholder="$t('btn.selectSearchPrefix')+'客户等级'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_grade_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="客户信用" prop="scCustomerCredit">
            <el-select filterable clearable v-model="queryParams.scCustomerCredit"
              :placeholder="$t('btn.selectSearchPrefix')+'客户信用'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_credit_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="国家地区" prop="scRegionCode">
            <el-select filterable clearable v-model="queryParams.scRegionCode"
              :placeholder="$t('btn.selectSearchPrefix')+'国家地区'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_country_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="州省" prop="scState">
            <el-select filterable clearable v-model="queryParams.scState"
              :placeholder="$t('btn.selectSearchPrefix')+'州省'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_region_province " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="冻结标记" prop="isFroze">
            <el-radio-group v-model="queryParams.isFroze">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_freeze_flag " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
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
        <el-button class="btn-add" v-hasPermi="['sd:customer:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sd:customer:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sd:customer:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sd:customer:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/SdCustomer/importTemplate"
                  importUrl="/Logistics/SdCustomer/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['sd:customer:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="600px" :data="dataList" v-loading="loading" ref="table"
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="scSfId" label="SFID" align="center" v-if="columns.showColumn('scSfId')" />
      <el-table-column prop="scOrg" label="销售组织" align="center" v-if="columns.showColumn('scOrg')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.scOrg" />
        </template>
      </el-table-column>
      <el-table-column prop="scIndustryType" label="行业类别" align="center" v-if="columns.showColumn('scIndustryType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.scIndustryType" />
        </template>
      </el-table-column>
      <el-table-column prop="scEnterpriseNature" label="企业性质" align="center"
        v-if="columns.showColumn('scEnterpriseNature')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.scEnterpriseNature" />
        </template>
      </el-table-column>
      <el-table-column prop="scCode" label="客户代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scCode')" />
      <el-table-column prop="scAbbr" label="客户简称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scAbbr')" />
      <el-table-column prop="scName" label="客户名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scName')" />
      <el-table-column prop="scEbe" label="企业法人" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scEbe')" />
      <el-table-column prop="scTaxNo" label="税号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scTaxNo')" />
      <el-table-column prop="scBusinessNo" label="营业执照" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBusinessNo')" />
      <el-table-column prop="scTaxType" label="税别" align="center" v-if="columns.showColumn('scTaxType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_tax_list " :value="scope.row.scTaxType" />
        </template>
      </el-table-column>
      <el-table-column prop="scMainBusiness" label="主营业务" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scMainBusiness')" />
      <el-table-column prop="scCcy" label="交易币种" align="center" v-if="columns.showColumn('scCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.scCcy" />
        </template>
      </el-table-column>
      <el-table-column prop="scPayTerms" label="付款条件" align="center" v-if="columns.showColumn('scPayTerms')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_terms " :value="scope.row.scPayTerms" />
        </template>
      </el-table-column>
      <el-table-column prop="scPayMethod" label="付款方式" align="center" v-if="columns.showColumn('scPayMethod')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_method " :value="scope.row.scPayMethod" />
        </template>
      </el-table-column>
      <el-table-column prop="scRecAccount" label="统驭科目" align="center" v-if="columns.showColumn('scRecAccount')">
        <template #default="scope">
          <dict-tag :options=" options.sql_recon_account " :value="scope.row.scRecAccount" />
        </template>
      </el-table-column>
      <el-table-column prop="scTradeTerms" label="贸易条件" align="center" v-if="columns.showColumn('scTradeTerms')">
        <template #default="scope">
          <dict-tag :options=" options.sys_terms_trade " :value="scope.row.scTradeTerms" />
        </template>
      </el-table-column>
      <el-table-column prop="scShippingTerms" label="装运条件" align="center" v-if="columns.showColumn('scShippingTerms')">
        <template #default="scope">
          <dict-tag :options=" options.sys_cond_shipment " :value="scope.row.scShippingTerms" />
        </template>
      </el-table-column>
      <el-table-column prop="scCustomerGrade" label="客户等级" align="center" v-if="columns.showColumn('scCustomerGrade')">
        <template #default="scope">
          <dict-tag :options=" options.sys_grade_list " :value="scope.row.scCustomerGrade" />
        </template>
      </el-table-column>
      <el-table-column prop="scCustomerCredit" label="客户信用" align="center"
        v-if="columns.showColumn('scCustomerCredit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_credit_list " :value="scope.row.scCustomerCredit" />
        </template>
      </el-table-column>
      <el-table-column prop="scFirstTransDate" label="首次交易" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scFirstTransDate')" />
      <el-table-column prop="scLastTransDate" label="最近交易" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scLastTransDate')" />
      <el-table-column prop="scBankCode" label="银行代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBankCode')" />
      <el-table-column prop="scBankName" label="银行名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBankName')" />
      <el-table-column prop="scBranchName" label="分行名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBranchName')" />
      <el-table-column prop="scBankCountry" label="银行所在国" align="center" v-if="columns.showColumn('scBankCountry')">
        <template #default="scope">
          <dict-tag :options=" options.sys_country_list " :value="scope.row.scBankCountry" />
        </template>
      </el-table-column>
      <el-table-column prop="scBankState" label="银行所在州省" align="center" v-if="columns.showColumn('scBankState')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_province " :value="scope.row.scBankState" />
        </template>
      </el-table-column>
      <el-table-column prop="scBankCity" label="银行所在市" align="center" v-if="columns.showColumn('scBankCity')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_city " :value="scope.row.scBankCity" />
        </template>
      </el-table-column>
      <el-table-column prop="scBankCounty" label="银行所在县" align="center" v-if="columns.showColumn('scBankCounty')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_county " :value="scope.row.scBankCounty" />
        </template>
      </el-table-column>
      <el-table-column prop="scBankAddr" label="银行地址" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBankAddr')" />
      <el-table-column prop="scBankAddr1" label="银行地址1" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBankAddr1')" />
      <el-table-column prop="scBankAddr2" label="银行地址2" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBankAddr2')" />
      <el-table-column prop="scBankAccount" label="银行账号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBankAccount')" />
      <el-table-column prop="scBankSwiftNo" label="SWIFT代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scBankSwiftNo')" />
      <el-table-column prop="scRegionCode" label="国家地区" align="center" v-if="columns.showColumn('scRegionCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_country_list " :value="scope.row.scRegionCode" />
        </template>
      </el-table-column>
      <el-table-column prop="scState" label="州省" align="center" v-if="columns.showColumn('scState')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_province " :value="scope.row.scState" />
        </template>
      </el-table-column>
      <el-table-column prop="scCity" label="市" align="center" v-if="columns.showColumn('scCity')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_city " :value="scope.row.scCity" />
        </template>
      </el-table-column>
      <el-table-column prop="scCounty" label="县" align="center" v-if="columns.showColumn('scCounty')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_county " :value="scope.row.scCounty" />
        </template>
      </el-table-column>
      <el-table-column prop="scAddr" label="地址" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scAddr')" />
      <el-table-column prop="scAddr1" label="地址1" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scAddr1')" />
      <el-table-column prop="scAddr2" label="地址2" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scAddr2')" />
      <el-table-column prop="scContacts" label="联系人" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scContacts')" />
      <el-table-column prop="scEmail" label="电邮" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scEmail')" />
      <el-table-column prop="scTelNo" label="电话" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scTelNo')" />
      <el-table-column prop="scFaxNp" label="传真" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scFaxNp')" />
      <el-table-column prop="scPhoneNo" label="手机" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scPhoneNo')" />
      <el-table-column prop="isFroze" label="冻结标记" align="center" v-if="columns.showColumn('isFroze')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.isFroze" />
        </template>
      </el-table-column>
      <el-table-column prop="scLicenseAnnex" label="营业执照附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scLicenseAnnex')" />
      <el-table-column prop="scOtherAnnex" label="其它附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('scOtherAnnex')" />
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createBy')" />
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateBy')" />
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateTime')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['sd:customer:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['sd:customer:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改顾客信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="SFID" prop="scSfId">
                  <el-input v-model.number="form.scSfId"
                    :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="销售组织" prop="scOrg">
                  <el-select filterable clearable v-model="form.scOrg"
                    :placeholder="$t('btn.selectPrefix')+'销售组织'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_crop_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="行业类别" prop="scIndustryType">
                  <el-select filterable clearable v-model="form.scIndustryType"
                    :placeholder="$t('btn.selectPrefix')+'行业类别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ind_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="企业性质" prop="scEnterpriseNature">
                  <el-select filterable clearable v-model="form.scEnterpriseNature"
                    :placeholder="$t('btn.selectPrefix')+'企业性质'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_nature_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="客户代码" prop="scCode">
                  <el-input v-model="form.scCode" :placeholder="$t('btn.enterPrefix')+'客户代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="客户简称" prop="scAbbr">
                  <el-input v-model="form.scAbbr" :placeholder="$t('btn.enterPrefix')+'客户简称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="客户名称" prop="scName">
                  <el-input v-model="form.scName" :placeholder="$t('btn.enterPrefix')+'客户名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="企业法人" prop="scEbe">
                  <el-input v-model="form.scEbe" :placeholder="$t('btn.enterPrefix')+'企业法人'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="税号" prop="scTaxNo">
                  <el-input v-model="form.scTaxNo" :placeholder="$t('btn.enterPrefix')+'税号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="营业执照" prop="scBusinessNo">
                  <el-input v-model="form.scBusinessNo"
                    :placeholder="$t('btn.enterPrefix')+'营业执照'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="税别" prop="scTaxType">
                  <el-select filterable clearable v-model="form.scTaxType"
                    :placeholder="$t('btn.selectPrefix')+'税别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_tax_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="主营业务" prop="scMainBusiness">
                  <el-input v-model="form.scMainBusiness"
                    :placeholder="$t('btn.enterPrefix')+'主营业务'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="交易币种" prop="scCcy">
                  <el-select filterable clearable v-model="form.scCcy"
                    :placeholder="$t('btn.selectPrefix')+'交易币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="付款条件" prop="scPayTerms">
                  <el-select filterable clearable v-model="form.scPayTerms"
                    :placeholder="$t('btn.selectPrefix')+'付款条件'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_payment_terms" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="付款方式" prop="scPayMethod">
                  <el-select filterable clearable v-model="form.scPayMethod"
                    :placeholder="$t('btn.selectPrefix')+'付款方式'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_payment_method" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="统驭科目" prop="scRecAccount">
                  <el-select filterable clearable v-model="form.scRecAccount"
                    :placeholder="$t('btn.selectPrefix')+'统驭科目'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_recon_account" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="贸易条件" prop="scTradeTerms">
                  <el-select filterable clearable v-model="form.scTradeTerms"
                    :placeholder="$t('btn.selectPrefix')+'贸易条件'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_terms_trade" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="装运条件" prop="scShippingTerms">
                  <el-select filterable clearable v-model="form.scShippingTerms"
                    :placeholder="$t('btn.selectPrefix')+'装运条件'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_cond_shipment" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="客户等级" prop="scCustomerGrade">
                  <el-select filterable clearable v-model="form.scCustomerGrade"
                    :placeholder="$t('btn.selectPrefix')+'客户等级'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_grade_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="客户信用" prop="scCustomerCredit">
                  <el-select filterable clearable v-model="form.scCustomerCredit"
                    :placeholder="$t('btn.selectPrefix')+'客户信用'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_credit_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="首次交易" prop="scFirstTransDate">
                  <el-date-picker v-model="form.scFirstTransDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最近交易" prop="scLastTransDate">
                  <el-date-picker v-model="form.scLastTransDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行代码" prop="scBankCode">
                  <el-input v-model="form.scBankCode"
                    :placeholder="$t('btn.enterPrefix')+'银行代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行名称" prop="scBankName">
                  <el-input v-model="form.scBankName"
                    :placeholder="$t('btn.enterPrefix')+'银行名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分行名称" prop="scBranchName">
                  <el-input v-model="form.scBranchName"
                    :placeholder="$t('btn.enterPrefix')+'分行名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行所在国" prop="scBankCountry">
                  <el-select filterable clearable v-model="form.scBankCountry"
                    :placeholder="$t('btn.selectPrefix')+'银行所在国'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_country_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="银行所在州省" prop="scBankState">
                  <el-select filterable clearable v-model="form.scBankState"
                    :placeholder="$t('btn.selectPrefix')+'银行所在州省'+$t('btn.selectSuffix')"
                    @change="handleBankCityChange">
                    <el-option v-for="item in  options.sql_region_province" :key="item.dictValue"
                      :label="item.dictLabel" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="银行所在市" prop="scBankCity">
                  <el-select filterable clearable v-model="form.scBankCity"
                    :placeholder="$t('btn.selectPrefix')+'银行所在市'+$t('btn.selectSuffix')"
                    @change="handleBankCountyChange">
                    <el-option v-for="item in  optionsBankCity" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="银行所在县" prop="scBankCounty">
                  <el-select filterable clearable v-model="form.scBankCounty"
                    :placeholder="$t('btn.selectPrefix')+'银行所在县'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  optionsBankCounty" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="银行地址" prop="scBankAddr">
                  <el-input v-model="form.scBankAddr"
                    :placeholder="$t('btn.enterPrefix')+'银行地址'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行地址1" prop="scBankAddr1">
                  <el-input v-model="form.scBankAddr1"
                    :placeholder="$t('btn.enterPrefix')+'银行地址1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行地址2" prop="scBankAddr2">
                  <el-input v-model="form.scBankAddr2"
                    :placeholder="$t('btn.enterPrefix')+'银行地址2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行账号" prop="scBankAccount">
                  <el-input v-model="form.scBankAccount"
                    :placeholder="$t('btn.enterPrefix')+'银行账号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="SWIFT代码" prop="scBankSwiftNo">
                  <el-input v-model="form.scBankSwiftNo"
                    :placeholder="$t('btn.enterPrefix')+'SWIFT代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="国家地区" prop="scRegionCode">
                  <el-select filterable clearable v-model="form.scRegionCode"
                    :placeholder="$t('btn.selectPrefix')+'国家地区'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_country_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="州省" prop="scState">
                  <el-select filterable clearable v-model="form.scState"
                    :placeholder="$t('btn.selectPrefix')+'州省'+$t('btn.selectSuffix')" @change="handleCityChange">
                    <el-option v-for="item in  options.sql_region_province" :key="item.dictValue"
                      :label="item.dictLabel" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="市" prop="scCity">
                  <el-select filterable clearable v-model="form.scCity"
                    :placeholder="$t('btn.selectPrefix')+'市'+$t('btn.selectSuffix')" @change="handleCountyChange">
                    <el-option v-for="item in  optionsCity" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="县" prop="scCounty">
                  <el-select filterable clearable v-model="form.scCounty"
                    :placeholder="$t('btn.selectPrefix')+'县'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  optionsCounty" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="地址" prop="scAddr">
                  <el-input v-model="form.scAddr" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="地址1" prop="scAddr1">
                  <el-input v-model="form.scAddr1" :placeholder="$t('btn.enterPrefix')+'地址1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="地址2" prop="scAddr2">
                  <el-input v-model="form.scAddr2" :placeholder="$t('btn.enterPrefix')+'地址2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="联系人" prop="scContacts">
                  <el-input v-model="form.scContacts"
                    :placeholder="$t('btn.enterPrefix')+'联系人'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="电邮" prop="scEmail">
                  <el-input v-model="form.scEmail" :placeholder="$t('btn.enterPrefix')+'电邮'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="电话" prop="scTelNo">
                  <el-input v-model="form.scTelNo" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="传真" prop="scFaxNp">
                  <el-input v-model="form.scFaxNp" :placeholder="$t('btn.enterPrefix')+'传真'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="手机" prop="scPhoneNo">
                  <el-input v-model="form.scPhoneNo" :placeholder="$t('btn.enterPrefix')+'手机'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="冻结标记" prop="isFroze">
                  <el-radio-group v-model="form.isFroze">
                    <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="营业执照附件" prop="scLicenseAnnex">
                  <UploadFile v-model="form.scLicenseAnnex" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="其它附件" prop="scOtherAnnex">
                  <UploadFile v-model="form.scOtherAnnex" :data="{ uploadType: 1 }" />
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
                  <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2" prop="uDF52">
                  <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3" prop="uDF53">
                  <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4" prop="uDF54">
                  <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5" prop="uDF55">
                  <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6" prop="uDF56">
                  <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="说明" prop="remark">
                  <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-radio-group v-model="form.isDeleted">
                    <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
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
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新者" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="sdcustomer">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listSdCustomer,
    addSdCustomer, delSdCustomer,
    updateSdCustomer, getSdCustomer,
  }
    from '@/api/logistics/sdcustomer.js'
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
    scOrg: undefined,
    //是否查询（1是）
    scIndustryType: undefined,
    //是否查询（1是）
    scEnterpriseNature: undefined,
    //是否查询（1是）
    scCode: undefined,
    //是否查询（1是）
    scAbbr: undefined,
    //是否查询（1是）
    scName: undefined,
    //是否查询（1是）
    scTaxNo: undefined,
    //是否查询（1是）
    scTaxType: undefined,
    //是否查询（1是）
    scCcy: undefined,
    //是否查询（1是）
    scPayTerms: undefined,
    //是否查询（1是）
    scPayMethod: undefined,
    //是否查询（1是）
    scRecAccount: undefined,
    //是否查询（1是）
    scTradeTerms: undefined,
    //是否查询（1是）
    scShippingTerms: undefined,
    //是否查询（1是）
    scCustomerGrade: undefined,
    //是否查询（1是）
    scCustomerCredit: undefined,
    //是否查询（1是）
    scRegionCode: undefined,
    //是否查询（1是）
    scState: undefined,
    //是否查询（1是）
    isFroze: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'scSfId', label: 'SFID' },
    { visible: true, prop: 'scOrg', label: '销售组织' },
    { visible: true, prop: 'scIndustryType', label: '行业类别' },
    { visible: true, prop: 'scEnterpriseNature', label: '企业性质' },
    { visible: true, prop: 'scCode', label: '客户代码' },
    { visible: true, prop: 'scAbbr', label: '客户简称' },
    { visible: true, prop: 'scName', label: '客户名称' },
    { visible: true, prop: 'scEbe', label: '企业法人' },
    { visible: false, prop: 'scTaxNo', label: '税号' },
    { visible: false, prop: 'scBusinessNo', label: '营业执照' },
    { visible: false, prop: 'scTaxType', label: '税别' },
    { visible: false, prop: 'scMainBusiness', label: '主营业务' },
    { visible: false, prop: 'scCcy', label: '交易币种' },
    { visible: false, prop: 'scPayTerms', label: '付款条件' },
    { visible: false, prop: 'scPayMethod', label: '付款方式' },
    { visible: false, prop: 'scRecAccount', label: '统驭科目' },
    { visible: false, prop: 'scTradeTerms', label: '贸易条件' },
    { visible: false, prop: 'scShippingTerms', label: '装运条件' },
    { visible: false, prop: 'scCustomerGrade', label: '客户等级' },
    { visible: false, prop: 'scCustomerCredit', label: '客户信用' },
    { visible: false, prop: 'scFirstTransDate', label: '首次交易' },
    { visible: false, prop: 'scLastTransDate', label: '最近交易' },
    { visible: false, prop: 'scBankCode', label: '银行代码' },
    { visible: false, prop: 'scBankName', label: '银行名称' },
    { visible: false, prop: 'scBranchName', label: '分行名称' },
    { visible: false, prop: 'scBankCountry', label: '银行所在国' },
    { visible: false, prop: 'scBankState', label: '银行所在州省' },
    { visible: false, prop: 'scBankCity', label: '银行所在市' },
    { visible: false, prop: 'scBankCounty', label: '银行所在县' },
    { visible: false, prop: 'scBankAddr', label: '银行地址' },
    { visible: false, prop: 'scBankAddr1', label: '银行地址1' },
    { visible: false, prop: 'scBankAddr2', label: '银行地址2' },
    { visible: false, prop: 'scBankAccount', label: '银行账号' },
    { visible: false, prop: 'scBankSwiftNo', label: 'SWIFT代码' },
    { visible: false, prop: 'scRegionCode', label: '国家地区' },
    { visible: false, prop: 'scState', label: '州省' },
    { visible: false, prop: 'scCity', label: '市' },
    { visible: false, prop: 'scCounty', label: '县' },
    { visible: false, prop: 'scAddr', label: '地址' },
    { visible: false, prop: 'scAddr1', label: '地址1' },
    { visible: false, prop: 'scAddr2', label: '地址2' },
    { visible: false, prop: 'scContacts', label: '联系人' },
    { visible: false, prop: 'scEmail', label: '电邮' },
    { visible: false, prop: 'scTelNo', label: '电话' },
    { visible: false, prop: 'scFaxNp', label: '传真' },
    { visible: false, prop: 'scPhoneNo', label: '手机' },
    { visible: false, prop: 'isFroze', label: '冻结标记' },
    { visible: false, prop: 'scLicenseAnnex', label: '营业执照附件' },
    { visible: false, prop: 'scOtherAnnex', label: '其它附件' },
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
    { dictType: "sys_crop_list" },
    { dictType: "sys_ind_type" },
    { dictType: "sys_nature_list" },
    { dictType: "sys_tax_list" },
    { dictType: "sys_ccy_type" },
    { dictType: "sys_payment_terms" },
    { dictType: "sys_payment_method" },
    { dictType: "sql_recon_account" },
    { dictType: "sys_terms_trade" },
    { dictType: "sys_cond_shipment" },
    { dictType: "sys_grade_list" },
    { dictType: "sys_credit_list" },
    { dictType: "sys_country_list" },
    { dictType: "sql_region_province" },
    { dictType: "sql_region_city" },
    { dictType: "sql_region_county" },
    { dictType: "sys_freeze_flag" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从顾客信息/sd_customer表记录数据
  function getList() {
    loading.value = true
    listSdCustomer(queryParams).then(res => {
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
  function resetQuery() {
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.scSfId);
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
      scSfId: [{ required: true, message: "SFID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scOrg: [{ required: true, message: "销售组织" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scIndustryType: [{ required: true, message: "行业类别" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scEnterpriseNature: [{ required: true, message: "企业性质" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scCode: [{ required: true, message: "客户代码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scAbbr: [{ required: true, message: "客户简称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scName: [{ required: true, message: "客户名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scEbe: [{ required: true, message: "企业法人" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scTaxNo: [{ required: true, message: "税号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scBusinessNo: [{ required: true, message: "营业执照" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scTaxType: [{ required: true, message: "税别" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scMainBusiness: [{ required: true, message: "主营业务" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scCcy: [{ required: true, message: "交易币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scPayTerms: [{ required: true, message: "付款条件" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scPayMethod: [{ required: true, message: "付款方式" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scRecAccount: [{ required: true, message: "统驭科目" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scTradeTerms: [{ required: true, message: "贸易条件" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scShippingTerms: [{ required: true, message: "装运条件" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scBankCode: [{ required: true, message: "银行代码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scBankName: [{ required: true, message: "银行名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scBankCountry: [{ required: true, message: "银行所在国" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scBankState: [{ required: true, message: "银行所在州省" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scBankCity: [{ required: true, message: "银行所在市" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scBankCounty: [{ required: true, message: "银行所在县" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      scBankAddr: [{ required: true, message: "银行地址" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scBankAccount: [{ required: true, message: "银行账号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      scAddr: [{ required: true, message: "地址" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isFroze: [{ required: true, message: "冻结标记" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      uDF51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 销售组织 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_crop_list: [],
      // 行业类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ind_type: [],
      // 企业性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_nature_list: [],
      // 税别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_tax_list: [],
      // 交易币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
      // 付款条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_payment_terms: [],
      // 付款方式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_payment_method: [],
      // 统驭科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_recon_account: [],
      // 贸易条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_terms_trade: [],
      // 装运条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_cond_shipment: [],
      // 客户等级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_grade_list: [],
      // 客户信用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_credit_list: [],
      // 银行所在国 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_country_list: [],
      // 银行所在州省 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_region_province: [],
      // 银行所在市 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_region_city: [],
      // 银行所在县 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_region_county: [],
      // 冻结标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_freeze_flag: [],
      // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_deleted: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }
  const optionsBankCity = ref()
  const optionsBankCounty = ref()
  const optionsCity = ref()
  const optionsCounty = ref()

  const handleBankCityChange = (event) => {
    form.value.scBankCity = null
    form.value.scBankCounty = null
    //queryParams.sspYm = null
    //ffy.value = event
    console.log(event, state.options.sql_region_city)
    // 这里可以添加其他逻辑，比如触发父组件的方法

    optionsBankCity.value = state.options.sql_region_city.filter(item => item.label.includes((event)))
    //form.sspYm.value = []
    //return selectedCountry.value ? cities[selectedCountry.value] : []


  }
  const handleBankCountyChange = (event) => {
    form.value.scBankCounty = null
    //queryParams.sspYm = null
    //ffy.value = event
    console.log(event, state.options.sql_region_county)
    // 这里可以添加其他逻辑，比如触发父组件的方法

    optionsBankCounty.value = state.options.sql_region_county.filter(item => item.label.includes((event)))
    //form.sspYm.value = []
    //return selectedCountry.value ? cities[selectedCountry.value] : []


  }
  const handleCityChange = (event) => {
    form.value.scCity = null
    form.value.scCounty = null
    //queryParams.sspYm = null
    //ffy.value = event
    console.log(event, state.options.sql_region_city)
    // 这里可以添加其他逻辑，比如触发父组件的方法

    optionsCity.value = state.options.sql_region_city.filter(item => item.label.includes((event)))
    //form.sspYm.value = []
    //return selectedCountry.value ? cities[selectedCountry.value] : []


  }
  const handleCountyChange = (event) => {
    form.value.scCounty = null
    //queryParams.sspYm = null
    //ffy.value = event
    console.log(event, state.options.sql_region_county)
    // 这里可以添加其他逻辑，比如触发父组件的方法

    optionsCounty.value = state.options.sql_region_county.filter(item => item.label.includes((event)))
    //form.sspYm.value = []
    //return selectedCountry.value ? cities[selectedCountry.value] : []


  }
  // 重置表单
  function reset() {
    form.value = {
      scSfId: 0,
      scOrg: null,
      scIndustryType: null,
      scEnterpriseNature: null,
      scCode: null,
      scAbbr: null,
      scName: null,
      scEbe: null,
      scTaxNo: null,
      scBusinessNo: null,
      scTaxType: null,
      scMainBusiness: null,
      scCcy: null,
      scPayTerms: null,
      scPayMethod: null,
      scRecAccount: null,
      scTradeTerms: null,
      scShippingTerms: null,
      scCustomerGrade: null,
      scCustomerCredit: null,
      scFirstTransDate: null,
      scLastTransDate: null,
      scBankCode: null,
      scBankName: null,
      scBranchName: null,
      scBankCountry: null,
      scBankState: null,
      scBankCity: null,
      scBankCounty: null,
      scBankAddr: null,
      scBankAddr1: null,
      scBankAddr2: null,
      scBankAccount: null,
      scBankSwiftNo: null,
      scRegionCode: null,
      scState: null,
      scCity: null,
      scCounty: null,
      scAddr: null,
      scAddr1: null,
      scAddr2: null,
      scContacts: null,
      scEmail: null,
      scTelNo: null,
      scFaxNp: null,
      scPhoneNo: null,
      isFroze: 0,
      scLicenseAnnex: null,
      scOtherAnnex: null,
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
    title.value = proxy.$t('btn.add') + " " + '顾客信息'
    opertype.value = 1
    form.value.scOrg = []
    form.value.scIndustryType = []
    form.value.scEnterpriseNature = []
    form.value.scTaxType = []
    form.value.scCcy = []
    form.value.scPayTerms = []
    form.value.scPayMethod = []
    form.value.scRecAccount = []
    form.value.scTradeTerms = []
    form.value.scShippingTerms = []
    form.value.scCustomerGrade = []
    form.value.scCustomerCredit = []
    form.value.scFirstTransDate = new Date()
    form.value.scLastTransDate = new Date()
    form.value.scBankCountry = ' China 中国'
    form.value.scBankState = []
    form.value.scBankCity = []
    form.value.scBankCounty = []
    form.value.scRegionCode = ' China 中国'
    form.value.scState = []
    form.value.scCity = []
    form.value.scCounty = []
    form.value.isFroze = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.scSfId || ids.value
    getSdCustomer(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '顾客信息'
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

        if (form.value.scSfId != undefined && opertype.value === 2) {
          updateSdCustomer(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addSdCustomer(form.value).then((res) => {
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
    const Ids = row.scSfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delSdCustomer(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<顾客信息.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/SdCustomer/export', { ...queryParams })
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