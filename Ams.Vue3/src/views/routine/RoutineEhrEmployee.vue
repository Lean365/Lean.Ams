<!--
 * @Descripttion: 人事/routine_ehr_employee
 * @Version: 0.24.657.14913
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/10/18 8:40:20
 * @column：73
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="姓名" prop="mh002">
            <el-input v-model="queryParams.mh002"
              :placeholder="$t('btn.enterSearchPrefix')+'姓名'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="性别" prop="mh006">
            <el-select filterable clearable v-model="queryParams.mh006"
              :placeholder="$t('btn.selectSearchPrefix')+'性别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_gender_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="出生日期">
            <el-date-picker v-model="dateRangeMh007" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="婚姻状态" prop="mh009">
            <el-select filterable clearable v-model="queryParams.mh009"
              :placeholder="$t('btn.selectSearchPrefix')+'婚姻状态'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_wedlock_state " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="民族" prop="mh010">
            <el-select filterable clearable v-model="queryParams.mh010"
              :placeholder="$t('btn.selectSearchPrefix')+'民族'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_nation_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="政治面貌" prop="mh012">
            <el-select filterable clearable v-model="queryParams.mh012"
              :placeholder="$t('btn.selectSearchPrefix')+'政治面貌'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_politic_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="国家/地区" prop="mh015">
            <el-select filterable clearable v-model="queryParams.mh015"
              :placeholder="$t('btn.selectSearchPrefix')+'国家/地区'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="部门" prop="mh023">
            <el-select filterable clearable v-model="queryParams.mh023"
              :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="职称" prop="mh024">
            <el-select filterable clearable v-model="queryParams.mh024"
              :placeholder="$t('btn.selectSearchPrefix')+'职称'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_titles_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="职位" prop="mh025">
            <el-select filterable clearable v-model="queryParams.mh025"
              :placeholder="$t('btn.selectSearchPrefix')+'职位'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_posts_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="学历" prop="mh030">
            <el-select filterable clearable v-model="queryParams.mh030"
              :placeholder="$t('btn.selectSearchPrefix')+'学历'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_level_education " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="工号" prop="mh033">
            <el-input v-model="queryParams.mh033"
              :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="入职日期">
            <el-date-picker v-model="dateRangeMh034" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="在职状态" prop="mh035">
            <el-select filterable clearable v-model="queryParams.mh035"
              :placeholder="$t('btn.selectSearchPrefix')+'在职状态'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_serve_state " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="离职日期">
            <el-date-picker v-model="dateRangeMh039" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
              :end-placeholder="$t('btn.dateEnd')" value-format="YYYY-MM-DD HH:mm:ss" :default-time="defaultTime"
              :shortcuts="dateOptions">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="打卡否" prop="mh044">
            <el-radio-group v-model="queryParams.mh044">
              <el-radio :value="-1">{{$t('common.all')}}</el-radio>
              <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue"
                :value="item.dictValue">{{item.dictLabel}}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="班别" prop="mh045">
            <el-select filterable clearable v-model="queryParams.mh045"
              :placeholder="$t('btn.selectSearchPrefix')+'班别'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_shifts_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['routine:ehremployee:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehremployee:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehremployee:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['routine:ehremployee:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Routine/RoutineEhrEmployee/importTemplate"
                  importUrl="/Routine/RoutineEhrEmployee/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['routine:ehremployee:export']">
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
      <el-table-column prop="mh002" label="姓名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh002')" />
      <el-table-column prop="mh003" label="曾用名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh003')" />
      <el-table-column prop="mh004" label="昵称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh004')" />
      <el-table-column prop="mh005" label="英文名" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh005')" />
      <el-table-column prop="mh006" label="性别" align="center" v-if="columns.showColumn('mh006')">
        <template #default="scope">
          <dict-tag :options=" options.sys_gender_type " :value="scope.row.mh006" />
        </template>
      </el-table-column>
      <el-table-column prop="mh007" label="出生日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mh007')" />
      <el-table-column prop="mh008" label="身份证号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh008')" />
      <el-table-column prop="mh009" label="婚姻状态" align="center" v-if="columns.showColumn('mh009')">
        <template #default="scope">
          <dict-tag :options=" options.sys_wedlock_state " :value="scope.row.mh009" />
        </template>
      </el-table-column>
      <el-table-column prop="mh010" label="民族" align="center" v-if="columns.showColumn('mh010')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nation_list " :value="scope.row.mh010" />
        </template>
      </el-table-column>
      <el-table-column prop="mh011" label="籍贯" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh011')" />
      <el-table-column prop="mh012" label="政治面貌" align="center" v-if="columns.showColumn('mh012')">
        <template #default="scope">
          <dict-tag :options=" options.sys_politic_list " :value="scope.row.mh012" />
        </template>
      </el-table-column>
      <el-table-column prop="mh013" label="邮件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh013')" />
      <el-table-column prop="mh014" label="电话" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh014')" />
      <el-table-column prop="mh015" label="国家/地区" align="center" v-if="columns.showColumn('mh015')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.mh015" />
        </template>
      </el-table-column>
      <el-table-column prop="mh016" label="省区" align="center" v-if="columns.showColumn('mh016')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_state " :value="scope.row.mh016" />
        </template>
      </el-table-column>
      <el-table-column prop="mh017" label="市区" align="center" v-if="columns.showColumn('mh017')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.mh017" />
        </template>
      </el-table-column>
      <el-table-column prop="mh018" label="县区" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh018')" />
      <el-table-column prop="mh019" label="家庭住址" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh019')" />
      <el-table-column prop="mh020" label="邮编" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh020')" />
      <el-table-column prop="mh021" label="户口性质" align="center" v-if="columns.showColumn('mh021')">
        <template #default="scope">
          <dict-tag :options=" options.sys_household_type " :value="scope.row.mh021" />
        </template>
      </el-table-column>
      <el-table-column prop="mh022" label="暂住地址" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh022')" />
      <el-table-column prop="mh023" label="部门" align="center" v-if="columns.showColumn('mh023')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.mh023" />
        </template>
      </el-table-column>
      <el-table-column prop="mh024" label="职称" align="center" v-if="columns.showColumn('mh024')">
        <template #default="scope">
          <dict-tag :options=" options.sys_titles_list " :value="scope.row.mh024" />
        </template>
      </el-table-column>
      <el-table-column prop="mh025" label="职位" align="center" v-if="columns.showColumn('mh025')">
        <template #default="scope">
          <dict-tag :options=" options.sql_posts_list " :value="scope.row.mh025" />
        </template>
      </el-table-column>
      <el-table-column prop="mh026" label="职级" align="center" v-if="columns.showColumn('mh026')">
        <template #default="scope">
          <dict-tag :options=" options.sys_post_level " :value="scope.row.mh026" />
        </template>
      </el-table-column>
      <el-table-column prop="mh027" label="职务" align="center" v-if="columns.showColumn('mh027')">
        <template #default="scope">
          <dict-tag :options=" options.sql_posts_list " :value="scope.row.mh027" />
        </template>
      </el-table-column>
      <el-table-column prop="mh028" label="招聘来源" align="center" v-if="columns.showColumn('mh028')">
        <template #default="scope">
          <dict-tag :options=" options.sys_recruited_list " :value="scope.row.mh028" />
        </template>
      </el-table-column>
      <el-table-column prop="mh029" label="聘用形式" align="center" v-if="columns.showColumn('mh029')">
        <template #default="scope">
          <dict-tag :options=" options.sys_employ_term " :value="scope.row.mh029" />
        </template>
      </el-table-column>
      <el-table-column prop="mh030" label="学历" align="center" v-if="columns.showColumn('mh030')">
        <template #default="scope">
          <dict-tag :options=" options.sys_level_education " :value="scope.row.mh030" />
        </template>
      </el-table-column>
      <el-table-column prop="mh031" label="专业" align="center" v-if="columns.showColumn('mh031')">
        <template #default="scope">
          <dict-tag :options=" options.sys_specialty_list " :value="scope.row.mh031" />
        </template>
      </el-table-column>
      <el-table-column prop="mh032" label="院校" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh032')" />
      <el-table-column prop="mh033" label="工号" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh033')" />
      <el-table-column prop="mh034" label="入职日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mh034')" />
      <el-table-column prop="mh035" label="在职状态" align="center" v-if="columns.showColumn('mh035')">
        <template #default="scope">
          <dict-tag :options=" options.sys_serve_state " :value="scope.row.mh035" />
        </template>
      </el-table-column>
      <el-table-column prop="mh036" label="试用期" align="center" v-if="columns.showColumn('mh036')" />
      <el-table-column prop="mh037" label="合同期限" align="center" v-if="columns.showColumn('mh037')" />
      <el-table-column prop="mh038" label="转正日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mh038')" />
      <el-table-column prop="mh039" label="离职日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mh039')" />
      <el-table-column prop="mh040" label="合同起始日" :show-overflow-tooltip="true" v-if="columns.showColumn('mh040')" />
      <el-table-column prop="mh041" label="合同终止日" :show-overflow-tooltip="true" v-if="columns.showColumn('mh041')" />
      <el-table-column prop="mh042" label="工龄" align="center" v-if="columns.showColumn('mh042')" />
      <el-table-column prop="mh043" label="退休日期" :show-overflow-tooltip="true" v-if="columns.showColumn('mh043')" />
      <el-table-column prop="mh044" label="打卡否" align="center" v-if="columns.showColumn('mh044')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.mh044" />
        </template>
      </el-table-column>
      <el-table-column prop="mh045" label="班别" align="center" v-if="columns.showColumn('mh045')">
        <template #default="scope">
          <dict-tag :options=" options.sys_shifts_list " :value="scope.row.mh045" />
        </template>
      </el-table-column>
      <el-table-column prop="mh046" label="头像" align="center" v-if="columns.showColumn('mh046')">
        <template #default="scope">
          <ImagePreview :src="scope.row.mh046"></ImagePreview>
        </template>
      </el-table-column>
      <el-table-column prop="mh047" label="学历附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh047')" />
      <el-table-column prop="mh048" label="职称附件" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('mh048')" />
      <el-table-column prop="mh049" label="系统访问" align="center" v-if="columns.showColumn('mh049')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.mh049" />
        </template>
      </el-table-column>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['routine:ehremployee:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['routine:ehremployee:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改人事对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="姓名" prop="mh002">
                  <el-input v-model="form.mh002" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" @input="handleNameInput" @change="handleNameInput" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="曾用名" prop="mh003">
                  <el-input v-model="form.mh003" :placeholder="$t('btn.enterPrefix')+'曾用名'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="昵称" prop="mh004">
                  <el-input v-model="form.mh004" :placeholder="$t('btn.enterPrefix')+'昵称'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="40" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="英文名" prop="mh005">
                  <el-input v-model="form.mh005" :placeholder="$t('btn.enterPrefix')+'英文名'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="200" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="性别" prop="mh006">
                  <el-select filterable clearable v-model="form.mh006"
                    :placeholder="$t('btn.selectPrefix')+'性别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_gender_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="出生日期" prop="mh007">
                  <el-date-picker v-model="form.mh007" type="date" :teleported="false"
                    :placeholder="$t('btn.dateselect')" @change="handleBirthdayChange"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="身份证号" prop="mh008">
                  <el-input v-model="form.mh008" :placeholder="$t('btn.enterPrefix')+'身份证号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="18" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="婚姻状态" prop="mh009">
                  <el-select filterable clearable v-model="form.mh009"
                    :placeholder="$t('btn.selectPrefix')+'婚姻状态'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_wedlock_state" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="民族" prop="mh010">
                  <el-select filterable clearable v-model="form.mh010"
                    :placeholder="$t('btn.selectPrefix')+'民族'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_nation_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="籍贯" prop="mh011">
                  <el-input v-model="form.mh011" :placeholder="$t('btn.enterPrefix')+'籍贯'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="100" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="政治面貌" prop="mh012">
                  <el-select filterable clearable v-model="form.mh012"
                    :placeholder="$t('btn.selectPrefix')+'政治面貌'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_politic_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
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
              <el-col :lg="12">
                <el-form-item label="部门" prop="mh023">
                  <el-select filterable clearable v-model="form.mh023"
                    :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_dept_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="职称" prop="mh024">
                  <el-select filterable clearable v-model="form.mh024"
                    :placeholder="$t('btn.selectPrefix')+'职称'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_titles_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="职位" prop="mh025">
                  <el-select filterable clearable v-model="form.mh025"
                    :placeholder="$t('btn.selectPrefix')+'职位'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_posts_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="职级" prop="mh026">
                  <el-select filterable clearable v-model="form.mh026"
                    :placeholder="$t('btn.selectPrefix')+'职级'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_post_level" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="职务" prop="mh027">
                  <el-select filterable clearable v-model="form.mh027"
                    :placeholder="$t('btn.selectPrefix')+'职务'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_posts_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="招聘来源" prop="mh028">
                  <el-select filterable clearable v-model="form.mh028"
                    :placeholder="$t('btn.selectPrefix')+'招聘来源'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_recruited_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="聘用形式" prop="mh029">
                  <el-select filterable clearable v-model="form.mh029"
                    :placeholder="$t('btn.selectPrefix')+'聘用形式'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_employ_term" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>



              <el-col :lg="12">
                <el-form-item label="工号" prop="mh033">
                  <el-input v-model="form.mh033" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="入职日期" prop="mh034">
                  <el-date-picker v-model="form.mh034" type="date" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="在职状态" prop="mh035">
                  <el-select filterable clearable v-model="form.mh035"
                    :placeholder="$t('btn.selectPrefix')+'在职状态'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_serve_state" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="试用期" prop="mh036">
                  <el-input-number v-model.number="form.mh036" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'试用期'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="合同期限" prop="mh037">
                  <el-input-number v-model.number="form.mh037" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'合同期限'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="转正日期" prop="mh038">
                  <el-date-picker v-model="form.mh038" type="date" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="离职日期" prop="mh039">
                  <el-date-picker v-model="form.mh039" type="date" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="合同起始日" prop="mh040">
                  <el-date-picker v-model="form.mh040" type="date" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="合同终止日" prop="mh041">
                  <el-date-picker v-model="form.mh041" type="date" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工龄" prop="mh042">
                  <el-input-number v-model.number="form.mh042" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'工龄'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="退休日期" prop="mh043">
                  <el-date-picker v-model="form.mh043" type="date" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="打卡否" prop="mh044">
                  <el-radio-group v-model="form.mh044">
                    <el-radio v-for="item in options.sys_is_status" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="班别" prop="mh045">
                  <el-select filterable clearable v-model="form.mh045"
                    :placeholder="$t('btn.selectPrefix')+'班别'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_shifts_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>
              <el-col :lg="12">
                <el-form-item label="系统访问" prop="mh049">
                  <el-radio-group v-model="form.mh049">
                    <el-radio v-for="item in options.sys_is_status" :key="item.dictValue"
                      :value="parseInt(item.dictValue)">
                      {{item.dictLabel}}
                    </el-radio>
                  </el-radio-group>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="学历" prop="mh030">
                  <el-select filterable clearable v-model="form.mh030"
                    :placeholder="$t('btn.selectPrefix')+'学历'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_level_education" :key="item.dictValue"
                      :label="item.dictLabel" :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="专业" prop="mh031">
                  <el-select filterable clearable v-model="form.mh031"
                    :placeholder="$t('btn.selectPrefix')+'专业'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_specialty_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="24">
                <el-form-item label="院校" prop="mh032">
                  <el-input v-model="form.mh032" :placeholder="$t('btn.enterPrefix')+'院校'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="100" />
                </el-form-item>
              </el-col>
              <el-col :lg="12">
                <el-form-item label="学历附件" prop="mh047">
                  <UploadFile v-model="form.mh047" fileSize="20" :fileType="['pdf']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'routine/routineehremployee' ,uploadType: 1}" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="职称附件" prop="mh048">
                  <UploadFile v-model="form.mh048" fileSize="20" :fileType="['pdf']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'routine/routineehremployee' ,uploadType: 1}" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.attachment')" name="fourth">
            <el-row :gutter="20">
              <el-col :lg="24">
                <el-form-item label="头像" prop="mh046">
                  <UploadImage v-model="form.mh046" fileSize="5" :fileType="['png,jpg']" limit="1"
                    :data=" {fileNameType:1, fileDir: 'routine/routineehremployee' ,uploadType: 1}" />
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.contact')" name="eighth">
            <el-row :gutter="20">
              <el-col :lg="12">
                <el-form-item label="邮件" prop="mh013">
                  <el-input v-model="form.mh013" :placeholder="$t('btn.enterPrefix')+'邮件'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="20" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="电话" prop="mh014">
                  <el-input v-model="form.mh014" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="11" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="国家/地区" prop="mh015">
                  <el-select filterable clearable v-model="form.mh015"
                    :placeholder="$t('btn.selectPrefix')+'国家/地区'+$t('btn.selectSuffix')" @change="handleAlandChange">
                    <el-option v-for="item in  options.sql_global_country" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="省区" prop="mh016">
                  <el-select-v2 filterable clearable v-model="form.mh016"
                    :placeholder="$t('btn.selectPrefix')+'省区'+$t('btn.selectSuffix')" :options="filteredFormState"
                    @change="handleStateChange">
                  </el-select-v2>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="市区" prop="mh017">
                  <el-select-v2 filterable clearable v-model="form.mh017"
                    :placeholder="$t('btn.selectPrefix')+'市区'+$t('btn.selectSuffix')" :options="filteredFormCity">
                  </el-select-v2>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="县区" prop="mh018">
                  <el-input v-model="form.mh018" :placeholder="$t('btn.enterPrefix')+'县区'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="50" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="家庭住址" prop="mh019">
                  <el-input v-model="form.mh019" :placeholder="$t('btn.enterPrefix')+'家庭住址'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="128" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="邮编" prop="mh020">
                  <el-input v-model="form.mh020" :placeholder="$t('btn.enterPrefix')+'邮编'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="8" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="户口性质" prop="mh021">
                  <el-select filterable clearable v-model="form.mh021"
                    :placeholder="$t('btn.selectPrefix')+'户口性质'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_household_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="parseInt(item.dictValue)"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="暂住地址" prop="mh022">
                  <el-input v-model="form.mh022" :placeholder="$t('btn.enterPrefix')+'暂住地址'+$t('btn.enterSuffix')"
                    show-word-limit maxlength="128" />
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

<script setup name="routineehremployee">
  import '@/assets/styles/btn-custom.scss'
  import { pinyin } from "pinyin-pro"
  //后台操作函数
  import {
    listRoutineEhrEmployee,
    addRoutineEhrEmployee, delRoutineEhrEmployee,
    updateRoutineEhrEmployee, getRoutineEhrEmployee,
  }
    from '@/api/routine/routineehremployee.js'
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
    sort: 'Mh034',
    sortType: 'desc',
    //是否查询（1是）
    mh002: undefined,
    //是否查询（1是）
    mh006: undefined,
    //是否查询（1是）
    mh007: undefined,
    //是否查询（1是）
    mh009: undefined,
    //是否查询（1是）
    mh010: undefined,
    //是否查询（1是）
    mh012: undefined,
    //是否查询（1是）
    mh015: undefined,
    //是否查询（1是）
    mh023: undefined,
    //是否查询（1是）
    mh024: undefined,
    //是否查询（1是）
    mh025: undefined,
    //是否查询（1是）
    mh030: undefined,
    //是否查询（1是）
    mh033: undefined,
    //是否查询（1是）
    mh034: undefined,
    //是否查询（1是）
    mh035: undefined,
    //是否查询（1是）
    mh039: undefined,
    //是否查询（1是）
    mh044: -1,
    //是否查询（1是）
    mh045: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'id', label: 'ID' },
    { visible: true, prop: 'mh002', label: '姓名' },
    { visible: true, prop: 'mh003', label: '曾用名' },
    { visible: true, prop: 'mh004', label: '昵称' },
    { visible: true, prop: 'mh005', label: '英文名' },
    { visible: true, prop: 'mh006', label: '性别' },
    { visible: true, prop: 'mh007', label: '出生日期' },
    { visible: true, prop: 'mh008', label: '身份证号' },
    { visible: false, prop: 'mh009', label: '婚姻状态' },
    { visible: false, prop: 'mh010', label: '民族' },
    { visible: false, prop: 'mh011', label: '籍贯' },
    { visible: false, prop: 'mh012', label: '政治面貌' },
    { visible: false, prop: 'mh013', label: '邮件' },
    { visible: false, prop: 'mh014', label: '电话' },
    { visible: false, prop: 'mh015', label: '国家/地区' },
    { visible: false, prop: 'mh016', label: '省区' },
    { visible: false, prop: 'mh017', label: '市区' },
    { visible: false, prop: 'mh018', label: '县区' },
    { visible: false, prop: 'mh019', label: '家庭住址' },
    { visible: false, prop: 'mh020', label: '邮编' },
    { visible: false, prop: 'mh021', label: '户口性质' },
    { visible: false, prop: 'mh022', label: '暂住地址' },
    { visible: false, prop: 'mh023', label: '部门' },
    { visible: false, prop: 'mh024', label: '职称' },
    { visible: false, prop: 'mh025', label: '职位' },
    { visible: false, prop: 'mh026', label: '职级' },
    { visible: false, prop: 'mh027', label: '职务' },
    { visible: false, prop: 'mh028', label: '招聘来源' },
    { visible: false, prop: 'mh029', label: '聘用形式' },
    { visible: false, prop: 'mh030', label: '学历' },
    { visible: false, prop: 'mh031', label: '专业' },
    { visible: false, prop: 'mh032', label: '院校' },
    { visible: false, prop: 'mh033', label: '工号' },
    { visible: false, prop: 'mh034', label: '入职日期' },
    { visible: false, prop: 'mh035', label: '在职状态' },
    { visible: false, prop: 'mh036', label: '试用期' },
    { visible: false, prop: 'mh037', label: '合同期限' },
    { visible: false, prop: 'mh038', label: '转正日期' },
    { visible: false, prop: 'mh039', label: '离职日期' },
    { visible: false, prop: 'mh040', label: '合同起始日' },
    { visible: false, prop: 'mh041', label: '合同终止日' },
    { visible: false, prop: 'mh042', label: '工龄' },
    { visible: false, prop: 'mh043', label: '退休日期' },
    { visible: false, prop: 'mh044', label: '打卡否' },
    { visible: false, prop: 'mh045', label: '班别' },
    { visible: false, prop: 'mh046', label: '头像' },
    { visible: false, prop: 'mh047', label: '学历附件' },
    { visible: false, prop: 'mh048', label: '职称附件' },
    { visible: false, prop: 'mh049', label: '系统访问' },
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
  // 出生日期时间范围
  const dateRangeMh007 = ref([])
  // 入职日期时间范围
  const dateRangeMh034 = ref([])
  // 离职日期时间范围
  const dateRangeMh039 = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sys_gender_type" },
    { dictType: "sys_wedlock_state" },
    { dictType: "sys_nation_list" },
    { dictType: "sys_politic_list" },
    { dictType: "sql_global_country" },
    { dictType: "sql_global_state" },
    { dictType: "sql_global_city" },
    { dictType: "sys_household_type" },
    { dictType: "sql_dept_list" },
    { dictType: "sys_titles_list" },
    { dictType: "sql_posts_list" },
    { dictType: "sys_post_level" },
    { dictType: "sys_recruited_list" },
    { dictType: "sys_employ_term" },
    { dictType: "sys_level_education" },
    { dictType: "sys_specialty_list" },
    { dictType: "sys_serve_state" },
    { dictType: "sys_is_status" },
    { dictType: "sys_shifts_list" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从人事/routine_ehr_employee表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeMh007.value, 'Mh007');
    proxy.addDateRange(queryParams, dateRangeMh034.value, 'Mh034');
    proxy.addDateRange(queryParams, dateRangeMh039.value, 'Mh039');
    loading.value = true
    listRoutineEhrEmployee(queryParams).then(res => {
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
    // 出生日期时间范围
    dateRangeMh007.value = []
    // 入职日期时间范围
    dateRangeMh034.value = []
    // 离职日期时间范围
    dateRangeMh039.value = []
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
      mh002: [{ required: true, message: "姓名" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mh006: [{ required: true, message: "性别" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh009: [{ required: true, message: "婚姻状态" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh010: [{ required: true, message: "民族" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh012: [{ required: true, message: "政治面貌" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh021: [{ required: true, message: "户口性质" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh023: [{ required: true, message: "部门" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh024: [{ required: true, message: "职称" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh025: [{ required: true, message: "职位" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh026: [{ required: true, message: "职级" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh027: [{ required: true, message: "职务" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh028: [{ required: true, message: "招聘来源" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh029: [{ required: true, message: "聘用形式" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh030: [{ required: true, message: "学历" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh031: [{ required: true, message: "专业" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh033: [{ required: true, message: "工号" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      mh035: [{ required: true, message: "在职状态" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
      mh036: [{ required: true, message: "试用期" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mh037: [{ required: true, message: "合同期限" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mh042: [{ required: true, message: "工龄" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mh044: [{ required: true, message: "打卡否" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      mh045: [{ required: true, message: "班别" + proxy.$t('btn.isEmpty'), trigger: "change", type: "number" }],
    },
    //字典名称
    options: {
      // 性别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_gender_type: [],
      // 婚姻状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_wedlock_state: [],
      // 民族 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_nation_list: [],
      // 政治面貌 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_politic_list: [],
      // 国家/地区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_global_country: [],
      // 省区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_global_state: [],
      // 市区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_global_city: [],
      // 户口性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_household_type: [],
      // 部门 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_dept_list: [],
      // 职称 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_titles_list: [],
      // 职位 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_posts_list: [],
      // 职级 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_post_level: [],
      // 招聘来源 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_recruited_list: [],
      // 聘用形式 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_employ_term: [],
      // 学历 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_level_education: [],
      // 专业 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_specialty_list: [],
      // 在职状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_serve_state: [],
      // 打卡否 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_is_status: [],
      // 班别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_shifts_list: [],
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
      mh002: null,
      mh003: null,
      mh004: null,
      mh005: null,
      mh006: [],
      mh007: null,
      mh008: null,
      mh009: [],
      mh010: [],
      mh011: null,
      mh012: [],
      mh013: null,
      mh014: null,
      mh015: [],
      mh016: [],
      mh017: [],
      mh018: null,
      mh019: null,
      mh020: null,
      mh021: [],
      mh022: null,
      mh023: [],
      mh024: [],
      mh025: [],
      mh026: [],
      mh027: [],
      mh028: [],
      mh029: [],
      mh030: [],
      mh031: [],
      mh032: null,
      mh033: null,
      mh034: null,
      mh035: [],
      mh036: 0,
      mh037: 0,
      mh038: null,
      mh039: null,
      mh040: null,
      mh041: null,
      mh042: 0,
      mh043: null,
      mh044: 0,
      mh045: [],
      mh046: null,
      mh047: null,
      mh048: null,
      mh049: 0,
      remark: null,
    };
    proxy.resetForm("formRef")
  }


  // 添加按钮操作
  function handleAdd() {
    reset();
    open.value = true
    title.value = proxy.$t('btn.add') + " " + '人事'
    opertype.value = 1
    form.value.mh006 = 0
    form.value.mh007 = new Date('2006')
    form.value.mh009 = 0
    form.value.mh010 = 0
    form.value.mh012 = 0
    form.value.mh015 = 'CN'
    form.value.mh016 = []
    form.value.mh017 = []
    form.value.mh021 = 0
    form.value.mh023 = 0
    form.value.mh024 = 0
    form.value.mh025 = 0
    form.value.mh026 = 0
    form.value.mh027 = 0
    form.value.mh028 = 0
    form.value.mh029 = 0
    form.value.mh030 = 0
    form.value.mh031 = 0
    form.value.mh034 = new Date()
    form.value.mh035 = 0
    form.value.mh036 = 0
    form.value.mh037 = 0
    form.value.mh038 = new Date()
    form.value.mh039 = new Date()
    form.value.mh040 = new Date()
    form.value.mh041 = new Date()
    form.value.mh042 = 0
    form.value.mh043 = new Date()
    form.value.mh044 = 0
    form.value.mh045 = 0
    form.value.mh049 = 0
  }
  const filteredFormState = ref([])
  const filteredFormCity = ref([])

  function handleAlandChange() {
    console.log(form.value.mh015)
    form.value.mh016 = ''
    form.value.mh017 = ''
    filteredFormState.value = state.options.sql_global_state.filter(item => item.extLabel === form.value.mh015).map(item => ({ label: item.dictLabel, value: item.dictValue }))
    //console.log(form.value.Mh015, filteredFormState.value)
  }
  function handleStateChange() {
    console.log(form.value.mh016)
    form.value.mh017 = ''
    filteredFormCity.value = state.options.sql_global_city.filter(item => item.extLabel === form.value.mh016).map(item => ({ label: item.dictLabel, value: item.dictValue }))


  }
  function handleBirthdayChange() {
    //计算年龄
    let d = new Date()
    let age = d.getFullYear() - form.value.mh007.getFullYear() - (d.getMonth() < form.value.mh007.getMonth() || (d.getMonth() == form.value.mh007.getMonth() && d.getDate() < form.value.mh007.getDate()) ? 1 : 0);
    console.log('年龄', age)
  }

  function handleNameInput() {
    //console.log(form.value.mh002)
    if (form.value.mh002 != null && form.value.mh002 != '') {
      form.value.mh004 = (pinyin(form.value.mh002, { toneType: "none" })[0].toUpperCase() + pinyin(form.value.mh002, { toneType: "none" }).slice(1)).replace(/[^\w\u4e00-\u9fa5]/g, '')
      form.value.mh005 = (pinyin(form.value.mh002, { toneType: "none" })[0].toUpperCase() + pinyin(form.value.mh002, { toneType: "none" }).slice(1)).replace(/[^\w\u4e00-\u9fa5]/g, '')
    }
    else {
      form.value.mh004 = ''
      form.value.mh005 = ''
    }
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.id || ids.value
    getRoutineEhrEmployee(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '人事'
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
          updateRoutineEhrEmployee(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addRoutineEhrEmployee(form.value).then((res) => {
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
        return delRoutineEhrEmployee(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<人事.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Routine/RoutineEhrEmployee/export', { ...queryParams })
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