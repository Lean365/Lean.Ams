<!--
 * @Descripttion: 从设变/pp_ec_slave
 * @Version: 0.24.508.21631
 * @Author: Lean365(Davis.Ching)(Davis.Ching)
 * @Date: 2024/5/23 8:52:11
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-form-item label="输入日">
        <el-date-picker
          v-model="dateRangeEsEntryDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="设变No." prop="esEcNo">
        <el-input v-model="queryParams.esEcNo" :placeholder="$t('btn.enter')+'设变No.'" />
      </el-form-item>
      <el-form-item label="机种" prop="esModel">
        <el-input v-model="queryParams.esModel" :placeholder="$t('btn.enter')+'机种'" />
      </el-form-item>
      <el-form-item label="物料" prop="esItem">
        <el-input v-model="queryParams.esItem" :placeholder="$t('btn.enter')+'物料'" />
      </el-form-item>
      <el-form-item label="旧物料" prop="esOldItem">
        <el-input v-model="queryParams.esOldItem" :placeholder="$t('btn.enter')+'旧物料'" />
      </el-form-item>
      <el-form-item label="新物料" prop="esNewItem">
        <el-input v-model="queryParams.esNewItem" :placeholder="$t('btn.enter')+'新物料'" />
      </el-form-item>
      <el-form-item label="实施部门" prop="emEcImpDept">
        <el-select filterable clearable   v-model="queryParams.emEcImpDept" :placeholder="$t('btn.select')+'实施部门'">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购类型" prop="esPurType">
        <el-select filterable clearable   v-model="queryParams.esPurType" :placeholder="$t('btn.select')+'采购类型'">
          <el-option v-for="item in   options.app_pur_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="仓库" prop="esSloc">
        <el-select filterable clearable   v-model="queryParams.esSloc" :placeholder="$t('btn.select')+'仓库'">
          <el-option v-for="item in   options.app_sloc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验否" prop="esInsmk">
        <el-radio-group v-model="queryParams.esInsmk">
          <el-radio>{{$t('layout.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_yes_no " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="工厂状态" prop="esMstae">
        <el-radio-group v-model="queryParams.esMstae">
          <el-radio>{{$t('layout.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_yes_no " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="SOP" prop="esSopStae">
        <el-radio-group v-model="queryParams.esSopStae">
          <el-radio>{{$t('layout.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_yes_no " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="add" v-hasPermi="['pp:ecslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="edit" :disabled="single" v-hasPermi="['pp:ecslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="deletebatch" :disabled="multiple" v-hasPermi="['pp:ecslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecslave:import']">
          <el-button type="import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="logistics/PpEcSlave/importTemplate"
                  importUrl="/logistics/PpEcSlave/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="export" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecslave:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="650"
      :data="dataList"
      v-loading="loading"
      ref="table"
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="esSFID" label="SFID" align="center" v-if="columns.showColumn('esSFID')"/>
      <el-table-column prop="esEntryDate" label="输入日" :show-overflow-tooltip="true"  v-if="columns.showColumn('esEntryDate')"/>
      <el-table-column prop="esEcNo" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esEcNo')"/>
      <el-table-column prop="esModel" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esModel')"/>
      <el-table-column prop="esItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esItem')"/>
      <el-table-column prop="esSubItem" label="子物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esSubItem')"/>
      <el-table-column prop="esOldItem" label="旧物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldItem')"/>
      <el-table-column prop="esOldItemText" label="旧文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldItemText')"/>
      <el-table-column prop="esOldUsageQty" label="用量" align="center" v-if="columns.showColumn('esOldUsageQty')"/>
      <el-table-column prop="esOldSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldSetLoc')"/>
      <el-table-column prop="esNewItem" label="新物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esNewItem')"/>
      <el-table-column prop="esNewItemText" label="新文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esNewItemText')"/>
      <el-table-column prop="esNewUsageQty" label="用量" align="center" v-if="columns.showColumn('esNewUsageQty')"/>
      <el-table-column prop="esNewSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esNewSetLoc')"/>
      <el-table-column prop="esBomNo" label="bom番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esBomNo')"/>
      <el-table-column prop="esChange" label="互换" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esChange')"/>
      <el-table-column prop="eslocal" label="区分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eslocal')"/>
      <el-table-column prop="esnote" label="指示" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esnote')"/>
      <el-table-column prop="esOldProcess" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esOldProcess')"/>
      <el-table-column prop="esBomDate" label="bom日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esBomDate')"/>
      <el-table-column prop="emEcImpDept" label="实施部门" align="center" v-if="columns.showColumn('emEcImpDept')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.emEcImpDept"  />
        </template>
      </el-table-column>
      <el-table-column prop="esPurType" label="采购类型" align="center" v-if="columns.showColumn('esPurType')">
        <template #default="scope">
          <dict-tag :options=" options.app_pur_type " :value="scope.row.esPurType"  />
        </template>
      </el-table-column>
      <el-table-column prop="esSloc" label="仓库" align="center" v-if="columns.showColumn('esSloc')">
        <template #default="scope">
          <dict-tag :options=" options.app_sloc_list " :value="scope.row.esSloc"  />
        </template>
      </el-table-column>
      <el-table-column prop="esInsmk" label="检验否" align="center" v-if="columns.showColumn('esInsmk')">
        <template #default="scope">
          <dict-tag :options=" options.sys_yes_no " :value="scope.row.esInsmk"  />
        </template>
      </el-table-column>
      <el-table-column prop="esMstae" label="工厂状态" align="center" v-if="columns.showColumn('esMstae')">
        <template #default="scope">
          <dict-tag :options=" options.sys_yes_no " :value="scope.row.esMstae"  />
        </template>
      </el-table-column>
      <el-table-column prop="esSopStae" label="SOP" align="center" v-if="columns.showColumn('esSopStae')">
        <template #default="scope">
          <dict-tag :options=" options.sys_yes_no " :value="scope.row.esSopStae"  />
        </template>
      </el-table-column>
      <el-table-column prop="esOldCurrStock" label="旧品库存" align="center" v-if="columns.showColumn('esOldCurrStock')"/>
      <el-table-column prop="esNewCurrStock" label="新品库存" align="center" v-if="columns.showColumn('esNewCurrStock')"/>
      <el-table-column prop="esPurEntryDate" label="采购登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPurEntryDate')"/>
      <el-table-column prop="esSupplier" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esSupplier')"/>
      <el-table-column prop="esPurOrder" label="采购PO" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPurOrder')"/>
      <el-table-column prop="esPurNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPurNote')"/>
      <el-table-column prop="esPurCreator" label="采购新增" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPurCreator')"/>
      <el-table-column prop="esPurCreateTime" label="采购新增日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPurCreateTime')"/>
      <el-table-column prop="esPurModifier" label="采购修改" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPurModifier')"/>
      <el-table-column prop="esPurModifyTime" label="采购修改日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPurModifyTime')"/>
      <el-table-column prop="esPmcEntryDate" label="生管登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPmcEntryDate')"/>
      <el-table-column prop="esPmcLot" label="预投入批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcLot')"/>
      <el-table-column prop="esPmcMemo" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcMemo')"/>
      <el-table-column prop="esPmcNote" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcNote')"/>
      <el-table-column prop="esPmcCreator" label="生管新增" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcCreator')"/>
      <el-table-column prop="esPmcCreateTime" label="生管新增日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPmcCreateTime')"/>
      <el-table-column prop="esPmcModifier" label="生管修改" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPmcModifier')"/>
      <el-table-column prop="esPmcModifyTime" label="生管修改日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPmcModifyTime')"/>
      <el-table-column prop="esIqcEntryDate" label="IQC登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esIqcEntryDate')"/>
      <el-table-column prop="esIqcOrder" label="检验订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esIqcOrder')"/>
      <el-table-column prop="esIqcNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esIqcNote')"/>
      <el-table-column prop="esIqcCreator" label="IQC新增" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esIqcCreator')"/>
      <el-table-column prop="esIqcCreateTime" label="IQC新增日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esIqcCreateTime')"/>
      <el-table-column prop="esIqcModifier" label="IQC修改" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esIqcModifier')"/>
      <el-table-column prop="esIqcModifyTime" label="IQC修改日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esIqcModifyTime')"/>
      <el-table-column prop="esMmEntryDate" label="部管登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esMmEntryDate')"/>
      <el-table-column prop="esMmLot" label="领用批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmLot')"/>
      <el-table-column prop="esMmMocNo" label="工单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmMocNo')"/>
      <el-table-column prop="esMmNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmNote')"/>
      <el-table-column prop="esMmCreator" label="EsMmCreator" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmCreator')"/>
      <el-table-column prop="esMmCreateTime" label="EsMmCreateTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esMmCreateTime')"/>
      <el-table-column prop="esMmModifier" label="EsMmModifier" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esMmModifier')"/>
      <el-table-column prop="esMmModifyTime" label="EsMmModifyTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esMmModifyTime')"/>
      <el-table-column prop="esPpEntryDate" label="制一登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPpEntryDate')"/>
      <el-table-column prop="esPpLine" label="班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpLine')"/>
      <el-table-column prop="esPpLot" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpLot')"/>
      <el-table-column prop="esPpNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpNote')"/>
      <el-table-column prop="esPpCreator" label="EsPpCreator" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpCreator')"/>
      <el-table-column prop="esPpCreateTime" label="EsPpCreateTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPpCreateTime')"/>
      <el-table-column prop="esPpModifier" label="EsPpModifier" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPpModifier')"/>
      <el-table-column prop="esPpModifyTime" label="EsPpModifyTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPpModifyTime')"/>
      <el-table-column prop="esPcbaEntryDate" label="制二登入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPcbaEntryDate')"/>
      <el-table-column prop="esPcbaLine" label="Pcba班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaLine')"/>
      <el-table-column prop="esPcbaLot" label="Pcba批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaLot')"/>
      <el-table-column prop="esPcbaNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaNote')"/>
      <el-table-column prop="esPcbaCreator" label="EsPcbaCreator" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaCreator')"/>
      <el-table-column prop="esPcbaCreateTime" label="EsPcbaCreateTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPcbaCreateTime')"/>
      <el-table-column prop="esPcbaModifier" label="EsPcbaModifier" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esPcbaModifier')"/>
      <el-table-column prop="esPcbaModifyTime" label="EsPcbaModifyTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esPcbaModifyTime')"/>
      <el-table-column prop="esQaEntryDate" label="QA确认日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('esQaEntryDate')"/>
      <el-table-column prop="esQaLot" label="检验批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esQaLot')"/>
      <el-table-column prop="esQaNote" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esQaNote')"/>
      <el-table-column prop="esQaCreator" label="EsQaCreator" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esQaCreator')"/>
      <el-table-column prop="esQaCreateTime" label="EsQaCreateTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esQaCreateTime')"/>
      <el-table-column prop="esQaModifier" label="EsQaModifier" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('esQaModifier')"/>
      <el-table-column prop="esQaModifyTime" label="EsQaModifyTime" :show-overflow-tooltip="true"  v-if="columns.showColumn('esQaModifyTime')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button type="edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:ecslave:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:ecslave:delete']" @click="handleDelete(scope.row)"></el-button>
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
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="esSFID">
              <el-input v-model.number="form.esSFID" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日" prop="esEntryDate">
              <el-date-picker v-model="form.esEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="esEcNo">
              <el-input v-model="form.esEcNo" :placeholder="$t('btn.enter')+'设变No.'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="esModel">
              <el-input v-model="form.esModel" :placeholder="$t('btn.enter')+'机种'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="esItem">
              <el-input v-model="form.esItem" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="子物料" prop="esSubItem">
              <el-input v-model="form.esSubItem" :placeholder="$t('btn.enter')+'子物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料" prop="esOldItem">
              <el-input v-model="form.esOldItem" :placeholder="$t('btn.enter')+'旧物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧文本" prop="esOldItemText">
              <el-input v-model="form.esOldItemText" :placeholder="$t('btn.enter')+'旧文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="esOldUsageQty">
              <el-input-number v-model.number="form.esOldUsageQty" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'用量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="esOldSetLoc">
              <el-input v-model="form.esOldSetLoc" :placeholder="$t('btn.enter')+'位置'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="esNewItem">
              <el-input v-model="form.esNewItem" :placeholder="$t('btn.enter')+'新物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新文本" prop="esNewItemText">
              <el-input v-model="form.esNewItemText" :placeholder="$t('btn.enter')+'新文本'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="esNewUsageQty">
              <el-input-number v-model.number="form.esNewUsageQty" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'用量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="esNewSetLoc">
              <el-input v-model="form.esNewSetLoc" :placeholder="$t('btn.enter')+'位置'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom番号" prop="esBomNo">
              <el-input v-model="form.esBomNo" :placeholder="$t('btn.enter')+'bom番号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="互换" prop="esChange">
              <el-input v-model="form.esChange" :placeholder="$t('btn.enter')+'互换'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="区分" prop="eslocal">
              <el-input v-model="form.eslocal" :placeholder="$t('btn.enter')+'区分'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="指示" prop="esnote">
              <el-input v-model="form.esnote" :placeholder="$t('btn.enter')+'指示'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品处理" prop="esOldProcess">
              <el-input v-model="form.esOldProcess" :placeholder="$t('btn.enter')+'旧品处理'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom日期" prop="esBomDate">
              <el-date-picker v-model="form.esBomDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实施部门" prop="emEcImpDept">
              <el-select filterable clearable   v-model="form.emEcImpDept"  :placeholder="$t('btn.select')+'实施部门'">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购类型" prop="esPurType">
              <el-select filterable clearable   v-model="form.esPurType"  :placeholder="$t('btn.select')+'采购类型'">
                <el-option
                  v-for="item in  options.app_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="仓库" prop="esSloc">
              <el-select filterable clearable   v-model="form.esSloc"  :placeholder="$t('btn.select')+'仓库'">
                <el-option
                  v-for="item in  options.app_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验否" prop="esInsmk">
              <el-radio-group v-model="form.esInsmk">
                <el-radio v-for="item in options.sys_yes_no" :key="item.dictValue" :value="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂状态" prop="esMstae">
              <el-radio-group v-model="form.esMstae">
                <el-radio v-for="item in options.sys_yes_no" :key="item.dictValue" :value="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SOP" prop="esSopStae">
              <el-radio-group v-model="form.esSopStae">
                <el-radio v-for="item in options.sys_yes_no" :key="item.dictValue" :value="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品库存" prop="esOldCurrStock">
              <el-input-number v-model.number="form.esOldCurrStock" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'旧品库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新品库存" prop="esNewCurrStock">
              <el-input-number v-model.number="form.esNewCurrStock" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'新品库存'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购登入日期" prop="esPurEntryDate">
              <el-date-picker v-model="form.esPurEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商" prop="esSupplier">
              <el-input v-model="form.esSupplier" :placeholder="$t('btn.enter')+'供应商'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购PO" prop="esPurOrder">
              <el-input v-model="form.esPurOrder" :placeholder="$t('btn.enter')+'采购PO'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esPurNote">
              <el-input v-model="form.esPurNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购新增" prop="esPurCreator">
              <el-input v-model="form.esPurCreator" :placeholder="$t('btn.enter')+'采购新增'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购新增日期" prop="esPurCreateTime">
              <el-date-picker v-model="form.esPurCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购修改" prop="esPurModifier">
              <el-input v-model="form.esPurModifier" :placeholder="$t('btn.enter')+'采购修改'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购修改日期" prop="esPurModifyTime">
              <el-date-picker v-model="form.esPurModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管登入日期" prop="esPmcEntryDate">
              <el-date-picker v-model="form.esPmcEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预投入批次" prop="esPmcLot">
              <el-input v-model="form.esPmcLot" :placeholder="$t('btn.enter')+'预投入批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esPmcMemo">
              <el-input v-model="form.esPmcMemo" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="esPmcNote">
              <el-input v-model="form.esPmcNote" :placeholder="$t('btn.enter')+'备注'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管新增" prop="esPmcCreator">
              <el-input v-model="form.esPmcCreator" :placeholder="$t('btn.enter')+'生管新增'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管新增日期" prop="esPmcCreateTime">
              <el-date-picker v-model="form.esPmcCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管修改" prop="esPmcModifier">
              <el-input v-model="form.esPmcModifier" :placeholder="$t('btn.enter')+'生管修改'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管修改日期" prop="esPmcModifyTime">
              <el-date-picker v-model="form.esPmcModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC登入日期" prop="esIqcEntryDate">
              <el-date-picker v-model="form.esIqcEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验订单" prop="esIqcOrder">
              <el-input v-model="form.esIqcOrder" :placeholder="$t('btn.enter')+'检验订单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esIqcNote">
              <el-input v-model="form.esIqcNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC新增" prop="esIqcCreator">
              <el-input v-model="form.esIqcCreator" :placeholder="$t('btn.enter')+'IQC新增'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC新增日期" prop="esIqcCreateTime">
              <el-date-picker v-model="form.esIqcCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC修改" prop="esIqcModifier">
              <el-input v-model="form.esIqcModifier" :placeholder="$t('btn.enter')+'IQC修改'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC修改日期" prop="esIqcModifyTime">
              <el-date-picker v-model="form.esIqcModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="部管登入日期" prop="esMmEntryDate">
              <el-date-picker v-model="form.esMmEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="领用批次" prop="esMmLot">
              <el-input v-model="form.esMmLot" :placeholder="$t('btn.enter')+'领用批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单" prop="esMmMocNo">
              <el-input v-model="form.esMmMocNo" :placeholder="$t('btn.enter')+'工单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esMmNote">
              <el-input v-model="form.esMmNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsMmCreator" prop="esMmCreator">
              <el-input v-model="form.esMmCreator" :placeholder="$t('btn.enter')+'EsMmCreator'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsMmCreateTime" prop="esMmCreateTime">
              <el-date-picker v-model="form.esMmCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsMmModifier" prop="esMmModifier">
              <el-input v-model="form.esMmModifier" :placeholder="$t('btn.enter')+'EsMmModifier'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsMmModifyTime" prop="esMmModifyTime">
              <el-date-picker v-model="form.esMmModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制一登入日期" prop="esPpEntryDate">
              <el-date-picker v-model="form.esPpEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组" prop="esPpLine">
              <el-input v-model="form.esPpLine" :placeholder="$t('btn.enter')+'班组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="esPpLot">
              <el-input v-model="form.esPpLot" :placeholder="$t('btn.enter')+'生产批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esPpNote">
              <el-input v-model="form.esPpNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPpCreator" prop="esPpCreator">
              <el-input v-model="form.esPpCreator" :placeholder="$t('btn.enter')+'EsPpCreator'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPpCreateTime" prop="esPpCreateTime">
              <el-date-picker v-model="form.esPpCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPpModifier" prop="esPpModifier">
              <el-input v-model="form.esPpModifier" :placeholder="$t('btn.enter')+'EsPpModifier'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPpModifyTime" prop="esPpModifyTime">
              <el-date-picker v-model="form.esPpModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制二登入日期" prop="esPcbaEntryDate">
              <el-date-picker v-model="form.esPcbaEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Pcba班组" prop="esPcbaLine">
              <el-input v-model="form.esPcbaLine" :placeholder="$t('btn.enter')+'Pcba班组'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Pcba批次" prop="esPcbaLot">
              <el-input v-model="form.esPcbaLot" :placeholder="$t('btn.enter')+'Pcba批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esPcbaNote">
              <el-input v-model="form.esPcbaNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPcbaCreator" prop="esPcbaCreator">
              <el-input v-model="form.esPcbaCreator" :placeholder="$t('btn.enter')+'EsPcbaCreator'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPcbaCreateTime" prop="esPcbaCreateTime">
              <el-date-picker v-model="form.esPcbaCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPcbaModifier" prop="esPcbaModifier">
              <el-input v-model="form.esPcbaModifier" :placeholder="$t('btn.enter')+'EsPcbaModifier'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsPcbaModifyTime" prop="esPcbaModifyTime">
              <el-date-picker v-model="form.esPcbaModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QA确认日期" prop="esQaEntryDate">
              <el-date-picker v-model="form.esQaEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验批次" prop="esQaLot">
              <el-input v-model="form.esQaLot" :placeholder="$t('btn.enter')+'检验批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="esQaNote">
              <el-input v-model="form.esQaNote" :placeholder="$t('btn.enter')+'说明'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsQaCreator" prop="esQaCreator">
              <el-input v-model="form.esQaCreator" :placeholder="$t('btn.enter')+'EsQaCreator'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsQaCreateTime" prop="esQaCreateTime">
              <el-date-picker v-model="form.esQaCreateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsQaModifier" prop="esQaModifier">
              <el-input v-model="form.esQaModifier" :placeholder="$t('btn.enter')+'EsQaModifier'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EsQaModifyTime" prop="esQaModifyTime">
              <el-date-picker v-model="form.esQaModifyTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enter')+'自定义A'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input v-model="form.uDF02" :placeholder="$t('btn.enter')+'自定义B'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input v-model="form.uDF03" :placeholder="$t('btn.enter')+'自定义C'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input v-model="form.uDF04" :placeholder="$t('btn.enter')+'自定义D'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input v-model="form.uDF05" :placeholder="$t('btn.enter')+'自定义E'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input v-model="form.uDF06" :placeholder="$t('btn.enter')+'自定义F'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义3'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义4'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义5'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义6'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
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

<script setup name="ppecslave">

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
  pageSize: 50,
  sort: '',
  sortType: 'asc',
//是否查询（1是）
  esEntryDate: undefined,
//是否查询（1是）
  esEcNo: undefined,
//是否查询（1是）
  esModel: undefined,
//是否查询（1是）
  esItem: undefined,
//是否查询（1是）
  esOldItem: undefined,
//是否查询（1是）
  esNewItem: undefined,
//是否查询（1是）
  emEcImpDept: undefined,
//是否查询（1是）
  esPurType: undefined,
//是否查询（1是）
  esSloc: undefined,
//是否查询（1是）
  esInsmk: undefined,
//是否查询（1是）
  esMstae: undefined,
//是否查询（1是）
  esSopStae: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'esSFID', label: 'SFID' },
  { visible: true, prop: 'esEntryDate', label: '输入日' },
  { visible: true, prop: 'esEcNo', label: '设变No.' },
  { visible: true, prop: 'esModel', label: '机种' },
  { visible: true, prop: 'esItem', label: '物料' },
  { visible: true, prop: 'esSubItem', label: '子物料' },
  { visible: true, prop: 'esOldItem', label: '旧物料' },
  { visible: true, prop: 'esOldItemText', label: '旧文本' },
  { visible: false, prop: 'esOldUsageQty', label: '用量' },
  { visible: false, prop: 'esOldSetLoc', label: '位置' },
  { visible: false, prop: 'esNewItem', label: '新物料' },
  { visible: false, prop: 'esNewItemText', label: '新文本' },
  { visible: false, prop: 'esNewUsageQty', label: '用量' },
  { visible: false, prop: 'esNewSetLoc', label: '位置' },
  { visible: false, prop: 'esBomNo', label: 'bom番号' },
  { visible: false, prop: 'esChange', label: '互换' },
  { visible: false, prop: 'eslocal', label: '区分' },
  { visible: false, prop: 'esnote', label: '指示' },
  { visible: false, prop: 'esOldProcess', label: '旧品处理' },
  { visible: false, prop: 'esBomDate', label: 'bom日期' },
  { visible: false, prop: 'emEcImpDept', label: '实施部门' },
  { visible: false, prop: 'esPurType', label: '采购类型' },
  { visible: false, prop: 'esSloc', label: '仓库' },
  { visible: false, prop: 'esInsmk', label: '检验否' },
  { visible: false, prop: 'esMstae', label: '工厂状态' },
  { visible: false, prop: 'esSopStae', label: 'SOP' },
  { visible: false, prop: 'esOldCurrStock', label: '旧品库存' },
  { visible: false, prop: 'esNewCurrStock', label: '新品库存' },
  { visible: false, prop: 'esPurEntryDate', label: '采购登入日期' },
  { visible: false, prop: 'esSupplier', label: '供应商' },
  { visible: false, prop: 'esPurOrder', label: '采购PO' },
  { visible: false, prop: 'esPurNote', label: '说明' },
  { visible: false, prop: 'esPurCreator', label: '采购新增' },
  { visible: false, prop: 'esPurCreateTime', label: '采购新增日期' },
  { visible: false, prop: 'esPurModifier', label: '采购修改' },
  { visible: false, prop: 'esPurModifyTime', label: '采购修改日期' },
  { visible: false, prop: 'esPmcEntryDate', label: '生管登入日期' },
  { visible: false, prop: 'esPmcLot', label: '预投入批次' },
  { visible: false, prop: 'esPmcMemo', label: '说明' },
  { visible: false, prop: 'esPmcNote', label: '备注' },
  { visible: false, prop: 'esPmcCreator', label: '生管新增' },
  { visible: false, prop: 'esPmcCreateTime', label: '生管新增日期' },
  { visible: false, prop: 'esPmcModifier', label: '生管修改' },
  { visible: false, prop: 'esPmcModifyTime', label: '生管修改日期' },
  { visible: false, prop: 'esIqcEntryDate', label: 'IQC登入日期' },
  { visible: false, prop: 'esIqcOrder', label: '检验订单' },
  { visible: false, prop: 'esIqcNote', label: '说明' },
  { visible: false, prop: 'esIqcCreator', label: 'IQC新增' },
  { visible: false, prop: 'esIqcCreateTime', label: 'IQC新增日期' },
  { visible: false, prop: 'esIqcModifier', label: 'IQC修改' },
  { visible: false, prop: 'esIqcModifyTime', label: 'IQC修改日期' },
  { visible: false, prop: 'esMmEntryDate', label: '部管登入日期' },
  { visible: false, prop: 'esMmLot', label: '领用批次' },
  { visible: false, prop: 'esMmMocNo', label: '工单' },
  { visible: false, prop: 'esMmNote', label: '说明' },
  { visible: false, prop: 'esMmCreator', label: 'EsMmCreator' },
  { visible: false, prop: 'esMmCreateTime', label: 'EsMmCreateTime' },
  { visible: false, prop: 'esMmModifier', label: 'EsMmModifier' },
  { visible: false, prop: 'esMmModifyTime', label: 'EsMmModifyTime' },
  { visible: false, prop: 'esPpEntryDate', label: '制一登入日期' },
  { visible: false, prop: 'esPpLine', label: '班组' },
  { visible: false, prop: 'esPpLot', label: '生产批次' },
  { visible: false, prop: 'esPpNote', label: '说明' },
  { visible: false, prop: 'esPpCreator', label: 'EsPpCreator' },
  { visible: false, prop: 'esPpCreateTime', label: 'EsPpCreateTime' },
  { visible: false, prop: 'esPpModifier', label: 'EsPpModifier' },
  { visible: false, prop: 'esPpModifyTime', label: 'EsPpModifyTime' },
  { visible: false, prop: 'esPcbaEntryDate', label: '制二登入日期' },
  { visible: false, prop: 'esPcbaLine', label: 'Pcba班组' },
  { visible: false, prop: 'esPcbaLot', label: 'Pcba批次' },
  { visible: false, prop: 'esPcbaNote', label: '说明' },
  { visible: false, prop: 'esPcbaCreator', label: 'EsPcbaCreator' },
  { visible: false, prop: 'esPcbaCreateTime', label: 'EsPcbaCreateTime' },
  { visible: false, prop: 'esPcbaModifier', label: 'EsPcbaModifier' },
  { visible: false, prop: 'esPcbaModifyTime', label: 'EsPcbaModifyTime' },
  { visible: false, prop: 'esQaEntryDate', label: 'QA确认日期' },
  { visible: false, prop: 'esQaLot', label: '检验批次' },
  { visible: false, prop: 'esQaNote', label: '说明' },
  { visible: false, prop: 'esQaCreator', label: 'EsQaCreator' },
  { visible: false, prop: 'esQaCreateTime', label: 'EsQaCreateTime' },
  { visible: false, prop: 'esQaModifier', label: 'EsQaModifier' },
  { visible: false, prop: 'esQaModifyTime', label: 'EsQaModifyTime' },
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



// 输入日时间范围
const dateRangeEsEntryDate = ref([])




































































































//字典参数
var dictParams = [
  { dictType: "sql_dept_list" },
  { dictType: "app_pur_type" },
  { dictType: "app_sloc_list" },
  { dictType: "sys_yes_no" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从从设变/pp_ec_slave表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEsEntryDate.value, 'EsEntryDate');
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
  // 输入日时间范围
  dateRangeEsEntryDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.esSFID);
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
    esSFID: [{ required: true, message: "SFID不能为空", trigger: "blur" }],
    esEntryDate: [{ required: true, message: "输入日不能为空", trigger: "blur"     }],
    esEcNo: [{ required: true, message: "设变No.不能为空", trigger: "blur"     }],
    esModel: [{ required: true, message: "机种不能为空", trigger: "blur"     }],
    esItem: [{ required: true, message: "物料不能为空", trigger: "blur"     }],
    esOldUsageQty: [{ required: true, message: "用量不能为空", trigger: "blur"     }],
    esNewUsageQty: [{ required: true, message: "用量不能为空", trigger: "blur"     }],
    esBomDate: [{ required: true, message: "bom日期不能为空", trigger: "blur"     }],
    emEcImpDept: [{ required: true, message: "实施部门不能为空", trigger: "change"     }],
    esPurType: [{ required: true, message: "采购类型不能为空", trigger: "change"     }],
    esSloc: [{ required: true, message: "仓库不能为空", trigger: "change"     }],
    esSopStae: [{ required: true, message: "SOP不能为空", trigger: "blur"     }],
    esOldCurrStock: [{ required: true, message: "旧品库存不能为空", trigger: "blur"     }],
    esNewCurrStock: [{ required: true, message: "新品库存不能为空", trigger: "blur"     }],
  },
  options: {
    // 实施部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_pur_type: [],
    // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_sloc_list: [],
    // 检验否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_yes_no: [],
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
    esSFID: 0,
    esSFID: null,
    esEntryDate: null,
    esEntryDate: null,
    esEcNo: null,
    esEcNo: null,
    esModel: null,
    esModel: null,
    esItem: null,
    esItem: null,
    esSubItem: null,
    esSubItem: null,
    esOldItem: null,
    esOldItem: null,
    esOldItemText: null,
    esOldItemText: null,
    esOldUsageQty: 0,
    esOldUsageQty: null,
    esOldSetLoc: null,
    esOldSetLoc: null,
    esNewItem: null,
    esNewItem: null,
    esNewItemText: null,
    esNewItemText: null,
    esNewUsageQty: 0,
    esNewUsageQty: null,
    esNewSetLoc: null,
    esNewSetLoc: null,
    esBomNo: null,
    esBomNo: null,
    esChange: null,
    esChange: null,
    eslocal: null,
    eslocal: null,
    esnote: null,
    esnote: null,
    esOldProcess: null,
    esOldProcess: null,
    esBomDate: null,
    esBomDate: null,
    emEcImpDept: null,
    emEcImpDept: null,
    esPurType: null,
    esPurType: null,
    esSloc: null,
    esSloc: null,
    esInsmk: null,
    esInsmk: null,
    esMstae: null,
    esMstae: null,
    esSopStae: null,
    esSopStae: null,
    esOldCurrStock: 0,
    esOldCurrStock: null,
    esNewCurrStock: 0,
    esNewCurrStock: null,
    esPurEntryDate: null,
    esPurEntryDate: null,
    esSupplier: null,
    esSupplier: null,
    esPurOrder: null,
    esPurOrder: null,
    esPurNote: null,
    esPurNote: null,
    esPurCreator: null,
    esPurCreator: null,
    esPurCreateTime: null,
    esPurCreateTime: null,
    esPurModifier: null,
    esPurModifier: null,
    esPurModifyTime: null,
    esPurModifyTime: null,
    esPmcEntryDate: null,
    esPmcEntryDate: null,
    esPmcLot: null,
    esPmcLot: null,
    esPmcMemo: null,
    esPmcMemo: null,
    esPmcNote: null,
    esPmcNote: null,
    esPmcCreator: null,
    esPmcCreator: null,
    esPmcCreateTime: null,
    esPmcCreateTime: null,
    esPmcModifier: null,
    esPmcModifier: null,
    esPmcModifyTime: null,
    esPmcModifyTime: null,
    esIqcEntryDate: null,
    esIqcEntryDate: null,
    esIqcOrder: null,
    esIqcOrder: null,
    esIqcNote: null,
    esIqcNote: null,
    esIqcCreator: null,
    esIqcCreator: null,
    esIqcCreateTime: null,
    esIqcCreateTime: null,
    esIqcModifier: null,
    esIqcModifier: null,
    esIqcModifyTime: null,
    esIqcModifyTime: null,
    esMmEntryDate: null,
    esMmEntryDate: null,
    esMmLot: null,
    esMmLot: null,
    esMmMocNo: null,
    esMmMocNo: null,
    esMmNote: null,
    esMmNote: null,
    esMmCreator: null,
    esMmCreator: null,
    esMmCreateTime: null,
    esMmCreateTime: null,
    esMmModifier: null,
    esMmModifier: null,
    esMmModifyTime: null,
    esMmModifyTime: null,
    esPpEntryDate: null,
    esPpEntryDate: null,
    esPpLine: null,
    esPpLine: null,
    esPpLot: null,
    esPpLot: null,
    esPpNote: null,
    esPpNote: null,
    esPpCreator: null,
    esPpCreator: null,
    esPpCreateTime: null,
    esPpCreateTime: null,
    esPpModifier: null,
    esPpModifier: null,
    esPpModifyTime: null,
    esPpModifyTime: null,
    esPcbaEntryDate: null,
    esPcbaEntryDate: null,
    esPcbaLine: null,
    esPcbaLine: null,
    esPcbaLot: null,
    esPcbaLot: null,
    esPcbaNote: null,
    esPcbaNote: null,
    esPcbaCreator: null,
    esPcbaCreator: null,
    esPcbaCreateTime: null,
    esPcbaCreateTime: null,
    esPcbaModifier: null,
    esPcbaModifier: null,
    esPcbaModifyTime: null,
    esPcbaModifyTime: null,
    esQaEntryDate: null,
    esQaEntryDate: null,
    esQaLot: null,
    esQaLot: null,
    esQaNote: null,
    esQaNote: null,
    esQaCreator: null,
    esQaCreator: null,
    esQaCreateTime: null,
    esQaCreateTime: null,
    esQaModifier: null,
    esQaModifier: null,
    esQaModifyTime: null,
    esQaModifyTime: null,
    uDF01: null,
    uDF01: null,
    uDF02: null,
    uDF02: null,
    uDF03: null,
    uDF03: null,
    uDF04: null,
    uDF04: null,
    uDF05: null,
    uDF05: null,
    uDF06: null,
    uDF06: null,
    uDF51: 0,
    uDF51: null,
    uDF52: 0,
    uDF52: null,
    uDF53: 0,
    uDF53: null,
    uDF54: 0,
    uDF54: null,
    uDF55: 0,
    uDF55: null,
    uDF56: 0,
    uDF56: null,
    isDeleted: 0,
    isDeleted: null,
    remark: null,
    remark: null,
    createBy: null,
    createBy: null,
    createTime: null,
    createTime: null,
    updateBy: null,
    updateBy: null,
    updateTime: null,
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
  form.value.esEntryDate= new Date()
  form.value.esOldUsageQty= 0
  form.value.esNewUsageQty= 0
  form.value.esBomDate= new Date()
  form.value.emEcImpDept= []
  form.value.esPurType= []
  form.value.esSloc= []
  form.value.esInsmk= 0
  form.value.esMstae= 0
  form.value.esSopStae= 0
  form.value.esOldCurrStock= 0
  form.value.esNewCurrStock= 0
  form.value.esPurEntryDate= new Date()
  form.value.esPurCreateTime= new Date()
  form.value.esPurModifyTime= new Date()
  form.value.esPmcEntryDate= new Date()
  form.value.esPmcCreateTime= new Date()
  form.value.esPmcModifyTime= new Date()
  form.value.esIqcEntryDate= new Date()
  form.value.esIqcCreateTime= new Date()
  form.value.esIqcModifyTime= new Date()
  form.value.esMmEntryDate= new Date()
  form.value.esMmCreateTime= new Date()
  form.value.esMmModifyTime= new Date()
  form.value.esPpEntryDate= new Date()
  form.value.esPpCreateTime= new Date()
  form.value.esPpModifyTime= new Date()
  form.value.esPcbaEntryDate= new Date()
  form.value.esPcbaCreateTime= new Date()
  form.value.esPcbaModifyTime= new Date()
  form.value.esQaEntryDate= new Date()
  form.value.esQaCreateTime= new Date()
  form.value.esQaModifyTime= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.esSFID || ids.value
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

      if (form.value.esSFID != undefined && opertype.value === 2) {
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
  const Ids = row.esSFID || ids.value

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
      await proxy.downFile('/logistics/PpEcSlave/export', { ...queryParams })
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