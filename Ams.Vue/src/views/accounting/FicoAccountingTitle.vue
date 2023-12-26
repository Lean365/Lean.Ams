<!--
 * @Descripttion: (会计科目/fico_accounting_title)
 * @Version: (0.23.360.13974)
 * @Author: (Lean365)
 * @Date: (2023/12/26 7:53:53)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="公司名称" prop="ftCorpCode">
        <el-select clearable  v-model="queryParams.ftCorpCode" placeholder="请选择公司名称">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目代码" prop="ftTitleCode">
        <el-input v-model="queryParams.ftTitleCode" placeholder="请输入科目代码" />
      </el-form-item>
      <el-form-item label="科目名称" prop="ftTitleName">
        <el-input v-model="queryParams.ftTitleName" placeholder="请输入科目名称" />
      </el-form-item>
      <el-form-item label="语言" prop="ftTitleLang">
        <el-select clearable  v-model="queryParams.ftTitleLang" placeholder="请选择语言">
          <el-option v-for="item in  options.sys_lang_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['fico:accountingtitle:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:accountingtitle:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:accountingtitle:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:accountingtitle:import']">
          <el-button type="primary" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="accounting/FicoAccountingTitle/importTemplate"
                  importUrl="/accounting/FicoAccountingTitle/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:accountingtitle:export']">
          {{ $t('btn.export') }}
        </el-button>
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
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="ftSFID" label="SFID" align="center" v-if="columns.showColumn('ftSFID')"/>
      <el-table-column prop="ftCorpCode" label="公司名称" align="center" v-if="columns.showColumn('ftCorpCode')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.ftCorpCode"  />
        </template>
      </el-table-column>
      <el-table-column prop="ftTitleCode" label="科目代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ftTitleCode')"/>
      <el-table-column prop="ftTitleName" label="科目名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ftTitleName')"/>
      <el-table-column prop="ftTitleLang" label="语言" align="center" v-if="columns.showColumn('ftTitleLang')">
        <template #default="scope">
          <dict-tag :options=" options.sys_lang_type " :value="scope.row.ftTitleLang"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column label="操作" width="160">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" title="编辑" v-hasPermi="['fico:accountingtitle:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" icon="delete" title="删除" v-hasPermi="['fico:accountingtitle:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改会计科目对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="SFID" prop="ftSFID">
              <el-input-number v-model.number="form.ftSFID" controls-position="right" placeholder="请输入SFID" :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司名称" prop="ftCorpCode">
              <el-select v-model="form.ftCorpCode"  placeholder="请选择公司名称">
                <el-option
                  v-for="item in options.sys_crop_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目代码" prop="ftTitleCode">
              <el-input v-model="form.ftTitleCode" placeholder="请输入科目代码" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目名称" prop="ftTitleName">
              <el-input v-model="form.ftTitleName" placeholder="请输入科目名称" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="语言" prop="ftTitleLang">
              <el-select v-model="form.ftTitleLang"  placeholder="请选择语言">
                <el-option
                  v-for="item in options.sys_lang_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input v-model.number="form.isDeleted" placeholder="请输入软删除" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" placeholder="请输入说明"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" placeholder="请输入创建者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" placeholder="请输入更新者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" placeholder="选择日期时间"></el-date-picker>
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

<script setup name="ficoaccountingtitle">
import { listFicoAccountingTitle,
 addFicoAccountingTitle, delFicoAccountingTitle, 
 updateFicoAccountingTitle,getFicoAccountingTitle, 
 } 
from '@/api/accounting/ficoaccountingtitle.js'
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
  ftCorpCode: undefined,
  ftTitleCode: undefined,
  ftTitleName: undefined,
  ftTitleLang: undefined,
})
const columns = ref([
  { visible: true, prop: 'ftSFID', label: 'SFID' },
  { visible: true, prop: 'ftCorpCode', label: '公司名称' },
  { visible: true, prop: 'ftTitleCode', label: '科目代码' },
  { visible: true, prop: 'ftTitleName', label: '科目名称' },
  { visible: true, prop: 'ftTitleLang', label: '语言' },
  { visible: true, prop: 'remark', label: '说明' },
  { visible: true, prop: 'createTime', label: '创建时间' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'updateBy', label: '更新者' },
  { visible: false, prop: 'updateTime', label: '更新时间' },
])
const total = ref(0)
const dataList = ref([])
const queryRef = ref()
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_crop_list" },
  { dictType: "sys_lang_type" },
]

proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})

function getList(){
  loading.value = true
  listFicoAccountingTitle(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.ftSFID);
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
    ftSFID: [{ required: true, message: "SFID不能为空", trigger: "blur" }],
    ftCorpCode: [{ required: true, message: "公司名称不能为空", trigger: "change"     }],
    ftTitleCode: [{ required: true, message: "科目代码不能为空", trigger: "blur"     }],
    ftTitleName: [{ required: true, message: "科目名称不能为空", trigger: "blur"     }],
    ftTitleLang: [{ required: true, message: "语言不能为空", trigger: "change"     }],
  },
  options: {
    // 公司名称 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_crop_list: [],
    // 语言 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_lang_type: [],
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
    ftSFID: null,
    ftCorpCode: null,
    ftTitleCode: null,
    ftTitleName: null,
    ftTitleLang: null,
    isDeleted: null,
    remark: null,
    createTime: null,
    createBy: null,
    updateBy: null,
    updateTime: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = '添加会计科目'
  opertype.value = 1
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.ftSFID || ids.value
  getFicoAccountingTitle(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = '修改会计科目'
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

      if (form.value.ftSFID != undefined && opertype.value === 2) {
        updateFicoAccountingTitle(form.value).then((res) => {
          proxy.$modal.msgSuccess("修改成功")
          open.value = false
          getList()
        })
      } else {
        addFicoAccountingTitle(form.value).then((res) => {
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
  const Ids = row.ftSFID || ids.value

  proxy
    .$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？')
    .then(function () {
      return delFicoAccountingTitle(Ids)
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

// 导出按钮操作
function handleExport() {
  proxy
    .$confirm("是否确认导出会计科目数据项?", "警告", {
      confirmButtonText: "确定",
      cancelButtonText: "取消",
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/accounting/FicoAccountingTitle/export', { ...queryParams })
    })
}


handleQuery()
</script>