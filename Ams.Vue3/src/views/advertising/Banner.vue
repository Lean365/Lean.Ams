<!--
 * @Descripttion: (广告管理/banner_config)
 * @Author: (admin)
 * @Date: (2024-05-11)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="标题" prop="mb002">
        <el-input v-model="queryParams.mb002" placeholder="请输入标题" />
      </el-form-item>
      <el-form-item label="是否显示" prop="mb008">
        <el-radio-group v-model="queryParams.mb008">
          <el-radio :value="-1">{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_menu_show " :key="item.dictValue"
            :value="item.dictValue">{{item.dictLabel}}</el-radio>
          <!--  <el-radio-button>全部</el-radio-button> -->
          <!-- <el-radio-button v-for="item in options.sys_menu_show" :key="item.dictValue" :value="item.dictValue">{{ 
            item.dictLabel
            }}</el-radio-button> -->
        </el-radio-group>
      </el-form-item>
      <el-form-item label="广告类型" prop="mb009">
        <el-radio-group v-model="queryParams.mb009" @change="handleQuery()">
          <el-radio :value="-1">{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_ad_type " :key="item.dictValue"
            :value="item.dictValue">{{item.dictLabel}}</el-radio>
          <!-- <el-radio-button>全部</el-radio-button> -->
          <!-- <el-radio-button v-for="item in options.sys_ad_type" :key="item.dictValue" :value="item.dictValue">{{
            item.dictLabel }}</el-radio-button> -->
        </el-radio-group>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['Banner:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['Banner:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <myTable row-key="id" v-loading="loading" :columns="columns" :data="dataList" :dicts="options"
      header-cell-class-name="el-table-header-cell" @sort-change="sortChange">
      <!-- <template #tableColumn>
        <el-table-column type="selection" width="50" align="center" :selectable="checkSelectable" />
      </template> -->
      <template #mb010="{ row }">
        <div>{{ showTime(row.mb010) }}</div>
        <div>{{ showTime(row.mb011) }}</div>
      </template>
      <template #mb012="{ scope }">
        <span v-show="editIndex != scope.$index" @click="editCurrRow(scope.$index)">{{ scope.row.mb012 }}</span>
        <el-input :ref="setColumnsRef" v-show="editIndex == scope.$index" v-model="scope.row.mb012"
          @blur="handleChangeSort(scope.row)"></el-input>
      </template>
      <template #actions="{ scope }">
        <el-button type="success" size="small" icon="edit" title="编辑" v-hasPermi="['Banner:edit']"
          @click="handleUpdate(scope.row)"></el-button>
        <el-button type="danger" size="small" icon="delete" title="删除" v-hasPermi="['Banner:delete']"
          @click="handleDelete(scope.row)"></el-button>
      </template>
    </myTable>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <el-dialog :title="title" :lock-scroll="false" v-model="open" width="600">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
          <el-col :lg="24">
            <el-form-item label="类型" prop="mb009">
              <el-radio-group v-model="form.mb009">
                <el-radio v-for="item in options.sys_ad_type" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{ item.dictLabel }}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item label="标题" prop="mb002">
              <el-input v-model="form.mb002" placeholder="请输入标题" show-word-limit maxlength="40" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="说明" prop="mb003">
              <el-input v-model="form.mb003" placeholder="请输入说明" show-word-limit maxlength="200" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="图片" prop="mb005">
              <UploadImage v-model="form.mb005" :limit="1" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="跳转类型" prop="mb006">
              <el-radio-group v-model="form.mb006">
                <el-radio-button v-for="item in options.mb006Options" :key="item.dictValue"
                  :value="parseInt(item.dictValue)">
                  {{ item.dictLabel }}
                </el-radio-button>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24" v-if="form.mb006 != 0">
            <el-form-item label="链接" prop="mb004">
              <el-input v-model="form.mb004" placeholder="请输入链接" show-word-limit maxlength="200" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="开始时间" prop="mb010">
              <el-date-picker v-model="form.mb010" type="datetime" placeholder="选择日期时间"> </el-date-picker>
            </el-form-item>
          </el-col>
          <el-col :lg="24">
            <el-form-item label="结束时间" prop="mb011">
              <el-date-picker v-model="form.mb011" type="datetime" placeholder="选择日期时间"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="排序id" prop="mb012">
              <el-input-number v-model.number="form.mb012" :min="0" :controls="true" controls-position="right"
                placeholder="请输入排序id" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="是否显示" prop="mb008">
              <el-radio-group v-model="form.mb008">
                <el-radio v-for="item in options.sys_menu_show" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{ item.dictLabel }}
                </el-radio>
              </el-radio-group>
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

<script setup name="Banner">
  import { listBanner, addBanner, delBanner, updateBanner, getBanner, changeSort } from '@/api/advertising/banner.js'
  const { proxy } = getCurrentInstance()
  import { showTime } from '@/utils'
  const ids = ref([])
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 56,
    sort: 'Id',
    sortType: 'desc',
    mb002: undefined,
    mb006: undefined,
    mb008: -1,
    mb009: -1
  })
  const columns = ref([
    { visible: true, prop: 'id', label: 'id' },
    { visible: true, prop: 'mb002', label: '标题' },
    { visible: true, prop: 'mb003', label: '说明' },
    { visible: true, prop: 'mb004', label: '链接', showOverflowTooltip: true },
    { visible: true, prop: 'mb005', label: '图片', type: 'img' },
    { visible: true, prop: 'mb006', label: '跳转类型', type: 'dict', dictType: 'mb006Options' },

    { visible: true, prop: 'mb007', label: '点击次数' },
    { visible: true, prop: 'mb008', label: '是否显示', type: 'dict', dictType: 'sys_menu_show' },
    { visible: true, prop: 'mb009', label: '广告类型', type: 'dict', dictType: 'sys_ad_type' },
    { visible: true, prop: 'mb010', label: '显示时间', type: 'slot', width: '130', align: 'left' },
    { visible: true, prop: 'mb012', label: '排序id', type: 'slot' },
    {
      visible: true,
      prop: 'actions',
      label: '操作',
      type: 'slot',
      width: '120'
    }
  ])
  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  /******************自定义编辑 start **********************/
  const editIndex = ref(-1)
  const columnRefs = ref([])
  const setColumnsRef = (el) => {
    if (el) {
      columnRefs.value.push(el)
    }
  }
  // 显示编辑排序
  function editCurrRow(index) {
    editIndex.value = index

    setTimeout(() => {
      columnRefs.value[index].focus()
    }, 100)
  }
  // 保存排序
  function handleChangeSort(info) {
    editIndex.value = -1
    proxy
      .$confirm('是否保存数据?')
      .then(function () {
        return changeSort({ value: info.mb012, id: info.id })
      })
      .then(() => {
        handleQuery()
        proxy.$modal.msgSuccess('修改成功')
      })
  }
  /******************自定义编辑 end **********************/

  var dictParams = ['sys_menu_show', 'sys_ad_type']

  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })

  function getList() {
    loading.value = true
    listBanner(queryParams).then((res) => {
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
  function resetQuery() {
    proxy.resetForm('queryRef')
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
      title: [{ required: true, message: 'Title不能为空', trigger: 'blur' }],
      mb006: [{ required: true, message: '跳转类型不能为空', trigger: 'change', type: 'number' }],
      mb008: [{ required: true, message: '是否显示不能为空', trigger: 'blur', type: 'number' }],
      mb009: [{ required: true, message: '广告类型不能为空', trigger: 'change', type: 'number' }],
      mb010: [{ required: true, message: '广告显示时间不能为空', trigger: 'change' }],
      mb011: [{ required: true, message: '广告显示时间不能为空', trigger: 'change' }],
      mb004: [{ required: true, message: '跳转链接不能为空', trigger: 'blur' }]
    },
    options: {
      // 跳转类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      mb006Options: [
        { dictLabel: '不跳转', dictValue: '0' },
        { dictLabel: '外链', dictValue: '1' },
        { dictLabel: '内部跳转', dictValue: '2' }
      ],
      // 是否显示 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_menu_show: [],
      // 广告类型
      sys_ad_type: []
    }
  })

  const { form, rules, options } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      id: null,
      mb002: null,
      mb003: null,
      mb004: null,
      mb005: null,
      mb006: 0,

      mb007: null,
      mb008: 0,
      mb009: 0,
      mb010: null,
      mb011: null,
      mb012: 99
    }
    proxy.resetForm('formRef')
  }

  // 添加按钮操作
  function handleAdd() {
    reset()
    open.value = true
    title.value = '添加广告管理'
    opertype.value = 1
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getBanner(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = '修改广告管理'
        opertype.value = 2

        form.value = {
          ...data
        }
      }
    })
  }

  // 添加&修改 表单提交
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.id != undefined && opertype.value === 2) {
          updateBanner(form.value).then((res) => {
            proxy.$modal.msgSuccess('修改成功')
            open.value = false
            getList()
          })
        } else {
          addBanner(form.value).then((res) => {
            proxy.$modal.msgSuccess('新增成功')
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
      .$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？', '警告', {
        confirmButtonText: proxy.$t('common.ok'),
        cancelButtonText: proxy.$t('common.cancel'),
        type: 'warning'
      })
      .then(function () {
        return delBanner(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess('删除成功')
      })
  }

  // 导出按钮操作
  function handleExport() {
    proxy
      .$confirm('是否确认导出广告管理数据项?', '警告', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
      .then(async () => {
        await proxy.downFile('/advertising/banner/export', { ...queryParams })
      })
  }

  handleQuery()
</script>