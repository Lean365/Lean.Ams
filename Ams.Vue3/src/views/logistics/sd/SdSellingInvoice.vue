<!--
 * @Descripttion: 销售凭证/sd_selling_invoice
 * @Version: 0.24.620.27469
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 15:47:09
 * @column：50
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="mc002">
        <el-select filterable clearable   v-model="queryParams.mc002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="期间" prop="mc003">
        <el-select filterable clearable   v-model="queryParams.mc003" :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="mc004">
        <el-select filterable clearable   v-model="queryParams.mc004" :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ymdt_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="客户" prop="mc007">
        <el-input v-model="queryParams.mc007" :placeholder="$t('btn.enterSearchPrefix')+'客户'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="利润中心" prop="mc008">
        <el-input v-model="queryParams.mc008" :placeholder="$t('btn.enterSearchPrefix')+'利润中心'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="mc009">
        <el-input v-model="queryParams.mc009" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['sd:sellinginvoice:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sd:sellinginvoice:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sd:sellinginvoice:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sd:sellinginvoice:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/SdSellingInvoice/importTemplate"
                  importUrl="/Logistics/SdSellingInvoice/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['sd:sellinginvoice:export']">
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
      <el-table-column prop="mc002" label="工厂" align="center" v-if="columns.showColumn('mc002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mc002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc003" label="期间" align="center" v-if="columns.showColumn('mc003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mc003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc004" label="年月" align="center" v-if="columns.showColumn('mc004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mc004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc005" label="销售凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc005')"/>
      <el-table-column prop="mc006" label="凭证明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc006')"/>
      <el-table-column prop="mc007" label="客户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc007')"/>
      <el-table-column prop="mc008" label="利润中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc008')"/>
      <el-table-column prop="mc009" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc009')"/>
      <el-table-column prop="mc010" label="科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc010')"/>
      <el-table-column prop="mc011" label="销售数量" align="center" v-if="columns.showColumn('mc011')"/>
      <el-table-column prop="mc012" label="销售单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc012')"/>
      <el-table-column prop="mc013" label="原币销售额" align="center" v-if="columns.showColumn('mc013')"/>
      <el-table-column prop="mc014" label="原币币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc014')"/>
      <el-table-column prop="mc015" label="本币销售额" align="center" v-if="columns.showColumn('mc015')"/>
      <el-table-column prop="mc016" label="本币币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc016')"/>
      <el-table-column prop="mc017" label="参考凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc017')"/>
      <el-table-column prop="mc018" label="参考明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc018')"/>
      <el-table-column prop="mc019" label="过账日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc019')"/>
      <el-table-column prop="mc020" label="用户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc020')"/>
      <el-table-column prop="mc021" label="输入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc021')"/>
      <el-table-column prop="mc022" label="输入时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc022')"/>
      <el-table-column prop="mc023" label="来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc023')"/>
      <el-table-column prop="mc024" label="产品组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc024')"/>
      <el-table-column prop="mc025" label="凭证类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc025')"/>
      <el-table-column prop="mc026" label="凭证名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc026')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['sd:sellinginvoice:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['sd:sellinginvoice:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改销售凭证对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="工厂" prop="mc002">
              <el-select filterable clearable   v-model="form.mc002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="期间" prop="mc003">
              <el-select filterable clearable   v-model="form.mc003"  :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_attr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="年月" prop="mc004">
              <el-select filterable clearable   v-model="form.mc004"  :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ymdt_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="销售凭证" prop="mc005">
              <el-input   v-model="form.mc005" :placeholder="$t('btn.enterPrefix')+'销售凭证'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="mc006">
              <el-input   v-model="form.mc006" :placeholder="$t('btn.enterPrefix')+'凭证明细'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户" prop="mc007">
              <el-input   v-model="form.mc007" :placeholder="$t('btn.enterPrefix')+'客户'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="mc008">
              <el-input   v-model="form.mc008" :placeholder="$t('btn.enterPrefix')+'利润中心'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mc009">
              <el-input   v-model="form.mc009" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="mc010">
              <el-input   v-model="form.mc010" :placeholder="$t('btn.enterPrefix')+'科目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售数量" prop="mc011">
              <el-input-number v-model.number="form.mc011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'销售数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售单位" prop="mc012">
              <el-input   v-model="form.mc012" :placeholder="$t('btn.enterPrefix')+'销售单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币销售额" prop="mc013">
              <el-input-number v-model.number="form.mc013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'原币销售额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币币种" prop="mc014">
              <el-input   v-model="form.mc014" :placeholder="$t('btn.enterPrefix')+'原币币种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币销售额" prop="mc015">
              <el-input-number v-model.number="form.mc015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'本币销售额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币币种" prop="mc016">
              <el-input   v-model="form.mc016" :placeholder="$t('btn.enterPrefix')+'本币币种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考凭证" prop="mc017">
              <el-input   v-model="form.mc017" :placeholder="$t('btn.enterPrefix')+'参考凭证'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考明细" prop="mc018">
              <el-input   v-model="form.mc018" :placeholder="$t('btn.enterPrefix')+'参考明细'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过账日期" prop="mc019">
              <el-date-picker v-model="form.mc019" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用户" prop="mc020">
              <el-input   v-model="form.mc020" :placeholder="$t('btn.enterPrefix')+'用户'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日期" prop="mc021">
              <el-date-picker v-model="form.mc021" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入时间" prop="mc022">
              <el-input   v-model="form.mc022" :placeholder="$t('btn.enterPrefix')+'输入时间'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="来源" prop="mc023">
              <el-input   v-model="form.mc023" :placeholder="$t('btn.enterPrefix')+'来源'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品组" prop="mc024">
              <el-input   v-model="form.mc024" :placeholder="$t('btn.enterPrefix')+'产品组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证类型" prop="mc025">
              <el-input   v-model="form.mc025" :placeholder="$t('btn.enterPrefix')+'凭证类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证名称" prop="mc026">
              <el-input   v-model="form.mc026" :placeholder="$t('btn.enterPrefix')+'凭证名称'+$t('btn.enterSuffix')"  show-word-limit   maxlength="255"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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

<script setup name="sdsellinginvoice">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listSdSellingInvoice,
 addSdSellingInvoice, delSdSellingInvoice, 
 updateSdSellingInvoice,getSdSellingInvoice, 
 } 
from '@/api/logistics/sdsellinginvoice.js'
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
  sort: 'Mc004',
  sortType: 'desc',
  //是否查询（1是）
  mc002: undefined,
  //是否查询（1是）
  mc003: undefined,
  //是否查询（1是）
  mc004: undefined,
  //是否查询（1是）
  mc007: undefined,
  //是否查询（1是）
  mc008: undefined,
  //是否查询（1是）
  mc009: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mc002', label: '工厂' },
  { visible: true, prop: 'mc003', label: '期间' },
  { visible: true, prop: 'mc004', label: '年月' },
  { visible: true, prop: 'mc005', label: '销售凭证' },
  { visible: true, prop: 'mc006', label: '凭证明细' },
  { visible: true, prop: 'mc007', label: '客户' },
  { visible: true, prop: 'mc008', label: '利润中心' },
  { visible: false, prop: 'mc009', label: '物料' },
  { visible: false, prop: 'mc010', label: '科目' },
  { visible: false, prop: 'mc011', label: '销售数量' },
  { visible: false, prop: 'mc012', label: '销售单位' },
  { visible: false, prop: 'mc013', label: '原币销售额' },
  { visible: false, prop: 'mc014', label: '原币币种' },
  { visible: false, prop: 'mc015', label: '本币销售额' },
  { visible: false, prop: 'mc016', label: '本币币种' },
  { visible: false, prop: 'mc017', label: '参考凭证' },
  { visible: false, prop: 'mc018', label: '参考明细' },
  { visible: false, prop: 'mc019', label: '过账日期' },
  { visible: false, prop: 'mc020', label: '用户' },
  { visible: false, prop: 'mc021', label: '输入日期' },
  { visible: false, prop: 'mc022', label: '输入时间' },
  { visible: false, prop: 'mc023', label: '来源' },
  { visible: false, prop: 'mc024', label: '产品组' },
  { visible: false, prop: 'mc025', label: '凭证类型' },
  { visible: false, prop: 'mc026', label: '凭证名称' },
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
  { dictType: "sql_plant_list" },
  { dictType: "sql_attr_list" },
  { dictType: "sql_ymdt_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从销售凭证/sd_selling_invoice表记录数据
function getList(){
  loading.value = true
  listSdSellingInvoice(queryParams).then(res => {
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
    mc002: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mc003: [{ required: true, message: "期间"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mc004: [{ required: true, message: "年月"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mc007: [{ required: true, message: "客户"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc008: [{ required: true, message: "利润中心"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc009: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc011: [{ required: true, message: "销售数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc013: [{ required: true, message: "原币销售额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc015: [{ required: true, message: "本币销售额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_attr_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ymdt_list: [],
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
    mc002: [],
    mc003: [],
    mc004: [],
    mc005: null,
    mc006: null,
    mc007: null,
    mc008: null,
    mc009: null,
    mc010: null,
    mc011: 0,
    mc012: null,
    mc013: 0,
    mc014: null,
    mc015: 0,
    mc016: null,
    mc017: null,
    mc018: null,
    mc019: null,
    mc020: null,
    mc021: null,
    mc022: null,
    mc023: null,
    mc024: null,
    mc025: null,
    mc026: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'销售凭证'
  opertype.value = 1
  form.value.mc002= []
  form.value.mc003= []
  form.value.mc004= []
  form.value.mc011= 0
  form.value.mc013= 0
  form.value.mc015= 0
  form.value.mc019= new Date()
  form.value.mc021= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getSdSellingInvoice(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '销售凭证'
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
        updateSdSellingInvoice(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addSdSellingInvoice(form.value).then((res) => {
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
      return delSdSellingInvoice(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<销售凭证.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/SdSellingInvoice/export', { ...queryParams })
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