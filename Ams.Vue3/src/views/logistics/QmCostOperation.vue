<!--
 * @Descripttion: 品质业务/qm_cost_operation
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/19 15:11:02
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="日期">
        <el-date-picker
          v-model="dateRangeQcod001" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
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
        <el-button class="btn-add" v-hasPermi="['qm:costoperation:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:costoperation:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:costoperation:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:costoperation:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmCostOperation/importTemplate"
                  importUrl="/Logistics/QmCostOperation/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:costoperation:export']">
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
      <el-table-column prop="qcodSFID" label="SFID" align="center" v-if="columns.showColumn('qcodSFID')"/>
      <el-table-column prop="qcod001" label="日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('qcod001')"/>
      <el-table-column prop="qcod002" label="间接赁率" align="center" v-if="columns.showColumn('qcod002')"/>
      <el-table-column prop="qcod003" label="IQC检查费用" align="center" v-if="columns.showColumn('qcod003')"/>
      <el-table-column prop="qcod004" label="检查时间" align="center" v-if="columns.showColumn('qcod004')"/>
      <el-table-column prop="qcod005" label="差旅费" align="center" v-if="columns.showColumn('qcod005')"/>
      <el-table-column prop="qcod006" label="其他费用" align="center" v-if="columns.showColumn('qcod006')"/>
      <el-table-column prop="qcod007" label="特记说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod007')"/>
      <el-table-column prop="qcod008" label="初期检定?定期检定业务费用" align="center" v-if="columns.showColumn('qcod008')"/>
      <el-table-column prop="qcod009" label="作业时间" align="center" v-if="columns.showColumn('qcod009')"/>
      <el-table-column prop="qcod010" label="其他费用" align="center" v-if="columns.showColumn('qcod010')"/>
      <el-table-column prop="qcod011" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod011')"/>
      <el-table-column prop="qcod012" label="测定器校正业务费用" align="center" v-if="columns.showColumn('qcod012')"/>
      <el-table-column prop="qcod013" label="校正时间" align="center" v-if="columns.showColumn('qcod013')"/>
      <el-table-column prop="qcod014" label="外部委托，搬运费" align="center" v-if="columns.showColumn('qcod014')"/>
      <el-table-column prop="qcod015" label="其他费用" align="center" v-if="columns.showColumn('qcod015')"/>
      <el-table-column prop="qcod016" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod016')"/>
      <el-table-column prop="qcod017" label="其他通常费用" align="center" v-if="columns.showColumn('qcod017')"/>
      <el-table-column prop="qcod018" label="通常作业时间" align="center" v-if="columns.showColumn('qcod018')"/>
      <el-table-column prop="qcod019" label="通常其他费用" align="center" v-if="columns.showColumn('qcod019')"/>
      <el-table-column prop="qcod020" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod020')"/>
      <el-table-column prop="qcodqcr" label="IQC品质问题対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcodqcr')"/>
      <el-table-column prop="qcod021" label="出货检查费用" align="center" v-if="columns.showColumn('qcod021')"/>
      <el-table-column prop="qcod022" label="检查时间" align="center" v-if="columns.showColumn('qcod022')"/>
      <el-table-column prop="qcod023" label="其他费用" align="center" v-if="columns.showColumn('qcod023')"/>
      <el-table-column prop="qcod024" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod024')"/>
      <el-table-column prop="qcod025" label="信赖性评价?ORT业务费用" align="center" v-if="columns.showColumn('qcod025')"/>
      <el-table-column prop="qcod026" label="评价时间" align="center" v-if="columns.showColumn('qcod026')"/>
      <el-table-column prop="qcod027" label="其他费用" align="center" v-if="columns.showColumn('qcod027')"/>
      <el-table-column prop="qcod028" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod028')"/>
      <el-table-column prop="qcod029" label="顾客品质要求对应业务费用" align="center" v-if="columns.showColumn('qcod029')"/>
      <el-table-column prop="qcod030" label="评价作业时间" align="center" v-if="columns.showColumn('qcod030')"/>
      <el-table-column prop="qcod031" label="评价其他费用" align="center" v-if="columns.showColumn('qcod031')"/>
      <el-table-column prop="qcod032" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod032')"/>
      <el-table-column prop="qcod033" label="其他通常业务费用" align="center" v-if="columns.showColumn('qcod033')"/>
      <el-table-column prop="qcod034" label="通常业务作业时间" align="center" v-if="columns.showColumn('qcod034')"/>
      <el-table-column prop="qcod035" label="通常业务其他费用" align="center" v-if="columns.showColumn('qcod035')"/>
      <el-table-column prop="qcod036" label="特记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcod036')"/>
      <el-table-column prop="qcodqar" label="QA品质问题対応记录者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('qcodqar')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:costoperation:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:costoperation:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改品质业务对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="qcodSFID">
              <el-input v-model.number="form.qcodSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="日期" prop="qcod001">
              <el-date-picker v-model="form.qcod001" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="间接赁率" prop="qcod002">
              <el-input-number v-model.number="form.qcod002" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'间接赁率'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC检查费用" prop="qcod003">
              <el-input-number v-model.number="form.qcod003" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'IQC检查费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检查时间" prop="qcod004">
              <el-input-number v-model.number="form.qcod004" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="差旅费" prop="qcod005">
              <el-input-number v-model.number="form.qcod005" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'差旅费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcod006">
              <el-input-number v-model.number="form.qcod006" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记说明" prop="qcod007">
              <el-input type="textarea" v-model="form.qcod007" :placeholder="$t('btn.enterPrefix')+'特记说明'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="初期检定?定期检定业务费用" prop="qcod008">
              <el-input-number v-model.number="form.qcod008" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'初期检定?定期检定业务费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="作业时间" prop="qcod009">
              <el-input-number v-model.number="form.qcod009" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'作业时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcod010">
              <el-input-number v-model.number="form.qcod010" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记" prop="qcod011">
              <el-input type="textarea" v-model="form.qcod011" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="测定器校正业务费用" prop="qcod012">
              <el-input-number v-model.number="form.qcod012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'测定器校正业务费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="校正时间" prop="qcod013">
              <el-input-number v-model.number="form.qcod013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'校正时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部委托，搬运费" prop="qcod014">
              <el-input-number v-model.number="form.qcod014" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'外部委托，搬运费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcod015">
              <el-input-number v-model.number="form.qcod015" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记" prop="qcod016">
              <el-input type="textarea" v-model="form.qcod016" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他通常费用" prop="qcod017">
              <el-input-number v-model.number="form.qcod017" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他通常费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="通常作业时间" prop="qcod018">
              <el-input-number v-model.number="form.qcod018" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'通常作业时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="通常其他费用" prop="qcod019">
              <el-input-number v-model.number="form.qcod019" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'通常其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记" prop="qcod020">
              <el-input type="textarea" v-model="form.qcod020" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="IQC品质问题対応记录者" prop="qcodqcr">
              <el-input v-model="form.qcodqcr" :placeholder="$t('btn.enterPrefix')+'IQC品质问题対応记录者'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出货检查费用" prop="qcod021">
              <el-input-number v-model.number="form.qcod021" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'出货检查费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="检查时间" prop="qcod022">
              <el-input-number v-model.number="form.qcod022" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'检查时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcod023">
              <el-input-number v-model.number="form.qcod023" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记" prop="qcod024">
              <el-input type="textarea" v-model="form.qcod024" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="信赖性评价?ORT业务费用" prop="qcod025">
              <el-input-number v-model.number="form.qcod025" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'信赖性评价?ORT业务费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="评价时间" prop="qcod026">
              <el-input-number v-model.number="form.qcod026" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'评价时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他费用" prop="qcod027">
              <el-input-number v-model.number="form.qcod027" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记" prop="qcod028">
              <el-input type="textarea" v-model="form.qcod028" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="顾客品质要求对应业务费用" prop="qcod029">
              <el-input-number v-model.number="form.qcod029" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'顾客品质要求对应业务费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="评价作业时间" prop="qcod030">
              <el-input-number v-model.number="form.qcod030" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'评价作业时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="评价其他费用" prop="qcod031">
              <el-input-number v-model.number="form.qcod031" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'评价其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记" prop="qcod032">
              <el-input type="textarea" v-model="form.qcod032" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="其他通常业务费用" prop="qcod033">
              <el-input-number v-model.number="form.qcod033" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'其他通常业务费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="通常业务作业时间" prop="qcod034">
              <el-input-number v-model.number="form.qcod034" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'通常业务作业时间'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="通常业务其他费用" prop="qcod035">
              <el-input-number v-model.number="form.qcod035" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'通常业务其他费用'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="特记" prop="qcod036">
              <el-input type="textarea" v-model="form.qcod036" :placeholder="$t('btn.enterPrefix')+'特记'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="QA品质问题対応记录者" prop="qcodqar">
              <el-input v-model="form.qcodqar" :placeholder="$t('btn.enterPrefix')+'QA品质问题対応记录者'+$t('btn.enterSuffix')" />
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

<script setup name="qmcostoperation">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmCostOperation,
 addQmCostOperation, delQmCostOperation, 
 updateQmCostOperation,getQmCostOperation, 
 } 
from '@/api/logistics/qmcostoperation.js'
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
  qcod001: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'qcodSFID', label: 'SFID' },
  { visible: true, prop: 'qcod001', label: '日期' },
  { visible: true, prop: 'qcod002', label: '间接赁率' },
  { visible: true, prop: 'qcod003', label: 'IQC检查费用' },
  { visible: true, prop: 'qcod004', label: '检查时间' },
  { visible: true, prop: 'qcod005', label: '差旅费' },
  { visible: true, prop: 'qcod006', label: '其他费用' },
  { visible: true, prop: 'qcod007', label: '特记说明' },
  { visible: false, prop: 'qcod008', label: '初期检定?定期检定业务费用' },
  { visible: false, prop: 'qcod009', label: '作业时间' },
  { visible: false, prop: 'qcod010', label: '其他费用' },
  { visible: false, prop: 'qcod011', label: '特记' },
  { visible: false, prop: 'qcod012', label: '测定器校正业务费用' },
  { visible: false, prop: 'qcod013', label: '校正时间' },
  { visible: false, prop: 'qcod014', label: '外部委托，搬运费' },
  { visible: false, prop: 'qcod015', label: '其他费用' },
  { visible: false, prop: 'qcod016', label: '特记' },
  { visible: false, prop: 'qcod017', label: '其他通常费用' },
  { visible: false, prop: 'qcod018', label: '通常作业时间' },
  { visible: false, prop: 'qcod019', label: '通常其他费用' },
  { visible: false, prop: 'qcod020', label: '特记' },
  { visible: false, prop: 'qcodqcr', label: 'IQC品质问题対応记录者' },
  { visible: false, prop: 'qcod021', label: '出货检查费用' },
  { visible: false, prop: 'qcod022', label: '检查时间' },
  { visible: false, prop: 'qcod023', label: '其他费用' },
  { visible: false, prop: 'qcod024', label: '特记' },
  { visible: false, prop: 'qcod025', label: '信赖性评价?ORT业务费用' },
  { visible: false, prop: 'qcod026', label: '评价时间' },
  { visible: false, prop: 'qcod027', label: '其他费用' },
  { visible: false, prop: 'qcod028', label: '特记' },
  { visible: false, prop: 'qcod029', label: '顾客品质要求对应业务费用' },
  { visible: false, prop: 'qcod030', label: '评价作业时间' },
  { visible: false, prop: 'qcod031', label: '评价其他费用' },
  { visible: false, prop: 'qcod032', label: '特记' },
  { visible: false, prop: 'qcod033', label: '其他通常业务费用' },
  { visible: false, prop: 'qcod034', label: '通常业务作业时间' },
  { visible: false, prop: 'qcod035', label: '通常业务其他费用' },
  { visible: false, prop: 'qcod036', label: '特记' },
  { visible: false, prop: 'qcodqar', label: 'QA品质问题対応记录者' },
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
// 日期时间范围
const dateRangeQcod001 = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从品质业务/qm_cost_operation表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeQcod001.value, 'Qcod001');
  loading.value = true
  listQmCostOperation(queryParams).then(res => {
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
  // 日期时间范围
  dateRangeQcod001.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.qcodSFID);
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
    qcodSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    qcod001: [{ required: true, message: "日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod002: [{ required: true, message: "间接赁率"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod003: [{ required: true, message: "IQC检查费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod004: [{ required: true, message: "检查时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod005: [{ required: true, message: "差旅费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod006: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod008: [{ required: true, message: "初期检定?定期检定业务费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod009: [{ required: true, message: "作业时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod010: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod012: [{ required: true, message: "测定器校正业务费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod013: [{ required: true, message: "校正时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod014: [{ required: true, message: "外部委托，搬运费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod015: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod017: [{ required: true, message: "其他通常费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod018: [{ required: true, message: "通常作业时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod019: [{ required: true, message: "通常其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod021: [{ required: true, message: "出货检查费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod022: [{ required: true, message: "检查时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod023: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod025: [{ required: true, message: "信赖性评价?ORT业务费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod026: [{ required: true, message: "评价时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod027: [{ required: true, message: "其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod029: [{ required: true, message: "顾客品质要求对应业务费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod030: [{ required: true, message: "评价作业时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod031: [{ required: true, message: "评价其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod033: [{ required: true, message: "其他通常业务费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    qcod034: [{ required: true, message: "通常业务作业时间"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    qcod035: [{ required: true, message: "通常业务其他费用"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
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
    qcodSFID: 0,
    qcod001: null,
    qcod002: 0,
    qcod003: 0,
    qcod004: 0,
    qcod005: 0,
    qcod006: 0,
    qcod007: null,
    qcod008: 0,
    qcod009: 0,
    qcod010: 0,
    qcod011: null,
    qcod012: 0,
    qcod013: 0,
    qcod014: 0,
    qcod015: 0,
    qcod016: null,
    qcod017: 0,
    qcod018: 0,
    qcod019: 0,
    qcod020: null,
    qcodqcr: null,
    qcod021: 0,
    qcod022: 0,
    qcod023: 0,
    qcod024: null,
    qcod025: 0,
    qcod026: 0,
    qcod027: 0,
    qcod028: null,
    qcod029: 0,
    qcod030: 0,
    qcod031: 0,
    qcod032: null,
    qcod033: 0,
    qcod034: 0,
    qcod035: 0,
    qcod036: null,
    qcodqar: null,
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
  title.value = proxy.$t('btn.add')+" "+'品质业务'
  opertype.value = 1
  form.value.qcod001= new Date()
  form.value.qcod002= 0
  form.value.qcod003= 0
  form.value.qcod004= 0
  form.value.qcod005= 0
  form.value.qcod006= 0
  form.value.qcod008= 0
  form.value.qcod009= 0
  form.value.qcod010= 0
  form.value.qcod012= 0
  form.value.qcod013= 0
  form.value.qcod014= 0
  form.value.qcod015= 0
  form.value.qcod017= 0
  form.value.qcod018= 0
  form.value.qcod019= 0
  form.value.qcod021= 0
  form.value.qcod022= 0
  form.value.qcod023= 0
  form.value.qcod025= 0
  form.value.qcod026= 0
  form.value.qcod027= 0
  form.value.qcod029= 0
  form.value.qcod030= 0
  form.value.qcod031= 0
  form.value.qcod033= 0
  form.value.qcod034= 0
  form.value.qcod035= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.qcodSFID || ids.value
  getQmCostOperation(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '品质业务'
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

      if (form.value.qcodSFID != undefined && opertype.value === 2) {
        updateQmCostOperation(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmCostOperation(form.value).then((res) => {
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
  const Ids = row.qcodSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delQmCostOperation(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<品质业务.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/QmCostOperation/export', { ...queryParams })
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