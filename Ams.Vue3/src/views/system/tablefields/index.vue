<!--
 * @Descripttion: 表字段/sys_table_fields
 * @Version: 0.24.613.26771
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/4 16:50:01
 * @column：43
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="表名" prop="tf002">
            <el-input v-model="queryParams.tf002"
              :placeholder="$t('btn.enterSearchPrefix')+'表名'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="字段名称" prop="tf005">
            <el-input v-model="queryParams.tf005"
              :placeholder="$t('btn.enterSearchPrefix')+'字段名称'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="翻译" prop="tf015">
            <el-input v-model="queryParams.tf015"
              :placeholder="$t('btn.enterSearchPrefix')+'翻译'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['sys:tablefields:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sys:tablefields:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sys:tablefields:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sys:tablefields:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Admin/SysTableFields/importTemplate"
                  importUrl="/Admin/SysTableFields/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['sys:tablefields:export']">
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
      <el-table-column prop="tf002" label="表名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf002')" />
      <el-table-column prop="tf003" label="字段编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf003')" />
      <el-table-column prop="tf004" label="序号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf004')" />
      <el-table-column prop="tf005" label="字段名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf005')" />
      <el-table-column prop="tf006" label="类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf006')" />
      <el-table-column prop="tf007" label="长度" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf007')" />
      <el-table-column prop="tf008" label="字段说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf008')" />
      <el-table-column prop="tf009" label="实体类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf009')" />
      <el-table-column prop="tf010" label="最大长度" align="center" v-if="columns.showColumn('tf010')" />
      <el-table-column prop="tf011" label="精度" align="center" v-if="columns.showColumn('tf011')" />
      <el-table-column prop="tf012" label="刻度" align="center" v-if="columns.showColumn('tf012')" />
      <el-table-column prop="tf013" label="原字段编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf013')" />
      <el-table-column prop="tf014" label="Nullable" align="center" v-if="columns.showColumn('tf014')" />
      <el-table-column prop="tf015" label="翻译" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf015')" />
      <el-table-column prop="tf016" label="建表语句" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf016')" />
      <el-table-column prop="tf017" label="字段语句" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf017')" />
      <el-table-column prop="tf018" label="默认值语句" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf018')" />
      <el-table-column prop="tf019" label="字段名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tf019')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['sys:tablefields:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['sys:tablefields:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改表字段对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="24">
                <el-form-item label="表名" prop="tf002">
                  <el-input v-model="form.tf002" :placeholder="$t('btn.enterPrefix')+'表名'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段编号" prop="tf003">
                  <el-input v-model="form.tf003" :placeholder="$t('btn.enterPrefix')+'字段编号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序号" prop="tf004">
                  <el-input v-model="form.tf004" :placeholder="$t('btn.enterPrefix')+'序号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称" prop="tf005">
                  <el-input v-model="form.tf005" :placeholder="$t('btn.enterPrefix')+'字段名称'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="100" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="类型" prop="tf006">
                  <el-input v-model="form.tf006" :placeholder="$t('btn.enterPrefix')+'类型'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="长度" prop="tf007">
                  <el-input v-model="form.tf007" :placeholder="$t('btn.enterPrefix')+'长度'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段说明" prop="tf008">
                  <el-input v-model="form.tf008" :placeholder="$t('btn.enterPrefix')+'字段说明'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="实体类型" prop="tf009">
                  <el-input v-model="form.tf009" :placeholder="$t('btn.enterPrefix')+'实体类型'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最大长度" prop="tf010">
                  <el-input-number v-model.number="form.tf010" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最大长度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="精度" prop="tf011">
                  <el-input-number v-model.number="form.tf011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'精度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="刻度" prop="tf012">
                  <el-input-number v-model.number="form.tf012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'刻度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="原字段编号" prop="tf013">
                  <el-input v-model="form.tf013" :placeholder="$t('btn.enterPrefix')+'原字段编号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="99" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Nullable" prop="tf014">
                  <el-input-number v-model.number="form.tf014" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'Nullable'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="翻译" prop="tf015">
                  <el-input type="textarea" v-model="form.tf015"
                    :placeholder="$t('btn.enterPrefix')+'翻译'+$t('btn.enterSuffix')" show-word-limit maxlength="4000" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="建表语句" prop="tf016">
                  <el-input type="textarea" v-model="form.tf016"
                    :placeholder="$t('btn.enterPrefix')+'建表语句'+$t('btn.enterSuffix')" show-word-limit
                    maxlength="4000" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="字段语句" prop="tf017">
                  <el-input type="textarea" v-model="form.tf017"
                    :placeholder="$t('btn.enterPrefix')+'字段语句'+$t('btn.enterSuffix')" show-word-limit
                    maxlength="4000" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="默认值语句" prop="tf018">
                  <el-input type="textarea" v-model="form.tf018"
                    :placeholder="$t('btn.enterPrefix')+'默认值语句'+$t('btn.enterSuffix')" show-word-limit
                    maxlength="4000" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="字段名" prop="tf019">
                  <el-input v-model="form.tf019" :placeholder="$t('btn.enterPrefix')+'字段名'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
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

<script setup name="systablefields">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listSysTableFields,
    addSysTableFields, delSysTableFields,
    updateSysTableFields, getSysTableFields,
  }
    from '@/api/system/tablefields.js'
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
    sort: 'Tf002',
    sortType: 'asc',
    //是否查询（1是）
    tf002: undefined,
    //是否查询（1是）
    tf005: undefined,
    //是否查询（1是）
    tf015: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'tf002', label: '表名' },
    { visible: true, prop: 'tf003', label: '字段编号' },
    { visible: true, prop: 'tf004', label: '序号' },
    { visible: true, prop: 'tf005', label: '字段名称' },
    { visible: true, prop: 'tf006', label: '类型' },
    { visible: true, prop: 'tf007', label: '长度' },
    { visible: true, prop: 'tf008', label: '字段说明' },
    { visible: false, prop: 'tf009', label: '实体类型' },
    { visible: false, prop: 'tf010', label: '最大长度' },
    { visible: false, prop: 'tf011', label: '精度' },
    { visible: false, prop: 'tf012', label: '刻度' },
    { visible: false, prop: 'tf013', label: '原字段编号' },
    { visible: false, prop: 'tf014', label: 'Nullable' },
    { visible: false, prop: 'tf015', label: '翻译' },
    { visible: false, prop: 'tf016', label: '建表语句' },
    { visible: false, prop: 'tf017', label: '字段语句' },
    { visible: false, prop: 'tf018', label: '默认值语句' },
    { visible: false, prop: 'tf019', label: '字段名' },
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
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从表字段/sys_table_fields表记录数据
  function getList() {
    loading.value = true
    listSysTableFields(queryParams).then(res => {
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
      tf002: [{ required: true, message: "表名" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      tf003: [{ required: true, message: "字段编号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      tf010: [{ required: true, message: "最大长度" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      tf011: [{ required: true, message: "精度" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      tf012: [{ required: true, message: "刻度" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      tf014: [{ required: true, message: "Nullable" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      tf015: [{ required: true, message: "翻译" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      rEF04: [{ required: true, message: "预留1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      rEF05: [{ required: true, message: "预留2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      rEF06: [{ required: true, message: "预留3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      uDF52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      uDF53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      uDF54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    //字典名称
    options: {
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
      tf002: null,
      tf003: null,
      tf004: null,
      tf005: null,
      tf006: null,
      tf007: null,
      tf008: null,
      tf009: null,
      tf010: 0,
      tf011: 0,
      tf012: 0,
      tf013: null,
      tf014: 0,
      tf015: null,
      tf016: null,
      tf017: null,
      tf018: null,
      tf019: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '表字段'
    opertype.value = 1
    form.value.tf010 = 0
    form.value.tf011 = 0
    form.value.tf012 = 0
    form.value.tf014 = 0
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getSysTableFields(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '表字段'
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
          updateSysTableFields(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addSysTableFields(form.value).then((res) => {
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
        return delSysTableFields(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<表字段.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Admin/SysTableFields/export', { ...queryParams })
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