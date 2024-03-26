<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @Version: (0.24.387.19951)
 * @Author: (Lean365)
 * @Date: (2024/1/22 11:16:45)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="生产工单" prop="pomMfgOrder">
        <el-select clearable filterable v-model="queryParams.pomMfgOrder" :placeholder="$t('btn.select')+'生产工单'">
          <el-option v-for="item in  options.sql_moc_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产批次" prop="pomMfgLot">
        <el-input v-model="queryParams.pomMfgLot" :placeholder="$t('btn.enter')+'生产批次'" />
      </el-form-item>
      <el-form-item label="机种名" prop="pomMfgModel">
        <el-input v-model="queryParams.pomMfgModel" :placeholder="$t('btn.enter')+'机种名'" />
      </el-form-item>
      <el-form-item label="物料" prop="pomMfgItem">
        <el-input v-model="queryParams.pomMfgItem" :placeholder="$t('btn.enter')+'物料'" />
      </el-form-item>
      <el-form-item label="生产日期">
        <el-date-picker v-model="dateRangePomMfgDate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产班组" prop="pomMfgLine">
        <el-select clearable filterable v-model="queryParams.pomMfgLine" :placeholder="$t('btn.select')+'生产班组'">
          <el-option v-for="item in  options.sql_line_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:outputmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:outputmaster:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:outputmaster:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputmaster:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="logistics/OutputMaster/importTemplate"
                  importUrl="/logistics/OutputMaster/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputmaster:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" height="650" v-loading="loading" ref="table" border
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="40" align="center" />
      <el-table-column :label="$t('btn.details')" width="65" align="center">
        <template #default="scope">
          <el-button size="small" color="#79bbff" plain icon="view" :title=" $t('btn.details') "
            @click="rowClick(scope.row)"></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="pomSfid" label="SFID" align="center" v-if="columns.showColumn('pomSfid')" />
      <el-table-column prop="pomMfgOrder" label="生产工单" align="center" v-if="columns.showColumn('pomMfgOrder')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_list " :value="scope.row.pomMfgOrder" />
        </template>
      </el-table-column>
      <el-table-column prop="pomMfgOrderQty" label="工单数量" align="center" v-if="columns.showColumn('pomMfgOrderQty')" />
      <el-table-column prop="pomMfgOrderSerial" label="管理序列号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pomMfgOrderSerial')" />
      <el-table-column prop="pomMfgLot" label="生产批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pomMfgLot')" />
      <el-table-column prop="pomMfgModel" label="机种名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pomMfgModel')" />
      <el-table-column prop="pomMfgItem" label="物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pomMfgItem')" />
      <el-table-column prop="pomMfgDate" label="生产日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pomMfgDate')" />
      <el-table-column prop="pomMfgLine" label="生产班组" align="center" v-if="columns.showColumn('pomMfgLine')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.pomMfgLine" />
        </template>
      </el-table-column>
      <el-table-column prop="pomDirect" label="直接人数" align="center" v-if="columns.showColumn('pomDirect')" />
      <el-table-column prop="pomIndirect" label="间接人数" align="center" v-if="columns.showColumn('pomIndirect')" />
      <el-table-column prop="pomStdTime" label="标准工时" align="center" v-if="columns.showColumn('pomStdTime')" />
      <el-table-column prop="pomStdOutput" label="标准产能" align="center" v-if="columns.showColumn('pomStdOutput')" />
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
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')"
            v-hasPermi="['pp:outputmaster:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['pp:outputmaster:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <el-drawer v-model="drawer" size="50%" direction="rtl">
      <el-table :data="outputSlaveList" header-row-class-name="text-navy">
        <el-table-column label="序号" type="index" width="80" />
        <el-table-column prop="posSfid" label="SFID" />
        <el-table-column prop="posParentSfid" label="父SFID" />
        <el-table-column prop="posProductionTime" label="生产时段">
          <template #default="scope">
            <dict-tag :options=" options.app_phase_time " :value="scope.row.posProductionTime" />
          </template>
        </el-table-column>
        <el-table-column prop="posRealOutput" label="实际产能" />
        <el-table-column prop="posDownTime" label="停线时间" />
        <el-table-column prop="posDownTimeReasons" label="停线原因">
          <template #default="scope">
            <dict-tag :options=" options.sql_line_stop " :value="scope.row.posDownTimeReasons" />
          </template>
        </el-table-column>
        <el-table-column prop="posDownTimeDescription" label="停线说明" />
        <el-table-column prop="posUnfinishedReasons" label="未达成原因">
          <template #default="scope">
            <dict-tag :options=" options.sql_non_conf " :value="scope.row.posUnfinishedReasons" />
          </template>
        </el-table-column>
        <el-table-column prop="posUnfinishedDescription" label="未达成说明" />
        <el-table-column prop="posRealWorkhours" label="实际工数" />
        <el-table-column prop="posInputsWorkhours" label="投入工数" />
        <el-table-column prop="posRealWorkinghoursDiff" label="工时差异" />
        <el-table-column prop="posRealOutputDiff" label="产能差异" />
        <el-table-column prop="posAchievedRate" label="达成率" />
        <el-table-column prop="remark" label="说明" />
        <el-table-column prop="createBy" label="创建者" />
        <el-table-column prop="createTime" label="创建时间" />
        <el-table-column prop="updateBy" label="更新者" />
        <el-table-column prop="updateTime" label="更新时间" />
      </el-table>
    </el-drawer>

    <!-- 添加或修改oph主表对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <!-- <el-col :lg="12" v-if="opertype != 1">
                <el-form-item label="SFID" prop="pomSfid">
                  <el-input-number v-model.number="form.pomSfid" controls-position="right"
                    :placeholder="$t('btn.enter')+'SFID'" :disabled="true" />
                </el-form-item>
              </el-col> -->

              <el-col :lg="12">
                <el-form-item label="生产工单" prop="pomMfgOrder">
                  <el-select clearable filterable v-model="form.pomMfgOrder" :placeholder="$t('btn.select')+'生产工单'"
                    @change="assignModelValue">
                    <el-option v-for="item in options.sql_moc_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工单数量" prop="pomMfgOrderQty">
                  <el-input-number v-model.number="form.pomMfgOrderQty" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'工单数量'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="管理序列号" prop="pomMfgOrderSerial">
                  <el-input v-model="form.pomMfgOrderSerial" :placeholder="$t('btn.enter')+'管理序列号'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产批次" prop="pomMfgLot">
                  <el-input v-model="form.pomMfgLot" :placeholder="$t('btn.enter')+'生产批次'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="机种名" prop="pomMfgModel">
                  <el-input v-model="form.pomMfgModel" :placeholder="$t('btn.enter')+'机种名'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="pomMfgItem">
                  <el-input v-model="form.pomMfgItem" :placeholder="$t('btn.enter')+'物料'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产日期" prop="pomMfgDate">
                  <el-date-picker v-model="form.pomMfgDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产班组" prop="pomMfgLine">
                  <el-select clearable filterable v-model="form.pomMfgLine" :placeholder="$t('btn.select')+'生产班组'">
                    <el-option v-for="item in options.sql_line_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="直接人数" prop="pomDirect">
                  <el-input-number v-model.number="form.pomDirect" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'直接人数'" @input="assignStdlValue" :precision="0" :step="1" :max="99"
                    :min="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接人数" prop="pomIndirect">
                  <el-input-number v-model.number="form.pomIndirect" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'间接人数'" :precision="0" :step="1" :max="33" :min="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准工时" prop="pomStdTime">
                  <el-input-number v-model.number="form.pomStdTime" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'标准工时'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准产能" prop="pomStdOutput">
                  <el-input-number v-model.number="form.pomStdOutput" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'标准产能'" :disabled="true" />
                </el-form-item>
              </el-col>


            </el-row>
          </el-tab-pane>



          <el-tab-pane :label="$t('ptabs.customization')" name="ninth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="自定义A" prop="uDF01">
                  <el-input v-model="form.uDF01" :placeholder="$t('btn.enter')+'自定义A'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义B" prop="uDF02">
                  <el-input v-model="form.uDF02" :placeholder="$t('btn.enter')+'自定义B'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义C" prop="uDF03">
                  <el-input v-model="form.uDF03" :placeholder="$t('btn.enter')+'自定义C'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义D" prop="uDF04">
                  <el-input v-model="form.uDF04" :placeholder="$t('btn.enter')+'自定义D'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义E" prop="uDF05">
                  <el-input v-model="form.uDF05" :placeholder="$t('btn.enter')+'自定义E'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义F" prop="uDF06">
                  <el-input v-model="form.uDF06" :placeholder="$t('btn.enter')+'自定义F'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义1" prop="uDF51">
                  <el-input v-model="form.uDF51" :placeholder="$t('btn.enter')+'自定义1'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2" prop="uDF52">
                  <el-input v-model="form.uDF52" :placeholder="$t('btn.enter')+'自定义2'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3" prop="uDF53">
                  <el-input v-model="form.uDF53" :placeholder="$t('btn.enter')+'自定义3'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4" prop="uDF54">
                  <el-input v-model="form.uDF54" :placeholder="$t('btn.enter')+'自定义4'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5" prop="uDF55">
                  <el-input v-model="form.uDF55" :placeholder="$t('btn.enter')+'自定义5'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6" prop="uDF56">
                  <el-input v-model="form.uDF56" :placeholder="$t('btn.enter')+'自定义6'" :disabled="true" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="tenth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-input v-model.number="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建者" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新者" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
        </el-tabs>
        <el-divider content-position="center">oph从表</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button type="primary" icon="Plus" @click="handleAddOutputSlave">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="danger" icon="Delete" @click="handleDeleteOutputSlave">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button type="info" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?
              $t('layout.exitfullscreen')
              : $t('layout.fullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="outputSlaveList" :row-class-name="rowOutputSlaveIndex"
          @selection-change="handleOutputSlaveSelectionChange" ref="OutputSlaveRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50" />
          <el-table-column label="生产时段" prop="posProductionTime">
            <template #default="scope">
              <el-select v-model="scope.row.posProductionTime" :placeholder="$t('btn.enter')+'生产时段'">
                <el-option v-for="item in options.app_phase_time" :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="实际产能" align="center" prop="posRealOutput" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealOutput" controls-position="right"
                :placeholder="$t('btn.enter')+'实际产能'" />
            </template>
          </el-table-column>
          <el-table-column label="停线时间" align="center" prop="posDownTime" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posDownTime" controls-position="right"
                :placeholder="$t('btn.enter')+'停线时间'" />
            </template>
          </el-table-column>
          <el-table-column label="停线原因" prop="posDownTimeReasons">
            <template #default="scope">
              <el-select v-model="scope.row.posDownTimeReasons" :placeholder="$t('btn.enter')+'停线原因'">
                <el-option v-for="item in options.sql_line_stop" :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="停线说明" align="center" prop="posDownTimeDescription">
            <template #default="scope">
              <el-input v-model="scope.row.posDownTimeDescription" :placeholder="$t('btn.enter')+'停线说明'" />
            </template>
          </el-table-column>
          <el-table-column label="未达成原因" prop="posUnfinishedReasons">
            <template #default="scope">
              <el-select v-model="scope.row.posUnfinishedReasons" :placeholder="$t('btn.enter')+'未达成原因'">
                <el-option v-for="item in options.sql_non_conf" :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="未达成说明" align="center" prop="posUnfinishedDescription">
            <template #default="scope">
              <el-input v-model="scope.row.posUnfinishedDescription" :placeholder="$t('btn.enter')+'未达成说明'" />
            </template>
          </el-table-column>
          <el-table-column label="实际工数" align="center" prop="posRealWorkhours" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealWorkhours" controls-position="right"
                :placeholder="$t('btn.enter')+'实际工数'" />
            </template>
          </el-table-column>
          <el-table-column label="投入工数" align="center" prop="posInputsWorkhours" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posInputsWorkhours" controls-position="right"
                :placeholder="$t('btn.enter')+'投入工数'" />
            </template>
          </el-table-column>
          <el-table-column label="工时差异" align="center" prop="posRealWorkinghoursDiff" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealWorkinghoursDiff" controls-position="right"
                :placeholder="$t('btn.enter')+'工时差异'" />
            </template>
          </el-table-column>
          <el-table-column label="产能差异" align="center" prop="posRealOutputDiff" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posRealOutputDiff" controls-position="right"
                :placeholder="$t('btn.enter')+'产能差异'" />
            </template>
          </el-table-column>
          <el-table-column label="达成率" align="center" prop="posAchievedRate" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.posAchievedRate" controls-position="right"
                :placeholder="$t('btn.enter')+'达成率'" />
            </template>
          </el-table-column>
          <el-table-column label="说明" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enter')+'说明'" />
            </template>
          </el-table-column>
          <el-table-column label="创建者" align="center" prop="createBy">
            <template #default="scope">
              <el-input v-model="scope.row.createBy" :placeholder="$t('btn.enter')+'创建者'" />
            </template>
          </el-table-column>
          <el-table-column label="创建时间" align="center" prop="createTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.createTime" type="date"
                :placeholder="$t('btn.select')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="更新者" align="center" prop="updateBy">
            <template #default="scope">
              <el-input v-model="scope.row.updateBy" :placeholder="$t('btn.enter')+'更新者'" />
            </template>
          </el-table-column>
          <el-table-column label="更新时间" align="center" prop="updateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.updateTime" type="date"
                :placeholder="$t('btn.select')"></el-date-picker>
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

<script setup name="outputmaster">
  //后台操作函数
  import {
    listOutputMaster,
    addOutputMaster, delOutputMaster,
    updateOutputMaster, getOutputMaster,
  }
    from '@/api/logistics/outputmaster.js'
  //
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
    pageSize: 20,
    sort: '',
    sortType: 'asc',
    pomMfgOrder: undefined,
    pomMfgLot: undefined,
    pomMfgModel: undefined,
    pomMfgItem: undefined,
    pomMfgDate: undefined,
    pomMfgLine: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'pomSfid', label: 'SFID' },
    { visible: true, prop: 'pomMfgOrder', label: '生产工单' },
    { visible: true, prop: 'pomMfgOrderQty', label: '工单数量' },
    { visible: true, prop: 'pomMfgOrderSerial', label: '管理序列号' },
    { visible: true, prop: 'pomMfgLot', label: '生产批次' },
    { visible: true, prop: 'pomMfgModel', label: '机种名' },
    { visible: true, prop: 'pomMfgItem', label: '物料' },
    { visible: true, prop: 'pomMfgDate', label: '生产日期' },
    { visible: false, prop: 'pomMfgLine', label: '生产班组' },
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
  //定义从设变表格数据变量
  const dataList = ref([])
  //查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
  //输入日时间范围
  // 生产日期时间范围
  const dateRangePomMfgDate = ref([])
  //字典参数
  var dictParams = [
    { dictType: "sql_moc_list" },
    { dictType: "sql_line_list" },
    { dictType: "app_phase_time" },
    { dictType: "sql_line_stop" },
    { dictType: "sql_non_conf" },
  ]
  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从oph主表/pp_output_master表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangePomMfgDate.value, 'PomMfgDate');
    loading.value = true
    listOutputMaster(queryParams).then(res => {
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
    // 生产日期时间范围
    dateRangePomMfgDate.value = []
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
      pomSfid: [{ required: true, message: 'SFID' + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      pomMfgOrder: [{ required: true, message: '生产工单' + proxy.$t('btn.empty'), trigger: "change" }],
      pomMfgOrderQty: [{ required: true, message: '工单数量' + proxy.$t('btn.empty'), trigger: "blur" }],
      pomMfgOrderSerial: [{ required: true, message: '管理序列号' + proxy.$t('btn.empty'), trigger: "blur" }],
      pomMfgLot: [{ required: true, message: '生产批次' + proxy.$t('btn.empty'), trigger: "blur" }],
      pomMfgModel: [{ required: true, message: '机种名' + proxy.$t('btn.empty'), trigger: "blur" }],
      pomMfgItem: [{ required: true, message: '物料' + proxy.$t('btn.empty'), trigger: "blur" }],
      pomMfgDate: [{ required: true, message: '生产日期' + proxy.$t('btn.empty'), trigger: "blur" }],
      pomMfgLine: [{ required: true, message: '生产班组' + proxy.$t('btn.empty'), trigger: "change" }],
      pomDirect: [{ required: true, message: '直接人数' + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      pomIndirect: [{ required: true, message: '间接人数' + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      pomStdTime: [{ required: true, message: '标准工时' + proxy.$t('btn.empty'), trigger: "blur" }],
      pomStdOutput: [{ required: true, message: '标准产能' + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 生产工单 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_list: [],
      // 生产班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_line_list: [],
      // 生产时段 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_phase_time: [],
      // 停线原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_line_stop: [],
      // 未达成原因 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_non_conf: [],
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
      pomSfid: 0,
      pomMfgOrder: null,
      pomMfgOrderQty: 0,
      pomMfgOrderSerial: null,
      pomMfgLot: null,
      pomMfgModel: null,
      pomMfgItem: null,
      pomMfgDate: null,
      pomMfgLine: null,
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
    outputSlaveList.value = []
    proxy.resetForm("formRef")
  }

  //赋值
  function assignModelValue(val) {
    let obj = {};
    obj = state.options.sql_moc_list.find((item) => {//这里的userList就是上面遍历的数据源
      return item.dictValue === val;//筛选出匹配数据
    });

    const arr = obj.dictLabel.split("|")
    console.log(arr)
    form.value.pomMfgOrderQty = arr[3]
    if (arr[4] != undefined && arr[4] != null && arr[4] != '') {
      form.value.pomMfgOrderSerial = arr[4]
    }
    else {
      form.value.pomMfgOrderSerial = arr[2] + '00001~' + parseFloat(arr[3]).toFixed(0)
    }

    form.value.pomMfgLot = arr[2]
    form.value.pomMfgModel = arr[5]
    form.value.pomMfgItem = arr[1]
    form.value.pomStdTime = arr[7]
    form.value.pomStdOutput = ((parseFloat(form.value.pomDirect) * 60) / parseFloat(form.value.pomStdTime)).toFixed(2)
  }
  function assignStdlValue(val) {
    form.value.pomStdOutput = ((parseFloat(form.value.pomDirect) * 60) / parseFloat(form.value.pomStdTime)).toFixed(2)
  }
  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + 'oph主表'
    opertype.value = 1
    form.value.pomMfgOrder = []
    form.value.pomMfgOrderQty = 0
    form.value.pomMfgDate = new Date()
    form.value.pomMfgLine = []
    form.value.pomDirect = 0
    form.value.pomIndirect = 0
    form.value.pomStdTime = 0
    form.value.pomStdOutput = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.pomSfid || ids.value
    getOutputMaster(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + 'oph主表'
        opertype.value = 2

        form.value = {
          ...data,
        }
        outputSlaveList.value = res.data.outputSlaveNav
      }
    })
  }

  // 添加&修改 表单提交
  function submitForm() {
    proxy.$refs["formRef"].validate((valid) => {
      if (valid) {

        form.value.outputSlaveNav = outputSlaveList.value
        if (form.value.pomSfid != undefined && opertype.value === 2) {
          updateOutputMaster(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addOutputMaster(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
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
      .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delOutputMaster(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
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
      .$confirm(proxy.$t('common.confirmExport') + "oph主表", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/logistics/OutputMaster/export', { ...queryParams })
      })
  }

  /*********************oph从表子表信息*************************/
  const outputSlaveList = ref([])
  const checkedOutputSlave = ref([])
  const fullScreen = ref(false)
  const drawer = ref(false)

  /** oph从表序号 */
  function rowOutputSlaveIndex({ row, rowIndex }) {
    row.index = rowIndex + 1;
  }

  /** oph从表添加按钮操作 */
  function handleAddOutputSlave() {
    let obj = {};
    //下面的代码自己设置默认值
    obj.posProductionTime = null;
    obj.posRealOutput = null;
    obj.posDownTime = null;
    obj.posDownTimeReasons = null;
    obj.posDownTimeDescription = null;
    obj.posUnfinishedReasons = null;
    obj.posUnfinishedDescription = null;
    obj.posRealWorkhours = null;
    obj.posInputsWorkhours = parseFloat(form.value.pomDirect) * 60;
    obj.posRealWorkinghoursDiff = null;
    obj.posRealOutputDiff = null;
    obj.posAchievedRate = null;
    obj.isDeleted = 0;
    obj.remark = null;
    obj.createBy = null;
    obj.createTime = null;
    obj.updateBy = null;
    obj.updateTime = null;
    outputSlaveList.value.push(obj);
  }

  /** 复选框选中数据 */
  function handleOutputSlaveSelectionChange(selection) {
    checkedOutputSlave.value = selection.map(item => item.index)
  }

  /** oph从表删除按钮操作 */
  function handleDeleteOutputSlave() {
    if (checkedOutputSlave.value.length == 0) {
      proxy.$modal.msgError(proxy.$t('btn.firstDelete') + 'oph从表' + proxy.$t('btn.firstData'))
    } else {
      const OutputSlaves = outputSlaveList.value;
      const checkedOutputSlaves = checkedOutputSlave.value;
      outputSlaveList.value = OutputSlaves.filter(function (item) {
        return checkedOutputSlaves.indexOf(item.index) == -1
      });
    }
  }

  /** oph从表详情 */
  function rowClick(row) {
    const id = row.pomSfid || ids.value
    getOutputMaster(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        drawer.value = true
        outputSlaveList.value = data.outputSlaveNav
      }
    })
  }

  //自定义统计函数
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