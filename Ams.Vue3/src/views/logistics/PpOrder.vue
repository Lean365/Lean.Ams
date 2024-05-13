<!--
 * @Descripttion: 生产工单/pp_order
 * @Version: 0.24.495.26722
 * @Author: Lean365(Davis.Ching)(Davis.Ching)
 * @Date: 2024/5/9 15:36:42
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-form-item label="生产工厂" prop="moPlant">
        <el-select filterable clearable v-model="queryParams.moPlant" :placeholder="$t('btn.select')+'生产工厂'">
          <el-option v-for="item in   options.app_plant_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="订单类型" prop="moOrderType">
        <el-select filterable clearable v-model="queryParams.moOrderType" :placeholder="$t('btn.select')+'订单类型'">
          <el-option v-for="item in   options.app_mo_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产订单" prop="moOrderNo">
        <el-input v-model="queryParams.moOrderNo" :placeholder="$t('btn.enter')+'生产订单'" />
      </el-form-item>
      <el-form-item label="物料" prop="moOrderItem">
        <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod" :loading="loading "
          v-model="queryParams.moOrderItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="批次" prop="moOrderlot">
        <el-input v-model="queryParams.moOrderlot" :placeholder="$t('btn.enter')+'批次'" />
      </el-form-item>
      <el-form-item label="订单日期">
        <el-date-picker v-model="dateRangeMoOrderDate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
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
        <el-button type="primary" v-hasPermi="['pp:order:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:order:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:order:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:order:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="logistics/PpOrder/importTemplate" importUrl="/logistics/PpOrder/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['pp:order:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="650" :data="dataList" v-loading="loading" ref="table"
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="moSFID" label="SFID" align="center" v-if="columns.showColumn('moSFID')" />
      <el-table-column prop="moPlant" label="生产工厂" align="center" v-if="columns.showColumn('moPlant')">
        <template #default="scope">
          <dict-tag :options=" options.app_plant_list " :value="scope.row.moPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="moOrderType" label="订单类型" align="center" v-if="columns.showColumn('moOrderType')">
        <template #default="scope">
          <dict-tag :options=" options.app_mo_type " :value="scope.row.moOrderType" />
        </template>
      </el-table-column>
      <el-table-column prop="moOrderNo" label="生产订单" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moOrderNo')" />
      <el-table-column prop="moOrderItem" label="物料" align="center" v-if="columns.showColumn('moOrderItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.moOrderItem" />
        </template>
      </el-table-column>
      <el-table-column prop="moOrderlot" label="批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moOrderlot')" />
      <el-table-column prop="moOrderQty" label="工单数量" align="center" v-if="columns.showColumn('moOrderQty')" />
      <el-table-column prop="moOrderProQty" label="生产数量" align="center" v-if="columns.showColumn('moOrderProQty')" />
      <el-table-column prop="moOrderDate" label="订单日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moOrderDate')">
        <template #default="scope"> {{ parseTime(scope.row.moOrderDate, 'YYYY-MM-DD') }} </template>
      </el-table-column>
      <el-table-column prop="moOrderRoute" label="工艺路线" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moOrderRoute')" />
      <el-table-column prop="moOrderSerial" label="序列号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moOrderSerial')" />
      <el-table-column prop="isStated" label="状态" align="center" v-if="columns.showColumn('isStated')" />
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
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button type="success" plain size="small" icon="edit" :title="$t('btn.edit')"
            v-hasPermi="['pp:order:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" plain size="small" icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['pp:order:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />


    <!-- 添加或修改生产工单对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="SFID" prop="moSFID">
                  <el-input v-model.number="form.moSFID" :placeholder="$t('btn.enter')+'SFID'"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产工厂" prop="moPlant">
                  <el-select filterable clearable v-model="form.moPlant" :placeholder="$t('btn.select')+'生产工厂'">
                    <el-option v-for="item in  options.app_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="订单类型" prop="moOrderType">
                  <el-select filterable clearable v-model="form.moOrderType" :placeholder="$t('btn.select')+'订单类型'">
                    <el-option v-for="item in  options.app_mo_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="生产订单" prop="moOrderNo">
                  <el-input v-model="form.moOrderNo" :placeholder="$t('btn.enter')+'生产订单'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="moOrderItem">
                  <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod"
                    :loading="loading " v-model="form.moOrderItem" :placeholder="$t('btn.select')+'物料'">
                    <el-option v-for="item in  remotequery_sql_mats_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="批次" prop="moOrderlot">
                  <el-input v-model="form.moOrderlot" :placeholder="$t('btn.enter')+'批次'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工单数量" prop="moOrderQty">
                  <el-input-number v-model.number="form.moOrderQty" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'工单数量'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产数量" prop="moOrderProQty">
                  <el-input-number v-model.number="form.moOrderProQty" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'生产数量'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="订单日期" prop="moOrderDate">
                  <el-date-picker v-model="form.moOrderDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工艺路线" prop="moOrderRoute">
                  <el-input v-model="form.moOrderRoute" :placeholder="$t('btn.enter')+'工艺路线'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序列号" prop="moOrderSerial">
                  <el-input v-model="form.moOrderSerial" :placeholder="$t('btn.enter')+'序列号'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="状态" prop="isStated">
                  <el-input-number v-model.number="form.isStated" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'状态'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-input-number v-model.number="form.isDeleted" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enter')+'软删除'" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建者" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新者" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.select')"></el-date-picker>
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

<script setup name="pporder">
  //后台操作函数
  import {
    listPpOrder,
    addPpOrder, delPpOrder,
    updatePpOrder, getPpOrder,
  }
    from '@/api/logistics/pporder.js'
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
    sort: 'MoOrderDate',
    sortType: 'asc',
    //是否查询（1是）
    moPlant: undefined,
    //是否查询（1是）
    moOrderType: undefined,
    //是否查询（1是）
    moOrderNo: undefined,
    //是否查询（1是）
    moOrderItem: undefined,
    //是否查询（1是）
    moOrderlot: undefined,
    //是否查询（1是）
    moOrderDate: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'moSFID', label: 'SFID' },
    { visible: true, prop: 'moPlant', label: '生产工厂' },
    { visible: true, prop: 'moOrderType', label: '订单类型' },
    { visible: true, prop: 'moOrderNo', label: '生产订单' },
    { visible: true, prop: 'moOrderItem', label: '物料' },
    { visible: true, prop: 'moOrderlot', label: '批次' },
    { visible: true, prop: 'moOrderQty', label: '工单数量' },
    { visible: true, prop: 'moOrderProQty', label: '生产数量' },
    { visible: false, prop: 'moOrderDate', label: '订单日期' },
    { visible: false, prop: 'moOrderRoute', label: '工艺路线' },
    { visible: false, prop: 'moOrderSerial', label: '序列号' },
    { visible: false, prop: 'isStated', label: '状态' },
    { visible: false, prop: 'remark', label: '备注' },
    { visible: false, prop: 'createBy', label: '创建者' },
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
  const remotequeryList = ref([])
  //定义远程搜索变量
  const remotequery_sql_mats_list = ref([])

  //远程字典参数
  var remotedictParams = [

    { dictType: "sql_mats_list" },

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
        // remotequery_sql_mats_list.value = remotequeryList.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod(query)
      }, 2000)
    } else {
      //默认显示前15条记录
      remotequery_sql_mats_list.value.slice(0, 15)
    }
  }, 300)
  // 筛选方法
  const filterMethod = debounce((query) => {
    let arr = remotequeryList.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_mats_list.value = arr.slice(0, 5)
      addFilterOptions(query)
    } else {
      remotequery_sql_mats_list.value = arr
    }
  }, 300)
  // 精准筛选方法
  const addFilterOptions = debounce((dictValue) => {
    let target = remotequeryList.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_mats_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_mats_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)




  // 订单日期时间范围
  const dateRangeMoOrderDate = ref([])











  //字典参数
  var dictParams = [
    { dictType: "app_plant_list" },
    { dictType: "app_mo_type" },
    { dictType: "sql_mats_list" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从生产工单/pp_order表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMoOrderDate.value, 'MoOrderDate');
    loading.value = true
    listPpOrder(queryParams).then(res => {
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
    // 订单日期时间范围
    dateRangeMoOrderDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.moSFID);
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
      moSFID: [{ required: true, message: "SFID不能为空", trigger: "blur" }],
      moPlant: [{ required: true, message: "生产工厂不能为空", trigger: "change" }],
      moOrderType: [{ required: true, message: "订单类型不能为空", trigger: "change" }],
      moOrderNo: [{ required: true, message: "生产订单不能为空", trigger: "blur" }],
      moOrderItem: [{ required: true, message: "物料不能为空", trigger: "blur" }],
      moOrderQty: [{ required: true, message: "工单数量不能为空", trigger: "blur" }],
      moOrderProQty: [{ required: true, message: "生产数量不能为空", trigger: "blur" }],
      moOrderDate: [{ required: true, message: "订单日期不能为空", trigger: "blur" }],
      isStated: [{ required: true, message: "状态不能为空", trigger: "blur", type: "number" }],
    },
    options: {
      // 生产工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_plant_list: [],
      // 订单类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_mo_type: [],
      // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_mats_list: [],
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
      moSFID: 0,
      moSFID: null,
      moPlant: null,
      moPlant: null,
      moOrderType: null,
      moOrderType: null,
      moOrderNo: null,
      moOrderNo: null,
      moOrderItem: null,
      moOrderItem: null,
      moOrderlot: null,
      moOrderlot: null,
      moOrderQty: 0,
      moOrderQty: null,
      moOrderProQty: 0,
      moOrderProQty: null,
      moOrderDate: null,
      moOrderDate: null,
      moOrderRoute: null,
      moOrderRoute: null,
      moOrderSerial: null,
      moOrderSerial: null,
      isStated: 0,
      isStated: null,
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
    title.value = proxy.$t('btn.add') + '生产工单'
    opertype.value = 1
    form.value.moPlant = []
    form.value.moOrderType = []
    form.value.moOrderQty = 0
    form.value.moOrderProQty = 0
    form.value.moOrderDate = new Date()
    form.value.isStated = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.moSFID || ids.value
    getPpOrder(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + '生产工单'
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

        if (form.value.moSFID != undefined && opertype.value === 2) {
          updatePpOrder(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addPpOrder(form.value).then((res) => {
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
    const Ids = row.moSFID || ids.value

    proxy
      .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'), proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delPpOrder(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "生产工单", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/logistics/PpOrder/export', { ...queryParams })
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