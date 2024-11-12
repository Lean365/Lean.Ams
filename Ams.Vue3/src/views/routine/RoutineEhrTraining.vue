<!--
 * @Descripttion: 培训/routine_ehr_training
 * @Version: 0.24.660.15020
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/10/21 8:56:48
 * @column：41
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <el-row :gutter="20" type="flex">
      <!--部门数据-->
      <el-col :span="4" :xs="24">
        <div class="scroll-container">
          <div class=" head-container">
            <el-input v-model="deptName"
              :placeholder="$t('btn.enterSearchPrefix')+$t('pdept.deptName')+$t('btn.enterSearchSuffix')" clearable
              prefix-icon="search" style="margin-bottom: 20px" />
          </div>
          <div class="head-container">
            <el-tree :data="deptOptions" :props="{ label: 'label', children: 'children' }" :expand-on-click-node="false"
              :filter-node-method="filterNode" ref="deptTreeRef" node-key="id" highlight-current default-expand-all
              @node-click="handleNodeClick">
              <template #default="{ node, data }">
                <span>
                  <span>
                    <svg-icon name="m-house" v-if="data.children && data.children.length > 0"></svg-icon>
                    {{ node.label }}
                  </span>
                </span>
              </template>
            </el-tree>
          </div>
        </div>
      </el-col>
      <!-- 查询区域 -->
      <el-col :span="20" :xs="24">
        <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
          label-width="auto">
          <el-row :gutter="10" class="mb8">
            <el-col :lg="24">
              <el-form-item label="工号" prop="mq002">
                <el-input v-model="queryParams.mq002"
                  :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
              </el-form-item>
              <el-form-item label="姓名" prop="mq003">
                <el-input v-model="queryParams.mq003"
                  :placeholder="$t('btn.enterSearchPrefix')+'姓名'+$t('btn.enterSearchSuffix')" />
              </el-form-item>
              <el-form-item label="年度" prop="mq004">
                <el-select filterable clearable v-model="queryParams.mq004"
                  :placeholder="$t('btn.selectSearchPrefix')+'年度'+$t('btn.selectSearchSuffix')">
                  <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel"
                    :value="item.dictValue">
                    <span class="fl">{{ item.dictLabel }}</span>
                    <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
                  </el-option>
                </el-select>
              </el-form-item>
              <el-form-item label="项目" prop="mq005">
                <el-select filterable clearable v-model="queryParams.mq005"
                  :placeholder="$t('btn.selectSearchPrefix')+'项目'+$t('btn.selectSearchSuffix')">
                  <el-option v-for="item in   options.sys_training_items " :key="item.dictValue" :label="item.dictLabel"
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
            <el-button class="btn-add" v-hasPermi="['routine:ehrtraining:add']" plain icon="plus" @click="handleAdd">
              {{ $t('btn.add') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehrtraining:edit']" plain icon="edit"
              @click="handleUpdate">
              {{ $t('btn.edit') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehrtraining:delete']" plain
              icon="delete" @click="handleDelete">
              {{ $t('btn.delete') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-dropdown trigger="click" v-hasPermi="['routine:ehrtraining:import']">
              <el-button class="btn-import" plain icon="Upload">
                {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
              </el-button>
              <template #dropdown>
                <el-dropdown-menu>
                  <el-dropdown-item command="upload">
                    <importData templateUrl="Routine/RoutineEhrTraining/importTemplate"
                      importUrl="/Routine/RoutineEhrTraining/importData" @success="handleFileSuccess"></importData>
                  </el-dropdown-item>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-export" plain icon="download" @click="handleExport"
              v-hasPermi="['routine:ehrtraining:export']">
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
          <el-table-column prop="mq002" label="工号" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq002')" />
          <el-table-column prop="mq003" label="姓名" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq003')" />
          <el-table-column prop="mq004" label="年度" align="center" v-if="columns.showColumn('mq004')">
            <template #default="scope">
              <dict-tag :options=" options.sql_attr_list " :value="scope.row.mq004" />
            </template>
          </el-table-column>
          <el-table-column prop="mq005" label="项目" align="center" v-if="columns.showColumn('mq005')">
            <template #default="scope">
              <dict-tag :options=" options.sys_training_items " :value="scope.row.mq005" />
            </template>
          </el-table-column>
          <el-table-column prop="mq006" label="内容" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq006')" />
          <el-table-column prop="mq007" label="目的" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq007')" />
          <el-table-column prop="mq008" label="分数" align="center" v-if="columns.showColumn('mq008')" />
          <el-table-column prop="mq009" label="结果" align="center" v-if="columns.showColumn('mq009')">
            <template #default="scope">
              <dict-tag :options=" options.sys_training_results " :value="scope.row.mq009" />
            </template>
          </el-table-column>
          <el-table-column prop="mq010" label="日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mq010')" />
          <el-table-column prop="mq011" label="指导老师" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq011')" />
          <el-table-column prop="mq012" label="确认" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq012')" />
          <el-table-column prop="mq013" label="确认" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq013')" />
          <el-table-column prop="mq014" label="确认" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq014')" />
          <el-table-column prop="mq015" label="承认" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq015')" />
          <el-table-column prop="mq016" label="承认" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq016')" />
          <el-table-column prop="mq017" label="承认" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mq017')" />
          <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('remark')" />
          <el-table-column :label="$t('btn.operation')" width="160" align="center">
            <template #default="scope">
              <el-button-group>
                <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
                  v-hasPermi="['routine:ehrtraining:edit']" @click="handleUpdate(scope.row)"></el-button>
                <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
                  v-hasPermi="['routine:ehrtraining:delete']" @click="handleDelete(scope.row)"></el-button>
              </el-button-group>
            </template>
          </el-table-column>
        </el-table>
        <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
          @pagination="getList" />
      </el-col>
    </el-row>

    <!-- 添加或修改培训对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="工号" prop="mq002">
                  <el-input v-model="form.mq002" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="姓名" prop="mq003">
                  <el-input v-model="form.mq003" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="年度" prop="mq004">
                  <el-select filterable clearable v-model="form.mq004"
                    :placeholder="$t('btn.selectPrefix')+'年度'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_attr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="项目" prop="mq005">
                  <el-select filterable clearable v-model="form.mq005"
                    :placeholder="$t('btn.selectPrefix')+'项目'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_training_items" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="内容" prop="mq006">
                  <el-input type="textarea" v-model="form.mq006"
                    :placeholder="$t('btn.enterPrefix')+'内容'+$t('btn.enterSuffix')" show-word-limit :rows="8"
                    maxlength="4000" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="目的" prop="mq007">
                  <el-input type="textarea" v-model="form.mq007"
                    :placeholder="$t('btn.enterPrefix')+'目的'+$t('btn.enterSuffix')" show-word-limit :rows="8"
                    maxlength="4000" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分数" prop="mq008">
                  <el-input-number v-model.number="form.mq008" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'分数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="结果" prop="mq009">
                  <el-select filterable clearable v-model="form.mq009"
                    :placeholder="$t('btn.selectPrefix')+'结果'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_training_results" :key="item.dictValue"
                      :label="item.dictLabel" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="日期" prop="mq010">
                  <el-date-picker v-model="form.mq010" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指导老师" prop="mq011">
                  <el-input v-model="form.mq011" :placeholder="$t('btn.enterPrefix')+'指导老师'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="确认" prop="mq012">
                  <el-input v-model="form.mq012" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="确认" prop="mq013">
                  <el-input v-model="form.mq013" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="确认" prop="mq014">
                  <el-input v-model="form.mq014" :placeholder="$t('btn.enterPrefix')+'确认'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="承认" prop="mq015">
                  <el-input v-model="form.mq015" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="承认" prop="mq016">
                  <el-input v-model="form.mq016" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="承认" prop="mq017">
                  <el-input v-model="form.mq017" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
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

<script setup name="routineehrtraining">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listRoutineEhrTraining,
    addRoutineEhrTraining, delRoutineEhrTraining,
    updateRoutineEhrTraining, getRoutineEhrTraining,
  }
    from '@/api/routine/routineehrtraining.js'
  import { treeselect } from '@/api/system/dept'
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
  //部门名称
  const deptName = ref('')
  //部门数据
  const deptOptions = ref([])
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
    sort: 'Mq010',
    sortType: 'desc',
    //是否查询（1是）
    mq002: undefined,
    //是否查询（1是）
    mq003: undefined,
    //是否查询（1是）
    mq004: undefined,
    //是否查询（1是）
    mq005: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mq002', label: '工号' },
    { visible: true, prop: 'mq003', label: '姓名' },
    { visible: true, prop: 'mq004', label: '年度' },
    { visible: true, prop: 'mq005', label: '项目' },
    { visible: true, prop: 'mq006', label: '内容' },
    { visible: true, prop: 'mq007', label: '目的' },
    { visible: true, prop: 'mq008', label: '分数' },
    { visible: false, prop: 'mq009', label: '结果' },
    { visible: false, prop: 'mq010', label: '日期' },
    { visible: false, prop: 'mq011', label: '指导老师' },
    { visible: false, prop: 'mq012', label: '确认' },
    { visible: false, prop: 'mq013', label: '确认' },
    { visible: false, prop: 'mq014', label: '确认' },
    { visible: false, prop: 'mq015', label: '承认' },
    { visible: false, prop: 'mq016', label: '承认' },
    { visible: false, prop: 'mq017', label: '承认' },
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

  //字典参数
  var dictParams = [
    { dictType: "sql_attr_list" },
    { dictType: "sys_training_items" },
    { dictType: "sys_training_results" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从培训/routine_ehr_training表记录数据
  function getList() {
    loading.value = true
    listRoutineEhrTraining(queryParams).then(res => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
      }
    })
  }
  /** 通过条件过滤节点  */
  const filterNode = (value, data) => {
    if (!value) return true
    return data.label.indexOf(value) !== -1
  }
  /** 根据名称筛选部门树 */
  watch(deptName, (val) => {
    proxy.$refs['deptTreeRef'].filter(val)
  })
  /** 查询部门下拉树结构 */
  function getDeptTreeSelect() {
    treeselect().then((response) => {
      deptOptions.value = [{ id: 0, label: proxy.$t('common.unknow') + proxy.$t('puser.deptName'), children: [] }, ...response.data]
    })
  }
  /** 初始化部门数据 */
  function initDeptTreeData() {
    // 判断部门的数据是否存在，存在不获取，不存在则获取
    if (deptOptions.value === undefined) {
      treeselect().then((response) => {
        deptOptions.value = response.data
      })
    }
  }
  const deptIdSelect = ref(0)
  /** 节点单击事件 */
  function handleNodeClick(data) {
    console.log(data)
    deptIdSelect.value = data.id
    queryParams.mn004 = data.id
    handleQuery()
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
      mq002: [{ required: true, message: "工号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mq003: [{ required: true, message: "姓名" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mq005: [{ required: true, message: "项目" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mq008: [{ required: true, message: "分数" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    //字典名称
    options: {
      // 年度 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_attr_list: [],
      // 项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_training_items: [],
      // 结果 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_training_results: [],
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
      mq002: null,
      mq003: null,
      mq004: [],
      mq005: [],
      mq006: null,
      mq007: null,
      mq008: 0,
      mq009: [],
      mq010: null,
      mq011: null,
      mq012: null,
      mq013: null,
      mq014: null,
      mq015: null,
      mq016: null,
      mq017: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '培训'
    opertype.value = 1
    form.value.mq004 = []
    form.value.mq005 = 0
    form.value.mq008 = 0
    form.value.mq009 = []
    form.value.mq010 = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getRoutineEhrTraining(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '培训'
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
          updateRoutineEhrTraining(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addRoutineEhrTraining(form.value).then((res) => {
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
        return delRoutineEhrTraining(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<培训.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Routine/RoutineEhrTraining/export', { ...queryParams })
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
  getDeptTreeSelect()
  handleQuery()
</script>
<style scoped>
  .scroll-container {
    height: 80%;
    /* 设置固定高度 */
    overflow-y: auto;
    /* 添加垂直滚动条 */
    overflow-x: hidden;
    /* 隐藏水平滚动条 */
  }
</style>