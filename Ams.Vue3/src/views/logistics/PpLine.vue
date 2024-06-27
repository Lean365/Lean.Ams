<!--
 * @Descripttion: (生产班组/pp_line)
 * @Author: (Lean365(Davis.Ching))
 * @Date: (2024-06-27)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['ppline:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['ppline:import']">
          <el-button type="primary" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpLine/importTemplate"
                  importUrl="/Logistics/PpLine/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table
      :data="dataList"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      >
      <el-table-column prop="plSFID" label="SFID" align="center" v-if="columns.showColumn('plSFID')"/>
      <el-table-column prop="plLineType" label="班组类别" align="center" v-if="columns.showColumn('plLineType')">
        <template #default="scope">
          <dict-tag :options=" options.plLineTypeOptions" :value="scope.row.plLineType"  />
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
      <el-table-column label="操作" width="160">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" title="编辑" v-hasPermi="['ppline:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" icon="delete" title="删除" v-hasPermi="['ppline:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="plSFID">
              <el-input v-model.number="form.plSFID" placeholder="请输入SFID" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组类别" prop="plLineType">
              <el-select v-model="form.plLineType"  placeholder="请选择班组类别">
                <el-option
                  v-for="item in options.plLineTypeOptions" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组代码" prop="plLineCode">
              <el-input v-model="form.plLineCode" placeholder="请输入班组代码" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="语言Key" prop="plLineLangCode">
              <el-input v-model="form.plLineLangCode" placeholder="请输入语言Key" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="班组名称" prop="plLineName">
              <el-input v-model="form.plLineName" placeholder="请输入班组名称" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.isDeletedOptions" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" placeholder="请输入备注"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" placeholder="请输入创建者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker
                v-model="form.createTime"
                type="datetime"
                placeholder="选择日期时间"
                value-format="YYYY-MM-DD HH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" placeholder="请输入更新者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker
                v-model="form.updateTime"
                type="datetime"
                placeholder="选择日期时间"
                value-format="YYYY-MM-DD HH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ppline">
import { listPpLine,
 addPpLine, delPpLine, 
 updatePpLine,getPpLine, 
 } 
from '@/api/logistics/ppline.js'
import importData from '@/components/ImportData'
const { proxy } = getCurrentInstance()
const ids = ref([])
const loading = ref(false)
const showSearch = ref(true)
const queryParams = reactive({
  pageNum: 1,
  pageSize: 10,
  sort: '',
  sortType: 'asc',
})
const columns = ref([
  { visible: true, align: 'center', type: '', prop: 'plSFID', label: 'SFID'   },
  { visible: true, align: 'center', type: 'dict', prop: 'plLineType', label: '班组类别'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'plLineCode', label: '班组代码'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'plLineLangCode', label: '语言Key'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'plLineName', label: '班组名称'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'remark', label: '备注'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'createBy', label: '创建者'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'createTime', label: '创建时间'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'updateBy', label: '更新者'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'updateTime', label: '更新时间'  ,showOverflowTooltip: true  },
  //{ visible: false, prop: 'actions', label: '操作', type: 'slot', width: '160' }
])
const total = ref(0)
const dataList = ref([])
const queryRef = ref()
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]


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
const formRef = ref()
const title = ref('')
// 操作类型 1、add 2、edit 3、view
const opertype = ref(0)
const open = ref(false)
const state = reactive({
  single: true,
  multiple: true,
  form: {},
  rules: {
    plSFID: [{ required: true, message: "SFID不能为空", trigger: "blur"    , type: "number"  }],
    plLineType: [{ required: true, message: "班组类别不能为空", trigger: "change"     }],
    plLineCode: [{ required: true, message: "班组代码不能为空", trigger: "blur"     }],
    plLineLangCode: [{ required: true, message: "语言Key不能为空", trigger: "blur"     }],
    plLineName: [{ required: true, message: "班组名称不能为空", trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除不能为空", trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 班组类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
plLineTypeOptions: [],
  }
})

const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    plSFID: null,
    plLineType: null,
    plLineCode: null,
    plLineLangCode: null,
    plLineName: null,
    isDeleted: null,
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
  title.value = '添加生产班组'
  opertype.value = 1
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.plSFID || ids.value
  getPpLine(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = '修改生产班组'
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
          proxy.$modal.msgSuccess("修改成功")
          open.value = false
          getList()
        })
      } else {
        addPpLine(form.value).then((res) => {
            proxy.$modal.msgSuccess("新增成功")
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
    .$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？', "警告", {
      confirmButtonText: proxy.$t('common.ok'),
      cancelButtonText: proxy.$t('common.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpLine(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess("删除成功")
    })
}


// 导入数据成功处理
const handleFileSuccess = (response) => {
  const { item1, item2 } = response.data
  var error = ''
  item2.forEach((item) => {
    error += item.storageMessage + ','
  })
  proxy.$alert(item1 + '<p>' + error + '</p>', '导入结果', {
    dangerouslyUseHTMLString: true
  })
  getList()
}


handleQuery()
</script>