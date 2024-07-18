<!--
 * @Descripttion: 主设变/pp_ec_master
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/16 10:27:43
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="发行日">
        <el-date-picker
          v-model="dateRangeEmEcIssueDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="设变No." prop="emEcNo">
        <el-input v-model="queryParams.emEcNo" :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="标题" prop="emEcTitle">
        <el-input v-model="queryParams.emEcTitle" :placeholder="$t('btn.enterSearchPrefix')+'标题'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="担当" prop="emEcAssigned">
        <el-select filterable clearable   v-model="queryParams.emEcAssigned" :placeholder="$t('btn.selectSearchPrefix')+'担当'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="管理区分" prop="emEcManageCategory">
        <el-radio-group v-model="queryParams.emEcManageCategory">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_ec_mgtype " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="联络No." prop="emEcLiaisonNo">
        <el-input v-model="queryParams.emEcLiaisonNo" :placeholder="$t('btn.enterSearchPrefix')+'联络No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="EppNo." prop="emEcEppLiaisonNo">
        <el-input v-model="queryParams.emEcEppLiaisonNo" :placeholder="$t('btn.enterSearchPrefix')+'EppNo.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="FppNo." prop="emEcFppLiaisonNo">
        <el-input v-model="queryParams.emEcFppLiaisonNo" :placeholder="$t('btn.enterSearchPrefix')+'FppNo.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="外部No." prop="emEcExternalNo">
        <el-input v-model="queryParams.emEcExternalNo" :placeholder="$t('btn.enterSearchPrefix')+'外部No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="输入日">
        <el-date-picker
          v-model="dateRangeEmEcEntryDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="SOP" prop="esSopStae">
        <el-radio-group v-model="queryParams.esSopStae">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_sop_yn " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
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
        <el-button class="btn-add" v-hasPermi="['pp:ecmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:ecmaster:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:ecmaster:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecmaster:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpEcMaster/importTemplate"
                  importUrl="/Logistics/PpEcMaster/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecmaster:export']">
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain  icon="view" size="small" @click="rowClick(scope.row)" :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="emSFID" label="SFID" align="center" v-if="columns.showColumn('emSFID')"/>
      <el-table-column prop="emEcIssueDate" label="发行日" :show-overflow-tooltip="true"  v-if="columns.showColumn('emEcIssueDate')"/>
      <el-table-column prop="emEcNo" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcNo')"/>
      <el-table-column prop="emEcDoc" label="关联文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcDoc')"/>
      <el-table-column prop="emEcStatus" label="状态" align="center" v-if="columns.showColumn('emEcStatus')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.emEcStatus"  />
        </template>
      </el-table-column>
      <el-table-column prop="emEcTitle" label="标题" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcTitle')"/>
      <el-table-column prop="emEcContent" label="内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcContent')"/>
      <el-table-column prop="emEcAssigned" label="担当" align="center" v-if="columns.showColumn('emEcAssigned')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.emEcAssigned"  />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLossAmount" label="损失金额" align="center" v-if="columns.showColumn('emEcLossAmount')"/>
      <el-table-column prop="emEcManageCategory" label="管理区分" align="center" v-if="columns.showColumn('emEcManageCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_mgtype " :value="scope.row.emEcManageCategory"  />
        </template>
      </el-table-column>
      <el-table-column prop="emEcLiaisonNo" label="联络No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcLiaisonNo')"/>
      <el-table-column prop="emEcLiaisonDoc" label="联络文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcLiaisonDoc')"/>
      <el-table-column prop="emEcEppLiaisonNo" label="EppNo." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcEppLiaisonNo')"/>
      <el-table-column prop="emEcEppLiaisonDoc" label="Epp文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcEppLiaisonDoc')"/>
      <el-table-column prop="emEcFppLiaisonNo" label="FppNo." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcFppLiaisonNo')"/>
      <el-table-column prop="emEcFppLiaisonDoc" label="Fpp文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcFppLiaisonDoc')"/>
      <el-table-column prop="emEcExternalNo" label="外部No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcExternalNo')"/>
      <el-table-column prop="emEcExternalDoc" label="外部文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcExternalDoc')"/>
      <el-table-column prop="emEcImpDept" label="输入部门" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('emEcImpDept')"/>
      <el-table-column prop="emEcEntryDate" label="输入日" :show-overflow-tooltip="true"  v-if="columns.showColumn('emEcEntryDate')"/>
      <el-table-column prop="esSopStae" label="SOP" align="center" v-if="columns.showColumn('esSopStae')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sop_yn " :value="scope.row.esSopStae"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:ecmaster:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:ecmaster:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppEcSlaveList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="esSFID" label="SFID"/>
        <el-table-column prop="esParentSfid" label="EsParentSfid"/>
        <el-table-column prop="esEntryDate" label="输入日"/>
        <el-table-column prop="esEcNo" label="设变No."/>
        <el-table-column prop="esModel" label="机种"/>
        <el-table-column prop="esItem" label="物料"/>
        <el-table-column prop="esSubItem" label="子物料"/>
        <el-table-column prop="esOldItem" label="旧物料"/>
        <el-table-column prop="esOldItemText" label="旧文本"/>
        <el-table-column prop="esOldUsageQty" label="用量"/>
        <el-table-column prop="esOldSetLoc" label="位置"/>
        <el-table-column prop="esNewItem" label="新物料"/>
        <el-table-column prop="esNewItemText" label="新文本"/>
        <el-table-column prop="esNewUsageQty" label="用量"/>
        <el-table-column prop="esNewSetLoc" label="位置"/>
        <el-table-column prop="esBomNo" label="bom番号"/>
        <el-table-column prop="esChange" label="互换"/>
        <el-table-column prop="eslocal" label="区分"/>
        <el-table-column prop="esnote" label="指示"/>
        <el-table-column prop="esOldProcess" label="旧品处理"/>
        <el-table-column prop="esBomDate" label="bom日期"/>
        <el-table-column prop="emEcImpDept" label="实施部门"/>
        <el-table-column prop="esPurType" label="采购类型">
          <template #default="scope">
            <dict-tag :options=" options.sys_pur_type " :value="scope.row.esPurType"  />
          </template>
        </el-table-column>
        <el-table-column prop="esSloc" label="仓库"/>
        <el-table-column prop="esInsmk" label="检验否">
          <template #default="scope">
            <dict-tag :options=" options.sys_normal_whether " :value="scope.row.esInsmk"  />
          </template>
        </el-table-column>
        <el-table-column prop="esMstae" label="工厂状态"/>
        <el-table-column prop="esSopStae" label="SOP">
          <template #default="scope">
            <dict-tag :options=" options.sys_sop_yn " :value="scope.row.esSopStae"  />
          </template>
        </el-table-column>
        <el-table-column prop="esOldCurrStock" label="旧品库存"/>
        <el-table-column prop="esNewCurrStock" label="新品库存"/>
        <el-table-column prop="esPurEntryDate" label="采购登入日期"/>
        <el-table-column prop="esSupplier" label="供应商"/>
        <el-table-column prop="esPurOrder" label="采购PO"/>
        <el-table-column prop="esPurNote" label="说明"/>
        <el-table-column prop="esPurCreator" label="采购新增"/>
        <el-table-column prop="esPurModifier" label="采购修改"/>
        <el-table-column prop="esPurModifyTime" label="采购修改日期"/>
        <el-table-column prop="esPmcEntryDate" label="生管登入日期"/>
        <el-table-column prop="esPmcLot" label="预投入批次"/>
        <el-table-column prop="esPmcMemo" label="说明"/>
        <el-table-column prop="esPmcNote" label="备注"/>
        <el-table-column prop="esPmcCreator" label="生管新增"/>
        <el-table-column prop="esPmcModifier" label="生管修改"/>
        <el-table-column prop="esPmcModifyTime" label="生管修改日期"/>
        <el-table-column prop="esIqcEntryDate" label="IQC登入日期"/>
        <el-table-column prop="esIqcOrder" label="检验订单"/>
        <el-table-column prop="esIqcNote" label="说明"/>
        <el-table-column prop="esIqcCreator" label="IQC新增"/>
        <el-table-column prop="esIqcModifier" label="IQC修改"/>
        <el-table-column prop="esIqcModifyTime" label="IQC修改日期"/>
        <el-table-column prop="esMmEntryDate" label="部管登入日期"/>
        <el-table-column prop="esMmLot" label="领用批次"/>
        <el-table-column prop="esMmMocNo" label="工单"/>
        <el-table-column prop="esMmNote" label="说明"/>
        <el-table-column prop="esMmCreator" label="EsMmCreator"/>
        <el-table-column prop="esMmModifier" label="EsMmModifier"/>
        <el-table-column prop="esMmModifyTime" label="EsMmModifyTime"/>
        <el-table-column prop="esPpEntryDate" label="制一登入日期"/>
        <el-table-column prop="esPpLine" label="班组"/>
        <el-table-column prop="esPpLot" label="生产批次"/>
        <el-table-column prop="esPpNote" label="说明"/>
        <el-table-column prop="esPpCreator" label="EsPpCreator"/>
        <el-table-column prop="esPpModifier" label="EsPpModifier"/>
        <el-table-column prop="esPpModifyTime" label="EsPpModifyTime"/>
        <el-table-column prop="esPcbaEntryDate" label="制二登入日期"/>
        <el-table-column prop="esPcbaLine" label="Pcba班组"/>
        <el-table-column prop="esPcbaLot" label="Pcba批次"/>
        <el-table-column prop="esPcbaNote" label="说明"/>
        <el-table-column prop="esPcbaCreator" label="EsPcbaCreator"/>
        <el-table-column prop="esPcbaModifier" label="EsPcbaModifier"/>
        <el-table-column prop="esPcbaModifyTime" label="EsPcbaModifyTime"/>
        <el-table-column prop="esQaEntryDate" label="QA确认日期"/>
        <el-table-column prop="esQaLot" label="检验批次"/>
        <el-table-column prop="esQaNote" label="说明"/>
        <el-table-column prop="esQaCreator" label="EsQaCreator"/>
        <el-table-column prop="esQaModifier" label="EsQaModifier"/>
        <el-table-column prop="esQaModifyTime" label="EsQaModifyTime"/>
        <el-table-column prop="remark" label="备注"/>
        <el-table-column prop="createBy" label="创建者"/>
        <el-table-column prop="createTime" label="创建时间"/>
        <el-table-column prop="updateBy" label="更新者"/>
        <el-table-column prop="updateTime" label="更新时间"/>
      </el-table>
    </el-drawer>

    <!-- 添加或修改主设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="emSFID">
              <el-input v-model.number="form.emSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行日" prop="emEcIssueDate">
              <el-date-picker v-model="form.emEcIssueDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="emEcNo">
              <el-input v-model="form.emEcNo" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="关联文件" prop="emEcDoc">
              <UploadFile v-model="form.emEcDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="emEcStatus">
              <el-radio-group v-model="form.emEcStatus">
                <el-radio v-for="item in options.sys_ec_status" :key="item.dictValue" :value="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标题" prop="emEcTitle">
              <el-input v-model="form.emEcTitle" :placeholder="$t('btn.enterPrefix')+'标题'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="内容" prop="emEcContent">
              <el-input type="textarea" v-model="form.emEcContent" :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="emEcAssigned">
              <el-select filterable clearable   v-model="form.emEcAssigned"  :placeholder="$t('btn.selectPrefix')+'担当'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="损失金额" prop="emEcLossAmount">
              <el-input-number v-model.number="form.emEcLossAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'损失金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="管理区分" prop="emEcManageCategory">
              <el-radio-group v-model="form.emEcManageCategory">
                <el-radio v-for="item in options.sys_ec_mgtype" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络No." prop="emEcLiaisonNo">
              <el-input v-model="form.emEcLiaisonNo" :placeholder="$t('btn.enterPrefix')+'联络No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="联络文件" prop="emEcLiaisonDoc">
              <UploadFile v-model="form.emEcLiaisonDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EppNo." prop="emEcEppLiaisonNo">
              <el-input v-model="form.emEcEppLiaisonNo" :placeholder="$t('btn.enterPrefix')+'EppNo.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Epp文件" prop="emEcEppLiaisonDoc">
              <UploadFile v-model="form.emEcEppLiaisonDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="FppNo." prop="emEcFppLiaisonNo">
              <el-input v-model="form.emEcFppLiaisonNo" :placeholder="$t('btn.enterPrefix')+'FppNo.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Fpp文件" prop="emEcFppLiaisonDoc">
              <UploadFile v-model="form.emEcFppLiaisonDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部No." prop="emEcExternalNo">
              <el-input v-model="form.emEcExternalNo" :placeholder="$t('btn.enterPrefix')+'外部No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="外部文件" prop="emEcExternalDoc">
              <UploadFile v-model="form.emEcExternalDoc" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入部门" prop="emEcImpDept">
              <el-input v-model="form.emEcImpDept" :placeholder="$t('btn.enterPrefix')+'输入部门'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日" prop="emEcEntryDate">
              <el-date-picker v-model="form.emEcEntryDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="SOP" prop="esSopStae">
              <el-radio-group v-model="form.esSopStae">
                <el-radio v-for="item in options.sys_sop_yn" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
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
    <!-- 子表信息 -->
        <el-divider content-position="center">从设变</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpEcSlave">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpEcSlave">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppEcSlaveList" :row-class-name="rowPpEcSlaveIndex" @selection-change="handlePpEcSlaveSelectionChange" ref="PpEcSlaveRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="输入日" align="center" prop="esEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="设变No." align="center" prop="esEcNo">
            <template #default="scope">
              <el-input v-model="scope.row.esEcNo" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="机种" align="center" prop="esModel">
            <template #default="scope">
              <el-input v-model="scope.row.esModel" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="物料" align="center" prop="esItem">
            <template #default="scope">
              <el-input v-model="scope.row.esItem" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="子物料" align="center" prop="esSubItem">
            <template #default="scope">
              <el-input v-model="scope.row.esSubItem" :placeholder="$t('btn.enterPrefix')+'子物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧物料" align="center" prop="esOldItem">
            <template #default="scope">
              <el-input v-model="scope.row.esOldItem" :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧文本" align="center" prop="esOldItemText">
            <template #default="scope">
              <el-input v-model="scope.row.esOldItemText" :placeholder="$t('btn.enterPrefix')+'旧文本'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="用量" align="center" prop="esOldUsageQty" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.esOldUsageQty" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="esOldSetLoc">
            <template #default="scope">
              <el-input v-model="scope.row.esOldSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新物料" align="center" prop="esNewItem">
            <template #default="scope">
              <el-input v-model="scope.row.esNewItem" :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新文本" align="center" prop="esNewItemText">
            <template #default="scope">
              <el-input v-model="scope.row.esNewItemText" :placeholder="$t('btn.enterPrefix')+'新文本'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="用量" align="center" prop="esNewUsageQty" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.esNewUsageQty" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="esNewSetLoc">
            <template #default="scope">
              <el-input v-model="scope.row.esNewSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="bom番号" align="center" prop="esBomNo">
            <template #default="scope">
              <el-input v-model="scope.row.esBomNo" :placeholder="$t('btn.enterPrefix')+'bom番号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="互换" align="center" prop="esChange">
            <template #default="scope">
              <el-input v-model="scope.row.esChange" :placeholder="$t('btn.enterPrefix')+'互换'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="区分" align="center" prop="eslocal">
            <template #default="scope">
              <el-input v-model="scope.row.eslocal" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="指示" align="center" prop="esnote">
            <template #default="scope">
              <el-input v-model="scope.row.esnote" :placeholder="$t('btn.enterPrefix')+'指示'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧品处理" align="center" prop="esOldProcess">
            <template #default="scope">
              <el-input v-model="scope.row.esOldProcess" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="bom日期" align="center" prop="esBomDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esBomDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="实施部门" align="center" prop="emEcImpDept">
            <template #default="scope">
              <el-input v-model="scope.row.emEcImpDept" :placeholder="$t('btn.enterPrefix')+'实施部门'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="采购类型" prop="esPurType">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.esPurType" :placeholder="$t('btn.enterPrefix')+'采购类型'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="仓库" align="center" prop="esSloc">
            <template #default="scope">
              <el-input v-model="scope.row.esSloc" :placeholder="$t('btn.enterPrefix')+'仓库'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="检验否" prop="esInsmk">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.esInsmk" :placeholder="$t('btn.enterPrefix')+'检验否'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_normal_whether" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="工厂状态" align="center" prop="esMstae">
            <template #default="scope">
              <el-input v-model="scope.row.esMstae" :placeholder="$t('btn.enterPrefix')+'工厂状态'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="SOP" prop="esSopStae">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.esSopStae" :placeholder="$t('btn.enterPrefix')+'SOP'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_sop_yn" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="旧品库存" align="center" prop="esOldCurrStock" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.esOldCurrStock" controls-position="right" :placeholder="$t('btn.enterPrefix')+'旧品库存'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新品库存" align="center" prop="esNewCurrStock" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.esNewCurrStock" controls-position="right" :placeholder="$t('btn.enterPrefix')+'新品库存'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="采购登入日期" align="center" prop="esPurEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPurEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="供应商" align="center" prop="esSupplier">
            <template #default="scope">
              <el-input v-model="scope.row.esSupplier" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="采购PO" align="center" prop="esPurOrder">
            <template #default="scope">
              <el-input v-model="scope.row.esPurOrder" :placeholder="$t('btn.enterPrefix')+'采购PO'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPurNote">
            <template #default="scope">
              <el-input v-model="scope.row.esPurNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="采购新增" align="center" prop="esPurCreator">
            <template #default="scope">
              <el-input v-model="scope.row.esPurCreator" :placeholder="$t('btn.enterPrefix')+'采购新增'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="采购修改" align="center" prop="esPurModifier">
            <template #default="scope">
              <el-input v-model="scope.row.esPurModifier" :placeholder="$t('btn.enterPrefix')+'采购修改'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="采购修改日期" align="center" prop="esPurModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPurModifyTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="生管登入日期" align="center" prop="esPmcEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPmcEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="预投入批次" align="center" prop="esPmcLot">
            <template #default="scope">
              <el-input v-model="scope.row.esPmcLot" :placeholder="$t('btn.enterPrefix')+'预投入批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPmcMemo">
            <template #default="scope">
              <el-input v-model="scope.row.esPmcMemo" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="esPmcNote">
            <template #default="scope">
              <el-input v-model="scope.row.esPmcNote" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生管新增" align="center" prop="esPmcCreator">
            <template #default="scope">
              <el-input v-model="scope.row.esPmcCreator" :placeholder="$t('btn.enterPrefix')+'生管新增'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生管修改" align="center" prop="esPmcModifier">
            <template #default="scope">
              <el-input v-model="scope.row.esPmcModifier" :placeholder="$t('btn.enterPrefix')+'生管修改'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生管修改日期" align="center" prop="esPmcModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPmcModifyTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="IQC登入日期" align="center" prop="esIqcEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esIqcEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="检验订单" align="center" prop="esIqcOrder">
            <template #default="scope">
              <el-input v-model="scope.row.esIqcOrder" :placeholder="$t('btn.enterPrefix')+'检验订单'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esIqcNote">
            <template #default="scope">
              <el-input v-model="scope.row.esIqcNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="IQC新增" align="center" prop="esIqcCreator">
            <template #default="scope">
              <el-input v-model="scope.row.esIqcCreator" :placeholder="$t('btn.enterPrefix')+'IQC新增'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="IQC修改" align="center" prop="esIqcModifier">
            <template #default="scope">
              <el-input v-model="scope.row.esIqcModifier" :placeholder="$t('btn.enterPrefix')+'IQC修改'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="IQC修改日期" align="center" prop="esIqcModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esIqcModifyTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="部管登入日期" align="center" prop="esMmEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esMmEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="领用批次" align="center" prop="esMmLot">
            <template #default="scope">
              <el-input v-model="scope.row.esMmLot" :placeholder="$t('btn.enterPrefix')+'领用批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="工单" align="center" prop="esMmMocNo">
            <template #default="scope">
              <el-input v-model="scope.row.esMmMocNo" :placeholder="$t('btn.enterPrefix')+'工单'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esMmNote">
            <template #default="scope">
              <el-input v-model="scope.row.esMmNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsMmCreator" align="center" prop="esMmCreator">
            <template #default="scope">
              <el-input v-model="scope.row.esMmCreator" :placeholder="$t('btn.enterPrefix')+'EsMmCreator'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsMmModifier" align="center" prop="esMmModifier">
            <template #default="scope">
              <el-input v-model="scope.row.esMmModifier" :placeholder="$t('btn.enterPrefix')+'EsMmModifier'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsMmModifyTime" align="center" prop="esMmModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esMmModifyTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="制一登入日期" align="center" prop="esPpEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPpEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="班组" align="center" prop="esPpLine">
            <template #default="scope">
              <el-input v-model="scope.row.esPpLine" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生产批次" align="center" prop="esPpLot">
            <template #default="scope">
              <el-input v-model="scope.row.esPpLot" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPpNote">
            <template #default="scope">
              <el-input v-model="scope.row.esPpNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsPpCreator" align="center" prop="esPpCreator">
            <template #default="scope">
              <el-input v-model="scope.row.esPpCreator" :placeholder="$t('btn.enterPrefix')+'EsPpCreator'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsPpModifier" align="center" prop="esPpModifier">
            <template #default="scope">
              <el-input v-model="scope.row.esPpModifier" :placeholder="$t('btn.enterPrefix')+'EsPpModifier'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsPpModifyTime" align="center" prop="esPpModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPpModifyTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="制二登入日期" align="center" prop="esPcbaEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPcbaEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="Pcba班组" align="center" prop="esPcbaLine">
            <template #default="scope">
              <el-input v-model="scope.row.esPcbaLine" :placeholder="$t('btn.enterPrefix')+'Pcba班组'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="Pcba批次" align="center" prop="esPcbaLot">
            <template #default="scope">
              <el-input v-model="scope.row.esPcbaLot" :placeholder="$t('btn.enterPrefix')+'Pcba批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esPcbaNote">
            <template #default="scope">
              <el-input v-model="scope.row.esPcbaNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsPcbaCreator" align="center" prop="esPcbaCreator">
            <template #default="scope">
              <el-input v-model="scope.row.esPcbaCreator" :placeholder="$t('btn.enterPrefix')+'EsPcbaCreator'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsPcbaModifier" align="center" prop="esPcbaModifier">
            <template #default="scope">
              <el-input v-model="scope.row.esPcbaModifier" :placeholder="$t('btn.enterPrefix')+'EsPcbaModifier'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsPcbaModifyTime" align="center" prop="esPcbaModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esPcbaModifyTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="QA确认日期" align="center" prop="esQaEntryDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esQaEntryDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="检验批次" align="center" prop="esQaLot">
            <template #default="scope">
              <el-input v-model="scope.row.esQaLot" :placeholder="$t('btn.enterPrefix')+'检验批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="esQaNote">
            <template #default="scope">
              <el-input v-model="scope.row.esQaNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsQaCreator" align="center" prop="esQaCreator">
            <template #default="scope">
              <el-input v-model="scope.row.esQaCreator" :placeholder="$t('btn.enterPrefix')+'EsQaCreator'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsQaModifier" align="center" prop="esQaModifier">
            <template #default="scope">
              <el-input v-model="scope.row.esQaModifier" :placeholder="$t('btn.enterPrefix')+'EsQaModifier'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="EsQaModifyTime" align="center" prop="esQaModifyTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.esQaModifyTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="创建者" align="center" prop="createBy">
            <template #default="scope">
              <el-input v-model="scope.row.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="创建时间" align="center" prop="createTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.createTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="更新者" align="center" prop="updateBy">
            <template #default="scope">
              <el-input v-model="scope.row.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="更新时间" align="center" prop="updateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.updateTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ppecmaster">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpEcMaster,
 addPpEcMaster, delPpEcMaster, 
 updatePpEcMaster,getPpEcMaster, 
 } 
from '@/api/logistics/ppecmaster.js'
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
  emEcIssueDate: undefined,
//是否查询（1是）
  emEcNo: undefined,
//是否查询（1是）
  emEcTitle: undefined,
//是否查询（1是）
  emEcAssigned: undefined,
//是否查询（1是）
  emEcManageCategory: undefined,
//是否查询（1是）
  emEcLiaisonNo: undefined,
//是否查询（1是）
  emEcEppLiaisonNo: undefined,
//是否查询（1是）
  emEcFppLiaisonNo: undefined,
//是否查询（1是）
  emEcExternalNo: undefined,
//是否查询（1是）
  emEcEntryDate: undefined,
//是否查询（1是）
  esSopStae: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'emSFID', label: 'SFID' },
  { visible: true, prop: 'emEcIssueDate', label: '发行日' },
  { visible: true, prop: 'emEcNo', label: '设变No.' },
  { visible: true, prop: 'emEcDoc', label: '关联文件' },
  { visible: true, prop: 'emEcStatus', label: '状态' },
  { visible: true, prop: 'emEcTitle', label: '标题' },
  { visible: true, prop: 'emEcContent', label: '内容' },
  { visible: true, prop: 'emEcAssigned', label: '担当' },
  { visible: false, prop: 'emEcLossAmount', label: '损失金额' },
  { visible: false, prop: 'emEcManageCategory', label: '管理区分' },
  { visible: false, prop: 'emEcLiaisonNo', label: '联络No.' },
  { visible: false, prop: 'emEcLiaisonDoc', label: '联络文件' },
  { visible: false, prop: 'emEcEppLiaisonNo', label: 'EppNo.' },
  { visible: false, prop: 'emEcEppLiaisonDoc', label: 'Epp文件' },
  { visible: false, prop: 'emEcFppLiaisonNo', label: 'FppNo.' },
  { visible: false, prop: 'emEcFppLiaisonDoc', label: 'Fpp文件' },
  { visible: false, prop: 'emEcExternalNo', label: '外部No.' },
  { visible: false, prop: 'emEcExternalDoc', label: '外部文件' },
  { visible: false, prop: 'emEcImpDept', label: '输入部门' },
  { visible: false, prop: 'emEcEntryDate', label: '输入日' },
  { visible: false, prop: 'esSopStae', label: 'SOP' },
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



// 发行日时间范围
const dateRangeEmEcIssueDate = ref([])



















// 输入日时间范围
const dateRangeEmEcEntryDate = ref([])





















//字典参数
var dictParams = [
  { dictType: "sys_ec_status" },
  { dictType: "sql_ec_group" },
  { dictType: "sys_ec_mgtype" },
  { dictType: "sys_sop_yn" },
  { dictType: "sys_is_deleted" },
  { dictType: "sys_pur_type" },
  { dictType: "sys_normal_whether" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从主设变/pp_ec_master表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEmEcIssueDate.value, 'EmEcIssueDate');
  proxy.addDateRange(queryParams, dateRangeEmEcEntryDate.value, 'EmEcEntryDate');
  loading.value = true
  listPpEcMaster(queryParams).then(res => {
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
  // 发行日时间范围
  dateRangeEmEcIssueDate.value = []
  // 输入日时间范围
  dateRangeEmEcEntryDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.emSFID);
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
    emSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    emEcIssueDate: [{ required: true, message: "发行日"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    emEcNo: [{ required: true, message: "设变No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    emEcStatus: [{ required: true, message: "状态"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    emEcTitle: [{ required: true, message: "标题"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    emEcContent: [{ required: true, message: "内容"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    emEcAssigned: [{ required: true, message: "担当"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    emEcLossAmount: [{ required: true, message: "损失金额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    emEcManageCategory: [{ required: true, message: "管理区分"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    emEcImpDept: [{ required: true, message: "输入部门"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    emEcEntryDate: [{ required: true, message: "输入日"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    esSopStae: [{ required: true, message: "SOP"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ec_status: [],
    // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ec_group: [],
    // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ec_mgtype: [],
    // SOP 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_sop_yn: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_deleted: [],
    // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_type: [],
    // 检验否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_normal_whether: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
isDeletedOptions: [],
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
    emSFID: 0,
    emEcIssueDate: null,
    emEcNo: null,
    emEcDoc: null,
    emEcStatus: null,
    emEcTitle: null,
    emEcContent: null,
    emEcAssigned: null,
    emEcLossAmount: 0,
    emEcManageCategory: 0,
    emEcLiaisonNo: null,
    emEcLiaisonDoc: null,
    emEcEppLiaisonNo: null,
    emEcEppLiaisonDoc: null,
    emEcFppLiaisonNo: null,
    emEcFppLiaisonDoc: null,
    emEcExternalNo: null,
    emEcExternalDoc: null,
    emEcImpDept: null,
    emEcEntryDate: null,
    esSopStae: 0,
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
  ppEcSlaveList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'主设变'
  opertype.value = 1
  form.value.emEcIssueDate= new Date()
  form.value.emEcStatus= 0
  form.value.emEcAssigned= []
  form.value.emEcLossAmount= 0
  form.value.emEcManageCategory= 0
  form.value.emEcEntryDate= new Date()
  form.value.esSopStae= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.emSFID || ids.value
  getPpEcMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '主设变'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppEcSlaveList.value = res.data.ppEcSlaveNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppEcSlaveNav = ppEcSlaveList.value
      if (form.value.emSFID != undefined && opertype.value === 2) {
        updatePpEcMaster(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpEcMaster(form.value).then((res) => {
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
  const Ids = row.emSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpEcMaster(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<主设变.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpEcMaster/export', { ...queryParams })
    })
}

/*********************从设变子表信息*************************/
const ppEcSlaveList = ref([])
const checkedPpEcSlave = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 从设变序号 */
function rowPpEcSlaveIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 从设变添加按钮操作 */
function handleAddPpEcSlave() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.esEntryDate = null;
  //obj.esEcNo = null;
  //obj.esModel = null;
  //obj.esItem = null;
  //obj.esSubItem = null;
  //obj.esOldItem = null;
  //obj.esOldItemText = null;
  //obj.esOldUsageQty = null;
  //obj.esOldSetLoc = null;
  //obj.esNewItem = null;
  //obj.esNewItemText = null;
  //obj.esNewUsageQty = null;
  //obj.esNewSetLoc = null;
  //obj.esBomNo = null;
  //obj.esChange = null;
  //obj.eslocal = null;
  //obj.esnote = null;
  //obj.esOldProcess = null;
  //obj.esBomDate = null;
  //obj.emEcImpDept = null;
  //obj.esPurType = null;
  //obj.esSloc = null;
  //obj.esInsmk = null;
  //obj.esMstae = null;
  //obj.esSopStae = null;
  //obj.esOldCurrStock = null;
  //obj.esNewCurrStock = null;
  //obj.esPurEntryDate = null;
  //obj.esSupplier = null;
  //obj.esPurOrder = null;
  //obj.esPurNote = null;
  //obj.esPurCreator = null;
  //obj.esPurModifier = null;
  //obj.esPurModifyTime = null;
  //obj.esPmcEntryDate = null;
  //obj.esPmcLot = null;
  //obj.esPmcMemo = null;
  //obj.esPmcNote = null;
  //obj.esPmcCreator = null;
  //obj.esPmcModifier = null;
  //obj.esPmcModifyTime = null;
  //obj.esIqcEntryDate = null;
  //obj.esIqcOrder = null;
  //obj.esIqcNote = null;
  //obj.esIqcCreator = null;
  //obj.esIqcModifier = null;
  //obj.esIqcModifyTime = null;
  //obj.esMmEntryDate = null;
  //obj.esMmLot = null;
  //obj.esMmMocNo = null;
  //obj.esMmNote = null;
  //obj.esMmCreator = null;
  //obj.esMmModifier = null;
  //obj.esMmModifyTime = null;
  //obj.esPpEntryDate = null;
  //obj.esPpLine = null;
  //obj.esPpLot = null;
  //obj.esPpNote = null;
  //obj.esPpCreator = null;
  //obj.esPpModifier = null;
  //obj.esPpModifyTime = null;
  //obj.esPcbaEntryDate = null;
  //obj.esPcbaLine = null;
  //obj.esPcbaLot = null;
  //obj.esPcbaNote = null;
  //obj.esPcbaCreator = null;
  //obj.esPcbaModifier = null;
  //obj.esPcbaModifyTime = null;
  //obj.esQaEntryDate = null;
  //obj.esQaLot = null;
  //obj.esQaNote = null;
  //obj.esQaCreator = null;
  //obj.esQaModifier = null;
  //obj.esQaModifyTime = null;
  //obj.remark = null;
  //obj.createBy = null;
  //obj.createTime = null;
  //obj.updateBy = null;
  //obj.updateTime = null;
  ppEcSlaveList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpEcSlaveSelectionChange(selection) {
  checkedPpEcSlave.value = selection.map(item => item.index)
}

/** 从设变删除按钮操作 */
function handleDeletePpEcSlave() {
  if(checkedPpEcSlave.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的从设变数据')
  } else {
    const PpEcSlaves = ppEcSlaveList.value;
    const checkedPpEcSlaves = checkedPpEcSlave.value;
    ppEcSlaveList.value = PpEcSlaves.filter(function(item) {
      return checkedPpEcSlaves.indexOf(item.index) == -1
    });
  }
}

/** 从设变详情 */
function rowClick(row) {
  const id = row.emSFID || ids.value
  getPpEcMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppEcSlaveList.value = data.ppEcSlaveNav
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