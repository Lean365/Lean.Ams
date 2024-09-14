<!--
 * @Descripttion: 公司代码/inst_corp
 * @Version: 0.24.614.18504
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 10:19:56
 * @column：107
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="性质" prop="ma003">
        <el-select filterable clearable   v-model="queryParams.ma003" :placeholder="$t('btn.selectSearchPrefix')+'性质'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="类别" prop="ma004">
        <el-select filterable clearable   v-model="queryParams.ma004" :placeholder="$t('btn.selectSearchPrefix')+'类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="代码" prop="ma005">
        <el-input v-model="queryParams.ma005" :placeholder="$t('btn.enterSearchPrefix')+'代码'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="简称" prop="ma006">
        <el-input v-model="queryParams.ma006" :placeholder="$t('btn.enterSearchPrefix')+'简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="名称" prop="ma007">
        <el-input v-model="queryParams.ma007" :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="国家" prop="ma009">
        <el-select filterable clearable   v-model="queryParams.ma009" :placeholder="$t('btn.selectSearchPrefix')+'国家'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="城市" prop="ma008">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" :loading="loading" v-model="queryParams.ma008" :placeholder="$t('btn.selectSearchPrefix')+'城市'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_global_city " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="货币码" prop="ma010">
        <el-select filterable clearable   v-model="queryParams.ma010" :placeholder="$t('btn.selectSearchPrefix')+'货币码'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_currency " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产公司代码" prop="ma036">
        <el-input v-model="queryParams.ma036" :placeholder="$t('btn.enterSearchPrefix')+'生产公司代码'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['inst:corp:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['inst:corp:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['inst:corp:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['inst:corp:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/InstCorp/importTemplate"
                  importUrl="/Routine/InstCorp/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['inst:corp:export']">
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
      <el-table-column prop="ma003" label="性质" align="center" v-if="columns.showColumn('ma003')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.ma003"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma004" label="类别" align="center" v-if="columns.showColumn('ma004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.ma004"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma005" label="代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma005')"/>
      <el-table-column prop="ma006" label="简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma006')"/>
      <el-table-column prop="ma007" label="名称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma007')"/>
      <el-table-column prop="ma009" label="国家" align="center" v-if="columns.showColumn('ma009')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.ma009"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma008" label="城市" align="center" v-if="columns.showColumn('ma008')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.ma008"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma010" label="货币码" align="center" v-if="columns.showColumn('ma010')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_currency " :value="scope.row.ma010"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma011" label="语言" align="center" v-if="columns.showColumn('ma011')">
        <template #default="scope">
          <dict-tag :options=" options.sys_lang_type " :value="scope.row.ma011"  />
        </template>
      </el-table-column>
      <el-table-column prop="ma012" label="帐目表" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma012')"/>
      <el-table-column prop="ma013" label="最大汇率偏差" align="center" v-if="columns.showColumn('ma013')"/>
      <el-table-column prop="ma014" label="会计年度变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma014')"/>
      <el-table-column prop="ma015" label="分配标识符" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma015')"/>
      <el-table-column prop="ma016" label="公司简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma016')"/>
      <el-table-column prop="ma017" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma017')"/>
      <el-table-column prop="ma018" label="增值税登记号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma018')"/>
      <el-table-column prop="ma019" label="财务管理范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma019')"/>
      <el-table-column prop="ma020" label="现金管理项目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma020')"/>
      <el-table-column prop="ma021" label="现金预算管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma021')"/>
      <el-table-column prop="ma022" label="资金管理更新" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma022')"/>
      <el-table-column prop="ma023" label="地区税务代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma023')"/>
      <el-table-column prop="ma024" label="基金分配科目" :show-overflow-tooltip="true"  v-if="columns.showColumn('ma024')"/>
      <el-table-column prop="ma025" label="公司变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma025')"/>
      <el-table-column prop="ma026" label="预测公司" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma026')"/>
      <el-table-column prop="ma027" label="现金管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma027')"/>
      <el-table-column prop="ma028" label="起息日" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma028')"/>
      <el-table-column prop="ma029" label="折扣金额净值" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma029')"/>
      <el-table-column prop="ma030" label="贷方控制范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma030')"/>
      <el-table-column prop="ma031" label="净折扣额" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma031')"/>
      <el-table-column prop="ma032" label="从样本科目复制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma032')"/>
      <el-table-column prop="ma033" label="业务部门资产负债表" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma033')"/>
      <el-table-column prop="ma034" label="建议会计年度" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma034')"/>
      <el-table-column prop="ma035" label="外向换算记帐" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma035')"/>
      <el-table-column prop="ma036" label="生产公司代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma036')"/>
      <el-table-column prop="ma037" label="采购科目" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma037')"/>
      <el-table-column prop="ma038" label="联营公司会计" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma038')"/>
      <el-table-column prop="ma039" label="金融资产管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma039')"/>
      <el-table-column prop="ma040" label="汇率差额" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma040')"/>
      <el-table-column prop="ma041" label="更新MM" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma041')"/>
      <el-table-column prop="ma042" label="更新SD" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma042')"/>
      <el-table-column prop="ma043" label="外部公司代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma043')"/>
      <el-table-column prop="ma044" label="原始码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma044')"/>
      <el-table-column prop="ma045" label="法定科目表" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma045')"/>
      <el-table-column prop="ma046" label="税组" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma046')"/>
      <el-table-column prop="ma047" label="全球公司代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma047')"/>
      <el-table-column prop="ma048" label="字段状态变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma048')"/>
      <el-table-column prop="ma049" label="记帐期间变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma049')"/>
      <el-table-column prop="ma050" label="套期请求" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma050')"/>
      <el-table-column prop="ma051" label="外币换算税金" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma051')"/>
      <el-table-column prop="ma052" label="工作流变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma052')"/>
      <el-table-column prop="ma053" label="库存管理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma053')"/>
      <el-table-column prop="ma054" label="采购订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma054')"/>
      <el-table-column prop="ma055" label="采购申请" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma055')"/>
      <el-table-column prop="ma056" label="合同" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma056')"/>
      <el-table-column prop="ma057" label="税金确定" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma057')"/>
      <el-table-column prop="ma058" label="进项税码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma058')"/>
      <el-table-column prop="ma059" label="销项税码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma059')"/>
      <el-table-column prop="ma060" label="进口数据" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma060')"/>
      <el-table-column prop="ma061" label="允许负数记帐" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma061')"/>
      <el-table-column prop="ma062" label="信用控制范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma062')"/>
      <el-table-column prop="ma063" label="预扣税" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma063')"/>
      <el-table-column prop="ma064" label="记帐日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma064')"/>
      <el-table-column prop="ma065" label="通货膨胀方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma065')"/>
      <el-table-column prop="ma066" label="字段状态变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma066')"/>
      <el-table-column prop="ma067" label="复制控制GR" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma067')"/>
      <el-table-column prop="ma068" label="收货进口控制" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma068')"/>
      <el-table-column prop="ma069" label="冲销科目方法" align="center" v-if="columns.showColumn('ma069')"/>
      <el-table-column prop="ma070" label="BA变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma070')"/>
      <el-table-column prop="ma071" label="销售会计核算" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma071')"/>
      <el-table-column prop="ma072" label="应收科目抵押激活" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma072')"/>
      <el-table-column prop="ma073" label="可行的金额划分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma073')"/>
      <el-table-column prop="ma074" label="附加费计算方法" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma074')"/>
      <el-table-column prop="ma075" label="征税类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma075')"/>
      <el-table-column prop="ma076" label="金额更正" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma076')"/>
      <el-table-column prop="ma077" label="税码更正" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma077')"/>
      <el-table-column prop="ma078" label="汇款文件类型" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma078')"/>
      <el-table-column prop="ma079" label="递延税规则" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma079')"/>
      <el-table-column prop="ma080" label="报税日期" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma080')"/>
      <el-table-column prop="ma081" label="过帐期间变式" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma081')"/>
      <el-table-column prop="ma082" label="购物车" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma082')"/>
      <el-table-column prop="ma083" label="基金管理分配" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('ma083')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['inst:corp:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['inst:corp:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改公司代码对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="集团" prop="ma002">
              <el-input v-model="form.ma002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"  show-word-limit maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="性质" prop="ma003">
              <el-select filterable clearable   v-model="form.ma003"  :placeholder="$t('btn.selectPrefix')+'性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_nature_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="类别" prop="ma004">
              <el-select filterable clearable   v-model="form.ma004"  :placeholder="$t('btn.selectPrefix')+'类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="代码" prop="ma005">
              <el-input v-model="form.ma005" :placeholder="$t('btn.enterPrefix')+'代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="简称" prop="ma006">
              <el-input v-model="form.ma006" :placeholder="$t('btn.enterPrefix')+'简称'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="名称" prop="ma007">
              <el-input v-model="form.ma007" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家" prop="ma009">
              <el-select filterable clearable   v-model="form.ma009"  :placeholder="$t('btn.selectPrefix')+'国家'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_country" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="城市" prop="ma008">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" 
              :loading="loading" v-model="form.ma008"  :placeholder="$t('btn.selectPrefix')+'城市'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="货币码" prop="ma010">
              <el-select filterable clearable   v-model="form.ma010"  :placeholder="$t('btn.selectPrefix')+'货币码'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_currency" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="语言" prop="ma011">
              <el-select filterable clearable   v-model="form.ma011"  :placeholder="$t('btn.selectPrefix')+'语言'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_lang_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="帐目表" prop="ma012">
              <el-input v-model="form.ma012" :placeholder="$t('btn.enterPrefix')+'帐目表'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="最大汇率偏差" prop="ma013">
              <el-input-number v-model.number="form.ma013" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'最大汇率偏差'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="会计年度变式" prop="ma014">
              <el-input v-model="form.ma014" :placeholder="$t('btn.enterPrefix')+'会计年度变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="分配标识符" prop="ma015">
              <el-input v-model="form.ma015" :placeholder="$t('btn.enterPrefix')+'分配标识符'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司简称" prop="ma016">
              <el-input v-model="form.ma016" :placeholder="$t('btn.enterPrefix')+'公司简称'+$t('btn.enterSuffix')"  show-word-limit maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="ma017">
              <el-input v-model="form.ma017" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="增值税登记号" prop="ma018">
              <el-input v-model="form.ma018" :placeholder="$t('btn.enterPrefix')+'增值税登记号'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="财务管理范围" prop="ma019">
              <el-input v-model="form.ma019" :placeholder="$t('btn.enterPrefix')+'财务管理范围'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="现金管理项目" prop="ma020">
              <el-input v-model="form.ma020" :placeholder="$t('btn.enterPrefix')+'现金管理项目'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="现金预算管理" prop="ma021">
              <el-input v-model="form.ma021" :placeholder="$t('btn.enterPrefix')+'现金预算管理'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资金管理更新" prop="ma022">
              <el-input v-model="form.ma022" :placeholder="$t('btn.enterPrefix')+'资金管理更新'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地区税务代码" prop="ma023">
              <el-input v-model="form.ma023" :placeholder="$t('btn.enterPrefix')+'地区税务代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基金分配科目" prop="ma024">
              <el-date-picker v-model="form.ma024" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司变式" prop="ma025">
              <el-input v-model="form.ma025" :placeholder="$t('btn.enterPrefix')+'公司变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预测公司" prop="ma026">
              <el-input v-model="form.ma026" :placeholder="$t('btn.enterPrefix')+'预测公司'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="现金管理" prop="ma027">
              <el-input v-model="form.ma027" :placeholder="$t('btn.enterPrefix')+'现金管理'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="起息日" prop="ma028">
              <el-input v-model="form.ma028" :placeholder="$t('btn.enterPrefix')+'起息日'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折扣金额净值" prop="ma029">
              <el-input v-model="form.ma029" :placeholder="$t('btn.enterPrefix')+'折扣金额净值'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="贷方控制范围" prop="ma030">
              <el-input v-model="form.ma030" :placeholder="$t('btn.enterPrefix')+'贷方控制范围'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="净折扣额" prop="ma031">
              <el-input v-model="form.ma031" :placeholder="$t('btn.enterPrefix')+'净折扣额'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="从样本科目复制" prop="ma032">
              <el-input v-model="form.ma032" :placeholder="$t('btn.enterPrefix')+'从样本科目复制'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="业务部门资产负债表" prop="ma033">
              <el-input v-model="form.ma033" :placeholder="$t('btn.enterPrefix')+'业务部门资产负债表'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="建议会计年度" prop="ma034">
              <el-input v-model="form.ma034" :placeholder="$t('btn.enterPrefix')+'建议会计年度'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外向换算记帐" prop="ma035">
              <el-input v-model="form.ma035" :placeholder="$t('btn.enterPrefix')+'外向换算记帐'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产公司代码" prop="ma036">
              <el-input v-model="form.ma036" :placeholder="$t('btn.enterPrefix')+'生产公司代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购科目" prop="ma037">
              <el-input v-model="form.ma037" :placeholder="$t('btn.enterPrefix')+'采购科目'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联营公司会计" prop="ma038">
              <el-input v-model="form.ma038" :placeholder="$t('btn.enterPrefix')+'联营公司会计'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金融资产管理" prop="ma039">
              <el-input v-model="form.ma039" :placeholder="$t('btn.enterPrefix')+'金融资产管理'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="汇率差额" prop="ma040">
              <el-input v-model="form.ma040" :placeholder="$t('btn.enterPrefix')+'汇率差额'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新MM" prop="ma041">
              <el-input v-model="form.ma041" :placeholder="$t('btn.enterPrefix')+'更新MM'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新SD" prop="ma042">
              <el-input v-model="form.ma042" :placeholder="$t('btn.enterPrefix')+'更新SD'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外部公司代码" prop="ma043">
              <el-input v-model="form.ma043" :placeholder="$t('btn.enterPrefix')+'外部公司代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="原始码" prop="ma044">
              <el-input v-model="form.ma044" :placeholder="$t('btn.enterPrefix')+'原始码'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="法定科目表" prop="ma045">
              <el-input v-model="form.ma045" :placeholder="$t('btn.enterPrefix')+'法定科目表'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税组" prop="ma046">
              <el-input v-model="form.ma046" :placeholder="$t('btn.enterPrefix')+'税组'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="全球公司代码" prop="ma047">
              <el-input v-model="form.ma047" :placeholder="$t('btn.enterPrefix')+'全球公司代码'+$t('btn.enterSuffix')"  show-word-limit maxlength="12"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="字段状态变式" prop="ma048">
              <el-input v-model="form.ma048" :placeholder="$t('btn.enterPrefix')+'字段状态变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="记帐期间变式" prop="ma049">
              <el-input v-model="form.ma049" :placeholder="$t('btn.enterPrefix')+'记帐期间变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="套期请求" prop="ma050">
              <el-input v-model="form.ma050" :placeholder="$t('btn.enterPrefix')+'套期请求'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外币换算税金" prop="ma051">
              <el-input v-model="form.ma051" :placeholder="$t('btn.enterPrefix')+'外币换算税金'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工作流变式" prop="ma052">
              <el-input v-model="form.ma052" :placeholder="$t('btn.enterPrefix')+'工作流变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="库存管理" prop="ma053">
              <el-input v-model="form.ma053" :placeholder="$t('btn.enterPrefix')+'库存管理'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购订单" prop="ma054">
              <el-input v-model="form.ma054" :placeholder="$t('btn.enterPrefix')+'采购订单'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购申请" prop="ma055">
              <el-input v-model="form.ma055" :placeholder="$t('btn.enterPrefix')+'采购申请'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同" prop="ma056">
              <el-input v-model="form.ma056" :placeholder="$t('btn.enterPrefix')+'合同'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税金确定" prop="ma057">
              <el-input v-model="form.ma057" :placeholder="$t('btn.enterPrefix')+'税金确定'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="进项税码" prop="ma058">
              <el-input v-model="form.ma058" :placeholder="$t('btn.enterPrefix')+'进项税码'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销项税码" prop="ma059">
              <el-input v-model="form.ma059" :placeholder="$t('btn.enterPrefix')+'销项税码'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="进口数据" prop="ma060">
              <el-input v-model="form.ma060" :placeholder="$t('btn.enterPrefix')+'进口数据'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="允许负数记帐" prop="ma061">
              <el-input v-model="form.ma061" :placeholder="$t('btn.enterPrefix')+'允许负数记帐'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="信用控制范围" prop="ma062">
              <el-input v-model="form.ma062" :placeholder="$t('btn.enterPrefix')+'信用控制范围'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="预扣税" prop="ma063">
              <el-input v-model="form.ma063" :placeholder="$t('btn.enterPrefix')+'预扣税'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="记帐日期" prop="ma064">
              <el-input v-model="form.ma064" :placeholder="$t('btn.enterPrefix')+'记帐日期'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="通货膨胀方法" prop="ma065">
              <el-input v-model="form.ma065" :placeholder="$t('btn.enterPrefix')+'通货膨胀方法'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="字段状态变式" prop="ma066">
              <el-input v-model="form.ma066" :placeholder="$t('btn.enterPrefix')+'字段状态变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="复制控制GR" prop="ma067">
              <el-input v-model="form.ma067" :placeholder="$t('btn.enterPrefix')+'复制控制GR'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="收货进口控制" prop="ma068">
              <el-input v-model="form.ma068" :placeholder="$t('btn.enterPrefix')+'收货进口控制'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="冲销科目方法" prop="ma069">
              <el-input-number v-model.number="form.ma069" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'冲销科目方法'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="BA变式" prop="ma070">
              <el-input v-model="form.ma070" :placeholder="$t('btn.enterPrefix')+'BA变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="销售会计核算" prop="ma071">
              <el-input v-model="form.ma071" :placeholder="$t('btn.enterPrefix')+'销售会计核算'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="应收科目抵押激活" prop="ma072">
              <el-input v-model="form.ma072" :placeholder="$t('btn.enterPrefix')+'应收科目抵押激活'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="可行的金额划分" prop="ma073">
              <el-input v-model="form.ma073" :placeholder="$t('btn.enterPrefix')+'可行的金额划分'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="附加费计算方法" prop="ma074">
              <el-input v-model="form.ma074" :placeholder="$t('btn.enterPrefix')+'附加费计算方法'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="征税类别" prop="ma075">
              <el-input v-model="form.ma075" :placeholder="$t('btn.enterPrefix')+'征税类别'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="金额更正" prop="ma076">
              <el-input v-model="form.ma076" :placeholder="$t('btn.enterPrefix')+'金额更正'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="税码更正" prop="ma077">
              <el-input v-model="form.ma077" :placeholder="$t('btn.enterPrefix')+'税码更正'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="汇款文件类型" prop="ma078">
              <el-input v-model="form.ma078" :placeholder="$t('btn.enterPrefix')+'汇款文件类型'+$t('btn.enterSuffix')"  show-word-limit maxlength="4"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="递延税规则" prop="ma079">
              <el-input v-model="form.ma079" :placeholder="$t('btn.enterPrefix')+'递延税规则'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="报税日期" prop="ma080">
              <el-input v-model="form.ma080" :placeholder="$t('btn.enterPrefix')+'报税日期'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="过帐期间变式" prop="ma081">
              <el-input v-model="form.ma081" :placeholder="$t('btn.enterPrefix')+'过帐期间变式'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="购物车" prop="ma082">
              <el-input v-model="form.ma082" :placeholder="$t('btn.enterPrefix')+'购物车'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="基金管理分配" prop="ma083">
              <el-input v-model="form.ma083" :placeholder="$t('btn.enterPrefix')+'基金管理分配'+$t('btn.enterSuffix')"  show-word-limit maxlength="2"/>
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

<script setup name="instcorp">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listInstCorp,
 addInstCorp, delInstCorp, 
 updateInstCorp,getInstCorp, 
 } 
from '@/api/routine/instcorp.js'
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
  sort: 'Ma005',
  sortType: 'asc',
  //是否查询（1是）
  ma003: undefined,
  //是否查询（1是）
  ma004: undefined,
  //是否查询（1是）
  ma005: undefined,
  //是否查询（1是）
  ma006: undefined,
  //是否查询（1是）
  ma007: undefined,
  //是否查询（1是）
  ma009: undefined,
  //是否查询（1是）
  ma008: undefined,
  //是否查询（1是）
  ma010: undefined,
  //是否查询（1是）
  ma036: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'ma002', label: '集团' },
  { visible: true, prop: 'ma003', label: '性质' },
  { visible: true, prop: 'ma004', label: '类别' },
  { visible: true, prop: 'ma005', label: '代码' },
  { visible: true, prop: 'ma006', label: '简称' },
  { visible: true, prop: 'ma007', label: '名称' },
  { visible: true, prop: 'ma009', label: '国家' },
  { visible: false, prop: 'ma008', label: '城市' },
  { visible: false, prop: 'ma010', label: '货币码' },
  { visible: false, prop: 'ma011', label: '语言' },
  { visible: false, prop: 'ma012', label: '帐目表' },
  { visible: false, prop: 'ma013', label: '最大汇率偏差' },
  { visible: false, prop: 'ma014', label: '会计年度变式' },
  { visible: false, prop: 'ma015', label: '分配标识符' },
  { visible: false, prop: 'ma016', label: '公司简称' },
  { visible: false, prop: 'ma017', label: '地址' },
  { visible: false, prop: 'ma018', label: '增值税登记号' },
  { visible: false, prop: 'ma019', label: '财务管理范围' },
  { visible: false, prop: 'ma020', label: '现金管理项目' },
  { visible: false, prop: 'ma021', label: '现金预算管理' },
  { visible: false, prop: 'ma022', label: '资金管理更新' },
  { visible: false, prop: 'ma023', label: '地区税务代码' },
  { visible: false, prop: 'ma024', label: '基金分配科目' },
  { visible: false, prop: 'ma025', label: '公司变式' },
  { visible: false, prop: 'ma026', label: '预测公司' },
  { visible: false, prop: 'ma027', label: '现金管理' },
  { visible: false, prop: 'ma028', label: '起息日' },
  { visible: false, prop: 'ma029', label: '折扣金额净值' },
  { visible: false, prop: 'ma030', label: '贷方控制范围' },
  { visible: false, prop: 'ma031', label: '净折扣额' },
  { visible: false, prop: 'ma032', label: '从样本科目复制' },
  { visible: false, prop: 'ma033', label: '业务部门资产负债表' },
  { visible: false, prop: 'ma034', label: '建议会计年度' },
  { visible: false, prop: 'ma035', label: '外向换算记帐' },
  { visible: false, prop: 'ma036', label: '生产公司代码' },
  { visible: false, prop: 'ma037', label: '采购科目' },
  { visible: false, prop: 'ma038', label: '联营公司会计' },
  { visible: false, prop: 'ma039', label: '金融资产管理' },
  { visible: false, prop: 'ma040', label: '汇率差额' },
  { visible: false, prop: 'ma041', label: '更新MM' },
  { visible: false, prop: 'ma042', label: '更新SD' },
  { visible: false, prop: 'ma043', label: '外部公司代码' },
  { visible: false, prop: 'ma044', label: '原始码' },
  { visible: false, prop: 'ma045', label: '法定科目表' },
  { visible: false, prop: 'ma046', label: '税组' },
  { visible: false, prop: 'ma047', label: '全球公司代码' },
  { visible: false, prop: 'ma048', label: '字段状态变式' },
  { visible: false, prop: 'ma049', label: '记帐期间变式' },
  { visible: false, prop: 'ma050', label: '套期请求' },
  { visible: false, prop: 'ma051', label: '外币换算税金' },
  { visible: false, prop: 'ma052', label: '工作流变式' },
  { visible: false, prop: 'ma053', label: '库存管理' },
  { visible: false, prop: 'ma054', label: '采购订单' },
  { visible: false, prop: 'ma055', label: '采购申请' },
  { visible: false, prop: 'ma056', label: '合同' },
  { visible: false, prop: 'ma057', label: '税金确定' },
  { visible: false, prop: 'ma058', label: '进项税码' },
  { visible: false, prop: 'ma059', label: '销项税码' },
  { visible: false, prop: 'ma060', label: '进口数据' },
  { visible: false, prop: 'ma061', label: '允许负数记帐' },
  { visible: false, prop: 'ma062', label: '信用控制范围' },
  { visible: false, prop: 'ma063', label: '预扣税' },
  { visible: false, prop: 'ma064', label: '记帐日期' },
  { visible: false, prop: 'ma065', label: '通货膨胀方法' },
  { visible: false, prop: 'ma066', label: '字段状态变式' },
  { visible: false, prop: 'ma067', label: '复制控制GR' },
  { visible: false, prop: 'ma068', label: '收货进口控制' },
  { visible: false, prop: 'ma069', label: '冲销科目方法' },
  { visible: false, prop: 'ma070', label: 'BA变式' },
  { visible: false, prop: 'ma071', label: '销售会计核算' },
  { visible: false, prop: 'ma072', label: '应收科目抵押激活' },
  { visible: false, prop: 'ma073', label: '可行的金额划分' },
  { visible: false, prop: 'ma074', label: '附加费计算方法' },
  { visible: false, prop: 'ma075', label: '征税类别' },
  { visible: false, prop: 'ma076', label: '金额更正' },
  { visible: false, prop: 'ma077', label: '税码更正' },
  { visible: false, prop: 'ma078', label: '汇款文件类型' },
  { visible: false, prop: 'ma079', label: '递延税规则' },
  { visible: false, prop: 'ma080', label: '报税日期' },
  { visible: false, prop: 'ma081', label: '过帐期间变式' },
  { visible: false, prop: 'ma082', label: '购物车' },
  { visible: false, prop: 'ma083', label: '基金管理分配' },
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
//定义远程搜索变量
const remotequeryList_sql_global_city=ref([])
//定义远程搜索变量
const remotequery_sql_global_city=ref([])
//远程字典参数
var remotedictParams_sql_global_city = [
    { dictType: "sql_global_city" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_global_city).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_global_city.value = element.list
      })
      //console.log(remotequeryList_sql_global_city)
    })
  })
//远程搜索
const remoteMethod_sql_global_city = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_global_city.value = remotequeryList_sql_global_city.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_global_city(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_global_city.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_global_city = debounce((query) => {
    let arr = remotequeryList_sql_global_city.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_global_city.value = arr.slice(0, 5)
      addFilterOptions_sql_global_city(query)
    } else {
      remotequery_sql_global_city.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_global_city =debounce((dictValue) => {
    let target = remotequeryList_sql_global_city.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_global_city.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_global_city.value.toLowerCase().unshift(target)
      }
    }
  }, 300)

//字典参数
var dictParams = [
  { dictType: "sys_nature_list" },
  { dictType: "sys_ind_type" },
  { dictType: "sql_global_country" },
  { dictType: "sql_global_currency" },
  { dictType: "sys_lang_type" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从公司代码/inst_corp表记录数据
function getList(){
  loading.value = true
  listInstCorp(queryParams).then(res => {
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
    id: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    ma002: [{ required: true, message: "集团"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ma003: [{ required: true, message: "性质"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma004: [{ required: true, message: "类别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    ma005: [{ required: true, message: "代码"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
    // 性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_nature_list: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ind_type: [],
    // 国家 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_country: [],
    // 货币码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_global_currency: [],
    // 语言 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_lang_type: [],
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
    ma002: null,
    ma003: [],
    ma004: [],
    ma005: null,
    ma006: null,
    ma007: null,
    ma009: [],
    ma008: [],
    ma010: [],
    ma011: [],
    ma012: null,
    ma013: 0,
    ma014: null,
    ma015: null,
    ma016: null,
    ma017: null,
    ma018: null,
    ma019: null,
    ma020: null,
    ma021: null,
    ma022: null,
    ma023: null,
    ma024: null,
    ma025: null,
    ma026: null,
    ma027: null,
    ma028: null,
    ma029: null,
    ma030: null,
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
    ma041: null,
    ma042: null,
    ma043: null,
    ma044: null,
    ma045: null,
    ma046: null,
    ma047: null,
    ma048: null,
    ma049: null,
    ma050: null,
    ma051: null,
    ma052: null,
    ma053: null,
    ma054: null,
    ma055: null,
    ma056: null,
    ma057: null,
    ma058: null,
    ma059: null,
    ma060: null,
    ma061: null,
    ma062: null,
    ma063: null,
    ma064: null,
    ma065: null,
    ma066: null,
    ma067: null,
    ma068: null,
    ma069: 0,
    ma070: null,
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
    remark: null,
  };
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'公司代码'
  opertype.value = 1
  form.value.ma003= []
  form.value.ma004= []
  form.value.ma009= []
  form.value.ma008= []
  form.value.ma010= []
  form.value.ma011= []
  form.value.ma013= 0
  form.value.ma024= new Date()
  form.value.ma069= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getInstCorp(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '公司代码'
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
        updateInstCorp(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addInstCorp(form.value).then((res) => {
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
      return delInstCorp(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<公司代码.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/InstCorp/export', { ...queryParams })
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