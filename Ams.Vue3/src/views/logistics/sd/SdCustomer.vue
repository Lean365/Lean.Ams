<!--
 * @Descripttion: 顾客/sd_customer
 * @Version: 0.24.620.29516
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 16:25:01
 * @column：65
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="销售组织" prop="mb003">
        <el-select filterable clearable   v-model="queryParams.mb003" :placeholder="$t('btn.selectSearchPrefix')+'销售组织'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="行业类别" prop="mb004">
        <el-select filterable clearable   v-model="queryParams.mb004" :placeholder="$t('btn.selectSearchPrefix')+'行业类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="企业性质" prop="mb005">
        <el-select filterable clearable   v-model="queryParams.mb005" :placeholder="$t('btn.selectSearchPrefix')+'企业性质'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客户代码" prop="mb006">
        <el-input v-model="queryParams.mb006" :placeholder="$t('btn.enterSearchPrefix')+'客户代码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="客户简称" prop="mb007">
        <el-input v-model="queryParams.mb007" :placeholder="$t('btn.enterSearchPrefix')+'客户简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="客户名称" prop="mb008">
        <el-input v-model="queryParams.mb008" :placeholder="$t('btn.enterSearchPrefix')+'客户名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="交易币种" prop="mb014">
        <el-select filterable clearable   v-model="queryParams.mb014" :placeholder="$t('btn.selectSearchPrefix')+'交易币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款条件" prop="mb015">
        <el-select filterable clearable   v-model="queryParams.mb015" :placeholder="$t('btn.selectSearchPrefix')+'付款条件'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_payment_terms " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客户等级" prop="mb020">
        <el-select filterable clearable   v-model="queryParams.mb020" :placeholder="$t('btn.selectSearchPrefix')+'客户等级'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_grade_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商" prop="mb024">
        <el-input v-model="queryParams.mb024" :placeholder="$t('btn.enterSearchPrefix')+'供应商'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="国家地区" prop="mb025">
        <el-select filterable clearable   v-model="queryParams.mb025" :placeholder="$t('btn.selectSearchPrefix')+'国家地区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
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
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sd:customer:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sd:customer:delete']" plain icon="delete" @click="handleDelete">
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
                <importData
                  templateUrl="Logistics/SdCustomer/importTemplate"
                  importUrl="/Logistics/SdCustomer/importData"
                  @success="handleFileSuccess"></importData>
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="mb002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb002')"/>
      <el-table-column prop="mb003" label="销售组织" align="center" v-if="columns.showColumn('mb003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mb003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb004" label="行业类别" align="center" v-if="columns.showColumn('mb004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mb004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb005" label="企业性质" align="center" v-if="columns.showColumn('mb005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.mb005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb006" label="客户代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb006')"/>
      <el-table-column prop="mb007" label="客户简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb007')"/>
      <el-table-column prop="mb008" label="客户名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb008')"/>
      <el-table-column prop="mb009" label="企业法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb009')"/>
      <el-table-column prop="mb010" label="税号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb010')"/>
      <el-table-column prop="mb011" label="营业执照" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb011')"/>
      <el-table-column prop="mb012" label="税别" align="center" v-if="columns.showColumn('mb012')">
        <template #default="scope">
          <dict-tag :options=" options.sys_tax_type " :value="scope.row.mb012"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb013" label="主营业务" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb013')"/>
      <el-table-column prop="mb014" label="交易币种" align="center" v-if="columns.showColumn('mb014')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.mb014"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb015" label="付款条件" align="center" v-if="columns.showColumn('mb015')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_terms " :value="scope.row.mb015"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb016" label="付款方式" align="center" v-if="columns.showColumn('mb016')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_method " :value="scope.row.mb016"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb017" label="统驭科目" align="center" v-if="columns.showColumn('mb017')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mitkz_list " :value="scope.row.mb017"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb018" label="贸易条件" align="center" v-if="columns.showColumn('mb018')">
        <template #default="scope">
          <dict-tag :options=" options.sys_terms_trade " :value="scope.row.mb018"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb019" label="装运条件" align="center" v-if="columns.showColumn('mb019')">
        <template #default="scope">
          <dict-tag :options=" options.sys_cond_shipment " :value="scope.row.mb019"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb020" label="客户等级" align="center" v-if="columns.showColumn('mb020')">
        <template #default="scope">
          <dict-tag :options=" options.sys_grade_list " :value="scope.row.mb020"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb021" label="客户信用" align="center" v-if="columns.showColumn('mb021')">
        <template #default="scope">
          <dict-tag :options=" options.sys_credit_list " :value="scope.row.mb021"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb022" label="首次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('mb022')"/>
      <el-table-column prop="mb023" label="最近交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('mb023')"/>
      <el-table-column prop="mb024" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb024')"/>
      <el-table-column prop="mb025" label="国家地区" align="center" v-if="columns.showColumn('mb025')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.mb025"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb026" label="州省" align="center" v-if="columns.showColumn('mb026')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_state " :value="scope.row.mb026"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb027" label="市" align="center" v-if="columns.showColumn('mb027')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.mb027"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb028" label="县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb028')"/>
      <el-table-column prop="mb029" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb029')"/>
      <el-table-column prop="mb030" label="地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb030')"/>
      <el-table-column prop="mb031" label="地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb031')"/>
      <el-table-column prop="mb032" label="邮政编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb032')"/>
      <el-table-column prop="mb033" label="地址号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb033')"/>
      <el-table-column prop="mb034" label="联系人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb034')"/>
      <el-table-column prop="mb035" label="电邮" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb035')"/>
      <el-table-column prop="mb036" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb036')"/>
      <el-table-column prop="mb037" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb037')"/>
      <el-table-column prop="mb038" label="手机" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb038')"/>
      <el-table-column prop="mb039" label="冻结标记" align="center" v-if="columns.showColumn('mb039')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.mb039"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb040" label="营业执照附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb040')"/>
      <el-table-column prop="mb041" label="其它附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb041')"/>
      <el-table-column prop="reMark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['sd:customer:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['sd:customer:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改顾客对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="mb002">
              <el-input   v-model="form.mb002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售组织" prop="mb003">
              <el-select filterable clearable   v-model="form.mb003"  :placeholder="$t('btn.selectPrefix')+'销售组织'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="行业类别" prop="mb004">
              <el-select filterable clearable   v-model="form.mb004"  :placeholder="$t('btn.selectPrefix')+'行业类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="企业性质" prop="mb005">
              <el-select filterable clearable   v-model="form.mb005"  :placeholder="$t('btn.selectPrefix')+'企业性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_nature_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户代码" prop="mb006">
              <el-input   v-model="form.mb006" :placeholder="$t('btn.enterPrefix')+'客户代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户简称" prop="mb007">
              <el-input   v-model="form.mb007" :placeholder="$t('btn.enterPrefix')+'客户简称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户名称" prop="mb008">
              <el-input   v-model="form.mb008" :placeholder="$t('btn.enterPrefix')+'客户名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业法人" prop="mb009">
              <el-input   v-model="form.mb009" :placeholder="$t('btn.enterPrefix')+'企业法人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税号" prop="mb010">
              <el-input   v-model="form.mb010" :placeholder="$t('btn.enterPrefix')+'税号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="营业执照" prop="mb011">
              <el-input   v-model="form.mb011" :placeholder="$t('btn.enterPrefix')+'营业执照'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税别" prop="mb012">
              <el-select filterable clearable   v-model="form.mb012"  :placeholder="$t('btn.selectPrefix')+'税别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_tax_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="主营业务" prop="mb013">
              <el-input   v-model="form.mb013" :placeholder="$t('btn.enterPrefix')+'主营业务'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交易币种" prop="mb014">
              <el-select filterable clearable   v-model="form.mb014"  :placeholder="$t('btn.selectPrefix')+'交易币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款条件" prop="mb015">
              <el-select filterable clearable   v-model="form.mb015"  :placeholder="$t('btn.selectPrefix')+'付款条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_terms" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款方式" prop="mb016">
              <el-select filterable clearable   v-model="form.mb016"  :placeholder="$t('btn.selectPrefix')+'付款方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="统驭科目" prop="mb017">
              <el-select filterable clearable   v-model="form.mb017"  :placeholder="$t('btn.selectPrefix')+'统驭科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_mitkz_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="贸易条件" prop="mb018">
              <el-select filterable clearable   v-model="form.mb018"  :placeholder="$t('btn.selectPrefix')+'贸易条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_terms_trade" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="装运条件" prop="mb019">
              <el-select filterable clearable   v-model="form.mb019"  :placeholder="$t('btn.selectPrefix')+'装运条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_cond_shipment" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户等级" prop="mb020">
              <el-select filterable clearable   v-model="form.mb020"  :placeholder="$t('btn.selectPrefix')+'客户等级'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_grade_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户信用" prop="mb021">
              <el-select filterable clearable   v-model="form.mb021"  :placeholder="$t('btn.selectPrefix')+'客户信用'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_credit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="首次交易" prop="mb022">
              <el-date-picker v-model="form.mb022" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最近交易" prop="mb023">
              <el-date-picker v-model="form.mb023" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商" prop="mb024">
              <el-input   v-model="form.mb024" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家地区" prop="mb025">
              <el-select filterable clearable   v-model="form.mb025"  :placeholder="$t('btn.selectPrefix')+'国家地区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_country" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="州省" prop="mb026">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" 
              :loading="loading" v-model="form.mb026"  :placeholder="$t('btn.selectPrefix')+'州省'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="市" prop="mb027">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" 
              :loading="loading" v-model="form.mb027"  :placeholder="$t('btn.selectPrefix')+'市'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="县" prop="mb028">
              <el-input   v-model="form.mb028" :placeholder="$t('btn.enterPrefix')+'县'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="mb029">
              <el-input   v-model="form.mb029" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址1" prop="mb030">
              <el-input   v-model="form.mb030" :placeholder="$t('btn.enterPrefix')+'地址1'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址2" prop="mb031">
              <el-input   v-model="form.mb031" :placeholder="$t('btn.enterPrefix')+'地址2'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮政编码" prop="mb032">
              <el-input   v-model="form.mb032" :placeholder="$t('btn.enterPrefix')+'邮政编码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址号码" prop="mb033">
              <el-input   v-model="form.mb033" :placeholder="$t('btn.enterPrefix')+'地址号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联系人" prop="mb034">
              <el-input   v-model="form.mb034" :placeholder="$t('btn.enterPrefix')+'联系人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电邮" prop="mb035">
              <el-input   v-model="form.mb035" :placeholder="$t('btn.enterPrefix')+'电邮'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="mb036">
              <el-input   v-model="form.mb036" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="mb037">
              <el-input   v-model="form.mb037" :placeholder="$t('btn.enterPrefix')+'传真'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手机" prop="mb038">
              <el-input   v-model="form.mb038" :placeholder="$t('btn.enterPrefix')+'手机'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="冻结标记" prop="mb039">
              <el-radio-group v-model="form.mb039">
                <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="营业执照附件" prop="mb040">
              <UploadFile v-model="form.mb040" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="其它附件" prop="mb041">
              <UploadFile v-model="form.mb041" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注说明" prop="reMark">
              <el-input   v-model="form.reMark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="500"/>
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
import { listSdCustomer,
 addSdCustomer, delSdCustomer, 
 updateSdCustomer,getSdCustomer, 
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
  sort: 'Mb003',
  sortType: 'asc',
  //是否查询（1是）
  mb003: undefined,
  //是否查询（1是）
  mb004: undefined,
  //是否查询（1是）
  mb005: undefined,
  //是否查询（1是）
  mb006: undefined,
  //是否查询（1是）
  mb007: undefined,
  //是否查询（1是）
  mb008: undefined,
  //是否查询（1是）
  mb014: undefined,
  //是否查询（1是）
  mb015: undefined,
  //是否查询（1是）
  mb020: undefined,
  //是否查询（1是）
  mb024: undefined,
  //是否查询（1是）
  mb025: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mb002', label: '集团' },
  { visible: true, prop: 'mb003', label: '销售组织' },
  { visible: true, prop: 'mb004', label: '行业类别' },
  { visible: true, prop: 'mb005', label: '企业性质' },
  { visible: true, prop: 'mb006', label: '客户代码' },
  { visible: true, prop: 'mb007', label: '客户简称' },
  { visible: true, prop: 'mb008', label: '客户名称' },
  { visible: false, prop: 'mb009', label: '企业法人' },
  { visible: false, prop: 'mb010', label: '税号' },
  { visible: false, prop: 'mb011', label: '营业执照' },
  { visible: false, prop: 'mb012', label: '税别' },
  { visible: false, prop: 'mb013', label: '主营业务' },
  { visible: false, prop: 'mb014', label: '交易币种' },
  { visible: false, prop: 'mb015', label: '付款条件' },
  { visible: false, prop: 'mb016', label: '付款方式' },
  { visible: false, prop: 'mb017', label: '统驭科目' },
  { visible: false, prop: 'mb018', label: '贸易条件' },
  { visible: false, prop: 'mb019', label: '装运条件' },
  { visible: false, prop: 'mb020', label: '客户等级' },
  { visible: false, prop: 'mb021', label: '客户信用' },
  { visible: false, prop: 'mb022', label: '首次交易' },
  { visible: false, prop: 'mb023', label: '最近交易' },
  { visible: false, prop: 'mb024', label: '供应商' },
  { visible: false, prop: 'mb025', label: '国家地区' },
  { visible: false, prop: 'mb026', label: '州省' },
  { visible: false, prop: 'mb027', label: '市' },
  { visible: false, prop: 'mb028', label: '县' },
  { visible: false, prop: 'mb029', label: '地址' },
  { visible: false, prop: 'mb030', label: '地址1' },
  { visible: false, prop: 'mb031', label: '地址2' },
  { visible: false, prop: 'mb032', label: '邮政编码' },
  { visible: false, prop: 'mb033', label: '地址号码' },
  { visible: false, prop: 'mb034', label: '联系人' },
  { visible: false, prop: 'mb035', label: '电邮' },
  { visible: false, prop: 'mb036', label: '电话' },
  { visible: false, prop: 'mb037', label: '传真' },
  { visible: false, prop: 'mb038', label: '手机' },
  { visible: false, prop: 'mb039', label: '冻结标记' },
  { visible: false, prop: 'mb040', label: '营业执照附件' },
  { visible: false, prop: 'mb041', label: '其它附件' },
  { visible: false, prop: 'reMark', label: '备注说明' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
//定义远程搜索变量
const remotequeryList_sql_global_state=ref([])
//定义远程搜索变量
const remotequery_sql_global_state=ref([])
//远程字典参数
var remotedictParams_sql_global_state = [
    { dictType: "sql_global_state" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_global_state).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_global_state.value = element.list
      })
      //console.log(remotequeryList_sql_global_state)
    })
  })
//远程搜索
const remoteMethod_sql_global_state = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_global_state.value = remotequeryList_sql_global_state.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_global_state(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_global_state.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_global_state = debounce((query) => {
    let arr = remotequeryList_sql_global_state.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_global_state.value = arr.slice(0, 5)
      addFilterOptions_sql_global_state(query)
    } else {
      remotequery_sql_global_state.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_global_state =debounce((dictValue) => {
    let target = remotequeryList_sql_global_state.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_global_state.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_global_state.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
//定义远程搜索变量
const remotequeryList_sql_global_city=ref([])
//定义远程搜索变量
const remotequery_sql_global_city=ref([])
//远程字典参数
var remotedictParams_sql_global_city = [
    { dictType: "sql_global_city" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_global_city).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_global_city.value = element.list
      })
      //console.log(remotequeryList_sql_global_city)
    })
  })
//远程搜索
const remoteMethod_sql_global_city = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_global_city.value = remotequeryList_sql_global_city.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_global_city(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_global_city.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_global_city = debounce((query) => {
    let arr = remotequeryList_sql_global_city.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_global_city.value = arr.slice(0, 5)
      addFilterOptions_sql_global_city(query)
    } else {
      remotequery_sql_global_city.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_global_city =debounce((dictValue) => {
    let target = remotequeryList_sql_global_city.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_global_city.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_global_city.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

//字典参数
var dictParams = [
  { dictType: "sql_corp_list" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_nature_list" },
  { dictType: "sys_tax_type" },
  { dictType: "sql_global_currency" },
  { dictType: "sys_payment_terms" },
  { dictType: "sys_payment_method" },
  { dictType: "sql_mitkz_list" },
  { dictType: "sys_terms_trade" },
  { dictType: "sys_cond_shipment" },
  { dictType: "sys_grade_list" },
  { dictType: "sys_credit_list" },
  { dictType: "sql_global_country" },
  { dictType: "sql_global_state" },
  { dictType: "sql_global_city" },
  { dictType: "sys_freeze_flag" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从顾客/sd_customer表记录数据
function getList(){
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
function resetQuery(){
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.id);
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
//正则表达式
  rules: {
    mb002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb003: [{ required: true, message: "销售组织"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb004: [{ required: true, message: "行业类别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb005: [{ required: true, message: "企业性质"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb006: [{ required: true, message: "客户代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb039: [{ required: true, message: "冻结标记"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 销售组织 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
    // 行业类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ind_type: [],
    // 企业性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_nature_list: [],
    // 税别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_tax_type: [],
    // 交易币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_currency: [],
    // 付款条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_payment_terms: [],
    // 付款方式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_payment_method: [],
    // 统驭科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_mitkz_list: [],
    // 贸易条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_terms_trade: [],
    // 装运条件 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_cond_shipment: [],
    // 客户等级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_grade_list: [],
    // 客户信用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_credit_list: [],
    // 国家地区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_country: [],
    // 州省 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_state: [],
    // 市 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_city: [],
    // 冻结标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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

// 重置表单
function reset() {
  form.value = {
    mb002: null,
    mb003: [],
    mb004: [],
    mb005: [],
    mb006: null,
    mb007: null,
    mb008: null,
    mb009: null,
    mb010: null,
    mb011: null,
    mb012: [],
    mb013: null,
    mb014: [],
    mb015: [],
    mb016: [],
    mb017: [],
    mb018: [],
    mb019: [],
    mb020: [],
    mb021: [],
    mb022: null,
    mb023: null,
    mb024: null,
    mb025: [],
    mb026: [],
    mb027: [],
    mb028: null,
    mb029: null,
    mb030: null,
    mb031: null,
    mb032: null,
    mb033: null,
    mb034: null,
    mb035: null,
    mb036: null,
    mb037: null,
    mb038: null,
    mb039: 0,
    mb040: null,
    mb041: null,
    reMark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'顾客'
  opertype.value = 1
  form.value.mb003= []
  form.value.mb004= []
  form.value.mb005= []
  form.value.mb012= []
  form.value.mb014= []
  form.value.mb015= []
  form.value.mb016= []
  form.value.mb017= []
  form.value.mb018= []
  form.value.mb019= []
  form.value.mb020= []
  form.value.mb021= []
  form.value.mb022= new Date()
  form.value.mb023= new Date()
  form.value.mb025= []
  form.value.mb026= []
  form.value.mb027= []
  form.value.mb039= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getSdCustomer(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '顾客'
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

      if (form.value.id != undefined && opertype.value === 2) {
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
  const Ids = row.id || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<顾客.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
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