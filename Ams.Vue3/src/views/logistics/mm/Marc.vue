<!--
 * @Descripttion: 工厂物料/mm_marc
 * @Version: 0.24.620.18453
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 11:30:16
 * @column：252
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="mc004">
        <el-select filterable clearable   v-model="queryParams.mc004" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="物料号" prop="mc003">
        <el-input v-model="queryParams.mc003" :placeholder="$t('btn.enterSearchPrefix')+'物料号'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['mm:marc:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['mm:marc:delete']" plain icon="delete" @click="handleDelete">
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
                <importData
                  templateUrl="Logistics/MmMarc/importTemplate"
                  importUrl="/Logistics/MmMarc/importData"
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
      <el-table-column prop="mc002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc002')"/>
      <el-table-column prop="mc004" label="工厂" align="center" v-if="columns.showColumn('mc004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mc004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mc003" label="物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc003')"/>
      <el-table-column prop="mc005" label="维护状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc005')"/>
      <el-table-column prop="mc006" label="工厂级删除" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc006')"/>
      <el-table-column prop="mc007" label="评估类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc007')"/>
      <el-table-column prop="mc008" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc008')"/>
      <el-table-column prop="mc009" label="PS物料状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc009')"/>
      <el-table-column prop="mc010" label="有效起始日" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc010')"/>
      <el-table-column prop="mc011" label="ABC标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc011')"/>
      <el-table-column prop="mc012" label="关键部件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc012')"/>
      <el-table-column prop="mc013" label="采购组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc013')"/>
      <el-table-column prop="mc014" label="发货单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc014')"/>
      <el-table-column prop="mc015" label="MRP 参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc015')"/>
      <el-table-column prop="mc016" label="MRP 类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc016')"/>
      <el-table-column prop="mc017" label="MRP 控制者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc017')"/>
      <el-table-column prop="mc018" label="MRP 控制者买方" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc018')"/>
      <el-table-column prop="mc019" label="计划交货天数" align="center" v-if="columns.showColumn('mc019')"/>
      <el-table-column prop="mc020" label="收货处理时间" align="center" v-if="columns.showColumn('mc020')"/>
      <el-table-column prop="mc021" label="期间标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc021')"/>
      <el-table-column prop="mc022" label="装配报废" align="center" v-if="columns.showColumn('mc022')"/>
      <el-table-column prop="mc023" label="批量大小" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc023')"/>
      <el-table-column prop="mc024" label="采购" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc024')"/>
      <el-table-column prop="mc025" label="特殊采购" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc025')"/>
      <el-table-column prop="mc026" label="再订货点" align="center" v-if="columns.showColumn('mc026')"/>
      <el-table-column prop="mc027" label="安全库存" align="center" v-if="columns.showColumn('mc027')"/>
      <el-table-column prop="mc028" label="最小批量" align="center" v-if="columns.showColumn('mc028')"/>
      <el-table-column prop="mc029" label="最大批量" align="center" v-if="columns.showColumn('mc029')"/>
      <el-table-column prop="mc030" label="固定批量" align="center" v-if="columns.showColumn('mc030')"/>
      <el-table-column prop="mc031" label="舍入值" align="center" v-if="columns.showColumn('mc031')"/>
      <el-table-column prop="mc032" label="最大库存水平" align="center" v-if="columns.showColumn('mc032')"/>
      <el-table-column prop="mc033" label="订购成本" align="center" v-if="columns.showColumn('mc033')"/>
      <el-table-column prop="mc034" label="独立/集中" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc034')"/>
      <el-table-column prop="mc035" label="库存成本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc035')"/>
      <el-table-column prop="mc036" label="选择方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc036')"/>
      <el-table-column prop="mc037" label="非连续标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc037')"/>
      <el-table-column prop="mc038" label="中断日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc038')"/>
      <el-table-column prop="mc039" label="后续物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc039')"/>
      <el-table-column prop="mc040" label="需求分组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc040')"/>
      <el-table-column prop="mc041" label="综合MRP" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc041')"/>
      <el-table-column prop="mc042" label="计划边际码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc042')"/>
      <el-table-column prop="mc043" label="自动更改工厂订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc043')"/>
      <el-table-column prop="mc044" label="自动批准" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc044')"/>
      <el-table-column prop="mc045" label="反冲" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc045')"/>
      <el-table-column prop="mc046" label="生产管理员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc046')"/>
      <el-table-column prop="mc047" label="处理时间" align="center" v-if="columns.showColumn('mc047')"/>
      <el-table-column prop="mc048" label="准备时间" align="center" v-if="columns.showColumn('mc048')"/>
      <el-table-column prop="mc049" label="工序间" align="center" v-if="columns.showColumn('mc049')"/>
      <el-table-column prop="mc050" label="基准数量" align="center" v-if="columns.showColumn('mc050')"/>
      <el-table-column prop="mc051" label="厂内生产时间" align="center" v-if="columns.showColumn('mc051')"/>
      <el-table-column prop="mc052" label="最大存储期间" align="center" v-if="columns.showColumn('mc052')"/>
      <el-table-column prop="mc053" label="时间单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc053')"/>
      <el-table-column prop="mc054" label="从产品货位库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc054')"/>
      <el-table-column prop="mc055" label="初步计划" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc055')"/>
      <el-table-column prop="mc056" label="超量交货容差" align="center" v-if="columns.showColumn('mc056')"/>
      <el-table-column prop="mc057" label="未限制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc057')"/>
      <el-table-column prop="mc058" label="不足交货容差" align="center" v-if="columns.showColumn('mc058')"/>
      <el-table-column prop="mc059" label="总计补货提前时间" align="center" v-if="columns.showColumn('mc059')"/>
      <el-table-column prop="mc060" label="替换部件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc060')"/>
      <el-table-column prop="mc061" label="附加费" align="center" v-if="columns.showColumn('mc061')"/>
      <el-table-column prop="mc062" label="生产状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc062')"/>
      <el-table-column prop="mc063" label="过帐到检验库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc063')"/>
      <el-table-column prop="mc064" label="样本" align="center" v-if="columns.showColumn('mc064')"/>
      <el-table-column prop="mc065" label="隔离" align="center" v-if="columns.showColumn('mc065')"/>
      <el-table-column prop="mc066" label="控制码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc066')"/>
      <el-table-column prop="mc067" label="平均检查持续期" align="center" v-if="columns.showColumn('mc067')"/>
      <el-table-column prop="mc068" label="检查计划" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc068')"/>
      <el-table-column prop="mc069" label="凭证需求" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc069')"/>
      <el-table-column prop="mc070" label="活动性物质" align="center" v-if="columns.showColumn('mc070')"/>
      <el-table-column prop="mc071" label="检查间隔" align="center" v-if="columns.showColumn('mc071')"/>
      <el-table-column prop="mc072" label="下一次检查" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc072')"/>
      <el-table-column prop="mc073" label="中转库存" align="center" v-if="columns.showColumn('mc073')"/>
      <el-table-column prop="mc074" label="装载组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc074')"/>
      <el-table-column prop="mc075" label="批次管理需求" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc075')"/>
      <el-table-column prop="mc076" label="配额使用" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc076')"/>
      <el-table-column prop="mc077" label="服务水平" align="center" v-if="columns.showColumn('mc077')"/>
      <el-table-column prop="mc078" label="分割标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc078')"/>
      <el-table-column prop="mc079" label="计划版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc079')"/>
      <el-table-column prop="mc080" label="对象类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc080')"/>
      <el-table-column prop="mc081" label="对象标识" align="center" v-if="columns.showColumn('mc081')"/>
      <el-table-column prop="mc082" label="可用性检查" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc082')"/>
      <el-table-column prop="mc083" label="会计年度变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc083')"/>
      <el-table-column prop="mc084" label="修正因子" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc084')"/>
      <el-table-column prop="mc085" label="准备时间" align="center" v-if="columns.showColumn('mc085')"/>
      <el-table-column prop="mc086" label="基准数量" align="center" v-if="columns.showColumn('mc086')"/>
      <el-table-column prop="mc087" label="处理时间" align="center" v-if="columns.showColumn('mc087')"/>
      <el-table-column prop="mc088" label="取消激活的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc088')"/>
      <el-table-column prop="mc089" label="货源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc089')"/>
      <el-table-column prop="mc090" label="自动采购订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc090')"/>
      <el-table-column prop="mc091" label="源清单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc091')"/>
      <el-table-column prop="mc092" label="商品代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc092')"/>
      <el-table-column prop="mc093" label="原产地国" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc093')"/>
      <el-table-column prop="mc094" label="货源地" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc094')"/>
      <el-table-column prop="mc095" label="商品代码单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc095')"/>
      <el-table-column prop="mc096" label="出口/进口组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc096')"/>
      <el-table-column prop="mc097" label="利润中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc097')"/>
      <el-table-column prop="mc098" label="在途库存" align="center" v-if="columns.showColumn('mc098')"/>
      <el-table-column prop="mc099" label="计划日历" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc099')"/>
      <el-table-column prop="mc100" label="重复生产" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc100')"/>
      <el-table-column prop="mc101" label="计划的时界" align="center" v-if="columns.showColumn('mc101')"/>
      <el-table-column prop="mc102" label="消耗模式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc102')"/>
      <el-table-column prop="mc103" label="消耗期间:逆向" align="center" v-if="columns.showColumn('mc103')"/>
      <el-table-column prop="mc104" label="消耗时期-向前" align="center" v-if="columns.showColumn('mc104')"/>
      <el-table-column prop="mc105" label="版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc105')"/>
      <el-table-column prop="mc106" label="可选 BOM" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc106')"/>
      <el-table-column prop="mc107" label="BOM 用途" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc107')"/>
      <el-table-column prop="mc108" label="组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc108')"/>
      <el-table-column prop="mc109" label="组计数器" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc109')"/>
      <el-table-column prop="mc110" label="成本核算批次" align="center" v-if="columns.showColumn('mc110')"/>
      <el-table-column prop="mc111" label="特殊工艺类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc111')"/>
      <el-table-column prop="mc112" label="生产单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc112')"/>
      <el-table-column prop="mc113" label="发货库存地点" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc113')"/>
      <el-table-column prop="mc114" label="MRP组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc114')"/>
      <el-table-column prop="mc115" label="组件报废" align="center" v-if="columns.showColumn('mc115')"/>
      <el-table-column prop="mc116" label="证书类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc116')"/>
      <el-table-column prop="mc117" label="检验设置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc117')"/>
      <el-table-column prop="mc118" label="间隔时间" align="center" v-if="columns.showColumn('mc118')"/>
      <el-table-column prop="mc119" label="供货天数参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc119')"/>
      <el-table-column prop="mc120" label="局部字段名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc120')"/>
      <el-table-column prop="mc121" label="周期盘点标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc121')"/>
      <el-table-column prop="mc122" label="差异码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc122')"/>
      <el-table-column prop="mc123" label="序列号参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc123')"/>
      <el-table-column prop="mc124" label="内部对象号" align="center" v-if="columns.showColumn('mc124')"/>
      <el-table-column prop="mc125" label="可配置的物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc125')"/>
      <el-table-column prop="mc126" label="重复生产参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc126')"/>
      <el-table-column prop="mc127" label="负库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc127')"/>
      <el-table-column prop="mc128" label="目标QM系统" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc128')"/>
      <el-table-column prop="mc129" label="计划周期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc129')"/>
      <el-table-column prop="mc130" label="舍入参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc130')"/>
      <el-table-column prop="mc131" label="消耗" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc131')"/>
      <el-table-column prop="mc132" label="寄存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc132')"/>
      <el-table-column prop="mc133" label="消耗日期到" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc133')"/>
      <el-table-column prop="mc134" label="乘数" align="center" v-if="columns.showColumn('mc134')"/>
      <el-table-column prop="mc135" label="自动重置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc135')"/>
      <el-table-column prop="mc136" label="优先权" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc136')"/>
      <el-table-column prop="mc137" label="免税证明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc137')"/>
      <el-table-column prop="mc138" label="免税证书编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc138')"/>
      <el-table-column prop="mc139" label="免税证书的发放日" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc139')"/>
      <el-table-column prop="mc140" label="供应商申报" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc140')"/>
      <el-table-column prop="mc141" label="供应商申报日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mc141')"/>
      <el-table-column prop="mc142" label="军用物资" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc142')"/>
      <el-table-column prop="mc143" label="服务级别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc143')"/>
      <el-table-column prop="mc144" label="联产品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc144')"/>
      <el-table-column prop="mc145" label="策略组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc145')"/>
      <el-table-column prop="mc146" label="内部对象号" align="center" v-if="columns.showColumn('mc146')"/>
      <el-table-column prop="mc147" label="外部采购仓储位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc147')"/>
      <el-table-column prop="mc148" label="散装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc148')"/>
      <el-table-column prop="mc149" label="周期标识被固定" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc149')"/>
      <el-table-column prop="mc150" label="库存确定组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc150')"/>
      <el-table-column prop="mc151" label="QM 物料授权组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc151')"/>
      <el-table-column prop="mc152" label="调整期间" align="center" v-if="columns.showColumn('mc152')"/>
      <el-table-column prop="mc153" label="任务清单类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc153')"/>
      <el-table-column prop="mc154" label="计量单位组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc154')"/>
      <el-table-column prop="mc155" label="转换组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc155')"/>
      <el-table-column prop="mc156" label="空气浮力因子" align="center" v-if="columns.showColumn('mc156')"/>
      <el-table-column prop="mc157" label="生产参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc157')"/>
      <el-table-column prop="mc158" label="安全时间标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc158')"/>
      <el-table-column prop="mc159" label="安全时间" align="center" v-if="columns.showColumn('mc159')"/>
      <el-table-column prop="mc160" label="活动控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc160')"/>
      <el-table-column prop="mc161" label="批量输入" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc161')"/>
      <el-table-column prop="mc162" label="计量单位组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc162')"/>
      <el-table-column prop="mc163" label="物料运输组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc163')"/>
      <el-table-column prop="mc164" label="库存转移SV" align="center" v-if="columns.showColumn('mc164')"/>
      <el-table-column prop="mc165" label="运输库存SP" align="center" v-if="columns.showColumn('mc165')"/>
      <el-table-column prop="mc166" label="平滑促销消耗" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc166')"/>
      <el-table-column prop="mc167" label="生产版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc167')"/>
      <el-table-column prop="mc168" label="固定价格联产品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc168')"/>
      <el-table-column prop="mc169" label="后勤组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc169')"/>
      <el-table-column prop="mc170" label="分销参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc170')"/>
      <el-table-column prop="mc171" label="有约束的虚拟库存" align="center" v-if="columns.showColumn('mc171')"/>
      <el-table-column prop="mc172" label="空缺库存销售价" align="center" v-if="columns.showColumn('mc172')"/>
      <el-table-column prop="mc173" label="物料类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc173')"/>
      <el-table-column prop="mc174" label="EU产品清单编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc174')"/>
      <el-table-column prop="mc175" label="CAP 产品组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc175')"/>
      <el-table-column prop="mc176" label="CAS 号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc176')"/>
      <el-table-column prop="mc177" label="PRODCOM 号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc177')"/>
      <el-table-column prop="mc178" label="控制代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc178')"/>
      <el-table-column prop="mc179" label="JIT标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc179')"/>
      <el-table-column prop="mc180" label="物料组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc180')"/>
      <el-table-column prop="mc181" label="建议供应区域" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc181')"/>
      <el-table-column prop="mc182" label="公平分享规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc182')"/>
      <el-table-column prop="mc183" label="推式分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc183')"/>
      <el-table-column prop="mc184" label="发布界限" align="center" v-if="columns.showColumn('mc184')"/>
      <el-table-column prop="mc185" label="最小批量" align="center" v-if="columns.showColumn('mc185')"/>
      <el-table-column prop="mc186" label="最大批量" align="center" v-if="columns.showColumn('mc186')"/>
      <el-table-column prop="mc187" label="固定批量" align="center" v-if="columns.showColumn('mc187')"/>
      <el-table-column prop="mc188" label="批尺寸增加" align="center" v-if="columns.showColumn('mc188')"/>
      <el-table-column prop="mc189" label="该字段不再使用" align="center" v-if="columns.showColumn('mc189')"/>
      <el-table-column prop="mc190" label="转换类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc190')"/>
      <el-table-column prop="mc191" label="ST期间参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc191')"/>
      <el-table-column prop="mc192" label="MRP 相关需求" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc192')"/>
      <el-table-column prop="mc193" label="MRP 范围存在" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc193')"/>
      <el-table-column prop="mc194" label="跨项目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc194')"/>
      <el-table-column prop="mc195" label="总体参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc195')"/>
      <el-table-column prop="mc196" label="APO 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc196')"/>
      <el-table-column prop="mc197" label="最后的MARD" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc197')"/>
      <el-table-column prop="mc198" label="当前期间 (记帐期间)" align="center" v-if="columns.showColumn('mc198')"/>
      <el-table-column prop="mc199" label="当前期间的会计年度" align="center" v-if="columns.showColumn('mc199')"/>
      <el-table-column prop="mc200" label="最小安全库存" align="center" v-if="columns.showColumn('mc200')"/>
      <el-table-column prop="mc201" label="无成本核算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc201')"/>
      <el-table-column prop="mc202" label="库存入库和出库" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc202')"/>
      <el-table-column prop="mc203" label="OB管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc203')"/>
      <el-table-column prop="mc204" label="OB参考物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc204')"/>
      <el-table-column prop="mc205" label="评估收货锁定库存" align="center" v-if="columns.showColumn('mc205')"/>
      <el-table-column prop="mc206" label="分段策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc206')"/>
      <el-table-column prop="mc207" label="分段状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc207')"/>
      <el-table-column prop="mc208" label="分段范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc208')"/>
      <el-table-column prop="mc209" label="排序库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc209')"/>
      <el-table-column prop="mc210" label="消耗优先级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc210')"/>
      <el-table-column prop="mc211" label="离散批次编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc211')"/>
      <el-table-column prop="mc212" label="库存保护" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc212')"/>
      <el-table-column prop="mc213" label="订单分配运行" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc213')"/>
      <el-table-column prop="mc214" label="库存管理中激活季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc214')"/>
      <el-table-column prop="mc215" label="包装组 (VSO)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc215')"/>
      <el-table-column prop="mc216" label="提货行 (VSO)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc216')"/>
      <el-table-column prop="mc217" label="物料编号 (VSO)" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc217')"/>
      <el-table-column prop="mc218" label="纵向提取" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc218')"/>
      <el-table-column prop="mc219" label="IUID相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc219')"/>
      <el-table-column prop="mc220" label="IUID类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc220')"/>
      <el-table-column prop="mc221" label="外部分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc221')"/>
      <el-table-column prop="mc222" label="寄售控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc222')"/>
      <el-table-column prop="mc223" label="发货处理时间" align="center" v-if="columns.showColumn('mc223')"/>
      <el-table-column prop="mc224" label="交叉的采购组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc224')"/>
      <el-table-column prop="mc225" label="参考确定方案" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mc225')"/>
      <el-table-column prop="mc226" label="最小目标范围" align="center" v-if="columns.showColumn('mc226')"/>
      <el-table-column prop="mc227" label="最大目标范围" align="center" v-if="columns.showColumn('mc227')"/>
      <el-table-column prop="mc228" label="目标库存" align="center" v-if="columns.showColumn('mc228')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['mm:marc:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['mm:marc:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改工厂物料对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="mc002">
              <el-input   v-model="form.mc002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂" prop="mc004">
              <el-select filterable clearable   v-model="form.mc004"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料号" prop="mc003">
              <el-input   v-model="form.mc003" :placeholder="$t('btn.enterPrefix')+'物料号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态" prop="mc005">
              <el-input   v-model="form.mc005" :placeholder="$t('btn.enterPrefix')+'维护状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工厂级删除" prop="mc006">
              <el-input   v-model="form.mc006" :placeholder="$t('btn.enterPrefix')+'工厂级删除'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类别" prop="mc007">
              <el-input   v-model="form.mc007" :placeholder="$t('btn.enterPrefix')+'评估类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="mc008">
              <el-input   v-model="form.mc008" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PS物料状态" prop="mc009">
              <el-input   v-model="form.mc009" :placeholder="$t('btn.enterPrefix')+'PS物料状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始日" prop="mc010">
              <el-date-picker v-model="form.mc010" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ABC标识" prop="mc011">
              <el-input   v-model="form.mc011" :placeholder="$t('btn.enterPrefix')+'ABC标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="关键部件" prop="mc012">
              <el-input   v-model="form.mc012" :placeholder="$t('btn.enterPrefix')+'关键部件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购组" prop="mc013">
              <el-input   v-model="form.mc013" :placeholder="$t('btn.enterPrefix')+'采购组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发货单位" prop="mc014">
              <el-input   v-model="form.mc014" :placeholder="$t('btn.enterPrefix')+'发货单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 参数文件" prop="mc015">
              <el-input   v-model="form.mc015" :placeholder="$t('btn.enterPrefix')+'MRP 参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 类型" prop="mc016">
              <el-input   v-model="form.mc016" :placeholder="$t('btn.enterPrefix')+'MRP 类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 控制者" prop="mc017">
              <el-input   v-model="form.mc017" :placeholder="$t('btn.enterPrefix')+'MRP 控制者'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 控制者买方" prop="mc018">
              <el-input   v-model="form.mc018" :placeholder="$t('btn.enterPrefix')+'MRP 控制者买方'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划交货天数" prop="mc019">
              <el-input-number v-model.number="form.mc019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'计划交货天数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="收货处理时间" prop="mc020">
              <el-input-number v-model.number="form.mc020" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'收货处理时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间标识" prop="mc021">
              <el-input   v-model="form.mc021" :placeholder="$t('btn.enterPrefix')+'期间标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装配报废" prop="mc022">
              <el-input-number v-model.number="form.mc022" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'装配报废'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批量大小" prop="mc023">
              <el-input   v-model="form.mc023" :placeholder="$t('btn.enterPrefix')+'批量大小'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购" prop="mc024">
              <el-input   v-model="form.mc024" :placeholder="$t('btn.enterPrefix')+'采购'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特殊采购" prop="mc025">
              <el-input   v-model="form.mc025" :placeholder="$t('btn.enterPrefix')+'特殊采购'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="再订货点" prop="mc026">
              <el-input-number v-model.number="form.mc026" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'再订货点'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安全库存" prop="mc027">
              <el-input-number v-model.number="form.mc027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'安全库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小批量" prop="mc028">
              <el-input-number v-model.number="form.mc028" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最小批量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大批量" prop="mc029">
              <el-input-number v-model.number="form.mc029" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大批量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定批量" prop="mc030">
              <el-input-number v-model.number="form.mc030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'固定批量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入值" prop="mc031">
              <el-input-number v-model.number="form.mc031" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'舍入值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大库存水平" prop="mc032">
              <el-input-number v-model.number="form.mc032" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大库存水平'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订购成本" prop="mc033">
              <el-input-number v-model.number="form.mc033" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'订购成本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="独立/集中" prop="mc034">
              <el-input   v-model="form.mc034" :placeholder="$t('btn.enterPrefix')+'独立/集中'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存成本" prop="mc035">
              <el-input   v-model="form.mc035" :placeholder="$t('btn.enterPrefix')+'库存成本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="选择方法" prop="mc036">
              <el-input   v-model="form.mc036" :placeholder="$t('btn.enterPrefix')+'选择方法'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="非连续标识" prop="mc037">
              <el-input   v-model="form.mc037" :placeholder="$t('btn.enterPrefix')+'非连续标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="中断日期" prop="mc038">
              <el-date-picker v-model="form.mc038" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后续物料" prop="mc039">
              <el-input   v-model="form.mc039" :placeholder="$t('btn.enterPrefix')+'后续物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="需求分组" prop="mc040">
              <el-input   v-model="form.mc040" :placeholder="$t('btn.enterPrefix')+'需求分组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="综合MRP" prop="mc041">
              <el-input   v-model="form.mc041" :placeholder="$t('btn.enterPrefix')+'综合MRP'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划边际码" prop="mc042">
              <el-input   v-model="form.mc042" :placeholder="$t('btn.enterPrefix')+'计划边际码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动更改工厂订单" prop="mc043">
              <el-input   v-model="form.mc043" :placeholder="$t('btn.enterPrefix')+'自动更改工厂订单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动批准" prop="mc044">
              <el-input   v-model="form.mc044" :placeholder="$t('btn.enterPrefix')+'自动批准'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="反冲" prop="mc045">
              <el-input   v-model="form.mc045" :placeholder="$t('btn.enterPrefix')+'反冲'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产管理员" prop="mc046">
              <el-input   v-model="form.mc046" :placeholder="$t('btn.enterPrefix')+'生产管理员'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理时间" prop="mc047">
              <el-input-number v-model.number="form.mc047" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'处理时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="准备时间" prop="mc048">
              <el-input-number v-model.number="form.mc048" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'准备时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工序间" prop="mc049">
              <el-input-number v-model.number="form.mc049" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工序间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基准数量" prop="mc050">
              <el-input-number v-model.number="form.mc050" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基准数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="厂内生产时间" prop="mc051">
              <el-input-number v-model.number="form.mc051" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'厂内生产时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大存储期间" prop="mc052">
              <el-input-number v-model.number="form.mc052" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大存储期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时间单位" prop="mc053">
              <el-input   v-model="form.mc053" :placeholder="$t('btn.enterPrefix')+'时间单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="从产品货位库存" prop="mc054">
              <el-input   v-model="form.mc054" :placeholder="$t('btn.enterPrefix')+'从产品货位库存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="初步计划" prop="mc055">
              <el-input   v-model="form.mc055" :placeholder="$t('btn.enterPrefix')+'初步计划'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超量交货容差" prop="mc056">
              <el-input-number v-model.number="form.mc056" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'超量交货容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未限制" prop="mc057">
              <el-input   v-model="form.mc057" :placeholder="$t('btn.enterPrefix')+'未限制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不足交货容差" prop="mc058">
              <el-input-number v-model.number="form.mc058" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'不足交货容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总计补货提前时间" prop="mc059">
              <el-input-number v-model.number="form.mc059" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总计补货提前时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="替换部件" prop="mc060">
              <el-input   v-model="form.mc060" :placeholder="$t('btn.enterPrefix')+'替换部件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="附加费" prop="mc061">
              <el-input-number v-model.number="form.mc061" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'附加费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产状态" prop="mc062">
              <el-input   v-model="form.mc062" :placeholder="$t('btn.enterPrefix')+'生产状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过帐到检验库存" prop="mc063">
              <el-input   v-model="form.mc063" :placeholder="$t('btn.enterPrefix')+'过帐到检验库存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="样本" prop="mc064">
              <el-input-number v-model.number="form.mc064" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'样本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="隔离" prop="mc065">
              <el-input-number v-model.number="form.mc065" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'隔离'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="控制码" prop="mc066">
              <el-input   v-model="form.mc066" :placeholder="$t('btn.enterPrefix')+'控制码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="平均检查持续期" prop="mc067">
              <el-input-number v-model.number="form.mc067" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'平均检查持续期'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查计划" prop="mc068">
              <el-input   v-model="form.mc068" :placeholder="$t('btn.enterPrefix')+'检查计划'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证需求" prop="mc069">
              <el-input   v-model="form.mc069" :placeholder="$t('btn.enterPrefix')+'凭证需求'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="活动性物质" prop="mc070">
              <el-input-number v-model.number="form.mc070" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'活动性物质'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查间隔" prop="mc071">
              <el-input-number v-model.number="form.mc071" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查间隔'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="下一次检查" prop="mc072">
              <el-date-picker v-model="form.mc072" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="中转库存" prop="mc073">
              <el-input-number v-model.number="form.mc073" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'中转库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装载组" prop="mc074">
              <el-input   v-model="form.mc074" :placeholder="$t('btn.enterPrefix')+'装载组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理需求" prop="mc075">
              <el-input   v-model="form.mc075" :placeholder="$t('btn.enterPrefix')+'批次管理需求'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="配额使用" prop="mc076">
              <el-input   v-model="form.mc076" :placeholder="$t('btn.enterPrefix')+'配额使用'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="服务水平" prop="mc077">
              <el-input-number v-model.number="form.mc077" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'服务水平'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分割标识" prop="mc078">
              <el-input   v-model="form.mc078" :placeholder="$t('btn.enterPrefix')+'分割标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划版本" prop="mc079">
              <el-input   v-model="form.mc079" :placeholder="$t('btn.enterPrefix')+'计划版本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="对象类型" prop="mc080">
              <el-input   v-model="form.mc080" :placeholder="$t('btn.enterPrefix')+'对象类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="对象标识" prop="mc081">
              <el-input-number v-model.number="form.mc081" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'对象标识'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可用性检查" prop="mc082">
              <el-input   v-model="form.mc082" :placeholder="$t('btn.enterPrefix')+'可用性检查'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="会计年度变式" prop="mc083">
              <el-input   v-model="form.mc083" :placeholder="$t('btn.enterPrefix')+'会计年度变式'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="修正因子" prop="mc084">
              <el-input   v-model="form.mc084" :placeholder="$t('btn.enterPrefix')+'修正因子'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="准备时间" prop="mc085">
              <el-input-number v-model.number="form.mc085" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'准备时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基准数量" prop="mc086">
              <el-input-number v-model.number="form.mc086" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'基准数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理时间" prop="mc087">
              <el-input-number v-model.number="form.mc087" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'处理时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="取消激活的" prop="mc088">
              <el-input   v-model="form.mc088" :placeholder="$t('btn.enterPrefix')+'取消激活的'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="货源" prop="mc089">
              <el-input   v-model="form.mc089" :placeholder="$t('btn.enterPrefix')+'货源'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动采购订单" prop="mc090">
              <el-input   v-model="form.mc090" :placeholder="$t('btn.enterPrefix')+'自动采购订单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="源清单" prop="mc091">
              <el-input   v-model="form.mc091" :placeholder="$t('btn.enterPrefix')+'源清单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商品代码" prop="mc092">
              <el-input   v-model="form.mc092" :placeholder="$t('btn.enterPrefix')+'商品代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="34"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原产地国" prop="mc093">
              <el-input   v-model="form.mc093" :placeholder="$t('btn.enterPrefix')+'原产地国'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="货源地" prop="mc094">
              <el-input   v-model="form.mc094" :placeholder="$t('btn.enterPrefix')+'货源地'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商品代码单位" prop="mc095">
              <el-input   v-model="form.mc095" :placeholder="$t('btn.enterPrefix')+'商品代码单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出口/进口组" prop="mc096">
              <el-input   v-model="form.mc096" :placeholder="$t('btn.enterPrefix')+'出口/进口组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="利润中心" prop="mc097">
              <el-input   v-model="form.mc097" :placeholder="$t('btn.enterPrefix')+'利润中心'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="在途库存" prop="mc098">
              <el-input-number v-model.number="form.mc098" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'在途库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划日历" prop="mc099">
              <el-input   v-model="form.mc099" :placeholder="$t('btn.enterPrefix')+'计划日历'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重复生产" prop="mc100">
              <el-input   v-model="form.mc100" :placeholder="$t('btn.enterPrefix')+'重复生产'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="计划的时界" prop="mc101">
              <el-input-number v-model.number="form.mc101" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'计划的时界'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="消耗模式" prop="mc102">
              <el-input   v-model="form.mc102" :placeholder="$t('btn.enterPrefix')+'消耗模式'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="消耗期间:逆向" prop="mc103">
              <el-input-number v-model.number="form.mc103" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'消耗期间:逆向'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="消耗时期-向前" prop="mc104">
              <el-input-number v-model.number="form.mc104" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'消耗时期-向前'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="版本" prop="mc105">
              <el-input   v-model="form.mc105" :placeholder="$t('btn.enterPrefix')+'版本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可选 BOM" prop="mc106">
              <el-input   v-model="form.mc106" :placeholder="$t('btn.enterPrefix')+'可选 BOM'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="BOM 用途" prop="mc107">
              <el-input   v-model="form.mc107" :placeholder="$t('btn.enterPrefix')+'BOM 用途'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组" prop="mc108">
              <el-input   v-model="form.mc108" :placeholder="$t('btn.enterPrefix')+'组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组计数器" prop="mc109">
              <el-input   v-model="form.mc109" :placeholder="$t('btn.enterPrefix')+'组计数器'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本核算批次" prop="mc110">
              <el-input-number v-model.number="form.mc110" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'成本核算批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特殊工艺类型" prop="mc111">
              <el-input   v-model="form.mc111" :placeholder="$t('btn.enterPrefix')+'特殊工艺类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产单位" prop="mc112">
              <el-input   v-model="form.mc112" :placeholder="$t('btn.enterPrefix')+'生产单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发货库存地点" prop="mc113">
              <el-input   v-model="form.mc113" :placeholder="$t('btn.enterPrefix')+'发货库存地点'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP组" prop="mc114">
              <el-input   v-model="form.mc114" :placeholder="$t('btn.enterPrefix')+'MRP组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件报废" prop="mc115">
              <el-input-number v-model.number="form.mc115" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'组件报废'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="证书类型" prop="mc116">
              <el-input   v-model="form.mc116" :placeholder="$t('btn.enterPrefix')+'证书类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验设置" prop="mc117">
              <el-input   v-model="form.mc117" :placeholder="$t('btn.enterPrefix')+'检验设置'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间隔时间" prop="mc118">
              <el-input-number v-model.number="form.mc118" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间隔时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供货天数参数文件" prop="mc119">
              <el-input   v-model="form.mc119" :placeholder="$t('btn.enterPrefix')+'供货天数参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="局部字段名" prop="mc120">
              <el-input   v-model="form.mc120" :placeholder="$t('btn.enterPrefix')+'局部字段名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="周期盘点标识" prop="mc121">
              <el-input   v-model="form.mc121" :placeholder="$t('btn.enterPrefix')+'周期盘点标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差异码" prop="mc122">
              <el-input   v-model="form.mc122" :placeholder="$t('btn.enterPrefix')+'差异码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号参数文件" prop="mc123">
              <el-input   v-model="form.mc123" :placeholder="$t('btn.enterPrefix')+'序列号参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部对象号" prop="mc124">
              <el-input-number v-model.number="form.mc124" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'内部对象号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可配置的物料" prop="mc125">
              <el-input   v-model="form.mc125" :placeholder="$t('btn.enterPrefix')+'可配置的物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重复生产参数文件" prop="mc126">
              <el-input   v-model="form.mc126" :placeholder="$t('btn.enterPrefix')+'重复生产参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="负库存" prop="mc127">
              <el-input   v-model="form.mc127" :placeholder="$t('btn.enterPrefix')+'负库存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="目标QM系统" prop="mc128">
              <el-input   v-model="form.mc128" :placeholder="$t('btn.enterPrefix')+'目标QM系统'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划周期" prop="mc129">
              <el-input   v-model="form.mc129" :placeholder="$t('btn.enterPrefix')+'计划周期'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入参数文件" prop="mc130">
              <el-input   v-model="form.mc130" :placeholder="$t('btn.enterPrefix')+'舍入参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="消耗" prop="mc131">
              <el-input   v-model="form.mc131" :placeholder="$t('btn.enterPrefix')+'消耗'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="寄存" prop="mc132">
              <el-input   v-model="form.mc132" :placeholder="$t('btn.enterPrefix')+'寄存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="消耗日期到" prop="mc133">
              <el-date-picker v-model="form.mc133" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="乘数" prop="mc134">
              <el-input-number v-model.number="form.mc134" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'乘数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自动重置" prop="mc135">
              <el-input   v-model="form.mc135" :placeholder="$t('btn.enterPrefix')+'自动重置'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="优先权" prop="mc136">
              <el-input   v-model="form.mc136" :placeholder="$t('btn.enterPrefix')+'优先权'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="免税证明" prop="mc137">
              <el-input   v-model="form.mc137" :placeholder="$t('btn.enterPrefix')+'免税证明'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="免税证书编号" prop="mc138">
              <el-input   v-model="form.mc138" :placeholder="$t('btn.enterPrefix')+'免税证书编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="免税证书的发放日" prop="mc139">
              <el-date-picker v-model="form.mc139" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商申报" prop="mc140">
              <el-input   v-model="form.mc140" :placeholder="$t('btn.enterPrefix')+'供应商申报'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商申报日期" prop="mc141">
              <el-date-picker v-model="form.mc141" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="军用物资" prop="mc142">
              <el-input   v-model="form.mc142" :placeholder="$t('btn.enterPrefix')+'军用物资'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="服务级别" prop="mc143">
              <el-input   v-model="form.mc143" :placeholder="$t('btn.enterPrefix')+'服务级别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联产品" prop="mc144">
              <el-input   v-model="form.mc144" :placeholder="$t('btn.enterPrefix')+'联产品'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="策略组" prop="mc145">
              <el-input   v-model="form.mc145" :placeholder="$t('btn.enterPrefix')+'策略组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部对象号" prop="mc146">
              <el-input-number v-model.number="form.mc146" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'内部对象号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部采购仓储位置" prop="mc147">
              <el-input   v-model="form.mc147" :placeholder="$t('btn.enterPrefix')+'外部采购仓储位置'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="散装物料" prop="mc148">
              <el-input   v-model="form.mc148" :placeholder="$t('btn.enterPrefix')+'散装物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="周期标识被固定" prop="mc149">
              <el-input   v-model="form.mc149" :placeholder="$t('btn.enterPrefix')+'周期标识被固定'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存确定组" prop="mc150">
              <el-input   v-model="form.mc150" :placeholder="$t('btn.enterPrefix')+'库存确定组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QM 物料授权组" prop="mc151">
              <el-input   v-model="form.mc151" :placeholder="$t('btn.enterPrefix')+'QM 物料授权组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="调整期间" prop="mc152">
              <el-input-number v-model.number="form.mc152" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'调整期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="任务清单类型" prop="mc153">
              <el-input   v-model="form.mc153" :placeholder="$t('btn.enterPrefix')+'任务清单类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位组" prop="mc154">
              <el-input   v-model="form.mc154" :placeholder="$t('btn.enterPrefix')+'计量单位组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转换组" prop="mc155">
              <el-input   v-model="form.mc155" :placeholder="$t('btn.enterPrefix')+'转换组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="空气浮力因子" prop="mc156">
              <el-input-number v-model.number="form.mc156" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'空气浮力因子'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产参数文件" prop="mc157">
              <el-input   v-model="form.mc157" :placeholder="$t('btn.enterPrefix')+'生产参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安全时间标识" prop="mc158">
              <el-input   v-model="form.mc158" :placeholder="$t('btn.enterPrefix')+'安全时间标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="安全时间" prop="mc159">
              <el-input-number v-model.number="form.mc159" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'安全时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="活动控制" prop="mc160">
              <el-input   v-model="form.mc160" :placeholder="$t('btn.enterPrefix')+'活动控制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批量输入" prop="mc161">
              <el-input   v-model="form.mc161" :placeholder="$t('btn.enterPrefix')+'批量输入'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位组" prop="mc162">
              <el-input   v-model="form.mc162" :placeholder="$t('btn.enterPrefix')+'计量单位组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料运输组" prop="mc163">
              <el-input   v-model="form.mc163" :placeholder="$t('btn.enterPrefix')+'物料运输组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存转移SV" prop="mc164">
              <el-input-number v-model.number="form.mc164" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'库存转移SV'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="运输库存SP" prop="mc165">
              <el-input-number v-model.number="form.mc165" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'运输库存SP'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="平滑促销消耗" prop="mc166">
              <el-input   v-model="form.mc166" :placeholder="$t('btn.enterPrefix')+'平滑促销消耗'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产版本" prop="mc167">
              <el-input   v-model="form.mc167" :placeholder="$t('btn.enterPrefix')+'生产版本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定价格联产品" prop="mc168">
              <el-input   v-model="form.mc168" :placeholder="$t('btn.enterPrefix')+'固定价格联产品'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤组" prop="mc169">
              <el-input   v-model="form.mc169" :placeholder="$t('btn.enterPrefix')+'后勤组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分销参数文件" prop="mc170">
              <el-input   v-model="form.mc170" :placeholder="$t('btn.enterPrefix')+'分销参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有约束的虚拟库存" prop="mc171">
              <el-input-number v-model.number="form.mc171" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'有约束的虚拟库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="空缺库存销售价" prop="mc172">
              <el-input-number v-model.number="form.mc172" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'空缺库存销售价'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类别" prop="mc173">
              <el-input   v-model="form.mc173" :placeholder="$t('btn.enterPrefix')+'物料类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EU产品清单编号" prop="mc174">
              <el-input   v-model="form.mc174" :placeholder="$t('btn.enterPrefix')+'EU产品清单编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="24"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CAP 产品组" prop="mc175">
              <el-input   v-model="form.mc175" :placeholder="$t('btn.enterPrefix')+'CAP 产品组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CAS 号码" prop="mc176">
              <el-input   v-model="form.mc176" :placeholder="$t('btn.enterPrefix')+'CAS 号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PRODCOM 号码" prop="mc177">
              <el-input   v-model="form.mc177" :placeholder="$t('btn.enterPrefix')+'PRODCOM 号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="18"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="控制代码" prop="mc178">
              <el-input   v-model="form.mc178" :placeholder="$t('btn.enterPrefix')+'控制代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="32"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="JIT标识" prop="mc179">
              <el-input   v-model="form.mc179" :placeholder="$t('btn.enterPrefix')+'JIT标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组" prop="mc180">
              <el-input   v-model="form.mc180" :placeholder="$t('btn.enterPrefix')+'物料组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="建议供应区域" prop="mc181">
              <el-input   v-model="form.mc181" :placeholder="$t('btn.enterPrefix')+'建议供应区域'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公平分享规则" prop="mc182">
              <el-input   v-model="form.mc182" :placeholder="$t('btn.enterPrefix')+'公平分享规则'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="推式分配" prop="mc183">
              <el-input   v-model="form.mc183" :placeholder="$t('btn.enterPrefix')+'推式分配'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发布界限" prop="mc184">
              <el-input-number v-model.number="form.mc184" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'发布界限'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小批量" prop="mc185">
              <el-input-number v-model.number="form.mc185" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最小批量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大批量" prop="mc186">
              <el-input-number v-model.number="form.mc186" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大批量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固定批量" prop="mc187">
              <el-input-number v-model.number="form.mc187" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'固定批量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批尺寸增加" prop="mc188">
              <el-input-number v-model.number="form.mc188" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'批尺寸增加'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="该字段不再使用" prop="mc189">
              <el-input-number v-model.number="form.mc189" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'该字段不再使用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转换类型" prop="mc190">
              <el-input   v-model="form.mc190" :placeholder="$t('btn.enterPrefix')+'转换类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ST期间参数文件" prop="mc191">
              <el-input   v-model="form.mc191" :placeholder="$t('btn.enterPrefix')+'ST期间参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 相关需求" prop="mc192">
              <el-input   v-model="form.mc192" :placeholder="$t('btn.enterPrefix')+'MRP 相关需求'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="MRP 范围存在" prop="mc193">
              <el-input   v-model="form.mc193" :placeholder="$t('btn.enterPrefix')+'MRP 范围存在'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨项目" prop="mc194">
              <el-input   v-model="form.mc194" :placeholder="$t('btn.enterPrefix')+'跨项目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总体参数文件" prop="mc195">
              <el-input   v-model="form.mc195" :placeholder="$t('btn.enterPrefix')+'总体参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="APO 相关" prop="mc196">
              <el-input   v-model="form.mc196" :placeholder="$t('btn.enterPrefix')+'APO 相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最后的MARD" prop="mc197">
              <el-input   v-model="form.mc197" :placeholder="$t('btn.enterPrefix')+'最后的MARD'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前期间 (记帐期间)" prop="mc198">
              <el-input-number v-model.number="form.mc198" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前期间 (记帐期间)'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前期间的会计年度" prop="mc199">
              <el-input-number v-model.number="form.mc199" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前期间的会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小安全库存" prop="mc200">
              <el-input-number v-model.number="form.mc200" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最小安全库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="无成本核算" prop="mc201">
              <el-input   v-model="form.mc201" :placeholder="$t('btn.enterPrefix')+'无成本核算'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存入库和出库" prop="mc202">
              <el-input   v-model="form.mc202" :placeholder="$t('btn.enterPrefix')+'库存入库和出库'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="OB管理" prop="mc203">
              <el-input   v-model="form.mc203" :placeholder="$t('btn.enterPrefix')+'OB管理'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="OB参考物料" prop="mc204">
              <el-input   v-model="form.mc204" :placeholder="$t('btn.enterPrefix')+'OB参考物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估收货锁定库存" prop="mc205">
              <el-input-number v-model.number="form.mc205" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'评估收货锁定库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段策略" prop="mc206">
              <el-input   v-model="form.mc206" :placeholder="$t('btn.enterPrefix')+'分段策略'+$t('btn.enterSuffix')"  show-word-limit   maxlength="16"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段状态" prop="mc207">
              <el-input   v-model="form.mc207" :placeholder="$t('btn.enterPrefix')+'分段状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段范围" prop="mc208">
              <el-input   v-model="form.mc208" :placeholder="$t('btn.enterPrefix')+'分段范围'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="排序库存" prop="mc209">
              <el-input   v-model="form.mc209" :placeholder="$t('btn.enterPrefix')+'排序库存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="消耗优先级" prop="mc210">
              <el-input   v-model="form.mc210" :placeholder="$t('btn.enterPrefix')+'消耗优先级'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="离散批次编号" prop="mc211">
              <el-input   v-model="form.mc211" :placeholder="$t('btn.enterPrefix')+'离散批次编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存保护" prop="mc212">
              <el-input   v-model="form.mc212" :placeholder="$t('btn.enterPrefix')+'库存保护'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单分配运行" prop="mc213">
              <el-input   v-model="form.mc213" :placeholder="$t('btn.enterPrefix')+'订单分配运行'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存管理中激活季节" prop="mc214">
              <el-input   v-model="form.mc214" :placeholder="$t('btn.enterPrefix')+'库存管理中激活季节'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装组 (VSO)" prop="mc215">
              <el-input   v-model="form.mc215" :placeholder="$t('btn.enterPrefix')+'包装组 (VSO)'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="提货行 (VSO)" prop="mc216">
              <el-input   v-model="form.mc216" :placeholder="$t('btn.enterPrefix')+'提货行 (VSO)'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料编号 (VSO)" prop="mc217">
              <el-input   v-model="form.mc217" :placeholder="$t('btn.enterPrefix')+'物料编号 (VSO)'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="纵向提取" prop="mc218">
              <el-input   v-model="form.mc218" :placeholder="$t('btn.enterPrefix')+'纵向提取'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IUID相关" prop="mc219">
              <el-input   v-model="form.mc219" :placeholder="$t('btn.enterPrefix')+'IUID相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IUID类型" prop="mc220">
              <el-input   v-model="form.mc220" :placeholder="$t('btn.enterPrefix')+'IUID类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部分配" prop="mc221">
              <el-input   v-model="form.mc221" :placeholder="$t('btn.enterPrefix')+'外部分配'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="寄售控制" prop="mc222">
              <el-input   v-model="form.mc222" :placeholder="$t('btn.enterPrefix')+'寄售控制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发货处理时间" prop="mc223">
              <el-input-number v-model.number="form.mc223" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'发货处理时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="交叉的采购组" prop="mc224">
              <el-input   v-model="form.mc224" :placeholder="$t('btn.enterPrefix')+'交叉的采购组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参考确定方案" prop="mc225">
              <el-input   v-model="form.mc225" :placeholder="$t('btn.enterPrefix')+'参考确定方案'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="最小目标范围" prop="mc226">
              <el-input-number v-model.number="form.mc226" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最小目标范围'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="最大目标范围" prop="mc227">
              <el-input-number v-model.number="form.mc227" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大目标范围'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="目标库存" prop="mc228">
              <el-input-number v-model.number="form.mc228" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'目标库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注说明" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500"/>
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
import { listMmMarc,
 addMmMarc, delMmMarc, 
 updateMmMarc,getMmMarc, 
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
  sort: 'Mc003',
  sortType: 'asc',
  //是否查询（1是）
  mc004: undefined,
  //是否查询（1是）
  mc003: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mc002', label: '集团' },
  { visible: true, prop: 'mc004', label: '工厂' },
  { visible: true, prop: 'mc003', label: '物料号' },
  { visible: true, prop: 'mc005', label: '维护状态' },
  { visible: true, prop: 'mc006', label: '工厂级删除' },
  { visible: true, prop: 'mc007', label: '评估类别' },
  { visible: true, prop: 'mc008', label: '批次' },
  { visible: false, prop: 'mc009', label: 'PS物料状态' },
  { visible: false, prop: 'mc010', label: '有效起始日' },
  { visible: false, prop: 'mc011', label: 'ABC标识' },
  { visible: false, prop: 'mc012', label: '关键部件' },
  { visible: false, prop: 'mc013', label: '采购组' },
  { visible: false, prop: 'mc014', label: '发货单位' },
  { visible: false, prop: 'mc015', label: 'MRP 参数文件' },
  { visible: false, prop: 'mc016', label: 'MRP 类型' },
  { visible: false, prop: 'mc017', label: 'MRP 控制者' },
  { visible: false, prop: 'mc018', label: 'MRP 控制者买方' },
  { visible: false, prop: 'mc019', label: '计划交货天数' },
  { visible: false, prop: 'mc020', label: '收货处理时间' },
  { visible: false, prop: 'mc021', label: '期间标识' },
  { visible: false, prop: 'mc022', label: '装配报废' },
  { visible: false, prop: 'mc023', label: '批量大小' },
  { visible: false, prop: 'mc024', label: '采购' },
  { visible: false, prop: 'mc025', label: '特殊采购' },
  { visible: false, prop: 'mc026', label: '再订货点' },
  { visible: false, prop: 'mc027', label: '安全库存' },
  { visible: false, prop: 'mc028', label: '最小批量' },
  { visible: false, prop: 'mc029', label: '最大批量' },
  { visible: false, prop: 'mc030', label: '固定批量' },
  { visible: false, prop: 'mc031', label: '舍入值' },
  { visible: false, prop: 'mc032', label: '最大库存水平' },
  { visible: false, prop: 'mc033', label: '订购成本' },
  { visible: false, prop: 'mc034', label: '独立/集中' },
  { visible: false, prop: 'mc035', label: '库存成本' },
  { visible: false, prop: 'mc036', label: '选择方法' },
  { visible: false, prop: 'mc037', label: '非连续标识' },
  { visible: false, prop: 'mc038', label: '中断日期' },
  { visible: false, prop: 'mc039', label: '后续物料' },
  { visible: false, prop: 'mc040', label: '需求分组' },
  { visible: false, prop: 'mc041', label: '综合MRP' },
  { visible: false, prop: 'mc042', label: '计划边际码' },
  { visible: false, prop: 'mc043', label: '自动更改工厂订单' },
  { visible: false, prop: 'mc044', label: '自动批准' },
  { visible: false, prop: 'mc045', label: '反冲' },
  { visible: false, prop: 'mc046', label: '生产管理员' },
  { visible: false, prop: 'mc047', label: '处理时间' },
  { visible: false, prop: 'mc048', label: '准备时间' },
  { visible: false, prop: 'mc049', label: '工序间' },
  { visible: false, prop: 'mc050', label: '基准数量' },
  { visible: false, prop: 'mc051', label: '厂内生产时间' },
  { visible: false, prop: 'mc052', label: '最大存储期间' },
  { visible: false, prop: 'mc053', label: '时间单位' },
  { visible: false, prop: 'mc054', label: '从产品货位库存' },
  { visible: false, prop: 'mc055', label: '初步计划' },
  { visible: false, prop: 'mc056', label: '超量交货容差' },
  { visible: false, prop: 'mc057', label: '未限制' },
  { visible: false, prop: 'mc058', label: '不足交货容差' },
  { visible: false, prop: 'mc059', label: '总计补货提前时间' },
  { visible: false, prop: 'mc060', label: '替换部件' },
  { visible: false, prop: 'mc061', label: '附加费' },
  { visible: false, prop: 'mc062', label: '生产状态' },
  { visible: false, prop: 'mc063', label: '过帐到检验库存' },
  { visible: false, prop: 'mc064', label: '样本' },
  { visible: false, prop: 'mc065', label: '隔离' },
  { visible: false, prop: 'mc066', label: '控制码' },
  { visible: false, prop: 'mc067', label: '平均检查持续期' },
  { visible: false, prop: 'mc068', label: '检查计划' },
  { visible: false, prop: 'mc069', label: '凭证需求' },
  { visible: false, prop: 'mc070', label: '活动性物质' },
  { visible: false, prop: 'mc071', label: '检查间隔' },
  { visible: false, prop: 'mc072', label: '下一次检查' },
  { visible: false, prop: 'mc073', label: '中转库存' },
  { visible: false, prop: 'mc074', label: '装载组' },
  { visible: false, prop: 'mc075', label: '批次管理需求' },
  { visible: false, prop: 'mc076', label: '配额使用' },
  { visible: false, prop: 'mc077', label: '服务水平' },
  { visible: false, prop: 'mc078', label: '分割标识' },
  { visible: false, prop: 'mc079', label: '计划版本' },
  { visible: false, prop: 'mc080', label: '对象类型' },
  { visible: false, prop: 'mc081', label: '对象标识' },
  { visible: false, prop: 'mc082', label: '可用性检查' },
  { visible: false, prop: 'mc083', label: '会计年度变式' },
  { visible: false, prop: 'mc084', label: '修正因子' },
  { visible: false, prop: 'mc085', label: '准备时间' },
  { visible: false, prop: 'mc086', label: '基准数量' },
  { visible: false, prop: 'mc087', label: '处理时间' },
  { visible: false, prop: 'mc088', label: '取消激活的' },
  { visible: false, prop: 'mc089', label: '货源' },
  { visible: false, prop: 'mc090', label: '自动采购订单' },
  { visible: false, prop: 'mc091', label: '源清单' },
  { visible: false, prop: 'mc092', label: '商品代码' },
  { visible: false, prop: 'mc093', label: '原产地国' },
  { visible: false, prop: 'mc094', label: '货源地' },
  { visible: false, prop: 'mc095', label: '商品代码单位' },
  { visible: false, prop: 'mc096', label: '出口/进口组' },
  { visible: false, prop: 'mc097', label: '利润中心' },
  { visible: false, prop: 'mc098', label: '在途库存' },
  { visible: false, prop: 'mc099', label: '计划日历' },
  { visible: false, prop: 'mc100', label: '重复生产' },
  { visible: false, prop: 'mc101', label: '计划的时界' },
  { visible: false, prop: 'mc102', label: '消耗模式' },
  { visible: false, prop: 'mc103', label: '消耗期间:逆向' },
  { visible: false, prop: 'mc104', label: '消耗时期-向前' },
  { visible: false, prop: 'mc105', label: '版本' },
  { visible: false, prop: 'mc106', label: '可选 BOM' },
  { visible: false, prop: 'mc107', label: 'BOM 用途' },
  { visible: false, prop: 'mc108', label: '组' },
  { visible: false, prop: 'mc109', label: '组计数器' },
  { visible: false, prop: 'mc110', label: '成本核算批次' },
  { visible: false, prop: 'mc111', label: '特殊工艺类型' },
  { visible: false, prop: 'mc112', label: '生产单位' },
  { visible: false, prop: 'mc113', label: '发货库存地点' },
  { visible: false, prop: 'mc114', label: 'MRP组' },
  { visible: false, prop: 'mc115', label: '组件报废' },
  { visible: false, prop: 'mc116', label: '证书类型' },
  { visible: false, prop: 'mc117', label: '检验设置' },
  { visible: false, prop: 'mc118', label: '间隔时间' },
  { visible: false, prop: 'mc119', label: '供货天数参数文件' },
  { visible: false, prop: 'mc120', label: '局部字段名' },
  { visible: false, prop: 'mc121', label: '周期盘点标识' },
  { visible: false, prop: 'mc122', label: '差异码' },
  { visible: false, prop: 'mc123', label: '序列号参数文件' },
  { visible: false, prop: 'mc124', label: '内部对象号' },
  { visible: false, prop: 'mc125', label: '可配置的物料' },
  { visible: false, prop: 'mc126', label: '重复生产参数文件' },
  { visible: false, prop: 'mc127', label: '负库存' },
  { visible: false, prop: 'mc128', label: '目标QM系统' },
  { visible: false, prop: 'mc129', label: '计划周期' },
  { visible: false, prop: 'mc130', label: '舍入参数文件' },
  { visible: false, prop: 'mc131', label: '消耗' },
  { visible: false, prop: 'mc132', label: '寄存' },
  { visible: false, prop: 'mc133', label: '消耗日期到' },
  { visible: false, prop: 'mc134', label: '乘数' },
  { visible: false, prop: 'mc135', label: '自动重置' },
  { visible: false, prop: 'mc136', label: '优先权' },
  { visible: false, prop: 'mc137', label: '免税证明' },
  { visible: false, prop: 'mc138', label: '免税证书编号' },
  { visible: false, prop: 'mc139', label: '免税证书的发放日' },
  { visible: false, prop: 'mc140', label: '供应商申报' },
  { visible: false, prop: 'mc141', label: '供应商申报日期' },
  { visible: false, prop: 'mc142', label: '军用物资' },
  { visible: false, prop: 'mc143', label: '服务级别' },
  { visible: false, prop: 'mc144', label: '联产品' },
  { visible: false, prop: 'mc145', label: '策略组' },
  { visible: false, prop: 'mc146', label: '内部对象号' },
  { visible: false, prop: 'mc147', label: '外部采购仓储位置' },
  { visible: false, prop: 'mc148', label: '散装物料' },
  { visible: false, prop: 'mc149', label: '周期标识被固定' },
  { visible: false, prop: 'mc150', label: '库存确定组' },
  { visible: false, prop: 'mc151', label: 'QM 物料授权组' },
  { visible: false, prop: 'mc152', label: '调整期间' },
  { visible: false, prop: 'mc153', label: '任务清单类型' },
  { visible: false, prop: 'mc154', label: '计量单位组' },
  { visible: false, prop: 'mc155', label: '转换组' },
  { visible: false, prop: 'mc156', label: '空气浮力因子' },
  { visible: false, prop: 'mc157', label: '生产参数文件' },
  { visible: false, prop: 'mc158', label: '安全时间标识' },
  { visible: false, prop: 'mc159', label: '安全时间' },
  { visible: false, prop: 'mc160', label: '活动控制' },
  { visible: false, prop: 'mc161', label: '批量输入' },
  { visible: false, prop: 'mc162', label: '计量单位组' },
  { visible: false, prop: 'mc163', label: '物料运输组' },
  { visible: false, prop: 'mc164', label: '库存转移SV' },
  { visible: false, prop: 'mc165', label: '运输库存SP' },
  { visible: false, prop: 'mc166', label: '平滑促销消耗' },
  { visible: false, prop: 'mc167', label: '生产版本' },
  { visible: false, prop: 'mc168', label: '固定价格联产品' },
  { visible: false, prop: 'mc169', label: '后勤组' },
  { visible: false, prop: 'mc170', label: '分销参数文件' },
  { visible: false, prop: 'mc171', label: '有约束的虚拟库存' },
  { visible: false, prop: 'mc172', label: '空缺库存销售价' },
  { visible: false, prop: 'mc173', label: '物料类别' },
  { visible: false, prop: 'mc174', label: 'EU产品清单编号' },
  { visible: false, prop: 'mc175', label: 'CAP 产品组' },
  { visible: false, prop: 'mc176', label: 'CAS 号码' },
  { visible: false, prop: 'mc177', label: 'PRODCOM 号码' },
  { visible: false, prop: 'mc178', label: '控制代码' },
  { visible: false, prop: 'mc179', label: 'JIT标识' },
  { visible: false, prop: 'mc180', label: '物料组' },
  { visible: false, prop: 'mc181', label: '建议供应区域' },
  { visible: false, prop: 'mc182', label: '公平分享规则' },
  { visible: false, prop: 'mc183', label: '推式分配' },
  { visible: false, prop: 'mc184', label: '发布界限' },
  { visible: false, prop: 'mc185', label: '最小批量' },
  { visible: false, prop: 'mc186', label: '最大批量' },
  { visible: false, prop: 'mc187', label: '固定批量' },
  { visible: false, prop: 'mc188', label: '批尺寸增加' },
  { visible: false, prop: 'mc189', label: '该字段不再使用' },
  { visible: false, prop: 'mc190', label: '转换类型' },
  { visible: false, prop: 'mc191', label: 'ST期间参数文件' },
  { visible: false, prop: 'mc192', label: 'MRP 相关需求' },
  { visible: false, prop: 'mc193', label: 'MRP 范围存在' },
  { visible: false, prop: 'mc194', label: '跨项目' },
  { visible: false, prop: 'mc195', label: '总体参数文件' },
  { visible: false, prop: 'mc196', label: 'APO 相关' },
  { visible: false, prop: 'mc197', label: '最后的MARD' },
  { visible: false, prop: 'mc198', label: '当前期间 (记帐期间)' },
  { visible: false, prop: 'mc199', label: '当前期间的会计年度' },
  { visible: false, prop: 'mc200', label: '最小安全库存' },
  { visible: false, prop: 'mc201', label: '无成本核算' },
  { visible: false, prop: 'mc202', label: '库存入库和出库' },
  { visible: false, prop: 'mc203', label: 'OB管理' },
  { visible: false, prop: 'mc204', label: 'OB参考物料' },
  { visible: false, prop: 'mc205', label: '评估收货锁定库存' },
  { visible: false, prop: 'mc206', label: '分段策略' },
  { visible: false, prop: 'mc207', label: '分段状态' },
  { visible: false, prop: 'mc208', label: '分段范围' },
  { visible: false, prop: 'mc209', label: '排序库存' },
  { visible: false, prop: 'mc210', label: '消耗优先级' },
  { visible: false, prop: 'mc211', label: '离散批次编号' },
  { visible: false, prop: 'mc212', label: '库存保护' },
  { visible: false, prop: 'mc213', label: '订单分配运行' },
  { visible: false, prop: 'mc214', label: '库存管理中激活季节' },
  { visible: false, prop: 'mc215', label: '包装组 (VSO)' },
  { visible: false, prop: 'mc216', label: '提货行 (VSO)' },
  { visible: false, prop: 'mc217', label: '物料编号 (VSO)' },
  { visible: false, prop: 'mc218', label: '纵向提取' },
  { visible: false, prop: 'mc219', label: 'IUID相关' },
  { visible: false, prop: 'mc220', label: 'IUID类型' },
  { visible: false, prop: 'mc221', label: '外部分配' },
  { visible: false, prop: 'mc222', label: '寄售控制' },
  { visible: false, prop: 'mc223', label: '发货处理时间' },
  { visible: false, prop: 'mc224', label: '交叉的采购组' },
  { visible: false, prop: 'mc225', label: '参考确定方案' },
  { visible: false, prop: 'mc226', label: '最小目标范围' },
  { visible: false, prop: 'mc227', label: '最大目标范围' },
  { visible: false, prop: 'mc228', label: '目标库存' },
  { visible: false, prop: 'remark', label: '备注说明' },
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
  { dictType: "sql_plant_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从工厂物料/mm_marc表记录数据
function getList(){
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
    mc019: [{ required: true, message: "计划交货天数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc020: [{ required: true, message: "收货处理时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc022: [{ required: true, message: "装配报废"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc026: [{ required: true, message: "再订货点"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc027: [{ required: true, message: "安全库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc028: [{ required: true, message: "最小批量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc029: [{ required: true, message: "最大批量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc030: [{ required: true, message: "固定批量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc033: [{ required: true, message: "订购成本"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc047: [{ required: true, message: "处理时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc048: [{ required: true, message: "准备时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc049: [{ required: true, message: "工序间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc050: [{ required: true, message: "基准数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc051: [{ required: true, message: "厂内生产时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc052: [{ required: true, message: "最大存储期间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc056: [{ required: true, message: "超量交货容差"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc058: [{ required: true, message: "不足交货容差"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc059: [{ required: true, message: "总计补货提前时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc061: [{ required: true, message: "附加费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc064: [{ required: true, message: "样本"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc070: [{ required: true, message: "活动性物质"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc071: [{ required: true, message: "检查间隔"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc081: [{ required: true, message: "对象标识"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc085: [{ required: true, message: "准备时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc086: [{ required: true, message: "基准数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc087: [{ required: true, message: "处理时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc098: [{ required: true, message: "在途库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc101: [{ required: true, message: "计划的时界"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc103: [{ required: true, message: "消耗期间:逆向"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc104: [{ required: true, message: "消耗时期-向前"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc110: [{ required: true, message: "成本核算批次"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc115: [{ required: true, message: "组件报废"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc118: [{ required: true, message: "间隔时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc124: [{ required: true, message: "内部对象号"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc134: [{ required: true, message: "乘数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc146: [{ required: true, message: "内部对象号"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc152: [{ required: true, message: "调整期间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc156: [{ required: true, message: "空气浮力因子"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc159: [{ required: true, message: "安全时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc164: [{ required: true, message: "库存转移SV"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc165: [{ required: true, message: "运输库存SP"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc171: [{ required: true, message: "有约束的虚拟库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc172: [{ required: true, message: "空缺库存销售价"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc184: [{ required: true, message: "发布界限"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc185: [{ required: true, message: "最小批量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc186: [{ required: true, message: "最大批量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc187: [{ required: true, message: "固定批量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc188: [{ required: true, message: "批尺寸增加"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc189: [{ required: true, message: "该字段不再使用"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc198: [{ required: true, message: "当前期间 (记帐期间)"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc199: [{ required: true, message: "当前期间的会计年度"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc200: [{ required: true, message: "最小安全库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc205: [{ required: true, message: "评估收货锁定库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc223: [{ required: true, message: "发货处理时间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mc226: [{ required: true, message: "最小目标范围"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc227: [{ required: true, message: "最大目标范围"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    mc228: [{ required: true, message: "目标库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
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
    mc002: null,
    mc004: [],
    mc003: null,
    mc005: null,
    mc006: null,
    mc007: null,
    mc008: null,
    mc009: null,
    mc010: null,
    mc011: null,
    mc012: null,
    mc013: null,
    mc014: null,
    mc015: null,
    mc016: null,
    mc017: null,
    mc018: null,
    mc019: 0,
    mc020: 0,
    mc021: null,
    mc022: 0,
    mc023: null,
    mc024: null,
    mc025: null,
    mc026: 0,
    mc027: 0,
    mc028: 0,
    mc029: 0,
    mc030: 0,
    mc031: 0,
    mc032: 0,
    mc033: 0,
    mc034: null,
    mc035: null,
    mc036: null,
    mc037: null,
    mc038: null,
    mc039: null,
    mc040: null,
    mc041: null,
    mc042: null,
    mc043: null,
    mc044: null,
    mc045: null,
    mc046: null,
    mc047: 0,
    mc048: 0,
    mc049: 0,
    mc050: 0,
    mc051: 0,
    mc052: 0,
    mc053: null,
    mc054: null,
    mc055: null,
    mc056: 0,
    mc057: null,
    mc058: 0,
    mc059: 0,
    mc060: null,
    mc061: 0,
    mc062: null,
    mc063: null,
    mc064: 0,
    mc065: 0,
    mc066: null,
    mc067: 0,
    mc068: null,
    mc069: null,
    mc070: 0,
    mc071: 0,
    mc072: null,
    mc073: 0,
    mc074: null,
    mc075: null,
    mc076: null,
    mc077: 0,
    mc078: null,
    mc079: null,
    mc080: null,
    mc081: 0,
    mc082: null,
    mc083: null,
    mc084: null,
    mc085: 0,
    mc086: 0,
    mc087: 0,
    mc088: null,
    mc089: null,
    mc090: null,
    mc091: null,
    mc092: null,
    mc093: null,
    mc094: null,
    mc095: null,
    mc096: null,
    mc097: null,
    mc098: 0,
    mc099: null,
    mc100: null,
    mc101: 0,
    mc102: null,
    mc103: 0,
    mc104: 0,
    mc105: null,
    mc106: null,
    mc107: null,
    mc108: null,
    mc109: null,
    mc110: 0,
    mc111: null,
    mc112: null,
    mc113: null,
    mc114: null,
    mc115: 0,
    mc116: null,
    mc117: null,
    mc118: 0,
    mc119: null,
    mc120: null,
    mc121: null,
    mc122: null,
    mc123: null,
    mc124: 0,
    mc125: null,
    mc126: null,
    mc127: null,
    mc128: null,
    mc129: null,
    mc130: null,
    mc131: null,
    mc132: null,
    mc133: null,
    mc134: 0,
    mc135: null,
    mc136: null,
    mc137: null,
    mc138: null,
    mc139: null,
    mc140: null,
    mc141: null,
    mc142: null,
    mc143: null,
    mc144: null,
    mc145: null,
    mc146: 0,
    mc147: null,
    mc148: null,
    mc149: null,
    mc150: null,
    mc151: null,
    mc152: 0,
    mc153: null,
    mc154: null,
    mc155: null,
    mc156: 0,
    mc157: null,
    mc158: null,
    mc159: 0,
    mc160: null,
    mc161: null,
    mc162: null,
    mc163: null,
    mc164: 0,
    mc165: 0,
    mc166: null,
    mc167: null,
    mc168: null,
    mc169: null,
    mc170: null,
    mc171: 0,
    mc172: 0,
    mc173: null,
    mc174: null,
    mc175: null,
    mc176: null,
    mc177: null,
    mc178: null,
    mc179: null,
    mc180: null,
    mc181: null,
    mc182: null,
    mc183: null,
    mc184: 0,
    mc185: 0,
    mc186: 0,
    mc187: 0,
    mc188: 0,
    mc189: 0,
    mc190: null,
    mc191: null,
    mc192: null,
    mc193: null,
    mc194: null,
    mc195: null,
    mc196: null,
    mc197: null,
    mc198: 0,
    mc199: 0,
    mc200: 0,
    mc201: null,
    mc202: null,
    mc203: null,
    mc204: null,
    mc205: 0,
    mc206: null,
    mc207: null,
    mc208: null,
    mc209: null,
    mc210: null,
    mc211: null,
    mc212: null,
    mc213: null,
    mc214: null,
    mc215: null,
    mc216: null,
    mc217: null,
    mc218: null,
    mc219: null,
    mc220: null,
    mc221: null,
    mc222: null,
    mc223: 0,
    mc224: null,
    mc225: null,
    mc226: 0,
    mc227: 0,
    mc228: 0,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'工厂物料'
  opertype.value = 1
  form.value.mc004= []
  form.value.mc010= new Date()
  form.value.mc019= 0
  form.value.mc020= 0
  form.value.mc022= 0
  form.value.mc026= 0
  form.value.mc027= 0
  form.value.mc028= 0
  form.value.mc029= 0
  form.value.mc030= 0
  form.value.mc031= 0
  form.value.mc032= 0
  form.value.mc033= 0
  form.value.mc038= new Date()
  form.value.mc047= 0
  form.value.mc048= 0
  form.value.mc049= 0
  form.value.mc050= 0
  form.value.mc051= 0
  form.value.mc052= 0
  form.value.mc056= 0
  form.value.mc058= 0
  form.value.mc059= 0
  form.value.mc061= 0
  form.value.mc064= 0
  form.value.mc065= 0
  form.value.mc067= 0
  form.value.mc070= 0
  form.value.mc071= 0
  form.value.mc072= new Date()
  form.value.mc073= 0
  form.value.mc077= 0
  form.value.mc081= 0
  form.value.mc085= 0
  form.value.mc086= 0
  form.value.mc087= 0
  form.value.mc098= 0
  form.value.mc101= 0
  form.value.mc103= 0
  form.value.mc104= 0
  form.value.mc110= 0
  form.value.mc115= 0
  form.value.mc118= 0
  form.value.mc124= 0
  form.value.mc133= new Date()
  form.value.mc134= 0
  form.value.mc139= new Date()
  form.value.mc141= new Date()
  form.value.mc146= 0
  form.value.mc152= 0
  form.value.mc156= 0
  form.value.mc159= 0
  form.value.mc164= 0
  form.value.mc165= 0
  form.value.mc171= 0
  form.value.mc172= 0
  form.value.mc184= 0
  form.value.mc185= 0
  form.value.mc186= 0
  form.value.mc187= 0
  form.value.mc188= 0
  form.value.mc189= 0
  form.value.mc198= 0
  form.value.mc199= 0
  form.value.mc200= 0
  form.value.mc205= 0
  form.value.mc223= 0
  form.value.mc226= 0
  form.value.mc227= 0
  form.value.mc228= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getMmMarc(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '工厂物料'
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
  const Ids = row.id || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<工厂物料.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
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