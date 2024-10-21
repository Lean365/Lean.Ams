<!--
 * @Descripttion: 月度资产/fico_monthly_assets
 * @Version: 0.24.619.29178
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 16:54:31
 * @column：54
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="期间" prop="mo002">
            <el-select filterable clearable v-model="queryParams.mo002"
              :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')" @change="handleLfgjaChange">
              <el-option v-for="item in   options.sql_attr_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="年月" prop="mo003">
            <el-select filterable clearable v-model="queryParams.mo003"
              :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   filteredLfmon " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="公司" prop="mo004">
            <el-select filterable clearable v-model="queryParams.mo004"
              :placeholder="$t('btn.selectSearchPrefix')+'公司'+$t('btn.selectSearchSuffix')" @change="handleBukrsChange">
              <el-option v-for="item in   options.sql_corp_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="成本中心" prop="mo008">
            <el-select filterable clearable v-model="queryParams.mo008"
              :placeholder="$t('btn.selectSearchPrefix')+'成本中心'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   filterdCsksz " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="资产简称" prop="mo009">
            <el-input v-model="queryParams.mo009"
              :placeholder="$t('btn.enterSearchPrefix')+'资产简称'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="资本化日期">
            <el-date-picker v-model="dateRangeMo016" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="报废日期">
            <el-date-picker v-model="dateRangeMo018" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
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
        <el-button class="btn-add" v-hasPermi="['fico:monthlyassets:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:monthlyassets:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:monthlyassets:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:monthlyassets:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoMonthlyAssets/importTemplate"
                  importUrl="/Accounting/FicoMonthlyAssets/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:monthlyassets:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table border height="600px" :data="dataList" v-loading="loading" ref="table"
      header-cell-class-name="el-table-header-cell" highlight-current-row @sort-change="sortChange"
      @selection-change="handleSelectionChange">
      <el-table-column type="selection" width="50" align="center" />
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')" />
      <el-table-column prop="mo002" label="期间" align="center" v-if="columns.showColumn('mo002')">
        <template #default="scope">
          <dict-tag :options=" options.sql_attr_list " :value="scope.row.mo002" />
        </template>
      </el-table-column>
      <el-table-column prop="mo003" label="年月" align="center" v-if="columns.showColumn('mo003')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ymdt_list " :value="scope.row.mo003" />
        </template>
      </el-table-column>
      <el-table-column prop="mo004" label="公司" align="center" v-if="columns.showColumn('mo004')">
        <template #default="scope">
          <dict-tag :options=" options.sql_corp_list " :value="scope.row.mo004" />
        </template>
      </el-table-column>
      <el-table-column prop="mo005" label="使用部门" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo005')" />
      <el-table-column prop="mo006" label="资产类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo006')" />
      <el-table-column prop="mo007" label="资产编码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo007')" />
      <el-table-column prop="mo008" label="成本中心" align="center" v-if="columns.showColumn('mo008')">
        <template #default="scope">
          <dict-tag :options=" options.sql_cost_center " :value="scope.row.mo008" />
        </template>
      </el-table-column>
      <el-table-column prop="mo009" label="资产简称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo009')" />
      <el-table-column prop="mo010" label="资产全称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo010')" />
      <el-table-column prop="mo011" label="单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo011')" />
      <el-table-column prop="mo012" label="数量" align="center" v-if="columns.showColumn('mo012')" />
      <el-table-column prop="mo013" label="管理区分" align="center" v-if="columns.showColumn('mo013')" />
      <el-table-column prop="mo014" label="币种" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo014')" />
      <el-table-column prop="mo015" label="购买价格" align="center" v-if="columns.showColumn('mo015')" />
      <el-table-column prop="mo016" label="资本化日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mo016')" />
      <el-table-column prop="mo017" label="折旧价值" align="center" v-if="columns.showColumn('mo017')" />
      <el-table-column prop="mo018" label="报废日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mo018')" />
      <el-table-column prop="mo019" label="残值" align="center" v-if="columns.showColumn('mo019')" />
      <el-table-column prop="mo020" label="存放位置" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo020')" />
      <el-table-column prop="mo021" label="使用年限" align="center" v-if="columns.showColumn('mo021')" />
      <el-table-column prop="mo022" label="是否停用" align="center" v-if="columns.showColumn('mo022')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_flag " :value="scope.row.mo022" />
        </template>
      </el-table-column>
      <el-table-column prop="mo023" label="供应商" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo023')" />
      <el-table-column prop="mo024" label="制造商" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo024')" />
      <el-table-column prop="mo025" label="供应商物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo025')" />
      <el-table-column prop="mo026" label="制造商物料" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo026')" />
      <el-table-column prop="mo027" label="资产形态" align="center" v-if="columns.showColumn('mo027')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_flag " :value="scope.row.mo027" />
        </template>
      </el-table-column>
      <el-table-column prop="mo028" label="资产存在否" align="center" v-if="columns.showColumn('mo028')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_flag " :value="scope.row.mo028" />
        </template>
      </el-table-column>
      <el-table-column prop="mo029" label="盘点人员" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mo029')" />
      <el-table-column prop="mo030" label="周期盘点日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mo030')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:monthlyassets:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['fico:monthlyassets:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改月度资产对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="期间" prop="mo002">
                  <el-select filterable clearable v-model="form.mo002"
                    :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')" @change="handleLfgjaChange">
                    <el-option v-for="item in  options.sql_attr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="年月" prop="mo003">
                  <el-select filterable clearable v-model="form.mo003"
                    :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  filteredLfmon" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="公司" prop="mo004">
                  <el-select filterable clearable v-model="form.mo004"
                    :placeholder="$t('btn.selectPrefix')+'公司'+$t('btn.selectSuffix')" @change="handleBukrsChange">
                    <el-option v-for="item in  options.sql_corp_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="使用部门" prop="mo005">
                  <el-input v-model="form.mo005" :placeholder="$t('btn.enterPrefix')+'使用部门'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="资产类别" prop="mo006">
                  <el-input v-model="form.mo006" :placeholder="$t('btn.enterPrefix')+'资产类别'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="资产编码" prop="mo007">
                  <el-input v-model="form.mo007" :placeholder="$t('btn.enterPrefix')+'资产编码'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="成本中心" prop="mo008">
                  <el-select filterable clearable v-model="form.mo008"
                    :placeholder="$t('btn.selectPrefix')+'成本中心'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  filterdCsksz" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="资产简称" prop="mo009">
                  <el-input v-model="form.mo009" :placeholder="$t('btn.enterPrefix')+'资产简称'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="资产全称" prop="mo010">
                  <el-input v-model="form.mo010" :placeholder="$t('btn.enterPrefix')+'资产全称'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="单位" prop="mo011">
                  <el-input v-model="form.mo011" :placeholder="$t('btn.enterPrefix')+'单位'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="数量" prop="mo012">
                  <el-input-number v-model.number="form.mo012" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="管理区分" prop="mo013">
                  <el-input-number v-model.number="form.mo013" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'管理区分'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="币种" prop="mo014">
                  <el-input v-model="form.mo014" :placeholder="$t('btn.enterPrefix')+'币种'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="购买价格" prop="mo015">
                  <el-input-number v-model.number="form.mo015" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'购买价格'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="资本化日期" prop="mo016">
                  <el-date-picker v-model="form.mo016" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="折旧价值" prop="mo017">
                  <el-input-number v-model.number="form.mo017" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'折旧价值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="报废日期" prop="mo018">
                  <el-date-picker v-model="form.mo018" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="残值" prop="mo019">
                  <el-input-number v-model.number="form.mo019" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'残值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="存放位置" prop="mo020">
                  <el-input v-model="form.mo020" :placeholder="$t('btn.enterPrefix')+'存放位置'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="使用年限" prop="mo021">
                  <el-input-number v-model.number="form.mo021" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'使用年限'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="是否停用" prop="mo022">
                  <el-radio-group v-model="form.mo022">
                    <el-radio v-for="item in options.sys_is_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商" prop="mo023">
                  <el-input v-model="form.mo023" :placeholder="$t('btn.enterPrefix')+'供应商'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="制造商" prop="mo024">
                  <el-input v-model="form.mo024" :placeholder="$t('btn.enterPrefix')+'制造商'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商物料" prop="mo025">
                  <el-input v-model="form.mo025" :placeholder="$t('btn.enterPrefix')+'供应商物料'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="制造商物料" prop="mo026">
                  <el-input v-model="form.mo026" :placeholder="$t('btn.enterPrefix')+'制造商物料'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="资产形态" prop="mo027">
                  <el-radio-group v-model="form.mo027">
                    <el-radio v-for="item in options.sys_is_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="资产存在否" prop="mo028">
                  <el-radio-group v-model="form.mo028">
                    <el-radio v-for="item in options.sys_is_flag" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="盘点人员" prop="mo029">
                  <el-input v-model="form.mo029" :placeholder="$t('btn.enterPrefix')+'盘点人员'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="周期盘点日期" prop="mo030">
                  <el-date-picker v-model="form.mo030" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注说明" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" show-word-limit maxlength="500" />
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

<script setup name="ficomonthlyassets">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoMonthlyAssets,
    addFicoMonthlyAssets, delFicoMonthlyAssets,
    updateFicoMonthlyAssets, getFicoMonthlyAssets,
  }
    from '@/api/accounting/ficomonthlyassets.js'
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
    sort: 'Mo003',
    sortType: 'desc',
    //是否查询（1是）
    mo002: undefined,
    //是否查询（1是）
    mo003: undefined,
    //是否查询（1是）
    mo004: undefined,
    //是否查询（1是）
    mo008: undefined,
    //是否查询（1是）
    mo009: undefined,
    //是否查询（1是）
    mo016: undefined,
    //是否查询（1是）
    mo018: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mo002', label: '期间' },
    { visible: true, prop: 'mo003', label: '年月' },
    { visible: true, prop: 'mo004', label: '公司' },
    { visible: true, prop: 'mo005', label: '使用部门' },
    { visible: true, prop: 'mo006', label: '资产类别' },
    { visible: true, prop: 'mo007', label: '资产编码' },
    { visible: true, prop: 'mo008', label: '成本中心' },
    { visible: false, prop: 'mo009', label: '资产简称' },
    { visible: false, prop: 'mo010', label: '资产全称' },
    { visible: false, prop: 'mo011', label: '单位' },
    { visible: false, prop: 'mo012', label: '数量' },
    { visible: false, prop: 'mo013', label: '管理区分' },
    { visible: false, prop: 'mo014', label: '币种' },
    { visible: false, prop: 'mo015', label: '购买价格' },
    { visible: false, prop: 'mo016', label: '资本化日期' },
    { visible: false, prop: 'mo017', label: '折旧价值' },
    { visible: false, prop: 'mo018', label: '报废日期' },
    { visible: false, prop: 'mo019', label: '残值' },
    { visible: false, prop: 'mo020', label: '存放位置' },
    { visible: false, prop: 'mo021', label: '使用年限' },
    { visible: false, prop: 'mo022', label: '是否停用' },
    { visible: false, prop: 'mo023', label: '供应商' },
    { visible: false, prop: 'mo024', label: '制造商' },
    { visible: false, prop: 'mo025', label: '供应商物料' },
    { visible: false, prop: 'mo026', label: '制造商物料' },
    { visible: false, prop: 'mo027', label: '资产形态' },
    { visible: false, prop: 'mo028', label: '资产存在否' },
    { visible: false, prop: 'mo029', label: '盘点人员' },
    { visible: false, prop: 'mo030', label: '周期盘点日期' },
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
  // 资本化日期时间范围
  const dateRangeMo016 = ref([])
  // 报废日期时间范围
  const dateRangeMo018 = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sql_attr_list" },
    { dictType: "sql_ymdt_list" },
    { dictType: "sql_corp_list" },
    { dictType: "sql_cost_center" },
    { dictType: "sys_is_flag" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从月度资产/fico_monthly_assets表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMo016.value, 'Mo016');
    proxy.addDateRange(queryParams, dateRangeMo018.value, 'Mo018');
    loading.value = true
    listFicoMonthlyAssets(queryParams).then(res => {
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
  function resetQuery() {
    // 资本化日期时间范围
    dateRangeMo016.value = []
    // 报废日期时间范围
    dateRangeMo018.value = []
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
      id: [{ required: true, message: "ID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mo002: [{ required: true, message: "期间" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mo003: [{ required: true, message: "年月" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mo004: [{ required: true, message: "公司" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mo012: [{ required: true, message: "数量" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mo013: [{ required: true, message: "管理区分" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mo014: [{ required: true, message: "币种" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mo015: [{ required: true, message: "购买价格" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mo017: [{ required: true, message: "折旧价值" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mo019: [{ required: true, message: "残值" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mo021: [{ required: true, message: "使用年限" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mo022: [{ required: true, message: "是否停用" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mo027: [{ required: true, message: "资产形态" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mo028: [{ required: true, message: "资产存在否" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      ref04: [{ required: true, message: "预留1" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ref05: [{ required: true, message: "预留2" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      ref06: [{ required: true, message: "预留3" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      udf51: [{ required: true, message: "自定义1" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      udf52: [{ required: true, message: "自定义2" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      udf53: [{ required: true, message: "自定义3" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      udf54: [{ required: true, message: "自定义4" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      udf55: [{ required: true, message: "自定义5" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      udf56: [{ required: true, message: "自定义6" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_attr_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ymdt_list: [],
      // 公司 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_corp_list: [],
      // 成本中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_cost_center: [],
      // 是否停用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_flag: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options, single, multiple } = toRefs(state)

  // 关闭dialog
  function cancel() {
    open.value = false
    reset()
  }

  // 重置表单
  function reset() {
    form.value = {
      mo002: [],
      mo003: [],
      mo004: [],
      mo005: null,
      mo006: null,
      mo007: null,
      mo008: [],
      mo009: null,
      mo010: null,
      mo011: null,
      mo012: 0,
      mo013: 0,
      mo014: null,
      mo015: 0,
      mo016: null,
      mo017: 0,
      mo018: null,
      mo019: 0,
      mo020: null,
      mo021: 0,
      mo022: 0,
      mo023: null,
      mo024: null,
      mo025: null,
      mo026: null,
      mo027: 0,
      mo028: 0,
      mo029: null,
      mo030: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }
  // 使用 computed 属性来过滤数据: 过滤出选中的数据年月
  const filteredLfmon = ref([])
  function handleLfgjaChange() {
    //console.log(open.value === true)
    //console.log(state.options.sql_ymdt_list)
    if (open.value === true) {
      form.value.mo003 = ''
      filteredLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === form.value.mo002)

    }
    else {
      queryParams.mo003 = ''
      //console.log(queryParams.mp002)
      filteredLfmon.value = state.options.sql_ymdt_list.filter(item => item.extLabel === queryParams.mo002)

    }
  }
  const filterdCsksz = ref([])
  function handleBukrsChange() {
    //console.log(open.value === true)
    //console.log(state.options.sql_cost_center)
    if (open.value === true) {
      form.value.mo008 = ''
      filterdCsksz.value = state.options.sql_cost_center.filter(item => item.extLabel === form.value.mo004)
    }
    else {
      queryParams.mo008 = ''
      filterdCsksz.value = state.options.sql_cost_center.filter(item => item.extLabel === queryParams.mo004)
    }
  }
  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '月度资产'
    opertype.value = 1
    form.value.mo002 = []
    form.value.mo003 = []
    form.value.mo004 = []
    form.value.mo008 = []
    form.value.mo012 = 0
    form.value.mo013 = 0
    form.value.mo015 = 0
    form.value.mo016 = new Date()
    form.value.mo017 = 0
    form.value.mo018 = new Date()
    form.value.mo019 = 0
    form.value.mo021 = 0
    form.value.mo022 = 0
    form.value.mo027 = 0
    form.value.mo028 = 0
    form.value.mo030 = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getFicoMonthlyAssets(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '月度资产'
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
          updateFicoMonthlyAssets(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addFicoMonthlyAssets(form.value).then((res) => {
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
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delFicoMonthlyAssets(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<月度资产.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoMonthlyAssets/export', { ...queryParams })
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