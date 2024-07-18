<!--
 * @Descripttion: PO残清单/mm_po_residue
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 10:59:13
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="prPlant">
        <el-select filterable clearable   v-model="queryParams.prPlant" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商ID" prop="prSupplierCode">
        <el-select filterable clearable   v-model="queryParams.prSupplierCode" :placeholder="$t('btn.selectSearchPrefix')+'供应商ID'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_cus_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="供应商名称" prop="prSupplierName">
        <el-input v-model="queryParams.prSupplierName" :placeholder="$t('btn.enterSearchPrefix')+'供应商名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="prPurItem">
        <el-input v-model="queryParams.prPurItem" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="仓库" prop="prLocation">
        <el-select filterable clearable   v-model="queryParams.prLocation" :placeholder="$t('btn.selectSearchPrefix')+'仓库'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="交货日期">
        <el-date-picker
          v-model="dateRangePrDelivDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="订单号" prop="prPurOrder">
        <el-input v-model="queryParams.prPurOrder" :placeholder="$t('btn.enterSearchPrefix')+'订单号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="采购组" prop="prPurGroup">
        <el-select filterable clearable   v-model="queryParams.prPurGroup" :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="采购日期">
        <el-date-picker
          v-model="dateRangePrPurDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="币种" prop="prPurCcy">
        <el-select filterable clearable   v-model="queryParams.prPurCcy" :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="税别" prop="prPurTaxType">
        <el-select filterable clearable   v-model="queryParams.prPurTaxType" :placeholder="$t('btn.selectSearchPrefix')+'税别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_tax_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="利润中心" prop="prPrctr">
        <el-select filterable clearable   v-model="queryParams.prPrctr" :placeholder="$t('btn.selectSearchPrefix')+'利润中心'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="PO残发行日期">
        <el-date-picker
          v-model="dateRangePrBalancedate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
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
        <el-button class="btn-add" v-hasPermi="['mm:poresidue:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:poresidue:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:poresidue:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:poresidue:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/MmPoResidue/importTemplate"
                  importUrl="/Logistics/MmPoResidue/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:poresidue:export']">
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
      <el-table-column prop="prSFID" label="SFID" align="center" v-if="columns.showColumn('prSFID')"/>
      <el-table-column prop="prPlant" label="工厂" align="center" v-if="columns.showColumn('prPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.prPlant"  />
        </template>
      </el-table-column>
      <el-table-column prop="prSupplierCode" label="供应商ID" align="center" v-if="columns.showColumn('prSupplierCode')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.prSupplierCode"  />
        </template>
      </el-table-column>
      <el-table-column prop="prSupplierName" label="供应商名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('prSupplierName')"/>
      <el-table-column prop="prPurItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('prPurItem')"/>
      <el-table-column prop="prPurItemText" label="物料文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('prPurItemText')"/>
      <el-table-column prop="prLocation" label="仓库" align="center" v-if="columns.showColumn('prLocation')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.prLocation"  />
        </template>
      </el-table-column>
      <el-table-column prop="prDelivDate" label="交货日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('prDelivDate')"/>
      <el-table-column prop="prUnpaidQty" label="未交" align="center" v-if="columns.showColumn('prUnpaidQty')"/>
      <el-table-column prop="prAlreadyQty" label="已交" align="center" v-if="columns.showColumn('prAlreadyQty')"/>
      <el-table-column prop="prPurOrder" label="订单号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('prPurOrder')"/>
      <el-table-column prop="prPurOrderDetails" label="订单明细" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('prPurOrderDetails')"/>
      <el-table-column prop="prPlannedQty" label="订单数量" align="center" v-if="columns.showColumn('prPlannedQty')"/>
      <el-table-column prop="prPurGroup" label="采购组" align="center" v-if="columns.showColumn('prPurGroup')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.prPurGroup"  />
        </template>
      </el-table-column>
      <el-table-column prop="prPurDate" label="采购日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('prPurDate')"/>
      <el-table-column prop="prPurUnit" label="单位" align="center" v-if="columns.showColumn('prPurUnit')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.prPurUnit"  />
        </template>
      </el-table-column>
      <el-table-column prop="prUnitPrice" label="价格单位" align="center" v-if="columns.showColumn('prUnitPrice')"/>
      <el-table-column prop="prPurCcy" label="币种" align="center" v-if="columns.showColumn('prPurCcy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.prPurCcy"  />
        </template>
      </el-table-column>
      <el-table-column prop="prPurTaxType" label="税别" align="center" v-if="columns.showColumn('prPurTaxType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_tax_list " :value="scope.row.prPurTaxType"  />
        </template>
      </el-table-column>
      <el-table-column prop="prPrctr" label="利润中心" align="center" v-if="columns.showColumn('prPrctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.prPrctr"  />
        </template>
      </el-table-column>
      <el-table-column prop="prBalancedate" label="PO残发行日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('prBalancedate')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:poresidue:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:poresidue:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改PO残清单对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="prSFID">
              <el-input v-model.number="form.prSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="prPlant">
              <el-select filterable clearable   v-model="form.prPlant"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商ID" prop="prSupplierCode">
              <el-select filterable clearable   v-model="form.prSupplierCode"  :placeholder="$t('btn.selectPrefix')+'供应商ID'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_cus_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="供应商名称" prop="prSupplierName">
              <el-input v-model="form.prSupplierName" :placeholder="$t('btn.enterPrefix')+'供应商名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="prPurItem">
              <el-input v-model="form.prPurItem" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料文本" prop="prPurItemText">
              <el-input v-model="form.prPurItemText" :placeholder="$t('btn.enterPrefix')+'物料文本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库" prop="prLocation">
              <el-select filterable clearable   v-model="form.prLocation"  :placeholder="$t('btn.selectPrefix')+'仓库'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="交货日期" prop="prDelivDate">
              <el-date-picker v-model="form.prDelivDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未交" prop="prUnpaidQty">
              <el-input-number v-model.number="form.prUnpaidQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未交'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="已交" prop="prAlreadyQty">
              <el-input-number v-model.number="form.prAlreadyQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'已交'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单号" prop="prPurOrder">
              <el-input v-model="form.prPurOrder" :placeholder="$t('btn.enterPrefix')+'订单号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单明细" prop="prPurOrderDetails">
              <el-input v-model="form.prPurOrderDetails" :placeholder="$t('btn.enterPrefix')+'订单明细'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单数量" prop="prPlannedQty">
              <el-input-number v-model.number="form.prPlannedQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'订单数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组" prop="prPurGroup">
              <el-select filterable clearable   v-model="form.prPurGroup"  :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="采购日期" prop="prPurDate">
              <el-date-picker v-model="form.prPurDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位" prop="prPurUnit">
              <el-select filterable clearable   v-model="form.prPurUnit"  :placeholder="$t('btn.selectPrefix')+'单位'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_unit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="价格单位" prop="prUnitPrice">
              <el-input-number v-model.number="form.prUnitPrice" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="prPurCcy">
              <el-select filterable clearable   v-model="form.prPurCcy"  :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ccy_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="税别" prop="prPurTaxType">
              <el-select filterable clearable   v-model="form.prPurTaxType"  :placeholder="$t('btn.selectPrefix')+'税别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_tax_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="利润中心" prop="prPrctr">
              <el-select filterable clearable   v-model="form.prPrctr"  :placeholder="$t('btn.selectPrefix')+'利润中心'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_prctr_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="PO残发行日期" prop="prBalancedate">
              <el-date-picker v-model="form.prBalancedate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="mmporesidue">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listMmPoResidue,
 addMmPoResidue, delMmPoResidue, 
 updateMmPoResidue,getMmPoResidue, 
 } 
from '@/api/logistics/mmporesidue.js'
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
  prPlant: undefined,
//是否查询（1是）
  prSupplierCode: undefined,
//是否查询（1是）
  prSupplierName: undefined,
//是否查询（1是）
  prPurItem: undefined,
//是否查询（1是）
  prLocation: undefined,
//是否查询（1是）
  prDelivDate: undefined,
//是否查询（1是）
  prPurOrder: undefined,
//是否查询（1是）
  prPurGroup: undefined,
//是否查询（1是）
  prPurDate: undefined,
//是否查询（1是）
  prPurCcy: undefined,
//是否查询（1是）
  prPurTaxType: undefined,
//是否查询（1是）
  prPrctr: undefined,
//是否查询（1是）
  prBalancedate: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'prSFID', label: 'SFID' },
  { visible: true, prop: 'prPlant', label: '工厂' },
  { visible: true, prop: 'prSupplierCode', label: '供应商ID' },
  { visible: true, prop: 'prSupplierName', label: '供应商名称' },
  { visible: true, prop: 'prPurItem', label: '物料' },
  { visible: true, prop: 'prPurItemText', label: '物料文本' },
  { visible: true, prop: 'prLocation', label: '仓库' },
  { visible: true, prop: 'prDelivDate', label: '交货日期' },
  { visible: false, prop: 'prUnpaidQty', label: '未交' },
  { visible: false, prop: 'prAlreadyQty', label: '已交' },
  { visible: false, prop: 'prPurOrder', label: '订单号' },
  { visible: false, prop: 'prPurOrderDetails', label: '订单明细' },
  { visible: false, prop: 'prPlannedQty', label: '订单数量' },
  { visible: false, prop: 'prPurGroup', label: '采购组' },
  { visible: false, prop: 'prPurDate', label: '采购日期' },
  { visible: false, prop: 'prPurUnit', label: '单位' },
  { visible: false, prop: 'prUnitPrice', label: '价格单位' },
  { visible: false, prop: 'prPurCcy', label: '币种' },
  { visible: false, prop: 'prPurTaxType', label: '税别' },
  { visible: false, prop: 'prPrctr', label: '利润中心' },
  { visible: false, prop: 'prBalancedate', label: 'PO残发行日期' },
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









// 交货日期时间范围
const dateRangePrDelivDate = ref([])








// 采购日期时间范围
const dateRangePrPurDate = ref([])







// PO残发行日期时间范围
const dateRangePrBalancedate = ref([])








//字典参数
var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sql_cus_list" },
  { dictType: "sys_sloc_list" },
  { dictType: "sys_pur_group" },
  { dictType: "sys_unit_list" },
  { dictType: "sys_ccy_type" },
  { dictType: "sys_tax_list" },
  { dictType: "sql_prctr_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从PO残清单/mm_po_residue表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangePrDelivDate.value, 'PrDelivDate');
  proxy.addDateRange(queryParams, dateRangePrPurDate.value, 'PrPurDate');
  proxy.addDateRange(queryParams, dateRangePrBalancedate.value, 'PrBalancedate');
  loading.value = true
  listMmPoResidue(queryParams).then(res => {
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
  // 交货日期时间范围
  dateRangePrDelivDate.value = []
  // 采购日期时间范围
  dateRangePrPurDate.value = []
  // PO残发行日期时间范围
  dateRangePrBalancedate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.prSFID);
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
    prSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    prPlant: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prSupplierCode: [{ required: true, message: "供应商ID"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prSupplierName: [{ required: true, message: "供应商名称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPurItem: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPurItemText: [{ required: true, message: "物料文本"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prLocation: [{ required: true, message: "仓库"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prDelivDate: [{ required: true, message: "交货日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prUnpaidQty: [{ required: true, message: "未交"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prAlreadyQty: [{ required: true, message: "已交"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPurOrder: [{ required: true, message: "订单号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPurOrderDetails: [{ required: true, message: "订单明细"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPlannedQty: [{ required: true, message: "订单数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPurGroup: [{ required: true, message: "采购组"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prPurDate: [{ required: true, message: "采购日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPurUnit: [{ required: true, message: "单位"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prUnitPrice: [{ required: true, message: "价格单位"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    prPurCcy: [{ required: true, message: "币种"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prPurTaxType: [{ required: true, message: "税别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prPrctr: [{ required: true, message: "利润中心"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    prBalancedate: [{ required: true, message: "PO残发行日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_plant_list: [],
    // 供应商ID 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_cus_list: [],
    // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_sloc_list: [],
    // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_group: [],
    // 单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_unit_list: [],
    // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ccy_type: [],
    // 税别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_tax_list: [],
    // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_prctr_list: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_deleted: [],
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
    prSFID: 0,
    prPlant: null,
    prSupplierCode: null,
    prSupplierName: null,
    prPurItem: null,
    prPurItemText: null,
    prLocation: null,
    prDelivDate: null,
    prUnpaidQty: 0,
    prAlreadyQty: 0,
    prPurOrder: null,
    prPurOrderDetails: null,
    prPlannedQty: 0,
    prPurGroup: null,
    prPurDate: null,
    prPurUnit: null,
    prUnitPrice: 0,
    prPurCcy: null,
    prPurTaxType: null,
    prPrctr: null,
    prBalancedate: null,
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
  title.value = proxy.$t('btn.add')+" "+'PO残清单'
  opertype.value = 1
  form.value.prPlant= []
  form.value.prSupplierCode= []
  form.value.prLocation= []
  form.value.prDelivDate= new Date()
  form.value.prUnpaidQty= 0
  form.value.prAlreadyQty= 0
  form.value.prPlannedQty= 0
  form.value.prPurGroup= []
  form.value.prPurDate= new Date()
  form.value.prPurUnit= []
  form.value.prUnitPrice= 0
  form.value.prPurCcy= []
  form.value.prPurTaxType= []
  form.value.prPrctr= []
  form.value.prBalancedate= new Date()
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.prSFID || ids.value
  getMmPoResidue(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ 'PO残清单'
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

      if (form.value.prSFID != undefined && opertype.value === 2) {
        updateMmPoResidue(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addMmPoResidue(form.value).then((res) => {
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
  const Ids = row.prSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delMmPoResidue(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<PO残清单.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/MmPoResidue/export', { ...queryParams })
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