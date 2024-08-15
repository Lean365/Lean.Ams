<!--
 * @Descripttion: 销售凭证/sd_selling_invoice
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 13:36:22
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="工厂" prop="ssiPlnt">
            <el-select filterable clearable v-model="queryParams.ssiPlnt"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="期间" prop="ssiFy">
            <el-select filterable clearable v-model="queryParams.ssiFy"
              :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')" @change="handleFyChange">
              <el-option v-for="item in   options.sql_fy_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="年月" prop="ssiYm">
            <el-select filterable clearable v-model="queryParams.ssiYm"
              :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   cascadeFm " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="客户" prop="ssiCustomercode">
            <el-select filterable clearable v-model="queryParams.ssiCustomercode"
              :placeholder="$t('btn.selectSearchPrefix')+'客户'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_cus_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="利润中心" prop="ssiPrctr">
            <el-select filterable clearable v-model="queryParams.ssiPrctr"
              :placeholder="$t('btn.selectSearchPrefix')+'利润中心'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料" prop="ssiSalesitem">
            <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
              :loading="loading " v-model="queryParams.ssiSalesitem"
              :placeholder="$t('btn.selectSearchPrefix')+'物料'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="原币币种" prop="ssiOriginalccy">
            <el-select filterable clearable v-model="queryParams.ssiOriginalccy"
              :placeholder="$t('btn.selectSearchPrefix')+'原币币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="过账日期">
            <el-date-picker v-model="dateRangeSsiPostingdate" type="datetimerange"
              :start-placeholder="$t('btn.dateStart')" :end-placeholder="$t('btn.dateEnd')"
              value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime" :shortcuts="dateOptions">
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
        <el-button class="btn-add" v-hasPermi="['sd:sellinginvoice:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sd:sellinginvoice:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sd:sellinginvoice:delete']" plain
          icon="delete" @click="handleDelete">
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
                <importData templateUrl="Logistics/SdSellingInvoice/importTemplate"
                  importUrl="/Logistics/SdSellingInvoice/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['sd:sellinginvoice:export']">
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
      <el-table-column prop="ssiSfid" label="SFID" align="center" v-if="columns.showColumn('ssiSfid')" />
      <el-table-column prop="ssiPlnt" label="工厂" align="center" v-if="columns.showColumn('ssiPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.ssiPlnt" />
        </template>
      </el-table-column>
      <el-table-column prop="ssiFy" label="期间" align="center" v-if="columns.showColumn('ssiFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_fy_list " :value="scope.row.ssiFy" />
        </template>
      </el-table-column>
      <el-table-column prop="ssiYm" label="年月" align="center" v-if="columns.showColumn('ssiYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.ssiYm" />
        </template>
      </el-table-column>
      <el-table-column prop="ssiAccdocno" label="销售凭证" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiAccdocno')" />
      <el-table-column prop="ssiAccdoclineno" label="凭证明细" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiAccdoclineno')" />
      <el-table-column prop="ssiCustomercode" label="客户" align="center" v-if="columns.showColumn('ssiCustomercode')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cus_list " :value="scope.row.ssiCustomercode" />
        </template>
      </el-table-column>
      <el-table-column prop="ssiPrctr" label="利润中心" align="center" v-if="columns.showColumn('ssiPrctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.ssiPrctr" />
        </template>
      </el-table-column>
      <el-table-column prop="ssiSalesitem" label="物料" align="center" v-if="columns.showColumn('ssiSalesitem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.ssiSalesitem" />
        </template>
      </el-table-column>
      <el-table-column prop="ssiAccountcode" label="科目" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiAccountcode')" />
      <el-table-column prop="ssiSalesqty" label="销售数量" align="center" v-if="columns.showColumn('ssiSalesqty')" />
      <el-table-column prop="ssiSalesunit" label="销售单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiSalesunit')" />
      <el-table-column prop="ssiOriginalamount" label="原币销售额" align="center"
        v-if="columns.showColumn('ssiOriginalamount')" />
      <el-table-column prop="ssiOriginalccy" label="原币币种" align="center" v-if="columns.showColumn('ssiOriginalccy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.ssiOriginalccy" />
        </template>
      </el-table-column>
      <el-table-column prop="ssiLocalamount" label="本币销售额" align="center" v-if="columns.showColumn('ssiLocalamount')" />
      <el-table-column prop="ssiLocalccy" label="本币币种" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiLocalccy')" />
      <el-table-column prop="ssiRefdocno" label="参考凭证" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiRefdocno')" />
      <el-table-column prop="ssiRefdoclineno" label="参考明细" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiRefdoclineno')" />
      <el-table-column prop="ssiPostingdate" label="过账日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiPostingdate')" />
      <el-table-column prop="ssiPostinguser" label="用户" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiPostinguser')" />
      <el-table-column prop="ssiEntrydate" label="输入日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiEntrydate')" />
      <el-table-column prop="ssiEntrytime" label="输入时间" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiEntrytime')" />
      <el-table-column prop="ssiOrigin" label="来源" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiOrigin')" />
      <el-table-column prop="ssiPgroup" label="产品组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiPgroup')" />
      <el-table-column prop="ssiAccdoctype" label="凭证类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiAccdoctype')" />
      <el-table-column prop="ssiAccdoctext" label="凭证名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssiAccdoctext')" />
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true"
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
              v-hasPermi="['sd:sellinginvoice:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['sd:sellinginvoice:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改销售凭证对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="SFID" prop="ssiSfid">
                  <el-input v-model.number="form.ssiSfid"
                    :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂" prop="ssiPlnt">
                  <el-select filterable clearable v-model="form.ssiPlnt"
                    :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="期间" prop="ssiFy">
                  <el-select filterable clearable v-model="form.ssiFy"
                    :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')" @change="handleFyChange">
                    <el-option v-for="item in  options.sql_fy_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="年月" prop="ssiYm">
                  <el-select filterable clearable v-model="form.ssiYm"
                    :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  cascadeFm" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="销售凭证" prop="ssiAccdocno">
                  <el-input v-model="form.ssiAccdocno"
                    :placeholder="$t('btn.enterPrefix')+'销售凭证'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="凭证明细" prop="ssiAccdoclineno">
                  <el-input v-model="form.ssiAccdoclineno"
                    :placeholder="$t('btn.enterPrefix')+'凭证明细'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="客户" prop="ssiCustomercode">
                  <el-select filterable clearable v-model="form.ssiCustomercode"
                    :placeholder="$t('btn.selectPrefix')+'客户'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_cus_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="利润中心" prop="ssiPrctr">
                  <el-select filterable clearable v-model="form.ssiPrctr"
                    :placeholder="$t('btn.selectPrefix')+'利润中心'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_prctr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料" prop="ssiSalesitem">
                  <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
                    :loading="loading " v-model="form.ssiSalesitem"
                    :placeholder="$t('btn.selectPrefix')+'物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  remotequery_sql_mats_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="科目" prop="ssiAccountcode">
                  <el-input v-model="form.ssiAccountcode"
                    :placeholder="$t('btn.enterPrefix')+'科目'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="销售数量" prop="ssiSalesqty">
                  <el-input-number v-model.number="form.ssiSalesqty" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'销售数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="销售单位" prop="ssiSalesunit">
                  <el-input v-model="form.ssiSalesunit"
                    :placeholder="$t('btn.enterPrefix')+'销售单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="原币销售额" prop="ssiOriginalamount">
                  <el-input-number v-model.number="form.ssiOriginalamount" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'原币销售额'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="原币币种" prop="ssiOriginalccy">
                  <el-select filterable clearable v-model="form.ssiOriginalccy"
                    :placeholder="$t('btn.selectPrefix')+'原币币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="本币销售额" prop="ssiLocalamount">
                  <el-input-number v-model.number="form.ssiLocalamount" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'本币销售额'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="本币币种" prop="ssiLocalccy">
                  <el-input v-model="form.ssiLocalccy"
                    :placeholder="$t('btn.enterPrefix')+'本币币种'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="参考凭证" prop="ssiRefdocno">
                  <el-input v-model="form.ssiRefdocno"
                    :placeholder="$t('btn.enterPrefix')+'参考凭证'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="参考明细" prop="ssiRefdoclineno">
                  <el-input v-model="form.ssiRefdoclineno"
                    :placeholder="$t('btn.enterPrefix')+'参考明细'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="过账日期" prop="ssiPostingdate">
                  <el-date-picker v-model="form.ssiPostingdate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用户" prop="ssiPostinguser">
                  <el-input v-model="form.ssiPostinguser"
                    :placeholder="$t('btn.enterPrefix')+'用户'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="输入日期" prop="ssiEntrydate">
                  <el-date-picker v-model="form.ssiEntrydate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="输入时间" prop="ssiEntrytime">
                  <el-input v-model="form.ssiEntrytime"
                    :placeholder="$t('btn.enterPrefix')+'输入时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="来源" prop="ssiOrigin">
                  <el-input v-model="form.ssiOrigin" :placeholder="$t('btn.enterPrefix')+'来源'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="产品组" prop="ssiPgroup">
                  <el-input v-model="form.ssiPgroup" :placeholder="$t('btn.enterPrefix')+'产品组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="凭证类型" prop="ssiAccdoctype">
                  <el-input v-model="form.ssiAccdoctype"
                    :placeholder="$t('btn.enterPrefix')+'凭证类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="凭证名称" prop="ssiAccdoctext">
                  <el-input v-model="form.ssiAccdoctext"
                    :placeholder="$t('btn.enterPrefix')+'凭证名称'+$t('btn.enterSuffix')" />
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

              <el-col :lg="12">
                <el-form-item label="说明" prop="remark">
                  <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
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

<script setup name="sdsellinginvoice">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listSdSellingInvoice,
    addSdSellingInvoice, delSdSellingInvoice,
    updateSdSellingInvoice, getSdSellingInvoice,
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
    sort: '',
    sortType: 'asc',
    //是否查询（1是）
    ssiPlnt: undefined,
    //是否查询（1是）
    ssiFy: undefined,
    //是否查询（1是）
    ssiYm: undefined,
    //是否查询（1是）
    ssiCustomercode: undefined,
    //是否查询（1是）
    ssiPrctr: undefined,
    //是否查询（1是）
    ssiSalesitem: undefined,
    //是否查询（1是）
    ssiOriginalccy: undefined,
    //是否查询（1是）
    ssiPostingdate: undefined,
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
  // 过账日期时间范围
  const dateRangeSsiPostingdate = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sql_fy_list" },
    { dictType: "sql_ym_list" },
    { dictType: "sql_cus_list" },
    { dictType: "sql_prctr_list" },
    { dictType: "sys_ccy_type" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从销售凭证/sd_selling_invoice表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeSsiPostingdate.value, 'SsiPostingdate');
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
  function resetQuery() {
    // 过账日期时间范围
    dateRangeSsiPostingdate.value = []
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
      ssiSfid: [{ required: true, message: "SFID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiPlnt: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ssiFy: [{ required: true, message: "期间" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ssiYm: [{ required: true, message: "年月" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ssiAccdocno: [{ required: true, message: "销售凭证" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiAccdoclineno: [{ required: true, message: "凭证明细" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiCustomercode: [{ required: true, message: "客户" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ssiPrctr: [{ required: true, message: "利润中心" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ssiSalesitem: [{ required: true, message: "物料" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiAccountcode: [{ required: true, message: "科目" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiSalesqty: [{ required: true, message: "销售数量" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiSalesunit: [{ required: true, message: "销售单位" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiOriginalamount: [{ required: true, message: "原币销售额" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiOriginalccy: [{ required: true, message: "原币币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ssiLocalamount: [{ required: true, message: "本币销售额" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiLocalccy: [{ required: true, message: "本币币种" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiRefdocno: [{ required: true, message: "参考凭证" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiRefdoclineno: [{ required: true, message: "参考明细" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiPostingdate: [{ required: true, message: "过账日期" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiPostinguser: [{ required: true, message: "用户" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiEntrydate: [{ required: true, message: "输入日期" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiEntrytime: [{ required: true, message: "输入时间" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiOrigin: [{ required: true, message: "来源" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiPgroup: [{ required: true, message: "产品组" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiAccdoctype: [{ required: true, message: "凭证类型" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ssiAccdoctext: [{ required: true, message: "凭证名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_fy_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ym_list: [],
      // 客户 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_cus_list: [],
      // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_prctr_list: [],
      // 原币币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
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
  const cascadeFm = ref()


  const handleFyChange = (event) => {
    form.value.ssiYm = null
    queryParams.ssiYm = null
    //ffy.value = event
    // console.log(ffy.value)
    // 这里可以添加其他逻辑，比如触发父组件的方法

    cascadeFm.value = state.options.sql_ym_list.filter(item => item.label.includes((event)))
    //form.sspYm.value = []
    //return selectedCountry.value ? cities[selectedCountry.value] : []


  }
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
      ssiSalesitemChecked: [],
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
    title.value = proxy.$t('btn.add') + " " + '销售凭证'
    opertype.value = 1
    form.value.ssiPlnt = []
    form.value.ssiFy = []
    form.value.ssiYm = []
    form.value.ssiCustomercode = []
    form.value.ssiPrctr = []
    form.value.ssiSalesqty = 0
    form.value.ssiOriginalamount = 0
    form.value.ssiOriginalccy = []
    form.value.ssiLocalamount = 0
    form.value.ssiPostingdate = new Date()
    form.value.ssiEntrydate = new Date()
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.ssiSfid || ids.value
    getSdSellingInvoice(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '销售凭证'
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
    const Ids = row.ssiSfid || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<销售凭证.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
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