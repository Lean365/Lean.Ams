<!--
 * @Descripttion: 月度资产/fico_monthly_assets
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/9 11:59:43
 * @column：54
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="期间" prop="faLfgja">
        <el-select filterable clearable   v-model="queryParams.faLfgja" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_fy_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="faLfmon">
        <el-select filterable clearable   v-model="queryParams.faLfmon" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司" prop="faBukrs">
        <el-select filterable clearable   v-model="queryParams.faBukrs" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="使用部门" prop="faBtabt">
        <el-select filterable clearable   v-model="queryParams.faBtabt" :placeholder="$t('btn.selectSearchPrefix')+'使用部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_name " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="资产类别" prop="faAnlkl">
        <el-select filterable clearable   v-model="queryParams.faAnlkl" :placeholder="$t('btn.selectSearchPrefix')+'资产类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_assets_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="资产编码" prop="faAnln">
        <el-input v-model="queryParams.faAnln" :placeholder="$t('btn.enterSearchPrefix')+'资产编码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="成本中心" prop="faKostl">
        <el-select filterable clearable   v-model="queryParams.faKostl" :placeholder="$t('btn.selectSearchPrefix')+'成本中心'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_cost_center " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="资产简称" prop="faStext">
        <el-input v-model="queryParams.faStext" :placeholder="$t('btn.enterSearchPrefix')+'资产简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="资本化日期">
        <el-date-picker
          v-model="dateRangeFaAktiv" 
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
          v-model="dateRangeFaDeakt" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="是否停用" prop="faParkflg">
        <el-radio-group v-model="queryParams.faParkflg">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
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
                  templateUrl="Accounting/FicoMonthlyAssets/importTemplate"
                  importUrl="/Accounting/FicoMonthlyAssets/importData"
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
      <el-table-column prop="faSfId" label="ID" align="center" v-if="columns.showColumn('faSfId')"/>
      <el-table-column prop="faLfgja" label="期间" align="center" v-if="columns.showColumn('faLfgja')">
        <template #default="scope">
          <dict-tag :options=" options.sql_fy_list " :value="scope.row.faLfgja"  />
        </template>
      </el-table-column>
      <el-table-column prop="faLfmon" label="年月" align="center" v-if="columns.showColumn('faLfmon')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.faLfmon"  />
        </template>
      </el-table-column>
      <el-table-column prop="faBukrs" label="公司" align="center" v-if="columns.showColumn('faBukrs')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.faBukrs"  />
        </template>
      </el-table-column>
      <el-table-column prop="faBtabt" label="使用部门" align="center" v-if="columns.showColumn('faBtabt')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_name " :value="scope.row.faBtabt"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAnlkl" label="资产类别" align="center" v-if="columns.showColumn('faAnlkl')">
        <template #default="scope">
          <dict-tag :options=" options.sys_assets_type " :value="scope.row.faAnlkl"  />
        </template>
      </el-table-column>
      <el-table-column prop="faAnln" label="资产编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAnln')"/>
      <el-table-column prop="faKostl" label="成本中心" align="center" v-if="columns.showColumn('faKostl')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cost_center " :value="scope.row.faKostl"  />
        </template>
      </el-table-column>
      <el-table-column prop="faStext" label="资产简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faStext')"/>
      <el-table-column prop="faLtext" label="资产全称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faLtext')"/>
      <el-table-column prop="faMeins" label="单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faMeins')"/>
      <el-table-column prop="faMenge" label="数量" align="center" v-if="columns.showColumn('faMenge')"/>
      <el-table-column prop="faBsakz" label="管理区分" align="center" v-if="columns.showColumn('faBsakz')">
        <template #default="scope">
          <dict-tag :options=" options.sys_assets_dist " :value="scope.row.faBsakz"  />
        </template>
      </el-table-column>
      <el-table-column prop="faWaers" label="币种" align="center" v-if="columns.showColumn('faWaers')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.faWaers"  />
        </template>
      </el-table-column>
      <el-table-column prop="faBubtr" label="购买价格" align="center" v-if="columns.showColumn('faBubtr')"/>
      <el-table-column prop="faAktiv" label="资本化日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faAktiv')"/>
      <el-table-column prop="faNafaz" label="折旧价值" align="center" v-if="columns.showColumn('faNafaz')"/>
      <el-table-column prop="faDeakt" label="报废日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faDeakt')"/>
      <el-table-column prop="faSchrw" label="残值" align="center" v-if="columns.showColumn('faSchrw')"/>
      <el-table-column prop="faPosnr" label="存放位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faPosnr')"/>
      <el-table-column prop="faSrvvy" label="使用年限" align="center" v-if="columns.showColumn('faSrvvy')"/>
      <el-table-column prop="faParkflg" label="是否停用" align="center" v-if="columns.showColumn('faParkflg')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.faParkflg"  />
        </template>
      </el-table-column>
      <el-table-column prop="faLifnr" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faLifnr')"/>
      <el-table-column prop="faHerst" label="制造商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faHerst')"/>
      <el-table-column prop="faVenpn" label="供应商物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faVenpn')"/>
      <el-table-column prop="faMfrpn" label="制造商物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faMfrpn')"/>
      <el-table-column prop="faEntity" label="资产形态" align="center" v-if="columns.showColumn('faEntity')">
        <template #default="scope">
          <dict-tag :options=" options.sys_assets_pattern " :value="scope.row.faEntity"  />
        </template>
      </el-table-column>
      <el-table-column prop="faNxtfl" label="资产存在否" align="center" v-if="columns.showColumn('faNxtfl')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.faNxtfl"  />
        </template>
      </el-table-column>
      <el-table-column prop="faPresp" label="盘点人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faPresp')"/>
      <el-table-column prop="faIdatu" label="周期盘点日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faIdatu')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
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

    <!-- 添加或修改月度资产对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="期间" prop="faLfgja">
              <el-select filterable clearable   v-model="form.faLfgja"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_fy_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="faLfmon">
              <el-select filterable clearable   v-model="form.faLfmon"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="公司" prop="faBukrs">
              <el-select filterable clearable   v-model="form.faBukrs"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="使用部门" prop="faBtabt">
              <el-select filterable clearable   v-model="form.faBtabt"  :placeholder="$t('btn.selectPrefix')+'使用部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_name" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="资产类别" prop="faAnlkl">
              <el-select filterable clearable   v-model="form.faAnlkl"  :placeholder="$t('btn.selectPrefix')+'资产类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_assets_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="资产编码" prop="faAnln">
              <el-input v-model="form.faAnln" :placeholder="$t('btn.enterPrefix')+'资产编码'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本中心" prop="faKostl">
              <el-select filterable clearable   v-model="form.faKostl"  :placeholder="$t('btn.selectPrefix')+'成本中心'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_cost_center" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="资产简称" prop="faStext">
              <el-input v-model="form.faStext" :placeholder="$t('btn.enterPrefix')+'资产简称'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资产全称" prop="faLtext">
              <el-input v-model="form.faLtext" :placeholder="$t('btn.enterPrefix')+'资产全称'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位" prop="faMeins">
              <el-input v-model="form.faMeins" :placeholder="$t('btn.enterPrefix')+'单位'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="数量" prop="faMenge">
              <el-input-number v-model.number="form.faMenge" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="管理区分" prop="faBsakz">
              <el-select filterable clearable   v-model="form.faBsakz"  :placeholder="$t('btn.selectPrefix')+'管理区分'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_assets_dist" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="币种" prop="faWaers">
              <el-select filterable clearable   v-model="form.faWaers"  :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="购买价格" prop="faBubtr">
              <el-input-number v-model.number="form.faBubtr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'购买价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资本化日期" prop="faAktiv">
              <el-date-picker v-model="form.faAktiv" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折旧价值" prop="faNafaz">
              <el-input-number v-model.number="form.faNafaz" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'折旧价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="报废日期" prop="faDeakt">
              <el-date-picker v-model="form.faDeakt" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="残值" prop="faSchrw">
              <el-input-number v-model.number="form.faSchrw" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'残值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="存放位置" prop="faPosnr">
              <el-input v-model="form.faPosnr" :placeholder="$t('btn.enterPrefix')+'存放位置'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="使用年限" prop="faSrvvy">
              <el-input-number v-model.number="form.faSrvvy" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'使用年限'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="是否停用" prop="faParkflg">
              <el-radio-group v-model="form.faParkflg">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商" prop="faLifnr">
              <el-input v-model="form.faLifnr" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="faHerst">
              <el-input v-model="form.faHerst" :placeholder="$t('btn.enterPrefix')+'制造商'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商物料" prop="faVenpn">
              <el-input v-model="form.faVenpn" :placeholder="$t('btn.enterPrefix')+'供应商物料'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商物料" prop="faMfrpn">
              <el-input v-model="form.faMfrpn" :placeholder="$t('btn.enterPrefix')+'制造商物料'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="资产形态" prop="faEntity">
              <el-radio-group v-model="form.faEntity">
                <el-radio v-for="item in options.sys_assets_pattern" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="资产存在否" prop="faNxtfl">
              <el-radio-group v-model="form.faNxtfl">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="盘点人员" prop="faPresp">
              <el-input v-model="form.faPresp" :placeholder="$t('btn.enterPrefix')+'盘点人员'+$t('btn.enterSuffix')"  show-word-limit maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="周期盘点日期" prop="faIdatu">
              <el-date-picker v-model="form.faIdatu" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ficomonthlyassets">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoMonthlyAssets,
 addFicoMonthlyAssets, delFicoMonthlyAssets, 
 updateFicoMonthlyAssets,getFicoMonthlyAssets, 
 } 
from '@/api/accounting/ficomonthlyassets.js'
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
  sort: 'FaLfmon',
  sortType: 'desc',
//是否查询（1是）
  faLfgja: undefined,
//是否查询（1是）
  faLfmon: undefined,
//是否查询（1是）
  faBukrs: undefined,
//是否查询（1是）
  faBtabt: undefined,
//是否查询（1是）
  faAnlkl: undefined,
//是否查询（1是）
  faAnln: undefined,
//是否查询（1是）
  faKostl: undefined,
//是否查询（1是）
  faStext: undefined,
//是否查询（1是）
  faAktiv: undefined,
//是否查询（1是）
  faDeakt: undefined,
//是否查询（1是）
  faParkflg: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'faSfId', label: 'ID' },
  { visible: true, prop: 'faLfgja', label: '期间' },
  { visible: true, prop: 'faLfmon', label: '年月' },
  { visible: true, prop: 'faBukrs', label: '公司' },
  { visible: true, prop: 'faBtabt', label: '使用部门' },
  { visible: true, prop: 'faAnlkl', label: '资产类别' },
  { visible: true, prop: 'faAnln', label: '资产编码' },
  { visible: true, prop: 'faKostl', label: '成本中心' },
  { visible: false, prop: 'faStext', label: '资产简称' },
  { visible: false, prop: 'faLtext', label: '资产全称' },
  { visible: false, prop: 'faMeins', label: '单位' },
  { visible: false, prop: 'faMenge', label: '数量' },
  { visible: false, prop: 'faBsakz', label: '管理区分' },
  { visible: false, prop: 'faWaers', label: '币种' },
  { visible: false, prop: 'faBubtr', label: '购买价格' },
  { visible: false, prop: 'faAktiv', label: '资本化日期' },
  { visible: false, prop: 'faNafaz', label: '折旧价值' },
  { visible: false, prop: 'faDeakt', label: '报废日期' },
  { visible: false, prop: 'faSchrw', label: '残值' },
  { visible: false, prop: 'faPosnr', label: '存放位置' },
  { visible: false, prop: 'faSrvvy', label: '使用年限' },
  { visible: false, prop: 'faParkflg', label: '是否停用' },
  { visible: false, prop: 'faLifnr', label: '供应商' },
  { visible: false, prop: 'faHerst', label: '制造商' },
  { visible: false, prop: 'faVenpn', label: '供应商物料' },
  { visible: false, prop: 'faMfrpn', label: '制造商物料' },
  { visible: false, prop: 'faEntity', label: '资产形态' },
  { visible: false, prop: 'faNxtfl', label: '资产存在否' },
  { visible: false, prop: 'faPresp', label: '盘点人员' },
  { visible: false, prop: 'faIdatu', label: '周期盘点日期' },
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
// 资本化日期时间范围
const dateRangeFaAktiv = ref([])
// 报废日期时间范围
const dateRangeFaDeakt = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_fy_list" },
  { dictType: "sql_ym_list" },
  { dictType: "sys_crop_list" },
  { dictType: "sql_dept_name" },
  { dictType: "sys_assets_type" },
  { dictType: "sql_cost_center" },
  { dictType: "sys_assets_dist" },
  { dictType: "sys_ccy_type" },
  { dictType: "sys_is_status" },
  { dictType: "sys_assets_pattern" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从月度资产/fico_monthly_assets表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeFaAktiv.value, 'FaAktiv');
  proxy.addDateRange(queryParams, dateRangeFaDeakt.value, 'FaDeakt');
  loading.value = true
  listFicoMonthlyAssets(queryParams).then(res => {
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
  dateRangeFaAktiv.value = []
  // 报废日期时间范围
  dateRangeFaDeakt.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.faSfId);
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
    faSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
  },
  options: {
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_fy_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ym_list: [],
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_crop_list: [],
    // 使用部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_name: [],
    // 资产类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_assets_type: [],
    // 成本中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_cost_center: [],
    // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_assets_dist: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ccy_type: [],
    // 是否停用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_status: [],
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
    faSfId: 0,
    faLfgja: null,
    faLfmon: null,
    faBukrs: null,
    faBtabt: null,
    faAnlkl: null,
    faAnln: null,
    faKostl: null,
    faStext: null,
    faLtext: null,
    faMeins: null,
    faMenge: 0,
    faBsakz: 0,
    faWaers: null,
    faBubtr: 0,
    faAktiv: null,
    faNafaz: 0,
    faDeakt: null,
    faSchrw: 0,
    faPosnr: null,
    faSrvvy: 0,
    faParkflg: 0,
    faLifnr: null,
    faHerst: null,
    faVenpn: null,
    faMfrpn: null,
    faEntity: 0,
    faNxtfl: 0,
    faPresp: null,
    faIdatu: null,
    rEF01: null,
    rEF02: null,
    rEF03: null,
    rEF04: 0,
    rEF05: 0,
    rEF06: 0,
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
  title.value = proxy.$t('btn.add')+" "+'月度资产'
  opertype.value = 1
  form.value.faLfgja= []
  form.value.faLfmon= []
  form.value.faBukrs= []
  form.value.faBtabt= []
  form.value.faAnlkl= []
  form.value.faKostl= []
  form.value.faMenge= 0
  form.value.faBsakz= 0
  form.value.faWaers= []
  form.value.faBubtr= 0
  form.value.faAktiv= new Date()
  form.value.faNafaz= 0
  form.value.faDeakt= new Date()
  form.value.faSchrw= 0
  form.value.faSrvvy= 0
  form.value.faParkflg= 0
  form.value.faEntity= 0
  form.value.faNxtfl= 0
  form.value.faIdatu= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.faSfId || ids.value
  getFicoMonthlyAssets(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '月度资产'
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

      if (form.value.faSfId != undefined && opertype.value === 2) {
        updateFicoMonthlyAssets(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoMonthlyAssets(form.value).then((res) => {
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
  const Ids = row.faSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoMonthlyAssets(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<月度资产.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoMonthlyAssets/export', { ...queryParams })
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