<!--
 * @Descripttion: 品质业务/qm_cost_operation
 * @Version: 0.24.620.29565
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 16:48:39
 * @column：66
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="工厂" prop="mc002">
            <el-select filterable clearable v-model="queryParams.mc002"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="日期">
            <el-date-picker v-model="dateRangeMc003" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
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
        <el-button class="btn-add" v-hasPermi="['qm:costoperation:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:costoperation:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:costoperation:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:costoperation:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/QmCostOperation/importTemplate"
                  importUrl="/Logistics/QmCostOperation/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['qm:costoperation:export']">
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')" />
      <el-table-column prop="mc002" label="工厂" align="center" v-if="columns.showColumn('mc002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mc002" />
        </template>
      </el-table-column>
      <el-table-column prop="mc003" label="日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mc003')" />
      <el-table-column prop="mc004" label="间接赁率" align="center" v-if="columns.showColumn('mc004')" />
      <el-table-column prop="mc005" label="IQC检查费用" align="center" v-if="columns.showColumn('mc005')" />
      <el-table-column prop="mc006" label="检查时间" align="center" v-if="columns.showColumn('mc006')" />
      <el-table-column prop="mc007" label="差旅费" align="center" v-if="columns.showColumn('mc007')" />
      <el-table-column prop="mc008" label="其他费用" align="center" v-if="columns.showColumn('mc008')" />
      <el-table-column prop="mc009" label="特记说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc009')" />
      <el-table-column prop="mc010" label="初期检定.定期检定业务费用" align="center" v-if="columns.showColumn('mc010')" />
      <el-table-column prop="mc011" label="作业时间" align="center" v-if="columns.showColumn('mc011')" />
      <el-table-column prop="mc012" label="其他费用" align="center" v-if="columns.showColumn('mc012')" />
      <el-table-column prop="mc013" label="特记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc013')" />
      <el-table-column prop="mc014" label="测定器校正业务费用" align="center" v-if="columns.showColumn('mc014')" />
      <el-table-column prop="mc015" label="校正时间" align="center" v-if="columns.showColumn('mc015')" />
      <el-table-column prop="mc016" label="外部委托，搬运费" align="center" v-if="columns.showColumn('mc016')" />
      <el-table-column prop="mc017" label="其他费用" align="center" v-if="columns.showColumn('mc017')" />
      <el-table-column prop="mc018" label="特记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc018')" />
      <el-table-column prop="mc019" label="其他通常费用" align="center" v-if="columns.showColumn('mc019')" />
      <el-table-column prop="mc020" label="通常作业时间" align="center" v-if="columns.showColumn('mc020')" />
      <el-table-column prop="mc021" label="通常其他费用" align="center" v-if="columns.showColumn('mc021')" />
      <el-table-column prop="mc022" label="特记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc022')" />
      <el-table-column prop="mc023" label="附件1" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc023')" />
      <el-table-column prop="mc024" label="IQC品质问题対応记录者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc024')" />
      <el-table-column prop="mc025" label="出货检查费用" align="center" v-if="columns.showColumn('mc025')" />
      <el-table-column prop="mc026" label="检查时间" align="center" v-if="columns.showColumn('mc026')" />
      <el-table-column prop="mc027" label="其他费用" align="center" v-if="columns.showColumn('mc027')" />
      <el-table-column prop="mc028" label="特记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc028')" />
      <el-table-column prop="mc029" label="信赖性评价.ORT业务费用" align="center" v-if="columns.showColumn('mc029')" />
      <el-table-column prop="mc030" label="评价时间" align="center" v-if="columns.showColumn('mc030')" />
      <el-table-column prop="mc031" label="其他费用" align="center" v-if="columns.showColumn('mc031')" />
      <el-table-column prop="mc032" label="特记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc032')" />
      <el-table-column prop="mc033" label="顾客品质要求对应业务费用" align="center" v-if="columns.showColumn('mc033')" />
      <el-table-column prop="mc034" label="评价作业时间" align="center" v-if="columns.showColumn('mc034')" />
      <el-table-column prop="mc035" label="评价其他费用" align="center" v-if="columns.showColumn('mc035')" />
      <el-table-column prop="mc036" label="特记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc036')" />
      <el-table-column prop="mc037" label="其他通常业务费用" align="center" v-if="columns.showColumn('mc037')" />
      <el-table-column prop="mc038" label="通常业务作业时间" align="center" v-if="columns.showColumn('mc038')" />
      <el-table-column prop="mc039" label="通常业务其他费用" align="center" v-if="columns.showColumn('mc039')" />
      <el-table-column prop="mc040" label="特记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc040')" />
      <el-table-column prop="mc041" label="附件2" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc041')" />
      <el-table-column prop="mc042" label="QA品质问题対応记录者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc042')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['qm:costoperation:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['qm:costoperation:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改品质业务对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="工厂" prop="mc002">
                  <el-select filterable clearable v-model="form.mc002"
                    :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="日期" prop="mc003">
                  <el-date-picker v-model="form.mc003" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接赁率" prop="mc004">
                  <el-input-number v-model.number="form.mc004" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间接赁率'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="IQC检查费用" prop="mc005">
                  <el-input-number v-model.number="form.mc005" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'IQC检查费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="检查时间" prop="mc006">
                  <el-input-number v-model.number="form.mc006" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'检查时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="差旅费" prop="mc007">
                  <el-input-number v-model.number="form.mc007" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'差旅费'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他费用" prop="mc008">
                  <el-input-number v-model.number="form.mc008" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记说明" prop="mc009">
                  <el-input v-model="form.mc009" :placeholder="$t('btn.enterPrefix')+'特记说明'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="初期检定.定期检定业务费用" prop="mc010">
                  <el-input-number v-model.number="form.mc010" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'初期检定.定期检定业务费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="作业时间" prop="mc011">
                  <el-input-number v-model.number="form.mc011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'作业时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他费用" prop="mc012">
                  <el-input-number v-model.number="form.mc012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记" prop="mc013">
                  <el-input v-model="form.mc013" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="测定器校正业务费用" prop="mc014">
                  <el-input-number v-model.number="form.mc014" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'测定器校正业务费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="校正时间" prop="mc015">
                  <el-input-number v-model.number="form.mc015" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'校正时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="外部委托，搬运费" prop="mc016">
                  <el-input-number v-model.number="form.mc016" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'外部委托，搬运费'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他费用" prop="mc017">
                  <el-input-number v-model.number="form.mc017" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记" prop="mc018">
                  <el-input v-model="form.mc018" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他通常费用" prop="mc019">
                  <el-input-number v-model.number="form.mc019" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他通常费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="通常作业时间" prop="mc020">
                  <el-input-number v-model.number="form.mc020" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'通常作业时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="通常其他费用" prop="mc021">
                  <el-input-number v-model.number="form.mc021" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'通常其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记" prop="mc022">
                  <el-input v-model="form.mc022" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="附件1" prop="mc023">
                  <UploadFile v-model="form.mc023" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="IQC品质问题対応记录者" prop="mc024">
                  <el-input v-model="form.mc024"
                    :placeholder="$t('btn.enterPrefix')+'IQC品质问题対応记录者'+$t('btn.enterSuffix')" show-word-limit
                    maxlength="50" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="出货检查费用" prop="mc025">
                  <el-input-number v-model.number="form.mc025" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'出货检查费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="检查时间" prop="mc026">
                  <el-input-number v-model.number="form.mc026" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'检查时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他费用" prop="mc027">
                  <el-input-number v-model.number="form.mc027" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记" prop="mc028">
                  <el-input v-model="form.mc028" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="信赖性评价.ORT业务费用" prop="mc029">
                  <el-input-number v-model.number="form.mc029" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'信赖性评价.ORT业务费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评价时间" prop="mc030">
                  <el-input-number v-model.number="form.mc030" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'评价时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他费用" prop="mc031">
                  <el-input-number v-model.number="form.mc031" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记" prop="mc032">
                  <el-input v-model="form.mc032" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="顾客品质要求对应业务费用" prop="mc033">
                  <el-input-number v-model.number="form.mc033" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'顾客品质要求对应业务费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评价作业时间" prop="mc034">
                  <el-input-number v-model.number="form.mc034" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'评价作业时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评价其他费用" prop="mc035">
                  <el-input-number v-model.number="form.mc035" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'评价其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记" prop="mc036">
                  <el-input v-model="form.mc036" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他通常业务费用" prop="mc037">
                  <el-input-number v-model.number="form.mc037" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他通常业务费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="通常业务作业时间" prop="mc038">
                  <el-input-number v-model.number="form.mc038" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'通常业务作业时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="通常业务其他费用" prop="mc039">
                  <el-input-number v-model.number="form.mc039" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'通常业务其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特记" prop="mc040">
                  <el-input v-model="form.mc040" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="附件2" prop="mc041">
                  <UploadFile v-model="form.mc041" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="QA品质问题対応记录者" prop="mc042">
                  <el-input v-model="form.mc042"
                    :placeholder="$t('btn.enterPrefix')+'QA品质问题対応记录者'+$t('btn.enterSuffix')" show-word-limit
                    maxlength="50" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注说明" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500" />
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

<script setup name="qmcostoperation">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listQmCostOperation,
    addQmCostOperation, delQmCostOperation,
    updateQmCostOperation, getQmCostOperation,
  }
    from '@/api/logistics/qmcostoperation.js'
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
    sort: 'Mc003',
    sortType: 'desc',
    //是否查询（1是）
    mc002: undefined,
    //是否查询（1是）
    mc003: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mc002', label: '工厂' },
    { visible: true, prop: 'mc003', label: '日期' },
    { visible: true, prop: 'mc004', label: '间接赁率' },
    { visible: true, prop: 'mc005', label: 'IQC检查费用' },
    { visible: true, prop: 'mc006', label: '检查时间' },
    { visible: true, prop: 'mc007', label: '差旅费' },
    { visible: true, prop: 'mc008', label: '其他费用' },
    { visible: false, prop: 'mc009', label: '特记说明' },
    { visible: false, prop: 'mc010', label: '初期检定.定期检定业务费用' },
    { visible: false, prop: 'mc011', label: '作业时间' },
    { visible: false, prop: 'mc012', label: '其他费用' },
    { visible: false, prop: 'mc013', label: '特记' },
    { visible: false, prop: 'mc014', label: '测定器校正业务费用' },
    { visible: false, prop: 'mc015', label: '校正时间' },
    { visible: false, prop: 'mc016', label: '外部委托，搬运费' },
    { visible: false, prop: 'mc017', label: '其他费用' },
    { visible: false, prop: 'mc018', label: '特记' },
    { visible: false, prop: 'mc019', label: '其他通常费用' },
    { visible: false, prop: 'mc020', label: '通常作业时间' },
    { visible: false, prop: 'mc021', label: '通常其他费用' },
    { visible: false, prop: 'mc022', label: '特记' },
    { visible: false, prop: 'mc023', label: '附件1' },
    { visible: false, prop: 'mc024', label: 'IQC品质问题対応记录者' },
    { visible: false, prop: 'mc025', label: '出货检查费用' },
    { visible: false, prop: 'mc026', label: '检查时间' },
    { visible: false, prop: 'mc027', label: '其他费用' },
    { visible: false, prop: 'mc028', label: '特记' },
    { visible: false, prop: 'mc029', label: '信赖性评价.ORT业务费用' },
    { visible: false, prop: 'mc030', label: '评价时间' },
    { visible: false, prop: 'mc031', label: '其他费用' },
    { visible: false, prop: 'mc032', label: '特记' },
    { visible: false, prop: 'mc033', label: '顾客品质要求对应业务费用' },
    { visible: false, prop: 'mc034', label: '评价作业时间' },
    { visible: false, prop: 'mc035', label: '评价其他费用' },
    { visible: false, prop: 'mc036', label: '特记' },
    { visible: false, prop: 'mc037', label: '其他通常业务费用' },
    { visible: false, prop: 'mc038', label: '通常业务作业时间' },
    { visible: false, prop: 'mc039', label: '通常业务其他费用' },
    { visible: false, prop: 'mc040', label: '特记' },
    { visible: false, prop: 'mc041', label: '附件2' },
    { visible: false, prop: 'mc042', label: 'QA品质问题対応记录者' },
    { visible: false, prop: 'remark', label: '备注说明' },
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
  const dateRangeMc003 = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sql_plant_list" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从品质业务/qm_cost_operation表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMc003.value, 'Mc003');
    loading.value = true
    listQmCostOperation(queryParams).then(res => {
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
    // 日期时间范围
    dateRangeMc003.value = []
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
      mc002: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mc003: [{ required: true, message: "日期" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc004: [{ required: true, message: "间接赁率" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc005: [{ required: true, message: "IQC检查费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc006: [{ required: true, message: "检查时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc007: [{ required: true, message: "差旅费" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc008: [{ required: true, message: "其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc010: [{ required: true, message: "初期检定.定期检定业务费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc011: [{ required: true, message: "作业时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc012: [{ required: true, message: "其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc014: [{ required: true, message: "测定器校正业务费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc015: [{ required: true, message: "校正时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc016: [{ required: true, message: "外部委托，搬运费" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc017: [{ required: true, message: "其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc019: [{ required: true, message: "其他通常费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc020: [{ required: true, message: "通常作业时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc021: [{ required: true, message: "通常其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc025: [{ required: true, message: "出货检查费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc026: [{ required: true, message: "检查时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc027: [{ required: true, message: "其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc029: [{ required: true, message: "信赖性评价.ORT业务费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc030: [{ required: true, message: "评价时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc031: [{ required: true, message: "其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc033: [{ required: true, message: "顾客品质要求对应业务费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc034: [{ required: true, message: "评价作业时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc035: [{ required: true, message: "评价其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc037: [{ required: true, message: "其他通常业务费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc038: [{ required: true, message: "通常业务作业时间" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mc039: [{ required: true, message: "通常业务其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_plant_list: [],
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
      mc002: [],
      mc003: null,
      mc004: 0,
      mc005: 0,
      mc006: 0,
      mc007: 0,
      mc008: 0,
      mc009: null,
      mc010: 0,
      mc011: 0,
      mc012: 0,
      mc013: null,
      mc014: 0,
      mc015: 0,
      mc016: 0,
      mc017: 0,
      mc018: null,
      mc019: 0,
      mc020: 0,
      mc021: 0,
      mc022: null,
      mc023: null,
      mc024: null,
      mc025: 0,
      mc026: 0,
      mc027: 0,
      mc028: null,
      mc029: 0,
      mc030: 0,
      mc031: 0,
      mc032: null,
      mc033: 0,
      mc034: 0,
      mc035: 0,
      mc036: null,
      mc037: 0,
      mc038: 0,
      mc039: 0,
      mc040: null,
      mc041: null,
      mc042: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '品质业务'
    opertype.value = 1
    form.value.mc002 = []
    form.value.mc003 = new Date()
    form.value.mc004 = 0
    form.value.mc005 = 0
    form.value.mc006 = 0
    form.value.mc007 = 0
    form.value.mc008 = 0
    form.value.mc010 = 0
    form.value.mc011 = 0
    form.value.mc012 = 0
    form.value.mc014 = 0
    form.value.mc015 = 0
    form.value.mc016 = 0
    form.value.mc017 = 0
    form.value.mc019 = 0
    form.value.mc020 = 0
    form.value.mc021 = 0
    form.value.mc024 = useUserStore().name
    form.value.mc025 = 0
    form.value.mc026 = 0
    form.value.mc027 = 0
    form.value.mc029 = 0
    form.value.mc030 = 0
    form.value.mc031 = 0
    form.value.mc033 = 0
    form.value.mc034 = 0
    form.value.mc035 = 0
    form.value.mc037 = 0
    form.value.mc038 = 0
    form.value.mc039 = 0
    form.value.mc042 = useUserStore().name
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getQmCostOperation(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '品质业务'
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

        if (form.value.id != undefined && opertype.value === 2) {
          updateQmCostOperation(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addQmCostOperation(form.value).then((res) => {
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
        return delQmCostOperation(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<品质业务.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/QmCostOperation/export', { ...queryParams })
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