<!--
 * @Descripttion: 常规物料/mm_mara
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 10:37:36
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
          <el-form-item label="客户级标记" prop="lvorm">
            <el-select filterable clearable v-model="queryParams.lvorm"
              :placeholder="$t('btn.selectSearchPrefix')+'客户级标记'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_is_deleted " :key="item.dictValue" :label="item.dictLabel"
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
          <el-form-item label="重量单位" prop="gewei">
            <el-select filterable clearable v-model="queryParams.gewei"
              :placeholder="$t('btn.selectSearchPrefix')+'重量单位'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="体积单位" prop="voleh">
            <el-select filterable clearable v-model="queryParams.voleh"
              :placeholder="$t('btn.selectSearchPrefix')+'体积单位'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="跨工厂物料状态" prop="mstae">
            <el-select filterable clearable v-model="queryParams.mstae"
              :placeholder="$t('btn.selectSearchPrefix')+'跨工厂物料状态'+$t('btn.selectSearchSuffix')">
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
        <el-button class="btn-add" v-hasPermi="['mm:mara:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:mara:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:mara:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:mara:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/MmMara/importTemplate" importUrl="/Logistics/MmMara/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:mara:export']">
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
      <el-table-column prop="ersda" label="创建日期" :show-overflow-tooltip="true" v-if="columns.showColumn('ersda')" />
      <el-table-column prop="ernam" label="创建对象的人员名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ernam')" />
      <el-table-column prop="laeda" label="上次更改的日期" :show-overflow-tooltip="true" v-if="columns.showColumn('laeda')" />
      <el-table-column prop="aenam" label="对象更改人员的名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('aenam')" />
      <el-table-column prop="vpsta" label="维护全部物料状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vpsta')" />
      <el-table-column prop="pstat" label="维护状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pstat')" />
      <el-table-column prop="lvorm" label="客户级标记" align="center" v-if="columns.showColumn('lvorm')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_deleted " :value="scope.row.lvorm" />
        </template>
      </el-table-column>
      <el-table-column prop="mtart" label="物料类型" align="center" v-if="columns.showColumn('mtart')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_type " :value="scope.row.mtart" />
        </template>
      </el-table-column>
      <el-table-column prop="mbrsh" label="行业领域" align="center" v-if="columns.showColumn('mbrsh')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mbrsh" />
        </template>
      </el-table-column>
      <el-table-column prop="matkl" label="物料组" align="center" v-if="columns.showColumn('matkl')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_group " :value="scope.row.matkl" />
        </template>
      </el-table-column>
      <el-table-column prop="bismt" label="旧物料号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bismt')" />
      <el-table-column prop="meins" label="基本计量单位" align="center" v-if="columns.showColumn('meins')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.meins" />
        </template>
      </el-table-column>
      <el-table-column prop="bstme" label="采购订单的计量单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bstme')" />
      <el-table-column prop="zeinr" label="文档号码(无文档管理系统)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zeinr')" />
      <el-table-column prop="zeiar" label="凭证类型(无凭证管理系统)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zeiar')" />
      <el-table-column prop="zeivr" label="文档版本（无文档管理系统）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zeivr')" />
      <el-table-column prop="zeifo" label="文件的页面大小（不包括文件管理系统）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zeifo')" />
      <el-table-column prop="aeszn" label="文档变更号(无文档管理系统)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('aeszn')" />
      <el-table-column prop="blatt" label="凭证的页号(不带凭证管理系统)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('blatt')" />
      <el-table-column prop="blanz" label="页数(没有凭证管理系统)" align="center" v-if="columns.showColumn('blanz')" />
      <el-table-column prop="ferth" label="生产/检验备忘录" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ferth')" />
      <el-table-column prop="formt" label="生产备忘录的页格式" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('formt')" />
      <el-table-column prop="groes" label="大小/量纲" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('groes')" />
      <el-table-column prop="wrkst" label="基本物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('wrkst')" />
      <el-table-column prop="normt" label="行业标准描述（例如 ANSI 或 ISO）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('normt')" />
      <el-table-column prop="labor" label="实验室/设计室" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('labor')" />
      <el-table-column prop="ekwsl" label="采购价值代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ekwsl')" />
      <el-table-column prop="brgew" label="毛重" align="center" v-if="columns.showColumn('brgew')" />
      <el-table-column prop="ntgew" label="净重" align="center" v-if="columns.showColumn('ntgew')" />
      <el-table-column prop="gewei" label="重量单位" align="center" v-if="columns.showColumn('gewei')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.gewei" />
        </template>
      </el-table-column>
      <el-table-column prop="volum" label="业务量" align="center" v-if="columns.showColumn('volum')" />
      <el-table-column prop="voleh" label="体积单位" align="center" v-if="columns.showColumn('voleh')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.voleh" />
        </template>
      </el-table-column>
      <el-table-column prop="behvo" label="容器需求" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('behvo')" />
      <el-table-column prop="raube" label="存储条件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('raube')" />
      <el-table-column prop="tempb" label="温度条件标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tempb')" />
      <el-table-column prop="disst" label="低层代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('disst')" />
      <el-table-column prop="tragr" label="运输组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tragr')" />
      <el-table-column prop="stoff" label="危险物料号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('stoff')" />
      <el-table-column prop="spart" label="产品组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('spart')" />
      <el-table-column prop="kunnr" label="竞争者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kunnr')" />
      <el-table-column prop="eannr" label="欧洲物品号 (EAN) - 已过时的 !!!!!" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('eannr')" />
      <el-table-column prop="wesch" label="数量: 待打印的 GR/GI 单数量" align="center" v-if="columns.showColumn('wesch')" />
      <el-table-column prop="bwvor" label="采购规则" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bwvor')" />
      <el-table-column prop="bwscl" label="货源" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bwscl')" />
      <el-table-column prop="saiso" label="季节类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('saiso')" />
      <el-table-column prop="etiar" label="标签类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('etiar')" />
      <el-table-column prop="etifo" label="标签格式" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('etifo')" />
      <el-table-column prop="entar" label="取消激活的" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('entar')" />
      <el-table-column prop="ean11" label="国际文件号(EAN/UPC)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ean11')" />
      <el-table-column prop="numtp" label="国际商品编码的类别 (EAN)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('numtp')" />
      <el-table-column prop="laeng" label="长度" align="center" v-if="columns.showColumn('laeng')" />
      <el-table-column prop="breit" label="宽度" align="center" v-if="columns.showColumn('breit')" />
      <el-table-column prop="hoehe" label="高度" align="center" v-if="columns.showColumn('hoehe')" />
      <el-table-column prop="meabm" label="长度/宽度/高度的尺寸单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('meabm')" />
      <el-table-column prop="prdha" label="产品层次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('prdha')" />
      <el-table-column prop="aeklk" label="库存转移净改变成本核算" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('aeklk')" />
      <el-table-column prop="cadkz" label="CAD 标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('cadkz')" />
      <el-table-column prop="qmpur" label="激活采购中的 QM" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('qmpur')" />
      <el-table-column prop="ergew" label="允许的包装重量" align="center" v-if="columns.showColumn('ergew')" />
      <el-table-column prop="ergei" label="加权的单位(允许打包加权)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ergei')" />
      <el-table-column prop="ervol" label="允许的包装体积" align="center" v-if="columns.showColumn('ervol')" />
      <el-table-column prop="ervoe" label="体积单位(允许打包体积)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ervoe')" />
      <el-table-column prop="gewto" label="处理单位的超重量容差" align="center" v-if="columns.showColumn('gewto')" />
      <el-table-column prop="volto" label="处理单位的超量冗差" align="center" v-if="columns.showColumn('volto')" />
      <el-table-column prop="vabme" label="可变采购订单单位活动" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vabme')" />
      <el-table-column prop="kzrev" label="标识: 修改水平已分配到物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzrev')" />
      <el-table-column prop="kzkfg" label="可配置的物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzkfg')" />
      <el-table-column prop="xchpf" label="批次管理需求的标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('xchpf')" />
      <el-table-column prop="vhart" label="包装物料类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vhart')" />
      <el-table-column prop="fuelg" label="最大层次 (按体积)" align="center" v-if="columns.showColumn('fuelg')" />
      <el-table-column prop="stfak" label="堆栈因子" align="center" v-if="columns.showColumn('stfak')" />
      <el-table-column prop="magrv" label="物料组: 包装物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('magrv')" />
      <el-table-column prop="begru" label="权限组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('begru')" />
      <el-table-column prop="datab" label="开始生效日期" :show-overflow-tooltip="true" v-if="columns.showColumn('datab')" />
      <el-table-column prop="liqdt" label="删除日期" :show-overflow-tooltip="true" v-if="columns.showColumn('liqdt')" />
      <el-table-column prop="saisj" label="季度年" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('saisj')" />
      <el-table-column prop="plgtp" label="价格标记类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('plgtp')" />
      <el-table-column prop="mlgut" label="空白物料清单" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mlgut')" />
      <el-table-column prop="extwg" label="外部物料组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('extwg')" />
      <el-table-column prop="satnr" label="一般可配置物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('satnr')" />
      <el-table-column prop="attyp" label="物料类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('attyp')" />
      <el-table-column prop="kzkup" label="指示符 : 物料是联产品" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzkup')" />
      <el-table-column prop="kznfm" label="标记：物料有一后续物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kznfm')" />
      <el-table-column prop="pmata" label="定价参考物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pmata')" />
      <el-table-column prop="mstae" label="跨工厂物料状态" align="center" v-if="columns.showColumn('mstae')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_list " :value="scope.row.mstae" />
        </template>
      </el-table-column>
      <el-table-column prop="mstav" label="跨分销链物料状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mstav')" />
      <el-table-column prop="mstde" label="从跨工厂物料状态有效起的日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mstde')" />
      <el-table-column prop="mstdv" label="从跨分销链物料状态有效起的日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mstdv')" />
      <el-table-column prop="taklv" label="物料从税收分类" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('taklv')" />
      <el-table-column prop="rbnrm" label="类别参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rbnrm')" />
      <el-table-column prop="mhdrz" label="最短剩余货架寿命" align="center" v-if="columns.showColumn('mhdrz')" />
      <el-table-column prop="mhdhb" label="总货架寿命" align="center" v-if="columns.showColumn('mhdhb')" />
      <el-table-column prop="mhdlp" label="仓储百分比" align="center" v-if="columns.showColumn('mhdlp')" />
      <el-table-column prop="inhme" label="内容单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('inhme')" />
      <el-table-column prop="inhal" label="净内容" align="center" v-if="columns.showColumn('inhal')" />
      <el-table-column prop="vpreh" label="比较价格单位" align="center" v-if="columns.showColumn('vpreh')" />
      <el-table-column prop="etiag" label="IS-R 标签：物料组（在 4.0 中不活动）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('etiag')" />
      <el-table-column prop="inhbr" label="毛内容" align="center" v-if="columns.showColumn('inhbr')" />
      <el-table-column prop="cmeth" label="数量转换方法" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('cmeth')" />
      <el-table-column prop="cuobf" label="内部对象号" align="center" v-if="columns.showColumn('cuobf')" />
      <el-table-column prop="kzumw" label="环境相关" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzumw')" />
      <el-table-column prop="kosch" label="产品分配确定程序" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kosch')" />
      <el-table-column prop="sprof" label="变式的定价参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sprof')" />
      <el-table-column prop="nrfhg" label="针对物料的折扣类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('nrfhg')" />
      <el-table-column prop="mfrpn" label="制造商零件编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mfrpn')" />
      <el-table-column prop="mfrnr" label="制造商编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mfrnr')" />
      <el-table-column prop="bmatn" label="公司自己 (内部) 的盘点管理物料编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bmatn')" />
      <el-table-column prop="mprof" label="制造商部件参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mprof')" />
      <el-table-column prop="kzwsm" label="计量单位使用" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzwsm')" />
      <el-table-column prop="saity" label="在季节内展开" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('saity')" />
      <el-table-column prop="profl" label="危险货物标识参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('profl')" />
      <el-table-column prop="ihivi" label="标识符:高粘性的" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ihivi')" />
      <el-table-column prop="iloos" label="标识符:固体/液体" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('iloos')" />
      <el-table-column prop="serlv" label="序列号的清晰的级别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('serlv')" />
      <el-table-column prop="kzgvh" label="包装物料是密闭包装的" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzgvh')" />
      <el-table-column prop="xgchp" label="指示符：需要批准的批量记录" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('xgchp')" />
      <el-table-column prop="kzeff" label="指定有效参数值/覆盖更改编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('kzeff')" />
      <el-table-column prop="compl" label="物料完成的水平" align="center" v-if="columns.showColumn('compl')" />
      <el-table-column prop="iprkz" label="货架寿命到期日的期间标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('iprkz')" />
      <el-table-column prop="rdmhd" label="货架寿命到期日期计算舍入规则" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rdmhd')" />
      <el-table-column prop="przus" label="标识：印刷在包装上的产品成份" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('przus')" />
      <el-table-column prop="mtposmara" label="普通项目类别组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mtposmara')" />
      <el-table-column prop="bflme" label="含后勤变量的一般物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bflme')" />
      <el-table-column prop="matfi" label="物料被锁定" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('matfi')" />
      <el-table-column prop="cmrel" label="与配置管理相关" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('cmrel')" />
      <el-table-column prop="bbtyp" label="分类清单类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bbtyp')" />
      <el-table-column prop="sledbbd" label="过期日期" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sledbbd')" />
      <el-table-column prop="gtinvariant" label="全球贸易项目编号变式" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('gtinvariant')" />
      <el-table-column prop="gennr" label="在预包装物料中的一般物料的物料编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('gennr')" />
      <el-table-column prop="rmatp" label="以相同方式包装的物料的参考物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rmatp')" />
      <el-table-column prop="gdsrelevant" label="标识：全局数据同步相关" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('gdsrelevant')" />
      <el-table-column prop="weora" label="原始接受" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('weora')" />
      <el-table-column prop="hutypdflt" label="标准处理单位类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('hutypdflt')" />
      <el-table-column prop="pilferable" label="可偷窃的" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pilferable')" />
      <el-table-column prop="whstc" label="仓库存储条件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('whstc')" />
      <el-table-column prop="whmatgr" label="仓库物料组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('whmatgr')" />
      <el-table-column prop="hndlcode" label="处理标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('hndlcode')" />
      <el-table-column prop="hazmat" label="与危险物料相关" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('hazmat')" />
      <el-table-column prop="hutyp" label="处理单位类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('hutyp')" />
      <el-table-column prop="tarevar" label="可变皮重" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tarevar')" />
      <el-table-column prop="maxc" label="包装物料的最大允许容量" align="center" v-if="columns.showColumn('maxc')" />
      <el-table-column prop="maxctol" label="处理单位的最大容量容差" align="center" v-if="columns.showColumn('maxctol')" />
      <el-table-column prop="maxl" label="包装物料的最大包长度" align="center" v-if="columns.showColumn('maxl')" />
      <el-table-column prop="maxb" label="包装物料的最大包宽度" align="center" v-if="columns.showColumn('maxb')" />
      <el-table-column prop="maxh" label="包装物料的最大包高度" align="center" v-if="columns.showColumn('maxh')" />
      <el-table-column prop="maxdimuom" label="最大包装长/宽/高的计量单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('maxdimuom')" />
      <el-table-column prop="herkl" label="物料原产地国家" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('herkl')" />
      <el-table-column prop="mfrgr" label="物料运输组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mfrgr')" />
      <el-table-column prop="qqtime" label="隔离期间" align="center" v-if="columns.showColumn('qqtime')" />
      <el-table-column prop="qqtimeuom" label="隔离期间的时间单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('qqtimeuom')" />
      <el-table-column prop="qgrp" label="质量检查组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('qgrp')" />
      <el-table-column prop="serial" label="序列号参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('serial')" />
      <el-table-column prop="pssmartform" label="表格名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('pssmartform')" />
      <el-table-column prop="logunit" label="EWM CW: 后勤计量单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('logunit')" />
      <el-table-column prop="cwqrel" label="EWM CW: 物料是称重物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('cwqrel')" />
      <el-table-column prop="cwqproc" label="EWM CW: 输入 CW 数量的称重参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('cwqproc')" />
      <el-table-column prop="cwqtolgr" label="EWM-CW: EWM 的称重容差组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('cwqtolgr')" />
      <el-table-column prop="adprof" label="调整参数文件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('adprof')" />
      <el-table-column prop="ipmipproduct" label="知识产权标识（CRM 产品）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ipmipproduct')" />
      <el-table-column prop="allowpmatigno" label="允许的变式价格（针对物料主数据）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('allowpmatigno')" />
      <el-table-column prop="medium" label="中间" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('medium')" />
      <el-table-column prop="commodity" label="实物商品" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('commodity')" />
      <el-table-column prop="animalorigin" label="标识：包含动物源的非纺织部分" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('animalorigin')" />
      <el-table-column prop="textilecompind" label="标识：新纺织组分功能" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('textilecompind')" />
      <el-table-column prop="sgtcsgr" label="分段结构" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtcsgr')" />
      <el-table-column prop="sgtcovsa" label="分段策略" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtcovsa')" />
      <el-table-column prop="sgtstat" label="分段物料主数据状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtstat')" />
      <el-table-column prop="sgtscope" label="分段策略范围" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtscope')" />
      <el-table-column prop="sgtrel" label="分段相关" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sgtrel')" />
      <el-table-column prop="anp" label="ANP Code" align="center" v-if="columns.showColumn('anp')" />
      <el-table-column prop="fshmgat1" label="Fashion 信息字段：1" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshmgat1')" />
      <el-table-column prop="fshmgat2" label="Fashion 信息字段：2" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshmgat2')" />
      <el-table-column prop="fshmgat3" label="Fashion 信息字段：3" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshmgat3')" />
      <el-table-column prop="fshsealv" label="标识：季节使用" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshsealv')" />
      <el-table-column prop="fshseaim" label="标识：在库存管理中激活季节" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshseaim')" />
      <el-table-column prop="fshscmid" label="特征值转换的物料转换标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fshscmid')" />
      <el-table-column prop="bev1luleinh" label="装载单位" align="center" v-if="columns.showColumn('bev1luleinh')" />
      <el-table-column prop="bev1luldegrp" label="装载单位组：IS 饮料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bev1luldegrp')" />
      <el-table-column prop="bev1nestruccat" label="物料关系的结构类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bev1nestruccat')" />
      <el-table-column prop="dsdsltoltyp" label="容差类型标识" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dsdsltoltyp')" />
      <el-table-column prop="dsdsvcntgrp" label="计算组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dsdsvcntgrp')" />
      <el-table-column prop="dsdvcgroup" label="DSD 分组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dsdvcgroup')" />
      <el-table-column prop="vsortiltind" label="可以倾斜物料 (车辆空间优化)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsortiltind')" />
      <el-table-column prop="vsorstackind" label="不允许堆栈 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorstackind')" />
      <el-table-column prop="vsorbotind" label="底层 (车辆空间最优化)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorbotind')" />
      <el-table-column prop="vsortopind" label="顶层 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsortopind')" />
      <el-table-column prop="vsorstackno" label="堆栈因子 (车辆空间优化)" align="center"
        v-if="columns.showColumn('vsorstackno')" />
      <el-table-column prop="vsorpalind" label="无包装物料的装载 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorpalind')" />
      <el-table-column prop="vsorpalovrd" label="包装物料的允许悬挂深度 (VSO)" align="center"
        v-if="columns.showColumn('vsorpalovrd')" />
      <el-table-column prop="vsorpalovrw" label="装运物料的允许悬挂宽度 (VSO)" align="center"
        v-if="columns.showColumn('vsorpalovrw')" />
      <el-table-column prop="vsorpalbht" label="包装物料的最大叠放高度 (VSO)" align="center"
        v-if="columns.showColumn('vsorpalbht')" />
      <el-table-column prop="vsorpalminh" label="包装物料的最小叠放高度 (VSO)" align="center"
        v-if="columns.showColumn('vsorpalminh')" />
      <el-table-column prop="vsortolbht" label="超出最大叠放高度的容差 (VSO)" align="center"
        v-if="columns.showColumn('vsortolbht')" />
      <el-table-column prop="vsornopgvh" label="每个已结清 PKM 的物料编号(VSO)" align="center"
        v-if="columns.showColumn('vsornopgvh')" />
      <el-table-column prop="vsorquanunit" label="计量单位车辆空间优化" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorquanunit')" />
      <el-table-column prop="vsorkzgvhind" label="请求的已清包装物料 (VSO)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('vsorkzgvhind')" />
      <el-table-column prop="packcode" label="Packaging Code" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('packcode')" />
      <el-table-column prop="dgpackstatus" label="危险品的包装状态" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('dgpackstatus')" />
      <el-table-column prop="mcond" label="物料条件管理" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mcond')" />
      <el-table-column prop="retdelc" label="返回代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('retdelc')" />
      <el-table-column prop="loglevreto" label="后勤等级退货" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('loglevreto')" />
      <el-table-column prop="nsnid" label="NATO 项目标识编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('nsnid')" />
      <el-table-column prop="imatn" label="完全互换组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('imatn')" />
      <el-table-column prop="picnum" label="替换链编号" align="center" v-if="columns.showColumn('picnum')">
        <template #default="scope">
          <ImagePreview :src="scope.row.picnum"></ImagePreview>
        </template>
      </el-table-column>
      <el-table-column prop="bstat" label="创建状态 - 季节性采购" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('bstat')" />
      <el-table-column prop="coloratinn" label="颜色特性的内部特性编号" align="center" v-if="columns.showColumn('coloratinn')" />
      <el-table-column prop="size1atinn" label="主尺寸的特性的内部特性编号" align="center" v-if="columns.showColumn('size1atinn')" />
      <el-table-column prop="size2atinn" label="次尺寸的特性的内部特性编号" align="center" v-if="columns.showColumn('size2atinn')" />
      <el-table-column prop="color" label="变式颜色的特性值" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('color')" />
      <el-table-column prop="size1" label="变式主尺寸的特性值" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('size1')" />
      <el-table-column prop="size2" label="变式的次尺寸的特性值" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('size2')" />
      <el-table-column prop="freechar" label="评估目的的特性值" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('freechar')" />
      <el-table-column prop="carecode" label="护理代码（例如洗涤代码, 烫平衣服代码, 等等)" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('carecode')" />
      <el-table-column prop="brandid" label="商标" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('brandid')" />
      <el-table-column prop="fibercode1" label="纺织品的光纤代码（组件1）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fibercode1')" />
      <el-table-column prop="fiberpart1" label="光纤的百分比共享（组件1）" align="center" v-if="columns.showColumn('fiberpart1')" />
      <el-table-column prop="fibercode2" label="纺织品的光纤代码（组件2）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fibercode2')" />
      <el-table-column prop="fiberpart2" label="光纤的百分比共享（组件2）" align="center" v-if="columns.showColumn('fiberpart2')" />
      <el-table-column prop="fibercode3" label="纺织品的光纤代码（组件3）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fibercode3')" />
      <el-table-column prop="fiberpart3" label="光纤的百分比共享（组件3）" align="center" v-if="columns.showColumn('fiberpart3')" />
      <el-table-column prop="fibercode4" label="纺织品的光纤代码（组件4）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fibercode4')" />
      <el-table-column prop="fiberpart4" label="光纤的百分比共享（组件4）" align="center" v-if="columns.showColumn('fiberpart4')" />
      <el-table-column prop="fibercode5" label="纺织品的光纤代码（组件5）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fibercode5')" />
      <el-table-column prop="fiberpart5" label="光纤的百分比共享（组件5）" align="center" v-if="columns.showColumn('fiberpart5')" />
      <el-table-column prop="fashgrd" label="时装等级" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('fashgrd')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
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
              v-hasPermi="['mm:mara:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['mm:mara:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改常规物料对话框 -->
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
                <el-form-item label="创建日期" prop="ersda">
                  <el-date-picker v-model="form.ersda" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建对象的人员名称" prop="ernam">
                  <el-input v-model="form.ernam"
                    :placeholder="$t('btn.enterPrefix')+'创建对象的人员名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="上次更改的日期" prop="laeda">
                  <el-date-picker v-model="form.laeda" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="对象更改人员的名称" prop="aenam">
                  <el-input v-model="form.aenam"
                    :placeholder="$t('btn.enterPrefix')+'对象更改人员的名称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="维护全部物料状态" prop="vpsta">
                  <el-input v-model="form.vpsta"
                    :placeholder="$t('btn.enterPrefix')+'维护全部物料状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="维护状态" prop="pstat">
                  <el-input v-model="form.pstat" :placeholder="$t('btn.enterPrefix')+'维护状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="客户级标记" prop="lvorm">
                  <el-select filterable clearable v-model="form.lvorm"
                    :placeholder="$t('btn.selectPrefix')+'客户级标记'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_is_deleted" :key="item.dictValue" :label="item.dictLabel"
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
                <el-form-item label="行业领域" prop="mbrsh">
                  <el-select filterable clearable v-model="form.mbrsh"
                    :placeholder="$t('btn.selectPrefix')+'行业领域'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ind_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
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
                <el-form-item label="旧物料号" prop="bismt">
                  <el-input v-model="form.bismt" :placeholder="$t('btn.enterPrefix')+'旧物料号'+$t('btn.enterSuffix')" />
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
                <el-form-item label="采购订单的计量单位" prop="bstme">
                  <el-input v-model="form.bstme"
                    :placeholder="$t('btn.enterPrefix')+'采购订单的计量单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="文档号码(无文档管理系统)" prop="zeinr">
                  <el-input v-model="form.zeinr"
                    :placeholder="$t('btn.enterPrefix')+'文档号码(无文档管理系统)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="凭证类型(无凭证管理系统)" prop="zeiar">
                  <el-input v-model="form.zeiar"
                    :placeholder="$t('btn.enterPrefix')+'凭证类型(无凭证管理系统)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="文档版本（无文档管理系统）" prop="zeivr">
                  <el-input v-model="form.zeivr"
                    :placeholder="$t('btn.enterPrefix')+'文档版本（无文档管理系统）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="文件的页面大小（不包括文件管理系统）" prop="zeifo">
                  <el-input v-model="form.zeifo"
                    :placeholder="$t('btn.enterPrefix')+'文件的页面大小（不包括文件管理系统）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="文档变更号(无文档管理系统)" prop="aeszn">
                  <el-input v-model="form.aeszn"
                    :placeholder="$t('btn.enterPrefix')+'文档变更号(无文档管理系统)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="凭证的页号(不带凭证管理系统)" prop="blatt">
                  <el-input v-model="form.blatt"
                    :placeholder="$t('btn.enterPrefix')+'凭证的页号(不带凭证管理系统)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="页数(没有凭证管理系统)" prop="blanz">
                  <el-input-number v-model.number="form.blanz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'页数(没有凭证管理系统)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产/检验备忘录" prop="ferth">
                  <el-input v-model="form.ferth"
                    :placeholder="$t('btn.enterPrefix')+'生产/检验备忘录'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产备忘录的页格式" prop="formt">
                  <el-input v-model="form.formt"
                    :placeholder="$t('btn.enterPrefix')+'生产备忘录的页格式'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="大小/量纲" prop="groes">
                  <el-input v-model="form.groes" :placeholder="$t('btn.enterPrefix')+'大小/量纲'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基本物料" prop="wrkst">
                  <el-input v-model="form.wrkst" :placeholder="$t('btn.enterPrefix')+'基本物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="行业标准描述（例如 ANSI 或 ISO）" prop="normt">
                  <el-input v-model="form.normt"
                    :placeholder="$t('btn.enterPrefix')+'行业标准描述（例如 ANSI 或 ISO）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="实验室/设计室" prop="labor">
                  <el-input v-model="form.labor" :placeholder="$t('btn.enterPrefix')+'实验室/设计室'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购价值代码" prop="ekwsl">
                  <el-input v-model="form.ekwsl" :placeholder="$t('btn.enterPrefix')+'采购价值代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="毛重" prop="brgew">
                  <el-input-number v-model.number="form.brgew" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'毛重'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="净重" prop="ntgew">
                  <el-input-number v-model.number="form.ntgew" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'净重'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="重量单位" prop="gewei">
                  <el-select filterable clearable v-model="form.gewei"
                    :placeholder="$t('btn.selectPrefix')+'重量单位'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_unit_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="业务量" prop="volum">
                  <el-input-number v-model.number="form.volum" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'业务量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="体积单位" prop="voleh">
                  <el-select filterable clearable v-model="form.voleh"
                    :placeholder="$t('btn.selectPrefix')+'体积单位'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_unit_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="容器需求" prop="behvo">
                  <el-input v-model="form.behvo" :placeholder="$t('btn.enterPrefix')+'容器需求'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="存储条件" prop="raube">
                  <el-input v-model="form.raube" :placeholder="$t('btn.enterPrefix')+'存储条件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="温度条件标识" prop="tempb">
                  <el-input v-model="form.tempb" :placeholder="$t('btn.enterPrefix')+'温度条件标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="低层代码" prop="disst">
                  <el-input v-model="form.disst" :placeholder="$t('btn.enterPrefix')+'低层代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="运输组" prop="tragr">
                  <el-input v-model="form.tragr" :placeholder="$t('btn.enterPrefix')+'运输组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="危险物料号" prop="stoff">
                  <el-input v-model="form.stoff" :placeholder="$t('btn.enterPrefix')+'危险物料号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="产品组" prop="spart">
                  <el-input v-model="form.spart" :placeholder="$t('btn.enterPrefix')+'产品组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="竞争者" prop="kunnr">
                  <el-input v-model="form.kunnr" :placeholder="$t('btn.enterPrefix')+'竞争者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="欧洲物品号 (EAN) - 已过时的 !!!!!" prop="eannr">
                  <el-input v-model="form.eannr"
                    :placeholder="$t('btn.enterPrefix')+'欧洲物品号 (EAN) - 已过时的 !!!!!'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="数量: 待打印的 GR/GI 单数量" prop="wesch">
                  <el-input-number v-model.number="form.wesch" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'数量: 待打印的 GR/GI 单数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购规则" prop="bwvor">
                  <el-input v-model="form.bwvor" :placeholder="$t('btn.enterPrefix')+'采购规则'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="货源" prop="bwscl">
                  <el-input v-model="form.bwscl" :placeholder="$t('btn.enterPrefix')+'货源'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="季节类别" prop="saiso">
                  <el-input v-model="form.saiso" :placeholder="$t('btn.enterPrefix')+'季节类别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标签类型" prop="etiar">
                  <el-input v-model="form.etiar" :placeholder="$t('btn.enterPrefix')+'标签类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标签格式" prop="etifo">
                  <el-input v-model="form.etifo" :placeholder="$t('btn.enterPrefix')+'标签格式'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="取消激活的" prop="entar">
                  <el-input v-model="form.entar" :placeholder="$t('btn.enterPrefix')+'取消激活的'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="国际文件号(EAN/UPC)" prop="ean11">
                  <el-input v-model="form.ean11"
                    :placeholder="$t('btn.enterPrefix')+'国际文件号(EAN/UPC)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="国际商品编码的类别 (EAN)" prop="numtp">
                  <el-input v-model="form.numtp"
                    :placeholder="$t('btn.enterPrefix')+'国际商品编码的类别 (EAN)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="长度" prop="laeng">
                  <el-input-number v-model.number="form.laeng" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'长度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="宽度" prop="breit">
                  <el-input-number v-model.number="form.breit" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'宽度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="高度" prop="hoehe">
                  <el-input-number v-model.number="form.hoehe" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'高度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="长度/宽度/高度的尺寸单位" prop="meabm">
                  <el-input v-model="form.meabm"
                    :placeholder="$t('btn.enterPrefix')+'长度/宽度/高度的尺寸单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="产品层次" prop="prdha">
                  <el-input v-model="form.prdha" :placeholder="$t('btn.enterPrefix')+'产品层次'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存转移净改变成本核算" prop="aeklk">
                  <el-input v-model="form.aeklk"
                    :placeholder="$t('btn.enterPrefix')+'库存转移净改变成本核算'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="CAD 标识" prop="cadkz">
                  <el-input v-model="form.cadkz" :placeholder="$t('btn.enterPrefix')+'CAD 标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="激活采购中的 QM" prop="qmpur">
                  <el-input v-model="form.qmpur"
                    :placeholder="$t('btn.enterPrefix')+'激活采购中的 QM'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="允许的包装重量" prop="ergew">
                  <el-input-number v-model.number="form.ergew" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'允许的包装重量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="加权的单位(允许打包加权)" prop="ergei">
                  <el-input v-model="form.ergei"
                    :placeholder="$t('btn.enterPrefix')+'加权的单位(允许打包加权)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="允许的包装体积" prop="ervol">
                  <el-input-number v-model.number="form.ervol" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'允许的包装体积'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="体积单位(允许打包体积)" prop="ervoe">
                  <el-input v-model="form.ervoe"
                    :placeholder="$t('btn.enterPrefix')+'体积单位(允许打包体积)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理单位的超重量容差" prop="gewto">
                  <el-input-number v-model.number="form.gewto" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'处理单位的超重量容差'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理单位的超量冗差" prop="volto">
                  <el-input-number v-model.number="form.volto" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'处理单位的超量冗差'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可变采购订单单位活动" prop="vabme">
                  <el-input v-model="form.vabme"
                    :placeholder="$t('btn.enterPrefix')+'可变采购订单单位活动'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识: 修改水平已分配到物料" prop="kzrev">
                  <el-input v-model="form.kzrev"
                    :placeholder="$t('btn.enterPrefix')+'标识: 修改水平已分配到物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可配置的物料" prop="kzkfg">
                  <el-input v-model="form.kzkfg" :placeholder="$t('btn.enterPrefix')+'可配置的物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批次管理需求的标识" prop="xchpf">
                  <el-input v-model="form.xchpf"
                    :placeholder="$t('btn.enterPrefix')+'批次管理需求的标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料类型" prop="vhart">
                  <el-input v-model="form.vhart" :placeholder="$t('btn.enterPrefix')+'包装物料类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最大层次 (按体积)" prop="fuelg">
                  <el-input-number v-model.number="form.fuelg" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最大层次 (按体积)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="堆栈因子" prop="stfak">
                  <el-input-number v-model.number="form.stfak" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'堆栈因子'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料组: 包装物料" prop="magrv">
                  <el-input v-model="form.magrv"
                    :placeholder="$t('btn.enterPrefix')+'物料组: 包装物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="权限组" prop="begru">
                  <el-input v-model="form.begru" :placeholder="$t('btn.enterPrefix')+'权限组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="开始生效日期" prop="datab">
                  <el-date-picker v-model="form.datab" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="删除日期" prop="liqdt">
                  <el-date-picker v-model="form.liqdt" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="季度年" prop="saisj">
                  <el-input v-model="form.saisj" :placeholder="$t('btn.enterPrefix')+'季度年'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="价格标记类别" prop="plgtp">
                  <el-input v-model="form.plgtp" :placeholder="$t('btn.enterPrefix')+'价格标记类别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="空白物料清单" prop="mlgut">
                  <el-input v-model="form.mlgut" :placeholder="$t('btn.enterPrefix')+'空白物料清单'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="外部物料组" prop="extwg">
                  <el-input v-model="form.extwg" :placeholder="$t('btn.enterPrefix')+'外部物料组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="一般可配置物料" prop="satnr">
                  <el-input v-model="form.satnr" :placeholder="$t('btn.enterPrefix')+'一般可配置物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料类别" prop="attyp">
                  <el-input v-model="form.attyp" :placeholder="$t('btn.enterPrefix')+'物料类别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示符 : 物料是联产品" prop="kzkup">
                  <el-input v-model="form.kzkup"
                    :placeholder="$t('btn.enterPrefix')+'指示符 : 物料是联产品'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标记：物料有一后续物料" prop="kznfm">
                  <el-input v-model="form.kznfm"
                    :placeholder="$t('btn.enterPrefix')+'标记：物料有一后续物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="定价参考物料" prop="pmata">
                  <el-input v-model="form.pmata" :placeholder="$t('btn.enterPrefix')+'定价参考物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="跨工厂物料状态" prop="mstae">
                  <el-select filterable clearable v-model="form.mstae"
                    :placeholder="$t('btn.selectPrefix')+'跨工厂物料状态'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_eol_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="跨分销链物料状态" prop="mstav">
                  <el-input v-model="form.mstav"
                    :placeholder="$t('btn.enterPrefix')+'跨分销链物料状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="从跨工厂物料状态有效起的日期" prop="mstde">
                  <el-date-picker v-model="form.mstde" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="从跨分销链物料状态有效起的日期" prop="mstdv">
                  <el-date-picker v-model="form.mstdv" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料从税收分类" prop="taklv">
                  <el-input v-model="form.taklv" :placeholder="$t('btn.enterPrefix')+'物料从税收分类'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="类别参数文件" prop="rbnrm">
                  <el-input v-model="form.rbnrm" :placeholder="$t('btn.enterPrefix')+'类别参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最短剩余货架寿命" prop="mhdrz">
                  <el-input-number v-model.number="form.mhdrz" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最短剩余货架寿命'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="总货架寿命" prop="mhdhb">
                  <el-input-number v-model.number="form.mhdhb" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'总货架寿命'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仓储百分比" prop="mhdlp">
                  <el-input-number v-model.number="form.mhdlp" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'仓储百分比'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="内容单位" prop="inhme">
                  <el-input v-model="form.inhme" :placeholder="$t('btn.enterPrefix')+'内容单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="净内容" prop="inhal">
                  <el-input-number v-model.number="form.inhal" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'净内容'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="比较价格单位" prop="vpreh">
                  <el-input-number v-model.number="form.vpreh" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'比较价格单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="IS-R 标签：物料组（在 4.0 中不活动）" prop="etiag">
                  <el-input v-model="form.etiag"
                    :placeholder="$t('btn.enterPrefix')+'IS-R 标签：物料组（在 4.0 中不活动）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="毛内容" prop="inhbr">
                  <el-input-number v-model.number="form.inhbr" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'毛内容'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="数量转换方法" prop="cmeth">
                  <el-input v-model="form.cmeth" :placeholder="$t('btn.enterPrefix')+'数量转换方法'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="内部对象号" prop="cuobf">
                  <el-input-number v-model.number="form.cuobf" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'内部对象号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="环境相关" prop="kzumw">
                  <el-input v-model="form.kzumw" :placeholder="$t('btn.enterPrefix')+'环境相关'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="产品分配确定程序" prop="kosch">
                  <el-input v-model="form.kosch"
                    :placeholder="$t('btn.enterPrefix')+'产品分配确定程序'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="变式的定价参数文件" prop="sprof">
                  <el-input v-model="form.sprof"
                    :placeholder="$t('btn.enterPrefix')+'变式的定价参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="针对物料的折扣类型" prop="nrfhg">
                  <el-input v-model="form.nrfhg"
                    :placeholder="$t('btn.enterPrefix')+'针对物料的折扣类型'+$t('btn.enterSuffix')" />
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
                <el-form-item label="公司自己 (内部) 的盘点管理物料编号" prop="bmatn">
                  <el-input v-model="form.bmatn"
                    :placeholder="$t('btn.enterPrefix')+'公司自己 (内部) 的盘点管理物料编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="制造商部件参数文件" prop="mprof">
                  <el-input v-model="form.mprof"
                    :placeholder="$t('btn.enterPrefix')+'制造商部件参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计量单位使用" prop="kzwsm">
                  <el-input v-model="form.kzwsm" :placeholder="$t('btn.enterPrefix')+'计量单位使用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="在季节内展开" prop="saity">
                  <el-input v-model="form.saity" :placeholder="$t('btn.enterPrefix')+'在季节内展开'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="危险货物标识参数文件" prop="profl">
                  <el-input v-model="form.profl"
                    :placeholder="$t('btn.enterPrefix')+'危险货物标识参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识符:高粘性的" prop="ihivi">
                  <el-input v-model="form.ihivi"
                    :placeholder="$t('btn.enterPrefix')+'标识符:高粘性的'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识符:固体/液体" prop="iloos">
                  <el-input v-model="form.iloos"
                    :placeholder="$t('btn.enterPrefix')+'标识符:固体/液体'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序列号的清晰的级别" prop="serlv">
                  <el-input v-model="form.serlv"
                    :placeholder="$t('btn.enterPrefix')+'序列号的清晰的级别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料是密闭包装的" prop="kzgvh">
                  <el-input v-model="form.kzgvh"
                    :placeholder="$t('btn.enterPrefix')+'包装物料是密闭包装的'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指示符：需要批准的批量记录" prop="xgchp">
                  <el-input v-model="form.xgchp"
                    :placeholder="$t('btn.enterPrefix')+'指示符：需要批准的批量记录'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="指定有效参数值/覆盖更改编号" prop="kzeff">
                  <el-input v-model="form.kzeff"
                    :placeholder="$t('btn.enterPrefix')+'指定有效参数值/覆盖更改编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料完成的水平" prop="compl">
                  <el-input-number v-model.number="form.compl" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'物料完成的水平'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="货架寿命到期日的期间标识" prop="iprkz">
                  <el-input v-model="form.iprkz"
                    :placeholder="$t('btn.enterPrefix')+'货架寿命到期日的期间标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="货架寿命到期日期计算舍入规则" prop="rdmhd">
                  <el-input v-model="form.rdmhd"
                    :placeholder="$t('btn.enterPrefix')+'货架寿命到期日期计算舍入规则'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：印刷在包装上的产品成份" prop="przus">
                  <el-input v-model="form.przus"
                    :placeholder="$t('btn.enterPrefix')+'标识：印刷在包装上的产品成份'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="普通项目类别组" prop="mtposmara">
                  <el-input v-model="form.mtposmara"
                    :placeholder="$t('btn.enterPrefix')+'普通项目类别组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="含后勤变量的一般物料" prop="bflme">
                  <el-input v-model="form.bflme"
                    :placeholder="$t('btn.enterPrefix')+'含后勤变量的一般物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料被锁定" prop="matfi">
                  <el-input v-model="form.matfi" :placeholder="$t('btn.enterPrefix')+'物料被锁定'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="与配置管理相关" prop="cmrel">
                  <el-input v-model="form.cmrel" :placeholder="$t('btn.enterPrefix')+'与配置管理相关'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分类清单类型" prop="bbtyp">
                  <el-input v-model="form.bbtyp" :placeholder="$t('btn.enterPrefix')+'分类清单类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="过期日期" prop="sledbbd">
                  <el-input v-model="form.sledbbd" :placeholder="$t('btn.enterPrefix')+'过期日期'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="全球贸易项目编号变式" prop="gtinvariant">
                  <el-input v-model="form.gtinvariant"
                    :placeholder="$t('btn.enterPrefix')+'全球贸易项目编号变式'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="在预包装物料中的一般物料的物料编号" prop="gennr">
                  <el-input v-model="form.gennr"
                    :placeholder="$t('btn.enterPrefix')+'在预包装物料中的一般物料的物料编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="以相同方式包装的物料的参考物料" prop="rmatp">
                  <el-input v-model="form.rmatp"
                    :placeholder="$t('btn.enterPrefix')+'以相同方式包装的物料的参考物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：全局数据同步相关" prop="gdsrelevant">
                  <el-input v-model="form.gdsrelevant"
                    :placeholder="$t('btn.enterPrefix')+'标识：全局数据同步相关'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="原始接受" prop="weora">
                  <el-input v-model="form.weora" :placeholder="$t('btn.enterPrefix')+'原始接受'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标准处理单位类型" prop="hutypdflt">
                  <el-input v-model="form.hutypdflt"
                    :placeholder="$t('btn.enterPrefix')+'标准处理单位类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可偷窃的" prop="pilferable">
                  <el-input v-model="form.pilferable"
                    :placeholder="$t('btn.enterPrefix')+'可偷窃的'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仓库存储条件" prop="whstc">
                  <el-input v-model="form.whstc" :placeholder="$t('btn.enterPrefix')+'仓库存储条件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="仓库物料组" prop="whmatgr">
                  <el-input v-model="form.whmatgr" :placeholder="$t('btn.enterPrefix')+'仓库物料组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理标识" prop="hndlcode">
                  <el-input v-model="form.hndlcode" :placeholder="$t('btn.enterPrefix')+'处理标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="与危险物料相关" prop="hazmat">
                  <el-input v-model="form.hazmat"
                    :placeholder="$t('btn.enterPrefix')+'与危险物料相关'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理单位类型" prop="hutyp">
                  <el-input v-model="form.hutyp" :placeholder="$t('btn.enterPrefix')+'处理单位类型'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可变皮重" prop="tarevar">
                  <el-input v-model="form.tarevar" :placeholder="$t('btn.enterPrefix')+'可变皮重'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料的最大允许容量" prop="maxc">
                  <el-input-number v-model.number="form.maxc" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'包装物料的最大允许容量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理单位的最大容量容差" prop="maxctol">
                  <el-input-number v-model.number="form.maxctol" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'处理单位的最大容量容差'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料的最大包长度" prop="maxl">
                  <el-input-number v-model.number="form.maxl" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'包装物料的最大包长度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料的最大包宽度" prop="maxb">
                  <el-input-number v-model.number="form.maxb" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'包装物料的最大包宽度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料的最大包高度" prop="maxh">
                  <el-input-number v-model.number="form.maxh" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'包装物料的最大包高度'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="最大包装长/宽/高的计量单位" prop="maxdimuom">
                  <el-input v-model="form.maxdimuom"
                    :placeholder="$t('btn.enterPrefix')+'最大包装长/宽/高的计量单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料原产地国家" prop="herkl">
                  <el-input v-model="form.herkl" :placeholder="$t('btn.enterPrefix')+'物料原产地国家'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料运输组" prop="mfrgr">
                  <el-input v-model="form.mfrgr" :placeholder="$t('btn.enterPrefix')+'物料运输组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="隔离期间" prop="qqtime">
                  <el-input-number v-model.number="form.qqtime" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'隔离期间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="隔离期间的时间单位" prop="qqtimeuom">
                  <el-input v-model="form.qqtimeuom"
                    :placeholder="$t('btn.enterPrefix')+'隔离期间的时间单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="质量检查组" prop="qgrp">
                  <el-input v-model="form.qgrp" :placeholder="$t('btn.enterPrefix')+'质量检查组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序列号参数文件" prop="serial">
                  <el-input v-model="form.serial"
                    :placeholder="$t('btn.enterPrefix')+'序列号参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="表格名" prop="pssmartform">
                  <el-input v-model="form.pssmartform"
                    :placeholder="$t('btn.enterPrefix')+'表格名'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EWM CW: 后勤计量单位" prop="logunit">
                  <el-input v-model="form.logunit"
                    :placeholder="$t('btn.enterPrefix')+'EWM CW: 后勤计量单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EWM CW: 物料是称重物料" prop="cwqrel">
                  <el-input v-model="form.cwqrel"
                    :placeholder="$t('btn.enterPrefix')+'EWM CW: 物料是称重物料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EWM CW: 输入 CW 数量的称重参数文件" prop="cwqproc">
                  <el-input v-model="form.cwqproc"
                    :placeholder="$t('btn.enterPrefix')+'EWM CW: 输入 CW 数量的称重参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="EWM-CW: EWM 的称重容差组" prop="cwqtolgr">
                  <el-input v-model="form.cwqtolgr"
                    :placeholder="$t('btn.enterPrefix')+'EWM-CW: EWM 的称重容差组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="调整参数文件" prop="adprof">
                  <el-input v-model="form.adprof" :placeholder="$t('btn.enterPrefix')+'调整参数文件'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="知识产权标识（CRM 产品）" prop="ipmipproduct">
                  <el-input v-model="form.ipmipproduct"
                    :placeholder="$t('btn.enterPrefix')+'知识产权标识（CRM 产品）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="允许的变式价格（针对物料主数据）" prop="allowpmatigno">
                  <el-input v-model="form.allowpmatigno"
                    :placeholder="$t('btn.enterPrefix')+'允许的变式价格（针对物料主数据）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="中间" prop="medium">
                  <el-input v-model="form.medium" :placeholder="$t('btn.enterPrefix')+'中间'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="实物商品" prop="commodity">
                  <el-input v-model="form.commodity"
                    :placeholder="$t('btn.enterPrefix')+'实物商品'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：包含动物源的非纺织部分" prop="animalorigin">
                  <el-input v-model="form.animalorigin"
                    :placeholder="$t('btn.enterPrefix')+'标识：包含动物源的非纺织部分'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：新纺织组分功能" prop="textilecompind">
                  <el-input v-model="form.textilecompind"
                    :placeholder="$t('btn.enterPrefix')+'标识：新纺织组分功能'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段结构" prop="sgtcsgr">
                  <el-input v-model="form.sgtcsgr" :placeholder="$t('btn.enterPrefix')+'分段结构'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段策略" prop="sgtcovsa">
                  <el-input v-model="form.sgtcovsa" :placeholder="$t('btn.enterPrefix')+'分段策略'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段物料主数据状态" prop="sgtstat">
                  <el-input v-model="form.sgtstat"
                    :placeholder="$t('btn.enterPrefix')+'分段物料主数据状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段策略范围" prop="sgtscope">
                  <el-input v-model="form.sgtscope"
                    :placeholder="$t('btn.enterPrefix')+'分段策略范围'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分段相关" prop="sgtrel">
                  <el-input v-model="form.sgtrel" :placeholder="$t('btn.enterPrefix')+'分段相关'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="ANP Code" prop="anp">
                  <el-input-number v-model.number="form.anp" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'ANP Code'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Fashion 信息字段：1" prop="fshmgat1">
                  <el-input v-model="form.fshmgat1"
                    :placeholder="$t('btn.enterPrefix')+'Fashion 信息字段：1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Fashion 信息字段：2" prop="fshmgat2">
                  <el-input v-model="form.fshmgat2"
                    :placeholder="$t('btn.enterPrefix')+'Fashion 信息字段：2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Fashion 信息字段：3" prop="fshmgat3">
                  <el-input v-model="form.fshmgat3"
                    :placeholder="$t('btn.enterPrefix')+'Fashion 信息字段：3'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：季节使用" prop="fshsealv">
                  <el-input v-model="form.fshsealv"
                    :placeholder="$t('btn.enterPrefix')+'标识：季节使用'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标识：在库存管理中激活季节" prop="fshseaim">
                  <el-input v-model="form.fshseaim"
                    :placeholder="$t('btn.enterPrefix')+'标识：在库存管理中激活季节'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="特征值转换的物料转换标识" prop="fshscmid">
                  <el-input v-model="form.fshscmid"
                    :placeholder="$t('btn.enterPrefix')+'特征值转换的物料转换标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="装载单位" prop="bev1luleinh">
                  <el-input-number v-model.number="form.bev1luleinh" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'装载单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="装载单位组：IS 饮料" prop="bev1luldegrp">
                  <el-input v-model="form.bev1luldegrp"
                    :placeholder="$t('btn.enterPrefix')+'装载单位组：IS 饮料'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料关系的结构类别" prop="bev1nestruccat">
                  <el-input v-model="form.bev1nestruccat"
                    :placeholder="$t('btn.enterPrefix')+'物料关系的结构类别'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="容差类型标识" prop="dsdsltoltyp">
                  <el-input v-model="form.dsdsltoltyp"
                    :placeholder="$t('btn.enterPrefix')+'容差类型标识'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计算组" prop="dsdsvcntgrp">
                  <el-input v-model="form.dsdsvcntgrp"
                    :placeholder="$t('btn.enterPrefix')+'计算组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="DSD 分组" prop="dsdvcgroup">
                  <el-input v-model="form.dsdvcgroup"
                    :placeholder="$t('btn.enterPrefix')+'DSD 分组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="可以倾斜物料 (车辆空间优化)" prop="vsortiltind">
                  <el-input v-model="form.vsortiltind"
                    :placeholder="$t('btn.enterPrefix')+'可以倾斜物料 (车辆空间优化)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="不允许堆栈 (VSO)" prop="vsorstackind">
                  <el-input v-model="form.vsorstackind"
                    :placeholder="$t('btn.enterPrefix')+'不允许堆栈 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="底层 (车辆空间最优化)" prop="vsorbotind">
                  <el-input v-model="form.vsorbotind"
                    :placeholder="$t('btn.enterPrefix')+'底层 (车辆空间最优化)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="顶层 (VSO)" prop="vsortopind">
                  <el-input v-model="form.vsortopind"
                    :placeholder="$t('btn.enterPrefix')+'顶层 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="堆栈因子 (车辆空间优化)" prop="vsorstackno">
                  <el-input-number v-model.number="form.vsorstackno" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'堆栈因子 (车辆空间优化)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="无包装物料的装载 (VSO)" prop="vsorpalind">
                  <el-input v-model="form.vsorpalind"
                    :placeholder="$t('btn.enterPrefix')+'无包装物料的装载 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料的允许悬挂深度 (VSO)" prop="vsorpalovrd">
                  <el-input-number v-model.number="form.vsorpalovrd" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'包装物料的允许悬挂深度 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="装运物料的允许悬挂宽度 (VSO)" prop="vsorpalovrw">
                  <el-input-number v-model.number="form.vsorpalovrw" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'装运物料的允许悬挂宽度 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料的最大叠放高度 (VSO)" prop="vsorpalbht">
                  <el-input-number v-model.number="form.vsorpalbht" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'包装物料的最大叠放高度 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="包装物料的最小叠放高度 (VSO)" prop="vsorpalminh">
                  <el-input-number v-model.number="form.vsorpalminh" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'包装物料的最小叠放高度 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="超出最大叠放高度的容差 (VSO)" prop="vsortolbht">
                  <el-input-number v-model.number="form.vsortolbht" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'超出最大叠放高度的容差 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="每个已结清 PKM 的物料编号(VSO)" prop="vsornopgvh">
                  <el-input-number v-model.number="form.vsornopgvh" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'每个已结清 PKM 的物料编号(VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计量单位车辆空间优化" prop="vsorquanunit">
                  <el-input v-model="form.vsorquanunit"
                    :placeholder="$t('btn.enterPrefix')+'计量单位车辆空间优化'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="请求的已清包装物料 (VSO)" prop="vsorkzgvhind">
                  <el-input v-model="form.vsorkzgvhind"
                    :placeholder="$t('btn.enterPrefix')+'请求的已清包装物料 (VSO)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Packaging Code" prop="packcode">
                  <el-input v-model="form.packcode"
                    :placeholder="$t('btn.enterPrefix')+'Packaging Code'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="危险品的包装状态" prop="dgpackstatus">
                  <el-input v-model="form.dgpackstatus"
                    :placeholder="$t('btn.enterPrefix')+'危险品的包装状态'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料条件管理" prop="mcond">
                  <el-input v-model="form.mcond" :placeholder="$t('btn.enterPrefix')+'物料条件管理'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="返回代码" prop="retdelc">
                  <el-input v-model="form.retdelc" :placeholder="$t('btn.enterPrefix')+'返回代码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="后勤等级退货" prop="loglevreto">
                  <el-input v-model="form.loglevreto"
                    :placeholder="$t('btn.enterPrefix')+'后勤等级退货'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="NATO 项目标识编号" prop="nsnid">
                  <el-input v-model="form.nsnid"
                    :placeholder="$t('btn.enterPrefix')+'NATO 项目标识编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="完全互换组" prop="imatn">
                  <el-input v-model="form.imatn" :placeholder="$t('btn.enterPrefix')+'完全互换组'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="替换链编号" prop="picnum">
                  <UploadImage v-model="form.picnum" :data="{ uploadType: 1 }" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建状态 - 季节性采购" prop="bstat">
                  <el-input v-model="form.bstat"
                    :placeholder="$t('btn.enterPrefix')+'创建状态 - 季节性采购'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="颜色特性的内部特性编号" prop="coloratinn">
                  <el-input-number v-model.number="form.coloratinn" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'颜色特性的内部特性编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="主尺寸的特性的内部特性编号" prop="size1atinn">
                  <el-input-number v-model.number="form.size1atinn" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'主尺寸的特性的内部特性编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="次尺寸的特性的内部特性编号" prop="size2atinn">
                  <el-input-number v-model.number="form.size2atinn" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'次尺寸的特性的内部特性编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="变式颜色的特性值" prop="color">
                  <el-input v-model="form.color"
                    :placeholder="$t('btn.enterPrefix')+'变式颜色的特性值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="变式主尺寸的特性值" prop="size1">
                  <el-input v-model="form.size1"
                    :placeholder="$t('btn.enterPrefix')+'变式主尺寸的特性值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="变式的次尺寸的特性值" prop="size2">
                  <el-input v-model="form.size2"
                    :placeholder="$t('btn.enterPrefix')+'变式的次尺寸的特性值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评估目的的特性值" prop="freechar">
                  <el-input v-model="form.freechar"
                    :placeholder="$t('btn.enterPrefix')+'评估目的的特性值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="护理代码（例如洗涤代码, 烫平衣服代码, 等等)" prop="carecode">
                  <el-input v-model="form.carecode"
                    :placeholder="$t('btn.enterPrefix')+'护理代码（例如洗涤代码, 烫平衣服代码, 等等)'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="商标" prop="brandid">
                  <el-input v-model="form.brandid" :placeholder="$t('btn.enterPrefix')+'商标'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="纺织品的光纤代码（组件1）" prop="fibercode1">
                  <el-input v-model="form.fibercode1"
                    :placeholder="$t('btn.enterPrefix')+'纺织品的光纤代码（组件1）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="光纤的百分比共享（组件1）" prop="fiberpart1">
                  <el-input-number v-model.number="form.fiberpart1" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'光纤的百分比共享（组件1）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="纺织品的光纤代码（组件2）" prop="fibercode2">
                  <el-input v-model="form.fibercode2"
                    :placeholder="$t('btn.enterPrefix')+'纺织品的光纤代码（组件2）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="光纤的百分比共享（组件2）" prop="fiberpart2">
                  <el-input-number v-model.number="form.fiberpart2" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'光纤的百分比共享（组件2）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="纺织品的光纤代码（组件3）" prop="fibercode3">
                  <el-input v-model="form.fibercode3"
                    :placeholder="$t('btn.enterPrefix')+'纺织品的光纤代码（组件3）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="光纤的百分比共享（组件3）" prop="fiberpart3">
                  <el-input-number v-model.number="form.fiberpart3" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'光纤的百分比共享（组件3）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="纺织品的光纤代码（组件4）" prop="fibercode4">
                  <el-input v-model="form.fibercode4"
                    :placeholder="$t('btn.enterPrefix')+'纺织品的光纤代码（组件4）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="光纤的百分比共享（组件4）" prop="fiberpart4">
                  <el-input-number v-model.number="form.fiberpart4" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'光纤的百分比共享（组件4）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="纺织品的光纤代码（组件5）" prop="fibercode5">
                  <el-input v-model="form.fibercode5"
                    :placeholder="$t('btn.enterPrefix')+'纺织品的光纤代码（组件5）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="光纤的百分比共享（组件5）" prop="fiberpart5">
                  <el-input-number v-model.number="form.fiberpart5" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'光纤的百分比共享（组件5）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="时装等级" prop="fashgrd">
                  <el-input v-model="form.fashgrd" :placeholder="$t('btn.enterPrefix')+'时装等级'+$t('btn.enterSuffix')" />
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

              <el-col :lg="12">
                <el-form-item label="备注说明" prop="remark">
                  <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
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

<script setup name="mmmara">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listMmMara,
    addMmMara, delMmMara,
    updateMmMara, getMmMara,
  }
    from '@/api/logistics/mmmara.js'
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
    lvorm: undefined,
    //是否查询（1是）
    mtart: undefined,
    //是否查询（1是）
    mbrsh: undefined,
    //是否查询（1是）
    matkl: undefined,
    //是否查询（1是）
    meins: undefined,
    //是否查询（1是）
    gewei: undefined,
    //是否查询（1是）
    voleh: undefined,
    //是否查询（1是）
    mstae: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'sfid', label: 'ID主键' },
    { visible: true, prop: 'mandt', label: '集团' },
    { visible: true, prop: 'matnr', label: '物料号' },
    { visible: true, prop: 'ersda', label: '创建日期' },
    { visible: true, prop: 'ernam', label: '创建对象的人员名称' },
    { visible: true, prop: 'laeda', label: '上次更改的日期' },
    { visible: true, prop: 'aenam', label: '对象更改人员的名称' },
    { visible: true, prop: 'vpsta', label: '维护全部物料状态' },
    { visible: false, prop: 'pstat', label: '维护状态' },
    { visible: false, prop: 'lvorm', label: '客户级标记' },
    { visible: false, prop: 'mtart', label: '物料类型' },
    { visible: false, prop: 'mbrsh', label: '行业领域' },
    { visible: false, prop: 'matkl', label: '物料组' },
    { visible: false, prop: 'bismt', label: '旧物料号' },
    { visible: false, prop: 'meins', label: '基本计量单位' },
    { visible: false, prop: 'bstme', label: '采购订单的计量单位' },
    { visible: false, prop: 'zeinr', label: '文档号码(无文档管理系统)' },
    { visible: false, prop: 'zeiar', label: '凭证类型(无凭证管理系统)' },
    { visible: false, prop: 'zeivr', label: '文档版本（无文档管理系统）' },
    { visible: false, prop: 'zeifo', label: '文件的页面大小（不包括文件管理系统）' },
    { visible: false, prop: 'aeszn', label: '文档变更号(无文档管理系统)' },
    { visible: false, prop: 'blatt', label: '凭证的页号(不带凭证管理系统)' },
    { visible: false, prop: 'blanz', label: '页数(没有凭证管理系统)' },
    { visible: false, prop: 'ferth', label: '生产/检验备忘录' },
    { visible: false, prop: 'formt', label: '生产备忘录的页格式' },
    { visible: false, prop: 'groes', label: '大小/量纲' },
    { visible: false, prop: 'wrkst', label: '基本物料' },
    { visible: false, prop: 'normt', label: '行业标准描述（例如 ANSI 或 ISO）' },
    { visible: false, prop: 'labor', label: '实验室/设计室' },
    { visible: false, prop: 'ekwsl', label: '采购价值代码' },
    { visible: false, prop: 'brgew', label: '毛重' },
    { visible: false, prop: 'ntgew', label: '净重' },
    { visible: false, prop: 'gewei', label: '重量单位' },
    { visible: false, prop: 'volum', label: '业务量' },
    { visible: false, prop: 'voleh', label: '体积单位' },
    { visible: false, prop: 'behvo', label: '容器需求' },
    { visible: false, prop: 'raube', label: '存储条件' },
    { visible: false, prop: 'tempb', label: '温度条件标识' },
    { visible: false, prop: 'disst', label: '低层代码' },
    { visible: false, prop: 'tragr', label: '运输组' },
    { visible: false, prop: 'stoff', label: '危险物料号' },
    { visible: false, prop: 'spart', label: '产品组' },
    { visible: false, prop: 'kunnr', label: '竞争者' },
    { visible: false, prop: 'eannr', label: '欧洲物品号 (EAN) - 已过时的 !!!!!' },
    { visible: false, prop: 'wesch', label: '数量: 待打印的 GR/GI 单数量' },
    { visible: false, prop: 'bwvor', label: '采购规则' },
    { visible: false, prop: 'bwscl', label: '货源' },
    { visible: false, prop: 'saiso', label: '季节类别' },
    { visible: false, prop: 'etiar', label: '标签类型' },
    { visible: false, prop: 'etifo', label: '标签格式' },
    { visible: false, prop: 'entar', label: '取消激活的' },
    { visible: false, prop: 'ean11', label: '国际文件号(EAN/UPC)' },
    { visible: false, prop: 'numtp', label: '国际商品编码的类别 (EAN)' },
    { visible: false, prop: 'laeng', label: '长度' },
    { visible: false, prop: 'breit', label: '宽度' },
    { visible: false, prop: 'hoehe', label: '高度' },
    { visible: false, prop: 'meabm', label: '长度/宽度/高度的尺寸单位' },
    { visible: false, prop: 'prdha', label: '产品层次' },
    { visible: false, prop: 'aeklk', label: '库存转移净改变成本核算' },
    { visible: false, prop: 'cadkz', label: 'CAD 标识' },
    { visible: false, prop: 'qmpur', label: '激活采购中的 QM' },
    { visible: false, prop: 'ergew', label: '允许的包装重量' },
    { visible: false, prop: 'ergei', label: '加权的单位(允许打包加权)' },
    { visible: false, prop: 'ervol', label: '允许的包装体积' },
    { visible: false, prop: 'ervoe', label: '体积单位(允许打包体积)' },
    { visible: false, prop: 'gewto', label: '处理单位的超重量容差' },
    { visible: false, prop: 'volto', label: '处理单位的超量冗差' },
    { visible: false, prop: 'vabme', label: '可变采购订单单位活动' },
    { visible: false, prop: 'kzrev', label: '标识: 修改水平已分配到物料' },
    { visible: false, prop: 'kzkfg', label: '可配置的物料' },
    { visible: false, prop: 'xchpf', label: '批次管理需求的标识' },
    { visible: false, prop: 'vhart', label: '包装物料类型' },
    { visible: false, prop: 'fuelg', label: '最大层次 (按体积)' },
    { visible: false, prop: 'stfak', label: '堆栈因子' },
    { visible: false, prop: 'magrv', label: '物料组: 包装物料' },
    { visible: false, prop: 'begru', label: '权限组' },
    { visible: false, prop: 'datab', label: '开始生效日期' },
    { visible: false, prop: 'liqdt', label: '删除日期' },
    { visible: false, prop: 'saisj', label: '季度年' },
    { visible: false, prop: 'plgtp', label: '价格标记类别' },
    { visible: false, prop: 'mlgut', label: '空白物料清单' },
    { visible: false, prop: 'extwg', label: '外部物料组' },
    { visible: false, prop: 'satnr', label: '一般可配置物料' },
    { visible: false, prop: 'attyp', label: '物料类别' },
    { visible: false, prop: 'kzkup', label: '指示符 : 物料是联产品' },
    { visible: false, prop: 'kznfm', label: '标记：物料有一后续物料' },
    { visible: false, prop: 'pmata', label: '定价参考物料' },
    { visible: false, prop: 'mstae', label: '跨工厂物料状态' },
    { visible: false, prop: 'mstav', label: '跨分销链物料状态' },
    { visible: false, prop: 'mstde', label: '从跨工厂物料状态有效起的日期' },
    { visible: false, prop: 'mstdv', label: '从跨分销链物料状态有效起的日期' },
    { visible: false, prop: 'taklv', label: '物料从税收分类' },
    { visible: false, prop: 'rbnrm', label: '类别参数文件' },
    { visible: false, prop: 'mhdrz', label: '最短剩余货架寿命' },
    { visible: false, prop: 'mhdhb', label: '总货架寿命' },
    { visible: false, prop: 'mhdlp', label: '仓储百分比' },
    { visible: false, prop: 'inhme', label: '内容单位' },
    { visible: false, prop: 'inhal', label: '净内容' },
    { visible: false, prop: 'vpreh', label: '比较价格单位' },
    { visible: false, prop: 'etiag', label: 'IS-R 标签：物料组（在 4.0 中不活动）' },
    { visible: false, prop: 'inhbr', label: '毛内容' },
    { visible: false, prop: 'cmeth', label: '数量转换方法' },
    { visible: false, prop: 'cuobf', label: '内部对象号' },
    { visible: false, prop: 'kzumw', label: '环境相关' },
    { visible: false, prop: 'kosch', label: '产品分配确定程序' },
    { visible: false, prop: 'sprof', label: '变式的定价参数文件' },
    { visible: false, prop: 'nrfhg', label: '针对物料的折扣类型' },
    { visible: false, prop: 'mfrpn', label: '制造商零件编号' },
    { visible: false, prop: 'mfrnr', label: '制造商编号' },
    { visible: false, prop: 'bmatn', label: '公司自己 (内部) 的盘点管理物料编号' },
    { visible: false, prop: 'mprof', label: '制造商部件参数文件' },
    { visible: false, prop: 'kzwsm', label: '计量单位使用' },
    { visible: false, prop: 'saity', label: '在季节内展开' },
    { visible: false, prop: 'profl', label: '危险货物标识参数文件' },
    { visible: false, prop: 'ihivi', label: '标识符:高粘性的' },
    { visible: false, prop: 'iloos', label: '标识符:固体/液体' },
    { visible: false, prop: 'serlv', label: '序列号的清晰的级别' },
    { visible: false, prop: 'kzgvh', label: '包装物料是密闭包装的' },
    { visible: false, prop: 'xgchp', label: '指示符：需要批准的批量记录' },
    { visible: false, prop: 'kzeff', label: '指定有效参数值/覆盖更改编号' },
    { visible: false, prop: 'compl', label: '物料完成的水平' },
    { visible: false, prop: 'iprkz', label: '货架寿命到期日的期间标识' },
    { visible: false, prop: 'rdmhd', label: '货架寿命到期日期计算舍入规则' },
    { visible: false, prop: 'przus', label: '标识：印刷在包装上的产品成份' },
    { visible: false, prop: 'mtposmara', label: '普通项目类别组' },
    { visible: false, prop: 'bflme', label: '含后勤变量的一般物料' },
    { visible: false, prop: 'matfi', label: '物料被锁定' },
    { visible: false, prop: 'cmrel', label: '与配置管理相关' },
    { visible: false, prop: 'bbtyp', label: '分类清单类型' },
    { visible: false, prop: 'sledbbd', label: '过期日期' },
    { visible: false, prop: 'gtinvariant', label: '全球贸易项目编号变式' },
    { visible: false, prop: 'gennr', label: '在预包装物料中的一般物料的物料编号' },
    { visible: false, prop: 'rmatp', label: '以相同方式包装的物料的参考物料' },
    { visible: false, prop: 'gdsrelevant', label: '标识：全局数据同步相关' },
    { visible: false, prop: 'weora', label: '原始接受' },
    { visible: false, prop: 'hutypdflt', label: '标准处理单位类型' },
    { visible: false, prop: 'pilferable', label: '可偷窃的' },
    { visible: false, prop: 'whstc', label: '仓库存储条件' },
    { visible: false, prop: 'whmatgr', label: '仓库物料组' },
    { visible: false, prop: 'hndlcode', label: '处理标识' },
    { visible: false, prop: 'hazmat', label: '与危险物料相关' },
    { visible: false, prop: 'hutyp', label: '处理单位类型' },
    { visible: false, prop: 'tarevar', label: '可变皮重' },
    { visible: false, prop: 'maxc', label: '包装物料的最大允许容量' },
    { visible: false, prop: 'maxctol', label: '处理单位的最大容量容差' },
    { visible: false, prop: 'maxl', label: '包装物料的最大包长度' },
    { visible: false, prop: 'maxb', label: '包装物料的最大包宽度' },
    { visible: false, prop: 'maxh', label: '包装物料的最大包高度' },
    { visible: false, prop: 'maxdimuom', label: '最大包装长/宽/高的计量单位' },
    { visible: false, prop: 'herkl', label: '物料原产地国家' },
    { visible: false, prop: 'mfrgr', label: '物料运输组' },
    { visible: false, prop: 'qqtime', label: '隔离期间' },
    { visible: false, prop: 'qqtimeuom', label: '隔离期间的时间单位' },
    { visible: false, prop: 'qgrp', label: '质量检查组' },
    { visible: false, prop: 'serial', label: '序列号参数文件' },
    { visible: false, prop: 'pssmartform', label: '表格名' },
    { visible: false, prop: 'logunit', label: 'EWM CW: 后勤计量单位' },
    { visible: false, prop: 'cwqrel', label: 'EWM CW: 物料是称重物料' },
    { visible: false, prop: 'cwqproc', label: 'EWM CW: 输入 CW 数量的称重参数文件' },
    { visible: false, prop: 'cwqtolgr', label: 'EWM-CW: EWM 的称重容差组' },
    { visible: false, prop: 'adprof', label: '调整参数文件' },
    { visible: false, prop: 'ipmipproduct', label: '知识产权标识（CRM 产品）' },
    { visible: false, prop: 'allowpmatigno', label: '允许的变式价格（针对物料主数据）' },
    { visible: false, prop: 'medium', label: '中间' },
    { visible: false, prop: 'commodity', label: '实物商品' },
    { visible: false, prop: 'animalorigin', label: '标识：包含动物源的非纺织部分' },
    { visible: false, prop: 'textilecompind', label: '标识：新纺织组分功能' },
    { visible: false, prop: 'sgtcsgr', label: '分段结构' },
    { visible: false, prop: 'sgtcovsa', label: '分段策略' },
    { visible: false, prop: 'sgtstat', label: '分段物料主数据状态' },
    { visible: false, prop: 'sgtscope', label: '分段策略范围' },
    { visible: false, prop: 'sgtrel', label: '分段相关' },
    { visible: false, prop: 'anp', label: 'ANP Code' },
    { visible: false, prop: 'fshmgat1', label: 'Fashion 信息字段：1' },
    { visible: false, prop: 'fshmgat2', label: 'Fashion 信息字段：2' },
    { visible: false, prop: 'fshmgat3', label: 'Fashion 信息字段：3' },
    { visible: false, prop: 'fshsealv', label: '标识：季节使用' },
    { visible: false, prop: 'fshseaim', label: '标识：在库存管理中激活季节' },
    { visible: false, prop: 'fshscmid', label: '特征值转换的物料转换标识' },
    { visible: false, prop: 'bev1luleinh', label: '装载单位' },
    { visible: false, prop: 'bev1luldegrp', label: '装载单位组：IS 饮料' },
    { visible: false, prop: 'bev1nestruccat', label: '物料关系的结构类别' },
    { visible: false, prop: 'dsdsltoltyp', label: '容差类型标识' },
    { visible: false, prop: 'dsdsvcntgrp', label: '计算组' },
    { visible: false, prop: 'dsdvcgroup', label: 'DSD 分组' },
    { visible: false, prop: 'vsortiltind', label: '可以倾斜物料 (车辆空间优化)' },
    { visible: false, prop: 'vsorstackind', label: '不允许堆栈 (VSO)' },
    { visible: false, prop: 'vsorbotind', label: '底层 (车辆空间最优化)' },
    { visible: false, prop: 'vsortopind', label: '顶层 (VSO)' },
    { visible: false, prop: 'vsorstackno', label: '堆栈因子 (车辆空间优化)' },
    { visible: false, prop: 'vsorpalind', label: '无包装物料的装载 (VSO)' },
    { visible: false, prop: 'vsorpalovrd', label: '包装物料的允许悬挂深度 (VSO)' },
    { visible: false, prop: 'vsorpalovrw', label: '装运物料的允许悬挂宽度 (VSO)' },
    { visible: false, prop: 'vsorpalbht', label: '包装物料的最大叠放高度 (VSO)' },
    { visible: false, prop: 'vsorpalminh', label: '包装物料的最小叠放高度 (VSO)' },
    { visible: false, prop: 'vsortolbht', label: '超出最大叠放高度的容差 (VSO)' },
    { visible: false, prop: 'vsornopgvh', label: '每个已结清 PKM 的物料编号(VSO)' },
    { visible: false, prop: 'vsorquanunit', label: '计量单位车辆空间优化' },
    { visible: false, prop: 'vsorkzgvhind', label: '请求的已清包装物料 (VSO)' },
    { visible: false, prop: 'packcode', label: 'Packaging Code' },
    { visible: false, prop: 'dgpackstatus', label: '危险品的包装状态' },
    { visible: false, prop: 'mcond', label: '物料条件管理' },
    { visible: false, prop: 'retdelc', label: '返回代码' },
    { visible: false, prop: 'loglevreto', label: '后勤等级退货' },
    { visible: false, prop: 'nsnid', label: 'NATO 项目标识编号' },
    { visible: false, prop: 'imatn', label: '完全互换组' },
    { visible: false, prop: 'picnum', label: '替换链编号' },
    { visible: false, prop: 'bstat', label: '创建状态 - 季节性采购' },
    { visible: false, prop: 'coloratinn', label: '颜色特性的内部特性编号' },
    { visible: false, prop: 'size1atinn', label: '主尺寸的特性的内部特性编号' },
    { visible: false, prop: 'size2atinn', label: '次尺寸的特性的内部特性编号' },
    { visible: false, prop: 'color', label: '变式颜色的特性值' },
    { visible: false, prop: 'size1', label: '变式主尺寸的特性值' },
    { visible: false, prop: 'size2', label: '变式的次尺寸的特性值' },
    { visible: false, prop: 'freechar', label: '评估目的的特性值' },
    { visible: false, prop: 'carecode', label: '护理代码（例如洗涤代码, 烫平衣服代码, 等等)' },
    { visible: false, prop: 'brandid', label: '商标' },
    { visible: false, prop: 'fibercode1', label: '纺织品的光纤代码（组件1）' },
    { visible: false, prop: 'fiberpart1', label: '光纤的百分比共享（组件1）' },
    { visible: false, prop: 'fibercode2', label: '纺织品的光纤代码（组件2）' },
    { visible: false, prop: 'fiberpart2', label: '光纤的百分比共享（组件2）' },
    { visible: false, prop: 'fibercode3', label: '纺织品的光纤代码（组件3）' },
    { visible: false, prop: 'fiberpart3', label: '光纤的百分比共享（组件3）' },
    { visible: false, prop: 'fibercode4', label: '纺织品的光纤代码（组件4）' },
    { visible: false, prop: 'fiberpart4', label: '光纤的百分比共享（组件4）' },
    { visible: false, prop: 'fibercode5', label: '纺织品的光纤代码（组件5）' },
    { visible: false, prop: 'fiberpart5', label: '光纤的百分比共享（组件5）' },
    { visible: false, prop: 'fashgrd', label: '时装等级' },
    { visible: false, prop: 'remark', label: '备注说明' },
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
    { dictType: "sys_is_deleted" },
    { dictType: "sys_matl_type" },
    { dictType: "sys_ind_type" },
    { dictType: "sys_matl_group" },
    { dictType: "sys_unit_list" },
    { dictType: "sys_eol_list" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从常规物料/mm_mara表记录数据
  function getList() {
    loading.value = true
    listMmMara(queryParams).then(res => {
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
      lvorm: [{ required: true, message: "客户级标记" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mtart: [{ required: true, message: "物料类型" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mbrsh: [{ required: true, message: "行业领域" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      matkl: [{ required: true, message: "物料组" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      meins: [{ required: true, message: "基本计量单位" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      gewei: [{ required: true, message: "重量单位" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      voleh: [{ required: true, message: "体积单位" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mstae: [{ required: true, message: "跨工厂物料状态" + proxy.$t('btn.isEmpty'), trigger: "change" }],
    },
    options: {
      // 客户级标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_deleted: [],
      // 物料类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_matl_type: [],
      // 行业领域 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ind_type: [],
      // 物料组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_matl_group: [],
      // 基本计量单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_unit_list: [],
      // 跨工厂物料状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_eol_list: [],
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
      ersda: null,
      ernam: null,
      laeda: null,
      aenam: null,
      vpsta: null,
      pstat: null,
      lvorm: null,
      mtart: null,
      mbrsh: null,
      matkl: null,
      bismt: null,
      meins: null,
      bstme: null,
      zeinr: null,
      zeiar: null,
      zeivr: null,
      zeifo: null,
      aeszn: null,
      blatt: null,
      blanz: 0,
      ferth: null,
      formt: null,
      groes: null,
      wrkst: null,
      normt: null,
      labor: null,
      ekwsl: null,
      brgew: 0,
      ntgew: 0,
      gewei: null,
      volum: 0,
      voleh: null,
      behvo: null,
      raube: null,
      tempb: null,
      disst: null,
      tragr: null,
      stoff: null,
      spart: null,
      kunnr: null,
      eannr: null,
      wesch: 0,
      bwvor: null,
      bwscl: null,
      saiso: null,
      etiar: null,
      etifo: null,
      entar: null,
      ean11: null,
      numtp: null,
      laeng: 0,
      breit: 0,
      hoehe: 0,
      meabm: null,
      prdha: null,
      aeklk: null,
      cadkz: null,
      qmpur: null,
      ergew: 0,
      ergei: null,
      ervol: 0,
      ervoe: null,
      gewto: 0,
      volto: 0,
      vabme: null,
      kzrev: null,
      kzkfg: null,
      xchpf: null,
      vhart: null,
      fuelg: 0,
      stfak: 0,
      magrv: null,
      begru: null,
      datab: null,
      liqdt: null,
      saisj: null,
      plgtp: null,
      mlgut: null,
      extwg: null,
      satnr: null,
      attyp: null,
      kzkup: null,
      kznfm: null,
      pmata: null,
      mstae: null,
      mstav: null,
      mstde: null,
      mstdv: null,
      taklv: null,
      rbnrm: null,
      mhdrz: 0,
      mhdhb: 0,
      mhdlp: 0,
      inhme: null,
      inhal: 0,
      vpreh: 0,
      etiag: null,
      inhbr: 0,
      cmeth: null,
      cuobf: 0,
      kzumw: null,
      kosch: null,
      sprof: null,
      nrfhg: null,
      mfrpn: null,
      mfrnr: null,
      bmatn: null,
      mprof: null,
      kzwsm: null,
      saity: null,
      profl: null,
      ihivi: null,
      iloos: null,
      serlv: null,
      kzgvh: null,
      xgchp: null,
      kzeff: null,
      compl: 0,
      iprkz: null,
      rdmhd: null,
      przus: null,
      mtposmara: null,
      bflme: null,
      matfi: null,
      cmrel: null,
      bbtyp: null,
      sledbbd: null,
      gtinvariant: null,
      gennr: null,
      rmatp: null,
      gdsrelevant: null,
      weora: null,
      hutypdflt: null,
      pilferable: null,
      whstc: null,
      whmatgr: null,
      hndlcode: null,
      hazmat: null,
      hutyp: null,
      tarevar: null,
      maxc: 0,
      maxctol: 0,
      maxl: 0,
      maxb: 0,
      maxh: 0,
      maxdimuom: null,
      herkl: null,
      mfrgr: null,
      qqtime: 0,
      qqtimeuom: null,
      qgrp: null,
      serial: null,
      pssmartform: null,
      logunit: null,
      cwqrel: null,
      cwqproc: null,
      cwqtolgr: null,
      adprof: null,
      ipmipproduct: null,
      allowpmatigno: null,
      medium: null,
      commodity: null,
      animalorigin: null,
      textilecompind: null,
      sgtcsgr: null,
      sgtcovsa: null,
      sgtstat: null,
      sgtscope: null,
      sgtrel: null,
      anp: 0,
      fshmgat1: null,
      fshmgat2: null,
      fshmgat3: null,
      fshsealv: null,
      fshseaim: null,
      fshscmid: null,
      bev1luleinh: 0,
      bev1luldegrp: null,
      bev1nestruccat: null,
      dsdsltoltyp: null,
      dsdsvcntgrp: null,
      dsdvcgroup: null,
      vsortiltind: null,
      vsorstackind: null,
      vsorbotind: null,
      vsortopind: null,
      vsorstackno: 0,
      vsorpalind: null,
      vsorpalovrd: 0,
      vsorpalovrw: 0,
      vsorpalbht: 0,
      vsorpalminh: 0,
      vsortolbht: 0,
      vsornopgvh: 0,
      vsorquanunit: null,
      vsorkzgvhind: null,
      packcode: null,
      dgpackstatus: null,
      mcond: null,
      retdelc: null,
      loglevreto: null,
      nsnid: null,
      imatn: null,
      picnum: null,
      bstat: null,
      coloratinn: 0,
      size1atinn: 0,
      size2atinn: 0,
      color: null,
      size1: null,
      size2: null,
      freechar: null,
      carecode: null,
      brandid: null,
      fibercode1: null,
      fiberpart1: 0,
      fibercode2: null,
      fiberpart2: 0,
      fibercode3: null,
      fiberpart3: 0,
      fibercode4: null,
      fiberpart4: 0,
      fibercode5: null,
      fiberpart5: 0,
      fashgrd: null,
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
    title.value = proxy.$t('btn.add') + " " + '常规物料'
    opertype.value = 1
    form.value.ersda = new Date()
    form.value.laeda = new Date()
    form.value.lvorm = []
    form.value.mtart = []
    form.value.mbrsh = []
    form.value.matkl = []
    form.value.meins = []
    form.value.blanz = 0
    form.value.brgew = 0
    form.value.ntgew = 0
    form.value.gewei = []
    form.value.volum = 0
    form.value.voleh = []
    form.value.wesch = 0
    form.value.laeng = 0
    form.value.breit = 0
    form.value.hoehe = 0
    form.value.ergew = 0
    form.value.ervol = 0
    form.value.gewto = 0
    form.value.volto = 0
    form.value.fuelg = 0
    form.value.stfak = 0
    form.value.datab = new Date()
    form.value.liqdt = new Date()
    form.value.mstae = []
    form.value.mstde = new Date()
    form.value.mstdv = new Date()
    form.value.mhdrz = 0
    form.value.mhdhb = 0
    form.value.mhdlp = 0
    form.value.inhal = 0
    form.value.vpreh = 0
    form.value.inhbr = 0
    form.value.cuobf = 0
    form.value.compl = 0
    form.value.maxc = 0
    form.value.maxctol = 0
    form.value.maxl = 0
    form.value.maxb = 0
    form.value.maxh = 0
    form.value.qqtime = 0
    form.value.anp = 0
    form.value.bev1luleinh = 0
    form.value.vsorstackno = 0
    form.value.vsorpalovrd = 0
    form.value.vsorpalovrw = 0
    form.value.vsorpalbht = 0
    form.value.vsorpalminh = 0
    form.value.vsortolbht = 0
    form.value.vsornopgvh = 0
    form.value.coloratinn = 0
    form.value.size1atinn = 0
    form.value.size2atinn = 0
    form.value.fiberpart1 = 0
    form.value.fiberpart2 = 0
    form.value.fiberpart3 = 0
    form.value.fiberpart4 = 0
    form.value.fiberpart5 = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.sfid || ids.value
    getMmMara(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '常规物料'
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
          updateMmMara(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addMmMara(form.value).then((res) => {
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
        return delMmMara(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<常规物料.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/MmMara/export', { ...queryParams })
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