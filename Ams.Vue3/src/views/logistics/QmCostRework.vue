<!--
 * @Descripttion: 返工改修/qm_cost_rework
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/19 15:11:26
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
          v-model="dateRangeQcrd001" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="机种" prop="qcrd002">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_oph_model" :loading="loading " v-model="queryParams.qcrd002" :placeholder="$t('btn.selectSearchPrefix')+'机种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_oph_model " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="批次" prop="qcrd003">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_oph_lot" :loading="loading " v-model="queryParams.qcrd003" :placeholder="$t('btn.selectSearchPrefix')+'批次'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_oph_lot " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeQcrd018" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="顾客名" prop="qcrd028">
        <el-select filterable clearable   v-model="queryParams.qcrd028" :placeholder="$t('btn.selectSearchPrefix')+'顾客名'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeQcrd033" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeQcrd048" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
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
      <el-table-column prop="qcrdSFID" label="SFID" align="center" v-if="columns.showColumn('qcrdSFID')"/>
      <el-table-column prop="qcrd001" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qcrd001')"/>
      <el-table-column prop="qcrd002" label="机种" align="center" v-if="columns.showColumn('qcrd002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_oph_model " :value="scope.row.qcrd002"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcrd003" label="批次" align="center" v-if="columns.showColumn('qcrd003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_oph_lot " :value="scope.row.qcrd003"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcrd004" label="直接人员赁率" align="center" v-if="columns.showColumn('qcrd004')"/>
      <el-table-column prop="qcrd005" label="间接人员赁率" align="center" v-if="columns.showColumn('qcrd005')"/>
      <el-table-column prop="qcrd006" label="检讨?调查?试验内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd006')"/>
      <el-table-column prop="qcrd007" label="检讨?调查?试验费用" align="center" v-if="columns.showColumn('qcrd007')"/>
      <el-table-column prop="qcrd008" label="检讨会使用时间(分)" align="center" v-if="columns.showColumn('qcrd008')"/>
      <el-table-column prop="qcrd009" label="直接人员参加人数" align="center" v-if="columns.showColumn('qcrd009')"/>
      <el-table-column prop="qcrd010" label="间接人员参加人数" align="center" v-if="columns.showColumn('qcrd010')"/>
      <el-table-column prop="qcrd011" label="调查评价试验工作时间(分)" align="center" v-if="columns.showColumn('qcrd011')"/>
      <el-table-column prop="qcrd012" label="交通费、旅费" align="center" v-if="columns.showColumn('qcrd012')"/>
      <el-table-column prop="qcrd013" label="其他费用" align="center" v-if="columns.showColumn('qcrd013')"/>
      <el-table-column prop="qcrd014" label="其他作业時間(分)" align="center" v-if="columns.showColumn('qcrd014')"/>
      <el-table-column prop="qcrd015" label="其他设备购入费,工程费,搬运费" align="center" v-if="columns.showColumn('qcrd015')"/>
      <el-table-column prop="qcrd016" label="需要不良改修对应" align="center" v-if="columns.showColumn('qcrd016')"/>
      <el-table-column prop="qcrd017" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd017')"/>
      <el-table-column prop="qcrdqarec" label="品质问题対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrdqarec')"/>
      <el-table-column prop="qcrd018" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qcrd018')"/>
      <el-table-column prop="qcrd019" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd019')"/>
      <el-table-column prop="qcrd020" label="选别?改修费用" align="center" v-if="columns.showColumn('qcrd020')"/>
      <el-table-column prop="qcrd021" label="选别?改修时间(分)" align="center" v-if="columns.showColumn('qcrd021')"/>
      <el-table-column prop="qcrd022" label="再检查时间(分)" align="center" v-if="columns.showColumn('qcrd022')"/>
      <el-table-column prop="qcrd023" label="交通费、旅费" align="center" v-if="columns.showColumn('qcrd023')"/>
      <el-table-column prop="qcrd024" label="仓库管理费" align="center" v-if="columns.showColumn('qcrd024')"/>
      <el-table-column prop="qcrd025" label="选别?改修其他费用" align="center" v-if="columns.showColumn('qcrd025')"/>
      <el-table-column prop="qcrd026" label="选别?改修备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd026')"/>
      <el-table-column prop="qcrd027" label="向顾客的费用请求" align="center" v-if="columns.showColumn('qcrd027')"/>
      <el-table-column prop="qcrd028" label="顾客名" align="center" v-if="columns.showColumn('qcrd028')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.qcrd028"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcrd029" label="Debit Note No" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd029')"/>
      <el-table-column prop="qcrd030" label="请求费用" align="center" v-if="columns.showColumn('qcrd030')"/>
      <el-table-column prop="qcrd031" label="其他费用" align="center" v-if="columns.showColumn('qcrd031')"/>
      <el-table-column prop="qcrd032" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd032')"/>
      <el-table-column prop="qcrdmcrec" label="生管品质问题対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrdmcrec')"/>
      <el-table-column prop="qcrd033" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qcrd033')"/>
      <el-table-column prop="qcrd034" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd034')"/>
      <el-table-column prop="qcrd035" label="选别?改修费用" align="center" v-if="columns.showColumn('qcrd035')"/>
      <el-table-column prop="qcrd036" label="选别?改修时间(分)" align="center" v-if="columns.showColumn('qcrd036')"/>
      <el-table-column prop="qcrd037" label="再检查时间(分)" align="center" v-if="columns.showColumn('qcrd037')"/>
      <el-table-column prop="qcrd038" label="交通费、旅费" align="center" v-if="columns.showColumn('qcrd038')"/>
      <el-table-column prop="qcrd039" label="仓库管理费" align="center" v-if="columns.showColumn('qcrd039')"/>
      <el-table-column prop="qcrd040" label="选别?改修其他费用" align="center" v-if="columns.showColumn('qcrd040')"/>
      <el-table-column prop="qcrd041" label="选别?改修备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd041')"/>
      <el-table-column prop="qcrd042" label="向顾客的费用请求" align="center" v-if="columns.showColumn('qcrd042')"/>
      <el-table-column prop="qcrd043" label="顾客名" align="center" v-if="columns.showColumn('qcrd043')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.qcrd043"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcrd044" label="Debit Note No" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd044')"/>
      <el-table-column prop="qcrd045" label="请求费用" align="center" v-if="columns.showColumn('qcrd045')"/>
      <el-table-column prop="qcrd046" label="其他费用" align="center" v-if="columns.showColumn('qcrd046')"/>
      <el-table-column prop="qcrd047" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd047')"/>
      <el-table-column prop="qcrdassrec" label="M/L不良改修対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrdassrec')"/>
      <el-table-column prop="qcrd048" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qcrd048')"/>
      <el-table-column prop="qcrd049" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd049')"/>
      <el-table-column prop="qcrd050" label="选别?改修费用" align="center" v-if="columns.showColumn('qcrd050')"/>
      <el-table-column prop="qcrd051" label="选别?改修时间(分)" align="center" v-if="columns.showColumn('qcrd051')"/>
      <el-table-column prop="qcrd052" label="再检查时间(分)" align="center" v-if="columns.showColumn('qcrd052')"/>
      <el-table-column prop="qcrd053" label="交通费、旅费" align="center" v-if="columns.showColumn('qcrd053')"/>
      <el-table-column prop="qcrd054" label="仓库管理费" align="center" v-if="columns.showColumn('qcrd054')"/>
      <el-table-column prop="qcrd055" label="选别?改修其他费用" align="center" v-if="columns.showColumn('qcrd055')"/>
      <el-table-column prop="qcrd056" label="选别?改修备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd056')"/>
      <el-table-column prop="qcrd057" label="向顾客的费用请求" align="center" v-if="columns.showColumn('qcrd057')"/>
      <el-table-column prop="qcrd058" label="顾客名" align="center" v-if="columns.showColumn('qcrd058')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.qcrd058"  />
        </template>
      </el-table-column>
      <el-table-column prop="qcrd059" label="Debit Note No" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd059')"/>
      <el-table-column prop="qcrd060" label="请求费用" align="center" v-if="columns.showColumn('qcrd060')"/>
      <el-table-column prop="qcrd061" label="其他费用" align="center" v-if="columns.showColumn('qcrd061')"/>
      <el-table-column prop="qcrd062" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrd062')"/>
      <el-table-column prop="qcrdpcbrec" label="担当" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcrdpcbrec')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
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
            <el-form-item label="SFID" prop="qcrdSFID">
              <el-input v-model.number="form.qcrdSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="qcrd001">
              <el-date-picker v-model="form.qcrd001" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="qcrd002">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_oph_model" 
              :loading="loading " v-model="form.qcrd002"  :placeholder="$t('btn.selectPrefix')+'机种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_oph_model" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="批次" prop="qcrd003">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_oph_lot" 
              :loading="loading " v-model="form.qcrd003"  :placeholder="$t('btn.selectPrefix')+'批次'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_oph_lot" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="直接人员赁率" prop="qcrd004">
              <el-input-number v-model.number="form.qcrd004" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'直接人员赁率'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接人员赁率" prop="qcrd005">
              <el-input-number v-model.number="form.qcrd005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人员赁率'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检讨?调查?试验内容" prop="qcrd006">
              <el-input v-model="form.qcrd006" :placeholder="$t('btn.enterPrefix')+'检讨?调查?试验内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检讨?调查?试验费用" prop="qcrd007">
              <el-input-number v-model.number="form.qcrd007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检讨?调查?试验费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检讨会使用时间(分)" prop="qcrd008">
              <el-input-number v-model.number="form.qcrd008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检讨会使用时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="直接人员参加人数" prop="qcrd009">
              <el-input-number v-model.number="form.qcrd009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'直接人员参加人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="间接人员参加人数" prop="qcrd010">
              <el-input-number v-model.number="form.qcrd010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人员参加人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="调查评价试验工作时间(分)" prop="qcrd011">
              <el-input-number v-model.number="form.qcrd011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'调查评价试验工作时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="qcrd012">
              <el-input-number v-model.number="form.qcrd012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcrd013">
              <el-input-number v-model.number="form.qcrd013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="其他作业時間(分)" prop="qcrd014">
              <el-input-number v-model.number="form.qcrd014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他作业時間(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他设备购入费,工程费,搬运费" prop="qcrd015">
              <el-input-number v-model.number="form.qcrd015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他设备购入费,工程费,搬运费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="需要不良改修对应" prop="qcrd016">
              <el-input-number v-model.number="form.qcrd016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'需要不良改修对应'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特记" prop="qcrd017">
              <el-input v-model="form.qcrd017" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="品质问题対応记录者" prop="qcrdqarec">
              <el-input v-model="form.qcrdqarec" :placeholder="$t('btn.enterPrefix')+'品质问题対応记录者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="qcrd018">
              <el-date-picker v-model="form.qcrd018" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良内容" prop="qcrd019">
              <el-input v-model="form.qcrd019" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修费用" prop="qcrd020">
              <el-input-number v-model.number="form.qcrd020" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="选别?改修时间(分)" prop="qcrd021">
              <el-input-number v-model.number="form.qcrd021" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="再检查时间(分)" prop="qcrd022">
              <el-input-number v-model.number="form.qcrd022" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'再检查时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="qcrd023">
              <el-input-number v-model.number="form.qcrd023" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库管理费" prop="qcrd024">
              <el-input-number v-model.number="form.qcrd024" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'仓库管理费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修其他费用" prop="qcrd025">
              <el-input-number v-model.number="form.qcrd025" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修备注" prop="qcrd026">
              <el-input v-model="form.qcrd026" :placeholder="$t('btn.enterPrefix')+'选别?改修备注'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="向顾客的费用请求" prop="qcrd027">
              <el-input-number v-model.number="form.qcrd027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'向顾客的费用请求'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顾客名" prop="qcrd028">
              <el-select filterable clearable   v-model="form.qcrd028"  :placeholder="$t('btn.selectPrefix')+'顾客名'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="Debit Note No" prop="qcrd029">
              <el-input v-model="form.qcrd029" :placeholder="$t('btn.enterPrefix')+'Debit Note No'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求费用" prop="qcrd030">
              <el-input-number v-model.number="form.qcrd030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'请求费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcrd031">
              <el-input-number v-model.number="form.qcrd031" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="qcrd032">
              <el-input v-model="form.qcrd032" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生管品质问题対応记录者" prop="qcrdmcrec">
              <el-input v-model="form.qcrdmcrec" :placeholder="$t('btn.enterPrefix')+'生管品质问题対応记录者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="qcrd033">
              <el-date-picker v-model="form.qcrd033" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良内容" prop="qcrd034">
              <el-input v-model="form.qcrd034" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修费用" prop="qcrd035">
              <el-input-number v-model.number="form.qcrd035" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="选别?改修时间(分)" prop="qcrd036">
              <el-input-number v-model.number="form.qcrd036" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="再检查时间(分)" prop="qcrd037">
              <el-input-number v-model.number="form.qcrd037" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'再检查时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="qcrd038">
              <el-input-number v-model.number="form.qcrd038" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库管理费" prop="qcrd039">
              <el-input-number v-model.number="form.qcrd039" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'仓库管理费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修其他费用" prop="qcrd040">
              <el-input-number v-model.number="form.qcrd040" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修备注" prop="qcrd041">
              <el-input v-model="form.qcrd041" :placeholder="$t('btn.enterPrefix')+'选别?改修备注'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="向顾客的费用请求" prop="qcrd042">
              <el-input-number v-model.number="form.qcrd042" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'向顾客的费用请求'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顾客名" prop="qcrd043">
              <el-select filterable clearable   v-model="form.qcrd043"  :placeholder="$t('btn.selectPrefix')+'顾客名'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="Debit Note No" prop="qcrd044">
              <el-input v-model="form.qcrd044" :placeholder="$t('btn.enterPrefix')+'Debit Note No'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求费用" prop="qcrd045">
              <el-input-number v-model.number="form.qcrd045" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'请求费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcrd046">
              <el-input-number v-model.number="form.qcrd046" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="qcrd047">
              <el-input v-model="form.qcrd047" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="M/L不良改修対応记录者" prop="qcrdassrec">
              <el-input v-model="form.qcrdassrec" :placeholder="$t('btn.enterPrefix')+'M/L不良改修対応记录者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="qcrd048">
              <el-date-picker v-model="form.qcrd048" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良内容" prop="qcrd049">
              <el-input v-model="form.qcrd049" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修费用" prop="qcrd050">
              <el-input-number v-model.number="form.qcrd050" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="选别?改修时间(分)" prop="qcrd051">
              <el-input-number v-model.number="form.qcrd051" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="再检查时间(分)" prop="qcrd052">
              <el-input-number v-model.number="form.qcrd052" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'再检查时间(分)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交通费、旅费" prop="qcrd053">
              <el-input-number v-model.number="form.qcrd053" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'交通费、旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库管理费" prop="qcrd054">
              <el-input-number v-model.number="form.qcrd054" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'仓库管理费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修其他费用" prop="qcrd055">
              <el-input-number v-model.number="form.qcrd055" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'选别?改修其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选别?改修备注" prop="qcrd056">
              <el-input v-model="form.qcrd056" :placeholder="$t('btn.enterPrefix')+'选别?改修备注'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="向顾客的费用请求" prop="qcrd057">
              <el-input-number v-model.number="form.qcrd057" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'向顾客的费用请求'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顾客名" prop="qcrd058">
              <el-select filterable clearable   v-model="form.qcrd058"  :placeholder="$t('btn.selectPrefix')+'顾客名'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="Debit Note No" prop="qcrd059">
              <el-input v-model="form.qcrd059" :placeholder="$t('btn.enterPrefix')+'Debit Note No'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求费用" prop="qcrd060">
              <el-input-number v-model.number="form.qcrd060" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'请求费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcrd061">
              <el-input-number v-model.number="form.qcrd061" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备注" prop="qcrd062">
              <el-input v-model="form.qcrd062" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="qcrdpcbrec">
              <el-input v-model="form.qcrdpcbrec" :placeholder="$t('btn.enterPrefix')+'担当'+$t('btn.enterSuffix')" />
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
  sort: '',
  sortType: 'asc',
//是否查询（1是）
  qcrd001: undefined,
//是否查询（1是）
  qcrd002: undefined,
//是否查询（1是）
  qcrd003: undefined,
//是否查询（1是）
  qcrd018: undefined,
//是否查询（1是）
  qcrd028: undefined,
//是否查询（1是）
  qcrd033: undefined,
//是否查询（1是）
  qcrd048: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qcrdSFID', label: 'SFID' },
  { visible: true, prop: 'qcrd001', label: '日期' },
  { visible: true, prop: 'qcrd002', label: '机种' },
  { visible: true, prop: 'qcrd003', label: '批次' },
  { visible: true, prop: 'qcrd004', label: '直接人员赁率' },
  { visible: true, prop: 'qcrd005', label: '间接人员赁率' },
  { visible: true, prop: 'qcrd006', label: '检讨?调查?试验内容' },
  { visible: true, prop: 'qcrd007', label: '检讨?调查?试验费用' },
  { visible: false, prop: 'qcrd008', label: '检讨会使用时间(分)' },
  { visible: false, prop: 'qcrd009', label: '直接人员参加人数' },
  { visible: false, prop: 'qcrd010', label: '间接人员参加人数' },
  { visible: false, prop: 'qcrd011', label: '调查评价试验工作时间(分)' },
  { visible: false, prop: 'qcrd012', label: '交通费、旅费' },
  { visible: false, prop: 'qcrd013', label: '其他费用' },
  { visible: false, prop: 'qcrd014', label: '其他作业時間(分)' },
  { visible: false, prop: 'qcrd015', label: '其他设备购入费,工程费,搬运费' },
  { visible: false, prop: 'qcrd016', label: '需要不良改修对应' },
  { visible: false, prop: 'qcrd017', label: '特记' },
  { visible: false, prop: 'qcrdqarec', label: '品质问题対応记录者' },
  { visible: false, prop: 'qcrd018', label: '日期' },
  { visible: false, prop: 'qcrd019', label: '不良内容' },
  { visible: false, prop: 'qcrd020', label: '选别?改修费用' },
  { visible: false, prop: 'qcrd021', label: '选别?改修时间(分)' },
  { visible: false, prop: 'qcrd022', label: '再检查时间(分)' },
  { visible: false, prop: 'qcrd023', label: '交通费、旅费' },
  { visible: false, prop: 'qcrd024', label: '仓库管理费' },
  { visible: false, prop: 'qcrd025', label: '选别?改修其他费用' },
  { visible: false, prop: 'qcrd026', label: '选别?改修备注' },
  { visible: false, prop: 'qcrd027', label: '向顾客的费用请求' },
  { visible: false, prop: 'qcrd028', label: '顾客名' },
  { visible: false, prop: 'qcrd029', label: 'Debit Note No' },
  { visible: false, prop: 'qcrd030', label: '请求费用' },
  { visible: false, prop: 'qcrd031', label: '其他费用' },
  { visible: false, prop: 'qcrd032', label: '备注' },
  { visible: false, prop: 'qcrdmcrec', label: '生管品质问题対応记录者' },
  { visible: false, prop: 'qcrd033', label: '日期' },
  { visible: false, prop: 'qcrd034', label: '不良内容' },
  { visible: false, prop: 'qcrd035', label: '选别?改修费用' },
  { visible: false, prop: 'qcrd036', label: '选别?改修时间(分)' },
  { visible: false, prop: 'qcrd037', label: '再检查时间(分)' },
  { visible: false, prop: 'qcrd038', label: '交通费、旅费' },
  { visible: false, prop: 'qcrd039', label: '仓库管理费' },
  { visible: false, prop: 'qcrd040', label: '选别?改修其他费用' },
  { visible: false, prop: 'qcrd041', label: '选别?改修备注' },
  { visible: false, prop: 'qcrd042', label: '向顾客的费用请求' },
  { visible: false, prop: 'qcrd043', label: '顾客名' },
  { visible: false, prop: 'qcrd044', label: 'Debit Note No' },
  { visible: false, prop: 'qcrd045', label: '请求费用' },
  { visible: false, prop: 'qcrd046', label: '其他费用' },
  { visible: false, prop: 'qcrd047', label: '备注' },
  { visible: false, prop: 'qcrdassrec', label: 'M/L不良改修対応记录者' },
  { visible: false, prop: 'qcrd048', label: '日期' },
  { visible: false, prop: 'qcrd049', label: '不良内容' },
  { visible: false, prop: 'qcrd050', label: '选别?改修费用' },
  { visible: false, prop: 'qcrd051', label: '选别?改修时间(分)' },
  { visible: false, prop: 'qcrd052', label: '再检查时间(分)' },
  { visible: false, prop: 'qcrd053', label: '交通费、旅费' },
  { visible: false, prop: 'qcrd054', label: '仓库管理费' },
  { visible: false, prop: 'qcrd055', label: '选别?改修其他费用' },
  { visible: false, prop: 'qcrd056', label: '选别?改修备注' },
  { visible: false, prop: 'qcrd057', label: '向顾客的费用请求' },
  { visible: false, prop: 'qcrd058', label: '顾客名' },
  { visible: false, prop: 'qcrd059', label: 'Debit Note No' },
  { visible: false, prop: 'qcrd060', label: '请求费用' },
  { visible: false, prop: 'qcrd061', label: '其他费用' },
  { visible: false, prop: 'qcrd062', label: '备注' },
  { visible: false, prop: 'qcrdpcbrec', label: '担当' },
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
const dateRangeQcrd001 = ref([])
//定义远程搜索变量
const remotequeryList_sql_oph_model=ref([])
//定义远程搜索变量
const remotequery_sql_oph_model=ref([])
//远程字典参数
var remotedictParams_sql_oph_model = [
    { dictType: "sql_oph_model" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_oph_model).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_oph_model.value = element.list
      })
      //console.log(remotequeryList_sql_oph_model)
    })
  })
//远程搜索
const remoteMethod_sql_oph_model = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_oph_model.value = remotequeryList_sql_oph_model.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_oph_model(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_oph_model.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_oph_model = debounce((query) => {
    let arr = remotequeryList_sql_oph_model.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_oph_model.value = arr.slice(0, 5)
      addFilterOptions_sql_oph_model(query)
    } else {
      remotequery_sql_oph_model.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_oph_model =debounce((dictValue) => {
    let target = remotequeryList_sql_oph_model.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_oph_model.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_oph_model.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
//定义远程搜索变量
const remotequeryList_sql_oph_lot=ref([])
//定义远程搜索变量
const remotequery_sql_oph_lot=ref([])
//远程字典参数
var remotedictParams_sql_oph_lot = [
    { dictType: "sql_oph_lot" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_oph_lot).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_oph_lot.value = element.list
      })
      //console.log(remotequeryList_sql_oph_lot)
    })
  })
//远程搜索
const remoteMethod_sql_oph_lot = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_oph_lot.value = remotequeryList_sql_oph_lot.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_oph_lot(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_oph_lot.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_oph_lot = debounce((query) => {
    let arr = remotequeryList_sql_oph_lot.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_oph_lot.value = arr.slice(0, 5)
      addFilterOptions_sql_oph_lot(query)
    } else {
      remotequery_sql_oph_lot.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_oph_lot =debounce((dictValue) => {
    let target = remotequeryList_sql_oph_lot.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_oph_lot.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_oph_lot.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
// 日期时间范围
const dateRangeQcrd018 = ref([])
// 日期时间范围
const dateRangeQcrd033 = ref([])
// 日期时间范围
const dateRangeQcrd048 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_cus_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从返工改修/qm_cost_rework表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQcrd001.value, 'Qcrd001');
  proxy.addDateRange(queryParams, dateRangeQcrd018.value, 'Qcrd018');
  proxy.addDateRange(queryParams, dateRangeQcrd033.value, 'Qcrd033');
  proxy.addDateRange(queryParams, dateRangeQcrd048.value, 'Qcrd048');
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
  dateRangeQcrd001.value = []
  // 日期时间范围
  dateRangeQcrd018.value = []
  // 日期时间范围
  dateRangeQcrd033.value = []
  // 日期时间范围
  dateRangeQcrd048.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qcrdSFID);
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
    qcrdSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    qcrd001: [{ required: true, message: "日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd004: [{ required: true, message: "直接人员赁率"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd005: [{ required: true, message: "间接人员赁率"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd007: [{ required: true, message: "检讨?调查?试验费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd008: [{ required: true, message: "检讨会使用时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd009: [{ required: true, message: "直接人员参加人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd010: [{ required: true, message: "间接人员参加人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd011: [{ required: true, message: "调查评价试验工作时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd012: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd013: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd014: [{ required: true, message: "其他作业時間(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd015: [{ required: true, message: "其他设备购入费,工程费,搬运费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd016: [{ required: true, message: "需要不良改修对应"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd020: [{ required: true, message: "选别?改修费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd021: [{ required: true, message: "选别?改修时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd022: [{ required: true, message: "再检查时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd023: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd024: [{ required: true, message: "仓库管理费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd025: [{ required: true, message: "选别?改修其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd027: [{ required: true, message: "向顾客的费用请求"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd030: [{ required: true, message: "请求费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd031: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd035: [{ required: true, message: "选别?改修费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd036: [{ required: true, message: "选别?改修时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd037: [{ required: true, message: "再检查时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd038: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd039: [{ required: true, message: "仓库管理费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd040: [{ required: true, message: "选别?改修其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd042: [{ required: true, message: "向顾客的费用请求"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd045: [{ required: true, message: "请求费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd046: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd050: [{ required: true, message: "选别?改修费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd051: [{ required: true, message: "选别?改修时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd052: [{ required: true, message: "再检查时间(分)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcrd053: [{ required: true, message: "交通费、旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd054: [{ required: true, message: "仓库管理费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd055: [{ required: true, message: "选别?改修其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd057: [{ required: true, message: "向顾客的费用请求"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd060: [{ required: true, message: "请求费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcrd061: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 顾客名 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_cus_list: [],
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
    qcrdSFID: 0,
    qcrd001: null,
    qcrd002Checked: [],
    qcrd003Checked: [],
    qcrd004: 0,
    qcrd005: 0,
    qcrd006: null,
    qcrd007: 0,
    qcrd008: 0,
    qcrd009: 0,
    qcrd010: 0,
    qcrd011: 0,
    qcrd012: 0,
    qcrd013: 0,
    qcrd014: 0,
    qcrd015: 0,
    qcrd016: 0,
    qcrd017: null,
    qcrdqarec: null,
    qcrd018: null,
    qcrd019: null,
    qcrd020: 0,
    qcrd021: 0,
    qcrd022: 0,
    qcrd023: 0,
    qcrd024: 0,
    qcrd025: 0,
    qcrd026: null,
    qcrd027: 0,
    qcrd028: null,
    qcrd029: null,
    qcrd030: 0,
    qcrd031: 0,
    qcrd032: null,
    qcrdmcrec: null,
    qcrd033: null,
    qcrd034: null,
    qcrd035: 0,
    qcrd036: 0,
    qcrd037: 0,
    qcrd038: 0,
    qcrd039: 0,
    qcrd040: 0,
    qcrd041: null,
    qcrd042: 0,
    qcrd043: null,
    qcrd044: null,
    qcrd045: 0,
    qcrd046: 0,
    qcrd047: null,
    qcrdassrec: null,
    qcrd048: null,
    qcrd049: null,
    qcrd050: 0,
    qcrd051: 0,
    qcrd052: 0,
    qcrd053: 0,
    qcrd054: 0,
    qcrd055: 0,
    qcrd056: null,
    qcrd057: 0,
    qcrd058: null,
    qcrd059: null,
    qcrd060: 0,
    qcrd061: 0,
    qcrd062: null,
    qcrdpcbrec: null,
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
  title.value = proxy.$t('btn.add')+" "+'返工改修'
  opertype.value = 1
  form.value.qcrd001= new Date()
  form.value.qcrd004= 0
  form.value.qcrd005= 0
  form.value.qcrd007= 0
  form.value.qcrd008= 0
  form.value.qcrd009= 0
  form.value.qcrd010= 0
  form.value.qcrd011= 0
  form.value.qcrd012= 0
  form.value.qcrd013= 0
  form.value.qcrd014= 0
  form.value.qcrd015= 0
  form.value.qcrd016= 0
  form.value.qcrd018= new Date()
  form.value.qcrd020= 0
  form.value.qcrd021= 0
  form.value.qcrd022= 0
  form.value.qcrd023= 0
  form.value.qcrd024= 0
  form.value.qcrd025= 0
  form.value.qcrd027= 0
  form.value.qcrd028= []
  form.value.qcrd030= 0
  form.value.qcrd031= 0
  form.value.qcrd033= new Date()
  form.value.qcrd035= 0
  form.value.qcrd036= 0
  form.value.qcrd037= 0
  form.value.qcrd038= 0
  form.value.qcrd039= 0
  form.value.qcrd040= 0
  form.value.qcrd042= 0
  form.value.qcrd043= []
  form.value.qcrd045= 0
  form.value.qcrd046= 0
  form.value.qcrd048= new Date()
  form.value.qcrd050= 0
  form.value.qcrd051= 0
  form.value.qcrd052= 0
  form.value.qcrd053= 0
  form.value.qcrd054= 0
  form.value.qcrd055= 0
  form.value.qcrd057= 0
  form.value.qcrd058= []
  form.value.qcrd060= 0
  form.value.qcrd061= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qcrdSFID || ids.value
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

      if (form.value.qcrdSFID != undefined && opertype.value === 2) {
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
  const Ids = row.qcrdSFID || ids.value

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