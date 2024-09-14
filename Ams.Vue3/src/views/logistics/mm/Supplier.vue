<!--
 * @Descripttion: 供应商/mm_supplier
 * @Version: 0.24.620.18453
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 11:38:53
 * @column：69
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="购买组织" prop="mf003">
        <el-select filterable clearable   v-model="queryParams.mf003" :placeholder="$t('btn.selectSearchPrefix')+'购买组织'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="行业类别" prop="mf004">
        <el-select filterable clearable   v-model="queryParams.mf004" :placeholder="$t('btn.selectSearchPrefix')+'行业类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="企业性质" prop="mf005">
        <el-select filterable clearable   v-model="queryParams.mf005" :placeholder="$t('btn.selectSearchPrefix')+'企业性质'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商代码" prop="mf006">
        <el-input v-model="queryParams.mf006" :placeholder="$t('btn.enterSearchPrefix')+'供应商代码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="供应商简称" prop="mf008">
        <el-input v-model="queryParams.mf008" :placeholder="$t('btn.enterSearchPrefix')+'供应商简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="供应商名称" prop="mf009">
        <el-input v-model="queryParams.mf009" :placeholder="$t('btn.enterSearchPrefix')+'供应商名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="税别" prop="mf013">
        <el-select filterable clearable   v-model="queryParams.mf013" :placeholder="$t('btn.selectSearchPrefix')+'税别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_tax_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购组" prop="mf015">
        <el-select filterable clearable   v-model="queryParams.mf015" :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="交易币种" prop="mf016">
        <el-select filterable clearable   v-model="queryParams.mf016" :placeholder="$t('btn.selectSearchPrefix')+'交易币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款条件" prop="mf017">
        <el-select filterable clearable   v-model="queryParams.mf017" :placeholder="$t('btn.selectSearchPrefix')+'付款条件'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_payment_terms " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款方式" prop="mf018">
        <el-select filterable clearable   v-model="queryParams.mf018" :placeholder="$t('btn.selectSearchPrefix')+'付款方式'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_payment_method " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="统驭科目" prop="mf019">
        <el-select filterable clearable   v-model="queryParams.mf019" :placeholder="$t('btn.selectSearchPrefix')+'统驭科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_mitkz_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="贸易条件" prop="mf020">
        <el-select filterable clearable   v-model="queryParams.mf020" :placeholder="$t('btn.selectSearchPrefix')+'贸易条件'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_terms_trade " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商等级" prop="mf023">
        <el-select filterable clearable   v-model="queryParams.mf023" :placeholder="$t('btn.selectSearchPrefix')+'供应商等级'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_grade_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="国家地区" prop="mf028">
        <el-select filterable clearable   v-model="queryParams.mf028" :placeholder="$t('btn.selectSearchPrefix')+'国家地区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="交易冻结" prop="mf045">
        <el-radio-group v-model="queryParams.mf045">
          <el-radio :value="-1">{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_freeze_flag " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
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
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:supplier:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:supplier:delete']" plain icon="delete" @click="handleDelete">
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
                <importData
                  templateUrl="Logistics/MmSupplier/importTemplate"
                  importUrl="/Logistics/MmSupplier/importData"
                  @success="handleFileSuccess"></importData>
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
      <el-table-column prop="mf002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf002')"/>
      <el-table-column prop="mf003" label="购买组织" align="center" v-if="columns.showColumn('mf003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mf003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf004" label="行业类别" align="center" v-if="columns.showColumn('mf004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mf004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf005" label="企业性质" align="center" v-if="columns.showColumn('mf005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.mf005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf006" label="供应商代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf006')"/>
      <el-table-column prop="mf007" label="ABC标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf007')"/>
      <el-table-column prop="mf008" label="供应商简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf008')"/>
      <el-table-column prop="mf009" label="供应商名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf009')"/>
      <el-table-column prop="mf010" label="企业法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf010')"/>
      <el-table-column prop="mf011" label="营业执照" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf011')"/>
      <el-table-column prop="mf012" label="税号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf012')"/>
      <el-table-column prop="mf013" label="税别" align="center" v-if="columns.showColumn('mf013')">
        <template #default="scope">
          <dict-tag :options=" options.sys_tax_type " :value="scope.row.mf013"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf014" label="主营业务" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf014')"/>
      <el-table-column prop="mf015" label="采购组" align="center" v-if="columns.showColumn('mf015')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.mf015"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf016" label="交易币种" align="center" v-if="columns.showColumn('mf016')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.mf016"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf017" label="付款条件" align="center" v-if="columns.showColumn('mf017')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_terms " :value="scope.row.mf017"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf018" label="付款方式" align="center" v-if="columns.showColumn('mf018')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_method " :value="scope.row.mf018"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf019" label="统驭科目" align="center" v-if="columns.showColumn('mf019')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mitkz_list " :value="scope.row.mf019"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf020" label="贸易条件" align="center" v-if="columns.showColumn('mf020')">
        <template #default="scope">
          <dict-tag :options=" options.sys_terms_trade " :value="scope.row.mf020"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf021" label="装运条件" align="center" v-if="columns.showColumn('mf021')">
        <template #default="scope">
          <dict-tag :options=" options.sys_cond_shipment " :value="scope.row.mf021"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf022" label="运输方式" align="center" v-if="columns.showColumn('mf022')">
        <template #default="scope">
          <dict-tag :options=" options.sys_transport_method " :value="scope.row.mf022"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf023" label="供应商等级" align="center" v-if="columns.showColumn('mf023')">
        <template #default="scope">
          <dict-tag :options=" options.sys_grade_list " :value="scope.row.mf023"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf024" label="供应商信用" align="center" v-if="columns.showColumn('mf024')">
        <template #default="scope">
          <dict-tag :options=" options.sys_credit_list " :value="scope.row.mf024"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf025" label="客户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf025')"/>
      <el-table-column prop="mf026" label="首次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('mf026')"/>
      <el-table-column prop="mf027" label="末次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('mf027')"/>
      <el-table-column prop="mf028" label="国家地区" align="center" v-if="columns.showColumn('mf028')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.mf028"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf029" label="州省" align="center" v-if="columns.showColumn('mf029')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_state " :value="scope.row.mf029"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf030" label="市" align="center" v-if="columns.showColumn('mf030')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.mf030"  />
        </template>
      </el-table-column>
      <el-table-column prop="mf031" label="县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf031')"/>
      <el-table-column prop="mf032" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf032')"/>
      <el-table-column prop="mf033" label="地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf033')"/>
      <el-table-column prop="mf034" label="地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf034')"/>
      <el-table-column prop="mf035" label="邮政编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf035')"/>
      <el-table-column prop="mf036" label="地址号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf036')"/>
      <el-table-column prop="mf037" label="联系人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf037')"/>
      <el-table-column prop="mf038" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf038')"/>
      <el-table-column prop="mf039" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf039')"/>
      <el-table-column prop="mf040" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf040')"/>
      <el-table-column prop="mf041" label="手机" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf041')"/>
      <el-table-column prop="mf042" label="帐户组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf042')"/>
      <el-table-column prop="mf043" label="营业执照附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf043')"/>
      <el-table-column prop="mf044" label="其它附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mf044')"/>
      <el-table-column prop="mf045" label="交易冻结" align="center" v-if="columns.showColumn('mf045')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.mf045"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:supplier:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:supplier:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改供应商对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="mf002">
              <el-input   v-model="form.mf002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="购买组织" prop="mf003">
              <el-select filterable clearable   v-model="form.mf003"  :placeholder="$t('btn.selectPrefix')+'购买组织'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="行业类别" prop="mf004">
              <el-select filterable clearable   v-model="form.mf004"  :placeholder="$t('btn.selectPrefix')+'行业类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="企业性质" prop="mf005">
              <el-select filterable clearable   v-model="form.mf005"  :placeholder="$t('btn.selectPrefix')+'企业性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_nature_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商代码" prop="mf006">
              <el-input   v-model="form.mf006" :placeholder="$t('btn.enterPrefix')+'供应商代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ABC标识" prop="mf007">
              <el-input   v-model="form.mf007" :placeholder="$t('btn.enterPrefix')+'ABC标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商简称" prop="mf008">
              <el-input   v-model="form.mf008" :placeholder="$t('btn.enterPrefix')+'供应商简称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商名称" prop="mf009">
              <el-input   v-model="form.mf009" :placeholder="$t('btn.enterPrefix')+'供应商名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业法人" prop="mf010">
              <el-input   v-model="form.mf010" :placeholder="$t('btn.enterPrefix')+'企业法人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="营业执照" prop="mf011">
              <el-input   v-model="form.mf011" :placeholder="$t('btn.enterPrefix')+'营业执照'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税号" prop="mf012">
              <el-input   v-model="form.mf012" :placeholder="$t('btn.enterPrefix')+'税号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税别" prop="mf013">
              <el-select filterable clearable   v-model="form.mf013"  :placeholder="$t('btn.selectPrefix')+'税别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_tax_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="主营业务" prop="mf014">
              <el-input   v-model="form.mf014" :placeholder="$t('btn.enterPrefix')+'主营业务'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组" prop="mf015">
              <el-select filterable clearable   v-model="form.mf015"  :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="交易币种" prop="mf016">
              <el-select filterable clearable   v-model="form.mf016"  :placeholder="$t('btn.selectPrefix')+'交易币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款条件" prop="mf017">
              <el-select filterable clearable   v-model="form.mf017"  :placeholder="$t('btn.selectPrefix')+'付款条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_terms" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款方式" prop="mf018">
              <el-select filterable clearable   v-model="form.mf018"  :placeholder="$t('btn.selectPrefix')+'付款方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="统驭科目" prop="mf019">
              <el-select filterable clearable   v-model="form.mf019"  :placeholder="$t('btn.selectPrefix')+'统驭科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_mitkz_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="贸易条件" prop="mf020">
              <el-select filterable clearable   v-model="form.mf020"  :placeholder="$t('btn.selectPrefix')+'贸易条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_terms_trade" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="装运条件" prop="mf021">
              <el-select filterable clearable   v-model="form.mf021"  :placeholder="$t('btn.selectPrefix')+'装运条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_cond_shipment" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="运输方式" prop="mf022">
              <el-select filterable clearable   v-model="form.mf022"  :placeholder="$t('btn.selectPrefix')+'运输方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_transport_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商等级" prop="mf023">
              <el-select filterable clearable   v-model="form.mf023"  :placeholder="$t('btn.selectPrefix')+'供应商等级'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_grade_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商信用" prop="mf024">
              <el-select filterable clearable   v-model="form.mf024"  :placeholder="$t('btn.selectPrefix')+'供应商信用'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_credit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户" prop="mf025">
              <el-input   v-model="form.mf025" :placeholder="$t('btn.enterPrefix')+'客户'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="首次交易" prop="mf026">
              <el-date-picker v-model="form.mf026" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="末次交易" prop="mf027">
              <el-date-picker v-model="form.mf027" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家地区" prop="mf028">
              <el-select filterable clearable   v-model="form.mf028"  :placeholder="$t('btn.selectPrefix')+'国家地区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_country" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="州省" prop="mf029">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" 
              :loading="loading" v-model="form.mf029"  :placeholder="$t('btn.selectPrefix')+'州省'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="市" prop="mf030">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" 
              :loading="loading" v-model="form.mf030"  :placeholder="$t('btn.selectPrefix')+'市'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="县" prop="mf031">
              <el-input   v-model="form.mf031" :placeholder="$t('btn.enterPrefix')+'县'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="mf032">
              <el-input   v-model="form.mf032" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')"  show-word-limit   maxlength="400"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="地址1" prop="mf033">
              <el-input type="textarea" v-model="form.mf033" :placeholder="$t('btn.enterPrefix')+'地址1'+$t('btn.enterSuffix')" show-word-limit maxlength="800"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="地址2" prop="mf034">
              <el-input type="textarea" v-model="form.mf034" :placeholder="$t('btn.enterPrefix')+'地址2'+$t('btn.enterSuffix')" show-word-limit maxlength="1200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮政编码" prop="mf035">
              <el-input   v-model="form.mf035" :placeholder="$t('btn.enterPrefix')+'邮政编码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址号码" prop="mf036">
              <el-input   v-model="form.mf036" :placeholder="$t('btn.enterPrefix')+'地址号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联系人" prop="mf037">
              <el-input   v-model="form.mf037" :placeholder="$t('btn.enterPrefix')+'联系人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮件" prop="mf038">
              <el-input   v-model="form.mf038" :placeholder="$t('btn.enterPrefix')+'邮件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="mf039">
              <el-input   v-model="form.mf039" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="mf040">
              <el-input   v-model="form.mf040" :placeholder="$t('btn.enterPrefix')+'传真'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手机" prop="mf041">
              <el-input   v-model="form.mf041" :placeholder="$t('btn.enterPrefix')+'手机'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="帐户组" prop="mf042">
              <el-input   v-model="form.mf042" :placeholder="$t('btn.enterPrefix')+'帐户组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="营业执照附件" prop="mf043">
              <UploadFile v-model="form.mf043" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="其它附件" prop="mf044">
              <UploadFile v-model="form.mf044" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="交易冻结" prop="mf045">
              <el-radio-group v-model="form.mf045">
                <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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
import { listMmSupplier,
 addMmSupplier, delMmSupplier, 
 updateMmSupplier,getMmSupplier, 
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
  sort: 'Mf006',
  sortType: 'asc',
  //是否查询（1是）
  mf003: undefined,
  //是否查询（1是）
  mf004: undefined,
  //是否查询（1是）
  mf005: undefined,
  //是否查询（1是）
  mf006: undefined,
  //是否查询（1是）
  mf008: undefined,
  //是否查询（1是）
  mf009: undefined,
  //是否查询（1是）
  mf013: undefined,
  //是否查询（1是）
  mf015: undefined,
  //是否查询（1是）
  mf016: undefined,
  //是否查询（1是）
  mf017: undefined,
  //是否查询（1是）
  mf018: undefined,
  //是否查询（1是）
  mf019: undefined,
  //是否查询（1是）
  mf020: undefined,
  //是否查询（1是）
  mf023: undefined,
  //是否查询（1是）
  mf028: undefined,
   //是否查询（1是）
  mf045: -1,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mf002', label: '集团' },
  { visible: true, prop: 'mf003', label: '购买组织' },
  { visible: true, prop: 'mf004', label: '行业类别' },
  { visible: true, prop: 'mf005', label: '企业性质' },
  { visible: true, prop: 'mf006', label: '供应商代码' },
  { visible: true, prop: 'mf007', label: 'ABC标识' },
  { visible: true, prop: 'mf008', label: '供应商简称' },
  { visible: false, prop: 'mf009', label: '供应商名称' },
  { visible: false, prop: 'mf010', label: '企业法人' },
  { visible: false, prop: 'mf011', label: '营业执照' },
  { visible: false, prop: 'mf012', label: '税号' },
  { visible: false, prop: 'mf013', label: '税别' },
  { visible: false, prop: 'mf014', label: '主营业务' },
  { visible: false, prop: 'mf015', label: '采购组' },
  { visible: false, prop: 'mf016', label: '交易币种' },
  { visible: false, prop: 'mf017', label: '付款条件' },
  { visible: false, prop: 'mf018', label: '付款方式' },
  { visible: false, prop: 'mf019', label: '统驭科目' },
  { visible: false, prop: 'mf020', label: '贸易条件' },
  { visible: false, prop: 'mf021', label: '装运条件' },
  { visible: false, prop: 'mf022', label: '运输方式' },
  { visible: false, prop: 'mf023', label: '供应商等级' },
  { visible: false, prop: 'mf024', label: '供应商信用' },
  { visible: false, prop: 'mf025', label: '客户' },
  { visible: false, prop: 'mf026', label: '首次交易' },
  { visible: false, prop: 'mf027', label: '末次交易' },
  { visible: false, prop: 'mf028', label: '国家地区' },
  { visible: false, prop: 'mf029', label: '州省' },
  { visible: false, prop: 'mf030', label: '市' },
  { visible: false, prop: 'mf031', label: '县' },
  { visible: false, prop: 'mf032', label: '地址' },
  { visible: false, prop: 'mf033', label: '地址1' },
  { visible: false, prop: 'mf034', label: '地址2' },
  { visible: false, prop: 'mf035', label: '邮政编码' },
  { visible: false, prop: 'mf036', label: '地址号码' },
  { visible: false, prop: 'mf037', label: '联系人' },
  { visible: false, prop: 'mf038', label: '邮件' },
  { visible: false, prop: 'mf039', label: '电话' },
  { visible: false, prop: 'mf040', label: '传真' },
  { visible: false, prop: 'mf041', label: '手机' },
  { visible: false, prop: 'mf042', label: '帐户组' },
  { visible: false, prop: 'mf043', label: '营业执照附件' },
  { visible: false, prop: 'mf044', label: '其它附件' },
  { visible: false, prop: 'mf045', label: '交易冻结' },
  { visible: false, prop: 'remark', label: '备注说明' },
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
  { dictType: "sql_plant_list" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_nature_list" },
  { dictType: "sys_tax_type" },
  { dictType: "sys_pur_group" },
  { dictType: "sql_global_currency" },
  { dictType: "sys_payment_terms" },
  { dictType: "sys_payment_method" },
  { dictType: "sql_mitkz_list" },
  { dictType: "sys_terms_trade" },
  { dictType: "sys_cond_shipment" },
  { dictType: "sys_transport_method" },
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
//API获取从供应商/mm_supplier表记录数据
function getList(){
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
    mf002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mf003: [{ required: true, message: "购买组织"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mf004: [{ required: true, message: "行业类别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mf005: [{ required: true, message: "企业性质"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mf006: [{ required: true, message: "供应商代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mf045: [{ required: true, message: "交易冻结"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 购买组织 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 行业类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ind_type: [],
    // 企业性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_nature_list: [],
    // 税别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_tax_type: [],
    // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_group: [],
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
    // 运输方式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_transport_method: [],
    // 供应商等级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_grade_list: [],
    // 供应商信用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_credit_list: [],
    // 国家地区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_country: [],
    // 州省 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_state: [],
    // 市 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_city: [],
    // 交易冻结 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    mf002: null,
    mf003: [],
    mf004: [],
    mf005: [],
    mf006: null,
    mf007: null,
    mf008: null,
    mf009: null,
    mf010: null,
    mf011: null,
    mf012: null,
    mf013: [],
    mf014: null,
    mf015: [],
    mf016: [],
    mf017: [],
    mf018: [],
    mf019: [],
    mf020: [],
    mf021: [],
    mf022: [],
    mf023: [],
    mf024: [],
    mf025: null,
    mf026: null,
    mf027: null,
    mf028: [],
    mf029: [],
    mf030: [],
    mf031: null,
    mf032: null,
    mf033: null,
    mf034: null,
    mf035: null,
    mf036: null,
    mf037: null,
    mf038: null,
    mf039: null,
    mf040: null,
    mf041: null,
    mf042: null,
    mf043: null,
    mf044: null,
    mf045: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'供应商'
  opertype.value = 1
  form.value.mf003= []
  form.value.mf004= []
  form.value.mf005= []
  form.value.mf013= []
  form.value.mf015= []
  form.value.mf016= []
  form.value.mf017= []
  form.value.mf018= []
  form.value.mf019= []
  form.value.mf020= []
  form.value.mf021= []
  form.value.mf022= []
  form.value.mf023= []
  form.value.mf024= []
  form.value.mf026= new Date()
  form.value.mf027= new Date()
  form.value.mf028= []
  form.value.mf029= []
  form.value.mf030= []
  form.value.mf045= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getMmSupplier(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '供应商'
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
  const Ids = row.id || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<供应商.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
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