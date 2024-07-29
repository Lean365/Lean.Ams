<!--
 * @Descripttion: 制一OPH主表/pp_output_assy_master
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 16:09:23
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工单号码" prop="pomOrderNo">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_moc_list" :loading="loading " v-model="queryParams.pomOrderNo" :placeholder="$t('btn.selectSearchPrefix')+'工单号码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_moc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产批次" prop="pomLot">
        <el-input v-model="queryParams.pomLot" :placeholder="$t('btn.enterSearchPrefix')+'生产批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种名" prop="pomModel">
        <el-input v-model="queryParams.pomModel" :placeholder="$t('btn.enterSearchPrefix')+'机种名'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="pomItem">
        <el-input v-model="queryParams.pomItem" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产日期">
        <el-date-picker
          v-model="dateRangePomDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产班组" prop="pomLine">
        <el-select filterable clearable   v-model="queryParams.pomLine" :placeholder="$t('btn.selectSearchPrefix')+'生产班组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_line_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:outputassymaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:outputassymaster:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:outputassymaster:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputassymaster:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpOutputAssyMaster/importTemplate"
                  importUrl="/Logistics/PpOutputAssyMaster/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputassymaster:export']">
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
      <el-table-column prop="pomSfid" label="SFID" align="center" v-if="columns.showColumn('pomSfid')"/>
      <el-table-column prop="pomOrderType" label="工单类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomOrderType')"/>
      <el-table-column prop="pomOrderNo" label="工单号码" align="center" v-if="columns.showColumn('pomOrderNo')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_list " :value="scope.row.pomOrderNo"  />
        </template>
      </el-table-column>
      <el-table-column prop="pomOrderQty" label="工单数量" align="center" v-if="columns.showColumn('pomOrderQty')"/>
      <el-table-column prop="pomOrderSerial" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomOrderSerial')"/>
      <el-table-column prop="pomLot" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomLot')"/>
      <el-table-column prop="pomModel" label="机种名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomModel')"/>
      <el-table-column prop="pomItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pomItem')"/>
      <el-table-column prop="pomDate" label="生产日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('pomDate')"/>
      <el-table-column prop="pomLine" label="生产班组" align="center" v-if="columns.showColumn('pomLine')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.pomLine"  />
        </template>
      </el-table-column>
      <el-table-column prop="pomDirect" label="直接人数" align="center" v-if="columns.showColumn('pomDirect')"/>
      <el-table-column prop="pomIndirect" label="间接人数" align="center" v-if="columns.showColumn('pomIndirect')"/>
      <el-table-column prop="pomStdTime" label="标准工时" align="center" v-if="columns.showColumn('pomStdTime')"/>
      <el-table-column prop="pomStdOutput" label="标准产能" align="center" v-if="columns.showColumn('pomStdOutput')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:outputassymaster:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:outputassymaster:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppOutputAssySlaveList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="posSfid" label="SFID"/>
        <el-table-column prop="posParentSfid" label="父SFID"/>
        <el-table-column prop="posProductionTime" label="生产时段">
          <template #default="scope">
            <dict-tag :options=" options.sys_phase_time " :value="scope.row.posProductionTime"  />
          </template>
        </el-table-column>
        <el-table-column prop="posRealOutput" label="实际产能"/>
        <el-table-column prop="posDownTime" label="停线时间"/>
        <el-table-column prop="posDownTimeReasons" label="停线原因">
          <template #default="scope">
            <dict-tag :options=" options.sql_line_stop " :value="scope.row.posDownTimeReasons"  />
          </template>
        </el-table-column>
        <el-table-column prop="posDownTimeDescription" label="停线说明"/>
        <el-table-column prop="posMissingReasons" label="未达成原因">
          <template #default="scope">
            <dict-tag :options=" options.sql_non_conf " :value="scope.row.posMissingReasons"  />
          </template>
        </el-table-column>
        <el-table-column prop="posMissingDescription" label="未达成说明"/>
        <el-table-column prop="posRealWorkhours" label="实际工数"/>
        <el-table-column prop="posInputsWorkhours" label="投入工数"/>
        <el-table-column prop="posRealWorkinghoursDiff" label="工时差异"/>
        <el-table-column prop="posRealOutputDiff" label="产能差异"/>
        <el-table-column prop="posAchievedRate" label="达成率"/>
        <el-table-column prop="remark" label="说明"/>
        <el-table-column prop="createBy" label="创建者"/>
        <el-table-column prop="createTime" label="创建时间"/>
        <el-table-column prop="updateBy" label="更新者"/>
        <el-table-column prop="updateTime" label="更新时间"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改制一OPH主表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="pomSfid">
              <el-input v-model.number="form.pomSfid" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单类别" prop="pomOrderType">
              <el-input v-model="form.pomOrderType" :placeholder="$t('btn.enterPrefix')+'工单类别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单号码" prop="pomOrderNo">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_moc_list" 
              :loading="loading " v-model="form.pomOrderNo"  :placeholder="$t('btn.selectPrefix')+'工单号码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_moc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工单数量" prop="pomOrderQty">
              <el-input-number v-model.number="form.pomOrderQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工单数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="pomOrderSerial">
              <el-input v-model="form.pomOrderSerial" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="pomLot">
              <el-input v-model="form.pomLot" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种名" prop="pomModel">
              <el-input v-model="form.pomModel" :placeholder="$t('btn.enterPrefix')+'机种名'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="pomItem">
              <el-input v-model="form.pomItem" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="pomDate">
              <el-date-picker v-model="form.pomDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班组" prop="pomLine">
              <el-select filterable clearable   v-model="form.pomLine"  :placeholder="$t('btn.selectPrefix')+'生产班组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_line_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="直接人数" prop="pomDirect">
              <el-input-number v-model.number="form.pomDirect" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'直接人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="pomIndirect">
              <el-input-number v-model.number="form.pomIndirect" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准工时" prop="pomStdTime">
              <el-input-number v-model.number="form.pomStdTime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'标准工时'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准产能" prop="pomStdOutput">
              <el-input-number v-model.number="form.pomStdOutput" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'标准产能'+$t('btn.enterSuffix')" />
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
        <el-divider content-position="center">制一OPH从表</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpOutputAssySlave">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpOutputAssySlave">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppOutputAssySlaveList" :row-class-name="rowPpOutputAssySlaveIndex" @selection-change="handlePpOutputAssySlaveSelectionChange" ref="PpOutputAssySlaveRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="生产时段" prop="posProductionTime">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.posProductionTime" :placeholder="$t('btn.enterPrefix')+'生产时段'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_phase_time" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="实际产能" align="center" prop="posRealOutput" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealOutput" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际产能'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="停线时间" align="center" prop="posDownTime" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posDownTime" controls-position="right" :placeholder="$t('btn.enterPrefix')+'停线时间'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="停线原因" prop="posDownTimeReasons">
            <template #default="scope">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip v-model="scope.row.posDownTimeReasons" :placeholder="$t('btn.enterPrefix')+'停线原因'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_line_stop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="停线说明" align="center" prop="posDownTimeDescription">
            <template #default="scope">
              <el-input v-model="scope.row.posDownTimeDescription" :placeholder="$t('btn.enterPrefix')+'停线说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="未达成原因" prop="posMissingReasons">
            <template #default="scope">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip v-model="scope.row.posMissingReasons" :placeholder="$t('btn.enterPrefix')+'未达成原因'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_non_conf" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="未达成说明" align="center" prop="posMissingDescription">
            <template #default="scope">
              <el-input v-model="scope.row.posMissingDescription" :placeholder="$t('btn.enterPrefix')+'未达成说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="实际工数" align="center" prop="posRealWorkhours" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealWorkhours" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实际工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="投入工数" align="center" prop="posInputsWorkhours" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posInputsWorkhours" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="工时差异" align="center" prop="posRealWorkinghoursDiff" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealWorkinghoursDiff" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工时差异'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="产能差异" align="center" prop="posRealOutputDiff" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealOutputDiff" controls-position="right" :placeholder="$t('btn.enterPrefix')+'产能差异'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="达成率" align="center" prop="posAchievedRate" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posAchievedRate" controls-position="right" :placeholder="$t('btn.enterPrefix')+'达成率'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
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

<script setup name="ppoutputassymaster">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpOutputAssyMaster,
 addPpOutputAssyMaster, delPpOutputAssyMaster, 
 updatePpOutputAssyMaster,getPpOutputAssyMaster, 
 } 
from '@/api/logistics/ppoutputassymaster.js'
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
  pomOrderNo: undefined,
//是否查询（1是）
  pomLot: undefined,
//是否查询（1是）
  pomModel: undefined,
//是否查询（1是）
  pomItem: undefined,
//是否查询（1是）
  pomDate: undefined,
//是否查询（1是）
  pomLine: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'pomSfid', label: 'SFID' },
  { visible: true, prop: 'pomOrderType', label: '工单类别' },
  { visible: true, prop: 'pomOrderNo', label: '工单号码' },
  { visible: true, prop: 'pomOrderQty', label: '工单数量' },
  { visible: true, prop: 'pomOrderSerial', label: '序列号' },
  { visible: true, prop: 'pomLot', label: '生产批次' },
  { visible: true, prop: 'pomModel', label: '机种名' },
  { visible: true, prop: 'pomItem', label: '物料' },
  { visible: false, prop: 'pomDate', label: '生产日期' },
  { visible: false, prop: 'pomLine', label: '生产班组' },
  { visible: false, prop: 'pomDirect', label: '直接人数' },
  { visible: false, prop: 'pomIndirect', label: '间接人数' },
  { visible: false, prop: 'pomStdTime', label: '标准工时' },
  { visible: false, prop: 'pomStdOutput', label: '标准产能' },
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
//定义远程搜索变量
const remotequeryList_sql_moc_list=ref([])
//定义远程搜索变量
const remotequery_sql_moc_list=ref([])
//远程字典参数
var remotedictParams_sql_moc_list = [
    { dictType: "sql_moc_list" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_moc_list).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_moc_list.value = element.list
      })
      //console.log(remotequeryList_sql_moc_list)
    })
  })
//远程搜索
const remoteMethod_sql_moc_list = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_moc_list.value = remotequeryList_sql_moc_list.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_moc_list(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_moc_list.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_moc_list = debounce((query) => {
    let arr = remotequeryList_sql_moc_list.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_moc_list.value = arr.slice(0, 5)
      addFilterOptions_sql_moc_list(query)
    } else {
      remotequery_sql_moc_list.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_moc_list =debounce((dictValue) => {
    let target = remotequeryList_sql_moc_list.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_moc_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_moc_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
// 生产日期时间范围
const dateRangePomDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_line_list" },
  { dictType: "sys_is_deleted" },
  { dictType: "sys_phase_time" },
  { dictType: "sql_line_stop" },
  { dictType: "sql_non_conf" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从制一OPH主表/pp_output_assy_master表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangePomDate.value, 'PomDate');
  loading.value = true
  listPpOutputAssyMaster(queryParams).then(res => {
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
  // 生产日期时间范围
  dateRangePomDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.pomSfid);
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
    pomSfid: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    pomOrderType: [{ required: true, message: "工单类别"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomOrderNo: [{ required: true, message: "工单号码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomOrderQty: [{ required: true, message: "工单数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomOrderSerial: [{ required: true, message: "序列号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomLot: [{ required: true, message: "生产批次"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomModel: [{ required: true, message: "机种名"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomItem: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomDate: [{ required: true, message: "生产日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomLine: [{ required: true, message: "生产班组"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    pomDirect: [{ required: true, message: "直接人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pomIndirect: [{ required: true, message: "间接人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pomStdTime: [{ required: true, message: "标准工时"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    pomStdOutput: [{ required: true, message: "标准产能"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 生产班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_list: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_deleted: [],
    // 生产时段 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_phase_time: [],
    // 停线原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_stop: [],
    // 未达成原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_non_conf: [],
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
    pomSfid: 0,
    pomOrderType: null,
    pomOrderNoChecked: [],
    pomOrderQty: 0,
    pomOrderSerial: null,
    pomLot: null,
    pomModel: null,
    pomItem: null,
    pomDate: null,
    pomLine: null,
    pomDirect: 0,
    pomIndirect: 0,
    pomStdTime: 0,
    pomStdOutput: 0,
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
  ppOutputAssySlaveList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'制一OPH主表'
  opertype.value = 1
  form.value.pomOrderQty= 0
  form.value.pomDate= new Date()
  form.value.pomLine= []
  form.value.pomDirect= 0
  form.value.pomIndirect= 0
  form.value.pomStdTime= 0
  form.value.pomStdOutput= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.pomSfid || ids.value
  getPpOutputAssyMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '制一OPH主表'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppOutputAssySlaveList.value = res.data.ppOutputAssySlaveNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppOutputAssySlaveNav = ppOutputAssySlaveList.value
      if (form.value.pomSfid != undefined && opertype.value === 2) {
        updatePpOutputAssyMaster(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpOutputAssyMaster(form.value).then((res) => {
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
  const Ids = row.pomSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpOutputAssyMaster(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<制一OPH主表.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpOutputAssyMaster/export', { ...queryParams })
    })
}

/*********************制一OPH从表子表信息*************************/
const ppOutputAssySlaveList = ref([])
const checkedPpOutputAssySlave = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 制一OPH从表序号 */
function rowPpOutputAssySlaveIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 制一OPH从表添加按钮操作 */
function handleAddPpOutputAssySlave() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.posProductionTime = null;
  //obj.posRealOutput = null;
  //obj.posDownTime = null;
  //obj.posDownTimeReasons = null;
  //obj.posDownTimeDescription = null;
  //obj.posMissingReasons = null;
  //obj.posMissingDescription = null;
  //obj.posRealWorkhours = null;
  //obj.posInputsWorkhours = null;
  //obj.posRealWorkinghoursDiff = null;
  //obj.posRealOutputDiff = null;
  //obj.posAchievedRate = null;
  //obj.remark = null;
  //obj.createBy = null;
  //obj.createTime = null;
  //obj.updateBy = null;
  //obj.updateTime = null;
  ppOutputAssySlaveList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpOutputAssySlaveSelectionChange(selection) {
  checkedPpOutputAssySlave.value = selection.map(item => item.index)
}

/** 制一OPH从表删除按钮操作 */
function handleDeletePpOutputAssySlave() {
  if(checkedPpOutputAssySlave.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的制一OPH从表数据')
  } else {
    const PpOutputAssySlaves = ppOutputAssySlaveList.value;
    const checkedPpOutputAssySlaves = checkedPpOutputAssySlave.value;
    ppOutputAssySlaveList.value = PpOutputAssySlaves.filter(function(item) {
      return checkedPpOutputAssySlaves.indexOf(item.index) == -1
    });
  }
}

/** 制一OPH从表详情 */
function rowClick(row) {
  const id = row.pomSfid || ids.value
  getPpOutputAssyMaster(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppOutputAssySlaveList.value = data.ppOutputAssySlaveNav
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