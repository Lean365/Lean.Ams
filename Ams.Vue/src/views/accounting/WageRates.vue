<!--
 * @Descripttion: (工资率/fico_wage_rates)
 * @Version: (0.24.389.31147)
 * @Author: (Lean365)
 * @Date: (2024/1/25 7:33:39)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="公司" prop="fwCrop">
        <el-select clearable filterable v-model="queryParams.fwCrop" :placeholder="$t('btn.select')+'公司'">
          <el-option v-for="item in  options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="fwYm">
        <el-select clearable filterable v-model="queryParams.fwYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ficoym_list " :key="item.dictValue" :label="item.dictLabel"
            :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="币种" prop="fwCcy">
        <el-select clearable filterable v-model="queryParams.fwCcy" :placeholder="$t('btn.select')+'币种'">
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
        <el-button type="primary" v-hasPermi="['fico:wagerates:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['fico:wagerates:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['fico:wagerates:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:wagerates:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="accounting/WageRates/importTemplate"
                  importUrl="/accounting/WageRates/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['fico:wagerates:export']">
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
      <el-table-column prop="fwSFID" label="SFID" align="center" v-if="columns.showColumn('fwSFID')" />
      <el-table-column prop="fwCrop" label="公司" align="center" v-if="columns.showColumn('fwCrop')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.fwCrop" />
        </template>
      </el-table-column>
      <el-table-column prop="fwYm" label="年月" align="center" v-if="columns.showColumn('fwYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ficoym_list " :value="scope.row.fwYm" />
        </template>
      </el-table-column>
      <el-table-column prop="fwCcy" label="币种" align="center" v-if="columns.showColumn('fwCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.fwCcy" />
        </template>
      </el-table-column>
      <el-table-column prop="fwSalesVolume" label="销售额" align="center" v-if="columns.showColumn('fwSalesVolume')" />
      <el-table-column prop="fwWorkingDays" label="工作天数" align="center" v-if="columns.showColumn('fwWorkingDays')" />
      <el-table-column prop="fwDirectWageRate" label="直接工资率" align="center"
        v-if="columns.showColumn('fwDirectWageRate')" />
      <el-table-column prop="fwDirect" label="直接人数" align="center" v-if="columns.showColumn('fwDirect')" />
      <el-table-column prop="fwDirectOverTime" label="直接加班费" align="center"
        v-if="columns.showColumn('fwDirectOverTime')" />
      <el-table-column prop="fwDirectWages" label="直接工资" align="center" v-if="columns.showColumn('fwDirectWages')" />
      <el-table-column prop="fwInDirectWageRate" label="间接工资率" align="center"
        v-if="columns.showColumn('fwInDirectWageRate')" />
      <el-table-column prop="fwInDirect" label="间接人数" align="center" v-if="columns.showColumn('fwInDirect')" />
      <el-table-column prop="fwInDirectOverTime" label="间接加班费" align="center"
        v-if="columns.showColumn('fwInDirectOverTime')" />
      <el-table-column prop="fwInDirectWages" label="间接工资" align="center"
        v-if="columns.showColumn('fwInDirectWages')" />
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
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')"
            v-hasPermi="['fico:wagerates:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')"
            v-hasPermi="['fico:wagerates:delete']" @click="handleDelete(scope.row)"></el-button>
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

              <!-- <el-col :lg="12">
            <el-form-item label="SFID" prop="fwSFID">
              <el-input v-model.number="form.fwSFID" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col> -->

              <el-col :lg="8">
                <el-form-item label="公司" prop="fwCrop">
                  <el-select clearable filterable v-model="form.fwCrop" :placeholder="$t('btn.select')+'公司'">
                    <el-option v-for="item in options.sys_crop_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="年月" prop="fwYm">
                  <el-select clearable filterable v-model="form.fwYm" :placeholder="$t('btn.select')+'年月'">
                    <el-option v-for="item in options.sql_ficoym_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="币种" prop="fwCcy">
                  <el-select clearable filterable v-model="form.fwCcy" :placeholder="$t('btn.select')+'币种'">
                    <el-option v-for="item in options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="销售额" prop="fwSalesVolume">
                  <el-input-number :precision="2" :step="0.01" :max="99999999" v-model.number="form.fwSalesVolume"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'销售额'" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工作天数" prop="fwWorkingDays">
                  <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.fwWorkingDays"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'工作天数'" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="直接工资率" prop="fwDirectWageRate">
                  <el-input-number :precision="2" :step="0.01" :max="9999" v-model.number="form.fwDirectWageRate"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'直接工资率'"
                    :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="直接人数" prop="fwDirect">
                  <el-input-number :precision="0" :step="1" :max="9999" v-model.number="form.fwDirect" :controls="true"
                    controls-position="right" :placeholder="$t('btn.enter')+'直接人数'" @input="directWages" />
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="直接加班费" prop="fwDirectOverTime">
                  <el-input-number :precision="2" :step="0.01" :max="9999" v-model.number="form.fwDirectOverTime"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'直接加班费'" />
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="直接工资" prop="fwDirectWages">
                  <el-input-number :precision="2" :step="0.01" :max="99999999" v-model.number="form.fwDirectWages"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'直接工资'"
                    @input="directWages" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="间接工资率" prop="fwInDirectWageRate">
                  <el-input-number :precision="2" :step="0.01" :max="99999999" v-model.number="form.fwInDirectWageRate"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'间接工资率'"
                    :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="间接人数" prop="fwInDirect">
                  <el-input-number :precision="0" :step="1" :max="9999" v-model.number="form.fwInDirect"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'间接人数'"
                    @input="inDirectWages" />
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="间接加班费" prop="fwInDirectOverTime">
                  <el-input-number :precision="2" :step="0.01" :max="99999999" v-model.number="form.fwInDirectOverTime"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'间接加班费'" />
                </el-form-item>
              </el-col>

              <el-col :lg="8">
                <el-form-item label="间接工资" prop="fwInDirectWages">
                  <el-input-number :precision="2" :step="0.01" :max="99999999" v-model.number="form.fwInDirectWages"
                    :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'间接工资'"
                    @input="inDirectWages" />
                </el-form-item>
              </el-col>




            </el-row>
          </el-tab-pane>

          <el-tab-pane :label="$t('ptabs.customization')" name="14th">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="自定义A" prop="uDF01">
                  <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'自定义A'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义B" prop="uDF02">
                  <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'自定义B'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义C" prop="uDF03">
                  <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'自定义C'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义D" prop="uDF04">
                  <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'自定义D'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义E" prop="uDF05">
                  <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'自定义E'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义F" prop="uDF06">
                  <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'自定义F'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义1" prop="uDF51">
                  <el-input clearable v-model="form.uDF51" :placeholder="$t('btn.enter')+'自定义1'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2" prop="uDF52">
                  <el-input clearable v-model="form.uDF52" :placeholder="$t('btn.enter')+'自定义2'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3" prop="uDF53">
                  <el-input clearable v-model="form.uDF53" :placeholder="$t('btn.enter')+'自定义3'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4" prop="uDF54">
                  <el-input clearable v-model="form.uDF54" :placeholder="$t('btn.enter')+'自定义4'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5" prop="uDF55">
                  <el-input clearable v-model="form.uDF55" :placeholder="$t('btn.enter')+'自定义5'" :disabled="true"
                    maxlength="10" show-word-limit />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6" prop="uDF56">
                  <el-input clearable v-model="form.uDF56" :placeholder="$t('btn.enter')+'自定义6'" :disabled="true"
                    maxlength="10" show-word-limit />
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
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'" />
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

<script setup name="wagerates">
  //后台操作函数
  import {
    listWageRates,
    addWageRates, delWageRates,
    updateWageRates, getWageRates,
  }
    from '@/api/accounting/wagerates.js'
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
    fwCrop: undefined,
    fwYm: undefined,
    fwCcy: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'fwSFID', label: 'SFID' },
    { visible: true, prop: 'fwCrop', label: '公司' },
    { visible: true, prop: 'fwYm', label: '年月' },
    { visible: true, prop: 'fwCcy', label: '币种' },
    { visible: true, prop: 'fwSalesVolume', label: '销售额' },
    { visible: true, prop: 'fwWorkingDays', label: '工作天数' },
    { visible: true, prop: 'fwDirectWageRate', label: '直接工资率' },
    { visible: true, prop: 'fwDirect', label: '直接人数' },
    { visible: false, prop: 'fwDirectOverTime', label: '直接加班费' },
    { visible: false, prop: 'fwDirectWages', label: '直接工资' },
    { visible: false, prop: 'fwInDirectWageRate', label: '间接工资率' },
    { visible: false, prop: 'fwInDirect', label: '间接人数' },
    { visible: false, prop: 'fwInDirectOverTime', label: '间接加班费' },
    { visible: false, prop: 'fwInDirectWages', label: '间接工资' },
    { visible: false, prop: 'remark', label: '备注' },
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
  //字典参数
  var dictParams = [
    { dictType: "sys_crop_list" },
    { dictType: "sql_ficoym_list" },
    { dictType: "sys_ccy_type" },
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
    listWageRates(queryParams).then(res => {
      const { code, data } = res
      if (code == 200) {
        dataList.value = data.result
        total.value = data.totalNum
        loading.value = false
      }
    })
  }
  //直接工人工资 ÷ 直接生产工时（组装和加工时间）= 工资率
  //年間労務費 : 会社が支払った賃金、賞与、手当など人件費の年間合計　プラス　社会保険料の会社負担分
  //年間就業時間 : 残業、休日出勤を含む就業時間合計
  //稼働率 : 実際に製造した時間(稼働時間)を就業時間で割ったもの
  //アワーレートの計算式：月間労務費/月就業時間*稼働率
  function directWages(val) {
    form.value.fwDirectWageRate = (parseFloat(form.value.fwDirectWages) / (parseFloat(form.value.fwDirect) * parseFloat(form.value.fwWorkingDays) * 8 * 60)).toFixed(2)

  }
  function inDirectWages() {
    form.value.fwInDirectWageRate = (parseFloat(form.value.fwInDirectWages) / (parseFloat(form.value.fwInDirect) * parseFloat(form.value.fwWorkingDays) * 8 * 60)).toFixed(2)
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
    ids.value = selection.map((item) => item.fwSFID);
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
      fwSFID: [{ required: true, message: 'SFID' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwCrop: [{ required: true, message: '公司' + proxy.$t('btn.empty'), trigger: "change" }],
      fwYm: [{ required: true, message: '年月' + proxy.$t('btn.empty'), trigger: "change" }],
      fwCcy: [{ required: true, message: '币种' + proxy.$t('btn.empty'), trigger: "change" }],
      fwSalesVolume: [{ required: true, message: '销售额' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwWorkingDays: [{ required: true, message: '工作天数' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirectWageRate: [{ required: true, message: '直接工资率' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirect: [{ required: true, message: '直接人数' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirectOverTime: [{ required: true, message: '直接加班费' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwDirectWages: [{ required: true, message: '直接工资' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirectWageRate: [{ required: true, message: '间接工资率' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirect: [{ required: true, message: '间接人数' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirectOverTime: [{ required: true, message: '间接加班费' + proxy.$t('btn.empty'), trigger: "blur" }],
      fwInDirectWages: [{ required: true, message: '间接工资' + proxy.$t('btn.empty'), trigger: "blur" }],
    },
    options: {
      // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_crop_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ficoym_list: [],
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
  // @Version: (0.24.389.31147)
  // @Author: (Lean365)
  // @Date: (2024/1/25 7:33:39)



  // 重置表单
  function reset() {
    form.value = {
      fwSFID: 0,
      fwCrop: null,
      fwYm: null,
      fwCcy: null,
      fwSalesVolume: 0,
      fwWorkingDays: 0,
      fwDirectWageRate: 0,
      fwDirect: 0,
      fwDirectOverTime: 0,
      fwDirectWages: 0,
      fwInDirectWageRate: 0,
      fwInDirect: 0,
      fwInDirectOverTime: 0,
      fwInDirectWages: 0,
      uDF01: null,
      uDF02: null,
      uDF03: null,
      uDF04: null,
      uDF05: null,
      uDF06: null,
      uDF51: 0,
      uDF52: 0,
      uDF53: 0,
      uDF54: 0,
      uDF55: 0,
      uDF56: 0,
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
    title.value = proxy.$t('btn.add') + '工资率'
    opertype.value = 1
    form.value.fwCrop = []
    form.value.fwYm = []
    form.value.fwCcy = []
    form.value.fwSalesVolume = 0
    form.value.fwWorkingDays = 21.75
    form.value.fwDirectWageRate = 0
    form.value.fwDirect = 0
    form.value.fwDirectOverTime = 0
    form.value.fwDirectWages = 0
    form.value.fwInDirectWageRate = 0
    form.value.fwInDirect = 0
    form.value.fwInDirectOverTime = 0
    form.value.fwInDirectWages = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.fwSFID || ids.value
    getWageRates(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + '工资率'
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

        if (form.value.fwSFID != undefined && opertype.value === 2) {
          updateWageRates(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
            open.value = false
            getList()
          })
        } else {
          addWageRates(form.value).then((res) => {
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
    const Ids = row.fwSFID || ids.value

    proxy
      .$confirm(proxy.$t('common.confirmDel') + Ids + proxy.$t('common.confirmDelDataitems'))
      .then(function () {
        return delWageRates(Ids)
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
      .$confirm(proxy.$t('common.confirmExport') + "工资率", proxy.$t('common.warningTips'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/accounting/WageRates/export', { ...queryParams })
      })
  }


  // @Descripttion: (自定义函数/CustomFunctions)
  // @Functions: (assignValue,calculateValue,statisticValue)
  // @Version: (0.24.389.31147)
  // @Author: (Lean365)
  // @Date: (2024/1/25 7:33:39)

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