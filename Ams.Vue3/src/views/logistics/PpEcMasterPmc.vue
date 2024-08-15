<!--
 * @Descripttion: 生管/pp_ec_master_pmc
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/31 15:49:28
 * @column：46
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
      <el-form-item label="设变No. " prop="ecmNo">
        <el-input v-model="queryParams.ecmNo" :placeholder="$t('btn.enterSearchPrefix')+'设变No. '+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="标题 " prop="ecmTitle">
        <el-input v-model="queryParams.ecmTitle" :placeholder="$t('btn.enterSearchPrefix')+'标题 '+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="内容 " prop="ecmContent">
        <el-input v-model="queryParams.ecmContent" :placeholder="$t('btn.enterSearchPrefix')+'内容 '+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="担当 " prop="ecmLeader">
        <el-select filterable clearable   v-model="queryParams.ecmLeader" :placeholder="$t('btn.selectSearchPrefix')+'担当 '+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="管理区分 " prop="ecmManageCategory">
        <el-select filterable clearable   v-model="queryParams.ecmManageCategory" :placeholder="$t('btn.selectSearchPrefix')+'管理区分 '+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ec_mgtype " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
      <el-form-item label="SOP更新否 " prop="ecmSopStated">
        <el-radio-group v-model="queryParams.ecmSopStated">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_flag_list " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="实施标记 " prop="ecmImplStated">
        <el-radio-group v-model="queryParams.ecmImplStated">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_flag_list " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
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
        <el-button class="btn-add" v-hasPermi="['pp:ecmasterpmc:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:ecmasterpmc:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:ecmasterpmc:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecmasterpmc:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpEcMasterPmc/importTemplate"
                  importUrl="/Logistics/PpEcMasterPmc/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecmasterpmc:export']">
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
      <el-table-column prop="ecmSfId" label="ID" align="center" v-if="columns.showColumn('ecmSfId')"/>
      <el-table-column prop="ecmIssueDate" label="发行日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecmIssueDate')"/>
      <el-table-column prop="ecmNo" label="设变No. " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmNo')"/>
      <el-table-column prop="ecmFileUrl" label="关联文件 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmFileUrl')"/>
      <el-table-column prop="ecmStated" label="设变状态 " align="center" v-if="columns.showColumn('ecmStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.ecmStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmTitle" label="标题 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmTitle')"/>
      <el-table-column prop="ecmContent" label="内容 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmContent')"/>
      <el-table-column prop="ecmLeader" label="担当 " align="center" v-if="columns.showColumn('ecmLeader')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.ecmLeader"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmLossAmount" label="损失金额 " align="center" v-if="columns.showColumn('ecmLossAmount')"/>
      <el-table-column prop="ecmManageCategory" label="管理区分 " align="center" v-if="columns.showColumn('ecmManageCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_mgtype " :value="scope.row.ecmManageCategory"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmLiaisonNo" label="联络No. " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmLiaisonNo')"/>
      <el-table-column prop="ecmLiaisonFileUrl" label="联络文件 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmLiaisonFileUrl')"/>
      <el-table-column prop="ecmEppLiaisonNo" label="EppNo. " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmEppLiaisonNo')"/>
      <el-table-column prop="ecmEppLiaisonFileUrl" label="Epp文件 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmEppLiaisonFileUrl')"/>
      <el-table-column prop="ecmFppLiaisonNo" label="FppNo. " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmFppLiaisonNo')"/>
      <el-table-column prop="ecmFppLiaisonFileUrl" label="Fpp文件 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmFppLiaisonFileUrl')"/>
      <el-table-column prop="ecmExternalNo" label="外部No. " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmExternalNo')"/>
      <el-table-column prop="ecmExternalFileUrl" label="外部文件 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmExternalFileUrl')"/>
      <el-table-column prop="ecmEnteredDept" label="输入部门 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ecmEnteredDept')"/>
      <el-table-column prop="ecmEnteredDate" label="输入日" :show-overflow-tooltip="true"  v-if="columns.showColumn('ecmEnteredDate')"/>
      <el-table-column prop="ecmSopStated" label="SOP更新否 " align="center" v-if="columns.showColumn('ecmSopStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecmSopStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="ecmImplStated" label="实施标记 " align="center" v-if="columns.showColumn('ecmImplStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.ecmImplStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="rEF01" label="预留A " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rEF01')"/>
      <el-table-column prop="rEF02" label="预留B " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rEF02')"/>
      <el-table-column prop="rEF03" label="预留C " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rEF03')"/>
      <el-table-column prop="rEF04" label="预留1 " align="center" v-if="columns.showColumn('rEF04')"/>
      <el-table-column prop="rEF05" label="预留2 " align="center" v-if="columns.showColumn('rEF05')"/>
      <el-table-column prop="rEF06" label="预留3" align="center" v-if="columns.showColumn('rEF06')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:ecmasterpmc:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:ecmasterpmc:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppEcSlavePmcList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="pmcSfId" label="ID"/>
        <el-table-column prop="pmcParentSfId" label="父ID"/>
        <el-table-column prop="pmcEcNo" label="设变No. "/>
        <el-table-column prop="pmcModel" label="机种 "/>
        <el-table-column prop="pmcItem" label="物料 "/>
        <el-table-column prop="pmcImplStated" label="实施标记 ">
          <template #default="scope">
            <dict-tag :options=" options.sys_flag_list " :value="scope.row.pmcImplStated"  />
          </template>
        </el-table-column>
        <el-table-column prop="pmcEnteredDate" label="输入日期"/>
        <el-table-column prop="pmcPreLot" label="预投批次 "/>
        <el-table-column prop="pmcDisposal" label="旧品处理 ">
          <template #default="scope">
            <dict-tag :options=" options.sys_old_disposal " :value="scope.row.pmcDisposal"  />
          </template>
        </el-table-column>
        <el-table-column prop="pmcNote" label="记事 "/>
        <el-table-column prop="rEF01" label="预留A "/>
        <el-table-column prop="rEF02" label="预留B "/>
        <el-table-column prop="rEF03" label="预留C "/>
        <el-table-column prop="rEF04" label="预留1 "/>
        <el-table-column prop="rEF05" label="预留2 "/>
        <el-table-column prop="rEF06" label="预留3"/>
        <el-table-column prop="remark" label="备注说明"/>
        <el-table-column prop="createBy" label="创建人员"/>
        <el-table-column prop="createTime" label="创建时间"/>
        <el-table-column prop="updateBy" label="更新人员"/>
        <el-table-column prop="updateTime" label="更新时间"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改生管对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="ID" prop="ecmSfId">
              <el-input-number v-model.number="form.ecmSfId" controls-position="right" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')" :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行日期" prop="ecmIssueDate">
              <el-date-picker v-model="form.ecmIssueDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No. " prop="ecmNo">
              <el-input v-model="form.ecmNo" :placeholder="$t('btn.enterPrefix')+'设变No. '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关联文件 " prop="ecmFileUrl">
              <el-input v-model="form.ecmFileUrl" :placeholder="$t('btn.enterPrefix')+'关联文件 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="设变状态 " prop="ecmStated">
              <el-select filterable clearable   v-model="form.ecmStated"  :placeholder="$t('btn.selectPrefix')+'设变状态 '+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ec_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="标题 " prop="ecmTitle">
              <el-input v-model="form.ecmTitle" :placeholder="$t('btn.enterPrefix')+'标题 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内容 " prop="ecmContent">
              <el-input v-model="form.ecmContent" :placeholder="$t('btn.enterPrefix')+'内容 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当 " prop="ecmLeader">
              <el-select filterable clearable   v-model="form.ecmLeader"  :placeholder="$t('btn.selectPrefix')+'担当 '+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="损失金额 " prop="ecmLossAmount">
              <el-input-number v-model.number="form.ecmLossAmount" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'损失金额 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="管理区分 " prop="ecmManageCategory">
              <el-select filterable clearable   v-model="form.ecmManageCategory"  :placeholder="$t('btn.selectPrefix')+'管理区分 '+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ec_mgtype" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="联络No. " prop="ecmLiaisonNo">
              <el-input v-model="form.ecmLiaisonNo" :placeholder="$t('btn.enterPrefix')+'联络No. '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络文件 " prop="ecmLiaisonFileUrl">
              <el-input v-model="form.ecmLiaisonFileUrl" :placeholder="$t('btn.enterPrefix')+'联络文件 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EppNo. " prop="ecmEppLiaisonNo">
              <el-input v-model="form.ecmEppLiaisonNo" :placeholder="$t('btn.enterPrefix')+'EppNo. '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Epp文件 " prop="ecmEppLiaisonFileUrl">
              <el-input v-model="form.ecmEppLiaisonFileUrl" :placeholder="$t('btn.enterPrefix')+'Epp文件 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="FppNo. " prop="ecmFppLiaisonNo">
              <el-input v-model="form.ecmFppLiaisonNo" :placeholder="$t('btn.enterPrefix')+'FppNo. '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fpp文件 " prop="ecmFppLiaisonFileUrl">
              <el-input v-model="form.ecmFppLiaisonFileUrl" :placeholder="$t('btn.enterPrefix')+'Fpp文件 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部No. " prop="ecmExternalNo">
              <el-input v-model="form.ecmExternalNo" :placeholder="$t('btn.enterPrefix')+'外部No. '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部文件 " prop="ecmExternalFileUrl">
              <el-input v-model="form.ecmExternalFileUrl" :placeholder="$t('btn.enterPrefix')+'外部文件 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入部门 " prop="ecmEnteredDept">
              <el-input v-model="form.ecmEnteredDept" :placeholder="$t('btn.enterPrefix')+'输入部门 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日" prop="ecmEnteredDate">
              <el-date-picker v-model="form.ecmEnteredDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="SOP更新否 " prop="ecmSopStated">
              <el-radio-group v-model="form.ecmSopStated">
                <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实施标记 " prop="ecmImplStated">
              <el-radio-group v-model="form.ecmImplStated">
                <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留A " prop="rEF01">
              <el-input v-model="form.rEF01" :placeholder="$t('btn.enterPrefix')+'预留A '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留B " prop="rEF02">
              <el-input v-model="form.rEF02" :placeholder="$t('btn.enterPrefix')+'预留B '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留C " prop="rEF03">
              <el-input v-model="form.rEF03" :placeholder="$t('btn.enterPrefix')+'预留C '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留1 " prop="rEF04">
              <el-input-number v-model.number="form.rEF04" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留1 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留2 " prop="rEF05">
              <el-input-number v-model.number="form.rEF05" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留2 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预留3" prop="rEF06">
              <el-input-number v-model.number="form.rEF06" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A " prop="uDF01">
              <el-input v-model="form.uDF01" :placeholder="$t('btn.enterPrefix')+'自定义A '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B " prop="uDF02">
              <el-input v-model="form.uDF02" :placeholder="$t('btn.enterPrefix')+'自定义B '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C " prop="uDF03">
              <el-input v-model="form.uDF03" :placeholder="$t('btn.enterPrefix')+'自定义C '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D " prop="uDF04">
              <el-input v-model="form.uDF04" :placeholder="$t('btn.enterPrefix')+'自定义D '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E " prop="uDF05">
              <el-input v-model="form.uDF05" :placeholder="$t('btn.enterPrefix')+'自定义E '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F " prop="uDF06">
              <el-input v-model="form.uDF06" :placeholder="$t('btn.enterPrefix')+'自定义F '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="自定义1 " prop="uDF51">
              <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义1 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="自定义2 " prop="uDF52">
              <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义2 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="自定义3 " prop="uDF53">
              <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义3 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4 " prop="uDF54">
              <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义4 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5 " prop="uDF55">
              <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义5 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6 " prop="uDF56">
              <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义6 '+$t('btn.enterSuffix')" />
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

          <el-col :lg="12">
            <el-form-item label="备注说明" prop="remark">
              <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建人员" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建人员'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新人员" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新人员'+$t('btn.enterSuffix')" />
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
        <el-divider content-position="center">Pmc设变</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpEcSlavePmc">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpEcSlavePmc">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppEcSlavePmcList" :row-class-name="rowPpEcSlavePmcIndex" @selection-change="handlePpEcSlavePmcSelectionChange" ref="PpEcSlavePmcRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="设变No. " align="center" prop="pmcEcNo">
            <template #default="scope">
              <el-input v-model="scope.row.pmcEcNo" :placeholder="$t('btn.enterPrefix')+'设变No. '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="机种 " align="center" prop="pmcModel">
            <template #default="scope">
              <el-input v-model="scope.row.pmcModel" :placeholder="$t('btn.enterPrefix')+'机种 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="物料 " align="center" prop="pmcItem">
            <template #default="scope">
              <el-input v-model="scope.row.pmcItem" :placeholder="$t('btn.enterPrefix')+'物料 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="实施标记 " prop="pmcImplStated">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.pmcImplStated" :placeholder="$t('btn.enterPrefix')+'实施标记 '+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="输入日期" align="center" prop="pmcEnteredDate">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.pmcEnteredDate" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="预投批次 " align="center" prop="pmcPreLot">
            <template #default="scope">
              <el-input v-model="scope.row.pmcPreLot" :placeholder="$t('btn.enterPrefix')+'预投批次 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧品处理 " prop="pmcDisposal">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.pmcDisposal" :placeholder="$t('btn.enterPrefix')+'旧品处理 '+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_old_disposal" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="记事 " align="center" prop="pmcNote">
            <template #default="scope">
              <el-input v-model="scope.row.pmcNote" :placeholder="$t('btn.enterPrefix')+'记事 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留A " align="center" prop="rEF01">
            <template #default="scope">
              <el-input v-model="scope.row.rEF01" :placeholder="$t('btn.enterPrefix')+'预留A '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留B " align="center" prop="rEF02">
            <template #default="scope">
              <el-input v-model="scope.row.rEF02" :placeholder="$t('btn.enterPrefix')+'预留B '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留C " align="center" prop="rEF03">
            <template #default="scope">
              <el-input v-model="scope.row.rEF03" :placeholder="$t('btn.enterPrefix')+'预留C '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留1 " align="center" prop="rEF04" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.rEF04" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留1 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留2 " align="center" prop="rEF05" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.rEF05" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留2 '+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="预留3" align="center" prop="rEF06" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.rEF06" controls-position="right" :placeholder="$t('btn.enterPrefix')+'预留3'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="备注说明" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="创建人员" align="center" prop="createBy">
            <template #default="scope">
              <el-input v-model="scope.row.createBy" :placeholder="$t('btn.enterPrefix')+'创建人员'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="创建时间" align="center" prop="createTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.createTime" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="更新人员" align="center" prop="updateBy">
            <template #default="scope">
              <el-input v-model="scope.row.updateBy" :placeholder="$t('btn.enterPrefix')+'更新人员'+$t('btn.enterSuffix')" />
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

<script setup name="ppecmasterpmc">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpEcMasterPmc,
 addPpEcMasterPmc, delPpEcMasterPmc, 
 updatePpEcMasterPmc,getPpEcMasterPmc, 
 } 
from '@/api/logistics/ppecmasterpmc.js'
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
  sort: 'EcmIssueDate',
  sortType: 'desc',
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
  ecmManageCategory: undefined,
//是否查询（1是）
  ecmEnteredDate: undefined,
//是否查询（1是）
  ecmSopStated: undefined,
//是否查询（1是）
  ecmImplStated: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'ecmSfId', label: 'ID' },
  { visible: true, prop: 'ecmIssueDate', label: '发行日期' },
  { visible: true, prop: 'ecmNo', label: '设变No. ' },
  { visible: true, prop: 'ecmFileUrl', label: '关联文件 ' },
  { visible: true, prop: 'ecmStated', label: '设变状态 ' },
  { visible: true, prop: 'ecmTitle', label: '标题 ' },
  { visible: true, prop: 'ecmContent', label: '内容 ' },
  { visible: true, prop: 'ecmLeader', label: '担当 ' },
  { visible: false, prop: 'ecmLossAmount', label: '损失金额 ' },
  { visible: false, prop: 'ecmManageCategory', label: '管理区分 ' },
  { visible: false, prop: 'ecmLiaisonNo', label: '联络No. ' },
  { visible: false, prop: 'ecmLiaisonFileUrl', label: '联络文件 ' },
  { visible: false, prop: 'ecmEppLiaisonNo', label: 'EppNo. ' },
  { visible: false, prop: 'ecmEppLiaisonFileUrl', label: 'Epp文件 ' },
  { visible: false, prop: 'ecmFppLiaisonNo', label: 'FppNo. ' },
  { visible: false, prop: 'ecmFppLiaisonFileUrl', label: 'Fpp文件 ' },
  { visible: false, prop: 'ecmExternalNo', label: '外部No. ' },
  { visible: false, prop: 'ecmExternalFileUrl', label: '外部文件 ' },
  { visible: false, prop: 'ecmEnteredDept', label: '输入部门 ' },
  { visible: false, prop: 'ecmEnteredDate', label: '输入日' },
  { visible: false, prop: 'ecmSopStated', label: 'SOP更新否 ' },
  { visible: false, prop: 'ecmImplStated', label: '实施标记 ' },
  { visible: false, prop: 'rEF01', label: '预留A ' },
  { visible: false, prop: 'rEF02', label: '预留B ' },
  { visible: false, prop: 'rEF03', label: '预留C ' },
  { visible: false, prop: 'rEF04', label: '预留1 ' },
  { visible: false, prop: 'rEF05', label: '预留2 ' },
  { visible: false, prop: 'rEF06', label: '预留3' },
  { visible: false, prop: 'remark', label: '备注说明' },
  { visible: false, prop: 'createBy', label: '创建人员' },
  { visible: false, prop: 'createTime', label: '创建时间' },
  { visible: false, prop: 'updateBy', label: '更新人员' },
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
  { dictType: "sys_flag_list" },
  { dictType: "sys_is_deleted" },
  { dictType: "sys_old_disposal" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从生管/pp_ec_master_pmc表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEcmIssueDate.value, 'EcmIssueDate');
  proxy.addDateRange(queryParams, dateRangeEcmEnteredDate.value, 'EcmEnteredDate');
  loading.value = true
  listPpEcMasterPmc(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.ecmSfId);
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
  },
  options: {
    // 设变状态  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ec_status: [],
    // 担当  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ec_group: [],
    // 管理区分  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ec_mgtype: [],
    // SOP更新否  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_flag_list: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_deleted: [],
    // 旧品处理  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_old_disposal: [],
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
    ecmSfId: 0,
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
  ppEcSlavePmcList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'生管'
  opertype.value = 1
  form.value.ecmIssueDate= new Date()
  form.value.ecmStated= 0
  form.value.ecmLeader= []
  form.value.ecmLossAmount= 0
  form.value.ecmManageCategory= 0
  form.value.ecmEnteredDate= new Date()
  form.value.ecmSopStated= 0
  form.value.ecmImplStated= 0
  form.value.rEF04= 0
  form.value.rEF05= 0
  form.value.rEF06= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.ecmSfId || ids.value
  getPpEcMasterPmc(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '生管'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppEcSlavePmcList.value = res.data.ppEcSlavePmcNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppEcSlavePmcNav = ppEcSlavePmcList.value
      if (form.value.ecmSfId != undefined && opertype.value === 2) {
        updatePpEcMasterPmc(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpEcMasterPmc(form.value).then((res) => {
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
  const Ids = row.ecmSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpEcMasterPmc(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<生管.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpEcMasterPmc/export', { ...queryParams })
    })
}

/*********************Pmc设变子表信息*************************/
const ppEcSlavePmcList = ref([])
const checkedPpEcSlavePmc = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** Pmc设变序号 */
function rowPpEcSlavePmcIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** Pmc设变添加按钮操作 */
function handleAddPpEcSlavePmc() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.pmcEcNo = null;
  //obj.pmcModel = null;
  //obj.pmcItem = null;
  //obj.pmcImplStated = null;
  //obj.pmcEnteredDate = null;
  //obj.pmcPreLot = null;
  //obj.pmcDisposal = null;
  //obj.pmcNote = null;
  //obj.rEF01 = null;
  //obj.rEF02 = null;
  //obj.rEF03 = null;
  //obj.rEF04 = null;
  //obj.rEF05 = null;
  //obj.rEF06 = null;
  //obj.remark = null;
  //obj.createBy = null;
  //obj.createTime = null;
  //obj.updateBy = null;
  //obj.updateTime = null;
  ppEcSlavePmcList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpEcSlavePmcSelectionChange(selection) {
  checkedPpEcSlavePmc.value = selection.map(item => item.index)
}

/** Pmc设变删除按钮操作 */
function handleDeletePpEcSlavePmc() {
  if(checkedPpEcSlavePmc.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的Pmc设变数据')
  } else {
    const PpEcSlavePmcs = ppEcSlavePmcList.value;
    const checkedPpEcSlavePmcs = checkedPpEcSlavePmc.value;
    ppEcSlavePmcList.value = PpEcSlavePmcs.filter(function(item) {
      return checkedPpEcSlavePmcs.indexOf(item.index) == -1
    });
  }
}

/** Pmc设变详情 */
function rowClick(row) {
  const id = row.ecmSfId || ids.value
  getPpEcMasterPmc(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppEcSlavePmcList.value = data.ppEcSlavePmcNav
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