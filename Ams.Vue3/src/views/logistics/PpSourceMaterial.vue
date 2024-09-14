<!--
 * @Descripttion: 源物料/pp_source_material
 * @Version: 0.24.620.21805
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 13:36:27
 * @column：59
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="Plnt" prop="zd002">
        <el-select filterable clearable   v-model="queryParams.zd002" :placeholder="$t('btn.selectSearchPrefix')+'Plnt'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="品目" prop="zd003">
        <el-input v-model="queryParams.zd003" :placeholder="$t('btn.enterSearchPrefix')+'品目'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="采购组" prop="zd010">
        <el-select filterable clearable   v-model="queryParams.zd010" :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:sourcematerial:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:sourcematerial:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:sourcematerial:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:sourcematerial:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpSourceMaterial/importTemplate"
                  importUrl="/Logistics/PpSourceMaterial/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:sourcematerial:export']">
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
      <el-table-column prop="zd002" label="Plnt" align="center" v-if="columns.showColumn('zd002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.zd002"  />
        </template>
      </el-table-column>
      <el-table-column prop="zd003" label="品目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd003')"/>
      <el-table-column prop="zd004" label="行业领域" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd004')"/>
      <el-table-column prop="zd005" label="物料类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd005')"/>
      <el-table-column prop="zd006" label="物料描述（短文本）" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd006')"/>
      <el-table-column prop="zd007" label="基本单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd007')"/>
      <el-table-column prop="zd008" label="产品层次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd008')"/>
      <el-table-column prop="zd009" label="物料组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd009')"/>
      <el-table-column prop="zd010" label="采购组" align="center" v-if="columns.showColumn('zd010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.zd010"  />
        </template>
      </el-table-column>
      <el-table-column prop="zd011" label="采购类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd011')"/>
      <el-table-column prop="zd012" label="特殊采购类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd012')"/>
      <el-table-column prop="zd013" label="散装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd013')"/>
      <el-table-column prop="zd014" label="最小起订量" align="center" v-if="columns.showColumn('zd014')"/>
      <el-table-column prop="zd015" label="基本单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd015')"/>
      <el-table-column prop="zd016" label="舍入值" align="center" v-if="columns.showColumn('zd016')"/>
      <el-table-column prop="zd017" label="基本单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd017')"/>
      <el-table-column prop="zd018" label="计划交货" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd018')"/>
      <el-table-column prop="zd019" label="自制天数" align="center" v-if="columns.showColumn('zd019')"/>
      <el-table-column prop="zd020" label="过账检验" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd020')"/>
      <el-table-column prop="zd021" label="利润中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd021')"/>
      <el-table-column prop="zd022" label="差异码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd022')"/>
      <el-table-column prop="zd023" label="批次管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd023')"/>
      <el-table-column prop="zd024" label="制造商零件编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd024')"/>
      <el-table-column prop="zd025" label="制造商编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd025')"/>
      <el-table-column prop="zd026" label="评估类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd026')"/>
      <el-table-column prop="zd027" label="移动平均价格/周期单价" align="center" v-if="columns.showColumn('zd027')"/>
      <el-table-column prop="zd028" label="币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd028')"/>
      <el-table-column prop="zd029" label="价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd029')"/>
      <el-table-column prop="zd030" label="价格单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd030')"/>
      <el-table-column prop="zd031" label="生产仓储" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd031')"/>
      <el-table-column prop="zd032" label="采购仓储" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd032')"/>
      <el-table-column prop="zd033" label="库存仓位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd033')"/>
      <el-table-column prop="zd034" label="库存" align="center" v-if="columns.showColumn('zd034')"/>
      <el-table-column prop="zd035" label="状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zd035')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:sourcematerial:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:sourcematerial:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改源物料对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="Plnt" prop="zd002">
              <el-select filterable clearable   v-model="form.zd002"  :placeholder="$t('btn.selectPrefix')+'Plnt'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="品目" prop="zd003">
              <el-input   v-model="form.zd003" :placeholder="$t('btn.enterPrefix')+'品目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业领域" prop="zd004">
              <el-input   v-model="form.zd004" :placeholder="$t('btn.enterPrefix')+'行业领域'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类型" prop="zd005">
              <el-input   v-model="form.zd005" :placeholder="$t('btn.enterPrefix')+'物料类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料描述（短文本）" prop="zd006">
              <el-input   v-model="form.zd006" :placeholder="$t('btn.enterPrefix')+'物料描述（短文本）'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="zd007">
              <el-input   v-model="form.zd007" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品层次" prop="zd008">
              <el-input   v-model="form.zd008" :placeholder="$t('btn.enterPrefix')+'产品层次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组" prop="zd009">
              <el-input   v-model="form.zd009" :placeholder="$t('btn.enterPrefix')+'物料组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组" prop="zd010">
              <el-select filterable clearable   v-model="form.zd010"  :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购类型" prop="zd011">
              <el-input   v-model="form.zd011" :placeholder="$t('btn.enterPrefix')+'采购类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特殊采购类" prop="zd012">
              <el-input   v-model="form.zd012" :placeholder="$t('btn.enterPrefix')+'特殊采购类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="散装物料" prop="zd013">
              <el-input   v-model="form.zd013" :placeholder="$t('btn.enterPrefix')+'散装物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="最小起订量" prop="zd014">
              <el-input-number v-model.number="form.zd014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最小起订量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="zd015">
              <el-input   v-model="form.zd015" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="舍入值" prop="zd016">
              <el-input-number v-model.number="form.zd016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'舍入值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="zd017">
              <el-input   v-model="form.zd017" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划交货" prop="zd018">
              <el-input   v-model="form.zd018" :placeholder="$t('btn.enterPrefix')+'计划交货'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自制天数" prop="zd019">
              <el-input-number v-model.number="form.zd019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自制天数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过账检验" prop="zd020">
              <el-input   v-model="form.zd020" :placeholder="$t('btn.enterPrefix')+'过账检验'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="zd021">
              <el-input   v-model="form.zd021" :placeholder="$t('btn.enterPrefix')+'利润中心'+$t('btn.enterSuffix')"  show-word-limit   maxlength="5"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异码" prop="zd022">
              <el-input   v-model="form.zd022" :placeholder="$t('btn.enterPrefix')+'差异码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理" prop="zd023">
              <el-input   v-model="form.zd023" :placeholder="$t('btn.enterPrefix')+'批次管理'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商零件编号" prop="zd024">
              <el-input   v-model="form.zd024" :placeholder="$t('btn.enterPrefix')+'制造商零件编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商编号" prop="zd025">
              <el-input   v-model="form.zd025" :placeholder="$t('btn.enterPrefix')+'制造商编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类" prop="zd026">
              <el-input   v-model="form.zd026" :placeholder="$t('btn.enterPrefix')+'评估类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动平均价格/周期单价" prop="zd027">
              <el-input-number v-model.number="form.zd027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'移动平均价格/周期单价'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="zd028">
              <el-input   v-model="form.zd028" :placeholder="$t('btn.enterPrefix')+'币种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格控制" prop="zd029">
              <el-input   v-model="form.zd029" :placeholder="$t('btn.enterPrefix')+'价格控制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格单位" prop="zd030">
              <el-input   v-model="form.zd030" :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产仓储" prop="zd031">
              <el-input   v-model="form.zd031" :placeholder="$t('btn.enterPrefix')+'生产仓储'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购仓储" prop="zd032">
              <el-input   v-model="form.zd032" :placeholder="$t('btn.enterPrefix')+'采购仓储'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存仓位" prop="zd033">
              <el-input   v-model="form.zd033" :placeholder="$t('btn.enterPrefix')+'库存仓位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存" prop="zd034">
              <el-input-number v-model.number="form.zd034" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="zd035">
              <el-input   v-model="form.zd035" :placeholder="$t('btn.enterPrefix')+'状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
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

<script setup name="ppsourcematerial">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpSourceMaterial,
 addPpSourceMaterial, delPpSourceMaterial, 
 updatePpSourceMaterial,getPpSourceMaterial, 
 } 
from '@/api/logistics/ppsourcematerial.js'
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
  sort: 'Zd003',
  sortType: 'asc',
  //是否查询（1是）
  zd002: undefined,
  //是否查询（1是）
  zd003: undefined,
  //是否查询（1是）
  zd010: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'zd002', label: 'Plnt' },
  { visible: true, prop: 'zd003', label: '品目' },
  { visible: true, prop: 'zd004', label: '行业领域' },
  { visible: true, prop: 'zd005', label: '物料类型' },
  { visible: true, prop: 'zd006', label: '物料描述（短文本）' },
  { visible: true, prop: 'zd007', label: '基本单位' },
  { visible: true, prop: 'zd008', label: '产品层次' },
  { visible: false, prop: 'zd009', label: '物料组' },
  { visible: false, prop: 'zd010', label: '采购组' },
  { visible: false, prop: 'zd011', label: '采购类型' },
  { visible: false, prop: 'zd012', label: '特殊采购类' },
  { visible: false, prop: 'zd013', label: '散装物料' },
  { visible: false, prop: 'zd014', label: '最小起订量' },
  { visible: false, prop: 'zd015', label: '基本单位' },
  { visible: false, prop: 'zd016', label: '舍入值' },
  { visible: false, prop: 'zd017', label: '基本单位' },
  { visible: false, prop: 'zd018', label: '计划交货' },
  { visible: false, prop: 'zd019', label: '自制天数' },
  { visible: false, prop: 'zd020', label: '过账检验' },
  { visible: false, prop: 'zd021', label: '利润中心' },
  { visible: false, prop: 'zd022', label: '差异码' },
  { visible: false, prop: 'zd023', label: '批次管理' },
  { visible: false, prop: 'zd024', label: '制造商零件编号' },
  { visible: false, prop: 'zd025', label: '制造商编号' },
  { visible: false, prop: 'zd026', label: '评估类' },
  { visible: false, prop: 'zd027', label: '移动平均价格/周期单价' },
  { visible: false, prop: 'zd028', label: '币种' },
  { visible: false, prop: 'zd029', label: '价格控制' },
  { visible: false, prop: 'zd030', label: '价格单位' },
  { visible: false, prop: 'zd031', label: '生产仓储' },
  { visible: false, prop: 'zd032', label: '采购仓储' },
  { visible: false, prop: 'zd033', label: '库存仓位' },
  { visible: false, prop: 'zd034', label: '库存' },
  { visible: false, prop: 'zd035', label: '状态' },
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
  { dictType: "sys_pur_group" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从源物料/pp_source_material表记录数据
function getList(){
  loading.value = true
  listPpSourceMaterial(queryParams).then(res => {
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
    zd002: [{ required: true, message: "Plnt"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    zd003: [{ required: true, message: "品目"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    zd014: [{ required: true, message: "最小起订量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    zd016: [{ required: true, message: "舍入值"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    zd019: [{ required: true, message: "自制天数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    zd027: [{ required: true, message: "移动平均价格/周期单价"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    zd034: [{ required: true, message: "库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // Plnt 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_group: [],
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
    zd002: [],
    zd003: null,
    zd004: null,
    zd005: null,
    zd006: null,
    zd007: null,
    zd008: null,
    zd009: null,
    zd010: [],
    zd011: null,
    zd012: null,
    zd013: null,
    zd014: 0,
    zd015: null,
    zd016: 0,
    zd017: null,
    zd018: null,
    zd019: 0,
    zd020: null,
    zd021: null,
    zd022: null,
    zd023: null,
    zd024: null,
    zd025: null,
    zd026: null,
    zd027: 0,
    zd028: null,
    zd029: null,
    zd030: null,
    zd031: null,
    zd032: null,
    zd033: null,
    zd034: 0,
    zd035: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'源物料'
  opertype.value = 1
  form.value.zd002= []
  form.value.zd010= []
  form.value.zd014= 0
  form.value.zd016= 0
  form.value.zd019= 0
  form.value.zd027= 0
  form.value.zd034= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpSourceMaterial(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '源物料'
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
        updatePpSourceMaterial(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpSourceMaterial(form.value).then((res) => {
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
      return delPpSourceMaterial(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<源物料.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpSourceMaterial/export', { ...queryParams })
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