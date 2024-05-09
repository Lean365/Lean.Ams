<!--
 * @Descripttion: 生产班组/pp_line
 * @Version: 0.24.495.26722
 * @Author: Lean365(Davis.Ching)(Davis.Ching)
 * @Date: 2024/5/9 15:07:59
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="班组类别" prop="plLineType">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod" :loading="loading " v-model="queryParams.plLineType" :placeholder="$t('btn.select')+'班组类别'">
          <el-option v-for="item in   remotequery_sys_line_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="班组代码" prop="plLineCode">
        <el-input v-model="queryParams.plLineCode" :placeholder="$t('btn.enter')+'班组代码'" />
      </el-form-item>
      <el-form-item label="班组名称" prop="plLineName">
        <el-input v-model="queryParams.plLineName" :placeholder="$t('btn.enter')+'班组名称'" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:line:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:line:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:line:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:line:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="logistics/PpLine/importTemplate"
                  importUrl="/logistics/PpLine/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:line:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="650"
      :data="dataList"
      v-loading="loading"
      ref="table"
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="plSFID" label="SFID" align="center" v-if="columns.showColumn('plSFID')"/>
      <el-table-column prop="plLineType" label="班组类别" align="center" v-if="columns.showColumn('plLineType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_line_type " :value="scope.row.plLineType"  />
        </template>
      </el-table-column>
      <el-table-column prop="plLineCode" label="班组代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('plLineCode')"/>
      <el-table-column prop="plLineLangCode" label="语言Key" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('plLineLangCode')"/>
      <el-table-column prop="plLineName" label="班组名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('plLineName')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button type="success" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:line:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:line:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改生产班组对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="plSFID">
              <el-input v-model.number="form.plSFID" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组类别" prop="plLineType">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod" 
              :loading="loading " v-model="form.plLineType"  :placeholder="$t('btn.select')+'班组类别'">
                <el-option
                  v-for="item in  remotequery_sys_line_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="班组代码" prop="plLineCode">
              <el-input v-model="form.plLineCode" :placeholder="$t('btn.enter')+'班组代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="语言Key" prop="plLineLangCode">
              <el-input v-model="form.plLineLangCode" :placeholder="$t('btn.enter')+'语言Key'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组名称" prop="plLineName">
              <el-input v-model="form.plLineName" :placeholder="$t('btn.enter')+'班组名称'" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
</el-tab-pane>


          <el-tab-pane :label="$t('ptabs.Onboarding')" name="second">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.annex')" name="fourth">
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
          <el-tab-pane :label="$t('ptabs.sale')" name="tenth">
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
          <el-tab-pane :label="$t('ptabs.customization')" name="14th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="15th">
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

<script setup name="ppline">
//后台操作函数
import { listPpLine,
 addPpLine, delPpLine, 
 updatePpLine,getPpLine, 
 } 
from '@/api/logistics/ppline.js'
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
  pageSize: 50,
  sort: '',
  sortType: 'asc',
//是否查询（1是）
  plLineType: undefined,
//是否查询（1是）
  plLineCode: undefined,
//是否查询（1是）
  plLineName: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'plSFID', label: 'SFID' },
  { visible: true, prop: 'plLineType', label: '班组类别' },
  { visible: true, prop: 'plLineCode', label: '班组代码' },
  { visible: true, prop: 'plLineLangCode', label: '语言Key' },
  { visible: true, prop: 'plLineName', label: '班组名称' },
  { visible: true, prop: 'remark', label: '备注' },
  { visible: true, prop: 'createBy', label: '创建者' },
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



//定义远程搜索变量
const remotequeryList=ref([])
//定义远程搜索变量
const remotequery_sys_line_type=ref([])

  //远程字典参数
  var remotedictParams = [

    { dictType: "sys_line_type" },

  ]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams).then((response) => {
      response.data.forEach((element) => {
        remotequeryList.value = element.list
      })
      //console.log(remotequeryList)
    })
  })
//远程搜索
const remoteMethod = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sys_line_type.value = remotequeryList.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sys_line_type.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod = debounce((query) => {
    let arr = remotequeryList.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sys_line_type.value = arr.slice(0, 5)
      addFilterOptions(query)
    } else {
      remotequery_sys_line_type.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions =debounce((dictValue) => {
    let target = remotequeryList.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sys_line_type.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sys_line_type.value.toLowerCase().unshift(target)
      }
    }
  }, 300)










//字典参数
var dictParams = [
  { dictType: "sys_line_type" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从生产班组/pp_line表记录数据
function getList(){
  loading.value = true
  listPpLine(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.plSFID);
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
    plSFID: [{ required: true, message: "SFID不能为空", trigger: "blur" }],
    plLineType: [{ required: true, message: "班组类别不能为空", trigger: "blur"     }],
    plLineCode: [{ required: true, message: "班组代码不能为空", trigger: "blur"     }],
    plLineLangCode: [{ required: true, message: "语言Key不能为空", trigger: "blur"     }],
    plLineName: [{ required: true, message: "班组名称不能为空", trigger: "blur"     }],
  },
  options: {
    // 班组类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_line_type: [],
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
    plSFID: 0,
    plSFID: null,
    plLineType: null,
    plLineType: null,
    plLineCode: null,
    plLineCode: null,
    plLineLangCode: null,
    plLineLangCode: null,
    plLineName: null,
    plLineName: null,
    isDeleted: 0,
    isDeleted: null,
    remark: null,
    remark: null,
    createBy: null,
    createBy: null,
    createTime: null,
    createTime: null,
    updateBy: null,
    updateBy: null,
    updateTime: null,
    updateTime: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+'生产班组'
  opertype.value = 1
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.plSFID || ids.value
  getPpLine(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+ '生产班组'
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

      if (form.value.plSFID != undefined && opertype.value === 2) {
        updatePpLine(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addPpLine(form.value).then((res) => {
             proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.plSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'), proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpLine(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
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
    .$confirm(proxy.$t('common.confirmExport')+"生产班组", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/logistics/PpLine/export', { ...queryParams })
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