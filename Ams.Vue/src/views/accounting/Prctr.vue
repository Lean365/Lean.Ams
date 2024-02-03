<!--
 * @Descripttion: (利润中心/fico_prctr)
 * @Version: (0.24.389.28396)
 * @Author: (Lean365)
 * @Date: (2024/1/24 17:18:00)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="公司" prop="fpCorp">
        <el-select clearable filterable v-model="queryParams.fpCorp" :placeholder="$t('btn.select')+'公司'">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="代码" prop="fpCode">
        <el-input clearable v-model="queryParams.fpCode" :placeholder="$t('btn.enter')+'代码'" />
      </el-form-item>
      <el-form-item label="名称" prop="fpName">
        <el-input clearable v-model="queryParams.fpName" :placeholder="$t('btn.enter')+'名称'" />
      </el-form-item>
      <el-form-item label="类别" prop="fpType">
        <el-select clearable filterable v-model="queryParams.fpType" :placeholder="$t('btn.select')+'类别'">
          <el-option v-for="item in  options.app_costs_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="有效到">
        <el-date-picker v-model="dateRangeFpExpDate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['fico:prctr:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:prctr:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:prctr:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:prctr:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="accounting/Prctr/importTemplate" importUrl="/accounting/Prctr/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:prctr:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" height="650" v-loading="loading" ref="table" border
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="40" align="center" />
      <el-table-column prop="fpSFID" label="唯一标识" align="center" v-if="columns.showColumn('fpSFID')" />
      <el-table-column prop="fpCorp" label="公司" align="center" v-if="columns.showColumn('fpCorp')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.fpCorp" />
        </template>
      </el-table-column>
      <el-table-column prop="fpCode" label="代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fpCode')" />
      <el-table-column prop="fpName" label="名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fpName')" />
      <el-table-column prop="fpType" label="类别" align="center" v-if="columns.showColumn('fpType')">
        <template #default="scope">
          <dict-tag :options=" options.app_costs_type " :value="scope.row.fpType" />
        </template>
      </el-table-column>
      <el-table-column prop="fpActDate" label="有效从" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fpActDate')" />
      <el-table-column prop="fpExpDate" label="有效到" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fpExpDate')" />
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createBy')" />
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateBy')" />
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateTime')" />
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:prctr:edit']"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['fico:prctr:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />


    <!-- 添加或修改利润中心对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <!-- <el-col :lg="12">
                <el-form-item label="唯一标识" prop="fpSFID">
                  <el-input v-model.number="form.fpSFID" :placeholder="$t('btn.enter')+'唯一标识'"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col> -->

              <el-col :lg="12">
                <el-form-item label="公司" prop="fpCorp">
                  <el-select clearable filterable v-model="form.fpCorp" :placeholder="$t('btn.select')+'公司'">
                    <el-option v-for="item in options.sys_crop_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="代码" prop="fpCode">
                  <el-input clearable v-model="form.fpCode" :placeholder="$t('btn.enter')+'代码'" maxlength="5"
                    show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="名称" prop="fpName">
                  <el-input clearable v-model="form.fpName" :placeholder="$t('btn.enter')+'名称'" maxlength="40"
                    show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="类别" prop="fpType">
                  <el-select clearable filterable v-model="form.fpType" :placeholder="$t('btn.select')+'类别'">
                    <el-option v-for="item in options.app_costs_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="有效从" prop="fpActDate">
                  <el-date-picker v-model="form.fpActDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="有效到" prop="fpExpDate">
                  <el-date-picker v-model="form.fpExpDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
              </el-col>


            </el-row>
          </el-tab-pane>

          <el-tab-pane :label="$t('ptabs.subInfo')" name="15th">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-input clearable v-model.number="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'"
                    :disabled="true" maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建者" prop="createBy">
                  <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新者" prop="updateBy">
                  <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
                </el-form-item>
              </el-col>
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

<script setup name="prctr">
  //后台操作函数
  import {
    listPrctr,
    addPrctr, delPrctr,
    updatePrctr, getPrctr,
  }
    from '@/api/accounting/prctr.js'
  //
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
    pageSize: 20,
    sort: '',
    sortType: 'asc',
    fpCorp: undefined,
    fpCode: undefined,
    fpName: undefined,
    fpType: undefined,
    fpExpDate: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'fpSFID', label: '唯一标识' },
    { visible: true, prop: 'fpCorp', label: '公司' },
    { visible: true, prop: 'fpCode', label: '代码' },
    { visible: true, prop: 'fpName', label: '名称' },
    { visible: true, prop: 'fpType', label: '类别' },
    { visible: true, prop: 'fpActDate', label: '有效从' },
    { visible: true, prop: 'fpExpDate', label: '有效到' },
    { visible: false, prop: 'remark', label: '备注' },
    { visible: false, prop: 'createBy', label: '创建者' },
    { visible: false, prop: 'createTime', label: '创建时间' },
    { visible: false, prop: 'updateBy', label: '更新者' },
    { visible: false, prop: 'updateTime', label: '更新时间' },
  ])
  // 记录数
  const total = ref(0)
  //定义从设变表格数据变量
  const dataList = ref([])
  //查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
  //输入日时间范围
  // 有效到时间范围
  const dateRangeFpExpDate = ref([])
  //字典参数
  var dictParams = [
    { dictType: "sys_crop_list" },
    { dictType: "app_costs_type" },
  ]
  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从利润中心/fico_prctr表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeFpExpDate.value, 'FpExpDate');
    loading.value = true
    listPrctr(queryParams).then(res => {
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
    // 有效到时间范围
    dateRangeFpExpDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.fpSFID);
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
      fpSFID: [{ required: true, message: '唯一标识' + proxy.$t('btn.empty'), trigger: "blur" }],
      fpCorp: [{ required: true, message: '公司' + proxy.$t('btn.empty'), trigger: "change" }],
      fpCode: [{ required: true, message: '代码' + proxy.$t('btn.empty'), trigger: "blur" }],
      fpName: [{ required: true, message: '名称' + proxy.$t('btn.empty'), trigger: "blur" }],
      fpType: [{ required: true, message: '类别' + proxy.$t('btn.empty'), trigger: "change" }],
      fpActDate: [{ required: true, message: '有效从' + proxy.$t('btn.empty'), trigger: "blur" }],
      fpExpDate: [{ required: true, message: '有效到' + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_crop_list: [],
      // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_costs_type: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // @Descripttion: (自定义函数/CustomFunctions)
  // @Functions: (assignValue,calculateValue,statisticValue)
  // @Version: (0.24.389.28396)
  // @Author: (Lean365)
  // @Date: (2024/1/24 17:18:00)



  // 重置表单
  function reset() {
    form.value = {
      fpSFID: 0,
      fpCorp: null,
      fpCode: null,
      fpName: null,
      fpType: null,
      fpActDate: null,
      fpExpDate: null,
      isDeleted: 0,
      remark: null,
      createBy: null,
      createTime: null,
      updateBy: null,
      updateTime: null,
    };
    proxy.resetForm("formRef")
  }

  //日期格式化
  const currentDate = new Date().getFullYear() + ('0' + (new Date().getMonth() + 1)).slice(-2)
  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + '利润中心'
    opertype.value = 1
    form.value.fpCorp = []
    form.value.fpType = []
    form.value.fpActDate = currentDate
    form.value.fpExpDate = new Date('9999/12/31')
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.fpSFID || ids.value
    getPrctr(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + '利润中心'
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

        if (form.value.fpSFID != undefined && opertype.value === 2) {
          updatePrctr(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addPrctr(form.value).then((res) => {
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
    const Ids = row.fpSFID || ids.value

    proxy
      .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delPrctr(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "利润中心", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/accounting/Prctr/export', { ...queryParams })
      })
  }


  // @Descripttion: (自定义函数/CustomFunctions)
  // @Functions: (assignValue,calculateValue,statisticValue)
  // @Version: (0.24.389.28396)
  // @Author: (Lean365)
  // @Date: (2024/1/24 17:18:00)

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