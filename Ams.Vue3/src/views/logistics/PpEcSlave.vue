<!--
 * @Descripttion: 从设变/pp_ec_slave
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 16:30:08
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="设变No." prop="ecsEcNo">
        <el-input v-model="queryParams.ecsEcNo" :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="ecsModel">
        <el-input v-model="queryParams.ecsModel" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="ecsItem">
        <el-input v-model="queryParams.ecsItem" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="子物料" prop="ecsSubItem">
        <el-input v-model="queryParams.ecsSubItem" :placeholder="$t('btn.enterSearchPrefix')+'子物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="旧物料" prop="ecsOldItem">
        <el-input v-model="queryParams.ecsOldItem" :placeholder="$t('btn.enterSearchPrefix')+'旧物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="采购类型" prop="ecsPurType">
        <el-select filterable clearable   v-model="queryParams.ecsPurType" :placeholder="$t('btn.selectSearchPrefix')+'采购类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购组" prop="ecsPurGroup">
        <el-select filterable clearable   v-model="queryParams.ecsPurGroup" :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="仓库" prop="ecsSloc">
        <el-select filterable clearable   v-model="queryParams.ecsSloc" :placeholder="$t('btn.selectSearchPrefix')+'仓库'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验否" prop="ecsInsmk">
        <el-select filterable clearable   v-model="queryParams.ecsInsmk" :placeholder="$t('btn.selectSearchPrefix')+'检验否'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工厂状态" prop="ecsPlntStated">
        <el-select filterable clearable   v-model="queryParams.ecsPlntStated" :placeholder="$t('btn.selectSearchPrefix')+'工厂状态'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_eol_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="SOP" prop="ecsSopStated">
        <el-select filterable clearable   v-model="queryParams.ecsSopStated" :placeholder="$t('btn.selectSearchPrefix')+'SOP'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="实施标记" prop="ecsImplStated">
        <el-select filterable clearable   v-model="queryParams.ecsImplStated" :placeholder="$t('btn.selectSearchPrefix')+'实施标记'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:ecslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:ecslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:ecslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecslave:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpEcSlave/importTemplate"
                  importUrl="/Logistics/PpEcSlave/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecslave:export']">
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
      <el-table-column prop="ecsSfid" label="ID" align="center" v-if="columns.showColumn('ecsSfid')"/>
      <el-table-column prop="ecsParentSfid" label="父ID" align="center" v-if="columns.showColumn('ecsParentSfid')"/>
      <el-table-column prop="ecsEcNo" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsEcNo')"/>
      <el-table-column prop="ecsModel" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsModel')"/>
      <el-table-column prop="ecsItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsItem')"/>
      <el-table-column prop="ecsItemText" label="物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsItemText')"/>
      <el-table-column prop="ecsSubItem" label="子物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsSubItem')"/>
      <el-table-column prop="ecsSubItemText" label="子物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsSubItemText')"/>
      <el-table-column prop="ecsOldItem" label="旧物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsOldItem')"/>
      <el-table-column prop="ecsOldItemText" label="旧文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsOldItemText')"/>
      <el-table-column prop="ecsOldCurrStock" label="旧品库存" align="center" v-if="columns.showColumn('ecsOldCurrStock')"/>
      <el-table-column prop="ecsOldUsageQty" label="用量" align="center" v-if="columns.showColumn('ecsOldUsageQty')"/>
      <el-table-column prop="ecsOldSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsOldSetLoc')"/>
      <el-table-column prop="ecsNewItem" label="新物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsNewItem')"/>
      <el-table-column prop="ecsNewItemText" label="新文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsNewItemText')"/>
      <el-table-column prop="ecsNewCurrStock" label="新品库存" align="center" v-if="columns.showColumn('ecsNewCurrStock')"/>
      <el-table-column prop="ecsNewUsageQty" label="用量" align="center" v-if="columns.showColumn('ecsNewUsageQty')"/>
      <el-table-column prop="ecsNewSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsNewSetLoc')"/>
      <el-table-column prop="ecsBomNo" label="bom番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsBomNo')"/>
      <el-table-column prop="ecsChange" label="互换" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsChange')"/>
      <el-table-column prop="ecsDistLocal" label="区分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsDistLocal')"/>
      <el-table-column prop="ecsInstNote" label="指示" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsInstNote')"/>
      <el-table-column prop="ecsOldProcess" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsOldProcess')"/>
      <el-table-column prop="ecsBomDate" label="bom日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsBomDate')"/>
      <el-table-column prop="ecsPurType" label="采购类型" align="center" v-if="columns.showColumn('ecsPurType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_type " :value="scope.row.ecsPurType"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecsPurGroup" label="采购组" align="center" v-if="columns.showColumn('ecsPurGroup')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.ecsPurGroup"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecsSloc" label="仓库" align="center" v-if="columns.showColumn('ecsSloc')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.ecsSloc"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecsInsmk" label="检验否" align="center" v-if="columns.showColumn('ecsInsmk')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecsInsmk"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecsPlntStated" label="工厂状态" align="center" v-if="columns.showColumn('ecsPlntStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_list " :value="scope.row.ecsPlntStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecsSopStated" label="SOP" align="center" v-if="columns.showColumn('ecsSopStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecsSopStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecsImplStated" label="实施标记" align="center" v-if="columns.showColumn('ecsImplStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecsImplStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecsPurEnteredDate" label="采购登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsPurEnteredDate')"/>
      <el-table-column prop="ecsPurSupplier" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPurSupplier')"/>
      <el-table-column prop="ecsPurOrder" label="采购PO" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPurOrder')"/>
      <el-table-column prop="ecsPurNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPurNote')"/>
      <el-table-column prop="ecsPmcEnteredDate" label="生管登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsPmcEnteredDate')"/>
      <el-table-column prop="ecsPmcPreLot" label="预投入批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPmcPreLot')"/>
      <el-table-column prop="ecsPmcDisposal" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPmcDisposal')"/>
      <el-table-column prop="ecsPmcNote" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPmcNote')"/>
      <el-table-column prop="ecsIqcEnteredDate" label="IQC登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsIqcEnteredDate')"/>
      <el-table-column prop="ecsIqcOrder" label="检验订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsIqcOrder')"/>
      <el-table-column prop="ecsIqcNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsIqcNote')"/>
      <el-table-column prop="ecsMmEnteredDate" label="部管登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsMmEnteredDate')"/>
      <el-table-column prop="ecsMmLot" label="领用批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsMmLot')"/>
      <el-table-column prop="ecsMmProOrder" label="工单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsMmProOrder')"/>
      <el-table-column prop="ecsMmNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsMmNote')"/>
      <el-table-column prop="ecsAssyEnteredDate" label="制一登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsAssyEnteredDate')"/>
      <el-table-column prop="ecsAssyLine" label="班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsAssyLine')"/>
      <el-table-column prop="ecsAssyPutLot" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsAssyPutLot')"/>
      <el-table-column prop="ecsAssyNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsAssyNote')"/>
      <el-table-column prop="ecsPcbaEnteredDate" label="制二登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsPcbaEnteredDate')"/>
      <el-table-column prop="ecsPcbaLine" label="Pcba班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPcbaLine')"/>
      <el-table-column prop="ecsPcbaPutLot" label="Pcba批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPcbaPutLot')"/>
      <el-table-column prop="ecsPcbaNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsPcbaNote')"/>
      <el-table-column prop="ecsFqcEnteredDate" label="QA确认日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecsFqcEnteredDate')"/>
      <el-table-column prop="ecsFqcImplLot" label="检验批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsFqcImplLot')"/>
      <el-table-column prop="ecsFqcNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecsFqcNote')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:ecslave:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:ecslave:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改从设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="ID" prop="ecsSfid">
              <el-input-number v-model.number="form.ecsSfid" controls-position="right" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')" :disabled="true"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="ecsParentSfid">
              <el-input v-model.number="form.ecsParentSfid" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="ecsEcNo">
              <el-input v-model="form.ecsEcNo" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="ecsModel">
              <el-input v-model="form.ecsModel" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="ecsItem">
              <el-input v-model="form.ecsItem" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料文本" prop="ecsItemText">
              <el-input v-model="form.ecsItemText" :placeholder="$t('btn.enterPrefix')+'物料文本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="子物料" prop="ecsSubItem">
              <el-input v-model="form.ecsSubItem" :placeholder="$t('btn.enterPrefix')+'子物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="子物料文本" prop="ecsSubItemText">
              <el-input v-model="form.ecsSubItemText" :placeholder="$t('btn.enterPrefix')+'子物料文本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料" prop="ecsOldItem">
              <el-input v-model="form.ecsOldItem" :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧文本" prop="ecsOldItemText">
              <el-input v-model="form.ecsOldItemText" :placeholder="$t('btn.enterPrefix')+'旧文本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品库存" prop="ecsOldCurrStock">
              <el-input-number v-model.number="form.ecsOldCurrStock" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'旧品库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="ecsOldUsageQty">
              <el-input-number v-model.number="form.ecsOldUsageQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="ecsOldSetLoc">
              <el-input v-model="form.ecsOldSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="ecsNewItem">
              <el-input v-model="form.ecsNewItem" :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新文本" prop="ecsNewItemText">
              <el-input v-model="form.ecsNewItemText" :placeholder="$t('btn.enterPrefix')+'新文本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新品库存" prop="ecsNewCurrStock">
              <el-input-number v-model.number="form.ecsNewCurrStock" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'新品库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="ecsNewUsageQty">
              <el-input-number v-model.number="form.ecsNewUsageQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="ecsNewSetLoc">
              <el-input v-model="form.ecsNewSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom番号" prop="ecsBomNo">
              <el-input v-model="form.ecsBomNo" :placeholder="$t('btn.enterPrefix')+'bom番号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="互换" prop="ecsChange">
              <el-input v-model="form.ecsChange" :placeholder="$t('btn.enterPrefix')+'互换'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="区分" prop="ecsDistLocal">
              <el-input v-model="form.ecsDistLocal" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="指示" prop="ecsInstNote">
              <el-input v-model="form.ecsInstNote" :placeholder="$t('btn.enterPrefix')+'指示'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品处理" prop="ecsOldProcess">
              <el-input v-model="form.ecsOldProcess" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom日期" prop="ecsBomDate">
              <el-date-picker v-model="form.ecsBomDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购类型" prop="ecsPurType">
              <el-select filterable clearable   v-model="form.ecsPurType"  :placeholder="$t('btn.selectPrefix')+'采购类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购组" prop="ecsPurGroup">
              <el-select filterable clearable   v-model="form.ecsPurGroup"  :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="仓库" prop="ecsSloc">
              <el-select filterable clearable   v-model="form.ecsSloc"  :placeholder="$t('btn.selectPrefix')+'仓库'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验否" prop="ecsInsmk">
              <el-select filterable clearable   v-model="form.ecsInsmk"  :placeholder="$t('btn.selectPrefix')+'检验否'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工厂状态" prop="ecsPlntStated">
              <el-select filterable clearable   v-model="form.ecsPlntStated"  :placeholder="$t('btn.selectPrefix')+'工厂状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_eol_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="SOP" prop="ecsSopStated">
              <el-select filterable clearable   v-model="form.ecsSopStated"  :placeholder="$t('btn.selectPrefix')+'SOP'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="实施标记" prop="ecsImplStated">
              <el-select filterable clearable   v-model="form.ecsImplStated"  :placeholder="$t('btn.selectPrefix')+'实施标记'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购登入日期" prop="ecsPurEnteredDate">
              <el-date-picker v-model="form.ecsPurEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商" prop="ecsPurSupplier">
              <el-input v-model="form.ecsPurSupplier" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购PO" prop="ecsPurOrder">
              <el-input v-model="form.ecsPurOrder" :placeholder="$t('btn.enterPrefix')+'采购PO'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="ecsPurNote">
              <el-input v-model="form.ecsPurNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管登入日期" prop="ecsPmcEnteredDate">
              <el-date-picker v-model="form.ecsPmcEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预投入批次" prop="ecsPmcPreLot">
              <el-input v-model="form.ecsPmcPreLot" :placeholder="$t('btn.enterPrefix')+'预投入批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品处理" prop="ecsPmcDisposal">
              <el-input v-model="form.ecsPmcDisposal" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="ecsPmcNote">
              <el-input v-model="form.ecsPmcNote" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC登入日期" prop="ecsIqcEnteredDate">
              <el-date-picker v-model="form.ecsIqcEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验订单" prop="ecsIqcOrder">
              <el-input v-model="form.ecsIqcOrder" :placeholder="$t('btn.enterPrefix')+'检验订单'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="ecsIqcNote">
              <el-input v-model="form.ecsIqcNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="部管登入日期" prop="ecsMmEnteredDate">
              <el-date-picker v-model="form.ecsMmEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="领用批次" prop="ecsMmLot">
              <el-input v-model="form.ecsMmLot" :placeholder="$t('btn.enterPrefix')+'领用批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单" prop="ecsMmProOrder">
              <el-input v-model="form.ecsMmProOrder" :placeholder="$t('btn.enterPrefix')+'工单'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="ecsMmNote">
              <el-input v-model="form.ecsMmNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制一登入日期" prop="ecsAssyEnteredDate">
              <el-date-picker v-model="form.ecsAssyEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组" prop="ecsAssyLine">
              <el-input v-model="form.ecsAssyLine" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="ecsAssyPutLot">
              <el-input v-model="form.ecsAssyPutLot" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="ecsAssyNote">
              <el-input v-model="form.ecsAssyNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制二登入日期" prop="ecsPcbaEnteredDate">
              <el-date-picker v-model="form.ecsPcbaEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Pcba班组" prop="ecsPcbaLine">
              <el-input v-model="form.ecsPcbaLine" :placeholder="$t('btn.enterPrefix')+'Pcba班组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Pcba批次" prop="ecsPcbaPutLot">
              <el-input v-model="form.ecsPcbaPutLot" :placeholder="$t('btn.enterPrefix')+'Pcba批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="ecsPcbaNote">
              <el-input v-model="form.ecsPcbaNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QA确认日期" prop="ecsFqcEnteredDate">
              <el-date-picker v-model="form.ecsFqcEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验批次" prop="ecsFqcImplLot">
              <el-input v-model="form.ecsFqcImplLot" :placeholder="$t('btn.enterPrefix')+'检验批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="ecsFqcNote">
              <el-input v-model="form.ecsFqcNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
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
              <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ppecslave">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpEcSlave,
 addPpEcSlave, delPpEcSlave, 
 updatePpEcSlave,getPpEcSlave, 
 } 
from '@/api/logistics/ppecslave.js'
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
  ecsEcNo: undefined,
//是否查询（1是）
  ecsModel: undefined,
//是否查询（1是）
  ecsItem: undefined,
//是否查询（1是）
  ecsSubItem: undefined,
//是否查询（1是）
  ecsOldItem: undefined,
//是否查询（1是）
  ecsPurType: undefined,
//是否查询（1是）
  ecsPurGroup: undefined,
//是否查询（1是）
  ecsSloc: undefined,
//是否查询（1是）
  ecsInsmk: undefined,
//是否查询（1是）
  ecsPlntStated: undefined,
//是否查询（1是）
  ecsSopStated: undefined,
//是否查询（1是）
  ecsImplStated: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'ecsSfid', label: 'ID' },
  { visible: true, prop: 'ecsParentSfid', label: '父ID' },
  { visible: true, prop: 'ecsEcNo', label: '设变No.' },
  { visible: true, prop: 'ecsModel', label: '机种' },
  { visible: true, prop: 'ecsItem', label: '物料' },
  { visible: true, prop: 'ecsItemText', label: '物料文本' },
  { visible: true, prop: 'ecsSubItem', label: '子物料' },
  { visible: true, prop: 'ecsSubItemText', label: '子物料文本' },
  { visible: false, prop: 'ecsOldItem', label: '旧物料' },
  { visible: false, prop: 'ecsOldItemText', label: '旧文本' },
  { visible: false, prop: 'ecsOldCurrStock', label: '旧品库存' },
  { visible: false, prop: 'ecsOldUsageQty', label: '用量' },
  { visible: false, prop: 'ecsOldSetLoc', label: '位置' },
  { visible: false, prop: 'ecsNewItem', label: '新物料' },
  { visible: false, prop: 'ecsNewItemText', label: '新文本' },
  { visible: false, prop: 'ecsNewCurrStock', label: '新品库存' },
  { visible: false, prop: 'ecsNewUsageQty', label: '用量' },
  { visible: false, prop: 'ecsNewSetLoc', label: '位置' },
  { visible: false, prop: 'ecsBomNo', label: 'bom番号' },
  { visible: false, prop: 'ecsChange', label: '互换' },
  { visible: false, prop: 'ecsDistLocal', label: '区分' },
  { visible: false, prop: 'ecsInstNote', label: '指示' },
  { visible: false, prop: 'ecsOldProcess', label: '旧品处理' },
  { visible: false, prop: 'ecsBomDate', label: 'bom日期' },
  { visible: false, prop: 'ecsPurType', label: '采购类型' },
  { visible: false, prop: 'ecsPurGroup', label: '采购组' },
  { visible: false, prop: 'ecsSloc', label: '仓库' },
  { visible: false, prop: 'ecsInsmk', label: '检验否' },
  { visible: false, prop: 'ecsPlntStated', label: '工厂状态' },
  { visible: false, prop: 'ecsSopStated', label: 'SOP' },
  { visible: false, prop: 'ecsImplStated', label: '实施标记' },
  { visible: false, prop: 'ecsPurEnteredDate', label: '采购登入日期' },
  { visible: false, prop: 'ecsPurSupplier', label: '供应商' },
  { visible: false, prop: 'ecsPurOrder', label: '采购PO' },
  { visible: false, prop: 'ecsPurNote', label: '说明' },
  { visible: false, prop: 'ecsPmcEnteredDate', label: '生管登入日期' },
  { visible: false, prop: 'ecsPmcPreLot', label: '预投入批次' },
  { visible: false, prop: 'ecsPmcDisposal', label: '旧品处理' },
  { visible: false, prop: 'ecsPmcNote', label: '备注' },
  { visible: false, prop: 'ecsIqcEnteredDate', label: 'IQC登入日期' },
  { visible: false, prop: 'ecsIqcOrder', label: '检验订单' },
  { visible: false, prop: 'ecsIqcNote', label: '说明' },
  { visible: false, prop: 'ecsMmEnteredDate', label: '部管登入日期' },
  { visible: false, prop: 'ecsMmLot', label: '领用批次' },
  { visible: false, prop: 'ecsMmProOrder', label: '工单' },
  { visible: false, prop: 'ecsMmNote', label: '说明' },
  { visible: false, prop: 'ecsAssyEnteredDate', label: '制一登入日期' },
  { visible: false, prop: 'ecsAssyLine', label: '班组' },
  { visible: false, prop: 'ecsAssyPutLot', label: '生产批次' },
  { visible: false, prop: 'ecsAssyNote', label: '说明' },
  { visible: false, prop: 'ecsPcbaEnteredDate', label: '制二登入日期' },
  { visible: false, prop: 'ecsPcbaLine', label: 'Pcba班组' },
  { visible: false, prop: 'ecsPcbaPutLot', label: 'Pcba批次' },
  { visible: false, prop: 'ecsPcbaNote', label: '说明' },
  { visible: false, prop: 'ecsFqcEnteredDate', label: 'QA确认日期' },
  { visible: false, prop: 'ecsFqcImplLot', label: '检验批次' },
  { visible: false, prop: 'ecsFqcNote', label: '说明' },
  { visible: false, prop: 'remark', label: '备注' },
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

//字典参数
var dictParams = [
  { dictType: "sys_pur_type" },
  { dictType: "sys_pur_group" },
  { dictType: "sys_sloc_list" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_eol_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从从设变/pp_ec_slave表记录数据
function getList(){
  loading.value = true
  listPpEcSlave(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.ecsSfid);
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
    ecsSfid: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    ecsParentSfid: [{ required: true, message: "父ID"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ecsEcNo: [{ required: true, message: "设变No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsModel: [{ required: true, message: "机种"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsItem: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsItemText: [{ required: true, message: "物料文本"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsOldCurrStock: [{ required: true, message: "旧品库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsOldUsageQty: [{ required: true, message: "用量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsNewCurrStock: [{ required: true, message: "新品库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsNewUsageQty: [{ required: true, message: "用量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsBomDate: [{ required: true, message: "bom日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecsPurType: [{ required: true, message: "采购类型"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ecsPurGroup: [{ required: true, message: "采购组"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ecsSloc: [{ required: true, message: "仓库"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ecsSopStated: [{ required: true, message: "SOP"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    ecsImplStated: [{ required: true, message: "实施标记"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_type: [],
    // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_group: [],
    // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_sloc_list: [],
    // 检验否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_flag_list: [],
    // 工厂状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_eol_list: [],
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
    ecsSfid: 0,
    ecsParentSfid: 0,
    ecsEcNo: null,
    ecsModel: null,
    ecsItem: null,
    ecsItemText: null,
    ecsSubItem: null,
    ecsSubItemText: null,
    ecsOldItem: null,
    ecsOldItemText: null,
    ecsOldCurrStock: 0,
    ecsOldUsageQty: 0,
    ecsOldSetLoc: null,
    ecsNewItem: null,
    ecsNewItemText: null,
    ecsNewCurrStock: 0,
    ecsNewUsageQty: 0,
    ecsNewSetLoc: null,
    ecsBomNo: null,
    ecsChange: null,
    ecsDistLocal: null,
    ecsInstNote: null,
    ecsOldProcess: null,
    ecsBomDate: null,
    ecsPurType: null,
    ecsPurGroup: null,
    ecsSloc: null,
    ecsInsmk: null,
    ecsPlntStated: null,
    ecsSopStated: 0,
    ecsImplStated: 0,
    ecsPurEnteredDate: null,
    ecsPurSupplier: null,
    ecsPurOrder: null,
    ecsPurNote: null,
    ecsPmcEnteredDate: null,
    ecsPmcPreLot: null,
    ecsPmcDisposal: null,
    ecsPmcNote: null,
    ecsIqcEnteredDate: null,
    ecsIqcOrder: null,
    ecsIqcNote: null,
    ecsMmEnteredDate: null,
    ecsMmLot: null,
    ecsMmProOrder: null,
    ecsMmNote: null,
    ecsAssyEnteredDate: null,
    ecsAssyLine: null,
    ecsAssyPutLot: null,
    ecsAssyNote: null,
    ecsPcbaEnteredDate: null,
    ecsPcbaLine: null,
    ecsPcbaPutLot: null,
    ecsPcbaNote: null,
    ecsFqcEnteredDate: null,
    ecsFqcImplLot: null,
    ecsFqcNote: null,
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
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'从设变'
  opertype.value = 1
  form.value.ecsOldCurrStock= 0
  form.value.ecsOldUsageQty= 0
  form.value.ecsNewCurrStock= 0
  form.value.ecsNewUsageQty= 0
  form.value.ecsBomDate= new Date()
  form.value.ecsPurType= []
  form.value.ecsPurGroup= []
  form.value.ecsSloc= []
  form.value.ecsInsmk= []
  form.value.ecsPlntStated= []
  form.value.ecsSopStated= 0
  form.value.ecsImplStated= 0
  form.value.ecsPurEnteredDate= new Date()
  form.value.ecsPmcEnteredDate= new Date()
  form.value.ecsIqcEnteredDate= new Date()
  form.value.ecsMmEnteredDate= new Date()
  form.value.ecsAssyEnteredDate= new Date()
  form.value.ecsPcbaEnteredDate= new Date()
  form.value.ecsFqcEnteredDate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.ecsSfid || ids.value
  getPpEcSlave(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '从设变'
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

      if (form.value.ecsSfid != undefined && opertype.value === 2) {
        updatePpEcSlave(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpEcSlave(form.value).then((res) => {
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
  const Ids = row.ecsSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpEcSlave(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<从设变.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpEcSlave/export', { ...queryParams })
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