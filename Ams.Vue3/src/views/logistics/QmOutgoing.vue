<!--
 * @Descripttion: 出货检验/qm_outgoing
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/19 9:46:39
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="生产工单" prop="qmoutProOrder">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_oph_moc" :loading="loading " v-model="queryParams.qmoutProOrder" :placeholder="$t('btn.selectSearchPrefix')+'生产工单'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_oph_moc " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="班组" prop="qmoutProLine">
        <el-input v-model="queryParams.qmoutProLine" :placeholder="$t('btn.enterSearchPrefix')+'班组'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="qmoutProModels">
        <el-input v-model="queryParams.qmoutProModels" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="qmoutProMaterial">
        <el-input v-model="queryParams.qmoutProMaterial" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="批次" prop="qmoutProLot">
        <el-input v-model="queryParams.qmoutProLot" :placeholder="$t('btn.enterSearchPrefix')+'批次'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="序号" prop="qmoutProSerial">
        <el-input v-model="queryParams.qmoutProSerial" :placeholder="$t('btn.enterSearchPrefix')+'序号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="生产日期">
        <el-date-picker
          v-model="dateRangeQmoutProDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="检查员" prop="qmoutInspector">
        <el-select filterable clearable   v-model="queryParams.qmoutInspector" :placeholder="$t('btn.selectSearchPrefix')+'检查员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_ec_group " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="查验日期">
        <el-date-picker
          v-model="dateRangeQmoutCheckDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="检查项目" prop="qmoutInspectingItem">
        <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip  v-model="queryParams.qmoutInspectingItem" :placeholder="$t('btn.selectSearchPrefix')+'检查项目'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验水准" prop="qmoutSamplingLevel">
        <el-select filterable clearable   v-model="queryParams.qmoutSamplingLevel" :placeholder="$t('btn.selectSearchPrefix')+'检验水准'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_level " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验方式" prop="qmoutCheckMethod">
        <el-select filterable clearable   v-model="queryParams.qmoutCheckMethod" :placeholder="$t('btn.selectSearchPrefix')+'检验方式'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_method " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="判定" prop="qmoutJudgment">
        <el-select filterable clearable   v-model="queryParams.qmoutJudgment" :placeholder="$t('btn.selectSearchPrefix')+'判定'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_judge " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="不良级别" prop="qmoutJudgmentLevel">
        <el-select filterable clearable   v-model="queryParams.qmoutJudgmentLevel" :placeholder="$t('btn.selectSearchPrefix')+'不良级别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_insp_bad " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检查号码" prop="qmoutCheckNotes">
        <el-input v-model="queryParams.qmoutCheckNotes" :placeholder="$t('btn.enterSearchPrefix')+'检查号码'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['qm:outgoing:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:outgoing:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:outgoing:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:outgoing:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmOutgoing/importTemplate"
                  importUrl="/Logistics/QmOutgoing/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:outgoing:export']">
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
      <el-table-column prop="qmoutSFID" label="QmoutSFID" align="center" v-if="columns.showColumn('qmoutSFID')"/>
      <el-table-column prop="qmoutProOrder" label="生产工单" align="center" v-if="columns.showColumn('qmoutProOrder')">
        <template #default="scope">
          <dict-tag :options=" options.sql_oph_moc " :value="scope.row.qmoutProOrder"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmoutProLine" label="班组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmoutProLine')"/>
      <el-table-column prop="qmoutProModels" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmoutProModels')"/>
      <el-table-column prop="qmoutProMaterial" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmoutProMaterial')"/>
      <el-table-column prop="qmoutProLot" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmoutProLot')"/>
      <el-table-column prop="qmoutProSerial" label="序号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmoutProSerial')"/>
      <el-table-column prop="qmoutProQty" label="送检数量" align="center" v-if="columns.showColumn('qmoutProQty')"/>
      <el-table-column prop="qmoutProDate" label="生产日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qmoutProDate')"/>
      <el-table-column prop="qmoutInspector" label="检查员" align="center" v-if="columns.showColumn('qmoutInspector')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ec_group " :value="scope.row.qmoutInspector"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmoutCheckDate" label="查验日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qmoutCheckDate')"/>
      <el-table-column prop="qmoutInspectingItem" label="检查项目" align="center" v-if="columns.showColumn('qmoutInspectingItem')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_type " :value="scope.row.qmoutInspectingItem" split="," />
        </template>
      </el-table-column>
      <el-table-column prop="qmoutSamplingLevel" label="检验水准" align="center" v-if="columns.showColumn('qmoutSamplingLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_level " :value="scope.row.qmoutSamplingLevel"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmoutCheckMethod" label="检验方式" align="center" v-if="columns.showColumn('qmoutCheckMethod')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_method " :value="scope.row.qmoutCheckMethod"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmoutSamplingQty" label="抽样数" align="center" v-if="columns.showColumn('qmoutSamplingQty')"/>
      <el-table-column prop="qmoutJudgment" label="判定" align="center" v-if="columns.showColumn('qmoutJudgment')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_judge " :value="scope.row.qmoutJudgment"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmoutJudgmentLevel" label="不良级别" align="center" v-if="columns.showColumn('qmoutJudgmentLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_bad " :value="scope.row.qmoutJudgmentLevel"  />
        </template>
      </el-table-column>
      <el-table-column prop="qmoutRejectQty" label="验退数" align="center" v-if="columns.showColumn('qmoutRejectQty')"/>
      <el-table-column prop="qmoutCheckNotes" label="检查号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmoutCheckNotes')"/>
      <el-table-column prop="qmoutSpecialNotes" label="特记事项" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qmoutSpecialNotes')"/>
      <el-table-column prop="qmoutAcceptQty" label="验收数量" align="center" v-if="columns.showColumn('qmoutAcceptQty')"/>
      <el-table-column prop="qmoutOrderQty" label="订单数量" align="center" v-if="columns.showColumn('qmoutOrderQty')"/>
      <el-table-column prop="qmoutCheckoutSequence" label="检验次数" align="center" v-if="columns.showColumn('qmoutCheckoutSequence')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:outgoing:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:outgoing:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改出货检验对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="QmoutSFID" prop="qmoutSFID">
              <el-input v-model.number="form.qmoutSFID" :placeholder="$t('btn.enterPrefix')+'QmoutSFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产工单" prop="qmoutProOrder">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_oph_moc" 
              :loading="loading " v-model="form.qmoutProOrder"  :placeholder="$t('btn.selectPrefix')+'生产工单'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_oph_moc" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="班组" prop="qmoutProLine">
              <el-input v-model="form.qmoutProLine" :placeholder="$t('btn.enterPrefix')+'班组'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="qmoutProModels">
              <el-input v-model="form.qmoutProModels" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="qmoutProMaterial">
              <el-input v-model="form.qmoutProMaterial" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="qmoutProLot">
              <el-input v-model="form.qmoutProLot" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序号" prop="qmoutProSerial">
              <el-input v-model="form.qmoutProSerial" :placeholder="$t('btn.enterPrefix')+'序号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="送检数量" prop="qmoutProQty">
              <el-input-number v-model.number="form.qmoutProQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'送检数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产日期" prop="qmoutProDate">
              <el-date-picker v-model="form.qmoutProDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查员" prop="qmoutInspector">
              <el-select filterable clearable   v-model="form.qmoutInspector"  :placeholder="$t('btn.selectPrefix')+'检查员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_ec_group" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="查验日期" prop="qmoutCheckDate">
              <el-date-picker v-model="form.qmoutCheckDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查项目" prop="qmoutInspectingItem">
              <el-select filterable clearable multiple collapse-tags collapse-tags-tooltip  v-model="form.qmoutInspectingItemChecked"  :placeholder="$t('btn.selectPrefix')+'检查项目'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验水准" prop="qmoutSamplingLevel">
              <el-select filterable clearable   v-model="form.qmoutSamplingLevel"  :placeholder="$t('btn.selectPrefix')+'检验水准'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_level" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验方式" prop="qmoutCheckMethod">
              <el-select filterable clearable   v-model="form.qmoutCheckMethod"  :placeholder="$t('btn.selectPrefix')+'检验方式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_method" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="抽样数" prop="qmoutSamplingQty">
              <el-input-number v-model.number="form.qmoutSamplingQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'抽样数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="判定" prop="qmoutJudgment">
              <el-select filterable clearable   v-model="form.qmoutJudgment"  :placeholder="$t('btn.selectPrefix')+'判定'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_judge" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="不良级别" prop="qmoutJudgmentLevel">
              <el-select filterable clearable   v-model="form.qmoutJudgmentLevel"  :placeholder="$t('btn.selectPrefix')+'不良级别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_bad" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="验退数" prop="qmoutRejectQty">
              <el-input-number v-model.number="form.qmoutRejectQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验退数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检查号码" prop="qmoutCheckNotes">
              <el-input v-model="form.qmoutCheckNotes" :placeholder="$t('btn.enterPrefix')+'检查号码'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记事项" prop="qmoutSpecialNotes">
              <el-input type="textarea" v-model="form.qmoutSpecialNotes" :placeholder="$t('btn.enterPrefix')+'特记事项'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="验收数量" prop="qmoutAcceptQty">
              <el-input-number v-model.number="form.qmoutAcceptQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验收数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单数量" prop="qmoutOrderQty">
              <el-input-number v-model.number="form.qmoutOrderQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'订单数量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检验次数" prop="qmoutCheckoutSequence">
              <el-input-number v-model.number="form.qmoutCheckoutSequence" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检验次数'+$t('btn.enterSuffix')" />
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

<script setup name="qmoutgoing">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmOutgoing,
 addQmOutgoing, delQmOutgoing, 
 updateQmOutgoing,getQmOutgoing, 
 } 
from '@/api/logistics/qmoutgoing.js'
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
  qmoutProOrder: undefined,
//是否查询（1是）
  qmoutProLine: undefined,
//是否查询（1是）
  qmoutProModels: undefined,
//是否查询（1是）
  qmoutProMaterial: undefined,
//是否查询（1是）
  qmoutProLot: undefined,
//是否查询（1是）
  qmoutProSerial: undefined,
//是否查询（1是）
  qmoutProDate: undefined,
//是否查询（1是）
  qmoutInspector: undefined,
//是否查询（1是）
  qmoutCheckDate: undefined,
//是否查询（1是）
  qmoutInspectingItem: undefined,
//是否查询（1是）
  qmoutSamplingLevel: undefined,
//是否查询（1是）
  qmoutCheckMethod: undefined,
//是否查询（1是）
  qmoutJudgment: undefined,
//是否查询（1是）
  qmoutJudgmentLevel: undefined,
//是否查询（1是）
  qmoutCheckNotes: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qmoutSFID', label: 'QmoutSFID' },
  { visible: true, prop: 'qmoutProOrder', label: '生产工单' },
  { visible: true, prop: 'qmoutProLine', label: '班组' },
  { visible: true, prop: 'qmoutProModels', label: '机种' },
  { visible: true, prop: 'qmoutProMaterial', label: '物料' },
  { visible: true, prop: 'qmoutProLot', label: '批次' },
  { visible: true, prop: 'qmoutProSerial', label: '序号' },
  { visible: true, prop: 'qmoutProQty', label: '送检数量' },
  { visible: false, prop: 'qmoutProDate', label: '生产日期' },
  { visible: false, prop: 'qmoutInspector', label: '检查员' },
  { visible: false, prop: 'qmoutCheckDate', label: '查验日期' },
  { visible: false, prop: 'qmoutInspectingItem', label: '检查项目' },
  { visible: false, prop: 'qmoutSamplingLevel', label: '检验水准' },
  { visible: false, prop: 'qmoutCheckMethod', label: '检验方式' },
  { visible: false, prop: 'qmoutSamplingQty', label: '抽样数' },
  { visible: false, prop: 'qmoutJudgment', label: '判定' },
  { visible: false, prop: 'qmoutJudgmentLevel', label: '不良级别' },
  { visible: false, prop: 'qmoutRejectQty', label: '验退数' },
  { visible: false, prop: 'qmoutCheckNotes', label: '检查号码' },
  { visible: false, prop: 'qmoutSpecialNotes', label: '特记事项' },
  { visible: false, prop: 'qmoutAcceptQty', label: '验收数量' },
  { visible: false, prop: 'qmoutOrderQty', label: '订单数量' },
  { visible: false, prop: 'qmoutCheckoutSequence', label: '检验次数' },
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
//定义远程搜索变量
const remotequeryList_sql_oph_moc=ref([])
//定义远程搜索变量
const remotequery_sql_oph_moc=ref([])
//远程字典参数
var remotedictParams_sql_oph_moc = [
    { dictType: "sql_oph_moc" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_oph_moc).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_oph_moc.value = element.list
      })
      //console.log(remotequeryList_sql_oph_moc)
    })
  })
//远程搜索
const remoteMethod_sql_oph_moc = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_oph_moc.value = remotequeryList_sql_oph_moc.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_oph_moc(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_oph_moc.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_oph_moc = debounce((query) => {
    let arr = remotequeryList_sql_oph_moc.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_oph_moc.value = arr.slice(0, 5)
      addFilterOptions_sql_oph_moc(query)
    } else {
      remotequery_sql_oph_moc.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_oph_moc =debounce((dictValue) => {
    let target = remotequeryList_sql_oph_moc.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_oph_moc.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_oph_moc.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
// 生产日期时间范围
const dateRangeQmoutProDate = ref([])
// 查验日期时间范围
const dateRangeQmoutCheckDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_ec_group" },
  { dictType: "sys_insp_type" },
  { dictType: "sys_insp_level" },
  { dictType: "sys_insp_method" },
  { dictType: "sys_insp_judge" },
  { dictType: "sys_insp_bad" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从出货检验/qm_outgoing表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQmoutProDate.value, 'QmoutProDate');
  proxy.addDateRange(queryParams, dateRangeQmoutCheckDate.value, 'QmoutCheckDate');
  loading.value = true
  listQmOutgoing(queryParams).then(res => {
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
  // 生产日期时间范围
  dateRangeQmoutProDate.value = []
  // 查验日期时间范围
  dateRangeQmoutCheckDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qmoutSFID);
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
    qmoutSFID: [{ required: true, message: "QmoutSFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    qmoutProOrder: [{ required: true, message: "生产工单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutProLine: [{ required: true, message: "班组"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutProMaterial: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutProLot: [{ required: true, message: "批次"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutProSerial: [{ required: true, message: "序号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutProQty: [{ required: true, message: "送检数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutProDate: [{ required: true, message: "生产日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutInspector: [{ required: true, message: "检查员"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qmoutCheckDate: [{ required: true, message: "查验日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutInspectingItem: [{ required: true, message: "检查项目"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutSamplingLevel: [{ required: true, message: "检验水准"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qmoutCheckMethod: [{ required: true, message: "检验方式"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qmoutSamplingQty: [{ required: true, message: "抽样数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutJudgment: [{ required: true, message: "判定"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qmoutJudgmentLevel: [{ required: true, message: "不良级别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    qmoutRejectQty: [{ required: true, message: "验退数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutCheckNotes: [{ required: true, message: "检查号码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutAcceptQty: [{ required: true, message: "验收数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutOrderQty: [{ required: true, message: "订单数量"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qmoutCheckoutSequence: [{ required: true, message: "检验次数"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
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
sql_ec_group: [],
    // 检查项目 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_type: [],
    // 检验水准 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_level: [],
    // 检验方式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_method: [],
    // 判定 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_judge: [],
    // 不良级别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_bad: [],
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
    qmoutSFID: 0,
    qmoutProOrderChecked: [],
    qmoutProLine: null,
    qmoutProModels: null,
    qmoutProMaterial: null,
    qmoutProLot: null,
    qmoutProSerial: null,
    qmoutProQty: 0,
    qmoutProDate: null,
    qmoutInspector: null,
    qmoutCheckDate: null,
    qmoutInspectingItemChecked: [],
    qmoutSamplingLevel: null,
    qmoutCheckMethod: null,
    qmoutSamplingQty: 0,
    qmoutJudgment: null,
    qmoutJudgmentLevel: null,
    qmoutRejectQty: 0,
    qmoutCheckNotes: null,
    qmoutSpecialNotes: null,
    qmoutAcceptQty: 0,
    qmoutOrderQty: 0,
    qmoutCheckoutSequence: 0,
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
  title.value = proxy.$t('btn.add')+" "+'出货检验'
  opertype.value = 1
  form.value.qmoutProQty= 0
  form.value.qmoutProDate= new Date()
  form.value.qmoutInspector= []
  form.value.qmoutCheckDate= new Date()
  form.value.qmoutSamplingLevel= []
  form.value.qmoutCheckMethod= []
  form.value.qmoutSamplingQty= 0
  form.value.qmoutJudgment= []
  form.value.qmoutJudgmentLevel= []
  form.value.qmoutRejectQty= 0
  form.value.qmoutAcceptQty= 0
  form.value.qmoutOrderQty= 0
  form.value.qmoutCheckoutSequence= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qmoutSFID || ids.value
  getQmOutgoing(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '出货检验'
      opertype.value = 2

      form.value = {
        ...data,
        qmoutInspectingItemChecked: data.qmoutInspectingItem ? data.qmoutInspectingItem.split(',') : [],
      }
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {
      form.value.qmoutInspectingItem = form.value.qmoutInspectingItemChecked.toString();

      if (form.value.qmoutSFID != undefined && opertype.value === 2) {
        updateQmOutgoing(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmOutgoing(form.value).then((res) => {
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
  const Ids = row.qmoutSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delQmOutgoing(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<出货检验.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmOutgoing/export', { ...queryParams })
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