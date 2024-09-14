<!--
 * @Descripttion: PCBA OPH/pp_output_pcba_ma
 * @Version: 0.24.621.29240
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 16:18:45
 * @column：36
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="订单号码" prop="mca003">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_moc_pcba" :loading="loading" v-model="queryParams.mca003" :placeholder="$t('btn.selectSearchPrefix')+'订单号码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_moc_pcba " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产批次" prop="mca005">
        <el-input v-model="queryParams.mca005" :placeholder="$t('btn.enterSearchPrefix')+'生产批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="mca006">
        <el-input v-model="queryParams.mca006" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="mca007">
        <el-input v-model="queryParams.mca007" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产日期">
        <el-date-picker
          v-model="dateRangeMca010" 
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
        <el-button class="btn-add" v-hasPermi="['pp:outputpcbama:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:outputpcbama:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:outputpcbama:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:outputpcbama:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpOutputPcbaMa/importTemplate"
                  importUrl="/Logistics/PpOutputPcbaMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:outputpcbama:export']">
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain  icon="view" size="small" @click="rowClick(scope.row)" :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="mca002" label="订单类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mca002')"/>
      <el-table-column prop="mca003" label="订单号码" align="center" v-if="columns.showColumn('mca003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_moc_pcba " :value="scope.row.mca003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mca004" label="订单数量" align="center" v-if="columns.showColumn('mca004')"/>
      <el-table-column prop="mca005" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mca005')"/>
      <el-table-column prop="mca006" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mca006')"/>
      <el-table-column prop="mca007" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mca007')"/>
      <el-table-column prop="mca008" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mca008')"/>
      <el-table-column prop="mca009" label="生产班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mca009')"/>
      <el-table-column prop="mca010" label="生产日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mca010')"/>
      <el-table-column prop="mca011" label="直接人数" align="center" v-if="columns.showColumn('mca011')"/>
      <el-table-column prop="mca012" label="间接人数" align="center" v-if="columns.showColumn('mca012')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:outputpcbama:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:outputpcbama:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppOutputPcbaSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID"/>
        <el-table-column prop="parentId" label="父ID"/>
        <el-table-column prop="mda003" label="班组"/>
        <el-table-column prop="mda004" label="板别">
          <template #default="scope">
            <dict-tag :options=" options.sql_pcb_type " :value="scope.row.mda004"  />
          </template>
        </el-table-column>
        <el-table-column prop="mda005" label="板面">
          <template #default="scope">
            <dict-tag :options=" options.sys_pcb_side " :value="scope.row.mda005"  />
          </template>
        </el-table-column>
        <el-table-column prop="mda006" label="Lot数"/>
        <el-table-column prop="mda007" label="生产实绩"/>
        <el-table-column prop="mda008" label="累计生产数"/>
        <el-table-column prop="mda009" label="序列号"/>
        <el-table-column prop="mda010" label="完成情况">
          <template #default="scope">
            <dict-tag :options=" options.sql_comp_status " :value="scope.row.mda010"  />
          </template>
        </el-table-column>
        <el-table-column prop="mda011" label="总工数"/>
        <el-table-column prop="mda012" label="切换次数"/>
        <el-table-column prop="mda013" label="切换时间"/>
        <el-table-column prop="mda014" label="切停机时间"/>
        <el-table-column prop="mda015" label="修工数"/>
        <el-table-column prop="mda016" label="投入工数"/>
        <el-table-column prop="mda017" label="不良台数"/>
        <el-table-column prop="mda018" label="手插仕损"/>
        <el-table-column prop="mda019" label="修正仕损"/>
        <el-table-column prop="mda020" label="停线原因"/>
        <el-table-column prop="mda021" label="停线备注说明"/>
        <el-table-column prop="mda022" label="未达成原因"/>
        <el-table-column prop="mda023" label="未达成备注说明"/>
        <el-table-column prop="remark" label="备注"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改PCBA OPH对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="订单类别" prop="mca002">
              <el-input   v-model="form.mca002" :placeholder="$t('btn.enterPrefix')+'订单类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单号码" prop="mca003">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_moc_pcba" 
              :loading="loading" v-model="form.mca003"  :placeholder="$t('btn.selectPrefix')+'订单号码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_moc_pcba" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="订单数量" prop="mca004">
              <el-input-number v-model.number="form.mca004" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'订单数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="mca005">
              <el-input   v-model="form.mca005" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="mca006">
              <el-input   v-model="form.mca006" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mca007">
              <el-input   v-model="form.mca007" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="mca008">
              <el-input   v-model="form.mca008" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班组" prop="mca009">
              <el-input   v-model="form.mca009" :placeholder="$t('btn.enterPrefix')+'生产班组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="mca010">
              <el-date-picker v-model="form.mca010" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="直接人数" prop="mca011">
              <el-input-number v-model.number="form.mca011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'直接人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="mca012">
              <el-input-number v-model.number="form.mca012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人数'+$t('btn.enterSuffix')" />
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


    <!-- 子表信息 -->
        <el-divider content-position="center">PCBA明细</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpOutputPcbaSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpOutputPcbaSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppOutputPcbaSlvList" :row-class-name="rowPpOutputPcbaSlvIndex" @selection-change="handlePpOutputPcbaSlvSelectionChange" ref="PpOutputPcbaSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="班组" align="center" prop="mda003">
            <template #default="scope">
              <el-input v-model="scope.row.mda003" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="板别" prop="mda004">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mda004" :placeholder="$t('btn.enterPrefix')+'板别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="板面" prop="mda005">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mda005" :placeholder="$t('btn.enterPrefix')+'板面'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_pcb_side" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="Lot数" align="center" prop="mda006" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda006" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="生产实绩" align="center" prop="mda007" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda007" controls-position="right" :placeholder="$t('btn.enterPrefix')+'生产实绩'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="累计生产数" align="center" prop="mda008" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda008" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计生产数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="序列号" align="center" prop="mda009">
            <template #default="scope">
              <el-input v-model="scope.row.mda009" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="完成情况" prop="mda010">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mda010" :placeholder="$t('btn.enterPrefix')+'完成情况'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_comp_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="总工数" align="center" prop="mda011" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda011" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="切换次数" align="center" prop="mda012" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda012" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切换次数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="切换时间" align="center" prop="mda013" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda013" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切换时间'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="切停机时间" align="center" prop="mda014" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda014" controls-position="right" :placeholder="$t('btn.enterPrefix')+'切停机时间'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="修工数" align="center" prop="mda015" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda015" controls-position="right" :placeholder="$t('btn.enterPrefix')+'修工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="投入工数" align="center" prop="mda016" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda016" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良台数" align="center" prop="mda017" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda017" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良台数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="手插仕损" align="center" prop="mda018" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda018" controls-position="right" :placeholder="$t('btn.enterPrefix')+'手插仕损'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="修正仕损" align="center" prop="mda019" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mda019" controls-position="right" :placeholder="$t('btn.enterPrefix')+'修正仕损'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="停线原因" align="center" prop="mda020">
            <template #default="scope">
              <el-input v-model="scope.row.mda020" :placeholder="$t('btn.enterPrefix')+'停线原因'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="停线备注说明" align="center" prop="mda021">
            <template #default="scope">
              <el-input v-model="scope.row.mda021" :placeholder="$t('btn.enterPrefix')+'停线备注说明'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="未达成原因" align="center" prop="mda022">
            <template #default="scope">
              <el-input v-model="scope.row.mda022" :placeholder="$t('btn.enterPrefix')+'未达成原因'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="未达成备注说明" align="center" prop="mda023">
            <template #default="scope">
              <el-input v-model="scope.row.mda023" :placeholder="$t('btn.enterPrefix')+'未达成备注说明'+$t('btn.enterSuffix')" />
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

<script setup name="ppoutputpcbama">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpOutputPcbaMa,
 addPpOutputPcbaMa, delPpOutputPcbaMa, 
 updatePpOutputPcbaMa,getPpOutputPcbaMa, 
 } 
from '@/api/logistics/ppoutputpcbama.js'
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
  sort: 'Mca010',
  sortType: 'desc',
  //是否查询（1是）
  mca003: undefined,
  //是否查询（1是）
  mca005: undefined,
  //是否查询（1是）
  mca006: undefined,
  //是否查询（1是）
  mca007: undefined,
  //是否查询（1是）
  mca010: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mca002', label: '订单类别' },
  { visible: true, prop: 'mca003', label: '订单号码' },
  { visible: true, prop: 'mca004', label: '订单数量' },
  { visible: true, prop: 'mca005', label: '生产批次' },
  { visible: true, prop: 'mca006', label: '机种' },
  { visible: true, prop: 'mca007', label: '物料' },
  { visible: true, prop: 'mca008', label: '序列号' },
  { visible: false, prop: 'mca009', label: '生产班组' },
  { visible: false, prop: 'mca010', label: '生产日期' },
  { visible: false, prop: 'mca011', label: '直接人数' },
  { visible: false, prop: 'mca012', label: '间接人数' },
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
const remotequeryList_sql_moc_pcba=ref([])
//定义远程搜索变量
const remotequery_sql_moc_pcba=ref([])
//远程字典参数
var remotedictParams_sql_moc_pcba = [
    { dictType: "sql_moc_pcba" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_moc_pcba).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_moc_pcba.value = element.list
      })
      //console.log(remotequeryList_sql_moc_pcba)
    })
  })
//远程搜索
const remoteMethod_sql_moc_pcba = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_moc_pcba.value = remotequeryList_sql_moc_pcba.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_moc_pcba(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_moc_pcba.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_moc_pcba = debounce((query) => {
    let arr = remotequeryList_sql_moc_pcba.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_moc_pcba.value = arr.slice(0, 5)
      addFilterOptions_sql_moc_pcba(query)
    } else {
      remotequery_sql_moc_pcba.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_moc_pcba =debounce((dictValue) => {
    let target = remotequeryList_sql_moc_pcba.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_moc_pcba.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_moc_pcba.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
// 生产日期时间范围
const dateRangeMca010 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_moc_pcba" },
  { dictType: "sql_pcb_type" },
  { dictType: "sys_pcb_side" },
  { dictType: "sql_comp_status" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从PCBA OPH/pp_output_pcba_ma表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMca010.value, 'Mca010');
  loading.value = true
  listPpOutputPcbaMa(queryParams).then(res => {
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
  // 生产日期时间范围
  dateRangeMca010.value = []
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
    mca003: [{ required: true, message: "订单号码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mca004: [{ required: true, message: "订单数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mca011: [{ required: true, message: "直接人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mca012: [{ required: true, message: "间接人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 订单号码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_moc_pcba: [],
    // 板别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_type: [],
    // 板面 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pcb_side: [],
    // 完成情况 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_comp_status: [],
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
    mca002: null,
    mca003: [],
    mca004: 0,
    mca005: null,
    mca006: null,
    mca007: null,
    mca008: null,
    mca009: null,
    mca010: null,
    mca011: 0,
    mca012: 0,
    remark: null,
  };
  ppOutputPcbaSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'PCBA OPH'
  opertype.value = 1
  form.value.mca003= []
  form.value.mca004= 0
  form.value.mca010= new Date()
  form.value.mca011= 0
  form.value.mca012= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpOutputPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ 'PCBA OPH'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppOutputPcbaSlvList.value = res.data.ppOutputPcbaSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppOutputPcbaSlvNav = ppOutputPcbaSlvList.value
      if (form.value.id != undefined && opertype.value === 2) {
        updatePpOutputPcbaMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpOutputPcbaMa(form.value).then((res) => {
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
      return delPpOutputPcbaMa(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<PCBA OPH.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpOutputPcbaMa/export', { ...queryParams })
    })
}

/*********************PCBA明细子表信息*************************/
const ppOutputPcbaSlvList = ref([])
const checkedPpOutputPcbaSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** PCBA明细序号 */
function rowPpOutputPcbaSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** PCBA明细添加按钮操作 */
function handleAddPpOutputPcbaSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.mda003 = null;
  //obj.mda004 = null;
  //obj.mda005 = null;
  //obj.mda006 = null;
  //obj.mda007 = null;
  //obj.mda008 = null;
  //obj.mda009 = null;
  //obj.mda010 = null;
  //obj.mda011 = null;
  //obj.mda012 = null;
  //obj.mda013 = null;
  //obj.mda014 = null;
  //obj.mda015 = null;
  //obj.mda016 = null;
  //obj.mda017 = null;
  //obj.mda018 = null;
  //obj.mda019 = null;
  //obj.mda020 = null;
  //obj.mda021 = null;
  //obj.mda022 = null;
  //obj.mda023 = null;
  //obj.remark = null;
  ppOutputPcbaSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpOutputPcbaSlvSelectionChange(selection) {
  checkedPpOutputPcbaSlv.value = selection.map(item => item.index)
}

/** PCBA明细删除按钮操作 */
function handleDeletePpOutputPcbaSlv() {
  if(checkedPpOutputPcbaSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的PCBA明细数据')
  } else {
    const PpOutputPcbaSlvs = ppOutputPcbaSlvList.value;
    const checkedPpOutputPcbaSlvs = checkedPpOutputPcbaSlv.value;
    ppOutputPcbaSlvList.value = PpOutputPcbaSlvs.filter(function(item) {
      return checkedPpOutputPcbaSlvs.indexOf(item.index) == -1
    });
  }
}

/** PCBA明细详情 */
function rowClick(row) {
  const id = row.id || ids.value
  getPpOutputPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppOutputPcbaSlvList.value = data.ppOutputPcbaSlvNav
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