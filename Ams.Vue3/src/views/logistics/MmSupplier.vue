<!--
 * @Descripttion: 供应商信息/mm_supplier
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 11:22:58
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="购买组织" prop="suOrg">
            <el-select filterable clearable v-model="queryParams.suOrg"
              :placeholder="$t('btn.selectSearchPrefix')+'购买组织'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="行业类别" prop="suIndustryType">
            <el-select filterable clearable v-model="queryParams.suIndustryType"
              :placeholder="$t('btn.selectSearchPrefix')+'行业类别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="企业性质" prop="suEnterpriseNature">
            <el-select filterable clearable v-model="queryParams.suEnterpriseNature"
              :placeholder="$t('btn.selectSearchPrefix')+'企业性质'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="供应商代码" prop="suCode">
            <el-input v-model="queryParams.suCode"
              :placeholder="$t('btn.enterSearchPrefix')+'供应商代码'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="供应商简称" prop="suAbbr">
            <el-input v-model="queryParams.suAbbr"
              :placeholder="$t('btn.enterSearchPrefix')+'供应商简称'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="供应商名称" prop="suName">
            <el-input v-model="queryParams.suName"
              :placeholder="$t('btn.enterSearchPrefix')+'供应商名称'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="税别" prop="suTaxType">
            <el-select filterable clearable v-model="queryParams.suTaxType"
              :placeholder="$t('btn.selectSearchPrefix')+'税别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_tax_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="交易币种" prop="suCcy">
            <el-select filterable clearable v-model="queryParams.suCcy"
              :placeholder="$t('btn.selectSearchPrefix')+'交易币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="付款条件" prop="suPayTerms">
            <el-select filterable clearable v-model="queryParams.suPayTerms"
              :placeholder="$t('btn.selectSearchPrefix')+'付款条件'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_payment_terms " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="付款方式" prop="suPayMethod">
            <el-select filterable clearable v-model="queryParams.suPayMethod"
              :placeholder="$t('btn.selectSearchPrefix')+'付款方式'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_payment_method " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="统驭科目" prop="suRecAccount">
            <el-select filterable clearable v-model="queryParams.suRecAccount"
              :placeholder="$t('btn.selectSearchPrefix')+'统驭科目'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_recon_account " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="贸易条件" prop="suTradeTerms">
            <el-select filterable clearable v-model="queryParams.suTradeTerms"
              :placeholder="$t('btn.selectSearchPrefix')+'贸易条件'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_terms_trade " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="装运条件" prop="suShippingTerms">
            <el-select filterable clearable v-model="queryParams.suShippingTerms"
              :placeholder="$t('btn.selectSearchPrefix')+'装运条件'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_cond_shipment " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="供应商等级" prop="suSupplierGrade">
            <el-select filterable clearable v-model="queryParams.suSupplierGrade"
              :placeholder="$t('btn.selectSearchPrefix')+'供应商等级'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_grade_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="供应商信用" prop="suSupplierCredit">
            <el-select filterable clearable v-model="queryParams.suSupplierCredit"
              :placeholder="$t('btn.selectSearchPrefix')+'供应商信用'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_credit_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="首次交易">
            <el-date-picker v-model="dateRangeSuFirstTransDate" type="datetimerange"
              :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
              value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime" :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="国家地区" prop="suRegionCode">
            <el-select filterable clearable v-model="queryParams.suRegionCode"
              :placeholder="$t('btn.selectSearchPrefix')+'国家地区'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_country_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="冻结标志" prop="isFroze">
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
        <el-button class="btn-add" v-hasPermi="['mm:supplier:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:supplier:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:supplier:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:supplier:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/MmSupplier/importTemplate"
                  importUrl="/Logistics/MmSupplier/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:supplier:export']">
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
      <el-table-column prop="suSfId" label="SFID" align="center" v-if="columns.showColumn('suSfId')" />
      <el-table-column prop="suOrg" label="购买组织" align="center" v-if="columns.showColumn('suOrg')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.suOrg" />
        </template>
      </el-table-column>
      <el-table-column prop="suIndustryType" label="行业类别" align="center" v-if="columns.showColumn('suIndustryType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.suIndustryType" />
        </template>
      </el-table-column>
      <el-table-column prop="suEnterpriseNature" label="企业性质" align="center"
        v-if="columns.showColumn('suEnterpriseNature')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.suEnterpriseNature" />
        </template>
      </el-table-column>
      <el-table-column prop="suCode" label="供应商代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suCode')" />
      <el-table-column prop="suAbbr" label="供应商简称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suAbbr')" />
      <el-table-column prop="suName" label="供应商名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suName')" />
      <el-table-column prop="suEbe" label="企业法人" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suEbe')" />
      <el-table-column prop="suBusinessNo" label="营业执照" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBusinessNo')" />
      <el-table-column prop="suTaxNo" label="税号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suTaxNo')" />
      <el-table-column prop="suTaxType" label="税别" align="center" v-if="columns.showColumn('suTaxType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_tax_list " :value="scope.row.suTaxType" />
        </template>
      </el-table-column>
      <el-table-column prop="suMainBusiness" label="主营业务" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suMainBusiness')" />
      <el-table-column prop="suCcy" label="交易币种" align="center" v-if="columns.showColumn('suCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.suCcy" />
        </template>
      </el-table-column>
      <el-table-column prop="suPayTerms" label="付款条件" align="center" v-if="columns.showColumn('suPayTerms')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_terms " :value="scope.row.suPayTerms" />
        </template>
      </el-table-column>
      <el-table-column prop="suPayMethod" label="付款方式" align="center" v-if="columns.showColumn('suPayMethod')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_method " :value="scope.row.suPayMethod" />
        </template>
      </el-table-column>
      <el-table-column prop="suRecAccount" label="统驭科目" align="center" v-if="columns.showColumn('suRecAccount')">
        <template #default="scope">
          <dict-tag :options=" options.sql_recon_account " :value="scope.row.suRecAccount" />
        </template>
      </el-table-column>
      <el-table-column prop="suTradeTerms" label="贸易条件" align="center" v-if="columns.showColumn('suTradeTerms')">
        <template #default="scope">
          <dict-tag :options=" options.sys_terms_trade " :value="scope.row.suTradeTerms" />
        </template>
      </el-table-column>
      <el-table-column prop="suShippingTerms" label="装运条件" align="center" v-if="columns.showColumn('suShippingTerms')">
        <template #default="scope">
          <dict-tag :options=" options.sys_cond_shipment " :value="scope.row.suShippingTerms" />
        </template>
      </el-table-column>
      <el-table-column prop="suSupplierGrade" label="供应商等级" align="center" v-if="columns.showColumn('suSupplierGrade')">
        <template #default="scope">
          <dict-tag :options=" options.sys_grade_list " :value="scope.row.suSupplierGrade" />
        </template>
      </el-table-column>
      <el-table-column prop="suSupplierCredit" label="供应商信用" align="center"
        v-if="columns.showColumn('suSupplierCredit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_credit_list " :value="scope.row.suSupplierCredit" />
        </template>
      </el-table-column>
      <el-table-column prop="suFirstTransDate" label="首次交易" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suFirstTransDate')" />
      <el-table-column prop="suLastTransDate" label="末次交易" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suLastTransDate')" />
      <el-table-column prop="suBankCode" label="银行代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankCode')" />
      <el-table-column prop="suBankName" label="银行名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankName')" />
      <el-table-column prop="suBranchName" label="分行名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBranchName')" />
      <el-table-column prop="suBankCountry" label="银行所在国" align="center" v-if="columns.showColumn('suBankCountry')">
        <template #default="scope">
          <dict-tag :options=" options.sys_country_list " :value="scope.row.suBankCountry" />
        </template>
      </el-table-column>
      <el-table-column prop="suBankState" label="所在州省" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankState')" />
      <el-table-column prop="suBankCity" label="所在市" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankCity')" />
      <el-table-column prop="suBankCounty" label="所在县" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankCounty')" />
      <el-table-column prop="suBankAddr" label="银行地址" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankAddr')" />
      <el-table-column prop="suBankAddr1" label="银行地址1" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankAddr1')" />
      <el-table-column prop="suBankAddr2" label="银行地址2" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankAddr2')" />
      <el-table-column prop="suBankAccount" label="银行账号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankAccount')" />
      <el-table-column prop="suBankSwiftNo" label="SWIFT代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suBankSwiftNo')" />
      <el-table-column prop="suRegionCode" label="国家地区" align="center" v-if="columns.showColumn('suRegionCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_country_list " :value="scope.row.suRegionCode" />
        </template>
      </el-table-column>
      <el-table-column prop="suState" label="州省" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suState')" />
      <el-table-column prop="suCity" label="市" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suCity')" />
      <el-table-column prop="suCounty" label="县" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suCounty')" />
      <el-table-column prop="suAddr" label="地址" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suAddr')" />
      <el-table-column prop="suAddr1" label="地址1" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suAddr1')" />
      <el-table-column prop="suAddr2" label="地址2" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suAddr2')" />
      <el-table-column prop="suContacts" label="联系人" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suContacts')" />
      <el-table-column prop="suEmail" label="邮件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suEmail')" />
      <el-table-column prop="suTelNo" label="电话" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suTelNo')" />
      <el-table-column prop="suFaxNp" label="传真" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suFaxNp')" />
      <el-table-column prop="suPhoneNo" label="手机" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suPhoneNo')" />
      <el-table-column prop="isFroze" label="冻结标志" align="center" v-if="columns.showColumn('isFroze')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.isFroze" />
        </template>
      </el-table-column>
      <el-table-column prop="suLicenseAnnex" label="营业执照附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suLicenseAnnex')" />
      <el-table-column prop="suOtherAnnex" label="其它附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('suOtherAnnex')" />
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
              v-hasPermi="['mm:supplier:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['mm:supplier:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改供应商信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="SFID" prop="suSfId">
                  <el-input v-model.number="form.suSfId"
                    :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="购买组织" prop="suOrg">
                  <el-select filterable clearable v-model="form.suOrg"
                    :placeholder="$t('btn.selectPrefix')+'购买组织'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="行业类别" prop="suIndustryType">
                  <el-select filterable clearable v-model="form.suIndustryType"
                    :placeholder="$t('btn.selectPrefix')+'行业类别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ind_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="企业性质" prop="suEnterpriseNature">
                  <el-select filterable clearable v-model="form.suEnterpriseNature"
                    :placeholder="$t('btn.selectPrefix')+'企业性质'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_nature_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="供应商代码" prop="suCode">
                  <el-input v-model="form.suCode" :placeholder="$t('btn.enterPrefix')+'供应商代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商简称" prop="suAbbr">
                  <el-input v-model="form.suAbbr" :placeholder="$t('btn.enterPrefix')+'供应商简称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商名称" prop="suName">
                  <el-input v-model="form.suName" :placeholder="$t('btn.enterPrefix')+'供应商名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="企业法人" prop="suEbe">
                  <el-input v-model="form.suEbe" :placeholder="$t('btn.enterPrefix')+'企业法人'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="营业执照" prop="suBusinessNo">
                  <el-input v-model="form.suBusinessNo"
                    :placeholder="$t('btn.enterPrefix')+'营业执照'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="税号" prop="suTaxNo">
                  <el-input v-model="form.suTaxNo" :placeholder="$t('btn.enterPrefix')+'税号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="税别" prop="suTaxType">
                  <el-select filterable clearable v-model="form.suTaxType"
                    :placeholder="$t('btn.selectPrefix')+'税别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_tax_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="主营业务" prop="suMainBusiness">
                  <el-input v-model="form.suMainBusiness"
                    :placeholder="$t('btn.enterPrefix')+'主营业务'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="交易币种" prop="suCcy">
                  <el-select filterable clearable v-model="form.suCcy"
                    :placeholder="$t('btn.selectPrefix')+'交易币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="付款条件" prop="suPayTerms">
                  <el-select filterable clearable v-model="form.suPayTerms"
                    :placeholder="$t('btn.selectPrefix')+'付款条件'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_payment_terms" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="付款方式" prop="suPayMethod">
                  <el-select filterable clearable v-model="form.suPayMethod"
                    :placeholder="$t('btn.selectPrefix')+'付款方式'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_payment_method" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="统驭科目" prop="suRecAccount">
                  <el-select filterable clearable v-model="form.suRecAccount"
                    :placeholder="$t('btn.selectPrefix')+'统驭科目'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_recon_account" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="贸易条件" prop="suTradeTerms">
                  <el-select filterable clearable v-model="form.suTradeTerms"
                    :placeholder="$t('btn.selectPrefix')+'贸易条件'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_terms_trade" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="装运条件" prop="suShippingTerms">
                  <el-select filterable clearable v-model="form.suShippingTerms"
                    :placeholder="$t('btn.selectPrefix')+'装运条件'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_cond_shipment" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="供应商等级" prop="suSupplierGrade">
                  <el-select filterable clearable v-model="form.suSupplierGrade"
                    :placeholder="$t('btn.selectPrefix')+'供应商等级'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_grade_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="供应商信用" prop="suSupplierCredit">
                  <el-select filterable clearable v-model="form.suSupplierCredit"
                    :placeholder="$t('btn.selectPrefix')+'供应商信用'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_credit_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="首次交易" prop="suFirstTransDate">
                  <el-date-picker v-model="form.suFirstTransDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="末次交易" prop="suLastTransDate">
                  <el-date-picker v-model="form.suLastTransDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行代码" prop="suBankCode">
                  <el-input v-model="form.suBankCode"
                    :placeholder="$t('btn.enterPrefix')+'银行代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行名称" prop="suBankName">
                  <el-input v-model="form.suBankName"
                    :placeholder="$t('btn.enterPrefix')+'银行名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分行名称" prop="suBranchName">
                  <el-input v-model="form.suBranchName"
                    :placeholder="$t('btn.enterPrefix')+'分行名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行所在国" prop="suBankCountry">
                  <el-select filterable clearable v-model="form.suBankCountry"
                    :placeholder="$t('btn.selectPrefix')+'银行所在国'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_country_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="所在州省" prop="suBankState">
                  <el-input v-model="form.suBankState"
                    :placeholder="$t('btn.enterPrefix')+'所在州省'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="所在市" prop="suBankCity">
                  <el-input v-model="form.suBankCity"
                    :placeholder="$t('btn.enterPrefix')+'所在市'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="所在县" prop="suBankCounty">
                  <el-input v-model="form.suBankCounty"
                    :placeholder="$t('btn.enterPrefix')+'所在县'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行地址" prop="suBankAddr">
                  <el-input v-model="form.suBankAddr"
                    :placeholder="$t('btn.enterPrefix')+'银行地址'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行地址1" prop="suBankAddr1">
                  <el-input v-model="form.suBankAddr1"
                    :placeholder="$t('btn.enterPrefix')+'银行地址1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行地址2" prop="suBankAddr2">
                  <el-input v-model="form.suBankAddr2"
                    :placeholder="$t('btn.enterPrefix')+'银行地址2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="银行账号" prop="suBankAccount">
                  <el-input v-model="form.suBankAccount"
                    :placeholder="$t('btn.enterPrefix')+'银行账号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="SWIFT代码" prop="suBankSwiftNo">
                  <el-input v-model="form.suBankSwiftNo"
                    :placeholder="$t('btn.enterPrefix')+'SWIFT代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="国家地区" prop="suRegionCode">
                  <el-select filterable clearable v-model="form.suRegionCode"
                    :placeholder="$t('btn.selectPrefix')+'国家地区'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_country_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="州省" prop="suState">
                  <el-input v-model="form.suState" :placeholder="$t('btn.enterPrefix')+'州省'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="市" prop="suCity">
                  <el-input v-model="form.suCity" :placeholder="$t('btn.enterPrefix')+'市'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="县" prop="suCounty">
                  <el-input v-model="form.suCounty" :placeholder="$t('btn.enterPrefix')+'县'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="地址" prop="suAddr">
                  <el-input v-model="form.suAddr" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="地址1" prop="suAddr1">
                  <el-input v-model="form.suAddr1" :placeholder="$t('btn.enterPrefix')+'地址1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="地址2" prop="suAddr2">
                  <el-input v-model="form.suAddr2" :placeholder="$t('btn.enterPrefix')+'地址2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="联系人" prop="suContacts">
                  <el-input v-model="form.suContacts"
                    :placeholder="$t('btn.enterPrefix')+'联系人'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="邮件" prop="suEmail">
                  <el-input v-model="form.suEmail" :placeholder="$t('btn.enterPrefix')+'邮件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="电话" prop="suTelNo">
                  <el-input v-model="form.suTelNo" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="传真" prop="suFaxNp">
                  <el-input v-model="form.suFaxNp" :placeholder="$t('btn.enterPrefix')+'传真'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="手机" prop="suPhoneNo">
                  <el-input v-model="form.suPhoneNo" :placeholder="$t('btn.enterPrefix')+'手机'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="冻结标志" prop="isFroze">
                  <el-radio-group v-model="form.isFroze">
                    <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="营业执照附件" prop="suLicenseAnnex">
                  <UploadFile v-model="form.suLicenseAnnex" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="其它附件" prop="suOtherAnnex">
                  <UploadFile v-model="form.suOtherAnnex" :data="{ uploadType: 1 }" />
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

              <el-col :lg="24">
                <el-form-item label="说明" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
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

<script setup name="mmsupplier">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listMmSupplier,
    addMmSupplier, delMmSupplier,
    updateMmSupplier, getMmSupplier,
  }
    from '@/api/logistics/mmsupplier.js'
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
    suOrg: undefined,
    //是否查询（1是）
    suIndustryType: undefined,
    //是否查询（1是）
    suEnterpriseNature: undefined,
    //是否查询（1是）
    suCode: undefined,
    //是否查询（1是）
    suAbbr: undefined,
    //是否查询（1是）
    suName: undefined,
    //是否查询（1是）
    suTaxType: undefined,
    //是否查询（1是）
    suCcy: undefined,
    //是否查询（1是）
    suPayTerms: undefined,
    //是否查询（1是）
    suPayMethod: undefined,
    //是否查询（1是）
    suRecAccount: undefined,
    //是否查询（1是）
    suTradeTerms: undefined,
    //是否查询（1是）
    suShippingTerms: undefined,
    //是否查询（1是）
    suSupplierGrade: undefined,
    //是否查询（1是）
    suSupplierCredit: undefined,
    //是否查询（1是）
    suFirstTransDate: undefined,
    //是否查询（1是）
    suRegionCode: undefined,
    //是否查询（1是）
    isFroze: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'suSfId', label: 'SFID' },
    { visible: true, prop: 'suOrg', label: '购买组织' },
    { visible: true, prop: 'suIndustryType', label: '行业类别' },
    { visible: true, prop: 'suEnterpriseNature', label: '企业性质' },
    { visible: true, prop: 'suCode', label: '供应商代码' },
    { visible: true, prop: 'suAbbr', label: '供应商简称' },
    { visible: true, prop: 'suName', label: '供应商名称' },
    { visible: true, prop: 'suEbe', label: '企业法人' },
    { visible: false, prop: 'suBusinessNo', label: '营业执照' },
    { visible: false, prop: 'suTaxNo', label: '税号' },
    { visible: false, prop: 'suTaxType', label: '税别' },
    { visible: false, prop: 'suMainBusiness', label: '主营业务' },
    { visible: false, prop: 'suCcy', label: '交易币种' },
    { visible: false, prop: 'suPayTerms', label: '付款条件' },
    { visible: false, prop: 'suPayMethod', label: '付款方式' },
    { visible: false, prop: 'suRecAccount', label: '统驭科目' },
    { visible: false, prop: 'suTradeTerms', label: '贸易条件' },
    { visible: false, prop: 'suShippingTerms', label: '装运条件' },
    { visible: false, prop: 'suSupplierGrade', label: '供应商等级' },
    { visible: false, prop: 'suSupplierCredit', label: '供应商信用' },
    { visible: false, prop: 'suFirstTransDate', label: '首次交易' },
    { visible: false, prop: 'suLastTransDate', label: '末次交易' },
    { visible: false, prop: 'suBankCode', label: '银行代码' },
    { visible: false, prop: 'suBankName', label: '银行名称' },
    { visible: false, prop: 'suBranchName', label: '分行名称' },
    { visible: false, prop: 'suBankCountry', label: '银行所在国' },
    { visible: false, prop: 'suBankState', label: '所在州省' },
    { visible: false, prop: 'suBankCity', label: '所在市' },
    { visible: false, prop: 'suBankCounty', label: '所在县' },
    { visible: false, prop: 'suBankAddr', label: '银行地址' },
    { visible: false, prop: 'suBankAddr1', label: '银行地址1' },
    { visible: false, prop: 'suBankAddr2', label: '银行地址2' },
    { visible: false, prop: 'suBankAccount', label: '银行账号' },
    { visible: false, prop: 'suBankSwiftNo', label: 'SWIFT代码' },
    { visible: false, prop: 'suRegionCode', label: '国家地区' },
    { visible: false, prop: 'suState', label: '州省' },
    { visible: false, prop: 'suCity', label: '市' },
    { visible: false, prop: 'suCounty', label: '县' },
    { visible: false, prop: 'suAddr', label: '地址' },
    { visible: false, prop: 'suAddr1', label: '地址1' },
    { visible: false, prop: 'suAddr2', label: '地址2' },
    { visible: false, prop: 'suContacts', label: '联系人' },
    { visible: false, prop: 'suEmail', label: '邮件' },
    { visible: false, prop: 'suTelNo', label: '电话' },
    { visible: false, prop: 'suFaxNp', label: '传真' },
    { visible: false, prop: 'suPhoneNo', label: '手机' },
    { visible: false, prop: 'isFroze', label: '冻结标志' },
    { visible: false, prop: 'suLicenseAnnex', label: '营业执照附件' },
    { visible: false, prop: 'suOtherAnnex', label: '其它附件' },
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






















  // 首次交易时间范围
  const dateRangeSuFirstTransDate = ref([])
















































  //字典参数
  var dictParams = [
    { dictType: "sys_plant_list" },
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
    { dictType: "sys_freeze_flag" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从供应商信息/mm_supplier表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeSuFirstTransDate.value, 'SuFirstTransDate');
    loading.value = true
    listMmSupplier(queryParams).then(res => {
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
    // 首次交易时间范围
    dateRangeSuFirstTransDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.suSfId);
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
      suSfId: [{ required: true, message: "SFID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suOrg: [{ required: true, message: "购买组织" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suIndustryType: [{ required: true, message: "行业类别" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suEnterpriseNature: [{ required: true, message: "企业性质" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suCode: [{ required: true, message: "供应商代码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suAbbr: [{ required: true, message: "供应商简称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suName: [{ required: true, message: "供应商名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suEbe: [{ required: true, message: "企业法人" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suBusinessNo: [{ required: true, message: "营业执照" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suTaxNo: [{ required: true, message: "税号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suTaxType: [{ required: true, message: "税别" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suMainBusiness: [{ required: true, message: "主营业务" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suCcy: [{ required: true, message: "交易币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suPayTerms: [{ required: true, message: "付款条件" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suPayMethod: [{ required: true, message: "付款方式" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suRecAccount: [{ required: true, message: "统驭科目" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suTradeTerms: [{ required: true, message: "贸易条件" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suShippingTerms: [{ required: true, message: "装运条件" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suBankCode: [{ required: true, message: "银行代码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suBankName: [{ required: true, message: "银行名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suBankCountry: [{ required: true, message: "银行所在国" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      suBankState: [{ required: true, message: "所在州省" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suBankCity: [{ required: true, message: "所在市" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suBankCounty: [{ required: true, message: "所在县" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suBankAddr: [{ required: true, message: "银行地址" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suBankAccount: [{ required: true, message: "银行账号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      suAddr: [{ required: true, message: "地址" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isFroze: [{ required: true, message: "冻结标志" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      uDF51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 购买组织 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
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
      // 供应商等级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_grade_list: [],
      // 供应商信用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_credit_list: [],
      // 银行所在国 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_country_list: [],
      // 冻结标志 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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

  // 重置表单
  function reset() {
    form.value = {
      suSfId: 0,
      suOrg: null,
      suIndustryType: null,
      suEnterpriseNature: null,
      suCode: null,
      suAbbr: null,
      suName: null,
      suEbe: null,
      suBusinessNo: null,
      suTaxNo: null,
      suTaxType: null,
      suMainBusiness: null,
      suCcy: null,
      suPayTerms: null,
      suPayMethod: null,
      suRecAccount: null,
      suTradeTerms: null,
      suShippingTerms: null,
      suSupplierGrade: null,
      suSupplierCredit: null,
      suFirstTransDate: null,
      suLastTransDate: null,
      suBankCode: null,
      suBankName: null,
      suBranchName: null,
      suBankCountry: null,
      suBankState: null,
      suBankCity: null,
      suBankCounty: null,
      suBankAddr: null,
      suBankAddr1: null,
      suBankAddr2: null,
      suBankAccount: null,
      suBankSwiftNo: null,
      suRegionCode: null,
      suState: null,
      suCity: null,
      suCounty: null,
      suAddr: null,
      suAddr1: null,
      suAddr2: null,
      suContacts: null,
      suEmail: null,
      suTelNo: null,
      suFaxNp: null,
      suPhoneNo: null,
      isFroze: 0,
      suLicenseAnnex: null,
      suOtherAnnex: null,
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
    title.value = proxy.$t('btn.add') + " " + '供应商信息'
    opertype.value = 1
    form.value.suOrg = []
    form.value.suIndustryType = []
    form.value.suEnterpriseNature = []
    form.value.suTaxType = []
    form.value.suCcy = []
    form.value.suPayTerms = []
    form.value.suPayMethod = []
    form.value.suRecAccount = []
    form.value.suTradeTerms = []
    form.value.suShippingTerms = []
    form.value.suSupplierGrade = []
    form.value.suSupplierCredit = []
    form.value.suFirstTransDate = new Date()
    form.value.suLastTransDate = new Date()
    form.value.suBankCountry = []
    form.value.suRegionCode = []
    form.value.isFroze = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.suSfId || ids.value
    getMmSupplier(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '供应商信息'
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

        if (form.value.suSfId != undefined && opertype.value === 2) {
          updateMmSupplier(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addMmSupplier(form.value).then((res) => {
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
    const Ids = row.suSfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delMmSupplier(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<供应商信息.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/MmSupplier/export', { ...queryParams })
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