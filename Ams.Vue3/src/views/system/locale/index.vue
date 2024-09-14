<!--
 * @Descripttion: (多语言配置/)
 * @version: (1.0)
 * @Author: (zr)
 * @Date: (2022-05-06)
 * @LastEditors: (zr)
 * @LastEditTime: (2022-5-14)
-->
<template>
  <div class="app-container">
    <!-- :model属性用于表单验证使用 比如下面的el-form-item 的 prop属性用于对表单值进行验证操作 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-row :gutter="20">
        <el-col :lg="24">
          <!-- <el-form-item :label="$t('plang.language')" prop="langCode">
            <el-select v-model="queryParams.langCode"
              :placeholder="$t('btn.selectSearchPrefix')+$t('plang.language')+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in options.sys_lang_type" :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue"></el-option>
            </el-select>
          </el-form-item> -->
          <el-form-item :label="$t('plang.languageKey')" prop="langKey">
            <el-input v-model="queryParams.langKey"
              :placeholder="$t('btn.selectSearchPrefix')+$t('plang.languageKey')+$t('btn.selectSearchSuffix')" />
          </el-form-item>

          <!-- <el-form-item :label="$t('common.tipCreateTime')">
            <el-date-picker v-model="dateRangeAddtime" style="width: 240px" type="daterange" range-separator="-"
              :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
              value-format="YYYY-MM-DD HH:mm:ss" :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item> -->
          <el-form-item :label="$t('plang.showWay')">
            <el-radio-group v-model="queryParams.showMode">
              <el-radio-button value="1">{{$t('btn.grid')}}</el-radio-button>
              <el-radio-button value="2">{{$t('btn.transpose')}}</el-radio-button>
            </el-radio-group>
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
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['system:lang:add']" plain icon="plus" @click="handleAdd">{{
          $t('btn.add')
          }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['system:lang:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['system:lang:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['business:commonlang:import']">
          <el-button type="primary" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="system/locale/lang/importTemplate" importUrl="/system/locale/lang/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['system:lang:export']">{{
          $t('btn.export') }}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table v-if="queryParams.showMode == 1" :data="dataList" v-loading="loading" ref="table" height="620px" border
      highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />

      <!-- <el-table-column prop="id" label="id" align="center" /> -->
      <el-table-column prop="langCode" :label="$t('plang.language')" align="center">
        <template #default="scope">
          <dict-tag :options="options.sys_lang_type" :value="scope.row.langCode" />
        </template>
      </el-table-column>
      <el-table-column prop="langKey" :label="$t('plang.languageKey')" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="langName" :label="$t('plang.languageName')" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="createTime" :label="$t('common.tipCreateTime')" align="center"
        :show-overflow-tooltip="true" />

      <el-table-column :label="$t('btn.operation')" align="center" width="140">
        <template #default="scope">
          <el-button-group>
            <el-button v-hasPermi="['system:lang:edit']" type="success" plain size="small" icon="edit"
              :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
            <el-button v-hasPermi="['system:lang:delete']" type="danger" plain size="small" icon="delete"
              :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>

    <!-- 行列显示 -->
    <el-table v-if="queryParams.showMode == 2" :data="paginatedData" v-loading="loading" ref="table" border
      height="620px" highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange">
      <el-table-column prop="langKey" :label="$t('plang.languageKey')" align="center" :show-overflow-tooltip="true" />

      <el-table-column prop="zh-cn" :label="$t('plang.simplified')" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="zh-tw" :label="$t('plang.traditional')" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="ja" :label="$t('plang.japanese')" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="fr" :label="$t('plang.french')" align="center" :show-overflow-tooltip="true" />
      <el-table-column prop="en" :label="$t('plang.english')" align="center" :show-overflow-tooltip="true" />
      <el-table-column :label="$t('btn.operation')" align="center" width="140">
        <template #default="scope">
          <el-button-group>
            <el-button v-hasPermi="['system:lang:edit']" type="success" plain size="small" icon="edit"
              :title="$t('btn.edit')" @click="handleUpdateP(scope.row)">

            </el-button>
            <el-button v-hasPermi="['system:lang:delete']" type="danger" plain size="small" icon="delete"
              :title="$t('btn.delete')" @click="handleDeleteByKey(scope.row)">

            </el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>

    <pagination v-if="queryParams.showMode == 1" :total="total" v-model:page="queryParams.pageNum"
      v-model:limit="queryParams.pageSize" @pagination="getList" />
    <el-pagination v-if="queryParams.showMode == 2" @size-change="handleSizeChange"
      @current-change="handleCurrentChange" :current-page="currentPage" :page-size="pageSize"
      :page-sizes="[14, 28, 56, 112, 224]" :total="dataList.length" layout="->,total, sizes, prev, pager, next, jumper">
    </el-pagination>
    <!-- 添加或修改多语言配置对话框 -->
    <el-dialog :title=" title" :lock-scroll="false" v-model="open" width="550px">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-row :gutter="20">
          <el-col :lg="24">
            <el-form-item prop="langKey">
              <template #label>
                <span>
                  <el-tooltip :content="$t('plang.langKeycontent')" placement="top">
                    <el-icon :size="15">
                      <questionFilled />
                    </el-icon>
                  </el-tooltip>
                </span>
                {{ $t('plang.languageKey') }}
              </template>
              <el-input v-model="form.langKey"
                :placeholder="$t('btn.enterPrefix')+$t('plang.language')+$t('btn.enterSuffix')" show-word-limit
                maxlength="80" />
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-table :data="form.langList">
            <el-table-column :label="$t('plang.language')" align="center" prop="langCode" width="150">
              <template #default="scope">
                {{ scope.row.label }} <br />
                {{ scope.row.langCode }}

              </template>
            </el-table-column>
            <el-table-column :label="$t('plang.languageName')" align="center">
              <template #default="scope">
                <el-input type="textarea" rows="2" prop="langName" v-model="scope.row.langName" show-word-limit
                  maxlength="200"></el-input>
              </template>
            </el-table-column>
          </el-table>
        </el-row>
      </el-form>
      <template #footer>
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="commonlang">
  import {
    listLocaleLang,
    delLocaleLang,
    updateLocaleLang,
    getLocaleLang,
    exportLocaleLang,
    getLocaleLangByKey,
    delLocaleLangByKey
  } from '@/api/system/locale.js'
  import { isEmpty } from '@/utils/ruoyi.js'
  import importData from '@/components/ImportData'
  const { proxy } = getCurrentInstance()
  // 选中id数组数组
  const ids = ref([])
  // 非单选禁用
  const single = ref(true)
  // 非多个禁用
  const multiple = ref(true)
  // 遮罩层
  const loading = ref(false)
  // 显示搜索条件
  const showSearch = ref(true)
  // 查询参数
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 14,
    sort: undefined,
    sortType: undefined,
    langCode: undefined,
    langKey: undefined,
    createTime: undefined,
    showMode: 2 // 显示模式 1、table显示 2、行列显示
  })
  const currentPage = ref(1)
  const pageSize = ref(14)
  const paginatedData = computed(() => {
    const start = (currentPage.value - 1) * pageSize.value
    const end = start + pageSize.value
    return dataList.value.slice(start, end)
  })

  const handleCurrentChange = (newPage) => {
    currentPage.value = newPage
  }

  const handleSizeChange = (newSize) => {
    pageSize.value = newSize
  }
  // 弹出层标题
  const title = ref('')
  // 操作类型 1、add 2、edit
  const opertype = ref(0)
  // 是否显示弹出层
  const open = ref(false)
  // 表单参数
  const state = reactive({
    form: {},
    rules: {
      id: [{ required: true, message: 'id ' + proxy.$t('btn.isEmpty'), trigger: 'blur', type: 'number' }],
      // langCode: [{ required: true, message: '语言code不能为空', trigger: 'change' }],
      langKey: [
        { pattern: /^[A-Za-z].+$/, message: proxy.$t('common.tipInputLangKeyError'), trigger: 'blur' },
        { required: true, message: proxy.$t('plang.languageKey') + proxy.$t('btn.isEmpty'), trigger: 'change' }
      ],


      langName: [{ required: true, message: proxy.$t('plang.languageName') + proxy.$t('btn.isEmpty'), trigger: 'blur' }]
    },
    options: {}
  })

  var dictParams = [{ dictType: 'sys_lang_type' }]
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  const { form, rules, options } = toRefs(state)
  // 总记录数
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const formRef = ref()
  // 语言code选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
  const sys_lang_type = ref([])
  // 添加时间时间范围
  //const dateRangeAddtime = ref([])

  watch(
    () => queryParams.showMode,
    () => {
      getList()
    },
    { immediate: true }
  )
  function getList() {
    proxy.addDateRange(queryParams)//, proxy.dateRangeAddtime, 'CreateTime')
    loading.value = true
    listLocaleLang(queryParams).then((res) => {
      if (res.code == 200) {
        dataList.value = res.data.result
        total.value = res.data.totalNum
        loading.value = false
      }
    })
  }

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      langKey: undefined,
      langList: [
        {
          langCode: 'zh-cn',
          label: proxy.$t('plang.simplified'),
          langName: undefined,
        },
        {
          langCode: 'zh-tw',
          label: proxy.$t('plang.traditional'),
          langName: undefined
        },
        {
          langCode: 'ja',
          label: proxy.$t('plang.japanese'),
          langName: undefined
        },
        {
          langCode: 'fr',
          label: proxy.$t('plang.french'),
          langName: undefined
        },
        {
          langCode: 'en',
          label: proxy.$t('plang.english'),
          langName: undefined
        }
      ]
    }
    proxy.resetForm('formRef')
  }

  // 查询
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }

  // 添加
  function handleAdd() {
    reset()
    open.value = true
    title.value = proxy.$t('btn.add')
    opertype.value = 1
  }

  // 删除按钮操作
  function handleDelete(row) {
    const Ids = row.id || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delLocaleLang(Ids)
      })
      .then(() => {
        handleQuery()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
      .catch(() => { })
  }

  function handleDeleteByKey(row) {
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + row.langKey + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delLocaleLangByKey(row.langKey)
      })
      .then(() => {
        handleQuery()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }

  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getLocaleLang(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit')
        opertype.value = 2

        form.value = {
          ...data
        }
      }
    })
  }
  function handleUpdateP(row) {
    reset()
    getLocaleLangByKey(row.langKey).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit')
        opertype.value = 2

        form.value = {
          ...data
        }
      }
    })
  }

  // 表单提交
  function submitForm() {
    const formValid = ref(true)
    form.value.langList.forEach((item) => {
      if (isEmpty(item.langName)) {
        formValid.value = false
      }
    })
    if (!formValid.value) {
      proxy.$modal.msgError(proxy.$t('common.tipInputcontentError'))
      return
    }
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        updateLocaleLang(form.value)
          .then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipOperationSucceed'))
            open.value = false
            getList()
          })
          .catch(() => { })
      }
    })
  }

  // 重置查询操作
  function resetQuery() {
    // 添加时间时间范围
    //dateRangeAddtime.value = []
    proxy.resetForm('queryRef')
    handleQuery()
  }
  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm(proxy.$t('common.tipConfirmExport') + "<LocaleLang.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return exportLocaleLang(queryParams)
      })
      .then((response) => {
        proxy.download(response.data.path)
      })
  }

  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.id)
    single.value = selection.length != 1
    multiple.value = !selection.length
  }

  // 自定义排序
  function sortChange(column) {
    if (column.prop == null || column.order == null) {
      queryParams.sort = undefined
      queryParams.sortType = undefined
    } else {
      queryParams.sort = column.prop
      queryParams.sortType = column.order
    }

    handleQuery()
  }
  // 导入数据成功处理
  const handleFileSuccess = (response) => {
    const { item1, item2 } = response.data
    var error = ''
    item2.forEach((item) => {
      error += item.storageMessage + ','
    })
    proxy.$alert(item1 + '<p>' + error + '</p>', proxy.$t('common.tipImportResults'), {
      dangerouslyUseHTMLString: true
    })
    getList()
  }

  handleQuery()
  reset()
</script>

<style>
  /* 左对齐表单项 */
  .item-left-align .el-form-item__label {
    text-align: right;
  }
</style>