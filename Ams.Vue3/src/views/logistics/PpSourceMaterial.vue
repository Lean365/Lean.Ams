<!--
 * @Descripttion: 源物料/pp_source_material
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 15:18:11
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="品目" prop="zcadz002">
            <el-input v-model="queryParams.zcadz002"
              :placeholder="$t('btn.enterSearchPrefix')+'品目'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="行业领域" prop="zcadz003">
            <el-select-v2 filterable clearable v-model="queryParams.zcadz003"
              :placeholder="$t('btn.selectSearchPrefix')+'行业领域'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option></el-select-v2>
            <!-- <el-select filterable clearable v-model="queryParams.zcadz003"
              :placeholder="$t('btn.selectSearchPrefix')+'行业领域'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select> -->
          </el-form-item>
          <el-form-item label="物料类型" prop="zcadz004">
            <el-select filterable clearable v-model="queryParams.zcadz004"
              :placeholder="$t('btn.selectSearchPrefix')+'物料类型'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_matl_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料描述（短文本）" prop="zcadz005">
            <el-input v-model="queryParams.zcadz005"
              :placeholder="$t('btn.enterSearchPrefix')+'物料描述（短文本）'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="基本单位" prop="zcadz006">
            <el-select filterable clearable v-model="queryParams.zcadz006"
              :placeholder="$t('btn.selectSearchPrefix')+'基本单位'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_unit_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料组" prop="zcadz008">
            <el-select filterable clearable v-model="queryParams.zcadz008"
              :placeholder="$t('btn.selectSearchPrefix')+'物料组'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_matl_group " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="采购组" prop="zcadz009">
            <el-select filterable clearable v-model="queryParams.zcadz009"
              :placeholder="$t('btn.selectSearchPrefix')+'采购组'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_pur_group " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="采购类型" prop="zcadz010">
            <el-select filterable clearable v-model="queryParams.zcadz010"
              :placeholder="$t('btn.selectSearchPrefix')+'采购类型'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="特殊采购类" prop="zcadz011">
            <el-select filterable clearable v-model="queryParams.zcadz011"
              :placeholder="$t('btn.selectSearchPrefix')+'特殊采购类'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_pur_spec " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="过账检验" prop="zcadz019">
            <el-radio-group v-model="queryParams.zcadz019">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_normal_whether " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="批次管理" prop="zcadz022">
            <el-radio-group v-model="queryParams.zcadz022">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_normal_whether " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="评估类" prop="zcadz025">
            <el-select filterable clearable v-model="queryParams.zcadz025"
              :placeholder="$t('btn.selectSearchPrefix')+'评估类'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_val_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="币种" prop="zcadz027">
            <el-select filterable clearable v-model="queryParams.zcadz027"
              :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="生产仓储" prop="zcadz030">
            <el-select filterable clearable v-model="queryParams.zcadz030"
              :placeholder="$t('btn.selectSearchPrefix')+'生产仓储'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="采购仓储" prop="zcadz031">
            <el-select filterable clearable v-model="queryParams.zcadz031"
              :placeholder="$t('btn.selectSearchPrefix')+'采购仓储'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="库存仓位" prop="zcadz032">
            <el-input v-model="queryParams.zcadz032"
              :placeholder="$t('btn.enterSearchPrefix')+'库存仓位'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="状态" prop="zcadz034">
            <el-radio-group v-model="queryParams.zcadz034">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_eol_list " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
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
        <el-button class="btn-add" v-hasPermi="['pp:sourcematerial:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:sourcematerial:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:sourcematerial:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:sourcematerial:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/PpSourceMaterial/importTemplate"
                  importUrl="/Logistics/PpSourceMaterial/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['pp:sourcematerial:export']">
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
      <el-table-column prop="sfId" label="sfId" align="center" v-if="columns.showColumn('sfId')" />
      <el-table-column prop="zcadz001" label="Plnt" align="center" v-if="columns.showColumn('zcadz001')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.zcadz001" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz002" label="品目" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz002')" />
      <el-table-column prop="zcadz003" label="行业领域" align="center" v-if="columns.showColumn('zcadz003')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.zcadz003" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz004" label="物料类型" align="center" v-if="columns.showColumn('zcadz004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_type " :value="scope.row.zcadz004" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz005" label="物料描述（短文本）" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz005')" />
      <el-table-column prop="zcadz006" label="基本单位" align="center" v-if="columns.showColumn('zcadz006')">
        <template #default="scope">
          <dict-tag :options=" options.sys_unit_list " :value="scope.row.zcadz006" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz007" label="产品层次" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz007')" />
      <el-table-column prop="zcadz008" label="物料组" align="center" v-if="columns.showColumn('zcadz008')">
        <template #default="scope">
          <dict-tag :options=" options.sys_matl_group " :value="scope.row.zcadz008" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz009" label="采购组" align="center" v-if="columns.showColumn('zcadz009')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_group " :value="scope.row.zcadz009" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz010" label="采购类型" align="center" v-if="columns.showColumn('zcadz010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_type " :value="scope.row.zcadz010" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz011" label="特殊采购类" align="center" v-if="columns.showColumn('zcadz011')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_spec " :value="scope.row.zcadz011" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz012" label="散装物料" align="center" v-if="columns.showColumn('zcadz012')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.zcadz012" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz013" label="最小起订量" align="center" v-if="columns.showColumn('zcadz013')" />
      <el-table-column prop="zcadz014" label="基本单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz014')" />
      <el-table-column prop="zcadz015" label="舍入值" align="center" v-if="columns.showColumn('zcadz015')" />
      <el-table-column prop="zcadz016" label="基本单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz016')" />
      <el-table-column prop="zcadz017" label="计划交货" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz017')" />
      <el-table-column prop="zcadz018" label="自制天数" align="center" v-if="columns.showColumn('zcadz018')" />
      <el-table-column prop="zcadz019" label="过账检验" align="center" v-if="columns.showColumn('zcadz019')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.zcadz019" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz020" label="利润中心" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz020')" />
      <el-table-column prop="zcadz021" label="差异码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz021')" />
      <el-table-column prop="zcadz022" label="批次管理" align="center" v-if="columns.showColumn('zcadz022')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.zcadz022" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz023" label="制造商零件编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz023')" />
      <el-table-column prop="zcadz024" label="制造商编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz024')" />
      <el-table-column prop="zcadz025" label="评估类" align="center" v-if="columns.showColumn('zcadz025')">
        <template #default="scope">
          <dict-tag :options=" options.sys_val_type " :value="scope.row.zcadz025" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz026" label="移动平均价格/周期单价" align="center" v-if="columns.showColumn('zcadz026')" />
      <el-table-column prop="zcadz027" label="币种" align="center" v-if="columns.showColumn('zcadz027')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.zcadz027" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz028" label="价格控制" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz028')" />
      <el-table-column prop="zcadz029" label="价格单位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz029')" />
      <el-table-column prop="zcadz030" label="生产仓储" align="center" v-if="columns.showColumn('zcadz030')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.zcadz030" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz031" label="采购仓储" align="center" v-if="columns.showColumn('zcadz031')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.zcadz031" />
        </template>
      </el-table-column>
      <el-table-column prop="zcadz032" label="库存仓位" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zcadz032')" />
      <el-table-column prop="zcadz033" label="库存" align="center" v-if="columns.showColumn('zcadz033')" />
      <el-table-column prop="zcadz034" label="状态" align="center" v-if="columns.showColumn('zcadz034')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_list " :value="scope.row.zcadz034" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createBy')" />
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateBy')" />
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateTime')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['pp:sourcematerial:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['pp:sourcematerial:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改源物料对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="sfId" prop="sfId">
                  <el-input v-model.number="form.sfId" :placeholder="$t('btn.enterPrefix')+'sfId'+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="Plnt" prop="zcadz001">
                  <el-select filterable clearable v-model="form.zcadz001"
                    :placeholder="$t('btn.selectPrefix')+'Plnt'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="品目" prop="zcadz002">
                  <el-input v-model="form.zcadz002" :placeholder="$t('btn.enterPrefix')+'品目'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="行业领域" prop="zcadz003">
                  <el-select filterable clearable v-model="form.zcadz003"
                    :placeholder="$t('btn.selectPrefix')+'行业领域'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ind_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料类型" prop="zcadz004">
                  <el-select filterable clearable v-model="form.zcadz004"
                    :placeholder="$t('btn.selectPrefix')+'物料类型'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_matl_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料描述（短文本）" prop="zcadz005">
                  <el-input v-model="form.zcadz005"
                    :placeholder="$t('btn.enterPrefix')+'物料描述（短文本）'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基本单位" prop="zcadz006">
                  <el-select filterable clearable v-model="form.zcadz006"
                    :placeholder="$t('btn.selectPrefix')+'基本单位'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_unit_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="产品层次" prop="zcadz007">
                  <el-input v-model="form.zcadz007" :placeholder="$t('btn.enterPrefix')+'产品层次'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="物料组" prop="zcadz008">
                  <el-select filterable clearable v-model="form.zcadz008"
                    :placeholder="$t('btn.selectPrefix')+'物料组'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_matl_group" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="采购组" prop="zcadz009">
                  <el-select filterable clearable v-model="form.zcadz009"
                    :placeholder="$t('btn.selectPrefix')+'采购组'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_pur_group" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="采购类型" prop="zcadz010">
                  <el-select filterable clearable v-model="form.zcadz010"
                    :placeholder="$t('btn.selectPrefix')+'采购类型'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_pur_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="特殊采购类" prop="zcadz011">
                  <el-select filterable clearable v-model="form.zcadz011"
                    :placeholder="$t('btn.selectPrefix')+'特殊采购类'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_pur_spec" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="散装物料" prop="zcadz012">
                  <el-select filterable clearable v-model="form.zcadz012"
                    :placeholder="$t('btn.selectPrefix')+'散装物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_normal_whether" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="最小起订量" prop="zcadz013">
                  <el-input-number v-model.number="form.zcadz013" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'最小起订量'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基本单位" prop="zcadz014">
                  <el-input v-model="form.zcadz014" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="舍入值" prop="zcadz015">
                  <el-input-number v-model.number="form.zcadz015" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'舍入值'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="基本单位" prop="zcadz016">
                  <el-input v-model="form.zcadz016" :placeholder="$t('btn.enterPrefix')+'基本单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划交货" prop="zcadz017">
                  <el-input v-model="form.zcadz017" :placeholder="$t('btn.enterPrefix')+'计划交货'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自制天数" prop="zcadz018">
                  <el-input-number v-model.number="form.zcadz018" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自制天数'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="过账检验" prop="zcadz019">
                  <el-radio-group v-model="form.zcadz019">
                    <el-radio v-for="item in options.sys_normal_whether" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="利润中心" prop="zcadz020">
                  <el-input v-model="form.zcadz020" :placeholder="$t('btn.enterPrefix')+'利润中心'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="差异码" prop="zcadz021">
                  <el-input v-model="form.zcadz021" :placeholder="$t('btn.enterPrefix')+'差异码'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批次管理" prop="zcadz022">
                  <el-radio-group v-model="form.zcadz022">
                    <el-radio v-for="item in options.sys_normal_whether" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="制造商零件编号" prop="zcadz023">
                  <el-input v-model="form.zcadz023"
                    :placeholder="$t('btn.enterPrefix')+'制造商零件编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="制造商编号" prop="zcadz024">
                  <el-input v-model="form.zcadz024"
                    :placeholder="$t('btn.enterPrefix')+'制造商编号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评估类" prop="zcadz025">
                  <el-select filterable clearable v-model="form.zcadz025"
                    :placeholder="$t('btn.selectPrefix')+'评估类'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_val_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="移动平均价格/周期单价" prop="zcadz026">
                  <el-input-number v-model.number="form.zcadz026" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'移动平均价格/周期单价'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="币种" prop="zcadz027">
                  <el-select filterable clearable v-model="form.zcadz027"
                    :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="价格控制" prop="zcadz028">
                  <el-input v-model="form.zcadz028" :placeholder="$t('btn.enterPrefix')+'价格控制'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="价格单位" prop="zcadz029">
                  <el-input v-model="form.zcadz029" :placeholder="$t('btn.enterPrefix')+'价格单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="生产仓储" prop="zcadz030">
                  <el-select filterable clearable v-model="form.zcadz030"
                    :placeholder="$t('btn.selectPrefix')+'生产仓储'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_sloc_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="采购仓储" prop="zcadz031">
                  <el-select filterable clearable v-model="form.zcadz031"
                    :placeholder="$t('btn.selectPrefix')+'采购仓储'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_sloc_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="库存仓位" prop="zcadz032">
                  <el-input v-model="form.zcadz032" :placeholder="$t('btn.enterPrefix')+'库存仓位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="库存" prop="zcadz033">
                  <el-input-number v-model.number="form.zcadz033" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'库存'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="状态" prop="zcadz034">
                  <el-radio-group v-model="form.zcadz034">
                    <el-radio v-for="item in options.sys_eol_list" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="软删除" prop="isDeleted">
                  <el-radio-group v-model="form.isDeleted">
                    <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注说明" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建者" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新者" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新时间" prop="updateTime">
                  <el-date-picker v-model="form.updateTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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

<script setup name="ppsourcematerial">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listPpSourceMaterial,
    addPpSourceMaterial, delPpSourceMaterial,
    updatePpSourceMaterial, getPpSourceMaterial,
  }
    from '@/api/logistics/ppsourcematerial.js'
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
    zcadz002: undefined,
    //是否查询（1是）
    zcadz003: undefined,
    //是否查询（1是）
    zcadz004: undefined,
    //是否查询（1是）
    zcadz005: undefined,
    //是否查询（1是）
    zcadz006: undefined,
    //是否查询（1是）
    zcadz008: undefined,
    //是否查询（1是）
    zcadz009: undefined,
    //是否查询（1是）
    zcadz010: undefined,
    //是否查询（1是）
    zcadz011: undefined,
    //是否查询（1是）
    zcadz019: undefined,
    //是否查询（1是）
    zcadz022: undefined,
    //是否查询（1是）
    zcadz025: undefined,
    //是否查询（1是）
    zcadz027: undefined,
    //是否查询（1是）
    zcadz030: undefined,
    //是否查询（1是）
    zcadz031: undefined,
    //是否查询（1是）
    zcadz032: undefined,
    //是否查询（1是）
    zcadz034: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'sfId', label: 'sfId' },
    { visible: true, prop: 'zcadz001', label: 'Plnt' },
    { visible: true, prop: 'zcadz002', label: '品目' },
    { visible: true, prop: 'zcadz003', label: '行业领域' },
    { visible: true, prop: 'zcadz004', label: '物料类型' },
    { visible: true, prop: 'zcadz005', label: '物料描述（短文本）' },
    { visible: true, prop: 'zcadz006', label: '基本单位' },
    { visible: true, prop: 'zcadz007', label: '产品层次' },
    { visible: false, prop: 'zcadz008', label: '物料组' },
    { visible: true, prop: 'zcadz009', label: '采购组' },
    { visible: false, prop: 'zcadz010', label: '采购类型' },
    { visible: false, prop: 'zcadz011', label: '特殊采购类' },
    { visible: false, prop: 'zcadz012', label: '散装物料' },
    { visible: false, prop: 'zcadz013', label: '最小起订量' },
    { visible: false, prop: 'zcadz014', label: '基本单位' },
    { visible: false, prop: 'zcadz015', label: '舍入值' },
    { visible: false, prop: 'zcadz016', label: '基本单位' },
    { visible: false, prop: 'zcadz017', label: '计划交货' },
    { visible: false, prop: 'zcadz018', label: '自制天数' },
    { visible: false, prop: 'zcadz019', label: '过账检验' },
    { visible: false, prop: 'zcadz020', label: '利润中心' },
    { visible: false, prop: 'zcadz021', label: '差异码' },
    { visible: false, prop: 'zcadz022', label: '批次管理' },
    { visible: false, prop: 'zcadz023', label: '制造商零件编号' },
    { visible: false, prop: 'zcadz024', label: '制造商编号' },
    { visible: false, prop: 'zcadz025', label: '评估类' },
    { visible: false, prop: 'zcadz026', label: '移动平均价格/周期单价' },
    { visible: false, prop: 'zcadz027', label: '币种' },
    { visible: false, prop: 'zcadz028', label: '价格控制' },
    { visible: false, prop: 'zcadz029', label: '价格单位' },
    { visible: false, prop: 'zcadz030', label: '生产仓储' },
    { visible: true, prop: 'zcadz031', label: '采购仓储' },
    { visible: false, prop: 'zcadz032', label: '库存仓位' },
    { visible: true, prop: 'zcadz033', label: '库存' },
    { visible: false, prop: 'zcadz034', label: '状态' },
    { visible: false, prop: 'remark', label: '备注说明' },
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
  //字典参数
  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sys_ind_type" },
    { dictType: "sys_matl_type" },
    { dictType: "sys_unit_list" },
    { dictType: "sys_matl_group" },
    { dictType: "sys_pur_group" },
    { dictType: "sys_pur_type" },
    { dictType: "sys_pur_spec" },
    { dictType: "sys_normal_whether" },
    { dictType: "sys_val_type" },
    { dictType: "sys_ccy_type" },
    { dictType: "sys_sloc_list" },
    { dictType: "sys_eol_list" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从源物料/pp_source_material表记录数据
  function getList() {
    loading.value = true
    listPpSourceMaterial(queryParams).then(res => {
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
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.sfId);
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
      sfId: [{ required: true, message: "sfId" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      zcadz002: [{ required: true, message: "品目" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      zcadz013: [{ required: true, message: "最小起订量" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      zcadz015: [{ required: true, message: "舍入值" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      zcadz018: [{ required: true, message: "自制天数" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      zcadz026: [{ required: true, message: "移动平均价格/周期单价" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      zcadz033: [{ required: true, message: "库存" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // Plnt 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 行业领域 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ind_type: [],
      // 物料类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_matl_type: [],
      // 基本单位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_unit_list: [],
      // 物料组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_matl_group: [],
      // 采购组 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_group: [],
      // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_type: [],
      // 特殊采购类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pur_spec: [],
      // 散装物料 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_normal_whether: [],
      // 评估类 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_val_type: [],
      // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
      // 生产仓储 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_sloc_list: [],
      // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_eol_list: [],
      // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_deleted: [],
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
      sfId: 0,
      zcadz001: null,
      zcadz002: null,
      zcadz003: null,
      zcadz004: null,
      zcadz005: null,
      zcadz006: null,
      zcadz007: null,
      zcadz008: null,
      zcadz009: null,
      zcadz010: null,
      zcadz011: null,
      zcadz012: null,
      zcadz013: 0,
      zcadz014: null,
      zcadz015: 0,
      zcadz016: null,
      zcadz017: null,
      zcadz018: 0,
      zcadz019: null,
      zcadz020: null,
      zcadz021: null,
      zcadz022: null,
      zcadz023: null,
      zcadz024: null,
      zcadz025: null,
      zcadz026: 0,
      zcadz027: null,
      zcadz028: null,
      zcadz029: null,
      zcadz030: null,
      zcadz031: null,
      zcadz032: null,
      zcadz033: 0,
      zcadz034: null,
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
    title.value = proxy.$t('btn.add') + " " + '源物料'
    opertype.value = 1
    form.value.zcadz001 = []
    form.value.zcadz003 = []
    form.value.zcadz004 = []
    form.value.zcadz006 = []
    form.value.zcadz008 = []
    form.value.zcadz009 = []
    form.value.zcadz010 = []
    form.value.zcadz011 = []
    form.value.zcadz012 = []
    form.value.zcadz013 = 0
    form.value.zcadz015 = 0
    form.value.zcadz018 = 0
    form.value.zcadz019 = 0
    form.value.zcadz022 = 0
    form.value.zcadz025 = []
    form.value.zcadz026 = 0
    form.value.zcadz027 = []
    form.value.zcadz030 = []
    form.value.zcadz031 = []
    form.value.zcadz033 = 0
    form.value.zcadz034 = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.sfId || ids.value
    getPpSourceMaterial(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '源物料'
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

        if (form.value.sfId != undefined && opertype.value === 2) {
          updatePpSourceMaterial(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addPpSourceMaterial(form.value).then((res) => {
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
    const Ids = row.sfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delPpSourceMaterial(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<源物料.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/PpSourceMaterial/export', { ...queryParams })
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