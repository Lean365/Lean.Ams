<!--
 * @Descripttion: 分析对策/qm_improvement_replyletter
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/19 15:07:55
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="检查员" prop="qirdInspector">
        <el-select filterable clearable   v-model="queryParams.qirdInspector" :placeholder="$t('btn.selectSearchPrefix')+'检查员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_inspector_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="班组" prop="qirdLine">
        <el-input v-model="queryParams.qirdLine" :placeholder="$t('btn.enterSearchPrefix')+'班组'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="订单" prop="qirdOrder">
        <el-input v-model="queryParams.qirdOrder" :placeholder="$t('btn.enterSearchPrefix')+'订单'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="qirdModels">
        <el-input v-model="queryParams.qirdModels" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="qirdMaterial">
        <el-input v-model="queryParams.qirdMaterial" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="仕向" prop="qirdRegion">
        <el-input v-model="queryParams.qirdRegion" :placeholder="$t('btn.enterSearchPrefix')+'仕向'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="检验日期">
        <el-date-picker
          v-model="dateRangeQirdCheckDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="批次" prop="qirdProLot">
        <el-input v-model="queryParams.qirdProLot" :placeholder="$t('btn.enterSearchPrefix')+'批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="不良级别" prop="qirdJudgmentLevel">
        <el-select filterable clearable   v-model="queryParams.qirdJudgmentLevel" :placeholder="$t('btn.selectSearchPrefix')+'不良级别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_bad " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="不良内容" prop="qirdCheckNotes">
        <el-input v-model="queryParams.qirdCheckNotes" :placeholder="$t('btn.enterSearchPrefix')+'不良内容'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="对策人员" prop="qirdPersonnel">
        <el-select filterable clearable   v-model="queryParams.qirdPersonnel" :placeholder="$t('btn.selectSearchPrefix')+'对策人员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_inspector_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="对应日期">
        <el-date-picker
          v-model="dateRangeQirdDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="检证人员" prop="qirdVerify">
        <el-select filterable clearable   v-model="queryParams.qirdVerify" :placeholder="$t('btn.selectSearchPrefix')+'检证人员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_inspector_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="实施日期">
        <el-date-picker
          v-model="dateRangeQirdCarryoutdate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="实施查证" prop="qirdCarryoutverify">
        <el-select filterable clearable   v-model="queryParams.qirdCarryoutverify" :placeholder="$t('btn.selectSearchPrefix')+'实施查证'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_normal_whether " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['qm:improvementreplyletter:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:improvementreplyletter:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:improvementreplyletter:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:improvementreplyletter:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmImprovementReplyletter/importTemplate"
                  importUrl="/Logistics/QmImprovementReplyletter/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:improvementreplyletter:export']">
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
      <el-table-column prop="qirdSFID" label="SFID" align="center" v-if="columns.showColumn('qirdSFID')"/>
      <el-table-column prop="qirdInspector" label="检查员" align="center" v-if="columns.showColumn('qirdInspector')">
        <template #default="scope">
          <dict-tag :options=" options.sql_inspector_list " :value="scope.row.qirdInspector"  />
        </template>
      </el-table-column>
      <el-table-column prop="qirdLine" label="班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdLine')"/>
      <el-table-column prop="qirdOrder" label="订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdOrder')"/>
      <el-table-column prop="qirdModels" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdModels')"/>
      <el-table-column prop="qirdMaterial" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdMaterial')"/>
      <el-table-column prop="qirdRegion" label="仕向" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdRegion')"/>
      <el-table-column prop="qirdCheckDate" label="检验日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qirdCheckDate')"/>
      <el-table-column prop="qirdProLot" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdProLot')"/>
      <el-table-column prop="qirdProSerial" label="序号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdProSerial')"/>
      <el-table-column prop="qirdRejectQty" label="验退数" align="center" v-if="columns.showColumn('qirdRejectQty')"/>
      <el-table-column prop="qirdJudgmentLevel" label="不良级别" align="center" v-if="columns.showColumn('qirdJudgmentLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_bad " :value="scope.row.qirdJudgmentLevel"  />
        </template>
      </el-table-column>
      <el-table-column prop="qirdCheckNotes" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdCheckNotes')"/>
      <el-table-column prop="qirdPersonnel" label="对策人员" align="center" v-if="columns.showColumn('qirdPersonnel')">
        <template #default="scope">
          <dict-tag :options=" options.sql_inspector_list " :value="scope.row.qirdPersonnel"  />
        </template>
      </el-table-column>
      <el-table-column prop="qirdDate" label="对应日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qirdDate')"/>
      <el-table-column prop="qirdDirectreason" label="直接原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdDirectreason')"/>
      <el-table-column prop="qirdIndirectreason" label="间接原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdIndirectreason')"/>
      <el-table-column prop="qirdDisposal" label="处置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdDisposal')"/>
      <el-table-column prop="qirdDirectsolutions" label="直接对策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdDirectsolutions')"/>
      <el-table-column prop="qirdIndirectsolutions" label="间接对策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdIndirectsolutions')"/>
      <el-table-column prop="qirdVerify" label="检证人员" align="center" v-if="columns.showColumn('qirdVerify')">
        <template #default="scope">
          <dict-tag :options=" options.sql_inspector_list " :value="scope.row.qirdVerify"  />
        </template>
      </el-table-column>
      <el-table-column prop="qirdCarryoutdate" label="实施日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qirdCarryoutdate')"/>
      <el-table-column prop="qirdCarryoutverify" label="实施查证" align="center" v-if="columns.showColumn('qirdCarryoutverify')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.qirdCarryoutverify"  />
        </template>
      </el-table-column>
      <el-table-column prop="qirdSolutionsverify" label="对策实施查证" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdSolutionsverify')"/>
      <el-table-column prop="qirdNotes" label="特记事项" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdNotes')"/>
      <el-table-column prop="qirdIssueno" label="发行号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qirdIssueno')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column prop="qirdFileUrl" label="附件" align="center" v-if="columns.showColumn('qirdFileUrl')">
        <template #default="scope">
          <ImagePreview :src="scope.row.qirdFileUrl"></ImagePreview>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:improvementreplyletter:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:improvementreplyletter:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改分析对策对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="qirdSFID">
              <el-input v-model.number="form.qirdSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查员" prop="qirdInspector">
              <el-select filterable clearable   v-model="form.qirdInspector"  :placeholder="$t('btn.selectPrefix')+'检查员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_inspector_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="班组" prop="qirdLine">
              <el-input v-model="form.qirdLine" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单" prop="qirdOrder">
              <el-input v-model="form.qirdOrder" :placeholder="$t('btn.enterPrefix')+'订单'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="qirdModels">
              <el-input v-model="form.qirdModels" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="qirdMaterial">
              <el-input v-model="form.qirdMaterial" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仕向" prop="qirdRegion">
              <el-input v-model="form.qirdRegion" :placeholder="$t('btn.enterPrefix')+'仕向'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验日期" prop="qirdCheckDate">
              <el-date-picker v-model="form.qirdCheckDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="qirdProLot">
              <el-input v-model="form.qirdProLot" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="序号" prop="qirdProSerial">
              <el-input type="textarea" v-model="form.qirdProSerial" :placeholder="$t('btn.enterPrefix')+'序号'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="验退数" prop="qirdRejectQty">
              <el-input-number v-model.number="form.qirdRejectQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验退数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良级别" prop="qirdJudgmentLevel">
              <el-select filterable clearable   v-model="form.qirdJudgmentLevel"  :placeholder="$t('btn.selectPrefix')+'不良级别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_bad" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="不良内容" prop="qirdCheckNotes">
              <el-input type="textarea" v-model="form.qirdCheckNotes" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="对策人员" prop="qirdPersonnel">
              <el-select filterable clearable   v-model="form.qirdPersonnel"  :placeholder="$t('btn.selectPrefix')+'对策人员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_inspector_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="对应日期" prop="qirdDate">
              <el-date-picker v-model="form.qirdDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="直接原因" prop="qirdDirectreason">
              <el-input v-model="form.qirdDirectreason" :placeholder="$t('btn.enterPrefix')+'直接原因'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接原因" prop="qirdIndirectreason">
              <el-input v-model="form.qirdIndirectreason" :placeholder="$t('btn.enterPrefix')+'间接原因'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处置" prop="qirdDisposal">
              <el-input v-model="form.qirdDisposal" :placeholder="$t('btn.enterPrefix')+'处置'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="直接对策" prop="qirdDirectsolutions">
              <el-input v-model="form.qirdDirectsolutions" :placeholder="$t('btn.enterPrefix')+'直接对策'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接对策" prop="qirdIndirectsolutions">
              <el-input v-model="form.qirdIndirectsolutions" :placeholder="$t('btn.enterPrefix')+'间接对策'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检证人员" prop="qirdVerify">
              <el-select filterable clearable   v-model="form.qirdVerify"  :placeholder="$t('btn.selectPrefix')+'检证人员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_inspector_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="实施日期" prop="qirdCarryoutdate">
              <el-date-picker v-model="form.qirdCarryoutdate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实施查证" prop="qirdCarryoutverify">
              <el-select filterable clearable   v-model="form.qirdCarryoutverify"  :placeholder="$t('btn.selectPrefix')+'实施查证'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_normal_whether" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="对策实施查证" prop="qirdSolutionsverify">
              <el-input v-model="form.qirdSolutionsverify" :placeholder="$t('btn.enterPrefix')+'对策实施查证'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="特记事项" prop="qirdNotes">
              <el-input v-model="form.qirdNotes" :placeholder="$t('btn.enterPrefix')+'特记事项'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行号码" prop="qirdIssueno">
              <el-input v-model="form.qirdIssueno" :placeholder="$t('btn.enterPrefix')+'发行号码'+$t('btn.enterSuffix')" />
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

          <el-col :lg="24">
            <el-form-item label="附件" prop="qirdFileUrl">
              <UploadImage v-model="form.qirdFileUrl" :data="{ uploadType: 1 }" />
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

<script setup name="qmimprovementreplyletter">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmImprovementReplyletter,
 addQmImprovementReplyletter, delQmImprovementReplyletter, 
 updateQmImprovementReplyletter,getQmImprovementReplyletter, 
 } 
from '@/api/logistics/qmimprovementreplyletter.js'
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
  qirdInspector: undefined,
//是否查询（1是）
  qirdLine: undefined,
//是否查询（1是）
  qirdOrder: undefined,
//是否查询（1是）
  qirdModels: undefined,
//是否查询（1是）
  qirdMaterial: undefined,
//是否查询（1是）
  qirdRegion: undefined,
//是否查询（1是）
  qirdCheckDate: undefined,
//是否查询（1是）
  qirdProLot: undefined,
//是否查询（1是）
  qirdJudgmentLevel: undefined,
//是否查询（1是）
  qirdCheckNotes: undefined,
//是否查询（1是）
  qirdPersonnel: undefined,
//是否查询（1是）
  qirdDate: undefined,
//是否查询（1是）
  qirdVerify: undefined,
//是否查询（1是）
  qirdCarryoutdate: undefined,
//是否查询（1是）
  qirdCarryoutverify: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qirdSFID', label: 'SFID' },
  { visible: true, prop: 'qirdInspector', label: '检查员' },
  { visible: true, prop: 'qirdLine', label: '班组' },
  { visible: true, prop: 'qirdOrder', label: '订单' },
  { visible: true, prop: 'qirdModels', label: '机种' },
  { visible: true, prop: 'qirdMaterial', label: '物料' },
  { visible: true, prop: 'qirdRegion', label: '仕向' },
  { visible: true, prop: 'qirdCheckDate', label: '检验日期' },
  { visible: false, prop: 'qirdProLot', label: '批次' },
  { visible: false, prop: 'qirdProSerial', label: '序号' },
  { visible: false, prop: 'qirdRejectQty', label: '验退数' },
  { visible: false, prop: 'qirdJudgmentLevel', label: '不良级别' },
  { visible: false, prop: 'qirdCheckNotes', label: '不良内容' },
  { visible: false, prop: 'qirdPersonnel', label: '对策人员' },
  { visible: false, prop: 'qirdDate', label: '对应日期' },
  { visible: false, prop: 'qirdDirectreason', label: '直接原因' },
  { visible: false, prop: 'qirdIndirectreason', label: '间接原因' },
  { visible: false, prop: 'qirdDisposal', label: '处置' },
  { visible: false, prop: 'qirdDirectsolutions', label: '直接对策' },
  { visible: false, prop: 'qirdIndirectsolutions', label: '间接对策' },
  { visible: false, prop: 'qirdVerify', label: '检证人员' },
  { visible: false, prop: 'qirdCarryoutdate', label: '实施日期' },
  { visible: false, prop: 'qirdCarryoutverify', label: '实施查证' },
  { visible: false, prop: 'qirdSolutionsverify', label: '对策实施查证' },
  { visible: false, prop: 'qirdNotes', label: '特记事项' },
  { visible: false, prop: 'qirdIssueno', label: '发行号码' },
  { visible: false, prop: 'remark', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
  { visible: false, prop: 'updateBy', label: '更新者' },
  { visible: false, prop: 'updateTime', label: '更新时间' },
  { visible: false, prop: 'qirdFileUrl', label: '附件' },
])
// 记录数
const total = ref(0)
//定义数据变量
const dataList = ref([])
//查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])
// 检验日期时间范围
const dateRangeQirdCheckDate = ref([])
// 对应日期时间范围
const dateRangeQirdDate = ref([])
// 实施日期时间范围
const dateRangeQirdCarryoutdate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_inspector_list" },
  { dictType: "sys_insp_bad" },
  { dictType: "sys_normal_whether" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从分析对策/qm_improvement_replyletter表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQirdCheckDate.value, 'QirdCheckDate');
  proxy.addDateRange(queryParams, dateRangeQirdDate.value, 'QirdDate');
  proxy.addDateRange(queryParams, dateRangeQirdCarryoutdate.value, 'QirdCarryoutdate');
  loading.value = true
  listQmImprovementReplyletter(queryParams).then(res => {
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
  // 检验日期时间范围
  dateRangeQirdCheckDate.value = []
  // 对应日期时间范围
  dateRangeQirdDate.value = []
  // 实施日期时间范围
  dateRangeQirdCarryoutdate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qirdSFID);
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
    qirdSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    qirdInspector: [{ required: true, message: "检查员"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qirdLine: [{ required: true, message: "班组"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qirdOrder: [{ required: true, message: "订单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qirdMaterial: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qirdCheckDate: [{ required: true, message: "检验日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qirdRejectQty: [{ required: true, message: "验退数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qirdJudgmentLevel: [{ required: true, message: "不良级别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qirdCheckNotes: [{ required: true, message: "不良内容"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qirdPersonnel: [{ required: true, message: "对策人员"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qirdVerify: [{ required: true, message: "检证人员"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qirdCarryoutverify: [{ required: true, message: "实施查证"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 检查员 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_inspector_list: [],
    // 不良级别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_bad: [],
    // 实施查证 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_normal_whether: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
isDeletedOptions: [],
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
    qirdSFID: 0,
    qirdInspector: null,
    qirdLine: null,
    qirdOrder: null,
    qirdModels: null,
    qirdMaterial: null,
    qirdRegion: null,
    qirdCheckDate: null,
    qirdProLot: null,
    qirdProSerial: null,
    qirdRejectQty: 0,
    qirdJudgmentLevel: null,
    qirdCheckNotes: null,
    qirdPersonnel: null,
    qirdDate: null,
    qirdDirectreason: null,
    qirdIndirectreason: null,
    qirdDisposal: null,
    qirdDirectsolutions: null,
    qirdIndirectsolutions: null,
    qirdVerify: null,
    qirdCarryoutdate: null,
    qirdCarryoutverify: 0,
    qirdSolutionsverify: null,
    qirdNotes: null,
    qirdIssueno: null,
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
    qirdFileUrl: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'分析对策'
  opertype.value = 1
  form.value.qirdInspector= []
  form.value.qirdCheckDate= new Date()
  form.value.qirdRejectQty= 0
  form.value.qirdJudgmentLevel= []
  form.value.qirdPersonnel= []
  form.value.qirdDate= new Date()
  form.value.qirdVerify= []
  form.value.qirdCarryoutdate= new Date()
  form.value.qirdCarryoutverify= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qirdSFID || ids.value
  getQmImprovementReplyletter(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '分析对策'
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

      if (form.value.qirdSFID != undefined && opertype.value === 2) {
        updateQmImprovementReplyletter(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmImprovementReplyletter(form.value).then((res) => {
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
  const Ids = row.qirdSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delQmImprovementReplyletter(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<分析对策.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmImprovementReplyletter/export', { ...queryParams })
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