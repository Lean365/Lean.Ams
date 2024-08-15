<!--
 * @Descripttion: 进料检验/qm_incoming
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/19 9:53:50
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="采购订单" prop="qminPurOrder">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_oph_moc" :loading="loading " v-model="queryParams.qminPurOrder" :placeholder="$t('btn.selectSearchPrefix')+'采购订单'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_oph_moc " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="qminMaterial">
        <el-input v-model="queryParams.qminMaterial" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="进货日期">
        <el-date-picker
          v-model="dateRangeQminPurDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="检验员" prop="qminInspector">
        <el-select filterable clearable   v-model="queryParams.qminInspector" :placeholder="$t('btn.selectSearchPrefix')+'检验员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验日期">
        <el-date-picker
          v-model="dateRangeQminCheckDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="检验项目" prop="qminInspectingItem">
        <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip  v-model="queryParams.qminInspectingItem" :placeholder="$t('btn.selectSearchPrefix')+'检验项目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_insp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验水准" prop="qminSamplingLevel">
        <el-select filterable clearable   v-model="queryParams.qminSamplingLevel" :placeholder="$t('btn.selectSearchPrefix')+'检验水准'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_level " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验方式" prop="qminCheckMethod">
        <el-select filterable clearable   v-model="queryParams.qminCheckMethod" :placeholder="$t('btn.selectSearchPrefix')+'检验方式'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_method " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="判定" prop="qminJudgment">
        <el-select filterable clearable   v-model="queryParams.qminJudgment" :placeholder="$t('btn.selectSearchPrefix')+'判定'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_judge " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="不良级别" prop="qminJudgmentLevel">
        <el-select filterable clearable   v-model="queryParams.qminJudgmentLevel" :placeholder="$t('btn.selectSearchPrefix')+'不良级别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_bad " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['qm:incoming:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:incoming:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:incoming:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:incoming:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmIncoming/importTemplate"
                  importUrl="/Logistics/QmIncoming/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:incoming:export']">
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
      <el-table-column prop="qminSFID" label="SFID" align="center" v-if="columns.showColumn('qminSFID')"/>
      <el-table-column prop="qminPurOrder" label="采购订单" align="center" v-if="columns.showColumn('qminPurOrder')">
        <template #default="scope">
          <dict-tag :options=" options.sql_oph_moc " :value="scope.row.qminPurOrder"  />
        </template>
      </el-table-column>
      <el-table-column prop="qminMaterial" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qminMaterial')"/>
      <el-table-column prop="qminPurOrderQty" label="数量" align="center" v-if="columns.showColumn('qminPurOrderQty')"/>
      <el-table-column prop="qminPurDate" label="进货日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qminPurDate')"/>
      <el-table-column prop="qminInspector" label="检验员" align="center" v-if="columns.showColumn('qminInspector')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.qminInspector"  />
        </template>
      </el-table-column>
      <el-table-column prop="qminCheckDate" label="检验日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qminCheckDate')"/>
      <el-table-column prop="qminInspectingItem" label="检验项目" align="center" v-if="columns.showColumn('qminInspectingItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_list " :value="scope.row.qminInspectingItem" split="," />
        </template>
      </el-table-column>
      <el-table-column prop="qminSamplingLevel" label="检验水准" align="center" v-if="columns.showColumn('qminSamplingLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_level " :value="scope.row.qminSamplingLevel"  />
        </template>
      </el-table-column>
      <el-table-column prop="qminCheckMethod" label="检验方式" align="center" v-if="columns.showColumn('qminCheckMethod')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_method " :value="scope.row.qminCheckMethod"  />
        </template>
      </el-table-column>
      <el-table-column prop="qminSamplingQty" label="抽样数" align="center" v-if="columns.showColumn('qminSamplingQty')"/>
      <el-table-column prop="qminJudgment" label="判定" align="center" v-if="columns.showColumn('qminJudgment')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_judge " :value="scope.row.qminJudgment"  />
        </template>
      </el-table-column>
      <el-table-column prop="qminJudgmentLevel" label="不良级别" align="center" v-if="columns.showColumn('qminJudgmentLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_bad " :value="scope.row.qminJudgmentLevel"  />
        </template>
      </el-table-column>
      <el-table-column prop="qminRejectQty" label="验退数" align="center" v-if="columns.showColumn('qminRejectQty')"/>
      <el-table-column prop="qminSpecialNotes" label="特记事项" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qminSpecialNotes')"/>
      <el-table-column prop="qminAcceptQty" label="验收数量" align="center" v-if="columns.showColumn('qminAcceptQty')"/>
      <el-table-column prop="qminCheckoutSequence" label="检验次数" align="center" v-if="columns.showColumn('qminCheckoutSequence')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:incoming:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:incoming:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改进料检验对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="qminSFID">
              <el-input v-model.number="form.qminSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购订单" prop="qminPurOrder">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_oph_moc" 
              :loading="loading " v-model="form.qminPurOrder"  :placeholder="$t('btn.selectPrefix')+'采购订单'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_oph_moc" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料" prop="qminMaterial">
              <el-input v-model="form.qminMaterial" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="数量" prop="qminPurOrderQty">
              <el-input-number v-model.number="form.qminPurOrderQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="进货日期" prop="qminPurDate">
              <el-date-picker v-model="form.qminPurDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验员" prop="qminInspector">
              <el-select filterable clearable   v-model="form.qminInspector"  :placeholder="$t('btn.selectPrefix')+'检验员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验日期" prop="qminCheckDate">
              <el-date-picker v-model="form.qminCheckDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验项目" prop="qminInspectingItem">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip  v-model="form.qminInspectingItemChecked"  :placeholder="$t('btn.selectPrefix')+'检验项目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验水准" prop="qminSamplingLevel">
              <el-select filterable clearable   v-model="form.qminSamplingLevel"  :placeholder="$t('btn.selectPrefix')+'检验水准'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_level" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验方式" prop="qminCheckMethod">
              <el-select filterable clearable   v-model="form.qminCheckMethod"  :placeholder="$t('btn.selectPrefix')+'检验方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="抽样数" prop="qminSamplingQty">
              <el-input-number v-model.number="form.qminSamplingQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'抽样数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="判定" prop="qminJudgment">
              <el-select filterable clearable   v-model="form.qminJudgment"  :placeholder="$t('btn.selectPrefix')+'判定'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_judge" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="不良级别" prop="qminJudgmentLevel">
              <el-select filterable clearable   v-model="form.qminJudgmentLevel"  :placeholder="$t('btn.selectPrefix')+'不良级别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_bad" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="验退数" prop="qminRejectQty">
              <el-input-number v-model.number="form.qminRejectQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验退数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特记事项" prop="qminSpecialNotes">
              <el-input v-model="form.qminSpecialNotes" :placeholder="$t('btn.enterPrefix')+'特记事项'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="验收数量" prop="qminAcceptQty">
              <el-input-number v-model.number="form.qminAcceptQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验收数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检验次数" prop="qminCheckoutSequence">
              <el-input-number v-model.number="form.qminCheckoutSequence" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检验次数'+$t('btn.enterSuffix')" />
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

<script setup name="qmincoming">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmIncoming,
 addQmIncoming, delQmIncoming, 
 updateQmIncoming,getQmIncoming, 
 } 
from '@/api/logistics/qmincoming.js'
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
  qminPurOrder: undefined,
//是否查询（1是）
  qminMaterial: undefined,
//是否查询（1是）
  qminPurDate: undefined,
//是否查询（1是）
  qminInspector: undefined,
//是否查询（1是）
  qminCheckDate: undefined,
//是否查询（1是）
  qminInspectingItem: undefined,
//是否查询（1是）
  qminSamplingLevel: undefined,
//是否查询（1是）
  qminCheckMethod: undefined,
//是否查询（1是）
  qminJudgment: undefined,
//是否查询（1是）
  qminJudgmentLevel: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qminSFID', label: 'SFID' },
  { visible: true, prop: 'qminPurOrder', label: '采购订单' },
  { visible: true, prop: 'qminMaterial', label: '物料' },
  { visible: true, prop: 'qminPurOrderQty', label: '数量' },
  { visible: true, prop: 'qminPurDate', label: '进货日期' },
  { visible: true, prop: 'qminInspector', label: '检验员' },
  { visible: true, prop: 'qminCheckDate', label: '检验日期' },
  { visible: true, prop: 'qminInspectingItem', label: '检验项目' },
  { visible: false, prop: 'qminSamplingLevel', label: '检验水准' },
  { visible: false, prop: 'qminCheckMethod', label: '检验方式' },
  { visible: false, prop: 'qminSamplingQty', label: '抽样数' },
  { visible: false, prop: 'qminJudgment', label: '判定' },
  { visible: false, prop: 'qminJudgmentLevel', label: '不良级别' },
  { visible: false, prop: 'qminRejectQty', label: '验退数' },
  { visible: false, prop: 'qminSpecialNotes', label: '特记事项' },
  { visible: false, prop: 'qminAcceptQty', label: '验收数量' },
  { visible: false, prop: 'qminCheckoutSequence', label: '检验次数' },
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
// 进货日期时间范围
const dateRangeQminPurDate = ref([])
// 检验日期时间范围
const dateRangeQminCheckDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_ec_group" },
  { dictType: "sql_insp_list" },
  { dictType: "sys_insp_level" },
  { dictType: "sys_insp_method" },
  { dictType: "sys_insp_judge" },
  { dictType: "sys_insp_bad" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从进料检验/qm_incoming表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQminPurDate.value, 'QminPurDate');
  proxy.addDateRange(queryParams, dateRangeQminCheckDate.value, 'QminCheckDate');
  loading.value = true
  listQmIncoming(queryParams).then(res => {
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
  // 进货日期时间范围
  dateRangeQminPurDate.value = []
  // 检验日期时间范围
  dateRangeQminCheckDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qminSFID);
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
    qminSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    qminPurOrder: [{ required: true, message: "采购订单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminMaterial: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminPurOrderQty: [{ required: true, message: "数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminPurDate: [{ required: true, message: "进货日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminInspector: [{ required: true, message: "检验员"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qminCheckDate: [{ required: true, message: "检验日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminInspectingItem: [{ required: true, message: "检验项目"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminSamplingLevel: [{ required: true, message: "检验水准"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qminCheckMethod: [{ required: true, message: "检验方式"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qminSamplingQty: [{ required: true, message: "抽样数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminJudgment: [{ required: true, message: "判定"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qminJudgmentLevel: [{ required: true, message: "不良级别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qminRejectQty: [{ required: true, message: "验退数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminAcceptQty: [{ required: true, message: "验收数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qminCheckoutSequence: [{ required: true, message: "检验次数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 检验员 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ec_group: [],
    // 检验项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_insp_list: [],
    // 检验水准 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_level: [],
    // 检验方式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_method: [],
    // 判定 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_judge: [],
    // 不良级别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_bad: [],
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
    qminSFID: 0,
    qminPurOrderChecked: [],
    qminMaterial: null,
    qminPurOrderQty: 0,
    qminPurDate: null,
    qminInspector: null,
    qminCheckDate: null,
    qminInspectingItemChecked: [],
    qminSamplingLevel: null,
    qminCheckMethod: null,
    qminSamplingQty: 0,
    qminJudgment: null,
    qminJudgmentLevel: null,
    qminRejectQty: 0,
    qminSpecialNotes: null,
    qminAcceptQty: 0,
    qminCheckoutSequence: 0,
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
  title.value = proxy.$t('btn.add')+" "+'进料检验'
  opertype.value = 1
  form.value.qminPurOrderQty= 0
  form.value.qminPurDate= new Date()
  form.value.qminInspector= []
  form.value.qminCheckDate= new Date()
  form.value.qminSamplingLevel= []
  form.value.qminCheckMethod= []
  form.value.qminSamplingQty= 0
  form.value.qminJudgment= []
  form.value.qminJudgmentLevel= []
  form.value.qminRejectQty= 0
  form.value.qminAcceptQty= 0
  form.value.qminCheckoutSequence= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qminSFID || ids.value
  getQmIncoming(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '进料检验'
      opertype.value = 2

      form.value = {
        ...data,
        qminInspectingItemChecked: data.qminInspectingItem ? data.qminInspectingItem.split(',') : [],
      }
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {
      form.value.qminInspectingItem = form.value.qminInspectingItemChecked.toString();

      if (form.value.qminSFID != undefined && opertype.value === 2) {
        updateQmIncoming(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmIncoming(form.value).then((res) => {
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
  const Ids = row.qminSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delQmIncoming(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<进料检验.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmIncoming/export', { ...queryParams })
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