<!--
 * @Descripttion: 物料评估/mm_mbew
 * @Version: 0.24.620.18453
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 11:30:25
 * @column：134
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="物料号" prop="md003">
        <el-input v-model="queryParams.md003" :placeholder="$t('btn.enterSearchPrefix')+'物料号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="评估范围" prop="md004">
        <el-select filterable clearable   v-model="queryParams.md004" :placeholder="$t('btn.selectSearchPrefix')+'评估范围'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="评估类型" prop="md005">
        <el-select filterable clearable   v-model="queryParams.md005" :placeholder="$t('btn.selectSearchPrefix')+'评估类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_val_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="md002" label="集团" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md002')"/>
      <el-table-column prop="md003" label="物料号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md003')"/>
      <el-table-column prop="md004" label="评估范围" align="center" v-if="columns.showColumn('md004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.md004"  />
        </template>
      </el-table-column>
      <el-table-column prop="md005" label="评估类型" align="center" v-if="columns.showColumn('md005')">
        <template #default="scope">
          <dict-tag :options=" options.sys_val_type " :value="scope.row.md005"  />
        </template>
      </el-table-column>
      <el-table-column prop="md006" label="删除标志" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md006')"/>
      <el-table-column prop="md007" label="总库存" align="center" v-if="columns.showColumn('md007')"/>
      <el-table-column prop="md008" label="估价值" align="center" v-if="columns.showColumn('md008')"/>
      <el-table-column prop="md009" label="价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md009')"/>
      <el-table-column prop="md010" label="移动价格" align="center" v-if="columns.showColumn('md010')"/>
      <el-table-column prop="md011" label="标准价格" align="center" v-if="columns.showColumn('md011')"/>
      <el-table-column prop="md012" label="价格单位" align="center" v-if="columns.showColumn('md012')"/>
      <el-table-column prop="md013" label="评估类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md013')"/>
      <el-table-column prop="md014" label="价值/MA价格" align="center" v-if="columns.showColumn('md014')"/>
      <el-table-column prop="md015" label="前期总库存" align="center" v-if="columns.showColumn('md015')"/>
      <el-table-column prop="md016" label="前期总价值" align="center" v-if="columns.showColumn('md016')"/>
      <el-table-column prop="md017" label="前期价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md017')"/>
      <el-table-column prop="md018" label="前期移动平均价" align="center" v-if="columns.showColumn('md018')"/>
      <el-table-column prop="md019" label="前期标准价格" align="center" v-if="columns.showColumn('md019')"/>
      <el-table-column prop="md020" label="上期价格单位" align="center" v-if="columns.showColumn('md020')"/>
      <el-table-column prop="md021" label="上期评价分类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md021')"/>
      <el-table-column prop="md022" label="上期价值" align="center" v-if="columns.showColumn('md022')"/>
      <el-table-column prop="md023" label="前年总库存" align="center" v-if="columns.showColumn('md023')"/>
      <el-table-column prop="md024" label="上年总价值" align="center" v-if="columns.showColumn('md024')"/>
      <el-table-column prop="md025" label="前年价格控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md025')"/>
      <el-table-column prop="md026" label="去年移动平均价" align="center" v-if="columns.showColumn('md026')"/>
      <el-table-column prop="md027" label="去年标准价格" align="center" v-if="columns.showColumn('md027')"/>
      <el-table-column prop="md028" label="上年价格单位" align="center" v-if="columns.showColumn('md028')"/>
      <el-table-column prop="md029" label="上年评估类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md029')"/>
      <el-table-column prop="md030" label="上年价值" align="center" v-if="columns.showColumn('md030')"/>
      <el-table-column prop="md031" label="当前会计年度" align="center" v-if="columns.showColumn('md031')"/>
      <el-table-column prop="md032" label="当前期间" align="center" v-if="columns.showColumn('md032')"/>
      <el-table-column prop="md033" label="评估类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md033')"/>
      <el-table-column prop="md034" label="上期价格" align="center" v-if="columns.showColumn('md034')"/>
      <el-table-column prop="md035" label="最新价格更改" :show-overflow-tooltip="true"  v-if="columns.showColumn('md035')"/>
      <el-table-column prop="md036" label="未来价格" align="center" v-if="columns.showColumn('md036')"/>
      <el-table-column prop="md037" label="有效起始日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md037')"/>
      <el-table-column prop="md038" label="时戳" align="center" v-if="columns.showColumn('md038')"/>
      <el-table-column prop="md039" label="税价1" align="center" v-if="columns.showColumn('md039')"/>
      <el-table-column prop="md040" label="商业价格1" align="center" v-if="columns.showColumn('md040')"/>
      <el-table-column prop="md041" label="税价3" align="center" v-if="columns.showColumn('md041')"/>
      <el-table-column prop="md042" label="商业价格3" align="center" v-if="columns.showColumn('md042')"/>
      <el-table-column prop="md043" label="计价" align="center" v-if="columns.showColumn('md043')"/>
      <el-table-column prop="md044" label="前年总库存" align="center" v-if="columns.showColumn('md044')"/>
      <el-table-column prop="md045" label="前期总价值" align="center" v-if="columns.showColumn('md045')"/>
      <el-table-column prop="md046" label="计价在" align="center" v-if="columns.showColumn('md046')"/>
      <el-table-column prop="md047" label="未来计划价格" align="center" v-if="columns.showColumn('md047')"/>
      <el-table-column prop="md048" label="未来计划价格1" align="center" v-if="columns.showColumn('md048')"/>
      <el-table-column prop="md049" label="未来计划价格 2" align="center" v-if="columns.showColumn('md049')"/>
      <el-table-column prop="md050" label="未来计划价格 3" align="center" v-if="columns.showColumn('md050')"/>
      <el-table-column prop="md051" label="计划价格日期1" :show-overflow-tooltip="true"  v-if="columns.showColumn('md051')"/>
      <el-table-column prop="md052" label="计划价格日期2" :show-overflow-tooltip="true"  v-if="columns.showColumn('md052')"/>
      <el-table-column prop="md053" label="计划价格日期3" :show-overflow-tooltip="true"  v-if="columns.showColumn('md053')"/>
      <el-table-column prop="md054" label="未来成本估算" :show-overflow-tooltip="true"  v-if="columns.showColumn('md054')"/>
      <el-table-column prop="md055" label="期间成本估算" :show-overflow-tooltip="true"  v-if="columns.showColumn('md055')"/>
      <el-table-column prop="md056" label="上期成本估算" :show-overflow-tooltip="true"  v-if="columns.showColumn('md056')"/>
      <el-table-column prop="md057" label="未来成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md057')"/>
      <el-table-column prop="md058" label="当前成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md058')"/>
      <el-table-column prop="md059" label="上期成本估算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md059')"/>
      <el-table-column prop="md060" label="一般费用代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md060')"/>
      <el-table-column prop="md061" label="LIFO/FIFO 相关" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md061')"/>
      <el-table-column prop="md062" label="LIFO评估储备号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md062')"/>
      <el-table-column prop="md063" label="商业价格2" align="center" v-if="columns.showColumn('md063')"/>
      <el-table-column prop="md064" label="税价2" align="center" v-if="columns.showColumn('md064')"/>
      <el-table-column prop="md065" label="贬值标志" align="center" v-if="columns.showColumn('md065')"/>
      <el-table-column prop="md066" label="维护状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md066')"/>
      <el-table-column prop="md067" label="产品成本核算" align="center" v-if="columns.showColumn('md067')"/>
      <el-table-column prop="md068" label="成本估算编号" align="center" v-if="columns.showColumn('md068')"/>
      <el-table-column prop="md069" label="评估变式1" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md069')"/>
      <el-table-column prop="md070" label="评估变式2" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md070')"/>
      <el-table-column prop="md071" label="评估变式3" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md071')"/>
      <el-table-column prop="md072" label="成本核算版本1" align="center" v-if="columns.showColumn('md072')"/>
      <el-table-column prop="md073" label="成本核算版本2" align="center" v-if="columns.showColumn('md073')"/>
      <el-table-column prop="md074" label="成本核算版本3" align="center" v-if="columns.showColumn('md074')"/>
      <el-table-column prop="md075" label="原始组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md075')"/>
      <el-table-column prop="md076" label="间接费分组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md076')"/>
      <el-table-column prop="md077" label="计价期间" align="center" v-if="columns.showColumn('md077')"/>
      <el-table-column prop="md078" label="当前期间" align="center" v-if="columns.showColumn('md078')"/>
      <el-table-column prop="md079" label="前一期间" align="center" v-if="columns.showColumn('md079')"/>
      <el-table-column prop="md080" label="未来会计年度" align="center" v-if="columns.showColumn('md080')"/>
      <el-table-column prop="md081" label="当前会计年度" align="center" v-if="columns.showColumn('md081')"/>
      <el-table-column prop="md082" label="上一会计年度" align="center" v-if="columns.showColumn('md082')"/>
      <el-table-column prop="md083" label="QS成本核算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md083')"/>
      <el-table-column prop="md084" label="上期标准价格" align="center" v-if="columns.showColumn('md084')"/>
      <el-table-column prop="md085" label="ML作业" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md085')"/>
      <el-table-column prop="md086" label="价格确定" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md086')"/>
      <el-table-column prop="md087" label="当前计划价格" align="center" v-if="columns.showColumn('md087')"/>
      <el-table-column prop="md088" label="总SP值" align="center" v-if="columns.showColumn('md088')"/>
      <el-table-column prop="md089" label="物料来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md089')"/>
      <el-table-column prop="md090" label="库存冻结" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md090')"/>
      <el-table-column prop="md091" label="库存盘点VO物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md091')"/>
      <el-table-column prop="md092" label="最新实际盘点日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('md092')"/>
      <el-table-column prop="md093" label="周期盘点的盘点标识" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md093')"/>
      <el-table-column prop="md094" label="评价毛利" align="center" v-if="columns.showColumn('md094')"/>
      <el-table-column prop="md095" label="当前计划价格的固定金额" align="center" v-if="columns.showColumn('md095')"/>
      <el-table-column prop="md096" label="上年计划价格的固定比例" align="center" v-if="columns.showColumn('md096')"/>
      <el-table-column prop="md097" label="未来计划价格的固定比例" align="center" v-if="columns.showColumn('md097')"/>
      <el-table-column prop="md098" label="当前的值决策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md098')"/>
      <el-table-column prop="md099" label="上年评估策略" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md099')"/>
      <el-table-column prop="md100" label="未来评估决策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md100')"/>
      <el-table-column prop="md101" label="销售订单库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md101')"/>
      <el-table-column prop="md102" label="项目库存评估类" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md102')"/>
      <el-table-column prop="md103" label="物料用途" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md103')"/>
      <el-table-column prop="md104" label="物料来源" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md104')"/>
      <el-table-column prop="md105" label="自制产品" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md105')"/>
      <el-table-column prop="md106" label="评估单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md106')"/>
      <el-table-column prop="md107" label="价格单位" align="center" v-if="columns.showColumn('md107')"/>
      <el-table-column prop="md108" label="最后期间之前" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md108')"/>
      <el-table-column prop="md109" label="VC供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md109')"/>
      <el-table-column prop="md110" label="预付库存" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('md110')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
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
            <el-form-item label="集团" prop="md002">
              <el-input   v-model="form.md002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料号" prop="md003">
              <el-input   v-model="form.md003" :placeholder="$t('btn.enterPrefix')+'物料号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="18"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估范围" prop="md004">
              <el-select filterable clearable   v-model="form.md004"  :placeholder="$t('btn.selectPrefix')+'评估范围'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="评估类型" prop="md005">
              <el-select filterable clearable   v-model="form.md005"  :placeholder="$t('btn.selectPrefix')+'评估类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_val_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="删除标志" prop="md006">
              <el-input   v-model="form.md006" :placeholder="$t('btn.enterPrefix')+'删除标志'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总库存" prop="md007">
              <el-input-number v-model.number="form.md007" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="估价值" prop="md008">
              <el-input-number v-model.number="form.md008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'估价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格控制" prop="md009">
              <el-input   v-model="form.md009" :placeholder="$t('btn.enterPrefix')+'价格控制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="移动价格" prop="md010">
              <el-input-number v-model.number="form.md010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'移动价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标准价格" prop="md011">
              <el-input-number v-model.number="form.md011" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格单位" prop="md012">
              <el-input-number v-model.number="form.md012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类" prop="md013">
              <el-input   v-model="form.md013" :placeholder="$t('btn.enterPrefix')+'评估类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价值/MA价格" prop="md014">
              <el-input-number v-model.number="form.md014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'价值/MA价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期总库存" prop="md015">
              <el-input-number v-model.number="form.md015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期总库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期总价值" prop="md016">
              <el-input-number v-model.number="form.md016" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期总价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期价格控制" prop="md017">
              <el-input   v-model="form.md017" :placeholder="$t('btn.enterPrefix')+'前期价格控制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期移动平均价" prop="md018">
              <el-input-number v-model.number="form.md018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期移动平均价'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期标准价格" prop="md019">
              <el-input-number v-model.number="form.md019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期价格单位" prop="md020">
              <el-input-number v-model.number="form.md020" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上期价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期评价分类" prop="md021">
              <el-input   v-model="form.md021" :placeholder="$t('btn.enterPrefix')+'上期评价分类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期价值" prop="md022">
              <el-input-number v-model.number="form.md022" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上期价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年总库存" prop="md023">
              <el-input-number v-model.number="form.md023" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前年总库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年总价值" prop="md024">
              <el-input-number v-model.number="form.md024" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上年总价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年价格控制" prop="md025">
              <el-input   v-model="form.md025" :placeholder="$t('btn.enterPrefix')+'前年价格控制'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="去年移动平均价" prop="md026">
              <el-input-number v-model.number="form.md026" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'去年移动平均价'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="去年标准价格" prop="md027">
              <el-input-number v-model.number="form.md027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'去年标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年价格单位" prop="md028">
              <el-input-number v-model.number="form.md028" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上年价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年评估类" prop="md029">
              <el-input   v-model="form.md029" :placeholder="$t('btn.enterPrefix')+'上年评估类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年价值" prop="md030">
              <el-input-number v-model.number="form.md030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上年价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前会计年度" prop="md031">
              <el-input-number v-model.number="form.md031" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前期间" prop="md032">
              <el-input-number v-model.number="form.md032" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估类别" prop="md033">
              <el-input   v-model="form.md033" :placeholder="$t('btn.enterPrefix')+'评估类别'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期价格" prop="md034">
              <el-input-number v-model.number="form.md034" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上期价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最新价格更改" prop="md035">
              <el-date-picker v-model="form.md035" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来价格" prop="md036">
              <el-input-number v-model.number="form.md036" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="有效起始日期" prop="md037">
              <el-date-picker v-model="form.md037" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="时戳" prop="md038">
              <el-input-number v-model.number="form.md038" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'时戳'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税价1" prop="md039">
              <el-input-number v-model.number="form.md039" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'税价1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商业价格1" prop="md040">
              <el-input-number v-model.number="form.md040" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'商业价格1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税价3" prop="md041">
              <el-input-number v-model.number="form.md041" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'税价3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商业价格3" prop="md042">
              <el-input-number v-model.number="form.md042" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'商业价格3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计价" prop="md043">
              <el-input-number v-model.number="form.md043" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'计价'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前年总库存" prop="md044">
              <el-input-number v-model.number="form.md044" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前年总库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="前期总价值" prop="md045">
              <el-input-number v-model.number="form.md045" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前期总价值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计价在" prop="md046">
              <el-input-number v-model.number="form.md046" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'计价在'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格" prop="md047">
              <el-input-number v-model.number="form.md047" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格1" prop="md048">
              <el-input-number v-model.number="form.md048" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格 2" prop="md049">
              <el-input-number v-model.number="form.md049" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格 2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格 3" prop="md050">
              <el-input-number v-model.number="form.md050" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格 3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格日期1" prop="md051">
              <el-date-picker v-model="form.md051" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格日期2" prop="md052">
              <el-date-picker v-model="form.md052" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="计划价格日期3" prop="md053">
              <el-date-picker v-model="form.md053" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来成本估算" prop="md054">
              <el-date-picker v-model="form.md054" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="期间成本估算" prop="md055">
              <el-date-picker v-model="form.md055" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期成本估算" prop="md056">
              <el-date-picker v-model="form.md056" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来成本估算" prop="md057">
              <el-input   v-model="form.md057" :placeholder="$t('btn.enterPrefix')+'未来成本估算'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前成本估算" prop="md058">
              <el-input   v-model="form.md058" :placeholder="$t('btn.enterPrefix')+'当前成本估算'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期成本估算" prop="md059">
              <el-input   v-model="form.md059" :placeholder="$t('btn.enterPrefix')+'上期成本估算'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="一般费用代码" prop="md060">
              <el-input   v-model="form.md060" :placeholder="$t('btn.enterPrefix')+'一般费用代码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="LIFO/FIFO 相关" prop="md061">
              <el-input   v-model="form.md061" :placeholder="$t('btn.enterPrefix')+'LIFO/FIFO 相关'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="LIFO评估储备号" prop="md062">
              <el-input   v-model="form.md062" :placeholder="$t('btn.enterPrefix')+'LIFO评估储备号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="商业价格2" prop="md063">
              <el-input-number v-model.number="form.md063" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'商业价格2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税价2" prop="md064">
              <el-input-number v-model.number="form.md064" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'税价2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="贬值标志" prop="md065">
              <el-input-number v-model.number="form.md065" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'贬值标志'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="维护状态" prop="md066">
              <el-input   v-model="form.md066" :placeholder="$t('btn.enterPrefix')+'维护状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="15"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="产品成本核算" prop="md067">
              <el-input-number v-model.number="form.md067" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'产品成本核算'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="成本估算编号" prop="md068">
              <el-input-number v-model.number="form.md068" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'成本估算编号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估变式1" prop="md069">
              <el-input   v-model="form.md069" :placeholder="$t('btn.enterPrefix')+'评估变式1'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估变式2" prop="md070">
              <el-input   v-model="form.md070" :placeholder="$t('btn.enterPrefix')+'评估变式2'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估变式3" prop="md071">
              <el-input   v-model="form.md071" :placeholder="$t('btn.enterPrefix')+'评估变式3'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="成本核算版本1" prop="md072">
              <el-input-number v-model.number="form.md072" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'成本核算版本1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="成本核算版本2" prop="md073">
              <el-input-number v-model.number="form.md073" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'成本核算版本2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="成本核算版本3" prop="md074">
              <el-input-number v-model.number="form.md074" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'成本核算版本3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原始组" prop="md075">
              <el-input   v-model="form.md075" :placeholder="$t('btn.enterPrefix')+'原始组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接费分组" prop="md076">
              <el-input   v-model="form.md076" :placeholder="$t('btn.enterPrefix')+'间接费分组'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="计价期间" prop="md077">
              <el-input-number v-model.number="form.md077" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'计价期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前期间" prop="md078">
              <el-input-number v-model.number="form.md078" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="前一期间" prop="md079">
              <el-input-number v-model.number="form.md079" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'前一期间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="未来会计年度" prop="md080">
              <el-input-number v-model.number="form.md080" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="当前会计年度" prop="md081">
              <el-input-number v-model.number="form.md081" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="上一会计年度" prop="md082">
              <el-input-number v-model.number="form.md082" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上一会计年度'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QS成本核算" prop="md083">
              <el-input   v-model="form.md083" :placeholder="$t('btn.enterPrefix')+'QS成本核算'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上期标准价格" prop="md084">
              <el-input-number v-model.number="form.md084" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上期标准价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="ML作业" prop="md085">
              <el-input   v-model="form.md085" :placeholder="$t('btn.enterPrefix')+'ML作业'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格确定" prop="md086">
              <el-input   v-model="form.md086" :placeholder="$t('btn.enterPrefix')+'价格确定'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前计划价格" prop="md087">
              <el-input-number v-model.number="form.md087" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前计划价格'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="总SP值" prop="md088">
              <el-input-number v-model.number="form.md088" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'总SP值'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料来源" prop="md089">
              <el-input   v-model="form.md089" :placeholder="$t('btn.enterPrefix')+'物料来源'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存冻结" prop="md090">
              <el-input   v-model="form.md090" :placeholder="$t('btn.enterPrefix')+'库存冻结'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存盘点VO物料" prop="md091">
              <el-input   v-model="form.md091" :placeholder="$t('btn.enterPrefix')+'库存盘点VO物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最新实际盘点日期" prop="md092">
              <el-date-picker v-model="form.md092" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="周期盘点的盘点标识" prop="md093">
              <el-input   v-model="form.md093" :placeholder="$t('btn.enterPrefix')+'周期盘点的盘点标识'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评价毛利" prop="md094">
              <el-input-number v-model.number="form.md094" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'评价毛利'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前计划价格的固定金额" prop="md095">
              <el-input-number v-model.number="form.md095" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'当前计划价格的固定金额'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年计划价格的固定比例" prop="md096">
              <el-input-number v-model.number="form.md096" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'上年计划价格的固定比例'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来计划价格的固定比例" prop="md097">
              <el-input-number v-model.number="form.md097" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'未来计划价格的固定比例'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="当前的值决策" prop="md098">
              <el-input   v-model="form.md098" :placeholder="$t('btn.enterPrefix')+'当前的值决策'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="上年评估策略" prop="md099">
              <el-input   v-model="form.md099" :placeholder="$t('btn.enterPrefix')+'上年评估策略'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="未来评估决策" prop="md100">
              <el-input   v-model="form.md100" :placeholder="$t('btn.enterPrefix')+'未来评估决策'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售订单库存" prop="md101">
              <el-input   v-model="form.md101" :placeholder="$t('btn.enterPrefix')+'销售订单库存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="项目库存评估类" prop="md102">
              <el-input   v-model="form.md102" :placeholder="$t('btn.enterPrefix')+'项目库存评估类'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料用途" prop="md103">
              <el-input   v-model="form.md103" :placeholder="$t('btn.enterPrefix')+'物料用途'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料来源" prop="md104">
              <el-input   v-model="form.md104" :placeholder="$t('btn.enterPrefix')+'物料来源'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自制产品" prop="md105">
              <el-input   v-model="form.md105" :placeholder="$t('btn.enterPrefix')+'自制产品'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评估单位" prop="md106">
              <el-input   v-model="form.md106" :placeholder="$t('btn.enterPrefix')+'评估单位'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="价格单位" prop="md107">
              <el-input-number v-model.number="form.md107" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="最后期间之前" prop="md108">
              <el-input   v-model="form.md108" :placeholder="$t('btn.enterPrefix')+'最后期间之前'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="VC供应商" prop="md109">
              <el-input   v-model="form.md109" :placeholder="$t('btn.enterPrefix')+'VC供应商'+$t('btn.enterSuffix')"  show-word-limit   maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预付库存" prop="md110">
              <el-input   v-model="form.md110" :placeholder="$t('btn.enterPrefix')+'预付库存'+$t('btn.enterSuffix')"  show-word-limit   maxlength="1"/>
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
  sort: 'Md003',
  sortType: 'asc',
  //是否查询（1是）
  md003: undefined,
  //是否查询（1是）
  md004: undefined,
  //是否查询（1是）
  md005: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'md002', label: '集团' },
  { visible: true, prop: 'md003', label: '物料号' },
  { visible: true, prop: 'md004', label: '评估范围' },
  { visible: true, prop: 'md005', label: '评估类型' },
  { visible: true, prop: 'md006', label: '删除标志' },
  { visible: true, prop: 'md007', label: '总库存' },
  { visible: true, prop: 'md008', label: '估价值' },
  { visible: false, prop: 'md009', label: '价格控制' },
  { visible: false, prop: 'md010', label: '移动价格' },
  { visible: false, prop: 'md011', label: '标准价格' },
  { visible: false, prop: 'md012', label: '价格单位' },
  { visible: false, prop: 'md013', label: '评估类' },
  { visible: false, prop: 'md014', label: '价值/MA价格' },
  { visible: false, prop: 'md015', label: '前期总库存' },
  { visible: false, prop: 'md016', label: '前期总价值' },
  { visible: false, prop: 'md017', label: '前期价格控制' },
  { visible: false, prop: 'md018', label: '前期移动平均价' },
  { visible: false, prop: 'md019', label: '前期标准价格' },
  { visible: false, prop: 'md020', label: '上期价格单位' },
  { visible: false, prop: 'md021', label: '上期评价分类' },
  { visible: false, prop: 'md022', label: '上期价值' },
  { visible: false, prop: 'md023', label: '前年总库存' },
  { visible: false, prop: 'md024', label: '上年总价值' },
  { visible: false, prop: 'md025', label: '前年价格控制' },
  { visible: false, prop: 'md026', label: '去年移动平均价' },
  { visible: false, prop: 'md027', label: '去年标准价格' },
  { visible: false, prop: 'md028', label: '上年价格单位' },
  { visible: false, prop: 'md029', label: '上年评估类' },
  { visible: false, prop: 'md030', label: '上年价值' },
  { visible: false, prop: 'md031', label: '当前会计年度' },
  { visible: false, prop: 'md032', label: '当前期间' },
  { visible: false, prop: 'md033', label: '评估类别' },
  { visible: false, prop: 'md034', label: '上期价格' },
  { visible: false, prop: 'md035', label: '最新价格更改' },
  { visible: false, prop: 'md036', label: '未来价格' },
  { visible: false, prop: 'md037', label: '有效起始日期' },
  { visible: false, prop: 'md038', label: '时戳' },
  { visible: false, prop: 'md039', label: '税价1' },
  { visible: false, prop: 'md040', label: '商业价格1' },
  { visible: false, prop: 'md041', label: '税价3' },
  { visible: false, prop: 'md042', label: '商业价格3' },
  { visible: false, prop: 'md043', label: '计价' },
  { visible: false, prop: 'md044', label: '前年总库存' },
  { visible: false, prop: 'md045', label: '前期总价值' },
  { visible: false, prop: 'md046', label: '计价在' },
  { visible: false, prop: 'md047', label: '未来计划价格' },
  { visible: false, prop: 'md048', label: '未来计划价格1' },
  { visible: false, prop: 'md049', label: '未来计划价格 2' },
  { visible: false, prop: 'md050', label: '未来计划价格 3' },
  { visible: false, prop: 'md051', label: '计划价格日期1' },
  { visible: false, prop: 'md052', label: '计划价格日期2' },
  { visible: false, prop: 'md053', label: '计划价格日期3' },
  { visible: false, prop: 'md054', label: '未来成本估算' },
  { visible: false, prop: 'md055', label: '期间成本估算' },
  { visible: false, prop: 'md056', label: '上期成本估算' },
  { visible: false, prop: 'md057', label: '未来成本估算' },
  { visible: false, prop: 'md058', label: '当前成本估算' },
  { visible: false, prop: 'md059', label: '上期成本估算' },
  { visible: false, prop: 'md060', label: '一般费用代码' },
  { visible: false, prop: 'md061', label: 'LIFO/FIFO 相关' },
  { visible: false, prop: 'md062', label: 'LIFO评估储备号' },
  { visible: false, prop: 'md063', label: '商业价格2' },
  { visible: false, prop: 'md064', label: '税价2' },
  { visible: false, prop: 'md065', label: '贬值标志' },
  { visible: false, prop: 'md066', label: '维护状态' },
  { visible: false, prop: 'md067', label: '产品成本核算' },
  { visible: false, prop: 'md068', label: '成本估算编号' },
  { visible: false, prop: 'md069', label: '评估变式1' },
  { visible: false, prop: 'md070', label: '评估变式2' },
  { visible: false, prop: 'md071', label: '评估变式3' },
  { visible: false, prop: 'md072', label: '成本核算版本1' },
  { visible: false, prop: 'md073', label: '成本核算版本2' },
  { visible: false, prop: 'md074', label: '成本核算版本3' },
  { visible: false, prop: 'md075', label: '原始组' },
  { visible: false, prop: 'md076', label: '间接费分组' },
  { visible: false, prop: 'md077', label: '计价期间' },
  { visible: false, prop: 'md078', label: '当前期间' },
  { visible: false, prop: 'md079', label: '前一期间' },
  { visible: false, prop: 'md080', label: '未来会计年度' },
  { visible: false, prop: 'md081', label: '当前会计年度' },
  { visible: false, prop: 'md082', label: '上一会计年度' },
  { visible: false, prop: 'md083', label: 'QS成本核算' },
  { visible: false, prop: 'md084', label: '上期标准价格' },
  { visible: false, prop: 'md085', label: 'ML作业' },
  { visible: false, prop: 'md086', label: '价格确定' },
  { visible: false, prop: 'md087', label: '当前计划价格' },
  { visible: false, prop: 'md088', label: '总SP值' },
  { visible: false, prop: 'md089', label: '物料来源' },
  { visible: false, prop: 'md090', label: '库存冻结' },
  { visible: false, prop: 'md091', label: '库存盘点VO物料' },
  { visible: false, prop: 'md092', label: '最新实际盘点日期' },
  { visible: false, prop: 'md093', label: '周期盘点的盘点标识' },
  { visible: false, prop: 'md094', label: '评价毛利' },
  { visible: false, prop: 'md095', label: '当前计划价格的固定金额' },
  { visible: false, prop: 'md096', label: '上年计划价格的固定比例' },
  { visible: false, prop: 'md097', label: '未来计划价格的固定比例' },
  { visible: false, prop: 'md098', label: '当前的值决策' },
  { visible: false, prop: 'md099', label: '上年评估策略' },
  { visible: false, prop: 'md100', label: '未来评估决策' },
  { visible: false, prop: 'md101', label: '销售订单库存' },
  { visible: false, prop: 'md102', label: '项目库存评估类' },
  { visible: false, prop: 'md103', label: '物料用途' },
  { visible: false, prop: 'md104', label: '物料来源' },
  { visible: false, prop: 'md105', label: '自制产品' },
  { visible: false, prop: 'md106', label: '评估单位' },
  { visible: false, prop: 'md107', label: '价格单位' },
  { visible: false, prop: 'md108', label: '最后期间之前' },
  { visible: false, prop: 'md109', label: 'VC供应商' },
  { visible: false, prop: 'md110', label: '预付库存' },
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
  { dictType: "sys_val_type" },
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
    md002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md003: [{ required: true, message: "物料号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md004: [{ required: true, message: "评估范围"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    md005: [{ required: true, message: "评估类型"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    md007: [{ required: true, message: "总库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md008: [{ required: true, message: "估价值"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md010: [{ required: true, message: "移动价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md011: [{ required: true, message: "标准价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md012: [{ required: true, message: "价格单位"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md014: [{ required: true, message: "价值/MA价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md015: [{ required: true, message: "前期总库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md016: [{ required: true, message: "前期总价值"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md018: [{ required: true, message: "前期移动平均价"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md019: [{ required: true, message: "前期标准价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md020: [{ required: true, message: "上期价格单位"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md022: [{ required: true, message: "上期价值"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md023: [{ required: true, message: "前年总库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md024: [{ required: true, message: "上年总价值"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md026: [{ required: true, message: "去年移动平均价"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md027: [{ required: true, message: "去年标准价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md028: [{ required: true, message: "上年价格单位"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md030: [{ required: true, message: "上年价值"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md031: [{ required: true, message: "当前会计年度"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md032: [{ required: true, message: "当前期间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md034: [{ required: true, message: "上期价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md036: [{ required: true, message: "未来价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md038: [{ required: true, message: "时戳"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md039: [{ required: true, message: "税价1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md040: [{ required: true, message: "商业价格1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md041: [{ required: true, message: "税价3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md042: [{ required: true, message: "商业价格3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md043: [{ required: true, message: "计价"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md044: [{ required: true, message: "前年总库存"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md045: [{ required: true, message: "前期总价值"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md046: [{ required: true, message: "计价在"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md047: [{ required: true, message: "未来计划价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md048: [{ required: true, message: "未来计划价格1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md049: [{ required: true, message: "未来计划价格 2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md050: [{ required: true, message: "未来计划价格 3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md063: [{ required: true, message: "商业价格2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md064: [{ required: true, message: "税价2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md065: [{ required: true, message: "贬值标志"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md067: [{ required: true, message: "产品成本核算"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md068: [{ required: true, message: "成本估算编号"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md072: [{ required: true, message: "成本核算版本1"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md073: [{ required: true, message: "成本核算版本2"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md074: [{ required: true, message: "成本核算版本3"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md077: [{ required: true, message: "计价期间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md078: [{ required: true, message: "当前期间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md079: [{ required: true, message: "前一期间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md080: [{ required: true, message: "未来会计年度"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md081: [{ required: true, message: "当前会计年度"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md082: [{ required: true, message: "上一会计年度"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    md084: [{ required: true, message: "上期标准价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md087: [{ required: true, message: "当前计划价格"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md088: [{ required: true, message: "总SP值"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md094: [{ required: true, message: "评价毛利"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md095: [{ required: true, message: "当前计划价格的固定金额"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md096: [{ required: true, message: "上年计划价格的固定比例"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md097: [{ required: true, message: "未来计划价格的固定比例"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    md107: [{ required: true, message: "价格单位"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 评估范围 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 评估类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_val_type: [],
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
    md002: null,
    md003: null,
    md004: [],
    md005: [],
    md006: null,
    md007: 0,
    md008: 0,
    md009: null,
    md010: 0,
    md011: 0,
    md012: 0,
    md013: null,
    md014: 0,
    md015: 0,
    md016: 0,
    md017: null,
    md018: 0,
    md019: 0,
    md020: 0,
    md021: null,
    md022: 0,
    md023: 0,
    md024: 0,
    md025: null,
    md026: 0,
    md027: 0,
    md028: 0,
    md029: null,
    md030: 0,
    md031: 0,
    md032: 0,
    md033: null,
    md034: 0,
    md035: null,
    md036: 0,
    md037: null,
    md038: 0,
    md039: 0,
    md040: 0,
    md041: 0,
    md042: 0,
    md043: 0,
    md044: 0,
    md045: 0,
    md046: 0,
    md047: 0,
    md048: 0,
    md049: 0,
    md050: 0,
    md051: null,
    md052: null,
    md053: null,
    md054: null,
    md055: null,
    md056: null,
    md057: null,
    md058: null,
    md059: null,
    md060: null,
    md061: null,
    md062: null,
    md063: 0,
    md064: 0,
    md065: 0,
    md066: null,
    md067: 0,
    md068: 0,
    md069: null,
    md070: null,
    md071: null,
    md072: 0,
    md073: 0,
    md074: 0,
    md075: null,
    md076: null,
    md077: 0,
    md078: 0,
    md079: 0,
    md080: 0,
    md081: 0,
    md082: 0,
    md083: null,
    md084: 0,
    md085: null,
    md086: null,
    md087: 0,
    md088: 0,
    md089: null,
    md090: null,
    md091: null,
    md092: null,
    md093: null,
    md094: 0,
    md095: 0,
    md096: 0,
    md097: 0,
    md098: null,
    md099: null,
    md100: null,
    md101: null,
    md102: null,
    md103: null,
    md104: null,
    md105: null,
    md106: null,
    md107: 0,
    md108: null,
    md109: null,
    md110: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'物料评估'
  opertype.value = 1
  form.value.md004= []
  form.value.md005= []
  form.value.md007= 0
  form.value.md008= 0
  form.value.md010= 0
  form.value.md011= 0
  form.value.md012= 0
  form.value.md014= 0
  form.value.md015= 0
  form.value.md016= 0
  form.value.md018= 0
  form.value.md019= 0
  form.value.md020= 0
  form.value.md022= 0
  form.value.md023= 0
  form.value.md024= 0
  form.value.md026= 0
  form.value.md027= 0
  form.value.md028= 0
  form.value.md030= 0
  form.value.md031= 0
  form.value.md032= 0
  form.value.md034= 0
  form.value.md035= new Date()
  form.value.md036= 0
  form.value.md037= new Date()
  form.value.md038= 0
  form.value.md039= 0
  form.value.md040= 0
  form.value.md041= 0
  form.value.md042= 0
  form.value.md043= 0
  form.value.md044= 0
  form.value.md045= 0
  form.value.md046= 0
  form.value.md047= 0
  form.value.md048= 0
  form.value.md049= 0
  form.value.md050= 0
  form.value.md051= new Date()
  form.value.md052= new Date()
  form.value.md053= new Date()
  form.value.md054= new Date()
  form.value.md055= new Date()
  form.value.md056= new Date()
  form.value.md063= 0
  form.value.md064= 0
  form.value.md065= 0
  form.value.md067= 0
  form.value.md068= 0
  form.value.md072= 0
  form.value.md073= 0
  form.value.md074= 0
  form.value.md077= 0
  form.value.md078= 0
  form.value.md079= 0
  form.value.md080= 0
  form.value.md081= 0
  form.value.md082= 0
  form.value.md084= 0
  form.value.md087= 0
  form.value.md088= 0
  form.value.md092= new Date()
  form.value.md094= 0
  form.value.md095= 0
  form.value.md096= 0
  form.value.md097= 0
  form.value.md107= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
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

      if (form.value.id != undefined && opertype.value === 2) {
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
  const Ids = row.id || ids.value

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