<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @Author: (Lean365)
 * @Date: (2024/1/6 10:53:01)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>

      <el-form-item label="生产日期">
        <el-date-picker v-model="dateRangePomMfgDate" type="datetimerange" start-placeholder="开始日期"
          end-placeholder="结束日期" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
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
        <el-button type="primary" v-hasPermi="['pp:outputmaster:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table :data="dataList" border hight="200">
      <el-table-column prop="mfgDate" label="日期"></el-table-column>
      <el-table-column prop="stdOutputQty" label="标准"></el-table-column>
      <el-table-column prop="realOutputQty" label="实际"></el-table-column>
      <el-table-column prop="achievedRate" label="达成率">
        <template #default="scope">
          {{ scope.row. achievedRate}}%
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />



    <!-- 添加或修改oph主表对话框 -->

  </div>
</template>

<script setup name="monthdef">
  import {
    getQuerySfid,
    getCountMonthOutput, getCountMonthLineOutput, getCountMonthModelOutput,
    getCountMonthEc, getCountMonthDefective, getCountMonthLaborhours,
    getCountMonthIncoming, getCountMonthOutgoing, getCountMonthSales,
    getCountMonthAreaSales, getCountMonthRegionSales,
    getCountYearOutput, getCountYearLineOutput, getCountYearModelOutput,
    getCountYearEc, getCountYearDefective, getCountYearLaborhours,
    getCountYearIncoming, getCountYearOutgoing, getCountYearSales,
    getCountYearAreaSales, getCountYearRegionSales
  }
    from '@/api/statistics/output.js'
  const { proxy } = getCurrentInstance()
  const ids = ref([])
  const loading = ref(false)
  const showSearch = ref(true)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10,
    sort: '',
    sortType: 'asc',
    mfgDate: undefined,
    stdOutputQty: undefined,
    realOutputQty: undefined,
    achievedRate: undefined,
  })


  const total = ref(0)
  const dataList = ref([])
  const queryRef = ref()
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

  // 生产日期时间范围
  const dateRangePomMfgDate = ref([])

  function getList() {
    proxy.addDateRange(queryParams, dateRangePomMfgDate.value, 'PomMfgDate');
    loading.value = true
    getCountMonthDefective(queryParams).then(res => {
      const { code, data } = res
      if (code == 200) {
        console.log(data)
        dataList.value = data

        loading.value = false
      }
    })
  }

  // 查询
  // 查询
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  // 重置查询操作
  function resetQuery() {
    // 生产日期时间范围
    dateRangePomMfgDate.value = []
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


  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单


  // 添加按钮操作

  // 修改按钮操作


  // 添加&修改 表单提交


  // 删除按钮操作



  // 导入数据成功处理



  /*********************oph从表子表信息*************************/

  /** oph从表序号 */

  /** oph从表添加按钮操作 */

  /** oph从表删除按钮操作 */

  /** oph从表详情 */

  handleQuery()
</script>