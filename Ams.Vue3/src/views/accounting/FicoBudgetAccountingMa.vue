<!--
 * @Descripttion: 预算科目/fico_budget_accounting_ma
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/7 8:08:11
 * @column：37
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="公司代码  " prop="fbasBukrs">
            <el-select filterable clearable v-model="queryParams.fbasBukrs"
              :placeholder="$t('btn.selectSearchPrefix')+'公司代码  '+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="预算科目  " prop="fbasFipls">
            <el-input v-model="queryParams.fbasFipls"
              :placeholder="$t('btn.enterSearchPrefix')+'预算科目  '+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="币种  " prop="fbasWaers">
            <el-select filterable clearable v-model="queryParams.fbasWaers"
              :placeholder="$t('btn.selectSearchPrefix')+'币种  '+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="会计科目  " prop="fbasSaknr">
            <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_accounting_title"
              :loading="loading " v-model="queryParams.fbasSaknr"
              :placeholder="$t('btn.selectSearchPrefix')+'会计科目  '+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   remotequery_sql_accounting_title " :key="item.dictValue"
                :label="item.dictLabel" :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="名称  " prop="fbasStext">
            <el-input v-model="queryParams.fbasStext"
              :placeholder="$t('btn.enterSearchPrefix')+'名称  '+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="长文本  " prop="fbasLtext">
            <el-input v-model="queryParams.fbasLtext"
              :placeholder="$t('btn.enterSearchPrefix')+'长文本  '+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="费用类型  " prop="fbasGvtyp">
            <el-select filterable clearable v-model="queryParams.fbasGvtyp"
              :placeholder="$t('btn.selectSearchPrefix')+'费用类型  '+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_exp_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="统驭科目  " prop="fbasMitkz">
            <el-select filterable clearable v-model="queryParams.fbasMitkz"
              :placeholder="$t('btn.selectSearchPrefix')+'统驭科目  '+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_conrol_title " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="冻结  " prop="fbasXspea">
            <el-radio-group v-model="queryParams.fbasXspea">
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetaccountingma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetaccountingma:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetaccountingma:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetaccountingma:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoBudgetAccountingMa/importTemplate"
                  importUrl="/Accounting/FicoBudgetAccountingMa/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:budgetaccountingma:export']">
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain icon="view" size="small" @click="rowClick(scope.row)"
            :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="fbasSfId" label="ID" align="center" v-if="columns.showColumn('fbasSfId')" />
      <el-table-column prop="fbasMandt" label="集团  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbasMandt')" />
      <el-table-column prop="fbasBukrs" label="公司代码  " align="center" v-if="columns.showColumn('fbasBukrs')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.fbasBukrs" />
        </template>
      </el-table-column>
      <el-table-column prop="fbasSpras" label="语言Key  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbasSpras')" />
      <el-table-column prop="fbasFipls" label="预算科目  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbasFipls')" />
      <el-table-column prop="fbasWaers" label="币种  " align="center" v-if="columns.showColumn('fbasWaers')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.fbasWaers" />
        </template>
      </el-table-column>
      <el-table-column prop="fbasSaknr" label="会计科目  " align="center" v-if="columns.showColumn('fbasSaknr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_accounting_title " :value="scope.row.fbasSaknr" />
        </template>
      </el-table-column>
      <el-table-column prop="fbasStext" label="名称  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbasStext')" />
      <el-table-column prop="fbasLtext" label="长文本  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbasLtext')" />
      <el-table-column prop="fbasAtext" label="附加文本  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fbasAtext')" />
      <el-table-column prop="fbasGvtyp" label="费用类型  " align="center" v-if="columns.showColumn('fbasGvtyp')">
        <template #default="scope">
          <dict-tag :options=" options.sys_exp_type " :value="scope.row.fbasGvtyp" />
        </template>
      </el-table-column>
      <el-table-column prop="fbasMitkz" label="统驭科目  " align="center" v-if="columns.showColumn('fbasMitkz')">
        <template #default="scope">
          <dict-tag :options=" options.sys_conrol_title " :value="scope.row.fbasMitkz" />
        </template>
      </el-table-column>
      <el-table-column prop="fbasXspea" label="冻结  " align="center" v-if="columns.showColumn('fbasXspea')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.fbasXspea" />
        </template>
      </el-table-column>
      <el-table-column prop="rEF01" label="预留A  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF01')" />
      <el-table-column prop="rEF02" label="预留B  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF02')" />
      <el-table-column prop="rEF03" label="预留C  " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF03')" />
      <el-table-column prop="rEF04" label="预留1  " align="center" v-if="columns.showColumn('rEF04')" />
      <el-table-column prop="rEF05" label="预留2  " align="center" v-if="columns.showColumn('rEF05')" />
      <el-table-column prop="rEF06" label="预留3 " align="center" v-if="columns.showColumn('rEF06')" />
      <el-table-column prop="remark" label="备注说明 " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:budgetaccountingma:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['fico:budgetaccountingma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ficoBudgetAccountingSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="fbasSfId" label="ID" />
        <el-table-column prop="fbasParentSfId" label="父ID  " />
        <el-table-column prop="fbasSpras" label="语言Key  " />
        <el-table-column prop="fbasFdpls" label="明细科目  " />
        <el-table-column prop="fbasStext" label="名称  " />
        <el-table-column prop="fbasLtext" label="长文本  " />
        <el-table-column prop="fbasAtext" label="附加文本  " />
        <el-table-column prop="fbasXspea" label="冻结  ">
          <template #default="scope">
            <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.fbasXspea" />
          </template>
        </el-table-column>
        <el-table-column prop="rEF01" label="预留A  " />
        <el-table-column prop="rEF02" label="预留B  " />
        <el-table-column prop="rEF03" label="预留C  " />
        <el-table-column prop="rEF04" label="预留1  " />
        <el-table-column prop="rEF05" label="预留2  " />
        <el-table-column prop="rEF06" label="预留3 " />
        <el-table-column prop="remark" label="备注说明 " />
      </el-table>
    </el-drawer>
    <!-- 添加或修改预算科目对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <!-- <el-col :lg="12">
                <el-form-item label="ID" prop="fbasSfId">
                  <el-input v-model.number="form.fbasSfId"
                    :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col> -->

              <el-col :lg="12">
                <el-form-item label="集团  " prop="fbasMandt">
                  <el-input v-model="form.fbasMandt" :placeholder="$t('btn.enterPrefix')+'集团  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="公司代码  " prop="fbasBukrs">
                  <el-select filterable clearable v-model="form.fbasBukrs"
                    :placeholder="$t('btn.selectPrefix')+'公司代码  '+$t('btn.selectSuffix')"
                    @change="handleFbasBukrsChange">
                    <el-option v-for="item in  options.sys_crop_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="语言Key  " prop="fbasSpras">
                  <el-input v-model="form.fbasSpras"
                    :placeholder="$t('btn.enterPrefix')+'语言Key  '+$t('btn.enterSuffix')" show-word-limit maxlength="255"
                    :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预算科目  " prop="fbasFipls">
                  <el-input v-model="form.fbasFipls" :placeholder="$t('btn.enterPrefix')+'预算科目  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" @input="handleFbasFiplsInput" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="币种  " prop="fbasWaers">
                  <el-select filterable clearable v-model="form.fbasWaers"
                    :placeholder="$t('btn.selectPrefix')+'币种  '+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="会计科目  " prop="fbasSaknr">
                  <el-select filterable clearable remote remote-show-suffix
                    :remote-method="remoteMethod_sql_accounting_title" :loading="loading " v-model="form.fbasSaknr"
                    :placeholder="$t('btn.selectPrefix')+'会计科目  '+$t('btn.selectSuffix')">
                    <el-option v-for="item in  remotequery_sql_accounting_title" :key="item.dictValue"
                      :label="item.dictLabel" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="名称  " prop="fbasStext">
                  <el-input v-model="form.fbasStext" :placeholder="$t('btn.enterPrefix')+'名称  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" @input="handleFbasStextInput" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="长文本  " prop="fbasLtext">
                  <el-input v-model="form.fbasLtext" :placeholder="$t('btn.enterPrefix')+'长文本  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="80" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="附加文本  " prop="fbasAtext">
                  <el-input v-model="form.fbasAtext" :placeholder="$t('btn.enterPrefix')+'附加文本  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="120" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="费用类型  " prop="fbasGvtyp">
                  <el-select filterable clearable v-model="form.fbasGvtyp"
                    :placeholder="$t('btn.selectPrefix')+'费用类型  '+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_exp_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="统驭科目  " prop="fbasMitkz">
                  <el-select filterable clearable v-model="form.fbasMitkz"
                    :placeholder="$t('btn.selectPrefix')+'统驭科目  '+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_conrol_title" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="冻结  " prop="fbasXspea">
                  <el-radio-group v-model="form.fbasXspea">
                    <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>







              <el-col :lg="24">
                <el-form-item label="备注说明 " prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注说明 '+$t('btn.enterSuffix')" show-word-limit
                    maxlength="500" />
                </el-form-item>
              </el-col>


            </el-row>
          </el-tab-pane>




          <el-tab-pane :label="$t('ptabs.content')" name="eighth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="预留A  " prop="rEF01">
                  <el-input v-model="form.rEF01" :placeholder="$t('btn.enterPrefix')+'预留A  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留B  " prop="rEF02">
                  <el-input v-model="form.rEF02" :placeholder="$t('btn.enterPrefix')+'预留B  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="预留C  " prop="rEF03">
                  <el-input v-model="form.rEF03" :placeholder="$t('btn.enterPrefix')+'预留C  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="30" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留1  " prop="rEF04">
                  <el-input-number v-model.number="form.rEF04" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留1  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留2  " prop="rEF05">
                  <el-input-number v-model.number="form.rEF05" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留2  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留3 " prop="rEF06">
                  <el-input-number v-model.number="form.rEF06" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留3 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.customization')" name="16th">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="自定义A  " prop="uDF01">
                  <el-input v-model="form.uDF01" :placeholder="$t('btn.enterPrefix')+'自定义A  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义B  " prop="uDF02">
                  <el-input v-model="form.uDF02" :placeholder="$t('btn.enterPrefix')+'自定义B  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义C  " prop="uDF03">
                  <el-input v-model="form.uDF03" :placeholder="$t('btn.enterPrefix')+'自定义C  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义D  " prop="uDF04">
                  <el-input v-model="form.uDF04" :placeholder="$t('btn.enterPrefix')+'自定义D  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义E  " prop="uDF05">
                  <el-input v-model="form.uDF05" :placeholder="$t('btn.enterPrefix')+'自定义E  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义F  " prop="uDF06">
                  <el-input v-model="form.uDF06" :placeholder="$t('btn.enterPrefix')+'自定义F  '+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义1  " prop="uDF51">
                  <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义1  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2  " prop="uDF52">
                  <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义2  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3  " prop="uDF53">
                  <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义3  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4  " prop="uDF54">
                  <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义4  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5  " prop="uDF55">
                  <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义5  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6  " prop="uDF56">
                  <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义6  '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.oper')" name="17th">
            <el-row :gutter="20">
              <el-col :lg="24">
                <el-form-item label="软删除 " prop="isDeleted">
                  <el-radio-group v-model="form.isDeleted">
                    <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>
              <el-col :lg="12">
                <el-form-item label="创建人员" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建人员'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')" :disabled="opertype != 3"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新人员" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新人员'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')" :disabled="opertype != 3"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
        </el-tabs>


        <!-- 子表信息 -->
        <el-divider content-position="center">明细科目</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddFicoBudgetAccountingSlv">{{ $t('btn.add')
              }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeleteFicoBudgetAccountingSlv">{{ $t('btn.delete')
              }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?
              $t('layout.headerExitfullscreen')
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ficoBudgetAccountingSlvList" :row-class-name="rowFicoBudgetAccountingSlvIndex"
          @selection-change="handleFicoBudgetAccountingSlvSelectionChange" ref="FicoBudgetAccountingSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50" />
          <el-table-column label="语言Key  " align="center" prop="fbasSpras">
            <template #default="scope">
              <el-input v-model="scope.row.fbasSpras"
                :placeholder="$t('btn.enterPrefix')+'语言Key  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="明细科目  " align="center" prop="fbasFdpls">
            <template #default="scope">
              <el-input v-model="scope.row.fbasFdpls"
                :placeholder="$t('btn.enterPrefix')+'明细科目  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="名称  " align="center" prop="fbasStext">
            <template #default="scope">
              <el-input v-model="scope.row.fbasStext"
                :placeholder="$t('btn.enterPrefix')+'名称  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="长文本  " align="center" prop="fbasLtext">
            <template #default="scope">
              <el-input v-model="scope.row.fbasLtext"
                :placeholder="$t('btn.enterPrefix')+'长文本  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="附加文本  " align="center" prop="fbasAtext">
            <template #default="scope">
              <el-input v-model="scope.row.fbasAtext"
                :placeholder="$t('btn.enterPrefix')+'附加文本  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="冻结  " prop="fbasXspea">
            <template #default="scope">
              <el-select filterable clearable v-model="scope.row.fbasXspea"
                :placeholder="$t('btn.enterPrefix')+'冻结  '+$t('btn.enterSuffix')">
                <el-option v-for="item in options.sys_freeze_flag" :key="item.dictValue" :label="item.dictLabel"
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <!-- <el-table-column label="预留A  " align="center" prop="rEF01">
            <template #default="scope">
              <el-input v-model="scope.row.rEF01" :placeholder="$t('btn.enterPrefix')+'预留A  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留B  " align="center" prop="rEF02">
            <template #default="scope">
              <el-input v-model="scope.row.rEF02" :placeholder="$t('btn.enterPrefix')+'预留B  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留C  " align="center" prop="rEF03">
            <template #default="scope">
              <el-input v-model="scope.row.rEF03" :placeholder="$t('btn.enterPrefix')+'预留C  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留1  " align="center" prop="rEF04" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.rEF04" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留1  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留2  " align="center" prop="rEF05" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.rEF05" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留2  '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留3 " align="center" prop="rEF06" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.rEF06" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留3 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column> -->
          <el-table-column label="备注说明 " align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注说明 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
        </el-table>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ficobudgetaccountingma">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoBudgetAccountingMa,
    addFicoBudgetAccountingMa, delFicoBudgetAccountingMa,
    updateFicoBudgetAccountingMa, getFicoBudgetAccountingMa,
  }
    from '@/api/accounting/ficobudgetaccountingma.js'
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
    fbasBukrs: undefined,
    //是否查询（1是）
    fbasFipls: undefined,
    //是否查询（1是）
    fbasWaers: undefined,
    //是否查询（1是）
    fbasSaknr: undefined,
    //是否查询（1是）
    fbasStext: undefined,
    //是否查询（1是）
    fbasLtext: undefined,
    //是否查询（1是）
    fbasGvtyp: undefined,
    //是否查询（1是）
    fbasMitkz: undefined,
    //是否查询（1是）
    fbasXspea: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'fbasSfId', label: 'ID' },
    { visible: true, prop: 'fbasMandt', label: '集团  ' },
    { visible: true, prop: 'fbasBukrs', label: '公司代码  ' },
    { visible: true, prop: 'fbasSpras', label: '语言Key  ' },
    { visible: true, prop: 'fbasFipls', label: '预算科目  ' },
    { visible: true, prop: 'fbasWaers', label: '币种  ' },
    { visible: true, prop: 'fbasSaknr', label: '会计科目  ' },
    { visible: true, prop: 'fbasStext', label: '名称  ' },
    { visible: true, prop: 'fbasLtext', label: '长文本  ' },
    { visible: true, prop: 'fbasAtext', label: '附加文本  ' },
    { visible: true, prop: 'fbasGvtyp', label: '费用类型  ' },
    { visible: true, prop: 'fbasMitkz', label: '统驭科目  ' },
    { visible: true, prop: 'fbasXspea', label: '冻结  ' },
    { visible: false, prop: 'rEF01', label: '预留A  ' },
    { visible: false, prop: 'rEF02', label: '预留B  ' },
    { visible: false, prop: 'rEF03', label: '预留C  ' },
    { visible: false, prop: 'rEF04', label: '预留1  ' },
    { visible: false, prop: 'rEF05', label: '预留2  ' },
    { visible: false, prop: 'rEF06', label: '预留3 ' },
    { visible: false, prop: 'remark', label: '备注说明 ' },
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
  const remotequeryList_sql_accounting_title = ref([])
  //定义远程搜索变量
  const remotequery_sql_accounting_title = ref([])
  //远程字典参数
  var remotedictParams_sql_accounting_title = [
    { dictType: "sql_accounting_title" },
  ]
  //远程搜索组件实例
  onMounted(() => {
    proxy.getDicts(remotedictParams_sql_accounting_title).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_accounting_title.value = element.list
      })
      //console.log(remotequeryList_sql_accounting_title)
    })
  })
  //远程搜索
  const remoteMethod_sql_accounting_title = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_accounting_title.value = remotequeryList_sql_accounting_title.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_accounting_title(query)
      }, 2000)
    } else {
      //默认显示前15条记录
      remotequery_sql_accounting_title.value.slice(0, 15)
    }
  }, 300)
  // 筛选方法
  const filterMethod_sql_accounting_title = debounce((query) => {
    let arr = remotequeryList_sql_accounting_title.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_accounting_title.value = arr.slice(0, 5)
      addFilterOptions_sql_accounting_title(query)
    } else {
      remotequery_sql_accounting_title.value = arr
    }
  }, 300)
  // 精准筛选方法
  const addFilterOptions_sql_accounting_title = debounce((dictValue) => {
    let target = remotequeryList_sql_accounting_title.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_accounting_title.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_accounting_title.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

  //字典参数
  var dictParams = [
    { dictType: "sys_crop_list" },
    { dictType: "sys_ccy_type" },
    { dictType: "sys_exp_type" },
    { dictType: "sys_conrol_title" },
    { dictType: "sys_freeze_flag" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从预算科目/fico_budget_accounting_ma表记录数据
  function getList() {
    loading.value = true
    listFicoBudgetAccountingMa(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.fbasSfId);
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
      fbasSfId: [{ required: true, message: "ID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    options: {
      // 公司代码   选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_crop_list: [],
      // 币种   选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
      // 费用类型   选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_exp_type: [],
      // 统驭科目   选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_conrol_title: [],
      // 冻结   选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_freeze_flag: [],
      // 软删除  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
      fbasSfId: 0,
      fbasMandt: null,
      fbasBukrs: null,
      fbasSpras: null,
      fbasFipls: null,
      fbasWaers: null,
      fbasSaknrChecked: [],
      fbasStext: null,
      fbasLtext: null,
      fbasAtext: null,
      fbasGvtyp: null,
      fbasMitkz: null,
      fbasXspea: 0,
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
      isDeleted: 0,
      remark: null,
      createBy: null,
      createTime: null,
      updateBy: null,
      updateTime: null,
    };
    ficoBudgetAccountingSlvList.value = []
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '预算科目'
    opertype.value = 1
    form.value.fbasMandt = '100'
    form.value.fbasBukrs = []
    form.value.fbasWaers = []
    form.value.fbasGvtyp = []
    form.value.fbasMitkz = []
    form.value.fbasXspea = 0
    form.value.rEF04 = 0
    form.value.rEF05 = 0
    form.value.rEF06 = 0
  }
  function handleFbasBukrsChange() {
    console.log(options.sys_crop_list)
  }
  function handleFbasFiplsInput() {
    form.value.fbasSpras = 'dict.bu_acc_title.' + form.value.fbasFipls
  }
  function handleFbasStextInput() {
    form.value.fbasLtext = form.value.fbasStext
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.fbasSfId || ids.value
    getFicoBudgetAccountingMa(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '预算科目'
        opertype.value = 2

        form.value = {
          ...data,
        }
        ficoBudgetAccountingSlvList.value = res.data.ficoBudgetAccountingSlvNav
      }
    })
  }

  // 添加&修改 表单提交
  function submitForm() {
    proxy.$refs["formRef"].validate((valid) => {
      if (valid) {

        form.value.ficoBudgetAccountingSlvNav = ficoBudgetAccountingSlvList.value
        if (form.value.fbasSfId != undefined && opertype.value === 2) {
          updateFicoBudgetAccountingMa(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addFicoBudgetAccountingMa(form.value).then((res) => {
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
    const Ids = row.fbasSfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delFicoBudgetAccountingMa(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<预算科目.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoBudgetAccountingMa/export', { ...queryParams })
      })
  }

  /*********************明细科目子表信息*************************/
  const ficoBudgetAccountingSlvList = ref([])
  const checkedFicoBudgetAccountingSlv = ref([])
  const fullScreen = ref(false)
  const drawer = ref(false)

  /** 明细科目序号 */
  function rowFicoBudgetAccountingSlvIndex({ row, rowIndex }) {
    row.index = rowIndex + 1;
  }

  /** 明细科目添加按钮操作 */
  function handleAddFicoBudgetAccountingSlv() {
    let obj = {};
    //下面的代码自己设置默认值
    //obj.fbasSpras = null;
    //obj.fbasFdpls = null;
    //obj.fbasStext = null;
    //obj.fbasLtext = null;
    //obj.fbasAtext = null;
    //obj.fbasXspea = null;
    //obj.rEF01 = null;
    //obj.rEF02 = null;
    //obj.rEF03 = null;
    //obj.rEF04 = null;
    //obj.rEF05 = null;
    //obj.rEF06 = null;
    //obj.remark = null;
    ficoBudgetAccountingSlvList.value.push(obj);
  }

  /** 复选框选中数据 */
  function handleFicoBudgetAccountingSlvSelectionChange(selection) {
    checkedFicoBudgetAccountingSlv.value = selection.map(item => item.index)
  }

  /** 明细科目删除按钮操作 */
  function handleDeleteFicoBudgetAccountingSlv() {
    if (checkedFicoBudgetAccountingSlv.value.length == 0) {
      proxy.$modal.msgError('请先选择要删除的明细科目数据')
    } else {
      const FicoBudgetAccountingSlvs = ficoBudgetAccountingSlvList.value;
      const checkedFicoBudgetAccountingSlvs = checkedFicoBudgetAccountingSlv.value;
      ficoBudgetAccountingSlvList.value = FicoBudgetAccountingSlvs.filter(function (item) {
        return checkedFicoBudgetAccountingSlvs.indexOf(item.index) == -1
      });
    }
  }

  /** 明细科目详情 */
  function rowClick(row) {
    const id = row.fbasSfId || ids.value
    getFicoBudgetAccountingMa(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        drawer.value = true
        ficoBudgetAccountingSlvList.value = data.ficoBudgetAccountingSlvNav
      }
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