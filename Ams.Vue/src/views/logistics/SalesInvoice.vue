<!--
 * @Descripttion: (销售凭证/sd_sales_invoice)
 * @Version: (0.24.394.29764)
 * @Author: (Lean365)
 * @Date: (2024/1/31 12:01:23)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="工厂" prop="ssiPlnt">
        <el-select clearable filterable  v-model="queryParams.ssiPlnt" :placeholder="$t('btn.select')+'工厂'">
          <el-option v-for="item in  options.app_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="年月" prop="ssiYm">
        <el-select clearable filterable  v-model="queryParams.ssiYm" :placeholder="$t('btn.select')+'年月'">
          <el-option v-for="item in  options.sql_ficoym_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="利润中心" prop="ssiPrctr">
        <el-select clearable filterable  v-model="queryParams.ssiPrctr" :placeholder="$t('btn.select')+'利润中心'">
          <el-option v-for="item in  options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料" prop="ssiSalesitem">
        <el-input clearable v-model="queryParams.ssiSalesitem" :placeholder="$t('btn.enter')+'物料'" />
      </el-form-item>
      <el-form-item label="原币币种" prop="ssiOriginalccy">
        <el-select clearable filterable  v-model="queryParams.ssiOriginalccy" :placeholder="$t('btn.select')+'原币币种'">
          <el-option v-for="item in  options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['sd:salesinvoice:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['sd:salesinvoice:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['sd:salesinvoice:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sd:salesinvoice:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="logistics/SalesInvoice/importTemplate"
                  importUrl="/logistics/SalesInvoice/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['sd:salesinvoice:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table
      :data="dataList" height="650"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      >
      <el-table-column type="selection" width="40" align="center"/>
      <el-table-column prop="ssiSfid" label="SFID" align="center" v-if="columns.showColumn('ssiSfid')"/>
      <el-table-column prop="ssiPlnt" label="工厂" align="center" v-if="columns.showColumn('ssiPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.app_plant_list " :value="scope.row.ssiPlnt"  />
        </template>
      </el-table-column>
      <el-table-column prop="ssiFy" label="期间" align="center" v-if="columns.showColumn('ssiFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_period_list " :value="scope.row.ssiFy"  />
        </template>
      </el-table-column>
      <el-table-column prop="ssiYm" label="年月" align="center" v-if="columns.showColumn('ssiYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ficoym_list " :value="scope.row.ssiYm"  />
        </template>
      </el-table-column>
      <el-table-column prop="ssiAccdocno" label="销售凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiAccdocno')"/>
      <el-table-column prop="ssiAccdoclineno" label="凭证明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiAccdoclineno')"/>
      <el-table-column prop="ssiCustomercode" label="客户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiCustomercode')"/>
      <el-table-column prop="ssiPrctr" label="利润中心" align="center" v-if="columns.showColumn('ssiPrctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.ssiPrctr"  />
        </template>
      </el-table-column>
      <el-table-column prop="ssiSalesitem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiSalesitem')"/>
      <el-table-column prop="ssiAccountcode" label="科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiAccountcode')"/>
      <el-table-column prop="ssiSalesqty" label="销售数量" align="center" v-if="columns.showColumn('ssiSalesqty')"/>
      <el-table-column prop="ssiSalesunit" label="销售单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiSalesunit')"/>
      <el-table-column prop="ssiOriginalamount" label="原币销售额" align="center" v-if="columns.showColumn('ssiOriginalamount')"/>
      <el-table-column prop="ssiOriginalccy" label="原币币种" align="center" v-if="columns.showColumn('ssiOriginalccy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.ssiOriginalccy"  />
        </template>
      </el-table-column>
      <el-table-column prop="ssiLocalamount" label="本币销售额" align="center" v-if="columns.showColumn('ssiLocalamount')"/>
      <el-table-column prop="ssiLocalccy" label="本币币种" align="center" v-if="columns.showColumn('ssiLocalccy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.ssiLocalccy"  />
        </template>
      </el-table-column>
      <el-table-column prop="ssiRefdocno" label="参考凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiRefdocno')"/>
      <el-table-column prop="ssiRefdoclineno" label="参考明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiRefdoclineno')"/>
      <el-table-column prop="ssiPostingdate" label="过账日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ssiPostingdate')"/>
      <el-table-column prop="ssiPostinguser" label="用户" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiPostinguser')"/>
      <el-table-column prop="ssiEntrydate" label="输入日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ssiEntrydate')"/>
      <el-table-column prop="ssiEntrytime" label="输入时间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiEntrytime')"/>
      <el-table-column prop="ssiOrigin" label="来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiOrigin')"/>
      <el-table-column prop="ssiPgroup" label="产品组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiPgroup')"/>
      <el-table-column prop="ssiAccdoctype" label="凭证类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiAccdoctype')"/>
      <el-table-column prop="ssiAccdoctext" label="凭证名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ssiAccdoctext')"/>
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['sd:salesinvoice:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['sd:salesinvoice:delete']" @click="handleDelete(scope.row)"></el-button>
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
            <el-form-item label="SFID" prop="ssiSfid">
              <el-input v-model.number="form.ssiSfid" :placeholder="$t('btn.enter')+'SFID'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="ssiPlnt">
              <el-select clearable filterable v-model="form.ssiPlnt"  :placeholder="$t('btn.select')+'工厂'">
                <el-option
                  v-for="item in options.app_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间" prop="ssiFy">
              <el-select clearable filterable v-model="form.ssiFy"  :placeholder="$t('btn.select')+'期间'">
                <el-option
                  v-for="item in options.sql_period_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年月" prop="ssiYm">
              <el-select clearable filterable v-model="form.ssiYm"  :placeholder="$t('btn.select')+'年月'">
                <el-option
                  v-for="item in options.sql_ficoym_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售凭证" prop="ssiAccdocno">
              <el-input clearable v-model="form.ssiAccdocno" :placeholder="$t('btn.enter')+'销售凭证'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证明细" prop="ssiAccdoclineno">
              <el-input clearable v-model="form.ssiAccdoclineno" :placeholder="$t('btn.enter')+'凭证明细'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="客户" prop="ssiCustomercode">
              <el-input clearable v-model="form.ssiCustomercode" :placeholder="$t('btn.enter')+'客户'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="ssiPrctr">
              <el-select clearable filterable v-model="form.ssiPrctr"  :placeholder="$t('btn.select')+'利润中心'">
                <el-option
                  v-for="item in options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="ssiSalesitem">
              <el-input clearable v-model="form.ssiSalesitem" :placeholder="$t('btn.enter')+'物料'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="科目" prop="ssiAccountcode">
              <el-input clearable v-model="form.ssiAccountcode" :placeholder="$t('btn.enter')+'科目'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售数量" prop="ssiSalesqty">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.ssiSalesqty" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'销售数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售单位" prop="ssiSalesunit">
              <el-input clearable v-model="form.ssiSalesunit" :placeholder="$t('btn.enter')+'销售单位'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币销售额" prop="ssiOriginalamount">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.ssiOriginalamount" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'原币销售额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原币币种" prop="ssiOriginalccy">
              <el-select clearable filterable v-model="form.ssiOriginalccy"  :placeholder="$t('btn.select')+'原币币种'">
                <el-option
                  v-for="item in options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币销售额" prop="ssiLocalamount">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.ssiLocalamount" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'本币销售额'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本币币种" prop="ssiLocalccy">
              <el-select clearable filterable v-model="form.ssiLocalccy"  :placeholder="$t('btn.select')+'本币币种'">
                <el-option
                  v-for="item in options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考凭证" prop="ssiRefdocno">
              <el-input clearable v-model="form.ssiRefdocno" :placeholder="$t('btn.enter')+'参考凭证'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考明细" prop="ssiRefdoclineno">
              <el-input clearable v-model="form.ssiRefdoclineno" :placeholder="$t('btn.enter')+'参考明细'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过账日期" prop="ssiPostingdate">
              <el-date-picker v-model="form.ssiPostingdate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用户" prop="ssiPostinguser">
              <el-input clearable v-model="form.ssiPostinguser" :placeholder="$t('btn.enter')+'用户'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入日期" prop="ssiEntrydate">
              <el-date-picker v-model="form.ssiEntrydate" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="输入时间" prop="ssiEntrytime">
              <el-input clearable v-model="form.ssiEntrytime" :placeholder="$t('btn.enter')+'输入时间'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="来源" prop="ssiOrigin">
              <el-input clearable v-model="form.ssiOrigin" :placeholder="$t('btn.enter')+'来源'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品组" prop="ssiPgroup">
              <el-input clearable v-model="form.ssiPgroup" :placeholder="$t('btn.enter')+'产品组'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证类型" prop="ssiAccdoctype">
              <el-input clearable v-model="form.ssiAccdoctype" :placeholder="$t('btn.enter')+'凭证类型'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证名称" prop="ssiAccdoctext">
              <el-input clearable v-model="form.ssiAccdoctext" :placeholder="$t('btn.enter')+'凭证名称'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="说明" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'说明'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'更新者'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')" :disabled="true"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.Onboarding')" name="second">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.annex')" name="fourth">
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
          <el-tab-pane :label="$t('ptabs.sale')" name="tenth">
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
          <el-tab-pane :label="$t('ptabs.customization')" name="14th">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="15th">
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

<script setup name="salesinvoice">
//后台操作函数
import { listSalesInvoice,
 addSalesInvoice, delSalesInvoice, 
 updateSalesInvoice,getSalesInvoice, 
 } 
from '@/api/logistics/salesinvoice.js'
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
  ssiPlnt: undefined,
  ssiYm: undefined,
  ssiPrctr: undefined,
  ssiSalesitem: undefined,
  ssiOriginalccy: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'ssiSfid', label: 'SFID' },
  { visible: true, prop: 'ssiPlnt', label: '工厂' },
  { visible: true, prop: 'ssiFy', label: '期间' },
  { visible: true, prop: 'ssiYm', label: '年月' },
  { visible: true, prop: 'ssiAccdocno', label: '销售凭证' },
  { visible: true, prop: 'ssiAccdoclineno', label: '凭证明细' },
  { visible: true, prop: 'ssiCustomercode', label: '客户' },
  { visible: true, prop: 'ssiPrctr', label: '利润中心' },
  { visible: false, prop: 'ssiSalesitem', label: '物料' },
  { visible: false, prop: 'ssiAccountcode', label: '科目' },
  { visible: false, prop: 'ssiSalesqty', label: '销售数量' },
  { visible: false, prop: 'ssiSalesunit', label: '销售单位' },
  { visible: false, prop: 'ssiOriginalamount', label: '原币销售额' },
  { visible: false, prop: 'ssiOriginalccy', label: '原币币种' },
  { visible: false, prop: 'ssiLocalamount', label: '本币销售额' },
  { visible: false, prop: 'ssiLocalccy', label: '本币币种' },
  { visible: false, prop: 'ssiRefdocno', label: '参考凭证' },
  { visible: false, prop: 'ssiRefdoclineno', label: '参考明细' },
  { visible: false, prop: 'ssiPostingdate', label: '过账日期' },
  { visible: false, prop: 'ssiPostinguser', label: '用户' },
  { visible: false, prop: 'ssiEntrydate', label: '输入日期' },
  { visible: false, prop: 'ssiEntrytime', label: '输入时间' },
  { visible: false, prop: 'ssiOrigin', label: '来源' },
  { visible: false, prop: 'ssiPgroup', label: '产品组' },
  { visible: false, prop: 'ssiAccdoctype', label: '凭证类型' },
  { visible: false, prop: 'ssiAccdoctext', label: '凭证名称' },
  { visible: false, prop: 'remark', label: '说明' },
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
  { dictType: "app_plant_list" },
  { dictType: "sql_period_list" },
  { dictType: "sql_ficoym_list" },
  { dictType: "sql_prctr_list" },
  { dictType: "sys_ccy_type" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从销售凭证/sd_sales_invoice表记录数据
function getList(){
  loading.value = true
  listSalesInvoice(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.ssiSfid);
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
    ssiSfid: [{ required: true, message: 'SFID'+ proxy.$t('btn.empty'), trigger: "blur" }],
    ssiPlnt: [{ required: true, message: '工厂'+ proxy.$t('btn.empty'), trigger: "change"     }],
    ssiFy: [{ required: true, message: '期间'+ proxy.$t('btn.empty'), trigger: "change"     }],
    ssiYm: [{ required: true, message: '年月'+ proxy.$t('btn.empty'), trigger: "change"     }],
    ssiAccdocno: [{ required: true, message: '销售凭证'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiAccdoclineno: [{ required: true, message: '凭证明细'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiCustomercode: [{ required: true, message: '客户'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiPrctr: [{ required: true, message: '利润中心'+ proxy.$t('btn.empty'), trigger: "change"     }],
    ssiSalesitem: [{ required: true, message: '物料'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiAccountcode: [{ required: true, message: '科目'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiSalesqty: [{ required: true, message: '销售数量'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiSalesunit: [{ required: true, message: '销售单位'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiOriginalamount: [{ required: true, message: '原币销售额'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiOriginalccy: [{ required: true, message: '原币币种'+ proxy.$t('btn.empty'), trigger: "change"     }],
    ssiLocalamount: [{ required: true, message: '本币销售额'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiLocalccy: [{ required: true, message: '本币币种'+ proxy.$t('btn.empty'), trigger: "change"     }],
    ssiRefdocno: [{ required: true, message: '参考凭证'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiRefdoclineno: [{ required: true, message: '参考明细'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiPostingdate: [{ required: true, message: '过账日期'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiPostinguser: [{ required: true, message: '用户'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiEntrydate: [{ required: true, message: '输入日期'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiEntrytime: [{ required: true, message: '输入时间'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiOrigin: [{ required: true, message: '来源'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiPgroup: [{ required: true, message: '产品组'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiAccdoctype: [{ required: true, message: '凭证类型'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    ssiAccdoctext: [{ required: true, message: '凭证名称'+ proxy.$t('btn.empty'), trigger: "blur"     }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_plant_list: [],
    // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_period_list: [],
    // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_ficoym_list: [],
    // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_prctr_list: [],
    // 原币币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ccy_type: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.394.29764)
// @Author: (Lean365)
// @Date: (2024/1/31 12:01:23)



// 重置表单
function reset() {
  form.value = {
    ssiSfid: 0,
    ssiPlnt: null,
    ssiFy: null,
    ssiYm: null,
    ssiAccdocno: null,
    ssiAccdoclineno: null,
    ssiCustomercode: null,
    ssiPrctr: null,
    ssiSalesitem: null,
    ssiAccountcode: null,
    ssiSalesqty: 0,
    ssiSalesunit: null,
    ssiOriginalamount: 0,
    ssiOriginalccy: null,
    ssiLocalamount: 0,
    ssiLocalccy: null,
    ssiRefdocno: null,
    ssiRefdoclineno: null,
    ssiPostingdate: null,
    ssiPostinguser: null,
    ssiEntrydate: null,
    ssiEntrytime: null,
    ssiOrigin: null,
    ssiPgroup: null,
    ssiAccdoctype: null,
    ssiAccdoctext: null,
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
  title.value = proxy.$t('btn.add')+'销售凭证'
  opertype.value = 1
  form.value.ssiPlnt= []
  form.value.ssiFy= []
  form.value.ssiYm= []
  form.value.ssiPrctr= []
  form.value.ssiSalesqty= 0
  form.value.ssiOriginalamount= 0
  form.value.ssiOriginalccy= []
  form.value.ssiLocalamount= 0
  form.value.ssiLocalccy= []
  form.value.ssiPostingdate= new Date()
  form.value.ssiEntrydate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.ssiSfid || ids.value
  getSalesInvoice(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ '销售凭证'
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

      if (form.value.ssiSfid != undefined && opertype.value === 2) {
        updateSalesInvoice(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addSalesInvoice(form.value).then((res) => {
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
  const Ids = row.ssiSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delSalesInvoice(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"销售凭证", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/logistics/SalesInvoice/export', { ...queryParams })
    })
}


// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.394.29764)
// @Author: (Lean365)
// @Date: (2024/1/31 12:01:23)

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