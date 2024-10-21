<!--
 * @Descripttion: 月度存货/fico_monthly_inventory
 * @Version: 0.24.619.29178
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 16:55:10
 * @column：38
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="期间" prop="mp002">
            <el-select filterable clearable v-model="queryParams.mp002"
              :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')" @change="handleLfgjaChange">
              <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="年月" prop="mp003">
            <el-select filterable clearable v-model="queryParams.mp003"
              :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   filteredLfmon " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="工厂" prop="mp004">
            <el-select filterable clearable v-model="queryParams.mp004"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料" prop="mp005">
            <el-input v-model="queryParams.mp005"
              :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['fico:monthlyinventory:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:monthlyinventory:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:monthlyinventory:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:monthlyinventory:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoMonthlyInventory/importTemplate"
                  importUrl="/Accounting/FicoMonthlyInventory/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:monthlyinventory:export']">
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')" />
      <el-table-column prop="mp002" label="期间" align="center" v-if="columns.showColumn('mp002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mp002" />
        </template>
      </el-table-column>
      <el-table-column prop="mp003" label="年月" align="center" v-if="columns.showColumn('mp003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mp003" />
        </template>
      </el-table-column>
      <el-table-column prop="mp004" label="工厂" align="center" v-if="columns.showColumn('mp004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mp004" />
        </template>
      </el-table-column>
      <el-table-column prop="mp005" label="物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mp005')" />
      <el-table-column prop="mp006" label="评估类" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mp006')" />
      <el-table-column prop="mp007" label="价格控制" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mp007')" />
      <el-table-column prop="mp008" label="移动平均价" align="center" v-if="columns.showColumn('mp008')" />
      <el-table-column prop="mp009" label="Per单位" align="center" v-if="columns.showColumn('mp009')" />
      <el-table-column prop="mp010" label="币种" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mp010')" />
      <el-table-column prop="mp011" label="库存" align="center" v-if="columns.showColumn('mp011')" />
      <el-table-column prop="mp012" label="金额" align="center" v-if="columns.showColumn('mp012')" />
      <el-table-column prop="mp013" label="核算人员" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mp013')" />
      <el-table-column prop="mp014" label="核算日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mp014')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:monthlyinventory:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['fico:monthlyinventory:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
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

              <el-col :lg="12">
                <el-form-item label="期间" prop="mp002">
                  <el-select filterable clearable v-model="form.mp002"
                    :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')" @change="handleLfgjaChange">
                    <el-option v-for="item in  options.sql_attr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="年月" prop="mp003">
                  <el-select filterable clearable v-model="form.mp003"
                    :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  filteredLfmon" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="工厂" prop="mp004">
                  <el-select filterable clearable v-model="form.mp004"
                    :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料" prop="mp005">
                  <el-input v-model="form.mp005" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评估类" prop="mp006">
                  <el-input v-model="form.mp006" :placeholder="$t('btn.enterPrefix')+'评估类'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="价格控制" prop="mp007">
                  <el-input v-model="form.mp007" :placeholder="$t('btn.enterPrefix')+'价格控制'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="移动平均价" prop="mp008">
                  <el-input-number v-model.number="form.mp008" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'移动平均价'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Per单位" prop="mp009">
                  <el-input-number v-model.number="form.mp009" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'Per单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="币种" prop="mp010">
                  <el-input v-model="form.mp010" :placeholder="$t('btn.enterPrefix')+'币种'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存" prop="mp011">
                  <el-input-number v-model.number="form.mp011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="金额" prop="mp012">
                  <el-input-number v-model.number="form.mp012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'金额'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="核算人员" prop="mp013">
                  <el-input v-model="form.mp013" :placeholder="$t('btn.enterPrefix')+'核算人员'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="核算日期" prop="mp014">
                  <el-date-picker v-model="form.mp014" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注说明" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.onboarding')" name="second">
            <el-row :gutter="20">
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
            <el-row :gutter="20">
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.attachment')" name="fourth">
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
          <el-tab-pane :label="$t('ptabs.sales')" name="tenth">
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
          <el-tab-pane :label="$t('ptabs.incoming')" name="14th">
            <el-row :gutter="20">
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.outgoing')" name="15th">
            <el-row :gutter="20">
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.customization')" name="16th">
            <el-row :gutter="20">
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.oper')" name="17th">
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

<script setup name="ficomonthlyinventory">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoMonthlyInventory,
    addFicoMonthlyInventory, delFicoMonthlyInventory,
    updateFicoMonthlyInventory, getFicoMonthlyInventory,
  }
    from '@/api/accounting/ficomonthlyinventory.js'
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
    pageSize: 56,
    sort: 'Mp003',
    sortType: 'desc',
    //是否查询（1是）
    mp002: undefined,
    //是否查询（1是）
    mp003: undefined,
    //是否查询（1是）
    mp004: undefined,
    //是否查询（1是）
    mp005: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mp002', label: '期间' },
    { visible: true, prop: 'mp003', label: '年月' },
    { visible: true, prop: 'mp004', label: '工厂' },
    { visible: true, prop: 'mp005', label: '物料' },
    { visible: true, prop: 'mp006', label: '评估类' },
    { visible: true, prop: 'mp007', label: '价格控制' },
    { visible: true, prop: 'mp008', label: '移动平均价' },
    { visible: false, prop: 'mp009', label: 'Per单位' },
    { visible: false, prop: 'mp010', label: '币种' },
    { visible: false, prop: 'mp011', label: '库存' },
    { visible: false, prop: 'mp012', label: '金额' },
    { visible: false, prop: 'mp013', label: '核算人员' },
    { visible: false, prop: 'mp014', label: '核算日期' },
    { visible: false, prop: 'remark', label: '备注说明' },
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
    { dictType: "sql_attr_list" },
    { dictType: "sql_ymdt_list" },
    { dictType: "sql_plant_list" },
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
    listFicoMonthlyInventory(queryParams).then(res => {
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
      id: [{ required: true, message: "ID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mp002: [{ required: true, message: "期间" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mp003: [{ required: true, message: "年月" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mp004: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mp005: [{ required: true, message: "物料" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mp009: [{ required: true, message: "Per单位" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      ref04: [{ required: true, message: "预留1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ref05: [{ required: true, message: "预留2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ref06: [{ required: true, message: "预留3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      udf51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      udf52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      udf53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      udf54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      udf55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      udf56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_attr_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ymdt_list: [],
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_plant_list: [],
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
      mp002: [],
      mp003: [],
      mp004: [],
      mp005: null,
      mp006: null,
      mp007: null,
      mp008: 0,
      mp009: 0,
      mp010: null,
      mp011: 0,
      mp012: 0,
      mp013: null,
      mp014: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '月度存货'
    opertype.value = 1
    form.value.mp002 = []
    form.value.mp003 = []
    form.value.mp004 = []
    form.value.mp008 = 0
    form.value.mp009 = 0
    form.value.mp011 = 0
    form.value.mp012 = 0
    form.value.mp014 = new Date()
  }
  // 使用 computed 属性来过滤数据: 过滤出选中的数据年月
  const filteredLfmon = ref([])
  function handleLfgjaChange() {
    //console.log(open.value === true)
    //console.log(state.options.sql_ymdt_list)
    if (open.value === true) {
      filteredLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === form.value.mp002)
      //console.log(form.value.fbasBukrs)
      // if (form.value.fbasBukrs === '2300') {
      //   form.value.fbasWaers = 'CNY'
      // }
      // if (form.value.fbasBukrs === '2400') {
      //   form.value.fbasWaers = 'HKD'
      // }
      // if (form.value.fbasBukrs === '1000') {
      //   form.value.fbasWaers = 'JPY'
      // }
      form.value.mp003 = ''
    }
    else {
      //console.log(queryParams.mp002)
      filteredLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === queryParams.mp002)
      queryParams.mp003 = ''
    }
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getFicoMonthlyInventory(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '月度存货'
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
          updateFicoMonthlyInventory(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addFicoMonthlyInventory(form.value).then((res) => {
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
        return delFicoMonthlyInventory(Ids)
      })
      .then(() => {
        getList()
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<月度存货.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoMonthlyInventory/export', { ...queryParams })
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