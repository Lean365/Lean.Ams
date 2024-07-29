<!--
 * @Descripttion: 主设变/pp_ec_master
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 16:35:09
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="发行日期">
        <el-date-picker
          v-model="dateRangeEcmIssueDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="设变No." prop="ecmNo">
        <el-input v-model="queryParams.ecmNo" :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="标题" prop="ecmTitle">
        <el-input v-model="queryParams.ecmTitle" :placeholder="$t('btn.enterSearchPrefix')+'标题'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="内容" prop="ecmContent">
        <el-input v-model="queryParams.ecmContent" :placeholder="$t('btn.enterSearchPrefix')+'内容'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="担当" prop="ecmLeader">
        <el-select filterable clearable   v-model="queryParams.ecmLeader" :placeholder="$t('btn.selectSearchPrefix')+'担当'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="输入部门" prop="ecmEnteredDept">
        <el-select filterable clearable   v-model="queryParams.ecmEnteredDept" :placeholder="$t('btn.selectSearchPrefix')+'输入部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="输入日">
        <el-date-picker
          v-model="dateRangeEcmEnteredDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
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
      <el-table-column prop="ecmSfid" label="Sfid" align="center" v-if="columns.showColumn('ecmSfid')"/>
      <el-table-column prop="ecmIssueDate" label="发行日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecmIssueDate')"/>
      <el-table-column prop="ecmNo" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmNo')"/>
      <el-table-column prop="ecmFileUrl" label="关联文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmFileUrl')"/>
      <el-table-column prop="ecmStated" label="设变状态" align="center" v-if="columns.showColumn('ecmStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.ecmStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmTitle" label="标题" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmTitle')"/>
      <el-table-column prop="ecmContent" label="内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmContent')"/>
      <el-table-column prop="ecmLeader" label="担当" align="center" v-if="columns.showColumn('ecmLeader')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.ecmLeader"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmLossAmount" label="损失金额" align="center" v-if="columns.showColumn('ecmLossAmount')"/>
      <el-table-column prop="ecmManageCategory" label="管理区分" align="center" v-if="columns.showColumn('ecmManageCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_mgtype " :value="scope.row.ecmManageCategory"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmLiaisonNo" label="联络No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmLiaisonNo')"/>
      <el-table-column prop="ecmLiaisonFileUrl" label="联络文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmLiaisonFileUrl')"/>
      <el-table-column prop="ecmEppLiaisonNo" label="EppNo." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmEppLiaisonNo')"/>
      <el-table-column prop="ecmEppLiaisonFileUrl" label="Epp文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmEppLiaisonFileUrl')"/>
      <el-table-column prop="ecmFppLiaisonNo" label="FppNo." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmFppLiaisonNo')"/>
      <el-table-column prop="ecmFppLiaisonFileUrl" label="Fpp文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmFppLiaisonFileUrl')"/>
      <el-table-column prop="ecmExternalNo" label="外部No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmExternalNo')"/>
      <el-table-column prop="ecmExternalFileUrl" label="外部文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmExternalFileUrl')"/>
      <el-table-column prop="ecmEnteredDept" label="输入部门" align="center" v-if="columns.showColumn('ecmEnteredDept')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.ecmEnteredDept"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmEnteredDate" label="输入日" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecmEnteredDate')"/>
      <el-table-column prop="ecmSopStated" label="SOP更新否" align="center" v-if="columns.showColumn('ecmSopStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecmSopStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmImplStated" label="实施标记" align="center" v-if="columns.showColumn('ecmImplStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecmImplStated"  />
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
        <el-table-column prop="ecsSfid" label="ID"/>
        <el-table-column prop="ecsParentSfid" label="父ID"/>
        <el-table-column prop="ecsEcNo" label="设变No."/>
        <el-table-column prop="ecsModel" label="机种"/>
        <el-table-column prop="ecsItem" label="物料"/>
        <el-table-column prop="ecsItemText" label="物料文本"/>
        <el-table-column prop="ecsSubItem" label="子物料"/>
        <el-table-column prop="ecsSubItemText" label="子物料文本"/>
        <el-table-column prop="ecsOldItem" label="旧物料"/>
        <el-table-column prop="ecsOldItemText" label="旧文本"/>
        <el-table-column prop="ecsOldCurrStock" label="旧品库存"/>
        <el-table-column prop="ecsOldUsageQty" label="用量"/>
        <el-table-column prop="ecsOldSetLoc" label="位置"/>
        <el-table-column prop="ecsNewItem" label="新物料"/>
        <el-table-column prop="ecsNewItemText" label="新文本"/>
        <el-table-column prop="ecsNewCurrStock" label="新品库存"/>
        <el-table-column prop="ecsNewUsageQty" label="用量"/>
        <el-table-column prop="ecsNewSetLoc" label="位置"/>
        <el-table-column prop="ecsBomNo" label="bom番号"/>
        <el-table-column prop="ecsChange" label="互换"/>
        <el-table-column prop="ecsDistLocal" label="区分"/>
        <el-table-column prop="ecsInstNote" label="指示"/>
        <el-table-column prop="ecsOldProcess" label="旧品处理"/>
        <el-table-column prop="ecsBomDate" label="bom日期"/>
        <el-table-column prop="ecsPurType" label="采购类型">
          <template #default="scope">
            <dict-tag :options=" options.sys_pur_type " :value="scope.row.ecsPurType"  />
          </template>
        </el-table-column>
        <el-table-column prop="ecsPurGroup" label="采购组">
          <template #default="scope">
            <dict-tag :options=" options.sys_pur_group " :value="scope.row.ecsPurGroup"  />
          </template>
        </el-table-column>
        <el-table-column prop="ecsSloc" label="仓库">
          <template #default="scope">
            <dict-tag :options=" options.sys_sloc_list " :value="scope.row.ecsSloc"  />
          </template>
        </el-table-column>
        <el-table-column prop="ecsInsmk" label="检验否">
          <template #default="scope">
            <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecsInsmk"  />
          </template>
        </el-table-column>
        <el-table-column prop="ecsPlntStated" label="工厂状态">
          <template #default="scope">
            <dict-tag :options=" options.sys_eol_list " :value="scope.row.ecsPlntStated"  />
          </template>
        </el-table-column>
        <el-table-column prop="ecsSopStated" label="SOP">
          <template #default="scope">
            <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecsSopStated"  />
          </template>
        </el-table-column>
        <el-table-column prop="ecsImplStated" label="实施标记">
          <template #default="scope">
            <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecsImplStated"  />
          </template>
        </el-table-column>
        <el-table-column prop="ecsPurEnteredDate" label="采购登入日期"/>
        <el-table-column prop="ecsPurSupplier" label="供应商"/>
        <el-table-column prop="ecsPurOrder" label="采购PO"/>
        <el-table-column prop="ecsPurNote" label="说明"/>
        <el-table-column prop="ecsPmcEnteredDate" label="生管登入日期"/>
        <el-table-column prop="ecsPmcPreLot" label="预投入批次"/>
        <el-table-column prop="ecsPmcDisposal" label="旧品处理"/>
        <el-table-column prop="ecsPmcNote" label="备注"/>
        <el-table-column prop="ecsIqcEnteredDate" label="IQC登入日期"/>
        <el-table-column prop="ecsIqcOrder" label="检验订单"/>
        <el-table-column prop="ecsIqcNote" label="说明"/>
        <el-table-column prop="ecsMmEnteredDate" label="部管登入日期"/>
        <el-table-column prop="ecsMmLot" label="领用批次"/>
        <el-table-column prop="ecsMmProOrder" label="工单"/>
        <el-table-column prop="ecsMmNote" label="说明"/>
        <el-table-column prop="ecsAssyEnteredDate" label="制一登入日期"/>
        <el-table-column prop="ecsAssyLine" label="班组"/>
        <el-table-column prop="ecsAssyPutLot" label="生产批次"/>
        <el-table-column prop="ecsAssyNote" label="说明"/>
        <el-table-column prop="ecsPcbaEnteredDate" label="制二登入日期"/>
        <el-table-column prop="ecsPcbaLine" label="Pcba班组"/>
        <el-table-column prop="ecsPcbaPutLot" label="Pcba批次"/>
        <el-table-column prop="ecsPcbaNote" label="说明"/>
        <el-table-column prop="ecsFqcEnteredDate" label="QA确认日期"/>
        <el-table-column prop="ecsFqcImplLot" label="检验批次"/>
        <el-table-column prop="ecsFqcNote" label="说明"/>
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
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="Sfid" prop="ecmSfid">
              <el-input-number v-model.number="form.ecmSfid" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Sfid'+$t('btn.enterSuffix')" :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行日期" prop="ecmIssueDate">
              <el-date-picker v-model="form.ecmIssueDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="ecmNo">
              <el-input v-model="form.ecmNo" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="关联文件" prop="ecmFileUrl">
              <UploadFile v-model="form.ecmFileUrl" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="设变状态" prop="ecmStated">
              <el-select filterable clearable   v-model="form.ecmStated"  :placeholder="$t('btn.selectPrefix')+'设变状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ec_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="标题" prop="ecmTitle">
              <el-input v-model="form.ecmTitle" :placeholder="$t('btn.enterPrefix')+'标题'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内容" prop="ecmContent">
              <el-input v-model="form.ecmContent" :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="ecmLeader">
              <el-select filterable clearable   v-model="form.ecmLeader"  :placeholder="$t('btn.selectPrefix')+'担当'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="损失金额" prop="ecmLossAmount">
              <el-input-number v-model.number="form.ecmLossAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'损失金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="管理区分" prop="ecmManageCategory">
              <el-select filterable clearable   v-model="form.ecmManageCategory"  :placeholder="$t('btn.selectPrefix')+'管理区分'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ec_mgtype" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="联络No." prop="ecmLiaisonNo">
              <el-input v-model="form.ecmLiaisonNo" :placeholder="$t('btn.enterPrefix')+'联络No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="联络文件" prop="ecmLiaisonFileUrl">
              <UploadFile v-model="form.ecmLiaisonFileUrl" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EppNo." prop="ecmEppLiaisonNo">
              <el-input v-model="form.ecmEppLiaisonNo" :placeholder="$t('btn.enterPrefix')+'EppNo.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Epp文件" prop="ecmEppLiaisonFileUrl">
              <UploadFile v-model="form.ecmEppLiaisonFileUrl" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="FppNo." prop="ecmFppLiaisonNo">
              <el-input v-model="form.ecmFppLiaisonNo" :placeholder="$t('btn.enterPrefix')+'FppNo.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="Fpp文件" prop="ecmFppLiaisonFileUrl">
              <UploadFile v-model="form.ecmFppLiaisonFileUrl" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部No." prop="ecmExternalNo">
              <el-input v-model="form.ecmExternalNo" :placeholder="$t('btn.enterPrefix')+'外部No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="外部文件" prop="ecmExternalFileUrl">
              <UploadFile v-model="form.ecmExternalFileUrl" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入部门" prop="ecmEnteredDept">
              <el-select filterable clearable   v-model="form.ecmEnteredDept"  :placeholder="$t('btn.selectPrefix')+'输入部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="输入日" prop="ecmEnteredDate">
              <el-date-picker v-model="form.ecmEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="SOP更新否" prop="ecmSopStated">
              <el-radio-group v-model="form.ecmSopStated">
                <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实施标记" prop="ecmImplStated">
              <el-radio-group v-model="form.ecmImplStated">
                <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue" :value="parseInt(item.dictValue)">
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
          <el-table-column label="设变No." align="center" prop="ecsEcNo">
            <template #default="scope">
              <el-input v-model="scope.row.ecsEcNo" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="机种" align="center" prop="ecsModel">
            <template #default="scope">
              <el-input v-model="scope.row.ecsModel" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="物料" align="center" prop="ecsItem">
            <template #default="scope">
              <el-input v-model="scope.row.ecsItem" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="物料文本" align="center" prop="ecsItemText">
            <template #default="scope">
              <el-input v-model="scope.row.ecsItemText" :placeholder="$t('btn.enterPrefix')+'物料文本'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="子物料" align="center" prop="ecsSubItem">
            <template #default="scope">
              <el-input v-model="scope.row.ecsSubItem" :placeholder="$t('btn.enterPrefix')+'子物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="子物料文本" align="center" prop="ecsSubItemText">
            <template #default="scope">
              <el-input v-model="scope.row.ecsSubItemText" :placeholder="$t('btn.enterPrefix')+'子物料文本'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧物料" align="center" prop="ecsOldItem">
            <template #default="scope">
              <el-input v-model="scope.row.ecsOldItem" :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧文本" align="center" prop="ecsOldItemText">
            <template #default="scope">
              <el-input v-model="scope.row.ecsOldItemText" :placeholder="$t('btn.enterPrefix')+'旧文本'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧品库存" align="center" prop="ecsOldCurrStock" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.ecsOldCurrStock" controls-position="right" :placeholder="$t('btn.enterPrefix')+'旧品库存'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="用量" align="center" prop="ecsOldUsageQty" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.ecsOldUsageQty" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="ecsOldSetLoc">
            <template #default="scope">
              <el-input v-model="scope.row.ecsOldSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新物料" align="center" prop="ecsNewItem">
            <template #default="scope">
              <el-input v-model="scope.row.ecsNewItem" :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新文本" align="center" prop="ecsNewItemText">
            <template #default="scope">
              <el-input v-model="scope.row.ecsNewItemText" :placeholder="$t('btn.enterPrefix')+'新文本'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新品库存" align="center" prop="ecsNewCurrStock" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.ecsNewCurrStock" controls-position="right" :placeholder="$t('btn.enterPrefix')+'新品库存'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="用量" align="center" prop="ecsNewUsageQty" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.ecsNewUsageQty" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="ecsNewSetLoc">
            <template #default="scope">
              <el-input v-model="scope.row.ecsNewSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="bom番号" align="center" prop="ecsBomNo">
            <template #default="scope">
              <el-input v-model="scope.row.ecsBomNo" :placeholder="$t('btn.enterPrefix')+'bom番号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="互换" align="center" prop="ecsChange">
            <template #default="scope">
              <el-input v-model="scope.row.ecsChange" :placeholder="$t('btn.enterPrefix')+'互换'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="区分" align="center" prop="ecsDistLocal">
            <template #default="scope">
              <el-input v-model="scope.row.ecsDistLocal" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="指示" align="center" prop="ecsInstNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsInstNote" :placeholder="$t('btn.enterPrefix')+'指示'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧品处理" align="center" prop="ecsOldProcess">
            <template #default="scope">
              <el-input v-model="scope.row.ecsOldProcess" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="bom日期" align="center" prop="ecsBomDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsBomDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="采购类型" prop="ecsPurType">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.ecsPurType" :placeholder="$t('btn.enterPrefix')+'采购类型'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="采购组" prop="ecsPurGroup">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.ecsPurGroup" :placeholder="$t('btn.enterPrefix')+'采购组'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="仓库" prop="ecsSloc">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.ecsSloc" :placeholder="$t('btn.enterPrefix')+'仓库'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="检验否" prop="ecsInsmk">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.ecsInsmk" :placeholder="$t('btn.enterPrefix')+'检验否'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="工厂状态" prop="ecsPlntStated">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.ecsPlntStated" :placeholder="$t('btn.enterPrefix')+'工厂状态'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_eol_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="SOP" prop="ecsSopStated">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.ecsSopStated" :placeholder="$t('btn.enterPrefix')+'SOP'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="实施标记" prop="ecsImplStated">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.ecsImplStated" :placeholder="$t('btn.enterPrefix')+'实施标记'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="采购登入日期" align="center" prop="ecsPurEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsPurEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="供应商" align="center" prop="ecsPurSupplier">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPurSupplier" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="采购PO" align="center" prop="ecsPurOrder">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPurOrder" :placeholder="$t('btn.enterPrefix')+'采购PO'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="ecsPurNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPurNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生管登入日期" align="center" prop="ecsPmcEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsPmcEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="预投入批次" align="center" prop="ecsPmcPreLot">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPmcPreLot" :placeholder="$t('btn.enterPrefix')+'预投入批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧品处理" align="center" prop="ecsPmcDisposal">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPmcDisposal" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="ecsPmcNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPmcNote" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="IQC登入日期" align="center" prop="ecsIqcEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsIqcEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="检验订单" align="center" prop="ecsIqcOrder">
            <template #default="scope">
              <el-input v-model="scope.row.ecsIqcOrder" :placeholder="$t('btn.enterPrefix')+'检验订单'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="ecsIqcNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsIqcNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="部管登入日期" align="center" prop="ecsMmEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsMmEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="领用批次" align="center" prop="ecsMmLot">
            <template #default="scope">
              <el-input v-model="scope.row.ecsMmLot" :placeholder="$t('btn.enterPrefix')+'领用批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="工单" align="center" prop="ecsMmProOrder">
            <template #default="scope">
              <el-input v-model="scope.row.ecsMmProOrder" :placeholder="$t('btn.enterPrefix')+'工单'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="ecsMmNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsMmNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="制一登入日期" align="center" prop="ecsAssyEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsAssyEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="班组" align="center" prop="ecsAssyLine">
            <template #default="scope">
              <el-input v-model="scope.row.ecsAssyLine" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生产批次" align="center" prop="ecsAssyPutLot">
            <template #default="scope">
              <el-input v-model="scope.row.ecsAssyPutLot" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="ecsAssyNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsAssyNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="制二登入日期" align="center" prop="ecsPcbaEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsPcbaEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="Pcba班组" align="center" prop="ecsPcbaLine">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPcbaLine" :placeholder="$t('btn.enterPrefix')+'Pcba班组'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="Pcba批次" align="center" prop="ecsPcbaPutLot">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPcbaPutLot" :placeholder="$t('btn.enterPrefix')+'Pcba批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="ecsPcbaNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsPcbaNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="QA确认日期" align="center" prop="ecsFqcEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.ecsFqcEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="检验批次" align="center" prop="ecsFqcImplLot">
            <template #default="scope">
              <el-input v-model="scope.row.ecsFqcImplLot" :placeholder="$t('btn.enterPrefix')+'检验批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="ecsFqcNote">
            <template #default="scope">
              <el-input v-model="scope.row.ecsFqcNote" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
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
  ecmIssueDate: undefined,
//是否查询（1是）
  ecmNo: undefined,
//是否查询（1是）
  ecmTitle: undefined,
//是否查询（1是）
  ecmContent: undefined,
//是否查询（1是）
  ecmLeader: undefined,
//是否查询（1是）
  ecmEnteredDept: undefined,
//是否查询（1是）
  ecmEnteredDate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'ecmSfid', label: 'Sfid' },
  { visible: true, prop: 'ecmIssueDate', label: '发行日期' },
  { visible: true, prop: 'ecmNo', label: '设变No.' },
  { visible: true, prop: 'ecmFileUrl', label: '关联文件' },
  { visible: true, prop: 'ecmStated', label: '设变状态' },
  { visible: true, prop: 'ecmTitle', label: '标题' },
  { visible: true, prop: 'ecmContent', label: '内容' },
  { visible: true, prop: 'ecmLeader', label: '担当' },
  { visible: false, prop: 'ecmLossAmount', label: '损失金额' },
  { visible: false, prop: 'ecmManageCategory', label: '管理区分' },
  { visible: false, prop: 'ecmLiaisonNo', label: '联络No.' },
  { visible: false, prop: 'ecmLiaisonFileUrl', label: '联络文件' },
  { visible: false, prop: 'ecmEppLiaisonNo', label: 'EppNo.' },
  { visible: false, prop: 'ecmEppLiaisonFileUrl', label: 'Epp文件' },
  { visible: false, prop: 'ecmFppLiaisonNo', label: 'FppNo.' },
  { visible: false, prop: 'ecmFppLiaisonFileUrl', label: 'Fpp文件' },
  { visible: false, prop: 'ecmExternalNo', label: '外部No.' },
  { visible: false, prop: 'ecmExternalFileUrl', label: '外部文件' },
  { visible: false, prop: 'ecmEnteredDept', label: '输入部门' },
  { visible: false, prop: 'ecmEnteredDate', label: '输入日' },
  { visible: false, prop: 'ecmSopStated', label: 'SOP更新否' },
  { visible: false, prop: 'ecmImplStated', label: '实施标记' },
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
// 发行日期时间范围
const dateRangeEcmIssueDate = ref([])
// 输入日时间范围
const dateRangeEcmEnteredDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_ec_status" },
  { dictType: "sql_ec_group" },
  { dictType: "sys_ec_mgtype" },
  { dictType: "sql_dept_list" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_is_deleted" },
  { dictType: "sys_pur_type" },
  { dictType: "sys_pur_group" },
  { dictType: "sys_sloc_list" },
  { dictType: "sys_eol_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从主设变/pp_ec_master表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEcmIssueDate.value, 'EcmIssueDate');
  proxy.addDateRange(queryParams, dateRangeEcmEnteredDate.value, 'EcmEnteredDate');
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
  // 发行日期时间范围
  dateRangeEcmIssueDate.value = []
  // 输入日时间范围
  dateRangeEcmEnteredDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.ecmSfid);
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
    ecmSfid: [{ required: true, message: "Sfid"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    ecmIssueDate: [{ required: true, message: "发行日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecmNo: [{ required: true, message: "设变No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecmStated: [{ required: true, message: "设变状态"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    ecmTitle: [{ required: true, message: "标题"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecmContent: [{ required: true, message: "内容"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecmLeader: [{ required: true, message: "担当"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ecmLossAmount: [{ required: true, message: "损失金额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecmManageCategory: [{ required: true, message: "管理区分"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    ecmEnteredDept: [{ required: true, message: "输入部门"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ecmEnteredDate: [{ required: true, message: "输入日"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ecmSopStated: [{ required: true, message: "SOP更新否"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ecmImplStated: [{ required: true, message: "实施标记"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 设变状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ec_status: [],
    // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ec_group: [],
    // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ec_mgtype: [],
    // 输入部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // SOP更新否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_flag_list: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_deleted: [],
    // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_type: [],
    // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_group: [],
    // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_sloc_list: [],
    // 工厂状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
    ecmSfid: 0,
    ecmIssueDate: null,
    ecmNo: null,
    ecmFileUrl: null,
    ecmStated: 0,
    ecmTitle: null,
    ecmContent: null,
    ecmLeader: null,
    ecmLossAmount: 0,
    ecmManageCategory: 0,
    ecmLiaisonNo: null,
    ecmLiaisonFileUrl: null,
    ecmEppLiaisonNo: null,
    ecmEppLiaisonFileUrl: null,
    ecmFppLiaisonNo: null,
    ecmFppLiaisonFileUrl: null,
    ecmExternalNo: null,
    ecmExternalFileUrl: null,
    ecmEnteredDept: null,
    ecmEnteredDate: null,
    ecmSopStated: 0,
    ecmImplStated: 0,
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
  form.value.ecmIssueDate= new Date()
  form.value.ecmStated= 0
  form.value.ecmLeader= []
  form.value.ecmLossAmount= 0
  form.value.ecmManageCategory= 0
  form.value.ecmEnteredDept= []
  form.value.ecmEnteredDate= new Date()
  form.value.ecmSopStated= 0
  form.value.ecmImplStated= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.ecmSfid || ids.value
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
      if (form.value.ecmSfid != undefined && opertype.value === 2) {
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
  const Ids = row.ecmSfid || ids.value

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
  //obj.ecsEcNo = null;
  //obj.ecsModel = null;
  //obj.ecsItem = null;
  //obj.ecsItemText = null;
  //obj.ecsSubItem = null;
  //obj.ecsSubItemText = null;
  //obj.ecsOldItem = null;
  //obj.ecsOldItemText = null;
  //obj.ecsOldCurrStock = null;
  //obj.ecsOldUsageQty = null;
  //obj.ecsOldSetLoc = null;
  //obj.ecsNewItem = null;
  //obj.ecsNewItemText = null;
  //obj.ecsNewCurrStock = null;
  //obj.ecsNewUsageQty = null;
  //obj.ecsNewSetLoc = null;
  //obj.ecsBomNo = null;
  //obj.ecsChange = null;
  //obj.ecsDistLocal = null;
  //obj.ecsInstNote = null;
  //obj.ecsOldProcess = null;
  //obj.ecsBomDate = null;
  //obj.ecsPurType = null;
  //obj.ecsPurGroup = null;
  //obj.ecsSloc = null;
  //obj.ecsInsmk = null;
  //obj.ecsPlntStated = null;
  //obj.ecsSopStated = null;
  //obj.ecsImplStated = null;
  //obj.ecsPurEnteredDate = null;
  //obj.ecsPurSupplier = null;
  //obj.ecsPurOrder = null;
  //obj.ecsPurNote = null;
  //obj.ecsPmcEnteredDate = null;
  //obj.ecsPmcPreLot = null;
  //obj.ecsPmcDisposal = null;
  //obj.ecsPmcNote = null;
  //obj.ecsIqcEnteredDate = null;
  //obj.ecsIqcOrder = null;
  //obj.ecsIqcNote = null;
  //obj.ecsMmEnteredDate = null;
  //obj.ecsMmLot = null;
  //obj.ecsMmProOrder = null;
  //obj.ecsMmNote = null;
  //obj.ecsAssyEnteredDate = null;
  //obj.ecsAssyLine = null;
  //obj.ecsAssyPutLot = null;
  //obj.ecsAssyNote = null;
  //obj.ecsPcbaEnteredDate = null;
  //obj.ecsPcbaLine = null;
  //obj.ecsPcbaPutLot = null;
  //obj.ecsPcbaNote = null;
  //obj.ecsFqcEnteredDate = null;
  //obj.ecsFqcImplLot = null;
  //obj.ecsFqcNote = null;
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
  const id = row.ecmSfid || ids.value
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