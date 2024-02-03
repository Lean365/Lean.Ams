<!--
 * @Descripttion: (物料评估/mm_mbew)
 * @Version: (0.24.389.27614)
 * @Author: (Lean365)
 * @Date: (2024/1/24 15:30:16)
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="评估类 " prop="mbewBKLAS">
        <el-select clearable filterable  v-model="queryParams.mbewBKLAS" :placeholder="$t('btn.select')+'评估类 '">
          <el-option v-for="item in  options.app_val_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估范围" prop="mbewBWKEY">
        <el-select clearable filterable  v-model="queryParams.mbewBWKEY" :placeholder="$t('btn.select')+'评估范围'">
          <el-option v-for="item in  options.app_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button type="primary" v-hasPermi="['mm:mbew:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['mm:mbew:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['mm:mbew:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['mm:mbew:import']">
          <el-button color="#626aef" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="accounting/Mbew/importTemplate"
                  importUrl="/accounting/Mbew/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['mm:mbew:export']">
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
      <el-table-column prop="mbewSFID" label="ID主键" align="center" v-if="columns.showColumn('mbewSFID')"/>
      <el-table-column prop="mbewABCIW" label="CC 库存盘点" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewABCIW')"/>
      <el-table-column prop="mbewABWKZ" label="贬值标识  " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewABWKZ')"/>
      <el-table-column prop="mbewBKLAS" label="评估类 " align="center" v-if="columns.showColumn('mbewBKLAS')">
        <template #default="scope">
          <dict-tag :options=" options.app_val_type " :value="scope.row.mbewBKLAS"  />
        </template>
      </el-table-column>
      <el-table-column prop="mbewBWKEY" label="评估范围" align="center" v-if="columns.showColumn('mbewBWKEY')">
        <template #default="scope">
          <dict-tag :options=" options.app_plant_list " :value="scope.row.mbewBWKEY"  />
        </template>
      </el-table-column>
      <el-table-column prop="mbewBWPEI" label="价格单位" align="center" v-if="columns.showColumn('mbewBWPEI')"/>
      <el-table-column prop="mbewBWPH1" label="商业价格 2" align="center" v-if="columns.showColumn('mbewBWPH1')"/>
      <el-table-column prop="mbewBWPRH" label="商业价格 1" align="center" v-if="columns.showColumn('mbewBWPRH')"/>
      <el-table-column prop="mbewBWPRS" label="税价1" align="center" v-if="columns.showColumn('mbewBWPRS')"/>
      <el-table-column prop="mbewBWPS1" label="税价2" align="center" v-if="columns.showColumn('mbewBWPS1')"/>
      <el-table-column prop="mbewBWSPA" label="评价毛利" align="center" v-if="columns.showColumn('mbewBWSPA')"/>
      <el-table-column prop="mbewBWTAR" label="评估类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewBWTAR')"/>
      <el-table-column prop="mbewBWTTY" label="评估类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewBWTTY')"/>
      <el-table-column prop="mbewBWVA1" label="评估变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewBWVA1')"/>
      <el-table-column prop="mbewBWVA2" label="评估变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewBWVA2')"/>
      <el-table-column prop="mbewBWVA3" label="评估变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewBWVA3')"/>
      <el-table-column prop="mbewEKALR" label="用QS的成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewEKALR')"/>
      <el-table-column prop="mbewEKLAS" label="VC:销售订单库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewEKLAS')"/>
      <el-table-column prop="mbewFBWST" label="未来评估决策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewFBWST')"/>
      <el-table-column prop="mbewFPLPX" label="固定的未来计划价格" align="center" v-if="columns.showColumn('mbewFPLPX')"/>
      <el-table-column prop="mbewHKMAT" label="物料来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewHKMAT')"/>
      <el-table-column prop="mbewHRKFT" label="原始组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewHRKFT')"/>
      <el-table-column prop="mbewKALKL" label="当前成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKALKL')"/>
      <el-table-column prop="mbewKALKV" label="上期成本估计" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKALKV')"/>
      <el-table-column prop="mbewKALKZ" label="未来成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKALKZ')"/>
      <el-table-column prop="mbewKALN1" label="产品成本核算号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKALN1')"/>
      <el-table-column prop="mbewKALNR" label="成本估算编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKALNR')"/>
      <el-table-column prop="mbewKALSC" label="一般费用代码 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKALSC')"/>
      <el-table-column prop="mbewKOSGR" label="间接费分组 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKOSGR')"/>
      <el-table-column prop="mbewKZIWL" label="盘点库存VO物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewKZIWL')"/>
      <el-table-column prop="mbewLAEPR" label="最近价格更改 " :show-overflow-tooltip="true"  v-if="columns.showColumn('mbewLAEPR')"/>
      <el-table-column prop="mbewLBKUM" label="总库存 " align="center" v-if="columns.showColumn('mbewLBKUM')"/>
      <el-table-column prop="mbewLBWST" label="当前的值决策 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewLBWST')"/>
      <el-table-column prop="mbewLFGJA" label="年  当前期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewLFGJA')"/>
      <el-table-column prop="mbewLFMON" label="本期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewLFMON')"/>
      <el-table-column prop="mbewLPLPR" label="当前计划价格" align="center" v-if="columns.showColumn('mbewLPLPR')"/>
      <el-table-column prop="mbewLPLPX" label="固定的当前计划价格" align="center" v-if="columns.showColumn('mbewLPLPX')"/>
      <el-table-column prop="mbewLVORM" label="评估类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewLVORM')"/>
      <el-table-column prop="mbewMANDT" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMANDT')"/>
      <el-table-column prop="mbewMATNR" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMATNR')"/>
      <el-table-column prop="mbewMBRUE" label="MBEW 最后期间之前，期间的 MBEW" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMBRUE')"/>
      <el-table-column prop="mbewMLAST" label="价格确定" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMLAST')"/>
      <el-table-column prop="mbewMLMAA" label="ML 作业" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMLMAA')"/>
      <el-table-column prop="mbewMTORG" label="物料来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMTORG')"/>
      <el-table-column prop="mbewMTUSE" label="物料用途 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMTUSE')"/>
      <el-table-column prop="mbewMYPOL" label="LIFO评估储备号 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewMYPOL')"/>
      <el-table-column prop="mbewOIPPINV" label="预付库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewOIPPINV')"/>
      <el-table-column prop="mbewOKLAS" label="VC: 供应商 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewOKLAS')"/>
      <el-table-column prop="mbewOWNPR" label="自制产品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewOWNPR')"/>
      <el-table-column prop="mbewPDATL" label="当前会计年度" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPDATL')"/>
      <el-table-column prop="mbewPDATV" label="上一会计年 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPDATV')"/>
      <el-table-column prop="mbewPDATZ" label="来年会计年度" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPDATZ')"/>
      <el-table-column prop="mbewPEINH" label="价格单位" align="center" v-if="columns.showColumn('mbewPEINH')"/>
      <el-table-column prop="mbewPPERL" label="期间成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPPERL')"/>
      <el-table-column prop="mbewPPERV" label="上期成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPPERV')"/>
      <el-table-column prop="mbewPPERZ" label="未来成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPPERZ')"/>
      <el-table-column prop="mbewPPRDL" label="当前期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPPRDL')"/>
      <el-table-column prop="mbewPPRDV" label="前一期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPPRDV')"/>
      <el-table-column prop="mbewPPRDZ" label="记帐期间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPPRDZ')"/>
      <el-table-column prop="mbewPSTAT" label="维护状态 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewPSTAT')"/>
      <el-table-column prop="mbewQKLAS" label="项目库存评估类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewQKLAS')"/>
      <el-table-column prop="mbewSALK3" label="总价值 " align="center" v-if="columns.showColumn('mbewSALK3')"/>
      <el-table-column prop="mbewSALKV" label="价值/MA价格" align="center" v-if="columns.showColumn('mbewSALKV')"/>
      <el-table-column prop="mbewSPERW" label="库存冻结" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewSPERW')"/>
      <el-table-column prop="mbewSTPRS" label="标准价格" align="center" v-if="columns.showColumn('mbewSTPRS')"/>
      <el-table-column prop="mbewSTPRV" label="上期价格" align="center" v-if="columns.showColumn('mbewSTPRV')"/>
      <el-table-column prop="mbewTIMESTAMP" label="时戳" align="center" v-if="columns.showColumn('mbewTIMESTAMP')"/>
      <el-table-column prop="mbewVBWST" label="上年评估策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVBWST')"/>
      <el-table-column prop="mbewVERPR" label="移动价格" align="center" v-if="columns.showColumn('mbewVERPR')"/>
      <el-table-column prop="mbewVERS1" label="成本核算版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVERS1')"/>
      <el-table-column prop="mbewVERS2" label="成本核算版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVERS2')"/>
      <el-table-column prop="mbewVERS3" label="成本核算版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVERS3')"/>
      <el-table-column prop="mbewVJBKL" label="上年估价类 " align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVJBKL')"/>
      <el-table-column prop="mbewVJBWH" label="商业价格 3" align="center" v-if="columns.showColumn('mbewVJBWH')"/>
      <el-table-column prop="mbewVJBWS" label="税价3" align="center" v-if="columns.showColumn('mbewVJBWS')"/>
      <el-table-column prop="mbewVJKUM" label="前年总库存值 " align="center" v-if="columns.showColumn('mbewVJKUM')"/>
      <el-table-column prop="mbewVJPEI" label="上年价格单位" align="center" v-if="columns.showColumn('mbewVJPEI')"/>
      <el-table-column prop="mbewVJSAL" label="上年总值 " align="center" v-if="columns.showColumn('mbewVJSAL')"/>
      <el-table-column prop="mbewVJSAV" label="上年价值 " align="center" v-if="columns.showColumn('mbewVJSAV')"/>
      <el-table-column prop="mbewVJSTP" label="去年标准价格" align="center" v-if="columns.showColumn('mbewVJSTP')"/>
      <el-table-column prop="mbewVJVER" label="去年移动平均价" align="center" v-if="columns.showColumn('mbewVJVER')"/>
      <el-table-column prop="mbewVJVPR" label="前一年价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVJVPR')"/>
      <el-table-column prop="mbewVKSAL" label="总SP值 " align="center" v-if="columns.showColumn('mbewVKSAL')"/>
      <el-table-column prop="mbewVMBKL" label="上期的评价分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVMBKL')"/>
      <el-table-column prop="mbewVMKUM" label="前期总库存 " align="center" v-if="columns.showColumn('mbewVMKUM')"/>
      <el-table-column prop="mbewVMPEI" label="上期间价格单位" align="center" v-if="columns.showColumn('mbewVMPEI')"/>
      <el-table-column prop="mbewVMSAL" label="前期总值 " align="center" v-if="columns.showColumn('mbewVMSAL')"/>
      <el-table-column prop="mbewVMSAV" label="上期的价值 " align="center" v-if="columns.showColumn('mbewVMSAV')"/>
      <el-table-column prop="mbewVMSTP" label="前期标准价格" align="center" v-if="columns.showColumn('mbewVMSTP')"/>
      <el-table-column prop="mbewVMVER" label="前期移动平均价" align="center" v-if="columns.showColumn('mbewVMVER')"/>
      <el-table-column prop="mbewVMVPR" label="前期间价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVMVPR')"/>
      <el-table-column prop="mbewVPLPR" label="上期标准价格" align="center" v-if="columns.showColumn('mbewVPLPR')"/>
      <el-table-column prop="mbewVPLPX" label="固定的上年计划价格" align="center" v-if="columns.showColumn('mbewVPLPX')"/>
      <el-table-column prop="mbewVPRSV" label="价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewVPRSV')"/>
      <el-table-column prop="mbewVVJLB" label="前年的总库存 " align="center" v-if="columns.showColumn('mbewVVJLB')"/>
      <el-table-column prop="mbewVVJSL" label="计价在 " align="center" v-if="columns.showColumn('mbewVVJSL')"/>
      <el-table-column prop="mbewVVMLB" label="前期的总库存值" align="center" v-if="columns.showColumn('mbewVVMLB')"/>
      <el-table-column prop="mbewVVSAL" label="计价在 " align="center" v-if="columns.showColumn('mbewVVSAL')"/>
      <el-table-column prop="mbewWLINL" label="最后实际盘点日" :show-overflow-tooltip="true"  v-if="columns.showColumn('mbewWLINL')"/>
      <el-table-column prop="mbewXBEWM" label="评估单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewXBEWM')"/>
      <el-table-column prop="mbewXLIFO" label="LIFO/FIFO-相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mbewXLIFO')"/>
      <el-table-column prop="mbewZKDAT" label="有效起始期 " :show-overflow-tooltip="true"  v-if="columns.showColumn('mbewZKDAT')"/>
      <el-table-column prop="mbewZKPRS" label="未来价格" align="center" v-if="columns.showColumn('mbewZKPRS')"/>
      <el-table-column prop="mbewZPLD1" label="计划价格日期 1" :show-overflow-tooltip="true"  v-if="columns.showColumn('mbewZPLD1')"/>
      <el-table-column prop="mbewZPLD2" label="计划价格日期 2" :show-overflow-tooltip="true"  v-if="columns.showColumn('mbewZPLD2')"/>
      <el-table-column prop="mbewZPLD3" label="计划价格日期 3" :show-overflow-tooltip="true"  v-if="columns.showColumn('mbewZPLD3')"/>
      <el-table-column prop="mbewZPLP1" label="计划价格 1" align="center" v-if="columns.showColumn('mbewZPLP1')"/>
      <el-table-column prop="mbewZPLP2" label="计划价格 2" align="center" v-if="columns.showColumn('mbewZPLP2')"/>
      <el-table-column prop="mbewZPLP3" label="计划价格 3" align="center" v-if="columns.showColumn('mbewZPLP3')"/>
      <el-table-column prop="mbewZPLPR" label="未来计划价格" align="center" v-if="columns.showColumn('mbewZPLPR')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="150" align="center">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:mbew:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:mbew:delete']" @click="handleDelete(scope.row)"></el-button>
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
            <el-form-item label="ID主键" prop="mbewSFID">
              <el-input v-model.number="form.mbewSFID" :placeholder="$t('btn.enter')+'ID主键'" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CC 库存盘点" prop="mbewABCIW">
              <el-input clearable v-model="form.mbewABCIW" :placeholder="$t('btn.enter')+'CC 库存盘点'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="贬值标识  " prop="mbewABWKZ">
              <el-input clearable v-model="form.mbewABWKZ" :placeholder="$t('btn.enter')+'贬值标识  '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类 " prop="mbewBKLAS">
              <el-select clearable filterable v-model="form.mbewBKLAS"  :placeholder="$t('btn.select')+'评估类 '">
                <el-option
                  v-for="item in options.app_val_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估范围" prop="mbewBWKEY">
              <el-select clearable filterable v-model="form.mbewBWKEY"  :placeholder="$t('btn.select')+'评估范围'">
                <el-option
                  v-for="item in options.app_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格单位" prop="mbewBWPEI">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewBWPEI" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'价格单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商业价格 2" prop="mbewBWPH1">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewBWPH1" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'商业价格 2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商业价格 1" prop="mbewBWPRH">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewBWPRH" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'商业价格 1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税价1" prop="mbewBWPRS">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewBWPRS" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'税价1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税价2" prop="mbewBWPS1">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewBWPS1" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'税价2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评价毛利" prop="mbewBWSPA">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewBWSPA" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'评价毛利'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类型" prop="mbewBWTAR">
              <el-input clearable v-model="form.mbewBWTAR" :placeholder="$t('btn.enter')+'评估类型'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类别" prop="mbewBWTTY">
              <el-input clearable v-model="form.mbewBWTTY" :placeholder="$t('btn.enter')+'评估类别'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估变式" prop="mbewBWVA1">
              <el-input clearable v-model="form.mbewBWVA1" :placeholder="$t('btn.enter')+'评估变式'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估变式" prop="mbewBWVA2">
              <el-input clearable v-model="form.mbewBWVA2" :placeholder="$t('btn.enter')+'评估变式'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估变式" prop="mbewBWVA3">
              <el-input clearable v-model="form.mbewBWVA3" :placeholder="$t('btn.enter')+'评估变式'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用QS的成本估算" prop="mbewEKALR">
              <el-input clearable v-model="form.mbewEKALR" :placeholder="$t('btn.enter')+'用QS的成本估算'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="VC:销售订单库存" prop="mbewEKLAS">
              <el-input clearable v-model="form.mbewEKLAS" :placeholder="$t('btn.enter')+'VC:销售订单库存'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来评估决策" prop="mbewFBWST">
              <el-input clearable v-model="form.mbewFBWST" :placeholder="$t('btn.enter')+'未来评估决策'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定的未来计划价格" prop="mbewFPLPX">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewFPLPX" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'固定的未来计划价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料来源" prop="mbewHKMAT">
              <el-input clearable v-model="form.mbewHKMAT" :placeholder="$t('btn.enter')+'物料来源'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原始组 " prop="mbewHRKFT">
              <el-input clearable v-model="form.mbewHRKFT" :placeholder="$t('btn.enter')+'原始组 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前成本估算" prop="mbewKALKL">
              <el-input clearable v-model="form.mbewKALKL" :placeholder="$t('btn.enter')+'当前成本估算'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期成本估计" prop="mbewKALKV">
              <el-input clearable v-model="form.mbewKALKV" :placeholder="$t('btn.enter')+'上期成本估计'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来成本估算" prop="mbewKALKZ">
              <el-input clearable v-model="form.mbewKALKZ" :placeholder="$t('btn.enter')+'未来成本估算'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品成本核算号" prop="mbewKALN1">
              <el-input clearable v-model="form.mbewKALN1" :placeholder="$t('btn.enter')+'产品成本核算号'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本估算编号" prop="mbewKALNR">
              <el-input clearable v-model="form.mbewKALNR" :placeholder="$t('btn.enter')+'成本估算编号'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般费用代码 " prop="mbewKALSC">
              <el-input clearable v-model="form.mbewKALSC" :placeholder="$t('btn.enter')+'一般费用代码 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接费分组 " prop="mbewKOSGR">
              <el-input clearable v-model="form.mbewKOSGR" :placeholder="$t('btn.enter')+'间接费分组 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="盘点库存VO物料" prop="mbewKZIWL">
              <el-input clearable v-model="form.mbewKZIWL" :placeholder="$t('btn.enter')+'盘点库存VO物料'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最近价格更改 " prop="mbewLAEPR">
              <el-date-picker v-model="form.mbewLAEPR" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总库存 " prop="mbewLBKUM">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewLBKUM" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'总库存 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前的值决策 " prop="mbewLBWST">
              <el-input clearable v-model="form.mbewLBWST" :placeholder="$t('btn.enter')+'当前的值决策 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="年  当前期间" prop="mbewLFGJA">
              <el-input clearable v-model="form.mbewLFGJA" :placeholder="$t('btn.enter')+'年  当前期间'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="本期" prop="mbewLFMON">
              <el-input clearable v-model="form.mbewLFMON" :placeholder="$t('btn.enter')+'本期'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前计划价格" prop="mbewLPLPR">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewLPLPR" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'当前计划价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定的当前计划价格" prop="mbewLPLPX">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewLPLPX" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'固定的当前计划价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类型" prop="mbewLVORM">
              <el-input clearable v-model="form.mbewLVORM" :placeholder="$t('btn.enter')+'评估类型'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团" prop="mbewMANDT">
              <el-input clearable v-model="form.mbewMANDT" :placeholder="$t('btn.enter')+'集团'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mbewMATNR">
              <el-input clearable v-model="form.mbewMATNR" :placeholder="$t('btn.enter')+'物料'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MBEW 最后期间之前，期间的 MBEW" prop="mbewMBRUE">
              <el-input clearable v-model="form.mbewMBRUE" :placeholder="$t('btn.enter')+'MBEW 最后期间之前，期间的 MBEW'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格确定" prop="mbewMLAST">
              <el-input clearable v-model="form.mbewMLAST" :placeholder="$t('btn.enter')+'价格确定'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ML 作业" prop="mbewMLMAA">
              <el-input clearable v-model="form.mbewMLMAA" :placeholder="$t('btn.enter')+'ML 作业'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料来源" prop="mbewMTORG">
              <el-input clearable v-model="form.mbewMTORG" :placeholder="$t('btn.enter')+'物料来源'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料用途 " prop="mbewMTUSE">
              <el-input clearable v-model="form.mbewMTUSE" :placeholder="$t('btn.enter')+'物料用途 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="LIFO评估储备号 " prop="mbewMYPOL">
              <el-input clearable v-model="form.mbewMYPOL" :placeholder="$t('btn.enter')+'LIFO评估储备号 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预付库存" prop="mbewOIPPINV">
              <el-input clearable v-model="form.mbewOIPPINV" :placeholder="$t('btn.enter')+'预付库存'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="VC: 供应商 " prop="mbewOKLAS">
              <el-input clearable v-model="form.mbewOKLAS" :placeholder="$t('btn.enter')+'VC: 供应商 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自制产品" prop="mbewOWNPR">
              <el-input clearable v-model="form.mbewOWNPR" :placeholder="$t('btn.enter')+'自制产品'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前会计年度" prop="mbewPDATL">
              <el-input clearable v-model="form.mbewPDATL" :placeholder="$t('btn.enter')+'当前会计年度'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上一会计年 " prop="mbewPDATV">
              <el-input clearable v-model="form.mbewPDATV" :placeholder="$t('btn.enter')+'上一会计年 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="来年会计年度" prop="mbewPDATZ">
              <el-input clearable v-model="form.mbewPDATZ" :placeholder="$t('btn.enter')+'来年会计年度'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格单位" prop="mbewPEINH">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewPEINH" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'价格单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间成本估算" prop="mbewPPERL">
              <el-input clearable v-model="form.mbewPPERL" :placeholder="$t('btn.enter')+'期间成本估算'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期成本估算" prop="mbewPPERV">
              <el-input clearable v-model="form.mbewPPERV" :placeholder="$t('btn.enter')+'上期成本估算'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来成本估算" prop="mbewPPERZ">
              <el-input clearable v-model="form.mbewPPERZ" :placeholder="$t('btn.enter')+'未来成本估算'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前期间" prop="mbewPPRDL">
              <el-input clearable v-model="form.mbewPPRDL" :placeholder="$t('btn.enter')+'当前期间'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前一期间" prop="mbewPPRDV">
              <el-input clearable v-model="form.mbewPPRDV" :placeholder="$t('btn.enter')+'前一期间'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="记帐期间" prop="mbewPPRDZ">
              <el-input clearable v-model="form.mbewPPRDZ" :placeholder="$t('btn.enter')+'记帐期间'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态 " prop="mbewPSTAT">
              <el-input clearable v-model="form.mbewPSTAT" :placeholder="$t('btn.enter')+'维护状态 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="项目库存评估类" prop="mbewQKLAS">
              <el-input clearable v-model="form.mbewQKLAS" :placeholder="$t('btn.enter')+'项目库存评估类'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总价值 " prop="mbewSALK3">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewSALK3" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'总价值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价值/MA价格" prop="mbewSALKV">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewSALKV" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'价值/MA价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存冻结" prop="mbewSPERW">
              <el-input clearable v-model="form.mbewSPERW" :placeholder="$t('btn.enter')+'库存冻结'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准价格" prop="mbewSTPRS">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewSTPRS" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'标准价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期价格" prop="mbewSTPRV">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewSTPRV" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'上期价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时戳" prop="mbewTIMESTAMP">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewTIMESTAMP" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'时戳'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年评估策略" prop="mbewVBWST">
              <el-input clearable v-model="form.mbewVBWST" :placeholder="$t('btn.enter')+'上年评估策略'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动价格" prop="mbewVERPR">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVERPR" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'移动价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本核算版本" prop="mbewVERS1">
              <el-input clearable v-model="form.mbewVERS1" :placeholder="$t('btn.enter')+'成本核算版本'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本核算版本" prop="mbewVERS2">
              <el-input clearable v-model="form.mbewVERS2" :placeholder="$t('btn.enter')+'成本核算版本'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本核算版本" prop="mbewVERS3">
              <el-input clearable v-model="form.mbewVERS3" :placeholder="$t('btn.enter')+'成本核算版本'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年估价类 " prop="mbewVJBKL">
              <el-input clearable v-model="form.mbewVJBKL" :placeholder="$t('btn.enter')+'上年估价类 '"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商业价格 3" prop="mbewVJBWH">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJBWH" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'商业价格 3'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税价3" prop="mbewVJBWS">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJBWS" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'税价3'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年总库存值 " prop="mbewVJKUM">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJKUM" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'前年总库存值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年价格单位" prop="mbewVJPEI">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJPEI" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'上年价格单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年总值 " prop="mbewVJSAL">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJSAL" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'上年总值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年价值 " prop="mbewVJSAV">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJSAV" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'上年价值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="去年标准价格" prop="mbewVJSTP">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJSTP" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'去年标准价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="去年移动平均价" prop="mbewVJVER">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVJVER" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'去年移动平均价'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前一年价格控制" prop="mbewVJVPR">
              <el-input clearable v-model="form.mbewVJVPR" :placeholder="$t('btn.enter')+'前一年价格控制'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总SP值 " prop="mbewVKSAL">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVKSAL" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'总SP值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期的评价分类" prop="mbewVMBKL">
              <el-input clearable v-model="form.mbewVMBKL" :placeholder="$t('btn.enter')+'上期的评价分类'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期总库存 " prop="mbewVMKUM">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVMKUM" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'前期总库存 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期间价格单位" prop="mbewVMPEI">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVMPEI" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'上期间价格单位'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期总值 " prop="mbewVMSAL">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVMSAL" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'前期总值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期的价值 " prop="mbewVMSAV">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVMSAV" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'上期的价值 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期标准价格" prop="mbewVMSTP">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVMSTP" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'前期标准价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期移动平均价" prop="mbewVMVER">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVMVER" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'前期移动平均价'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期间价格控制" prop="mbewVMVPR">
              <el-input clearable v-model="form.mbewVMVPR" :placeholder="$t('btn.enter')+'前期间价格控制'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期标准价格" prop="mbewVPLPR">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVPLPR" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'上期标准价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定的上年计划价格" prop="mbewVPLPX">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVPLPX" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'固定的上年计划价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格控制" prop="mbewVPRSV">
              <el-input clearable v-model="form.mbewVPRSV" :placeholder="$t('btn.enter')+'价格控制'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年的总库存 " prop="mbewVVJLB">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVVJLB" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'前年的总库存 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计价在 " prop="mbewVVJSL">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVVJSL" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'计价在 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期的总库存值" prop="mbewVVMLB">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVVMLB" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'前期的总库存值'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计价在 " prop="mbewVVSAL">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewVVSAL" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'计价在 '" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最后实际盘点日" prop="mbewWLINL">
              <el-date-picker v-model="form.mbewWLINL" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估单位" prop="mbewXBEWM">
              <el-input clearable v-model="form.mbewXBEWM" :placeholder="$t('btn.enter')+'评估单位'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="LIFO/FIFO-相关" prop="mbewXLIFO">
              <el-input clearable v-model="form.mbewXLIFO" :placeholder="$t('btn.enter')+'LIFO/FIFO-相关'"  maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始期 " prop="mbewZKDAT">
              <el-date-picker v-model="form.mbewZKDAT" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来价格" prop="mbewZKPRS">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewZKPRS" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'未来价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格日期 1" prop="mbewZPLD1">
              <el-date-picker v-model="form.mbewZPLD1" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格日期 2" prop="mbewZPLD2">
              <el-date-picker v-model="form.mbewZPLD2" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格日期 3" prop="mbewZPLD3">
              <el-date-picker v-model="form.mbewZPLD3" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格 1" prop="mbewZPLP1">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewZPLP1" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'计划价格 1'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格 2" prop="mbewZPLP2">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewZPLP2" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'计划价格 2'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格 3" prop="mbewZPLP3">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewZPLP3" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'计划价格 3'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格" prop="mbewZPLPR">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.mbewZPLPR" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'未来计划价格'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input clearable v-model="form.uDF01" :placeholder="$t('btn.enter')+'自定义A'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input clearable v-model="form.uDF02" :placeholder="$t('btn.enter')+'自定义B'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input clearable v-model="form.uDF03" :placeholder="$t('btn.enter')+'自定义C'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input clearable v-model="form.uDF04" :placeholder="$t('btn.enter')+'自定义D'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input clearable v-model="form.uDF05" :placeholder="$t('btn.enter')+'自定义E'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input clearable v-model="form.uDF06" :placeholder="$t('btn.enter')+'自定义F'"  :disabled="true" maxlength="10" show-word-limit/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF51" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义1'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF52" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义2'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF53" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义3'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF54" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义4'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF55" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义5'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.uDF56" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'自定义6'"  :disabled="true"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-input-number :precision="2" :step="0.1" :max="9999" v-model.number="form.isDeleted" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enter')+'备注'"/>
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

<script setup name="mbew">
//后台操作函数
import { listMbew,
 addMbew, delMbew, 
 updateMbew,getMbew, 
 } 
from '@/api/accounting/mbew.js'
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
  mbewBKLAS: undefined,
  mbewBWKEY: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'mbewSFID', label: 'ID主键' },
  { visible: true, prop: 'mbewABCIW', label: 'CC 库存盘点' },
  { visible: true, prop: 'mbewABWKZ', label: '贬值标识  ' },
  { visible: true, prop: 'mbewBKLAS', label: '评估类 ' },
  { visible: true, prop: 'mbewBWKEY', label: '评估范围' },
  { visible: true, prop: 'mbewBWPEI', label: '价格单位' },
  { visible: true, prop: 'mbewBWPH1', label: '商业价格 2' },
  { visible: true, prop: 'mbewBWPRH', label: '商业价格 1' },
  { visible: false, prop: 'mbewBWPRS', label: '税价1' },
  { visible: false, prop: 'mbewBWPS1', label: '税价2' },
  { visible: false, prop: 'mbewBWSPA', label: '评价毛利' },
  { visible: false, prop: 'mbewBWTAR', label: '评估类型' },
  { visible: false, prop: 'mbewBWTTY', label: '评估类别' },
  { visible: false, prop: 'mbewBWVA1', label: '评估变式' },
  { visible: false, prop: 'mbewBWVA2', label: '评估变式' },
  { visible: false, prop: 'mbewBWVA3', label: '评估变式' },
  { visible: false, prop: 'mbewEKALR', label: '用QS的成本估算' },
  { visible: false, prop: 'mbewEKLAS', label: 'VC:销售订单库存' },
  { visible: false, prop: 'mbewFBWST', label: '未来评估决策' },
  { visible: false, prop: 'mbewFPLPX', label: '固定的未来计划价格' },
  { visible: false, prop: 'mbewHKMAT', label: '物料来源' },
  { visible: false, prop: 'mbewHRKFT', label: '原始组 ' },
  { visible: false, prop: 'mbewKALKL', label: '当前成本估算' },
  { visible: false, prop: 'mbewKALKV', label: '上期成本估计' },
  { visible: false, prop: 'mbewKALKZ', label: '未来成本估算' },
  { visible: false, prop: 'mbewKALN1', label: '产品成本核算号' },
  { visible: false, prop: 'mbewKALNR', label: '成本估算编号' },
  { visible: false, prop: 'mbewKALSC', label: '一般费用代码 ' },
  { visible: false, prop: 'mbewKOSGR', label: '间接费分组 ' },
  { visible: false, prop: 'mbewKZIWL', label: '盘点库存VO物料' },
  { visible: false, prop: 'mbewLAEPR', label: '最近价格更改 ' },
  { visible: false, prop: 'mbewLBKUM', label: '总库存 ' },
  { visible: false, prop: 'mbewLBWST', label: '当前的值决策 ' },
  { visible: false, prop: 'mbewLFGJA', label: '年  当前期间' },
  { visible: false, prop: 'mbewLFMON', label: '本期' },
  { visible: false, prop: 'mbewLPLPR', label: '当前计划价格' },
  { visible: false, prop: 'mbewLPLPX', label: '固定的当前计划价格' },
  { visible: false, prop: 'mbewLVORM', label: '评估类型' },
  { visible: false, prop: 'mbewMANDT', label: '集团' },
  { visible: false, prop: 'mbewMATNR', label: '物料' },
  { visible: false, prop: 'mbewMBRUE', label: 'MBEW 最后期间之前，期间的 MBEW' },
  { visible: false, prop: 'mbewMLAST', label: '价格确定' },
  { visible: false, prop: 'mbewMLMAA', label: 'ML 作业' },
  { visible: false, prop: 'mbewMTORG', label: '物料来源' },
  { visible: false, prop: 'mbewMTUSE', label: '物料用途 ' },
  { visible: false, prop: 'mbewMYPOL', label: 'LIFO评估储备号 ' },
  { visible: false, prop: 'mbewOIPPINV', label: '预付库存' },
  { visible: false, prop: 'mbewOKLAS', label: 'VC: 供应商 ' },
  { visible: false, prop: 'mbewOWNPR', label: '自制产品' },
  { visible: false, prop: 'mbewPDATL', label: '当前会计年度' },
  { visible: false, prop: 'mbewPDATV', label: '上一会计年 ' },
  { visible: false, prop: 'mbewPDATZ', label: '来年会计年度' },
  { visible: false, prop: 'mbewPEINH', label: '价格单位' },
  { visible: false, prop: 'mbewPPERL', label: '期间成本估算' },
  { visible: false, prop: 'mbewPPERV', label: '上期成本估算' },
  { visible: false, prop: 'mbewPPERZ', label: '未来成本估算' },
  { visible: false, prop: 'mbewPPRDL', label: '当前期间' },
  { visible: false, prop: 'mbewPPRDV', label: '前一期间' },
  { visible: false, prop: 'mbewPPRDZ', label: '记帐期间' },
  { visible: false, prop: 'mbewPSTAT', label: '维护状态 ' },
  { visible: false, prop: 'mbewQKLAS', label: '项目库存评估类' },
  { visible: false, prop: 'mbewSALK3', label: '总价值 ' },
  { visible: false, prop: 'mbewSALKV', label: '价值/MA价格' },
  { visible: false, prop: 'mbewSPERW', label: '库存冻结' },
  { visible: false, prop: 'mbewSTPRS', label: '标准价格' },
  { visible: false, prop: 'mbewSTPRV', label: '上期价格' },
  { visible: false, prop: 'mbewTIMESTAMP', label: '时戳' },
  { visible: false, prop: 'mbewVBWST', label: '上年评估策略' },
  { visible: false, prop: 'mbewVERPR', label: '移动价格' },
  { visible: false, prop: 'mbewVERS1', label: '成本核算版本' },
  { visible: false, prop: 'mbewVERS2', label: '成本核算版本' },
  { visible: false, prop: 'mbewVERS3', label: '成本核算版本' },
  { visible: false, prop: 'mbewVJBKL', label: '上年估价类 ' },
  { visible: false, prop: 'mbewVJBWH', label: '商业价格 3' },
  { visible: false, prop: 'mbewVJBWS', label: '税价3' },
  { visible: false, prop: 'mbewVJKUM', label: '前年总库存值 ' },
  { visible: false, prop: 'mbewVJPEI', label: '上年价格单位' },
  { visible: false, prop: 'mbewVJSAL', label: '上年总值 ' },
  { visible: false, prop: 'mbewVJSAV', label: '上年价值 ' },
  { visible: false, prop: 'mbewVJSTP', label: '去年标准价格' },
  { visible: false, prop: 'mbewVJVER', label: '去年移动平均价' },
  { visible: false, prop: 'mbewVJVPR', label: '前一年价格控制' },
  { visible: false, prop: 'mbewVKSAL', label: '总SP值 ' },
  { visible: false, prop: 'mbewVMBKL', label: '上期的评价分类' },
  { visible: false, prop: 'mbewVMKUM', label: '前期总库存 ' },
  { visible: false, prop: 'mbewVMPEI', label: '上期间价格单位' },
  { visible: false, prop: 'mbewVMSAL', label: '前期总值 ' },
  { visible: false, prop: 'mbewVMSAV', label: '上期的价值 ' },
  { visible: false, prop: 'mbewVMSTP', label: '前期标准价格' },
  { visible: false, prop: 'mbewVMVER', label: '前期移动平均价' },
  { visible: false, prop: 'mbewVMVPR', label: '前期间价格控制' },
  { visible: false, prop: 'mbewVPLPR', label: '上期标准价格' },
  { visible: false, prop: 'mbewVPLPX', label: '固定的上年计划价格' },
  { visible: false, prop: 'mbewVPRSV', label: '价格控制' },
  { visible: false, prop: 'mbewVVJLB', label: '前年的总库存 ' },
  { visible: false, prop: 'mbewVVJSL', label: '计价在 ' },
  { visible: false, prop: 'mbewVVMLB', label: '前期的总库存值' },
  { visible: false, prop: 'mbewVVSAL', label: '计价在 ' },
  { visible: false, prop: 'mbewWLINL', label: '最后实际盘点日' },
  { visible: false, prop: 'mbewXBEWM', label: '评估单位' },
  { visible: false, prop: 'mbewXLIFO', label: 'LIFO/FIFO-相关' },
  { visible: false, prop: 'mbewZKDAT', label: '有效起始期 ' },
  { visible: false, prop: 'mbewZKPRS', label: '未来价格' },
  { visible: false, prop: 'mbewZPLD1', label: '计划价格日期 1' },
  { visible: false, prop: 'mbewZPLD2', label: '计划价格日期 2' },
  { visible: false, prop: 'mbewZPLD3', label: '计划价格日期 3' },
  { visible: false, prop: 'mbewZPLP1', label: '计划价格 1' },
  { visible: false, prop: 'mbewZPLP2', label: '计划价格 2' },
  { visible: false, prop: 'mbewZPLP3', label: '计划价格 3' },
  { visible: false, prop: 'mbewZPLPR', label: '未来计划价格' },
  { visible: false, prop: 'remark', label: '备注' },
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
  { dictType: "app_val_type" },
  { dictType: "app_plant_list" },
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
  listMbew(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.mbewSFID);
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
    mbewSFID: [{ required: true, message: 'ID主键'+ proxy.$t('btn.empty'), trigger: "blur" }],
    mbewBWKEY: [{ required: true, message: '评估范围'+ proxy.$t('btn.empty'), trigger: "change"     }],
    mbewBWPEI: [{ required: true, message: '价格单位'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewBWPH1: [{ required: true, message: '商业价格 2'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewBWPRH: [{ required: true, message: '商业价格 1'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewBWPRS: [{ required: true, message: '税价1'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewBWPS1: [{ required: true, message: '税价2'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewBWSPA: [{ required: true, message: '评价毛利'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewBWTAR: [{ required: true, message: '评估类型'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewFPLPX: [{ required: true, message: '固定的未来计划价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewLBKUM: [{ required: true, message: '总库存 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewLPLPR: [{ required: true, message: '当前计划价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewLPLPX: [{ required: true, message: '固定的当前计划价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewMANDT: [{ required: true, message: '集团'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewMATNR: [{ required: true, message: '物料'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewPEINH: [{ required: true, message: '价格单位'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewSALK3: [{ required: true, message: '总价值 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewSALKV: [{ required: true, message: '价值/MA价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewSTPRS: [{ required: true, message: '标准价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewSTPRV: [{ required: true, message: '上期价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewTIMESTAMP: [{ required: true, message: '时戳'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVERPR: [{ required: true, message: '移动价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJBWH: [{ required: true, message: '商业价格 3'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJBWS: [{ required: true, message: '税价3'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJKUM: [{ required: true, message: '前年总库存值 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJPEI: [{ required: true, message: '上年价格单位'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJSAL: [{ required: true, message: '上年总值 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJSAV: [{ required: true, message: '上年价值 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJSTP: [{ required: true, message: '去年标准价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVJVER: [{ required: true, message: '去年移动平均价'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVKSAL: [{ required: true, message: '总SP值 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVMKUM: [{ required: true, message: '前期总库存 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVMPEI: [{ required: true, message: '上期间价格单位'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVMSAL: [{ required: true, message: '前期总值 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVMSAV: [{ required: true, message: '上期的价值 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVMSTP: [{ required: true, message: '前期标准价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVMVER: [{ required: true, message: '前期移动平均价'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVPLPR: [{ required: true, message: '上期标准价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVPLPX: [{ required: true, message: '固定的上年计划价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVVJLB: [{ required: true, message: '前年的总库存 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVVJSL: [{ required: true, message: '计价在 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVVMLB: [{ required: true, message: '前期的总库存值'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewVVSAL: [{ required: true, message: '计价在 '+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewZKPRS: [{ required: true, message: '未来价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewZPLP1: [{ required: true, message: '计划价格 1'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewZPLP2: [{ required: true, message: '计划价格 2'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewZPLP3: [{ required: true, message: '计划价格 3'+ proxy.$t('btn.empty'), trigger: "blur"     }],
    mbewZPLPR: [{ required: true, message: '未来计划价格'+ proxy.$t('btn.empty'), trigger: "blur"     }],
  },
  options: {
    // 评估类  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_val_type: [],
    // 评估范围 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
app_plant_list: [],
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
// @Version: (0.24.389.27614)
// @Author: (Lean365)
// @Date: (2024/1/24 15:30:16)



// 重置表单
function reset() {
  form.value = {
    mbewSFID: 0,
    mbewABCIW: null,
    mbewABWKZ: null,
    mbewBKLAS: null,
    mbewBWKEY: null,
    mbewBWPEI: 0,
    mbewBWPH1: 0,
    mbewBWPRH: 0,
    mbewBWPRS: 0,
    mbewBWPS1: 0,
    mbewBWSPA: 0,
    mbewBWTAR: null,
    mbewBWTTY: null,
    mbewBWVA1: null,
    mbewBWVA2: null,
    mbewBWVA3: null,
    mbewEKALR: null,
    mbewEKLAS: null,
    mbewFBWST: null,
    mbewFPLPX: 0,
    mbewHKMAT: null,
    mbewHRKFT: null,
    mbewKALKL: null,
    mbewKALKV: null,
    mbewKALKZ: null,
    mbewKALN1: null,
    mbewKALNR: null,
    mbewKALSC: null,
    mbewKOSGR: null,
    mbewKZIWL: null,
    mbewLAEPR: null,
    mbewLBKUM: 0,
    mbewLBWST: null,
    mbewLFGJA: null,
    mbewLFMON: null,
    mbewLPLPR: 0,
    mbewLPLPX: 0,
    mbewLVORM: null,
    mbewMANDT: null,
    mbewMATNR: null,
    mbewMBRUE: null,
    mbewMLAST: null,
    mbewMLMAA: null,
    mbewMTORG: null,
    mbewMTUSE: null,
    mbewMYPOL: null,
    mbewOIPPINV: null,
    mbewOKLAS: null,
    mbewOWNPR: null,
    mbewPDATL: null,
    mbewPDATV: null,
    mbewPDATZ: null,
    mbewPEINH: 0,
    mbewPPERL: null,
    mbewPPERV: null,
    mbewPPERZ: null,
    mbewPPRDL: null,
    mbewPPRDV: null,
    mbewPPRDZ: null,
    mbewPSTAT: null,
    mbewQKLAS: null,
    mbewSALK3: 0,
    mbewSALKV: 0,
    mbewSPERW: null,
    mbewSTPRS: 0,
    mbewSTPRV: 0,
    mbewTIMESTAMP: 0,
    mbewVBWST: null,
    mbewVERPR: 0,
    mbewVERS1: null,
    mbewVERS2: null,
    mbewVERS3: null,
    mbewVJBKL: null,
    mbewVJBWH: 0,
    mbewVJBWS: 0,
    mbewVJKUM: 0,
    mbewVJPEI: 0,
    mbewVJSAL: 0,
    mbewVJSAV: 0,
    mbewVJSTP: 0,
    mbewVJVER: 0,
    mbewVJVPR: null,
    mbewVKSAL: 0,
    mbewVMBKL: null,
    mbewVMKUM: 0,
    mbewVMPEI: 0,
    mbewVMSAL: 0,
    mbewVMSAV: 0,
    mbewVMSTP: 0,
    mbewVMVER: 0,
    mbewVMVPR: null,
    mbewVPLPR: 0,
    mbewVPLPX: 0,
    mbewVPRSV: null,
    mbewVVJLB: 0,
    mbewVVJSL: 0,
    mbewVVMLB: 0,
    mbewVVSAL: 0,
    mbewWLINL: null,
    mbewXBEWM: null,
    mbewXLIFO: null,
    mbewZKDAT: null,
    mbewZKPRS: 0,
    mbewZPLD1: null,
    mbewZPLD2: null,
    mbewZPLD3: null,
    mbewZPLP1: 0,
    mbewZPLP2: 0,
    mbewZPLP3: 0,
    mbewZPLPR: 0,
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
  title.value = proxy.$t('btn.add')+'物料评估'
  opertype.value = 1
  form.value.mbewBKLAS= []
  form.value.mbewBWKEY= []
  form.value.mbewBWPEI= 0
  form.value.mbewBWPH1= 0
  form.value.mbewBWPRH= 0
  form.value.mbewBWPRS= 0
  form.value.mbewBWPS1= 0
  form.value.mbewBWSPA= 0
  form.value.mbewFPLPX= 0
  form.value.mbewLAEPR= new Date()
  form.value.mbewLBKUM= 0
  form.value.mbewLPLPR= 0
  form.value.mbewLPLPX= 0
  form.value.mbewPEINH= 0
  form.value.mbewSALK3= 0
  form.value.mbewSALKV= 0
  form.value.mbewSTPRS= 0
  form.value.mbewSTPRV= 0
  form.value.mbewTIMESTAMP= 0
  form.value.mbewVERPR= 0
  form.value.mbewVJBWH= 0
  form.value.mbewVJBWS= 0
  form.value.mbewVJKUM= 0
  form.value.mbewVJPEI= 0
  form.value.mbewVJSAL= 0
  form.value.mbewVJSAV= 0
  form.value.mbewVJSTP= 0
  form.value.mbewVJVER= 0
  form.value.mbewVKSAL= 0
  form.value.mbewVMKUM= 0
  form.value.mbewVMPEI= 0
  form.value.mbewVMSAL= 0
  form.value.mbewVMSAV= 0
  form.value.mbewVMSTP= 0
  form.value.mbewVMVER= 0
  form.value.mbewVPLPR= 0
  form.value.mbewVPLPX= 0
  form.value.mbewVVJLB= 0
  form.value.mbewVVJSL= 0
  form.value.mbewVVMLB= 0
  form.value.mbewVVSAL= 0
  form.value.mbewWLINL= new Date()
  form.value.mbewZKDAT= new Date()
  form.value.mbewZKPRS= 0
  form.value.mbewZPLD1= new Date()
  form.value.mbewZPLD2= new Date()
  form.value.mbewZPLD3= new Date()
  form.value.mbewZPLP1= 0
  form.value.mbewZPLP2= 0
  form.value.mbewZPLP3= 0
  form.value.mbewZPLPR= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.mbewSFID || ids.value
  getMbew(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value =proxy.$t('btn.edit')+ '物料评估'
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

      if (form.value.mbewSFID != undefined && opertype.value === 2) {
        updateMbew(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addMbew(form.value).then((res) => {
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
  const Ids = row.mbewSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.confirmDel')  + Ids + proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delMbew(Ids)
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
    .$confirm(proxy.$t('common.confirmExport')+"物料评估", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/accounting/Mbew/export', { ...queryParams })
    })
}


// @Descripttion: (自定义函数/CustomFunctions)
// @Functions: (assignValue,calculateValue,statisticValue)
// @Version: (0.24.389.27614)
// @Author: (Lean365)
// @Date: (2024/1/24 15:30:16)

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