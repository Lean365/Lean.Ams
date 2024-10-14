<!--
 * @Descripttion: 组立OPH/pp_output_assy_ma
 * @Version: 0.24.621.29240
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 16:21:13
 * @column：38
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="工单号码" prop="mma003">
            <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_moc_assy"
              :loading="loading" v-model="queryParams.mma003"
              :placeholder="$t('btn.selectSearchPrefix')+'工单号码'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   remotequery_sql_moc_assy " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="生产批次" prop="mma006">
            <el-input v-model="queryParams.mma006"
              :placeholder="$t('btn.enterSearchPrefix')+'生产批次'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="机种名" prop="mma007">
            <el-input v-model="queryParams.mma007"
              :placeholder="$t('btn.enterSearchPrefix')+'机种名'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="物料" prop="mma008">
            <el-input v-model="queryParams.mma008"
              :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="生产日期">
            <el-date-picker v-model="dateRangeMma009" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="生产班组" prop="mma010">
            <el-select filterable clearable v-model="queryParams.mma010"
              :placeholder="$t('btn.selectSearchPrefix')+'生产班组'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_assy_line " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:outputassyma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:outputassyma:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:outputassyma:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputassyma:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/PpOutputAssyMa/importTemplate"
                  importUrl="/Logistics/PpOutputAssyMa/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['pp:outputassyma:export']">
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain icon="view" size="small" @click="rowClick(scope.row)"
            :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')" />
      <el-table-column prop="mma002" label="工单类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mma002')" />
      <el-table-column prop="mma003" label="工单号码" align="center" v-if="columns.showColumn('mma003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_assy " :value="scope.row.mma003" />
        </template>
      </el-table-column>
      <el-table-column prop="mma004" label="工单数量" align="center" v-if="columns.showColumn('mma004')" />
      <el-table-column prop="mma005" label="序列号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mma005')" />
      <el-table-column prop="mma006" label="生产批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mma006')" />
      <el-table-column prop="mma007" label="机种名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mma007')" />
      <el-table-column prop="mma008" label="物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mma008')" />
      <el-table-column prop="mma009" label="生产日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mma009')" />
      <el-table-column prop="mma010" label="生产班组" align="center" v-if="columns.showColumn('mma010')">
        <template #default="scope">
          <dict-tag :options=" options.sql_assy_line " :value="scope.row.mma010" />
        </template>
      </el-table-column>
      <el-table-column prop="mma011" label="直接人数" align="center" v-if="columns.showColumn('mma011')" />
      <el-table-column prop="mma012" label="间接人数" align="center" v-if="columns.showColumn('mma012')" />
      <el-table-column prop="mma013" label="标准工时" align="center" v-if="columns.showColumn('mma013')" />
      <el-table-column prop="mma014" label="标准产能" align="center" v-if="columns.showColumn('mma014')" />
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['pp:outputassyma:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['pp:outputassyma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppOutputAssySlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID" />
        <el-table-column prop="parentId" label="父Id" />
        <el-table-column prop="mmb002" label="生产时段" />
        <el-table-column prop="mmb003" label="实际产能" />
        <el-table-column prop="mmb004" label="停线时间" />
        <el-table-column prop="mmb005" label="停线">
          <template #default="scope">
            <dict-tag :options=" options.sql_line_stop " :value="scope.row.mmb005" />
          </template>
        </el-table-column>
        <el-table-column prop="mmb006" label="停线说明" />
        <el-table-column prop="mmb007" label="未达成">
          <template #default="scope">
            <dict-tag :options=" options.sql_non_conf " :value="scope.row.mmb007" />
          </template>
        </el-table-column>
        <el-table-column prop="mmb008" label="未达成说明" />
        <el-table-column prop="mmb009" label="实际工数" />
        <el-table-column prop="mmb010" label="投入工数" />
        <el-table-column prop="mmb011" label="工时差异" />
        <el-table-column prop="mmb012" label="产能差异" />
        <el-table-column prop="mmb013" label="达成率" />
        <el-table-column prop="remark" label="备注" />
      </el-table>
    </el-drawer>
    <!-- 添加或修改组立OPH对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="工单类别" prop="mma002">
                  <el-input v-model="form.mma002" :placeholder="$t('btn.enterPrefix')+'工单类别'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工单号码" prop="mma003">
                  <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_moc_assy"
                    :loading="loading" v-model="form.mma003"
                    :placeholder="$t('btn.selectPrefix')+'工单号码'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  remotequery_sql_moc_assy" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="工单数量" prop="mma004">
                  <el-input-number v-model.number="form.mma004" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'工单数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序列号" prop="mma005">
                  <el-input v-model="form.mma005" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产批次" prop="mma006">
                  <el-input v-model="form.mma006" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="机种名" prop="mma007">
                  <el-input v-model="form.mma007" :placeholder="$t('btn.enterPrefix')+'机种名'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="100" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="mma008">
                  <el-input v-model="form.mma008" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产日期" prop="mma009">
                  <el-date-picker v-model="form.mma009" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产班组" prop="mma010">
                  <el-select filterable clearable v-model="form.mma010"
                    :placeholder="$t('btn.selectPrefix')+'生产班组'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_assy_line" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="直接人数" prop="mma011">
                  <el-input-number v-model.number="form.mma011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'直接人数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接人数" prop="mma012">
                  <el-input-number v-model.number="form.mma012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间接人数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准工时" prop="mma013">
                  <el-input-number v-model.number="form.mma013" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'标准工时'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准产能" prop="mma014">
                  <el-input-number v-model.number="form.mma014" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'标准产能'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" show-word-limit maxlength="500" />
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
        <el-divider content-position="center">组立明细</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpOutputAssySlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpOutputAssySlv">{{ $t('btn.delete')
              }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?
              $t('layout.headerExitfullscreen')
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppOutputAssySlvList" :row-class-name="rowPpOutputAssySlvIndex"
          @selection-change="handlePpOutputAssySlvSelectionChange" ref="PpOutputAssySlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50" />
          <el-table-column label="生产时段" align="center" prop="mmb002">
            <template #default="scope">
              <el-input v-model="scope.row.mmb002" :placeholder="$t('btn.enterPrefix')+'生产时段'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="实际产能" align="center" prop="mmb003" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mmb003" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'实际产能'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="停线时间" align="center" prop="mmb004" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mmb004" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'停线时间'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="停线" prop="mmb005">
            <template #default="scope">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip v-model="scope.row.mmb005"
                :placeholder="$t('btn.enterPrefix')+'停线'+$t('btn.enterSuffix')">
                <el-option v-for="item in options.sql_line_stop" :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="停线说明" align="center" prop="mmb006">
            <template #default="scope">
              <el-input v-model="scope.row.mmb006" :placeholder="$t('btn.enterPrefix')+'停线说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="未达成" prop="mmb007">
            <template #default="scope">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip v-model="scope.row.mmb007"
                :placeholder="$t('btn.enterPrefix')+'未达成'+$t('btn.enterSuffix')">
                <el-option v-for="item in options.sql_non_conf" :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="未达成说明" align="center" prop="mmb008">
            <template #default="scope">
              <el-input v-model="scope.row.mmb008" :placeholder="$t('btn.enterPrefix')+'未达成说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="实际工数" align="center" prop="mmb009" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mmb009" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'实际工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="投入工数" align="center" prop="mmb010" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mmb010" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'投入工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="工时差异" align="center" prop="mmb011" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mmb011" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'工时差异'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="产能差异" align="center" prop="mmb012" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mmb012" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'产能差异'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="达成率" align="center" prop="mmb013" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mmb013" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'达成率'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
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

<script setup name="ppoutputassyma">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listPpOutputAssyMa,
    addPpOutputAssyMa, delPpOutputAssyMa,
    updatePpOutputAssyMa, getPpOutputAssyMa,
  }
    from '@/api/logistics/ppoutputassyma.js'
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
    sort: 'Mma009',
    sortType: 'desc',
    //是否查询（1是）
    mma003: undefined,
    //是否查询（1是）
    mma006: undefined,
    //是否查询（1是）
    mma007: undefined,
    //是否查询（1是）
    mma008: undefined,
    //是否查询（1是）
    mma009: undefined,
    //是否查询（1是）
    mma010: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mma002', label: '工单类别' },
    { visible: true, prop: 'mma003', label: '工单号码' },
    { visible: true, prop: 'mma004', label: '工单数量' },
    { visible: true, prop: 'mma005', label: '序列号' },
    { visible: true, prop: 'mma006', label: '生产批次' },
    { visible: true, prop: 'mma007', label: '机种名' },
    { visible: true, prop: 'mma008', label: '物料' },
    { visible: false, prop: 'mma009', label: '生产日期' },
    { visible: false, prop: 'mma010', label: '生产班组' },
    { visible: false, prop: 'mma011', label: '直接人数' },
    { visible: false, prop: 'mma012', label: '间接人数' },
    { visible: false, prop: 'mma013', label: '标准工时' },
    { visible: false, prop: 'mma014', label: '标准产能' },
    { visible: false, prop: 'remark', label: '备注' },
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
  const remotequeryList_sql_moc_assy = ref([])
  //定义远程搜索变量
  const remotequery_sql_moc_assy = ref([])
  //远程字典参数
  var remotedictParams_sql_moc_assy = [
    { dictType: "sql_moc_assy" },
  ]
  //远程搜索组件实例
  onMounted(() => {
    proxy.getDicts(remotedictParams_sql_moc_assy).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_moc_assy.value = element.list
      })
      //console.log(remotequeryList_sql_moc_assy)
    })
  })
  //远程搜索
  const remoteMethod_sql_moc_assy = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_moc_assy.value = remotequeryList_sql_moc_assy.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_moc_assy(query)
      }, 2000)
    } else {
      //默认显示前15条记录
      remotequery_sql_moc_assy.value.slice(0, 15)
    }
  }, 300)
  // 筛选方法
  const filterMethod_sql_moc_assy = debounce((query) => {
    let arr = remotequeryList_sql_moc_assy.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_moc_assy.value = arr.slice(0, 5)
      addFilterOptions_sql_moc_assy(query)
    } else {
      remotequery_sql_moc_assy.value = arr
    }
  }, 300)
  // 精准筛选方法
  const addFilterOptions_sql_moc_assy = debounce((dictValue) => {
    let target = remotequeryList_sql_moc_assy.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_moc_assy.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_moc_assy.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
  // 生产日期时间范围
  const dateRangeMma009 = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sql_moc_assy" },
    { dictType: "sql_assy_line" },
    { dictType: "sql_line_stop" },
    { dictType: "sql_non_conf" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从组立OPH/pp_output_assy_ma表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMma009.value, 'Mma009');
    loading.value = true
    listPpOutputAssyMa(queryParams).then(res => {
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
    dateRangeMma009.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.id);
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
    //正则表达式
    rules: {
      mma003: [{ required: true, message: "工单号码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mma004: [{ required: true, message: "工单数量" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mma010: [{ required: true, message: "生产班组" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mma011: [{ required: true, message: "直接人数" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mma012: [{ required: true, message: "间接人数" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mma013: [{ required: true, message: "标准工时" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mma014: [{ required: true, message: "标准产能" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
      // 工单号码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_moc_assy: [],
      // 生产班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_assy_line: [],
      // 停线 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_line_stop: [],
      // 未达成 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
      mma002: null,
      mma003: [],
      mma004: 0,
      mma005: null,
      mma006: null,
      mma007: null,
      mma008: null,
      mma009: null,
      mma010: [],
      mma011: 0,
      mma012: 0,
      mma013: 0,
      mma014: 0,
      remark: null,
    };
    ppOutputAssySlvList.value = []
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '组立OPH'
    opertype.value = 1
    form.value.mma003 = []
    form.value.mma004 = 0
    form.value.mma009 = new Date()
    form.value.mma010 = []
    form.value.mma011 = 0
    form.value.mma012 = 0
    form.value.mma013 = 0
    form.value.mma014 = 0
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getPpOutputAssyMa(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '组立OPH'
        opertype.value = 2

        form.value = {
          ...data,
        }
        ppOutputAssySlvList.value = res.data.ppOutputAssySlvNav
      }
    })
  }

  // 添加&修改 表单提交
  function submitForm() {
    proxy.$refs["formRef"].validate((valid) => {
      if (valid) {

        form.value.ppOutputAssySlvNav = ppOutputAssySlvList.value
        if (form.value.id != undefined && opertype.value === 2) {
          updatePpOutputAssyMa(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addPpOutputAssyMa(form.value).then((res) => {
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
    const Ids = row.id || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delPpOutputAssyMa(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<组立OPH.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/PpOutputAssyMa/export', { ...queryParams })
      })
  }

  /*********************组立明细子表信息*************************/
  const ppOutputAssySlvList = ref([])
  const checkedPpOutputAssySlv = ref([])
  const fullScreen = ref(false)
  const drawer = ref(false)

  /** 组立明细序号 */
  function rowPpOutputAssySlvIndex({ row, rowIndex }) {
    row.index = rowIndex + 1;
  }

  /** 组立明细添加按钮操作 */
  function handleAddPpOutputAssySlv() {
    let obj = {};
    //下面的代码自己设置默认值
    //obj.mmb002 = null;
    //obj.mmb003 = null;
    //obj.mmb004 = null;
    //obj.mmb005 = null;
    //obj.mmb006 = null;
    //obj.mmb007 = null;
    //obj.mmb008 = null;
    //obj.mmb009 = null;
    //obj.mmb010 = null;
    //obj.mmb011 = null;
    //obj.mmb012 = null;
    //obj.mmb013 = null;
    //obj.remark = null;
    ppOutputAssySlvList.value.push(obj);
  }

  /** 复选框选中数据 */
  function handlePpOutputAssySlvSelectionChange(selection) {
    checkedPpOutputAssySlv.value = selection.map(item => item.index)
  }

  /** 组立明细删除按钮操作 */
  function handleDeletePpOutputAssySlv() {
    if (checkedPpOutputAssySlv.value.length == 0) {
      proxy.$modal.msgError('请先选择要删除的组立明细数据')
    } else {
      const PpOutputAssySlvs = ppOutputAssySlvList.value;
      const checkedPpOutputAssySlvs = checkedPpOutputAssySlv.value;
      ppOutputAssySlvList.value = PpOutputAssySlvs.filter(function (item) {
        return checkedPpOutputAssySlvs.indexOf(item.index) == -1
      });
    }
  }

  /** 组立明细详情 */
  function rowClick(row) {
    const id = row.id || ids.value
    getPpOutputAssyMa(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        drawer.value = true
        ppOutputAssySlvList.value = data.ppOutputAssySlvNav
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