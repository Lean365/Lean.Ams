<!--
 * @Descripttion: 修理日报slv/pp_repair_pcba_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/22 12:03:40
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="Pdrlot" prop="pdrlot">
        <el-input v-model="queryParams.pdrlot" :placeholder="$t('btn.enterSearchPrefix')+'Pdrlot'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="板别" prop="pdrpcbtype">
        <el-select filterable clearable   v-model="queryParams.pdrpcbtype" :placeholder="$t('btn.selectSearchPrefix')+'板别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_pcb_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检出工程" prop="pdrpcbcheckout">
        <el-select filterable clearable   v-model="queryParams.pdrpcbcheckout" :placeholder="$t('btn.selectSearchPrefix')+'检出工程'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_insp_eng " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="责任归属" prop="pdrbadresponsibility">
        <el-select filterable clearable   v-model="queryParams.pdrbadresponsibility" :placeholder="$t('btn.selectSearchPrefix')+'责任归属'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_resp_bel " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:repairpcbaslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:repairpcbaslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:repairpcbaslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:repairpcbaslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpRepairPcbaSlv/importTemplate"
                  importUrl="/Logistics/PpRepairPcbaSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:repairpcbaslv:export']">
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
      <el-table-column prop="pdrSfid" label="ID" align="center" v-if="columns.showColumn('pdrSfid')"/>
      <el-table-column prop="pdrParentSfid" label="父ID" align="center" v-if="columns.showColumn('pdrParentSfid')"/>
      <el-table-column prop="pdrlot" label="Pdrlot" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrlot')"/>
      <el-table-column prop="pdrpcbtype" label="板别" align="center" v-if="columns.showColumn('pdrpcbtype')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_type " :value="scope.row.pdrpcbtype"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdrlotqty" label="Lot数" align="center" v-if="columns.showColumn('pdrlotqty')"/>
      <el-table-column prop="pdrrealqty" label="当日生产数" align="center" v-if="columns.showColumn('pdrrealqty')"/>
      <el-table-column prop="pdrrealtotal" label="累计完成数" align="center" v-if="columns.showColumn('pdrrealtotal')"/>
      <el-table-column prop="pdrlinename" label="生产组别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrlinename')"/>
      <el-table-column prop="pdrpcbcardno" label="卡号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrpcbcardno')"/>
      <el-table-column prop="pdrbadnote" label="不良症状" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrbadnote')"/>
      <el-table-column prop="pdrpcbcheckout" label="检出工程" align="center" v-if="columns.showColumn('pdrpcbcheckout')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_eng " :value="scope.row.pdrpcbcheckout"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdrbadreason" label="不良原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrbadreason')"/>
      <el-table-column prop="pdrbadqty" label="不良数量" align="center" v-if="columns.showColumn('pdrbadqty')"/>
      <el-table-column prop="pdrbadtotal" label="累计不良台数" align="center" v-if="columns.showColumn('pdrbadtotal')"/>
      <el-table-column prop="pdrbadresponsibility" label="责任归属" align="center" v-if="columns.showColumn('pdrbadresponsibility')">
        <template #default="scope">
          <dict-tag :options=" options.sql_resp_bel " :value="scope.row.pdrbadresponsibility"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdrbadprop" label="不良性质" align="center" v-if="columns.showColumn('pdrbadprop')">
        <template #default="scope">
          <dict-tag :options=" options.sql_bad_prop " :value="scope.row.pdrbadprop"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdrbadserial" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdrbadserial')"/>
      <el-table-column prop="pdrbadrepairman" label="修理" align="center" v-if="columns.showColumn('pdrbadrepairman')">
        <template #default="scope">
          <dict-tag :options=" options.sql_repair_list " :value="scope.row.pdrbadrepairman"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:repairpcbaslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:repairpcbaslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改修理日报slv对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
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
            <el-form-item label="父ID" prop="pdrParentSfid">
              <el-input v-model.number="form.pdrParentSfid" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Pdrlot" prop="pdrlot">
              <el-input v-model="form.pdrlot" :placeholder="$t('btn.enterPrefix')+'Pdrlot'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="板别" prop="pdrpcbtype">
              <el-select filterable clearable   v-model="form.pdrpcbtype"  :placeholder="$t('btn.selectPrefix')+'板别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="Lot数" prop="pdrlotqty">
              <el-input-number v-model.number="form.pdrlotqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当日生产数" prop="pdrrealqty">
              <el-input-number v-model.number="form.pdrrealqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当日生产数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计完成数" prop="pdrrealtotal">
              <el-input-number v-model.number="form.pdrrealtotal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计完成数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产组别" prop="pdrlinename">
              <el-input v-model="form.pdrlinename" :placeholder="$t('btn.enterPrefix')+'生产组别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="卡号" prop="pdrpcbcardno">
              <el-input v-model="form.pdrpcbcardno" :placeholder="$t('btn.enterPrefix')+'卡号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良症状" prop="pdrbadnote">
              <el-input v-model="form.pdrbadnote" :placeholder="$t('btn.enterPrefix')+'不良症状'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检出工程" prop="pdrpcbcheckout">
              <el-select filterable clearable   v-model="form.pdrpcbcheckout"  :placeholder="$t('btn.selectPrefix')+'检出工程'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_eng" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="不良原因" prop="pdrbadreason">
              <el-input v-model="form.pdrbadreason" :placeholder="$t('btn.enterPrefix')+'不良原因'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="不良数量" prop="pdrbadqty">
              <el-input-number v-model.number="form.pdrbadqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计不良台数" prop="pdrbadtotal">
              <el-input-number v-model.number="form.pdrbadtotal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计不良台数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="责任归属" prop="pdrbadresponsibility">
              <el-select filterable clearable   v-model="form.pdrbadresponsibility"  :placeholder="$t('btn.selectPrefix')+'责任归属'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_resp_bel" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="不良性质" prop="pdrbadprop">
              <el-select filterable clearable   v-model="form.pdrbadprop"  :placeholder="$t('btn.selectPrefix')+'不良性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_bad_prop" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="序列号" prop="pdrbadserial">
              <el-input v-model="form.pdrbadserial" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="修理" prop="pdrbadrepairman">
              <el-select filterable clearable   v-model="form.pdrbadrepairman"  :placeholder="$t('btn.selectPrefix')+'修理'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_repair_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
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


      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="pprepairpcbaslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpRepairPcbaSlv,
 addPpRepairPcbaSlv, delPpRepairPcbaSlv, 
 updatePpRepairPcbaSlv,getPpRepairPcbaSlv, 
 } 
from '@/api/logistics/pprepairpcbaslv.js'
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
  pdrlot: undefined,
//是否查询（1是）
  pdrpcbtype: undefined,
//是否查询（1是）
  pdrpcbcheckout: undefined,
//是否查询（1是）
  pdrbadresponsibility: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'pdrSfid', label: 'ID' },
  { visible: true, prop: 'pdrParentSfid', label: '父ID' },
  { visible: true, prop: 'pdrlot', label: 'Pdrlot' },
  { visible: true, prop: 'pdrpcbtype', label: '板别' },
  { visible: true, prop: 'pdrlotqty', label: 'Lot数' },
  { visible: true, prop: 'pdrrealqty', label: '当日生产数' },
  { visible: true, prop: 'pdrrealtotal', label: '累计完成数' },
  { visible: true, prop: 'pdrlinename', label: '生产组别' },
  { visible: false, prop: 'pdrpcbcardno', label: '卡号' },
  { visible: false, prop: 'pdrbadnote', label: '不良症状' },
  { visible: false, prop: 'pdrpcbcheckout', label: '检出工程' },
  { visible: false, prop: 'pdrbadreason', label: '不良原因' },
  { visible: false, prop: 'pdrbadqty', label: '不良数量' },
  { visible: false, prop: 'pdrbadtotal', label: '累计不良台数' },
  { visible: false, prop: 'pdrbadresponsibility', label: '责任归属' },
  { visible: false, prop: 'pdrbadprop', label: '不良性质' },
  { visible: false, prop: 'pdrbadserial', label: '序列号' },
  { visible: false, prop: 'pdrbadrepairman', label: '修理' },
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

//字典参数
var dictParams = [
  { dictType: "sql_pcb_type" },
  { dictType: "sql_insp_eng" },
  { dictType: "sql_resp_bel" },
  { dictType: "sql_bad_prop" },
  { dictType: "sql_repair_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从修理日报slv/pp_repair_pcba_slv表记录数据
function getList(){
  loading.value = true
  listPpRepairPcbaSlv(queryParams).then(res => {
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
    pdrParentSfid: [{ required: true, message: "父ID"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdrrealqty: [{ required: true, message: "当日生产数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdrrealtotal: [{ required: true, message: "累计完成数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdrbadqty: [{ required: true, message: "不良数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdrbadtotal: [{ required: true, message: "累计不良台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
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
    pdrSfid: 0,
    pdrParentSfid: 0,
    pdrlot: null,
    pdrpcbtype: null,
    pdrlotqty: 0,
    pdrrealqty: 0,
    pdrrealtotal: 0,
    pdrlinename: null,
    pdrpcbcardno: null,
    pdrbadnote: null,
    pdrpcbcheckout: null,
    pdrbadreason: null,
    pdrbadqty: 0,
    pdrbadtotal: 0,
    pdrbadresponsibility: null,
    pdrbadprop: null,
    pdrbadserial: null,
    pdrbadrepairman: null,
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
  title.value = proxy.$t('btn.add')+" "+'修理日报slv'
  opertype.value = 1
  form.value.pdrpcbtype= []
  form.value.pdrlotqty= 0
  form.value.pdrrealqty= 0
  form.value.pdrrealtotal= 0
  form.value.pdrpcbcheckout= []
  form.value.pdrbadqty= 0
  form.value.pdrbadtotal= 0
  form.value.pdrbadresponsibility= []
  form.value.pdrbadprop= []
  form.value.pdrbadrepairman= []
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.pdrSfid || ids.value
  getPpRepairPcbaSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '修理日报slv'
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

      if (form.value.pdrSfid != undefined && opertype.value === 2) {
        updatePpRepairPcbaSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpRepairPcbaSlv(form.value).then((res) => {
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
      return delPpRepairPcbaSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<修理日报slv.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpRepairPcbaSlv/export', { ...queryParams })
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