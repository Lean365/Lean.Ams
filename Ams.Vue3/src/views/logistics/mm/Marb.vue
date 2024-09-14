<!--
 * @Descripttion: 物料信息/mm_marb
 * @Version: 0.24.620.18453
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 11:22:47
 * @column：59
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="mb002">
        <el-select filterable clearable   v-model="queryParams.mb002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料号" prop="mb003">
        <el-input v-model="queryParams.mb003" :placeholder="$t('btn.enterSearchPrefix')+'物料号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="行业领域" prop="mb004">
        <el-select filterable clearable   v-model="queryParams.mb004" :placeholder="$t('btn.selectSearchPrefix')+'行业领域'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料类型" prop="mb005">
        <el-select filterable clearable   v-model="queryParams.mb005" :placeholder="$t('btn.selectSearchPrefix')+'物料类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_matl_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料描述" prop="mb006">
        <el-input v-model="queryParams.mb006" :placeholder="$t('btn.enterSearchPrefix')+'物料描述'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="基本单位" prop="mb007">
        <el-select filterable clearable   v-model="queryParams.mb007" :placeholder="$t('btn.selectSearchPrefix')+'基本单位'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料组" prop="mb009">
        <el-select filterable clearable   v-model="queryParams.mb009" :placeholder="$t('btn.selectSearchPrefix')+'物料组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_matl_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购组" prop="mb010">
        <el-select filterable clearable   v-model="queryParams.mb010" :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购" prop="mb011">
        <el-select filterable clearable   v-model="queryParams.mb011" :placeholder="$t('btn.selectSearchPrefix')+'采购'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="特殊采购" prop="mb012">
        <el-select filterable clearable   v-model="queryParams.mb012" :placeholder="$t('btn.selectSearchPrefix')+'特殊采购'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_spec " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="散装物料" prop="mb013">
        <el-input v-model="queryParams.mb013" :placeholder="$t('btn.enterSearchPrefix')+'散装物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="利润中心" prop="mb021">
        <el-select filterable clearable   v-model="queryParams.mb021" :placeholder="$t('btn.selectSearchPrefix')+'利润中心'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="批次管理" prop="mb023">
        <el-input v-model="queryParams.mb023" :placeholder="$t('btn.enterSearchPrefix')+'批次管理'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="评估类" prop="mb026">
        <el-select filterable clearable   v-model="queryParams.mb026" :placeholder="$t('btn.selectSearchPrefix')+'评估类'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_val_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="mb028">
        <el-select filterable clearable   v-model="queryParams.mb028" :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="发货库存地点" prop="mb031">
        <el-select filterable clearable   v-model="queryParams.mb031" :placeholder="$t('btn.selectSearchPrefix')+'发货库存地点'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工厂级删除标记" prop="mb035">
        <el-select filterable clearable   v-model="queryParams.mb035" :placeholder="$t('btn.selectSearchPrefix')+'工厂级删除标记'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_eol_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['mm:marb:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:marb:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:marb:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:marb:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/MmMarb/importTemplate"
                  importUrl="/Logistics/MmMarb/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:marb:export']">
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
      <el-table-column prop="mb002" label="工厂" align="center" v-if="columns.showColumn('mb002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mb002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb003" label="物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb003')"/>
      <el-table-column prop="mb004" label="行业领域" align="center" v-if="columns.showColumn('mb004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mb004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb005" label="物料类型" align="center" v-if="columns.showColumn('mb005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_type " :value="scope.row.mb005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb006" label="物料描述" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb006')"/>
      <el-table-column prop="mb007" label="基本单位" align="center" v-if="columns.showColumn('mb007')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.mb007"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb008" label="产品层次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb008')"/>
      <el-table-column prop="mb009" label="物料组" align="center" v-if="columns.showColumn('mb009')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_group " :value="scope.row.mb009"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb010" label="采购组" align="center" v-if="columns.showColumn('mb010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.mb010"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb011" label="采购" align="center" v-if="columns.showColumn('mb011')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_type " :value="scope.row.mb011"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb012" label="特殊采购" align="center" v-if="columns.showColumn('mb012')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_spec " :value="scope.row.mb012"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb013" label="散装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb013')"/>
      <el-table-column prop="mb014" label="最小批量" align="center" v-if="columns.showColumn('mb014')"/>
      <el-table-column prop="mb015" label="基本单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb015')"/>
      <el-table-column prop="mb016" label="舍入值" align="center" v-if="columns.showColumn('mb016')"/>
      <el-table-column prop="mb017" label="基本单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb017')"/>
      <el-table-column prop="mb018" label="计划交货天数" align="center" v-if="columns.showColumn('mb018')"/>
      <el-table-column prop="mb019" label="厂内生产时间" align="center" v-if="columns.showColumn('mb019')"/>
      <el-table-column prop="mb020" label="过帐到检验库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb020')"/>
      <el-table-column prop="mb021" label="利润中心" align="center" v-if="columns.showColumn('mb021')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.mb021"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb022" label="差异码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb022')"/>
      <el-table-column prop="mb023" label="批次管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb023')"/>
      <el-table-column prop="mb024" label="制造商零件编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb024')"/>
      <el-table-column prop="mb025" label="制造商编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb025')"/>
      <el-table-column prop="mb026" label="评估类" align="center" v-if="columns.showColumn('mb026')">
        <template #default="scope">
          <dict-tag :options=" options.sys_val_type " :value="scope.row.mb026"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb027" label="移动价格" align="center" v-if="columns.showColumn('mb027')"/>
      <el-table-column prop="mb028" label="币种" align="center" v-if="columns.showColumn('mb028')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.mb028"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb029" label="价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mb029')"/>
      <el-table-column prop="mb030" label="价格单位" align="center" v-if="columns.showColumn('mb030')"/>
      <el-table-column prop="mb031" label="发货库存地点" align="center" v-if="columns.showColumn('mb031')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.mb031"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb032" label="外部采购仓储位置" align="center" v-if="columns.showColumn('mb032')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.mb032"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb033" label="库存仓位" align="center" v-if="columns.showColumn('mb033')">
        <template #default="scope">
          <dict-tag :options=" options.sys_whse_location " :value="scope.row.mb033"  />
        </template>
      </el-table-column>
      <el-table-column prop="mb034" label="总库存" align="center" v-if="columns.showColumn('mb034')"/>
      <el-table-column prop="mb035" label="工厂级删除标记" align="center" v-if="columns.showColumn('mb035')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_list " :value="scope.row.mb035"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:marb:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:marb:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改物料信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂" prop="mb002">
              <el-select filterable clearable   v-model="form.mb002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料号" prop="mb003">
              <el-input   v-model="form.mb003" :placeholder="$t('btn.enterPrefix')+'物料号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业领域" prop="mb004">
              <el-select filterable clearable   v-model="form.mb004"  :placeholder="$t('btn.selectPrefix')+'行业领域'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料类型" prop="mb005">
              <el-select filterable clearable   v-model="form.mb005"  :placeholder="$t('btn.selectPrefix')+'物料类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_matl_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料描述" prop="mb006">
              <el-input   v-model="form.mb006" :placeholder="$t('btn.enterPrefix')+'物料描述'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="mb007">
              <el-select filterable clearable   v-model="form.mb007"  :placeholder="$t('btn.selectPrefix')+'基本单位'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_unit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="产品层次" prop="mb008">
              <el-input   v-model="form.mb008" :placeholder="$t('btn.enterPrefix')+'产品层次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组" prop="mb009">
              <el-select filterable clearable   v-model="form.mb009"  :placeholder="$t('btn.selectPrefix')+'物料组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_matl_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购组" prop="mb010">
              <el-select filterable clearable   v-model="form.mb010"  :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购" prop="mb011">
              <el-select filterable clearable   v-model="form.mb011"  :placeholder="$t('btn.selectPrefix')+'采购'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="特殊采购" prop="mb012">
              <el-select filterable clearable   v-model="form.mb012"  :placeholder="$t('btn.selectPrefix')+'特殊采购'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_spec" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="散装物料" prop="mb013">
              <el-input   v-model="form.mb013" :placeholder="$t('btn.enterPrefix')+'散装物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小批量" prop="mb014">
              <el-input-number v-model.number="form.mb014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最小批量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="mb015">
              <el-input   v-model="form.mb015" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入值" prop="mb016">
              <el-input-number v-model.number="form.mb016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'舍入值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="mb017">
              <el-input   v-model="form.mb017" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划交货天数" prop="mb018">
              <el-input-number v-model.number="form.mb018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'计划交货天数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="厂内生产时间" prop="mb019">
              <el-input-number v-model.number="form.mb019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'厂内生产时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过帐到检验库存" prop="mb020">
              <el-input   v-model="form.mb020" :placeholder="$t('btn.enterPrefix')+'过帐到检验库存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="mb021">
              <el-select filterable clearable   v-model="form.mb021"  :placeholder="$t('btn.selectPrefix')+'利润中心'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="差异码" prop="mb022">
              <el-input   v-model="form.mb022" :placeholder="$t('btn.enterPrefix')+'差异码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理" prop="mb023">
              <el-input   v-model="form.mb023" :placeholder="$t('btn.enterPrefix')+'批次管理'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商零件编号" prop="mb024">
              <el-input   v-model="form.mb024" :placeholder="$t('btn.enterPrefix')+'制造商零件编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="80"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商编号" prop="mb025">
              <el-input   v-model="form.mb025" :placeholder="$t('btn.enterPrefix')+'制造商编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类" prop="mb026">
              <el-select filterable clearable   v-model="form.mb026"  :placeholder="$t('btn.selectPrefix')+'评估类'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_val_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="移动价格" prop="mb027">
              <el-input-number v-model.number="form.mb027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'移动价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="mb028">
              <el-select filterable clearable   v-model="form.mb028"  :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="价格控制" prop="mb029">
              <el-input   v-model="form.mb029" :placeholder="$t('btn.enterPrefix')+'价格控制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格单位" prop="mb030">
              <el-input-number v-model.number="form.mb030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发货库存地点" prop="mb031">
              <el-select filterable clearable   v-model="form.mb031"  :placeholder="$t('btn.selectPrefix')+'发货库存地点'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="外部采购仓储位置" prop="mb032">
              <el-select filterable clearable   v-model="form.mb032"  :placeholder="$t('btn.selectPrefix')+'外部采购仓储位置'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="库存仓位" prop="mb033">
              <el-select filterable clearable   v-model="form.mb033"  :placeholder="$t('btn.selectPrefix')+'库存仓位'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_whse_location" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="总库存" prop="mb034">
              <el-input-number v-model.number="form.mb034" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂级删除标记" prop="mb035">
              <el-select filterable clearable   v-model="form.mb035"  :placeholder="$t('btn.selectPrefix')+'工厂级删除标记'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_eol_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
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

<script setup name="mmmarb">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listMmMarb,
 addMmMarb, delMmMarb, 
 updateMmMarb,getMmMarb, 
 } 
from '@/api/logistics/mmmarb.js'
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
  mb002: undefined,
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
  mb009: undefined,
  //是否查询（1是）
  mb010: undefined,
  //是否查询（1是）
  mb011: undefined,
  //是否查询（1是）
  mb012: undefined,
  //是否查询（1是）
  mb013: undefined,
  //是否查询（1是）
  mb021: undefined,
  //是否查询（1是）
  mb023: undefined,
  //是否查询（1是）
  mb026: undefined,
  //是否查询（1是）
  mb028: undefined,
  //是否查询（1是）
  mb031: undefined,
  //是否查询（1是）
  mb035: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mb002', label: '工厂' },
  { visible: true, prop: 'mb003', label: '物料号' },
  { visible: true, prop: 'mb004', label: '行业领域' },
  { visible: true, prop: 'mb005', label: '物料类型' },
  { visible: true, prop: 'mb006', label: '物料描述' },
  { visible: true, prop: 'mb007', label: '基本单位' },
  { visible: true, prop: 'mb008', label: '产品层次' },
  { visible: false, prop: 'mb009', label: '物料组' },
  { visible: false, prop: 'mb010', label: '采购组' },
  { visible: false, prop: 'mb011', label: '采购' },
  { visible: false, prop: 'mb012', label: '特殊采购' },
  { visible: false, prop: 'mb013', label: '散装物料' },
  { visible: false, prop: 'mb014', label: '最小批量' },
  { visible: false, prop: 'mb015', label: '基本单位' },
  { visible: false, prop: 'mb016', label: '舍入值' },
  { visible: false, prop: 'mb017', label: '基本单位' },
  { visible: false, prop: 'mb018', label: '计划交货天数' },
  { visible: false, prop: 'mb019', label: '厂内生产时间' },
  { visible: false, prop: 'mb020', label: '过帐到检验库存' },
  { visible: false, prop: 'mb021', label: '利润中心' },
  { visible: false, prop: 'mb022', label: '差异码' },
  { visible: false, prop: 'mb023', label: '批次管理' },
  { visible: false, prop: 'mb024', label: '制造商零件编号' },
  { visible: false, prop: 'mb025', label: '制造商编号' },
  { visible: false, prop: 'mb026', label: '评估类' },
  { visible: false, prop: 'mb027', label: '移动价格' },
  { visible: false, prop: 'mb028', label: '币种' },
  { visible: false, prop: 'mb029', label: '价格控制' },
  { visible: false, prop: 'mb030', label: '价格单位' },
  { visible: false, prop: 'mb031', label: '发货库存地点' },
  { visible: false, prop: 'mb032', label: '外部采购仓储位置' },
  { visible: false, prop: 'mb033', label: '库存仓位' },
  { visible: false, prop: 'mb034', label: '总库存' },
  { visible: false, prop: 'mb035', label: '工厂级删除标记' },
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

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_matl_type" },
  { dictType: "sys_unit_list" },
  { dictType: "sys_matl_group" },
  { dictType: "sys_pur_group" },
  { dictType: "sys_pur_type" },
  { dictType: "sys_pur_spec" },
  { dictType: "sql_prctr_list" },
  { dictType: "sys_val_type" },
  { dictType: "sql_global_currency" },
  { dictType: "sys_sloc_list" },
  { dictType: "sys_whse_location" },
  { dictType: "sys_eol_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从物料信息/mm_marb表记录数据
function getList(){
  loading.value = true
  listMmMarb(queryParams).then(res => {
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
    mb002: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb003: [{ required: true, message: "物料号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mb004: [{ required: true, message: "行业领域"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb005: [{ required: true, message: "物料类型"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mb028: [{ required: true, message: "币种"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 行业领域 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ind_type: [],
    // 物料类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_matl_type: [],
    // 基本单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_unit_list: [],
    // 物料组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_matl_group: [],
    // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_group: [],
    // 采购 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_type: [],
    // 特殊采购 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_spec: [],
    // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_prctr_list: [],
    // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_val_type: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_currency: [],
    // 发货库存地点 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_sloc_list: [],
    // 库存仓位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_whse_location: [],
    // 工厂级删除标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_eol_list: [],
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
    mb002: [],
    mb003: null,
    mb004: [],
    mb005: [],
    mb006: null,
    mb007: [],
    mb008: null,
    mb009: [],
    mb010: [],
    mb011: [],
    mb012: [],
    mb013: null,
    mb014: 0,
    mb015: null,
    mb016: 0,
    mb017: null,
    mb018: 0,
    mb019: 0,
    mb020: null,
    mb021: [],
    mb022: null,
    mb023: null,
    mb024: null,
    mb025: null,
    mb026: [],
    mb027: 0,
    mb028: [],
    mb029: null,
    mb030: 0,
    mb031: [],
    mb032: [],
    mb033: [],
    mb034: 0,
    mb035: [],
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'物料信息'
  opertype.value = 1
  form.value.mb002= []
  form.value.mb004= []
  form.value.mb005= []
  form.value.mb007= []
  form.value.mb009= []
  form.value.mb010= []
  form.value.mb011= []
  form.value.mb012= []
  form.value.mb014= 0
  form.value.mb016= 0
  form.value.mb018= 0
  form.value.mb019= 0
  form.value.mb021= []
  form.value.mb026= []
  form.value.mb027= 0
  form.value.mb028= []
  form.value.mb030= 0
  form.value.mb031= []
  form.value.mb032= []
  form.value.mb033= []
  form.value.mb034= 0
  form.value.mb035= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getMmMarb(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '物料信息'
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
        updateMmMarb(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addMmMarb(form.value).then((res) => {
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
      return delMmMarb(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<物料信息.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/MmMarb/export', { ...queryParams })
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