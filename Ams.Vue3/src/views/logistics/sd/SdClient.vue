<!--
 * @Descripttion: 客户/sd_client
 * @Version: 0.24.620.27469
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 15:53:14
 * @column：65
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="销售组织" prop="ma003">
        <el-select filterable clearable   v-model="queryParams.ma003" :placeholder="$t('btn.selectSearchPrefix')+'销售组织'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="行业类别" prop="ma004">
        <el-select filterable clearable   v-model="queryParams.ma004" :placeholder="$t('btn.selectSearchPrefix')+'行业类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="企业性质" prop="ma005">
        <el-select filterable clearable   v-model="queryParams.ma005" :placeholder="$t('btn.selectSearchPrefix')+'企业性质'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客户代码" prop="ma006">
        <el-input v-model="queryParams.ma006" :placeholder="$t('btn.enterSearchPrefix')+'客户代码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="客户简称" prop="ma007">
        <el-input v-model="queryParams.ma007" :placeholder="$t('btn.enterSearchPrefix')+'客户简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="客户名称" prop="ma008">
        <el-input v-model="queryParams.ma008" :placeholder="$t('btn.enterSearchPrefix')+'客户名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="交易币种" prop="ma014">
        <el-select filterable clearable   v-model="queryParams.ma014" :placeholder="$t('btn.selectSearchPrefix')+'交易币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="付款条件" prop="ma015">
        <el-select filterable clearable   v-model="queryParams.ma015" :placeholder="$t('btn.selectSearchPrefix')+'付款条件'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_payment_terms " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客户等级" prop="ma020">
        <el-select filterable clearable   v-model="queryParams.ma020" :placeholder="$t('btn.selectSearchPrefix')+'客户等级'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_grade_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商" prop="ma024">
        <el-input v-model="queryParams.ma024" :placeholder="$t('btn.enterSearchPrefix')+'供应商'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="国家地区" prop="ma025">
        <el-select filterable clearable   v-model="queryParams.ma025" :placeholder="$t('btn.selectSearchPrefix')+'国家地区'+$t('btn.selectSearchSuffix')">
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
        <el-button class="btn-add" v-hasPermi="['sd:client:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sd:client:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sd:client:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sd:client:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/SdClient/importTemplate"
                  importUrl="/Logistics/SdClient/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['sd:client:export']">
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
      <el-table-column prop="ma002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma002')"/>
      <el-table-column prop="ma003" label="销售组织" align="center" v-if="columns.showColumn('ma003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.ma003"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma004" label="行业类别" align="center" v-if="columns.showColumn('ma004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.ma004"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma005" label="企业性质" align="center" v-if="columns.showColumn('ma005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.ma005"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma006" label="客户代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma006')"/>
      <el-table-column prop="ma007" label="客户简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma007')"/>
      <el-table-column prop="ma008" label="客户名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma008')"/>
      <el-table-column prop="ma009" label="企业法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma009')"/>
      <el-table-column prop="ma010" label="税号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma010')"/>
      <el-table-column prop="ma011" label="营业执照" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma011')"/>
      <el-table-column prop="ma012" label="税别" align="center" v-if="columns.showColumn('ma012')">
        <template #default="scope">
          <dict-tag :options=" options.sys_tax_type " :value="scope.row.ma012"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma013" label="主营业务" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma013')"/>
      <el-table-column prop="ma014" label="交易币种" align="center" v-if="columns.showColumn('ma014')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.ma014"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma015" label="付款条件" align="center" v-if="columns.showColumn('ma015')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_terms " :value="scope.row.ma015"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma016" label="付款方式" align="center" v-if="columns.showColumn('ma016')">
        <template #default="scope">
          <dict-tag :options=" options.sys_payment_method " :value="scope.row.ma016"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma017" label="统驭科目" align="center" v-if="columns.showColumn('ma017')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mitkz_list " :value="scope.row.ma017"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma018" label="贸易条件" align="center" v-if="columns.showColumn('ma018')">
        <template #default="scope">
          <dict-tag :options=" options.sys_terms_trade " :value="scope.row.ma018"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma019" label="装运条件" align="center" v-if="columns.showColumn('ma019')">
        <template #default="scope">
          <dict-tag :options=" options.sys_cond_shipment " :value="scope.row.ma019"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma020" label="客户等级" align="center" v-if="columns.showColumn('ma020')">
        <template #default="scope">
          <dict-tag :options=" options.sys_grade_list " :value="scope.row.ma020"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma021" label="客户信用" align="center" v-if="columns.showColumn('ma021')">
        <template #default="scope">
          <dict-tag :options=" options.sys_credit_list " :value="scope.row.ma021"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma022" label="首次交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('ma022')"/>
      <el-table-column prop="ma023" label="最近交易" :show-overflow-tooltip="true"  v-if="columns.showColumn('ma023')"/>
      <el-table-column prop="ma024" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma024')"/>
      <el-table-column prop="ma025" label="国家地区" align="center" v-if="columns.showColumn('ma025')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.ma025"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma026" label="州省" align="center" v-if="columns.showColumn('ma026')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_state " :value="scope.row.ma026"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma027" label="市" align="center" v-if="columns.showColumn('ma027')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.ma027"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma028" label="县" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma028')"/>
      <el-table-column prop="ma029" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma029')"/>
      <el-table-column prop="ma030" label="地址1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma030')"/>
      <el-table-column prop="ma031" label="地址2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma031')"/>
      <el-table-column prop="ma032" label="邮政编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma032')"/>
      <el-table-column prop="ma033" label="地址号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma033')"/>
      <el-table-column prop="ma034" label="联系人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma034')"/>
      <el-table-column prop="ma035" label="电邮" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma035')"/>
      <el-table-column prop="ma036" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma036')"/>
      <el-table-column prop="ma037" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma037')"/>
      <el-table-column prop="ma038" label="手机" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma038')"/>
      <el-table-column prop="ma039" label="冻结标记" align="center" v-if="columns.showColumn('ma039')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.ma039"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma040" label="营业执照附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma040')"/>
      <el-table-column prop="ma041" label="其它附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma041')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['sd:client:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['sd:client:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改客户对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="ID" prop="id">
              <el-input   v-model.number="form.id" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')"  show-word-limit   maxlength="19"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团" prop="ma002">
              <el-input   v-model="form.ma002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售组织" prop="ma003">
              <el-select filterable clearable   v-model="form.ma003"  :placeholder="$t('btn.selectPrefix')+'销售组织'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="行业类别" prop="ma004">
              <el-select filterable clearable   v-model="form.ma004"  :placeholder="$t('btn.selectPrefix')+'行业类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="企业性质" prop="ma005">
              <el-select filterable clearable   v-model="form.ma005"  :placeholder="$t('btn.selectPrefix')+'企业性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_nature_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户代码" prop="ma006">
              <el-input   v-model="form.ma006" :placeholder="$t('btn.enterPrefix')+'客户代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户简称" prop="ma007">
              <el-input   v-model="form.ma007" :placeholder="$t('btn.enterPrefix')+'客户简称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户名称" prop="ma008">
              <el-input   v-model="form.ma008" :placeholder="$t('btn.enterPrefix')+'客户名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="企业法人" prop="ma009">
              <el-input   v-model="form.ma009" :placeholder="$t('btn.enterPrefix')+'企业法人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税号" prop="ma010">
              <el-input   v-model="form.ma010" :placeholder="$t('btn.enterPrefix')+'税号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="营业执照" prop="ma011">
              <el-input   v-model="form.ma011" :placeholder="$t('btn.enterPrefix')+'营业执照'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税别" prop="ma012">
              <el-select filterable clearable   v-model="form.ma012"  :placeholder="$t('btn.selectPrefix')+'税别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_tax_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="主营业务" prop="ma013">
              <el-input   v-model="form.ma013" :placeholder="$t('btn.enterPrefix')+'主营业务'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交易币种" prop="ma014">
              <el-select filterable clearable   v-model="form.ma014"  :placeholder="$t('btn.selectPrefix')+'交易币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款条件" prop="ma015">
              <el-select filterable clearable   v-model="form.ma015"  :placeholder="$t('btn.selectPrefix')+'付款条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_terms" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="付款方式" prop="ma016">
              <el-select filterable clearable   v-model="form.ma016"  :placeholder="$t('btn.selectPrefix')+'付款方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_payment_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="统驭科目" prop="ma017">
              <el-select filterable clearable   v-model="form.ma017"  :placeholder="$t('btn.selectPrefix')+'统驭科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_mitkz_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="贸易条件" prop="ma018">
              <el-select filterable clearable   v-model="form.ma018"  :placeholder="$t('btn.selectPrefix')+'贸易条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_terms_trade" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="装运条件" prop="ma019">
              <el-select filterable clearable   v-model="form.ma019"  :placeholder="$t('btn.selectPrefix')+'装运条件'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_cond_shipment" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户等级" prop="ma020">
              <el-select filterable clearable   v-model="form.ma020"  :placeholder="$t('btn.selectPrefix')+'客户等级'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_grade_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="客户信用" prop="ma021">
              <el-select filterable clearable   v-model="form.ma021"  :placeholder="$t('btn.selectPrefix')+'客户信用'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_credit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="首次交易" prop="ma022">
              <el-date-picker v-model="form.ma022" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最近交易" prop="ma023">
              <el-date-picker v-model="form.ma023" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商" prop="ma024">
              <el-input   v-model="form.ma024" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家地区" prop="ma025">
              <el-select filterable clearable   v-model="form.ma025"  :placeholder="$t('btn.selectPrefix')+'国家地区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_country" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="州省" prop="ma026">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" 
              :loading="loading" v-model="form.ma026"  :placeholder="$t('btn.selectPrefix')+'州省'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="市" prop="ma027">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" 
              :loading="loading" v-model="form.ma027"  :placeholder="$t('btn.selectPrefix')+'市'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="县" prop="ma028">
              <el-input   v-model="form.ma028" :placeholder="$t('btn.enterPrefix')+'县'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="ma029">
              <el-input   v-model="form.ma029" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址1" prop="ma030">
              <el-input   v-model="form.ma030" :placeholder="$t('btn.enterPrefix')+'地址1'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址2" prop="ma031">
              <el-input   v-model="form.ma031" :placeholder="$t('btn.enterPrefix')+'地址2'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮政编码" prop="ma032">
              <el-input   v-model="form.ma032" :placeholder="$t('btn.enterPrefix')+'邮政编码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址号码" prop="ma033">
              <el-input   v-model="form.ma033" :placeholder="$t('btn.enterPrefix')+'地址号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联系人" prop="ma034">
              <el-input   v-model="form.ma034" :placeholder="$t('btn.enterPrefix')+'联系人'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电邮" prop="ma035">
              <el-input   v-model="form.ma035" :placeholder="$t('btn.enterPrefix')+'电邮'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="ma036">
              <el-input   v-model="form.ma036" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="ma037">
              <el-input   v-model="form.ma037" :placeholder="$t('btn.enterPrefix')+'传真'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手机" prop="ma038">
              <el-input   v-model="form.ma038" :placeholder="$t('btn.enterPrefix')+'手机'+$t('btn.enterSuffix')"  show-word-limit   maxlength="160"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="冻结标记" prop="ma039">
              <el-radio-group v-model="form.ma039">
                <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="营业执照附件" prop="ma040">
              <UploadFile v-model="form.ma040" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="其它附件" prop="ma041">
              <UploadFile v-model="form.ma041" :data="{ uploadType: 1 }" />
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

<script setup name="sdclient">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listSdClient,
 addSdClient, delSdClient, 
 updateSdClient,getSdClient, 
 } 
from '@/api/logistics/sdclient.js'
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
  sort: 'Ma003',
  sortType: 'asc',
  //是否查询（1是）
  ma003: undefined,
  //是否查询（1是）
  ma004: undefined,
  //是否查询（1是）
  ma005: undefined,
  //是否查询（1是）
  ma006: undefined,
  //是否查询（1是）
  ma007: undefined,
  //是否查询（1是）
  ma008: undefined,
  //是否查询（1是）
  ma014: undefined,
  //是否查询（1是）
  ma015: undefined,
  //是否查询（1是）
  ma020: undefined,
  //是否查询（1是）
  ma024: undefined,
  //是否查询（1是）
  ma025: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'ma002', label: '集团' },
  { visible: true, prop: 'ma003', label: '销售组织' },
  { visible: true, prop: 'ma004', label: '行业类别' },
  { visible: true, prop: 'ma005', label: '企业性质' },
  { visible: true, prop: 'ma006', label: '客户代码' },
  { visible: true, prop: 'ma007', label: '客户简称' },
  { visible: true, prop: 'ma008', label: '客户名称' },
  { visible: false, prop: 'ma009', label: '企业法人' },
  { visible: false, prop: 'ma010', label: '税号' },
  { visible: false, prop: 'ma011', label: '营业执照' },
  { visible: false, prop: 'ma012', label: '税别' },
  { visible: false, prop: 'ma013', label: '主营业务' },
  { visible: false, prop: 'ma014', label: '交易币种' },
  { visible: false, prop: 'ma015', label: '付款条件' },
  { visible: false, prop: 'ma016', label: '付款方式' },
  { visible: false, prop: 'ma017', label: '统驭科目' },
  { visible: false, prop: 'ma018', label: '贸易条件' },
  { visible: false, prop: 'ma019', label: '装运条件' },
  { visible: false, prop: 'ma020', label: '客户等级' },
  { visible: false, prop: 'ma021', label: '客户信用' },
  { visible: false, prop: 'ma022', label: '首次交易' },
  { visible: false, prop: 'ma023', label: '最近交易' },
  { visible: false, prop: 'ma024', label: '供应商' },
  { visible: false, prop: 'ma025', label: '国家地区' },
  { visible: false, prop: 'ma026', label: '州省' },
  { visible: false, prop: 'ma027', label: '市' },
  { visible: false, prop: 'ma028', label: '县' },
  { visible: false, prop: 'ma029', label: '地址' },
  { visible: false, prop: 'ma030', label: '地址1' },
  { visible: false, prop: 'ma031', label: '地址2' },
  { visible: false, prop: 'ma032', label: '邮政编码' },
  { visible: false, prop: 'ma033', label: '地址号码' },
  { visible: false, prop: 'ma034', label: '联系人' },
  { visible: false, prop: 'ma035', label: '电邮' },
  { visible: false, prop: 'ma036', label: '电话' },
  { visible: false, prop: 'ma037', label: '传真' },
  { visible: false, prop: 'ma038', label: '手机' },
  { visible: false, prop: 'ma039', label: '冻结标记' },
  { visible: false, prop: 'ma040', label: '营业执照附件' },
  { visible: false, prop: 'ma041', label: '其它附件' },
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
//API获取从客户/sd_client表记录数据
function getList(){
  loading.value = true
  listSdClient(queryParams).then(res => {
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
    id: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma003: [{ required: true, message: "销售组织"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma004: [{ required: true, message: "行业类别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma005: [{ required: true, message: "企业性质"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma006: [{ required: true, message: "客户代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma039: [{ required: true, message: "冻结标记"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
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
    id: 0,
    ma002: null,
    ma003: [],
    ma004: [],
    ma005: [],
    ma006: null,
    ma007: null,
    ma008: null,
    ma009: null,
    ma010: null,
    ma011: null,
    ma012: [],
    ma013: null,
    ma014: [],
    ma015: [],
    ma016: [],
    ma017: [],
    ma018: [],
    ma019: [],
    ma020: [],
    ma021: [],
    ma022: null,
    ma023: null,
    ma024: null,
    ma025: [],
    ma026: [],
    ma027: [],
    ma028: null,
    ma029: null,
    ma030: null,
    ma031: null,
    ma032: null,
    ma033: null,
    ma034: null,
    ma035: null,
    ma036: null,
    ma037: null,
    ma038: null,
    ma039: 0,
    ma040: null,
    ma041: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'客户'
  opertype.value = 1
  form.value.ma003= []
  form.value.ma004= []
  form.value.ma005= []
  form.value.ma012= []
  form.value.ma014= []
  form.value.ma015= []
  form.value.ma016= []
  form.value.ma017= []
  form.value.ma018= []
  form.value.ma019= []
  form.value.ma020= []
  form.value.ma021= []
  form.value.ma022= new Date()
  form.value.ma023= new Date()
  form.value.ma025= []
  form.value.ma026= []
  form.value.ma027= []
  form.value.ma039= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getSdClient(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '客户'
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
        updateSdClient(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addSdClient(form.value).then((res) => {
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
      return delSdClient(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<客户.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/SdClient/export', { ...queryParams })
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