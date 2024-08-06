<!--
 * @Descripttion: 物料信息/mm_marb
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 14:13:37
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="工厂" prop="werks">
            <el-select filterable clearable v-model="queryParams.werks"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料号" prop="matnr">
            <el-input v-model="queryParams.matnr"
              :placeholder="$t('btn.enterSearchPrefix')+'物料号'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="行业领域" prop="mbrsh">
            <el-select filterable clearable v-model="queryParams.mbrsh"
              :placeholder="$t('btn.selectSearchPrefix')+'行业领域'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料类型" prop="mtart">
            <el-select filterable clearable v-model="queryParams.mtart"
              :placeholder="$t('btn.selectSearchPrefix')+'物料类型'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_matl_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="基本计量单位" prop="meins">
            <el-select filterable clearable v-model="queryParams.meins"
              :placeholder="$t('btn.selectSearchPrefix')+'基本计量单位'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料组" prop="matkl">
            <el-select filterable clearable v-model="queryParams.matkl"
              :placeholder="$t('btn.selectSearchPrefix')+'物料组'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_matl_group " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="采购组" prop="ekgrp">
            <el-select filterable clearable v-model="queryParams.ekgrp"
              :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="采购类型" prop="beskz">
            <el-select filterable clearable v-model="queryParams.beskz"
              :placeholder="$t('btn.selectSearchPrefix')+'采购类型'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="特殊采购类型" prop="sobsl">
            <el-select filterable clearable v-model="queryParams.sobsl"
              :placeholder="$t('btn.selectSearchPrefix')+'特殊采购类型'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_pur_spec " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="过帐到检验库存" prop="insmk">
            <el-radio-group v-model="queryParams.insmk">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_normal_whether " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="利润中心" prop="prctr">
            <el-select filterable clearable v-model="queryParams.prctr"
              :placeholder="$t('btn.selectSearchPrefix')+'利润中心'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="批次管理需求的标识" prop="xchpf">
            <el-radio-group v-model="queryParams.xchpf">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_normal_whether " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="评估类" prop="bklas">
            <el-select filterable clearable v-model="queryParams.bklas"
              :placeholder="$t('btn.selectSearchPrefix')+'评估类'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_val_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="币种" prop="waers">
            <el-select filterable clearable v-model="queryParams.waers"
              :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="发货库存地点" prop="lgpro">
            <el-select filterable clearable v-model="queryParams.lgpro"
              :placeholder="$t('btn.selectSearchPrefix')+'发货库存地点'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="外部采购的缺省仓储位置" prop="lgfsb">
            <el-select filterable clearable v-model="queryParams.lgfsb"
              :placeholder="$t('btn.selectSearchPrefix')+'外部采购的缺省仓储位置'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="在工厂级标记要删除的物料" prop="lvorm">
            <el-select filterable clearable v-model="queryParams.lvorm"
              :placeholder="$t('btn.selectSearchPrefix')+'在工厂级标记要删除的物料'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_eol_list " :key="item.dictValue" :label="item.dictLabel"
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
        <el-button class="btn-add" v-hasPermi="['mm:marb:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:marb:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:marb:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:marb:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/MmMarb/importTemplate" importUrl="/Logistics/MmMarb/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:marb:export']">
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
      <el-table-column prop="sfId" label="ID" align="center" v-if="columns.showColumn('sfId')" />
      <el-table-column prop="werks" label="工厂" align="center" v-if="columns.showColumn('werks')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.werks" />
        </template>
      </el-table-column>
      <el-table-column prop="matnr" label="物料号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('matnr')" />
      <el-table-column prop="mbrsh" label="行业领域" align="center" v-if="columns.showColumn('mbrsh')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mbrsh" />
        </template>
      </el-table-column>
      <el-table-column prop="mtart" label="物料类型" align="center" v-if="columns.showColumn('mtart')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_type " :value="scope.row.mtart" />
        </template>
      </el-table-column>
      <el-table-column prop="maktx" label="物料描述（短文本）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('maktx')" />
      <el-table-column prop="meins" label="基本计量单位" align="center" v-if="columns.showColumn('meins')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.meins" />
        </template>
      </el-table-column>
      <el-table-column prop="prdha" label="产品层次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('prdha')" />
      <el-table-column prop="matkl" label="物料组" align="center" v-if="columns.showColumn('matkl')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_group " :value="scope.row.matkl" />
        </template>
      </el-table-column>
      <el-table-column prop="ekgrp" label="采购组" align="center" v-if="columns.showColumn('ekgrp')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.ekgrp" />
        </template>
      </el-table-column>
      <el-table-column prop="beskz" label="采购类型" align="center" v-if="columns.showColumn('beskz')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_type " :value="scope.row.beskz" />
        </template>
      </el-table-column>
      <el-table-column prop="sobsl" label="特殊采购类型" align="center" v-if="columns.showColumn('sobsl')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_spec " :value="scope.row.sobsl" />
        </template>
      </el-table-column>
      <el-table-column prop="schgt" label="标识：散装物料" align="center" v-if="columns.showColumn('schgt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.schgt" />
        </template>
      </el-table-column>
      <el-table-column prop="bstmi" label="最小批量" align="center" v-if="columns.showColumn('bstmi')" />
      <el-table-column prop="bstme" label="基本计量单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bstme')" />
      <el-table-column prop="bstrf" label="采购订单数量的舍入值" align="center" v-if="columns.showColumn('bstrf')" />
      <el-table-column prop="kzwsm" label="基本计量单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzwsm')" />
      <el-table-column prop="plifz" label="计划的天数内交货" align="center" v-if="columns.showColumn('plifz')" />
      <el-table-column prop="dzeit" label="厂内生产时间" align="center" v-if="columns.showColumn('dzeit')" />
      <el-table-column prop="insmk" label="过帐到检验库存" align="center" v-if="columns.showColumn('insmk')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.insmk" />
        </template>
      </el-table-column>
      <el-table-column prop="prctr" label="利润中心" align="center" v-if="columns.showColumn('prctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.prctr" />
        </template>
      </el-table-column>
      <el-table-column prop="awsls" label="差异码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('awsls')" />
      <el-table-column prop="xchpf" label="批次管理需求的标识" align="center" v-if="columns.showColumn('xchpf')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.xchpf" />
        </template>
      </el-table-column>
      <el-table-column prop="mfrpn" label="制造商零件编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mfrpn')" />
      <el-table-column prop="mfrnr" label="制造商编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mfrnr')" />
      <el-table-column prop="bklas" label="评估类" align="center" v-if="columns.showColumn('bklas')">
        <template #default="scope">
          <dict-tag :options=" options.sys_val_type " :value="scope.row.bklas" />
        </template>
      </el-table-column>
      <el-table-column prop="verpr" label="移动平均价格/周期单价" align="center" v-if="columns.showColumn('verpr')" />
      <el-table-column prop="waers" label="币种" align="center" v-if="columns.showColumn('waers')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.waers" />
        </template>
      </el-table-column>
      <el-table-column prop="vprsv" label="价格控制指示符" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vprsv')" />
      <el-table-column prop="peinh" label="价格单位" align="center" v-if="columns.showColumn('peinh')" />
      <el-table-column prop="lgpro" label="发货库存地点" align="center" v-if="columns.showColumn('lgpro')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.lgpro" />
        </template>
      </el-table-column>
      <el-table-column prop="lgfsb" label="外部采购的缺省仓储位置" align="center" v-if="columns.showColumn('lgfsb')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.lgfsb" />
        </template>
      </el-table-column>
      <el-table-column prop="lgpbe" label="库存仓位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('lgpbe')" />
      <el-table-column prop="lbkum" label="总计已估计库存" align="center" v-if="columns.showColumn('lbkum')" />
      <el-table-column prop="lvorm" label="在工厂级标记要删除的物料" align="center" v-if="columns.showColumn('lvorm')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_list " :value="scope.row.lvorm" />
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
              v-hasPermi="['mm:marb:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['mm:marb:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改物料信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="sfId" prop="sfId">
                  <el-input v-model.number="form.sfId" :placeholder="$t('btn.enterPrefix')+'sfId'+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂" prop="werks">
                  <el-select filterable clearable v-model="form.werks"
                    :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料号" prop="matnr">
                  <el-input v-model="form.matnr" :placeholder="$t('btn.enterPrefix')+'物料号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="行业领域" prop="mbrsh">
                  <el-select filterable clearable v-model="form.mbrsh"
                    :placeholder="$t('btn.selectPrefix')+'行业领域'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ind_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料类型" prop="mtart">
                  <el-select filterable clearable v-model="form.mtart"
                    :placeholder="$t('btn.selectPrefix')+'物料类型'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_matl_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料描述（短文本）" prop="maktx">
                  <el-input v-model="form.maktx"
                    :placeholder="$t('btn.enterPrefix')+'物料描述（短文本）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基本计量单位" prop="meins">
                  <el-select filterable clearable v-model="form.meins"
                    :placeholder="$t('btn.selectPrefix')+'基本计量单位'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_unit_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="产品层次" prop="prdha">
                  <el-input v-model="form.prdha" :placeholder="$t('btn.enterPrefix')+'产品层次'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料组" prop="matkl">
                  <el-select filterable clearable v-model="form.matkl"
                    :placeholder="$t('btn.selectPrefix')+'物料组'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_matl_group" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="采购组" prop="ekgrp">
                  <el-select filterable clearable v-model="form.ekgrp"
                    :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_pur_group" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="采购类型" prop="beskz">
                  <el-select filterable clearable v-model="form.beskz"
                    :placeholder="$t('btn.selectPrefix')+'采购类型'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_pur_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="特殊采购类型" prop="sobsl">
                  <el-select filterable clearable v-model="form.sobsl"
                    :placeholder="$t('btn.selectPrefix')+'特殊采购类型'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_pur_spec" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="标识：散装物料" prop="schgt">
                  <el-select filterable clearable v-model="form.schgt"
                    :placeholder="$t('btn.selectPrefix')+'标识：散装物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_normal_whether" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="最小批量" prop="bstmi">
                  <el-input-number v-model.number="form.bstmi" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最小批量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基本计量单位" prop="bstme">
                  <el-input v-model="form.bstme" :placeholder="$t('btn.enterPrefix')+'基本计量单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购订单数量的舍入值" prop="bstrf">
                  <el-input-number v-model.number="form.bstrf" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'采购订单数量的舍入值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基本计量单位" prop="kzwsm">
                  <el-input v-model="form.kzwsm" :placeholder="$t('btn.enterPrefix')+'基本计量单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划的天数内交货" prop="plifz">
                  <el-input-number v-model.number="form.plifz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'计划的天数内交货'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="厂内生产时间" prop="dzeit">
                  <el-input-number v-model.number="form.dzeit" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'厂内生产时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="过帐到检验库存" prop="insmk">
                  <el-radio-group v-model="form.insmk">
                    <el-radio v-for="item in options.sys_normal_whether" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="利润中心" prop="prctr">
                  <el-select filterable clearable v-model="form.prctr"
                    :placeholder="$t('btn.selectPrefix')+'利润中心'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_prctr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="差异码" prop="awsls">
                  <el-input v-model="form.awsls" :placeholder="$t('btn.enterPrefix')+'差异码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批次管理需求的标识" prop="xchpf">
                  <el-radio-group v-model="form.xchpf">
                    <el-radio v-for="item in options.sys_normal_whether" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="制造商零件编号" prop="mfrpn">
                  <el-input v-model="form.mfrpn" :placeholder="$t('btn.enterPrefix')+'制造商零件编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="制造商编号" prop="mfrnr">
                  <el-input v-model="form.mfrnr" :placeholder="$t('btn.enterPrefix')+'制造商编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评估类" prop="bklas">
                  <el-select filterable clearable v-model="form.bklas"
                    :placeholder="$t('btn.selectPrefix')+'评估类'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_val_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="移动平均价格/周期单价" prop="verpr">
                  <el-input-number v-model.number="form.verpr" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'移动平均价格/周期单价'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="币种" prop="waers">
                  <el-select filterable clearable v-model="form.waers"
                    :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="价格控制指示符" prop="vprsv">
                  <el-input v-model="form.vprsv" :placeholder="$t('btn.enterPrefix')+'价格控制指示符'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="价格单位" prop="peinh">
                  <el-input-number v-model.number="form.peinh" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="发货库存地点" prop="lgpro">
                  <el-select filterable clearable v-model="form.lgpro"
                    :placeholder="$t('btn.selectPrefix')+'发货库存地点'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_sloc_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="外部采购的缺省仓储位置" prop="lgfsb">
                  <el-select filterable clearable v-model="form.lgfsb"
                    :placeholder="$t('btn.selectPrefix')+'外部采购的缺省仓储位置'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_sloc_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="库存仓位" prop="lgpbe">
                  <el-input v-model="form.lgpbe" :placeholder="$t('btn.enterPrefix')+'库存仓位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="总计已估计库存" prop="lbkum">
                  <el-input-number v-model.number="form.lbkum" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'总计已估计库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="在工厂级标记要删除的物料" prop="lvorm">
                  <el-select filterable clearable v-model="form.lvorm"
                    :placeholder="$t('btn.selectPrefix')+'在工厂级标记要删除的物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_eol_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="自定义A" prop="uDF01">
                  <el-input v-model="form.uDF01" :placeholder="$t('btn.enterPrefix')+'自定义A'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义B" prop="uDF02">
                  <el-input v-model="form.uDF02" :placeholder="$t('btn.enterPrefix')+'自定义B'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义C" prop="uDF03">
                  <el-input v-model="form.uDF03" :placeholder="$t('btn.enterPrefix')+'自定义C'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义D" prop="uDF04">
                  <el-input v-model="form.uDF04" :placeholder="$t('btn.enterPrefix')+'自定义D'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义E" prop="uDF05">
                  <el-input v-model="form.uDF05" :placeholder="$t('btn.enterPrefix')+'自定义E'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义F" prop="uDF06">
                  <el-input v-model="form.uDF06" :placeholder="$t('btn.enterPrefix')+'自定义F'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义1" prop="uDF51">
                  <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2" prop="uDF52">
                  <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3" prop="uDF53">
                  <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4" prop="uDF54">
                  <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5" prop="uDF55">
                  <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6" prop="uDF56">
                  <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
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

<script setup name="mmmarb">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listMmMarb,
    addMmMarb, delMmMarb,
    updateMmMarb, getMmMarb,
  }
    from '@/api/logistics/mmmarb.js'
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
    werks: undefined,
    //是否查询（1是）
    matnr: undefined,
    //是否查询（1是）
    mbrsh: undefined,
    //是否查询（1是）
    mtart: undefined,
    //是否查询（1是）
    meins: undefined,
    //是否查询（1是）
    matkl: undefined,
    //是否查询（1是）
    ekgrp: undefined,
    //是否查询（1是）
    beskz: undefined,
    //是否查询（1是）
    sobsl: undefined,
    //是否查询（1是）
    insmk: undefined,
    //是否查询（1是）
    prctr: undefined,
    //是否查询（1是）
    xchpf: undefined,
    //是否查询（1是）
    bklas: undefined,
    //是否查询（1是）
    waers: undefined,
    //是否查询（1是）
    lgpro: undefined,
    //是否查询（1是）
    lgfsb: undefined,
    //是否查询（1是）
    lvorm: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'sfId', label: 'sfId' },
    { visible: true, prop: 'werks', label: '工厂' },
    { visible: true, prop: 'matnr', label: '物料号' },
    { visible: true, prop: 'mbrsh', label: '行业领域' },
    { visible: true, prop: 'mtart', label: '物料类型' },
    { visible: true, prop: 'maktx', label: '物料描述（短文本）' },
    { visible: true, prop: 'meins', label: '基本计量单位' },
    { visible: true, prop: 'prdha', label: '产品层次' },
    { visible: false, prop: 'matkl', label: '物料组' },
    { visible: false, prop: 'ekgrp', label: '采购组' },
    { visible: false, prop: 'beskz', label: '采购类型' },
    { visible: false, prop: 'sobsl', label: '特殊采购类型' },
    { visible: false, prop: 'schgt', label: '标识：散装物料' },
    { visible: false, prop: 'bstmi', label: '最小批量' },
    { visible: false, prop: 'bstme', label: '基本计量单位' },
    { visible: false, prop: 'bstrf', label: '采购订单数量的舍入值' },
    { visible: false, prop: 'kzwsm', label: '基本计量单位' },
    { visible: false, prop: 'plifz', label: '计划的天数内交货' },
    { visible: false, prop: 'dzeit', label: '厂内生产时间' },
    { visible: false, prop: 'insmk', label: '过帐到检验库存' },
    { visible: false, prop: 'prctr', label: '利润中心' },
    { visible: false, prop: 'awsls', label: '差异码' },
    { visible: false, prop: 'xchpf', label: '批次管理需求的标识' },
    { visible: false, prop: 'mfrpn', label: '制造商零件编号' },
    { visible: false, prop: 'mfrnr', label: '制造商编号' },
    { visible: false, prop: 'bklas', label: '评估类' },
    { visible: false, prop: 'verpr', label: '移动平均价格/周期单价' },
    { visible: false, prop: 'waers', label: '币种' },
    { visible: false, prop: 'vprsv', label: '价格控制指示符' },
    { visible: false, prop: 'peinh', label: '价格单位' },
    { visible: false, prop: 'lgpro', label: '发货库存地点' },
    { visible: false, prop: 'lgfsb', label: '外部采购的缺省仓储位置' },
    { visible: false, prop: 'lgpbe', label: '库存仓位' },
    { visible: false, prop: 'lbkum', label: '总计已估计库存' },
    { visible: false, prop: 'lvorm', label: '在工厂级标记要删除的物料' },
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























































  //字典参数
  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sys_ind_type" },
    { dictType: "sys_matl_type" },
    { dictType: "sys_unit_list" },
    { dictType: "sys_matl_group" },
    { dictType: "sys_pur_group" },
    { dictType: "sys_pur_type" },
    { dictType: "sys_pur_spec" },
    { dictType: "sys_normal_whether" },
    { dictType: "sql_prctr_list" },
    { dictType: "sys_val_type" },
    { dictType: "sys_ccy_type" },
    { dictType: "sys_sloc_list" },
    { dictType: "sys_eol_list" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从物料信息/mm_marb表记录数据
  function getList() {
    loading.value = true
    listMmMarb(queryParams).then(res => {
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
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.sfId);
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
      sfId: [{ required: true, message: "sfId" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      werks: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      matnr: [{ required: true, message: "物料号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mbrsh: [{ required: true, message: "行业领域" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mtart: [{ required: true, message: "物料类型" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      meins: [{ required: true, message: "基本计量单位" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      matkl: [{ required: true, message: "物料组" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ekgrp: [{ required: true, message: "采购组" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      beskz: [{ required: true, message: "采购类型" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sobsl: [{ required: true, message: "特殊采购类型" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      insmk: [{ required: true, message: "过帐到检验库存" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      prctr: [{ required: true, message: "利润中心" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      xchpf: [{ required: true, message: "批次管理需求的标识" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      bklas: [{ required: true, message: "评估类" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      waers: [{ required: true, message: "币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      lgpro: [{ required: true, message: "发货库存地点" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      lgfsb: [{ required: true, message: "外部采购的缺省仓储位置" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      lvorm: [{ required: true, message: "在工厂级标记要删除的物料" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      uDF51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 行业领域 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ind_type: [],
      // 物料类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_matl_type: [],
      // 基本计量单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_unit_list: [],
      // 物料组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_matl_group: [],
      // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_group: [],
      // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_type: [],
      // 特殊采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_spec: [],
      // 标识：散装物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_normal_whether: [],
      // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_prctr_list: [],
      // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_val_type: [],
      // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
      // 发货库存地点 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sloc_list: [],
      // 在工厂级标记要删除的物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_eol_list: [],
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
      sfId: 0,
      werks: null,
      matnr: null,
      mbrsh: null,
      mtart: null,
      maktx: null,
      meins: null,
      prdha: null,
      matkl: null,
      ekgrp: null,
      beskz: null,
      sobsl: null,
      schgt: null,
      bstmi: 0,
      bstme: null,
      bstrf: 0,
      kzwsm: null,
      plifz: 0,
      dzeit: 0,
      insmk: null,
      prctr: null,
      awsls: null,
      xchpf: null,
      mfrpn: null,
      mfrnr: null,
      bklas: null,
      verpr: 0,
      waers: null,
      vprsv: null,
      peinh: 0,
      lgpro: null,
      lgfsb: null,
      lgpbe: null,
      lbkum: 0,
      lvorm: null,
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
    title.value = proxy.$t('btn.add') + " " + '物料信息'
    opertype.value = 1
    form.value.werks = []
    form.value.mbrsh = []
    form.value.mtart = []
    form.value.meins = []
    form.value.matkl = []
    form.value.ekgrp = []
    form.value.beskz = []
    form.value.sobsl = []
    form.value.schgt = []
    form.value.bstmi = 0
    form.value.bstrf = 0
    form.value.plifz = 0
    form.value.dzeit = 0
    form.value.insmk = 0
    form.value.prctr = []
    form.value.xchpf = 0
    form.value.bklas = []
    form.value.verpr = 0
    form.value.waers = []
    form.value.peinh = 0
    form.value.lgpro = []
    form.value.lgfsb = []
    form.value.lbkum = 0
    form.value.lvorm = []
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.sfId || ids.value
    getMmMarb(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '物料信息'
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

        if (form.value.sfId != undefined && opertype.value === 2) {
          updateMmMarb(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addMmMarb(form.value).then((res) => {
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
    const Ids = row.sfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delMmMarb(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<物料信息.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/MmMarb/export', { ...queryParams })
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