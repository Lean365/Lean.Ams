<!--
 * @Descripttion: 常规物料/mm_mara
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 8:13:28
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
        <el-button class="btn-add" v-hasPermi="['mm:mara:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:mara:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:mara:delete']" plain icon="delete" @click="handleDelete">
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
                <importData
                  templateUrl="Accounting,Logistics,Routine,Statistics/MmMara/importTemplate"
                  importUrl="/Accounting,Logistics,Routine,Statistics/MmMara/importData"
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
      <el-table-column prop="sfid" label="ID主键" align="center" v-if="columns.showColumn('sfid')"/>
      <el-table-column prop="mandt" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mandt')"/>
      <el-table-column prop="matnr" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('matnr')"/>
      <el-table-column prop="ersda" label="创建日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ersda')"/>
      <el-table-column prop="ernam" label="创建对象的人员名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ernam')"/>
      <el-table-column prop="laeda" label="上次更改的日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('laeda')"/>
      <el-table-column prop="aenam" label="对象更改人员的名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('aenam')"/>
      <el-table-column prop="vpsta" label="完整状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vpsta')"/>
      <el-table-column prop="pstat" label="维护状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pstat')"/>
      <el-table-column prop="lvorm" label="集团级的 DF" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('lvorm')"/>
      <el-table-column prop="mtart" label="物料类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mtart')"/>
      <el-table-column prop="mbrsh" label="行业领域" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbrsh')"/>
      <el-table-column prop="matkl" label="物料组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('matkl')"/>
      <el-table-column prop="bismt" label="旧物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bismt')"/>
      <el-table-column prop="meins" label="基本单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('meins')"/>
      <el-table-column prop="bstme" label="订单单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bstme')"/>
      <el-table-column prop="zeinr" label="凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zeinr')"/>
      <el-table-column prop="zeiar" label="凭证类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zeiar')"/>
      <el-table-column prop="zeivr" label="凭证版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zeivr')"/>
      <el-table-column prop="zeifo" label="页面大小" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('zeifo')"/>
      <el-table-column prop="aeszn" label="文档变更号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('aeszn')"/>
      <el-table-column prop="blatt" label="页号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('blatt')"/>
      <el-table-column prop="blanz" label="页数" align="center" v-if="columns.showColumn('blanz')"/>
      <el-table-column prop="ferth" label="生产/检验备忘录" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ferth')"/>
      <el-table-column prop="formt" label="页格式 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('formt')"/>
      <el-table-column prop="groes" label="大小/量纲" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('groes')"/>
      <el-table-column prop="wrkst" label="基本物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('wrkst')"/>
      <el-table-column prop="normt" label="行业标准描述" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('normt')"/>
      <el-table-column prop="labor" label="实验室/办公室 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('labor')"/>
      <el-table-column prop="ekwsl" label="采购值代码 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ekwsl')"/>
      <el-table-column prop="brgew" label="毛重" align="center" v-if="columns.showColumn('brgew')"/>
      <el-table-column prop="ntgew" label="净重 " align="center" v-if="columns.showColumn('ntgew')"/>
      <el-table-column prop="gewei" label="重量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('gewei')"/>
      <el-table-column prop="volum" label="业务量 " align="center" v-if="columns.showColumn('volum')"/>
      <el-table-column prop="voleh" label="体积单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('voleh')"/>
      <el-table-column prop="behvo" label="容器" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('behvo')"/>
      <el-table-column prop="raube" label="存储条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('raube')"/>
      <el-table-column prop="tempb" label="温度" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('tempb')"/>
      <el-table-column prop="disst" label="低层代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('disst')"/>
      <el-table-column prop="tragr" label="运输组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('tragr')"/>
      <el-table-column prop="stoff" label="危险物料号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('stoff')"/>
      <el-table-column prop="spart" label="产品组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('spart')"/>
      <el-table-column prop="kunnr" label="竞争者 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kunnr')"/>
      <el-table-column prop="eannr" label="EAN 号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eannr')"/>
      <el-table-column prop="wesch" label="GR单数量 " align="center" v-if="columns.showColumn('wesch')"/>
      <el-table-column prop="bwvor" label="采购规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bwvor')"/>
      <el-table-column prop="bwscl" label="货源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bwscl')"/>
      <el-table-column prop="saiso" label="季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('saiso')"/>
      <el-table-column prop="etiar" label="标号类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('etiar')"/>
      <el-table-column prop="etifo" label="标签格式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('etifo')"/>
      <el-table-column prop="entar" label="取消激活字段 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('entar')"/>
      <el-table-column prop="eAN11" label="EAN/UPC" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eAN11')"/>
      <el-table-column prop="numtp" label="EAN 类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('numtp')"/>
      <el-table-column prop="laeng" label="长度" align="center" v-if="columns.showColumn('laeng')"/>
      <el-table-column prop="breit" label="宽度" align="center" v-if="columns.showColumn('breit')"/>
      <el-table-column prop="hoehe" label="高度" align="center" v-if="columns.showColumn('hoehe')"/>
      <el-table-column prop="meabm" label="单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('meabm')"/>
      <el-table-column prop="prdha" label="产品层次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('prdha')"/>
      <el-table-column prop="aeklk" label="净改变成本核算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('aeklk')"/>
      <el-table-column prop="cadkz" label="CAD 标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('cadkz')"/>
      <el-table-column prop="qmpur" label="QM 采购" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmpur')"/>
      <el-table-column prop="ergew" label="允许的包装重量" align="center" v-if="columns.showColumn('ergew')"/>
      <el-table-column prop="ergei" label="重量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ergei')"/>
      <el-table-column prop="ervol" label="允许的体积 " align="center" v-if="columns.showColumn('ervol')"/>
      <el-table-column prop="ervoe" label="体积单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ervoe')"/>
      <el-table-column prop="gewto" label="超重量容差 " align="center" v-if="columns.showColumn('gewto')"/>
      <el-table-column prop="volto" label="超过体积容差" align="center" v-if="columns.showColumn('volto')"/>
      <el-table-column prop="vabme" label="可变的订单单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vabme')"/>
      <el-table-column prop="kzrev" label="修订等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kzrev')"/>
      <el-table-column prop="kzkfg" label="可配置 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kzkfg')"/>
      <el-table-column prop="xchpf" label="批次管理需求 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('xchpf')"/>
      <el-table-column prop="vhart" label="包装物料类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vhart')"/>
      <el-table-column prop="fuelg" label="最大层次 " align="center" v-if="columns.showColumn('fuelg')"/>
      <el-table-column prop="stfak" label="堆栈因子" align="center" v-if="columns.showColumn('stfak')"/>
      <el-table-column prop="magrv" label="物料组包装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('magrv')"/>
      <el-table-column prop="begru" label="权限组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('begru')"/>
      <el-table-column prop="datab" label="有效起始日 " :show-overflow-tooltip="true"  v-if="columns.showColumn('datab')"/>
      <el-table-column prop="liqdt" label="有效至 " :show-overflow-tooltip="true"  v-if="columns.showColumn('liqdt')"/>
      <el-table-column prop="saisj" label="季度年 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('saisj')"/>
      <el-table-column prop="plgtp" label="价格标记类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('plgtp')"/>
      <el-table-column prop="mlgut" label="含空BOM" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mlgut')"/>
      <el-table-column prop="extwg" label="外部物料组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('extwg')"/>
      <el-table-column prop="satnr" label="一般可配置物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('satnr')"/>
      <el-table-column prop="attyp" label="物料类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('attyp')"/>
      <el-table-column prop="kzkup" label="联产品 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kzkup')"/>
      <el-table-column prop="kznfm" label="后继的物料 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kznfm')"/>
      <el-table-column prop="pmata" label="定价参考物料 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pmata')"/>
      <el-table-column prop="mstae" label="跨工厂物料状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mstae')"/>
      <el-table-column prop="mstav" label="跨分销链状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mstav')"/>
      <el-table-column prop="mstde" label="有效起始期 " :show-overflow-tooltip="true"  v-if="columns.showColumn('mstde')"/>
      <el-table-column prop="mstdv" label="有效从 " :show-overflow-tooltip="true"  v-if="columns.showColumn('mstdv')"/>
      <el-table-column prop="taklv" label="税收分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('taklv')"/>
      <el-table-column prop="rbnrm" label="类别参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rbnrm')"/>
      <el-table-column prop="mhdrz" label="剩余货架寿命" align="center" v-if="columns.showColumn('mhdrz')"/>
      <el-table-column prop="mhdhb" label="总货架寿命 " align="center" v-if="columns.showColumn('mhdhb')"/>
      <el-table-column prop="mhdlp" label="仓储 %" align="center" v-if="columns.showColumn('mhdlp')"/>
      <el-table-column prop="inhme" label="内容单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('inhme')"/>
      <el-table-column prop="inhal" label="净内容" align="center" v-if="columns.showColumn('inhal')"/>
      <el-table-column prop="vpreh" label="比较价格单位" align="center" v-if="columns.showColumn('vpreh')"/>
      <el-table-column prop="etiag" label="给物料组加标签" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('etiag')"/>
      <el-table-column prop="inhbr" label="毛内容 " align="center" v-if="columns.showColumn('inhbr')"/>
      <el-table-column prop="cmeth" label="转换方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('cmeth')"/>
      <el-table-column prop="cuobf" label="内部对象号 " align="center" v-if="columns.showColumn('cuobf')"/>
      <el-table-column prop="kzumw" label="环境是相关的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kzumw')"/>
      <el-table-column prop="kosch" label="产品分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kosch')"/>
      <el-table-column prop="sprof" label="定价参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sprof')"/>
      <el-table-column prop="nrfhg" label="折扣类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('nrfhg')"/>
      <el-table-column prop="mfrpn" label="制造商零件编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mfrpn')"/>
      <el-table-column prop="mfrnr" label="制造商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mfrnr')"/>
      <el-table-column prop="bmatn" label="内部物料编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bmatn')"/>
      <el-table-column prop="mprof" label="制造商部件参数文" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mprof')"/>
      <el-table-column prop="kzwsm" label="测量单位用法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kzwsm')"/>
      <el-table-column prop="saity" label="展开" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('saity')"/>
      <el-table-column prop="profl" label="DG标识参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('profl')"/>
      <el-table-column prop="ihivi" label="高粘性的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ihivi')"/>
      <el-table-column prop="iloos" label="以大批/液体" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iloos')"/>
      <el-table-column prop="serlv" label="序列化层次 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('serlv')"/>
      <el-table-column prop="kzgvh" label="密闭的 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kzgvh')"/>
      <el-table-column prop="xgchp" label="需要批量记录 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('xgchp')"/>
      <el-table-column prop="kzeff" label="参数有效值· " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kzeff')"/>
      <el-table-column prop="compl" label="完成水平" align="center" v-if="columns.showColumn('compl')"/>
      <el-table-column prop="iprkz" label="期间标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iprkz')"/>
      <el-table-column prop="rdmhd" label="舍入规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rdmhd')"/>
      <el-table-column prop="przus" label="产品成分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('przus')"/>
      <el-table-column prop="mtposMara" label="普通项目类别组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mtposMara')"/>
      <el-table-column prop="bflme" label="后勤变量" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bflme')"/>
      <el-table-column prop="matfi" label="物料被锁定 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('matfi')"/>
      <el-table-column prop="cmrel" label="CM 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('cmrel')"/>
      <el-table-column prop="bbtyp" label="分类清单类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bbtyp')"/>
      <el-table-column prop="sledBbd" label="过期日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sledBbd')"/>
      <el-table-column prop="gtinVariant" label="EAN变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('gtinVariant')"/>
      <el-table-column prop="gennr" label="一般物料 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('gennr')"/>
      <el-table-column prop="rmatp" label="包装的参考物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rmatp')"/>
      <el-table-column prop="gdsRelevant" label="GDS 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('gdsRelevant')"/>
      <el-table-column prop="weora" label="原始接受" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('weora')"/>
      <el-table-column prop="hutypDflt" label="标准处理单位类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('hutypDflt')"/>
      <el-table-column prop="pilferable" label="可偷窃的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pilferable')"/>
      <el-table-column prop="whstc" label="仓库存储条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('whstc')"/>
      <el-table-column prop="whmatgr" label="仓库物料组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('whmatgr')"/>
      <el-table-column prop="hndlcode" label="处理标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('hndlcode')"/>
      <el-table-column prop="hazmat" label="危险物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('hazmat')"/>
      <el-table-column prop="hutyp" label="处理单位类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('hutyp')"/>
      <el-table-column prop="tareVar" label="可变皮重" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('tareVar')"/>
      <el-table-column prop="maxc" label="最大容量 " align="center" v-if="columns.showColumn('maxc')"/>
      <el-table-column prop="maxcTol" label="超过容量容差" align="center" v-if="columns.showColumn('maxcTol')"/>
      <el-table-column prop="maxl" label="最大长度 " align="center" v-if="columns.showColumn('maxl')"/>
      <el-table-column prop="maxb" label="最大包宽度" align="center" v-if="columns.showColumn('maxb')"/>
      <el-table-column prop="maxh" label="最大高度 " align="center" v-if="columns.showColumn('maxh')"/>
      <el-table-column prop="maxdimUom" label="计量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('maxdimUom')"/>
      <el-table-column prop="herkl" label="原产地国" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('herkl')"/>
      <el-table-column prop="mfrgr" label="物料运输组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mfrgr')"/>
      <el-table-column prop="qqtime" label="隔离期间" align="center" v-if="columns.showColumn('qqtime')"/>
      <el-table-column prop="qqtimeuom" label="时间单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qqtimeuom')"/>
      <el-table-column prop="qgrp" label="质量检查组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qgrp')"/>
      <el-table-column prop="serial" label="序列号参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('serial')"/>
      <el-table-column prop="psSmartform" label="表格名 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('psSmartform')"/>
      <el-table-column prop="logunit" label="后勤计量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('logunit')"/>
      <el-table-column prop="cwqrel" label="称重物料相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('cwqrel')"/>
      <el-table-column prop="cwqproc" label="CW 参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('cwqproc')"/>
      <el-table-column prop="cwqtolgr" label="CW 容差组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('cwqtolgr')"/>
      <el-table-column prop="adprof" label="调整参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('adprof')"/>
      <el-table-column prop="ipmipproduct" label="知识产权" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ipmipproduct')"/>
      <el-table-column prop="allowPmatIgno" label="允许的变式价格" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('allowPmatIgno')"/>
      <el-table-column prop="medium" label="中间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('medium')"/>
      <el-table-column prop="commodity" label="实物商品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('commodity')"/>
      <el-table-column prop="animalOrigin" label="动物源 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('animalOrigin')"/>
      <el-table-column prop="textileCompInd" label="纺织组分活动" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('textileCompInd')"/>
      <el-table-column prop="sgtCsgr" label="分段结构" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sgtCsgr')"/>
      <el-table-column prop="sgtCovsa" label="分段策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sgtCovsa')"/>
      <el-table-column prop="sgtStat" label="分段状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sgtStat')"/>
      <el-table-column prop="sgtScope" label="分段范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sgtScope')"/>
      <el-table-column prop="sgtRel" label="分段相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sgtRel')"/>
      <el-table-column prop="anp" label="ANP Code" align="center" v-if="columns.showColumn('anp')"/>
      <el-table-column prop="fshMgAt1" label="Fashion 属性 1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fshMgAt1')"/>
      <el-table-column prop="fshMgAt2" label="Fashion 属性 2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fshMgAt2')"/>
      <el-table-column prop="fshMgAt3" label="Fashion 属性 3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fshMgAt3')"/>
      <el-table-column prop="fshSealv" label="季节使用" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fshSealv')"/>
      <el-table-column prop="fshSeaim" label="库存管理中激活季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fshSeaim')"/>
      <el-table-column prop="fshScMid" label="物料转换标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fshScMid')"/>
      <el-table-column prop="bev1Luleinh" label="装载单位" align="center" v-if="columns.showColumn('bev1Luleinh')"/>
      <el-table-column prop="bev1Luldegrp" label="装载单位组：IS 饮料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bev1Luldegrp')"/>
      <el-table-column prop="bev1Nestruccat" label="物料关系的结构类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bev1Nestruccat')"/>
      <el-table-column prop="dsdSlToltyp" label="容差类型标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dsdSlToltyp')"/>
      <el-table-column prop="dsdSvCntGrp" label="计算组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dsdSvCntGrp')"/>
      <el-table-column prop="dsdVcGroup" label="DSD 分组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('dsdVcGroup')"/>
      <el-table-column prop="vsoRTiltInd" label="可以倾斜物料 (车辆空间优化)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vsoRTiltInd')"/>
      <el-table-column prop="vsoRStackInd" label="不允许堆栈 (VSO)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vsoRStackInd')"/>
      <el-table-column prop="vsoRBotInd" label="底层 (车辆空间最优化)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vsoRBotInd')"/>
      <el-table-column prop="vsoRTopInd" label="顶层 (VSO)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vsoRTopInd')"/>
      <el-table-column prop="vsoRStackNo" label="堆栈因子 (车辆空间优化)" align="center" v-if="columns.showColumn('vsoRStackNo')"/>
      <el-table-column prop="vsoRPalInd" label="无包装物料的装载 (VSO)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vsoRPalInd')"/>
      <el-table-column prop="vsoRPalOvrD" label="包装物料的允许悬挂深度 (VSO)" align="center" v-if="columns.showColumn('vsoRPalOvrD')"/>
      <el-table-column prop="vsoRPalOvrW" label="装运物料的允许悬挂宽度 (VSO)" align="center" v-if="columns.showColumn('vsoRPalOvrW')"/>
      <el-table-column prop="vsoRPalBHt" label="包装物料的最大叠放高度 (VSO)" align="center" v-if="columns.showColumn('vsoRPalBHt')"/>
      <el-table-column prop="vsoRPalMinH" label="包装物料的最小叠放高度 (VSO)" align="center" v-if="columns.showColumn('vsoRPalMinH')"/>
      <el-table-column prop="vsoRTolBHt" label="超出最大叠放高度的容差 (VSO)" align="center" v-if="columns.showColumn('vsoRTolBHt')"/>
      <el-table-column prop="vsoRNoPGvh" label="每个已结清 PKM 的物料编号(VSO)" align="center" v-if="columns.showColumn('vsoRNoPGvh')"/>
      <el-table-column prop="vsoRQuanUnit" label="计量单位车辆空间优化" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vsoRQuanUnit')"/>
      <el-table-column prop="vsoRKzgvhInd" label="请求的已清包装物料 (VSO)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vsoRKzgvhInd')"/>
      <el-table-column prop="packcode" label="Packaging Code" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('packcode')"/>
      <el-table-column prop="dgPackStatus" label="危险品包装状态" align="center" v-if="columns.showColumn('dgPackStatus')">
        <template #default="scope">
          <dict-tag :options=" options.dgPackStatusOptions" :value="scope.row.dgPackStatus"  />
        </template>
      </el-table-column>
      <el-table-column prop="mcond" label="物料条件管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mcond')"/>
      <el-table-column prop="retdelc" label="返回代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('retdelc')"/>
      <el-table-column prop="loglevReto" label="退货到后勤等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('loglevReto')"/>
      <el-table-column prop="nsnid" label="NIIn" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('nsnid')"/>
      <el-table-column prop="imatn" label="完全互换组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('imatn')"/>
      <el-table-column prop="picnum" label="链编号 " align="center" v-if="columns.showColumn('picnum')">
        <template #default="scope">
          <ImagePreview :src="scope.row.picnum"></ImagePreview>
        </template>
      </el-table-column>
      <el-table-column prop="bstat" label="创建状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bstat')"/>
      <el-table-column prop="colorAtinn" label="内部特性 " align="center" v-if="columns.showColumn('colorAtinn')"/>
      <el-table-column prop="size1Atinn" label="内部特性 " align="center" v-if="columns.showColumn('size1Atinn')"/>
      <el-table-column prop="size2Atinn" label="内部特性 " align="center" v-if="columns.showColumn('size2Atinn')"/>
      <el-table-column prop="color" label="颜色" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('color')"/>
      <el-table-column prop="sIZE1" label="主尺寸 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sIZE1')"/>
      <el-table-column prop="sIZE2" label="次尺寸 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sIZE2')"/>
      <el-table-column prop="freeChar" label="特性值 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('freeChar')"/>
      <el-table-column prop="careCode" label="护理代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('careCode')"/>
      <el-table-column prop="brandId" label="商标" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('brandId')"/>
      <el-table-column prop="fiberCode1" label="组件1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fiberCode1')"/>
      <el-table-column prop="fiberPart1" label="百分比共享1" align="center" v-if="columns.showColumn('fiberPart1')"/>
      <el-table-column prop="fiberCode2" label="组件2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fiberCode2')"/>
      <el-table-column prop="fiberPart2" label="百分比共享2" align="center" v-if="columns.showColumn('fiberPart2')"/>
      <el-table-column prop="fiberCode3" label="组件3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fiberCode3')"/>
      <el-table-column prop="fiberPart3" label="百分比共享3" align="center" v-if="columns.showColumn('fiberPart3')"/>
      <el-table-column prop="fiberCode4" label="组件4" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fiberCode4')"/>
      <el-table-column prop="fiberPart4" label="百分比共享4" align="center" v-if="columns.showColumn('fiberPart4')"/>
      <el-table-column prop="fiberCode5" label="组件5" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fiberCode5')"/>
      <el-table-column prop="fiberPart5" label="百分比共享5" align="center" v-if="columns.showColumn('fiberPart5')"/>
      <el-table-column prop="fashgrd" label="时装等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fashgrd')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:mara:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:mara:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改常规物料对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="ID主键" prop="sfid">
              <el-input-number v-model.number="form.sfid" controls-position="right" :placeholder="$t('btn.enterPrefix')+'ID主键'+$t('btn.enterSuffix')" :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团" prop="mandt">
              <el-input v-model="form.mandt" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="matnr">
              <el-input v-model="form.matnr" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建日期" prop="ersda">
              <el-date-picker v-model="form.ersda" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建对象的人员名称" prop="ernam">
              <el-input v-model="form.ernam" :placeholder="$t('btn.enterPrefix')+'创建对象的人员名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上次更改的日期" prop="laeda">
              <el-date-picker v-model="form.laeda" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="对象更改人员的名称" prop="aenam">
              <el-input v-model="form.aenam" :placeholder="$t('btn.enterPrefix')+'对象更改人员的名称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完整状态 " prop="vpsta">
              <el-input v-model="form.vpsta" :placeholder="$t('btn.enterPrefix')+'完整状态 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态 " prop="pstat">
              <el-input v-model="form.pstat" :placeholder="$t('btn.enterPrefix')+'维护状态 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团级的 DF" prop="lvorm">
              <el-input v-model="form.lvorm" :placeholder="$t('btn.enterPrefix')+'集团级的 DF'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类型" prop="mtart">
              <el-input v-model="form.mtart" :placeholder="$t('btn.enterPrefix')+'物料类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业领域" prop="mbrsh">
              <el-input v-model="form.mbrsh" :placeholder="$t('btn.enterPrefix')+'行业领域'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组 " prop="matkl">
              <el-input v-model="form.matkl" :placeholder="$t('btn.enterPrefix')+'物料组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料号" prop="bismt">
              <el-input v-model="form.bismt" :placeholder="$t('btn.enterPrefix')+'旧物料号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="meins">
              <el-input v-model="form.meins" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单单位" prop="bstme">
              <el-input v-model="form.bstme" :placeholder="$t('btn.enterPrefix')+'订单单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证" prop="zeinr">
              <el-input v-model="form.zeinr" :placeholder="$t('btn.enterPrefix')+'凭证'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证类型" prop="zeiar">
              <el-input v-model="form.zeiar" :placeholder="$t('btn.enterPrefix')+'凭证类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证版本" prop="zeivr">
              <el-input v-model="form.zeivr" :placeholder="$t('btn.enterPrefix')+'凭证版本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页面大小" prop="zeifo">
              <el-input v-model="form.zeifo" :placeholder="$t('btn.enterPrefix')+'页面大小'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="文档变更号 " prop="aeszn">
              <el-input v-model="form.aeszn" :placeholder="$t('btn.enterPrefix')+'文档变更号 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页号" prop="blatt">
              <el-input v-model="form.blatt" :placeholder="$t('btn.enterPrefix')+'页号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="页数" prop="blanz">
              <el-input v-model.number="form.blanz" :placeholder="$t('btn.enterPrefix')+'页数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产/检验备忘录" prop="ferth">
              <el-input v-model="form.ferth" :placeholder="$t('btn.enterPrefix')+'生产/检验备忘录'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页格式 " prop="formt">
              <el-input v-model="form.formt" :placeholder="$t('btn.enterPrefix')+'页格式 '+$t('btn.enterSuffix')" />
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
            <el-form-item label="行业标准描述" prop="normt">
              <el-input v-model="form.normt" :placeholder="$t('btn.enterPrefix')+'行业标准描述'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实验室/办公室 " prop="labor">
              <el-input v-model="form.labor" :placeholder="$t('btn.enterPrefix')+'实验室/办公室 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购值代码 " prop="ekwsl">
              <el-input v-model="form.ekwsl" :placeholder="$t('btn.enterPrefix')+'采购值代码 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="毛重" prop="brgew">
              <el-input v-model="form.brgew" :placeholder="$t('btn.enterPrefix')+'毛重'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净重 " prop="ntgew">
              <el-input v-model="form.ntgew" :placeholder="$t('btn.enterPrefix')+'净重 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重量单位" prop="gewei">
              <el-input v-model="form.gewei" :placeholder="$t('btn.enterPrefix')+'重量单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="业务量 " prop="volum">
              <el-input v-model="form.volum" :placeholder="$t('btn.enterPrefix')+'业务量 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="体积单位" prop="voleh">
              <el-input v-model="form.voleh" :placeholder="$t('btn.enterPrefix')+'体积单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="容器" prop="behvo">
              <el-input v-model="form.behvo" :placeholder="$t('btn.enterPrefix')+'容器'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="存储条件" prop="raube">
              <el-input v-model="form.raube" :placeholder="$t('btn.enterPrefix')+'存储条件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="温度" prop="tempb">
              <el-input v-model="form.tempb" :placeholder="$t('btn.enterPrefix')+'温度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="低层代码" prop="disst">
              <el-input v-model="form.disst" :placeholder="$t('btn.enterPrefix')+'低层代码'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="运输组 " prop="tragr">
              <el-input v-model="form.tragr" :placeholder="$t('btn.enterPrefix')+'运输组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险物料号 " prop="stoff">
              <el-input v-model="form.stoff" :placeholder="$t('btn.enterPrefix')+'危险物料号 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品组 " prop="spart">
              <el-input v-model="form.spart" :placeholder="$t('btn.enterPrefix')+'产品组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="竞争者 " prop="kunnr">
              <el-input v-model="form.kunnr" :placeholder="$t('btn.enterPrefix')+'竞争者 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN 号 " prop="eannr">
              <el-input v-model="form.eannr" :placeholder="$t('btn.enterPrefix')+'EAN 号 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="GR单数量 " prop="wesch">
              <el-input v-model="form.wesch" :placeholder="$t('btn.enterPrefix')+'GR单数量 '+$t('btn.enterSuffix')" />
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
            <el-form-item label="季节" prop="saiso">
              <el-input v-model="form.saiso" :placeholder="$t('btn.enterPrefix')+'季节'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标号类型" prop="etiar">
              <el-input v-model="form.etiar" :placeholder="$t('btn.enterPrefix')+'标号类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标签格式" prop="etifo">
              <el-input v-model="form.etifo" :placeholder="$t('btn.enterPrefix')+'标签格式'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="取消激活字段 " prop="entar">
              <el-input v-model="form.entar" :placeholder="$t('btn.enterPrefix')+'取消激活字段 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN/UPC" prop="eAN11">
              <el-input v-model="form.eAN11" :placeholder="$t('btn.enterPrefix')+'EAN/UPC'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN 类别" prop="numtp">
              <el-input v-model="form.numtp" :placeholder="$t('btn.enterPrefix')+'EAN 类别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="长度" prop="laeng">
              <el-input v-model="form.laeng" :placeholder="$t('btn.enterPrefix')+'长度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="宽度" prop="breit">
              <el-input v-model="form.breit" :placeholder="$t('btn.enterPrefix')+'宽度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="高度" prop="hoehe">
              <el-input v-model="form.hoehe" :placeholder="$t('btn.enterPrefix')+'高度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位" prop="meabm">
              <el-input v-model="form.meabm" :placeholder="$t('btn.enterPrefix')+'单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品层次" prop="prdha">
              <el-input v-model="form.prdha" :placeholder="$t('btn.enterPrefix')+'产品层次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净改变成本核算" prop="aeklk">
              <el-input v-model="form.aeklk" :placeholder="$t('btn.enterPrefix')+'净改变成本核算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CAD 标识" prop="cadkz">
              <el-input v-model="form.cadkz" :placeholder="$t('btn.enterPrefix')+'CAD 标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QM 采购" prop="qmpur">
              <el-input v-model="form.qmpur" :placeholder="$t('btn.enterPrefix')+'QM 采购'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的包装重量" prop="ergew">
              <el-input v-model="form.ergew" :placeholder="$t('btn.enterPrefix')+'允许的包装重量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重量单位" prop="ergei">
              <el-input v-model="form.ergei" :placeholder="$t('btn.enterPrefix')+'重量单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的体积 " prop="ervol">
              <el-input v-model="form.ervol" :placeholder="$t('btn.enterPrefix')+'允许的体积 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="体积单位" prop="ervoe">
              <el-input v-model="form.ervoe" :placeholder="$t('btn.enterPrefix')+'体积单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超重量容差 " prop="gewto">
              <el-input v-model="form.gewto" :placeholder="$t('btn.enterPrefix')+'超重量容差 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超过体积容差" prop="volto">
              <el-input v-model="form.volto" :placeholder="$t('btn.enterPrefix')+'超过体积容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可变的订单单位" prop="vabme">
              <el-input v-model="form.vabme" :placeholder="$t('btn.enterPrefix')+'可变的订单单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="修订等级" prop="kzrev">
              <el-input v-model="form.kzrev" :placeholder="$t('btn.enterPrefix')+'修订等级'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可配置 " prop="kzkfg">
              <el-input v-model="form.kzkfg" :placeholder="$t('btn.enterPrefix')+'可配置 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理需求 " prop="xchpf">
              <el-input v-model="form.xchpf" :placeholder="$t('btn.enterPrefix')+'批次管理需求 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装物料类型" prop="vhart">
              <el-input v-model="form.vhart" :placeholder="$t('btn.enterPrefix')+'包装物料类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大层次 " prop="fuelg">
              <el-input v-model="form.fuelg" :placeholder="$t('btn.enterPrefix')+'最大层次 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="堆栈因子" prop="stfak">
              <el-input v-model.number="form.stfak" :placeholder="$t('btn.enterPrefix')+'堆栈因子'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组包装物料" prop="magrv">
              <el-input v-model="form.magrv" :placeholder="$t('btn.enterPrefix')+'物料组包装物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="权限组 " prop="begru">
              <el-input v-model="form.begru" :placeholder="$t('btn.enterPrefix')+'权限组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始日 " prop="datab">
              <el-date-picker v-model="form.datab" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效至 " prop="liqdt">
              <el-date-picker v-model="form.liqdt" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季度年 " prop="saisj">
              <el-input v-model="form.saisj" :placeholder="$t('btn.enterPrefix')+'季度年 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格标记类型" prop="plgtp">
              <el-input v-model="form.plgtp" :placeholder="$t('btn.enterPrefix')+'价格标记类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="含空BOM" prop="mlgut">
              <el-input v-model="form.mlgut" :placeholder="$t('btn.enterPrefix')+'含空BOM'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部物料组 " prop="extwg">
              <el-input v-model="form.extwg" :placeholder="$t('btn.enterPrefix')+'外部物料组 '+$t('btn.enterSuffix')" />
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
            <el-form-item label="联产品 " prop="kzkup">
              <el-input v-model="form.kzkup" :placeholder="$t('btn.enterPrefix')+'联产品 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后继的物料 " prop="kznfm">
              <el-input v-model="form.kznfm" :placeholder="$t('btn.enterPrefix')+'后继的物料 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="定价参考物料 " prop="pmata">
              <el-input v-model="form.pmata" :placeholder="$t('btn.enterPrefix')+'定价参考物料 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨工厂物料状态" prop="mstae">
              <el-input v-model="form.mstae" :placeholder="$t('btn.enterPrefix')+'跨工厂物料状态'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨分销链状态 " prop="mstav">
              <el-input v-model="form.mstav" :placeholder="$t('btn.enterPrefix')+'跨分销链状态 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始期 " prop="mstde">
              <el-date-picker v-model="form.mstde" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效从 " prop="mstdv">
              <el-date-picker v-model="form.mstdv" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税收分类" prop="taklv">
              <el-input v-model="form.taklv" :placeholder="$t('btn.enterPrefix')+'税收分类'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别参数文件" prop="rbnrm">
              <el-input v-model="form.rbnrm" :placeholder="$t('btn.enterPrefix')+'类别参数文件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="剩余货架寿命" prop="mhdrz">
              <el-input v-model="form.mhdrz" :placeholder="$t('btn.enterPrefix')+'剩余货架寿命'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总货架寿命 " prop="mhdhb">
              <el-input v-model="form.mhdhb" :placeholder="$t('btn.enterPrefix')+'总货架寿命 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓储 %" prop="mhdlp">
              <el-input v-model="form.mhdlp" :placeholder="$t('btn.enterPrefix')+'仓储 %'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内容单位" prop="inhme">
              <el-input v-model="form.inhme" :placeholder="$t('btn.enterPrefix')+'内容单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净内容" prop="inhal">
              <el-input v-model="form.inhal" :placeholder="$t('btn.enterPrefix')+'净内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="比较价格单位" prop="vpreh">
              <el-input v-model="form.vpreh" :placeholder="$t('btn.enterPrefix')+'比较价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="给物料组加标签" prop="etiag">
              <el-input v-model="form.etiag" :placeholder="$t('btn.enterPrefix')+'给物料组加标签'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="毛内容 " prop="inhbr">
              <el-input v-model="form.inhbr" :placeholder="$t('btn.enterPrefix')+'毛内容 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转换方法" prop="cmeth">
              <el-input v-model="form.cmeth" :placeholder="$t('btn.enterPrefix')+'转换方法'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部对象号 " prop="cuobf">
              <el-input v-model.number="form.cuobf" :placeholder="$t('btn.enterPrefix')+'内部对象号 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="环境是相关的" prop="kzumw">
              <el-input v-model="form.kzumw" :placeholder="$t('btn.enterPrefix')+'环境是相关的'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品分配" prop="kosch">
              <el-input v-model="form.kosch" :placeholder="$t('btn.enterPrefix')+'产品分配'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="定价参数文件" prop="sprof">
              <el-input v-model="form.sprof" :placeholder="$t('btn.enterPrefix')+'定价参数文件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折扣类型" prop="nrfhg">
              <el-input v-model="form.nrfhg" :placeholder="$t('btn.enterPrefix')+'折扣类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商零件编号" prop="mfrpn">
              <el-input v-model="form.mfrpn" :placeholder="$t('btn.enterPrefix')+'制造商零件编号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="mfrnr">
              <el-input v-model="form.mfrnr" :placeholder="$t('btn.enterPrefix')+'制造商'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部物料编号" prop="bmatn">
              <el-input v-model="form.bmatn" :placeholder="$t('btn.enterPrefix')+'内部物料编号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商部件参数文" prop="mprof">
              <el-input v-model="form.mprof" :placeholder="$t('btn.enterPrefix')+'制造商部件参数文'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="测量单位用法" prop="kzwsm">
              <el-input v-model="form.kzwsm" :placeholder="$t('btn.enterPrefix')+'测量单位用法'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="展开" prop="saity">
              <el-input v-model="form.saity" :placeholder="$t('btn.enterPrefix')+'展开'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="DG标识参数文件" prop="profl">
              <el-input v-model="form.profl" :placeholder="$t('btn.enterPrefix')+'DG标识参数文件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="高粘性的" prop="ihivi">
              <el-input v-model="form.ihivi" :placeholder="$t('btn.enterPrefix')+'高粘性的'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="以大批/液体" prop="iloos">
              <el-input v-model="form.iloos" :placeholder="$t('btn.enterPrefix')+'以大批/液体'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列化层次 " prop="serlv">
              <el-input v-model="form.serlv" :placeholder="$t('btn.enterPrefix')+'序列化层次 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="密闭的 " prop="kzgvh">
              <el-input v-model="form.kzgvh" :placeholder="$t('btn.enterPrefix')+'密闭的 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="需要批量记录 " prop="xgchp">
              <el-input v-model="form.xgchp" :placeholder="$t('btn.enterPrefix')+'需要批量记录 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参数有效值· " prop="kzeff">
              <el-input v-model="form.kzeff" :placeholder="$t('btn.enterPrefix')+'参数有效值· '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="完成水平" prop="compl">
              <el-input v-model.number="form.compl" :placeholder="$t('btn.enterPrefix')+'完成水平'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间标识" prop="iprkz">
              <el-input v-model="form.iprkz" :placeholder="$t('btn.enterPrefix')+'期间标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入规则" prop="rdmhd">
              <el-input v-model="form.rdmhd" :placeholder="$t('btn.enterPrefix')+'舍入规则'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品成分" prop="przus">
              <el-input v-model="form.przus" :placeholder="$t('btn.enterPrefix')+'产品成分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="普通项目类别组" prop="mtposMara">
              <el-input v-model="form.mtposMara" :placeholder="$t('btn.enterPrefix')+'普通项目类别组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤变量" prop="bflme">
              <el-input v-model="form.bflme" :placeholder="$t('btn.enterPrefix')+'后勤变量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料被锁定 " prop="matfi">
              <el-input v-model="form.matfi" :placeholder="$t('btn.enterPrefix')+'物料被锁定 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CM 相关" prop="cmrel">
              <el-input v-model="form.cmrel" :placeholder="$t('btn.enterPrefix')+'CM 相关'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分类清单类型" prop="bbtyp">
              <el-input v-model="form.bbtyp" :placeholder="$t('btn.enterPrefix')+'分类清单类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过期日期" prop="sledBbd">
              <el-input v-model="form.sledBbd" :placeholder="$t('btn.enterPrefix')+'过期日期'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN变式" prop="gtinVariant">
              <el-input v-model="form.gtinVariant" :placeholder="$t('btn.enterPrefix')+'EAN变式'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般物料 " prop="gennr">
              <el-input v-model="form.gennr" :placeholder="$t('btn.enterPrefix')+'一般物料 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装的参考物料" prop="rmatp">
              <el-input v-model="form.rmatp" :placeholder="$t('btn.enterPrefix')+'包装的参考物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="GDS 相关" prop="gdsRelevant">
              <el-input v-model="form.gdsRelevant" :placeholder="$t('btn.enterPrefix')+'GDS 相关'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原始接受" prop="weora">
              <el-input v-model="form.weora" :placeholder="$t('btn.enterPrefix')+'原始接受'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准处理单位类" prop="hutypDflt">
              <el-input v-model="form.hutypDflt" :placeholder="$t('btn.enterPrefix')+'标准处理单位类'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可偷窃的" prop="pilferable">
              <el-input v-model="form.pilferable" :placeholder="$t('btn.enterPrefix')+'可偷窃的'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库存储条件" prop="whstc">
              <el-input v-model="form.whstc" :placeholder="$t('btn.enterPrefix')+'仓库存储条件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库物料组 " prop="whmatgr">
              <el-input v-model="form.whmatgr" :placeholder="$t('btn.enterPrefix')+'仓库物料组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理标识" prop="hndlcode">
              <el-input v-model="form.hndlcode" :placeholder="$t('btn.enterPrefix')+'处理标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险物料" prop="hazmat">
              <el-input v-model="form.hazmat" :placeholder="$t('btn.enterPrefix')+'危险物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理单位类型" prop="hutyp">
              <el-input v-model="form.hutyp" :placeholder="$t('btn.enterPrefix')+'处理单位类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可变皮重" prop="tareVar">
              <el-input v-model="form.tareVar" :placeholder="$t('btn.enterPrefix')+'可变皮重'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大容量 " prop="maxc">
              <el-input v-model="form.maxc" :placeholder="$t('btn.enterPrefix')+'最大容量 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超过容量容差" prop="maxcTol">
              <el-input v-model="form.maxcTol" :placeholder="$t('btn.enterPrefix')+'超过容量容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大长度 " prop="maxl">
              <el-input v-model="form.maxl" :placeholder="$t('btn.enterPrefix')+'最大长度 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大包宽度" prop="maxb">
              <el-input v-model="form.maxb" :placeholder="$t('btn.enterPrefix')+'最大包宽度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大高度 " prop="maxh">
              <el-input v-model="form.maxh" :placeholder="$t('btn.enterPrefix')+'最大高度 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位" prop="maxdimUom">
              <el-input v-model="form.maxdimUom" :placeholder="$t('btn.enterPrefix')+'计量单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原产地国" prop="herkl">
              <el-input v-model="form.herkl" :placeholder="$t('btn.enterPrefix')+'原产地国'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料运输组 " prop="mfrgr">
              <el-input v-model="form.mfrgr" :placeholder="$t('btn.enterPrefix')+'物料运输组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="隔离期间" prop="qqtime">
              <el-input v-model="form.qqtime" :placeholder="$t('btn.enterPrefix')+'隔离期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时间单位" prop="qqtimeuom">
              <el-input v-model="form.qqtimeuom" :placeholder="$t('btn.enterPrefix')+'时间单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="质量检查组" prop="qgrp">
              <el-input v-model="form.qgrp" :placeholder="$t('btn.enterPrefix')+'质量检查组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号参数文件" prop="serial">
              <el-input v-model="form.serial" :placeholder="$t('btn.enterPrefix')+'序列号参数文件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="表格名 " prop="psSmartform">
              <el-input v-model="form.psSmartform" :placeholder="$t('btn.enterPrefix')+'表格名 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤计量单位" prop="logunit">
              <el-input v-model="form.logunit" :placeholder="$t('btn.enterPrefix')+'后勤计量单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="称重物料相关" prop="cwqrel">
              <el-input v-model="form.cwqrel" :placeholder="$t('btn.enterPrefix')+'称重物料相关'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CW 参数文件" prop="cwqproc">
              <el-input v-model="form.cwqproc" :placeholder="$t('btn.enterPrefix')+'CW 参数文件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CW 容差组 " prop="cwqtolgr">
              <el-input v-model="form.cwqtolgr" :placeholder="$t('btn.enterPrefix')+'CW 容差组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="调整参数文件" prop="adprof">
              <el-input v-model="form.adprof" :placeholder="$t('btn.enterPrefix')+'调整参数文件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="知识产权" prop="ipmipproduct">
              <el-input v-model="form.ipmipproduct" :placeholder="$t('btn.enterPrefix')+'知识产权'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的变式价格" prop="allowPmatIgno">
              <el-input v-model="form.allowPmatIgno" :placeholder="$t('btn.enterPrefix')+'允许的变式价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="中间" prop="medium">
              <el-input v-model="form.medium" :placeholder="$t('btn.enterPrefix')+'中间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实物商品" prop="commodity">
              <el-input v-model="form.commodity" :placeholder="$t('btn.enterPrefix')+'实物商品'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="动物源 " prop="animalOrigin">
              <el-input v-model="form.animalOrigin" :placeholder="$t('btn.enterPrefix')+'动物源 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="纺织组分活动" prop="textileCompInd">
              <el-input v-model="form.textileCompInd" :placeholder="$t('btn.enterPrefix')+'纺织组分活动'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段结构" prop="sgtCsgr">
              <el-input v-model="form.sgtCsgr" :placeholder="$t('btn.enterPrefix')+'分段结构'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段策略" prop="sgtCovsa">
              <el-input v-model="form.sgtCovsa" :placeholder="$t('btn.enterPrefix')+'分段策略'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段状态 " prop="sgtStat">
              <el-input v-model="form.sgtStat" :placeholder="$t('btn.enterPrefix')+'分段状态 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段范围" prop="sgtScope">
              <el-input v-model="form.sgtScope" :placeholder="$t('btn.enterPrefix')+'分段范围'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段相关" prop="sgtRel">
              <el-input v-model="form.sgtRel" :placeholder="$t('btn.enterPrefix')+'分段相关'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="ANP Code" prop="anp">
              <el-input v-model.number="form.anp" :placeholder="$t('btn.enterPrefix')+'ANP Code'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion 属性 1" prop="fshMgAt1">
              <el-input v-model="form.fshMgAt1" :placeholder="$t('btn.enterPrefix')+'Fashion 属性 1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion 属性 2" prop="fshMgAt2">
              <el-input v-model="form.fshMgAt2" :placeholder="$t('btn.enterPrefix')+'Fashion 属性 2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion 属性 3" prop="fshMgAt3">
              <el-input v-model="form.fshMgAt3" :placeholder="$t('btn.enterPrefix')+'Fashion 属性 3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季节使用" prop="fshSealv">
              <el-input v-model="form.fshSealv" :placeholder="$t('btn.enterPrefix')+'季节使用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存管理中激活季节" prop="fshSeaim">
              <el-input v-model="form.fshSeaim" :placeholder="$t('btn.enterPrefix')+'库存管理中激活季节'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料转换标识" prop="fshScMid">
              <el-input v-model="form.fshScMid" :placeholder="$t('btn.enterPrefix')+'物料转换标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="装载单位" prop="bev1Luleinh">
              <el-input v-model.number="form.bev1Luleinh" :placeholder="$t('btn.enterPrefix')+'装载单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装载单位组：IS 饮料" prop="bev1Luldegrp">
              <el-input v-model="form.bev1Luldegrp" :placeholder="$t('btn.enterPrefix')+'装载单位组：IS 饮料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料关系的结构类别" prop="bev1Nestruccat">
              <el-input v-model="form.bev1Nestruccat" :placeholder="$t('btn.enterPrefix')+'物料关系的结构类别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="容差类型标识" prop="dsdSlToltyp">
              <el-input v-model="form.dsdSlToltyp" :placeholder="$t('btn.enterPrefix')+'容差类型标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计算组" prop="dsdSvCntGrp">
              <el-input v-model="form.dsdSvCntGrp" :placeholder="$t('btn.enterPrefix')+'计算组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="DSD 分组" prop="dsdVcGroup">
              <el-input v-model="form.dsdVcGroup" :placeholder="$t('btn.enterPrefix')+'DSD 分组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可以倾斜物料 (车辆空间优化)" prop="vsoRTiltInd">
              <el-input v-model="form.vsoRTiltInd" :placeholder="$t('btn.enterPrefix')+'可以倾斜物料 (车辆空间优化)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不允许堆栈 (VSO)" prop="vsoRStackInd">
              <el-input v-model="form.vsoRStackInd" :placeholder="$t('btn.enterPrefix')+'不允许堆栈 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="底层 (车辆空间最优化)" prop="vsoRBotInd">
              <el-input v-model="form.vsoRBotInd" :placeholder="$t('btn.enterPrefix')+'底层 (车辆空间最优化)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顶层 (VSO)" prop="vsoRTopInd">
              <el-input v-model="form.vsoRTopInd" :placeholder="$t('btn.enterPrefix')+'顶层 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="堆栈因子 (车辆空间优化)" prop="vsoRStackNo">
              <el-input v-model.number="form.vsoRStackNo" :placeholder="$t('btn.enterPrefix')+'堆栈因子 (车辆空间优化)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="无包装物料的装载 (VSO)" prop="vsoRPalInd">
              <el-input v-model="form.vsoRPalInd" :placeholder="$t('btn.enterPrefix')+'无包装物料的装载 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装物料的允许悬挂深度 (VSO)" prop="vsoRPalOvrD">
              <el-input v-model="form.vsoRPalOvrD" :placeholder="$t('btn.enterPrefix')+'包装物料的允许悬挂深度 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装运物料的允许悬挂宽度 (VSO)" prop="vsoRPalOvrW">
              <el-input v-model="form.vsoRPalOvrW" :placeholder="$t('btn.enterPrefix')+'装运物料的允许悬挂宽度 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装物料的最大叠放高度 (VSO)" prop="vsoRPalBHt">
              <el-input v-model="form.vsoRPalBHt" :placeholder="$t('btn.enterPrefix')+'包装物料的最大叠放高度 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装物料的最小叠放高度 (VSO)" prop="vsoRPalMinH">
              <el-input v-model="form.vsoRPalMinH" :placeholder="$t('btn.enterPrefix')+'包装物料的最小叠放高度 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超出最大叠放高度的容差 (VSO)" prop="vsoRTolBHt">
              <el-input v-model="form.vsoRTolBHt" :placeholder="$t('btn.enterPrefix')+'超出最大叠放高度的容差 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="每个已结清 PKM 的物料编号(VSO)" prop="vsoRNoPGvh">
              <el-input v-model.number="form.vsoRNoPGvh" :placeholder="$t('btn.enterPrefix')+'每个已结清 PKM 的物料编号(VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位车辆空间优化" prop="vsoRQuanUnit">
              <el-input v-model="form.vsoRQuanUnit" :placeholder="$t('btn.enterPrefix')+'计量单位车辆空间优化'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求的已清包装物料 (VSO)" prop="vsoRKzgvhInd">
              <el-input v-model="form.vsoRKzgvhInd" :placeholder="$t('btn.enterPrefix')+'请求的已清包装物料 (VSO)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Packaging Code" prop="packcode">
              <el-input v-model="form.packcode" :placeholder="$t('btn.enterPrefix')+'Packaging Code'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险品包装状态" prop="dgPackStatus">
              <el-radio-group v-model="form.dgPackStatus">
                <el-radio v-for="item in options.dgPackStatusOptions" :key="item.dictValue" :value="item.dictValue">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
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
            <el-form-item label="退货到后勤等级" prop="loglevReto">
              <el-input v-model="form.loglevReto" :placeholder="$t('btn.enterPrefix')+'退货到后勤等级'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="NIIn" prop="nsnid">
              <el-input v-model="form.nsnid" :placeholder="$t('btn.enterPrefix')+'NIIn'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完全互换组 " prop="imatn">
              <el-input v-model="form.imatn" :placeholder="$t('btn.enterPrefix')+'完全互换组 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="链编号 " prop="picnum">
              <UploadImage v-model="form.picnum" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建状态 " prop="bstat">
              <el-input v-model="form.bstat" :placeholder="$t('btn.enterPrefix')+'创建状态 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部特性 " prop="colorAtinn">
              <el-input v-model.number="form.colorAtinn" :placeholder="$t('btn.enterPrefix')+'内部特性 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部特性 " prop="size1Atinn">
              <el-input v-model.number="form.size1Atinn" :placeholder="$t('btn.enterPrefix')+'内部特性 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部特性 " prop="size2Atinn">
              <el-input v-model.number="form.size2Atinn" :placeholder="$t('btn.enterPrefix')+'内部特性 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="颜色" prop="color">
              <el-input v-model="form.color" :placeholder="$t('btn.enterPrefix')+'颜色'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="主尺寸 " prop="sIZE1">
              <el-input v-model="form.sIZE1" :placeholder="$t('btn.enterPrefix')+'主尺寸 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="次尺寸 " prop="sIZE2">
              <el-input v-model="form.sIZE2" :placeholder="$t('btn.enterPrefix')+'次尺寸 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特性值 " prop="freeChar">
              <el-input v-model="form.freeChar" :placeholder="$t('btn.enterPrefix')+'特性值 '+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="护理代码" prop="careCode">
              <el-input v-model="form.careCode" :placeholder="$t('btn.enterPrefix')+'护理代码'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商标" prop="brandId">
              <el-input v-model="form.brandId" :placeholder="$t('btn.enterPrefix')+'商标'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件1" prop="fiberCode1">
              <el-input v-model="form.fiberCode1" :placeholder="$t('btn.enterPrefix')+'组件1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享1" prop="fiberPart1">
              <el-input v-model.number="form.fiberPart1" :placeholder="$t('btn.enterPrefix')+'百分比共享1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件2" prop="fiberCode2">
              <el-input v-model="form.fiberCode2" :placeholder="$t('btn.enterPrefix')+'组件2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享2" prop="fiberPart2">
              <el-input v-model.number="form.fiberPart2" :placeholder="$t('btn.enterPrefix')+'百分比共享2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件3" prop="fiberCode3">
              <el-input v-model="form.fiberCode3" :placeholder="$t('btn.enterPrefix')+'组件3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享3" prop="fiberPart3">
              <el-input v-model.number="form.fiberPart3" :placeholder="$t('btn.enterPrefix')+'百分比共享3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件4" prop="fiberCode4">
              <el-input v-model="form.fiberCode4" :placeholder="$t('btn.enterPrefix')+'组件4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享4" prop="fiberPart4">
              <el-input v-model.number="form.fiberPart4" :placeholder="$t('btn.enterPrefix')+'百分比共享4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件5" prop="fiberCode5">
              <el-input v-model="form.fiberCode5" :placeholder="$t('btn.enterPrefix')+'组件5'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享5" prop="fiberPart5">
              <el-input v-model.number="form.fiberPart5" :placeholder="$t('btn.enterPrefix')+'百分比共享5'+$t('btn.enterSuffix')" />
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
              <el-input v-model="form.uDF51" :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input v-model="form.uDF52" :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input v-model="form.uDF53" :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input v-model="form.uDF54" :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input v-model="form.uDF55" :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input v-model="form.uDF56" :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.isDeletedOptions" :key="item.dictValue" :value="parseInt(item.dictValue)">
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

<script setup name="mmmara">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listMmMara,
 addMmMara, delMmMara, 
 updateMmMara,getMmMara, 
 } 
from '@/api/accounting,Logistics,Routine,Statistics/mmmara.js'
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
  { visible: true, prop: 'sfid', label: 'ID主键' },
  { visible: true, prop: 'mandt', label: '集团' },
  { visible: true, prop: 'matnr', label: '物料' },
  { visible: true, prop: 'ersda', label: '创建日期' },
  { visible: true, prop: 'ernam', label: '创建对象的人员名称' },
  { visible: true, prop: 'laeda', label: '上次更改的日期' },
  { visible: true, prop: 'aenam', label: '对象更改人员的名称' },
  { visible: true, prop: 'vpsta', label: '完整状态 ' },
  { visible: false, prop: 'pstat', label: '维护状态 ' },
  { visible: false, prop: 'lvorm', label: '集团级的 DF' },
  { visible: false, prop: 'mtart', label: '物料类型' },
  { visible: false, prop: 'mbrsh', label: '行业领域' },
  { visible: false, prop: 'matkl', label: '物料组 ' },
  { visible: false, prop: 'bismt', label: '旧物料号' },
  { visible: false, prop: 'meins', label: '基本单位' },
  { visible: false, prop: 'bstme', label: '订单单位' },
  { visible: false, prop: 'zeinr', label: '凭证' },
  { visible: false, prop: 'zeiar', label: '凭证类型' },
  { visible: false, prop: 'zeivr', label: '凭证版本' },
  { visible: false, prop: 'zeifo', label: '页面大小' },
  { visible: false, prop: 'aeszn', label: '文档变更号 ' },
  { visible: false, prop: 'blatt', label: '页号' },
  { visible: false, prop: 'blanz', label: '页数' },
  { visible: false, prop: 'ferth', label: '生产/检验备忘录' },
  { visible: false, prop: 'formt', label: '页格式 ' },
  { visible: false, prop: 'groes', label: '大小/量纲' },
  { visible: false, prop: 'wrkst', label: '基本物料' },
  { visible: false, prop: 'normt', label: '行业标准描述' },
  { visible: false, prop: 'labor', label: '实验室/办公室 ' },
  { visible: false, prop: 'ekwsl', label: '采购值代码 ' },
  { visible: false, prop: 'brgew', label: '毛重' },
  { visible: false, prop: 'ntgew', label: '净重 ' },
  { visible: false, prop: 'gewei', label: '重量单位' },
  { visible: false, prop: 'volum', label: '业务量 ' },
  { visible: false, prop: 'voleh', label: '体积单位' },
  { visible: false, prop: 'behvo', label: '容器' },
  { visible: false, prop: 'raube', label: '存储条件' },
  { visible: false, prop: 'tempb', label: '温度' },
  { visible: false, prop: 'disst', label: '低层代码' },
  { visible: false, prop: 'tragr', label: '运输组 ' },
  { visible: false, prop: 'stoff', label: '危险物料号 ' },
  { visible: false, prop: 'spart', label: '产品组 ' },
  { visible: false, prop: 'kunnr', label: '竞争者 ' },
  { visible: false, prop: 'eannr', label: 'EAN 号 ' },
  { visible: false, prop: 'wesch', label: 'GR单数量 ' },
  { visible: false, prop: 'bwvor', label: '采购规则' },
  { visible: false, prop: 'bwscl', label: '货源' },
  { visible: false, prop: 'saiso', label: '季节' },
  { visible: false, prop: 'etiar', label: '标号类型' },
  { visible: false, prop: 'etifo', label: '标签格式' },
  { visible: false, prop: 'entar', label: '取消激活字段 ' },
  { visible: false, prop: 'eAN11', label: 'EAN/UPC' },
  { visible: false, prop: 'numtp', label: 'EAN 类别' },
  { visible: false, prop: 'laeng', label: '长度' },
  { visible: false, prop: 'breit', label: '宽度' },
  { visible: false, prop: 'hoehe', label: '高度' },
  { visible: false, prop: 'meabm', label: '单位' },
  { visible: false, prop: 'prdha', label: '产品层次' },
  { visible: false, prop: 'aeklk', label: '净改变成本核算' },
  { visible: false, prop: 'cadkz', label: 'CAD 标识' },
  { visible: false, prop: 'qmpur', label: 'QM 采购' },
  { visible: false, prop: 'ergew', label: '允许的包装重量' },
  { visible: false, prop: 'ergei', label: '重量单位' },
  { visible: false, prop: 'ervol', label: '允许的体积 ' },
  { visible: false, prop: 'ervoe', label: '体积单位' },
  { visible: false, prop: 'gewto', label: '超重量容差 ' },
  { visible: false, prop: 'volto', label: '超过体积容差' },
  { visible: false, prop: 'vabme', label: '可变的订单单位' },
  { visible: false, prop: 'kzrev', label: '修订等级' },
  { visible: false, prop: 'kzkfg', label: '可配置 ' },
  { visible: false, prop: 'xchpf', label: '批次管理需求 ' },
  { visible: false, prop: 'vhart', label: '包装物料类型' },
  { visible: false, prop: 'fuelg', label: '最大层次 ' },
  { visible: false, prop: 'stfak', label: '堆栈因子' },
  { visible: false, prop: 'magrv', label: '物料组包装物料' },
  { visible: false, prop: 'begru', label: '权限组 ' },
  { visible: false, prop: 'datab', label: '有效起始日 ' },
  { visible: false, prop: 'liqdt', label: '有效至 ' },
  { visible: false, prop: 'saisj', label: '季度年 ' },
  { visible: false, prop: 'plgtp', label: '价格标记类型' },
  { visible: false, prop: 'mlgut', label: '含空BOM' },
  { visible: false, prop: 'extwg', label: '外部物料组 ' },
  { visible: false, prop: 'satnr', label: '一般可配置物料' },
  { visible: false, prop: 'attyp', label: '物料类别' },
  { visible: false, prop: 'kzkup', label: '联产品 ' },
  { visible: false, prop: 'kznfm', label: '后继的物料 ' },
  { visible: false, prop: 'pmata', label: '定价参考物料 ' },
  { visible: false, prop: 'mstae', label: '跨工厂物料状态' },
  { visible: false, prop: 'mstav', label: '跨分销链状态 ' },
  { visible: false, prop: 'mstde', label: '有效起始期 ' },
  { visible: false, prop: 'mstdv', label: '有效从 ' },
  { visible: false, prop: 'taklv', label: '税收分类' },
  { visible: false, prop: 'rbnrm', label: '类别参数文件' },
  { visible: false, prop: 'mhdrz', label: '剩余货架寿命' },
  { visible: false, prop: 'mhdhb', label: '总货架寿命 ' },
  { visible: false, prop: 'mhdlp', label: '仓储 %' },
  { visible: false, prop: 'inhme', label: '内容单位' },
  { visible: false, prop: 'inhal', label: '净内容' },
  { visible: false, prop: 'vpreh', label: '比较价格单位' },
  { visible: false, prop: 'etiag', label: '给物料组加标签' },
  { visible: false, prop: 'inhbr', label: '毛内容 ' },
  { visible: false, prop: 'cmeth', label: '转换方法' },
  { visible: false, prop: 'cuobf', label: '内部对象号 ' },
  { visible: false, prop: 'kzumw', label: '环境是相关的' },
  { visible: false, prop: 'kosch', label: '产品分配' },
  { visible: false, prop: 'sprof', label: '定价参数文件' },
  { visible: false, prop: 'nrfhg', label: '折扣类型' },
  { visible: false, prop: 'mfrpn', label: '制造商零件编号' },
  { visible: false, prop: 'mfrnr', label: '制造商' },
  { visible: false, prop: 'bmatn', label: '内部物料编号' },
  { visible: false, prop: 'mprof', label: '制造商部件参数文' },
  { visible: false, prop: 'kzwsm', label: '测量单位用法' },
  { visible: false, prop: 'saity', label: '展开' },
  { visible: false, prop: 'profl', label: 'DG标识参数文件' },
  { visible: false, prop: 'ihivi', label: '高粘性的' },
  { visible: false, prop: 'iloos', label: '以大批/液体' },
  { visible: false, prop: 'serlv', label: '序列化层次 ' },
  { visible: false, prop: 'kzgvh', label: '密闭的 ' },
  { visible: false, prop: 'xgchp', label: '需要批量记录 ' },
  { visible: false, prop: 'kzeff', label: '参数有效值· ' },
  { visible: false, prop: 'compl', label: '完成水平' },
  { visible: false, prop: 'iprkz', label: '期间标识' },
  { visible: false, prop: 'rdmhd', label: '舍入规则' },
  { visible: false, prop: 'przus', label: '产品成分' },
  { visible: false, prop: 'mtposMara', label: '普通项目类别组' },
  { visible: false, prop: 'bflme', label: '后勤变量' },
  { visible: false, prop: 'matfi', label: '物料被锁定 ' },
  { visible: false, prop: 'cmrel', label: 'CM 相关' },
  { visible: false, prop: 'bbtyp', label: '分类清单类型' },
  { visible: false, prop: 'sledBbd', label: '过期日期' },
  { visible: false, prop: 'gtinVariant', label: 'EAN变式' },
  { visible: false, prop: 'gennr', label: '一般物料 ' },
  { visible: false, prop: 'rmatp', label: '包装的参考物料' },
  { visible: false, prop: 'gdsRelevant', label: 'GDS 相关' },
  { visible: false, prop: 'weora', label: '原始接受' },
  { visible: false, prop: 'hutypDflt', label: '标准处理单位类' },
  { visible: false, prop: 'pilferable', label: '可偷窃的' },
  { visible: false, prop: 'whstc', label: '仓库存储条件' },
  { visible: false, prop: 'whmatgr', label: '仓库物料组 ' },
  { visible: false, prop: 'hndlcode', label: '处理标识' },
  { visible: false, prop: 'hazmat', label: '危险物料' },
  { visible: false, prop: 'hutyp', label: '处理单位类型' },
  { visible: false, prop: 'tareVar', label: '可变皮重' },
  { visible: false, prop: 'maxc', label: '最大容量 ' },
  { visible: false, prop: 'maxcTol', label: '超过容量容差' },
  { visible: false, prop: 'maxl', label: '最大长度 ' },
  { visible: false, prop: 'maxb', label: '最大包宽度' },
  { visible: false, prop: 'maxh', label: '最大高度 ' },
  { visible: false, prop: 'maxdimUom', label: '计量单位' },
  { visible: false, prop: 'herkl', label: '原产地国' },
  { visible: false, prop: 'mfrgr', label: '物料运输组 ' },
  { visible: false, prop: 'qqtime', label: '隔离期间' },
  { visible: false, prop: 'qqtimeuom', label: '时间单位' },
  { visible: false, prop: 'qgrp', label: '质量检查组' },
  { visible: false, prop: 'serial', label: '序列号参数文件' },
  { visible: false, prop: 'psSmartform', label: '表格名 ' },
  { visible: false, prop: 'logunit', label: '后勤计量单位' },
  { visible: false, prop: 'cwqrel', label: '称重物料相关' },
  { visible: false, prop: 'cwqproc', label: 'CW 参数文件' },
  { visible: false, prop: 'cwqtolgr', label: 'CW 容差组 ' },
  { visible: false, prop: 'adprof', label: '调整参数文件' },
  { visible: false, prop: 'ipmipproduct', label: '知识产权' },
  { visible: false, prop: 'allowPmatIgno', label: '允许的变式价格' },
  { visible: false, prop: 'medium', label: '中间' },
  { visible: false, prop: 'commodity', label: '实物商品' },
  { visible: false, prop: 'animalOrigin', label: '动物源 ' },
  { visible: false, prop: 'textileCompInd', label: '纺织组分活动' },
  { visible: false, prop: 'sgtCsgr', label: '分段结构' },
  { visible: false, prop: 'sgtCovsa', label: '分段策略' },
  { visible: false, prop: 'sgtStat', label: '分段状态 ' },
  { visible: false, prop: 'sgtScope', label: '分段范围' },
  { visible: false, prop: 'sgtRel', label: '分段相关' },
  { visible: false, prop: 'anp', label: 'ANP Code' },
  { visible: false, prop: 'fshMgAt1', label: 'Fashion 属性 1' },
  { visible: false, prop: 'fshMgAt2', label: 'Fashion 属性 2' },
  { visible: false, prop: 'fshMgAt3', label: 'Fashion 属性 3' },
  { visible: false, prop: 'fshSealv', label: '季节使用' },
  { visible: false, prop: 'fshSeaim', label: '库存管理中激活季节' },
  { visible: false, prop: 'fshScMid', label: '物料转换标识' },
  { visible: false, prop: 'bev1Luleinh', label: '装载单位' },
  { visible: false, prop: 'bev1Luldegrp', label: '装载单位组：IS 饮料' },
  { visible: false, prop: 'bev1Nestruccat', label: '物料关系的结构类别' },
  { visible: false, prop: 'dsdSlToltyp', label: '容差类型标识' },
  { visible: false, prop: 'dsdSvCntGrp', label: '计算组' },
  { visible: false, prop: 'dsdVcGroup', label: 'DSD 分组' },
  { visible: false, prop: 'vsoRTiltInd', label: '可以倾斜物料 (车辆空间优化)' },
  { visible: false, prop: 'vsoRStackInd', label: '不允许堆栈 (VSO)' },
  { visible: false, prop: 'vsoRBotInd', label: '底层 (车辆空间最优化)' },
  { visible: false, prop: 'vsoRTopInd', label: '顶层 (VSO)' },
  { visible: false, prop: 'vsoRStackNo', label: '堆栈因子 (车辆空间优化)' },
  { visible: false, prop: 'vsoRPalInd', label: '无包装物料的装载 (VSO)' },
  { visible: false, prop: 'vsoRPalOvrD', label: '包装物料的允许悬挂深度 (VSO)' },
  { visible: false, prop: 'vsoRPalOvrW', label: '装运物料的允许悬挂宽度 (VSO)' },
  { visible: false, prop: 'vsoRPalBHt', label: '包装物料的最大叠放高度 (VSO)' },
  { visible: false, prop: 'vsoRPalMinH', label: '包装物料的最小叠放高度 (VSO)' },
  { visible: false, prop: 'vsoRTolBHt', label: '超出最大叠放高度的容差 (VSO)' },
  { visible: false, prop: 'vsoRNoPGvh', label: '每个已结清 PKM 的物料编号(VSO)' },
  { visible: false, prop: 'vsoRQuanUnit', label: '计量单位车辆空间优化' },
  { visible: false, prop: 'vsoRKzgvhInd', label: '请求的已清包装物料 (VSO)' },
  { visible: false, prop: 'packcode', label: 'Packaging Code' },
  { visible: false, prop: 'dgPackStatus', label: '危险品包装状态' },
  { visible: false, prop: 'mcond', label: '物料条件管理' },
  { visible: false, prop: 'retdelc', label: '返回代码' },
  { visible: false, prop: 'loglevReto', label: '退货到后勤等级' },
  { visible: false, prop: 'nsnid', label: 'NIIn' },
  { visible: false, prop: 'imatn', label: '完全互换组 ' },
  { visible: false, prop: 'picnum', label: '链编号 ' },
  { visible: false, prop: 'bstat', label: '创建状态 ' },
  { visible: false, prop: 'colorAtinn', label: '内部特性 ' },
  { visible: false, prop: 'size1Atinn', label: '内部特性 ' },
  { visible: false, prop: 'size2Atinn', label: '内部特性 ' },
  { visible: false, prop: 'color', label: '颜色' },
  { visible: false, prop: 'sIZE1', label: '主尺寸 ' },
  { visible: false, prop: 'sIZE2', label: '次尺寸 ' },
  { visible: false, prop: 'freeChar', label: '特性值 ' },
  { visible: false, prop: 'careCode', label: '护理代码' },
  { visible: false, prop: 'brandId', label: '商标' },
  { visible: false, prop: 'fiberCode1', label: '组件1' },
  { visible: false, prop: 'fiberPart1', label: '百分比共享1' },
  { visible: false, prop: 'fiberCode2', label: '组件2' },
  { visible: false, prop: 'fiberPart2', label: '百分比共享2' },
  { visible: false, prop: 'fiberCode3', label: '组件3' },
  { visible: false, prop: 'fiberPart3', label: '百分比共享3' },
  { visible: false, prop: 'fiberCode4', label: '组件4' },
  { visible: false, prop: 'fiberPart4', label: '百分比共享4' },
  { visible: false, prop: 'fiberCode5', label: '组件5' },
  { visible: false, prop: 'fiberPart5', label: '百分比共享5' },
  { visible: false, prop: 'fashgrd', label: '时装等级' },
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
]

//API获取从常规物料/mm_mara表记录数据
function getList(){
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
function resetQuery(){
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
    sfid: [{ required: true, message: "ID主键"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mandt: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    matnr: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 危险品包装状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
dgPackStatusOptions: [],
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
    eAN11: null,
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
    mtposMara: null,
    bflme: null,
    matfi: null,
    cmrel: null,
    bbtyp: null,
    sledBbd: null,
    gtinVariant: null,
    gennr: null,
    rmatp: null,
    gdsRelevant: null,
    weora: null,
    hutypDflt: null,
    pilferable: null,
    whstc: null,
    whmatgr: null,
    hndlcode: null,
    hazmat: null,
    hutyp: null,
    tareVar: null,
    maxc: 0,
    maxcTol: 0,
    maxl: 0,
    maxb: 0,
    maxh: 0,
    maxdimUom: null,
    herkl: null,
    mfrgr: null,
    qqtime: 0,
    qqtimeuom: null,
    qgrp: null,
    serial: null,
    psSmartform: null,
    logunit: null,
    cwqrel: null,
    cwqproc: null,
    cwqtolgr: null,
    adprof: null,
    ipmipproduct: null,
    allowPmatIgno: null,
    medium: null,
    commodity: null,
    animalOrigin: null,
    textileCompInd: null,
    sgtCsgr: null,
    sgtCovsa: null,
    sgtStat: null,
    sgtScope: null,
    sgtRel: null,
    anp: 0,
    fshMgAt1: null,
    fshMgAt2: null,
    fshMgAt3: null,
    fshSealv: null,
    fshSeaim: null,
    fshScMid: null,
    bev1Luleinh: 0,
    bev1Luldegrp: null,
    bev1Nestruccat: null,
    dsdSlToltyp: null,
    dsdSvCntGrp: null,
    dsdVcGroup: null,
    vsoRTiltInd: null,
    vsoRStackInd: null,
    vsoRBotInd: null,
    vsoRTopInd: null,
    vsoRStackNo: 0,
    vsoRPalInd: null,
    vsoRPalOvrD: 0,
    vsoRPalOvrW: 0,
    vsoRPalBHt: 0,
    vsoRPalMinH: 0,
    vsoRTolBHt: 0,
    vsoRNoPGvh: 0,
    vsoRQuanUnit: null,
    vsoRKzgvhInd: null,
    packcode: null,
    dgPackStatus: null,
    mcond: null,
    retdelc: null,
    loglevReto: null,
    nsnid: null,
    imatn: null,
    picnum: null,
    bstat: null,
    colorAtinn: 0,
    size1Atinn: 0,
    size2Atinn: 0,
    color: null,
    sIZE1: null,
    sIZE2: null,
    freeChar: null,
    careCode: null,
    brandId: null,
    fiberCode1: null,
    fiberPart1: 0,
    fiberCode2: null,
    fiberPart2: 0,
    fiberCode3: null,
    fiberPart3: 0,
    fiberCode4: null,
    fiberPart4: 0,
    fiberCode5: null,
    fiberPart5: 0,
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
  title.value = proxy.$t('btn.add')+" "+'常规物料'
  opertype.value = 1
  form.value.ersda= new Date()
  form.value.laeda= new Date()
  form.value.blanz= 0
  form.value.brgew= 0
  form.value.ntgew= 0
  form.value.volum= 0
  form.value.wesch= 0
  form.value.laeng= 0
  form.value.breit= 0
  form.value.hoehe= 0
  form.value.ergew= 0
  form.value.ervol= 0
  form.value.gewto= 0
  form.value.volto= 0
  form.value.fuelg= 0
  form.value.stfak= 0
  form.value.datab= new Date()
  form.value.liqdt= new Date()
  form.value.mstde= new Date()
  form.value.mstdv= new Date()
  form.value.mhdrz= 0
  form.value.mhdhb= 0
  form.value.mhdlp= 0
  form.value.inhal= 0
  form.value.vpreh= 0
  form.value.inhbr= 0
  form.value.cuobf= 0
  form.value.compl= 0
  form.value.maxc= 0
  form.value.maxcTol= 0
  form.value.maxl= 0
  form.value.maxb= 0
  form.value.maxh= 0
  form.value.qqtime= 0
  form.value.anp= 0
  form.value.bev1Luleinh= 0
  form.value.vsoRStackNo= 0
  form.value.vsoRPalOvrD= 0
  form.value.vsoRPalOvrW= 0
  form.value.vsoRPalBHt= 0
  form.value.vsoRPalMinH= 0
  form.value.vsoRTolBHt= 0
  form.value.vsoRNoPGvh= 0
  form.value.dgPackStatus= 0
  form.value.colorAtinn= 0
  form.value.size1Atinn= 0
  form.value.size2Atinn= 0
  form.value.fiberPart1= 0
  form.value.fiberPart2= 0
  form.value.fiberPart3= 0
  form.value.fiberPart4= 0
  form.value.fiberPart5= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.sfid || ids.value
  getMmMara(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '常规物料'
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
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<常规物料.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Accounting,Logistics,Routine,Statistics/MmMara/export', { ...queryParams })
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