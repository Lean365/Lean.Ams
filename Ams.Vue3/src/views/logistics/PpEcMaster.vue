<!--
 * @Descripttion: 设变/pp_ec_master
 * @Version: 0.24.627.15377
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/18 8:51:20
 * @column：47
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="发行日期">
            <el-date-picker v-model="dateRangeMb002" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :default-value="defaultDate" :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="设变No." prop="mb003">
            <el-input v-model="queryParams.mb003"
              :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="标题" prop="mb006">
            <el-input v-model="queryParams.mb006"
              :placeholder="$t('btn.enterSearchPrefix')+'标题'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="内容" prop="mb007">
            <el-input v-model="queryParams.mb007"
              :placeholder="$t('btn.enterSearchPrefix')+'内容'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="担当" prop="mb008">
            <el-select filterable clearable v-model="queryParams.mb008"
              :placeholder="$t('btn.selectSearchPrefix')+'担当'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="管理区分" prop="mb013">
            <el-select filterable clearable v-model="queryParams.mb013"
              :placeholder="$t('btn.selectSearchPrefix')+'管理区分'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ec_mgtype " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="输入日">
            <el-date-picker v-model="dateRangeMb023" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :default-value="defaultDate" :shortcuts="dateOptions">
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
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:ecmaster:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:ecmaster:delete']" plain icon="delete"
          @click="handleDelete">
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
                <importData templateUrl="Logistics/PpEcMaster/importTemplate"
                  importUrl="/Logistics/PpEcMaster/importData" @success="handleFileSuccess"></importData>
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
      <el-table-column prop="mb002" label="发行日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mb002')" />
      <el-table-column prop="mb003" label="设变No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb003')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.mb004" target="_blank">{{ scope.row.mb003 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="mb004" label="关联文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb004')">

      </el-table-column>
      <el-table-column prop="mb005" label="设变状态" align="center" v-if="columns.showColumn('mb005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.mb005" />
        </template>
      </el-table-column>
      <el-table-column prop="mb006" label="标题" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb006')" />
      <el-table-column prop="mb007" label="内容" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb007')" />
      <el-table-column prop="mb008" label="担当" align="center" v-if="columns.showColumn('mb008')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.mb008" />
        </template>
      </el-table-column>
      <el-table-column prop="mb009" label="成本变更" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb009')" />
      <el-table-column prop="mb010" label="单位成本" align="center" v-if="columns.showColumn('mb010')" />
      <el-table-column prop="mb011" label="模具费用" align="center" v-if="columns.showColumn('mb011')" />
      <el-table-column prop="mb012" label="关联图纸" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb012')" />
      <el-table-column prop="mb013" label="管理区分" align="center" v-if="columns.showColumn('mb013')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_mgtype " :value="scope.row.mb013" />
        </template>
      </el-table-column>
      <el-table-column prop="mb014" label="联络No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb014')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.mb015" target="_blank">{{ scope.row.mb014 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="mb015" label="联络文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb015')" />
      <el-table-column prop="mb016" label="EppNo." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb016')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.mb017" target="_blank">{{ scope.row.mb016 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="mb017" label="Epp文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb017')" />
      <el-table-column prop="mb018" label="FppNo." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb018')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.mb019" target="_blank">{{ scope.row.mb018 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="mb019" label="Fpp文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb019')" />
      <el-table-column prop="mb020" label="外部No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb020')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.mb021" target="_blank">{{ scope.row.mb020 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="mb021" label="外部文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb021')" />
      <el-table-column prop="mb022" label="输入部门" align="center" v-if="columns.showColumn('mb022')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.mb022" />
        </template>
      </el-table-column>
      <el-table-column prop="mb023" label="输入日" :show-overflow-tooltip="true" v-if="columns.showColumn('mb023')" />
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['pp:ecmaster:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['pp:ecmaster:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppEcSlaveList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID" />
        <el-table-column prop="parentId" label="父ID" />
        <el-table-column prop="mc003" label="设变No." />
        <el-table-column prop="mc004" label="机种" />
        <el-table-column prop="mc005" label="物料" />
        <el-table-column prop="mc006" label="物料文本" />
        <el-table-column prop="mc007" label="子物料" />
        <el-table-column prop="mc008" label="子物料文本" />
        <el-table-column prop="mc009" label="旧物料" />
        <el-table-column prop="mc010" label="旧文本" />
        <el-table-column prop="mc011" label="旧品库存" />
        <el-table-column prop="mc012" label="用量" />
        <el-table-column prop="mc013" label="位置" />
        <el-table-column prop="mc014" label="新物料" />
        <el-table-column prop="mc015" label="新文本" />
        <el-table-column prop="mc016" label="新品库存" />
        <el-table-column prop="mc017" label="用量" />
        <el-table-column prop="mc018" label="位置" />
        <el-table-column prop="mc019" label="bom番号" />
        <el-table-column prop="mc020" label="互换" />
        <el-table-column prop="mc021" label="区分" />
        <el-table-column prop="mc022" label="指示" />
        <el-table-column prop="mc023" label="旧品处理" />
        <el-table-column prop="mc024" label="bom日期" />
        <el-table-column prop="mc025" label="采购类型" />
        <el-table-column prop="mc026" label="采购组" />
        <el-table-column prop="mc027" label="仓库" />
        <el-table-column prop="mc028" label="检验否" />
        <el-table-column prop="mc029" label="工厂状态" />
        <el-table-column prop="mc030" label="SOP" />
        <el-table-column prop="mc031" label="实施标记" />
        <el-table-column prop="mc032" label="部管" />
        <el-table-column prop="mc033" label="Pcba" />
        <el-table-column prop="mc034" label="组立" />
        <el-table-column prop="remark" label="备注" />
      </el-table>
    </el-drawer>
    <!-- 添加或修改设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="24">
                <el-form-item label="发行日期" prop="mb002">
                  <el-date-picker v-model="form.mb002" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="设变No." prop="mb003">
                  <el-input v-model="form.mb003" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="关联文件" prop="mb004">
                  <UploadFile v-model="form.mb004" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="担当" prop="mb008">
                  <el-select filterable clearable v-model="form.mb008"
                    :placeholder="$t('btn.selectPrefix')+'担当'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_ec_group" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>
              <el-col :lg="12">
                <el-form-item label="管理区分" prop="mb013">
                  <el-select filterable clearable v-model="form.mb013"
                    :placeholder="$t('btn.selectPrefix')+'管理区分'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ec_mgtype" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="标题" prop="mb006">
                  <el-input type="textarea" v-model="form.mb006" :disabled="true"
                    :placeholder="$t('btn.enterPrefix')+'标题'+$t('btn.enterSuffix')" show-word-limit :rows="2"
                    maxlength="500" />
                </el-form-item>
              </el-col>



              <el-col :lg="12">
                <el-form-item label="成本变更" prop="mb009">
                  <el-input v-model="form.mb009" :placeholder="$t('btn.enterPrefix')+'成本变更'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="单位成本" prop="mb010">
                  <el-input-number v-model.number="form.mb010" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'单位成本'+$t('btn.enterSuffix')" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="模具费用" prop="mb011">
                  <el-input-number v-model.number="form.mb011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'模具费用'+$t('btn.enterSuffix')" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="关联图纸" prop="mb012">
                  <el-input v-model="form.mb012" :placeholder="$t('btn.enterPrefix')+'关联图纸'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="设变状态" prop="mb005">
                  <el-select filterable clearable v-model="form.mb005" :disabled="true"
                    :placeholder="$t('btn.selectPrefix')+'设变状态'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ec_status" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>
              <el-col :lg="12">
                <el-form-item label="输入部门" prop="mb022">
                  <el-select filterable clearable v-model="form.mb022" :disabled="true"
                    :placeholder="$t('btn.selectPrefix')+'输入部门'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_dept_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="输入日" prop="mb023">
                  <el-date-picker v-model="form.mb023" type="datetime" :teleported="false" :disabled="true"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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

          <el-tab-pane :label="$t('ptabs.attachment')" name="fourth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="联络No." prop="mb014">
                  <el-input v-model="form.mb014" :placeholder="$t('btn.enterPrefix')+'联络No.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="联络文件" prop="mb015">
                  <UploadFile v-model="form.mb015" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EppNo." prop="mb016">
                  <el-input v-model="form.mb016" :placeholder="$t('btn.enterPrefix')+'EppNo.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="Epp文件" prop="mb017">
                  <UploadFile v-model="form.mb017" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="FppNo." prop="mb018">
                  <el-input v-model="form.mb018" :placeholder="$t('btn.enterPrefix')+'FppNo.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="Fpp文件" prop="mb019">
                  <UploadFile v-model="form.mb019" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="外部No." prop="mb020">
                  <el-input v-model="form.mb020" :placeholder="$t('btn.enterPrefix')+'外部No.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="外部文件" prop="mb021">
                  <UploadFile v-model="form.mb021" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.content')" name="fifth">
            <el-row :gutter="20">
              <el-col :lg="24">
                <el-form-item label="内容" prop="mb007">
                  <el-input type="textarea" v-model="form.mb007"
                    :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')" show-word-limit :rows="16"
                    maxlength="4000" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subMore')" name="17th">
            <el-row :gutter="20">
              <!-- 子表信息 -->
              <el-divider content-position="center">设变明细</el-divider>
              <el-row :gutter="10" class="mb8">
                <el-col :span="1.5">
                  <el-button class="btn-add" icon="Plus" @click="handleAddPpEcSlave">{{ $t('btn.add') }}</el-button>
                </el-col>
                <el-col :span="1.5">
                  <el-button class="btn-delete" icon="Delete" @click="handleDeletePpEcSlave">{{ $t('btn.delete')
                    }}</el-button>
                </el-col>
                <el-col :span="1.5">
                  <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?
                    $t('layout.headerExitfullscreen')
                    : $t('layout.headerFullscreen') }}</el-button>
                </el-col>
              </el-row>
              <el-table :data="myPagedData" :row-class-name="rowPpEcSlaveIndex"
                @selection-change="handlePpEcSlaveSelectionChange" ref="PpEcSlaveRef">
                <el-table-column type="selection" width="40" align="center" />
                <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50" />
                <el-table-column label="设变No." align="center" prop="mc003">

                </el-table-column>
                <el-table-column label="SOP" align="center" prop="mc030" width="70">
                  <template #default="scope">
                    <el-switch v-model="scope.row.mc030" class="ml-2" :active-value="0" :inactive-value="1"
                      :active-text="$t('common.yes')" :inactive-text="$t('common.no')" inline-prompt
                      style="--el-switch-on-color: #337ecc; --el-switch-off-color: #606266" />
                    <!-- <el-input-number v-model="scope.row.mc030" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'SOP'+$t('btn.enterSuffix')" /> -->
                  </template>
                </el-table-column>
                <!-- <el-table-column label="实施标记" align="center" prop="mc031" width="70">
            <template #default="scope">
              <el-switch v-model="scope.row.mc031" class="ml-2":active-value="0" :inactive-value="1"
                :active-text="$t('common.yes')" :inactive-text="$t('common.no')" inline-prompt
                style="--el-switch-on-color: #630eec; --el-switch-off-color: #ff4949" />
              <el-input-number v-model="scope.row.mc031" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'实施标记'+$t('btn.enterSuffix')" /> 
            </template>
          </el-table-column> -->
                <el-table-column label="部管" align="center" prop="mc032" width="70">
                  <template #default="scope">
                    <el-switch v-model="scope.row.mc032" class="ml-2" :active-value="0" :inactive-value="1"
                      :active-text="$t('common.yes')" :inactive-text="$t('common.no')" inline-prompt
                      style="--el-switch-on-color: #529b2e; --el-switch-off-color: #909399" />
                    <!-- <el-input-number v-model="scope.row.mc032" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'部管'+$t('btn.enterSuffix')" /> -->
                  </template>
                </el-table-column>
                <el-table-column label="Pcba" align="center" prop="mc033" width="70">
                  <template #default="scope">
                    <el-switch v-model="scope.row.mc033" class="ml-2" :active-value="0" :inactive-value="1"
                      :active-text="$t('common.yes')" :inactive-text="$t('common.no')" inline-prompt
                      style="--el-switch-on-color: #b88230; --el-switch-off-color: #A8ABB2" />
                    <!-- <el-input-number v-model="scope.row.mc033" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'Pcba'+$t('btn.enterSuffix')" /> -->
                  </template>
                </el-table-column>
                <el-table-column label="组立" align="center" prop="mc034" width="70">
                  <template #default="scope">
                    <el-switch v-model="scope.row.mc034" class="ml-2" :active-value="0" :inactive-value="1"
                      :active-text="$t('common.yes')" :inactive-text="$t('common.no')" inline-prompt
                      style="--el-switch-on-color: #c45656; --el-switch-off-color: #C0C4CC" />
                    <!-- <el-input-number v-model="scope.row.mc034" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'组立'+$t('btn.enterSuffix')" /> -->
                  </template>
                </el-table-column>
                <el-table-column label="机种" align="center" prop="mc004" width="120" show-overflow-tooltip>

                </el-table-column>
                <el-table-column label="物料" align="center" prop="mc005" width="120" show-overflow-tooltip>

                </el-table-column>
                <!-- <el-table-column label="物料文本" align="center" prop="mc006" show-overflow-tooltip>

          </el-table-column> -->
                <el-table-column label="子物料" align="center" prop="mc007" width="120" show-overflow-tooltip>

                </el-table-column>
                <!-- <el-table-column label="子物料文本" align="center" prop="mc008" show-overflow-tooltip>

          </el-table-column> -->
                <el-table-column label="旧物料" align="center" prop="mc009" width="120" show-overflow-tooltip>

                </el-table-column>
                <!-- <el-table-column label="旧文本" align="center" prop="mc010" show-overflow-tooltip>

          </el-table-column> -->
                <el-table-column label="旧品库存" align="center" prop="mc011" width="140">

                </el-table-column>
                <el-table-column label="用量" align="center" prop="mc012" width="40">

                </el-table-column>
                <el-table-column label="位置" align="center" prop="mc013" width="40" show-overflow-tooltip>

                </el-table-column>
                <el-table-column label="新物料" align="center" prop="mc014" width="120" show-overflow-tooltip>

                </el-table-column>
                <!-- <el-table-column label="新文本" align="center" prop="mc015" show-overflow-tooltip>

          </el-table-column> -->
                <el-table-column label="新品库存" align="center" prop="mc016" width="140">

                </el-table-column>
                <el-table-column label="用量" align="center" prop="mc017" width="40">

                </el-table-column>
                <el-table-column label="位置" align="center" prop="mc018" width="40" show-overflow-tooltip>

                </el-table-column>
                <el-table-column label="番号" align="center" prop="mc019" width="40" show-overflow-tooltip>

                </el-table-column>
                <!-- <el-table-column label="互换" align="center" prop="mc020">

          </el-table-column>
          <el-table-column label="区分" align="center" prop="mc021">

          </el-table-column>
          <el-table-column label="指示" align="center" prop="mc022">

          </el-table-column>
          <el-table-column label="旧品处理" align="center" prop="mc023">

          </el-table-column>
          <el-table-column label="bom日期" align="center" prop="mc024">
            <template #default="scope"> {{ parseTime(scope.row.mc024, 'YYYY-MM-DD') }} </template>
          </el-table-column> -->
                <el-table-column label="采购类型" align="center" prop="mc025">

                </el-table-column>
                <el-table-column label="采购组" align="center" prop="mc026">

                </el-table-column>
                <el-table-column label="仓库" align="center" prop="mc027">

                </el-table-column>
                <el-table-column label="检验否" align="center" prop="mc028">

                </el-table-column>
                <el-table-column label="工厂状态" align="center" prop="mc029">

                </el-table-column>

                <!-- <el-table-column label="备注" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column> -->
              </el-table>
              <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange"
                :current-page="currentPage" :page-size="pageSize" :page-sizes="[14, 28, 56, 112, 224]"
                :total="ppEcSlaveList.length" layout="->,total, sizes, prev, pager, next, jumper">
              </el-pagination>


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

<script setup name="ppecmaster">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listPpEcMaster,
    addPpEcMaster, delPpEcMaster,
    updatePpEcMaster, getPpEcMaster,
  }
    from '@/api/logistics/ppecmaster.js'
  import importData from '@/components/ImportData'
  import useUserStore from '@/store/modules/user'
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
    sort: 'Mb003',
    sortType: 'asc',
    //是否查询（1是）
    mb002: undefined,
    //是否查询（1是）
    mb003: undefined,
    //是否查询（1是）
    mb006: undefined,
    //是否查询（1是）
    mb007: undefined,
    //是否查询（1是）
    mb008: undefined,
    //是否查询（1是）
    mb013: undefined,
    //是否查询（1是）
    mb023: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mb002', label: '发行日期' },
    { visible: true, prop: 'mb003', label: '设变No.' },
    { visible: false, prop: 'mb004', label: '关联文件' },
    { visible: true, prop: 'mb005', label: '设变状态' },
    { visible: true, prop: 'mb006', label: '标题' },
    { visible: true, prop: 'mb007', label: '内容' },
    { visible: true, prop: 'mb008', label: '担当' },
    { visible: false, prop: 'mb009', label: '成本变更' },
    { visible: false, prop: 'mb010', label: '单位成本' },
    { visible: false, prop: 'mb011', label: '模具费用' },
    { visible: false, prop: 'mb012', label: '关联图纸' },
    { visible: false, prop: 'mb013', label: '管理区分' },
    { visible: true, prop: 'mb014', label: '联络No.' },
    { visible: false, prop: 'mb015', label: '联络文件' },
    { visible: true, prop: 'mb016', label: 'EppNo.' },
    { visible: false, prop: 'mb017', label: 'Epp文件' },
    { visible: true, prop: 'mb018', label: 'FppNo.' },
    { visible: false, prop: 'mb019', label: 'Fpp文件' },
    { visible: true, prop: 'mb020', label: '外部No.' },
    { visible: false, prop: 'mb021', label: '外部文件' },
    { visible: false, prop: 'mb022', label: '输入部门' },
    { visible: true, prop: 'mb023', label: '输入日' },
    { visible: false, prop: 'remark', label: '备注' },
  ])
  // 记录数
  const total = ref(0)
  //定义数据变量
  const dataList = ref([])
  //查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(1899, 12, 31, 0, 0, 0), new Date(9999, 11, 30, 23, 59, 59)])
  //const defaultDate = ref([new Date(), new Date(new Date().setDate(new Date().getDate() + 7))]);
  const defaultDate = ref([new Date(1899, 12, 31, 0, 0, 0), new Date(9999, 11, 30, 23, 59, 59)])
  // 发行日期时间范围
  const dateRangeMb002 = ref([new Date(1899, 12, 31, 0, 0, 0), new Date(9999, 11, 30, 23, 59, 59)])
  // 输入日时间范围
  const dateRangeMb023 = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sys_ec_status" },
    { dictType: "sql_ec_group" },
    { dictType: "sys_ec_mgtype" },
    { dictType: "sql_dept_list" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从设变/pp_ec_master表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMb002.value, 'Mb002');
    proxy.addDateRange(queryParams, dateRangeMb023.value, 'Mb023');
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
  function resetQuery() {
    // 发行日期时间范围
    dateRangeMb002.value = []
    // 输入日时间范围
    dateRangeMb023.value = []
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
      mb003: [{ required: true, message: "设变No." + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mb005: [{ required: true, message: "设变状态" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mb010: [{ required: true, message: "单位成本" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mb011: [{ required: true, message: "模具费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mb013: [{ required: true, message: "管理区分" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
    },
    //字典名称
    options: {
      // 设变状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ec_status: [],
      // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ec_group: [],
      // 管理区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ec_mgtype: [],
      // 输入部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_dept_list: [],
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
      mb002: null,
      mb003: null,
      mb004: null,
      mb005: [],
      mb006: null,
      mb007: null,
      mb008: [],
      mb009: null,
      mb010: 0,
      mb011: 0,
      mb012: null,
      mb013: [],
      mb014: null,
      mb015: null,
      mb016: null,
      mb017: null,
      mb018: null,
      mb019: null,
      mb020: null,
      mb021: null,
      mb022: [],
      mb023: null,
      remark: null,
    };
    ppEcSlaveList.value = []
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '设变'
    opertype.value = 1
    form.value.mb002 = new Date()
    form.value.mb005 = 0
    form.value.mb008 = []
    form.value.mb010 = 0
    form.value.mb011 = 0
    form.value.mb013 = 0
    form.value.mb022 = []
    form.value.mb023 = new Date()
    form.value.mb022 = useUserStore().deptId
  }
  //前端分布显示
  const currentPage = ref(1)
  const pageSize = ref(14)
  const myPagedData = computed(() => {
    const start = (currentPage.value - 1) * pageSize.value
    const end = start + pageSize.value
    return ppEcSlaveList.value.slice(start, end)
  })

  const handleCurrentChange = (newPage) => {
    currentPage.value = newPage
  }

  const handleSizeChange = (newSize) => {
    pageSize.value = newSize
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getPpEcMaster(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '设变'
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
        if (form.value.id != undefined && opertype.value === 2) {
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
    const Ids = row.id || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<设变.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/PpEcMaster/export', { ...queryParams })
      })
  }

  /*********************设变明细子表信息*************************/
  const ppEcSlaveList = ref([])
  const checkedPpEcSlave = ref([])
  const fullScreen = ref(false)
  const drawer = ref(false)

  /** 设变明细序号 */
  function rowPpEcSlaveIndex({ row, rowIndex }) {
    row.index = rowIndex + 1;
  }

  /** 设变明细添加按钮操作 */
  function handleAddPpEcSlave() {
    let obj = {};
    //下面的代码自己设置默认值
    //obj.mc003 = null;
    //obj.mc004 = null;
    //obj.mc005 = null;
    //obj.mc006 = null;
    //obj.mc007 = null;
    //obj.mc008 = null;
    //obj.mc009 = null;
    //obj.mc010 = null;
    //obj.mc011 = null;
    //obj.mc012 = null;
    //obj.mc013 = null;
    //obj.mc014 = null;
    //obj.mc015 = null;
    //obj.mc016 = null;
    //obj.mc017 = null;
    //obj.mc018 = null;
    //obj.mc019 = null;
    //obj.mc020 = null;
    //obj.mc021 = null;
    //obj.mc022 = null;
    //obj.mc023 = null;
    //obj.mc024 = null;
    //obj.mc025 = null;
    //obj.mc026 = null;
    //obj.mc027 = null;
    //obj.mc028 = null;
    //obj.mc029 = null;
    //obj.mc030 = null;
    //obj.mc031 = null;
    //obj.mc032 = null;
    //obj.mc033 = null;
    //obj.mc034 = null;
    //obj.remark = null;
    ppEcSlaveList.value.push(obj);
  }

  /** 复选框选中数据 */
  function handlePpEcSlaveSelectionChange(selection) {
    checkedPpEcSlave.value = selection.map(item => item.index)
  }

  /** 设变明细删除按钮操作 */
  function handleDeletePpEcSlave() {
    if (checkedPpEcSlave.value.length == 0) {
      proxy.$modal.msgError('请先选择要删除的设变明细数据')
    } else {
      const PpEcSlaves = ppEcSlaveList.value;
      const checkedPpEcSlaves = checkedPpEcSlave.value;
      ppEcSlaveList.value = PpEcSlaves.filter(function (item) {
        return checkedPpEcSlaves.indexOf(item.index) == -1
      });
    }
  }

  /** 设变明细详情 */
  function rowClick(row) {
    const id = row.id || ids.value
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