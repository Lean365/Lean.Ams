<!--
 * @Descripttion: 废弃部品/qm_cost_discard
 * @Version: 0.24.627.15253
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/18 8:30:51
 * @column：44
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="工厂" prop="me002">
            <el-select filterable clearable v-model="queryParams.me002"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="日期">
            <el-date-picker v-model="dateRangeMe003" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="机种" prop="me004">
            <el-input v-model="queryParams.me004"
              :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="物料" prop="me006">
            <el-input v-model="queryParams.me006"
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
        <el-button class="btn-add" v-hasPermi="['qm:costdiscard:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:costdiscard:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:costdiscard:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:costdiscard:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/QmCostDiscard/importTemplate"
                  importUrl="/Logistics/QmCostDiscard/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['qm:costdiscard:export']">
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
      <el-table-column prop="me002" label="工厂" align="center" v-if="columns.showColumn('me002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.me002" />
        </template>
      </el-table-column>
      <el-table-column prop="me003" label="日期" :show-overflow-tooltip="true" v-if="columns.showColumn('me003')" />
      <el-table-column prop="me004" label="机种" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('me004')" />
      <el-table-column prop="me005" label="间接人员赁率" align="center" v-if="columns.showColumn('me005')" />
      <el-table-column prop="me006" label="物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('me006')" />
      <el-table-column prop="me007" label="描述" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('me007')" />
      <el-table-column prop="me008" label="事故内容" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('me008')" />
      <el-table-column prop="me009" label="废弃费用" align="center" v-if="columns.showColumn('me009')" />
      <el-table-column prop="me010" label="废弃数量" align="center" v-if="columns.showColumn('me010')" />
      <el-table-column prop="me011" label="部品单价" align="center" v-if="columns.showColumn('me011')" />
      <el-table-column prop="me012" label="废弃处理费用" align="center" v-if="columns.showColumn('me012')" />
      <el-table-column prop="me013" label="运费" align="center" v-if="columns.showColumn('me013')" />
      <el-table-column prop="me014" label="其他费用" align="center" v-if="columns.showColumn('me014')" />
      <el-table-column prop="me015" label="处理作业时间(分)" align="center" v-if="columns.showColumn('me015')" />
      <el-table-column prop="me016" label="关税" align="center" v-if="columns.showColumn('me016')" />
      <el-table-column prop="me017" label="处理发生其他费用" align="center" v-if="columns.showColumn('me017')" />
      <el-table-column prop="me018" label="设变" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('me018')" />
      <el-table-column prop="me019" label="担当" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('me019')" />
      <el-table-column prop="me020" label="附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('me020')" />
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['qm:costdiscard:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['qm:costdiscard:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改废弃部品对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="工厂" prop="me002">
                  <el-select filterable clearable v-model="form.me002"
                    :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="日期" prop="me003">
                  <el-date-picker v-model="form.me003" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="机种" prop="me004">
                  <el-input v-model="form.me004" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间接人员赁率" prop="me005">
                  <el-input-number v-model.number="form.me005" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间接人员赁率'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="me006">
                  <el-input v-model="form.me006" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="描述" prop="me007">
                  <el-input v-model="form.me007" :placeholder="$t('btn.enterPrefix')+'描述'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="事故内容" prop="me008">
                  <el-input type="textarea" v-model="form.me008"
                    :placeholder="$t('btn.enterPrefix')+'事故内容'+$t('btn.enterSuffix')" show-word-limit maxlength="300" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="废弃费用" prop="me009">
                  <el-input-number v-model.number="form.me009" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'废弃费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="废弃数量" prop="me010">
                  <el-input-number v-model.number="form.me010" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'废弃数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="部品单价" prop="me011">
                  <el-input-number v-model.number="form.me011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'部品单价'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="废弃处理费用" prop="me012">
                  <el-input-number v-model.number="form.me012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'废弃处理费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="运费" prop="me013">
                  <el-input-number v-model.number="form.me013" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'运费'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="其他费用" prop="me014">
                  <el-input-number v-model.number="form.me014" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理作业时间(分)" prop="me015">
                  <el-input-number v-model.number="form.me015" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'处理作业时间(分)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="关税" prop="me016">
                  <el-input-number v-model.number="form.me016" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'关税'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理发生其他费用" prop="me017">
                  <el-input-number v-model.number="form.me017" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'处理发生其他费用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="设变" prop="me018">
                  <el-input v-model="form.me018" :placeholder="$t('btn.enterPrefix')+'设变'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="担当" prop="me019">
                  <el-input v-model="form.me019" :placeholder="$t('btn.enterPrefix')+'担当'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="附件" prop="me020">
                  <UploadFile v-model="form.me020" :data="{ uploadType: 1 }" />
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

<script setup name="qmcostdiscard">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listQmCostDiscard,
    addQmCostDiscard, delQmCostDiscard,
    updateQmCostDiscard, getQmCostDiscard,
  }
    from '@/api/logistics/qmcostdiscard.js'
  import importData from '@/components/ImportData'
  import useUserStore from '@/store/modules/user'
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
    sort: 'Me003',
    sortType: 'desc',
    //是否查询（1是）
    me002: undefined,
    //是否查询（1是）
    me003: undefined,
    //是否查询（1是）
    me004: undefined,
    //是否查询（1是）
    me006: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'me002', label: '工厂' },
    { visible: true, prop: 'me003', label: '日期' },
    { visible: true, prop: 'me004', label: '机种' },
    { visible: true, prop: 'me005', label: '间接人员赁率' },
    { visible: true, prop: 'me006', label: '物料' },
    { visible: true, prop: 'me007', label: '描述' },
    { visible: true, prop: 'me008', label: '事故内容' },
    { visible: false, prop: 'me009', label: '废弃费用' },
    { visible: false, prop: 'me010', label: '废弃数量' },
    { visible: false, prop: 'me011', label: '部品单价' },
    { visible: false, prop: 'me012', label: '废弃处理费用' },
    { visible: false, prop: 'me013', label: '运费' },
    { visible: false, prop: 'me014', label: '其他费用' },
    { visible: false, prop: 'me015', label: '处理作业时间(分)' },
    { visible: false, prop: 'me016', label: '关税' },
    { visible: false, prop: 'me017', label: '处理发生其他费用' },
    { visible: false, prop: 'me018', label: '设变' },
    { visible: false, prop: 'me019', label: '担当' },
    { visible: false, prop: 'me020', label: '附件' },
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
  // 日期时间范围
  const dateRangeMe003 = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sql_plant_list" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从废弃部品/qm_cost_discard表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMe003.value, 'Me003');
    loading.value = true
    listQmCostDiscard(queryParams).then(res => {
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
    // 日期时间范围
    dateRangeMe003.value = []
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
      me002: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      me005: [{ required: true, message: "间接人员赁率" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me006: [{ required: true, message: "物料" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me009: [{ required: true, message: "废弃费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me010: [{ required: true, message: "废弃数量" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me011: [{ required: true, message: "部品单价" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me012: [{ required: true, message: "废弃处理费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me013: [{ required: true, message: "运费" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me014: [{ required: true, message: "其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me015: [{ required: true, message: "处理作业时间(分)" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      me016: [{ required: true, message: "关税" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      me017: [{ required: true, message: "处理发生其他费用" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
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
      me002: [],
      me003: null,
      me004: null,
      me005: 0,
      me006: null,
      me007: null,
      me008: null,
      me009: 0,
      me010: 0,
      me011: 0,
      me012: 0,
      me013: 0,
      me014: 0,
      me015: 0,
      me016: 0,
      me017: 0,
      me018: null,
      me019: null,
      me020: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '废弃部品'
    opertype.value = 1
    form.value.me002 = []
    form.value.me003 = new Date()
    form.value.me005 = 0
    form.value.me009 = 0
    form.value.me010 = 0
    form.value.me011 = 0
    form.value.me012 = 0
    form.value.me013 = 0
    form.value.me014 = 0
    form.value.me015 = 0
    form.value.me016 = 0
    form.value.me017 = 0
    form.value.me019 = useUserStore().name //+ useUserStore().deptId.toString()

  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getQmCostDiscard(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '废弃部品'
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
          updateQmCostDiscard(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addQmCostDiscard(form.value).then((res) => {
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
        return delQmCostDiscard(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<废弃部品.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/QmCostDiscard/export', { ...queryParams })
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