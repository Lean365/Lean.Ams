<!--
 * @Descripttion: 看板/routine_board
 * @Version: 0.24.629.17422
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/20 9:52:38
 * @column：29
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="公司名称" prop="mb004">
            <el-input v-model="queryParams.mb004"
              :placeholder="$t('btn.enterSearchPrefix')+'公司名称'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['routine:board:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:board:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:board:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:board:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Routine/RoutineBoard/importTemplate"
                  importUrl="/Routine/RoutineBoard/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:board:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="600px" :data="dataList" v-loading="loading" ref="table"
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain icon="view" size="small" @click="openNewTab(scope.row)"
            :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="id" label="主键" align="center" v-if="columns.showColumn('id')" />
      <el-table-column prop="mb002" label="起始日" :show-overflow-tooltip="true" v-if="columns.showColumn('mb002')" />
      <el-table-column prop="mb003" label="结束日" :show-overflow-tooltip="true" v-if="columns.showColumn('mb003')" />
      <el-table-column prop="mb004" label="公司名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb004')" />
      <el-table-column prop="mb005" label="参访人员" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mb005')" />
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['routine:board:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['routine:board:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改看板对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="起始日" prop="mb002">
                  <el-date-picker v-model="form.mb002" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="结束日" prop="mb003">
                  <el-date-picker v-model="form.mb003" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="公司名称" prop="mb004">
                  <el-input type="textarea" v-model="form.mb004"
                    :placeholder="$t('btn.enterPrefix')+'公司名称'+$t('btn.enterSuffix')" show-word-limit :rows="2"
                    maxlength="400" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="参访人员" prop="mb005">
                  <el-input type="textarea" v-model="form.mb005"
                    :placeholder="$t('btn.enterPrefix')+'参访人员'+$t('btn.enterSuffix')" show-word-limit :rows="8"
                    maxlength="4000" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" show-word-limit maxlength="500" />
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

    <el-dialog :lock-scroll="false" v-model="openView" :style="{ backgroundColor: '#000' }" :fullscreen="true">
      <div style="position: absolute;top:0;left:0;width:100%;height:100%;">
        <el-container style="height: 90%;">
          <el-header>熱烈歡迎</el-header>
          <el-main>
            <div class="el-main-corp">{{ formView.mb004 }}</div>
            <el-form>
              <el-form-item>
                <pre class="el-main-guest">{{ formView.mb005.split(',').join(' \n') }}</pre>
              </el-form-item>
            </el-form>
          </el-main>
          <el-footer>
            <marquee>蒞臨指導 </marquee>
          </el-footer>
        </el-container>
      </div>
    </el-dialog>
  </div>
</template>

<script setup name="routineboard">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listRoutineBoard,
    addRoutineBoard, delRoutineBoard,
    updateRoutineBoard, getRoutineBoard,
  }
    from '@/api/routine/routineboard.js'
  import importData from '@/components/ImportData'
  //防抖处理函数 import { debounce } from 'lodash';
  import { debounce } from 'lodash';
  const dynamicTop = ref(0)
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
  const openView = ref(false)
  const formView = ref({})
  //显示搜索条件
  const showSearch = ref(true)
  //使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 56,
    sort: 'Mb002',
    sortType: 'desc',
    //是否查询（1是）
    mb004: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'id', label: '主键' },
    { visible: true, prop: 'mb002', label: '起始日' },
    { visible: true, prop: 'mb003', label: '结束日' },
    { visible: true, prop: 'mb004', label: '公司名称' },
    { visible: true, prop: 'mb005', label: '参访人员' },
    { visible: true, prop: 'remark', label: '备注' },
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
  ]

  //API获取从看板/routine_board表记录数据
  function getList() {
    loading.value = true
    listRoutineBoard(queryParams).then(res => {
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
      mb002: [{ required: true, message: "起始日" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mb003: [{ required: true, message: "结束日" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mb004: [{ required: true, message: "公司名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }, {
        pattern: /^(?!_)(?!.*?_$)[a-zA-Z0-9, -\u4e00-\u9fa5\u3040-\u318F\u31A0-\u31BF\u31F0-\u31FF\u3400-\u4DB5\u4E00-\u9FFF\uA960-\uA97F\uAC00-\uD7FF]+$/,
        message: proxy.$t('common.tipMobilePhoneNumberError'),
        trigger: 'blur'
      }],
      mb005: [
        {
          required: true, message: "参访人员" + proxy.$t('btn.isEmpty'), trigger: "blur"

        }, {
          pattern: /^(?!_)(?!.*?_$)[a-zA-Z0-9, \u4e00-\u9fa5\u3040-\u318F\u31A0-\u31BF\u31F0-\u31FF\u3400-\u4DB5\u4E00-\u9FFF\uA960-\uA97F\uAC00-\uD7FF]+$/,
          message: proxy.$t('common.tipMobilePhoneNumberError'),
          trigger: 'blur'
        }],
    },
    //字典名称
    options: {
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      mb002: null,
      mb003: null,
      mb004: null,
      mb005: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '看板'
    opertype.value = 1
    form.value.mb002 = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), 0, 0, 0)
    form.value.mb003 = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() + 7, 23, 59, 59)
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getRoutineBoard(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '看板'
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
          updateRoutineBoard(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addRoutineBoard(form.value).then((res) => {
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
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delRoutineBoard(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }
  /** 查看按钮操作 */
  function handleView(row) {
    const id = row.id || ids.value
    getRoutineBoard(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        openView.value = true
        formView.value = data

      }
    })
  }
  const router = useRouter();
  function openNewTab(row) {
    // 打开新页签
    const id = row.id || ids.value
    getRoutineBoard(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        const routeData = router.resolve({
          path: "view",
          query: { mb004: row.mb004, mb005: row.mb005 },

        })
        openFullScreenWindow(routeData.href);


        // let _url = this.$router.resolve({
        //   name: 'nextPage',
        //   query: {
        //     page: this.page,
        //     pageSize: this.pageSize,
        //     pageName: 'mainPage',
        //     searchForm: JSON.stringify(this.dataForm)
        //   }
        // })
        // window.open(_url.href, '_blank')
        // 新页面的URL
        // const url = router.push({ path: '/routine/board/view' });

        // // router.push({
        // //   path: '/gen/editTable',
        // //   query: { tableId: row.tableId }
        // // })
        // // 参数
        // const params = { mb004: row.mb004, mb005: row.mb005,  /* 其他需要传递的参数 */ };
        // // 打开新标签页，并传递参数
        // const queryString = new URLSearchParams(params).toString();
        // console.log(queryString);
        // window.open(`${url}?${queryString}`, '_blank', 'fullscreen=yes');

      }
    })

  }
  // 全屏打开窗口的函数
  function openFullScreenWindow(urls) {
    // 获取屏幕宽度和高度
    const screenWidth = window.screen.width;
    const screenHeight = window.screen.height;

    // 新开窗口的URL
    const url = urls;

    // 打开新窗口，并设置全屏
    const newWindow = window.open(url, '_blank');
    if (newWindow) {
      // 设置新窗口的外部宽度和高度为全屏
      newWindow.outerWidth = screenWidth;
      newWindow.outerHeight = screenHeight;
    }
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<看板.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Routine/RoutineBoard/export', { ...queryParams })
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
<style scoped>
  .el-header,
  .el-footer {
    /* background-color: #B3C0D1; */
    color: #ffd504;
    text-align: center;
    line-height: 80px;
    font-size: 80px;
    font-weight: bold;
    letter-spacing: 80px;
  }

  .el-main-corp {
    position: absolute;
    left: 110px;
    top: 80px;
    /* text-align: center; */
    /* background-color: #E9EEF3; */
    font-family: 'Microsoft YaHei', '微软雅黑', sans-serif;
    font-weight: bold;
    color: #ffd504;
    font-size: 60px;

  }

  .el-main-guest {
    position: absolute;
    top: 40px;
    left: 160px;
    font-family: 'Microsoft YaHei', '微软雅黑', sans-serif;
    /* background-color: #E9EEF3; */
    font-weight: bold;
    color: #ffd504;
    line-height: 50px;
    letter-spacing: 5px;
    font-size: 40px;
    display: flex;
    flex-wrap: wrap;
  }
</style>