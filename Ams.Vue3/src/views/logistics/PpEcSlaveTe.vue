<!--
 * @Descripttion: Te设变/pp_ec_slave_te
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/31 15:39:03
 * @column：46
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="设变No." prop="teEcNo">
        <el-input v-model="queryParams.teEcNo" :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="机种" prop="teModel">
        <el-input v-model="queryParams.teModel" :placeholder="$t('btn.enterSearchPrefix')+'机种'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="物料" prop="teItem">
        <el-input v-model="queryParams.teItem" :placeholder="$t('btn.enterSearchPrefix')+'物料'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="采购类型" prop="tePurType">
        <el-select filterable clearable   v-model="queryParams.tePurType" :placeholder="$t('btn.selectSearchPrefix')+'采购类型'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_pur_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="仓库" prop="teSloc">
        <el-select filterable clearable   v-model="queryParams.teSloc" :placeholder="$t('btn.selectSearchPrefix')+'仓库'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_sloc_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="检验否" prop="teInsmk">
        <el-select filterable clearable   v-model="queryParams.teInsmk" :placeholder="$t('btn.selectSearchPrefix')+'检验否'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工厂状态" prop="tePlntStated">
        <el-select filterable clearable   v-model="queryParams.tePlntStated" :placeholder="$t('btn.selectSearchPrefix')+'工厂状态'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_eol_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="SOP" prop="teSopStated">
        <el-select filterable clearable   v-model="queryParams.teSopStated" :placeholder="$t('btn.selectSearchPrefix')+'SOP'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_flag_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['pp:ecslavete:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:ecslavete:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:ecslavete:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['pp:ecslavete:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Logistics/PpEcSlaveTe/importTemplate"
                  importUrl="/Logistics/PpEcSlaveTe/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['pp:ecslavete:export']">
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
      <el-table-column prop="teSfid" label="ID" align="center" v-if="columns.showColumn('teSfid')"/>
      <el-table-column prop="teParentSfid" label="父ID" align="center" v-if="columns.showColumn('teParentSfid')"/>
      <el-table-column prop="teEcNo" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teEcNo')"/>
      <el-table-column prop="teModel" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teModel')"/>
      <el-table-column prop="teItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teItem')"/>
      <el-table-column prop="teSubItem" label="子物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teSubItem')"/>
      <el-table-column prop="teOldItem" label="旧物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teOldItem')"/>
      <el-table-column prop="teOldItemText" label="旧文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teOldItemText')"/>
      <el-table-column prop="teOldCurrStock" label="旧品库存" align="center" v-if="columns.showColumn('teOldCurrStock')"/>
      <el-table-column prop="teOldUsageQty" label="用量" align="center" v-if="columns.showColumn('teOldUsageQty')"/>
      <el-table-column prop="teOldSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teOldSetLoc')"/>
      <el-table-column prop="teNewItem" label="新物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teNewItem')"/>
      <el-table-column prop="teNewItemText" label="新文本" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teNewItemText')"/>
      <el-table-column prop="teNewCurrStock" label="新品库存" align="center" v-if="columns.showColumn('teNewCurrStock')"/>
      <el-table-column prop="teNewUsageQty" label="用量" align="center" v-if="columns.showColumn('teNewUsageQty')"/>
      <el-table-column prop="teNewSetLoc" label="位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teNewSetLoc')"/>
      <el-table-column prop="teBomNo" label="bom番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teBomNo')"/>
      <el-table-column prop="teChange" label="互换" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teChange')"/>
      <el-table-column prop="teDistLocal" label="区分" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teDistLocal')"/>
      <el-table-column prop="teInstNote" label="指示" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teInstNote')"/>
      <el-table-column prop="teOldProcess" label="旧品处理" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('teOldProcess')"/>
      <el-table-column prop="teBomDate" label="bom日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('teBomDate')"/>
      <el-table-column prop="tePurType" label="采购类型" align="center" v-if="columns.showColumn('tePurType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_pur_type " :value="scope.row.tePurType"  />
        </template>
      </el-table-column>
      <el-table-column prop="teSloc" label="仓库" align="center" v-if="columns.showColumn('teSloc')">
        <template #default="scope">
          <dict-tag :options=" options.sys_sloc_list " :value="scope.row.teSloc"  />
        </template>
      </el-table-column>
      <el-table-column prop="teInsmk" label="检验否" align="center" v-if="columns.showColumn('teInsmk')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.teInsmk"  />
        </template>
      </el-table-column>
      <el-table-column prop="tePlntStated" label="工厂状态" align="center" v-if="columns.showColumn('tePlntStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_eol_list " :value="scope.row.tePlntStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="teSopStated" label="SOP" align="center" v-if="columns.showColumn('teSopStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.teSopStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="teImplStated" label="实施标记" align="center" v-if="columns.showColumn('teImplStated')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.teImplStated"  />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:ecslavete:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:ecslavete:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改Te设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="ID" prop="teSfid">
              <el-input-number v-model.number="form.teSfid" controls-position="right" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')" :disabled="true"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="父ID" prop="teParentSfid">
              <el-input v-model.number="form.teParentSfid" :placeholder="$t('btn.enterPrefix')+'父ID'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变No." prop="teEcNo">
              <el-input v-model="form.teEcNo" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="teModel">
              <el-input v-model="form.teModel" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="teItem">
              <el-input v-model="form.teItem" :placeholder="$t('btn.enterPrefix')+'物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="子物料" prop="teSubItem">
              <el-input v-model="form.teSubItem" :placeholder="$t('btn.enterPrefix')+'子物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧物料" prop="teOldItem">
              <el-input v-model="form.teOldItem" :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧文本" prop="teOldItemText">
              <el-input v-model="form.teOldItemText" :placeholder="$t('btn.enterPrefix')+'旧文本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品库存" prop="teOldCurrStock">
              <el-input-number v-model.number="form.teOldCurrStock" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'旧品库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="teOldUsageQty">
              <el-input-number v-model.number="form.teOldUsageQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="teOldSetLoc">
              <el-input v-model="form.teOldSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新物料" prop="teNewItem">
              <el-input v-model="form.teNewItem" :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新文本" prop="teNewItemText">
              <el-input v-model="form.teNewItemText" :placeholder="$t('btn.enterPrefix')+'新文本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="新品库存" prop="teNewCurrStock">
              <el-input-number v-model.number="form.teNewCurrStock" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'新品库存'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用量" prop="teNewUsageQty">
              <el-input-number v-model.number="form.teNewUsageQty" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'用量'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="位置" prop="teNewSetLoc">
              <el-input v-model="form.teNewSetLoc" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom番号" prop="teBomNo">
              <el-input v-model="form.teBomNo" :placeholder="$t('btn.enterPrefix')+'bom番号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="互换" prop="teChange">
              <el-input v-model="form.teChange" :placeholder="$t('btn.enterPrefix')+'互换'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="区分" prop="teDistLocal">
              <el-input v-model="form.teDistLocal" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="指示" prop="teInstNote">
              <el-input v-model="form.teInstNote" :placeholder="$t('btn.enterPrefix')+'指示'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="旧品处理" prop="teOldProcess">
              <el-input v-model="form.teOldProcess" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="bom日期" prop="teBomDate">
              <el-date-picker v-model="form.teBomDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="采购类型" prop="tePurType">
              <el-select filterable clearable   v-model="form.tePurType"  :placeholder="$t('btn.selectPrefix')+'采购类型'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_pur_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="仓库" prop="teSloc">
              <el-select filterable clearable   v-model="form.teSloc"  :placeholder="$t('btn.selectPrefix')+'仓库'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_sloc_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="检验否" prop="teInsmk">
              <el-select filterable clearable   v-model="form.teInsmk"  :placeholder="$t('btn.selectPrefix')+'检验否'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="工厂状态" prop="tePlntStated">
              <el-select filterable clearable   v-model="form.tePlntStated"  :placeholder="$t('btn.selectPrefix')+'工厂状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_eol_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="SOP" prop="teSopStated">
              <el-select filterable clearable   v-model="form.teSopStated"  :placeholder="$t('btn.selectPrefix')+'SOP'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="实施标记" prop="teImplStated">
              <el-select filterable clearable   v-model="form.teImplStated"  :placeholder="$t('btn.selectPrefix')+'实施标记'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_flag_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
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

<script setup name="ppecslavete">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listPpEcSlaveTe,
 addPpEcSlaveTe, delPpEcSlaveTe, 
 updatePpEcSlaveTe,getPpEcSlaveTe, 
 } 
from '@/api/logistics/ppecslavete.js'
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
  teEcNo: undefined,
//是否查询（1是）
  teModel: undefined,
//是否查询（1是）
  teItem: undefined,
//是否查询（1是）
  tePurType: undefined,
//是否查询（1是）
  teSloc: undefined,
//是否查询（1是）
  teInsmk: undefined,
//是否查询（1是）
  tePlntStated: undefined,
//是否查询（1是）
  teSopStated: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'teSfid', label: 'ID' },
  { visible: true, prop: 'teParentSfid', label: '父ID' },
  { visible: true, prop: 'teEcNo', label: '设变No.' },
  { visible: true, prop: 'teModel', label: '机种' },
  { visible: true, prop: 'teItem', label: '物料' },
  { visible: true, prop: 'teSubItem', label: '子物料' },
  { visible: true, prop: 'teOldItem', label: '旧物料' },
  { visible: true, prop: 'teOldItemText', label: '旧文本' },
  { visible: false, prop: 'teOldCurrStock', label: '旧品库存' },
  { visible: false, prop: 'teOldUsageQty', label: '用量' },
  { visible: false, prop: 'teOldSetLoc', label: '位置' },
  { visible: false, prop: 'teNewItem', label: '新物料' },
  { visible: false, prop: 'teNewItemText', label: '新文本' },
  { visible: false, prop: 'teNewCurrStock', label: '新品库存' },
  { visible: false, prop: 'teNewUsageQty', label: '用量' },
  { visible: false, prop: 'teNewSetLoc', label: '位置' },
  { visible: false, prop: 'teBomNo', label: 'bom番号' },
  { visible: false, prop: 'teChange', label: '互换' },
  { visible: false, prop: 'teDistLocal', label: '区分' },
  { visible: false, prop: 'teInstNote', label: '指示' },
  { visible: false, prop: 'teOldProcess', label: '旧品处理' },
  { visible: false, prop: 'teBomDate', label: 'bom日期' },
  { visible: false, prop: 'tePurType', label: '采购类型' },
  { visible: false, prop: 'teSloc', label: '仓库' },
  { visible: false, prop: 'teInsmk', label: '检验否' },
  { visible: false, prop: 'tePlntStated', label: '工厂状态' },
  { visible: false, prop: 'teSopStated', label: 'SOP' },
  { visible: false, prop: 'teImplStated', label: '实施标记' },
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

//字典参数
var dictParams = [
  { dictType: "sys_pur_type" },
  { dictType: "sys_sloc_list" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_eol_list" },
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从Te设变/pp_ec_slave_te表记录数据
function getList(){
  loading.value = true
  listPpEcSlaveTe(queryParams).then(res => {
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
  ids.value = selection.map((item) => item.teSfid);
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
    tePurType: [{ required: true, message: "采购类型"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    teSloc: [{ required: true, message: "仓库"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    teSopStated: [{ required: true, message: "SOP"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    teImplStated: [{ required: true, message: "实施标记"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 采购类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_pur_type: [],
    // 仓库 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_sloc_list: [],
    // 检验否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_flag_list: [],
    // 工厂状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_eol_list: [],
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
    teSfid: 0,
    teParentSfid: 0,
    teEcNo: null,
    teModel: null,
    teItem: null,
    teSubItem: null,
    teOldItem: null,
    teOldItemText: null,
    teOldCurrStock: 0,
    teOldUsageQty: 0,
    teOldSetLoc: null,
    teNewItem: null,
    teNewItemText: null,
    teNewCurrStock: 0,
    teNewUsageQty: 0,
    teNewSetLoc: null,
    teBomNo: null,
    teChange: null,
    teDistLocal: null,
    teInstNote: null,
    teOldProcess: null,
    teBomDate: null,
    tePurType: null,
    teSloc: null,
    teInsmk: null,
    tePlntStated: null,
    teSopStated: 0,
    teImplStated: 0,
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
  title.value = proxy.$t('btn.add')+" "+'Te设变'
  opertype.value = 1
  form.value.teOldCurrStock= 0
  form.value.teOldUsageQty= 0
  form.value.teNewCurrStock= 0
  form.value.teNewUsageQty= 0
  form.value.teBomDate= new Date()
  form.value.tePurType= []
  form.value.teSloc= []
  form.value.teInsmk= []
  form.value.tePlntStated= []
  form.value.teSopStated= 0
  form.value.teImplStated= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.teSfid || ids.value
  getPpEcSlaveTe(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ 'Te设变'
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

      if (form.value.teSfid != undefined && opertype.value === 2) {
        updatePpEcSlaveTe(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addPpEcSlaveTe(form.value).then((res) => {
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
  const Ids = row.teSfid || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delPpEcSlaveTe(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<Te设变.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Logistics/PpEcSlaveTe/export', { ...queryParams })
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