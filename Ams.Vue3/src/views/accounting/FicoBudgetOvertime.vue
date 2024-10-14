<!--
 * @Descripttion: 加班预算/fico_budget_overtime
 * @Version: 0.24.653.19532
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/10/14 12:09:13
 * @column：49
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="部门ID" prop="deptId">
        <el-select filterable clearable  v-model="queryParams.deptId" :placeholder="$t('btn.selectSearchPrefix')+'部门ID'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="财年" prop="mi004">
        <el-select filterable clearable  v-model="queryParams.mi004" :placeholder="$t('btn.selectSearchPrefix')+'财年'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="mi005">
        <el-select filterable clearable  v-model="queryParams.mi005" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="公司" prop="mi006">
        <el-select filterable clearable  v-model="queryParams.mi006" :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="科目" prop="mi007">
        <el-select filterable clearable  v-model="queryParams.mi007" :placeholder="$t('btn.selectSearchPrefix')+'科目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_budget_title " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="名称" prop="mi008">
        <el-input v-model="queryParams.mi008" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="审核" prop="mi021">
        <el-radio-group v-model="queryParams.mi021">
          <el-radio :value="-1">{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
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
        <el-button class="btn-add" v-hasPermi="['fico:budgetovertime:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:budgetovertime:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:budgetovertime:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:budgetovertime:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Accounting/FicoBudgetOvertime/importTemplate"
                  importUrl="/Accounting/FicoBudgetOvertime/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['fico:budgetovertime:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="600px"
      :data="dataList"
      v-loading="loading"
      ref="table"
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="parentId" label="父ID" align="center" v-if="columns.showColumn('parentId')"/>
      <el-table-column prop="deptId" label="部门ID" align="center" v-if="columns.showColumn('deptId')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.deptId"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi004" label="财年" align="center" v-if="columns.showColumn('mi004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mi004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi005" label="年月" align="center" v-if="columns.showColumn('mi005')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mi005"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi006" label="公司" align="center" v-if="columns.showColumn('mi006')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mi006"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi007" label="科目" align="center" v-if="columns.showColumn('mi007')">
        <template #default="scope">
          <dict-tag :options=" options.sql_budget_title " :value="scope.row.mi007"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi008" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi008')"/>
      <el-table-column prop="mi009" label="必要工数" align="center" v-if="columns.showColumn('mi009')"/>
      <el-table-column prop="mi010" label="保有人数" align="center" v-if="columns.showColumn('mi010')"/>
      <el-table-column prop="mi011" label="间接人数" align="center" v-if="columns.showColumn('mi011')"/>
      <el-table-column prop="mi012" label="上班天数" align="center" v-if="columns.showColumn('mi012')"/>
      <el-table-column prop="mi013" label="加班事由" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi013')"/>
      <el-table-column prop="mi014" label="保有工数" align="center" v-if="columns.showColumn('mi014')"/>
      <el-table-column prop="mi015" label="工数差异" align="center" v-if="columns.showColumn('mi015')"/>
      <el-table-column prop="mi016" label="投入加班" align="center" v-if="columns.showColumn('mi016')"/>
      <el-table-column prop="mi017" label="平均投入加班" align="center" v-if="columns.showColumn('mi017')"/>
      <el-table-column prop="mi018" label="间接加班" align="center" v-if="columns.showColumn('mi018')"/>
      <el-table-column prop="mi019" label="投入总加班" align="center" v-if="columns.showColumn('mi019')"/>
      <el-table-column prop="mi020" label="启用标记" align="center" v-if="columns.showColumn('mi020')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.mi020"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi021" label="审核" align="center" v-if="columns.showColumn('mi021')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.mi021"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi022" label="审核人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi022')"/>
      <el-table-column prop="mi023" label="审核日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mi023')"/>
      <el-table-column prop="mi024" label="撤消人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi024')"/>
      <el-table-column prop="mi025" label="撤消日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mi025')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['fico:budgetovertime:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['fico:budgetovertime:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改加班预算对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="parentId">
              <el-input   v-model.number="form.parentId" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')"  show-word-limit  maxlength="19"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="部门ID" prop="deptId">
              <el-select filterable clearable   v-model="form.deptId"  :placeholder="$t('btn.selectPrefix')+'部门ID'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="财年" prop="mi004">
              <el-select filterable clearable   v-model="form.mi004"  :placeholder="$t('btn.selectPrefix')+'财年'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="mi005">
              <el-select filterable clearable   v-model="form.mi005"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司" prop="mi006">
              <el-select filterable clearable   v-model="form.mi006"  :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_corp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="mi007">
              <el-select filterable clearable   v-model="form.mi007"  :placeholder="$t('btn.selectPrefix')+'科目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_budget_title" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="mi008">
              <el-input   v-model="form.mi008" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit  maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="必要工数" prop="mi009">
              <el-input-number v-model.number="form.mi009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'必要工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="保有人数" prop="mi010">
              <el-input-number v-model.number="form.mi010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="间接人数" prop="mi011">
              <el-input-number v-model.number="form.mi011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接人数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="上班天数" prop="mi012">
              <el-input-number v-model.number="form.mi012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上班天数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="加班事由" prop="mi013">
              <el-input  type="textarea"  v-model="form.mi013" :placeholder="$t('btn.enterPrefix')+'加班事由'+$t('btn.enterSuffix')"  show-word-limit  :rows="2" maxlength="500"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="保有工数" prop="mi014">
              <el-input-number v-model.number="form.mi014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'保有工数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工数差异" prop="mi015">
              <el-input-number v-model.number="form.mi015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工数差异'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入加班" prop="mi016">
              <el-input-number v-model.number="form.mi016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="平均投入加班" prop="mi017">
              <el-input-number v-model.number="form.mi017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'平均投入加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接加班" prop="mi018">
              <el-input-number v-model.number="form.mi018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="投入总加班" prop="mi019">
              <el-input-number v-model.number="form.mi019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'投入总加班'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用标记" prop="mi020">
              <el-radio-group v-model="form.mi020">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="审核" prop="mi021">
              <el-radio-group v-model="form.mi021">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核人员" prop="mi022">
              <el-input   v-model="form.mi022" :placeholder="$t('btn.enterPrefix')+'审核人员'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="审核日期" prop="mi023">
              <el-date-picker v-model="form.mi023" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消人员" prop="mi024">
              <el-input   v-model="form.mi024" :placeholder="$t('btn.enterPrefix')+'撤消人员'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="撤消日期" prop="mi025">
              <el-date-picker v-model="form.mi025" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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

<script setup name="ficobudgetovertime">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listFicoBudgetOvertime,
 addFicoBudgetOvertime, delFicoBudgetOvertime, 
 updateFicoBudgetOvertime,getFicoBudgetOvertime, 
 } 
from '@/api/accounting/ficobudgetovertime.js'
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
  sort: 'Mi005',
  sortType: 'desc',
  //是否查询（1是）
  deptId: undefined,
  //是否查询（1是）
  mi004: undefined,
  //是否查询（1是）
  mi005: undefined,
  //是否查询（1是）
  mi006: undefined,
  //是否查询（1是）
  mi007: undefined,
  //是否查询（1是）
  mi008: undefined,
   //是否查询（1是）
  mi021: -1,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'deptId', label: '部门ID' },
  { visible: true, prop: 'mi004', label: '财年' },
  { visible: true, prop: 'mi005', label: '年月' },
  { visible: true, prop: 'mi006', label: '公司' },
  { visible: true, prop: 'mi007', label: '科目' },
  { visible: true, prop: 'mi008', label: '名称' },
  { visible: false, prop: 'mi009', label: '必要工数' },
  { visible: false, prop: 'mi010', label: '保有人数' },
  { visible: false, prop: 'mi011', label: '间接人数' },
  { visible: false, prop: 'mi012', label: '上班天数' },
  { visible: false, prop: 'mi013', label: '加班事由' },
  { visible: false, prop: 'mi014', label: '保有工数' },
  { visible: false, prop: 'mi015', label: '工数差异' },
  { visible: false, prop: 'mi016', label: '投入加班' },
  { visible: false, prop: 'mi017', label: '平均投入加班' },
  { visible: false, prop: 'mi018', label: '间接加班' },
  { visible: false, prop: 'mi019', label: '投入总加班' },
  { visible: false, prop: 'mi020', label: '启用标记' },
  { visible: false, prop: 'mi021', label: '审核' },
  { visible: false, prop: 'mi022', label: '审核人员' },
  { visible: false, prop: 'mi023', label: '审核日期' },
  { visible: false, prop: 'mi024', label: '撤消人员' },
  { visible: false, prop: 'mi025', label: '撤消日期' },
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
  { dictType: "sql_dept_list" },
  { dictType: "sql_attr_list" },
  { dictType: "sql_ymdt_list" },
  { dictType: "sql_corp_list" },
  { dictType: "sql_budget_title" },
  { dictType: "sys_is_status" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从加班预算/fico_budget_overtime表记录数据
function getList(){
  loading.value = true
  listFicoBudgetOvertime(queryParams).then(res => {
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
function resetQuery(){
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
    mi004: [{ required: true, message: "财年"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mi005: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mi006: [{ required: true, message: "公司"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mi007: [{ required: true, message: "科目"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mi009: [{ required: true, message: "必要工数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi010: [{ required: true, message: "保有人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mi011: [{ required: true, message: "间接人数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mi012: [{ required: true, message: "上班天数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mi014: [{ required: true, message: "保有工数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi015: [{ required: true, message: "工数差异"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi016: [{ required: true, message: "投入加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi017: [{ required: true, message: "平均投入加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi018: [{ required: true, message: "间接加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi019: [{ required: true, message: "投入总加班"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi020: [{ required: true, message: "启用标记"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mi021: [{ required: true, message: "审核"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 部门ID 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_dept_list: [],
    // 财年 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ymdt_list: [],
    // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_corp_list: [],
    // 科目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_budget_title: [],
    // 启用标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_status: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    parentId: 0,
    deptId: [],
    mi004: [],
    mi005: [],
    mi006: [],
    mi007: [],
    mi008: null,
    mi009: 0,
    mi010: 0,
    mi011: 0,
    mi012: 0,
    mi013: null,
    mi014: 0,
    mi015: 0,
    mi016: 0,
    mi017: 0,
    mi018: 0,
    mi019: 0,
    mi020: 0,
    mi021: 0,
    mi022: null,
    mi023: null,
    mi024: null,
    mi025: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'加班预算'
  opertype.value = 1
  form.value.deptId= []
  form.value.mi004= []
  form.value.mi005= []
  form.value.mi006= []
  form.value.mi007= []
  form.value.mi009= 0
  form.value.mi010= 0
  form.value.mi011= 0
  form.value.mi012= 0
  form.value.mi014= 0
  form.value.mi015= 0
  form.value.mi016= 0
  form.value.mi017= 0
  form.value.mi018= 0
  form.value.mi019= 0
  form.value.mi020= 0
  form.value.mi021= 0
  form.value.mi023= new Date()
  form.value.mi025= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getFicoBudgetOvertime(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '加班预算'
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
        updateFicoBudgetOvertime(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addFicoBudgetOvertime(form.value).then((res) => {
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
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoBudgetOvertime(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<加班预算.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting/FicoBudgetOvertime/export', { ...queryParams })
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