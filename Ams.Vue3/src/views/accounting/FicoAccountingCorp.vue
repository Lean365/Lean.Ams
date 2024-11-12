<!--
 * @Descripttion: 公司科目/fico_accounting_corp
 * @Version: 0.24.614.29513
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 16:35:01
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
          <el-form-item label="帐目表" prop="ma003">
            <el-input v-model="queryParams.ma003"
              :placeholder="$t('btn.enterSearchPrefix')+'帐目表'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="总帐科目" prop="ma004">
            <el-input v-model="queryParams.ma004"
              :placeholder="$t('btn.enterSearchPrefix')+'总帐科目'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="短文本" prop="ma014">
            <el-input v-model="queryParams.ma014"
              :placeholder="$t('btn.enterSearchPrefix')+'短文本'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="冻结" prop="ma017">
            <el-radio-group v-model="queryParams.ma017">
              <el-radio :value="-1">{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_freeze_flag " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
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
        <el-button class="btn-add" v-hasPermi="['fico:accountingcorp:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:accountingcorp:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:accountingcorp:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:accountingcorp:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoAccountingCorp/importTemplate"
                  importUrl="/Accounting/FicoAccountingCorp/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:accountingcorp:export']">
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
      <el-table-column prop="ma002" label="集团" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma002')" />
      <el-table-column prop="ma003" label="帐目表" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma003')" />
      <el-table-column prop="ma004" label="总帐科目" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma004')" />
      <el-table-column prop="ma005" label="负债科目" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma005')" />
      <el-table-column prop="ma006" label="总帐科目" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma006')" />
      <el-table-column prop="ma007" label="组科目号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma007')" />
      <el-table-column prop="ma008" label="损益科目" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma008')" />
      <el-table-column prop="ma009" label="总帐科目组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma009')" />
      <el-table-column prop="ma010" label="样本科目" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma010')" />
      <el-table-column prop="ma011" label="贸易伙伴" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma011')" />
      <el-table-column prop="ma012" label="搜索条件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma012')" />
      <el-table-column prop="ma013" label="功能范围" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma013')" />
      <el-table-column prop="ma014" label="短文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma014')" />
      <el-table-column prop="ma015" label="长文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma015')" />
      <el-table-column prop="ma016" label="附加文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ma016')" />
      <el-table-column prop="ma017" label="冻结" align="center" v-if="columns.showColumn('ma017')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.ma017" />
        </template>
      </el-table-column>
      <el-table-column prop="ma018" label="冻结过账" align="center" v-if="columns.showColumn('ma018')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.ma018" />
        </template>
      </el-table-column>
      <el-table-column prop="ma019" label="冻结计划" align="center" v-if="columns.showColumn('ma019')">
        <template #default="scope">
          <dict-tag :options=" options.sys_freeze_flag " :value="scope.row.ma019" />
        </template>
      </el-table-column>
      <el-table-column prop="isDeleted" label="软删除" align="center" v-if="columns.showColumn('isDeleted')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_deleted " :value="scope.row.isDeleted" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:accountingcorp:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['fico:accountingcorp:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改公司科目对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="集团" prop="ma002">
                  <el-input v-model="form.ma002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="6" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="帐目表" prop="ma003">
                  <el-input v-model="form.ma003" :placeholder="$t('btn.enterPrefix')+'帐目表'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="总帐科目" prop="ma004">
                  <el-input v-model="form.ma004" :placeholder="$t('btn.enterPrefix')+'总帐科目'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="负债科目" prop="ma005">
                  <el-input v-model="form.ma005" :placeholder="$t('btn.enterPrefix')+'负债科目'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="2" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="总帐科目" prop="ma006">
                  <el-input v-model="form.ma006" :placeholder="$t('btn.enterPrefix')+'总帐科目'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="组科目号" prop="ma007">
                  <el-input v-model="form.ma007" :placeholder="$t('btn.enterPrefix')+'组科目号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="损益科目" prop="ma008">
                  <el-input v-model="form.ma008" :placeholder="$t('btn.enterPrefix')+'损益科目'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="总帐科目组" prop="ma009">
                  <el-input v-model="form.ma009" :placeholder="$t('btn.enterPrefix')+'总帐科目组'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="样本科目" prop="ma010">
                  <el-input v-model="form.ma010" :placeholder="$t('btn.enterPrefix')+'样本科目'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="贸易伙伴" prop="ma011">
                  <el-input v-model="form.ma011" :placeholder="$t('btn.enterPrefix')+'贸易伙伴'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="12" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="搜索条件" prop="ma012">
                  <el-input v-model="form.ma012" :placeholder="$t('btn.enterPrefix')+'搜索条件'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="50" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="功能范围" prop="ma013">
                  <el-input v-model="form.ma013" :placeholder="$t('btn.enterPrefix')+'功能范围'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="32" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="短文本" prop="ma014">
                  <el-input v-model="form.ma014" :placeholder="$t('btn.enterPrefix')+'短文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="长文本" prop="ma015">
                  <el-input v-model="form.ma015" :placeholder="$t('btn.enterPrefix')+'长文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="80" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="附加文本" prop="ma016">
                  <el-input type="textarea" v-model="form.ma016"
                    :placeholder="$t('btn.enterPrefix')+'附加文本'+$t('btn.enterSuffix')" show-word-limit
                    maxlength="8000" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="冻结" prop="ma017">
                  <el-radio-group v-model="form.ma017">
                    <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="冻结过账" prop="ma018">
                  <el-radio-group v-model="form.ma018">
                    <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="冻结计划" prop="ma019">
                  <el-radio-group v-model="form.ma019">
                    <el-radio v-for="item in options.sys_freeze_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-radio-group v-model="form.isDeleted">
                    <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
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

<script setup name="ficoaccountingcorp">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoAccountingCorp,
    addFicoAccountingCorp, delFicoAccountingCorp,
    updateFicoAccountingCorp, getFicoAccountingCorp,
  }
    from '@/api/accounting/ficoaccountingcorp.js'
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
    sort: 'Ma004',
    sortType: 'asc',
    //是否查询（1是）
    ma003: undefined,
    //是否查询（1是）
    ma004: undefined,
    //是否查询（1是）
    ma014: undefined,
    //是否查询（1是）
    ma017: -1,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'ma002', label: '集团' },
    { visible: true, prop: 'ma003', label: '帐目表' },
    { visible: true, prop: 'ma004', label: '总帐科目' },
    { visible: true, prop: 'ma005', label: '负债科目' },
    { visible: true, prop: 'ma006', label: '总帐科目' },
    { visible: true, prop: 'ma007', label: '组科目号' },
    { visible: true, prop: 'ma008', label: '损益科目' },
    { visible: false, prop: 'ma009', label: '总帐科目组' },
    { visible: false, prop: 'ma010', label: '样本科目' },
    { visible: false, prop: 'ma011', label: '贸易伙伴' },
    { visible: false, prop: 'ma012', label: '搜索条件' },
    { visible: false, prop: 'ma013', label: '功能范围' },
    { visible: false, prop: 'ma014', label: '短文本' },
    { visible: false, prop: 'ma015', label: '长文本' },
    { visible: false, prop: 'ma016', label: '附加文本' },
    { visible: false, prop: 'ma017', label: '冻结' },
    { visible: false, prop: 'ma018', label: '冻结过账' },
    { visible: false, prop: 'ma019', label: '冻结计划' },
    { visible: false, prop: 'isDeleted', label: '软删除' },
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
    { dictType: "sys_freeze_flag" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从公司科目/fico_accounting_corp表记录数据
  function getList() {
    loading.value = true
    listFicoAccountingCorp(queryParams).then(res => {
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
      ma002: [{ required: true, message: "集团" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ma003: [{ required: true, message: "帐目表" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ma004: [{ required: true, message: "总帐科目" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ma014: [{ required: true, message: "短文本" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ma017: [{ required: true, message: "冻结" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      ma018: [{ required: true, message: "冻结过账" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      ma019: [{ required: true, message: "冻结计划" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    //字典名称
    options: {
      // 冻结 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_freeze_flag: [],
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
      ma002: null,
      ma003: null,
      ma004: null,
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
      ma016: null,
      ma017: 0,
      ma018: 0,
      ma019: 0,
      isDeleted: 0,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '公司科目'
    opertype.value = 1
    form.value.ma002 = 100
    form.value.ma003 = 'TEAC'
    form.value.ma017 = 0
    form.value.ma018 = 0
    form.value.ma019 = 0
    form.value.isDeleted = 0
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getFicoAccountingCorp(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '公司科目'
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
          updateFicoAccountingCorp(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addFicoAccountingCorp(form.value).then((res) => {
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
        return delFicoAccountingCorp(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<公司科目.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoAccountingCorp/export', { ...queryParams })
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