<!--
 * @Descripttion: 标准工时/pp_manhours
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 15:04:58
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="生效日期">
            <el-date-picker v-model="dateRangeMhEffDate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="工厂" prop="mhPlant">
            <el-select filterable clearable v-model="queryParams.mhPlant"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="机种名" prop="mhModelType">
            <el-input v-model="queryParams.mhModelType"
              :placeholder="$t('btn.enterSearchPrefix')+'机种名'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="仕向别" prop="mhRegionType">
            <el-input v-model="queryParams.mhRegionType"
              :placeholder="$t('btn.enterSearchPrefix')+'仕向别'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="物料" prop="mhItem">
            <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
              :loading="loading " v-model="queryParams.mhItem"
              :placeholder="$t('btn.selectSearchPrefix')+'物料'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="工作中心" prop="mhWcName">
            <el-select filterable clearable v-model="queryParams.mhWcName"
              :placeholder="$t('btn.selectSearchPrefix')+'工作中心'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_work_center " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button class="btn-add" v-hasPermi="['pp:manhours:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:manhours:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:manhours:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:manhours:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/PpManhours/importTemplate"
                  importUrl="/Logistics/PpManhours/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:manhours:export']">
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
      <el-table-column prop="mhSfId" label="SFID" align="center" v-if="columns.showColumn('mhSfId')" />
      <el-table-column prop="mhEffDate" label="生效日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhEffDate')" />
      <el-table-column prop="mhPlant" label="工厂" align="center" v-if="columns.showColumn('mhPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.mhPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="mhModelType" label="机种名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhModelType')" />
      <el-table-column prop="mhRegionType" label="仕向别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhRegionType')" />
      <el-table-column prop="mhItem" label="物料" align="center" v-if="columns.showColumn('mhItem')">
      </el-table-column>
      <el-table-column prop="mhItemText" label="物料文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhItemText')" />
      <el-table-column prop="mhWcName" label="工作中心" align="center" v-if="columns.showColumn('mhWcName')">
        <template #default="scope">
          <dict-tag :options=" options.sys_work_center " :value="scope.row.mhWcName" />
        </template>
      </el-table-column>
      <el-table-column prop="mhWcText" label="工作中心文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhWcText')" />
      <el-table-column prop="mhStdShort" label="标准点数" align="center" v-if="columns.showColumn('mhStdShort')" />
      <el-table-column prop="mhShortUnit" label="Short单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhShortUnit')" />
      <el-table-column prop="mhToMinRate" label="点数换算汇率" align="center" v-if="columns.showColumn('mhToMinRate')" />
      <el-table-column prop="mhStdTime" label="标准工时" align="center" v-if="columns.showColumn('mhStdTime')" />
      <el-table-column prop="mhTimeUnit" label="工时单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mhTimeUnit')" />
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
              v-hasPermi="['pp:manhours:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['pp:manhours:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改标准工时对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="SFID" prop="mhSfId">
                  <el-input v-model.number="form.mhSfId"
                    :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生效日期" prop="mhEffDate">
                  <el-date-picker v-model="form.mhEffDate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂" prop="mhPlant">
                  <el-select filterable clearable v-model="form.mhPlant"
                    :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="机种名" prop="mhModelType">
                  <el-input v-model="form.mhModelType"
                    :placeholder="$t('btn.enterPrefix')+'机种名'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仕向别" prop="mhRegionType">
                  <el-input v-model="form.mhRegionType"
                    :placeholder="$t('btn.enterPrefix')+'仕向别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料" prop="mhItem">
                  <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
                    :loading="loading " v-model="form.mhItem"
                    :placeholder="$t('btn.selectPrefix')+'物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  remotequery_sql_mats_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料文本" prop="mhItemText">
                  <el-input v-model="form.mhItemText"
                    :placeholder="$t('btn.enterPrefix')+'物料文本'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工作中心" prop="mhWcName">
                  <el-select filterable clearable v-model="form.mhWcName"
                    :placeholder="$t('btn.selectPrefix')+'工作中心'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_work_center" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="工作中心文本" prop="mhWcText">
                  <el-input v-model="form.mhWcText"
                    :placeholder="$t('btn.enterPrefix')+'工作中心文本'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准点数" prop="mhStdShort">
                  <el-input-number v-model.number="form.mhStdShort" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'标准点数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Short单位" prop="mhShortUnit">
                  <el-input v-model="form.mhShortUnit"
                    :placeholder="$t('btn.enterPrefix')+'Short单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="点数换算汇率" prop="mhToMinRate">
                  <el-input-number v-model.number="form.mhToMinRate" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'点数换算汇率'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准工时" prop="mhStdTime">
                  <el-input-number v-model.number="form.mhStdTime" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'标准工时'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工时单位" prop="mhTimeUnit">
                  <el-input v-model="form.mhTimeUnit"
                    :placeholder="$t('btn.enterPrefix')+'工时单位'+$t('btn.enterSuffix')" />
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

<script setup name="ppmanhours">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listPpManhours,
    addPpManhours, delPpManhours,
    updatePpManhours, getPpManhours,
  }
    from '@/api/logistics/ppmanhours.js'
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
    sort: '',
    sortType: 'asc',
    //是否查询（1是）
    mhEffDate: undefined,
    //是否查询（1是）
    mhPlant: undefined,
    //是否查询（1是）
    mhModelType: undefined,
    //是否查询（1是）
    mhRegionType: undefined,
    //是否查询（1是）
    mhItem: undefined,
    //是否查询（1是）
    mhWcName: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'mhSfId', label: 'SFID' },
    { visible: true, prop: 'mhEffDate', label: '生效日期' },
    { visible: true, prop: 'mhPlant', label: '工厂' },
    { visible: true, prop: 'mhModelType', label: '机种名' },
    { visible: true, prop: 'mhRegionType', label: '仕向别' },
    { visible: true, prop: 'mhItem', label: '物料' },
    { visible: true, prop: 'mhItemText', label: '物料文本' },
    { visible: true, prop: 'mhWcName', label: '工作中心' },
    { visible: false, prop: 'mhWcText', label: '工作中心文本' },
    { visible: false, prop: 'mhStdShort', label: '标准点数' },
    { visible: false, prop: 'mhShortUnit', label: 'Short单位' },
    { visible: false, prop: 'mhToMinRate', label: '点数换算汇率' },
    { visible: false, prop: 'mhStdTime', label: '标准工时' },
    { visible: false, prop: 'mhTimeUnit', label: '工时单位' },
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
  // 生效日期时间范围
  const dateRangeMhEffDate = ref([])
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

  //字典参数
  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sys_work_center" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从标准工时/pp_manhours表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMhEffDate.value, 'MhEffDate');
    loading.value = true
    listPpManhours(queryParams).then(res => {
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
    // 生效日期时间范围
    dateRangeMhEffDate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.mhSfId);
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
      mhSfId: [{ required: true, message: "SFID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mhPlant: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mhModelType: [{ required: true, message: "机种名" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mhWcName: [{ required: true, message: "工作中心" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mhStdShort: [{ required: true, message: "标准点数" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mhToMinRate: [{ required: true, message: "点数换算汇率" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mhStdTime: [{ required: true, message: "标准工时" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 工作中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_work_center: [],
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
      mhSfId: 0,
      mhEffDate: null,
      mhPlant: null,
      mhModelType: null,
      mhRegionType: null,
      mhItemChecked: [],
      mhItemText: null,
      mhWcName: null,
      mhWcText: null,
      mhStdShort: 0,
      mhShortUnit: null,
      mhToMinRate: 0,
      mhStdTime: 0,
      mhTimeUnit: null,
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
    title.value = proxy.$t('btn.add') + " " + '标准工时'
    opertype.value = 1
    form.value.mhEffDate = new Date()
    form.value.mhPlant = []
    form.value.mhWcName = []
    form.value.mhStdShort = 0
    form.value.mhToMinRate = 0
    form.value.mhStdTime = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.mhSfId || ids.value
    getPpManhours(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '标准工时'
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

        if (form.value.mhSfId != undefined && opertype.value === 2) {
          updatePpManhours(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addPpManhours(form.value).then((res) => {
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
    const Ids = row.mhSfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delPpManhours(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<标准工时.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/PpManhours/export', { ...queryParams })
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