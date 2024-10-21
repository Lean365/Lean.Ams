<!--
 * @Descripttion: 工资率/fico_wage_rates
 * @Version: 0.24.614.27288
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 15:26:01
 * @column：39
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="期间" prop="mr002">
            <el-select filterable clearable v-model="queryParams.mr002"
              :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')" @change="handleLfgjaChange">
              <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="年月" prop="mr003">
            <el-select filterable clearable v-model="queryParams.mr003"
              :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   filteredLfmon " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="公司" prop="mr004">
            <el-select filterable clearable v-model="queryParams.mr004"
              :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')" @change="handleBukrsChange">
              <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="币种" prop="mr005">
            <el-select filterable clearable v-model="queryParams.mr005"
              :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
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
        <el-button class="btn-add" v-hasPermi="['fico:wagerates:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:wagerates:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:wagerates:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:wagerates:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoWageRates/importTemplate"
                  importUrl="/Accounting/FicoWageRates/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:wagerates:export']">
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
      <el-table-column prop="mr002" label="期间" align="center" v-if="columns.showColumn('mr002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mr002" />
        </template>
      </el-table-column>
      <el-table-column prop="mr003" label="年月" align="center" v-if="columns.showColumn('mr003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mr003" />
        </template>
      </el-table-column>
      <el-table-column prop="mr004" label="公司" align="center" v-if="columns.showColumn('mr004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mr004" />
        </template>
      </el-table-column>
      <el-table-column prop="mr005" label="币种" align="center" v-if="columns.showColumn('mr005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.mr005" />
        </template>
      </el-table-column>
      <el-table-column prop="mr006" label="销售额" align="center" v-if="columns.showColumn('mr006')" />
      <el-table-column prop="mr007" label="工作天数" align="center" v-if="columns.showColumn('mr007')" />
      <el-table-column prop="mr008" label="直接工资率" align="center" v-if="columns.showColumn('mr008')" />
      <el-table-column prop="mr009" label="直接人数" align="center" v-if="columns.showColumn('mr009')" />
      <el-table-column prop="mr010" label="直接加班费" align="center" v-if="columns.showColumn('mr010')" />
      <el-table-column prop="mr011" label="直接工资" align="center" v-if="columns.showColumn('mr011')" />
      <el-table-column prop="mr012" label="间接工资率" align="center" v-if="columns.showColumn('mr012')" />
      <el-table-column prop="mr013" label="间接人数" align="center" v-if="columns.showColumn('mr013')" />
      <el-table-column prop="mr014" label="间接加班费" align="center" v-if="columns.showColumn('mr014')" />
      <el-table-column prop="mr015" label="间接工资" align="center" v-if="columns.showColumn('mr015')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:wagerates:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['fico:wagerates:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改工资率对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="期间" prop="mr002">
                  <el-select filterable clearable v-model="form.mr002"
                    :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')" @change="handleLfgjaChange">
                    <el-option v-for="item in  options.sql_attr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="年月" prop="mr003">
                  <el-select filterable clearable v-model="form.mr003"
                    :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  filteredLfmon" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="公司" prop="mr004">
                  <el-select filterable clearable v-model="form.mr004"
                    :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')" @change="handleBukrsChange">
                    <el-option v-for="item in  options.sql_corp_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="币种" prop="mr005">
                  <el-select filterable clearable v-model="form.mr005"
                    :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_global_currency" :key="item.dictValue"
                      :label="item.dictLabel" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="销售额" prop="mr006">
                  <el-input-number v-model.number="form.mr006" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'销售额'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工作天数" prop="mr007">
                  <el-input-number v-model.number="form.mr007" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'工作天数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="直接工资率" prop="mr008">
                  <el-input-number v-model.number="form.mr008" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'直接工资率'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="直接人数" prop="mr009">
                  <el-input-number v-model.number="form.mr009" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'直接人数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="直接加班费" prop="mr010">
                  <el-input-number v-model.number="form.mr010" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'直接加班费'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="直接工资" prop="mr011">
                  <el-input-number v-model.number="form.mr011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'直接工资'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接工资率" prop="mr012">
                  <el-input-number v-model.number="form.mr012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间接工资率'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接人数" prop="mr013">
                  <el-input-number v-model.number="form.mr013" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间接人数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接加班费" prop="mr014">
                  <el-input-number v-model.number="form.mr014" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间接加班费'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接工资" prop="mr015">
                  <el-input-number v-model.number="form.mr015" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间接工资'+$t('btn.enterSuffix')" />
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

<script setup name="ficowagerates">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoWageRates,
    addFicoWageRates, delFicoWageRates,
    updateFicoWageRates, getFicoWageRates,
  }
    from '@/api/accounting/ficowagerates.js'
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
    sort: 'Mr002',
    sortType: 'desc',
    //是否查询（1是）
    mr002: undefined,
    //是否查询（1是）
    mr003: undefined,
    //是否查询（1是）
    mr004: undefined,
    //是否查询（1是）
    mr005: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mr002', label: '期间' },
    { visible: true, prop: 'mr003', label: '年月' },
    { visible: true, prop: 'mr004', label: '公司' },
    { visible: true, prop: 'mr005', label: '币种' },
    { visible: true, prop: 'mr006', label: '销售额' },
    { visible: true, prop: 'mr007', label: '工作天数' },
    { visible: true, prop: 'mr008', label: '直接工资率' },
    { visible: false, prop: 'mr009', label: '直接人数' },
    { visible: false, prop: 'mr010', label: '直接加班费' },
    { visible: false, prop: 'mr011', label: '直接工资' },
    { visible: false, prop: 'mr012', label: '间接工资率' },
    { visible: false, prop: 'mr013', label: '间接人数' },
    { visible: false, prop: 'mr014', label: '间接加班费' },
    { visible: false, prop: 'mr015', label: '间接工资' },
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
    { dictType: "sql_corp_list" },
    { dictType: "sql_global_currency" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从工资率/fico_wage_rates表记录数据
  function getList() {
    loading.value = true
    listFicoWageRates(queryParams).then(res => {
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
      mr002: [{ required: true, message: "期间" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mr003: [{ required: true, message: "年月" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mr004: [{ required: true, message: "公司" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mr005: [{ required: true, message: "币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mr006: [{ required: true, message: "销售额" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mr007: [{ required: true, message: "工作天数" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mr008: [{ required: true, message: "直接工资率" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mr009: [{ required: true, message: "直接人数" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mr010: [{ required: true, message: "直接加班费" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mr011: [{ required: true, message: "直接工资" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_attr_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ymdt_list: [],
      // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_corp_list: [],
      // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_global_currency: [],
      // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_deleted: [],
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
      mr002: [],
      mr003: [],
      mr004: [],
      mr005: [],
      mr006: 0,
      mr007: 0,
      mr008: 0,
      mr009: 0,
      mr010: 0,
      mr011: 0,
      mr012: 0,
      mr013: 0,
      mr014: 0,
      mr015: 0,
      remark: null,
    };
    proxy.resetForm("formRef")
  }
  // 使用 computed 属性来过滤数据: 过滤出选中的数据年月
  const filteredLfmon = ref([])
  function handleLfgjaChange() {
    //console.log(open.value === true)
    //console.log(state.options.sql_ymdt_list)
    if (open.value === true) {
      form.value.mr003 = ''
      filteredLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === form.value.mr002)
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

    }
    else {
      //console.log(queryParams.mp002)
      queryParams.mr003 = ''
      filteredLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === queryParams.mr002)

    }
  }
  // 使用 computed 属性来过滤数据
  const filteredSaknr = ref([])
  function handleBukrsChange() {
    //console.log(open.value === true)
    //console.log(state.options.sql_global_currency)
    if (open.value === true) {
      form.value.mr005 = ''
      //filteredSaknr.value = state.options.sql_global_currency.value.filter(item => item.label === form.value.mb003)
      //console.log(state.options.sql_global_currency)
      if (form.value.mr004 === '0001') {
        //console.log(state.options.sql_global_currency)
        //filteredSaknr.value = state.options.sql_global_currency.value.filter(item => item.dictValue === 'CNY')
        form.value.mr005 = 'EUR'
        //console.log(queryParams.mb004)
      }
      if (form.value.mr004 === '2300') {
        //console.log(state.options.sql_global_currency)
        //filteredSaknr.value = state.options.sql_global_currency.value.filter(item => item.dictValue === 'CNY')
        form.value.mr005 = 'CNY'
        //console.log(queryParams.mb004)
      }
      if (form.value.mr004 === '2400') {
        form.value.mr005 = 'HKD'
      }
      if (form.value.mr004 === '1000') {
        form.value.mr005 = 'JPY'
      }
      if (form.value.mr004 === '2700') {
        form.value.mr005 = 'CNY'
      }
      if (form.value.mr004 === '3000') {
        form.value.mr005 = 'USD'
      }
      if (form.value.mr004 === '4000') {
        form.value.mr005 = 'EUR'
      }
      if (form.value.mr004 === '4100') {
        form.value.mr005 = 'EUR'
      }
      //form.value.mb004 = ''
    }
    else {
      queryParams.mr005 = ''
      //filteredSaknr.value = state.options.sql_global_currency.value.filter(item => item.label === queryParams.mb003)
      if (queryParams.mr004 === '0001') {
        console.log(state.options.sql_global_currency)
        //filteredSaknr.value = state.options.sql_global_currency.value.filter(item => item.dictValue === 'CNY')
        queryParams.mr005 = 'EUR'
        //console.log(queryParams.mb004)
      }
      if (queryParams.mr004 === '2300') {
        //console.log(state.options.sql_global_currency)
        //filteredSaknr.value = state.options.sql_global_currency.value.filter(item => item.dictValue === 'CNY')
        queryParams.mr005 = 'CNY'
        //console.log(queryParams.mb004)
      }
      if (queryParams.mr004 === '2400') {
        queryParams.mr005 = 'HKD'
      }
      if (queryParams.mr004 === '1000') {
        queryParams.mr005 = 'JPY'
      }
      if (queryParams.mr004 === '2700') {
        queryParams.mr005 = 'CNY'
      }
      if (queryParams.mr004 === '3000') {
        queryParams.mr005 = 'USD'
      }
      if (queryParams.mr004 === '4000') {
        queryParams.mr005 = 'EUR'
      }
      if (queryParams.mr004 === '4100') {
        queryParams.mr005 = 'EUR'
      }
      //queryParams.mb003 = ''
    }



  }

  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '工资率'
    opertype.value = 1
    form.value.mr002 = []
    form.value.mr003 = []
    form.value.mr004 = []
    form.value.mr005 = []
    form.value.mr006 = 0
    form.value.mr007 = 0
    form.value.mr008 = 0
    form.value.mr009 = 0
    form.value.mr010 = 0
    form.value.mr011 = 0
    form.value.mr012 = 0
    form.value.mr013 = 0
    form.value.mr014 = 0
    form.value.mr015 = 0
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getFicoWageRates(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '工资率'
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
          updateFicoWageRates(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addFicoWageRates(form.value).then((res) => {
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
        return delFicoWageRates(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<工资率.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoWageRates/export', { ...queryParams })
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