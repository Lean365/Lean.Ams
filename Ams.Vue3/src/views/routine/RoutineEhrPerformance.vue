<!--
 * @Descripttion: 绩效/routine_ehr_performance
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/29 17:18:14
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="工号" prop="epWorkID">
            <el-input v-model="queryParams.epWorkID"
              :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="考核年度" prop="epAssessmentYear">
            <el-select filterable clearable v-model="queryParams.epAssessmentYear"
              :placeholder="$t('btn.selectSearchPrefix')+'考核年度'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_fy_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="考核日期">
            <el-date-picker v-model="dateRangeEpAssessmentDate" type="datetimerange"
              :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
              value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime" :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="生效日期">
            <el-date-picker v-model="dateRangeEpEffectiveDate" type="datetimerange"
              :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
              value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime" :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="审核日期">
            <el-date-picker v-model="dateRangeEpAuditDate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrperformance:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrperformance:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrperformance:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrperformance:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Routine/RoutineEhrPerformance/importTemplate"
                  importUrl="/Routine/RoutineEhrPerformance/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['routine:ehrperformance:export']">
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
      <el-table-column prop="epSfid" label="ID" align="center" v-if="columns.showColumn('epSfid')" />
      <el-table-column prop="epParentSfid" label="父ID" align="center" v-if="columns.showColumn('epParentSfid')" />
      <el-table-column prop="epWorkID" label="工号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('epWorkID')" />
      <el-table-column prop="epAssessmentYear" label="考核年度" align="center"
        v-if="columns.showColumn('epAssessmentYear')">
        <template #default="scope">
          <dict-tag :options=" options.sql_fy_list " :value="scope.row.epAssessmentYear" />
        </template>
      </el-table-column>
      <el-table-column prop="epAssessmentDate" label="考核日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('epAssessmentDate')" />
      <el-table-column prop="epWorkPerformance" label="工作绩效" align="center"
        v-if="columns.showColumn('epWorkPerformance')" />
      <el-table-column prop="epExpertise" label="专业知识" align="center" v-if="columns.showColumn('epExpertise')" />
      <el-table-column prop="epWorkingAttitude" label="工作态度" align="center"
        v-if="columns.showColumn('epWorkingAttitude')" />
      <el-table-column prop="epLeadershipSkills" label="领导能力" align="center"
        v-if="columns.showColumn('epLeadershipSkills')" />
      <el-table-column prop="epDiscipline" label="员工纪律" align="center" v-if="columns.showColumn('epDiscipline')" />
      <el-table-column prop="epMorale" label="员工士气" align="center" v-if="columns.showColumn('epMorale')" />
      <el-table-column prop="epEffectiveness" label="监督实效" align="center"
        v-if="columns.showColumn('epEffectiveness')" />
      <el-table-column prop="epDecision" label="决策分析" align="center" v-if="columns.showColumn('epDecision')" />
      <el-table-column prop="epCommunication" label="沟通协调" align="center"
        v-if="columns.showColumn('epCommunication')" />
      <el-table-column prop="epConsciousness" label="成本意识" align="center"
        v-if="columns.showColumn('epConsciousness')" />
      <el-table-column prop="epJudgement" label="判断对策" align="center" v-if="columns.showColumn('epJudgement')" />
      <el-table-column prop="epCreativity" label="前瞻创造" align="center" v-if="columns.showColumn('epCreativity')" />
      <el-table-column prop="epControl" label="控制能力" align="center" v-if="columns.showColumn('epControl')" />
      <el-table-column prop="epSustainability" label="持续力" align="center"
        v-if="columns.showColumn('epSustainability')" />
      <el-table-column prop="epSelfConfidence" label="自信心" align="center"
        v-if="columns.showColumn('epSelfConfidence')" />
      <el-table-column prop="epAdaptability" label="适应能力" align="center" v-if="columns.showColumn('epAdaptability')" />
      <el-table-column prop="epEffectiveDate" label="生效日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('epEffectiveDate')" />
      <el-table-column prop="epAuditDate" label="审核日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('epAuditDate')" />
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createBy')" />
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateBy')" />
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateTime')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['routine:ehrperformance:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['routine:ehrperformance:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改绩效对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="ID" prop="epSfid">
                  <el-input v-model.number="form.epSfid" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="父ID" prop="epParentSfid">
                  <el-input v-model.number="form.epParentSfid"
                    :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工号" prop="epWorkID">
                  <el-input v-model="form.epWorkID" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="考核年度" prop="epAssessmentYear">
                  <el-select filterable clearable v-model="form.epAssessmentYear"
                    :placeholder="$t('btn.selectPrefix')+'考核年度'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_fy_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="考核日期" prop="epAssessmentDate">
                  <el-date-picker v-model="form.epAssessmentDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="工作绩效" prop="epWorkPerformance">
                  <el-slider v-model="form.epWorkPerformance" :min="1" :max="30" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="专业知识" prop="epExpertise">
                  <el-slider v-model="form.epExpertise" :min="1" :max="26" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="工作态度" prop="epWorkingAttitude">
                  <el-slider v-model="form.epWorkingAttitude" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="领导能力" prop="epLeadershipSkills">
                  <el-slider v-model="form.epLeadershipSkills" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="员工纪律" prop="epDiscipline">
                  <el-slider v-model="form.epDiscipline" :min="1" :max="3" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="员工士气" prop="epMorale">
                  <el-slider v-model="form.epMorale" :min="1" :max="3" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="监督实效" prop="epEffectiveness">
                  <el-slider v-model="form.epEffectiveness" :min="1" :max="2" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="决策分析" prop="epDecision">
                  <el-slider v-model="form.epDecision" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="沟通协调" prop="epCommunication">
                  <el-slider v-model="form.epCommunication" :min="1" :max="6" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="成本意识" prop="epConsciousness">
                  <el-slider v-model="form.epConsciousness" :min="1" :max="6" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="判断对策" prop="epJudgement">
                  <el-slider v-model="form.epJudgement" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="前瞻创造" prop="epCreativity">
                  <el-slider v-model="form.epCreativity" :min="1" :max="10" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="控制能力" prop="epControl">
                  <el-slider v-model="form.epControl" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="持续力" prop="epSustainability">
                  <el-slider v-model="form.epSustainability" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="自信心" prop="epSelfConfidence">
                  <el-slider v-model="form.epSelfConfidence" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="适应能力" prop="epAdaptability">
                  <el-slider v-model="form.epAdaptability" :min="1" :max="8" :step="0.5" show-stops />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生效日期" prop="epEffectiveDate">
                  <el-date-picker v-model="form.epEffectiveDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="审核日期" prop="epAuditDate">
                  <el-date-picker v-model="form.epAuditDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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
                  <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2" prop="uDF52">
                  <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3" prop="uDF53">
                  <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4" prop="uDF54">
                  <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5" prop="uDF55">
                  <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6" prop="uDF56">
                  <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-radio-group v-model="form.isDeleted">
                    <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="备注" prop="remark">
                  <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建者" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新者" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="routineehrperformance">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listRoutineEhrPerformance,
    addRoutineEhrPerformance, delRoutineEhrPerformance,
    updateRoutineEhrPerformance, getRoutineEhrPerformance,
  }
    from '@/api/routine/routineehrperformance.js'
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
    sort: 'EpAssessmentYear',
    sortType: 'asc',
    //是否查询（1是）
    epWorkID: undefined,
    //是否查询（1是）
    epAssessmentYear: undefined,
    //是否查询（1是）
    epAssessmentDate: undefined,
    //是否查询（1是）
    epEffectiveDate: undefined,
    //是否查询（1是）
    epAuditDate: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'epSfid', label: 'ID' },
    { visible: true, prop: 'epParentSfid', label: '父ID' },
    { visible: true, prop: 'epWorkID', label: '工号' },
    { visible: true, prop: 'epAssessmentYear', label: '考核年度' },
    { visible: true, prop: 'epAssessmentDate', label: '考核日期' },
    { visible: true, prop: 'epWorkPerformance', label: '工作绩效' },
    { visible: true, prop: 'epExpertise', label: '专业知识' },
    { visible: true, prop: 'epWorkingAttitude', label: '工作态度' },
    { visible: false, prop: 'epLeadershipSkills', label: '领导能力' },
    { visible: false, prop: 'epDiscipline', label: '员工纪律' },
    { visible: false, prop: 'epMorale', label: '员工士气' },
    { visible: false, prop: 'epEffectiveness', label: '监督实效' },
    { visible: false, prop: 'epDecision', label: '决策分析' },
    { visible: false, prop: 'epCommunication', label: '沟通协调' },
    { visible: false, prop: 'epConsciousness', label: '成本意识' },
    { visible: false, prop: 'epJudgement', label: '判断对策' },
    { visible: false, prop: 'epCreativity', label: '前瞻创造' },
    { visible: false, prop: 'epControl', label: '控制能力' },
    { visible: false, prop: 'epSustainability', label: '持续力' },
    { visible: false, prop: 'epSelfConfidence', label: '自信心' },
    { visible: false, prop: 'epAdaptability', label: '适应能力' },
    { visible: false, prop: 'epEffectiveDate', label: '生效日期' },
    { visible: false, prop: 'epAuditDate', label: '审核日期' },
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
  // 考核日期时间范围
  const dateRangeEpAssessmentDate = ref([])
  // 生效日期时间范围
  const dateRangeEpEffectiveDate = ref([])
  // 审核日期时间范围
  const dateRangeEpAuditDate = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sql_fy_list" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从绩效/routine_ehr_performance表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeEpAssessmentDate.value, 'EpAssessmentDate');
    proxy.addDateRange(queryParams, dateRangeEpEffectiveDate.value, 'EpEffectiveDate');
    proxy.addDateRange(queryParams, dateRangeEpAuditDate.value, 'EpAuditDate');
    loading.value = true
    listRoutineEhrPerformance(queryParams).then(res => {
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
    // 考核日期时间范围
    dateRangeEpAssessmentDate.value = []
    // 生效日期时间范围
    dateRangeEpEffectiveDate.value = []
    // 审核日期时间范围
    dateRangeEpAuditDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.epSfid);
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
      epSfid: [{ required: true, message: "ID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      epParentSfid: [{ required: true, message: "父ID" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      epWorkID: [{ required: true, message: "工号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 考核年度 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_fy_list: [],
      // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
      epSfid: 0,
      epParentSfid: 0,
      epWorkID: null,
      epAssessmentYear: null,
      epAssessmentDate: null,
      epWorkPerformance: 0,
      epExpertise: 0,
      epWorkingAttitude: 0,
      epLeadershipSkills: 0,
      epDiscipline: 0,
      epMorale: 0,
      epEffectiveness: 0,
      epDecision: 0,
      epCommunication: 0,
      epConsciousness: 0,
      epJudgement: 0,
      epCreativity: 0,
      epControl: 0,
      epSustainability: 0,
      epSelfConfidence: 0,
      epAdaptability: 0,
      epEffectiveDate: null,
      epAuditDate: null,
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
    title.value = proxy.$t('btn.add') + " " + '绩效'
    opertype.value = 1
    form.value.epAssessmentYear = []
    form.value.epAssessmentDate = new Date()
    form.value.epWorkPerformance = 0
    form.value.epExpertise = 0
    form.value.epWorkingAttitude = 0
    form.value.epLeadershipSkills = 0
    form.value.epDiscipline = 0
    form.value.epMorale = 0
    form.value.epEffectiveness = 0
    form.value.epDecision = 0
    form.value.epCommunication = 0
    form.value.epConsciousness = 0
    form.value.epJudgement = 0
    form.value.epCreativity = 0
    form.value.epControl = 0
    form.value.epSustainability = 0
    form.value.epSelfConfidence = 0
    form.value.epAdaptability = 0
    form.value.epEffectiveDate = new Date()
    form.value.epAuditDate = new Date()
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.epSfid || ids.value
    getRoutineEhrPerformance(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '绩效'
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

        if (form.value.epSfid != undefined && opertype.value === 2) {
          updateRoutineEhrPerformance(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addRoutineEhrPerformance(form.value).then((res) => {
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
    const Ids = row.epSfid || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delRoutineEhrPerformance(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<绩效.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Routine/RoutineEhrPerformance/export', { ...queryParams })
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