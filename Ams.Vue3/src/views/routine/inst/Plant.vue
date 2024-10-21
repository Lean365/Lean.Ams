<!--
 * @Descripttion: 工厂代码/inst_plant
 * @Version: 0.24.614.18227
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/5 10:16:10
 * @column：89
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="性质" prop="mc003">
            <el-select filterable clearable v-model="queryParams.mc003"
              :placeholder="$t('btn.selectSearchPrefix')+'性质'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="类别" prop="mc004">
            <el-select filterable clearable v-model="queryParams.mc004"
              :placeholder="$t('btn.selectSearchPrefix')+'类别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="工厂" prop="mc005">
            <el-input v-model="queryParams.mc005"
              :placeholder="$t('btn.enterSearchPrefix')+'工厂'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="名称" prop="mc006">
            <el-input v-model="queryParams.mc006"
              :placeholder="$t('btn.enterSearchPrefix')+'名称'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="评估范围" prop="mc007">
            <el-input v-model="queryParams.mc007"
              :placeholder="$t('btn.enterSearchPrefix')+'评估范围'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="城市" prop="mc015">
            <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_global_city"
              :loading="loading" v-model="queryParams.mc015"
              :placeholder="$t('btn.selectSearchPrefix')+'城市'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   remotequery_sql_global_city " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="采购组织" prop="mc016">
            <el-input v-model="queryParams.mc016"
              :placeholder="$t('btn.enterSearchPrefix')+'采购组织'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="销售组织" prop="mc017">
            <el-input v-model="queryParams.mc017"
              :placeholder="$t('btn.enterSearchPrefix')+'销售组织'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="国家" prop="mc022">
            <el-select filterable clearable v-model="queryParams.mc022"
              :placeholder="$t('btn.selectSearchPrefix')+'国家'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <!-- <el-form-item label="语言" prop="mc031">
        <el-select filterable clearable   v-model="queryParams.mc031" :placeholder="$t('btn.selectSearchPrefix')+'语言'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_lang_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item> -->
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
        <el-button class="btn-add" v-hasPermi="['inst:plant:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['inst:plant:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['inst:plant:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['inst:plant:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Routine/InstPlant/importTemplate" importUrl="/Routine/InstPlant/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['inst:plant:export']">
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
      <el-table-column prop="mc002" label="集团" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc002')" />
      <el-table-column prop="mc003" label="性质" align="center" v-if="columns.showColumn('mc003')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.mc003" />
        </template>
      </el-table-column>
      <el-table-column prop="mc004" label="类别" align="center" v-if="columns.showColumn('mc004')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.mc004" />
        </template>
      </el-table-column>
      <el-table-column prop="mc005" label="工厂" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc005')" />
      <el-table-column prop="mc006" label="名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc006')" />
      <el-table-column prop="mc007" label="评估范围" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc007')" />
      <el-table-column prop="mc008" label="竞争者" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc008')" />
      <el-table-column prop="mc009" label="工厂供应商号码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc009')" />
      <el-table-column prop="mc010" label="日历" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc010')" />
      <el-table-column prop="mc011" label="名称 2" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc011')" />
      <el-table-column prop="mc012" label="住宅号及街道" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc012')" />
      <el-table-column prop="mc013" label="邮政信箱" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc013')" />
      <el-table-column prop="mc014" label="邮政编码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc014')" />
      <el-table-column prop="mc015" label="城市" align="center" v-if="columns.showColumn('mc015')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.mc015" />
        </template>
      </el-table-column>
      <el-table-column prop="mc016" label="采购组织" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc016')" />
      <el-table-column prop="mc017" label="销售组织" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc017')" />
      <el-table-column prop="mc018" label="批量管理" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc018')" />
      <el-table-column prop="mc019" label="工厂条件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc019')" />
      <el-table-column prop="mc020" label="源清单" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc020')" />
      <el-table-column prop="mc021" label="MRP" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc021')" />
      <el-table-column prop="mc022" label="国家" align="center" v-if="columns.showColumn('mc022')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.mc022" />
        </template>
      </el-table-column>
      <el-table-column prop="mc023" label="地区" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc023')" />
      <el-table-column prop="mc024" label="县" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc024')" />
      <el-table-column prop="mc025" label="市" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc025')" />
      <el-table-column prop="mc026" label="地址" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc026')" />
      <el-table-column prop="mc027" label="计划工厂" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc027')" />
      <el-table-column prop="mc028" label="地区税务代码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc028')" />
      <el-table-column prop="mc029" label="分销渠道" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc029')" />
      <el-table-column prop="mc030" label="产品组" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc030')" />
      <el-table-column prop="mc031" label="语言" align="center" v-if="columns.showColumn('mc031')">
        <template #default="scope">
          <dict-tag :options=" options.sys_lang_type " :value="scope.row.mc031" />
        </template>
      </el-table-column>
      <el-table-column prop="mc032" label="SOP工厂" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc032')" />
      <el-table-column prop="mc033" label="差异码" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc033')" />
      <el-table-column prop="mc034" label="批量管理" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc034')" />
      <el-table-column prop="mc035" label="工厂种类" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc035')" />
      <el-table-column prop="mc036" label="销售地区" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc036')" />
      <el-table-column prop="mc037" label="供应地区" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc037')" />
      <el-table-column prop="mc038" label="工厂" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc038')" />
      <el-table-column prop="mc039" label="常规供应商" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc039')" />
      <el-table-column prop="mc040" label="第一封催询单" align="center" v-if="columns.showColumn('mc040')" />
      <el-table-column prop="mc041" label="第二封催询单" align="center" v-if="columns.showColumn('mc041')" />
      <el-table-column prop="mc042" label="第三封催询单" align="center" v-if="columns.showColumn('mc042')" />
      <el-table-column prop="mc043" label="第一催讨文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc043')" />
      <el-table-column prop="mc044" label="第二催讨文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc044')" />
      <el-table-column prop="mc045" label="第三催讨文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc045')" />
      <el-table-column prop="mc046" label="采购订单容差" align="center" v-if="columns.showColumn('mc046')" />
      <el-table-column prop="mc047" label="业务地点" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc047')" />
      <el-table-column prop="mc048" label="销售范围" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc048')" />
      <el-table-column prop="mc049" label="工厂分配" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc049')" />
      <el-table-column prop="mc050" label="归档标记" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc050')" />
      <el-table-column prop="mc051" label="批次记录" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc051')" />
      <el-table-column prop="mc052" label="节点类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc052')" />
      <el-table-column prop="mc053" label="名称结构" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc053')" />
      <el-table-column prop="mc054" label="成本对象控制" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc054')" />
      <el-table-column prop="mc055" label="混合成本核算" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc055')" />
      <el-table-column prop="mc056" label="实际成本核算" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc056')" />
      <el-table-column prop="mc057" label="装运点/接收点" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc057')" />
      <el-table-column prop="mc058" label="更新作业消耗" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc058')" />
      <el-table-column prop="mc059" label="信用控制" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc059')" />
      <el-table-column prop="mc060" label="附加货源" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc060')" />
      <el-table-column prop="mc061" label="交易评估" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc061')" />
      <el-table-column prop="mc062" label="供应商类型" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc062')" />
      <el-table-column prop="mc063" label="IPI信贷" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc063')" />
      <el-table-column prop="mc064" label="存储类别" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc064')" />
      <el-table-column prop="mc065" label="上级公司" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mc065')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['inst:plant:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['inst:plant:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改工厂代码对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="集团" prop="mc002">
                  <el-input v-model="form.mc002" :placeholder="$t('btn.enterPrefix')+'集团'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="6" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="性质" prop="mc003">
                  <el-select filterable clearable v-model="form.mc003"
                    :placeholder="$t('btn.selectPrefix')+'性质'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_nature_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="类别" prop="mc004">
                  <el-select filterable clearable v-model="form.mc004"
                    :placeholder="$t('btn.selectPrefix')+'类别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ind_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="工厂" prop="mc005">
                  <el-input v-model="form.mc005" :placeholder="$t('btn.enterPrefix')+'工厂'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="名称" prop="mc006">
                  <el-input v-model="form.mc006" :placeholder="$t('btn.enterPrefix')+'名称'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="60" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="评估范围" prop="mc007">
                  <el-input v-model="form.mc007" :placeholder="$t('btn.enterPrefix')+'评估范围'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="竞争者" prop="mc008">
                  <el-input v-model="form.mc008" :placeholder="$t('btn.enterPrefix')+'竞争者'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂供应商号码" prop="mc009">
                  <el-input v-model="form.mc009" :placeholder="$t('btn.enterPrefix')+'工厂供应商号码'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="日历" prop="mc010">
                  <el-input v-model="form.mc010" :placeholder="$t('btn.enterPrefix')+'日历'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="2" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="名称 2" prop="mc011">
                  <el-input v-model="form.mc011" :placeholder="$t('btn.enterPrefix')+'名称 2'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="60" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="住宅号及街道" prop="mc012">
                  <el-input v-model="form.mc012" :placeholder="$t('btn.enterPrefix')+'住宅号及街道'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="30" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="邮政信箱" prop="mc013">
                  <el-input v-model="form.mc013" :placeholder="$t('btn.enterPrefix')+'邮政信箱'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="邮政编码" prop="mc014">
                  <el-input v-model="form.mc014" :placeholder="$t('btn.enterPrefix')+'邮政编码'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="城市" prop="mc015">
                  <el-select filterable clearable remote remote-show-suffix
                    :remote-method="remoteMethod_sql_global_city" :loading="loading" v-model="form.mc015"
                    :placeholder="$t('btn.selectPrefix')+'城市'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  remotequery_sql_global_city" :key="item.dictValue"
                      :label="item.dictLabel" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="采购组织" prop="mc016">
                  <el-input v-model="form.mc016" :placeholder="$t('btn.enterPrefix')+'采购组织'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="销售组织" prop="mc017">
                  <el-input v-model="form.mc017" :placeholder="$t('btn.enterPrefix')+'销售组织'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批量管理" prop="mc018">
                  <el-input v-model="form.mc018" :placeholder="$t('btn.enterPrefix')+'批量管理'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂条件" prop="mc019">
                  <el-input v-model="form.mc019" :placeholder="$t('btn.enterPrefix')+'工厂条件'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="源清单" prop="mc020">
                  <el-input v-model="form.mc020" :placeholder="$t('btn.enterPrefix')+'源清单'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="MRP" prop="mc021">
                  <el-input v-model="form.mc021" :placeholder="$t('btn.enterPrefix')+'MRP'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="国家" prop="mc022">
                  <el-select filterable clearable v-model="form.mc022"
                    :placeholder="$t('btn.selectPrefix')+'国家'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_global_country" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="地区" prop="mc023">
                  <el-input v-model="form.mc023" :placeholder="$t('btn.enterPrefix')+'地区'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="县" prop="mc024">
                  <el-input v-model="form.mc024" :placeholder="$t('btn.enterPrefix')+'县'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="市" prop="mc025">
                  <el-input v-model="form.mc025" :placeholder="$t('btn.enterPrefix')+'市'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="地址" prop="mc026">
                  <el-input v-model="form.mc026" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="计划工厂" prop="mc027">
                  <el-input v-model="form.mc027" :placeholder="$t('btn.enterPrefix')+'计划工厂'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="地区税务代码" prop="mc028">
                  <el-input v-model="form.mc028" :placeholder="$t('btn.enterPrefix')+'地区税务代码'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="15" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="分销渠道" prop="mc029">
                  <el-input v-model="form.mc029" :placeholder="$t('btn.enterPrefix')+'分销渠道'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="2" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="产品组" prop="mc030">
                  <el-input v-model="form.mc030" :placeholder="$t('btn.enterPrefix')+'产品组'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="2" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="语言" prop="mc031">
                  <el-select filterable clearable v-model="form.mc031"
                    :placeholder="$t('btn.selectPrefix')+'语言'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_lang_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="SOP工厂" prop="mc032">
                  <el-input v-model="form.mc032" :placeholder="$t('btn.enterPrefix')+'SOP工厂'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="差异码" prop="mc033">
                  <el-input v-model="form.mc033" :placeholder="$t('btn.enterPrefix')+'差异码'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="6" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批量管理" prop="mc034">
                  <el-input v-model="form.mc034" :placeholder="$t('btn.enterPrefix')+'批量管理'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂种类" prop="mc035">
                  <el-input v-model="form.mc035" :placeholder="$t('btn.enterPrefix')+'工厂种类'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="销售地区" prop="mc036">
                  <el-input v-model="form.mc036" :placeholder="$t('btn.enterPrefix')+'销售地区'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="6" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应地区" prop="mc037">
                  <el-input v-model="form.mc037" :placeholder="$t('btn.enterPrefix')+'供应地区'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="10" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂" prop="mc038">
                  <el-input v-model="form.mc038" :placeholder="$t('btn.enterPrefix')+'工厂'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="常规供应商" prop="mc039">
                  <el-input v-model="form.mc039" :placeholder="$t('btn.enterPrefix')+'常规供应商'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="第一封催询单" prop="mc040">
                  <el-input-number v-model.number="form.mc040" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'第一封催询单'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="第二封催询单" prop="mc041">
                  <el-input-number v-model.number="form.mc041" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'第二封催询单'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="第三封催询单" prop="mc042">
                  <el-input-number v-model.number="form.mc042" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'第三封催询单'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="第一催讨文本" prop="mc043">
                  <el-input v-model="form.mc043" :placeholder="$t('btn.enterPrefix')+'第一催讨文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="16" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="第二催讨文本" prop="mc044">
                  <el-input v-model="form.mc044" :placeholder="$t('btn.enterPrefix')+'第二催讨文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="16" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="第三催讨文本" prop="mc045">
                  <el-input v-model="form.mc045" :placeholder="$t('btn.enterPrefix')+'第三催讨文本'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="16" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="采购订单容差" prop="mc046">
                  <el-input-number v-model.number="form.mc046" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'采购订单容差'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="业务地点" prop="mc047">
                  <el-input v-model="form.mc047" :placeholder="$t('btn.enterPrefix')+'业务地点'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="销售范围" prop="mc048">
                  <el-input v-model="form.mc048" :placeholder="$t('btn.enterPrefix')+'销售范围'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="2" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂分配" prop="mc049">
                  <el-input v-model="form.mc049" :placeholder="$t('btn.enterPrefix')+'工厂分配'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="归档标记" prop="mc050">
                  <el-input v-model="form.mc050" :placeholder="$t('btn.enterPrefix')+'归档标记'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="批次记录" prop="mc051">
                  <el-input v-model="form.mc051" :placeholder="$t('btn.enterPrefix')+'批次记录'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="节点类型" prop="mc052">
                  <el-input v-model="form.mc052" :placeholder="$t('btn.enterPrefix')+'节点类型'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="3" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="名称结构" prop="mc053">
                  <el-input v-model="form.mc053" :placeholder="$t('btn.enterPrefix')+'名称结构'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="成本对象控制" prop="mc054">
                  <el-input v-model="form.mc054" :placeholder="$t('btn.enterPrefix')+'成本对象控制'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="混合成本核算" prop="mc055">
                  <el-input v-model="form.mc055" :placeholder="$t('btn.enterPrefix')+'混合成本核算'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="实际成本核算" prop="mc056">
                  <el-input v-model="form.mc056" :placeholder="$t('btn.enterPrefix')+'实际成本核算'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="装运点/接收点" prop="mc057">
                  <el-input v-model="form.mc057" :placeholder="$t('btn.enterPrefix')+'装运点/接收点'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="更新作业消耗" prop="mc058">
                  <el-input v-model="form.mc058" :placeholder="$t('btn.enterPrefix')+'更新作业消耗'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="信用控制" prop="mc059">
                  <el-input v-model="form.mc059" :placeholder="$t('btn.enterPrefix')+'信用控制'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="附加货源" prop="mc060">
                  <el-input v-model="form.mc060" :placeholder="$t('btn.enterPrefix')+'附加货源'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="交易评估" prop="mc061">
                  <el-input v-model="form.mc061" :placeholder="$t('btn.enterPrefix')+'交易评估'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="供应商类型" prop="mc062">
                  <el-input v-model="form.mc062" :placeholder="$t('btn.enterPrefix')+'供应商类型'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="IPI信贷" prop="mc063">
                  <el-input v-model="form.mc063" :placeholder="$t('btn.enterPrefix')+'IPI信贷'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="存储类别" prop="mc064">
                  <el-input v-model="form.mc064" :placeholder="$t('btn.enterPrefix')+'存储类别'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="上级公司" prop="mc065">
                  <el-input v-model="form.mc065" :placeholder="$t('btn.enterPrefix')+'上级公司'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="4" />
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

<script setup name="instplant">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listInstPlant,
    addInstPlant, delInstPlant,
    updateInstPlant, getInstPlant,
  }
    from '@/api/routine/instplant.js'
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
    sort: 'Mc005',
    sortType: 'asc',
    //是否查询（1是）
    mc003: undefined,
    //是否查询（1是）
    mc004: undefined,
    //是否查询（1是）
    mc005: undefined,
    //是否查询（1是）
    mc006: undefined,
    //是否查询（1是）
    mc007: undefined,
    //是否查询（1是）
    mc015: undefined,
    //是否查询（1是）
    mc016: undefined,
    //是否查询（1是）
    mc017: undefined,
    //是否查询（1是）
    mc022: undefined,
    //是否查询（1是）
    mc031: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mc002', label: '集团' },
    { visible: true, prop: 'mc003', label: '性质' },
    { visible: true, prop: 'mc004', label: '类别' },
    { visible: true, prop: 'mc005', label: '工厂' },
    { visible: true, prop: 'mc006', label: '名称' },
    { visible: true, prop: 'mc007', label: '评估范围' },
    { visible: true, prop: 'mc008', label: '竞争者' },
    { visible: false, prop: 'mc009', label: '工厂供应商号码' },
    { visible: false, prop: 'mc010', label: '日历' },
    { visible: false, prop: 'mc011', label: '名称 2' },
    { visible: false, prop: 'mc012', label: '住宅号及街道' },
    { visible: false, prop: 'mc013', label: '邮政信箱' },
    { visible: false, prop: 'mc014', label: '邮政编码' },
    { visible: false, prop: 'mc015', label: '城市' },
    { visible: false, prop: 'mc016', label: '采购组织' },
    { visible: false, prop: 'mc017', label: '销售组织' },
    { visible: false, prop: 'mc018', label: '批量管理' },
    { visible: false, prop: 'mc019', label: '工厂条件' },
    { visible: false, prop: 'mc020', label: '源清单' },
    { visible: false, prop: 'mc021', label: 'MRP' },
    { visible: false, prop: 'mc022', label: '国家' },
    { visible: false, prop: 'mc023', label: '地区' },
    { visible: false, prop: 'mc024', label: '县' },
    { visible: false, prop: 'mc025', label: '市' },
    { visible: false, prop: 'mc026', label: '地址' },
    { visible: false, prop: 'mc027', label: '计划工厂' },
    { visible: false, prop: 'mc028', label: '地区税务代码' },
    { visible: false, prop: 'mc029', label: '分销渠道' },
    { visible: false, prop: 'mc030', label: '产品组' },
    { visible: false, prop: 'mc031', label: '语言' },
    { visible: false, prop: 'mc032', label: 'SOP工厂' },
    { visible: false, prop: 'mc033', label: '差异码' },
    { visible: false, prop: 'mc034', label: '批量管理' },
    { visible: false, prop: 'mc035', label: '工厂种类' },
    { visible: false, prop: 'mc036', label: '销售地区' },
    { visible: false, prop: 'mc037', label: '供应地区' },
    { visible: false, prop: 'mc038', label: '工厂' },
    { visible: false, prop: 'mc039', label: '常规供应商' },
    { visible: false, prop: 'mc040', label: '第一封催询单' },
    { visible: false, prop: 'mc041', label: '第二封催询单' },
    { visible: false, prop: 'mc042', label: '第三封催询单' },
    { visible: false, prop: 'mc043', label: '第一催讨文本' },
    { visible: false, prop: 'mc044', label: '第二催讨文本' },
    { visible: false, prop: 'mc045', label: '第三催讨文本' },
    { visible: false, prop: 'mc046', label: '采购订单容差' },
    { visible: false, prop: 'mc047', label: '业务地点' },
    { visible: false, prop: 'mc048', label: '销售范围' },
    { visible: false, prop: 'mc049', label: '工厂分配' },
    { visible: false, prop: 'mc050', label: '归档标记' },
    { visible: false, prop: 'mc051', label: '批次记录' },
    { visible: false, prop: 'mc052', label: '节点类型' },
    { visible: false, prop: 'mc053', label: '名称结构' },
    { visible: false, prop: 'mc054', label: '成本对象控制' },
    { visible: false, prop: 'mc055', label: '混合成本核算' },
    { visible: false, prop: 'mc056', label: '实际成本核算' },
    { visible: false, prop: 'mc057', label: '装运点/接收点' },
    { visible: false, prop: 'mc058', label: '更新作业消耗' },
    { visible: false, prop: 'mc059', label: '信用控制' },
    { visible: false, prop: 'mc060', label: '附加货源' },
    { visible: false, prop: 'mc061', label: '交易评估' },
    { visible: false, prop: 'mc062', label: '供应商类型' },
    { visible: false, prop: 'mc063', label: 'IPI信贷' },
    { visible: false, prop: 'mc064', label: '存储类别' },
    { visible: false, prop: 'mc065', label: '上级公司' },
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
  const remotequeryList_sql_global_city = ref([])
  //定义远程搜索变量
  const remotequery_sql_global_city = ref([])
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
  const addFilterOptions_sql_global_city = debounce((dictValue) => {
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
    { dictType: "sys_lang_type" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从工厂代码/inst_plant表记录数据
  function getList() {
    loading.value = true
    listInstPlant(queryParams).then(res => {
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
      mc002: [{ required: true, message: "集团" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mc003: [{ required: true, message: "性质" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mc004: [{ required: true, message: "类别" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      mc005: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    //字典名称
    options: {
      // 性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_nature_list: [],
      // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ind_type: [],
      // 国家 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_global_country: [],
      // 语言 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_lang_type: [],
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
      mc002: null,
      mc003: [],
      mc004: [],
      mc005: null,
      mc006: null,
      mc007: null,
      mc008: null,
      mc009: null,
      mc010: null,
      mc011: null,
      mc012: null,
      mc013: null,
      mc014: null,
      mc015: [],
      mc016: null,
      mc017: null,
      mc018: null,
      mc019: null,
      mc020: null,
      mc021: null,
      mc022: [],
      mc023: null,
      mc024: null,
      mc025: null,
      mc026: null,
      mc027: null,
      mc028: null,
      mc029: null,
      mc030: null,
      mc031: [],
      mc032: null,
      mc033: null,
      mc034: null,
      mc035: null,
      mc036: null,
      mc037: null,
      mc038: null,
      mc039: null,
      mc040: 0,
      mc041: 0,
      mc042: 0,
      mc043: null,
      mc044: null,
      mc045: null,
      mc046: 0,
      mc047: null,
      mc048: null,
      mc049: null,
      mc050: null,
      mc051: null,
      mc052: null,
      mc053: null,
      mc054: null,
      mc055: null,
      mc056: null,
      mc057: null,
      mc058: null,
      mc059: null,
      mc060: null,
      mc061: null,
      mc062: null,
      mc063: null,
      mc064: null,
      mc065: null,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '工厂代码'
    opertype.value = 1
    form.value.mc003 = []
    form.value.mc004 = []
    form.value.mc015 = []
    form.value.mc022 = []
    form.value.mc031 = []
    form.value.mc040 = 0
    form.value.mc041 = 0
    form.value.mc042 = 0
    form.value.mc046 = 0
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getInstPlant(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '工厂代码'
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
          updateInstPlant(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addInstPlant(form.value).then((res) => {
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
        return delInstPlant(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<工厂代码.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Routine/InstPlant/export', { ...queryParams })
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