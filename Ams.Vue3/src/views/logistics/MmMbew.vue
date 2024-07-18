<!--
 * @Descripttion: 物料评估/mm_mbew
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 10:50:11
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="物料号" prop="matnr">
        <el-input v-model="queryParams.matnr" :placeholder="$t('btn.enterSearchPrefix')+'物料号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="评估范围" prop="bwkey">
        <el-select filterable clearable   v-model="queryParams.bwkey" :placeholder="$t('btn.selectSearchPrefix')+'评估范围'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估类" prop="bklas">
        <el-select filterable clearable   v-model="queryParams.bklas" :placeholder="$t('btn.selectSearchPrefix')+'评估类'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_val_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="当前期间的会计年度" prop="lfgja">
        <el-input v-model.number="queryParams.lfgja" :placeholder="$t('btn.enterSearchPrefix')+'当前期间的会计年度'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="当前期间 (记帐期间)" prop="lfmon">
        <el-input v-model.number="queryParams.lfmon" :placeholder="$t('btn.enterSearchPrefix')+'当前期间 (记帐期间)'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['mm:mbew:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:mbew:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:mbew:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:mbew:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/MmMbew/importTemplate"
                  importUrl="/Logistics/MmMbew/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['mm:mbew:export']">
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
      <el-table-column prop="matnr" label="物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('matnr')"/>
      <el-table-column prop="bwkey" label="评估范围" align="center" v-if="columns.showColumn('bwkey')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.bwkey"  />
        </template>
      </el-table-column>
      <el-table-column prop="bwtar" label="评估类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bwtar')"/>
      <el-table-column prop="lvorm" label="一种评估类型的所有物料数据的删除标志" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('lvorm')"/>
      <el-table-column prop="lbkum" label="总计已估计库存" align="center" v-if="columns.showColumn('lbkum')"/>
      <el-table-column prop="salk3" label="估价的总库存价值" align="center" v-if="columns.showColumn('salk3')"/>
      <el-table-column prop="vprsv" label="价格控制指示符" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vprsv')"/>
      <el-table-column prop="verpr" label="移动平均价格/周期单价" align="center" v-if="columns.showColumn('verpr')"/>
      <el-table-column prop="stprs" label="标准价格" align="center" v-if="columns.showColumn('stprs')"/>
      <el-table-column prop="peinh" label="价格单位" align="center" v-if="columns.showColumn('peinh')"/>
      <el-table-column prop="bklas" label="评估类" align="center" v-if="columns.showColumn('bklas')">
        <template #default="scope">
          <dict-tag :options=" options.sys_val_type " :value="scope.row.bklas"  />
        </template>
      </el-table-column>
      <el-table-column prop="salkv" label="基于平均移动价的值（仅价格控制 S）" align="center" v-if="columns.showColumn('salkv')"/>
      <el-table-column prop="vmkum" label="前期的总评估库存" align="center" v-if="columns.showColumn('vmkum')"/>
      <el-table-column prop="vmsal" label="上期估过价的总库存价值" align="center" v-if="columns.showColumn('vmsal')"/>
      <el-table-column prop="vmvpr" label="前一期间价格控制标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vmvpr')"/>
      <el-table-column prop="vmver" label="前一期间的移动平均价格/期间单位价格" align="center" v-if="columns.showColumn('vmver')"/>
      <el-table-column prop="vmstp" label="前期的标准价格" align="center" v-if="columns.showColumn('vmstp')"/>
      <el-table-column prop="vmpei" label="前期的价格单位" align="center" v-if="columns.showColumn('vmpei')"/>
      <el-table-column prop="vmbkl" label="上期的评价分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vmbkl')"/>
      <el-table-column prop="vmsav" label="基于平均移动价的值(上期)" align="center" v-if="columns.showColumn('vmsav')"/>
      <el-table-column prop="vjkum" label="前年的总评估库存" align="center" v-if="columns.showColumn('vjkum')"/>
      <el-table-column prop="vjsal" label="上年估价的总库存价值" align="center" v-if="columns.showColumn('vjsal')"/>
      <el-table-column prop="vjvpr" label="前一年的价格控制标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vjvpr')"/>
      <el-table-column prop="vjver" label="前一年移动平均价格/期间单价价格" align="center" v-if="columns.showColumn('vjver')"/>
      <el-table-column prop="vjstp" label="上年的标准价格" align="center" v-if="columns.showColumn('vjstp')"/>
      <el-table-column prop="vjpei" label="去年的价格单位" align="center" v-if="columns.showColumn('vjpei')"/>
      <el-table-column prop="vjbkl" label="上年的评价分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vjbkl')"/>
      <el-table-column prop="vjsav" label="基于平均移动价的值(上年)" align="center" v-if="columns.showColumn('vjsav')"/>
      <el-table-column prop="lfgja" label="当前期间的会计年度" align="center" v-if="columns.showColumn('lfgja')"/>
      <el-table-column prop="lfmon" label="当前期间 (记帐期间)" align="center" v-if="columns.showColumn('lfmon')"/>
      <el-table-column prop="bwtty" label="评估类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bwtty')"/>
      <el-table-column prop="stprv" label="上期价格" align="center" v-if="columns.showColumn('stprv')"/>
      <el-table-column prop="laepr" label="最新价格更改的日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('laepr')"/>
      <el-table-column prop="zkprs" label="未来价格" align="center" v-if="columns.showColumn('zkprs')"/>
      <el-table-column prop="zkdat" label="价格开始有效的日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('zkdat')"/>
      <el-table-column prop="timestamp" label="简短格式的 UTC 时戳 (YYYYMMDDhhmmss)" align="center" v-if="columns.showColumn('timestamp')"/>
      <el-table-column prop="bwprs" label="基于税法的估价价格 - 级别1" align="center" v-if="columns.showColumn('bwprs')"/>
      <el-table-column prop="bwprh" label="基于商法的估价价格 - 级别 1" align="center" v-if="columns.showColumn('bwprh')"/>
      <el-table-column prop="vjbws" label="基于税法的估价价格(BTCI) - 级别3" align="center" v-if="columns.showColumn('vjbws')"/>
      <el-table-column prop="vjbwh" label="基于商业法律的估价价格 - 级别3" align="center" v-if="columns.showColumn('vjbwh')"/>
      <el-table-column prop="vvjsl" label="前年估价的总库存价值" align="center" v-if="columns.showColumn('vvjsl')"/>
      <el-table-column prop="vvjlb" label="前年的总评估库存" align="center" v-if="columns.showColumn('vvjlb')"/>
      <el-table-column prop="vvmlb" label="前期的总评估库存" align="center" v-if="columns.showColumn('vvmlb')"/>
      <el-table-column prop="vvsal" label="前期估价的总库存价值" align="center" v-if="columns.showColumn('vvsal')"/>
      <el-table-column prop="zplpr" label="未来计划价格" align="center" v-if="columns.showColumn('zplpr')"/>
      <el-table-column prop="zplp1" label="未来计划价格1" align="center" v-if="columns.showColumn('zplp1')"/>
      <el-table-column prop="zplp2" label="未来计划价格 2" align="center" v-if="columns.showColumn('zplp2')"/>
      <el-table-column prop="zplp3" label="未来计划价格 3" align="center" v-if="columns.showColumn('zplp3')"/>
      <el-table-column prop="zpld1" label="计划价格 1 开始有效的日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('zpld1')"/>
      <el-table-column prop="zpld2" label="计划价格 2 开始有效的日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('zpld2')"/>
      <el-table-column prop="zpld3" label="计划价格 3 开始有效的日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('zpld3')"/>
      <el-table-column prop="pperz" label="未来标准成本估计的期间(未激活)" :show-overflow-tooltip="true"  v-if="columns.showColumn('pperz')"/>
      <el-table-column prop="pperl" label="当前标准成本估计的期间(未激活)" :show-overflow-tooltip="true"  v-if="columns.showColumn('pperl')"/>
      <el-table-column prop="pperv" label="以前标准成本估计的期间(未激活)" :show-overflow-tooltip="true"  v-if="columns.showColumn('pperv')"/>
      <el-table-column prop="kalkz" label="标识: 未来期间的标准成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kalkz')"/>
      <el-table-column prop="kalkl" label="当前期间的标准成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kalkl')"/>
      <el-table-column prop="kalkv" label="标识: 上一期间的标准成本估计" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kalkv')"/>
      <el-table-column prop="kalsc" label="一般费用代码(未激活)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kalsc')"/>
      <el-table-column prop="xlifo" label="LIFO/FIFO 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('xlifo')"/>
      <el-table-column prop="mypol" label="用于LIFO评估的储备号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mypol')"/>
      <el-table-column prop="bwph1" label="基于商业法律的估价价格：级别 2" align="center" v-if="columns.showColumn('bwph1')"/>
      <el-table-column prop="bwps1" label="基于税法的估价价格： 级别2" align="center" v-if="columns.showColumn('bwps1')"/>
      <el-table-column prop="abwkz" label="最低价值: 贬值标志" align="center" v-if="columns.showColumn('abwkz')"/>
      <el-table-column prop="pstat" label="维护状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('pstat')"/>
      <el-table-column prop="kaln1" label="成本估算号 - 产品成本核算" align="center" v-if="columns.showColumn('kaln1')"/>
      <el-table-column prop="kalnr" label="没有数量结构的成本估算的成本估算编号" align="center" v-if="columns.showColumn('kalnr')"/>
      <el-table-column prop="bwva1" label="未来的标准成本估算的估价变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bwva1')"/>
      <el-table-column prop="bwva2" label="当前的标准成本估算的估价变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bwva2')"/>
      <el-table-column prop="bwva3" label="过去的标准成本估算的估价变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('bwva3')"/>
      <el-table-column prop="vers1" label="未来的标准成本估算的成本核算方案" align="center" v-if="columns.showColumn('vers1')"/>
      <el-table-column prop="vers2" label="当前的标准成本估算的成本核算方案" align="center" v-if="columns.showColumn('vers2')"/>
      <el-table-column prop="vers3" label="先前的标准成本估算的成本核算方案" align="center" v-if="columns.showColumn('vers3')"/>
      <el-table-column prop="hrkft" label="作为成本要素子组的原始组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('hrkft')"/>
      <el-table-column prop="kosgr" label="成本核算间接费用组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kosgr')"/>
      <el-table-column prop="pprdz" label="未来成本估算期间" align="center" v-if="columns.showColumn('pprdz')"/>
      <el-table-column prop="pprdl" label="当前的标准成本估算期间" align="center" v-if="columns.showColumn('pprdl')"/>
      <el-table-column prop="pprdv" label="先前的标准成本估算期间" align="center" v-if="columns.showColumn('pprdv')"/>
      <el-table-column prop="pdatz" label="未来标准成本估算的会计年度" align="center" v-if="columns.showColumn('pdatz')"/>
      <el-table-column prop="pdatl" label="当前标准成本估算的会计年度" align="center" v-if="columns.showColumn('pdatl')"/>
      <el-table-column prop="pdatv" label="上一标准成本估算的会计年度" align="center" v-if="columns.showColumn('pdatv')"/>
      <el-table-column prop="ekalr" label="物料根据数量结构进行成本核算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ekalr')"/>
      <el-table-column prop="vplpr" label="上期标准价格" align="center" v-if="columns.showColumn('vplpr')"/>
      <el-table-column prop="mlmaa" label="物料帐簿在物料层被激活" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mlmaa')"/>
      <el-table-column prop="mlast" label="物料价格确定: 控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mlast')"/>
      <el-table-column prop="lplpr" label="当前的计划价格" align="center" v-if="columns.showColumn('lplpr')"/>
      <el-table-column prop="vksal" label="以销售价格计的总估价库存价值" align="center" v-if="columns.showColumn('vksal')"/>
      <el-table-column prop="hkmat" label="物料相关的源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('hkmat')"/>
      <el-table-column prop="sperw" label="实际盘点冻结标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('sperw')"/>
      <el-table-column prop="kziwl" label="单一价值物料的盘点库存标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('kziwl')"/>
      <el-table-column prop="wlinl" label="非限制使用的库存中最新实际盘点的日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('wlinl')"/>
      <el-table-column prop="abciw" label="周期盘点的盘点标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('abciw')"/>
      <el-table-column prop="bwspa" label="评价毛利" align="center" v-if="columns.showColumn('bwspa')"/>
      <el-table-column prop="lplpx" label="当前计划价格的固定金额" align="center" v-if="columns.showColumn('lplpx')"/>
      <el-table-column prop="vplpx" label="上年计划价格的固定比例" align="center" v-if="columns.showColumn('vplpx')"/>
      <el-table-column prop="fplpx" label="未来计划价格的固定比例" align="center" v-if="columns.showColumn('fplpx')"/>
      <el-table-column prop="lbwst" label="当前计划价格, 销售订单/项目存货的值决策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('lbwst')"/>
      <el-table-column prop="vbwst" label="上年计划价格，限制使用库存的评估策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('vbwst')"/>
      <el-table-column prop="fbwst" label="未来计划价格，限制使用库存的评估决策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('fbwst')"/>
      <el-table-column prop="eklas" label="关于销售订单库存的评估类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eklas')"/>
      <el-table-column prop="qklas" label="项目库存的评估分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qklas')"/>
      <el-table-column prop="mtuse" label="物料用途" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mtuse')"/>
      <el-table-column prop="mtorg" label="物料来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mtorg')"/>
      <el-table-column prop="ownpr" label="自制产品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ownpr')"/>
      <el-table-column prop="xbewm" label="基于批次特定计量单位的评估" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('xbewm')"/>
      <el-table-column prop="bwpei" label="基于税/商法估价价格的价格单位" align="center" v-if="columns.showColumn('bwpei')"/>
      <el-table-column prop="mbrue" label="MBEW 最后期间之前，期间的 MBEWH 已经存在。" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbrue')"/>
      <el-table-column prop="oklas" label="供应商特殊库存的估价类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('oklas')"/>
      <el-table-column prop="oippinv" label="物料评估类型段的预付库存标记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('oippinv')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:mbew:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:mbew:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改物料评估对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="ID主键" prop="sfid">
              <el-input v-model.number="form.sfid" :placeholder="$t('btn.enterPrefix')+'ID主键'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
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
            <el-form-item label="评估范围" prop="bwkey">
              <el-select filterable clearable   v-model="form.bwkey"  :placeholder="$t('btn.selectPrefix')+'评估范围'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="评估类型" prop="bwtar">
              <el-input v-model="form.bwtar" :placeholder="$t('btn.enterPrefix')+'评估类型'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一种评估类型的所有物料数据的删除标志" prop="lvorm">
              <el-input v-model="form.lvorm" :placeholder="$t('btn.enterPrefix')+'一种评估类型的所有物料数据的删除标志'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总计已估计库存" prop="lbkum">
              <el-input-number v-model.number="form.lbkum" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总计已估计库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="估价的总库存价值" prop="salk3">
              <el-input-number v-model.number="form.salk3" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'估价的总库存价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格控制指示符" prop="vprsv">
              <el-input v-model="form.vprsv" :placeholder="$t('btn.enterPrefix')+'价格控制指示符'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动平均价格/周期单价" prop="verpr">
              <el-input-number v-model.number="form.verpr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'移动平均价格/周期单价'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准价格" prop="stprs">
              <el-input-number v-model.number="form.stprs" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格单位" prop="peinh">
              <el-input-number v-model.number="form.peinh" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类" prop="bklas">
              <el-select filterable clearable   v-model="form.bklas"  :placeholder="$t('btn.selectPrefix')+'评估类'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_val_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="基于平均移动价的值（仅价格控制 S）" prop="salkv">
              <el-input-number v-model.number="form.salkv" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于平均移动价的值（仅价格控制 S）'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期的总评估库存" prop="vmkum">
              <el-input-number v-model.number="form.vmkum" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期的总评估库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期估过价的总库存价值" prop="vmsal">
              <el-input-number v-model.number="form.vmsal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上期估过价的总库存价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前一期间价格控制标识" prop="vmvpr">
              <el-input v-model="form.vmvpr" :placeholder="$t('btn.enterPrefix')+'前一期间价格控制标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前一期间的移动平均价格/期间单位价格" prop="vmver">
              <el-input-number v-model.number="form.vmver" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前一期间的移动平均价格/期间单位价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期的标准价格" prop="vmstp">
              <el-input-number v-model.number="form.vmstp" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期的标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期的价格单位" prop="vmpei">
              <el-input-number v-model.number="form.vmpei" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期的价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期的评价分类" prop="vmbkl">
              <el-input v-model="form.vmbkl" :placeholder="$t('btn.enterPrefix')+'上期的评价分类'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于平均移动价的值(上期)" prop="vmsav">
              <el-input-number v-model.number="form.vmsav" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于平均移动价的值(上期)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年的总评估库存" prop="vjkum">
              <el-input-number v-model.number="form.vjkum" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前年的总评估库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年估价的总库存价值" prop="vjsal">
              <el-input-number v-model.number="form.vjsal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上年估价的总库存价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前一年的价格控制标识" prop="vjvpr">
              <el-input v-model="form.vjvpr" :placeholder="$t('btn.enterPrefix')+'前一年的价格控制标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前一年移动平均价格/期间单价价格" prop="vjver">
              <el-input-number v-model.number="form.vjver" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前一年移动平均价格/期间单价价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年的标准价格" prop="vjstp">
              <el-input-number v-model.number="form.vjstp" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上年的标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="去年的价格单位" prop="vjpei">
              <el-input-number v-model.number="form.vjpei" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'去年的价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年的评价分类" prop="vjbkl">
              <el-input v-model="form.vjbkl" :placeholder="$t('btn.enterPrefix')+'上年的评价分类'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于平均移动价的值(上年)" prop="vjsav">
              <el-input-number v-model.number="form.vjsav" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于平均移动价的值(上年)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前期间的会计年度" prop="lfgja">
              <el-input-number v-model.number="form.lfgja" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前期间的会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前期间 (记帐期间)" prop="lfmon">
              <el-input-number v-model.number="form.lfmon" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前期间 (记帐期间)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类别" prop="bwtty">
              <el-input v-model="form.bwtty" :placeholder="$t('btn.enterPrefix')+'评估类别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期价格" prop="stprv">
              <el-input-number v-model.number="form.stprv" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上期价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最新价格更改的日期" prop="laepr">
              <el-date-picker v-model="form.laepr" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来价格" prop="zkprs">
              <el-input-number v-model.number="form.zkprs" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格开始有效的日期" prop="zkdat">
              <el-date-picker v-model="form.zkdat" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="简短格式的 UTC 时戳 (YYYYMMDDhhmmss)" prop="timestamp">
              <el-input-number v-model.number="form.timestamp" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'简短格式的 UTC 时戳 (YYYYMMDDhhmmss)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于税法的估价价格 - 级别1" prop="bwprs">
              <el-input-number v-model.number="form.bwprs" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于税法的估价价格 - 级别1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于商法的估价价格 - 级别 1" prop="bwprh">
              <el-input-number v-model.number="form.bwprh" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于商法的估价价格 - 级别 1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于税法的估价价格(BTCI) - 级别3" prop="vjbws">
              <el-input-number v-model.number="form.vjbws" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于税法的估价价格(BTCI) - 级别3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于商业法律的估价价格 - 级别3" prop="vjbwh">
              <el-input-number v-model.number="form.vjbwh" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于商业法律的估价价格 - 级别3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年估价的总库存价值" prop="vvjsl">
              <el-input-number v-model.number="form.vvjsl" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前年估价的总库存价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年的总评估库存" prop="vvjlb">
              <el-input-number v-model.number="form.vvjlb" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前年的总评估库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期的总评估库存" prop="vvmlb">
              <el-input-number v-model.number="form.vvmlb" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期的总评估库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期估价的总库存价值" prop="vvsal">
              <el-input-number v-model.number="form.vvsal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期估价的总库存价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格" prop="zplpr">
              <el-input-number v-model.number="form.zplpr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格1" prop="zplp1">
              <el-input-number v-model.number="form.zplp1" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格 2" prop="zplp2">
              <el-input-number v-model.number="form.zplp2" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格 2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格 3" prop="zplp3">
              <el-input-number v-model.number="form.zplp3" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格 3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格 1 开始有效的日期" prop="zpld1">
              <el-date-picker v-model="form.zpld1" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格 2 开始有效的日期" prop="zpld2">
              <el-date-picker v-model="form.zpld2" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格 3 开始有效的日期" prop="zpld3">
              <el-date-picker v-model="form.zpld3" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来标准成本估计的期间(未激活)" prop="pperz">
              <el-date-picker v-model="form.pperz" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前标准成本估计的期间(未激活)" prop="pperl">
              <el-date-picker v-model="form.pperl" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="以前标准成本估计的期间(未激活)" prop="pperv">
              <el-date-picker v-model="form.pperv" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标识: 未来期间的标准成本估算" prop="kalkz">
              <el-input v-model="form.kalkz" :placeholder="$t('btn.enterPrefix')+'标识: 未来期间的标准成本估算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前期间的标准成本估算" prop="kalkl">
              <el-input v-model="form.kalkl" :placeholder="$t('btn.enterPrefix')+'当前期间的标准成本估算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标识: 上一期间的标准成本估计" prop="kalkv">
              <el-input v-model="form.kalkv" :placeholder="$t('btn.enterPrefix')+'标识: 上一期间的标准成本估计'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般费用代码(未激活)" prop="kalsc">
              <el-input v-model="form.kalsc" :placeholder="$t('btn.enterPrefix')+'一般费用代码(未激活)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="LIFO/FIFO 相关" prop="xlifo">
              <el-input v-model="form.xlifo" :placeholder="$t('btn.enterPrefix')+'LIFO/FIFO 相关'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用于LIFO评估的储备号" prop="mypol">
              <el-input v-model="form.mypol" :placeholder="$t('btn.enterPrefix')+'用于LIFO评估的储备号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于商业法律的估价价格：级别 2" prop="bwph1">
              <el-input-number v-model.number="form.bwph1" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于商业法律的估价价格：级别 2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于税法的估价价格： 级别2" prop="bwps1">
              <el-input-number v-model.number="form.bwps1" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于税法的估价价格： 级别2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="最低价值: 贬值标志" prop="abwkz">
              <el-input-number v-model.number="form.abwkz" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最低价值: 贬值标志'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态" prop="pstat">
              <el-input v-model="form.pstat" :placeholder="$t('btn.enterPrefix')+'维护状态'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="成本估算号 - 产品成本核算" prop="kaln1">
              <el-input-number v-model.number="form.kaln1" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'成本估算号 - 产品成本核算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="没有数量结构的成本估算的成本估算编号" prop="kalnr">
              <el-input-number v-model.number="form.kalnr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'没有数量结构的成本估算的成本估算编号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来的标准成本估算的估价变式" prop="bwva1">
              <el-input v-model="form.bwva1" :placeholder="$t('btn.enterPrefix')+'未来的标准成本估算的估价变式'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前的标准成本估算的估价变式" prop="bwva2">
              <el-input v-model="form.bwva2" :placeholder="$t('btn.enterPrefix')+'当前的标准成本估算的估价变式'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过去的标准成本估算的估价变式" prop="bwva3">
              <el-input v-model="form.bwva3" :placeholder="$t('btn.enterPrefix')+'过去的标准成本估算的估价变式'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="未来的标准成本估算的成本核算方案" prop="vers1">
              <el-input-number v-model.number="form.vers1" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来的标准成本估算的成本核算方案'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前的标准成本估算的成本核算方案" prop="vers2">
              <el-input-number v-model.number="form.vers2" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前的标准成本估算的成本核算方案'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="先前的标准成本估算的成本核算方案" prop="vers3">
              <el-input-number v-model.number="form.vers3" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'先前的标准成本估算的成本核算方案'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="作为成本要素子组的原始组" prop="hrkft">
              <el-input v-model="form.hrkft" :placeholder="$t('btn.enterPrefix')+'作为成本要素子组的原始组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本核算间接费用组" prop="kosgr">
              <el-input v-model="form.kosgr" :placeholder="$t('btn.enterPrefix')+'成本核算间接费用组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="未来成本估算期间" prop="pprdz">
              <el-input-number v-model.number="form.pprdz" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来成本估算期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前的标准成本估算期间" prop="pprdl">
              <el-input-number v-model.number="form.pprdl" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前的标准成本估算期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="先前的标准成本估算期间" prop="pprdv">
              <el-input-number v-model.number="form.pprdv" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'先前的标准成本估算期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="未来标准成本估算的会计年度" prop="pdatz">
              <el-input-number v-model.number="form.pdatz" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来标准成本估算的会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前标准成本估算的会计年度" prop="pdatl">
              <el-input-number v-model.number="form.pdatl" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前标准成本估算的会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="上一标准成本估算的会计年度" prop="pdatv">
              <el-input-number v-model.number="form.pdatv" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上一标准成本估算的会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料根据数量结构进行成本核算" prop="ekalr">
              <el-input v-model="form.ekalr" :placeholder="$t('btn.enterPrefix')+'物料根据数量结构进行成本核算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期标准价格" prop="vplpr">
              <el-input-number v-model.number="form.vplpr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上期标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料帐簿在物料层被激活" prop="mlmaa">
              <el-input v-model="form.mlmaa" :placeholder="$t('btn.enterPrefix')+'物料帐簿在物料层被激活'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料价格确定: 控制" prop="mlast">
              <el-input v-model="form.mlast" :placeholder="$t('btn.enterPrefix')+'物料价格确定: 控制'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前的计划价格" prop="lplpr">
              <el-input-number v-model.number="form.lplpr" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前的计划价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="以销售价格计的总估价库存价值" prop="vksal">
              <el-input-number v-model.number="form.vksal" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'以销售价格计的总估价库存价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料相关的源" prop="hkmat">
              <el-input v-model="form.hkmat" :placeholder="$t('btn.enterPrefix')+'物料相关的源'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实际盘点冻结标识" prop="sperw">
              <el-input v-model="form.sperw" :placeholder="$t('btn.enterPrefix')+'实际盘点冻结标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单一价值物料的盘点库存标识" prop="kziwl">
              <el-input v-model="form.kziwl" :placeholder="$t('btn.enterPrefix')+'单一价值物料的盘点库存标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="非限制使用的库存中最新实际盘点的日期" prop="wlinl">
              <el-date-picker v-model="form.wlinl" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="周期盘点的盘点标识" prop="abciw">
              <el-input v-model="form.abciw" :placeholder="$t('btn.enterPrefix')+'周期盘点的盘点标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评价毛利" prop="bwspa">
              <el-input-number v-model.number="form.bwspa" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'评价毛利'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前计划价格的固定金额" prop="lplpx">
              <el-input-number v-model.number="form.lplpx" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前计划价格的固定金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年计划价格的固定比例" prop="vplpx">
              <el-input-number v-model.number="form.vplpx" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上年计划价格的固定比例'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格的固定比例" prop="fplpx">
              <el-input-number v-model.number="form.fplpx" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格的固定比例'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前计划价格, 销售订单/项目存货的值决策" prop="lbwst">
              <el-input v-model="form.lbwst" :placeholder="$t('btn.enterPrefix')+'当前计划价格, 销售订单/项目存货的值决策'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年计划价格，限制使用库存的评估策略" prop="vbwst">
              <el-input v-model="form.vbwst" :placeholder="$t('btn.enterPrefix')+'上年计划价格，限制使用库存的评估策略'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格，限制使用库存的评估决策" prop="fbwst">
              <el-input v-model="form.fbwst" :placeholder="$t('btn.enterPrefix')+'未来计划价格，限制使用库存的评估决策'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关于销售订单库存的评估类别" prop="eklas">
              <el-input v-model="form.eklas" :placeholder="$t('btn.enterPrefix')+'关于销售订单库存的评估类别'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="项目库存的评估分类" prop="qklas">
              <el-input v-model="form.qklas" :placeholder="$t('btn.enterPrefix')+'项目库存的评估分类'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料用途" prop="mtuse">
              <el-input v-model="form.mtuse" :placeholder="$t('btn.enterPrefix')+'物料用途'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料来源" prop="mtorg">
              <el-input v-model="form.mtorg" :placeholder="$t('btn.enterPrefix')+'物料来源'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自制产品" prop="ownpr">
              <el-input v-model="form.ownpr" :placeholder="$t('btn.enterPrefix')+'自制产品'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于批次特定计量单位的评估" prop="xbewm">
              <el-input v-model="form.xbewm" :placeholder="$t('btn.enterPrefix')+'基于批次特定计量单位的评估'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基于税/商法估价价格的价格单位" prop="bwpei">
              <el-input-number v-model.number="form.bwpei" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基于税/商法估价价格的价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MBEW 最后期间之前，期间的 MBEWH 已经存在。" prop="mbrue">
              <el-input v-model="form.mbrue" :placeholder="$t('btn.enterPrefix')+'MBEW 最后期间之前，期间的 MBEWH 已经存在。'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商特殊库存的估价类" prop="oklas">
              <el-input v-model="form.oklas" :placeholder="$t('btn.enterPrefix')+'供应商特殊库存的估价类'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料评估类型段的预付库存标记" prop="oippinv">
              <el-input v-model="form.oippinv" :placeholder="$t('btn.enterPrefix')+'物料评估类型段的预付库存标记'+$t('btn.enterSuffix')" />
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
              <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
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

<script setup name="mmmbew">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listMmMbew,
 addMmMbew, delMmMbew, 
 updateMmMbew,getMmMbew, 
 } 
from '@/api/logistics/mmmbew.js'
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
  bwkey: undefined,
//是否查询（1是）
  bklas: undefined,
//是否查询（1是）
  lfgja: undefined,
//是否查询（1是）
  lfmon: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'sfid', label: 'ID主键' },
  { visible: true, prop: 'mandt', label: '集团' },
  { visible: true, prop: 'matnr', label: '物料号' },
  { visible: true, prop: 'bwkey', label: '评估范围' },
  { visible: true, prop: 'bwtar', label: '评估类型' },
  { visible: true, prop: 'lvorm', label: '一种评估类型的所有物料数据的删除标志' },
  { visible: true, prop: 'lbkum', label: '总计已估计库存' },
  { visible: true, prop: 'salk3', label: '估价的总库存价值' },
  { visible: false, prop: 'vprsv', label: '价格控制指示符' },
  { visible: false, prop: 'verpr', label: '移动平均价格/周期单价' },
  { visible: false, prop: 'stprs', label: '标准价格' },
  { visible: false, prop: 'peinh', label: '价格单位' },
  { visible: false, prop: 'bklas', label: '评估类' },
  { visible: false, prop: 'salkv', label: '基于平均移动价的值（仅价格控制 S）' },
  { visible: false, prop: 'vmkum', label: '前期的总评估库存' },
  { visible: false, prop: 'vmsal', label: '上期估过价的总库存价值' },
  { visible: false, prop: 'vmvpr', label: '前一期间价格控制标识' },
  { visible: false, prop: 'vmver', label: '前一期间的移动平均价格/期间单位价格' },
  { visible: false, prop: 'vmstp', label: '前期的标准价格' },
  { visible: false, prop: 'vmpei', label: '前期的价格单位' },
  { visible: false, prop: 'vmbkl', label: '上期的评价分类' },
  { visible: false, prop: 'vmsav', label: '基于平均移动价的值(上期)' },
  { visible: false, prop: 'vjkum', label: '前年的总评估库存' },
  { visible: false, prop: 'vjsal', label: '上年估价的总库存价值' },
  { visible: false, prop: 'vjvpr', label: '前一年的价格控制标识' },
  { visible: false, prop: 'vjver', label: '前一年移动平均价格/期间单价价格' },
  { visible: false, prop: 'vjstp', label: '上年的标准价格' },
  { visible: false, prop: 'vjpei', label: '去年的价格单位' },
  { visible: false, prop: 'vjbkl', label: '上年的评价分类' },
  { visible: false, prop: 'vjsav', label: '基于平均移动价的值(上年)' },
  { visible: false, prop: 'lfgja', label: '当前期间的会计年度' },
  { visible: false, prop: 'lfmon', label: '当前期间 (记帐期间)' },
  { visible: false, prop: 'bwtty', label: '评估类别' },
  { visible: false, prop: 'stprv', label: '上期价格' },
  { visible: false, prop: 'laepr', label: '最新价格更改的日期' },
  { visible: false, prop: 'zkprs', label: '未来价格' },
  { visible: false, prop: 'zkdat', label: '价格开始有效的日期' },
  { visible: false, prop: 'timestamp', label: '简短格式的 UTC 时戳 (YYYYMMDDhhmmss)' },
  { visible: false, prop: 'bwprs', label: '基于税法的估价价格 - 级别1' },
  { visible: false, prop: 'bwprh', label: '基于商法的估价价格 - 级别 1' },
  { visible: false, prop: 'vjbws', label: '基于税法的估价价格(BTCI) - 级别3' },
  { visible: false, prop: 'vjbwh', label: '基于商业法律的估价价格 - 级别3' },
  { visible: false, prop: 'vvjsl', label: '前年估价的总库存价值' },
  { visible: false, prop: 'vvjlb', label: '前年的总评估库存' },
  { visible: false, prop: 'vvmlb', label: '前期的总评估库存' },
  { visible: false, prop: 'vvsal', label: '前期估价的总库存价值' },
  { visible: false, prop: 'zplpr', label: '未来计划价格' },
  { visible: false, prop: 'zplp1', label: '未来计划价格1' },
  { visible: false, prop: 'zplp2', label: '未来计划价格 2' },
  { visible: false, prop: 'zplp3', label: '未来计划价格 3' },
  { visible: false, prop: 'zpld1', label: '计划价格 1 开始有效的日期' },
  { visible: false, prop: 'zpld2', label: '计划价格 2 开始有效的日期' },
  { visible: false, prop: 'zpld3', label: '计划价格 3 开始有效的日期' },
  { visible: false, prop: 'pperz', label: '未来标准成本估计的期间(未激活)' },
  { visible: false, prop: 'pperl', label: '当前标准成本估计的期间(未激活)' },
  { visible: false, prop: 'pperv', label: '以前标准成本估计的期间(未激活)' },
  { visible: false, prop: 'kalkz', label: '标识: 未来期间的标准成本估算' },
  { visible: false, prop: 'kalkl', label: '当前期间的标准成本估算' },
  { visible: false, prop: 'kalkv', label: '标识: 上一期间的标准成本估计' },
  { visible: false, prop: 'kalsc', label: '一般费用代码(未激活)' },
  { visible: false, prop: 'xlifo', label: 'LIFO/FIFO 相关' },
  { visible: false, prop: 'mypol', label: '用于LIFO评估的储备号' },
  { visible: false, prop: 'bwph1', label: '基于商业法律的估价价格：级别 2' },
  { visible: false, prop: 'bwps1', label: '基于税法的估价价格： 级别2' },
  { visible: false, prop: 'abwkz', label: '最低价值: 贬值标志' },
  { visible: false, prop: 'pstat', label: '维护状态' },
  { visible: false, prop: 'kaln1', label: '成本估算号 - 产品成本核算' },
  { visible: false, prop: 'kalnr', label: '没有数量结构的成本估算的成本估算编号' },
  { visible: false, prop: 'bwva1', label: '未来的标准成本估算的估价变式' },
  { visible: false, prop: 'bwva2', label: '当前的标准成本估算的估价变式' },
  { visible: false, prop: 'bwva3', label: '过去的标准成本估算的估价变式' },
  { visible: false, prop: 'vers1', label: '未来的标准成本估算的成本核算方案' },
  { visible: false, prop: 'vers2', label: '当前的标准成本估算的成本核算方案' },
  { visible: false, prop: 'vers3', label: '先前的标准成本估算的成本核算方案' },
  { visible: false, prop: 'hrkft', label: '作为成本要素子组的原始组' },
  { visible: false, prop: 'kosgr', label: '成本核算间接费用组' },
  { visible: false, prop: 'pprdz', label: '未来成本估算期间' },
  { visible: false, prop: 'pprdl', label: '当前的标准成本估算期间' },
  { visible: false, prop: 'pprdv', label: '先前的标准成本估算期间' },
  { visible: false, prop: 'pdatz', label: '未来标准成本估算的会计年度' },
  { visible: false, prop: 'pdatl', label: '当前标准成本估算的会计年度' },
  { visible: false, prop: 'pdatv', label: '上一标准成本估算的会计年度' },
  { visible: false, prop: 'ekalr', label: '物料根据数量结构进行成本核算' },
  { visible: false, prop: 'vplpr', label: '上期标准价格' },
  { visible: false, prop: 'mlmaa', label: '物料帐簿在物料层被激活' },
  { visible: false, prop: 'mlast', label: '物料价格确定: 控制' },
  { visible: false, prop: 'lplpr', label: '当前的计划价格' },
  { visible: false, prop: 'vksal', label: '以销售价格计的总估价库存价值' },
  { visible: false, prop: 'hkmat', label: '物料相关的源' },
  { visible: false, prop: 'sperw', label: '实际盘点冻结标识' },
  { visible: false, prop: 'kziwl', label: '单一价值物料的盘点库存标识' },
  { visible: false, prop: 'wlinl', label: '非限制使用的库存中最新实际盘点的日期' },
  { visible: false, prop: 'abciw', label: '周期盘点的盘点标识' },
  { visible: false, prop: 'bwspa', label: '评价毛利' },
  { visible: false, prop: 'lplpx', label: '当前计划价格的固定金额' },
  { visible: false, prop: 'vplpx', label: '上年计划价格的固定比例' },
  { visible: false, prop: 'fplpx', label: '未来计划价格的固定比例' },
  { visible: false, prop: 'lbwst', label: '当前计划价格, 销售订单/项目存货的值决策' },
  { visible: false, prop: 'vbwst', label: '上年计划价格，限制使用库存的评估策略' },
  { visible: false, prop: 'fbwst', label: '未来计划价格，限制使用库存的评估决策' },
  { visible: false, prop: 'eklas', label: '关于销售订单库存的评估类别' },
  { visible: false, prop: 'qklas', label: '项目库存的评估分类' },
  { visible: false, prop: 'mtuse', label: '物料用途' },
  { visible: false, prop: 'mtorg', label: '物料来源' },
  { visible: false, prop: 'ownpr', label: '自制产品' },
  { visible: false, prop: 'xbewm', label: '基于批次特定计量单位的评估' },
  { visible: false, prop: 'bwpei', label: '基于税/商法估价价格的价格单位' },
  { visible: false, prop: 'mbrue', label: 'MBEW 最后期间之前，期间的 MBEWH 已经存在。' },
  { visible: false, prop: 'oklas', label: '供应商特殊库存的估价类' },
  { visible: false, prop: 'oippinv', label: '物料评估类型段的预付库存标记' },
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
  { dictType: "sys_val_type" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从物料评估/mm_mbew表记录数据
function getList(){
  loading.value = true
  listMmMbew(queryParams).then(res => {
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
    sfid: [{ required: true, message: "ID主键"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    matnr: [{ required: true, message: "物料号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    bwkey: [{ required: true, message: "评估范围"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    bklas: [{ required: true, message: "评估类"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 评估范围 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_plant_list: [],
    // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_val_type: [],
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
    sfid: 0,
    mandt: null,
    matnr: null,
    bwkey: null,
    bwtar: null,
    lvorm: null,
    lbkum: 0,
    salk3: 0,
    vprsv: null,
    verpr: 0,
    stprs: 0,
    peinh: 0,
    bklas: null,
    salkv: 0,
    vmkum: 0,
    vmsal: 0,
    vmvpr: null,
    vmver: 0,
    vmstp: 0,
    vmpei: 0,
    vmbkl: null,
    vmsav: 0,
    vjkum: 0,
    vjsal: 0,
    vjvpr: null,
    vjver: 0,
    vjstp: 0,
    vjpei: 0,
    vjbkl: null,
    vjsav: 0,
    lfgja: 0,
    lfmon: 0,
    bwtty: null,
    stprv: 0,
    laepr: null,
    zkprs: 0,
    zkdat: null,
    timestamp: 0,
    bwprs: 0,
    bwprh: 0,
    vjbws: 0,
    vjbwh: 0,
    vvjsl: 0,
    vvjlb: 0,
    vvmlb: 0,
    vvsal: 0,
    zplpr: 0,
    zplp1: 0,
    zplp2: 0,
    zplp3: 0,
    zpld1: null,
    zpld2: null,
    zpld3: null,
    pperz: null,
    pperl: null,
    pperv: null,
    kalkz: null,
    kalkl: null,
    kalkv: null,
    kalsc: null,
    xlifo: null,
    mypol: null,
    bwph1: 0,
    bwps1: 0,
    abwkz: 0,
    pstat: null,
    kaln1: 0,
    kalnr: 0,
    bwva1: null,
    bwva2: null,
    bwva3: null,
    vers1: 0,
    vers2: 0,
    vers3: 0,
    hrkft: null,
    kosgr: null,
    pprdz: 0,
    pprdl: 0,
    pprdv: 0,
    pdatz: 0,
    pdatl: 0,
    pdatv: 0,
    ekalr: null,
    vplpr: 0,
    mlmaa: null,
    mlast: null,
    lplpr: 0,
    vksal: 0,
    hkmat: null,
    sperw: null,
    kziwl: null,
    wlinl: null,
    abciw: null,
    bwspa: 0,
    lplpx: 0,
    vplpx: 0,
    fplpx: 0,
    lbwst: null,
    vbwst: null,
    fbwst: null,
    eklas: null,
    qklas: null,
    mtuse: null,
    mtorg: null,
    ownpr: null,
    xbewm: null,
    bwpei: 0,
    mbrue: null,
    oklas: null,
    oippinv: null,
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
  title.value = proxy.$t('btn.add')+" "+'物料评估'
  opertype.value = 1
  form.value.bwkey= []
  form.value.lbkum= 0
  form.value.salk3= 0
  form.value.verpr= 0
  form.value.stprs= 0
  form.value.peinh= 0
  form.value.bklas= []
  form.value.salkv= 0
  form.value.vmkum= 0
  form.value.vmsal= 0
  form.value.vmver= 0
  form.value.vmstp= 0
  form.value.vmpei= 0
  form.value.vmsav= 0
  form.value.vjkum= 0
  form.value.vjsal= 0
  form.value.vjver= 0
  form.value.vjstp= 0
  form.value.vjpei= 0
  form.value.vjsav= 0
  form.value.lfgja= 0
  form.value.lfmon= 0
  form.value.stprv= 0
  form.value.laepr= new Date()
  form.value.zkprs= 0
  form.value.zkdat= new Date()
  form.value.timestamp= 0
  form.value.bwprs= 0
  form.value.bwprh= 0
  form.value.vjbws= 0
  form.value.vjbwh= 0
  form.value.vvjsl= 0
  form.value.vvjlb= 0
  form.value.vvmlb= 0
  form.value.vvsal= 0
  form.value.zplpr= 0
  form.value.zplp1= 0
  form.value.zplp2= 0
  form.value.zplp3= 0
  form.value.zpld1= new Date()
  form.value.zpld2= new Date()
  form.value.zpld3= new Date()
  form.value.pperz= new Date()
  form.value.pperl= new Date()
  form.value.pperv= new Date()
  form.value.bwph1= 0
  form.value.bwps1= 0
  form.value.abwkz= 0
  form.value.kaln1= 0
  form.value.kalnr= 0
  form.value.vers1= 0
  form.value.vers2= 0
  form.value.vers3= 0
  form.value.pprdz= 0
  form.value.pprdl= 0
  form.value.pprdv= 0
  form.value.pdatz= 0
  form.value.pdatl= 0
  form.value.pdatv= 0
  form.value.vplpr= 0
  form.value.lplpr= 0
  form.value.vksal= 0
  form.value.wlinl= new Date()
  form.value.bwspa= 0
  form.value.lplpx= 0
  form.value.vplpx= 0
  form.value.fplpx= 0
  form.value.bwpei= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.sfid || ids.value
  getMmMbew(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '物料评估'
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
        updateMmMbew(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addMmMbew(form.value).then((res) => {
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
      return delMmMbew(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<物料评估.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/MmMbew/export', { ...queryParams })
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