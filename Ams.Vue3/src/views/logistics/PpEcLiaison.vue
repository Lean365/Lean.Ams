<!--
 * @Descripttion: 技联/pp_ec_liaison
 * @Version: 0.24.622.18534
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/13 10:18:56
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
          <el-form-item label="发行日">
            <el-date-picker v-model="dateRangeMa002" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="机种明细" prop="ma003">
            <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip v-model="queryParams.ma003"
              :placeholder="$t('btn.selectSearchPrefix')+'机种明细'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_sap_model " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="担当" prop="ma004">
            <el-select filterable clearable v-model="queryParams.ma004"
              :placeholder="$t('btn.selectSearchPrefix')+'担当'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button class="btn-add" v-hasPermi="['pp:ecliaison:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:ecliaison:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:ecliaison:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecliaison:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/PpEcLiaison/importTemplate"
                  importUrl="/Logistics/PpEcLiaison/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecliaison:export']">
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
      <el-table-column prop="ma002" label="发行日" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma002')">
        <template #default="scope"> {{ parseTime(scope.row.ma002, 'YYYY-MM-DD') }} </template>
      </el-table-column>
      <el-table-column prop="ma003" label="机种明细" align="center" v-if="columns.showColumn('ma003')"
        show-overflow-tooltip>
        <template #default="scope">
          <dict-tag :options=" options.sql_sap_model " :value="scope.row.ma003" split="," />
        </template>
      </el-table-column>
      <el-table-column prop="ma004" label="担当" align="center" v-if="columns.showColumn('ma004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.ma004" />
        </template>
      </el-table-column>
      <el-table-column prop="ma005" label="输入日" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma005')">
        <template #default="scope"> {{ parseTime(scope.row.ma005, 'YYYY-MM-DD') }} </template>
      </el-table-column>
      <el-table-column prop="ma006" label="技联NO." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma006')" />
      <el-table-column prop="ma007" label="技联文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma007')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.ma007" target="_blank">{{ scope.row.ma006 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="ma008" label="P番NO." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma008')" />
      <el-table-column prop="ma009" label="P番文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma009')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.ma009" target="_blank">{{ scope.row.ma008 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="ma010" label="TCJ P番NO." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma010')" />
      <el-table-column prop="ma011" label="TCJ P番文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma011')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.ma011" target="_blank">{{ scope.row.ma010 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="ma012" label="外联NO." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma012')" />
      <el-table-column prop="ma013" label="外联文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma013')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.ma013" target="_blank">{{ scope.row.ma012 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="ma014" label="其它NO." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma014')" />
      <el-table-column prop="ma015" label="附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma015')">
        <template #default="scope">
          <el-link type="primary" :href="scope.row.ma015" target="_blank">{{ scope.row.ma014 }}</el-link>
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['pp:ecliaison:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['pp:ecliaison:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改技联对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="发行日" prop="ma002">
                  <el-date-picker v-model="form.ma002" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="机种明细" prop="ma003">
                  <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip :max-collapse-tags="4"
                    style="width: 600px;" v-model="form.ma003Checked"
                    :placeholder="$t('btn.selectPrefix')+'机种明细'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_sap_model" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="担当" prop="ma004">
                  <el-select filterable clearable v-model="form.ma004"
                    :placeholder="$t('btn.selectPrefix')+'担当'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_ec_group" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="输入日" prop="ma005">
                  <el-date-picker v-model="form.ma005" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="技联NO." prop="ma006">
                  <el-input v-model="form.ma006" :placeholder="$t('btn.enterPrefix')+'技联NO.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="技联文件" prop="ma007">
                  <UploadFile v-model="form.ma007" fileSize="20" :fileType="['pdf']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'logistics/liaison' ,uploadType: 1}" />
                  <!-- <UploadFile v-model="form.ma007" :data="{ uploadType: 1 }" /> -->
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="P番NO." prop="ma008">
                  <el-input v-model="form.ma008" :placeholder="$t('btn.enterPrefix')+'P番NO.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="P番文件" prop="ma009">
                  <UploadFile v-model="form.ma009" fileSize="20" :fileType="['pdf']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'logistics/liaison' ,uploadType: 1}" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="TCJ P番NO." prop="ma010">
                  <el-input v-model="form.ma010" :placeholder="$t('btn.enterPrefix')+'TCJ P番NO.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="TCJ P番文件" prop="ma011">
                  <UploadFile v-model="form.ma011" fileSize="20" :fileType="['pdf']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'logistics/liaison' ,uploadType: 1}" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="外联NO." prop="ma012">
                  <el-input v-model="form.ma012" :placeholder="$t('btn.enterPrefix')+'外联NO.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="外联文件" prop="ma013">
                  <UploadFile v-model="form.ma013" fileSize="20" :fileType="['pdf']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'logistics/liaison' ,uploadType: 1}" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其它NO." prop="ma014">
                  <el-input v-model="form.ma014" :placeholder="$t('btn.enterPrefix')+'其它NO.'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="附件" prop="ma015">
                  <UploadFile v-model="form.ma015" fileSize="20" :fileType="['pdf']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'logistics/liaison' ,uploadType: 1}" />
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

<script setup name="ppecliaison">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listPpEcLiaison,
    addPpEcLiaison, delPpEcLiaison,
    updatePpEcLiaison, getPpEcLiaison,
  }
    from '@/api/logistics/ppecliaison.js'
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
    sort: 'Ma002',
    sortType: 'desc',
    //是否查询（1是）
    ma002: undefined,
    //是否查询（1是）
    ma003: undefined,
    //是否查询（1是）
    ma004: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'id', label: 'ID' },
    { visible: true, prop: 'ma002', label: '发行日' },
    { visible: true, prop: 'ma003', label: '机种明细' },
    { visible: true, prop: 'ma004', label: '担当' },
    { visible: true, prop: 'ma005', label: '输入日' },
    { visible: false, prop: 'ma006', label: '技联NO.' },
    { visible: true, prop: 'ma007', label: '技联文件' },
    { visible: false, prop: 'ma008', label: 'P番NO.' },
    { visible: true, prop: 'ma009', label: 'P番文件' },
    { visible: false, prop: 'ma010', label: 'TCJ P番NO.' },
    { visible: true, prop: 'ma011', label: 'TCJ P番文件' },
    { visible: false, prop: 'ma012', label: '外联NO.' },
    { visible: true, prop: 'ma013', label: '外联文件' },
    { visible: false, prop: 'ma014', label: '其它NO.' },
    { visible: true, prop: 'ma015', label: '附件' },
    { visible: false, prop: 'remark', label: '备注' },
  ])
  // 记录数
  const total = ref(0)
  //定义数据变量
  const dataList = ref([])
  //查询参数
  const queryRef = ref()
  //定义起始时间
  const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
  // 发行日时间范围
  const dateRangeMa002 = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sql_sap_model" },
    { dictType: "sql_ec_group" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从技联/pp_ec_liaison表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMa002.value, 'Ma002');
    loading.value = true
    listPpEcLiaison(queryParams).then(res => {
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
    // 发行日时间范围
    dateRangeMa002.value = []
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
      ma002: [{ required: true, message: "发行日" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
      // 机种明细 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_sap_model: [],
      // 担当 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ec_group: [],
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
      ma002: null,
      ma003: [],
      ma004: [],
      ma005: null,
      ma006: null,
      ma007: null,
      ma008: null,
      ma009: null,
      ma010: null,
      ma011: null,
      ma012: null,
      ma013: null,
      ma014: null,
      ma015: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '技联'
    opertype.value = 1
    form.value.ma002 = new Date()
    form.value.ma003 = []
    form.value.ma004 = []
    form.value.ma005 = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getPpEcLiaison(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '技联'
        opertype.value = 2

        form.value = {
          ...data,
          ma003Checked: data.ma003 ? data.ma003.split(',') : [],
        }
      }
    })
  }

  // 添加&修改 表单提交
  function submitForm() {
    proxy.$refs["formRef"].validate((valid) => {
      if (valid) {
        form.value.ma003 = form.value.ma003Checked.toString();

        if (form.value.id != undefined && opertype.value === 2) {
          updatePpEcLiaison(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addPpEcLiaison(form.value).then((res) => {
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
        return delPpEcLiaison(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<技联.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/PpEcLiaison/export', { ...queryParams })
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