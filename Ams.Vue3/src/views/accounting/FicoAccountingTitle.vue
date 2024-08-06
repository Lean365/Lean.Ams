<!--
 * @Descripttion: 会计科目/fico_accounting_title
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/6 12:02:48
 * @column：39
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="公司代码" prop="bukrs">
            <el-select filterable clearable v-model="queryParams.bukrs"
              :placeholder="$t('btn.selectSearchPrefix')+'公司代码'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_crop_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="币种" prop="waers">
            <el-select filterable clearable v-model="queryParams.waers"
              :placeholder="$t('btn.selectSearchPrefix')+'币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="科目编号" prop="saknr">
            <el-input v-model="queryParams.saknr"
              :placeholder="$t('btn.enterSearchPrefix')+'科目编号'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="BS类别" prop="xbilk">
            <el-radio-group v-model="queryParams.xbilk">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_flag_list " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="PL类别" prop="gvtyp">
            <el-select filterable clearable v-model="queryParams.gvtyp"
              :placeholder="$t('btn.selectSearchPrefix')+'PL类别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_pl_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="统驭类别" prop="mitkz">
            <el-select filterable clearable v-model="queryParams.mitkz"
              :placeholder="$t('btn.selectSearchPrefix')+'统驭类别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_conrol_title " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="短文本" prop="stext">
            <el-input v-model="queryParams.stext"
              :placeholder="$t('btn.enterSearchPrefix')+'短文本'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="长文本" prop="ltext">
            <el-input v-model="queryParams.ltext"
              :placeholder="$t('btn.enterSearchPrefix')+'长文本'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="冻结" prop="xspea">
            <el-radio-group v-model="queryParams.xspea">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue"
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
        <el-button class="btn-add" v-hasPermi="['fico:accountingtitle:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['fico:accountingtitle:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['fico:accountingtitle:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['fico:accountingtitle:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Accounting/FicoAccountingTitle/importTemplate"
                  importUrl="/Accounting/FicoAccountingTitle/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['fico:accountingtitle:export']">
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
      <el-table-column prop="fatSfId" label="ID" align="center" v-if="columns.showColumn('fatSfId')" />
      <el-table-column prop="mandt" label="集团" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mandt')" />
      <el-table-column prop="bukrs" label="公司代码" align="center" v-if="columns.showColumn('bukrs')">
        <template #default="scope">
          <dict-tag :options=" options.sys_crop_list " :value="scope.row.bukrs" />
        </template>
      </el-table-column>
      <el-table-column prop="waers" label="币种" align="center" v-if="columns.showColumn('waers')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.waers" />
        </template>
      </el-table-column>
      <el-table-column prop="spras" label="语言Key" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('spras')" />
      <el-table-column prop="saknr" label="科目编号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('saknr')" />
      <el-table-column prop="ktopl" label="科目表" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ktopl')" />
      <el-table-column prop="xbilk" label="BS类别" align="center" v-if="columns.showColumn('xbilk')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.xbilk" />
        </template>
      </el-table-column>
      <el-table-column prop="gvtyp" label="PL类别" align="center" v-if="columns.showColumn('gvtyp')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pl_type " :value="scope.row.gvtyp" />
        </template>
      </el-table-column>
      <el-table-column prop="mitkz" label="统驭类别" align="center" v-if="columns.showColumn('mitkz')">
        <template #default="scope">
          <dict-tag :options=" options.sys_conrol_title " :value="scope.row.mitkz" />
        </template>
      </el-table-column>
      <el-table-column prop="stext" label="短文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('stext')" />
      <el-table-column prop="ltext" label="长文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ltext')" />
      <el-table-column prop="atext" label="附加文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('atext')" />
      <el-table-column prop="ktoks" label="科目组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('ktoks')" />
      <el-table-column prop="xspea" label="冻结" align="center" v-if="columns.showColumn('xspea')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.xspea" />
        </template>
      </el-table-column>
      <el-table-column prop="rEF01" label="预留A" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF01')" />
      <el-table-column prop="rEF02" label="预留B" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF02')" />
      <el-table-column prop="rEF03" label="预留C" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF03')" />
      <el-table-column prop="rEF04" label="预留1" align="center" v-if="columns.showColumn('rEF04')" />
      <el-table-column prop="rEF05" label="预留2" align="center" v-if="columns.showColumn('rEF05')" />
      <el-table-column prop="rEF06" label="预留3 " align="center" v-if="columns.showColumn('rEF06')" />
      <el-table-column prop="remark" label="备注说明 " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['fico:accountingtitle:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['fico:accountingtitle:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改会计科目对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <!-- <el-col :lg="12">
                <el-form-item label="ID" prop="fatSfId">
                  <el-input v-model.number="form.fatSfId"
                    :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col> -->

              <el-col :lg="12">
                <el-form-item label="集团" prop="mandt">
                  <el-input v-model="form.mandt" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="公司代码" prop="bukrs">
                  <el-select filterable clearable v-model="form.bukrs"
                    :placeholder="$t('btn.selectPrefix')+'公司代码'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_crop_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="币种" prop="waers">
                  <el-select filterable clearable v-model="form.waers"
                    :placeholder="$t('btn.selectPrefix')+'币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="语言Key" prop="spras">
                  <el-input v-model="form.spras" :placeholder="$t('btn.enterPrefix')+'语言Key'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="100" :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="科目编号" prop="saknr">
                  <el-input v-model="form.saknr" :placeholder="$t('btn.enterPrefix')+'科目编号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" @input="handleSaknrInput" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="科目表" prop="ktopl">
                  <el-input v-model="form.ktopl" :placeholder="$t('btn.enterPrefix')+'科目表'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="BS类别" prop="xbilk">
                  <el-radio-group v-model="form.xbilk">
                    <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue" :value="item.dictValue">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="PL类别" prop="gvtyp">
                  <el-select filterable clearable v-model="form.gvtyp"
                    :placeholder="$t('btn.selectPrefix')+'PL类别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_pl_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="统驭类别" prop="mitkz">
                  <el-select filterable clearable v-model="form.mitkz"
                    :placeholder="$t('btn.selectPrefix')+'统驭类别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_conrol_title" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="短文本" prop="stext">
                  <el-input v-model="form.stext" :placeholder="$t('btn.enterPrefix')+'短文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" @input="handleStextInput" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="长文本" prop="ltext">
                  <el-input v-model="form.ltext" :placeholder="$t('btn.enterPrefix')+'长文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="80" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="附加文本" prop="atext">
                  <el-input v-model="form.atext" :placeholder="$t('btn.enterPrefix')+'附加文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="100" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="科目组" prop="ktoks">
                  <el-input v-model="form.ktoks" :placeholder="$t('btn.enterPrefix')+'科目组'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" :disabled="opertype != 3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="冻结" prop="xspea">
                  <el-radio-group v-model="form.xspea">
                    <el-radio v-for="item in options.sys_is_status" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="备注说明 " prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注说明 '+$t('btn.enterSuffix')" show-word-limit
                    maxlength="500" />
                </el-form-item>
              </el-col>


            </el-row>
          </el-tab-pane>



          <el-tab-pane :label="$t('ptabs.content')" name="fifth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="预留A" prop="rEF01">
                  <el-input v-model="form.rEF01" :placeholder="$t('btn.enterPrefix')+'预留A'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留B" prop="rEF02">
                  <el-input v-model="form.rEF02" :placeholder="$t('btn.enterPrefix')+'预留B'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留C" prop="rEF03">
                  <el-input v-model="form.rEF03" :placeholder="$t('btn.enterPrefix')+'预留C'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="30" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留1" prop="rEF04">
                  <el-input-number v-model.number="form.rEF04" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="预留2" prop="rEF05">
                  <el-input-number v-model.number="form.rEF05" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留3 " prop="rEF06">
                  <el-input-number v-model.number="form.rEF06" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留3 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.customization')" name="16th">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="自定义A" prop="uDF01">
                  <el-input v-model="form.uDF01" :placeholder="$t('btn.enterPrefix')+'自定义A'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义B" prop="uDF02">
                  <el-input v-model="form.uDF02" :placeholder="$t('btn.enterPrefix')+'自定义B'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义C" prop="uDF03">
                  <el-input v-model="form.uDF03" :placeholder="$t('btn.enterPrefix')+'自定义C'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义D" prop="uDF04">
                  <el-input v-model="form.uDF04" :placeholder="$t('btn.enterPrefix')+'自定义D'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义E" prop="uDF05">
                  <el-input v-model="form.uDF05" :placeholder="$t('btn.enterPrefix')+'自定义E'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义F" prop="uDF06">
                  <el-input v-model="form.uDF06" :placeholder="$t('btn.enterPrefix')+'自定义F'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="500" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义1" prop="uDF51">
                  <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2" prop="uDF52">
                  <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3" prop="uDF53">
                  <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4" prop="uDF54">
                  <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5" prop="uDF55">
                  <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6" prop="uDF56">
                  <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.oper')" name="17th">
            <el-row :gutter="20">
              <el-col :lg="24">
                <el-form-item label="软删除 " prop="isDeleted">
                  <el-radio-group v-model="form.isDeleted">
                    <el-radio v-for="item in options.sys_is_deleted" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>
              <el-col :lg="12">
                <el-form-item label="创建人员" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建人员'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
                  <el-date-picker v-model="form.createTime" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新人员" prop="updateBy">
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新人员'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="255" />
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
        </el-tabs>


      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ficoaccountingtitle">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listFicoAccountingTitle,
    addFicoAccountingTitle, delFicoAccountingTitle,
    updateFicoAccountingTitle, getFicoAccountingTitle,
  }
    from '@/api/accounting/ficoaccountingtitle.js'
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
    sort: 'Saknr',
    sortType: 'asc',
    //是否查询（1是）
    bukrs: undefined,
    //是否查询（1是）
    waers: undefined,
    //是否查询（1是）
    saknr: undefined,
    //是否查询（1是）
    xbilk: undefined,
    //是否查询（1是）
    gvtyp: undefined,
    //是否查询（1是）
    mitkz: undefined,
    //是否查询（1是）
    stext: undefined,
    //是否查询（1是）
    ltext: undefined,
    //是否查询（1是）
    xspea: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: false, prop: 'fatSfId', label: 'ID' },
    { visible: true, prop: 'mandt', label: '集团' },
    { visible: true, prop: 'bukrs', label: '公司代码' },
    { visible: true, prop: 'waers', label: '币种' },
    { visible: true, prop: 'spras', label: '语言Key' },
    { visible: true, prop: 'saknr', label: '科目编号' },
    { visible: true, prop: 'ktopl', label: '科目表' },
    { visible: true, prop: 'xbilk', label: 'BS类别' },
    { visible: true, prop: 'gvtyp', label: 'PL类别' },
    { visible: true, prop: 'mitkz', label: '统驭类别' },
    { visible: true, prop: 'stext', label: '短文本' },
    { visible: true, prop: 'ltext', label: '长文本' },
    { visible: true, prop: 'atext', label: '附加文本' },
    { visible: true, prop: 'ktoks', label: '科目组' },
    { visible: true, prop: 'xspea', label: '冻结' },
    { visible: false, prop: 'rEF01', label: '预留A' },
    { visible: false, prop: 'rEF02', label: '预留B' },
    { visible: false, prop: 'rEF03', label: '预留C' },
    { visible: false, prop: 'rEF04', label: '预留1' },
    { visible: false, prop: 'rEF05', label: '预留2' },
    { visible: false, prop: 'rEF06', label: '预留3 ' },
    { visible: false, prop: 'remark', label: '备注说明 ' },
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
    { dictType: "sys_crop_list" },
    { dictType: "sys_ccy_type" },
    { dictType: "sys_flag_list" },
    { dictType: "sys_pl_type" },
    { dictType: "sys_conrol_title" },
    { dictType: "sys_is_status" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从会计科目/fico_accounting_title表记录数据
  function getList() {
    loading.value = true
    listFicoAccountingTitle(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.fatSfId);
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
      fatSfId: [{ required: true, message: "ID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mandt: [{ required: true, message: "集团" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      bukrs: [{ required: true, message: "公司代码" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      waers: [{ required: true, message: "币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      saknr: [{ required: true, message: "科目编号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      xspea: [{ required: true, message: "冻结" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 公司代码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_crop_list: [],
      // 币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
      // BS类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_flag_list: [],
      // PL类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_pl_type: [],
      // 统驭类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_conrol_title: [],
      // 冻结 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_status: [],
      // 软删除  选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
      fatSfId: 0,
      mandt: null,
      bukrs: null,
      waers: null,
      spras: null,
      saknr: null,
      ktopl: null,
      xbilk: null,
      gvtyp: null,
      mitkz: null,
      stext: null,
      ltext: null,
      atext: null,
      ktoks: null,
      xspea: 0,
      rEF01: null,
      rEF02: null,
      rEF03: null,
      rEF04: 0,
      rEF05: 0,
      rEF06: 0,
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
    title.value = proxy.$t('btn.add') + " " + '会计科目'
    opertype.value = 1
    form.value.mandt = '100'
    form.value.bukrs = []
    form.value.waers = []
    form.value.ktopl = 'TEAC'
    form.value.xbilk = 'O'
    form.value.gvtyp = []
    form.value.mitkz = []
    form.value.ktoks = 'Z001'
    form.value.xspea = 0
    form.value.rEF04 = 0
    form.value.rEF05 = 0
    form.value.rEF06 = 0
  }
  //赋值
  function handleSaknrInput() {
    form.value.spras = 'dict.acc_title_list.' + form.value.saknr
  }
  function handleStextInput() {
    form.value.ltext = form.value.stext
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.fatSfId || ids.value
    getFicoAccountingTitle(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '会计科目'
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

        if (form.value.fatSfId != undefined && opertype.value === 2) {
          updateFicoAccountingTitle(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addFicoAccountingTitle(form.value).then((res) => {
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
    const Ids = row.fatSfId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delFicoAccountingTitle(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<会计科目.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Accounting/FicoAccountingTitle/export', { ...queryParams })
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