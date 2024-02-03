<!--
 * @Descripttion: (月度存货/fico_monthly_inventory)
 * @Version: (0.24.390.14851)
 * @Author: (Lean365)
 * @Date: (2024/1/25 8:20:25)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="miPlant">
        <el-select clearable filterable v-model="queryParams.miPlant" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.app_plant_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="期间" prop="miFy">
        <el-select clearable filterable v-model="queryParams.miFy" :placeholder="$t('btn.select')+'期间'">
          <el-option v-for="item in  options.sql_period_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="miYm">
        <el-select clearable filterable v-model="queryParams.miYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ficoym_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="miItem">
        <el-select filterable remote remote-show-suffix :remote-method="remoteMethod" clearable :loading="loading"
          v-model="queryParams.miItem" :placeholder="$t('btn.select')+'物料'">
          <el-option v-for="item in  remotequery_sql_mats_list" :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估类" prop="miValType">
        <el-select clearable filterable v-model="queryParams.miValType" :placeholder="$t('btn.select')+'评估类'">
          <el-option v-for="item in  options.app_val_type " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="miLocalCcy">
        <el-select clearable filterable v-model="queryParams.miLocalCcy" :placeholder="$t('btn.select')+'币种'">
          <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button type="primary" v-hasPermi="['fico:monthlyinventory:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:monthlyinventory:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:monthlyinventory:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:monthlyinventory:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="accounting/MonthlyInventory/importTemplate"
                  importUrl="/accounting/MonthlyInventory/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:monthlyinventory:export']">
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
      <el-table-column prop="miSFID" label="SFID" align="center" v-if="columns.showColumn('miSFID')" />
      <el-table-column prop="miPlant" label="工厂" align="center" v-if="columns.showColumn('miPlant')">
        <template #default="scope">
          <dict-tag :options=" options.app_plant_list " :value="scope.row.miPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="miFy" label="期间" align="center" v-if="columns.showColumn('miFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.miFy" />
        </template>
      </el-table-column>
      <el-table-column prop="miYm" label="年月" align="center" v-if="columns.showColumn('miYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ficoym_list " :value="scope.row.miYm" />
        </template>
      </el-table-column>
      <el-table-column prop="miItem" label="物料" align="center" v-if="columns.showColumn('miItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.miItem" />
        </template>
      </el-table-column>
      <el-table-column prop="miValType" label="评估类" align="center" v-if="columns.showColumn('miValType')">
        <template #default="scope">
          <dict-tag :options=" options.app_val_type " :value="scope.row.miValType" />
        </template>
      </el-table-column>
      <el-table-column prop="miPriceControl" label="价格控制" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('miPriceControl')" />
      <el-table-column prop="miMovingAverage" label="移动平均价" align="center"
        v-if="columns.showColumn('miMovingAverage')" />
      <el-table-column prop="miPerUnit" label="Per单位" align="center" v-if="columns.showColumn('miPerUnit')" />
      <el-table-column prop="miLocalCcy" label="币种" align="center" v-if="columns.showColumn('miLocalCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.miLocalCcy" />
        </template>
      </el-table-column>
      <el-table-column prop="miInventoryQty" label="库存" align="center" v-if="columns.showColumn('miInventoryQty')" />
      <el-table-column prop="miInventoryAmount" label="金额" align="center"
        v-if="columns.showColumn('miInventoryAmount')" />
      <el-table-column prop="miBalancedate" label="登录日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('miBalancedate')" />
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true"
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
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')"
            v-hasPermi="['fico:monthlyinventory:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['fico:monthlyinventory:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />


    <!-- 添加或修改月度存货对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <!-- <el-col :lg="12">
                <el-form-item label="SFID" prop="miSFID">
                  <el-input v-model.number="form.miSFID" :placeholder="$t('btn.enter')+'SFID'"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col> -->

              <el-col :lg="12">
                <el-form-item label="工厂" prop="miPlant">
                  <el-select clearable filterable v-model="form.miPlant" :placeholder="$t('btn.select')+'工厂'">
                    <el-option v-for="item in options.app_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="期间" prop="miFy">
                  <el-select clearable filterable v-model="form.miFy" :placeholder="$t('btn.select')+'期间'">
                    <el-option v-for="item in options.sql_period_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="年月" prop="miYm">
                  <el-select clearable filterable v-model="form.miYm" :placeholder="$t('btn.select')+'年月'">
                    <el-option v-for="item in options.sql_ficoym_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="miItem">
                  <el-select filterable remote remote-show-suffix :remote-method="remoteMethod" clearable
                    :loading="loading" style="width: 360px" v-model="form.miItem" :placeholder="$t('btn.select')+'物料'">
                    <el-option v-for="item in  remotequery_sql_mats_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评估类" prop="miValType">
                  <el-select clearable filterable v-model="form.miValType" :placeholder="$t('btn.select')+'评估类'">
                    <el-option v-for="item in options.app_val_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="价格控制" prop="miPriceControl">
                  <el-input clearable v-model="form.miPriceControl" :placeholder="$t('btn.enter')+'价格控制'" maxlength="1"
                    show-word-limit :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="移动平均价" prop="miMovingAverage">
                  <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.miMovingAverage"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'移动平均价'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Per单位" prop="miPerUnit">
                  <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.miPerUnit"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'Per单位'"
                    :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="币种" prop="miLocalCcy">
                  <el-select clearable filterable v-model="form.miLocalCcy" :placeholder="$t('btn.select')+'币种'">
                    <el-option v-for="item in options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存" prop="miInventoryQty">
                  <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.miInventoryQty"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'库存'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="金额" prop="miInventoryAmount">
                  <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.miInventoryAmount"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'金额'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="登录日期" prop="miBalancedate">
                  <el-date-picker v-model="form.miBalancedate" type="datetime" :teleported="false"
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
                <el-form-item label="说明" prop="remark">
                  <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'说明'" />
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

<script setup name="monthlyinventory">
  //后台操作函数
  import {
    listMonthlyInventory,
    addMonthlyInventory, delMonthlyInventory,
    updateMonthlyInventory, getMonthlyInventory,
  }
    from '@/api/accounting/monthlyinventory.js'
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
    miPlant: undefined,
    miFy: undefined,
    miYm: undefined,
    miItem: undefined,
    miValType: undefined,
    miLocalCcy: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'miSFID', label: 'SFID' },
    { visible: true, prop: 'miPlant', label: '工厂' },
    { visible: true, prop: 'miFy', label: '期间' },
    { visible: true, prop: 'miYm', label: '年月' },
    { visible: true, prop: 'miItem', label: '物料' },
    { visible: true, prop: 'miValType', label: '评估类' },
    { visible: true, prop: 'miPriceControl', label: '价格控制' },
    { visible: true, prop: 'miMovingAverage', label: '移动平均价' },
    { visible: false, prop: 'miPerUnit', label: 'Per单位' },
    { visible: false, prop: 'miLocalCcy', label: '币种' },
    { visible: false, prop: 'miInventoryQty', label: '库存' },
    { visible: false, prop: 'miInventoryAmount', label: '金额' },
    { visible: false, prop: 'miBalancedate', label: '登录日期' },
    { visible: false, prop: 'remark', label: '说明' },
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
  //字典参数
  var dictParams = [
    { dictType: "app_plant_list" },
    { dictType: "sql_period_list" },
    { dictType: "sql_ficoym_list" },
    { dictType: "sql_mats_list" },
    { dictType: "app_val_type" },
    { dictType: "sys_ccy_type" },
  ]
  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从月度存货/fico_monthly_inventory表记录数据
  function getList() {
    loading.value = true
    listMonthlyInventory(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.miSFID);
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
      miSFID: [{ required: true, message: 'SFID' + proxy.$t('btn.empty'), trigger: "blur" }],
      miPlant: [{ required: true, message: '工厂' + proxy.$t('btn.empty'), trigger: "change" }],
      miFy: [{ required: true, message: '期间' + proxy.$t('btn.empty'), trigger: "change" }],
      miYm: [{ required: true, message: '年月' + proxy.$t('btn.empty'), trigger: "change" }],
      miItem: [{ required: true, message: '物料' + proxy.$t('btn.empty'), trigger: "blur" }],
      miValType: [{ required: true, message: '评估类' + proxy.$t('btn.empty'), trigger: "change" }],
      miPriceControl: [{ required: true, message: '价格控制' + proxy.$t('btn.empty'), trigger: "blur" }],
      miMovingAverage: [{ required: true, message: '移动平均价' + proxy.$t('btn.empty'), trigger: "blur" }],
      miPerUnit: [{ required: true, message: 'Per单位' + proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
      miLocalCcy: [{ required: true, message: '币种' + proxy.$t('btn.empty'), trigger: "change" }],
      miInventoryQty: [{ required: true, message: '库存' + proxy.$t('btn.empty'), trigger: "blur" }],
      miInventoryAmount: [{ required: true, message: '金额' + proxy.$t('btn.empty'), trigger: "blur" }],
      miBalancedate: [{ required: true, message: '登录日期' + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_plant_list: [],
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_period_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ficoym_list: [],
      // 物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_mats_list: [],
      // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      app_val_type: [],
      // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
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
  // @Version: (0.24.390.14851)
  // @Author: (Lean365)
  // @Date: (2024/1/25 8:20:25)



  // 重置表单
  function reset() {
    form.value = {
      miSFID: 0,
      miPlant: null,
      miFy: null,
      miYm: null,
      miItem: null,
      miValType: null,
      miPriceControl: 'V',
      miMovingAverage: 0,
      miPerUnit: 0,
      miLocalCcy: null,
      miInventoryQty: 0,
      miInventoryAmount: 0,
      miBalancedate: null,
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
    title.value = proxy.$t('btn.add') + '月度存货'
    opertype.value = 1
    form.value.miPlant = []
    form.value.miFy = []
    form.value.miYm = []
    form.value.miValType = []
    form.value.miMovingAverage = 0
    form.value.miPerUnit = 1000
    form.value.miLocalCcy = []
    form.value.miInventoryQty = 0
    form.value.miInventoryAmount = 0
    form.value.miBalancedate = new Date()
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.miSFID || ids.value
    getMonthlyInventory(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + '月度存货'
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

        if (form.value.miSFID != undefined && opertype.value === 2) {
          updateMonthlyInventory(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addMonthlyInventory(form.value).then((res) => {
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
    const Ids = row.miSFID || ids.value

    proxy
      .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delMonthlyInventory(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "月度存货", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/accounting/MonthlyInventory/export', { ...queryParams })
      })
  }


  // @Descripttion: (自定义函数/CustomFunctions)
  // @Functions: (assignValue,calculateValue,statisticValue)
  // @Version: (0.24.390.14851)
  // @Author: (Lean365)
  // @Date: (2024/1/25 8:20:25)

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