<template>
  <el-form :model="queryParams" ref="queryForm" :inline="true" label-width="auto">
    <el-form-item :label="$t('pdict.dictType')" prop="dictType">
      <el-select v-model="queryParams.dictType">
        <el-option v-for="item in typeOptions" :key="item.dictId" :label="item.dictName" :value="item.dictType" />
      </el-select>
    </el-form-item>
    <el-form-item :label="$t('common.tipIsStated')" prop="isStatus">
      <el-radio-group v-model="queryParams.isStatus">
        <el-radio :value="-1">{{ $t('common.all') }}</el-radio>
        <el-radio v-for="dict in statusOptions" :key="dict.dictValue" :value="parseInt(dict.dictValue)">{{
          dict.dictLabel
          }}</el-radio>
      </el-radio-group>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
      <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
    </el-form-item>
  </el-form>

  <el-row :gutter="10" class="mb8">
    <el-col :span="1.5">
      <el-button type="primary" plain icon="plus" @click="handleAdd" v-hasPermi="['system:dict:add']">{{
        $t('btn.add') }}</el-button>
    </el-col>
  </el-row>
  <el-table :data="dataList">
    <!-- <el-table-column type="selection" width="55" align="center" /> -->
    <el-table-column :label="$t('pdict.dictCode')" align="center" prop="dictCode" />
    <el-table-column :label="$t('pdict.dictLabel')" align="center" prop="dictLabel">
      <template #default="scope">
        <span v-if="scope.row.listClass == '' || scope.row.listClass == 'default'" :class="scope.row.cssClass">{{
          scope.row.dictLabel }}</span>
        <el-tag v-else :type="scope.row.listClass == 'primary' ? '' : scope.row.listClass"
          :class="scope.row.cssClass">{{ scope.row.dictLabel }}
        </el-tag>
      </template>
    </el-table-column>
    <el-table-column :label="$t('pdict.langKey')" align="center" prop="langKey" />
    <el-table-column :label="$t('pdict.dictValue')" align="center" prop="dictValue" sortable />
    <el-table-column :label="$t('pdict.dictSort')" align="center" prop="sortingNum" sortable />
    <el-table-column :label="$t('common.tipIsStated')" align="center" prop="isStatus">
      <template #default="scope">
        <dict-tag :options="statusOptions" :value="scope.row.isStatus" />
      </template>
    </el-table-column>
    <el-table-column :label="$t('common.tipRemarks')" align="center" prop="remark" :show-overflow-tooltip="true" />
    <el-table-column :label="$t('btn.operation') " align="center" class-name="small-padding fixed-width" width="130px">
      <template #default="scope">
        <div v-if="scope.row.dictCode > 0">
          <el-button-group>
            <el-button type="success" plain size="small" icon="edit" @click="handleUpdate(scope.row)"
              v-hasPermi="['system:dict:edit']"></el-button>
            <el-button type="danger" plain size="small" icon="delete" @click="handleDelete(scope.row)"
              v-hasPermi="['system:dict:remove']"> </el-button>
          </el-button-group>
        </div>
      </template>
    </el-table-column>
  </el-table>
  <pagination :total="total" v-show="total > 0" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
    @pagination="getList" />

  <!-- 添加或修改参数配置对话框 -->
  <el-dialog :title="title" v-model="open" draggable width="500px" append-to-body>
    <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
      <el-row :gutter="20">
        <el-col :lg="24">
          <el-form-item :label="$t('pdict.dictType')">
            <el-input v-model="form.dictType" :disabled="true" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pdict.langKey')" prop="langKey">
            <el-input v-model="form.langKey"
              :placeholder="$t('btn.enterPrefix')+$t('pdict.langKey')+$t('btn.enterSuffix')" :disabled="true"
              show-word-limit maxlength="80" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pdict.dictLabel')" prop="dictLabel">
            <el-input v-model="form.dictLabel"
              :placeholder="$t('btn.enterPrefix')+$t('pdict.dictLabel')+$t('btn.enterSuffix')" @input="handleInput"
              show-word-limit maxlength="80" />
          </el-form-item>
        </el-col>

        <el-col :lg="24">
          <el-form-item :label="$t('pdict.dictValue')" prop="dictValue">
            <el-input v-model="form.dictValue"
              :placeholder="$t('btn.enterPrefix')+$t('pdict.dictValue')+$t('btn.enterSuffix')" @input="handleInput"
              show-word-limit maxlength="80" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pdict.cssClass')" prop="cssClass">
            <el-select v-model="form.cssClass" allow-create filterable clearable="">
              <el-option v-for="dict in cssClassOptions" :class="dict.value" :key="dict.value" :label="dict.label"
                :value="dict.value">
                <span style="float: left" :class="dict.value">{{ dict.label }}</span>
                <span style="float: right">{{ dict.value }}</span>
              </el-option>
            </el-select>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pdict.listClass')" prop="listClass">
            <el-select v-model="form.listClass">
              <el-option v-for="item in listClassOptions" :key="item.value" :label="item.label + '(' + item.value + ')'"
                :value="item.value">
              </el-option>
            </el-select>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pdict.dictSort')" prop="sortingNum">
            <el-input-number v-model="form.sortingNum" controls-position="right" :min="0" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('common.tipIsStated')" prop="isStatus">
            <el-radio-group v-model="form.isStatus">
              <el-radio v-for="dict in statusOptions" :key="dict.dictValue" :value="parseInt(dict.dictValue)">{{
                dict.dictLabel
                }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pdict.extLabel')" prop="extLabel">
            <el-input v-model="form.extLabel"
              :placeholder="$t('btn.enterPrefix')+$t('pdict.extLabel')+$t('btn.enterSuffix')" show-word-limit
              maxlength="80"></el-input>
          </el-form-item>
        </el-col>

        <el-col :lg="24">
          <el-form-item :label="$t('pdict.extValue')" prop="extValue">
            <el-input v-model="form.extValue"
              :placeholder="$t('btn.enterPrefix')+$t('pdict.extValue')+$t('btn.enterSuffix')" show-word-limit
              maxlength="80"></el-input>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('common.tipRemarks')" prop="remark">
            <el-input v-model="form.remark" type="textarea"
              :placeholder="$t('btn.enterPrefix')+$t('common.tipRemarks')+$t('btn.enterSuffix')" show-word-limit
              maxlength="400"></el-input>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <template #footer>
      <div class="dialog-footer">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </div>
    </template>
  </el-dialog>
</template>
<script setup name="dictData">
  import { listData, getData, delData, addData, updateData } from '@/api/system/dict/data'
  import { listType, getType } from '@/api/system/dict/type'
  const { proxy } = getCurrentInstance()
  const props = defineProps({
    dictId: {
      type: Number,
      default: 0
    }
  })
  watch(
    () => props.dictId,
    (newVal, oldValue) => {
      if (newVal) {
        getTypeInfo(newVal)
        getTypeList()
        proxy.getDicts('sys_normal_disable').then((response) => {
          statusOptions.value = response.data
        })
      }
    },
    {
      immediate: true,
      deep: true
    }
  )

  const ids = ref()
  const loading = ref(false)
  // 总条数
  const total = ref(0)
  // 字典表格数据
  const dataList = ref([])
  // 默认字典类型
  const defaultDictType = ref('')
  // 弹出层标题
  const title = ref('')
  // 是否显示弹出层
  const open = ref(false)
  // 数据标签回显样式
  const listClassOptions = ref([
    {
      value: 'default',
      label: proxy.$t('pdict.default')
    },
    {
      value: 'primary',
      label: proxy.$t('pdict.primary')
    },
    {
      value: 'success',
      label: proxy.$t('pdict.success')
    },
    {
      value: 'info',
      label: proxy.$t('pdict.info')
    },
    {
      value: 'warning',
      label: proxy.$t('pdict.warning')
    },
    {
      value: 'danger',
      label: proxy.$t('pdict.danger')
    },

  ])

  const cssClassOptions = ref([
    {
      value: 'text-primary',
      label: proxy.$t('pdict.textprimary')
    },
    {
      value: 'text-success',
      label: proxy.$t('pdict.textsuccess')
    },
    {
      value: 'text-info',
      label: proxy.$t('pdict.textinfo')
    },
    {
      value: 'text-warning',
      label: proxy.$t('pdict.textwarning')
    },
    {
      value: 'text-danger',
      label: proxy.$t('pdict.textdanger')
    },
    {
      value: 'text-orange',
      label: proxy.$t('pdict.textorange')
    },
    {
      value: 'text-hotpink',
      label: proxy.$t('pdict.texthotpink')
    },
    {
      value: 'text-green',
      label: proxy.$t('pdict.textgreen')
    },
    {
      value: 'text-greenyellow',
      label: proxy.$t('pdict.textgreenyellow')
    },
    {
      value: 'text-purple',
      label: proxy.$t('pdict.textpurple')
    }
  ])
  // 状态数据字典
  const statusOptions = ref([])
  // 类型数据字典
  const typeOptions = ref([])
  // 查询参数
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    dictName: undefined,
    dictType: undefined,
    isStatus: -1,
    sortingNum: undefined,
  })
  // 表单参数

  const formRef = ref()
  const state = reactive({
    form: {},
    rules: {
      dictLabel: [{ required: true, message: proxy.$t('pdict.dictLabel') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      dictValue: [{ required: true, message: proxy.$t('pdict.dictValue') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      sortingNum: [{ required: true, message: proxy.$t('pdict.dictSort') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      langKey: [{ pattern: /^[A-Za-z].+$/, message: proxy.$t('common.tipInputFormatError') + proxy.$t('common.tipInputLangKeyError'), trigger: 'blur' }]
    }
  })

  const { form, rules } = toRefs(state)
  /** 查询字典类型详细 */
  function getTypeInfo(dictId) {
    getType(dictId).then((response) => {
      queryParams.dictType = response.data.dictType
      defaultDictType.value = response.data.dictType
      getList()
    })
  }
  /** 查询字典类型列表 */
  function getTypeList() {
    listType().then((response) => {
      typeOptions.value = response.data.result
    })
  }

  /** 查询字典数据列表 */
  function getList() {
    loading.value = true
    listData(queryParams).then((response) => {
      dataList.value = response.data.result
      //console.log(response.data.result, response.data.totalNum)
      total.value = response.data.totalNum
      loading.value = false
    })

  }

  // 取消按钮
  function cancel() {
    open.value = false
    reset()
  }
  // 表单重置
  function reset() {
    form.value = {
      dictCode: undefined,
      dictLabel: undefined,
      dictValue: undefined,
      sortingNum: 10,
      isStatus: 0,
      remark: undefined
    }
    proxy.resetForm('formRef')
  }

  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }

  /** 重置按钮操作 */
  function resetQuery() {
    proxy.resetForm('queryForm')
    queryParams.dictType = defaultDictType.value
    handleQuery()
  }
  /** 新增按钮操作 */
  function handleAdd() {
    reset()
    open.value = true
    title.value = proxy.$t('btn.add')
    form.value.dictType = queryParams.dictType
  }
  // 多选框选中数据
  // function handleSelectionChange(selection) {
  //   this.ids = selection.map((item) => item.dictCode)
  //   this.single = selection.length != 1
  //   this.multiple = !selection.length
  // }

  function handleInput() {
    form.value.langKey = 'dict.' + form.value.dictType + ':' + form.value.dictValue
    form.value.remark = '列表(' + form.value.dictType + '):' + form.value.dictLabel

  }
  /** 修改按钮操作 */
  function handleUpdate(row) {
    reset()
    const dictCode = row.dictCode || ids.value
    getData(dictCode).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['formRef'].validate((valid) => {
      if (valid) {
        if (form.value.dictCode != undefined) {
          updateData(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addData(form.value).then((response) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipAddSucceed'))
            open.value = false
            getList()
          })
        }
      }
    })
  }

  /** 删除按钮操作 */
  function handleDelete(row) {
    const dictCodes = row.dictCode || ids.value
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + dictCodes + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delData(dictCodes)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipEmptySucceed'))
      })
  }
</script>