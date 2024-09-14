<!--
 * @Descripttion: 销售商/mm_vendor
 * @Version: 0.24.620.18453
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 11:38:56
 * @column：69
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="购买组织" prop="mg003">
        <el-select filterable clearable   v-model="queryParams.mg003" :placeholder="$t('btn.selectSearchPrefix')+'购买组织'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="行业类别" prop="mg004">
        <el-select filterable clearable   v-model="queryParams.mg004" :placeholder="$t('btn.selectSearchPrefix')+'行业类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="企业性质" prop="mg005">
        <el-select filterable clearable   v-model="queryParams.mg005" :placeholder="$t('btn.selectSearchPrefix')+'企业性质'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商代码" prop="mg006">
        <el-input v-model="queryParams.mg006" :placeholder="$t('btn.enterSearchPrefix')+'供应商代码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="供应商简称" prop="mg008">
        <el-input v-model="queryParams.mg008" :placeholder="$t('btn.enterSearchPrefix')+'供应商简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="供应商名称" prop="mg010">
        <el-input v-model="queryParams.mg010" :placeholder="$t('btn.enterSearchPrefix')+'供应商名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="税别" prop="mg015">
        <el-select filterable clearable   v-model="queryParams.mg015" :placeholder="$t('btn.selectSearchPrefix')+'税别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_tax_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购组" prop="mg017">
        <el-select filterable clearable   v-model="queryParams.mg017" :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="交易币种" prop="mg019">
        <el-select filterable clearable   v-model="queryParams.mg019" :placeholder="$t('btn.selectSearchPrefix')+'交易币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款条件" prop="mg020">
        <el-select filterable clearable   v-model="queryParams.mg020" :placeholder="$t('btn.selectSearchPrefix')+'付款条件'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_payment_terms " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款方式" prop="mg021">
        <el-select filterable clearable   v-model="queryParams.mg021" :placeholder="$t('btn.selectSearchPrefix')+'付款方式'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_payment_method " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="统驭科目" prop="mg022">
        <el-select filterable clearable   v-model="queryParams.mg022" :placeholder="$t('btn.selectSearchPrefix')+'统驭科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_mitkz_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="贸易条件" prop="mg023">
        <el-select filterable clearable   v-model="queryParams.mg023" :placeholder="$t('btn.selectSearchPrefix')+'贸易条件'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_terms_trade " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商等级" prop="mg026">
        <el-select filterable clearable   v-model="queryParams.mg026" :placeholder="$t('btn.selectSearchPrefix')+'供应商等级'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_grade_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="国家地区" prop="mg031">
        <el-select filterable clearable   v-model="queryParams.mg031" :placeholder="$t('btn.selectSearchPrefix')+'国家地区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="交易冻结" prop="mg051">
        <el-radio-group v-model="queryParams.mg051">
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
        <el-button class="btn-add" v-hasPermi="['mm:vendor:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:vendor:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:vendor:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:vendor:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/MmVendor/importTemplate"
                  importUrl="/Logistics/MmVendor/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:vendor:export']">
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
      <el-table-column prop="mg002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg002')"/>
      <el-table-column prop="mg003" label="购买组织" align="center" v-if="columns.showColumn('mg003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mg003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg004" label="行业类别" align="center" v-if="columns.showColumn('mg004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mg004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg005" label="企业性质" align="center" v-if="columns.showColumn('mg005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.mg005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg006" label="供应商代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg006')"/>
      <el-table-column prop="mg007" label="ABC标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg007')"/>
      <el-table-column prop="mg008" label="供应商简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg008')"/>
      <el-table-column prop="mg010" label="供应商名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg010')"/>
      <el-table-column prop="mg012" label="企业法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg012')"/>
      <el-table-column prop="mg013" label="营业执照" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg013')"/>
      <el-table-column prop="mg014" label="税号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg014')"/>
      <el-table-column prop="mg015" label="税别" align="center" v-if="columns.showColumn('mg015')">
        <template #default="scope">
          <dict-tag :options=" options.sys_tax_type " :value="scope.row.mg015"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg016" label="主营业务" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg016')"/>
      <el-table-column prop="mg017" label="采购组" align="center" v-if="columns.showColumn('mg017')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.mg017"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg019" label="交易币种" align="center" v-if="columns.showColumn('mg019')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.mg019"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg020" label="付款条件" align="center" v-if="columns.showColumn('mg020')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_terms " :value="scope.row.mg020"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg021" label="付款方式" align="center" v-if="columns.showColumn('mg021')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_method " :value="scope.row.mg021"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg022" label="统驭科目" align="center" v-if="columns.showColumn('mg022')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mitkz_list " :value="scope.row.mg022"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg023" label="贸易条件" align="center" v-if="columns.showColumn('mg023')">
        <template #default="scope">
          <dict-tag :options=" options.sys_terms_trade " :value="scope.row.mg023"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg024" label="装运条件" align="center" v-if="columns.showColumn('mg024')">
        <template #default="scope">
          <dict-tag :options=" options.sys_cond_shipment " :value="scope.row.mg024"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg025" label="运输方式" align="center" v-if="columns.showColumn('mg025')">
        <template #default="scope">
          <dict-tag :options=" options.sys_transport_method " :value="scope.row.mg025"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg026" label="供应商等级" align="center" v-if="columns.showColumn('mg026')">
        <template #default="scope">
          <dict-tag :options=" options.sys_grade_list " :value="scope.row.mg026"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg027" label="供应商信用" align="center" v-if="columns.showColumn('mg027')">
        <template #default="scope">
          <dict-tag :options=" options.sys_credit_list " :value="scope.row.mg027"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg028" label="客户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg028')"/>
      <el-table-column prop="mg029" label="首次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('mg029')"/>
      <el-table-column prop="mg030" label="末次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('mg030')"/>
      <el-table-column prop="mg031" label="国家地区" align="center" v-if="columns.showColumn('mg031')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.mg031"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg032" label="州省" align="center" v-if="columns.showColumn('mg032')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_state " :value="scope.row.mg032"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg033" label="市" align="center" v-if="columns.showColumn('mg033')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.mg033"  />
        </template>
      </el-table-column>
      <el-table-column prop="mg034" label="县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg034')"/>
      <el-table-column prop="mg035" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg035')"/>
      <el-table-column prop="mg037" label="地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg037')"/>
      <el-table-column prop="mg039" label="地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg039')"/>
      <el-table-column prop="mg041" label="邮政编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg041')"/>
      <el-table-column prop="mg042" label="地址号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg042')"/>
      <el-table-column prop="mg043" label="联系人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg043')"/>
      <el-table-column prop="mg044" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg044')"/>
      <el-table-column prop="mg045" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg045')"/>
      <el-table-column prop="mg046" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg046')"/>
      <el-table-column prop="mg047" label="手机" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg047')"/>
      <el-table-column prop="mg048" label="帐户组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg048')"/>
      <el-table-column prop="mg049" label="营业执照附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg049')"/>
      <el-table-column prop="mg050" label="其它附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mg050')"/>
      <el-table-column prop="mg051" label="交易冻结" align="center" v-if="columns.showColumn('mg051')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.mg051"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:vendor:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:vendor:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改销售商对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="mg002">
              <el-input   v-model="form.mg002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="购买组织" prop="mg003">
              <el-select filterable clearable   v-model="form.mg003"  :placeholder="$t('btn.selectPrefix')+'购买组织'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="行业类别" prop="mg004">
              <el-select filterable clearable   v-model="form.mg004"  :placeholder="$t('btn.selectPrefix')+'行业类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="企业性质" prop="mg005">
              <el-select filterable clearable   v-model="form.mg005"  :placeholder="$t('btn.selectPrefix')+'企业性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_nature_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商代码" prop="mg006">
              <el-input   v-model="form.mg006" :placeholder="$t('btn.enterPrefix')+'供应商代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ABC标识" prop="mg007">
              <el-input   v-model="form.mg007" :placeholder="$t('btn.enterPrefix')+'ABC标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商简称" prop="mg008">
              <el-input   v-model="form.mg008" :placeholder="$t('btn.enterPrefix')+'供应商简称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商名称" prop="mg010">
              <el-input   v-model="form.mg010" :placeholder="$t('btn.enterPrefix')+'供应商名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业法人" prop="mg012">
              <el-input   v-model="form.mg012" :placeholder="$t('btn.enterPrefix')+'企业法人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="营业执照" prop="mg013">
              <el-input   v-model="form.mg013" :placeholder="$t('btn.enterPrefix')+'营业执照'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税号" prop="mg014">
              <el-input   v-model="form.mg014" :placeholder="$t('btn.enterPrefix')+'税号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税别" prop="mg015">
              <el-select filterable clearable   v-model="form.mg015"  :placeholder="$t('btn.selectPrefix')+'税别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_tax_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="主营业务" prop="mg016">
              <el-input   v-model="form.mg016" :placeholder="$t('btn.enterPrefix')+'主营业务'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组" prop="mg017">
              <el-select filterable clearable   v-model="form.mg017"  :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="交易币种" prop="mg019">
              <el-select filterable clearable   v-model="form.mg019"  :placeholder="$t('btn.selectPrefix')+'交易币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款条件" prop="mg020">
              <el-select filterable clearable   v-model="form.mg020"  :placeholder="$t('btn.selectPrefix')+'付款条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_terms" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款方式" prop="mg021">
              <el-select filterable clearable   v-model="form.mg021"  :placeholder="$t('btn.selectPrefix')+'付款方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="统驭科目" prop="mg022">
              <el-select filterable clearable   v-model="form.mg022"  :placeholder="$t('btn.selectPrefix')+'统驭科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_mitkz_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="贸易条件" prop="mg023">
              <el-select filterable clearable   v-model="form.mg023"  :placeholder="$t('btn.selectPrefix')+'贸易条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_terms_trade" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="装运条件" prop="mg024">
              <el-select filterable clearable   v-model="form.mg024"  :placeholder="$t('btn.selectPrefix')+'装运条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_cond_shipment" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="运输方式" prop="mg025">
              <el-select filterable clearable   v-model="form.mg025"  :placeholder="$t('btn.selectPrefix')+'运输方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_transport_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商等级" prop="mg026">
              <el-select filterable clearable   v-model="form.mg026"  :placeholder="$t('btn.selectPrefix')+'供应商等级'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_grade_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商信用" prop="mg027">
              <el-select filterable clearable   v-model="form.mg027"  :placeholder="$t('btn.selectPrefix')+'供应商信用'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_credit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户" prop="mg028">
              <el-input   v-model="form.mg028" :placeholder="$t('btn.enterPrefix')+'客户'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="首次交易" prop="mg029">
              <el-date-picker v-model="form.mg029" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="末次交易" prop="mg030">
              <el-date-picker v-model="form.mg030" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家地区" prop="mg031">
              <el-select filterable clearable   v-model="form.mg031"  :placeholder="$t('btn.selectPrefix')+'国家地区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_country" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="州省" prop="mg032">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" 
              :loading="loading" v-model="form.mg032"  :placeholder="$t('btn.selectPrefix')+'州省'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="市" prop="mg033">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" 
              :loading="loading" v-model="form.mg033"  :placeholder="$t('btn.selectPrefix')+'市'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="县" prop="mg034">
              <el-input   v-model="form.mg034" :placeholder="$t('btn.enterPrefix')+'县'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="mg035">
              <el-input   v-model="form.mg035" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')"  show-word-limit   maxlength="400"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="地址1" prop="mg037">
              <el-input type="textarea" v-model="form.mg037" :placeholder="$t('btn.enterPrefix')+'地址1'+$t('btn.enterSuffix')" show-word-limit maxlength="800"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="地址2" prop="mg039">
              <el-input type="textarea" v-model="form.mg039" :placeholder="$t('btn.enterPrefix')+'地址2'+$t('btn.enterSuffix')" show-word-limit maxlength="1200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮政编码" prop="mg041">
              <el-input   v-model="form.mg041" :placeholder="$t('btn.enterPrefix')+'邮政编码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址号码" prop="mg042">
              <el-input   v-model="form.mg042" :placeholder="$t('btn.enterPrefix')+'地址号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联系人" prop="mg043">
              <el-input   v-model="form.mg043" :placeholder="$t('btn.enterPrefix')+'联系人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮件" prop="mg044">
              <el-input   v-model="form.mg044" :placeholder="$t('btn.enterPrefix')+'邮件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="mg045">
              <el-input   v-model="form.mg045" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="mg046">
              <el-input   v-model="form.mg046" :placeholder="$t('btn.enterPrefix')+'传真'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手机" prop="mg047">
              <el-input   v-model="form.mg047" :placeholder="$t('btn.enterPrefix')+'手机'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="帐户组" prop="mg048">
              <el-input   v-model="form.mg048" :placeholder="$t('btn.enterPrefix')+'帐户组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="营业执照附件" prop="mg049">
              <UploadFile v-model="form.mg049" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="其它附件" prop="mg050">
              <UploadFile v-model="form.mg050" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="交易冻结" prop="mg051">
              <el-radio-group v-model="form.mg051">
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

<script setup name="mmvendor">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listMmVendor,
 addMmVendor, delMmVendor, 
 updateMmVendor,getMmVendor, 
 } 
from '@/api/logistics/mmvendor.js'
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
  sort: 'Mg006',
  sortType: 'asc',
  //是否查询（1是）
  mg003: undefined,
  //是否查询（1是）
  mg004: undefined,
  //是否查询（1是）
  mg005: undefined,
  //是否查询（1是）
  mg006: undefined,
  //是否查询（1是）
  mg008: undefined,
  //是否查询（1是）
  mg010: undefined,
  //是否查询（1是）
  mg015: undefined,
  //是否查询（1是）
  mg017: undefined,
  //是否查询（1是）
  mg019: undefined,
  //是否查询（1是）
  mg020: undefined,
  //是否查询（1是）
  mg021: undefined,
  //是否查询（1是）
  mg022: undefined,
  //是否查询（1是）
  mg023: undefined,
  //是否查询（1是）
  mg026: undefined,
  //是否查询（1是）
  mg031: undefined,
   //是否查询（1是）
  mg051: -1,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mg002', label: '集团' },
  { visible: true, prop: 'mg003', label: '购买组织' },
  { visible: true, prop: 'mg004', label: '行业类别' },
  { visible: true, prop: 'mg005', label: '企业性质' },
  { visible: true, prop: 'mg006', label: '供应商代码' },
  { visible: true, prop: 'mg007', label: 'ABC标识' },
  { visible: true, prop: 'mg008', label: '供应商简称' },
  { visible: false, prop: 'mg010', label: '供应商名称' },
  { visible: false, prop: 'mg012', label: '企业法人' },
  { visible: false, prop: 'mg013', label: '营业执照' },
  { visible: false, prop: 'mg014', label: '税号' },
  { visible: false, prop: 'mg015', label: '税别' },
  { visible: false, prop: 'mg016', label: '主营业务' },
  { visible: false, prop: 'mg017', label: '采购组' },
  { visible: false, prop: 'mg019', label: '交易币种' },
  { visible: false, prop: 'mg020', label: '付款条件' },
  { visible: false, prop: 'mg021', label: '付款方式' },
  { visible: false, prop: 'mg022', label: '统驭科目' },
  { visible: false, prop: 'mg023', label: '贸易条件' },
  { visible: false, prop: 'mg024', label: '装运条件' },
  { visible: false, prop: 'mg025', label: '运输方式' },
  { visible: false, prop: 'mg026', label: '供应商等级' },
  { visible: false, prop: 'mg027', label: '供应商信用' },
  { visible: false, prop: 'mg028', label: '客户' },
  { visible: false, prop: 'mg029', label: '首次交易' },
  { visible: false, prop: 'mg030', label: '末次交易' },
  { visible: false, prop: 'mg031', label: '国家地区' },
  { visible: false, prop: 'mg032', label: '州省' },
  { visible: false, prop: 'mg033', label: '市' },
  { visible: false, prop: 'mg034', label: '县' },
  { visible: false, prop: 'mg035', label: '地址' },
  { visible: false, prop: 'mg037', label: '地址1' },
  { visible: false, prop: 'mg039', label: '地址2' },
  { visible: false, prop: 'mg041', label: '邮政编码' },
  { visible: false, prop: 'mg042', label: '地址号码' },
  { visible: false, prop: 'mg043', label: '联系人' },
  { visible: false, prop: 'mg044', label: '邮件' },
  { visible: false, prop: 'mg045', label: '电话' },
  { visible: false, prop: 'mg046', label: '传真' },
  { visible: false, prop: 'mg047', label: '手机' },
  { visible: false, prop: 'mg048', label: '帐户组' },
  { visible: false, prop: 'mg049', label: '营业执照附件' },
  { visible: false, prop: 'mg050', label: '其它附件' },
  { visible: false, prop: 'mg051', label: '交易冻结' },
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
//API获取从销售商/mm_vendor表记录数据
function getList(){
  loading.value = true
  listMmVendor(queryParams).then(res => {
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
    mg002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mg003: [{ required: true, message: "购买组织"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mg004: [{ required: true, message: "行业类别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mg005: [{ required: true, message: "企业性质"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mg006: [{ required: true, message: "供应商代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mg051: [{ required: true, message: "交易冻结"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
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
    mg002: null,
    mg003: [],
    mg004: [],
    mg005: [],
    mg006: null,
    mg007: null,
    mg008: null,
    mg010: null,
    mg012: null,
    mg013: null,
    mg014: null,
    mg015: [],
    mg016: null,
    mg017: [],
    mg019: [],
    mg020: [],
    mg021: [],
    mg022: [],
    mg023: [],
    mg024: [],
    mg025: [],
    mg026: [],
    mg027: [],
    mg028: null,
    mg029: null,
    mg030: null,
    mg031: [],
    mg032: [],
    mg033: [],
    mg034: null,
    mg035: null,
    mg037: null,
    mg039: null,
    mg041: null,
    mg042: null,
    mg043: null,
    mg044: null,
    mg045: null,
    mg046: null,
    mg047: null,
    mg048: null,
    mg049: null,
    mg050: null,
    mg051: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'销售商'
  opertype.value = 1
  form.value.mg003= []
  form.value.mg004= []
  form.value.mg005= []
  form.value.mg015= []
  form.value.mg017= []
  form.value.mg019= []
  form.value.mg020= []
  form.value.mg021= []
  form.value.mg022= []
  form.value.mg023= []
  form.value.mg024= []
  form.value.mg025= []
  form.value.mg026= []
  form.value.mg027= []
  form.value.mg029= new Date()
  form.value.mg030= new Date()
  form.value.mg031= []
  form.value.mg032= []
  form.value.mg033= []
  form.value.mg051= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getMmVendor(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '销售商'
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
        updateMmVendor(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addMmVendor(form.value).then((res) => {
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
      return delMmVendor(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<销售商.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/MmVendor/export', { ...queryParams })
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