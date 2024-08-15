<!--
 * @Descripttion: 主源设变/pp_source_ec_ma
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/18 15:08:51
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="设变No." prop="zpabdz001">
            <el-input v-model="queryParams.zpabdz001"
              :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="标题" prop="zpabdz003">
            <el-input v-model="queryParams.zpabdz003"
              :placeholder="$t('btn.enterSearchPrefix')+'标题'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="状态" prop="zpabdz004">
            <el-select filterable clearable v-model="queryParams.zpabdz004"
              :placeholder="$t('btn.selectSearchPrefix')+'状态'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ec_status " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="发行日">
            <el-date-picker v-model="dateRangeZpabdz005" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="处理标记" prop="isSolved">
            <el-radio-group v-model="queryParams.isSolved">
              <el-radio>{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_normal_whether " :key="item.dictValue"
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
        <el-button class="btn-add" v-hasPermi="['pp:sourceecma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:sourceecma:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:sourceecma:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:sourceecma:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/PpSourceEcMa/importTemplate"
                  importUrl="/Logistics/PpSourceEcMa/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:sourceecma:export']">
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain icon="view" size="small" @click="rowClick(scope.row)"
            :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="sfId" label="sfId" align="center" v-if="columns.showColumn('sfId')" />
      <el-table-column prop="zpabdz001" label="设变No." align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz001')" />
      <el-table-column prop="zpabdz002" label="机种" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz002')" />
      <el-table-column prop="zpabdz003" label="标题" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz003')" />
      <el-table-column prop="zpabdz004" label="状态" align="center" v-if="columns.showColumn('zpabdz004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ec_status " :value="scope.row.zpabdz004" />
        </template>
      </el-table-column>
      <el-table-column prop="zpabdz005" label="发行日" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz005')" />
      <el-table-column prop="zpabdz006" label="担当" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz006')" />
      <el-table-column prop="zpabdz007" label="依赖" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz007')" />
      <el-table-column prop="zpabdz008" label="会议" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz008')" />
      <el-table-column prop="zpabdz009" label="PP番号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz009')" />
      <el-table-column prop="zpabdz010" label="联络书" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz010')" />
      <el-table-column prop="zpabdz011" label="实施" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz011')" />
      <el-table-column prop="zpabdz012" label="主理由" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz012')" />
      <el-table-column prop="zpabdz013" label="次理由" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz013')" />
      <el-table-column prop="zpabdz014" label="安规" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz014')" />
      <el-table-column prop="zpabdz015" label="状况" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz015')" />
      <el-table-column prop="zpabdz016" label="机番" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz016')" />
      <el-table-column prop="zpabdz017" label="承认" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz017')" />
      <el-table-column prop="zpabdz018" label="服务手册订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz018')" />
      <el-table-column prop="zpabdz019" label="用户手册订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz019')" />
      <el-table-column prop="zpabdz020" label="宣传手册订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz020')" />
      <el-table-column prop="zpabdz021" label="SOP订正" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz021')" />
      <el-table-column prop="zpabdz022" label="信息发行" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz022')" />
      <el-table-column prop="zpabdz023" label="成本变动" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz023')" />
      <el-table-column prop="zpabdz024" label="单位成本" align="center" v-if="columns.showColumn('zpabdz024')" />
      <el-table-column prop="zpabdz025" label="模具改造费" align="center" v-if="columns.showColumn('zpabdz025')" />
      <el-table-column prop="zpabdz026" label="图纸" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz026')" />
      <el-table-column prop="zpabdz027" label="设变内容" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('zpabdz027')" />
      <el-table-column prop="isSolved" label="处理标记" align="center" v-if="columns.showColumn('isSolved')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.isSolved" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true"
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
              v-hasPermi="['pp:sourceecma:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['pp:sourceecma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppSourceEcSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="sfId" label="sfId" />
        <el-table-column prop="parentsfId" label="父ID" />
        <el-table-column prop="zpabds001" label="设变No." />
        <el-table-column prop="zpabds002" label="完成品" />
        <el-table-column prop="zpabds003" label="上阶" />
        <el-table-column prop="zpabds004" label="旧物料" />
        <el-table-column prop="zpabds005" label="品名" />
        <el-table-column prop="zpabds006" label="数量" />
        <el-table-column prop="zpabds007" label="位置" />
        <el-table-column prop="zpabds008" label="新物料" />
        <el-table-column prop="zpabds009" label="品名" />
        <el-table-column prop="zpabds010" label="数量" />
        <el-table-column prop="zpabds011" label="位置" />
        <el-table-column prop="zpabds012" label="BOM番号" />
        <el-table-column prop="zpabds013" label="互换性" />
        <el-table-column prop="zpabds014" label="区分" />
        <el-table-column prop="zpabds015" label="安排指示" />
        <el-table-column prop="zpabds016" label="旧品处理" />
        <el-table-column prop="zpabds017" label="BOM生效" />
        <el-table-column prop="isSolved" label="处理标记">
          <template #default="scope">
            <dict-tag :options=" options.sys_normal_whether " :value="scope.row.isSolved" />
          </template>
        </el-table-column>
        <el-table-column prop="remark" label="备注" />
        <el-table-column prop="createBy" label="创建者" />
        <el-table-column prop="createTime" label="创建时间" />
        <el-table-column prop="updateBy" label="更新者" />
        <el-table-column prop="updateTime" label="更新时间" />
      </el-table>
    </el-drawer>
    <!-- 添加或修改主源设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12" v-if="opertype != 1">
                <el-form-item label="sfId" prop="sfId">
                  <el-input-number v-model.number="form.sfId" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'sfId'+$t('btn.enterSuffix')" :disabled="true" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="设变No." prop="zpabdz001">
                  <el-input v-model="form.zpabdz001"
                    :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="机种" prop="zpabdz002">
                  <el-input v-model="form.zpabdz002" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="标题" prop="zpabdz003">
                  <el-input v-model="form.zpabdz003" :placeholder="$t('btn.enterPrefix')+'标题'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="状态" prop="zpabdz004">
                  <el-select filterable clearable v-model="form.zpabdz004"
                    :placeholder="$t('btn.selectPrefix')+'状态'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ec_status" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="发行日" prop="zpabdz005">
                  <el-date-picker v-model="form.zpabdz005" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="担当" prop="zpabdz006">
                  <el-input v-model="form.zpabdz006" :placeholder="$t('btn.enterPrefix')+'担当'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="依赖" prop="zpabdz007">
                  <el-input v-model="form.zpabdz007" :placeholder="$t('btn.enterPrefix')+'依赖'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="会议" prop="zpabdz008">
                  <el-input v-model="form.zpabdz008" :placeholder="$t('btn.enterPrefix')+'会议'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="PP番号" prop="zpabdz009">
                  <el-input v-model="form.zpabdz009"
                    :placeholder="$t('btn.enterPrefix')+'PP番号'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="联络书" prop="zpabdz010">
                  <el-input v-model="form.zpabdz010" :placeholder="$t('btn.enterPrefix')+'联络书'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="实施" prop="zpabdz011">
                  <el-input v-model="form.zpabdz011" :placeholder="$t('btn.enterPrefix')+'实施'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="主理由" prop="zpabdz012">
                  <el-input v-model="form.zpabdz012" :placeholder="$t('btn.enterPrefix')+'主理由'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="次理由" prop="zpabdz013">
                  <el-input v-model="form.zpabdz013" :placeholder="$t('btn.enterPrefix')+'次理由'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="安规" prop="zpabdz014">
                  <el-input v-model="form.zpabdz014" :placeholder="$t('btn.enterPrefix')+'安规'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="状况" prop="zpabdz015">
                  <el-input v-model="form.zpabdz015" :placeholder="$t('btn.enterPrefix')+'状况'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="机番" prop="zpabdz016">
                  <el-input v-model="form.zpabdz016" :placeholder="$t('btn.enterPrefix')+'机番'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="承认" prop="zpabdz017">
                  <el-input v-model="form.zpabdz017" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="服务手册订正" prop="zpabdz018">
                  <el-input v-model="form.zpabdz018"
                    :placeholder="$t('btn.enterPrefix')+'服务手册订正'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="用户手册订正" prop="zpabdz019">
                  <el-input v-model="form.zpabdz019"
                    :placeholder="$t('btn.enterPrefix')+'用户手册订正'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="宣传手册订正" prop="zpabdz020">
                  <el-input v-model="form.zpabdz020"
                    :placeholder="$t('btn.enterPrefix')+'宣传手册订正'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="SOP订正" prop="zpabdz021">
                  <el-input v-model="form.zpabdz021"
                    :placeholder="$t('btn.enterPrefix')+'SOP订正'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="信息发行" prop="zpabdz022">
                  <el-input v-model="form.zpabdz022"
                    :placeholder="$t('btn.enterPrefix')+'信息发行'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="成本变动" prop="zpabdz023">
                  <el-input v-model="form.zpabdz023"
                    :placeholder="$t('btn.enterPrefix')+'成本变动'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="单位成本" prop="zpabdz024">
                  <el-input-number v-model.number="form.zpabdz024" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'单位成本'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="模具改造费" prop="zpabdz025">
                  <el-input-number v-model.number="form.zpabdz025" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'模具改造费'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="图纸" prop="zpabdz026">
                  <el-input v-model="form.zpabdz026" :placeholder="$t('btn.enterPrefix')+'图纸'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="设变内容" prop="zpabdz027">
                  <el-input type="textarea" v-model="form.zpabdz027"
                    :placeholder="$t('btn.enterPrefix')+'设变内容'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="处理标记" prop="isSolved">
                  <el-radio-group v-model="form.isSolved">
                    <el-radio v-for="item in options.sys_normal_whether" :key="item.dictValue" :value="item.dictValue">
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
                <el-form-item label="备注" prop="remark">
                  <el-input type="textarea" v-model="form.remark"
                    :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
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


        <!-- 子表信息 -->
        <el-divider content-position="center">从源设变</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpSourceEcSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpSourceEcSlv">{{ $t('btn.delete')
              }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?
              $t('layout.headerExitfullscreen')
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppSourceEcSlvList" :row-class-name="rowPpSourceEcSlvIndex"
          @selection-change="handlePpSourceEcSlvSelectionChange" ref="PpSourceEcSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50" />
          <el-table-column label="设变No." align="center" prop="zpabds001">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds001"
                :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="完成品" align="center" prop="zpabds002">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds002"
                :placeholder="$t('btn.enterPrefix')+'完成品'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="上阶" align="center" prop="zpabds003">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds003" :placeholder="$t('btn.enterPrefix')+'上阶'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧物料" align="center" prop="zpabds004">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds004"
                :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="品名" align="center" prop="zpabds005">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds005" :placeholder="$t('btn.enterPrefix')+'品名'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="数量" align="center" prop="zpabds006" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.zpabds006" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="zpabds007">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds007" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新物料" align="center" prop="zpabds008">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds008"
                :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="品名" align="center" prop="zpabds009">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds009" :placeholder="$t('btn.enterPrefix')+'品名'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="数量" align="center" prop="zpabds010" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.zpabds010" controls-position="right"
                :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="zpabds011">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds011" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="BOM番号" align="center" prop="zpabds012">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds012"
                :placeholder="$t('btn.enterPrefix')+'BOM番号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="互换性" align="center" prop="zpabds013">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds013"
                :placeholder="$t('btn.enterPrefix')+'互换性'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="区分" align="center" prop="zpabds014">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds014" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="安排指示" align="center" prop="zpabds015">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds015"
                :placeholder="$t('btn.enterPrefix')+'安排指示'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧品处理" align="center" prop="zpabds016">
            <template #default="scope">
              <el-input v-model="scope.row.zpabds016"
                :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="BOM生效" align="center" prop="zpabds017">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.zpabds017" type="date"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="处理标记" prop="isSolved">
            <template #default="scope">
              <el-select filterable clearable v-model="scope.row.isSolved"
                :placeholder="$t('btn.enterPrefix')+'处理标记'+$t('btn.enterSuffix')">
                <el-option v-for="item in options.sys_normal_whether" :key="item.dictValue" :label="item.dictLabel"
                  :value="item.dictValue"></el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="备注" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="创建者" align="center" prop="createBy">
            <template #default="scope">
              <el-input v-model="scope.row.createBy" :placeholder="$t('btn.enterPrefix')+'创建者'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="创建时间" align="center" prop="createTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.createTime" type="date"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="更新者" align="center" prop="updateBy">
            <template #default="scope">
              <el-input v-model="scope.row.updateBy" :placeholder="$t('btn.enterPrefix')+'更新者'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="更新时间" align="center" prop="updateTime">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.updateTime" type="date"
                :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
        </el-table>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ppsourceecma">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listPpSourceEcMa,
    addPpSourceEcMa, delPpSourceEcMa,
    updatePpSourceEcMa, getPpSourceEcMa,
  }
    from '@/api/logistics/ppsourceecma.js'
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
    zpabdz001: undefined,
    //是否查询（1是）
    zpabdz003: undefined,
    //是否查询（1是）
    zpabdz004: undefined,
    //是否查询（1是）
    zpabdz005: undefined,
    //是否查询（1是）
    isSolved: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'sfId', label: 'sfId' },
    { visible: true, prop: 'zpabdz001', label: '设变No.' },
    { visible: true, prop: 'zpabdz002', label: '机种' },
    { visible: true, prop: 'zpabdz003', label: '标题' },
    { visible: true, prop: 'zpabdz004', label: '状态' },
    { visible: true, prop: 'zpabdz005', label: '发行日' },
    { visible: true, prop: 'zpabdz006', label: '担当' },
    { visible: true, prop: 'zpabdz007', label: '依赖' },
    { visible: false, prop: 'zpabdz008', label: '会议' },
    { visible: false, prop: 'zpabdz009', label: 'PP番号' },
    { visible: false, prop: 'zpabdz010', label: '联络书' },
    { visible: false, prop: 'zpabdz011', label: '实施' },
    { visible: false, prop: 'zpabdz012', label: '主理由' },
    { visible: false, prop: 'zpabdz013', label: '次理由' },
    { visible: false, prop: 'zpabdz014', label: '安规' },
    { visible: false, prop: 'zpabdz015', label: '状况' },
    { visible: false, prop: 'zpabdz016', label: '机番' },
    { visible: false, prop: 'zpabdz017', label: '承认' },
    { visible: false, prop: 'zpabdz018', label: '服务手册订正' },
    { visible: false, prop: 'zpabdz019', label: '用户手册订正' },
    { visible: false, prop: 'zpabdz020', label: '宣传手册订正' },
    { visible: false, prop: 'zpabdz021', label: 'SOP订正' },
    { visible: false, prop: 'zpabdz022', label: '信息发行' },
    { visible: false, prop: 'zpabdz023', label: '成本变动' },
    { visible: false, prop: 'zpabdz024', label: '单位成本' },
    { visible: false, prop: 'zpabdz025', label: '模具改造费' },
    { visible: false, prop: 'zpabdz026', label: '图纸' },
    { visible: false, prop: 'zpabdz027', label: '设变内容' },
    { visible: false, prop: 'isSolved', label: '处理标记' },
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







  // 发行日时间范围
  const dateRangeZpabdz005 = ref([])































  //字典参数
  var dictParams = [
    { dictType: "sys_ec_status" },
    { dictType: "sys_normal_whether" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从主源设变/pp_source_ec_ma表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeZpabdz005.value, 'Zpabdz005');
    loading.value = true
    listPpSourceEcMa(queryParams).then(res => {
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
    // 发行日时间范围
    dateRangeZpabdz005.value = []
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
      isSolved: [{ required: true, message: "处理标记" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ec_status: [],
      // 处理标记 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_normal_whether: [],
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
      zpabdz001: null,
      zpabdz002: null,
      zpabdz003: null,
      zpabdz004: null,
      zpabdz005: null,
      zpabdz006: null,
      zpabdz007: null,
      zpabdz008: null,
      zpabdz009: null,
      zpabdz010: null,
      zpabdz011: null,
      zpabdz012: null,
      zpabdz013: null,
      zpabdz014: null,
      zpabdz015: null,
      zpabdz016: null,
      zpabdz017: null,
      zpabdz018: null,
      zpabdz019: null,
      zpabdz020: null,
      zpabdz021: null,
      zpabdz022: null,
      zpabdz023: null,
      zpabdz024: 0,
      zpabdz025: 0,
      zpabdz026: null,
      zpabdz027: null,
      isSolved: null,
      isDeleted: 0,
      remark: null,
      createBy: null,
      createTime: null,
      updateBy: null,
      updateTime: null,
    };
    ppSourceEcSlvList.value = []
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '主源设变'
    opertype.value = 1
    form.value.zpabdz004 = []
    form.value.zpabdz005 = new Date()
    form.value.zpabdz024 = 0
    form.value.zpabdz025 = 0
    form.value.isSolved = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.sfId || ids.value
    getPpSourceEcMa(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '主源设变'
        opertype.value = 2

        form.value = {
          ...data,
        }
        ppSourceEcSlvList.value = res.data.ppSourceEcSlvNav
      }
    })
  }

  // 添加&修改 表单提交
  function submitForm() {
    proxy.$refs["formRef"].validate((valid) => {
      if (valid) {

        form.value.ppSourceEcSlvNav = ppSourceEcSlvList.value
        if (form.value.sfId != undefined && opertype.value === 2) {
          updatePpSourceEcMa(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addPpSourceEcMa(form.value).then((res) => {
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
        return delPpSourceEcMa(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<主源设变.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/PpSourceEcMa/export', { ...queryParams })
      })
  }

  /*********************从源设变子表信息*************************/
  const ppSourceEcSlvList = ref([])
  const checkedPpSourceEcSlv = ref([])
  const fullScreen = ref(false)
  const drawer = ref(false)

  /** 从源设变序号 */
  function rowPpSourceEcSlvIndex({ row, rowIndex }) {
    row.index = rowIndex + 1;
  }

  /** 从源设变添加按钮操作 */
  function handleAddPpSourceEcSlv() {
    let obj = {};
    //下面的代码自己设置默认值
    //obj.zpabds001 = null;
    //obj.zpabds002 = null;
    //obj.zpabds003 = null;
    //obj.zpabds004 = null;
    //obj.zpabds005 = null;
    //obj.zpabds006 = null;
    //obj.zpabds007 = null;
    //obj.zpabds008 = null;
    //obj.zpabds009 = null;
    //obj.zpabds010 = null;
    //obj.zpabds011 = null;
    //obj.zpabds012 = null;
    //obj.zpabds013 = null;
    //obj.zpabds014 = null;
    //obj.zpabds015 = null;
    //obj.zpabds016 = null;
    //obj.zpabds017 = null;
    //obj.isSolved = null;
    //obj.remark = null;
    //obj.createBy = null;
    //obj.createTime = null;
    //obj.updateBy = null;
    //obj.updateTime = null;
    ppSourceEcSlvList.value.push(obj);
  }

  /** 复选框选中数据 */
  function handlePpSourceEcSlvSelectionChange(selection) {
    checkedPpSourceEcSlv.value = selection.map(item => item.index)
  }

  /** 从源设变删除按钮操作 */
  function handleDeletePpSourceEcSlv() {
    if (checkedPpSourceEcSlv.value.length == 0) {
      proxy.$modal.msgError('请先选择要删除的从源设变数据')
    } else {
      const PpSourceEcSlvs = ppSourceEcSlvList.value;
      const checkedPpSourceEcSlvs = checkedPpSourceEcSlv.value;
      ppSourceEcSlvList.value = PpSourceEcSlvs.filter(function (item) {
        return checkedPpSourceEcSlvs.indexOf(item.index) == -1
      });
    }
  }

  /** 从源设变详情 */
  function rowClick(row) {
    const id = row.sfId || ids.value
    getPpSourceEcMa(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        drawer.value = true
        ppSourceEcSlvList.value = data.ppSourceEcSlvNav
      }
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