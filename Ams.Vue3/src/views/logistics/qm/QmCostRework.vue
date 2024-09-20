<!--
 * @Descripttion: 返工改修/qm_cost_rework
 * @Version: 0.24.627.15377
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/18 9:05:09
 * @column：95
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="md002">
        <el-select filterable clearable   v-model="queryParams.md002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeMd003" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="机种" prop="md004">
        <el-input v-model="queryParams.md004" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="批次" prop="md005">
        <el-input v-model="queryParams.md005" :placeholder="$t('btn.enterSearchPrefix')+'批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="顾客名" prop="md031">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_cus_list" :loading="loading" v-model="queryParams.md031" :placeholder="$t('btn.selectSearchPrefix')+'顾客名'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['qm:costrework:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:costrework:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:costrework:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:costrework:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmCostRework/importTemplate"
                  importUrl="/Logistics/QmCostRework/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:costrework:export']">
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="md002" label="工厂" align="center" v-if="columns.showColumn('md002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.md002"  />
        </template>
      </el-table-column>
      <el-table-column prop="md003" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md003')"/>
      <el-table-column prop="md004" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md004')"/>
      <el-table-column prop="md005" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md005')"/>
      <el-table-column prop="md006" label="直接人员赁率" align="center" v-if="columns.showColumn('md006')"/>
      <el-table-column prop="md007" label="间接人员赁率" align="center" v-if="columns.showColumn('md007')"/>
      <el-table-column prop="md008" label="检讨.调查.试验内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md008')"/>
      <el-table-column prop="md009" label="检讨.调查.试验费用" align="center" v-if="columns.showColumn('md009')"/>
      <el-table-column prop="md010" label="检讨会使用时间(分)" align="center" v-if="columns.showColumn('md010')"/>
      <el-table-column prop="md011" label="直接人员参加人数" align="center" v-if="columns.showColumn('md011')"/>
      <el-table-column prop="md012" label="间接人员参加人数" align="center" v-if="columns.showColumn('md012')"/>
      <el-table-column prop="md013" label="调查评价试验工作时间(分)" align="center" v-if="columns.showColumn('md013')"/>
      <el-table-column prop="md014" label="交通费、旅费" align="center" v-if="columns.showColumn('md014')"/>
      <el-table-column prop="md015" label="其他费用" align="center" v-if="columns.showColumn('md015')"/>
      <el-table-column prop="md016" label="其他作业時間(分)" align="center" v-if="columns.showColumn('md016')"/>
      <el-table-column prop="md017" label="其他设备购入费,工程费,搬运费" align="center" v-if="columns.showColumn('md017')"/>
      <el-table-column prop="md018" label="需要不良改修对应" align="center" v-if="columns.showColumn('md018')"/>
      <el-table-column prop="md019" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md019')"/>
      <el-table-column prop="md020" label="品质问题対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md020')"/>
      <el-table-column prop="md021" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md021')"/>
      <el-table-column prop="md022" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md022')"/>
      <el-table-column prop="md023" label="选别.改修费用" align="center" v-if="columns.showColumn('md023')"/>
      <el-table-column prop="md024" label="选别.改修时间(分)" align="center" v-if="columns.showColumn('md024')"/>
      <el-table-column prop="md025" label="再检查时间(分)" align="center" v-if="columns.showColumn('md025')"/>
      <el-table-column prop="md026" label="交通费、旅费" align="center" v-if="columns.showColumn('md026')"/>
      <el-table-column prop="md027" label="仓库管理费" align="center" v-if="columns.showColumn('md027')"/>
      <el-table-column prop="md028" label="选别.改修其他费用" align="center" v-if="columns.showColumn('md028')"/>
      <el-table-column prop="md029" label="选别.改修备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md029')"/>
      <el-table-column prop="md030" label="向顾客的费用请求" align="center" v-if="columns.showColumn('md030')"/>
      <el-table-column prop="md031" label="顾客名" align="center" v-if="columns.showColumn('md031')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.md031"  />
        </template>
      </el-table-column>
      <el-table-column prop="md032" label="请求号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md032')"/>
      <el-table-column prop="md033" label="请求费用" align="center" v-if="columns.showColumn('md033')"/>
      <el-table-column prop="md034" label="其他费用" align="center" v-if="columns.showColumn('md034')"/>
      <el-table-column prop="md035" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md035')"/>
      <el-table-column prop="md036" label="附件1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md036')"/>
      <el-table-column prop="md037" label="生管品质问题対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md037')"/>
      <el-table-column prop="md038" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md038')"/>
      <el-table-column prop="md039" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md039')"/>
      <el-table-column prop="md040" label="选别.改修费用" align="center" v-if="columns.showColumn('md040')"/>
      <el-table-column prop="md041" label="选别.改修时间(分)" align="center" v-if="columns.showColumn('md041')"/>
      <el-table-column prop="md042" label="再检查时间(分)" align="center" v-if="columns.showColumn('md042')"/>
      <el-table-column prop="md043" label="交通费、旅费" align="center" v-if="columns.showColumn('md043')"/>
      <el-table-column prop="md044" label="仓库管理费" align="center" v-if="columns.showColumn('md044')"/>
      <el-table-column prop="md045" label="选别.改修其他费用" align="center" v-if="columns.showColumn('md045')"/>
      <el-table-column prop="md046" label="选别.改修备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md046')"/>
      <el-table-column prop="md047" label="向顾客的费用请求" align="center" v-if="columns.showColumn('md047')"/>
      <el-table-column prop="md048" label="顾客名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md048')"/>
      <el-table-column prop="md049" label="请求号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md049')"/>
      <el-table-column prop="md050" label="请求费用" align="center" v-if="columns.showColumn('md050')"/>
      <el-table-column prop="md051" label="其他费用" align="center" v-if="columns.showColumn('md051')"/>
      <el-table-column prop="md052" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md052')"/>
      <el-table-column prop="md053" label="附件2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md053')"/>
      <el-table-column prop="md054" label="M/L不良改修対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md054')"/>
      <el-table-column prop="md055" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md055')"/>
      <el-table-column prop="md056" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md056')"/>
      <el-table-column prop="md057" label="选别.改修费用" align="center" v-if="columns.showColumn('md057')"/>
      <el-table-column prop="md058" label="选别.改修时间(分)" align="center" v-if="columns.showColumn('md058')"/>
      <el-table-column prop="md059" label="再检查时间(分)" align="center" v-if="columns.showColumn('md059')"/>
      <el-table-column prop="md060" label="交通费、旅费" align="center" v-if="columns.showColumn('md060')"/>
      <el-table-column prop="md061" label="仓库管理费" align="center" v-if="columns.showColumn('md061')"/>
      <el-table-column prop="md062" label="选别.改修其他费用" align="center" v-if="columns.showColumn('md062')"/>
      <el-table-column prop="md063" label="选别.改修备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md063')"/>
      <el-table-column prop="md064" label="向顾客的费用请求" align="center" v-if="columns.showColumn('md064')"/>
      <el-table-column prop="md065" label="顾客名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md065')"/>
      <el-table-column prop="md066" label="请求号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md066')"/>
      <el-table-column prop="md067" label="请求费用" align="center" v-if="columns.showColumn('md067')"/>
      <el-table-column prop="md068" label="其他费用" align="center" v-if="columns.showColumn('md068')"/>
      <el-table-column prop="md069" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md069')"/>
      <el-table-column prop="md070" label="附件3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md070')"/>
      <el-table-column prop="md071" label="担当" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md071')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:costrework:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:costrework:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改返工改修对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂" prop="md002">
              <el-select filterable clearable   v-model="form.md002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="日期" prop="md003">
              <el-date-picker v-model="form.md003" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="md004">
              <el-input   v-model="form.md004" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="md005">
              <el-input   v-model="form.md005" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="直接人员赁率" prop="md006">
              <el-input-number v-model.number="form.md006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'直接人员赁率'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接人员赁率" prop="md007">
              <el-input-number v-model.number="form.md007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人员赁率'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检讨.调查.试验内容" prop="md008">
              <el-input  type="textarea"  v-model="form.md008" :placeholder="$t('btn.enterPrefix')+'检讨.调查.试验内容'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检讨.调查.试验费用" prop="md009">
              <el-input-number v-model.number="form.md009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检讨.调查.试验费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检讨会使用时间(分)" prop="md010">
              <el-input-number v-model.number="form.md010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检讨会使用时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="直接人员参加人数" prop="md011">
              <el-input-number v-model.number="form.md011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'直接人员参加人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="间接人员参加人数" prop="md012">
              <el-input-number v-model.number="form.md012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人员参加人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="调查评价试验工作时间(分)" prop="md013">
              <el-input-number v-model.number="form.md013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'调查评价试验工作时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="md014">
              <el-input-number v-model.number="form.md014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="md015">
              <el-input-number v-model.number="form.md015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="其他作业時間(分)" prop="md016">
              <el-input-number v-model.number="form.md016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他作业時間(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他设备购入费,工程费,搬运费" prop="md017">
              <el-input-number v-model.number="form.md017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他设备购入费,工程费,搬运费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="需要不良改修对应" prop="md018">
              <el-input-number v-model.number="form.md018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'需要不良改修对应'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特记" prop="md019">
              <el-input  type="textarea"  v-model="form.md019" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="品质问题対応记录者" prop="md020">
              <el-input   v-model="form.md020" :placeholder="$t('btn.enterPrefix')+'品质问题対応记录者'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="md021">
              <el-date-picker v-model="form.md021" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良内容" prop="md022">
              <el-input  type="textarea"  v-model="form.md022" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修费用" prop="md023">
              <el-input-number v-model.number="form.md023" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="选别.改修时间(分)" prop="md024">
              <el-input-number v-model.number="form.md024" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="再检查时间(分)" prop="md025">
              <el-input-number v-model.number="form.md025" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'再检查时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="md026">
              <el-input-number v-model.number="form.md026" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库管理费" prop="md027">
              <el-input-number v-model.number="form.md027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'仓库管理费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修其他费用" prop="md028">
              <el-input-number v-model.number="form.md028" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修备注" prop="md029">
              <el-input  type="textarea"  v-model="form.md029" :placeholder="$t('btn.enterPrefix')+'选别.改修备注'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="向顾客的费用请求" prop="md030">
              <el-input-number v-model.number="form.md030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'向顾客的费用请求'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顾客名" prop="md031">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_cus_list" 
              :loading="loading" v-model="form.md031"  :placeholder="$t('btn.selectPrefix')+'顾客名'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="请求号码" prop="md032">
              <el-input   v-model="form.md032" :placeholder="$t('btn.enterPrefix')+'请求号码'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求费用" prop="md033">
              <el-input-number v-model.number="form.md033" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'请求费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="md034">
              <el-input-number v-model.number="form.md034" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="md035">
              <el-input  type="textarea"  v-model="form.md035" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="附件1" prop="md036">
              <UploadFile v-model="form.md036" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管品质问题対応记录者" prop="md037">
              <el-input   v-model="form.md037" :placeholder="$t('btn.enterPrefix')+'生管品质问题対応记录者'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="md038">
              <el-date-picker v-model="form.md038" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良内容" prop="md039">
              <el-input  type="textarea"  v-model="form.md039" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修费用" prop="md040">
              <el-input-number v-model.number="form.md040" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="选别.改修时间(分)" prop="md041">
              <el-input-number v-model.number="form.md041" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="再检查时间(分)" prop="md042">
              <el-input-number v-model.number="form.md042" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'再检查时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="md043">
              <el-input-number v-model.number="form.md043" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库管理费" prop="md044">
              <el-input-number v-model.number="form.md044" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'仓库管理费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修其他费用" prop="md045">
              <el-input-number v-model.number="form.md045" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修备注" prop="md046">
              <el-input  type="textarea"  v-model="form.md046" :placeholder="$t('btn.enterPrefix')+'选别.改修备注'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="向顾客的费用请求" prop="md047">
              <el-input-number v-model.number="form.md047" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'向顾客的费用请求'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顾客名" prop="md048">
              <el-input   v-model="form.md048" :placeholder="$t('btn.enterPrefix')+'顾客名'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求号码" prop="md049">
              <el-input   v-model="form.md049" :placeholder="$t('btn.enterPrefix')+'请求号码'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求费用" prop="md050">
              <el-input-number v-model.number="form.md050" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'请求费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="md051">
              <el-input-number v-model.number="form.md051" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="md052">
              <el-input  type="textarea"  v-model="form.md052" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="附件2" prop="md053">
              <UploadFile v-model="form.md053" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="M/L不良改修対応记录者" prop="md054">
              <el-input   v-model="form.md054" :placeholder="$t('btn.enterPrefix')+'M/L不良改修対応记录者'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="md055">
              <el-date-picker v-model="form.md055" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良内容" prop="md056">
              <el-input  type="textarea"  v-model="form.md056" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修费用" prop="md057">
              <el-input-number v-model.number="form.md057" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="选别.改修时间(分)" prop="md058">
              <el-input-number v-model.number="form.md058" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="再检查时间(分)" prop="md059">
              <el-input-number v-model.number="form.md059" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'再检查时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="md060">
              <el-input-number v-model.number="form.md060" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库管理费" prop="md061">
              <el-input-number v-model.number="form.md061" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'仓库管理费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修其他费用" prop="md062">
              <el-input-number v-model.number="form.md062" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别.改修其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别.改修备注" prop="md063">
              <el-input  type="textarea"  v-model="form.md063" :placeholder="$t('btn.enterPrefix')+'选别.改修备注'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="向顾客的费用请求" prop="md064">
              <el-input-number v-model.number="form.md064" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'向顾客的费用请求'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顾客名" prop="md065">
              <el-input   v-model="form.md065" :placeholder="$t('btn.enterPrefix')+'顾客名'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求号码" prop="md066">
              <el-input   v-model="form.md066" :placeholder="$t('btn.enterPrefix')+'请求号码'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求费用" prop="md067">
              <el-input-number v-model.number="form.md067" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'请求费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="md068">
              <el-input-number v-model.number="form.md068" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="md069">
              <el-input  type="textarea"  v-model="form.md069" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="附件3" prop="md070">
              <UploadFile v-model="form.md070" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="md071">
              <el-input   v-model="form.md071" :placeholder="$t('btn.enterPrefix')+'担当'+$t('btn.enterSuffix')"  show-word-limit  maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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

<script setup name="qmcostrework">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmCostRework,
 addQmCostRework, delQmCostRework, 
 updateQmCostRework,getQmCostRework, 
 } 
from '@/api/logistics/qmcostrework.js'
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
  sort: 'Md003',
  sortType: 'desc',
  //是否查询（1是）
  md002: undefined,
  //是否查询（1是）
  md003: undefined,
  //是否查询（1是）
  md004: undefined,
  //是否查询（1是）
  md005: undefined,
  //是否查询（1是）
  md031: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'md002', label: '工厂' },
  { visible: true, prop: 'md003', label: '日期' },
  { visible: true, prop: 'md004', label: '机种' },
  { visible: true, prop: 'md005', label: '批次' },
  { visible: true, prop: 'md006', label: '直接人员赁率' },
  { visible: true, prop: 'md007', label: '间接人员赁率' },
  { visible: true, prop: 'md008', label: '检讨.调查.试验内容' },
  { visible: false, prop: 'md009', label: '检讨.调查.试验费用' },
  { visible: false, prop: 'md010', label: '检讨会使用时间(分)' },
  { visible: false, prop: 'md011', label: '直接人员参加人数' },
  { visible: false, prop: 'md012', label: '间接人员参加人数' },
  { visible: false, prop: 'md013', label: '调查评价试验工作时间(分)' },
  { visible: false, prop: 'md014', label: '交通费、旅费' },
  { visible: false, prop: 'md015', label: '其他费用' },
  { visible: false, prop: 'md016', label: '其他作业時間(分)' },
  { visible: false, prop: 'md017', label: '其他设备购入费,工程费,搬运费' },
  { visible: false, prop: 'md018', label: '需要不良改修对应' },
  { visible: false, prop: 'md019', label: '特记' },
  { visible: false, prop: 'md020', label: '品质问题対応记录者' },
  { visible: false, prop: 'md021', label: '日期' },
  { visible: false, prop: 'md022', label: '不良内容' },
  { visible: false, prop: 'md023', label: '选别.改修费用' },
  { visible: false, prop: 'md024', label: '选别.改修时间(分)' },
  { visible: false, prop: 'md025', label: '再检查时间(分)' },
  { visible: false, prop: 'md026', label: '交通费、旅费' },
  { visible: false, prop: 'md027', label: '仓库管理费' },
  { visible: false, prop: 'md028', label: '选别.改修其他费用' },
  { visible: false, prop: 'md029', label: '选别.改修备注' },
  { visible: false, prop: 'md030', label: '向顾客的费用请求' },
  { visible: false, prop: 'md031', label: '顾客名' },
  { visible: false, prop: 'md032', label: '请求号码' },
  { visible: false, prop: 'md033', label: '请求费用' },
  { visible: false, prop: 'md034', label: '其他费用' },
  { visible: false, prop: 'md035', label: '备注' },
  { visible: false, prop: 'md036', label: '附件1' },
  { visible: false, prop: 'md037', label: '生管品质问题対応记录者' },
  { visible: false, prop: 'md038', label: '日期' },
  { visible: false, prop: 'md039', label: '不良内容' },
  { visible: false, prop: 'md040', label: '选别.改修费用' },
  { visible: false, prop: 'md041', label: '选别.改修时间(分)' },
  { visible: false, prop: 'md042', label: '再检查时间(分)' },
  { visible: false, prop: 'md043', label: '交通费、旅费' },
  { visible: false, prop: 'md044', label: '仓库管理费' },
  { visible: false, prop: 'md045', label: '选别.改修其他费用' },
  { visible: false, prop: 'md046', label: '选别.改修备注' },
  { visible: false, prop: 'md047', label: '向顾客的费用请求' },
  { visible: false, prop: 'md048', label: '顾客名' },
  { visible: false, prop: 'md049', label: '请求号码' },
  { visible: false, prop: 'md050', label: '请求费用' },
  { visible: false, prop: 'md051', label: '其他费用' },
  { visible: false, prop: 'md052', label: '备注' },
  { visible: false, prop: 'md053', label: '附件2' },
  { visible: false, prop: 'md054', label: 'M/L不良改修対応记录者' },
  { visible: false, prop: 'md055', label: '日期' },
  { visible: false, prop: 'md056', label: '不良内容' },
  { visible: false, prop: 'md057', label: '选别.改修费用' },
  { visible: false, prop: 'md058', label: '选别.改修时间(分)' },
  { visible: false, prop: 'md059', label: '再检查时间(分)' },
  { visible: false, prop: 'md060', label: '交通费、旅费' },
  { visible: false, prop: 'md061', label: '仓库管理费' },
  { visible: false, prop: 'md062', label: '选别.改修其他费用' },
  { visible: false, prop: 'md063', label: '选别.改修备注' },
  { visible: false, prop: 'md064', label: '向顾客的费用请求' },
  { visible: false, prop: 'md065', label: '顾客名' },
  { visible: false, prop: 'md066', label: '请求号码' },
  { visible: false, prop: 'md067', label: '请求费用' },
  { visible: false, prop: 'md068', label: '其他费用' },
  { visible: false, prop: 'md069', label: '备注' },
  { visible: false, prop: 'md070', label: '附件3' },
  { visible: false, prop: 'md071', label: '担当' },
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
// 日期时间范围
const dateRangeMd003 = ref([])
//定义远程搜索变量
const remotequeryList_sql_cus_list=ref([])
//定义远程搜索变量
const remotequery_sql_cus_list=ref([])
//远程字典参数
var remotedictParams_sql_cus_list = [
    { dictType: "sql_cus_list" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_cus_list).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_cus_list.value = element.list
      })
      //console.log(remotequeryList_sql_cus_list)
    })
  })
//远程搜索
const remoteMethod_sql_cus_list = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_cus_list.value = remotequeryList_sql_cus_list.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_cus_list(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_cus_list.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_cus_list = debounce((query) => {
    let arr = remotequeryList_sql_cus_list.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_cus_list.value = arr.slice(0, 5)
      addFilterOptions_sql_cus_list(query)
    } else {
      remotequery_sql_cus_list.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_cus_list =debounce((dictValue) => {
    let target = remotequeryList_sql_cus_list.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_cus_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_cus_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sql_cus_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从返工改修/qm_cost_rework表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMd003.value, 'Md003');
  loading.value = true
  listQmCostRework(queryParams).then(res => {
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
  dateRangeMd003.value = []
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
    md002: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    md003: [{ required: true, message: "日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md006: [{ required: true, message: "直接人员赁率"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md007: [{ required: true, message: "间接人员赁率"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md009: [{ required: true, message: "检讨.调查.试验费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md010: [{ required: true, message: "检讨会使用时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md011: [{ required: true, message: "直接人员参加人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md012: [{ required: true, message: "间接人员参加人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md013: [{ required: true, message: "调查评价试验工作时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md014: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md015: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md016: [{ required: true, message: "其他作业時間(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md017: [{ required: true, message: "其他设备购入费,工程费,搬运费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md018: [{ required: true, message: "需要不良改修对应"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md023: [{ required: true, message: "选别.改修费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md024: [{ required: true, message: "选别.改修时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md025: [{ required: true, message: "再检查时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md026: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md027: [{ required: true, message: "仓库管理费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md028: [{ required: true, message: "选别.改修其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md030: [{ required: true, message: "向顾客的费用请求"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md033: [{ required: true, message: "请求费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md034: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md040: [{ required: true, message: "选别.改修费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md041: [{ required: true, message: "选别.改修时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md042: [{ required: true, message: "再检查时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md043: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md044: [{ required: true, message: "仓库管理费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md045: [{ required: true, message: "选别.改修其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md047: [{ required: true, message: "向顾客的费用请求"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md050: [{ required: true, message: "请求费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md051: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md057: [{ required: true, message: "选别.改修费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md058: [{ required: true, message: "选别.改修时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md059: [{ required: true, message: "再检查时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md060: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md061: [{ required: true, message: "仓库管理费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md062: [{ required: true, message: "选别.改修其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md064: [{ required: true, message: "向顾客的费用请求"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md067: [{ required: true, message: "请求费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md068: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 顾客名 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_cus_list: [],
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
    md002: [],
    md003: null,
    md004: null,
    md005: null,
    md006: 0,
    md007: 0,
    md008: null,
    md009: 0,
    md010: 0,
    md011: 0,
    md012: 0,
    md013: 0,
    md014: 0,
    md015: 0,
    md016: 0,
    md017: 0,
    md018: 0,
    md019: null,
    md020: null,
    md021: null,
    md022: null,
    md023: 0,
    md024: 0,
    md025: 0,
    md026: 0,
    md027: 0,
    md028: 0,
    md029: null,
    md030: 0,
    md031: [],
    md032: null,
    md033: 0,
    md034: 0,
    md035: null,
    md036: null,
    md037: null,
    md038: null,
    md039: null,
    md040: 0,
    md041: 0,
    md042: 0,
    md043: 0,
    md044: 0,
    md045: 0,
    md046: null,
    md047: 0,
    md048: null,
    md049: null,
    md050: 0,
    md051: 0,
    md052: null,
    md053: null,
    md054: null,
    md055: null,
    md056: null,
    md057: 0,
    md058: 0,
    md059: 0,
    md060: 0,
    md061: 0,
    md062: 0,
    md063: null,
    md064: 0,
    md065: null,
    md066: null,
    md067: 0,
    md068: 0,
    md069: null,
    md070: null,
    md071: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'返工改修'
  opertype.value = 1
  form.value.md002= []
  form.value.md003= new Date()
  form.value.md006= 0
  form.value.md007= 0
  form.value.md009= 0
  form.value.md010= 0
  form.value.md011= 0
  form.value.md012= 0
  form.value.md013= 0
  form.value.md014= 0
  form.value.md015= 0
  form.value.md016= 0
  form.value.md017= 0
  form.value.md018= 0
  form.value.md021= new Date()
  form.value.md023= 0
  form.value.md024= 0
  form.value.md025= 0
  form.value.md026= 0
  form.value.md027= 0
  form.value.md028= 0
  form.value.md030= 0
  form.value.md031= []
  form.value.md033= 0
  form.value.md034= 0
  form.value.md038= new Date()
  form.value.md040= 0
  form.value.md041= 0
  form.value.md042= 0
  form.value.md043= 0
  form.value.md044= 0
  form.value.md045= 0
  form.value.md047= 0
  form.value.md050= 0
  form.value.md051= 0
  form.value.md055= new Date()
  form.value.md057= 0
  form.value.md058= 0
  form.value.md059= 0
  form.value.md060= 0
  form.value.md061= 0
  form.value.md062= 0
  form.value.md064= 0
  form.value.md067= 0
  form.value.md068= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getQmCostRework(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '返工改修'
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
        updateQmCostRework(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmCostRework(form.value).then((res) => {
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
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delQmCostRework(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<返工改修.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmCostRework/export', { ...queryParams })
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