<!--
 * @Descripttion: 修理日报ma/pp_repair_pcba_ma
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/22 12:04:48
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="生产日期">
        <el-date-picker
          v-model="dateRangePdrdate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产机种" prop="pdrmodel">
        <el-input v-model="queryParams.pdrmodel" :placeholder="$t('btn.enterSearchPrefix')+'生产机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产订单" prop="pdrorder">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_oph_moc" :loading="loading " v-model="queryParams.pdrorder" :placeholder="$t('btn.selectSearchPrefix')+'生产订单'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_oph_moc " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产LOT" prop="pdrlot">
        <el-input v-model="queryParams.pdrlot" :placeholder="$t('btn.enterSearchPrefix')+'生产LOT'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['pp:repairpcbama:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:repairpcbama:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:repairpcbama:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:repairpcbama:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpRepairPcbaMa/importTemplate"
                  importUrl="/Logistics/PpRepairPcbaMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:repairpcbama:export']">
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
      <el-table-column prop="pdrSfid" label="ID" align="center" v-if="columns.showColumn('pdrSfid')"/>
      <el-table-column prop="pdrdate" label="生产日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('pdrdate')"/>
      <el-table-column prop="pdrmodel" label="生产机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrmodel')"/>
      <el-table-column prop="pdrorder" label="生产订单" align="center" v-if="columns.showColumn('pdrorder')">
        <template #default="scope">
          <dict-tag :options=" options.sql_oph_moc " :value="scope.row.pdrorder"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdrlot" label="生产LOT" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrlot')"/>
      <el-table-column prop="pdrorderqty" label="订单台数" align="center" v-if="columns.showColumn('pdrorderqty')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:repairpcbama:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:repairpcbama:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppRepairPcbaSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="pdrSfid" label="ID"/>
        <el-table-column prop="pdrParentSfid" label="父ID"/>
        <el-table-column prop="pdrlot" label="Pdrlot"/>
        <el-table-column prop="pdrpcbtype" label="板别">
          <template #default="scope">
            <dict-tag :options=" options.sql_pcb_type " :value="scope.row.pdrpcbtype"  />
          </template>
        </el-table-column>
        <el-table-column prop="pdrlotqty" label="Lot数"/>
        <el-table-column prop="pdrrealqty" label="当日生产数"/>
        <el-table-column prop="pdrrealtotal" label="累计完成数"/>
        <el-table-column prop="pdrlinename" label="生产组别"/>
        <el-table-column prop="pdrpcbcardno" label="卡号"/>
        <el-table-column prop="pdrbadnote" label="不良症状"/>
        <el-table-column prop="pdrpcbcheckout" label="检出工程">
          <template #default="scope">
            <dict-tag :options=" options.sql_insp_eng " :value="scope.row.pdrpcbcheckout"  />
          </template>
        </el-table-column>
        <el-table-column prop="pdrbadreason" label="不良原因"/>
        <el-table-column prop="pdrbadqty" label="不良数量"/>
        <el-table-column prop="pdrbadtotal" label="累计不良台数"/>
        <el-table-column prop="pdrbadresponsibility" label="责任归属">
          <template #default="scope">
            <dict-tag :options=" options.sql_resp_bel " :value="scope.row.pdrbadresponsibility"  />
          </template>
        </el-table-column>
        <el-table-column prop="pdrbadprop" label="不良性质">
          <template #default="scope">
            <dict-tag :options=" options.sql_bad_prop " :value="scope.row.pdrbadprop"  />
          </template>
        </el-table-column>
        <el-table-column prop="pdrbadserial" label="序列号"/>
        <el-table-column prop="pdrbadrepairman" label="修理">
          <template #default="scope">
            <dict-tag :options=" options.sql_repair_list " :value="scope.row.pdrbadrepairman"  />
          </template>
        </el-table-column>
        <el-table-column prop="remark" label="说明"/>
        <el-table-column prop="createBy" label="创建者"/>
        <el-table-column prop="createTime" label="创建时间"/>
        <el-table-column prop="updateBy" label="更新者"/>
        <el-table-column prop="updateTime" label="更新时间"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改修理日报ma对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="ID" prop="pdrSfid">
              <el-input v-model.number="form.pdrSfid" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="pdrdate">
              <el-date-picker v-model="form.pdrdate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产机种" prop="pdrmodel">
              <el-input v-model="form.pdrmodel" :placeholder="$t('btn.enterPrefix')+'生产机种'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产订单" prop="pdrorder">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_oph_moc" 
              :loading="loading " v-model="form.pdrorder"  :placeholder="$t('btn.selectPrefix')+'生产订单'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_oph_moc" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="生产LOT" prop="pdrlot">
              <el-input v-model="form.pdrlot" :placeholder="$t('btn.enterPrefix')+'生产LOT'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="订单台数" prop="pdrorderqty">
              <el-input-number v-model.number="form.pdrorderqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'订单台数'+$t('btn.enterSuffix')" />
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
            <el-form-item label="说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')"/>
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
        <el-divider content-position="center">修理日报slv</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpRepairPcbaSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpRepairPcbaSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppRepairPcbaSlvList" :row-class-name="rowPpRepairPcbaSlvIndex" @selection-change="handlePpRepairPcbaSlvSelectionChange" ref="PpRepairPcbaSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="Pdrlot" align="center" prop="pdrlot">
            <template #default="scope">
              <el-input v-model="scope.row.pdrlot" :placeholder="$t('btn.enterPrefix')+'Pdrlot'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="板别" prop="pdrpcbtype">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.pdrpcbtype" :placeholder="$t('btn.enterPrefix')+'板别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="Lot数" align="center" prop="pdrlotqty" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.pdrlotqty" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="当日生产数" align="center" prop="pdrrealqty" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.pdrrealqty" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当日生产数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="累计完成数" align="center" prop="pdrrealtotal" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.pdrrealtotal" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计完成数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生产组别" align="center" prop="pdrlinename">
            <template #default="scope">
              <el-input v-model="scope.row.pdrlinename" :placeholder="$t('btn.enterPrefix')+'生产组别'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="卡号" align="center" prop="pdrpcbcardno">
            <template #default="scope">
              <el-input v-model="scope.row.pdrpcbcardno" :placeholder="$t('btn.enterPrefix')+'卡号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良症状" align="center" prop="pdrbadnote">
            <template #default="scope">
              <el-input v-model="scope.row.pdrbadnote" :placeholder="$t('btn.enterPrefix')+'不良症状'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="检出工程" prop="pdrpcbcheckout">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.pdrpcbcheckout" :placeholder="$t('btn.enterPrefix')+'检出工程'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_insp_eng" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="不良原因" align="center" prop="pdrbadreason">
            <template #default="scope">
              <el-input v-model="scope.row.pdrbadreason" :placeholder="$t('btn.enterPrefix')+'不良原因'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良数量" align="center" prop="pdrbadqty" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.pdrbadqty" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="累计不良台数" align="center" prop="pdrbadtotal" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.pdrbadtotal" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计不良台数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="责任归属" prop="pdrbadresponsibility">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.pdrbadresponsibility" :placeholder="$t('btn.enterPrefix')+'责任归属'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_resp_bel" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="不良性质" prop="pdrbadprop">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.pdrbadprop" :placeholder="$t('btn.enterPrefix')+'不良性质'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_bad_prop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="序列号" align="center" prop="pdrbadserial">
            <template #default="scope">
              <el-input v-model="scope.row.pdrbadserial" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="修理" prop="pdrbadrepairman">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.pdrbadrepairman" :placeholder="$t('btn.enterPrefix')+'修理'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_repair_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
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

<script setup name="pprepairpcbama">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpRepairPcbaMa,
 addPpRepairPcbaMa, delPpRepairPcbaMa, 
 updatePpRepairPcbaMa,getPpRepairPcbaMa, 
 } 
from '@/api/logistics/pprepairpcbama.js'
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
  pdrdate: undefined,
//是否查询（1是）
  pdrmodel: undefined,
//是否查询（1是）
  pdrorder: undefined,
//是否查询（1是）
  pdrlot: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'pdrSfid', label: 'ID' },
  { visible: true, prop: 'pdrdate', label: '生产日期' },
  { visible: true, prop: 'pdrmodel', label: '生产机种' },
  { visible: true, prop: 'pdrorder', label: '生产订单' },
  { visible: true, prop: 'pdrlot', label: '生产LOT' },
  { visible: true, prop: 'pdrorderqty', label: '订单台数' },
  { visible: false, prop: 'remark', label: '说明' },
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
// 生产日期时间范围
const dateRangePdrdate = ref([])
//定义远程搜索变量
const remotequeryList_sql_oph_moc=ref([])
//定义远程搜索变量
const remotequery_sql_oph_moc=ref([])
//远程字典参数
var remotedictParams_sql_oph_moc = [
    { dictType: "sql_oph_moc" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_oph_moc).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_oph_moc.value = element.list
      })
      //console.log(remotequeryList_sql_oph_moc)
    })
  })
//远程搜索
const remoteMethod_sql_oph_moc = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_oph_moc.value = remotequeryList_sql_oph_moc.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_oph_moc(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_oph_moc.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_oph_moc = debounce((query) => {
    let arr = remotequeryList_sql_oph_moc.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_oph_moc.value = arr.slice(0, 5)
      addFilterOptions_sql_oph_moc(query)
    } else {
      remotequery_sql_oph_moc.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_oph_moc =debounce((dictValue) => {
    let target = remotequeryList_sql_oph_moc.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_oph_moc.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_oph_moc.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

//字典参数
var dictParams = [
  { dictType: "sys_is_deleted" },
  { dictType: "sql_pcb_type" },
  { dictType: "sql_insp_eng" },
  { dictType: "sql_resp_bel" },
  { dictType: "sql_bad_prop" },
  { dictType: "sql_repair_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从修理日报ma/pp_repair_pcba_ma表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangePdrdate.value, 'Pdrdate');
  loading.value = true
  listPpRepairPcbaMa(queryParams).then(res => {
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
  dateRangePdrdate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.pdrSfid);
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
    pdrSfid: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    pdrorderqty: [{ required: true, message: "订单台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_deleted: [],
    // 板别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_type: [],
    // 检出工程 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_insp_eng: [],
    // 责任归属 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_resp_bel: [],
    // 不良性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_bad_prop: [],
    // 修理 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_repair_list: [],
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
    pdrSfid: 0,
    pdrdate: null,
    pdrmodel: null,
    pdrorderChecked: [],
    pdrlot: null,
    pdrorderqty: 0,
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
  ppRepairPcbaSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'修理日报ma'
  opertype.value = 1
  form.value.pdrdate= new Date()
  form.value.pdrorderqty= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.pdrSfid || ids.value
  getPpRepairPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '修理日报ma'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppRepairPcbaSlvList.value = res.data.ppRepairPcbaSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppRepairPcbaSlvNav = ppRepairPcbaSlvList.value
      if (form.value.pdrSfid != undefined && opertype.value === 2) {
        updatePpRepairPcbaMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpRepairPcbaMa(form.value).then((res) => {
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
  const Ids = row.pdrSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpRepairPcbaMa(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<修理日报ma.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpRepairPcbaMa/export', { ...queryParams })
    })
}

/*********************修理日报slv子表信息*************************/
const ppRepairPcbaSlvList = ref([])
const checkedPpRepairPcbaSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 修理日报slv序号 */
function rowPpRepairPcbaSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 修理日报slv添加按钮操作 */
function handleAddPpRepairPcbaSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.pdrlot = null;
  //obj.pdrpcbtype = null;
  //obj.pdrlotqty = null;
  //obj.pdrrealqty = null;
  //obj.pdrrealtotal = null;
  //obj.pdrlinename = null;
  //obj.pdrpcbcardno = null;
  //obj.pdrbadnote = null;
  //obj.pdrpcbcheckout = null;
  //obj.pdrbadreason = null;
  //obj.pdrbadqty = null;
  //obj.pdrbadtotal = null;
  //obj.pdrbadresponsibility = null;
  //obj.pdrbadprop = null;
  //obj.pdrbadserial = null;
  //obj.pdrbadrepairman = null;
  //obj.remark = null;
  //obj.createBy = null;
  //obj.createTime = null;
  //obj.updateBy = null;
  //obj.updateTime = null;
  ppRepairPcbaSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpRepairPcbaSlvSelectionChange(selection) {
  checkedPpRepairPcbaSlv.value = selection.map(item => item.index)
}

/** 修理日报slv删除按钮操作 */
function handleDeletePpRepairPcbaSlv() {
  if(checkedPpRepairPcbaSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的修理日报slv数据')
  } else {
    const PpRepairPcbaSlvs = ppRepairPcbaSlvList.value;
    const checkedPpRepairPcbaSlvs = checkedPpRepairPcbaSlv.value;
    ppRepairPcbaSlvList.value = PpRepairPcbaSlvs.filter(function(item) {
      return checkedPpRepairPcbaSlvs.indexOf(item.index) == -1
    });
  }
}

/** 修理日报slv详情 */
function rowClick(row) {
  const id = row.pdrSfid || ids.value
  getPpRepairPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppRepairPcbaSlvList.value = data.ppRepairPcbaSlvNav
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