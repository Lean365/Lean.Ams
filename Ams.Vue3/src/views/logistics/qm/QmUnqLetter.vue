<!--
 * @Descripttion: 不合格联络/qm_unq_letter
 * @Version: 0.24.620.29565
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 16:41:22
 * @column：41
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="ml002">
        <el-select filterable clearable   v-model="queryParams.ml002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检查员" prop="ml003">
        <el-select filterable clearable   v-model="queryParams.ml003" :placeholder="$t('btn.selectSearchPrefix')+'检查员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_insp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="班组" prop="ml004">
        <el-select filterable clearable   v-model="queryParams.ml004" :placeholder="$t('btn.selectSearchPrefix')+'班组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_line_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="订单" prop="ml005">
        <el-input v-model="queryParams.ml005" :placeholder="$t('btn.enterSearchPrefix')+'订单'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="ml006">
        <el-input v-model="queryParams.ml006" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="ml007">
        <el-input v-model="queryParams.ml007" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="仕向" prop="ml008">
        <el-input v-model="queryParams.ml008" :placeholder="$t('btn.enterSearchPrefix')+'仕向'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="查验日期">
        <el-date-picker
          v-model="dateRangeMl009" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="级别" prop="ml013">
        <el-select filterable clearable   v-model="queryParams.ml013" :placeholder="$t('btn.selectSearchPrefix')+'级别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_bad " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['qm:unqletter:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:unqletter:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:unqletter:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:unqletter:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmUnqLetter/importTemplate"
                  importUrl="/Logistics/QmUnqLetter/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:unqletter:export']">
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
      <el-table-column prop="ml002" label="工厂" align="center" v-if="columns.showColumn('ml002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.ml002"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml003" label="检查员" align="center" v-if="columns.showColumn('ml003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_list " :value="scope.row.ml003"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml004" label="班组" align="center" v-if="columns.showColumn('ml004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.ml004"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml005" label="订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml005')"/>
      <el-table-column prop="ml006" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml006')"/>
      <el-table-column prop="ml007" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml007')"/>
      <el-table-column prop="ml008" label="仕向" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml008')"/>
      <el-table-column prop="ml009" label="查验日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ml009')"/>
      <el-table-column prop="ml010" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml010')"/>
      <el-table-column prop="ml011" label="序号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml011')"/>
      <el-table-column prop="ml012" label="验退数" align="center" v-if="columns.showColumn('ml012')"/>
      <el-table-column prop="ml013" label="级别" align="center" v-if="columns.showColumn('ml013')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_bad " :value="scope.row.ml013"  />
        </template>
      </el-table-column>
      <el-table-column prop="ml014" label="判定说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml014')"/>
      <el-table-column prop="ml015" label="发行号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml015')"/>
      <el-table-column prop="ml016" label="附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ml016')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="werks" label="工厂" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('werks')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:unqletter:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:unqletter:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改不合格联络对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂" prop="ml002">
              <el-select filterable clearable   v-model="form.ml002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检查员" prop="ml003">
              <el-select filterable clearable   v-model="form.ml003"  :placeholder="$t('btn.selectPrefix')+'检查员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="班组" prop="ml004">
              <el-select filterable clearable   v-model="form.ml004"  :placeholder="$t('btn.selectPrefix')+'班组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_line_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="订单" prop="ml005">
              <el-input   v-model="form.ml005" :placeholder="$t('btn.enterPrefix')+'订单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="ml006">
              <el-input   v-model="form.ml006" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="ml007">
              <el-input   v-model="form.ml007" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仕向" prop="ml008">
              <el-input   v-model="form.ml008" :placeholder="$t('btn.enterPrefix')+'仕向'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="查验日期" prop="ml009">
              <el-date-picker v-model="form.ml009" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="ml010">
              <el-input   v-model="form.ml010" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序号" prop="ml011">
              <el-input   v-model="form.ml011" :placeholder="$t('btn.enterPrefix')+'序号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="验退数" prop="ml012">
              <el-input-number v-model.number="form.ml012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验退数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="级别" prop="ml013">
              <el-select filterable clearable   v-model="form.ml013"  :placeholder="$t('btn.selectPrefix')+'级别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_bad" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="判定说明" prop="ml014">
              <el-input type="textarea" v-model="form.ml014" :placeholder="$t('btn.enterPrefix')+'判定说明'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行号码" prop="ml015">
              <el-input   v-model="form.ml015" :placeholder="$t('btn.enterPrefix')+'发行号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="附件" prop="ml016">
              <UploadFile v-model="form.ml016" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="werks">
              <el-input   v-model="form.werks" :placeholder="$t('btn.enterPrefix')+'工厂'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
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

<script setup name="qmunqletter">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmUnqLetter,
 addQmUnqLetter, delQmUnqLetter, 
 updateQmUnqLetter,getQmUnqLetter, 
 } 
from '@/api/logistics/qmunqletter.js'
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
  sort: 'Ml009',
  sortType: 'desc',
  //是否查询（1是）
  ml002: undefined,
  //是否查询（1是）
  ml003: undefined,
  //是否查询（1是）
  ml004: undefined,
  //是否查询（1是）
  ml005: undefined,
  //是否查询（1是）
  ml006: undefined,
  //是否查询（1是）
  ml007: undefined,
  //是否查询（1是）
  ml008: undefined,
  //是否查询（1是）
  ml009: undefined,
  //是否查询（1是）
  ml013: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'ml002', label: '工厂' },
  { visible: true, prop: 'ml003', label: '检查员' },
  { visible: true, prop: 'ml004', label: '班组' },
  { visible: true, prop: 'ml005', label: '订单' },
  { visible: true, prop: 'ml006', label: '机种' },
  { visible: true, prop: 'ml007', label: '物料' },
  { visible: true, prop: 'ml008', label: '仕向' },
  { visible: false, prop: 'ml009', label: '查验日期' },
  { visible: false, prop: 'ml010', label: '批次' },
  { visible: false, prop: 'ml011', label: '序号' },
  { visible: false, prop: 'ml012', label: '验退数' },
  { visible: false, prop: 'ml013', label: '级别' },
  { visible: false, prop: 'ml014', label: '判定说明' },
  { visible: false, prop: 'ml015', label: '发行号码' },
  { visible: false, prop: 'ml016', label: '附件' },
  { visible: false, prop: 'remark', label: '备注说明' },
  { visible: false, prop: 'werks', label: '工厂' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
// 查验日期时间范围
const dateRangeMl009 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sql_insp_list" },
  { dictType: "sql_line_list" },
  { dictType: "sys_insp_bad" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从不合格联络/qm_unq_letter表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMl009.value, 'Ml009');
  loading.value = true
  listQmUnqLetter(queryParams).then(res => {
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
  // 查验日期时间范围
  dateRangeMl009.value = []
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
    ml002: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ml007: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ml009: [{ required: true, message: "查验日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ml012: [{ required: true, message: "验退数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 检查员 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_insp_list: [],
    // 班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_list: [],
    // 级别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_bad: [],
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
    ml002: [],
    ml003: [],
    ml004: [],
    ml005: null,
    ml006: null,
    ml007: null,
    ml008: null,
    ml009: null,
    ml010: null,
    ml011: null,
    ml012: 0,
    ml013: [],
    ml014: null,
    ml015: null,
    ml016: null,
    remark: null,
    werks: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'不合格联络'
  opertype.value = 1
  form.value.ml002= []
  form.value.ml003= []
  form.value.ml004= []
  form.value.ml009= new Date()
  form.value.ml012= 0
  form.value.ml013= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getQmUnqLetter(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '不合格联络'
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
        updateQmUnqLetter(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmUnqLetter(form.value).then((res) => {
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
      return delQmUnqLetter(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<不合格联络.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmUnqLetter/export', { ...queryParams })
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