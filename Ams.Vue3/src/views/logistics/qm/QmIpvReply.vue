<!--
 * @Descripttion: 分析对策/qm_ipv_reply
 * @Version: 0.24.620.29565
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/11 16:44:05
 * @column：52
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="工厂" prop="mi002">
        <el-select filterable clearable   v-model="queryParams.mi002" :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检查员" prop="mi003">
        <el-select filterable clearable   v-model="queryParams.mi003" :placeholder="$t('btn.selectSearchPrefix')+'检查员'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_insp_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="班组" prop="mi004">
        <el-select filterable clearable   v-model="queryParams.mi004" :placeholder="$t('btn.selectSearchPrefix')+'班组'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_line_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="订单" prop="mi005">
        <el-input v-model="queryParams.mi005" :placeholder="$t('btn.enterSearchPrefix')+'订单'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="mi006">
        <el-input v-model="queryParams.mi006" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="mi007">
        <el-input v-model="queryParams.mi007" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="检验日期">
        <el-date-picker
          v-model="dateRangeMi009" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="实施日期">
        <el-date-picker
          v-model="dateRangeMi023" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="发行号码" prop="mi027">
        <el-input v-model="queryParams.mi027" :placeholder="$t('btn.enterSearchPrefix')+'发行号码'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['qm:ipvreply:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['qm:ipvreply:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['qm:ipvreply:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['qm:ipvreply:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/QmIpvReply/importTemplate"
                  importUrl="/Logistics/QmIpvReply/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['qm:ipvreply:export']">
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
      <el-table-column prop="mi002" label="工厂" align="center" v-if="columns.showColumn('mi002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_plant_list " :value="scope.row.mi002"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi003" label="检查员" align="center" v-if="columns.showColumn('mi003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_list " :value="scope.row.mi003"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi004" label="班组" align="center" v-if="columns.showColumn('mi004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_line_list " :value="scope.row.mi004"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi005" label="订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi005')"/>
      <el-table-column prop="mi006" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi006')"/>
      <el-table-column prop="mi007" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi007')"/>
      <el-table-column prop="mi008" label="仕向" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi008')"/>
      <el-table-column prop="mi009" label="检验日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mi009')"/>
      <el-table-column prop="mi010" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi010')"/>
      <el-table-column prop="mi011" label="序号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi011')"/>
      <el-table-column prop="mi012" label="验退数" align="center" v-if="columns.showColumn('mi012')"/>
      <el-table-column prop="mi013" label="不良级别" align="center" v-if="columns.showColumn('mi013')">
        <template #default="scope">
          <dict-tag :options=" options.sys_insp_bad " :value="scope.row.mi013"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi014" label="不良内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi014')"/>
      <el-table-column prop="mi015" label="对策人员" align="center" v-if="columns.showColumn('mi015')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_list " :value="scope.row.mi015"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi016" label="对应日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mi016')"/>
      <el-table-column prop="mi017" label="直接原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi017')"/>
      <el-table-column prop="mi018" label="间接原因" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi018')"/>
      <el-table-column prop="mi019" label="处置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi019')"/>
      <el-table-column prop="mi020" label="直接对策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi020')"/>
      <el-table-column prop="mi021" label="间接对策" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi021')"/>
      <el-table-column prop="mi022" label="检证人员" align="center" v-if="columns.showColumn('mi022')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_list " :value="scope.row.mi022"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi023" label="实施日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('mi023')"/>
      <el-table-column prop="mi024" label="实施查证" align="center" v-if="columns.showColumn('mi024')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.mi024"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi025" label="对策实施查证" align="center" v-if="columns.showColumn('mi025')">
        <template #default="scope">
          <dict-tag :options=" options.sql_insp_list " :value="scope.row.mi025"  />
        </template>
      </el-table-column>
      <el-table-column prop="mi026" label="特记事项" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi026')"/>
      <el-table-column prop="mi027" label="发行号码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi027')"/>
      <el-table-column prop="mi028" label="附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('mi028')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['qm:ipvreply:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['qm:ipvreply:delete']" @click="handleDelete(scope.row)"></el-button>
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
            <el-form-item label="工厂" prop="mi002">
              <el-select filterable clearable   v-model="form.mi002"  :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_plant_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检查员" prop="mi003">
              <el-select filterable clearable   v-model="form.mi003"  :placeholder="$t('btn.selectPrefix')+'检查员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="班组" prop="mi004">
              <el-select filterable clearable   v-model="form.mi004"  :placeholder="$t('btn.selectPrefix')+'班组'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_line_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="订单" prop="mi005">
              <el-input   v-model="form.mi005" :placeholder="$t('btn.enterPrefix')+'订单'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="mi006">
              <el-input   v-model="form.mi006" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="mi007">
              <el-input   v-model="form.mi007" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="仕向" prop="mi008">
              <el-input   v-model="form.mi008" :placeholder="$t('btn.enterPrefix')+'仕向'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检验日期" prop="mi009">
              <el-date-picker v-model="form.mi009" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="mi010">
              <el-input   v-model="form.mi010" :placeholder="$t('btn.enterPrefix')+'批次'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序号" prop="mi011">
              <el-input   v-model="form.mi011" :placeholder="$t('btn.enterPrefix')+'序号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="验退数" prop="mi012">
              <el-input-number v-model.number="form.mi012" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'验退数'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="不良级别" prop="mi013">
              <el-select filterable clearable   v-model="form.mi013"  :placeholder="$t('btn.selectPrefix')+'不良级别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_insp_bad" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="不良内容" prop="mi014">
              <el-input type="textarea" v-model="form.mi014" :placeholder="$t('btn.enterPrefix')+'不良内容'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="对策人员" prop="mi015">
              <el-select filterable clearable   v-model="form.mi015"  :placeholder="$t('btn.selectPrefix')+'对策人员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="对应日期" prop="mi016">
              <el-date-picker v-model="form.mi016" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="直接原因" prop="mi017">
              <el-input type="textarea" v-model="form.mi017" :placeholder="$t('btn.enterPrefix')+'直接原因'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="间接原因" prop="mi018">
              <el-input type="textarea" v-model="form.mi018" :placeholder="$t('btn.enterPrefix')+'间接原因'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="处置" prop="mi019">
              <el-input type="textarea" v-model="form.mi019" :placeholder="$t('btn.enterPrefix')+'处置'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="直接对策" prop="mi020">
              <el-input type="textarea" v-model="form.mi020" :placeholder="$t('btn.enterPrefix')+'直接对策'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="间接对策" prop="mi021">
              <el-input type="textarea" v-model="form.mi021" :placeholder="$t('btn.enterPrefix')+'间接对策'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="检证人员" prop="mi022">
              <el-select filterable clearable   v-model="form.mi022"  :placeholder="$t('btn.selectPrefix')+'检证人员'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="实施日期" prop="mi023">
              <el-date-picker v-model="form.mi023" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="实施查证" prop="mi024">
              <el-radio-group v-model="form.mi024">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="对策实施查证" prop="mi025">
              <el-select filterable clearable   v-model="form.mi025"  :placeholder="$t('btn.selectPrefix')+'对策实施查证'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_insp_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="特记事项" prop="mi026">
              <el-input type="textarea" v-model="form.mi026" :placeholder="$t('btn.enterPrefix')+'特记事项'+$t('btn.enterSuffix')" show-word-limit maxlength="300"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行号码" prop="mi027">
              <el-input   v-model="form.mi027" :placeholder="$t('btn.enterPrefix')+'发行号码'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="附件" prop="mi028">
              <UploadFile v-model="form.mi028" :data="{ uploadType: 1 }" />
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

<script setup name="qmipvreply">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listQmIpvReply,
 addQmIpvReply, delQmIpvReply, 
 updateQmIpvReply,getQmIpvReply, 
 } 
from '@/api/logistics/qmipvreply.js'
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
  sort: 'Mi009',
  sortType: 'desc',
  //是否查询（1是）
  mi002: undefined,
  //是否查询（1是）
  mi003: undefined,
  //是否查询（1是）
  mi004: undefined,
  //是否查询（1是）
  mi005: undefined,
  //是否查询（1是）
  mi006: undefined,
  //是否查询（1是）
  mi007: undefined,
  //是否查询（1是）
  mi009: undefined,
  //是否查询（1是）
  mi023: undefined,
  //是否查询（1是）
  mi027: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'mi002', label: '工厂' },
  { visible: true, prop: 'mi003', label: '检查员' },
  { visible: true, prop: 'mi004', label: '班组' },
  { visible: true, prop: 'mi005', label: '订单' },
  { visible: true, prop: 'mi006', label: '机种' },
  { visible: true, prop: 'mi007', label: '物料' },
  { visible: true, prop: 'mi008', label: '仕向' },
  { visible: false, prop: 'mi009', label: '检验日期' },
  { visible: false, prop: 'mi010', label: '批次' },
  { visible: false, prop: 'mi011', label: '序号' },
  { visible: false, prop: 'mi012', label: '验退数' },
  { visible: false, prop: 'mi013', label: '不良级别' },
  { visible: false, prop: 'mi014', label: '不良内容' },
  { visible: false, prop: 'mi015', label: '对策人员' },
  { visible: false, prop: 'mi016', label: '对应日期' },
  { visible: false, prop: 'mi017', label: '直接原因' },
  { visible: false, prop: 'mi018', label: '间接原因' },
  { visible: false, prop: 'mi019', label: '处置' },
  { visible: false, prop: 'mi020', label: '直接对策' },
  { visible: false, prop: 'mi021', label: '间接对策' },
  { visible: false, prop: 'mi022', label: '检证人员' },
  { visible: false, prop: 'mi023', label: '实施日期' },
  { visible: false, prop: 'mi024', label: '实施查证' },
  { visible: false, prop: 'mi025', label: '对策实施查证' },
  { visible: false, prop: 'mi026', label: '特记事项' },
  { visible: false, prop: 'mi027', label: '发行号码' },
  { visible: false, prop: 'mi028', label: '附件' },
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
// 检验日期时间范围
const dateRangeMi009 = ref([])
// 实施日期时间范围
const dateRangeMi023 = ref([])

//字典参数
var dictParams = [
  { dictType: "sql_plant_list" },
  { dictType: "sql_insp_list" },
  { dictType: "sql_line_list" },
  { dictType: "sys_insp_bad" },
  { dictType: "sys_is_status" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从分析对策/qm_ipv_reply表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeMi009.value, 'Mi009');
  proxy.addDateRange(queryParams, dateRangeMi023.value, 'Mi023');
  loading.value = true
  listQmIpvReply(queryParams).then(res => {
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
  dateRangeMi009.value = []
  // 实施日期时间范围
  dateRangeMi023.value = []
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
    mi002: [{ required: true, message: "工厂"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    mi005: [{ required: true, message: "订单"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi007: [{ required: true, message: "物料"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi012: [{ required: true, message: "验退数"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    mi024: [{ required: true, message: "实施查证"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
//字典名称
  options: {
    // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_plant_list: [],
    // 检查员 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_insp_list: [],
    // 班组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_line_list: [],
    // 不良级别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_insp_bad: [],
    // 实施查证 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_is_status: [],
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
    mi002: [],
    mi003: [],
    mi004: [],
    mi005: null,
    mi006: null,
    mi007: null,
    mi008: null,
    mi009: null,
    mi010: null,
    mi011: null,
    mi012: 0,
    mi013: [],
    mi014: null,
    mi015: [],
    mi016: null,
    mi017: null,
    mi018: null,
    mi019: null,
    mi020: null,
    mi021: null,
    mi022: [],
    mi023: null,
    mi024: 0,
    mi025: [],
    mi026: null,
    mi027: null,
    mi028: null,
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'分析对策'
  opertype.value = 1
  form.value.mi002= []
  form.value.mi003= []
  form.value.mi004= []
  form.value.mi009= new Date()
  form.value.mi012= 0
  form.value.mi013= []
  form.value.mi015= []
  form.value.mi016= new Date()
  form.value.mi022= []
  form.value.mi023= new Date()
  form.value.mi024= 0
  form.value.mi025= []
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getQmIpvReply(id).then((res) => {
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

      if (form.value.id != undefined && opertype.value === 2) {
        updateQmIpvReply(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addQmIpvReply(form.value).then((res) => {
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
      return delQmIpvReply(Ids)
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
      await proxy.downFile('/Logistics/QmIpvReply/export', { ...queryParams })
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