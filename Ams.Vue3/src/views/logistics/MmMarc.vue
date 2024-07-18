<!--
 * @Descripttion: 工厂物料/mm_marc
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 10:45:06
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="物料号" prop="matnr">
            <el-input v-model="queryParams.matnr"
              :placeholder="$t('btn.enterSearchPrefix')+'物料号'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
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
          <el-form-item label="工厂级标记" prop="lvorm">
            <el-select filterable clearable v-model="queryParams.lvorm"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂级标记'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_is_deleted " :key="item.dictValue" :label="item.dictLabel"
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
          <el-form-item label="标识: 允许自动采购订单" prop="kautb">
            <el-radio-group v-model="queryParams.kautb">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_normal_whether " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="标识: 源清单要求" prop="kordb">
            <el-radio-group v-model="queryParams.kordb">
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
        <el-button class="btn-add" v-hasPermi="['mm:marc:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:marc:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:marc:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:marc:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/MmMarc/importTemplate" importUrl="/Logistics/MmMarc/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:marc:export']">
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
      <el-table-column prop="sfid" label="ID主键" align="center" v-if="columns.showColumn('sfid')" />
      <el-table-column prop="mandt" label="集团" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mandt')" />
      <el-table-column prop="matnr" label="物料号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('matnr')" />
      <el-table-column prop="werks" label="工厂" align="center" v-if="columns.showColumn('werks')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.werks" />
        </template>
      </el-table-column>
      <el-table-column prop="pstat" label="维护状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pstat')" />
      <el-table-column prop="lvorm" label="工厂级标记" align="center" v-if="columns.showColumn('lvorm')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_deleted " :value="scope.row.lvorm" />
        </template>
      </el-table-column>
      <el-table-column prop="bwtty" label="评估类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bwtty')" />
      <el-table-column prop="xchar" label="批量管理" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('xchar')" />
      <el-table-column prop="mmsta" label="工厂特定状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mmsta')" />
      <el-table-column prop="mmstd" label="工厂特定起始日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mmstd')" />
      <el-table-column prop="maabc" label="ABC标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('maabc')" />
      <el-table-column prop="kzkri" label="标志：关键部件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzkri')" />
      <el-table-column prop="ekgrp" label="采购组" align="center" v-if="columns.showColumn('ekgrp')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.ekgrp" />
        </template>
      </el-table-column>
      <el-table-column prop="ausme" label="发货单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ausme')" />
      <el-table-column prop="dispr" label="物料: MRP 参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dispr')" />
      <el-table-column prop="dismm" label="物料需求计划类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dismm')" />
      <el-table-column prop="dispo" label="MRP 控制者（物料计划人）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dispo')" />
      <el-table-column prop="kzdie" label="标识: MRP控制者是买方(未激活的)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzdie')" />
      <el-table-column prop="plifz" label="计划的天数内交货" align="center" v-if="columns.showColumn('plifz')" />
      <el-table-column prop="webaz" label="以天计的收货处理时间" align="center" v-if="columns.showColumn('webaz')" />
      <el-table-column prop="perkz" label="期间标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('perkz')" />
      <el-table-column prop="ausss" label="装配报废百分比" align="center" v-if="columns.showColumn('ausss')" />
      <el-table-column prop="disls" label="批量 (物料计划)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('disls')" />
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
      <el-table-column prop="minbe" label="再订货点" align="center" v-if="columns.showColumn('minbe')" />
      <el-table-column prop="eisbe" label="安全库存" align="center" v-if="columns.showColumn('eisbe')" />
      <el-table-column prop="bstmi" label="最小批量" align="center" v-if="columns.showColumn('bstmi')" />
      <el-table-column prop="bstma" label="最大批量大小" align="center" v-if="columns.showColumn('bstma')" />
      <el-table-column prop="bstfe" label="固定批量大小" align="center" v-if="columns.showColumn('bstfe')" />
      <el-table-column prop="bstrf" label="采购订单数量的舍入值" align="center" v-if="columns.showColumn('bstrf')" />
      <el-table-column prop="mabst" label="最大库存水平" align="center" v-if="columns.showColumn('mabst')" />
      <el-table-column prop="losfx" label="订购成本" align="center" v-if="columns.showColumn('losfx')" />
      <el-table-column prop="sbdkz" label="对于独立和集中需求的相关需求标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sbdkz')" />
      <el-table-column prop="lagpr" label="库存成本标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('lagpr')" />
      <el-table-column prop="altsl" label="选择可替换物料单的方法" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('altsl')" />
      <el-table-column prop="kzaus" label="中止指示符" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzaus')" />
      <el-table-column prop="ausdt" label="中断日期" :show-overflow-tooltip="true" v-if="columns.showColumn('ausdt')" />
      <el-table-column prop="nfmat" label="后续物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('nfmat')" />
      <el-table-column prop="kzbed" label="需求分组指示符" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzbed')" />
      <el-table-column prop="miskz" label="综合MRP标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('miskz')" />
      <el-table-column prop="fhori" label="浮动的计划边际码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fhori')" />
      <el-table-column prop="pfrei" label="标识: 计划订单的自动修正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pfrei')" />
      <el-table-column prop="ffrei" label="用于生产订单的批准标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ffrei')" />
      <el-table-column prop="rgekz" label="标识：反冲" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rgekz')" />
      <el-table-column prop="fevor" label="生产管理员" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fevor')" />
      <el-table-column prop="bearz" label="处理时间" align="center" v-if="columns.showColumn('bearz')" />
      <el-table-column prop="ruezt" label="建立和拆卸时间" align="center" v-if="columns.showColumn('ruezt')" />
      <el-table-column prop="tranz" label="工序间时间" align="center" v-if="columns.showColumn('tranz')" />
      <el-table-column prop="basmg" label="基准数量" align="center" v-if="columns.showColumn('basmg')" />
      <el-table-column prop="dzeit" label="厂内生产时间" align="center" v-if="columns.showColumn('dzeit')" />
      <el-table-column prop="maxlz" label="最大存储期间" align="center" v-if="columns.showColumn('maxlz')" />
      <el-table-column prop="lzeih" label="最大库存期间单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('lzeih')" />
      <el-table-column prop="kzpro" label="标识: 从生产区的库存提取" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzpro')" />
      <el-table-column prop="gpmkz" label="标识: 在初步计划中包括的物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('gpmkz')" />
      <el-table-column prop="ueeto" label="超量交货容差限制" align="center" v-if="columns.showColumn('ueeto')" />
      <el-table-column prop="ueetk" label="标识：允许未限制的过量交货" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ueetk')" />
      <el-table-column prop="uneto" label="不足交货容差限制" align="center" v-if="columns.showColumn('uneto')" />
      <el-table-column prop="wzeit" label="总计补货提前时间(按工作日)" align="center" v-if="columns.showColumn('wzeit')" />
      <el-table-column prop="atpkz" label="替换部件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('atpkz')" />
      <el-table-column prop="vzusl" label="用百分比表示的成本的附加因子" align="center" v-if="columns.showColumn('vzusl')" />
      <el-table-column prop="herbl" label="生产状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('herbl')" />
      <el-table-column prop="insmk" label="过帐到检验库存" align="center" v-if="columns.showColumn('insmk')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.insmk" />
        </template>
      </el-table-column>
      <el-table-column prop="sproz" label="质量检查的样本(在%中)(取消激活)" align="center" v-if="columns.showColumn('sproz')" />
      <el-table-column prop="quazt" label="隔离期(未激活)" align="center" v-if="columns.showColumn('quazt')" />
      <el-table-column prop="ssqss" label="采购中质量管理的控制码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ssqss')" />
      <el-table-column prop="mpdau" label="平均检查持续期间(未激活的的)" align="center" v-if="columns.showColumn('mpdau')" />
      <el-table-column prop="kzppv" label="检查计划的标识(未激活)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzppv')" />
      <el-table-column prop="kzdkz" label="凭证需求标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzdkz')" />
      <el-table-column prop="wstgh" label="活动性物质内容(未激活的)" align="center" v-if="columns.showColumn('wstgh')" />
      <el-table-column prop="prfrq" label="循环检查间隔" align="center" v-if="columns.showColumn('prfrq')" />
      <el-table-column prop="nkmpr" label="根据检验抽样检查的日期(取消激活)" :show-overflow-tooltip="true"
        v-if="columns.showColumn('nkmpr')" />
      <el-table-column prop="umlmc" label="中转库存（工厂到工厂）" align="center" v-if="columns.showColumn('umlmc')" />
      <el-table-column prop="ladgr" label="装载组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ladgr')" />
      <el-table-column prop="xchpf" label="批次管理需求的标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('xchpf')" />
      <el-table-column prop="usequ" label="配额分配使用" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('usequ')" />
      <el-table-column prop="lgrad" label="服务水平" align="center" v-if="columns.showColumn('lgrad')" />
      <el-table-column prop="auftl" label="分割标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('auftl')" />
      <el-table-column prop="plvar" label="计划版本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('plvar')" />
      <el-table-column prop="otype" label="对象类型" align="center" v-if="columns.showColumn('otype')">
        <template #default="scope">
          <dict-tag :options=" options.otypeOptions" :value="scope.row.otype" />
        </template>
      </el-table-column>
      <el-table-column prop="objid" label="对象标识" align="center" v-if="columns.showColumn('objid')" />
      <el-table-column prop="mtvfp" label="可用性检查的检查组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mtvfp')" />
      <el-table-column prop="periv" label="会计年度变式" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('periv')" />
      <el-table-column prop="kzkfk" label="标识: 考虑修正因子" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzkfk')" />
      <el-table-column prop="vrvez" label="装运建立时间" align="center" v-if="columns.showColumn('vrvez')" />
      <el-table-column prop="vbamg" label="在装运中有关能力计划的基准数量" align="center" v-if="columns.showColumn('vbamg')" />
      <el-table-column prop="vbeaz" label="处理时间: 装运" align="center" v-if="columns.showColumn('vbeaz')" />
      <el-table-column prop="lizyk" label="取消激活的" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('lizyk')" />
      <el-table-column prop="bwscl" label="货源" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bwscl')" />
      <el-table-column prop="kautb" label="标识: 允许自动采购订单" align="center" v-if="columns.showColumn('kautb')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.kautb" />
        </template>
      </el-table-column>
      <el-table-column prop="kordb" label="标识: 源清单要求" align="center" v-if="columns.showColumn('kordb')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.kordb" />
        </template>
      </el-table-column>
      <el-table-column prop="stawn" label="外贸的商品代码和进口代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('stawn')" />
      <el-table-column prop="herkl" label="物料原产地国家" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('herkl')" />
      <el-table-column prop="herkr" label="物料原产地（非特惠货源）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('herkr')" />
      <el-table-column prop="expme" label="商品代码的计量单位(外贸)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('expme')" />
      <el-table-column prop="mtver" label="出口/进口物料组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mtver')" />
      <el-table-column prop="prctr" label="利润中心" align="center" v-if="columns.showColumn('prctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.prctr" />
        </template>
      </el-table-column>
      <el-table-column prop="trame" label="在途库存" align="center" v-if="columns.showColumn('trame')" />
      <el-table-column prop="mrppp" label="PPC 计划日历" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mrppp')" />
      <el-table-column prop="sauft" label="标识: 允许的重复制造" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sauft')" />
      <el-table-column prop="fxhor" label="计划的时界" align="center" v-if="columns.showColumn('fxhor')" />
      <el-table-column prop="vrmod" label="消耗模式" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vrmod')" />
      <el-table-column prop="vint1" label="消耗期间:逆向" align="center" v-if="columns.showColumn('vint1')" />
      <el-table-column prop="vint2" label="消耗时期-向前" align="center" v-if="columns.showColumn('vint2')" />
      <el-table-column prop="verkz" label="版本标识符" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('verkz')" />
      <el-table-column prop="stlal" label="可选的 BOM" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('stlal')" />
      <el-table-column prop="stlan" label="BOM 用途" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('stlan')" />
      <el-table-column prop="plnnr" label="任务清单组码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('plnnr')" />
      <el-table-column prop="aplal" label="组计数器" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('aplal')" />
      <el-table-column prop="losgr" label="批量产品成本核算" align="center" v-if="columns.showColumn('losgr')" />
      <el-table-column prop="sobsk" label="成本核算的特殊采购类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sobsk')" />
      <el-table-column prop="frtme" label="生产单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('frtme')" />
      <el-table-column prop="lgpro" label="发货库存地点" align="center" v-if="columns.showColumn('lgpro')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.lgpro" />
        </template>
      </el-table-column>
      <el-table-column prop="disgr" label="物料需求计划组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('disgr')" />
      <el-table-column prop="kausf" label="部件废品百分数" align="center" v-if="columns.showColumn('kausf')" />
      <el-table-column prop="qzgtp" label="证书类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('qzgtp')" />
      <el-table-column prop="qmatv" label="物料/工厂的检验设置存在" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('qmatv')" />
      <el-table-column prop="takzt" label="间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)" align="center"
        v-if="columns.showColumn('takzt')" />
      <el-table-column prop="rwpro" label="供货天数参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rwpro')" />
      <el-table-column prop="copam" label="连接到SOP上的CO/PA局部字段名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('copam')" />
      <el-table-column prop="abcin" label="周期盘点的盘点标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('abcin')" />
      <el-table-column prop="awsls" label="差异码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('awsls')" />
      <el-table-column prop="sernp" label="序列号参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sernp')" />
      <el-table-column prop="cuobj" label="内部对象号" align="center" v-if="columns.showColumn('cuobj')" />
      <el-table-column prop="stdpd" label="可配置的物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('stdpd')" />
      <el-table-column prop="sfepr" label="重复生产参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sfepr')" />
      <el-table-column prop="xmcng" label="工厂中允许负库存" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('xmcng')" />
      <el-table-column prop="qssys" label="要求的供应商质量管理系统" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('qssys')" />
      <el-table-column prop="lfrhy" label="计划周期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('lfrhy')" />
      <el-table-column prop="rdprf" label="舍入参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rdprf')" />
      <el-table-column prop="vrbmt" label="消耗的参考物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vrbmt')" />
      <el-table-column prop="vrbwk" label="消耗的参考工厂" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vrbwk')" />
      <el-table-column prop="vrbdt" label="到消耗物料将被复制的日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vrbdt')" />
      <el-table-column prop="vrbfk" label="消耗的参考物料的乘数" align="center" v-if="columns.showColumn('vrbfk')" />
      <el-table-column prop="autru" label="自动重置预测模式" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('autru')" />
      <el-table-column prop="prefe" label="进/出口中优惠指示符" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('prefe')" />
      <el-table-column prop="prenc" label="免税证明：法律控制指示符" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('prenc')" />
      <el-table-column prop="preno" label="法律控制的免税证书编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('preno')" />
      <el-table-column prop="prend" label="免税证明：免税证书的发放日" :show-overflow-tooltip="true"
        v-if="columns.showColumn('prend')" />
      <el-table-column prop="prene" label="标识：存在供应商申报" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('prene')" />
      <el-table-column prop="preng" label="供应商申报的有效日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('preng')" />
      <el-table-column prop="itark" label="指示符：军用物资" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('itark')" />
      <el-table-column prop="servg" label="IS－R服务级别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('servg')" />
      <el-table-column prop="kzkup" label="指示符 : 物料是联产品" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzkup')" />
      <el-table-column prop="strgr" label="计划策略组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('strgr')" />
      <el-table-column prop="cuobv" label="计划中的可配置物料的内部对象号" align="center" v-if="columns.showColumn('cuobv')" />
      <el-table-column prop="lgfsb" label="外部采购的缺省仓储位置" align="center" v-if="columns.showColumn('lgfsb')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.lgfsb" />
        </template>
      </el-table-column>
      <el-table-column prop="schgt" label="标识：散装物料" align="center" v-if="columns.showColumn('schgt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.schgt" />
        </template>
      </el-table-column>
      <el-table-column prop="ccfix" label="周期标识被固定" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ccfix')" />
      <el-table-column prop="eprio" label="库存确定组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('eprio')" />
      <el-table-column prop="qmata" label="QM 中活动的物料授权组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('qmata')" />
      <el-table-column prop="resvp" label="计划独立需求的调整期间" align="center" v-if="columns.showColumn('resvp')" />
      <el-table-column prop="plnty" label="任务清单类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('plnty')" />
      <el-table-column prop="uomgr" label="计量组单位 (石油,天然气,...)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('uomgr')" />
      <el-table-column prop="umrsl" label="转换组 (石油,天然气,..)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('umrsl')" />
      <el-table-column prop="abfac" label="空气浮力因子" align="center" v-if="columns.showColumn('abfac')" />
      <el-table-column prop="sfcpf" label="生产计划参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sfcpf')" />
      <el-table-column prop="shflg" label="安全时间标识（含或不含安全时间）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('shflg')" />
      <el-table-column prop="shzet" label="安全时间（按工作日计算）" align="center" v-if="columns.showColumn('shzet')" />
      <el-table-column prop="mdach" label="活动控制：计划订单处理" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mdach')" />
      <el-table-column prop="kzech" label="在生产/处理订单中批量输入的确定" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzech')" />
      <el-table-column prop="megru" label="计量单位组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('megru')" />
      <el-table-column prop="mfrgr" label="物料运输组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mfrgr')" />
      <el-table-column prop="vkumc" label="VO 物料的库存转移销售值（工厂到工厂）" align="center" v-if="columns.showColumn('vkumc')" />
      <el-table-column prop="vktrw" label="仅记值物料的销售价格计的运输值" align="center" v-if="columns.showColumn('vktrw')" />
      <el-table-column prop="kzagl" label="指示符: 平滑促销消耗" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzagl')" />
      <el-table-column prop="fvidk" label="将进行成本核算的生产版本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fvidk')" />
      <el-table-column prop="fxpru" label="固定价格联产品" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fxpru')" />
      <el-table-column prop="loggr" label="用于计算工作负荷的后勤处理组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('loggr')" />
      <el-table-column prop="fprfm" label="工厂物料分销参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fprfm')" />
      <el-table-column prop="glgmg" label="有约束的虚拟库存" align="center" v-if="columns.showColumn('glgmg')" />
      <el-table-column prop="vkglg" label="连接空缺库存的销售价" align="center" v-if="columns.showColumn('vkglg')" />
      <el-table-column prop="indus" label="物料: CFOP类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('indus')" />
      <el-table-column prop="mownr" label="CAP：CAP 产品清单编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mownr')" />
      <el-table-column prop="mogru" label="共同农业市场政策：CAP 产品组－外贸" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mogru')" />
      <el-table-column prop="casnr" label="外贸药品 CAS 号码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('casnr')" />
      <el-table-column prop="gpnum" label="生产统计：外贸 PRODCOM 号码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('gpnum')" />
      <el-table-column prop="steuc" label="对外贸易消费税控制代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('steuc')" />
      <el-table-column prop="fabkz" label="标识: 与 JIT 交货计划相关的物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fabkz')" />
      <el-table-column prop="matgr" label="转换矩阵的物料组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('matgr')" />
      <el-table-column prop="vspvb" label="物料主记录中建议的供应区域" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vspvb')" />
      <el-table-column prop="dplfs" label="公平分享规则" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dplfs')" />
      <el-table-column prop="dplpu" label="指示器:推式分配" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dplpu')" />
      <el-table-column prop="dplho" label="发布的天数界限" align="center" v-if="columns.showColumn('dplho')" />
      <el-table-column prop="minls" label="匹配供应量的最小批尺寸" align="center" v-if="columns.showColumn('minls')" />
      <el-table-column prop="maxls" label="匹配供应需求的最大批尺寸" align="center" v-if="columns.showColumn('maxls')" />
      <el-table-column prop="fixls" label="匹配供应需求的固定批大小" align="center" v-if="columns.showColumn('fixls')" />
      <el-table-column prop="ltinc" label="匹配供应需求增加批尺寸" align="center" v-if="columns.showColumn('ltinc')" />
      <el-table-column prop="compl" label="该字段不再使用" align="center" v-if="columns.showColumn('compl')" />
      <el-table-column prop="convt" label="用于生产指标的转换类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('convt')" />
      <el-table-column prop="shpro" label="安全时间的期间参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('shpro')" />
      <el-table-column prop="ahdis" label="相关需求的 MRP  关联" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ahdis')" />
      <el-table-column prop="diber" label="指示：MRP  范围存在" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('diber')" />
      <el-table-column prop="kzpsp" label="跨项目物料指示符" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzpsp')" />
      <el-table-column prop="ocmpf" label="订单更改管理的总体参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ocmpf')" />
      <el-table-column prop="apokz" label="指示：物料是否与 APO 相关" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('apokz')" />
      <el-table-column prop="mcrue" label="最后的MARD 期间之前，MARDH 记录已经存在" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mcrue')" />
      <el-table-column prop="lfmon" label="当前期间 (记帐期间)" align="center" v-if="columns.showColumn('lfmon')" />
      <el-table-column prop="lfgja" label="当前期间的会计年度" align="center" v-if="columns.showColumn('lfgja')" />
      <el-table-column prop="eislo" label="最小安全库存" align="center" v-if="columns.showColumn('eislo')" />
      <el-table-column prop="ncost" label="无成本核算" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ncost')" />
      <el-table-column prop="rotationdate" label="库存入库和库存出库的策略" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rotationdate')" />
      <el-table-column prop="uchkz" label="初始批次管理的标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('uchkz')" />
      <el-table-column prop="ucmat" label="初始批量的参考物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ucmat')" />
      <el-table-column prop="bwesb" label="评估的收货锁定库存" align="center" v-if="columns.showColumn('bwesb')" />
      <el-table-column prop="sgtcovs" label="分段策略" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtcovs')" />
      <el-table-column prop="sgtstatc" label="分段状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtstatc')" />
      <el-table-column prop="sgtscope" label="分段策略范围" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtscope')" />
      <el-table-column prop="sgtmrpsi" label="根据交货日期或段排序库存" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtmrpsi')" />
      <el-table-column prop="sgtprcm" label="消耗优先级" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtprcm')" />
      <el-table-column prop="sgtchint" label="离散批次编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtchint')" />
      <el-table-column prop="sgtstkprt" label="库存保护标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtstkprt')" />
      <el-table-column prop="fshmgarunreq" label="订单分配运行" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshmgarunreq')" />
      <el-table-column prop="fshseaim" label="标识：在库存管理中激活季节" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshseaim')" />
      <el-table-column prop="vsorpkgrp" label="物料的包装组 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorpkgrp')" />
      <el-table-column prop="vsorlanenum" label="自动提货区域内的行 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorlanenum')" />
      <el-table-column prop="vsorpalvend" label="供应商包装物料的物料编号 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorpalvend')" />
      <el-table-column prop="vsorforkdir" label="仅纵向提取包装物料 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorforkdir')" />
      <el-table-column prop="iuidrelevant" label="项目唯一标识相关" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('iuidrelevant')" />
      <el-table-column prop="iuidtype" label="唯一项目标识的结构类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('iuidtype')" />
      <el-table-column prop="uidiea" label="UII 的外部分配" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('uidiea')" />
      <el-table-column prop="consprocg" label="寄售控制" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('consprocg')" />
      <el-table-column prop="giprtime" label="按天数发货处理时间" align="center" v-if="columns.showColumn('giprtime')" />
      <el-table-column prop="multipleekgrp" label="采购交叉的采购组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('multipleekgrp')" />
      <el-table-column prop="refschema" label="参考确定方案" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('refschema')" />
      <el-table-column prop="mintroc" label="覆盖的最小目标范围" align="center" v-if="columns.showColumn('mintroc')" />
      <el-table-column prop="maxtroc" label="覆盖的最大目标范围" align="center" v-if="columns.showColumn('maxtroc')" />
      <el-table-column prop="targetstock" label="目标库存" align="center" v-if="columns.showColumn('targetstock')" />
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
              v-hasPermi="['mm:marc:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['mm:marc:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改工厂物料对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="ID主键" prop="sfid">
                  <el-input v-model.number="form.sfid" :placeholder="$t('btn.enterPrefix')+'ID主键'+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="集团" prop="mandt">
                  <el-input v-model="form.mandt" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料号" prop="matnr">
                  <el-input v-model="form.matnr" :placeholder="$t('btn.enterPrefix')+'物料号'+$t('btn.enterSuffix')" />
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
                <el-form-item label="维护状态" prop="pstat">
                  <el-input v-model="form.pstat" :placeholder="$t('btn.enterPrefix')+'维护状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂级标记" prop="lvorm">
                  <el-select filterable clearable v-model="form.lvorm"
                    :placeholder="$t('btn.selectPrefix')+'工厂级标记'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_is_deleted" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="评估类别" prop="bwtty">
                  <el-input v-model="form.bwtty" :placeholder="$t('btn.enterPrefix')+'评估类别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批量管理" prop="xchar">
                  <el-input v-model="form.xchar" :placeholder="$t('btn.enterPrefix')+'批量管理'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂特定状态" prop="mmsta">
                  <el-input v-model="form.mmsta" :placeholder="$t('btn.enterPrefix')+'工厂特定状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂特定起始日期" prop="mmstd">
                  <el-date-picker v-model="form.mmstd" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="ABC标识" prop="maabc">
                  <el-input v-model="form.maabc" :placeholder="$t('btn.enterPrefix')+'ABC标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标志：关键部件" prop="kzkri">
                  <el-input v-model="form.kzkri" :placeholder="$t('btn.enterPrefix')+'标志：关键部件'+$t('btn.enterSuffix')" />
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
                <el-form-item label="发货单位" prop="ausme">
                  <el-input v-model="form.ausme" :placeholder="$t('btn.enterPrefix')+'发货单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料: MRP 参数文件" prop="dispr">
                  <el-input v-model="form.dispr"
                    :placeholder="$t('btn.enterPrefix')+'物料: MRP 参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料需求计划类型" prop="dismm">
                  <el-input v-model="form.dismm"
                    :placeholder="$t('btn.enterPrefix')+'物料需求计划类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="MRP 控制者（物料计划人）" prop="dispo">
                  <el-input v-model="form.dispo"
                    :placeholder="$t('btn.enterPrefix')+'MRP 控制者（物料计划人）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: MRP控制者是买方(未激活的)" prop="kzdie">
                  <el-input v-model="form.kzdie"
                    :placeholder="$t('btn.enterPrefix')+'标识: MRP控制者是买方(未激活的)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划的天数内交货" prop="plifz">
                  <el-input-number v-model.number="form.plifz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'计划的天数内交货'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="以天计的收货处理时间" prop="webaz">
                  <el-input-number v-model.number="form.webaz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'以天计的收货处理时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="期间标识" prop="perkz">
                  <el-input v-model="form.perkz" :placeholder="$t('btn.enterPrefix')+'期间标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="装配报废百分比" prop="ausss">
                  <el-input-number v-model.number="form.ausss" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'装配报废百分比'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批量 (物料计划)" prop="disls">
                  <el-input v-model="form.disls"
                    :placeholder="$t('btn.enterPrefix')+'批量 (物料计划)'+$t('btn.enterSuffix')" />
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
                <el-form-item label="再订货点" prop="minbe">
                  <el-input-number v-model.number="form.minbe" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'再订货点'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="安全库存" prop="eisbe">
                  <el-input-number v-model.number="form.eisbe" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'安全库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最小批量" prop="bstmi">
                  <el-input-number v-model.number="form.bstmi" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最小批量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最大批量大小" prop="bstma">
                  <el-input-number v-model.number="form.bstma" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最大批量大小'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="固定批量大小" prop="bstfe">
                  <el-input-number v-model.number="form.bstfe" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'固定批量大小'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购订单数量的舍入值" prop="bstrf">
                  <el-input-number v-model.number="form.bstrf" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'采购订单数量的舍入值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最大库存水平" prop="mabst">
                  <el-input-number v-model.number="form.mabst" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最大库存水平'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="订购成本" prop="losfx">
                  <el-input-number v-model.number="form.losfx" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'订购成本'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="对于独立和集中需求的相关需求标识" prop="sbdkz">
                  <el-input v-model="form.sbdkz"
                    :placeholder="$t('btn.enterPrefix')+'对于独立和集中需求的相关需求标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存成本标识" prop="lagpr">
                  <el-input v-model="form.lagpr" :placeholder="$t('btn.enterPrefix')+'库存成本标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="选择可替换物料单的方法" prop="altsl">
                  <el-input v-model="form.altsl"
                    :placeholder="$t('btn.enterPrefix')+'选择可替换物料单的方法'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="中止指示符" prop="kzaus">
                  <el-input v-model="form.kzaus" :placeholder="$t('btn.enterPrefix')+'中止指示符'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="中断日期" prop="ausdt">
                  <el-date-picker v-model="form.ausdt" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="后续物料" prop="nfmat">
                  <el-input v-model="form.nfmat" :placeholder="$t('btn.enterPrefix')+'后续物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="需求分组指示符" prop="kzbed">
                  <el-input v-model="form.kzbed" :placeholder="$t('btn.enterPrefix')+'需求分组指示符'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="综合MRP标识" prop="miskz">
                  <el-input v-model="form.miskz" :placeholder="$t('btn.enterPrefix')+'综合MRP标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="浮动的计划边际码" prop="fhori">
                  <el-input v-model="form.fhori"
                    :placeholder="$t('btn.enterPrefix')+'浮动的计划边际码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 计划订单的自动修正" prop="pfrei">
                  <el-input v-model="form.pfrei"
                    :placeholder="$t('btn.enterPrefix')+'标识: 计划订单的自动修正'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用于生产订单的批准标识" prop="ffrei">
                  <el-input v-model="form.ffrei"
                    :placeholder="$t('btn.enterPrefix')+'用于生产订单的批准标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：反冲" prop="rgekz">
                  <el-input v-model="form.rgekz" :placeholder="$t('btn.enterPrefix')+'标识：反冲'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产管理员" prop="fevor">
                  <el-input v-model="form.fevor" :placeholder="$t('btn.enterPrefix')+'生产管理员'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理时间" prop="bearz">
                  <el-input-number v-model.number="form.bearz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'处理时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="建立和拆卸时间" prop="ruezt">
                  <el-input-number v-model.number="form.ruezt" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'建立和拆卸时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工序间时间" prop="tranz">
                  <el-input-number v-model.number="form.tranz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'工序间时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基准数量" prop="basmg">
                  <el-input-number v-model.number="form.basmg" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'基准数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="厂内生产时间" prop="dzeit">
                  <el-input-number v-model.number="form.dzeit" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'厂内生产时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最大存储期间" prop="maxlz">
                  <el-input-number v-model.number="form.maxlz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最大存储期间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最大库存期间单位" prop="lzeih">
                  <el-input v-model="form.lzeih"
                    :placeholder="$t('btn.enterPrefix')+'最大库存期间单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 从生产区的库存提取" prop="kzpro">
                  <el-input v-model="form.kzpro"
                    :placeholder="$t('btn.enterPrefix')+'标识: 从生产区的库存提取'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 在初步计划中包括的物料" prop="gpmkz">
                  <el-input v-model="form.gpmkz"
                    :placeholder="$t('btn.enterPrefix')+'标识: 在初步计划中包括的物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="超量交货容差限制" prop="ueeto">
                  <el-input-number v-model.number="form.ueeto" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'超量交货容差限制'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：允许未限制的过量交货" prop="ueetk">
                  <el-input v-model="form.ueetk"
                    :placeholder="$t('btn.enterPrefix')+'标识：允许未限制的过量交货'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="不足交货容差限制" prop="uneto">
                  <el-input-number v-model.number="form.uneto" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'不足交货容差限制'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="总计补货提前时间(按工作日)" prop="wzeit">
                  <el-input-number v-model.number="form.wzeit" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'总计补货提前时间(按工作日)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="替换部件" prop="atpkz">
                  <el-input v-model="form.atpkz" :placeholder="$t('btn.enterPrefix')+'替换部件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用百分比表示的成本的附加因子" prop="vzusl">
                  <el-input-number v-model.number="form.vzusl" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'用百分比表示的成本的附加因子'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产状态" prop="herbl">
                  <el-input v-model="form.herbl" :placeholder="$t('btn.enterPrefix')+'生产状态'+$t('btn.enterSuffix')" />
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
                <el-form-item label="质量检查的样本(在%中)(取消激活)" prop="sproz">
                  <el-input-number v-model.number="form.sproz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'质量检查的样本(在%中)(取消激活)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="隔离期(未激活)" prop="quazt">
                  <el-input-number v-model.number="form.quazt" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'隔离期(未激活)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购中质量管理的控制码" prop="ssqss">
                  <el-input v-model="form.ssqss"
                    :placeholder="$t('btn.enterPrefix')+'采购中质量管理的控制码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="平均检查持续期间(未激活的的)" prop="mpdau">
                  <el-input-number v-model.number="form.mpdau" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'平均检查持续期间(未激活的的)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="检查计划的标识(未激活)" prop="kzppv">
                  <el-input v-model="form.kzppv"
                    :placeholder="$t('btn.enterPrefix')+'检查计划的标识(未激活)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="凭证需求标识" prop="kzdkz">
                  <el-input v-model="form.kzdkz" :placeholder="$t('btn.enterPrefix')+'凭证需求标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="活动性物质内容(未激活的)" prop="wstgh">
                  <el-input-number v-model.number="form.wstgh" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'活动性物质内容(未激活的)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="循环检查间隔" prop="prfrq">
                  <el-input-number v-model.number="form.prfrq" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'循环检查间隔'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="根据检验抽样检查的日期(取消激活)" prop="nkmpr">
                  <el-date-picker v-model="form.nkmpr" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="中转库存（工厂到工厂）" prop="umlmc">
                  <el-input-number v-model.number="form.umlmc" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'中转库存（工厂到工厂）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="装载组" prop="ladgr">
                  <el-input v-model="form.ladgr" :placeholder="$t('btn.enterPrefix')+'装载组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批次管理需求的标识" prop="xchpf">
                  <el-input v-model="form.xchpf"
                    :placeholder="$t('btn.enterPrefix')+'批次管理需求的标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="配额分配使用" prop="usequ">
                  <el-input v-model="form.usequ" :placeholder="$t('btn.enterPrefix')+'配额分配使用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="服务水平" prop="lgrad">
                  <el-input-number v-model.number="form.lgrad" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'服务水平'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分割标识" prop="auftl">
                  <el-input v-model="form.auftl" :placeholder="$t('btn.enterPrefix')+'分割标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划版本" prop="plvar">
                  <el-input v-model="form.plvar" :placeholder="$t('btn.enterPrefix')+'计划版本'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="对象类型" prop="otype">
                  <el-select filterable clearable v-model="form.otype"
                    :placeholder="$t('btn.selectPrefix')+'对象类型'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.otypeOptions" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="对象标识" prop="objid">
                  <el-input-number v-model.number="form.objid" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'对象标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可用性检查的检查组" prop="mtvfp">
                  <el-input v-model="form.mtvfp"
                    :placeholder="$t('btn.enterPrefix')+'可用性检查的检查组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="会计年度变式" prop="periv">
                  <el-input v-model="form.periv" :placeholder="$t('btn.enterPrefix')+'会计年度变式'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 考虑修正因子" prop="kzkfk">
                  <el-input v-model="form.kzkfk"
                    :placeholder="$t('btn.enterPrefix')+'标识: 考虑修正因子'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="装运建立时间" prop="vrvez">
                  <el-input-number v-model.number="form.vrvez" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'装运建立时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="在装运中有关能力计划的基准数量" prop="vbamg">
                  <el-input-number v-model.number="form.vbamg" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'在装运中有关能力计划的基准数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理时间: 装运" prop="vbeaz">
                  <el-input-number v-model.number="form.vbeaz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'处理时间: 装运'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="取消激活的" prop="lizyk">
                  <el-input v-model="form.lizyk" :placeholder="$t('btn.enterPrefix')+'取消激活的'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="货源" prop="bwscl">
                  <el-input v-model="form.bwscl" :placeholder="$t('btn.enterPrefix')+'货源'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 允许自动采购订单" prop="kautb">
                  <el-radio-group v-model="form.kautb">
                    <el-radio v-for="item in options.sys_normal_whether" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 源清单要求" prop="kordb">
                  <el-radio-group v-model="form.kordb">
                    <el-radio v-for="item in options.sys_normal_whether" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="外贸的商品代码和进口代码" prop="stawn">
                  <el-input v-model="form.stawn"
                    :placeholder="$t('btn.enterPrefix')+'外贸的商品代码和进口代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料原产地国家" prop="herkl">
                  <el-input v-model="form.herkl" :placeholder="$t('btn.enterPrefix')+'物料原产地国家'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料原产地（非特惠货源）" prop="herkr">
                  <el-input v-model="form.herkr"
                    :placeholder="$t('btn.enterPrefix')+'物料原产地（非特惠货源）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="商品代码的计量单位(外贸)" prop="expme">
                  <el-input v-model="form.expme"
                    :placeholder="$t('btn.enterPrefix')+'商品代码的计量单位(外贸)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="出口/进口物料组" prop="mtver">
                  <el-input v-model="form.mtver"
                    :placeholder="$t('btn.enterPrefix')+'出口/进口物料组'+$t('btn.enterSuffix')" />
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
                <el-form-item label="在途库存" prop="trame">
                  <el-input-number v-model.number="form.trame" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'在途库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="PPC 计划日历" prop="mrppp">
                  <el-input v-model="form.mrppp"
                    :placeholder="$t('btn.enterPrefix')+'PPC 计划日历'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 允许的重复制造" prop="sauft">
                  <el-input v-model="form.sauft"
                    :placeholder="$t('btn.enterPrefix')+'标识: 允许的重复制造'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划的时界" prop="fxhor">
                  <el-input-number v-model.number="form.fxhor" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'计划的时界'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="消耗模式" prop="vrmod">
                  <el-input v-model="form.vrmod" :placeholder="$t('btn.enterPrefix')+'消耗模式'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="消耗期间:逆向" prop="vint1">
                  <el-input-number v-model.number="form.vint1" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'消耗期间:逆向'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="消耗时期-向前" prop="vint2">
                  <el-input-number v-model.number="form.vint2" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'消耗时期-向前'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="版本标识符" prop="verkz">
                  <el-input v-model="form.verkz" :placeholder="$t('btn.enterPrefix')+'版本标识符'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可选的 BOM" prop="stlal">
                  <el-input v-model="form.stlal" :placeholder="$t('btn.enterPrefix')+'可选的 BOM'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="BOM 用途" prop="stlan">
                  <el-input v-model="form.stlan" :placeholder="$t('btn.enterPrefix')+'BOM 用途'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="任务清单组码" prop="plnnr">
                  <el-input v-model="form.plnnr" :placeholder="$t('btn.enterPrefix')+'任务清单组码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="组计数器" prop="aplal">
                  <el-input v-model="form.aplal" :placeholder="$t('btn.enterPrefix')+'组计数器'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批量产品成本核算" prop="losgr">
                  <el-input-number v-model.number="form.losgr" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'批量产品成本核算'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="成本核算的特殊采购类型" prop="sobsk">
                  <el-input v-model="form.sobsk"
                    :placeholder="$t('btn.enterPrefix')+'成本核算的特殊采购类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产单位" prop="frtme">
                  <el-input v-model="form.frtme" :placeholder="$t('btn.enterPrefix')+'生产单位'+$t('btn.enterSuffix')" />
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
                <el-form-item label="物料需求计划组" prop="disgr">
                  <el-input v-model="form.disgr" :placeholder="$t('btn.enterPrefix')+'物料需求计划组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="部件废品百分数" prop="kausf">
                  <el-input-number v-model.number="form.kausf" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'部件废品百分数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="证书类型" prop="qzgtp">
                  <el-input v-model="form.qzgtp" :placeholder="$t('btn.enterPrefix')+'证书类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料/工厂的检验设置存在" prop="qmatv">
                  <el-input v-model="form.qmatv"
                    :placeholder="$t('btn.enterPrefix')+'物料/工厂的检验设置存在'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)" prop="takzt">
                  <el-input-number v-model.number="form.takzt" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供货天数参数文件" prop="rwpro">
                  <el-input v-model="form.rwpro"
                    :placeholder="$t('btn.enterPrefix')+'供货天数参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="连接到SOP上的CO/PA局部字段名" prop="copam">
                  <el-input v-model="form.copam"
                    :placeholder="$t('btn.enterPrefix')+'连接到SOP上的CO/PA局部字段名'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="周期盘点的盘点标识" prop="abcin">
                  <el-input v-model="form.abcin"
                    :placeholder="$t('btn.enterPrefix')+'周期盘点的盘点标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="差异码" prop="awsls">
                  <el-input v-model="form.awsls" :placeholder="$t('btn.enterPrefix')+'差异码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序列号参数文件" prop="sernp">
                  <el-input v-model="form.sernp" :placeholder="$t('btn.enterPrefix')+'序列号参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="内部对象号" prop="cuobj">
                  <el-input-number v-model.number="form.cuobj" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'内部对象号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可配置的物料" prop="stdpd">
                  <el-input v-model="form.stdpd" :placeholder="$t('btn.enterPrefix')+'可配置的物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="重复生产参数文件" prop="sfepr">
                  <el-input v-model="form.sfepr"
                    :placeholder="$t('btn.enterPrefix')+'重复生产参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂中允许负库存" prop="xmcng">
                  <el-input v-model="form.xmcng"
                    :placeholder="$t('btn.enterPrefix')+'工厂中允许负库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="要求的供应商质量管理系统" prop="qssys">
                  <el-input v-model="form.qssys"
                    :placeholder="$t('btn.enterPrefix')+'要求的供应商质量管理系统'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划周期" prop="lfrhy">
                  <el-input v-model="form.lfrhy" :placeholder="$t('btn.enterPrefix')+'计划周期'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="舍入参数文件" prop="rdprf">
                  <el-input v-model="form.rdprf" :placeholder="$t('btn.enterPrefix')+'舍入参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="消耗的参考物料" prop="vrbmt">
                  <el-input v-model="form.vrbmt" :placeholder="$t('btn.enterPrefix')+'消耗的参考物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="消耗的参考工厂" prop="vrbwk">
                  <el-input v-model="form.vrbwk" :placeholder="$t('btn.enterPrefix')+'消耗的参考工厂'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="到消耗物料将被复制的日期" prop="vrbdt">
                  <el-date-picker v-model="form.vrbdt" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="消耗的参考物料的乘数" prop="vrbfk">
                  <el-input-number v-model.number="form.vrbfk" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'消耗的参考物料的乘数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自动重置预测模式" prop="autru">
                  <el-input v-model="form.autru"
                    :placeholder="$t('btn.enterPrefix')+'自动重置预测模式'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="进/出口中优惠指示符" prop="prefe">
                  <el-input v-model="form.prefe"
                    :placeholder="$t('btn.enterPrefix')+'进/出口中优惠指示符'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="免税证明：法律控制指示符" prop="prenc">
                  <el-input v-model="form.prenc"
                    :placeholder="$t('btn.enterPrefix')+'免税证明：法律控制指示符'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="法律控制的免税证书编号" prop="preno">
                  <el-input v-model="form.preno"
                    :placeholder="$t('btn.enterPrefix')+'法律控制的免税证书编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="免税证明：免税证书的发放日" prop="prend">
                  <el-date-picker v-model="form.prend" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：存在供应商申报" prop="prene">
                  <el-input v-model="form.prene"
                    :placeholder="$t('btn.enterPrefix')+'标识：存在供应商申报'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商申报的有效日期" prop="preng">
                  <el-date-picker v-model="form.preng" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示符：军用物资" prop="itark">
                  <el-input v-model="form.itark"
                    :placeholder="$t('btn.enterPrefix')+'指示符：军用物资'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="IS－R服务级别" prop="servg">
                  <el-input v-model="form.servg"
                    :placeholder="$t('btn.enterPrefix')+'IS－R服务级别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示符 : 物料是联产品" prop="kzkup">
                  <el-input v-model="form.kzkup"
                    :placeholder="$t('btn.enterPrefix')+'指示符 : 物料是联产品'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划策略组" prop="strgr">
                  <el-input v-model="form.strgr" :placeholder="$t('btn.enterPrefix')+'计划策略组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划中的可配置物料的内部对象号" prop="cuobv">
                  <el-input-number v-model.number="form.cuobv" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'计划中的可配置物料的内部对象号'+$t('btn.enterSuffix')" />
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
                <el-form-item label="标识：散装物料" prop="schgt">
                  <el-select filterable clearable v-model="form.schgt"
                    :placeholder="$t('btn.selectPrefix')+'标识：散装物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_normal_whether" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="周期标识被固定" prop="ccfix">
                  <el-input v-model="form.ccfix" :placeholder="$t('btn.enterPrefix')+'周期标识被固定'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存确定组" prop="eprio">
                  <el-input v-model="form.eprio" :placeholder="$t('btn.enterPrefix')+'库存确定组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="QM 中活动的物料授权组" prop="qmata">
                  <el-input v-model="form.qmata"
                    :placeholder="$t('btn.enterPrefix')+'QM 中活动的物料授权组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划独立需求的调整期间" prop="resvp">
                  <el-input-number v-model.number="form.resvp" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'计划独立需求的调整期间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="任务清单类型" prop="plnty">
                  <el-input v-model="form.plnty" :placeholder="$t('btn.enterPrefix')+'任务清单类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计量组单位 (石油,天然气,...)" prop="uomgr">
                  <el-input v-model="form.uomgr"
                    :placeholder="$t('btn.enterPrefix')+'计量组单位 (石油,天然气,...)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="转换组 (石油,天然气,..)" prop="umrsl">
                  <el-input v-model="form.umrsl"
                    :placeholder="$t('btn.enterPrefix')+'转换组 (石油,天然气,..)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="空气浮力因子" prop="abfac">
                  <el-input-number v-model.number="form.abfac" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'空气浮力因子'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产计划参数文件" prop="sfcpf">
                  <el-input v-model="form.sfcpf"
                    :placeholder="$t('btn.enterPrefix')+'生产计划参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="安全时间标识（含或不含安全时间）" prop="shflg">
                  <el-input v-model="form.shflg"
                    :placeholder="$t('btn.enterPrefix')+'安全时间标识（含或不含安全时间）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="安全时间（按工作日计算）" prop="shzet">
                  <el-input-number v-model.number="form.shzet" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'安全时间（按工作日计算）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="活动控制：计划订单处理" prop="mdach">
                  <el-input v-model="form.mdach"
                    :placeholder="$t('btn.enterPrefix')+'活动控制：计划订单处理'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="在生产/处理订单中批量输入的确定" prop="kzech">
                  <el-input v-model="form.kzech"
                    :placeholder="$t('btn.enterPrefix')+'在生产/处理订单中批量输入的确定'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计量单位组" prop="megru">
                  <el-input v-model="form.megru" :placeholder="$t('btn.enterPrefix')+'计量单位组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料运输组" prop="mfrgr">
                  <el-input v-model="form.mfrgr" :placeholder="$t('btn.enterPrefix')+'物料运输组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="VO 物料的库存转移销售值（工厂到工厂）" prop="vkumc">
                  <el-input-number v-model.number="form.vkumc" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'VO 物料的库存转移销售值（工厂到工厂）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仅记值物料的销售价格计的运输值" prop="vktrw">
                  <el-input-number v-model.number="form.vktrw" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'仅记值物料的销售价格计的运输值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示符: 平滑促销消耗" prop="kzagl">
                  <el-input v-model="form.kzagl"
                    :placeholder="$t('btn.enterPrefix')+'指示符: 平滑促销消耗'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="将进行成本核算的生产版本" prop="fvidk">
                  <el-input v-model="form.fvidk"
                    :placeholder="$t('btn.enterPrefix')+'将进行成本核算的生产版本'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="固定价格联产品" prop="fxpru">
                  <el-input v-model="form.fxpru" :placeholder="$t('btn.enterPrefix')+'固定价格联产品'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用于计算工作负荷的后勤处理组" prop="loggr">
                  <el-input v-model="form.loggr"
                    :placeholder="$t('btn.enterPrefix')+'用于计算工作负荷的后勤处理组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂物料分销参数文件" prop="fprfm">
                  <el-input v-model="form.fprfm"
                    :placeholder="$t('btn.enterPrefix')+'工厂物料分销参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="有约束的虚拟库存" prop="glgmg">
                  <el-input-number v-model.number="form.glgmg" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'有约束的虚拟库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="连接空缺库存的销售价" prop="vkglg">
                  <el-input-number v-model.number="form.vkglg" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'连接空缺库存的销售价'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料: CFOP类别" prop="indus">
                  <el-input v-model="form.indus"
                    :placeholder="$t('btn.enterPrefix')+'物料: CFOP类别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="CAP：CAP 产品清单编号" prop="mownr">
                  <el-input v-model="form.mownr"
                    :placeholder="$t('btn.enterPrefix')+'CAP：CAP 产品清单编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="共同农业市场政策：CAP 产品组－外贸" prop="mogru">
                  <el-input v-model="form.mogru"
                    :placeholder="$t('btn.enterPrefix')+'共同农业市场政策：CAP 产品组－外贸'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="外贸药品 CAS 号码" prop="casnr">
                  <el-input v-model="form.casnr"
                    :placeholder="$t('btn.enterPrefix')+'外贸药品 CAS 号码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产统计：外贸 PRODCOM 号码" prop="gpnum">
                  <el-input v-model="form.gpnum"
                    :placeholder="$t('btn.enterPrefix')+'生产统计：外贸 PRODCOM 号码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="对外贸易消费税控制代码" prop="steuc">
                  <el-input v-model="form.steuc"
                    :placeholder="$t('btn.enterPrefix')+'对外贸易消费税控制代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 与 JIT 交货计划相关的物料" prop="fabkz">
                  <el-input v-model="form.fabkz"
                    :placeholder="$t('btn.enterPrefix')+'标识: 与 JIT 交货计划相关的物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="转换矩阵的物料组" prop="matgr">
                  <el-input v-model="form.matgr"
                    :placeholder="$t('btn.enterPrefix')+'转换矩阵的物料组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料主记录中建议的供应区域" prop="vspvb">
                  <el-input v-model="form.vspvb"
                    :placeholder="$t('btn.enterPrefix')+'物料主记录中建议的供应区域'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="公平分享规则" prop="dplfs">
                  <el-input v-model="form.dplfs" :placeholder="$t('btn.enterPrefix')+'公平分享规则'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示器:推式分配" prop="dplpu">
                  <el-input v-model="form.dplpu"
                    :placeholder="$t('btn.enterPrefix')+'指示器:推式分配'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="发布的天数界限" prop="dplho">
                  <el-input-number v-model.number="form.dplho" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'发布的天数界限'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="匹配供应量的最小批尺寸" prop="minls">
                  <el-input-number v-model.number="form.minls" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'匹配供应量的最小批尺寸'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="匹配供应需求的最大批尺寸" prop="maxls">
                  <el-input-number v-model.number="form.maxls" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'匹配供应需求的最大批尺寸'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="匹配供应需求的固定批大小" prop="fixls">
                  <el-input-number v-model.number="form.fixls" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'匹配供应需求的固定批大小'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="匹配供应需求增加批尺寸" prop="ltinc">
                  <el-input-number v-model.number="form.ltinc" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'匹配供应需求增加批尺寸'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="该字段不再使用" prop="compl">
                  <el-input-number v-model.number="form.compl" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'该字段不再使用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用于生产指标的转换类型" prop="convt">
                  <el-input v-model="form.convt"
                    :placeholder="$t('btn.enterPrefix')+'用于生产指标的转换类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="安全时间的期间参数文件" prop="shpro">
                  <el-input v-model="form.shpro"
                    :placeholder="$t('btn.enterPrefix')+'安全时间的期间参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="相关需求的 MRP  关联" prop="ahdis">
                  <el-input v-model="form.ahdis"
                    :placeholder="$t('btn.enterPrefix')+'相关需求的 MRP  关联'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示：MRP  范围存在" prop="diber">
                  <el-input v-model="form.diber"
                    :placeholder="$t('btn.enterPrefix')+'指示：MRP  范围存在'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="跨项目物料指示符" prop="kzpsp">
                  <el-input v-model="form.kzpsp"
                    :placeholder="$t('btn.enterPrefix')+'跨项目物料指示符'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="订单更改管理的总体参数文件" prop="ocmpf">
                  <el-input v-model="form.ocmpf"
                    :placeholder="$t('btn.enterPrefix')+'订单更改管理的总体参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示：物料是否与 APO 相关" prop="apokz">
                  <el-input v-model="form.apokz"
                    :placeholder="$t('btn.enterPrefix')+'指示：物料是否与 APO 相关'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最后的MARD 期间之前，MARDH 记录已经存在" prop="mcrue">
                  <el-input v-model="form.mcrue"
                    :placeholder="$t('btn.enterPrefix')+'最后的MARD 期间之前，MARDH 记录已经存在'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="当前期间 (记帐期间)" prop="lfmon">
                  <el-input-number v-model.number="form.lfmon" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'当前期间 (记帐期间)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="当前期间的会计年度" prop="lfgja">
                  <el-input-number v-model.number="form.lfgja" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'当前期间的会计年度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最小安全库存" prop="eislo">
                  <el-input-number v-model.number="form.eislo" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最小安全库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="无成本核算" prop="ncost">
                  <el-input v-model="form.ncost" :placeholder="$t('btn.enterPrefix')+'无成本核算'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存入库和库存出库的策略" prop="rotationdate">
                  <el-input v-model="form.rotationdate"
                    :placeholder="$t('btn.enterPrefix')+'库存入库和库存出库的策略'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="初始批次管理的标识" prop="uchkz">
                  <el-input v-model="form.uchkz"
                    :placeholder="$t('btn.enterPrefix')+'初始批次管理的标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="初始批量的参考物料" prop="ucmat">
                  <el-input v-model="form.ucmat"
                    :placeholder="$t('btn.enterPrefix')+'初始批量的参考物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评估的收货锁定库存" prop="bwesb">
                  <el-input-number v-model.number="form.bwesb" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'评估的收货锁定库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段策略" prop="sgtcovs">
                  <el-input v-model="form.sgtcovs" :placeholder="$t('btn.enterPrefix')+'分段策略'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段状态" prop="sgtstatc">
                  <el-input v-model="form.sgtstatc" :placeholder="$t('btn.enterPrefix')+'分段状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段策略范围" prop="sgtscope">
                  <el-input v-model="form.sgtscope"
                    :placeholder="$t('btn.enterPrefix')+'分段策略范围'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="根据交货日期或段排序库存" prop="sgtmrpsi">
                  <el-input v-model="form.sgtmrpsi"
                    :placeholder="$t('btn.enterPrefix')+'根据交货日期或段排序库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="消耗优先级" prop="sgtprcm">
                  <el-input v-model="form.sgtprcm" :placeholder="$t('btn.enterPrefix')+'消耗优先级'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="离散批次编号" prop="sgtchint">
                  <el-input v-model="form.sgtchint"
                    :placeholder="$t('btn.enterPrefix')+'离散批次编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存保护标识" prop="sgtstkprt">
                  <el-input v-model="form.sgtstkprt"
                    :placeholder="$t('btn.enterPrefix')+'库存保护标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="订单分配运行" prop="fshmgarunreq">
                  <el-input v-model="form.fshmgarunreq"
                    :placeholder="$t('btn.enterPrefix')+'订单分配运行'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：在库存管理中激活季节" prop="fshseaim">
                  <el-input v-model="form.fshseaim"
                    :placeholder="$t('btn.enterPrefix')+'标识：在库存管理中激活季节'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料的包装组 (VSO)" prop="vsorpkgrp">
                  <el-input v-model="form.vsorpkgrp"
                    :placeholder="$t('btn.enterPrefix')+'物料的包装组 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自动提货区域内的行 (VSO)" prop="vsorlanenum">
                  <el-input v-model="form.vsorlanenum"
                    :placeholder="$t('btn.enterPrefix')+'自动提货区域内的行 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商包装物料的物料编号 (VSO)" prop="vsorpalvend">
                  <el-input v-model="form.vsorpalvend"
                    :placeholder="$t('btn.enterPrefix')+'供应商包装物料的物料编号 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仅纵向提取包装物料 (VSO)" prop="vsorforkdir">
                  <el-input v-model="form.vsorforkdir"
                    :placeholder="$t('btn.enterPrefix')+'仅纵向提取包装物料 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="项目唯一标识相关" prop="iuidrelevant">
                  <el-input v-model="form.iuidrelevant"
                    :placeholder="$t('btn.enterPrefix')+'项目唯一标识相关'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="唯一项目标识的结构类型" prop="iuidtype">
                  <el-input v-model="form.iuidtype"
                    :placeholder="$t('btn.enterPrefix')+'唯一项目标识的结构类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="UII 的外部分配" prop="uidiea">
                  <el-input v-model="form.uidiea"
                    :placeholder="$t('btn.enterPrefix')+'UII 的外部分配'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="寄售控制" prop="consprocg">
                  <el-input v-model="form.consprocg"
                    :placeholder="$t('btn.enterPrefix')+'寄售控制'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="按天数发货处理时间" prop="giprtime">
                  <el-input-number v-model.number="form.giprtime" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'按天数发货处理时间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购交叉的采购组" prop="multipleekgrp">
                  <el-input v-model="form.multipleekgrp"
                    :placeholder="$t('btn.enterPrefix')+'采购交叉的采购组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="参考确定方案" prop="refschema">
                  <el-input v-model="form.refschema"
                    :placeholder="$t('btn.enterPrefix')+'参考确定方案'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="覆盖的最小目标范围" prop="mintroc">
                  <el-input-number v-model.number="form.mintroc" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'覆盖的最小目标范围'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="覆盖的最大目标范围" prop="maxtroc">
                  <el-input-number v-model.number="form.maxtroc" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'覆盖的最大目标范围'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="目标库存" prop="targetstock">
                  <el-input-number v-model.number="form.targetstock" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'目标库存'+$t('btn.enterSuffix')" />
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

<script setup name="mmmarc">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listMmMarc,
    addMmMarc, delMmMarc,
    updateMmMarc, getMmMarc,
  }
    from '@/api/logistics/mmmarc.js'
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
    matnr: undefined,
    //是否查询（1是）
    werks: undefined,
    //是否查询（1是）
    lvorm: undefined,
    //是否查询（1是）
    ekgrp: undefined,
    //是否查询（1是）
    beskz: undefined,
    //是否查询（1是）
    sobsl: undefined,
    //是否查询（1是）
    insmk: undefined,
    //是否查询（1是）
    kautb: undefined,
    //是否查询（1是）
    kordb: undefined,
    //是否查询（1是）
    prctr: undefined,
    //是否查询（1是）
    lgpro: undefined,
    //是否查询（1是）
    lgfsb: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'sfid', label: 'ID主键' },
    { visible: true, prop: 'mandt', label: '集团' },
    { visible: true, prop: 'matnr', label: '物料号' },
    { visible: true, prop: 'werks', label: '工厂' },
    { visible: true, prop: 'pstat', label: '维护状态' },
    { visible: true, prop: 'lvorm', label: '工厂级标记' },
    { visible: true, prop: 'bwtty', label: '评估类别' },
    { visible: true, prop: 'xchar', label: '批量管理' },
    { visible: false, prop: 'mmsta', label: '工厂特定状态' },
    { visible: false, prop: 'mmstd', label: '工厂特定起始日期' },
    { visible: false, prop: 'maabc', label: 'ABC标识' },
    { visible: false, prop: 'kzkri', label: '标志：关键部件' },
    { visible: false, prop: 'ekgrp', label: '采购组' },
    { visible: false, prop: 'ausme', label: '发货单位' },
    { visible: false, prop: 'dispr', label: '物料: MRP 参数文件' },
    { visible: false, prop: 'dismm', label: '物料需求计划类型' },
    { visible: false, prop: 'dispo', label: 'MRP 控制者（物料计划人）' },
    { visible: false, prop: 'kzdie', label: '标识: MRP控制者是买方(未激活的)' },
    { visible: false, prop: 'plifz', label: '计划的天数内交货' },
    { visible: false, prop: 'webaz', label: '以天计的收货处理时间' },
    { visible: false, prop: 'perkz', label: '期间标识' },
    { visible: false, prop: 'ausss', label: '装配报废百分比' },
    { visible: false, prop: 'disls', label: '批量 (物料计划)' },
    { visible: false, prop: 'beskz', label: '采购类型' },
    { visible: false, prop: 'sobsl', label: '特殊采购类型' },
    { visible: false, prop: 'minbe', label: '再订货点' },
    { visible: false, prop: 'eisbe', label: '安全库存' },
    { visible: false, prop: 'bstmi', label: '最小批量' },
    { visible: false, prop: 'bstma', label: '最大批量大小' },
    { visible: false, prop: 'bstfe', label: '固定批量大小' },
    { visible: false, prop: 'bstrf', label: '采购订单数量的舍入值' },
    { visible: false, prop: 'mabst', label: '最大库存水平' },
    { visible: false, prop: 'losfx', label: '订购成本' },
    { visible: false, prop: 'sbdkz', label: '对于独立和集中需求的相关需求标识' },
    { visible: false, prop: 'lagpr', label: '库存成本标识' },
    { visible: false, prop: 'altsl', label: '选择可替换物料单的方法' },
    { visible: false, prop: 'kzaus', label: '中止指示符' },
    { visible: false, prop: 'ausdt', label: '中断日期' },
    { visible: false, prop: 'nfmat', label: '后续物料' },
    { visible: false, prop: 'kzbed', label: '需求分组指示符' },
    { visible: false, prop: 'miskz', label: '综合MRP标识' },
    { visible: false, prop: 'fhori', label: '浮动的计划边际码' },
    { visible: false, prop: 'pfrei', label: '标识: 计划订单的自动修正' },
    { visible: false, prop: 'ffrei', label: '用于生产订单的批准标识' },
    { visible: false, prop: 'rgekz', label: '标识：反冲' },
    { visible: false, prop: 'fevor', label: '生产管理员' },
    { visible: false, prop: 'bearz', label: '处理时间' },
    { visible: false, prop: 'ruezt', label: '建立和拆卸时间' },
    { visible: false, prop: 'tranz', label: '工序间时间' },
    { visible: false, prop: 'basmg', label: '基准数量' },
    { visible: false, prop: 'dzeit', label: '厂内生产时间' },
    { visible: false, prop: 'maxlz', label: '最大存储期间' },
    { visible: false, prop: 'lzeih', label: '最大库存期间单位' },
    { visible: false, prop: 'kzpro', label: '标识: 从生产区的库存提取' },
    { visible: false, prop: 'gpmkz', label: '标识: 在初步计划中包括的物料' },
    { visible: false, prop: 'ueeto', label: '超量交货容差限制' },
    { visible: false, prop: 'ueetk', label: '标识：允许未限制的过量交货' },
    { visible: false, prop: 'uneto', label: '不足交货容差限制' },
    { visible: false, prop: 'wzeit', label: '总计补货提前时间(按工作日)' },
    { visible: false, prop: 'atpkz', label: '替换部件' },
    { visible: false, prop: 'vzusl', label: '用百分比表示的成本的附加因子' },
    { visible: false, prop: 'herbl', label: '生产状态' },
    { visible: false, prop: 'insmk', label: '过帐到检验库存' },
    { visible: false, prop: 'sproz', label: '质量检查的样本(在%中)(取消激活)' },
    { visible: false, prop: 'quazt', label: '隔离期(未激活)' },
    { visible: false, prop: 'ssqss', label: '采购中质量管理的控制码' },
    { visible: false, prop: 'mpdau', label: '平均检查持续期间(未激活的的)' },
    { visible: false, prop: 'kzppv', label: '检查计划的标识(未激活)' },
    { visible: false, prop: 'kzdkz', label: '凭证需求标识' },
    { visible: false, prop: 'wstgh', label: '活动性物质内容(未激活的)' },
    { visible: false, prop: 'prfrq', label: '循环检查间隔' },
    { visible: false, prop: 'nkmpr', label: '根据检验抽样检查的日期(取消激活)' },
    { visible: false, prop: 'umlmc', label: '中转库存（工厂到工厂）' },
    { visible: false, prop: 'ladgr', label: '装载组' },
    { visible: false, prop: 'xchpf', label: '批次管理需求的标识' },
    { visible: false, prop: 'usequ', label: '配额分配使用' },
    { visible: false, prop: 'lgrad', label: '服务水平' },
    { visible: false, prop: 'auftl', label: '分割标识' },
    { visible: false, prop: 'plvar', label: '计划版本' },
    { visible: false, prop: 'otype', label: '对象类型' },
    { visible: false, prop: 'objid', label: '对象标识' },
    { visible: false, prop: 'mtvfp', label: '可用性检查的检查组' },
    { visible: false, prop: 'periv', label: '会计年度变式' },
    { visible: false, prop: 'kzkfk', label: '标识: 考虑修正因子' },
    { visible: false, prop: 'vrvez', label: '装运建立时间' },
    { visible: false, prop: 'vbamg', label: '在装运中有关能力计划的基准数量' },
    { visible: false, prop: 'vbeaz', label: '处理时间: 装运' },
    { visible: false, prop: 'lizyk', label: '取消激活的' },
    { visible: false, prop: 'bwscl', label: '货源' },
    { visible: false, prop: 'kautb', label: '标识: 允许自动采购订单' },
    { visible: false, prop: 'kordb', label: '标识: 源清单要求' },
    { visible: false, prop: 'stawn', label: '外贸的商品代码和进口代码' },
    { visible: false, prop: 'herkl', label: '物料原产地国家' },
    { visible: false, prop: 'herkr', label: '物料原产地（非特惠货源）' },
    { visible: false, prop: 'expme', label: '商品代码的计量单位(外贸)' },
    { visible: false, prop: 'mtver', label: '出口/进口物料组' },
    { visible: false, prop: 'prctr', label: '利润中心' },
    { visible: false, prop: 'trame', label: '在途库存' },
    { visible: false, prop: 'mrppp', label: 'PPC 计划日历' },
    { visible: false, prop: 'sauft', label: '标识: 允许的重复制造' },
    { visible: false, prop: 'fxhor', label: '计划的时界' },
    { visible: false, prop: 'vrmod', label: '消耗模式' },
    { visible: false, prop: 'vint1', label: '消耗期间:逆向' },
    { visible: false, prop: 'vint2', label: '消耗时期-向前' },
    { visible: false, prop: 'verkz', label: '版本标识符' },
    { visible: false, prop: 'stlal', label: '可选的 BOM' },
    { visible: false, prop: 'stlan', label: 'BOM 用途' },
    { visible: false, prop: 'plnnr', label: '任务清单组码' },
    { visible: false, prop: 'aplal', label: '组计数器' },
    { visible: false, prop: 'losgr', label: '批量产品成本核算' },
    { visible: false, prop: 'sobsk', label: '成本核算的特殊采购类型' },
    { visible: false, prop: 'frtme', label: '生产单位' },
    { visible: false, prop: 'lgpro', label: '发货库存地点' },
    { visible: false, prop: 'disgr', label: '物料需求计划组' },
    { visible: false, prop: 'kausf', label: '部件废品百分数' },
    { visible: false, prop: 'qzgtp', label: '证书类型' },
    { visible: false, prop: 'qmatv', label: '物料/工厂的检验设置存在' },
    { visible: false, prop: 'takzt', label: '间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)' },
    { visible: false, prop: 'rwpro', label: '供货天数参数文件' },
    { visible: false, prop: 'copam', label: '连接到SOP上的CO/PA局部字段名' },
    { visible: false, prop: 'abcin', label: '周期盘点的盘点标识' },
    { visible: false, prop: 'awsls', label: '差异码' },
    { visible: false, prop: 'sernp', label: '序列号参数文件' },
    { visible: false, prop: 'cuobj', label: '内部对象号' },
    { visible: false, prop: 'stdpd', label: '可配置的物料' },
    { visible: false, prop: 'sfepr', label: '重复生产参数文件' },
    { visible: false, prop: 'xmcng', label: '工厂中允许负库存' },
    { visible: false, prop: 'qssys', label: '要求的供应商质量管理系统' },
    { visible: false, prop: 'lfrhy', label: '计划周期' },
    { visible: false, prop: 'rdprf', label: '舍入参数文件' },
    { visible: false, prop: 'vrbmt', label: '消耗的参考物料' },
    { visible: false, prop: 'vrbwk', label: '消耗的参考工厂' },
    { visible: false, prop: 'vrbdt', label: '到消耗物料将被复制的日期' },
    { visible: false, prop: 'vrbfk', label: '消耗的参考物料的乘数' },
    { visible: false, prop: 'autru', label: '自动重置预测模式' },
    { visible: false, prop: 'prefe', label: '进/出口中优惠指示符' },
    { visible: false, prop: 'prenc', label: '免税证明：法律控制指示符' },
    { visible: false, prop: 'preno', label: '法律控制的免税证书编号' },
    { visible: false, prop: 'prend', label: '免税证明：免税证书的发放日' },
    { visible: false, prop: 'prene', label: '标识：存在供应商申报' },
    { visible: false, prop: 'preng', label: '供应商申报的有效日期' },
    { visible: false, prop: 'itark', label: '指示符：军用物资' },
    { visible: false, prop: 'servg', label: 'IS－R服务级别' },
    { visible: false, prop: 'kzkup', label: '指示符 : 物料是联产品' },
    { visible: false, prop: 'strgr', label: '计划策略组' },
    { visible: false, prop: 'cuobv', label: '计划中的可配置物料的内部对象号' },
    { visible: false, prop: 'lgfsb', label: '外部采购的缺省仓储位置' },
    { visible: false, prop: 'schgt', label: '标识：散装物料' },
    { visible: false, prop: 'ccfix', label: '周期标识被固定' },
    { visible: false, prop: 'eprio', label: '库存确定组' },
    { visible: false, prop: 'qmata', label: 'QM 中活动的物料授权组' },
    { visible: false, prop: 'resvp', label: '计划独立需求的调整期间' },
    { visible: false, prop: 'plnty', label: '任务清单类型' },
    { visible: false, prop: 'uomgr', label: '计量组单位 (石油,天然气,...)' },
    { visible: false, prop: 'umrsl', label: '转换组 (石油,天然气,..)' },
    { visible: false, prop: 'abfac', label: '空气浮力因子' },
    { visible: false, prop: 'sfcpf', label: '生产计划参数文件' },
    { visible: false, prop: 'shflg', label: '安全时间标识（含或不含安全时间）' },
    { visible: false, prop: 'shzet', label: '安全时间（按工作日计算）' },
    { visible: false, prop: 'mdach', label: '活动控制：计划订单处理' },
    { visible: false, prop: 'kzech', label: '在生产/处理订单中批量输入的确定' },
    { visible: false, prop: 'megru', label: '计量单位组' },
    { visible: false, prop: 'mfrgr', label: '物料运输组' },
    { visible: false, prop: 'vkumc', label: 'VO 物料的库存转移销售值（工厂到工厂）' },
    { visible: false, prop: 'vktrw', label: '仅记值物料的销售价格计的运输值' },
    { visible: false, prop: 'kzagl', label: '指示符: 平滑促销消耗' },
    { visible: false, prop: 'fvidk', label: '将进行成本核算的生产版本' },
    { visible: false, prop: 'fxpru', label: '固定价格联产品' },
    { visible: false, prop: 'loggr', label: '用于计算工作负荷的后勤处理组' },
    { visible: false, prop: 'fprfm', label: '工厂物料分销参数文件' },
    { visible: false, prop: 'glgmg', label: '有约束的虚拟库存' },
    { visible: false, prop: 'vkglg', label: '连接空缺库存的销售价' },
    { visible: false, prop: 'indus', label: '物料: CFOP类别' },
    { visible: false, prop: 'mownr', label: 'CAP：CAP 产品清单编号' },
    { visible: false, prop: 'mogru', label: '共同农业市场政策：CAP 产品组－外贸' },
    { visible: false, prop: 'casnr', label: '外贸药品 CAS 号码' },
    { visible: false, prop: 'gpnum', label: '生产统计：外贸 PRODCOM 号码' },
    { visible: false, prop: 'steuc', label: '对外贸易消费税控制代码' },
    { visible: false, prop: 'fabkz', label: '标识: 与 JIT 交货计划相关的物料' },
    { visible: false, prop: 'matgr', label: '转换矩阵的物料组' },
    { visible: false, prop: 'vspvb', label: '物料主记录中建议的供应区域' },
    { visible: false, prop: 'dplfs', label: '公平分享规则' },
    { visible: false, prop: 'dplpu', label: '指示器:推式分配' },
    { visible: false, prop: 'dplho', label: '发布的天数界限' },
    { visible: false, prop: 'minls', label: '匹配供应量的最小批尺寸' },
    { visible: false, prop: 'maxls', label: '匹配供应需求的最大批尺寸' },
    { visible: false, prop: 'fixls', label: '匹配供应需求的固定批大小' },
    { visible: false, prop: 'ltinc', label: '匹配供应需求增加批尺寸' },
    { visible: false, prop: 'compl', label: '该字段不再使用' },
    { visible: false, prop: 'convt', label: '用于生产指标的转换类型' },
    { visible: false, prop: 'shpro', label: '安全时间的期间参数文件' },
    { visible: false, prop: 'ahdis', label: '相关需求的 MRP  关联' },
    { visible: false, prop: 'diber', label: '指示：MRP  范围存在' },
    { visible: false, prop: 'kzpsp', label: '跨项目物料指示符' },
    { visible: false, prop: 'ocmpf', label: '订单更改管理的总体参数文件' },
    { visible: false, prop: 'apokz', label: '指示：物料是否与 APO 相关' },
    { visible: false, prop: 'mcrue', label: '最后的MARD 期间之前，MARDH 记录已经存在' },
    { visible: false, prop: 'lfmon', label: '当前期间 (记帐期间)' },
    { visible: false, prop: 'lfgja', label: '当前期间的会计年度' },
    { visible: false, prop: 'eislo', label: '最小安全库存' },
    { visible: false, prop: 'ncost', label: '无成本核算' },
    { visible: false, prop: 'rotationdate', label: '库存入库和库存出库的策略' },
    { visible: false, prop: 'uchkz', label: '初始批次管理的标识' },
    { visible: false, prop: 'ucmat', label: '初始批量的参考物料' },
    { visible: false, prop: 'bwesb', label: '评估的收货锁定库存' },
    { visible: false, prop: 'sgtcovs', label: '分段策略' },
    { visible: false, prop: 'sgtstatc', label: '分段状态' },
    { visible: false, prop: 'sgtscope', label: '分段策略范围' },
    { visible: false, prop: 'sgtmrpsi', label: '根据交货日期或段排序库存' },
    { visible: false, prop: 'sgtprcm', label: '消耗优先级' },
    { visible: false, prop: 'sgtchint', label: '离散批次编号' },
    { visible: false, prop: 'sgtstkprt', label: '库存保护标识' },
    { visible: false, prop: 'fshmgarunreq', label: '订单分配运行' },
    { visible: false, prop: 'fshseaim', label: '标识：在库存管理中激活季节' },
    { visible: false, prop: 'vsorpkgrp', label: '物料的包装组 (VSO)' },
    { visible: false, prop: 'vsorlanenum', label: '自动提货区域内的行 (VSO)' },
    { visible: false, prop: 'vsorpalvend', label: '供应商包装物料的物料编号 (VSO)' },
    { visible: false, prop: 'vsorforkdir', label: '仅纵向提取包装物料 (VSO)' },
    { visible: false, prop: 'iuidrelevant', label: '项目唯一标识相关' },
    { visible: false, prop: 'iuidtype', label: '唯一项目标识的结构类型' },
    { visible: false, prop: 'uidiea', label: 'UII 的外部分配' },
    { visible: false, prop: 'consprocg', label: '寄售控制' },
    { visible: false, prop: 'giprtime', label: '按天数发货处理时间' },
    { visible: false, prop: 'multipleekgrp', label: '采购交叉的采购组' },
    { visible: false, prop: 'refschema', label: '参考确定方案' },
    { visible: false, prop: 'mintroc', label: '覆盖的最小目标范围' },
    { visible: false, prop: 'maxtroc', label: '覆盖的最大目标范围' },
    { visible: false, prop: 'targetstock', label: '目标库存' },
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
    { dictType: "sys_is_deleted" },
    { dictType: "sys_pur_group" },
    { dictType: "sys_pur_type" },
    { dictType: "sys_pur_spec" },
    { dictType: "sys_normal_whether" },
    { dictType: "sql_prctr_list" },
    { dictType: "sys_sloc_list" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从工厂物料/mm_marc表记录数据
  function getList() {
    loading.value = true
    listMmMarc(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.sfid);
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
      sfid: [{ required: true, message: "ID主键" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      matnr: [{ required: true, message: "物料号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      werks: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      lvorm: [{ required: true, message: "工厂级标记" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      ekgrp: [{ required: true, message: "采购组" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      beskz: [{ required: true, message: "采购类型" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sobsl: [{ required: true, message: "特殊采购类型" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      insmk: [{ required: true, message: "过帐到检验库存" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      kautb: [{ required: true, message: "标识: 允许自动采购订单" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      kordb: [{ required: true, message: "标识: 源清单要求" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      prctr: [{ required: true, message: "利润中心" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      lgpro: [{ required: true, message: "发货库存地点" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      lgfsb: [{ required: true, message: "外部采购的缺省仓储位置" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      schgt: [{ required: true, message: "标识：散装物料" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      uDF51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      uDF56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 工厂级标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_deleted: [],
      // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_group: [],
      // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_type: [],
      // 特殊采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_spec: [],
      // 过帐到检验库存 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_normal_whether: [],
      // 对象类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      otypeOptions: [],
      // 利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_prctr_list: [],
      // 发货库存地点 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sloc_list: [],
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
      sfid: 0,
      mandt: null,
      matnr: null,
      werks: null,
      pstat: null,
      lvorm: null,
      bwtty: null,
      xchar: null,
      mmsta: null,
      mmstd: null,
      maabc: null,
      kzkri: null,
      ekgrp: null,
      ausme: null,
      dispr: null,
      dismm: null,
      dispo: null,
      kzdie: null,
      plifz: 0,
      webaz: 0,
      perkz: null,
      ausss: 0,
      disls: null,
      beskz: null,
      sobsl: null,
      minbe: 0,
      eisbe: 0,
      bstmi: 0,
      bstma: 0,
      bstfe: 0,
      bstrf: 0,
      mabst: 0,
      losfx: 0,
      sbdkz: null,
      lagpr: null,
      altsl: null,
      kzaus: null,
      ausdt: null,
      nfmat: null,
      kzbed: null,
      miskz: null,
      fhori: null,
      pfrei: null,
      ffrei: null,
      rgekz: null,
      fevor: null,
      bearz: 0,
      ruezt: 0,
      tranz: 0,
      basmg: 0,
      dzeit: 0,
      maxlz: 0,
      lzeih: null,
      kzpro: null,
      gpmkz: null,
      ueeto: 0,
      ueetk: null,
      uneto: 0,
      wzeit: 0,
      atpkz: null,
      vzusl: 0,
      herbl: null,
      insmk: null,
      sproz: 0,
      quazt: 0,
      ssqss: null,
      mpdau: 0,
      kzppv: null,
      kzdkz: null,
      wstgh: 0,
      prfrq: 0,
      nkmpr: null,
      umlmc: 0,
      ladgr: null,
      xchpf: null,
      usequ: null,
      lgrad: 0,
      auftl: null,
      plvar: null,
      otype: null,
      objid: 0,
      mtvfp: null,
      periv: null,
      kzkfk: null,
      vrvez: 0,
      vbamg: 0,
      vbeaz: 0,
      lizyk: null,
      bwscl: null,
      kautb: null,
      kordb: null,
      stawn: null,
      herkl: null,
      herkr: null,
      expme: null,
      mtver: null,
      prctr: null,
      trame: 0,
      mrppp: null,
      sauft: null,
      fxhor: 0,
      vrmod: null,
      vint1: 0,
      vint2: 0,
      verkz: null,
      stlal: null,
      stlan: null,
      plnnr: null,
      aplal: null,
      losgr: 0,
      sobsk: null,
      frtme: null,
      lgpro: null,
      disgr: null,
      kausf: 0,
      qzgtp: null,
      qmatv: null,
      takzt: 0,
      rwpro: null,
      copam: null,
      abcin: null,
      awsls: null,
      sernp: null,
      cuobj: 0,
      stdpd: null,
      sfepr: null,
      xmcng: null,
      qssys: null,
      lfrhy: null,
      rdprf: null,
      vrbmt: null,
      vrbwk: null,
      vrbdt: null,
      vrbfk: 0,
      autru: null,
      prefe: null,
      prenc: null,
      preno: null,
      prend: null,
      prene: null,
      preng: null,
      itark: null,
      servg: null,
      kzkup: null,
      strgr: null,
      cuobv: 0,
      lgfsb: null,
      schgt: null,
      ccfix: null,
      eprio: null,
      qmata: null,
      resvp: 0,
      plnty: null,
      uomgr: null,
      umrsl: null,
      abfac: 0,
      sfcpf: null,
      shflg: null,
      shzet: 0,
      mdach: null,
      kzech: null,
      megru: null,
      mfrgr: null,
      vkumc: 0,
      vktrw: 0,
      kzagl: null,
      fvidk: null,
      fxpru: null,
      loggr: null,
      fprfm: null,
      glgmg: 0,
      vkglg: 0,
      indus: null,
      mownr: null,
      mogru: null,
      casnr: null,
      gpnum: null,
      steuc: null,
      fabkz: null,
      matgr: null,
      vspvb: null,
      dplfs: null,
      dplpu: null,
      dplho: 0,
      minls: 0,
      maxls: 0,
      fixls: 0,
      ltinc: 0,
      compl: 0,
      convt: null,
      shpro: null,
      ahdis: null,
      diber: null,
      kzpsp: null,
      ocmpf: null,
      apokz: null,
      mcrue: null,
      lfmon: 0,
      lfgja: 0,
      eislo: 0,
      ncost: null,
      rotationdate: null,
      uchkz: null,
      ucmat: null,
      bwesb: 0,
      sgtcovs: null,
      sgtstatc: null,
      sgtscope: null,
      sgtmrpsi: null,
      sgtprcm: null,
      sgtchint: null,
      sgtstkprt: null,
      fshmgarunreq: null,
      fshseaim: null,
      vsorpkgrp: null,
      vsorlanenum: null,
      vsorpalvend: null,
      vsorforkdir: null,
      iuidrelevant: null,
      iuidtype: null,
      uidiea: null,
      consprocg: null,
      giprtime: 0,
      multipleekgrp: null,
      refschema: null,
      mintroc: 0,
      maxtroc: 0,
      targetstock: 0,
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
    title.value = proxy.$t('btn.add') + " " + '工厂物料'
    opertype.value = 1
    form.value.werks = []
    form.value.lvorm = []
    form.value.mmstd = new Date()
    form.value.ekgrp = []
    form.value.plifz = 0
    form.value.webaz = 0
    form.value.ausss = 0
    form.value.beskz = []
    form.value.sobsl = []
    form.value.minbe = 0
    form.value.eisbe = 0
    form.value.bstmi = 0
    form.value.bstma = 0
    form.value.bstfe = 0
    form.value.bstrf = 0
    form.value.mabst = 0
    form.value.losfx = 0
    form.value.ausdt = new Date()
    form.value.bearz = 0
    form.value.ruezt = 0
    form.value.tranz = 0
    form.value.basmg = 0
    form.value.dzeit = 0
    form.value.maxlz = 0
    form.value.ueeto = 0
    form.value.uneto = 0
    form.value.wzeit = 0
    form.value.vzusl = 0
    form.value.insmk = 0
    form.value.sproz = 0
    form.value.quazt = 0
    form.value.mpdau = 0
    form.value.wstgh = 0
    form.value.prfrq = 0
    form.value.nkmpr = new Date()
    form.value.umlmc = 0
    form.value.lgrad = 0
    form.value.otype = []
    form.value.objid = 0
    form.value.vrvez = 0
    form.value.vbamg = 0
    form.value.vbeaz = 0
    form.value.kautb = 0
    form.value.kordb = 0
    form.value.prctr = []
    form.value.trame = 0
    form.value.fxhor = 0
    form.value.vint1 = 0
    form.value.vint2 = 0
    form.value.losgr = 0
    form.value.lgpro = []
    form.value.kausf = 0
    form.value.takzt = 0
    form.value.cuobj = 0
    form.value.vrbdt = new Date()
    form.value.vrbfk = 0
    form.value.prend = new Date()
    form.value.preng = new Date()
    form.value.cuobv = 0
    form.value.lgfsb = []
    form.value.schgt = []
    form.value.resvp = 0
    form.value.abfac = 0
    form.value.shzet = 0
    form.value.vkumc = 0
    form.value.vktrw = 0
    form.value.glgmg = 0
    form.value.vkglg = 0
    form.value.dplho = 0
    form.value.minls = 0
    form.value.maxls = 0
    form.value.fixls = 0
    form.value.ltinc = 0
    form.value.compl = 0
    form.value.lfmon = 0
    form.value.lfgja = 0
    form.value.eislo = 0
    form.value.bwesb = 0
    form.value.giprtime = 0
    form.value.mintroc = 0
    form.value.maxtroc = 0
    form.value.targetstock = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.sfid || ids.value
    getMmMarc(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '工厂物料'
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

        if (form.value.sfid != undefined && opertype.value === 2) {
          updateMmMarc(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addMmMarc(form.value).then((res) => {
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
    const Ids = row.sfid || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delMmMarc(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<工厂物料.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/MmMarc/export', { ...queryParams })
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