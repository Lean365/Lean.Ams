<!--
 * @Descripttion: 人事/routine_ehr_employee
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/8/26 14:44:11
 * @column：72
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="姓名" prop="eeName">
        <el-input v-model="queryParams.eeName" :placeholder="$t('btn.enterSearchPrefix')+'姓名'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="英文名" prop="eeEnglishName">
        <el-input v-model="queryParams.eeEnglishName" :placeholder="$t('btn.enterSearchPrefix')+'英文名'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="性别" prop="eeGenderId">
        <el-radio-group v-model="queryParams.eeGenderId">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_gender_type " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="出生日期">
        <el-date-picker
          v-model="dateRangeEeBirthday" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="身份证号" prop="eeIdentityCard">
        <el-input v-model="queryParams.eeIdentityCard" :placeholder="$t('btn.enterSearchPrefix')+'身份证号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="婚姻状态" prop="eeWedlockId">
        <el-radio-group v-model="queryParams.eeWedlockId">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_wedlock_state " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="民族" prop="eeNationId">
        <el-select filterable clearable   v-model="queryParams.eeNationId" :placeholder="$t('btn.selectSearchPrefix')+'民族'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nation_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="政治面貌" prop="eePoliticId">
        <el-select filterable clearable   v-model="queryParams.eePoliticId" :placeholder="$t('btn.selectSearchPrefix')+'政治面貌'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_politic_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="国家/地区" prop="eeCountry">
        <el-select filterable clearable   v-model="queryParams.eeCountry" :placeholder="$t('btn.selectSearchPrefix')+'国家/地区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_global_country " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="省区" prop="eeProvince">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" :loading="loading" v-model="queryParams.eeProvince" :placeholder="$t('btn.selectSearchPrefix')+'省区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_global_state " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="市区" prop="eeCity">
        <el-select filterable clearable   remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" :loading="loading" v-model="queryParams.eeCity" :placeholder="$t('btn.selectSearchPrefix')+'市区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   remotequery_sql_global_city " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="户口性质" prop="eeHouseholdTypeId">
        <el-radio-group v-model="queryParams.eeHouseholdTypeId">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_household_type " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="部门" prop="eeDepartmentId">
        <el-select filterable clearable   v-model="queryParams.eeDepartmentId" :placeholder="$t('btn.selectSearchPrefix')+'部门'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_dept_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="职称" prop="eeTitlesId">
        <el-select filterable clearable   v-model="queryParams.eeTitlesId" :placeholder="$t('btn.selectSearchPrefix')+'职称'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_titles_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="职位" prop="eePostId">
        <el-select filterable clearable   v-model="queryParams.eePostId" :placeholder="$t('btn.selectSearchPrefix')+'职位'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_posts_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="职级" prop="eePostLevel">
        <el-select filterable clearable   v-model="queryParams.eePostLevel" :placeholder="$t('btn.selectSearchPrefix')+'职级'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_post_level " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="招聘来源" prop="eeRecruited">
        <el-select filterable clearable   v-model="queryParams.eeRecruited" :placeholder="$t('btn.selectSearchPrefix')+'招聘来源'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_recruited_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="聘用形式" prop="eeEngageFormId">
        <el-select filterable clearable   v-model="queryParams.eeEngageFormId" :placeholder="$t('btn.selectSearchPrefix')+'聘用形式'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="学历" prop="eeEducationalBackgroundId">
        <el-select filterable clearable   v-model="queryParams.eeEducationalBackgroundId" :placeholder="$t('btn.selectSearchPrefix')+'学历'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_level_education " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="专业" prop="eeSpecialtyId">
        <el-select filterable clearable   v-model="queryParams.eeSpecialtyId" :placeholder="$t('btn.selectSearchPrefix')+'专业'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_specialty_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工号" prop="eeEmployeeId">
        <el-input v-model="queryParams.eeEmployeeId" :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="入职日期">
        <el-date-picker
          v-model="dateRangeEeJoinedDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="在职状态" prop="eeEmployedStatus">
        <el-radio-group v-model="queryParams.eeEmployedStatus">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_serve_state " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="离职日期">
        <el-date-picker
          v-model="dateRangeEeLeaveDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="合同终止日">
        <el-date-picker
          v-model="dateRangeEeContractEndDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="退休日期">
        <el-date-picker
          v-model="dateRangeEeRetirementDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="打卡否" prop="eeClockInId">
        <el-radio-group v-model="queryParams.eeClockInId">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_is_status " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="班别" prop="eeShiftsTypeId">
        <el-select filterable clearable   v-model="queryParams.eeShiftsTypeId" :placeholder="$t('btn.selectSearchPrefix')+'班别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_shifts_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['routine:ehremployee:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['routine:ehremployee:delete']" plain icon="delete" @click="handleDelete">
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
                <importData
                  templateUrl="Routine/RoutineEhrEmployee/importTemplate"
                  importUrl="/Routine/RoutineEhrEmployee/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['routine:ehremployee:export']">
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
      <el-table-column prop="eeSfId" label="ID" align="center" v-if="columns.showColumn('eeSfId')"/>
      <el-table-column prop="eeName" label="姓名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeName')"/>
      <el-table-column prop="eeNameUsed" label="曾用名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeNameUsed')"/>
      <el-table-column prop="eeNickName" label="昵称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeNickName')"/>
      <el-table-column prop="eeEnglishName" label="英文名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeEnglishName')"/>
      <el-table-column prop="eeGenderId" label="性别" align="center" v-if="columns.showColumn('eeGenderId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_gender_type " :value="scope.row.eeGenderId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeBirthday" label="出生日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeBirthday')"/>
      <el-table-column prop="eeIdentityCard" label="身份证号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeIdentityCard')"/>
      <el-table-column prop="eeWedlockId" label="婚姻状态" align="center" v-if="columns.showColumn('eeWedlockId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_wedlock_state " :value="scope.row.eeWedlockId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeNationId" label="民族" align="center" v-if="columns.showColumn('eeNationId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nation_list " :value="scope.row.eeNationId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeNativePlace" label="籍贯" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeNativePlace')"/>
      <el-table-column prop="eePoliticId" label="政治面貌" align="center" v-if="columns.showColumn('eePoliticId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_politic_list " :value="scope.row.eePoliticId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeEmail" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeEmail')"/>
      <el-table-column prop="eePhone" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eePhone')"/>
      <el-table-column prop="eeCountry" label="国家/地区" align="center" v-if="columns.showColumn('eeCountry')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_country " :value="scope.row.eeCountry"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeProvince" label="省区" align="center" v-if="columns.showColumn('eeProvince')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_state " :value="scope.row.eeProvince"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeCity" label="市区" align="center" v-if="columns.showColumn('eeCity')">
        <template #default="scope">
          <dict-tag :options=" options.sql_global_city " :value="scope.row.eeCity"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeCounty" label="县区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeCounty')"/>
      <el-table-column prop="eeHomeAddress" label="家庭住址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeHomeAddress')"/>
      <el-table-column prop="eePostCode" label="邮编" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eePostCode')"/>
      <el-table-column prop="eeHouseholdTypeId" label="户口性质" align="center" v-if="columns.showColumn('eeHouseholdTypeId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_household_type " :value="scope.row.eeHouseholdTypeId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeStayAddress" label="暂住地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeStayAddress')"/>
      <el-table-column prop="eeDepartmentId" label="部门" align="center" v-if="columns.showColumn('eeDepartmentId')">
        <template #default="scope">
          <dict-tag :options=" options.sql_dept_list " :value="scope.row.eeDepartmentId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeTitlesId" label="职称" align="center" v-if="columns.showColumn('eeTitlesId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_titles_list " :value="scope.row.eeTitlesId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eePostId" label="职位" align="center" v-if="columns.showColumn('eePostId')">
        <template #default="scope">
          <dict-tag :options=" options.sql_posts_list " :value="scope.row.eePostId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eePostLevel" label="职级" align="center" v-if="columns.showColumn('eePostLevel')">
        <template #default="scope">
          <dict-tag :options=" options.sys_post_level " :value="scope.row.eePostLevel"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeDutyId" label="职务" align="center" v-if="columns.showColumn('eeDutyId')">
        <template #default="scope">
          <dict-tag :options=" options.sql_posts_list " :value="scope.row.eeDutyId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeRecruited" label="招聘来源" align="center" v-if="columns.showColumn('eeRecruited')">
        <template #default="scope">
          <dict-tag :options=" options.sys_recruited_list " :value="scope.row.eeRecruited"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeEngageFormId" label="聘用形式" align="center" v-if="columns.showColumn('eeEngageFormId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_employ_term " :value="scope.row.eeEngageFormId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeEducationalBackgroundId" label="学历" align="center" v-if="columns.showColumn('eeEducationalBackgroundId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_level_education " :value="scope.row.eeEducationalBackgroundId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeSpecialtyId" label="专业" align="center" v-if="columns.showColumn('eeSpecialtyId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_specialty_list " :value="scope.row.eeSpecialtyId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeCollegeName" label="院校" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeCollegeName')"/>
      <el-table-column prop="eeEmployeeId" label="工号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeEmployeeId')"/>
      <el-table-column prop="eeJoinedDate" label="入职日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeJoinedDate')"/>
      <el-table-column prop="eeEmployedStatus" label="在职状态" align="center" v-if="columns.showColumn('eeEmployedStatus')">
        <template #default="scope">
          <dict-tag :options=" options.sys_serve_state " :value="scope.row.eeEmployedStatus"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeProbationPeriod" label="试用期" align="center" v-if="columns.showColumn('eeProbationPeriod')"/>
      <el-table-column prop="eeContractPeriod" label="合同期限" align="center" v-if="columns.showColumn('eeContractPeriod')"/>
      <el-table-column prop="eePositiveDate" label="转正日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eePositiveDate')"/>
      <el-table-column prop="eeLeaveDate" label="离职日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeLeaveDate')"/>
      <el-table-column prop="eeContractBeginDate" label="合同起始日" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeContractBeginDate')"/>
      <el-table-column prop="eeContractEndDate" label="合同终止日" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeContractEndDate')"/>
      <el-table-column prop="eeSeniority" label="工龄" align="center" v-if="columns.showColumn('eeSeniority')"/>
      <el-table-column prop="eeRetirementDate" label="退休日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeRetirementDate')"/>
      <el-table-column prop="eeClockInId" label="打卡否" align="center" v-if="columns.showColumn('eeClockInId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_is_status " :value="scope.row.eeClockInId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeShiftsTypeId" label="班别" align="center" v-if="columns.showColumn('eeShiftsTypeId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_shifts_list " :value="scope.row.eeShiftsTypeId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeAvatarFileUrl" label="头像" align="center" v-if="columns.showColumn('eeAvatarFileUrl')">
        <template #default="scope">
          <ImagePreview :src="scope.row.eeAvatarFileUrl"></ImagePreview>
        </template>
      </el-table-column>
      <el-table-column prop="eeQualificationFileUrl" label="学历附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeQualificationFileUrl')"/>
      <el-table-column prop="eeTitleFileUrl" label="职称附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeTitleFileUrl')"/>
      <el-table-column prop="rEF01" label="预留A" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rEF01')"/>
      <el-table-column prop="rEF02" label="预留B" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rEF02')"/>
      <el-table-column prop="rEF03" label="预留C" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('rEF03')"/>
      <el-table-column prop="rEF04" label="预留1" align="center" v-if="columns.showColumn('rEF04')"/>
      <el-table-column prop="rEF05" label="预留2" align="center" v-if="columns.showColumn('rEF05')"/>
      <el-table-column prop="rEF06" label="预留3" align="center" v-if="columns.showColumn('rEF06')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['routine:ehremployee:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['routine:ehremployee:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改人事对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="姓名" prop="eeName">
              <el-input v-model="form.eeName" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="曾用名" prop="eeNameUsed">
              <el-input v-model="form.eeNameUsed" :placeholder="$t('btn.enterPrefix')+'曾用名'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="昵称" prop="eeNickName">
              <el-input v-model="form.eeNickName" :placeholder="$t('btn.enterPrefix')+'昵称'+$t('btn.enterSuffix')"  show-word-limit maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="英文名" prop="eeEnglishName">
              <el-input v-model="form.eeEnglishName" :placeholder="$t('btn.enterPrefix')+'英文名'+$t('btn.enterSuffix')"  show-word-limit maxlength="200"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="性别" prop="eeGenderId">
              <el-radio-group v-model="form.eeGenderId">
                <el-radio v-for="item in options.sys_gender_type" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="出生日期" prop="eeBirthday">
              <el-date-picker v-model="form.eeBirthday" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="身份证号" prop="eeIdentityCard">
              <el-input v-model="form.eeIdentityCard" :placeholder="$t('btn.enterPrefix')+'身份证号'+$t('btn.enterSuffix')"  show-word-limit maxlength="18"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="婚姻状态" prop="eeWedlockId">
              <el-radio-group v-model="form.eeWedlockId">
                <el-radio v-for="item in options.sys_wedlock_state" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="民族" prop="eeNationId">
              <el-select filterable clearable   v-model="form.eeNationId"  :placeholder="$t('btn.selectPrefix')+'民族'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_nation_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="籍贯" prop="eeNativePlace">
              <el-input v-model="form.eeNativePlace" :placeholder="$t('btn.enterPrefix')+'籍贯'+$t('btn.enterSuffix')"  show-word-limit maxlength="100"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="政治面貌" prop="eePoliticId">
              <el-select filterable clearable   v-model="form.eePoliticId"  :placeholder="$t('btn.selectPrefix')+'政治面貌'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_politic_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="邮件" prop="eeEmail">
              <el-input v-model="form.eeEmail" :placeholder="$t('btn.enterPrefix')+'邮件'+$t('btn.enterSuffix')"  show-word-limit maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="eePhone">
              <el-input v-model="form.eePhone" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')"  show-word-limit maxlength="11"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家/地区" prop="eeCountry">
              <el-select filterable clearable   v-model="form.eeCountry"  :placeholder="$t('btn.selectPrefix')+'国家/地区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_global_country" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="省区" prop="eeProvince">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_state" 
              :loading="loading" v-model="form.eeProvince"  :placeholder="$t('btn.selectPrefix')+'省区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="市区" prop="eeCity">
              <el-select filterable clearable  remote remote-show-suffix :remote-method="remoteMethod_sql_global_city" 
              :loading="loading" v-model="form.eeCity"  :placeholder="$t('btn.selectPrefix')+'市区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  remotequery_sql_global_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="县区" prop="eeCounty">
              <el-input v-model="form.eeCounty" :placeholder="$t('btn.enterPrefix')+'县区'+$t('btn.enterSuffix')"  show-word-limit maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="家庭住址" prop="eeHomeAddress">
              <el-input v-model="form.eeHomeAddress" :placeholder="$t('btn.enterPrefix')+'家庭住址'+$t('btn.enterSuffix')"  show-word-limit maxlength="128"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮编" prop="eePostCode">
              <el-input v-model="form.eePostCode" :placeholder="$t('btn.enterPrefix')+'邮编'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="户口性质" prop="eeHouseholdTypeId">
              <el-radio-group v-model="form.eeHouseholdTypeId">
                <el-radio v-for="item in options.sys_household_type" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="暂住地址" prop="eeStayAddress">
              <el-input v-model="form.eeStayAddress" :placeholder="$t('btn.enterPrefix')+'暂住地址'+$t('btn.enterSuffix')"  show-word-limit maxlength="128"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="部门" prop="eeDepartmentId">
              <el-select filterable clearable   v-model="form.eeDepartmentId"  :placeholder="$t('btn.selectPrefix')+'部门'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_dept_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="职称" prop="eeTitlesId">
              <el-select filterable clearable   v-model="form.eeTitlesId"  :placeholder="$t('btn.selectPrefix')+'职称'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_titles_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="职位" prop="eePostId">
              <el-select filterable clearable   v-model="form.eePostId"  :placeholder="$t('btn.selectPrefix')+'职位'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_posts_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="职级" prop="eePostLevel">
              <el-select filterable clearable   v-model="form.eePostLevel"  :placeholder="$t('btn.selectPrefix')+'职级'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_post_level" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="职务" prop="eeDutyId">
              <el-select filterable clearable   v-model="form.eeDutyId"  :placeholder="$t('btn.selectPrefix')+'职务'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_posts_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="招聘来源" prop="eeRecruited">
              <el-select filterable clearable   v-model="form.eeRecruited"  :placeholder="$t('btn.selectPrefix')+'招聘来源'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_recruited_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="聘用形式" prop="eeEngageFormId">
              <el-select filterable clearable   v-model="form.eeEngageFormId"  :placeholder="$t('btn.selectPrefix')+'聘用形式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_employ_term" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="学历" prop="eeEducationalBackgroundId">
              <el-select filterable clearable   v-model="form.eeEducationalBackgroundId"  :placeholder="$t('btn.selectPrefix')+'学历'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_level_education" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="专业" prop="eeSpecialtyId">
              <el-select filterable clearable   v-model="form.eeSpecialtyId"  :placeholder="$t('btn.selectPrefix')+'专业'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_specialty_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="院校" prop="eeCollegeName">
              <el-input v-model="form.eeCollegeName" :placeholder="$t('btn.enterPrefix')+'院校'+$t('btn.enterSuffix')"  show-word-limit maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工号" prop="eeEmployeeId">
              <el-input v-model="form.eeEmployeeId" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')"  show-word-limit maxlength="8"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="入职日期" prop="eeJoinedDate">
              <el-date-picker v-model="form.eeJoinedDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="在职状态" prop="eeEmployedStatus">
              <el-radio-group v-model="form.eeEmployedStatus">
                <el-radio v-for="item in options.sys_serve_state" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="试用期" prop="eeProbationPeriod">
              <el-input-number v-model.number="form.eeProbationPeriod" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'试用期'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="合同期限" prop="eeContractPeriod">
              <el-input-number v-model.number="form.eeContractPeriod" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'合同期限'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转正日期" prop="eePositiveDate">
              <el-date-picker v-model="form.eePositiveDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="离职日期" prop="eeLeaveDate">
              <el-date-picker v-model="form.eeLeaveDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同起始日" prop="eeContractBeginDate">
              <el-date-picker v-model="form.eeContractBeginDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同终止日" prop="eeContractEndDate">
              <el-date-picker v-model="form.eeContractEndDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="工龄" prop="eeSeniority">
              <el-input-number v-model.number="form.eeSeniority" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工龄'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="退休日期" prop="eeRetirementDate">
              <el-date-picker v-model="form.eeRetirementDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="打卡否" prop="eeClockInId">
              <el-radio-group v-model="form.eeClockInId">
                <el-radio v-for="item in options.sys_is_status" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="班别" prop="eeShiftsTypeId">
              <el-select filterable clearable   v-model="form.eeShiftsTypeId"  :placeholder="$t('btn.selectPrefix')+'班别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_shifts_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="24">
            <el-form-item label="头像" prop="eeAvatarFileUrl">
              <UploadImage v-model="form.eeAvatarFileUrl" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="学历附件" prop="eeQualificationFileUrl">
              <UploadFile v-model="form.eeQualificationFileUrl" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="职称附件" prop="eeTitleFileUrl">
              <UploadFile v-model="form.eeTitleFileUrl" :data="{ uploadType: 1 }" />
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

<script setup name="routineehremployee">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listRoutineEhrEmployee,
 addRoutineEhrEmployee, delRoutineEhrEmployee, 
 updateRoutineEhrEmployee,getRoutineEhrEmployee, 
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
  sort: 'EeJoinedDate',
  sortType: 'desc',
//是否查询（1是）
  eeName: undefined,
//是否查询（1是）
  eeEnglishName: undefined,
//是否查询（1是）
  eeGenderId: undefined,
//是否查询（1是）
  eeBirthday: undefined,
//是否查询（1是）
  eeIdentityCard: undefined,
//是否查询（1是）
  eeWedlockId: undefined,
//是否查询（1是）
  eeNationId: undefined,
//是否查询（1是）
  eePoliticId: undefined,
//是否查询（1是）
  eeCountry: undefined,
//是否查询（1是）
  eeProvince: undefined,
//是否查询（1是）
  eeCity: undefined,
//是否查询（1是）
  eeHouseholdTypeId: undefined,
//是否查询（1是）
  eeDepartmentId: undefined,
//是否查询（1是）
  eeTitlesId: undefined,
//是否查询（1是）
  eePostId: undefined,
//是否查询（1是）
  eePostLevel: undefined,
//是否查询（1是）
  eeRecruited: undefined,
//是否查询（1是）
  eeEngageFormId: undefined,
//是否查询（1是）
  eeEducationalBackgroundId: undefined,
//是否查询（1是）
  eeSpecialtyId: undefined,
//是否查询（1是）
  eeEmployeeId: undefined,
//是否查询（1是）
  eeJoinedDate: undefined,
//是否查询（1是）
  eeEmployedStatus: undefined,
//是否查询（1是）
  eeLeaveDate: undefined,
//是否查询（1是）
  eeContractEndDate: undefined,
//是否查询（1是）
  eeRetirementDate: undefined,
//是否查询（1是）
  eeClockInId: undefined,
//是否查询（1是）
  eeShiftsTypeId: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'eeSfId', label: 'ID' },
  { visible: true, prop: 'eeName', label: '姓名' },
  { visible: true, prop: 'eeNameUsed', label: '曾用名' },
  { visible: true, prop: 'eeNickName', label: '昵称' },
  { visible: true, prop: 'eeEnglishName', label: '英文名' },
  { visible: true, prop: 'eeGenderId', label: '性别' },
  { visible: true, prop: 'eeBirthday', label: '出生日期' },
  { visible: true, prop: 'eeIdentityCard', label: '身份证号' },
  { visible: false, prop: 'eeWedlockId', label: '婚姻状态' },
  { visible: false, prop: 'eeNationId', label: '民族' },
  { visible: false, prop: 'eeNativePlace', label: '籍贯' },
  { visible: false, prop: 'eePoliticId', label: '政治面貌' },
  { visible: false, prop: 'eeEmail', label: '邮件' },
  { visible: false, prop: 'eePhone', label: '电话' },
  { visible: false, prop: 'eeCountry', label: '国家/地区' },
  { visible: false, prop: 'eeProvince', label: '省区' },
  { visible: false, prop: 'eeCity', label: '市区' },
  { visible: false, prop: 'eeCounty', label: '县区' },
  { visible: false, prop: 'eeHomeAddress', label: '家庭住址' },
  { visible: false, prop: 'eePostCode', label: '邮编' },
  { visible: false, prop: 'eeHouseholdTypeId', label: '户口性质' },
  { visible: false, prop: 'eeStayAddress', label: '暂住地址' },
  { visible: false, prop: 'eeDepartmentId', label: '部门' },
  { visible: false, prop: 'eeTitlesId', label: '职称' },
  { visible: false, prop: 'eePostId', label: '职位' },
  { visible: false, prop: 'eePostLevel', label: '职级' },
  { visible: false, prop: 'eeDutyId', label: '职务' },
  { visible: false, prop: 'eeRecruited', label: '招聘来源' },
  { visible: false, prop: 'eeEngageFormId', label: '聘用形式' },
  { visible: false, prop: 'eeEducationalBackgroundId', label: '学历' },
  { visible: false, prop: 'eeSpecialtyId', label: '专业' },
  { visible: false, prop: 'eeCollegeName', label: '院校' },
  { visible: false, prop: 'eeEmployeeId', label: '工号' },
  { visible: false, prop: 'eeJoinedDate', label: '入职日期' },
  { visible: false, prop: 'eeEmployedStatus', label: '在职状态' },
  { visible: false, prop: 'eeProbationPeriod', label: '试用期' },
  { visible: false, prop: 'eeContractPeriod', label: '合同期限' },
  { visible: false, prop: 'eePositiveDate', label: '转正日期' },
  { visible: false, prop: 'eeLeaveDate', label: '离职日期' },
  { visible: false, prop: 'eeContractBeginDate', label: '合同起始日' },
  { visible: false, prop: 'eeContractEndDate', label: '合同终止日' },
  { visible: false, prop: 'eeSeniority', label: '工龄' },
  { visible: false, prop: 'eeRetirementDate', label: '退休日期' },
  { visible: false, prop: 'eeClockInId', label: '打卡否' },
  { visible: false, prop: 'eeShiftsTypeId', label: '班别' },
  { visible: false, prop: 'eeAvatarFileUrl', label: '头像' },
  { visible: false, prop: 'eeQualificationFileUrl', label: '学历附件' },
  { visible: false, prop: 'eeTitleFileUrl', label: '职称附件' },
  { visible: false, prop: 'rEF01', label: '预留A' },
  { visible: false, prop: 'rEF02', label: '预留B' },
  { visible: false, prop: 'rEF03', label: '预留C' },
  { visible: false, prop: 'rEF04', label: '预留1' },
  { visible: false, prop: 'rEF05', label: '预留2' },
  { visible: false, prop: 'rEF06', label: '预留3' },
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
const dateRangeEeBirthday = ref([])
//定义远程搜索变量
const remotequeryList_sql_global_state=ref([])
//定义远程搜索变量
const remotequery_sql_global_state=ref([])
//远程字典参数
var remotedictParams_sql_global_state = [
    { dictType: "sql_global_state" },
]
//远程搜索组件实例
onMounted(() => {
    proxy.getDicts(remotedictParams_sql_global_state).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_global_state.value = element.list
      })
      //console.log(remotequeryList_sql_global_state)
    })
  })
//远程搜索
const remoteMethod_sql_global_state = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_global_state.value = remotequeryList_sql_global_state.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_global_state(query)
      }, 2000)
    } else {
     //默认显示前15条记录
      remotequery_sql_global_state.value.slice(0, 15)
    }
  }, 300)
// 筛选方法
const filterMethod_sql_global_state = debounce((query) => {
    let arr = remotequeryList_sql_global_state.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_global_state.value = arr.slice(0, 5)
      addFilterOptions_sql_global_state(query)
    } else {
      remotequery_sql_global_state.value = arr
    }
  }, 300)
// 精准筛选方法
const addFilterOptions_sql_global_state =debounce((dictValue) => {
    let target = remotequeryList_sql_global_state.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_global_state.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_global_state.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
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
// 入职日期时间范围
const dateRangeEeJoinedDate = ref([])
// 离职日期时间范围
const dateRangeEeLeaveDate = ref([])
// 合同终止日时间范围
const dateRangeEeContractEndDate = ref([])
// 退休日期时间范围
const dateRangeEeRetirementDate = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_gender_type" },
  { dictType: "sys_wedlock_state" },
  { dictType: "sys_nation_list" },
  { dictType: "sys_politic_list" },
  { dictType: "sql_global_country" },
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
  { dictType: "sys_is_deleted" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从人事/routine_ehr_employee表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeEeBirthday.value, 'EeBirthday');
  proxy.addDateRange(queryParams, dateRangeEeJoinedDate.value, 'EeJoinedDate');
  proxy.addDateRange(queryParams, dateRangeEeLeaveDate.value, 'EeLeaveDate');
  proxy.addDateRange(queryParams, dateRangeEeContractEndDate.value, 'EeContractEndDate');
  proxy.addDateRange(queryParams, dateRangeEeRetirementDate.value, 'EeRetirementDate');
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
function resetQuery(){
  // 出生日期时间范围
  dateRangeEeBirthday.value = []
  // 入职日期时间范围
  dateRangeEeJoinedDate.value = []
  // 离职日期时间范围
  dateRangeEeLeaveDate.value = []
  // 合同终止日时间范围
  dateRangeEeContractEndDate.value = []
  // 退休日期时间范围
  dateRangeEeRetirementDate.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.eeSfId);
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
    eeSfId: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    eeName: [{ required: true, message: "姓名"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeGenderId: [{ required: true, message: "性别"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    eeBirthday: [{ required: true, message: "出生日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeIdentityCard: [{ required: true, message: "身份证号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeWedlockId: [{ required: true, message: "婚姻状态"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    eeNationId: [{ required: true, message: "民族"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeNativePlace: [{ required: true, message: "籍贯"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eePoliticId: [{ required: true, message: "政治面貌"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeCountry: [{ required: true, message: "国家/地区"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    eeProvince: [{ required: true, message: "省区"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeCity: [{ required: true, message: "市区"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeCounty: [{ required: true, message: "县区"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeHouseholdTypeId: [{ required: true, message: "户口性质"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    eeDepartmentId: [{ required: true, message: "部门"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeEmployeeId: [{ required: true, message: "工号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeJoinedDate: [{ required: true, message: "入职日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeClockInId: [{ required: true, message: "打卡否"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    eeShiftsTypeId: [{ required: true, message: "班别"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
  },
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
    eeSfId: 0,
    eeName: null,
    eeNameUsed: null,
    eeNickName: null,
    eeEnglishName: null,
    eeGenderId: 0,
    eeBirthday: null,
    eeIdentityCard: null,
    eeWedlockId: 0,
    eeNationId: 0,
    eeNativePlace: null,
    eePoliticId: 0,
    eeEmail: null,
    eePhone: null,
    eeCountry: null,
    eeProvinceChecked: [],
    eeCityChecked: [],
    eeCounty: null,
    eeHomeAddress: null,
    eePostCode: null,
    eeHouseholdTypeId: 0,
    eeStayAddress: null,
    eeDepartmentId: 0,
    eeTitlesId: 0,
    eePostId: 0,
    eePostLevel: 0,
    eeDutyId: 0,
    eeRecruited: 0,
    eeEngageFormId: 0,
    eeEducationalBackgroundId: 0,
    eeSpecialtyId: 0,
    eeCollegeName: null,
    eeEmployeeId: null,
    eeJoinedDate: null,
    eeEmployedStatus: 0,
    eeProbationPeriod: 0,
    eeContractPeriod: 0,
    eePositiveDate: null,
    eeLeaveDate: null,
    eeContractBeginDate: null,
    eeContractEndDate: null,
    eeSeniority: 0,
    eeRetirementDate: null,
    eeClockInId: 0,
    eeShiftsTypeId: 0,
    eeAvatarFileUrl: null,
    eeQualificationFileUrl: null,
    eeTitleFileUrl: null,
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
  title.value = proxy.$t('btn.add')+" "+'人事'
  opertype.value = 1
  form.value.eeGenderId= 0
  form.value.eeBirthday= new Date()
  form.value.eeWedlockId= 0
  form.value.eeNationId= 0
  form.value.eePoliticId= 0
  form.value.eeCountry= []
  form.value.eeHouseholdTypeId= 0
  form.value.eeDepartmentId= 0
  form.value.eeTitlesId= 0
  form.value.eePostId= 0
  form.value.eePostLevel= 0
  form.value.eeDutyId= 0
  form.value.eeRecruited= 0
  form.value.eeEngageFormId= 0
  form.value.eeEducationalBackgroundId= 0
  form.value.eeSpecialtyId= 0
  form.value.eeJoinedDate= new Date()
  form.value.eeEmployedStatus= 0
  form.value.eeProbationPeriod= 0
  form.value.eeContractPeriod= 0
  form.value.eePositiveDate= new Date()
  form.value.eeLeaveDate= new Date()
  form.value.eeContractBeginDate= new Date()
  form.value.eeContractEndDate= new Date()
  form.value.eeSeniority= 0
  form.value.eeRetirementDate= new Date()
  form.value.eeClockInId= 0
  form.value.eeShiftsTypeId= 0
  form.value.rEF04= 0
  form.value.rEF05= 0
  form.value.rEF06= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.eeSfId || ids.value
  getRoutineEhrEmployee(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '人事'
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

      if (form.value.eeSfId != undefined && opertype.value === 2) {
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
  const Ids = row.eeSfId || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<人事.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
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