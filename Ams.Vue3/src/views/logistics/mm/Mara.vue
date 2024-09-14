<!--
 * @Descripttion: 常规物料/mm_mara
 * @Version: 0.24.620.18453
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 10:59:57
 * @column：248
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="物料号" prop="ma003">
        <el-input v-model="queryParams.ma003" :placeholder="$t('btn.enterSearchPrefix')+'物料号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料类型" prop="ma007">
        <el-select filterable clearable   v-model="queryParams.ma007" :placeholder="$t('btn.selectSearchPrefix')+'物料类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_matl_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="行业领域" prop="ma008">
        <el-select filterable clearable   v-model="queryParams.ma008" :placeholder="$t('btn.selectSearchPrefix')+'行业领域'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="基本单位" prop="ma011">
        <el-select filterable clearable   v-model="queryParams.ma011" :placeholder="$t('btn.selectSearchPrefix')+'基本单位'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
                  templateUrl="Logistics/MmMara/importTemplate"
                  importUrl="/Logistics/MmMara/importData"
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="ma002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma002')"/>
      <el-table-column prop="ma003" label="物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma003')"/>
      <el-table-column prop="ma004" label="完整状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma004')"/>
      <el-table-column prop="ma005" label="维护状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma005')"/>
      <el-table-column prop="ma006" label="集团删除" align="center" v-if="columns.showColumn('ma006')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_list " :value="scope.row.ma006"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma007" label="物料类型" align="center" v-if="columns.showColumn('ma007')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_type " :value="scope.row.ma007"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma008" label="行业领域" align="center" v-if="columns.showColumn('ma008')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.ma008"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma009" label="物料组" align="center" v-if="columns.showColumn('ma009')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_group " :value="scope.row.ma009"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma010" label="旧物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma010')"/>
      <el-table-column prop="ma011" label="基本单位" align="center" v-if="columns.showColumn('ma011')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.ma011"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma012" label="订单单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma012')"/>
      <el-table-column prop="ma013" label="凭证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma013')"/>
      <el-table-column prop="ma014" label="凭证类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma014')"/>
      <el-table-column prop="ma015" label="凭证版本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma015')"/>
      <el-table-column prop="ma016" label="页面大小" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma016')"/>
      <el-table-column prop="ma017" label="文档变更号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma017')"/>
      <el-table-column prop="ma018" label="页号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma018')"/>
      <el-table-column prop="ma019" label="页数" align="center" v-if="columns.showColumn('ma019')"/>
      <el-table-column prop="ma020" label="备忘录" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma020')"/>
      <el-table-column prop="ma021" label="页格式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma021')"/>
      <el-table-column prop="ma022" label="大小/量纲" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma022')"/>
      <el-table-column prop="ma023" label="基本物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma023')"/>
      <el-table-column prop="ma024" label="行业标准" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma024')"/>
      <el-table-column prop="ma025" label="实验室/设计室" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma025')"/>
      <el-table-column prop="ma026" label="采购值代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma026')"/>
      <el-table-column prop="ma027" label="毛重" align="center" v-if="columns.showColumn('ma027')"/>
      <el-table-column prop="ma028" label="净重" align="center" v-if="columns.showColumn('ma028')"/>
      <el-table-column prop="ma029" label="重量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma029')"/>
      <el-table-column prop="ma030" label="业务量" align="center" v-if="columns.showColumn('ma030')"/>
      <el-table-column prop="ma031" label="体积单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma031')"/>
      <el-table-column prop="ma032" label="容器需求" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma032')"/>
      <el-table-column prop="ma033" label="存储条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma033')"/>
      <el-table-column prop="ma034" label="温度" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma034')"/>
      <el-table-column prop="ma035" label="低层代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma035')"/>
      <el-table-column prop="ma036" label="运输组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma036')"/>
      <el-table-column prop="ma037" label="危险物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma037')"/>
      <el-table-column prop="ma038" label="产品组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma038')"/>
      <el-table-column prop="ma039" label="竞争者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma039')"/>
      <el-table-column prop="ma040" label="EAN号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma040')"/>
      <el-table-column prop="ma041" label="GR单数量" align="center" v-if="columns.showColumn('ma041')"/>
      <el-table-column prop="ma042" label="采购规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma042')"/>
      <el-table-column prop="ma043" label="货源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma043')"/>
      <el-table-column prop="ma044" label="季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma044')"/>
      <el-table-column prop="ma045" label="标签类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma045')"/>
      <el-table-column prop="ma046" label="标签格式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma046')"/>
      <el-table-column prop="ma047" label="取消激活" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma047')"/>
      <el-table-column prop="ma048" label="EAN" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma048')"/>
      <el-table-column prop="ma049" label="EAN类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma049')"/>
      <el-table-column prop="ma050" label="长度" align="center" v-if="columns.showColumn('ma050')"/>
      <el-table-column prop="ma051" label="宽度" align="center" v-if="columns.showColumn('ma051')"/>
      <el-table-column prop="ma052" label="高度" align="center" v-if="columns.showColumn('ma052')"/>
      <el-table-column prop="ma053" label="尺寸单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma053')"/>
      <el-table-column prop="ma054" label="产品层次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma054')"/>
      <el-table-column prop="ma055" label="净改变成本核算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma055')"/>
      <el-table-column prop="ma056" label="CAD标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma056')"/>
      <el-table-column prop="ma057" label="QM采购" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma057')"/>
      <el-table-column prop="ma058" label="允许的包装重量" align="center" v-if="columns.showColumn('ma058')"/>
      <el-table-column prop="ma059" label="重量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma059')"/>
      <el-table-column prop="ma060" label="允许体积" align="center" v-if="columns.showColumn('ma060')"/>
      <el-table-column prop="ma061" label="体积单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma061')"/>
      <el-table-column prop="ma062" label="超重量容差" align="center" v-if="columns.showColumn('ma062')"/>
      <el-table-column prop="ma063" label="超体积容差" align="center" v-if="columns.showColumn('ma063')"/>
      <el-table-column prop="ma064" label="可变订单单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma064')"/>
      <el-table-column prop="ma065" label="修订等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma065')"/>
      <el-table-column prop="ma066" label="可配置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma066')"/>
      <el-table-column prop="ma067" label="批次管理需求" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma067')"/>
      <el-table-column prop="ma068" label="包装物料类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma068')"/>
      <el-table-column prop="ma069" label="最大层次" align="center" v-if="columns.showColumn('ma069')"/>
      <el-table-column prop="ma070" label="堆栈因子" align="center" v-if="columns.showColumn('ma070')"/>
      <el-table-column prop="ma071" label="物料组包装物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma071')"/>
      <el-table-column prop="ma072" label="权限组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma072')"/>
      <el-table-column prop="ma073" label="有效起始日" :show-overflow-tooltip="true"  v-if="columns.showColumn('ma073')"/>
      <el-table-column prop="ma074" label="有效结束日" :show-overflow-tooltip="true"  v-if="columns.showColumn('ma074')"/>
      <el-table-column prop="ma075" label="季度年" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma075')"/>
      <el-table-column prop="ma076" label="价格标记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma076')"/>
      <el-table-column prop="ma077" label="空白BOM" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma077')"/>
      <el-table-column prop="ma078" label="外部物料组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma078')"/>
      <el-table-column prop="ma079" label="一般可配置物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma079')"/>
      <el-table-column prop="ma080" label="物料类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma080')"/>
      <el-table-column prop="ma081" label="联产品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma081')"/>
      <el-table-column prop="ma082" label="后续物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma082')"/>
      <el-table-column prop="ma083" label="定价参考物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma083')"/>
      <el-table-column prop="ma084" label="跨工厂状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma084')"/>
      <el-table-column prop="ma085" label="跨分销链状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma085')"/>
      <el-table-column prop="ma086" label="跨工厂有效日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ma086')"/>
      <el-table-column prop="ma087" label="跨分销有效日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('ma087')"/>
      <el-table-column prop="ma088" label="税收分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma088')"/>
      <el-table-column prop="ma089" label="类别参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma089')"/>
      <el-table-column prop="ma090" label="剩余货架寿命" align="center" v-if="columns.showColumn('ma090')"/>
      <el-table-column prop="ma091" label="总货架寿命" align="center" v-if="columns.showColumn('ma091')"/>
      <el-table-column prop="ma092" label="仓储百分比" align="center" v-if="columns.showColumn('ma092')"/>
      <el-table-column prop="ma093" label="内容单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma093')"/>
      <el-table-column prop="ma094" label="净内容" align="center" v-if="columns.showColumn('ma094')"/>
      <el-table-column prop="ma095" label="比较价格单位" align="center" v-if="columns.showColumn('ma095')"/>
      <el-table-column prop="ma096" label="物料组标签" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma096')"/>
      <el-table-column prop="ma097" label="毛内容" align="center" v-if="columns.showColumn('ma097')"/>
      <el-table-column prop="ma098" label="转换方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma098')"/>
      <el-table-column prop="ma099" label="内部对象号" align="center" v-if="columns.showColumn('ma099')"/>
      <el-table-column prop="ma100" label="环境相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma100')"/>
      <el-table-column prop="ma101" label="产品分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma101')"/>
      <el-table-column prop="ma102" label="定价参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma102')"/>
      <el-table-column prop="ma103" label="折扣类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma103')"/>
      <el-table-column prop="ma104" label="制造商零件编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma104')"/>
      <el-table-column prop="ma105" label="制造商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma105')"/>
      <el-table-column prop="ma106" label="内部物料编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma106')"/>
      <el-table-column prop="ma107" label="制造商部件参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma107')"/>
      <el-table-column prop="ma108" label="测量单位用法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma108')"/>
      <el-table-column prop="ma109" label="展开" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma109')"/>
      <el-table-column prop="ma110" label="危险货物标识参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma110')"/>
      <el-table-column prop="ma111" label="高粘性的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma111')"/>
      <el-table-column prop="ma112" label="固体/液体" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma112')"/>
      <el-table-column prop="ma113" label="序列号层次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma113')"/>
      <el-table-column prop="ma114" label="密闭" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma114')"/>
      <el-table-column prop="ma115" label="需要批量记录" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma115')"/>
      <el-table-column prop="ma116" label="参数有效值" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma116')"/>
      <el-table-column prop="ma117" label="完成水平" align="center" v-if="columns.showColumn('ma117')"/>
      <el-table-column prop="ma118" label="期间标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma118')"/>
      <el-table-column prop="ma119" label="舍入规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma119')"/>
      <el-table-column prop="ma120" label="产品成份" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma120')"/>
      <el-table-column prop="ma121" label="普通项目类别组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma121')"/>
      <el-table-column prop="ma122" label="后勤变量" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma122')"/>
      <el-table-column prop="ma123" label="物料被锁定" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma123')"/>
      <el-table-column prop="ma124" label="配置相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma124')"/>
      <el-table-column prop="ma125" label="分类清单类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma125')"/>
      <el-table-column prop="ma126" label="过期日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma126')"/>
      <el-table-column prop="ma127" label="EAN变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma127')"/>
      <el-table-column prop="ma128" label="一般物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma128')"/>
      <el-table-column prop="ma129" label="包装参考物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma129')"/>
      <el-table-column prop="ma130" label="GDS相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma130')"/>
      <el-table-column prop="ma131" label="原始接受" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma131')"/>
      <el-table-column prop="ma132" label="标准处理单位类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma132')"/>
      <el-table-column prop="ma133" label="可偷窃的" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma133')"/>
      <el-table-column prop="ma134" label="仓库存储条件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma134')"/>
      <el-table-column prop="ma135" label="仓库物料组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma135')"/>
      <el-table-column prop="ma136" label="处理标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma136')"/>
      <el-table-column prop="ma137" label="危险物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma137')"/>
      <el-table-column prop="ma138" label="处理单位类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma138')"/>
      <el-table-column prop="ma139" label="可变皮重" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma139')"/>
      <el-table-column prop="ma140" label="最大容量" align="center" v-if="columns.showColumn('ma140')"/>
      <el-table-column prop="ma141" label="最大容量容差" align="center" v-if="columns.showColumn('ma141')"/>
      <el-table-column prop="ma142" label="最大长度" align="center" v-if="columns.showColumn('ma142')"/>
      <el-table-column prop="ma143" label="最大宽度" align="center" v-if="columns.showColumn('ma143')"/>
      <el-table-column prop="ma144" label="最大高度" align="center" v-if="columns.showColumn('ma144')"/>
      <el-table-column prop="ma145" label="计量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma145')"/>
      <el-table-column prop="ma146" label="原产地国" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma146')"/>
      <el-table-column prop="ma147" label="物料运输组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma147')"/>
      <el-table-column prop="ma148" label="隔离期间" align="center" v-if="columns.showColumn('ma148')"/>
      <el-table-column prop="ma149" label="时间单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma149')"/>
      <el-table-column prop="ma150" label="质量检查组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma150')"/>
      <el-table-column prop="ma151" label="序列号参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma151')"/>
      <el-table-column prop="ma152" label="表格名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma152')"/>
      <el-table-column prop="ma153" label="后勤计量单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma153')"/>
      <el-table-column prop="ma154" label="称重物料相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma154')"/>
      <el-table-column prop="ma155" label="CW参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma155')"/>
      <el-table-column prop="ma156" label="CW容差组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma156')"/>
      <el-table-column prop="ma157" label="调整参数文件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma157')"/>
      <el-table-column prop="ma158" label="知识产权" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma158')"/>
      <el-table-column prop="ma159" label="允许的变式价格" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma159')"/>
      <el-table-column prop="ma160" label="中间" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma160')"/>
      <el-table-column prop="ma161" label="实物商品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma161')"/>
      <el-table-column prop="ma162" label="动物源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma162')"/>
      <el-table-column prop="ma163" label="纺织组分功能" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma163')"/>
      <el-table-column prop="ma164" label="分段结构" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma164')"/>
      <el-table-column prop="ma165" label="分段策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma165')"/>
      <el-table-column prop="ma166" label="分段状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma166')"/>
      <el-table-column prop="ma167" label="分段范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma167')"/>
      <el-table-column prop="ma168" label="分段相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma168')"/>
      <el-table-column prop="ma169" label="ANP Code" align="center" v-if="columns.showColumn('ma169')"/>
      <el-table-column prop="ma170" label="Fashion属性1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma170')"/>
      <el-table-column prop="ma171" label="Fashion属性2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma171')"/>
      <el-table-column prop="ma172" label="Fashion属性3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma172')"/>
      <el-table-column prop="ma173" label="季节使用" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma173')"/>
      <el-table-column prop="ma174" label="库存管理中激活季节" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma174')"/>
      <el-table-column prop="ma175" label="物料转换标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma175')"/>
      <el-table-column prop="ma176" label="装载单位" align="center" v-if="columns.showColumn('ma176')"/>
      <el-table-column prop="ma177" label="装载单位组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma177')"/>
      <el-table-column prop="ma178" label="结构类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma178')"/>
      <el-table-column prop="ma179" label="容差类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma179')"/>
      <el-table-column prop="ma180" label="计算组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma180')"/>
      <el-table-column prop="ma181" label="DSD 分组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma181')"/>
      <el-table-column prop="ma182" label="允许倾斜" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma182')"/>
      <el-table-column prop="ma183" label="无堆栈" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma183')"/>
      <el-table-column prop="ma184" label="底层" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma184')"/>
      <el-table-column prop="ma185" label="顶层" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma185')"/>
      <el-table-column prop="ma186" label="堆栈因子" align="center" v-if="columns.showColumn('ma186')"/>
      <el-table-column prop="ma187" label="无包装物料装载" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma187')"/>
      <el-table-column prop="ma188" label="悬挂深度" align="center" v-if="columns.showColumn('ma188')"/>
      <el-table-column prop="ma189" label="悬挂宽度" align="center" v-if="columns.showColumn('ma189')"/>
      <el-table-column prop="ma190" label="最大叠放高度" align="center" v-if="columns.showColumn('ma190')"/>
      <el-table-column prop="ma191" label="最小叠放高度" align="center" v-if="columns.showColumn('ma191')"/>
      <el-table-column prop="ma192" label="叠放高度容差" align="center" v-if="columns.showColumn('ma192')"/>
      <el-table-column prop="ma193" label="物料编号PKM" align="center" v-if="columns.showColumn('ma193')"/>
      <el-table-column prop="ma194" label="VSO" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma194')"/>
      <el-table-column prop="ma195" label="请求已清PKM" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma195')"/>
      <el-table-column prop="ma196" label="Packaging Code" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma196')"/>
      <el-table-column prop="ma197" label="危险品的包装状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma197')"/>
      <el-table-column prop="ma198" label="物料条件管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma198')"/>
      <el-table-column prop="ma199" label="返回代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma199')"/>
      <el-table-column prop="ma200" label="后勤等级退货" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma200')"/>
      <el-table-column prop="ma201" label="NATO项目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma201')"/>
      <el-table-column prop="ma202" label="完全互换组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma202')"/>
      <el-table-column prop="ma203" label="链编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma203')"/>
      <el-table-column prop="ma204" label="创建状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma204')"/>
      <el-table-column prop="ma205" label="内部特性1" align="center" v-if="columns.showColumn('ma205')"/>
      <el-table-column prop="ma206" label="内部特性2" align="center" v-if="columns.showColumn('ma206')"/>
      <el-table-column prop="ma207" label="内部特性3" align="center" v-if="columns.showColumn('ma207')"/>
      <el-table-column prop="ma208" label="颜色" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma208')"/>
      <el-table-column prop="ma209" label="主尺寸" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma209')"/>
      <el-table-column prop="ma210" label="次尺寸" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma210')"/>
      <el-table-column prop="ma211" label="特性值" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma211')"/>
      <el-table-column prop="ma212" label="护理代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma212')"/>
      <el-table-column prop="ma213" label="商标" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma213')"/>
      <el-table-column prop="ma214" label="组件1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma214')"/>
      <el-table-column prop="ma215" label="百分比共享1" align="center" v-if="columns.showColumn('ma215')"/>
      <el-table-column prop="ma216" label="组件2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma216')"/>
      <el-table-column prop="ma217" label="百分比共2" align="center" v-if="columns.showColumn('ma217')"/>
      <el-table-column prop="ma218" label="组件3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma218')"/>
      <el-table-column prop="ma219" label="百分比共享3" align="center" v-if="columns.showColumn('ma219')"/>
      <el-table-column prop="ma220" label="组件4" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma220')"/>
      <el-table-column prop="ma221" label="百分比共享4" align="center" v-if="columns.showColumn('ma221')"/>
      <el-table-column prop="ma222" label="组件5" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma222')"/>
      <el-table-column prop="ma223" label="百分比共享5" align="center" v-if="columns.showColumn('ma223')"/>
      <el-table-column prop="ma224" label="时装等级" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma224')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
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

          <el-col :lg="12">
            <el-form-item label="集团" prop="ma002">
              <el-input   v-model="form.ma002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料号" prop="ma003">
              <el-input   v-model="form.ma003" :placeholder="$t('btn.enterPrefix')+'物料号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完整状态" prop="ma004">
              <el-input   v-model="form.ma004" :placeholder="$t('btn.enterPrefix')+'完整状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态" prop="ma005">
              <el-input   v-model="form.ma005" :placeholder="$t('btn.enterPrefix')+'维护状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="集团删除" prop="ma006">
              <el-select filterable clearable   v-model="form.ma006"  :placeholder="$t('btn.selectPrefix')+'集团删除'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_eol_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料类型" prop="ma007">
              <el-select filterable clearable   v-model="form.ma007"  :placeholder="$t('btn.selectPrefix')+'物料类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_matl_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="行业领域" prop="ma008">
              <el-select filterable clearable   v-model="form.ma008"  :placeholder="$t('btn.selectPrefix')+'行业领域'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="物料组" prop="ma009">
              <el-select filterable clearable   v-model="form.ma009"  :placeholder="$t('btn.selectPrefix')+'物料组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_matl_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="旧物料号" prop="ma010">
              <el-input   v-model="form.ma010" :placeholder="$t('btn.enterPrefix')+'旧物料号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本单位" prop="ma011">
              <el-select filterable clearable   v-model="form.ma011"  :placeholder="$t('btn.selectPrefix')+'基本单位'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_unit_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="订单单位" prop="ma012">
              <el-input   v-model="form.ma012" :placeholder="$t('btn.enterPrefix')+'订单单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证" prop="ma013">
              <el-input   v-model="form.ma013" :placeholder="$t('btn.enterPrefix')+'凭证'+$t('btn.enterSuffix')"  show-word-limit   maxlength="44"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证类型" prop="ma014">
              <el-input   v-model="form.ma014" :placeholder="$t('btn.enterPrefix')+'凭证类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="凭证版本" prop="ma015">
              <el-input   v-model="form.ma015" :placeholder="$t('btn.enterPrefix')+'凭证版本'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页面大小" prop="ma016">
              <el-input   v-model="form.ma016" :placeholder="$t('btn.enterPrefix')+'页面大小'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="文档变更号" prop="ma017">
              <el-input   v-model="form.ma017" :placeholder="$t('btn.enterPrefix')+'文档变更号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页号" prop="ma018">
              <el-input   v-model="form.ma018" :placeholder="$t('btn.enterPrefix')+'页号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="页数" prop="ma019">
              <el-input-number v-model.number="form.ma019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'页数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="备忘录" prop="ma020">
              <el-input   v-model="form.ma020" :placeholder="$t('btn.enterPrefix')+'备忘录'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="页格式" prop="ma021">
              <el-input   v-model="form.ma021" :placeholder="$t('btn.enterPrefix')+'页格式'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="大小/量纲" prop="ma022">
              <el-input   v-model="form.ma022" :placeholder="$t('btn.enterPrefix')+'大小/量纲'+$t('btn.enterSuffix')"  show-word-limit   maxlength="64"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基本物料" prop="ma023">
              <el-input   v-model="form.ma023" :placeholder="$t('btn.enterPrefix')+'基本物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="96"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="行业标准" prop="ma024">
              <el-input   v-model="form.ma024" :placeholder="$t('btn.enterPrefix')+'行业标准'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实验室/设计室" prop="ma025">
              <el-input   v-model="form.ma025" :placeholder="$t('btn.enterPrefix')+'实验室/设计室'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购值代码" prop="ma026">
              <el-input   v-model="form.ma026" :placeholder="$t('btn.enterPrefix')+'采购值代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="毛重" prop="ma027">
              <el-input-number v-model.number="form.ma027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'毛重'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净重" prop="ma028">
              <el-input-number v-model.number="form.ma028" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'净重'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重量单位" prop="ma029">
              <el-input   v-model="form.ma029" :placeholder="$t('btn.enterPrefix')+'重量单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="业务量" prop="ma030">
              <el-input-number v-model.number="form.ma030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'业务量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="体积单位" prop="ma031">
              <el-input   v-model="form.ma031" :placeholder="$t('btn.enterPrefix')+'体积单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="容器需求" prop="ma032">
              <el-input   v-model="form.ma032" :placeholder="$t('btn.enterPrefix')+'容器需求'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="存储条件" prop="ma033">
              <el-input   v-model="form.ma033" :placeholder="$t('btn.enterPrefix')+'存储条件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="温度" prop="ma034">
              <el-input   v-model="form.ma034" :placeholder="$t('btn.enterPrefix')+'温度'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="低层代码" prop="ma035">
              <el-input   v-model="form.ma035" :placeholder="$t('btn.enterPrefix')+'低层代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="运输组" prop="ma036">
              <el-input   v-model="form.ma036" :placeholder="$t('btn.enterPrefix')+'运输组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险物料号" prop="ma037">
              <el-input   v-model="form.ma037" :placeholder="$t('btn.enterPrefix')+'危险物料号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品组" prop="ma038">
              <el-input   v-model="form.ma038" :placeholder="$t('btn.enterPrefix')+'产品组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="竞争者" prop="ma039">
              <el-input   v-model="form.ma039" :placeholder="$t('btn.enterPrefix')+'竞争者'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN号" prop="ma040">
              <el-input   v-model="form.ma040" :placeholder="$t('btn.enterPrefix')+'EAN号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="GR单数量" prop="ma041">
              <el-input-number v-model.number="form.ma041" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'GR单数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购规则" prop="ma042">
              <el-input   v-model="form.ma042" :placeholder="$t('btn.enterPrefix')+'采购规则'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="货源" prop="ma043">
              <el-input   v-model="form.ma043" :placeholder="$t('btn.enterPrefix')+'货源'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季节" prop="ma044">
              <el-input   v-model="form.ma044" :placeholder="$t('btn.enterPrefix')+'季节'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标签类型" prop="ma045">
              <el-input   v-model="form.ma045" :placeholder="$t('btn.enterPrefix')+'标签类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标签格式" prop="ma046">
              <el-input   v-model="form.ma046" :placeholder="$t('btn.enterPrefix')+'标签格式'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="取消激活" prop="ma047">
              <el-input   v-model="form.ma047" :placeholder="$t('btn.enterPrefix')+'取消激活'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN" prop="ma048">
              <el-input   v-model="form.ma048" :placeholder="$t('btn.enterPrefix')+'EAN'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN类别" prop="ma049">
              <el-input   v-model="form.ma049" :placeholder="$t('btn.enterPrefix')+'EAN类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="长度" prop="ma050">
              <el-input-number v-model.number="form.ma050" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'长度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="宽度" prop="ma051">
              <el-input-number v-model.number="form.ma051" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'宽度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="高度" prop="ma052">
              <el-input-number v-model.number="form.ma052" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'高度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="尺寸单位" prop="ma053">
              <el-input   v-model="form.ma053" :placeholder="$t('btn.enterPrefix')+'尺寸单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品层次" prop="ma054">
              <el-input   v-model="form.ma054" :placeholder="$t('btn.enterPrefix')+'产品层次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净改变成本核算" prop="ma055">
              <el-input   v-model="form.ma055" :placeholder="$t('btn.enterPrefix')+'净改变成本核算'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CAD标识" prop="ma056">
              <el-input   v-model="form.ma056" :placeholder="$t('btn.enterPrefix')+'CAD标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QM采购" prop="ma057">
              <el-input   v-model="form.ma057" :placeholder="$t('btn.enterPrefix')+'QM采购'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的包装重量" prop="ma058">
              <el-input-number v-model.number="form.ma058" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'允许的包装重量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="重量单位" prop="ma059">
              <el-input   v-model="form.ma059" :placeholder="$t('btn.enterPrefix')+'重量单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许体积" prop="ma060">
              <el-input-number v-model.number="form.ma060" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'允许体积'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="体积单位" prop="ma061">
              <el-input   v-model="form.ma061" :placeholder="$t('btn.enterPrefix')+'体积单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超重量容差" prop="ma062">
              <el-input-number v-model.number="form.ma062" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'超重量容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="超体积容差" prop="ma063">
              <el-input-number v-model.number="form.ma063" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'超体积容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可变订单单位" prop="ma064">
              <el-input   v-model="form.ma064" :placeholder="$t('btn.enterPrefix')+'可变订单单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="修订等级" prop="ma065">
              <el-input   v-model="form.ma065" :placeholder="$t('btn.enterPrefix')+'修订等级'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可配置" prop="ma066">
              <el-input   v-model="form.ma066" :placeholder="$t('btn.enterPrefix')+'可配置'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次管理需求" prop="ma067">
              <el-input   v-model="form.ma067" :placeholder="$t('btn.enterPrefix')+'批次管理需求'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装物料类型" prop="ma068">
              <el-input   v-model="form.ma068" :placeholder="$t('btn.enterPrefix')+'包装物料类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大层次" prop="ma069">
              <el-input-number v-model.number="form.ma069" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大层次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="堆栈因子" prop="ma070">
              <el-input-number v-model.number="form.ma070" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'堆栈因子'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组包装物料" prop="ma071">
              <el-input   v-model="form.ma071" :placeholder="$t('btn.enterPrefix')+'物料组包装物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="权限组" prop="ma072">
              <el-input   v-model="form.ma072" :placeholder="$t('btn.enterPrefix')+'权限组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始日" prop="ma073">
              <el-date-picker v-model="form.ma073" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效结束日" prop="ma074">
              <el-date-picker v-model="form.ma074" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季度年" prop="ma075">
              <el-input   v-model="form.ma075" :placeholder="$t('btn.enterPrefix')+'季度年'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格标记" prop="ma076">
              <el-input   v-model="form.ma076" :placeholder="$t('btn.enterPrefix')+'价格标记'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="空白BOM" prop="ma077">
              <el-input   v-model="form.ma077" :placeholder="$t('btn.enterPrefix')+'空白BOM'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部物料组" prop="ma078">
              <el-input   v-model="form.ma078" :placeholder="$t('btn.enterPrefix')+'外部物料组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般可配置物料" prop="ma079">
              <el-input   v-model="form.ma079" :placeholder="$t('btn.enterPrefix')+'一般可配置物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料类别" prop="ma080">
              <el-input   v-model="form.ma080" :placeholder="$t('btn.enterPrefix')+'物料类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联产品" prop="ma081">
              <el-input   v-model="form.ma081" :placeholder="$t('btn.enterPrefix')+'联产品'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后续物料" prop="ma082">
              <el-input   v-model="form.ma082" :placeholder="$t('btn.enterPrefix')+'后续物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="定价参考物料" prop="ma083">
              <el-input   v-model="form.ma083" :placeholder="$t('btn.enterPrefix')+'定价参考物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨工厂状态" prop="ma084">
              <el-input   v-model="form.ma084" :placeholder="$t('btn.enterPrefix')+'跨工厂状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨分销链状态" prop="ma085">
              <el-input   v-model="form.ma085" :placeholder="$t('btn.enterPrefix')+'跨分销链状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨工厂有效日期" prop="ma086">
              <el-date-picker v-model="form.ma086" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="跨分销有效日期" prop="ma087">
              <el-date-picker v-model="form.ma087" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税收分类" prop="ma088">
              <el-input   v-model="form.ma088" :placeholder="$t('btn.enterPrefix')+'税收分类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="类别参数文件" prop="ma089">
              <el-input   v-model="form.ma089" :placeholder="$t('btn.enterPrefix')+'类别参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="剩余货架寿命" prop="ma090">
              <el-input-number v-model.number="form.ma090" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'剩余货架寿命'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总货架寿命" prop="ma091">
              <el-input-number v-model.number="form.ma091" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总货架寿命'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓储百分比" prop="ma092">
              <el-input-number v-model.number="form.ma092" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'仓储百分比'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内容单位" prop="ma093">
              <el-input   v-model="form.ma093" :placeholder="$t('btn.enterPrefix')+'内容单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净内容" prop="ma094">
              <el-input-number v-model.number="form.ma094" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'净内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="比较价格单位" prop="ma095">
              <el-input-number v-model.number="form.ma095" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'比较价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料组标签" prop="ma096">
              <el-input   v-model="form.ma096" :placeholder="$t('btn.enterPrefix')+'物料组标签'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="毛内容" prop="ma097">
              <el-input-number v-model.number="form.ma097" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'毛内容'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转换方法" prop="ma098">
              <el-input   v-model="form.ma098" :placeholder="$t('btn.enterPrefix')+'转换方法'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部对象号" prop="ma099">
              <el-input-number v-model.number="form.ma099" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'内部对象号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="环境相关" prop="ma100">
              <el-input   v-model="form.ma100" :placeholder="$t('btn.enterPrefix')+'环境相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品分配" prop="ma101">
              <el-input   v-model="form.ma101" :placeholder="$t('btn.enterPrefix')+'产品分配'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="定价参数文件" prop="ma102">
              <el-input   v-model="form.ma102" :placeholder="$t('btn.enterPrefix')+'定价参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折扣类型" prop="ma103">
              <el-input   v-model="form.ma103" :placeholder="$t('btn.enterPrefix')+'折扣类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商零件编号" prop="ma104">
              <el-input   v-model="form.ma104" :placeholder="$t('btn.enterPrefix')+'制造商零件编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="80"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="ma105">
              <el-input   v-model="form.ma105" :placeholder="$t('btn.enterPrefix')+'制造商'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内部物料编号" prop="ma106">
              <el-input   v-model="form.ma106" :placeholder="$t('btn.enterPrefix')+'内部物料编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商部件参数文件" prop="ma107">
              <el-input   v-model="form.ma107" :placeholder="$t('btn.enterPrefix')+'制造商部件参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="测量单位用法" prop="ma108">
              <el-input   v-model="form.ma108" :placeholder="$t('btn.enterPrefix')+'测量单位用法'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="展开" prop="ma109">
              <el-input   v-model="form.ma109" :placeholder="$t('btn.enterPrefix')+'展开'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险货物标识参数文件" prop="ma110">
              <el-input   v-model="form.ma110" :placeholder="$t('btn.enterPrefix')+'危险货物标识参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="高粘性的" prop="ma111">
              <el-input   v-model="form.ma111" :placeholder="$t('btn.enterPrefix')+'高粘性的'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="固体/液体" prop="ma112">
              <el-input   v-model="form.ma112" :placeholder="$t('btn.enterPrefix')+'固体/液体'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号层次" prop="ma113">
              <el-input   v-model="form.ma113" :placeholder="$t('btn.enterPrefix')+'序列号层次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="密闭" prop="ma114">
              <el-input   v-model="form.ma114" :placeholder="$t('btn.enterPrefix')+'密闭'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="需要批量记录" prop="ma115">
              <el-input   v-model="form.ma115" :placeholder="$t('btn.enterPrefix')+'需要批量记录'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="参数有效值" prop="ma116">
              <el-input   v-model="form.ma116" :placeholder="$t('btn.enterPrefix')+'参数有效值'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="完成水平" prop="ma117">
              <el-input-number v-model.number="form.ma117" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'完成水平'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间标识" prop="ma118">
              <el-input   v-model="form.ma118" :placeholder="$t('btn.enterPrefix')+'期间标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="舍入规则" prop="ma119">
              <el-input   v-model="form.ma119" :placeholder="$t('btn.enterPrefix')+'舍入规则'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="产品成份" prop="ma120">
              <el-input   v-model="form.ma120" :placeholder="$t('btn.enterPrefix')+'产品成份'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="普通项目类别组" prop="ma121">
              <el-input   v-model="form.ma121" :placeholder="$t('btn.enterPrefix')+'普通项目类别组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤变量" prop="ma122">
              <el-input   v-model="form.ma122" :placeholder="$t('btn.enterPrefix')+'后勤变量'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料被锁定" prop="ma123">
              <el-input   v-model="form.ma123" :placeholder="$t('btn.enterPrefix')+'物料被锁定'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="配置相关" prop="ma124">
              <el-input   v-model="form.ma124" :placeholder="$t('btn.enterPrefix')+'配置相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分类清单类型" prop="ma125">
              <el-input   v-model="form.ma125" :placeholder="$t('btn.enterPrefix')+'分类清单类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过期日期" prop="ma126">
              <el-input   v-model="form.ma126" :placeholder="$t('btn.enterPrefix')+'过期日期'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="EAN变式" prop="ma127">
              <el-input   v-model="form.ma127" :placeholder="$t('btn.enterPrefix')+'EAN变式'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般物料" prop="ma128">
              <el-input   v-model="form.ma128" :placeholder="$t('btn.enterPrefix')+'一般物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="包装参考物料" prop="ma129">
              <el-input   v-model="form.ma129" :placeholder="$t('btn.enterPrefix')+'包装参考物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="GDS相关" prop="ma130">
              <el-input   v-model="form.ma130" :placeholder="$t('btn.enterPrefix')+'GDS相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原始接受" prop="ma131">
              <el-input   v-model="form.ma131" :placeholder="$t('btn.enterPrefix')+'原始接受'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准处理单位类型" prop="ma132">
              <el-input   v-model="form.ma132" :placeholder="$t('btn.enterPrefix')+'标准处理单位类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可偷窃的" prop="ma133">
              <el-input   v-model="form.ma133" :placeholder="$t('btn.enterPrefix')+'可偷窃的'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库存储条件" prop="ma134">
              <el-input   v-model="form.ma134" :placeholder="$t('btn.enterPrefix')+'仓库存储条件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仓库物料组" prop="ma135">
              <el-input   v-model="form.ma135" :placeholder="$t('btn.enterPrefix')+'仓库物料组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理标识" prop="ma136">
              <el-input   v-model="form.ma136" :placeholder="$t('btn.enterPrefix')+'处理标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险物料" prop="ma137">
              <el-input   v-model="form.ma137" :placeholder="$t('btn.enterPrefix')+'危险物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理单位类型" prop="ma138">
              <el-input   v-model="form.ma138" :placeholder="$t('btn.enterPrefix')+'处理单位类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可变皮重" prop="ma139">
              <el-input   v-model="form.ma139" :placeholder="$t('btn.enterPrefix')+'可变皮重'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大容量" prop="ma140">
              <el-input-number v-model.number="form.ma140" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大容量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大容量容差" prop="ma141">
              <el-input-number v-model.number="form.ma141" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大容量容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大长度" prop="ma142">
              <el-input-number v-model.number="form.ma142" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大长度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大宽度" prop="ma143">
              <el-input-number v-model.number="form.ma143" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大宽度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大高度" prop="ma144">
              <el-input-number v-model.number="form.ma144" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大高度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计量单位" prop="ma145">
              <el-input   v-model="form.ma145" :placeholder="$t('btn.enterPrefix')+'计量单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原产地国" prop="ma146">
              <el-input   v-model="form.ma146" :placeholder="$t('btn.enterPrefix')+'原产地国'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料运输组" prop="ma147">
              <el-input   v-model="form.ma147" :placeholder="$t('btn.enterPrefix')+'物料运输组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="隔离期间" prop="ma148">
              <el-input-number v-model.number="form.ma148" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'隔离期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时间单位" prop="ma149">
              <el-input   v-model="form.ma149" :placeholder="$t('btn.enterPrefix')+'时间单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="质量检查组" prop="ma150">
              <el-input   v-model="form.ma150" :placeholder="$t('btn.enterPrefix')+'质量检查组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号参数文件" prop="ma151">
              <el-input   v-model="form.ma151" :placeholder="$t('btn.enterPrefix')+'序列号参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="表格名" prop="ma152">
              <el-input   v-model="form.ma152" :placeholder="$t('btn.enterPrefix')+'表格名'+$t('btn.enterSuffix')"  show-word-limit   maxlength="60"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤计量单位" prop="ma153">
              <el-input   v-model="form.ma153" :placeholder="$t('btn.enterPrefix')+'后勤计量单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="称重物料相关" prop="ma154">
              <el-input   v-model="form.ma154" :placeholder="$t('btn.enterPrefix')+'称重物料相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CW参数文件" prop="ma155">
              <el-input   v-model="form.ma155" :placeholder="$t('btn.enterPrefix')+'CW参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="CW容差组" prop="ma156">
              <el-input   v-model="form.ma156" :placeholder="$t('btn.enterPrefix')+'CW容差组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="18"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="调整参数文件" prop="ma157">
              <el-input   v-model="form.ma157" :placeholder="$t('btn.enterPrefix')+'调整参数文件'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="知识产权" prop="ma158">
              <el-input   v-model="form.ma158" :placeholder="$t('btn.enterPrefix')+'知识产权'+$t('btn.enterSuffix')"  show-word-limit   maxlength="80"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许的变式价格" prop="ma159">
              <el-input   v-model="form.ma159" :placeholder="$t('btn.enterPrefix')+'允许的变式价格'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="中间" prop="ma160">
              <el-input   v-model="form.ma160" :placeholder="$t('btn.enterPrefix')+'中间'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实物商品" prop="ma161">
              <el-input   v-model="form.ma161" :placeholder="$t('btn.enterPrefix')+'实物商品'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="动物源" prop="ma162">
              <el-input   v-model="form.ma162" :placeholder="$t('btn.enterPrefix')+'动物源'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="纺织组分功能" prop="ma163">
              <el-input   v-model="form.ma163" :placeholder="$t('btn.enterPrefix')+'纺织组分功能'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段结构" prop="ma164">
              <el-input   v-model="form.ma164" :placeholder="$t('btn.enterPrefix')+'分段结构'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段策略" prop="ma165">
              <el-input   v-model="form.ma165" :placeholder="$t('btn.enterPrefix')+'分段策略'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段状态" prop="ma166">
              <el-input   v-model="form.ma166" :placeholder="$t('btn.enterPrefix')+'分段状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段范围" prop="ma167">
              <el-input   v-model="form.ma167" :placeholder="$t('btn.enterPrefix')+'分段范围'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分段相关" prop="ma168">
              <el-input   v-model="form.ma168" :placeholder="$t('btn.enterPrefix')+'分段相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="ANP Code" prop="ma169">
              <el-input-number v-model.number="form.ma169" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'ANP Code'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion属性1" prop="ma170">
              <el-input   v-model="form.ma170" :placeholder="$t('btn.enterPrefix')+'Fashion属性1'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion属性2" prop="ma171">
              <el-input   v-model="form.ma171" :placeholder="$t('btn.enterPrefix')+'Fashion属性2'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Fashion属性3" prop="ma172">
              <el-input   v-model="form.ma172" :placeholder="$t('btn.enterPrefix')+'Fashion属性3'+$t('btn.enterSuffix')"  show-word-limit   maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="季节使用" prop="ma173">
              <el-input   v-model="form.ma173" :placeholder="$t('btn.enterPrefix')+'季节使用'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存管理中激活季节" prop="ma174">
              <el-input   v-model="form.ma174" :placeholder="$t('btn.enterPrefix')+'库存管理中激活季节'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料转换标识" prop="ma175">
              <el-input   v-model="form.ma175" :placeholder="$t('btn.enterPrefix')+'物料转换标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="装载单位" prop="ma176">
              <el-input-number v-model.number="form.ma176" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'装载单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="装载单位组" prop="ma177">
              <el-input   v-model="form.ma177" :placeholder="$t('btn.enterPrefix')+'装载单位组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="结构类别" prop="ma178">
              <el-input   v-model="form.ma178" :placeholder="$t('btn.enterPrefix')+'结构类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="容差类型" prop="ma179">
              <el-input   v-model="form.ma179" :placeholder="$t('btn.enterPrefix')+'容差类型'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计算组" prop="ma180">
              <el-input   v-model="form.ma180" :placeholder="$t('btn.enterPrefix')+'计算组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="DSD 分组" prop="ma181">
              <el-input   v-model="form.ma181" :placeholder="$t('btn.enterPrefix')+'DSD 分组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许倾斜" prop="ma182">
              <el-input   v-model="form.ma182" :placeholder="$t('btn.enterPrefix')+'允许倾斜'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="无堆栈" prop="ma183">
              <el-input   v-model="form.ma183" :placeholder="$t('btn.enterPrefix')+'无堆栈'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="底层" prop="ma184">
              <el-input   v-model="form.ma184" :placeholder="$t('btn.enterPrefix')+'底层'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顶层" prop="ma185">
              <el-input   v-model="form.ma185" :placeholder="$t('btn.enterPrefix')+'顶层'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="堆栈因子" prop="ma186">
              <el-input-number v-model.number="form.ma186" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'堆栈因子'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="无包装物料装载" prop="ma187">
              <el-input   v-model="form.ma187" :placeholder="$t('btn.enterPrefix')+'无包装物料装载'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="悬挂深度" prop="ma188">
              <el-input-number v-model.number="form.ma188" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'悬挂深度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="悬挂宽度" prop="ma189">
              <el-input-number v-model.number="form.ma189" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'悬挂宽度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最大叠放高度" prop="ma190">
              <el-input-number v-model.number="form.ma190" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大叠放高度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最小叠放高度" prop="ma191">
              <el-input-number v-model.number="form.ma191" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最小叠放高度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="叠放高度容差" prop="ma192">
              <el-input-number v-model.number="form.ma192" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'叠放高度容差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="物料编号PKM" prop="ma193">
              <el-input-number v-model.number="form.ma193" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'物料编号PKM'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="VSO" prop="ma194">
              <el-input   v-model="form.ma194" :placeholder="$t('btn.enterPrefix')+'VSO'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="请求已清PKM" prop="ma195">
              <el-input   v-model="form.ma195" :placeholder="$t('btn.enterPrefix')+'请求已清PKM'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="Packaging Code" prop="ma196">
              <el-input   v-model="form.ma196" :placeholder="$t('btn.enterPrefix')+'Packaging Code'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="危险品的包装状态" prop="ma197">
              <el-input   v-model="form.ma197" :placeholder="$t('btn.enterPrefix')+'危险品的包装状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料条件管理" prop="ma198">
              <el-input   v-model="form.ma198" :placeholder="$t('btn.enterPrefix')+'物料条件管理'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="返回代码" prop="ma199">
              <el-input   v-model="form.ma199" :placeholder="$t('btn.enterPrefix')+'返回代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="后勤等级退货" prop="ma200">
              <el-input   v-model="form.ma200" :placeholder="$t('btn.enterPrefix')+'后勤等级退货'+$t('btn.enterSuffix')"  show-word-limit   maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="NATO项目" prop="ma201">
              <el-input   v-model="form.ma201" :placeholder="$t('btn.enterPrefix')+'NATO项目'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="完全互换组" prop="ma202">
              <el-input   v-model="form.ma202" :placeholder="$t('btn.enterPrefix')+'完全互换组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="链编号" prop="ma203">
              <el-input   v-model="form.ma203" :placeholder="$t('btn.enterPrefix')+'链编号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建状态" prop="ma204">
              <el-input   v-model="form.ma204" :placeholder="$t('btn.enterPrefix')+'创建状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部特性1" prop="ma205">
              <el-input-number v-model.number="form.ma205" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'内部特性1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部特性2" prop="ma206">
              <el-input-number v-model.number="form.ma206" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'内部特性2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="内部特性3" prop="ma207">
              <el-input-number v-model.number="form.ma207" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'内部特性3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="颜色" prop="ma208">
              <el-input   v-model="form.ma208" :placeholder="$t('btn.enterPrefix')+'颜色'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="主尺寸" prop="ma209">
              <el-input   v-model="form.ma209" :placeholder="$t('btn.enterPrefix')+'主尺寸'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="次尺寸" prop="ma210">
              <el-input   v-model="form.ma210" :placeholder="$t('btn.enterPrefix')+'次尺寸'+$t('btn.enterSuffix')"  show-word-limit   maxlength="36"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特性值" prop="ma211">
              <el-input   v-model="form.ma211" :placeholder="$t('btn.enterPrefix')+'特性值'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="护理代码" prop="ma212">
              <el-input   v-model="form.ma212" :placeholder="$t('btn.enterPrefix')+'护理代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="32"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商标" prop="ma213">
              <el-input   v-model="form.ma213" :placeholder="$t('btn.enterPrefix')+'商标'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件1" prop="ma214">
              <el-input   v-model="form.ma214" :placeholder="$t('btn.enterPrefix')+'组件1'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享1" prop="ma215">
              <el-input-number v-model.number="form.ma215" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'百分比共享1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件2" prop="ma216">
              <el-input   v-model="form.ma216" :placeholder="$t('btn.enterPrefix')+'组件2'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共2" prop="ma217">
              <el-input-number v-model.number="form.ma217" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'百分比共2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件3" prop="ma218">
              <el-input   v-model="form.ma218" :placeholder="$t('btn.enterPrefix')+'组件3'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享3" prop="ma219">
              <el-input-number v-model.number="form.ma219" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'百分比共享3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件4" prop="ma220">
              <el-input   v-model="form.ma220" :placeholder="$t('btn.enterPrefix')+'组件4'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享4" prop="ma221">
              <el-input-number v-model.number="form.ma221" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'百分比共享4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组件5" prop="ma222">
              <el-input   v-model="form.ma222" :placeholder="$t('btn.enterPrefix')+'组件5'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="百分比共享5" prop="ma223">
              <el-input-number v-model.number="form.ma223" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'百分比共享5'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时装等级" prop="ma224">
              <el-input   v-model="form.ma224" :placeholder="$t('btn.enterPrefix')+'时装等级'+$t('btn.enterSuffix')"  show-word-limit   maxlength="8"/>
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

<script setup name="mmmara">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listMmMara,
 addMmMara, delMmMara, 
 updateMmMara,getMmMara, 
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
  sort: 'Ma003',
  sortType: 'asc',
  //是否查询（1是）
  ma003: undefined,
  //是否查询（1是）
  ma007: undefined,
  //是否查询（1是）
  ma008: undefined,
  //是否查询（1是）
  ma011: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'ma002', label: '集团' },
  { visible: true, prop: 'ma003', label: '物料号' },
  { visible: true, prop: 'ma004', label: '完整状态' },
  { visible: true, prop: 'ma005', label: '维护状态' },
  { visible: true, prop: 'ma006', label: '集团删除' },
  { visible: true, prop: 'ma007', label: '物料类型' },
  { visible: true, prop: 'ma008', label: '行业领域' },
  { visible: false, prop: 'ma009', label: '物料组' },
  { visible: false, prop: 'ma010', label: '旧物料号' },
  { visible: false, prop: 'ma011', label: '基本单位' },
  { visible: false, prop: 'ma012', label: '订单单位' },
  { visible: false, prop: 'ma013', label: '凭证' },
  { visible: false, prop: 'ma014', label: '凭证类型' },
  { visible: false, prop: 'ma015', label: '凭证版本' },
  { visible: false, prop: 'ma016', label: '页面大小' },
  { visible: false, prop: 'ma017', label: '文档变更号' },
  { visible: false, prop: 'ma018', label: '页号' },
  { visible: false, prop: 'ma019', label: '页数' },
  { visible: false, prop: 'ma020', label: '备忘录' },
  { visible: false, prop: 'ma021', label: '页格式' },
  { visible: false, prop: 'ma022', label: '大小/量纲' },
  { visible: false, prop: 'ma023', label: '基本物料' },
  { visible: false, prop: 'ma024', label: '行业标准' },
  { visible: false, prop: 'ma025', label: '实验室/设计室' },
  { visible: false, prop: 'ma026', label: '采购值代码' },
  { visible: false, prop: 'ma027', label: '毛重' },
  { visible: false, prop: 'ma028', label: '净重' },
  { visible: false, prop: 'ma029', label: '重量单位' },
  { visible: false, prop: 'ma030', label: '业务量' },
  { visible: false, prop: 'ma031', label: '体积单位' },
  { visible: false, prop: 'ma032', label: '容器需求' },
  { visible: false, prop: 'ma033', label: '存储条件' },
  { visible: false, prop: 'ma034', label: '温度' },
  { visible: false, prop: 'ma035', label: '低层代码' },
  { visible: false, prop: 'ma036', label: '运输组' },
  { visible: false, prop: 'ma037', label: '危险物料号' },
  { visible: false, prop: 'ma038', label: '产品组' },
  { visible: false, prop: 'ma039', label: '竞争者' },
  { visible: false, prop: 'ma040', label: 'EAN号' },
  { visible: false, prop: 'ma041', label: 'GR单数量' },
  { visible: false, prop: 'ma042', label: '采购规则' },
  { visible: false, prop: 'ma043', label: '货源' },
  { visible: false, prop: 'ma044', label: '季节' },
  { visible: false, prop: 'ma045', label: '标签类型' },
  { visible: false, prop: 'ma046', label: '标签格式' },
  { visible: false, prop: 'ma047', label: '取消激活' },
  { visible: false, prop: 'ma048', label: 'EAN' },
  { visible: false, prop: 'ma049', label: 'EAN类别' },
  { visible: false, prop: 'ma050', label: '长度' },
  { visible: false, prop: 'ma051', label: '宽度' },
  { visible: false, prop: 'ma052', label: '高度' },
  { visible: false, prop: 'ma053', label: '尺寸单位' },
  { visible: false, prop: 'ma054', label: '产品层次' },
  { visible: false, prop: 'ma055', label: '净改变成本核算' },
  { visible: false, prop: 'ma056', label: 'CAD标识' },
  { visible: false, prop: 'ma057', label: 'QM采购' },
  { visible: false, prop: 'ma058', label: '允许的包装重量' },
  { visible: false, prop: 'ma059', label: '重量单位' },
  { visible: false, prop: 'ma060', label: '允许体积' },
  { visible: false, prop: 'ma061', label: '体积单位' },
  { visible: false, prop: 'ma062', label: '超重量容差' },
  { visible: false, prop: 'ma063', label: '超体积容差' },
  { visible: false, prop: 'ma064', label: '可变订单单位' },
  { visible: false, prop: 'ma065', label: '修订等级' },
  { visible: false, prop: 'ma066', label: '可配置' },
  { visible: false, prop: 'ma067', label: '批次管理需求' },
  { visible: false, prop: 'ma068', label: '包装物料类型' },
  { visible: false, prop: 'ma069', label: '最大层次' },
  { visible: false, prop: 'ma070', label: '堆栈因子' },
  { visible: false, prop: 'ma071', label: '物料组包装物料' },
  { visible: false, prop: 'ma072', label: '权限组' },
  { visible: false, prop: 'ma073', label: '有效起始日' },
  { visible: false, prop: 'ma074', label: '有效结束日' },
  { visible: false, prop: 'ma075', label: '季度年' },
  { visible: false, prop: 'ma076', label: '价格标记' },
  { visible: false, prop: 'ma077', label: '空白BOM' },
  { visible: false, prop: 'ma078', label: '外部物料组' },
  { visible: false, prop: 'ma079', label: '一般可配置物料' },
  { visible: false, prop: 'ma080', label: '物料类别' },
  { visible: false, prop: 'ma081', label: '联产品' },
  { visible: false, prop: 'ma082', label: '后续物料' },
  { visible: false, prop: 'ma083', label: '定价参考物料' },
  { visible: false, prop: 'ma084', label: '跨工厂状态' },
  { visible: false, prop: 'ma085', label: '跨分销链状态' },
  { visible: false, prop: 'ma086', label: '跨工厂有效日期' },
  { visible: false, prop: 'ma087', label: '跨分销有效日期' },
  { visible: false, prop: 'ma088', label: '税收分类' },
  { visible: false, prop: 'ma089', label: '类别参数文件' },
  { visible: false, prop: 'ma090', label: '剩余货架寿命' },
  { visible: false, prop: 'ma091', label: '总货架寿命' },
  { visible: false, prop: 'ma092', label: '仓储百分比' },
  { visible: false, prop: 'ma093', label: '内容单位' },
  { visible: false, prop: 'ma094', label: '净内容' },
  { visible: false, prop: 'ma095', label: '比较价格单位' },
  { visible: false, prop: 'ma096', label: '物料组标签' },
  { visible: false, prop: 'ma097', label: '毛内容' },
  { visible: false, prop: 'ma098', label: '转换方法' },
  { visible: false, prop: 'ma099', label: '内部对象号' },
  { visible: false, prop: 'ma100', label: '环境相关' },
  { visible: false, prop: 'ma101', label: '产品分配' },
  { visible: false, prop: 'ma102', label: '定价参数文件' },
  { visible: false, prop: 'ma103', label: '折扣类型' },
  { visible: false, prop: 'ma104', label: '制造商零件编号' },
  { visible: false, prop: 'ma105', label: '制造商' },
  { visible: false, prop: 'ma106', label: '内部物料编号' },
  { visible: false, prop: 'ma107', label: '制造商部件参数文件' },
  { visible: false, prop: 'ma108', label: '测量单位用法' },
  { visible: false, prop: 'ma109', label: '展开' },
  { visible: false, prop: 'ma110', label: '危险货物标识参数文件' },
  { visible: false, prop: 'ma111', label: '高粘性的' },
  { visible: false, prop: 'ma112', label: '固体/液体' },
  { visible: false, prop: 'ma113', label: '序列号层次' },
  { visible: false, prop: 'ma114', label: '密闭' },
  { visible: false, prop: 'ma115', label: '需要批量记录' },
  { visible: false, prop: 'ma116', label: '参数有效值' },
  { visible: false, prop: 'ma117', label: '完成水平' },
  { visible: false, prop: 'ma118', label: '期间标识' },
  { visible: false, prop: 'ma119', label: '舍入规则' },
  { visible: false, prop: 'ma120', label: '产品成份' },
  { visible: false, prop: 'ma121', label: '普通项目类别组' },
  { visible: false, prop: 'ma122', label: '后勤变量' },
  { visible: false, prop: 'ma123', label: '物料被锁定' },
  { visible: false, prop: 'ma124', label: '配置相关' },
  { visible: false, prop: 'ma125', label: '分类清单类型' },
  { visible: false, prop: 'ma126', label: '过期日期' },
  { visible: false, prop: 'ma127', label: 'EAN变式' },
  { visible: false, prop: 'ma128', label: '一般物料' },
  { visible: false, prop: 'ma129', label: '包装参考物料' },
  { visible: false, prop: 'ma130', label: 'GDS相关' },
  { visible: false, prop: 'ma131', label: '原始接受' },
  { visible: false, prop: 'ma132', label: '标准处理单位类型' },
  { visible: false, prop: 'ma133', label: '可偷窃的' },
  { visible: false, prop: 'ma134', label: '仓库存储条件' },
  { visible: false, prop: 'ma135', label: '仓库物料组' },
  { visible: false, prop: 'ma136', label: '处理标识' },
  { visible: false, prop: 'ma137', label: '危险物料' },
  { visible: false, prop: 'ma138', label: '处理单位类型' },
  { visible: false, prop: 'ma139', label: '可变皮重' },
  { visible: false, prop: 'ma140', label: '最大容量' },
  { visible: false, prop: 'ma141', label: '最大容量容差' },
  { visible: false, prop: 'ma142', label: '最大长度' },
  { visible: false, prop: 'ma143', label: '最大宽度' },
  { visible: false, prop: 'ma144', label: '最大高度' },
  { visible: false, prop: 'ma145', label: '计量单位' },
  { visible: false, prop: 'ma146', label: '原产地国' },
  { visible: false, prop: 'ma147', label: '物料运输组' },
  { visible: false, prop: 'ma148', label: '隔离期间' },
  { visible: false, prop: 'ma149', label: '时间单位' },
  { visible: false, prop: 'ma150', label: '质量检查组' },
  { visible: false, prop: 'ma151', label: '序列号参数文件' },
  { visible: false, prop: 'ma152', label: '表格名' },
  { visible: false, prop: 'ma153', label: '后勤计量单位' },
  { visible: false, prop: 'ma154', label: '称重物料相关' },
  { visible: false, prop: 'ma155', label: 'CW参数文件' },
  { visible: false, prop: 'ma156', label: 'CW容差组' },
  { visible: false, prop: 'ma157', label: '调整参数文件' },
  { visible: false, prop: 'ma158', label: '知识产权' },
  { visible: false, prop: 'ma159', label: '允许的变式价格' },
  { visible: false, prop: 'ma160', label: '中间' },
  { visible: false, prop: 'ma161', label: '实物商品' },
  { visible: false, prop: 'ma162', label: '动物源' },
  { visible: false, prop: 'ma163', label: '纺织组分功能' },
  { visible: false, prop: 'ma164', label: '分段结构' },
  { visible: false, prop: 'ma165', label: '分段策略' },
  { visible: false, prop: 'ma166', label: '分段状态' },
  { visible: false, prop: 'ma167', label: '分段范围' },
  { visible: false, prop: 'ma168', label: '分段相关' },
  { visible: false, prop: 'ma169', label: 'ANP Code' },
  { visible: false, prop: 'ma170', label: 'Fashion属性1' },
  { visible: false, prop: 'ma171', label: 'Fashion属性2' },
  { visible: false, prop: 'ma172', label: 'Fashion属性3' },
  { visible: false, prop: 'ma173', label: '季节使用' },
  { visible: false, prop: 'ma174', label: '库存管理中激活季节' },
  { visible: false, prop: 'ma175', label: '物料转换标识' },
  { visible: false, prop: 'ma176', label: '装载单位' },
  { visible: false, prop: 'ma177', label: '装载单位组' },
  { visible: false, prop: 'ma178', label: '结构类别' },
  { visible: false, prop: 'ma179', label: '容差类型' },
  { visible: false, prop: 'ma180', label: '计算组' },
  { visible: false, prop: 'ma181', label: 'DSD 分组' },
  { visible: false, prop: 'ma182', label: '允许倾斜' },
  { visible: false, prop: 'ma183', label: '无堆栈' },
  { visible: false, prop: 'ma184', label: '底层' },
  { visible: false, prop: 'ma185', label: '顶层' },
  { visible: false, prop: 'ma186', label: '堆栈因子' },
  { visible: false, prop: 'ma187', label: '无包装物料装载' },
  { visible: false, prop: 'ma188', label: '悬挂深度' },
  { visible: false, prop: 'ma189', label: '悬挂宽度' },
  { visible: false, prop: 'ma190', label: '最大叠放高度' },
  { visible: false, prop: 'ma191', label: '最小叠放高度' },
  { visible: false, prop: 'ma192', label: '叠放高度容差' },
  { visible: false, prop: 'ma193', label: '物料编号PKM' },
  { visible: false, prop: 'ma194', label: 'VSO' },
  { visible: false, prop: 'ma195', label: '请求已清PKM' },
  { visible: false, prop: 'ma196', label: 'Packaging Code' },
  { visible: false, prop: 'ma197', label: '危险品的包装状态' },
  { visible: false, prop: 'ma198', label: '物料条件管理' },
  { visible: false, prop: 'ma199', label: '返回代码' },
  { visible: false, prop: 'ma200', label: '后勤等级退货' },
  { visible: false, prop: 'ma201', label: 'NATO项目' },
  { visible: false, prop: 'ma202', label: '完全互换组' },
  { visible: false, prop: 'ma203', label: '链编号' },
  { visible: false, prop: 'ma204', label: '创建状态' },
  { visible: false, prop: 'ma205', label: '内部特性1' },
  { visible: false, prop: 'ma206', label: '内部特性2' },
  { visible: false, prop: 'ma207', label: '内部特性3' },
  { visible: false, prop: 'ma208', label: '颜色' },
  { visible: false, prop: 'ma209', label: '主尺寸' },
  { visible: false, prop: 'ma210', label: '次尺寸' },
  { visible: false, prop: 'ma211', label: '特性值' },
  { visible: false, prop: 'ma212', label: '护理代码' },
  { visible: false, prop: 'ma213', label: '商标' },
  { visible: false, prop: 'ma214', label: '组件1' },
  { visible: false, prop: 'ma215', label: '百分比共享1' },
  { visible: false, prop: 'ma216', label: '组件2' },
  { visible: false, prop: 'ma217', label: '百分比共2' },
  { visible: false, prop: 'ma218', label: '组件3' },
  { visible: false, prop: 'ma219', label: '百分比共享3' },
  { visible: false, prop: 'ma220', label: '组件4' },
  { visible: false, prop: 'ma221', label: '百分比共享4' },
  { visible: false, prop: 'ma222', label: '组件5' },
  { visible: false, prop: 'ma223', label: '百分比共享5' },
  { visible: false, prop: 'ma224', label: '时装等级' },
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
  { dictType: "sys_eol_list" },
  { dictType: "sys_matl_type" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_matl_group" },
  { dictType: "sys_unit_list" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
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
    ma003: [{ required: true, message: "物料号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma007: [{ required: true, message: "物料类型"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma008: [{ required: true, message: "行业领域"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma011: [{ required: true, message: "基本单位"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma019: [{ required: true, message: "页数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma027: [{ required: true, message: "毛重"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma028: [{ required: true, message: "净重"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma030: [{ required: true, message: "业务量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma041: [{ required: true, message: "GR单数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma050: [{ required: true, message: "长度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma051: [{ required: true, message: "宽度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma052: [{ required: true, message: "高度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma058: [{ required: true, message: "允许的包装重量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma060: [{ required: true, message: "允许体积"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma062: [{ required: true, message: "超重量容差"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma063: [{ required: true, message: "超体积容差"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma069: [{ required: true, message: "最大层次"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma070: [{ required: true, message: "堆栈因子"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma090: [{ required: true, message: "剩余货架寿命"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma091: [{ required: true, message: "总货架寿命"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma092: [{ required: true, message: "仓储百分比"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma094: [{ required: true, message: "净内容"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma095: [{ required: true, message: "比较价格单位"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma097: [{ required: true, message: "毛内容"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma099: [{ required: true, message: "内部对象号"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma117: [{ required: true, message: "完成水平"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma140: [{ required: true, message: "最大容量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma141: [{ required: true, message: "最大容量容差"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma142: [{ required: true, message: "最大长度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma143: [{ required: true, message: "最大宽度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma144: [{ required: true, message: "最大高度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma148: [{ required: true, message: "隔离期间"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma169: [{ required: true, message: "ANP Code"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma176: [{ required: true, message: "装载单位"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma186: [{ required: true, message: "堆栈因子"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma188: [{ required: true, message: "悬挂深度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma189: [{ required: true, message: "悬挂宽度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma190: [{ required: true, message: "最大叠放高度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma191: [{ required: true, message: "最小叠放高度"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma192: [{ required: true, message: "叠放高度容差"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma193: [{ required: true, message: "物料编号PKM"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma205: [{ required: true, message: "内部特性1"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma206: [{ required: true, message: "内部特性2"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma207: [{ required: true, message: "内部特性3"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma215: [{ required: true, message: "百分比共享1"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma217: [{ required: true, message: "百分比共2"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma219: [{ required: true, message: "百分比共享3"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma221: [{ required: true, message: "百分比共享4"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    ma223: [{ required: true, message: "百分比共享5"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 集团删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_eol_list: [],
    // 物料类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_matl_type: [],
    // 行业领域 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ind_type: [],
    // 物料组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_matl_group: [],
    // 基本单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_unit_list: [],
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
    ma002: null,
    ma003: null,
    ma004: null,
    ma005: null,
    ma006: [],
    ma007: [],
    ma008: [],
    ma009: [],
    ma010: null,
    ma011: [],
    ma012: null,
    ma013: null,
    ma014: null,
    ma015: null,
    ma016: null,
    ma017: null,
    ma018: null,
    ma019: 0,
    ma020: null,
    ma021: null,
    ma022: null,
    ma023: null,
    ma024: null,
    ma025: null,
    ma026: null,
    ma027: 0,
    ma028: 0,
    ma029: null,
    ma030: 0,
    ma031: null,
    ma032: null,
    ma033: null,
    ma034: null,
    ma035: null,
    ma036: null,
    ma037: null,
    ma038: null,
    ma039: null,
    ma040: null,
    ma041: 0,
    ma042: null,
    ma043: null,
    ma044: null,
    ma045: null,
    ma046: null,
    ma047: null,
    ma048: null,
    ma049: null,
    ma050: 0,
    ma051: 0,
    ma052: 0,
    ma053: null,
    ma054: null,
    ma055: null,
    ma056: null,
    ma057: null,
    ma058: 0,
    ma059: null,
    ma060: 0,
    ma061: null,
    ma062: 0,
    ma063: 0,
    ma064: null,
    ma065: null,
    ma066: null,
    ma067: null,
    ma068: null,
    ma069: 0,
    ma070: 0,
    ma071: null,
    ma072: null,
    ma073: null,
    ma074: null,
    ma075: null,
    ma076: null,
    ma077: null,
    ma078: null,
    ma079: null,
    ma080: null,
    ma081: null,
    ma082: null,
    ma083: null,
    ma084: null,
    ma085: null,
    ma086: null,
    ma087: null,
    ma088: null,
    ma089: null,
    ma090: 0,
    ma091: 0,
    ma092: 0,
    ma093: null,
    ma094: 0,
    ma095: 0,
    ma096: null,
    ma097: 0,
    ma098: null,
    ma099: 0,
    ma100: null,
    ma101: null,
    ma102: null,
    ma103: null,
    ma104: null,
    ma105: null,
    ma106: null,
    ma107: null,
    ma108: null,
    ma109: null,
    ma110: null,
    ma111: null,
    ma112: null,
    ma113: null,
    ma114: null,
    ma115: null,
    ma116: null,
    ma117: 0,
    ma118: null,
    ma119: null,
    ma120: null,
    ma121: null,
    ma122: null,
    ma123: null,
    ma124: null,
    ma125: null,
    ma126: null,
    ma127: null,
    ma128: null,
    ma129: null,
    ma130: null,
    ma131: null,
    ma132: null,
    ma133: null,
    ma134: null,
    ma135: null,
    ma136: null,
    ma137: null,
    ma138: null,
    ma139: null,
    ma140: 0,
    ma141: 0,
    ma142: 0,
    ma143: 0,
    ma144: 0,
    ma145: null,
    ma146: null,
    ma147: null,
    ma148: 0,
    ma149: null,
    ma150: null,
    ma151: null,
    ma152: null,
    ma153: null,
    ma154: null,
    ma155: null,
    ma156: null,
    ma157: null,
    ma158: null,
    ma159: null,
    ma160: null,
    ma161: null,
    ma162: null,
    ma163: null,
    ma164: null,
    ma165: null,
    ma166: null,
    ma167: null,
    ma168: null,
    ma169: 0,
    ma170: null,
    ma171: null,
    ma172: null,
    ma173: null,
    ma174: null,
    ma175: null,
    ma176: 0,
    ma177: null,
    ma178: null,
    ma179: null,
    ma180: null,
    ma181: null,
    ma182: null,
    ma183: null,
    ma184: null,
    ma185: null,
    ma186: 0,
    ma187: null,
    ma188: 0,
    ma189: 0,
    ma190: 0,
    ma191: 0,
    ma192: 0,
    ma193: 0,
    ma194: null,
    ma195: null,
    ma196: null,
    ma197: null,
    ma198: null,
    ma199: null,
    ma200: null,
    ma201: null,
    ma202: null,
    ma203: null,
    ma204: null,
    ma205: 0,
    ma206: 0,
    ma207: 0,
    ma208: null,
    ma209: null,
    ma210: null,
    ma211: null,
    ma212: null,
    ma213: null,
    ma214: null,
    ma215: 0,
    ma216: null,
    ma217: 0,
    ma218: null,
    ma219: 0,
    ma220: null,
    ma221: 0,
    ma222: null,
    ma223: 0,
    ma224: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'常规物料'
  opertype.value = 1
  form.value.ma006= []
  form.value.ma007= []
  form.value.ma008= []
  form.value.ma009= []
  form.value.ma011= []
  form.value.ma019= 0
  form.value.ma027= 0
  form.value.ma028= 0
  form.value.ma030= 0
  form.value.ma041= 0
  form.value.ma050= 0
  form.value.ma051= 0
  form.value.ma052= 0
  form.value.ma058= 0
  form.value.ma060= 0
  form.value.ma062= 0
  form.value.ma063= 0
  form.value.ma069= 0
  form.value.ma070= 0
  form.value.ma073= new Date()
  form.value.ma074= new Date()
  form.value.ma086= new Date()
  form.value.ma087= new Date()
  form.value.ma090= 0
  form.value.ma091= 0
  form.value.ma092= 0
  form.value.ma094= 0
  form.value.ma095= 0
  form.value.ma097= 0
  form.value.ma099= 0
  form.value.ma117= 0
  form.value.ma140= 0
  form.value.ma141= 0
  form.value.ma142= 0
  form.value.ma143= 0
  form.value.ma144= 0
  form.value.ma148= 0
  form.value.ma169= 0
  form.value.ma176= 0
  form.value.ma186= 0
  form.value.ma188= 0
  form.value.ma189= 0
  form.value.ma190= 0
  form.value.ma191= 0
  form.value.ma192= 0
  form.value.ma193= 0
  form.value.ma205= 0
  form.value.ma206= 0
  form.value.ma207= 0
  form.value.ma215= 0
  form.value.ma217= 0
  form.value.ma219= 0
  form.value.ma221= 0
  form.value.ma223= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
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

      if (form.value.id != undefined && opertype.value === 2) {
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
  const Ids = row.id || ids.value

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