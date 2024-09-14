<!--
 * @Descripttion: 检查明细/pp_insp_pcba_slv
 * @Version: 0.24.621.29885
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/12 16:38:55
 * @column：47
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="parentId" label="父ID" align="center" v-if="columns.showColumn('parentId')"/>
      <el-table-column prop="mv003" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mv003')"/>
      <el-table-column prop="mv004" label="Lot数" align="center" v-if="columns.showColumn('mv004')"/>
      <el-table-column prop="mv005" label="板别" align="center" v-if="columns.showColumn('mv005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_type " :value="scope.row.mv005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mv006" label="目视线别" align="center" v-if="columns.showColumn('mv006')">
        <template #default="scope">
          <dict-tag :options=" options.sys_visual_type " :value="scope.row.mv006"  />
        </template>
      </el-table-column>
      <el-table-column prop="mv007" label="AOI线别" align="center" v-if="columns.showColumn('mv007')">
        <template #default="scope">
          <dict-tag :options=" options.sys_aoi_type " :value="scope.row.mv007"  />
        </template>
      </el-table-column>
      <el-table-column prop="mv008" label="B面实装" :show-overflow-tooltip="true"  v-if="columns.showColumn('mv008')"/>
      <el-table-column prop="mv009" label="T面实装" :show-overflow-tooltip="true"  v-if="columns.showColumn('mv009')"/>
      <el-table-column prop="mv010" label="生产班别" align="center" v-if="columns.showColumn('mv010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_shifts_list " :value="scope.row.mv010"  />
        </template>
      </el-table-column>
      <el-table-column prop="mv011" label="检查员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mv011')"/>
      <el-table-column prop="mv012" label="当日完成数" align="center" v-if="columns.showColumn('mv012')"/>
      <el-table-column prop="mv013" label="累计完成数" align="center" v-if="columns.showColumn('mv013')"/>
      <el-table-column prop="mv014" label="检查台数" align="center" v-if="columns.showColumn('mv014')"/>
      <el-table-column prop="mv015" label="检查状态" align="center" v-if="columns.showColumn('mv015')">
        <template #default="scope">
          <dict-tag :options=" options.sql_smt_status " :value="scope.row.mv015"  />
        </template>
      </el-table-column>
      <el-table-column prop="mv016" label="生产线别" align="center" v-if="columns.showColumn('mv016')">
        <template #default="scope">
          <dict-tag :options=" options.sql_smt_line " :value="scope.row.mv016"  />
        </template>
      </el-table-column>
      <el-table-column prop="mv017" label="检查工数" align="center" v-if="columns.showColumn('mv017')"/>
      <el-table-column prop="mv018" label="AOI工数" align="center" v-if="columns.showColumn('mv018')"/>
      <el-table-column prop="mv019" label="不良数量" align="center" v-if="columns.showColumn('mv019')"/>
      <el-table-column prop="mv020" label="手贴部品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mv020')"/>
      <el-table-column prop="mv021" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mv021')"/>
      <el-table-column prop="mv022" label="内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mv022')"/>
      <el-table-column prop="mv023" label="个所区分" align="center" v-if="columns.showColumn('mv023')">
        <template #default="scope">
          <dict-tag :options=" options.sql_pcb_place " :value="scope.row.mv023"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
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

    <!-- 添加或修改检查明细对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="parentId">
              <el-input v-model.number="form.parentId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="mv003">
              <el-input   v-model="form.mv003" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="Lot数" prop="mv004">
              <el-input-number v-model.number="form.mv004" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Lot数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="板别" prop="mv005">
              <el-select filterable clearable   v-model="form.mv005"  :placeholder="$t('btn.selectPrefix')+'板别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="目视线别" prop="mv006">
              <el-select filterable clearable   v-model="form.mv006"  :placeholder="$t('btn.selectPrefix')+'目视线别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_visual_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="AOI线别" prop="mv007">
              <el-select filterable clearable   v-model="form.mv007"  :placeholder="$t('btn.selectPrefix')+'AOI线别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_aoi_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="B面实装" prop="mv008">
              <el-date-picker v-model="form.mv008" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="T面实装" prop="mv009">
              <el-date-picker v-model="form.mv009" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产班别" prop="mv010">
              <el-select filterable clearable   v-model="form.mv010"  :placeholder="$t('btn.selectPrefix')+'生产班别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_shifts_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检查员" prop="mv011">
              <el-input   v-model="form.mv011" :placeholder="$t('btn.enterPrefix')+'检查员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当日完成数" prop="mv012">
              <el-input-number v-model.number="form.mv012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当日完成数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="累计完成数" prop="mv013">
              <el-input-number v-model.number="form.mv013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'累计完成数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检查台数" prop="mv014">
              <el-input-number v-model.number="form.mv014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查台数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查状态" prop="mv015">
              <el-select filterable clearable   v-model="form.mv015"  :placeholder="$t('btn.selectPrefix')+'检查状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_smt_status" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="生产线别" prop="mv016">
              <el-select filterable clearable   v-model="form.mv016"  :placeholder="$t('btn.selectPrefix')+'生产线别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_smt_line" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="检查工数" prop="mv017">
              <el-input-number v-model.number="form.mv017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="AOI工数" prop="mv018">
              <el-input-number v-model.number="form.mv018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'AOI工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="不良数量" prop="mv019">
              <el-input-number v-model.number="form.mv019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不良数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="手贴部品" prop="mv020">
              <el-input   v-model="form.mv020" :placeholder="$t('btn.enterPrefix')+'手贴部品'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="mv021">
              <el-input   v-model="form.mv021" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内容" prop="mv022">
              <el-input   v-model="form.mv022" :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="个所区分" prop="mv023">
              <el-select filterable clearable   v-model="form.mv023"  :placeholder="$t('btn.selectPrefix')+'个所区分'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_pcb_place" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
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
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'mv003', label: '批次' },
  { visible: true, prop: 'mv004', label: 'Lot数' },
  { visible: true, prop: 'mv005', label: '板别' },
  { visible: true, prop: 'mv006', label: '目视线别' },
  { visible: true, prop: 'mv007', label: 'AOI线别' },
  { visible: true, prop: 'mv008', label: 'B面实装' },
  { visible: false, prop: 'mv009', label: 'T面实装' },
  { visible: false, prop: 'mv010', label: '生产班别' },
  { visible: false, prop: 'mv011', label: '检查员' },
  { visible: false, prop: 'mv012', label: '当日完成数' },
  { visible: false, prop: 'mv013', label: '累计完成数' },
  { visible: false, prop: 'mv014', label: '检查台数' },
  { visible: false, prop: 'mv015', label: '检查状态' },
  { visible: false, prop: 'mv016', label: '生产线别' },
  { visible: false, prop: 'mv017', label: '检查工数' },
  { visible: false, prop: 'mv018', label: 'AOI工数' },
  { visible: false, prop: 'mv019', label: '不良数量' },
  { visible: false, prop: 'mv020', label: '手贴部品' },
  { visible: false, prop: 'mv021', label: '序列号' },
  { visible: false, prop: 'mv022', label: '内容' },
  { visible: false, prop: 'mv023', label: '个所区分' },
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
//API获取从检查明细/pp_insp_pcba_slv表记录数据
function getList(){
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
    mv004: [{ required: true, message: "Lot数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mv012: [{ required: true, message: "当日完成数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mv013: [{ required: true, message: "累计完成数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mv014: [{ required: true, message: "检查台数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mv017: [{ required: true, message: "检查工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mv018: [{ required: true, message: "AOI工数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mv019: [{ required: true, message: "不良数量"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
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
    parentId: 0,
    mv003: null,
    mv004: 0,
    mv005: [],
    mv006: [],
    mv007: [],
    mv008: null,
    mv009: null,
    mv010: [],
    mv011: null,
    mv012: 0,
    mv013: 0,
    mv014: 0,
    mv015: [],
    mv016: [],
    mv017: 0,
    mv018: 0,
    mv019: 0,
    mv020: null,
    mv021: null,
    mv022: null,
    mv023: [],
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'检查明细'
  opertype.value = 1
  form.value.mv004= 0
  form.value.mv005= []
  form.value.mv006= []
  form.value.mv007= []
  form.value.mv008= new Date()
  form.value.mv009= new Date()
  form.value.mv010= []
  form.value.mv012= 0
  form.value.mv013= 0
  form.value.mv014= 0
  form.value.mv015= []
  form.value.mv016= []
  form.value.mv017= 0
  form.value.mv018= 0
  form.value.mv019= 0
  form.value.mv023= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpInspPcbaSlv(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '检查明细'
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
  const Ids = row.id || ids.value

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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<检查明细.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
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