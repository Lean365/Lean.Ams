<!--
 * @Descripttion: 费用预算/fico_budget_expense
 * @Version: 0.24.654.30450
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/10/16 8:05:21
 * @column：44
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
                <span class="custom-tree-node">
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
              <el-form-item label="期间" prop="mh003">
                <el-select filterable clearable v-model="queryParams.mh003"
                  :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')"
                  @change="handleLfgjaChange">
                  <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel"
                    :value="item.dictValue">
                    <span class="fl">{{ item.dictLabel }}</span>
                    <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
                  </el-option>
                </el-select>
              </el-form-item>
              <el-form-item label="年月" prop="mh004">
                <el-select filterable clearable v-model="queryParams.mh004"
                  :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
                  <el-option v-for="item in   filteredParamsLfmon " :key="item.dictValue" :label="item.dictLabel"
                    :value="item.dictValue">
                    <span class="fl">{{ item.dictLabel }}</span>
                    <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
                  </el-option>
                </el-select>
              </el-form-item>
              <!-- <el-form-item label="公司" prop="mh005">
                <el-select filterable clearable v-model="queryParams.mh005"
                  :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
                  <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel"
                    :value="item.dictValue">
                    <span class="fl">{{ item.dictLabel }}</span>
                    <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
                  </el-option>
                </el-select>
              </el-form-item> -->
              <!-- <el-form-item label="部门" prop="mh006">
                <el-select filterable clearable v-model="queryParams.mh006"
                  :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
                  <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel"
                    :value="item.dictValue">
                    <span class="fl">{{ item.dictLabel }}</span>
                    <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
                  </el-option>
                </el-select>
              </el-form-item> -->
              <el-form-item label="科目" prop="mh007">
                <el-tree-select v-model="queryParams.mh007" :data="budgetAccounting"
                  :props="{ value: 'id', label: 'label', children: 'children' }" value-key="id"
                  :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')" check-strictly
                  :render-after-expand="false" />
                <!-- <el-select filterable clearable v-model="queryParams.mh007"
                  :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')">
                  <el-option v-for="item in   options.sql_budget_details " :key="item.dictValue" :label="item.dictLabel"
                    :value="item.dictValue">
                    <span class="fl">{{ item.dictLabel }}</span>
                    <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
                  </el-option>
                </el-select> -->
              </el-form-item>
              <el-form-item label="类别" prop="mh008">
                <el-select filterable clearable v-model="queryParams.mh008"
                  :placeholder="$t('btn.selectSearchPrefix')+'类别'+$t('btn.selectSearchSuffix')">
                  <el-option v-for="item in   options.sys_costs_type " :key="item.dictValue" :label="item.dictLabel"
                    :value="item.dictValue">
                    <span class="fl">{{ item.dictLabel }}</span>
                    <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
                  </el-option>
                </el-select>
              </el-form-item>
              <el-form-item label="用途" prop="mh009">
                <el-input v-model="queryParams.mh009"
                  :placeholder="$t('btn.enterSearchPrefix')+'用途'+$t('btn.enterSearchSuffix')" />
              </el-form-item>
              <el-form-item label="审核" prop="mh016">
                <el-radio-group v-model="queryParams.mh016">
                  <el-radio :value="-1">{{$t('common.all')}}</el-radio>
                  <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue"
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
            <el-button class="btn-add" v-hasPermi="['fico:budgetexpense:add']" plain icon="plus" @click="handleAdd">
              {{ $t('btn.add') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetexpense:edit']" plain icon="edit"
              @click="handleUpdate">
              {{ $t('btn.edit') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetexpense:delete']" plain
              icon="delete" @click="handleDelete">
              {{ $t('btn.delete') }}
            </el-button>
          </el-col>
          <el-col :span="1.5">
            <el-dropdown trigger="click" v-hasPermi="['fico:budgetexpense:import']">
              <el-button class="btn-import" plain icon="Upload">
                {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
              </el-button>
              <template #dropdown>
                <el-dropdown-menu>
                  <el-dropdown-item command="upload">
                    <importData templateUrl="Accounting/FicoBudgetExpense/importTemplate"
                      importUrl="/Accounting/FicoBudgetExpense/importData" @success="handleFileSuccess"></importData>
                  </el-dropdown-item>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-export" plain icon="download" @click="handleExport"
              v-hasPermi="['fico:budgetexpense:export']">
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
          <el-table-column prop="parentId" label="父ID" align="center" v-if="columns.showColumn('parentId')" />
          <el-table-column prop="mh003" label="期间" align="center" v-if="columns.showColumn('mh003')">
            <template #default="scope">
              <dict-tag :options=" options.sql_attr_list " :value="scope.row.mh003" />
            </template>
          </el-table-column>
          <el-table-column prop="mh004" label="年月" align="center" v-if="columns.showColumn('mh004')">
            <template #default="scope">
              <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mh004" />
            </template>
          </el-table-column>
          <el-table-column prop="mh005" label="公司" align="center" v-if="columns.showColumn('mh005')">
            <template #default="scope">
              <dict-tag :options=" options.sql_corp_list " :value="scope.row.mh005" />
            </template>
          </el-table-column>
          <el-table-column prop="mh006" label="部门" align="center" v-if="columns.showColumn('mh006')">
            <template #default="scope">
              <dict-tag :options=" options.sql_dept_list " :value="scope.row.mh006" />
            </template>
          </el-table-column>
          <el-table-column prop="mh007" label="科目" align="center" v-if="columns.showColumn('mh007')">
            <template #default="scope">
              <dict-tag :options=" options.sql_budget_details " :value="scope.row.mh007" />
            </template>
          </el-table-column>
          <el-table-column prop="mh008" label="类别" align="center" v-if="columns.showColumn('mh008')">
            <template #default="scope">
              <dict-tag :options=" options.sys_costs_type " :value="scope.row.mh008" />
            </template>
          </el-table-column>
          <el-table-column prop="mh009" label="用途" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mh009')" />
          <el-table-column prop="mh010" label="单价" align="center" v-if="columns.showColumn('mh010')" />
          <el-table-column prop="mh011" label="数量" align="center" v-if="columns.showColumn('mh011')" />
          <el-table-column prop="mh012" label="金额" align="center" v-if="columns.showColumn('mh012')" />
          <el-table-column prop="mh013" label="实际" align="center" v-if="columns.showColumn('mh013')" />
          <el-table-column prop="mh014" label="差异" align="center" v-if="columns.showColumn('mh014')" />
          <el-table-column prop="mh015" label="启用" align="center" v-if="columns.showColumn('mh015')">
            <template #default="scope">
              <dict-tag :options=" options.sys_is_status " :value="scope.row.mh015" />
            </template>
          </el-table-column>
          <el-table-column prop="mh016" label="审核" align="center" v-if="columns.showColumn('mh016')">
            <template #default="scope">
              <dict-tag :options=" options.sys_is_status " :value="scope.row.mh016" />
            </template>
          </el-table-column>
          <el-table-column prop="mh017" label="审核人" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mh017')" />
          <el-table-column prop="mh018" label="审核日" :show-overflow-tooltip="true" v-if="columns.showColumn('mh018')" />
          <el-table-column prop="mh019" label="撤消人" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('mh019')" />
          <el-table-column prop="mh020" label="撤消日" :show-overflow-tooltip="true" v-if="columns.showColumn('mh020')" />
          <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
            v-if="columns.showColumn('remark')" />
          <el-table-column :label="$t('btn.operation')" width="160" align="center">
            <template #default="scope">
              <el-button-group>
                <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
                  v-hasPermi="['fico:budgetexpense:edit']" @click="handleUpdate(scope.row)"></el-button>
                <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
                  v-hasPermi="['fico:budgetexpense:delete']" @click="handleDelete(scope.row)"></el-button>
              </el-button-group>
            </template>
          </el-table-column>
        </el-table>
        <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
          @pagination="getList" />
      </el-col>
    </el-row>
    <!-- 添加或修改费用预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">
              <!-- 
              <el-col :lg="12">
                <el-form-item label="父ID" prop="parentId">
                  <el-input v-model.number="form.parentId"
                    :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')" show-word-limit maxlength="19" />
                </el-form-item>
              </el-col> -->

              <el-col :lg="12">
                <el-form-item label="期间" prop="mh003">
                  <el-select filterable clearable v-model="form.mh003"
                    :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')" @change="handleLfgjaChange">
                    <el-option v-for="item in  options.sql_attr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="年月" prop="mh004">
                  <el-select filterable clearable v-model="form.mh004"
                    :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  filteredFormLfmon" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="公司" prop="mh005">
                  <el-select filterable clearable v-model="form.mh005"
                    :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_corp_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="部门" prop="mh006">
                  <el-select filterable clearable v-model="form.mh006"
                    :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_dept_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="科目" prop="mh007">
                  <el-tree-select v-model="form.mh007" :data="budgetAccounting"
                    :props="{ value: 'id', label: 'label', children: 'children' }" value-key="id"
                    :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')" check-strictly
                    :render-after-expand="false" />
                  <!-- <el-select filterable clearable v-model="form.mh007"
                    :placeholder="$t('btn.selectPrefix')+'科目'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_budget_details" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select> -->
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="类别" prop="mh008">
                  <el-select filterable clearable v-model="form.mh008"
                    :placeholder="$t('btn.selectPrefix')+'类别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_costs_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用途" prop="mh009">
                  <el-input type="textarea" v-model="form.mh009"
                    :placeholder="$t('btn.enterPrefix')+'用途'+$t('btn.enterSuffix')" show-word-limit :rows="2"
                    maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="单价" prop="mh010">
                  <el-input-number v-model.number="form.mh010" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'单价'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="数量" prop="mh011">
                  <el-input-number v-model.number="form.mh011" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="金额" prop="mh012">
                  <el-input-number v-model.number="form.mh012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'金额'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="实际" prop="mh013">
                  <el-input-number v-model.number="form.mh013" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'实际'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="差异" prop="mh014">
                  <el-input-number v-model.number="form.mh014" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'差异'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="启用" prop="mh015">
                  <el-radio-group v-model="form.mh015">
                    <el-radio v-for="item in options.sys_is_status" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="审核" prop="mh016">
                  <el-radio-group v-model="form.mh016">
                    <el-radio v-for="item in options.sys_is_status" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="审核人" prop="mh017">
                  <el-input v-model="form.mh017" :placeholder="$t('btn.enterPrefix')+'审核人'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="审核日" prop="mh018">
                  <el-date-picker v-model="form.mh018" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="撤消人" prop="mh019">
                  <el-input v-model="form.mh019" :placeholder="$t('btn.enterPrefix')+'撤消人'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="撤消日" prop="mh020">
                  <el-date-picker v-model="form.mh020" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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
        </el-tabs>


      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ficobudgetexpense">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoBudgetExpense,
    addFicoBudgetExpense, delFicoBudgetExpense,
    updateFicoBudgetExpense, getFicoBudgetExpense,
  }
    from '@/api/accounting/ficobudgetexpense.js'
  import { treeselect } from '@/api/system/dept'
  import { treeselectFicoBudgetAccounting } from '@/api/accounting/ficobudgetaccounting.js'
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
  //预算科目
  const budgetAccounting = ref([])
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
    sort: 'Mh004',
    sortType: 'desc',
    //是否查询（1是）
    mh003: undefined,
    //是否查询（1是）
    mh004: undefined,
    //是否查询（1是）
    mh005: undefined,
    //是否查询（1是）
    mh006: undefined,
    //是否查询（1是）
    mh007: undefined,
    //是否查询（1是）
    mh008: undefined,
    //是否查询（1是）
    mh009: undefined,
    //是否查询（1是）
    md009: undefined,
    //是否查询（1是）
    mh016: -1,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'id', label: 'ID' },
    { visible: false, prop: 'parentId', label: '父ID' },
    { visible: false, prop: 'mh003', label: '期间' },
    { visible: true, prop: 'mh004', label: '年月' },
    { visible: true, prop: 'mh005', label: '公司' },
    { visible: true, prop: 'mh006', label: '部门' },
    { visible: true, prop: 'mh007', label: '科目' },
    { visible: true, prop: 'mh008', label: '类别' },
    { visible: true, prop: 'mh009', label: '用途' },
    { visible: true, prop: 'mh010', label: '单价' },
    { visible: true, prop: 'mh011', label: '数量' },
    { visible: true, prop: 'mh012', label: '金额' },
    { visible: false, prop: 'mh013', label: '实际' },
    { visible: false, prop: 'mh014', label: '差异' },
    { visible: false, prop: 'mh015', label: '启用' },
    { visible: true, prop: 'mh016', label: '审核' },
    { visible: false, prop: 'mh017', label: '审核人' },
    { visible: false, prop: 'mh018', label: '审核日' },
    { visible: false, prop: 'mh019', label: '撤消人' },
    { visible: false, prop: 'mh020', label: '撤消日' },
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
    { dictType: "sql_ymdt_list" },
    { dictType: "sql_corp_list" },
    { dictType: "sql_dept_list" },
    { dictType: "sql_budget_details" },
    { dictType: "sys_costs_type" },
    { dictType: "sys_is_status" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从费用预算/fico_budget_expense表记录数据
  function getList() {
    loading.value = true
    listFicoBudgetExpense(queryParams).then(res => {
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
  //查询预算科目下拉树

  function getBudgetAccountingTreeSelect() {
    console.log(queryParams)
    treeselectFicoBudgetAccounting(queryParams).then((response) => {
      budgetAccounting.value = [{ id: 0, label: proxy.$t('common.unknow'), children: [] }, ...response.data]
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
    queryParams.mh006 = data.id
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
      mh003: [{ required: true, message: "期间" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mh004: [{ required: true, message: "年月" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mh005: [{ required: true, message: "公司" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mh006: [{ required: true, message: "部门" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh007: [{ required: true, message: "科目" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mh008: [{ required: true, message: "类别" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mh010: [{ required: true, message: "单价" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mh011: [{ required: true, message: "数量" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mh012: [{ required: true, message: "金额" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mh013: [{ required: true, message: "实际" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mh014: [{ required: true, message: "差异" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mh015: [{ required: true, message: "启用" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mh016: [{ required: true, message: "审核" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    //字典名称
    options: {
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_attr_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ymdt_list: [],
      // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_corp_list: [],
      // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_dept_list: [],
      // 科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_budget_details: [],
      // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_costs_type: [],
      // 启用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_status: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }
  // 使用 computed 属性来过滤数据: 过滤出选中的数据年月
  const filteredFormLfmon = ref([])
  const filteredParamsLfmon = ref([])
  function handleLfgjaChange() {
    //console.log(open.value === true)
    //console.log(state.options.sql_ymdt_list)
    if (open.value === true) {
      form.value.mh004 = ''
      filteredFormLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === form.value.mh003)

    }
    else {
      queryParams.mh004 = ''
      //console.log(queryParams.mp002)
      filteredParamsLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === queryParams.mh003)

    }
  }
  // 重置表单
  function reset() {
    form.value = {
      parentId: 0,
      mh003: [],
      mh004: [],
      mh005: [],
      mh006: [],
      mh007: [],
      mh008: [],
      mh009: null,
      mh010: 0,
      mh011: 0,
      mh012: 0,
      mh013: 0,
      mh014: 0,
      mh015: 0,
      mh016: 0,
      mh017: null,
      mh018: null,
      mh019: null,
      mh020: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }
  const cropDta = ref([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22])
  const cropTac = ref([23, 32, 33])
  const cropTsz = ref([24, 34, 35])
  const cropTcj = ref([25])
  const cropTss = ref([26])
  const cropTca = ref([27])
  const cropTms = ref([285])
  const cropTcs = ref([29])
  const cropTe = ref([30])
  const cropTuk = ref([31])

  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '费用预算'
    opertype.value = 1
    form.value.mh003 = 'FY' + (new Date().getFullYear() + 1)
    form.value.mh004 = new Date().getFullYear().toString() + (new Date().getMonth() + 1).toString()
    if ((deptIdSelect.value) == 0) {
      console.log(cropDta.value.includes(deptIdSelect.value))

      form.value.mh005 = '2300'
    } else if (cropDta.value.includes(deptIdSelect.value) == true) {
      console.log(cropDta.value.includes(deptIdSelect.value))
      form.value.mh005 = '2300'
    } else if (cropTac.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '2400'
    } else if (cropTsz.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '2500'
    } else if (cropTcj.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '1000'
    } else if (cropTss.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '1300'
    } else if (cropTca.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '3000'
    } else if (cropTms.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '1100'
    } else if (cropTcs.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '1700'
    } else if (cropTe.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '4000'
    } else if (cropTuk.value.includes(deptIdSelect.value) == true) {
      form.value.mh005 = '4100'
    } else { form.value.mh005 = [] }
    //form.value.mh005 = []
    form.value.mh006 = deptIdSelect.value
    form.value.mh007 = []
    form.value.mh008 = []
    form.value.mh010 = 0
    form.value.mh011 = 0
    form.value.mh012 = 0
    form.value.mh013 = 0
    form.value.mh014 = 0
    form.value.mh015 = 0
    form.value.mh016 = 0
    form.value.mh018 = new Date()
    form.value.mh020 = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getFicoBudgetExpense(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '费用预算'
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
          updateFicoBudgetExpense(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addFicoBudgetExpense(form.value).then((res) => {
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
        return delFicoBudgetExpense(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<费用预算.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoBudgetExpense/export', { ...queryParams })
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
  getBudgetAccountingTreeSelect()
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