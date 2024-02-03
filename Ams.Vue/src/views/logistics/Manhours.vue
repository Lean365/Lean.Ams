<!--
 * @Descripttion: (标准工时/pp_manhours)
 * @Version: (0.24.389.13976)
 * @Author: (Lean365)
 * @Date: (2024/1/24 9:28:16)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="生效日期">
        <el-date-picker v-model="dateRangeMhEffDate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="工厂" prop="mhPlant">
        <el-select clearable filterable v-model="queryParams.mhPlant" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.app_plant_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="mhItem">
        <el-select filterable remote remote-show-suffix :remote-method="remoteMethod" clearable :loading="loading"
          v-model="queryParams.mhItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  remotequery_sql_item_manhour" :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工作中心" prop="mhWcName">
        <el-select clearable filterable v-model="queryParams.mhWcName" :placeholder="$t('btn.select')+'工作中心'">
          <el-option v-for="item in  options.app_work_center " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['pp:manhours:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:manhours:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:manhours:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:manhours:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="logistics/Manhours/importTemplate" importUrl="/logistics/Manhours/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:manhours:export']">
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
      <el-table-column prop="mhSFID" label="SFID" align="center" v-if="columns.showColumn('mhSFID')" />
      <el-table-column prop="mhEffDate" label="生效日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhEffDate')" />
      <el-table-column prop="mhPlant" label="工厂" align="center" v-if="columns.showColumn('mhPlant')">
        <template #default="scope">
          <dict-tag :options=" options.app_plant_list " :value="scope.row.mhPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="mhItem" label="物料" align="center" v-if="columns.showColumn('mhItem')">
      </el-table-column>
      <el-table-column prop="mhModelType" label="机种名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhModelType')" />
      <el-table-column prop="mhRegionType" label="仕向别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhRegionType')" />
      <el-table-column prop="mhItemText" label="物料文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhItemText')" />
      <el-table-column prop="mhWcName" label="工作中心" align="center" v-if="columns.showColumn('mhWcName')">
        <template #default="scope">
          <dict-tag :options=" options.app_work_center " :value="scope.row.mhWcName" />
        </template>
      </el-table-column>
      <el-table-column prop="mhWcText" label="工作中心文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhWcText')" />
      <el-table-column prop="mhStdShort" label="标准点数" align="center" v-if="columns.showColumn('mhStdShort')" />
      <el-table-column prop="mhShortUnit" label="Short单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhShortUnit')" />
      <el-table-column prop="mhToMinRate" label="点数换算汇率" align="center" v-if="columns.showColumn('mhToMinRate')">
      </el-table-column>
      <el-table-column prop="mhStdTime" label="标准工时" align="center" v-if="columns.showColumn('mhStdTime')" />
      <el-table-column prop="mhTimeUnit" label="工时单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhTimeUnit')" />
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
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:manhours:edit']"
            @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['pp:manhours:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />


    <!-- 添加或修改标准工时对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="SFID" prop="mhSFID">
                  <el-input v-model.number="form.mhSFID" :placeholder="$t('btn.enter')+'SFID'"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生效日期" prop="mhEffDate">
                  <el-date-picker v-model="form.mhEffDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂" prop="mhPlant">
                  <el-select clearable filterable v-model="form.mhPlant" :placeholder="$t('btn.select')+'工厂'">
                    <el-option v-for="item in options.app_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="mhItem">
                  <el-select filterable remote remote-show-suffix :remote-method="remoteMethod" clearable
                    :loading="loading" style="width: 360px" v-model="form.mhItem" :placeholder="$t('btn.select')+'物料'"
                    @change="assignModelValue">
                    <el-option v-for="item in  remotequery_sql_item_manhour" :key="item.dictValue"
                      :label="item.dictLabel" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="机种名" prop="mhModelType">
                  <el-input v-model="form.mhModelType" :placeholder="$t('btn.enter')+'机种名'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仕向别" prop="mhRegionType">
                  <el-input v-model="form.mhRegionType" :placeholder="$t('btn.enter')+'仕向别'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料文本" prop="mhItemText">
                  <el-input v-model="form.mhItemText" :placeholder="$t('btn.enter')+'物料文本'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工作中心" prop="mhWcName">
                  <el-select clearable filterable v-model="form.mhWcName" :placeholder="$t('btn.select')+'工作中心'"
                    @change="assignWorkValue">
                    <el-option v-for="item in options.app_work_center" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工作中心文本" prop="mhWcText">
                  <el-input v-model="form.mhWcText" :placeholder="$t('btn.enter')+'工作中心文本'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准点数" prop="mhStdShort">
                  <el-input-number v-model.number="form.mhStdShort" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'标准点数'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Short单位" prop="mhShortUnit">
                  <el-input v-model="form.mhShortUnit" :placeholder="$t('btn.enter')+'Short单位'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="点数换算汇率" prop="mhToMinRate">
                  <el-select clearable filterable v-model="form.mhToMinRate" :placeholder="$t('btn.select')+'点数换算汇率'">
                    <el-option v-for="item in options.app_short_convert" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseFloat( item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准工时" prop="mhStdTime">
                  <el-input-number v-model.number="form.mhStdTime" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'标准工时'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工时单位" prop="mhTimeUnit">
                  <el-input v-model="form.mhTimeUnit" :placeholder="$t('btn.enter')+'工时单位'" :disabled="true" />
                </el-form-item>
              </el-col>


            </el-row>
          </el-tab-pane>



          <el-tab-pane :label="$t('ptabs.subInfo')" name="tenth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-input v-model.number="form.isDeleted" :placeholder="$t('btn.enter')+'软删除'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建者" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" :disabled="true" />
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
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'" :disabled="true" />
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

<script setup name="manhours">
  //后台操作函数
  import {
    listManhours,
    addManhours, delManhours,
    updateManhours, getManhours,
  }
    from '@/api/logistics/manhours.js'
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
    mhEffDate: undefined,
    mhPlant: undefined,
    mhItem: undefined,
    mhWcName: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'mhSFID', label: 'SFID' },
    { visible: true, prop: 'mhEffDate', label: '生效日期' },
    { visible: true, prop: 'mhPlant', label: '工厂' },
    { visible: true, prop: 'mhItem', label: '物料' },
    { visible: true, prop: 'mhModelType', label: '机种名' },
    { visible: true, prop: 'mhRegionType', label: '仕向别' },
    { visible: false, prop: 'mhItemText', label: '物料文本' },
    { visible: false, prop: 'mhWcName', label: '工作中心' },
    { visible: false, prop: 'mhWcText', label: '工作中心文本' },
    { visible: true, prop: 'mhStdShort', label: '标准点数' },
    { visible: false, prop: 'mhShortUnit', label: 'Short单位' },
    { visible: true, prop: 'mhToMinRate', label: '点数换算汇率' },
    { visible: true, prop: 'mhStdTime', label: '标准工时' },
    { visible: false, prop: 'mhTimeUnit', label: '工时单位' },
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
  // 生效日期时间范围
  const dateRangeMhEffDate = ref([])
  //定义远程搜索变量
  const remotequeryList = ref([])
  //定义远程搜索变量
  const remotequery_sql_item_manhour = ref([])

  //远程字典参数
  var remotedictParams = [

    { dictType: "sql_item_manhour" },

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
        // remotequery_sql_item_manhour.value = remotequeryList.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod(query)
      }, 2000)
    } else {
      //默认显示前15条记录
      remotequery_sql_item_manhour.value.slice(0, 15)
    }
  }, 300)
  // 筛选方法
  const filterMethod = debounce((query) => {
    let arr = remotequeryList.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_item_manhour.value = arr.slice(0, 5)
      addFilterOptions(query)
    } else {
      remotequery_sql_item_manhour.value = arr
    }
  }, 300)
  // 精准筛选方法
  const addFilterOptions = debounce((dictValue) => {
    let target = remotequeryList.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_item_manhour.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_item_manhour.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
  //字典参数
  var dictParams = [
    { dictType: "app_plant_list" },
    { dictType: "sql_item_manhour" },
    { dictType: "app_work_center" },
    { dictType: "app_short_convert" },
  ]
  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从标准工时/pp_manhours表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMhEffDate.value, 'MhEffDate');
    loading.value = true
    listManhours(queryParams).then(res => {
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
    // 生效日期时间范围
    dateRangeMhEffDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.mhSFID);
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
      mhSFID: [{ required: true, message: 'SFID' + proxy.$t('btn.empty'), trigger: "blur" }],
      mhPlant: [{ required: true, message: '工厂' + proxy.$t('btn.empty'), trigger: "change" }],
      mhWcName: [{ required: true, message: '工作中心' + proxy.$t('btn.empty'), trigger: "change" }],
      mhStdShort: [{ required: true, message: '标准点数' + proxy.$t('btn.empty'), trigger: "blur" }],
      mhToMinRate: [{ required: true, message: '点数换算汇率' + proxy.$t('btn.empty'), trigger: "change" }],
      mhStdTime: [{ required: true, message: '标准工时' + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_plant_list: [],
      // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_item_manhour: [],
      // 工作中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_work_center: [],
      // 点数换算汇率 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_short_convert: [],
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
  // @Version: (0.24.389.13976)
  // @Author: (Lean365)
  // @Date: (2024/1/24 9:28:16)
  function assignModelValue(val) {
    //console.log(state.options.app_work_center);
    let obj = {};
    obj = remotequeryList.value.find((item) => {//这里的userList就是上面遍历的数据源
      return item.dictValue === val;//筛选出匹配数据
    });
    const arr = obj.dictLabel.split("|");
    form.value.mhModelType = arr[1]
    form.value.mhRegionType = arr[2]
    form.value.mhItemText = arr[3]
    console.log(obj)
  }
  function assignWorkValue(val) {
    //console.log(state.options.app_work_center);
    let obj = {};
    obj = state.options.app_work_center.find((item) => {//这里的userList就是上面遍历的数据源
      return item.dictValue === val;//筛选出匹配数据
    });
    //console.log(data, obj.dictLabel);
    //console.log(obj.label);//我这边的name就是对应label的
    form.value.mhWcText = obj.dictLabel
  }


  // 重置表单
  function reset() {
    form.value = {
      mhSFID: 0,
      mhEffDate: null,
      mhPlant: null,
      mhItem: null,
      mhModelType: null,
      mhRegionType: null,
      mhItemText: null,
      mhWcName: null,
      mhWcText: null,
      mhStdShort: 0,
      mhShortUnit: 'P',
      mhToMinRate: 0,
      mhStdTime: 0,
      mhTimeUnit: 'MIN',
      isDeleted: 0,
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
    title.value = proxy.$t('btn.add') + '标准工时'
    opertype.value = 1
    form.value.mhEffDate = new Date()
    form.value.mhPlant = 'C100'
    form.value.mhWcName = []
    form.value.mhStdShort = 0
    form.value.mhToMinRate = 1
    form.value.mhStdTime = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.mhSFID || ids.value
    getManhours(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + '标准工时'
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

        if (form.value.mhSFID != undefined && opertype.value === 2) {
          updateManhours(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addManhours(form.value).then((res) => {
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
    const Ids = row.mhSFID || ids.value

    proxy
      .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delManhours(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "标准工时", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/logistics/Manhours/export', { ...queryParams })
      })
  }


  // @Descripttion: (自定义函数/CustomFunctions)
  // @Functions: (assignValue,calculateValue,statisticValue)
  // @Version: (0.24.389.13976)
  // @Author: (Lean365)
  // @Date: (2024/1/24 9:28:16)

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