<!--
 * @Descripttion: 废弃部品/qm_cost_waste
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/19 15:11:57
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeQcwd001" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="机种" prop="qcwd002">
        <el-select filterable clearable   v-model="queryParams.qcwd002" :placeholder="$t('btn.selectSearchPrefix')+'机种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_oph_model " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="部品品号" prop="qcwd004">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list" :loading="loading " v-model="queryParams.qcwd004" :placeholder="$t('btn.selectSearchPrefix')+'部品品号'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="设变" prop="qcwd016">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_ec_no" :loading="loading " v-model="queryParams.qcwd016" :placeholder="$t('btn.selectSearchPrefix')+'设变'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_ec_no " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="担当" prop="qcwdrec">
        <el-select filterable clearable   v-model="queryParams.qcwdrec" :placeholder="$t('btn.selectSearchPrefix')+'担当'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_inspector_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['qm:costwaste:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:costwaste:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:costwaste:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:costwaste:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmCostWaste/importTemplate"
                  importUrl="/Logistics/QmCostWaste/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:costwaste:export']">
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
      <el-table-column prop="qcwdSFID" label="SFID" align="center" v-if="columns.showColumn('qcwdSFID')"/>
      <el-table-column prop="qcwd001" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qcwd001')"/>
      <el-table-column prop="qcwd002" label="机种" align="center" v-if="columns.showColumn('qcwd002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_oph_model " :value="scope.row.qcwd002"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcwd003" label="间接人员赁率" align="center" v-if="columns.showColumn('qcwd003')"/>
      <el-table-column prop="qcwd004" label="部品品号" align="center" v-if="columns.showColumn('qcwd004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.qcwd004"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcwd005" label="部品品名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcwd005')"/>
      <el-table-column prop="qcwd006" label="事故内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcwd006')"/>
      <el-table-column prop="qcwd007" label="废弃费用" align="center" v-if="columns.showColumn('qcwd007')"/>
      <el-table-column prop="qcwd008" label="废弃数量" align="center" v-if="columns.showColumn('qcwd008')"/>
      <el-table-column prop="qcwd009" label="部品单价" align="center" v-if="columns.showColumn('qcwd009')"/>
      <el-table-column prop="qcwd010" label="废弃处理费用" align="center" v-if="columns.showColumn('qcwd010')"/>
      <el-table-column prop="qcwd011" label="运费" align="center" v-if="columns.showColumn('qcwd011')"/>
      <el-table-column prop="qcwd012" label="其他费用" align="center" v-if="columns.showColumn('qcwd012')"/>
      <el-table-column prop="qcwd013" label="处理作业时间(分)" align="center" v-if="columns.showColumn('qcwd013')"/>
      <el-table-column prop="qcwd014" label="关税" align="center" v-if="columns.showColumn('qcwd014')"/>
      <el-table-column prop="qcwd015" label="处理发生其他费用" align="center" v-if="columns.showColumn('qcwd015')"/>
      <el-table-column prop="qcwd016" label="设变" align="center" v-if="columns.showColumn('qcwd016')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_no " :value="scope.row.qcwd016"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcwdrec" label="担当" align="center" v-if="columns.showColumn('qcwdrec')">
        <template #default="scope">
          <dict-tag :options=" options.sql_inspector_list " :value="scope.row.qcwdrec"  />
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
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:costwaste:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:costwaste:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改废弃部品对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="qcwdSFID">
              <el-input v-model.number="form.qcwdSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="qcwd001">
              <el-date-picker v-model="form.qcwd001" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="qcwd002">
              <el-select filterable clearable   v-model="form.qcwd002"  :placeholder="$t('btn.selectPrefix')+'机种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_oph_model" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="间接人员赁率" prop="qcwd003">
              <el-input-number v-model.number="form.qcwd003" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人员赁率'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="部品品号" prop="qcwd004">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list" 
              :loading="loading " v-model="form.qcwd004"  :placeholder="$t('btn.selectPrefix')+'部品品号'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_mats_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="部品品名" prop="qcwd005">
              <el-input v-model="form.qcwd005" :placeholder="$t('btn.enterPrefix')+'部品品名'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="事故内容" prop="qcwd006">
              <el-input type="textarea" v-model="form.qcwd006" :placeholder="$t('btn.enterPrefix')+'事故内容'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="废弃费用" prop="qcwd007">
              <el-input-number v-model.number="form.qcwd007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'废弃费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="废弃数量" prop="qcwd008">
              <el-input-number v-model.number="form.qcwd008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'废弃数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="部品单价" prop="qcwd009">
              <el-input-number v-model.number="form.qcwd009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'部品单价'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="废弃处理费用" prop="qcwd010">
              <el-input-number v-model.number="form.qcwd010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'废弃处理费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="运费" prop="qcwd011">
              <el-input-number v-model.number="form.qcwd011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'运费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcwd012">
              <el-input-number v-model.number="form.qcwd012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="处理作业时间(分)" prop="qcwd013">
              <el-input-number v-model.number="form.qcwd013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'处理作业时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关税" prop="qcwd014">
              <el-input-number v-model.number="form.qcwd014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'关税'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理发生其他费用" prop="qcwd015">
              <el-input-number v-model.number="form.qcwd015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'处理发生其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变" prop="qcwd016">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_ec_no" 
              :loading="loading " v-model="form.qcwd016"  :placeholder="$t('btn.selectPrefix')+'设变'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_ec_no" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="担当" prop="qcwdrec">
              <el-select filterable clearable   v-model="form.qcwdrec"  :placeholder="$t('btn.selectPrefix')+'担当'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_inspector_list" 
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

<script setup name="qmcostwaste">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmCostWaste,
 addQmCostWaste, delQmCostWaste, 
 updateQmCostWaste,getQmCostWaste, 
 } 
from '@/api/logistics/qmcostwaste.js'
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
  qcwd001: undefined,
//是否查询（1是）
  qcwd002: undefined,
//是否查询（1是）
  qcwd004: undefined,
//是否查询（1是）
  qcwd016: undefined,
//是否查询（1是）
  qcwdrec: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qcwdSFID', label: 'SFID' },
  { visible: true, prop: 'qcwd001', label: '日期' },
  { visible: true, prop: 'qcwd002', label: '机种' },
  { visible: true, prop: 'qcwd003', label: '间接人员赁率' },
  { visible: true, prop: 'qcwd004', label: '部品品号' },
  { visible: true, prop: 'qcwd005', label: '部品品名' },
  { visible: true, prop: 'qcwd006', label: '事故内容' },
  { visible: true, prop: 'qcwd007', label: '废弃费用' },
  { visible: false, prop: 'qcwd008', label: '废弃数量' },
  { visible: false, prop: 'qcwd009', label: '部品单价' },
  { visible: false, prop: 'qcwd010', label: '废弃处理费用' },
  { visible: false, prop: 'qcwd011', label: '运费' },
  { visible: false, prop: 'qcwd012', label: '其他费用' },
  { visible: false, prop: 'qcwd013', label: '处理作业时间(分)' },
  { visible: false, prop: 'qcwd014', label: '关税' },
  { visible: false, prop: 'qcwd015', label: '处理发生其他费用' },
  { visible: false, prop: 'qcwd016', label: '设变' },
  { visible: false, prop: 'qcwdrec', label: '担当' },
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
// 日期时间范围
const dateRangeQcwd001 = ref([])
//定义远程搜索变量
const remotequeryList_sql_mats_list=ref([])
//定义远程搜索变量
const remotequery_sql_mats_list=ref([])
//远程字典参数
var remotedictParams_sql_mats_list = [
    { dictType: "sql_mats_list" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_mats_list).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_mats_list.value = element.list
      })
      //console.log(remotequeryList_sql_mats_list)
    })
  })
//远程搜索
const remoteMethod_sql_mats_list = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_mats_list.value = remotequeryList_sql_mats_list.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_mats_list(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_mats_list.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_mats_list = debounce((query) => {
    let arr = remotequeryList_sql_mats_list.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_mats_list.value = arr.slice(0, 5)
      addFilterOptions_sql_mats_list(query)
    } else {
      remotequery_sql_mats_list.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_mats_list =debounce((dictValue) => {
    let target = remotequeryList_sql_mats_list.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_mats_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_mats_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
//定义远程搜索变量
const remotequeryList_sql_ec_no=ref([])
//定义远程搜索变量
const remotequery_sql_ec_no=ref([])
//远程字典参数
var remotedictParams_sql_ec_no = [
    { dictType: "sql_ec_no" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_ec_no).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_ec_no.value = element.list
      })
      //console.log(remotequeryList_sql_ec_no)
    })
  })
//远程搜索
const remoteMethod_sql_ec_no = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_ec_no.value = remotequeryList_sql_ec_no.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_ec_no(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_ec_no.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_ec_no = debounce((query) => {
    let arr = remotequeryList_sql_ec_no.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_ec_no.value = arr.slice(0, 5)
      addFilterOptions_sql_ec_no(query)
    } else {
      remotequery_sql_ec_no.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_ec_no =debounce((dictValue) => {
    let target = remotequeryList_sql_ec_no.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_ec_no.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_ec_no.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

//字典参数
var dictParams = [
  { dictType: "sql_oph_model" },
  { dictType: "sql_inspector_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从废弃部品/qm_cost_waste表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQcwd001.value, 'Qcwd001');
  loading.value = true
  listQmCostWaste(queryParams).then(res => {
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
  // 日期时间范围
  dateRangeQcwd001.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qcwdSFID);
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
    qcwdSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    qcwd003: [{ required: true, message: "间接人员赁率"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd007: [{ required: true, message: "废弃费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd008: [{ required: true, message: "废弃数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd009: [{ required: true, message: "部品单价"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd010: [{ required: true, message: "废弃处理费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd011: [{ required: true, message: "运费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd012: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd013: [{ required: true, message: "处理作业时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcwd014: [{ required: true, message: "关税"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcwd015: [{ required: true, message: "处理发生其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 机种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_oph_model: [],
    // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_inspector_list: [],
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
    qcwdSFID: 0,
    qcwd001: null,
    qcwd002: null,
    qcwd003: 0,
    qcwd004Checked: [],
    qcwd005: null,
    qcwd006: null,
    qcwd007: 0,
    qcwd008: 0,
    qcwd009: 0,
    qcwd010: 0,
    qcwd011: 0,
    qcwd012: 0,
    qcwd013: 0,
    qcwd014: 0,
    qcwd015: 0,
    qcwd016Checked: [],
    qcwdrec: null,
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
  title.value = proxy.$t('btn.add')+" "+'废弃部品'
  opertype.value = 1
  form.value.qcwd001= new Date()
  form.value.qcwd002= []
  form.value.qcwd003= 0
  form.value.qcwd007= 0
  form.value.qcwd008= 0
  form.value.qcwd009= 0
  form.value.qcwd010= 0
  form.value.qcwd011= 0
  form.value.qcwd012= 0
  form.value.qcwd013= 0
  form.value.qcwd014= 0
  form.value.qcwd015= 0
  form.value.qcwdrec= []
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qcwdSFID || ids.value
  getQmCostWaste(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '废弃部品'
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

      if (form.value.qcwdSFID != undefined && opertype.value === 2) {
        updateQmCostWaste(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmCostWaste(form.value).then((res) => {
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
  const Ids = row.qcwdSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delQmCostWaste(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<废弃部品.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmCostWaste/export', { ...queryParams })
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