<!--
 * @Descripttion: 设变明细/pp_ec_slave
 * @Version: 0.24.622.14771
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/13 8:13:42
 * @column：58
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
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
        <el-button class="btn-add" v-hasPermi="['pp:ecslave:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:ecslave:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:ecslave:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecslave:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpEcSlave/importTemplate"
                  importUrl="/Logistics/PpEcSlave/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecslave:export']">
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
      <el-table-column prop="mc003" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc003')"/>
      <el-table-column prop="mc004" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc004')"/>
      <el-table-column prop="mc005" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc005')"/>
      <el-table-column prop="mc006" label="物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc006')"/>
      <el-table-column prop="mc007" label="子物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc007')"/>
      <el-table-column prop="mc008" label="子物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc008')"/>
      <el-table-column prop="mc009" label="旧物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc009')"/>
      <el-table-column prop="mc010" label="旧文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc010')"/>
      <el-table-column prop="mc011" label="旧品库存" align="center" v-if="columns.showColumn('mc011')"/>
      <el-table-column prop="mc012" label="用量" align="center" v-if="columns.showColumn('mc012')"/>
      <el-table-column prop="mc013" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc013')"/>
      <el-table-column prop="mc014" label="新物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc014')"/>
      <el-table-column prop="mc015" label="新文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc015')"/>
      <el-table-column prop="mc016" label="新品库存" align="center" v-if="columns.showColumn('mc016')"/>
      <el-table-column prop="mc017" label="用量" align="center" v-if="columns.showColumn('mc017')"/>
      <el-table-column prop="mc018" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc018')"/>
      <el-table-column prop="mc019" label="bom番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc019')"/>
      <el-table-column prop="mc020" label="互换" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc020')"/>
      <el-table-column prop="mc021" label="区分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc021')"/>
      <el-table-column prop="mc022" label="指示" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc022')"/>
      <el-table-column prop="mc023" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc023')"/>
      <el-table-column prop="mc024" label="bom日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc024')"/>
      <el-table-column prop="mc025" label="采购类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc025')"/>
      <el-table-column prop="mc026" label="采购组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc026')"/>
      <el-table-column prop="mc027" label="仓库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc027')"/>
      <el-table-column prop="mc028" label="检验否" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc028')"/>
      <el-table-column prop="mc029" label="工厂状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc029')"/>
      <el-table-column prop="mc030" label="SOP" align="center" v-if="columns.showColumn('mc030')"/>
      <el-table-column prop="mc031" label="实施标记" align="center" v-if="columns.showColumn('mc031')"/>
      <el-table-column prop="mc032" label="部管" align="center" v-if="columns.showColumn('mc032')"/>
      <el-table-column prop="mc033" label="Pcba" align="center" v-if="columns.showColumn('mc033')"/>
      <el-table-column prop="mc034" label="组立" align="center" v-if="columns.showColumn('mc034')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:ecslave:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:ecslave:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改设变明细对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="设变No." prop="mc003">
              <el-input   v-model="form.mc003" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="mc004">
              <el-input   v-model="form.mc004" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')"  show-word-limit  maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mc005">
              <el-input   v-model="form.mc005" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料文本" prop="mc006">
              <el-input   v-model="form.mc006" :placeholder="$t('btn.enterPrefix')+'物料文本'+$t('btn.enterSuffix')"  show-word-limit  maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="子物料" prop="mc007">
              <el-input   v-model="form.mc007" :placeholder="$t('btn.enterPrefix')+'子物料'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="子物料文本" prop="mc008">
              <el-input   v-model="form.mc008" :placeholder="$t('btn.enterPrefix')+'子物料文本'+$t('btn.enterSuffix')"  show-word-limit  maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料" prop="mc009">
              <el-input   v-model="form.mc009" :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧文本" prop="mc010">
              <el-input   v-model="form.mc010" :placeholder="$t('btn.enterPrefix')+'旧文本'+$t('btn.enterSuffix')"  show-word-limit  maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品库存" prop="mc011">
              <el-input-number v-model.number="form.mc011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'旧品库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="mc012">
              <el-input-number v-model.number="form.mc012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="mc013">
              <el-input   v-model="form.mc013" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="mc014">
              <el-input   v-model="form.mc014" :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新文本" prop="mc015">
              <el-input   v-model="form.mc015" :placeholder="$t('btn.enterPrefix')+'新文本'+$t('btn.enterSuffix')"  show-word-limit  maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新品库存" prop="mc016">
              <el-input-number v-model.number="form.mc016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'新品库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="mc017">
              <el-input-number v-model.number="form.mc017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="mc018">
              <el-input   v-model="form.mc018" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')"  show-word-limit  maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom番号" prop="mc019">
              <el-input   v-model="form.mc019" :placeholder="$t('btn.enterPrefix')+'bom番号'+$t('btn.enterSuffix')"  show-word-limit  maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="互换" prop="mc020">
              <el-input   v-model="form.mc020" :placeholder="$t('btn.enterPrefix')+'互换'+$t('btn.enterSuffix')"  show-word-limit  maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="区分" prop="mc021">
              <el-input   v-model="form.mc021" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')"  show-word-limit  maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="指示" prop="mc022">
              <el-input   v-model="form.mc022" :placeholder="$t('btn.enterPrefix')+'指示'+$t('btn.enterSuffix')"  show-word-limit  maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品处理" prop="mc023">
              <el-input   v-model="form.mc023" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')"  show-word-limit  maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom日期" prop="mc024">
              <el-date-picker v-model="form.mc024" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购类型" prop="mc025">
              <el-input   v-model="form.mc025" :placeholder="$t('btn.enterPrefix')+'采购类型'+$t('btn.enterSuffix')"  show-word-limit  maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组" prop="mc026">
              <el-input   v-model="form.mc026" :placeholder="$t('btn.enterPrefix')+'采购组'+$t('btn.enterSuffix')"  show-word-limit  maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="mc027">
              <el-input   v-model="form.mc027" :placeholder="$t('btn.enterPrefix')+'仓库'+$t('btn.enterSuffix')"  show-word-limit  maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验否" prop="mc028">
              <el-input   v-model="form.mc028" :placeholder="$t('btn.enterPrefix')+'检验否'+$t('btn.enterSuffix')"  show-word-limit  maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂状态" prop="mc029">
              <el-input   v-model="form.mc029" :placeholder="$t('btn.enterPrefix')+'工厂状态'+$t('btn.enterSuffix')"  show-word-limit  maxlength="4"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="SOP" prop="mc030">
              <el-input-number v-model.number="form.mc030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'SOP'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实施标记" prop="mc031">
              <el-input-number v-model.number="form.mc031" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'实施标记'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="部管" prop="mc032">
              <el-input-number v-model.number="form.mc032" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'部管'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="Pcba" prop="mc033">
              <el-input-number v-model.number="form.mc033" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'Pcba'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="组立" prop="mc034">
              <el-input-number v-model.number="form.mc034" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'组立'+$t('btn.enterSuffix')" />
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

<script setup name="ppecslave">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpEcSlave,
 addPpEcSlave, delPpEcSlave, 
 updatePpEcSlave,getPpEcSlave, 
 } 
from '@/api/logistics/ppecslave.js'
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
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'parentId', label: '父ID' },
  { visible: true, prop: 'mc003', label: '设变No.' },
  { visible: true, prop: 'mc004', label: '机种' },
  { visible: true, prop: 'mc005', label: '物料' },
  { visible: true, prop: 'mc006', label: '物料文本' },
  { visible: true, prop: 'mc007', label: '子物料' },
  { visible: true, prop: 'mc008', label: '子物料文本' },
  { visible: false, prop: 'mc009', label: '旧物料' },
  { visible: false, prop: 'mc010', label: '旧文本' },
  { visible: false, prop: 'mc011', label: '旧品库存' },
  { visible: false, prop: 'mc012', label: '用量' },
  { visible: false, prop: 'mc013', label: '位置' },
  { visible: false, prop: 'mc014', label: '新物料' },
  { visible: false, prop: 'mc015', label: '新文本' },
  { visible: false, prop: 'mc016', label: '新品库存' },
  { visible: false, prop: 'mc017', label: '用量' },
  { visible: false, prop: 'mc018', label: '位置' },
  { visible: false, prop: 'mc019', label: 'bom番号' },
  { visible: false, prop: 'mc020', label: '互换' },
  { visible: false, prop: 'mc021', label: '区分' },
  { visible: false, prop: 'mc022', label: '指示' },
  { visible: false, prop: 'mc023', label: '旧品处理' },
  { visible: false, prop: 'mc024', label: 'bom日期' },
  { visible: false, prop: 'mc025', label: '采购类型' },
  { visible: false, prop: 'mc026', label: '采购组' },
  { visible: false, prop: 'mc027', label: '仓库' },
  { visible: false, prop: 'mc028', label: '检验否' },
  { visible: false, prop: 'mc029', label: '工厂状态' },
  { visible: false, prop: 'mc030', label: 'SOP' },
  { visible: false, prop: 'mc031', label: '实施标记' },
  { visible: false, prop: 'mc032', label: '部管' },
  { visible: false, prop: 'mc033', label: 'Pcba' },
  { visible: false, prop: 'mc034', label: '组立' },
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
]

//API获取从设变明细/pp_ec_slave表记录数据
function getList(){
  loading.value = true
  listPpEcSlave(queryParams).then(res => {
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
    mc003: [{ required: true, message: "设变No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc004: [{ required: true, message: "机种"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc011: [{ required: true, message: "旧品库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc012: [{ required: true, message: "用量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc016: [{ required: true, message: "新品库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc017: [{ required: true, message: "用量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc030: [{ required: true, message: "SOP"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc031: [{ required: true, message: "实施标记"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc032: [{ required: true, message: "部管"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc033: [{ required: true, message: "Pcba"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc034: [{ required: true, message: "组立"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
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
    mc003: null,
    mc004: null,
    mc005: null,
    mc006: null,
    mc007: null,
    mc008: null,
    mc009: null,
    mc010: null,
    mc011: 0,
    mc012: 0,
    mc013: null,
    mc014: null,
    mc015: null,
    mc016: 0,
    mc017: 0,
    mc018: null,
    mc019: null,
    mc020: null,
    mc021: null,
    mc022: null,
    mc023: null,
    mc024: null,
    mc025: null,
    mc026: null,
    mc027: null,
    mc028: null,
    mc029: null,
    mc030: 0,
    mc031: 0,
    mc032: 0,
    mc033: 0,
    mc034: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'设变明细'
  opertype.value = 1
  form.value.mc011= 0
  form.value.mc012= 0
  form.value.mc016= 0
  form.value.mc017= 0
  form.value.mc024= new Date()
  form.value.mc030= 0
  form.value.mc031= 0
  form.value.mc032= 0
  form.value.mc033= 0
  form.value.mc034= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpEcSlave(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '设变明细'
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
        updatePpEcSlave(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpEcSlave(form.value).then((res) => {
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
      return delPpEcSlave(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<设变明细.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpEcSlave/export', { ...queryParams })
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