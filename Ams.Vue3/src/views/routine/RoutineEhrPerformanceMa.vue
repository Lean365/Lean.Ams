<!--
 * @Descripttion: 绩效/routine_ehr_performance_ma
 * @Version: 0.24.621.24558
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 15:19:03
 * @column：30
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工号" prop="ml002">
        <el-input v-model="queryParams.ml002" :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="姓名" prop="ml003">
        <el-input v-model="queryParams.ml003" :placeholder="$t('btn.enterSearchPrefix')+'姓名'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="年度" prop="ml004">
        <el-select filterable clearable   v-model="queryParams.ml004" :placeholder="$t('btn.selectSearchPrefix')+'年度'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="等级" prop="ml006">
        <el-select filterable clearable   v-model="queryParams.ml006" :placeholder="$t('btn.selectSearchPrefix')+'等级'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_eval_grade " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['routine:ehrperformancema:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrperformancema:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrperformancema:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehrperformancema:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/RoutineEhrPerformanceMa/importTemplate"
                  importUrl="/Routine/RoutineEhrPerformanceMa/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehrperformancema:export']">
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
      <el-table-column prop="ml002" label="工号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml002')"/>
      <el-table-column prop="ml003" label="姓名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml003')"/>
      <el-table-column prop="ml004" label="年度" align="center" v-if="columns.showColumn('ml004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.ml004"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml005" label="总分" align="center" v-if="columns.showColumn('ml005')"/>
      <el-table-column prop="ml006" label="等级" align="center" v-if="columns.showColumn('ml006')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eval_grade " :value="scope.row.ml006"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehrperformancema:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehrperformancema:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="routineEhrPerformanceSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID"/>
        <el-table-column prop="parentId" label="父ID"/>
        <el-table-column prop="mm003" label="考核项目">
          <template #default="scope">
            <dict-tag :options=" options.sys_eval_items " :value="scope.row.mm003"  />
          </template>
        </el-table-column>
        <el-table-column prop="mm004" label="初次评分"/>
        <el-table-column prop="mm005" label="初评人"/>
        <el-table-column prop="mm006" label="初评日期"/>
        <el-table-column prop="mm007" label="二次评分"/>
        <el-table-column prop="mm008" label="二次考评人"/>
        <el-table-column prop="mm009" label="二次考评日期"/>
        <el-table-column prop="mm010" label="三次评分"/>
        <el-table-column prop="mm011" label="三次考评人"/>
        <el-table-column prop="mm012" label="三次考评日期"/>
        <el-table-column prop="mm013" label="四次评分"/>
        <el-table-column prop="mm014" label="四次考评人"/>
        <el-table-column prop="mm015" label="四次考评日期"/>
        <el-table-column prop="mm016" label="五次评分"/>
        <el-table-column prop="mm017" label="五次考评人"/>
        <el-table-column prop="mm018" label="五次考评日期"/>
        <el-table-column prop="mm019" label="六次评分"/>
        <el-table-column prop="mm020" label="六次考评人"/>
        <el-table-column prop="mm021" label="六次考评日期"/>
        <el-table-column prop="isDeleted" label="软删除"/>
        <el-table-column prop="remark" label="备注说明"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改绩效对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工号" prop="ml002">
              <el-input   v-model="form.ml002" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="姓名" prop="ml003">
              <el-input   v-model="form.ml003" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年度" prop="ml004">
              <el-select filterable clearable   v-model="form.ml004"  :placeholder="$t('btn.selectPrefix')+'年度'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="总分" prop="ml005">
              <el-input-number v-model.number="form.ml005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="等级" prop="ml006">
              <el-select filterable clearable   v-model="form.ml006"  :placeholder="$t('btn.selectPrefix')+'等级'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_eval_grade" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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
        <el-divider content-position="center">绩效</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddRoutineEhrPerformanceSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeleteRoutineEhrPerformanceSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="routineEhrPerformanceSlvList" :row-class-name="rowRoutineEhrPerformanceSlvIndex" @selection-change="handleRoutineEhrPerformanceSlvSelectionChange" ref="RoutineEhrPerformanceSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="考核项目" prop="mm003">
            <template #default="scope">
              <el-select filterable clearable  v-model="scope.row.mm003" :placeholder="$t('btn.enterPrefix')+'考核项目'+$t('btn.enterSuffix')">
                <el-option
                  v-for="item in options.sys_eval_items" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="初次评分" align="center" prop="mm004" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mm004" controls-position="right" :placeholder="$t('btn.enterPrefix')+'初次评分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="初评人" align="center" prop="mm005">
            <template #default="scope">
              <el-input v-model="scope.row.mm005" :placeholder="$t('btn.enterPrefix')+'初评人'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="初评日期" align="center" prop="mm006">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mm006" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="二次评分" align="center" prop="mm007" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mm007" controls-position="right" :placeholder="$t('btn.enterPrefix')+'二次评分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="二次考评人" align="center" prop="mm008">
            <template #default="scope">
              <el-input v-model="scope.row.mm008" :placeholder="$t('btn.enterPrefix')+'二次考评人'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="二次考评日期" align="center" prop="mm009">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mm009" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="三次评分" align="center" prop="mm010" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mm010" controls-position="right" :placeholder="$t('btn.enterPrefix')+'三次评分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="三次考评人" align="center" prop="mm011">
            <template #default="scope">
              <el-input v-model="scope.row.mm011" :placeholder="$t('btn.enterPrefix')+'三次考评人'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="三次考评日期" align="center" prop="mm012">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mm012" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="四次评分" align="center" prop="mm013" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mm013" controls-position="right" :placeholder="$t('btn.enterPrefix')+'四次评分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="四次考评人" align="center" prop="mm014">
            <template #default="scope">
              <el-input v-model="scope.row.mm014" :placeholder="$t('btn.enterPrefix')+'四次考评人'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="四次考评日期" align="center" prop="mm015">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mm015" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="五次评分" align="center" prop="mm016" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mm016" controls-position="right" :placeholder="$t('btn.enterPrefix')+'五次评分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="五次考评人" align="center" prop="mm017">
            <template #default="scope">
              <el-input v-model="scope.row.mm017" :placeholder="$t('btn.enterPrefix')+'五次考评人'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="五次考评日期" align="center" prop="mm018">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mm018" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="六次评分" align="center" prop="mm019" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.mm019" controls-position="right" :placeholder="$t('btn.enterPrefix')+'六次评分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="六次考评人" align="center" prop="mm020">
            <template #default="scope">
              <el-input v-model="scope.row.mm020" :placeholder="$t('btn.enterPrefix')+'六次考评人'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="六次考评日期" align="center" prop="mm021">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.mm021" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="软删除" align="center" prop="isDeleted" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.isDeleted" controls-position="right" :placeholder="$t('btn.enterPrefix')+'软删除'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="备注说明" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
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

<script setup name="routineehrperformancema">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrPerformanceMa,
 addRoutineEhrPerformanceMa, delRoutineEhrPerformanceMa, 
 updateRoutineEhrPerformanceMa,getRoutineEhrPerformanceMa, 
 } 
from '@/api/routine/routineehrperformancema.js'
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
  sort: 'Ml002',
  sortType: 'asc',
  //是否查询（1是）
  ml002: undefined,
  //是否查询（1是）
  ml003: undefined,
  //是否查询（1是）
  ml004: undefined,
  //是否查询（1是）
  ml006: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'ml002', label: '工号' },
  { visible: true, prop: 'ml003', label: '姓名' },
  { visible: true, prop: 'ml004', label: '年度' },
  { visible: true, prop: 'ml005', label: '总分' },
  { visible: true, prop: 'ml006', label: '等级' },
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

//字典参数
var dictParams = [
  { dictType: "sql_attr_list" },
  { dictType: "sys_eval_grade" },
  { dictType: "sys_eval_items" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从绩效/routine_ehr_performance_ma表记录数据
function getList(){
  loading.value = true
  listRoutineEhrPerformanceMa(queryParams).then(res => {
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
    ml002: [{ required: true, message: "工号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ml003: [{ required: true, message: "姓名"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 年度 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 等级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_eval_grade: [],
    // 考核项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_eval_items: [],
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
    ml002: null,
    ml003: null,
    ml004: [],
    ml005: 0,
    ml006: [],
    remark: null,
  };
  routineEhrPerformanceSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'绩效'
  opertype.value = 1
  form.value.ml004= []
  form.value.ml005= 0
  form.value.ml006= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getRoutineEhrPerformanceMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '绩效'
      opertype.value = 2

      form.value = {
        ...data,
      }
      routineEhrPerformanceSlvList.value = res.data.routineEhrPerformanceSlvNav
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {

      form.value.routineEhrPerformanceSlvNav = routineEhrPerformanceSlvList.value
      if (form.value.id != undefined && opertype.value === 2) {
        updateRoutineEhrPerformanceMa(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addRoutineEhrPerformanceMa(form.value).then((res) => {
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
      return delRoutineEhrPerformanceMa(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<绩效.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/RoutineEhrPerformanceMa/export', { ...queryParams })
    })
}

/*********************绩效子表信息*************************/
const routineEhrPerformanceSlvList = ref([])
const checkedRoutineEhrPerformanceSlv = ref([])
const fullScreen = ref(false)
const drawer = ref(false)

/** 绩效序号 */
function rowRoutineEhrPerformanceSlvIndex({ row, rowIndex }) {
  row.index = rowIndex + 1;
}

/** 绩效添加按钮操作 */
function handleAddRoutineEhrPerformanceSlv() {
  let obj = {};
  //下面的代码自己设置默认值
  //obj.mm003 = null;
  //obj.mm004 = null;
  //obj.mm005 = null;
  //obj.mm006 = null;
  //obj.mm007 = null;
  //obj.mm008 = null;
  //obj.mm009 = null;
  //obj.mm010 = null;
  //obj.mm011 = null;
  //obj.mm012 = null;
  //obj.mm013 = null;
  //obj.mm014 = null;
  //obj.mm015 = null;
  //obj.mm016 = null;
  //obj.mm017 = null;
  //obj.mm018 = null;
  //obj.mm019 = null;
  //obj.mm020 = null;
  //obj.mm021 = null;
  //obj.isDeleted = null;
  //obj.remark = null;
  routineEhrPerformanceSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handleRoutineEhrPerformanceSlvSelectionChange(selection) {
  checkedRoutineEhrPerformanceSlv.value = selection.map(item => item.index)
}

/** 绩效删除按钮操作 */
function handleDeleteRoutineEhrPerformanceSlv() {
  if(checkedRoutineEhrPerformanceSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的绩效数据')
  } else {
    const RoutineEhrPerformanceSlvs = routineEhrPerformanceSlvList.value;
    const checkedRoutineEhrPerformanceSlvs = checkedRoutineEhrPerformanceSlv.value;
    routineEhrPerformanceSlvList.value = RoutineEhrPerformanceSlvs.filter(function(item) {
      return checkedRoutineEhrPerformanceSlvs.indexOf(item.index) == -1
    });
  }
}

/** 绩效详情 */
function rowClick(row) {
  const id = row.id || ids.value
  getRoutineEhrPerformanceMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      drawer.value = true
      routineEhrPerformanceSlvList.value = data.routineEhrPerformanceSlvNav
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