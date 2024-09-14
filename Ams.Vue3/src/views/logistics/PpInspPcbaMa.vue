<!--
 * @Descripttion: 检查/pp_insp_pcba_ma
 * @Version: 0.24.621.29240
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 16:26:18
 * @column：30
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="检查日期">
        <el-date-picker
          v-model="dateRangeMu002" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="生产机种" prop="mu003">
        <el-input v-model="queryParams.mu003" :placeholder="$t('btn.enterSearchPrefix')+'生产机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产工单" prop="mu004">
        <el-input v-model="queryParams.mu004" :placeholder="$t('btn.enterSearchPrefix')+'生产工单'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产批次" prop="mu005">
        <el-input v-model="queryParams.mu005" :placeholder="$t('btn.enterSearchPrefix')+'生产批次'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['pp:inscbama:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:inscbama:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:inscbama:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:inscbama:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpInspPcbaMa/importTemplate"
                  importUrl="/Logistics/PpInspPcbaMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:inscbama:export']">
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
      <el-table-column prop="mu002" label="检查日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mu002')"/>
      <el-table-column prop="mu003" label="生产机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mu003')"/>
      <el-table-column prop="mu004" label="生产工单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mu004')"/>
      <el-table-column prop="mu005" label="生产批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mu005')"/>
      <el-table-column prop="mu006" label="工单台数" align="center" v-if="columns.showColumn('mu006')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:inscbama:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:inscbama:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppInspPcbaSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID"/>
        <el-table-column prop="parentId" label="父ID"/>
        <el-table-column prop="mv003" label="批次"/>
        <el-table-column prop="mv004" label="Lot数"/>
        <el-table-column prop="mv005" label="板别">
          <template #default="scope">
            <dict-tag :options=" options.sql_pcb_type " :value="scope.row.mv005"  />
          </template>
        </el-table-column>
        <el-table-column prop="mv006" label="目视线别">
          <template #default="scope">
            <dict-tag :options=" options.sys_visual_type " :value="scope.row.mv006"  />
          </template>
        </el-table-column>
        <el-table-column prop="mv007" label="AOI线别">
          <template #default="scope">
            <dict-tag :options=" options.sys_aoi_type " :value="scope.row.mv007"  />
          </template>
        </el-table-column>
        <el-table-column prop="mv008" label="B面实装"/>
        <el-table-column prop="mv009" label="T面实装"/>
        <el-table-column prop="mv010" label="生产班别">
          <template #default="scope">
            <dict-tag :options=" options.sys_shifts_list " :value="scope.row.mv010"  />
          </template>
        </el-table-column>
        <el-table-column prop="mv011" label="检查员"/>
        <el-table-column prop="mv012" label="当日完成数"/>
        <el-table-column prop="mv013" label="累计完成数"/>
        <el-table-column prop="mv014" label="检查台数"/>
        <el-table-column prop="mv015" label="检查状态">
          <template #default="scope">
            <dict-tag :options=" options.sql_smt_status " :value="scope.row.mv015"  />
          </template>
        </el-table-column>
        <el-table-column prop="mv016" label="生产线别">
          <template #default="scope">
            <dict-tag :options=" options.sql_smt_line " :value="scope.row.mv016"  />
          </template>
        </el-table-column>
        <el-table-column prop="mv017" label="检查工数"/>
        <el-table-column prop="mv018" label="AOI工数"/>
        <el-table-column prop="mv019" label="不良数量"/>
        <el-table-column prop="mv020" label="手贴部品"/>
        <el-table-column prop="mv021" label="序列号"/>
        <el-table-column prop="mv022" label="内容"/>
        <el-table-column prop="mv023" label="个所区分">
          <template #default="scope">
            <dict-tag :options=" options.sql_pcb_place " :value="scope.row.mv023"  />
          </template>
        </el-table-column>
        <el-table-column prop="remark" label="备注"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改检查对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="检查日期" prop="mu002">
              <el-date-picker v-model="form.mu002" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产机种" prop="mu003">
              <el-input   v-model="form.mu003" :placeholder="$t('btn.enterPrefix')+'生产机种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产工单" prop="mu004">
              <el-input   v-model="form.mu004" :placeholder="$t('btn.enterPrefix')+'生产工单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产批次" prop="mu005">
              <el-input   v-model="form.mu005" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="工单台数" prop="mu006">
              <el-input-number v-model.number="form.mu006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工单台数'+$t('btn.enterSuffix')" />
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
        <el-divider content-position="center">检查明细</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpInspPcbaSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpInspPcbaSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppInspPcbaSlvList" :row-class-name="rowPpInspPcbaSlvIndex" @selection-change="handlePpInspPcbaSlvSelectionChange" ref="PpInspPcbaSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="批次" align="center" prop="mv003">
            <template #default="scope">
              <el-input v-model="scope.row.mv003" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="Lot数" align="center" prop="mv004" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mv004" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="板别" prop="mv005">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mv005" :placeholder="$t('btn.enterPrefix')+'板别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="目视线别" prop="mv006">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mv006" :placeholder="$t('btn.enterPrefix')+'目视线别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_visual_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="AOI线别" prop="mv007">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mv007" :placeholder="$t('btn.enterPrefix')+'AOI线别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_aoi_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="B面实装" align="center" prop="mv008">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mv008" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="T面实装" align="center" prop="mv009">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mv009" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="生产班别" prop="mv010">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mv010" :placeholder="$t('btn.enterPrefix')+'生产班别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_shifts_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="检查员" align="center" prop="mv011">
            <template #default="scope">
              <el-input v-model="scope.row.mv011" :placeholder="$t('btn.enterPrefix')+'检查员'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="当日完成数" align="center" prop="mv012" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mv012" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当日完成数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="累计完成数" align="center" prop="mv013" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mv013" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计完成数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="检查台数" align="center" prop="mv014" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mv014" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查台数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="检查状态" prop="mv015">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mv015" :placeholder="$t('btn.enterPrefix')+'检查状态'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_smt_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="生产线别" prop="mv016">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mv016" :placeholder="$t('btn.enterPrefix')+'生产线别'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_smt_line" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="检查工数" align="center" prop="mv017" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mv017" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="AOI工数" align="center" prop="mv018" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mv018" controls-position="right" :placeholder="$t('btn.enterPrefix')+'AOI工数'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="不良数量" align="center" prop="mv019" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mv019" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="手贴部品" align="center" prop="mv020">
            <template #default="scope">
              <el-input v-model="scope.row.mv020" :placeholder="$t('btn.enterPrefix')+'手贴部品'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="序列号" align="center" prop="mv021">
            <template #default="scope">
              <el-input v-model="scope.row.mv021" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="内容" align="center" prop="mv022">
            <template #default="scope">
              <el-input v-model="scope.row.mv022" :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="个所区分" prop="mv023">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mv023" :placeholder="$t('btn.enterPrefix')+'个所区分'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sql_pcb_place" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
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

<script setup name="ppinsppcbama">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpInspPcbaMa,
 addPpInspPcbaMa, delPpInspPcbaMa, 
 updatePpInspPcbaMa,getPpInspPcbaMa, 
 } 
from '@/api/logistics/ppinsppcbama.js'
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
  sort: 'Mu002',
  sortType: 'desc',
  //是否查询（1是）
  mu002: undefined,
  //是否查询（1是）
  mu003: undefined,
  //是否查询（1是）
  mu004: undefined,
  //是否查询（1是）
  mu005: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mu002', label: '检查日期' },
  { visible: true, prop: 'mu003', label: '生产机种' },
  { visible: true, prop: 'mu004', label: '生产工单' },
  { visible: true, prop: 'mu005', label: '生产批次' },
  { visible: true, prop: 'mu006', label: '工单台数' },
  { visible: true, prop: 'remark', label: '备注' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
// 检查日期时间范围
const dateRangeMu002 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_pcb_type" },
  { dictType: "sys_visual_type" },
  { dictType: "sys_aoi_type" },
  { dictType: "sys_shifts_list" },
  { dictType: "sql_smt_status" },
  { dictType: "sql_smt_line" },
  { dictType: "sql_pcb_place" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从检查/pp_insp_pcba_ma表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMu002.value, 'Mu002');
  loading.value = true
  listPpInspPcbaMa(queryParams).then(res => {
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
  // 检查日期时间范围
  dateRangeMu002.value = []
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
    mu004: [{ required: true, message: "生产工单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mu006: [{ required: true, message: "工单台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 板别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_type: [],
    // 目视线别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_visual_type: [],
    // AOI线别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_aoi_type: [],
    // 生产班别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_shifts_list: [],
    // 检查状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_smt_status: [],
    // 生产线别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_smt_line: [],
    // 个所区分 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_pcb_place: [],
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
    mu002: null,
    mu003: null,
    mu004: null,
    mu005: null,
    mu006: 0,
    remark: null,
  };
  ppInspPcbaSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'检查'
  opertype.value = 1
  form.value.mu002= new Date()
  form.value.mu006= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpInspPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '检查'
      opertype.value = 2

      form.value = {
        ...data,
      }
      ppInspPcbaSlvList.value = res.data.ppInspPcbaSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.ppInspPcbaSlvNav = ppInspPcbaSlvList.value
      if (form.value.id != undefined && opertype.value === 2) {
        updatePpInspPcbaMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpInspPcbaMa(form.value).then((res) => {
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
      return delPpInspPcbaMa(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<检查.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpInspPcbaMa/export', { ...queryParams })
    })
}

/*********************检查明细子表信息*************************/
const ppInspPcbaSlvList = ref([])
const checkedPpInspPcbaSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 检查明细序号 */
function rowPpInspPcbaSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 检查明细添加按钮操作 */
function handleAddPpInspPcbaSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.mv003 = null;
  //obj.mv004 = null;
  //obj.mv005 = null;
  //obj.mv006 = null;
  //obj.mv007 = null;
  //obj.mv008 = null;
  //obj.mv009 = null;
  //obj.mv010 = null;
  //obj.mv011 = null;
  //obj.mv012 = null;
  //obj.mv013 = null;
  //obj.mv014 = null;
  //obj.mv015 = null;
  //obj.mv016 = null;
  //obj.mv017 = null;
  //obj.mv018 = null;
  //obj.mv019 = null;
  //obj.mv020 = null;
  //obj.mv021 = null;
  //obj.mv022 = null;
  //obj.mv023 = null;
  //obj.remark = null;
  ppInspPcbaSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpInspPcbaSlvSelectionChange(selection) {
  checkedPpInspPcbaSlv.value = selection.map(item => item.index)
}

/** 检查明细删除按钮操作 */
function handleDeletePpInspPcbaSlv() {
  if(checkedPpInspPcbaSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的检查明细数据')
  } else {
    const PpInspPcbaSlvs = ppInspPcbaSlvList.value;
    const checkedPpInspPcbaSlvs = checkedPpInspPcbaSlv.value;
    ppInspPcbaSlvList.value = PpInspPcbaSlvs.filter(function(item) {
      return checkedPpInspPcbaSlvs.indexOf(item.index) == -1
    });
  }
}

/** 检查明细详情 */
function rowClick(row) {
  const id = row.id || ids.value
  getPpInspPcbaMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      ppInspPcbaSlvList.value = data.ppInspPcbaSlvNav
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