<!--
 * @Descripttion: (厂商信息/mm_vendor)
 * @Version: (0.24.390.26609)
 * @Author: (Lean365)
 * @Date: (2024/1/25 16:26:50)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="购买组织" prop="veOrg">
        <el-select clearable filterable  v-model="queryParams.veOrg" :placeholder="$t('btn.select')+'购买组织'">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="行业类别" prop="veIndustryType">
        <el-select clearable filterable  v-model="queryParams.veIndustryType" :placeholder="$t('btn.select')+'行业类别'">
          <el-option v-for="item in  options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="企业性质" prop="veEnterpriseNature">
        <el-select clearable filterable  v-model="queryParams.veEnterpriseNature" :placeholder="$t('btn.select')+'企业性质'">
          <el-option v-for="item in  options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商代码" prop="veCode">
        <el-input clearable v-model="queryParams.veCode" :placeholder="$t('btn.enter')+'供应商代码'" />
      </el-form-item>
      <el-form-item label="供应商简称" prop="veAbbr">
        <el-input clearable v-model="queryParams.veAbbr" :placeholder="$t('btn.enter')+'供应商简称'" />
      </el-form-item>
      <el-form-item label="交易币种" prop="veCcy">
        <el-select clearable filterable  v-model="queryParams.veCcy" :placeholder="$t('btn.select')+'交易币种'">
          <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款条件" prop="vePayTerms">
        <el-select clearable filterable  v-model="queryParams.vePayTerms" :placeholder="$t('btn.select')+'付款条件'">
          <el-option v-for="item in  options.sys_payment_terms " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款方式" prop="vePayMethod">
        <el-select clearable filterable  v-model="queryParams.vePayMethod" :placeholder="$t('btn.select')+'付款方式'">
          <el-option v-for="item in  options.sys_payment_method " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['mm:vendor:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['mm:vendor:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['mm:vendor:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:vendor:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="logistics/Vendor/importTemplate"
                  importUrl="/logistics/Vendor/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['mm:vendor:export']">
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
      <el-table-column prop="veSFID" label="SFID" align="center" v-if="columns.showColumn('veSFID')"/>
      <el-table-column prop="veOrg" label="购买组织" align="center" v-if="columns.showColumn('veOrg')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.veOrg"  />
        </template>
      </el-table-column>
      <el-table-column prop="veIndustryType" label="行业类别" align="center" v-if="columns.showColumn('veIndustryType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.veIndustryType"  />
        </template>
      </el-table-column>
      <el-table-column prop="veEnterpriseNature" label="企业性质" align="center" v-if="columns.showColumn('veEnterpriseNature')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.veEnterpriseNature"  />
        </template>
      </el-table-column>
      <el-table-column prop="veCode" label="供应商代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veCode')"/>
      <el-table-column prop="veAbbr" label="供应商简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veAbbr')"/>
      <el-table-column prop="veName" label="供应商名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veName')"/>
      <el-table-column prop="veEbe" label="企业法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veEbe')"/>
      <el-table-column prop="veBusinessNo" label="营业执照" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBusinessNo')"/>
      <el-table-column prop="veTaxNo" label="税号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veTaxNo')"/>
      <el-table-column prop="veTaxType" label="税别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veTaxType')"/>
      <el-table-column prop="veMainBusiness" label="主营业务" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veMainBusiness')"/>
      <el-table-column prop="veCcy" label="交易币种" align="center" v-if="columns.showColumn('veCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.veCcy"  />
        </template>
      </el-table-column>
      <el-table-column prop="vePayTerms" label="付款条件" align="center" v-if="columns.showColumn('vePayTerms')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_terms " :value="scope.row.vePayTerms"  />
        </template>
      </el-table-column>
      <el-table-column prop="vePayMethod" label="付款方式" align="center" v-if="columns.showColumn('vePayMethod')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_method " :value="scope.row.vePayMethod"  />
        </template>
      </el-table-column>
      <el-table-column prop="veRecAccount" label="统驭科目" align="center" v-if="columns.showColumn('veRecAccount')">
        <template #default="scope">
          <dict-tag :options=" options.sql_recon_account " :value="scope.row.veRecAccount"  />
        </template>
      </el-table-column>
      <el-table-column prop="veTradeTerms" label="贸易条件" align="center" v-if="columns.showColumn('veTradeTerms')">
        <template #default="scope">
          <dict-tag :options=" options.app_terms_trade " :value="scope.row.veTradeTerms"  />
        </template>
      </el-table-column>
      <el-table-column prop="veShippingTerms" label="装运条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veShippingTerms')"/>
      <el-table-column prop="veSupplierGrade" label="供应商等级" align="center" v-if="columns.showColumn('veSupplierGrade')">
        <template #default="scope">
          <dict-tag :options=" options.sys_grade_list " :value="scope.row.veSupplierGrade"  />
        </template>
      </el-table-column>
      <el-table-column prop="veSupplierCredit" label="供应商信用" align="center" v-if="columns.showColumn('veSupplierCredit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_credit_list " :value="scope.row.veSupplierCredit"  />
        </template>
      </el-table-column>
      <el-table-column prop="veFirstTransDate" label="首次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('veFirstTransDate')"/>
      <el-table-column prop="veLastTransDate" label="末次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('veLastTransDate')"/>
      <el-table-column prop="veBankCode" label="银行代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankCode')"/>
      <el-table-column prop="veBankName" label="银行名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankName')"/>
      <el-table-column prop="veBranchName" label="分行名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBranchName')"/>
      <el-table-column prop="veBankCountry" label="银行所在国" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankCountry')"/>
      <el-table-column prop="veBankState" label="所在州省" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankState')"/>
      <el-table-column prop="veBankCity" label="所在市" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankCity')"/>
      <el-table-column prop="veBankCounty" label="所在县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankCounty')"/>
      <el-table-column prop="veBankAddr" label="银行地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankAddr')"/>
      <el-table-column prop="veBankAddr1" label="银行地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankAddr1')"/>
      <el-table-column prop="veBankAddr2" label="银行地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankAddr2')"/>
      <el-table-column prop="veBankAccount" label="银行账号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankAccount')"/>
      <el-table-column prop="veBankSwiftNo" label="SWIFT代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veBankSwiftNo')"/>
      <el-table-column prop="veRegionCode" label="国家地区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veRegionCode')"/>
      <el-table-column prop="veState" label="州省" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veState')"/>
      <el-table-column prop="veCity" label="市" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veCity')"/>
      <el-table-column prop="veCounty" label="县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veCounty')"/>
      <el-table-column prop="veAddr" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veAddr')"/>
      <el-table-column prop="veAddr1" label="地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veAddr1')"/>
      <el-table-column prop="veAddr2" label="地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veAddr2')"/>
      <el-table-column prop="veContacts" label="联系人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veContacts')"/>
      <el-table-column prop="veEmail" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veEmail')"/>
      <el-table-column prop="veTelNo" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veTelNo')"/>
      <el-table-column prop="veFaxNp" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veFaxNp')"/>
      <el-table-column prop="vePhoneNo" label="手机" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vePhoneNo')"/>
      <el-table-column prop="isFroze" label="冻结标志" align="center" v-if="columns.showColumn('isFroze')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.isFroze"  />
        </template>
      </el-table-column>
      <el-table-column prop="veLicenseAnnex" label="营业执照附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veLicenseAnnex')"/>
      <el-table-column prop="veOtherAnnex" label="其它附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('veOtherAnnex')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:vendor:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:vendor:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改厂商信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="veSFID">
              <el-input v-model.number="form.veSFID" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="购买组织" prop="veOrg">
              <el-select clearable filterable v-model="form.veOrg"  :placeholder="$t('btn.select')+'购买组织'">
                <el-option
                  v-for="item in options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业类别" prop="veIndustryType">
              <el-select clearable filterable v-model="form.veIndustryType"  :placeholder="$t('btn.select')+'行业类别'">
                <el-option
                  v-for="item in options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业性质" prop="veEnterpriseNature">
              <el-select clearable filterable v-model="form.veEnterpriseNature"  :placeholder="$t('btn.select')+'企业性质'">
                <el-option
                  v-for="item in options.sys_nature_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商代码" prop="veCode">
              <el-input clearable v-model="form.veCode" :placeholder="$t('btn.enter')+'供应商代码'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商简称" prop="veAbbr">
              <el-input clearable v-model="form.veAbbr" :placeholder="$t('btn.enter')+'供应商简称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商名称" prop="veName">
              <el-input clearable v-model="form.veName" :placeholder="$t('btn.enter')+'供应商名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业法人" prop="veEbe">
              <el-input clearable v-model="form.veEbe" :placeholder="$t('btn.enter')+'企业法人'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="营业执照" prop="veBusinessNo">
              <el-input clearable v-model="form.veBusinessNo" :placeholder="$t('btn.enter')+'营业执照'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税号" prop="veTaxNo">
              <el-input clearable v-model="form.veTaxNo" :placeholder="$t('btn.enter')+'税号'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税别" prop="veTaxType">
              <el-input clearable v-model="form.veTaxType" :placeholder="$t('btn.enter')+'税别'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="主营业务" prop="veMainBusiness">
              <el-input clearable v-model="form.veMainBusiness" :placeholder="$t('btn.enter')+'主营业务'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交易币种" prop="veCcy">
              <el-select clearable filterable v-model="form.veCcy"  :placeholder="$t('btn.select')+'交易币种'">
                <el-option
                  v-for="item in options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="付款条件" prop="vePayTerms">
              <el-select clearable filterable v-model="form.vePayTerms"  :placeholder="$t('btn.select')+'付款条件'">
                <el-option
                  v-for="item in options.sys_payment_terms" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="付款方式" prop="vePayMethod">
              <el-select clearable filterable v-model="form.vePayMethod"  :placeholder="$t('btn.select')+'付款方式'">
                <el-option
                  v-for="item in options.sys_payment_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="统驭科目" prop="veRecAccount">
              <el-select clearable filterable v-model="form.veRecAccount"  :placeholder="$t('btn.select')+'统驭科目'">
                <el-option
                  v-for="item in options.sql_recon_account" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="贸易条件" prop="veTradeTerms">
              <el-select clearable filterable v-model="form.veTradeTerms"  :placeholder="$t('btn.select')+'贸易条件'">
                <el-option
                  v-for="item in options.app_terms_trade" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装运条件" prop="veShippingTerms">
              <el-input clearable v-model="form.veShippingTerms" :placeholder="$t('btn.enter')+'装运条件'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商等级" prop="veSupplierGrade">
              <el-select clearable filterable v-model="form.veSupplierGrade"  :placeholder="$t('btn.select')+'供应商等级'">
                <el-option
                  v-for="item in options.sys_grade_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商信用" prop="veSupplierCredit">
              <el-select clearable filterable v-model="form.veSupplierCredit"  :placeholder="$t('btn.select')+'供应商信用'">
                <el-option
                  v-for="item in options.sys_credit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="首次交易" prop="veFirstTransDate">
              <el-date-picker v-model="form.veFirstTransDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="末次交易" prop="veLastTransDate">
              <el-date-picker v-model="form.veLastTransDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行代码" prop="veBankCode">
              <el-input clearable v-model="form.veBankCode" :placeholder="$t('btn.enter')+'银行代码'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行名称" prop="veBankName">
              <el-input clearable v-model="form.veBankName" :placeholder="$t('btn.enter')+'银行名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分行名称" prop="veBranchName">
              <el-input clearable v-model="form.veBranchName" :placeholder="$t('btn.enter')+'分行名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行所在国" prop="veBankCountry">
              <el-input clearable v-model="form.veBankCountry" :placeholder="$t('btn.enter')+'银行所在国'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="所在州省" prop="veBankState">
              <el-input clearable v-model="form.veBankState" :placeholder="$t('btn.enter')+'所在州省'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="所在市" prop="veBankCity">
              <el-input clearable v-model="form.veBankCity" :placeholder="$t('btn.enter')+'所在市'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="所在县" prop="veBankCounty">
              <el-input clearable v-model="form.veBankCounty" :placeholder="$t('btn.enter')+'所在县'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行地址" prop="veBankAddr">
              <el-input clearable v-model="form.veBankAddr" :placeholder="$t('btn.enter')+'银行地址'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行地址1" prop="veBankAddr1">
              <el-input clearable v-model="form.veBankAddr1" :placeholder="$t('btn.enter')+'银行地址1'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行地址2" prop="veBankAddr2">
              <el-input clearable v-model="form.veBankAddr2" :placeholder="$t('btn.enter')+'银行地址2'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="银行账号" prop="veBankAccount">
              <el-input clearable v-model="form.veBankAccount" :placeholder="$t('btn.enter')+'银行账号'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SWIFT代码" prop="veBankSwiftNo">
              <el-input clearable v-model="form.veBankSwiftNo" :placeholder="$t('btn.enter')+'SWIFT代码'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家地区" prop="veRegionCode">
              <el-input clearable v-model="form.veRegionCode" :placeholder="$t('btn.enter')+'国家地区'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="州省" prop="veState">
              <el-input clearable v-model="form.veState" :placeholder="$t('btn.enter')+'州省'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="市" prop="veCity">
              <el-input clearable v-model="form.veCity" :placeholder="$t('btn.enter')+'市'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="县" prop="veCounty">
              <el-input clearable v-model="form.veCounty" :placeholder="$t('btn.enter')+'县'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="veAddr">
              <el-input clearable v-model="form.veAddr" :placeholder="$t('btn.enter')+'地址'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址1" prop="veAddr1">
              <el-input clearable v-model="form.veAddr1" :placeholder="$t('btn.enter')+'地址1'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址2" prop="veAddr2">
              <el-input clearable v-model="form.veAddr2" :placeholder="$t('btn.enter')+'地址2'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联系人" prop="veContacts">
              <el-input clearable v-model="form.veContacts" :placeholder="$t('btn.enter')+'联系人'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮件" prop="veEmail">
              <el-input clearable v-model="form.veEmail" :placeholder="$t('btn.enter')+'邮件'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="veTelNo">
              <el-input clearable v-model="form.veTelNo" :placeholder="$t('btn.enter')+'电话'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="veFaxNp">
              <el-input clearable v-model="form.veFaxNp" :placeholder="$t('btn.enter')+'传真'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手机" prop="vePhoneNo">
              <el-input clearable v-model="form.vePhoneNo" :placeholder="$t('btn.enter')+'手机'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="冻结标志" prop="isFroze">
              <el-radio-group v-model="form.isFroze">
                <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue" :label="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="营业执照附件" prop="veLicenseAnnex">
              <UploadFile v-model="form.veLicenseAnnex" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="其它附件" prop="veOtherAnnex">
              <UploadFile v-model="form.veOtherAnnex" :data="{ uploadType: 1 }" />
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
              <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'自定义1'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'自定义2'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'自定义3'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'自定义4'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'自定义5'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'自定义6'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'说明'"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input clearable v-model.number="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true" maxlength="10" show-word-limit/>
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

<script setup name="vendor">
//后台操作函数
import { listVendor,
 addVendor, delVendor, 
 updateVendor,getVendor, 
 } 
from '@/api/logistics/vendor.js'
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
  veOrg: undefined,
  veIndustryType: undefined,
  veEnterpriseNature: undefined,
  veCode: undefined,
  veAbbr: undefined,
  veCcy: undefined,
  vePayTerms: undefined,
  vePayMethod: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'veSFID', label: 'SFID' },
  { visible: true, prop: 'veOrg', label: '购买组织' },
  { visible: true, prop: 'veIndustryType', label: '行业类别' },
  { visible: true, prop: 'veEnterpriseNature', label: '企业性质' },
  { visible: true, prop: 'veCode', label: '供应商代码' },
  { visible: true, prop: 'veAbbr', label: '供应商简称' },
  { visible: true, prop: 'veName', label: '供应商名称' },
  { visible: true, prop: 'veEbe', label: '企业法人' },
  { visible: false, prop: 'veBusinessNo', label: '营业执照' },
  { visible: false, prop: 'veTaxNo', label: '税号' },
  { visible: false, prop: 'veTaxType', label: '税别' },
  { visible: false, prop: 'veMainBusiness', label: '主营业务' },
  { visible: false, prop: 'veCcy', label: '交易币种' },
  { visible: false, prop: 'vePayTerms', label: '付款条件' },
  { visible: false, prop: 'vePayMethod', label: '付款方式' },
  { visible: false, prop: 'veRecAccount', label: '统驭科目' },
  { visible: false, prop: 'veTradeTerms', label: '贸易条件' },
  { visible: false, prop: 'veShippingTerms', label: '装运条件' },
  { visible: false, prop: 'veSupplierGrade', label: '供应商等级' },
  { visible: false, prop: 'veSupplierCredit', label: '供应商信用' },
  { visible: false, prop: 'veFirstTransDate', label: '首次交易' },
  { visible: false, prop: 'veLastTransDate', label: '末次交易' },
  { visible: false, prop: 'veBankCode', label: '银行代码' },
  { visible: false, prop: 'veBankName', label: '银行名称' },
  { visible: false, prop: 'veBranchName', label: '分行名称' },
  { visible: false, prop: 'veBankCountry', label: '银行所在国' },
  { visible: false, prop: 'veBankState', label: '所在州省' },
  { visible: false, prop: 'veBankCity', label: '所在市' },
  { visible: false, prop: 'veBankCounty', label: '所在县' },
  { visible: false, prop: 'veBankAddr', label: '银行地址' },
  { visible: false, prop: 'veBankAddr1', label: '银行地址1' },
  { visible: false, prop: 'veBankAddr2', label: '银行地址2' },
  { visible: false, prop: 'veBankAccount', label: '银行账号' },
  { visible: false, prop: 'veBankSwiftNo', label: 'SWIFT代码' },
  { visible: false, prop: 'veRegionCode', label: '国家地区' },
  { visible: false, prop: 'veState', label: '州省' },
  { visible: false, prop: 'veCity', label: '市' },
  { visible: false, prop: 'veCounty', label: '县' },
  { visible: false, prop: 'veAddr', label: '地址' },
  { visible: false, prop: 'veAddr1', label: '地址1' },
  { visible: false, prop: 'veAddr2', label: '地址2' },
  { visible: false, prop: 'veContacts', label: '联系人' },
  { visible: false, prop: 'veEmail', label: '邮件' },
  { visible: false, prop: 'veTelNo', label: '电话' },
  { visible: false, prop: 'veFaxNp', label: '传真' },
  { visible: false, prop: 'vePhoneNo', label: '手机' },
  { visible: false, prop: 'isFroze', label: '冻结标志' },
  { visible: false, prop: 'veLicenseAnnex', label: '营业执照附件' },
  { visible: false, prop: 'veOtherAnnex', label: '其它附件' },
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
  { dictType: "sys_crop_list" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_nature_list" },
  { dictType: "sys_ccy_type" },
  { dictType: "sys_payment_terms" },
  { dictType: "sys_payment_method" },
  { dictType: "sql_recon_account" },
  { dictType: "app_terms_trade" },
  { dictType: "sys_grade_list" },
  { dictType: "sys_credit_list" },
  { dictType: "sys_freeze_flag" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从厂商信息/mm_vendor表记录数据
function getList(){
  loading.value = true
  listVendor(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.veSFID);
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
    veSFID: [{ required: true, message: 'SFID'+ proxy.$t('btn.empty'), trigger: "blur" }],
    veOrg: [{ required: true, message: '购买组织'+ proxy.$t('btn.empty'), trigger: "change"     }],
    veIndustryType: [{ required: true, message: '行业类别'+ proxy.$t('btn.empty'), trigger: "change"     }],
    veEnterpriseNature: [{ required: true, message: '企业性质'+ proxy.$t('btn.empty'), trigger: "change"     }],
    veCode: [{ required: true, message: '供应商代码'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veAbbr: [{ required: true, message: '供应商简称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veName: [{ required: true, message: '供应商名称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veEbe: [{ required: true, message: '企业法人'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBusinessNo: [{ required: true, message: '营业执照'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veTaxNo: [{ required: true, message: '税号'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veTaxType: [{ required: true, message: '税别'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veMainBusiness: [{ required: true, message: '主营业务'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veCcy: [{ required: true, message: '交易币种'+ proxy.$t('btn.empty'), trigger: "change"     }],
    vePayTerms: [{ required: true, message: '付款条件'+ proxy.$t('btn.empty'), trigger: "change"     }],
    vePayMethod: [{ required: true, message: '付款方式'+ proxy.$t('btn.empty'), trigger: "change"     }],
    veRecAccount: [{ required: true, message: '统驭科目'+ proxy.$t('btn.empty'), trigger: "change"     }],
    veTradeTerms: [{ required: true, message: '贸易条件'+ proxy.$t('btn.empty'), trigger: "change"     }],
    veShippingTerms: [{ required: true, message: '装运条件'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankCode: [{ required: true, message: '银行代码'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankName: [{ required: true, message: '银行名称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankCountry: [{ required: true, message: '银行所在国'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankState: [{ required: true, message: '所在州省'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankCity: [{ required: true, message: '所在市'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankCounty: [{ required: true, message: '所在县'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankAddr: [{ required: true, message: '银行地址'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veBankAccount: [{ required: true, message: '银行账号'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    veAddr: [{ required: true, message: '地址'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    isFroze: [{ required: true, message: '冻结标志'+ proxy.$t('btn.empty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 购买组织 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
    // 行业类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ind_type: [],
    // 企业性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_nature_list: [],
    // 交易币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ccy_type: [],
    // 付款条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_payment_terms: [],
    // 付款方式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_payment_method: [],
    // 统驭科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_recon_account: [],
    // 贸易条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_terms_trade: [],
    // 供应商等级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_grade_list: [],
    // 供应商信用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_credit_list: [],
    // 冻结标志 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_freeze_flag: [],
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
// @Version: (0.24.390.26609)
// @Author: (Lean365)
// @Date: (2024/1/25 16:26:50)



// 重置表单
function reset() {
  form.value = {
    veSFID: 0,
    veOrg: null,
    veIndustryType: null,
    veEnterpriseNature: null,
    veCode: null,
    veAbbr: null,
    veName: null,
    veEbe: null,
    veBusinessNo: null,
    veTaxNo: null,
    veTaxType: null,
    veMainBusiness: null,
    veCcy: null,
    vePayTerms: null,
    vePayMethod: null,
    veRecAccount: null,
    veTradeTerms: null,
    veShippingTerms: null,
    veSupplierGrade: null,
    veSupplierCredit: null,
    veFirstTransDate: null,
    veLastTransDate: null,
    veBankCode: null,
    veBankName: null,
    veBranchName: null,
    veBankCountry: null,
    veBankState: null,
    veBankCity: null,
    veBankCounty: null,
    veBankAddr: null,
    veBankAddr1: null,
    veBankAddr2: null,
    veBankAccount: null,
    veBankSwiftNo: null,
    veRegionCode: null,
    veState: null,
    veCity: null,
    veCounty: null,
    veAddr: null,
    veAddr1: null,
    veAddr2: null,
    veContacts: null,
    veEmail: null,
    veTelNo: null,
    veFaxNp: null,
    vePhoneNo: null,
    isFroze: 0,
    veLicenseAnnex: null,
    veOtherAnnex: null,
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
  title.value = proxy.$t('btn.add')+'厂商信息'
  opertype.value = 1
  form.value.veOrg= []
  form.value.veIndustryType= []
  form.value.veEnterpriseNature= []
  form.value.veCcy= []
  form.value.vePayTerms= []
  form.value.vePayMethod= []
  form.value.veRecAccount= []
  form.value.veTradeTerms= []
  form.value.veSupplierGrade= []
  form.value.veSupplierCredit= []
  form.value.veFirstTransDate= new Date()
  form.value.veLastTransDate= new Date()
  form.value.isFroze= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.veSFID || ids.value
  getVendor(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ '厂商信息'
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

      if (form.value.veSFID != undefined && opertype.value === 2) {
        updateVendor(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addVendor(form.value).then((res) => {
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
  const Ids = row.veSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delVendor(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"厂商信息", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/logistics/Vendor/export', { ...queryParams })
    })
}


// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.390.26609)
// @Author: (Lean365)
// @Date: (2024/1/25 16:26:50)

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