<!--
 * @Descripttion: 检查日报slv/pp_insp_pcba_slv
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/22 12:01:22
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="批次" prop="pdilot">
        <el-input v-model="queryParams.pdilot" :placeholder="$t('btn.enterSearchPrefix')+'批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="板别" prop="pdipcbtype">
        <el-select filterable clearable   v-model="queryParams.pdipcbtype" :placeholder="$t('btn.selectSearchPrefix')+'板别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_pcb_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="目视线别" prop="pdivisualtype">
        <el-select filterable clearable   v-model="queryParams.pdivisualtype" :placeholder="$t('btn.selectSearchPrefix')+'目视线别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_visual_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="AOI线别" prop="pdivctype">
        <el-select filterable clearable   v-model="queryParams.pdivctype" :placeholder="$t('btn.selectSearchPrefix')+'AOI线别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_aoi_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="B面实装">
        <el-date-picker
          v-model="dateRangePdisideadate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="T面实装">
        <el-date-picker
          v-model="dateRangePdisidebdate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="个所区分" prop="pdibadPosition">
        <el-select filterable clearable   v-model="queryParams.pdibadPosition" :placeholder="$t('btn.selectSearchPrefix')+'个所区分'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_pcb_place " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:inscbaslv:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:inscbaslv:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:inscbaslv:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:inscbaslv:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpInspPcbaSlv/importTemplate"
                  importUrl="/Logistics/PpInspPcbaSlv/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:inscbaslv:export']">
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
      <el-table-column prop="pdiSfid" label="ID" align="center" v-if="columns.showColumn('pdiSfid')"/>
      <el-table-column prop="pdiParentSfid" label="PdiParentSfid" align="center" v-if="columns.showColumn('pdiParentSfid')"/>
      <el-table-column prop="pdilot" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdilot')"/>
      <el-table-column prop="pdilotqty" label="Lot数" align="center" v-if="columns.showColumn('pdilotqty')"/>
      <el-table-column prop="pdipcbtype" label="板别" align="center" v-if="columns.showColumn('pdipcbtype')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_type " :value="scope.row.pdipcbtype"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdivisualtype" label="目视线别" align="center" v-if="columns.showColumn('pdivisualtype')">
        <template #default="scope">
          <dict-tag :options=" options.sys_visual_type " :value="scope.row.pdivisualtype"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdivctype" label="AOI线别" align="center" v-if="columns.showColumn('pdivctype')">
        <template #default="scope">
          <dict-tag :options=" options.sys_aoi_type " :value="scope.row.pdivctype"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdisideadate" label="B面实装" :show-overflow-tooltip="true"  v-if="columns.showColumn('pdisideadate')"/>
      <el-table-column prop="pdisidebdate" label="T面实装" :show-overflow-tooltip="true"  v-if="columns.showColumn('pdisidebdate')"/>
      <el-table-column prop="pdidshiftname" label="生产班别" align="center" v-if="columns.showColumn('pdidshiftname')">
        <template #default="scope">
          <dict-tag :options=" options.sql_smt_class " :value="scope.row.pdidshiftname"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdicensor" label="检查员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdicensor')"/>
      <el-table-column prop="pdirealqty" label="当日完成数" align="center" v-if="columns.showColumn('pdirealqty')"/>
      <el-table-column prop="pdirealtotal" label="累计完成数" align="center" v-if="columns.showColumn('pdirealtotal')"/>
      <el-table-column prop="pdiispqty" label="检查台数" align="center" v-if="columns.showColumn('pdiispqty')"/>
      <el-table-column prop="pdipcbchecktype" label="检查状态" align="center" v-if="columns.showColumn('pdipcbchecktype')">
        <template #default="scope">
          <dict-tag :options=" options.sql_smt_status " :value="scope.row.pdipcbchecktype"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdilinename" label="生产线别" align="center" v-if="columns.showColumn('pdilinename')">
        <template #default="scope">
          <dict-tag :options=" options.sql_smt_line " :value="scope.row.pdilinename"  />
        </template>
      </el-table-column>
      <el-table-column prop="pdiinsqtime" label="检查工数" align="center" v-if="columns.showColumn('pdiinsqtime')"/>
      <el-table-column prop="pdiaoitime" label="AOI工数" align="center" v-if="columns.showColumn('pdiaoitime')"/>
      <el-table-column prop="pdibadqty" label="不良数量" align="center" v-if="columns.showColumn('pdibadqty')"/>
      <el-table-column prop="pdihandle" label="手贴部品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdihandle')"/>
      <el-table-column prop="pdibadserial" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdibadserial')"/>
      <el-table-column prop="pdibadcontent" label="内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pdibadcontent')"/>
      <el-table-column prop="pdibadPosition" label="个所区分" align="center" v-if="columns.showColumn('pdibadPosition')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_place " :value="scope.row.pdibadPosition"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:inscbaslv:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:inscbaslv:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改检查日报slv对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="ID" prop="pdiSfid">
              <el-input v-model.number="form.pdiSfid" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="PdiParentSfid" prop="pdiParentSfid">
              <el-input v-model.number="form.pdiParentSfid" :placeholder="$t('btn.enterPrefix')+'PdiParentSfid'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="pdilot">
              <el-input v-model="form.pdilot" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="Lot数" prop="pdilotqty">
              <el-input-number v-model.number="form.pdilotqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="板别" prop="pdipcbtype">
              <el-select filterable clearable   v-model="form.pdipcbtype"  :placeholder="$t('btn.selectPrefix')+'板别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="目视线别" prop="pdivisualtype">
              <el-select filterable clearable   v-model="form.pdivisualtype"  :placeholder="$t('btn.selectPrefix')+'目视线别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_visual_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="AOI线别" prop="pdivctype">
              <el-select filterable clearable   v-model="form.pdivctype"  :placeholder="$t('btn.selectPrefix')+'AOI线别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_aoi_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="B面实装" prop="pdisideadate">
              <el-date-picker v-model="form.pdisideadate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="T面实装" prop="pdisidebdate">
              <el-date-picker v-model="form.pdisidebdate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班别" prop="pdidshiftname">
              <el-select filterable clearable   v-model="form.pdidshiftname"  :placeholder="$t('btn.selectPrefix')+'生产班别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_smt_class" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检查员" prop="pdicensor">
              <el-input v-model="form.pdicensor" :placeholder="$t('btn.enterPrefix')+'检查员'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当日完成数" prop="pdirealqty">
              <el-input-number v-model.number="form.pdirealqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当日完成数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计完成数" prop="pdirealtotal">
              <el-input-number v-model.number="form.pdirealtotal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计完成数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检查台数" prop="pdiispqty">
              <el-input-number v-model.number="form.pdiispqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查台数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查状态" prop="pdipcbchecktype">
              <el-select filterable clearable   v-model="form.pdipcbchecktype"  :placeholder="$t('btn.selectPrefix')+'检查状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_smt_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="生产线别" prop="pdilinename">
              <el-select filterable clearable   v-model="form.pdilinename"  :placeholder="$t('btn.selectPrefix')+'生产线别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_smt_line" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="检查工数" prop="pdiinsqtime">
              <el-input-number v-model.number="form.pdiinsqtime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="AOI工数" prop="pdiaoitime">
              <el-input-number v-model.number="form.pdiaoitime" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'AOI工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="不良数量" prop="pdibadqty">
              <el-input-number v-model.number="form.pdibadqty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手贴部品" prop="pdihandle">
              <el-input v-model="form.pdihandle" :placeholder="$t('btn.enterPrefix')+'手贴部品'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="pdibadserial">
              <el-input v-model="form.pdibadserial" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内容" prop="pdibadcontent">
              <el-input v-model="form.pdibadcontent" :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="个所区分" prop="pdibadPosition">
              <el-select filterable clearable   v-model="form.pdibadPosition"  :placeholder="$t('btn.selectPrefix')+'个所区分'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_place" 
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
            <el-form-item label="说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')"/>
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

<script setup name="ppinsppcbaslv">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpInspPcbaSlv,
 addPpInspPcbaSlv, delPpInspPcbaSlv, 
 updatePpInspPcbaSlv,getPpInspPcbaSlv, 
 } 
from '@/api/logistics/ppinsppcbaslv.js'
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
  pdilot: undefined,
//是否查询（1是）
  pdipcbtype: undefined,
//是否查询（1是）
  pdivisualtype: undefined,
//是否查询（1是）
  pdivctype: undefined,
//是否查询（1是）
  pdisideadate: undefined,
//是否查询（1是）
  pdisidebdate: undefined,
//是否查询（1是）
  pdibadPosition: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'pdiSfid', label: 'ID' },
  { visible: true, prop: 'pdiParentSfid', label: 'PdiParentSfid' },
  { visible: true, prop: 'pdilot', label: '批次' },
  { visible: true, prop: 'pdilotqty', label: 'Lot数' },
  { visible: true, prop: 'pdipcbtype', label: '板别' },
  { visible: true, prop: 'pdivisualtype', label: '目视线别' },
  { visible: true, prop: 'pdivctype', label: 'AOI线别' },
  { visible: true, prop: 'pdisideadate', label: 'B面实装' },
  { visible: false, prop: 'pdisidebdate', label: 'T面实装' },
  { visible: false, prop: 'pdidshiftname', label: '生产班别' },
  { visible: false, prop: 'pdicensor', label: '检查员' },
  { visible: false, prop: 'pdirealqty', label: '当日完成数' },
  { visible: false, prop: 'pdirealtotal', label: '累计完成数' },
  { visible: false, prop: 'pdiispqty', label: '检查台数' },
  { visible: false, prop: 'pdipcbchecktype', label: '检查状态' },
  { visible: false, prop: 'pdilinename', label: '生产线别' },
  { visible: false, prop: 'pdiinsqtime', label: '检查工数' },
  { visible: false, prop: 'pdiaoitime', label: 'AOI工数' },
  { visible: false, prop: 'pdibadqty', label: '不良数量' },
  { visible: false, prop: 'pdihandle', label: '手贴部品' },
  { visible: false, prop: 'pdibadserial', label: '序列号' },
  { visible: false, prop: 'pdibadcontent', label: '内容' },
  { visible: false, prop: 'pdibadPosition', label: '个所区分' },
  { visible: false, prop: 'remark', label: '说明' },
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
// B面实装时间范围
const dateRangePdisideadate = ref([])
// T面实装时间范围
const dateRangePdisidebdate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_pcb_type" },
  { dictType: "sys_visual_type" },
  { dictType: "sys_aoi_type" },
  { dictType: "sql_smt_class" },
  { dictType: "sql_smt_status" },
  { dictType: "sql_smt_line" },
  { dictType: "sql_pcb_place" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从检查日报slv/pp_insp_pcba_slv表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangePdisideadate.value, 'Pdisideadate');
  proxy.addDateRange(queryParams, dateRangePdisidebdate.value, 'Pdisidebdate');
  loading.value = true
  listPpInspPcbaSlv(queryParams).then(res => {
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
  // B面实装时间范围
  dateRangePdisideadate.value = []
  // T面实装时间范围
  dateRangePdisidebdate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.pdiSfid);
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
    pdiSfid: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    pdiParentSfid: [{ required: true, message: "PdiParentSfid"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdirealqty: [{ required: true, message: "当日完成数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdirealtotal: [{ required: true, message: "累计完成数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdiispqty: [{ required: true, message: "检查台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdiinsqtime: [{ required: true, message: "检查工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdiaoitime: [{ required: true, message: "AOI工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    pdibadqty: [{ required: true, message: "不良数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 板别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_type: [],
    // 目视线别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_visual_type: [],
    // AOI线别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_aoi_type: [],
    // 生产班别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_smt_class: [],
    // 检查状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_smt_status: [],
    // 生产线别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_smt_line: [],
    // 个所区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_place: [],
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
    pdiSfid: 0,
    pdiParentSfid: 0,
    pdilot: null,
    pdilotqty: 0,
    pdipcbtype: null,
    pdivisualtype: null,
    pdivctype: null,
    pdisideadate: null,
    pdisidebdate: null,
    pdidshiftname: null,
    pdicensor: null,
    pdirealqty: 0,
    pdirealtotal: 0,
    pdiispqty: 0,
    pdipcbchecktype: null,
    pdilinename: null,
    pdiinsqtime: 0,
    pdiaoitime: 0,
    pdibadqty: 0,
    pdihandle: null,
    pdibadserial: null,
    pdibadcontent: null,
    pdibadPosition: null,
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
  title.value = proxy.$t('btn.add')+" "+'检查日报slv'
  opertype.value = 1
  form.value.pdilotqty= 0
  form.value.pdipcbtype= []
  form.value.pdivisualtype= []
  form.value.pdivctype= []
  form.value.pdisideadate= new Date()
  form.value.pdisidebdate= new Date()
  form.value.pdidshiftname= []
  form.value.pdirealqty= 0
  form.value.pdirealtotal= 0
  form.value.pdiispqty= 0
  form.value.pdipcbchecktype= []
  form.value.pdilinename= []
  form.value.pdiinsqtime= 0
  form.value.pdiaoitime= 0
  form.value.pdibadqty= 0
  form.value.pdibadPosition= []
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.pdiSfid || ids.value
  getPpInspPcbaSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '检查日报slv'
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

      if (form.value.pdiSfid != undefined && opertype.value === 2) {
        updatePpInspPcbaSlv(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpInspPcbaSlv(form.value).then((res) => {
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
  const Ids = row.pdiSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpInspPcbaSlv(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<检查日报slv.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpInspPcbaSlv/export', { ...queryParams })
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