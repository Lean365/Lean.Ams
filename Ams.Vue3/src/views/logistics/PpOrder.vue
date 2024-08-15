<!--
 * @Descripttion: 生产工单/pp_order
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 15:07:48
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="生产工厂" prop="moPlant">
            <el-select filterable clearable v-model="queryParams.moPlant"
              :placeholder="$t('btn.selectSearchPrefix')+'生产工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="订单类型" prop="moType">
            <el-select filterable clearable v-model="queryParams.moType"
              :placeholder="$t('btn.selectSearchPrefix')+'订单类型'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_mo_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="订单号码" prop="moNumber">
            <el-input v-model="queryParams.moNumber"
              :placeholder="$t('btn.enterSearchPrefix')+'订单号码'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="物料" prop="moItem">
            <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
              :loading="loading " v-model="queryParams.moItem"
              :placeholder="$t('btn.selectSearchPrefix')+'物料'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="订单日期">
            <el-date-picker v-model="dateRangeMorDate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
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
        <el-button class="btn-add" v-hasPermi="['pp:order:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:order:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:order:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:order:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/PpOrder/importTemplate" importUrl="/Logistics/PpOrder/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:order:export']">
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
      <el-table-column prop="moSfId" label="ID" align="center" v-if="columns.showColumn('moSfId')" />
      <el-table-column prop="moPlant" label="生产工厂" align="center" v-if="columns.showColumn('moPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.moPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="moType" label="订单类型" align="center" v-if="columns.showColumn('moType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_mo_type " :value="scope.row.moType" />
        </template>
      </el-table-column>
      <el-table-column prop="moNumber" label="订单号码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moNumber')" />
      <el-table-column prop="moItem" label="物料" align="center" v-if="columns.showColumn('moItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.moItem" />
        </template>
      </el-table-column>
      <el-table-column prop="moLot" label="生产批次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moLot')" />
      <el-table-column prop="moPlanQty" label="工单数量" align="center" v-if="columns.showColumn('moPlanQty')" />
      <el-table-column prop="moProdQty" label="生产数量" align="center" v-if="columns.showColumn('moProdQty')" />
      <el-table-column prop="morDate" label="订单日期" :show-overflow-tooltip="true" v-if="columns.showColumn('morDate')" />
      <el-table-column prop="moRoute" label="工艺路线" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moRoute')" />
      <el-table-column prop="moSerial" label="序列号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('moSerial')" />
      <el-table-column prop="isStatus" label="状态" align="center" v-if="columns.showColumn('isStatus')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.isStatus" />
        </template>
      </el-table-column>
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
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['pp:order:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['pp:order:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
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
                <el-form-item label="SFID" prop="moSfId">
                  <el-input v-model.number="form.moSfId"
                    :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产工厂" prop="moPlant">
                  <el-select filterable clearable v-model="form.moPlant"
                    :placeholder="$t('btn.selectPrefix')+'生产工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="订单类型" prop="moType">
                  <el-select filterable clearable v-model="form.moType"
                    :placeholder="$t('btn.selectPrefix')+'订单类型'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_mo_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="订单号码" prop="moNumber">
                  <el-input v-model="form.moNumber" :placeholder="$t('btn.enterPrefix')+'订单号码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="moItem">
                  <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
                    :loading="loading " v-model="form.moItem"
                    :placeholder="$t('btn.selectPrefix')+'物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  remotequery_sql_mats_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="生产批次" prop="moLot">
                  <el-input v-model="form.moLot" :placeholder="$t('btn.enterPrefix')+'生产批次'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工单数量" prop="moPlanQty">
                  <el-input-number v-model.number="form.moPlanQty" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'工单数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产数量" prop="moProdQty">
                  <el-input-number v-model.number="form.moProdQty" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'生产数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="订单日期" prop="morDate">
                  <el-date-picker v-model="form.morDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工艺路线" prop="moRoute">
                  <el-input v-model="form.moRoute" :placeholder="$t('btn.enterPrefix')+'工艺路线'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序列号" prop="moSerial">
                  <el-input v-model="form.moSerial" :placeholder="$t('btn.enterPrefix')+'序列号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="状态" prop="isStatus">
                  <el-radio-group v-model="form.isStatus">
                    <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue"
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
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建者" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新者" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="pporder">
  import '@/assets/styles/btn-custom.scss'
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
    pageSize: 56,
    sort: 'MorDate',
    sortType: 'desc',
    //是否查询（1是）
    moPlant: undefined,
    //是否查询（1是）
    moType: undefined,
    //是否查询（1是）
    moNumber: undefined,
    //是否查询（1是）
    moItem: undefined,
    //是否查询（1是）
    morDate: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'moSfId', label: 'SFID' },
    { visible: true, prop: 'moPlant', label: '生产工厂' },
    { visible: true, prop: 'moType', label: '订单类型' },
    { visible: true, prop: 'moNumber', label: '订单号码' },
    { visible: true, prop: 'moItem', label: '物料' },
    { visible: true, prop: 'moLot', label: '生产批次' },
    { visible: true, prop: 'moPlanQty', label: '工单数量' },
    { visible: true, prop: 'moProdQty', label: '生产数量' },
    { visible: false, prop: 'morDate', label: '订单日期' },
    { visible: false, prop: 'moRoute', label: '工艺路线' },
    { visible: false, prop: 'moSerial', label: '序列号' },
    { visible: false, prop: 'isStatus', label: '状态' },
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
  const remotequeryList_sql_mats_list = ref([])
  //定义远程搜索变量
  const remotequery_sql_mats_list = ref([])
  //远程字典参数
  var remotedictParams_sql_mats_list = [
    { dictType: "sql_mats_list" },
  ]
  //远程搜索组件实例
  onMounted(() => {
    proxy.getDicts(remotedictParams_sql_mats_list).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_mats_list.value = element.list
      })
      //console.log(remotequeryList_sql_mats_list)
    })
  })
  //远程搜索
  const remoteMethod_sql_mats_list = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_mats_list.value = remotequeryList_sql_mats_list.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_mats_list(query)
      }, 2000)
    } else {
      //默认显示前15条记录
      remotequery_sql_mats_list.value.slice(0, 15)
    }
  }, 300)
  // 筛选方法
  const filterMethod_sql_mats_list = debounce((query) => {
    let arr = remotequeryList_sql_mats_list.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_mats_list.value = arr.slice(0, 5)
      addFilterOptions_sql_mats_list(query)
    } else {
      remotequery_sql_mats_list.value = arr
    }
  }, 300)
  // 精准筛选方法
  const addFilterOptions_sql_mats_list = debounce((dictValue) => {
    let target = remotequeryList_sql_mats_list.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_mats_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_mats_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
  // 订单日期时间范围
  const dateRangeMorDate = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sys_mo_type" },
    { dictType: "sys_flag_list" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从生产工单/pp_order表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMorDate.value, 'MorDate');
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
    dateRangeMorDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.moSfId);
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
      moSfId: [{ required: true, message: "SFID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      moPlant: [{ required: true, message: "生产工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      moType: [{ required: true, message: "订单类型" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      moNumber: [{ required: true, message: "订单号码" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      moItem: [{ required: true, message: "物料" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      moPlanQty: [{ required: true, message: "工单数量" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      moProdQty: [{ required: true, message: "生产数量" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      morDate: [{ required: true, message: "订单日期" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isStatus: [{ required: true, message: "状态" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 生产工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 订单类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_mo_type: [],
      // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_flag_list: [],
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
      moSfId: 0,
      moPlant: null,
      moType: null,
      moNumber: null,
      moItemChecked: [],
      moLot: null,
      moPlanQty: 0,
      moProdQty: 0,
      morDate: null,
      moRoute: null,
      moSerial: null,
      isStatus: 0,
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
    title.value = proxy.$t('btn.add') + " " + '生产工单'
    opertype.value = 1
    form.value.moPlant = []
    form.value.moType = []
    form.value.moPlanQty = 0
    form.value.moProdQty = 0
    form.value.morDate = new Date()
    form.value.isStatus = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.moSfId || ids.value
    getPpOrder(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '生产工单'
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

        if (form.value.moSfId != undefined && opertype.value === 2) {
          updatePpOrder(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addPpOrder(form.value).then((res) => {
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
    const Ids = row.moSfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delPpOrder(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<生产工单.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/PpOrder/export', { ...queryParams })
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