<!--
 * @Descripttion: 人事/routine_ehr_employee
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/25 11:51:07
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
      <el-form-item label="性别" prop="eeGender">
        <el-select filterable clearable   v-model="queryParams.eeGender" :placeholder="$t('btn.selectSearchPrefix')+'性别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in  options.eeGenderOptions" :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
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
      <el-form-item label="婚姻状态" prop="eeWedlock">
        <el-select filterable clearable   v-model="queryParams.eeWedlock" :placeholder="$t('btn.selectSearchPrefix')+'婚姻状态'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_wedlock_state " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="民族" prop="eeNationId">
        <el-select filterable clearable   v-model="queryParams.eeNationId" :placeholder="$t('btn.selectSearchPrefix')+'民族'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nation_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="籍贯" prop="eeNativePlace">
        <el-select filterable clearable   v-model="queryParams.eeNativePlace" :placeholder="$t('btn.selectSearchPrefix')+'籍贯'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_region_city " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="国家/地区" prop="eeCountry">
        <el-select filterable clearable   v-model="queryParams.eeCountry" :placeholder="$t('btn.selectSearchPrefix')+'国家/地区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_country_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="省区" prop="eeProvince">
        <el-select filterable clearable   v-model="queryParams.eeProvince" :placeholder="$t('btn.selectSearchPrefix')+'省区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_region_province " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="市区" prop="eeCity">
        <el-select filterable clearable   v-model="queryParams.eeCity" :placeholder="$t('btn.selectSearchPrefix')+'市区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_region_city " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="县区" prop="eeCounty">
        <el-select filterable clearable   v-model="queryParams.eeCounty" :placeholder="$t('btn.selectSearchPrefix')+'县区'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_region_county " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="家庭住址" prop="eeHomeAddress">
        <el-input v-model="queryParams.eeHomeAddress" :placeholder="$t('btn.enterSearchPrefix')+'家庭住址'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="户口性质" prop="eeHouseholdType">
        <el-select filterable clearable   v-model="queryParams.eeHouseholdType" :placeholder="$t('btn.selectSearchPrefix')+'户口性质'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_household_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="暂住地址" prop="eeStayAddress">
        <el-input v-model="queryParams.eeStayAddress" :placeholder="$t('btn.enterSearchPrefix')+'暂住地址'+$t('btn.enterSearchSuffix')" />
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
      <el-form-item label="职务" prop="eeDutyName">
        <el-select filterable clearable   v-model="queryParams.eeDutyName" :placeholder="$t('btn.selectSearchPrefix')+'职务'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sql_posts_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
      <el-form-item label="聘用形式" prop="eeEngageForm">
        <el-select filterable clearable   v-model="queryParams.eeEngageForm" :placeholder="$t('btn.selectSearchPrefix')+'聘用形式'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_employ_term " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="学历" prop="eeTiptopDegrEe">
        <el-select filterable clearable   v-model="queryParams.eeTiptopDegrEe" :placeholder="$t('btn.selectSearchPrefix')+'学历'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_level_education " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="专业" prop="eeSpecialty">
        <el-select filterable clearable   v-model="queryParams.eeSpecialty" :placeholder="$t('btn.selectSearchPrefix')+'专业'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_specialty_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="工号" prop="eeWorkID">
        <el-input v-model="queryParams.eeWorkID" :placeholder="$t('btn.enterSearchPrefix')+'工号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="入职日期">
        <el-date-picker
          v-model="dateRangeEeBeginDate" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="在职状态" prop="eeWorkState">
        <el-radio-group v-model="queryParams.eeWorkState">
          <el-radio>{{$t('common.all')}}</el-radio>
          <el-radio v-for="item in  options.sys_serve_state " :key="item.dictValue" :value="item.dictValue">{{item.dictLabel}}</el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="转正日期">
        <el-date-picker
          v-model="dateRangeEeConversionTime" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
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
      <el-form-item label="合同起始日">
        <el-date-picker
          v-model="dateRangeEeBeginContract" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
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
                  templateUrl="Routine/EhrEmployee/importTemplate"
                  importUrl="/Routine/EhrEmployee/importData"
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
      <el-table-column prop="eeSFID" label="SFID" align="center" v-if="columns.showColumn('eeSFID')"/>
      <el-table-column prop="eeName" label="姓名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeName')"/>
      <el-table-column prop="eeNameUsed" label="曾用名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeNameUsed')"/>
      <el-table-column prop="eeNickName" label="昵称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeNickName')"/>
      <el-table-column prop="eeEnglishName" label="英文名" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeEnglishName')"/>
      <el-table-column prop="eeGender" label="性别" align="center" v-if="columns.showColumn('eeGender')">
        <template #default="scope">
          <dict-tag :options=" options.eeGenderOptions" :value="scope.row.eeGender"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeBirthday" label="出生日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeBirthday')"/>
      <el-table-column prop="eeIdentityCard" label="身份证号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeIdentityCard')"/>
      <el-table-column prop="eeWedlock" label="婚姻状态" align="center" v-if="columns.showColumn('eeWedlock')">
        <template #default="scope">
          <dict-tag :options=" options.sys_wedlock_state " :value="scope.row.eeWedlock"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeNationId" label="民族" align="center" v-if="columns.showColumn('eeNationId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nation_list " :value="scope.row.eeNationId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeNativePlace" label="籍贯" align="center" v-if="columns.showColumn('eeNativePlace')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_city " :value="scope.row.eeNativePlace"  />
        </template>
      </el-table-column>
      <el-table-column prop="eePoliticId" label="政治面貌" align="center" v-if="columns.showColumn('eePoliticId')">
        <template #default="scope">
          <dict-tag :options=" options.sys_politic_list " :value="scope.row.eePoliticId"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeEmail" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeEmail')"/>
      <el-table-column prop="eePhone" label="电话" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eePhone')"/>
      <el-table-column prop="eeCountry" label="国家/地区" align="center" v-if="columns.showColumn('eeCountry')">
        <template #default="scope">
          <dict-tag :options=" options.sys_country_list " :value="scope.row.eeCountry"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeProvince" label="省区" align="center" v-if="columns.showColumn('eeProvince')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_province " :value="scope.row.eeProvince"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeCity" label="市区" align="center" v-if="columns.showColumn('eeCity')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_city " :value="scope.row.eeCity"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeCounty" label="县区" align="center" v-if="columns.showColumn('eeCounty')">
        <template #default="scope">
          <dict-tag :options=" options.sql_region_county " :value="scope.row.eeCounty"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeHomeAddress" label="家庭住址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeHomeAddress')"/>
      <el-table-column prop="eePostCode" label="邮编" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eePostCode')"/>
      <el-table-column prop="eeHouseholdType" label="户口性质" align="center" v-if="columns.showColumn('eeHouseholdType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_household_type " :value="scope.row.eeHouseholdType"  />
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
      <el-table-column prop="eeDutyName" label="职务" align="center" v-if="columns.showColumn('eeDutyName')">
        <template #default="scope">
          <dict-tag :options=" options.sql_posts_list " :value="scope.row.eeDutyName"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeRecruited" label="招聘来源" align="center" v-if="columns.showColumn('eeRecruited')">
        <template #default="scope">
          <dict-tag :options=" options.sys_recruited_list " :value="scope.row.eeRecruited"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeEngageForm" label="聘用形式" align="center" v-if="columns.showColumn('eeEngageForm')">
        <template #default="scope">
          <dict-tag :options=" options.sys_employ_term " :value="scope.row.eeEngageForm"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeTiptopDegrEe" label="学历" align="center" v-if="columns.showColumn('eeTiptopDegrEe')">
        <template #default="scope">
          <dict-tag :options=" options.sys_level_education " :value="scope.row.eeTiptopDegrEe"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeSpecialty" label="专业" align="center" v-if="columns.showColumn('eeSpecialty')">
        <template #default="scope">
          <dict-tag :options=" options.sys_specialty_list " :value="scope.row.eeSpecialty"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeSchool" label="院校" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeSchool')"/>
      <el-table-column prop="eeWorkID" label="工号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeWorkID')"/>
      <el-table-column prop="eeBeginDate" label="入职日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeBeginDate')"/>
      <el-table-column prop="eeWorkState" label="在职状态" align="center" v-if="columns.showColumn('eeWorkState')">
        <template #default="scope">
          <dict-tag :options=" options.sys_serve_state " :value="scope.row.eeWorkState"  />
        </template>
      </el-table-column>
      <el-table-column prop="eeProbation" label="试用期" align="center" v-if="columns.showColumn('eeProbation')"/>
      <el-table-column prop="eeContractTerm" label="合同期限" align="center" v-if="columns.showColumn('eeContractTerm')"/>
      <el-table-column prop="eeConversionTime" label="转正日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeConversionTime')"/>
      <el-table-column prop="eeLeaveDate" label="离职日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeLeaveDate')"/>
      <el-table-column prop="eeBeginContract" label="合同起始日" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeBeginContract')"/>
      <el-table-column prop="eeBndContract" label="合同终止日" :show-overflow-tooltip="true"  v-if="columns.showColumn('eeBndContract')"/>
      <el-table-column prop="eeWorkAge" label="工龄" align="center" v-if="columns.showColumn('eeWorkAge')"/>
      <el-table-column prop="eeAvatar" label="头像" align="center" v-if="columns.showColumn('eeAvatar')">
        <template #default="scope">
          <ImagePreview :src="scope.row.eeAvatar"></ImagePreview>
        </template>
      </el-table-column>
      <el-table-column prop="eeQualificationAnnex" label="学历附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeQualificationAnnex')"/>
      <el-table-column prop="eeTitleAnnex" label="职称附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('eeTitleAnnex')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
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
            <el-form-item label="SFID" prop="eeSFID">
              <el-input v-model.number="form.eeSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="姓名" prop="eeName">
              <el-input v-model="form.eeName" :placeholder="$t('btn.enterPrefix')+'姓名'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="曾用名" prop="eeNameUsed">
              <el-input v-model="form.eeNameUsed" :placeholder="$t('btn.enterPrefix')+'曾用名'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="昵称" prop="eeNickName">
              <el-input v-model="form.eeNickName" :placeholder="$t('btn.enterPrefix')+'昵称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="英文名" prop="eeEnglishName">
              <el-input v-model="form.eeEnglishName" :placeholder="$t('btn.enterPrefix')+'英文名'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="性别" prop="eeGender">
              <el-select filterable clearable   v-model="form.eeGender"  :placeholder="$t('btn.selectPrefix')+'性别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.eeGenderOptions" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="出生日期" prop="eeBirthday">
              <el-date-picker v-model="form.eeBirthday" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="身份证号" prop="eeIdentityCard">
              <el-input v-model="form.eeIdentityCard" :placeholder="$t('btn.enterPrefix')+'身份证号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="婚姻状态" prop="eeWedlock">
              <el-select filterable clearable   v-model="form.eeWedlock"  :placeholder="$t('btn.selectPrefix')+'婚姻状态'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_wedlock_state" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
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
              <el-select filterable clearable   v-model="form.eeNativePlace"  :placeholder="$t('btn.selectPrefix')+'籍贯'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_region_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
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
              <el-input v-model="form.eeEmail" :placeholder="$t('btn.enterPrefix')+'邮件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="电话" prop="eePhone">
              <el-input v-model="form.eePhone" :placeholder="$t('btn.enterPrefix')+'电话'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="国家/地区" prop="eeCountry">
              <el-select filterable clearable   v-model="form.eeCountry"  :placeholder="$t('btn.selectPrefix')+'国家/地区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_country_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="省区" prop="eeProvince">
              <el-select filterable clearable   v-model="form.eeProvince"  :placeholder="$t('btn.selectPrefix')+'省区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_region_province" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="市区" prop="eeCity">
              <el-select filterable clearable   v-model="form.eeCity"  :placeholder="$t('btn.selectPrefix')+'市区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_region_city" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="县区" prop="eeCounty">
              <el-select filterable clearable   v-model="form.eeCounty"  :placeholder="$t('btn.selectPrefix')+'县区'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sql_region_county" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="家庭住址" prop="eeHomeAddress">
              <el-input v-model="form.eeHomeAddress" :placeholder="$t('btn.enterPrefix')+'家庭住址'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮编" prop="eePostCode">
              <el-input v-model="form.eePostCode" :placeholder="$t('btn.enterPrefix')+'邮编'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="户口性质" prop="eeHouseholdType">
              <el-select filterable clearable   v-model="form.eeHouseholdType"  :placeholder="$t('btn.selectPrefix')+'户口性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_household_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="暂住地址" prop="eeStayAddress">
              <el-input v-model="form.eeStayAddress" :placeholder="$t('btn.enterPrefix')+'暂住地址'+$t('btn.enterSuffix')" />
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
            <el-form-item label="职务" prop="eeDutyName">
              <el-select filterable clearable   v-model="form.eeDutyName"  :placeholder="$t('btn.selectPrefix')+'职务'+$t('btn.selectSuffix')">
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
            <el-form-item label="聘用形式" prop="eeEngageForm">
              <el-select filterable clearable   v-model="form.eeEngageForm"  :placeholder="$t('btn.selectPrefix')+'聘用形式'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_employ_term" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="学历" prop="eeTiptopDegrEe">
              <el-select filterable clearable   v-model="form.eeTiptopDegrEe"  :placeholder="$t('btn.selectPrefix')+'学历'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_level_education" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

            
          <el-col :lg="12">
            <el-form-item label="专业" prop="eeSpecialty">
              <el-select filterable clearable   v-model="form.eeSpecialty"  :placeholder="$t('btn.selectPrefix')+'专业'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_specialty_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="院校" prop="eeSchool">
              <el-input v-model="form.eeSchool" :placeholder="$t('btn.enterPrefix')+'院校'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工号" prop="eeWorkID">
              <el-input v-model="form.eeWorkID" :placeholder="$t('btn.enterPrefix')+'工号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="入职日期" prop="eeBeginDate">
              <el-date-picker v-model="form.eeBeginDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="在职状态" prop="eeWorkState">
              <el-radio-group v-model="form.eeWorkState">
                <el-radio v-for="item in options.sys_serve_state" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="试用期" prop="eeProbation">
              <el-input-number v-model.number="form.eeProbation" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'试用期'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="合同期限" prop="eeContractTerm">
              <el-input-number v-model.number="form.eeContractTerm" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'合同期限'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="转正日期" prop="eeConversionTime">
              <el-date-picker v-model="form.eeConversionTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="离职日期" prop="eeLeaveDate">
              <el-date-picker v-model="form.eeLeaveDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同起始日" prop="eeBeginContract">
              <el-date-picker v-model="form.eeBeginContract" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="合同终止日" prop="eeBndContract">
              <el-date-picker v-model="form.eeBndContract" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="工龄" prop="eeWorkAge">
              <el-input-number v-model.number="form.eeWorkAge" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'工龄'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="头像" prop="eeAvatar">
              <UploadImage v-model="form.eeAvatar" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="学历附件" prop="eeQualificationAnnex">
              <UploadFile v-model="form.eeQualificationAnnex" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="职称附件" prop="eeTitleAnnex">
              <UploadFile v-model="form.eeTitleAnnex" :data="{ uploadType: 1 }" />
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

<script setup name="ehremployee">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listEhrEmployee,
 addEhrEmployee, delEhrEmployee, 
 updateEhrEmployee,getEhrEmployee, 
 } 
from '@/api/routine/ehremployee.js'
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
  eeName: undefined,
//是否查询（1是）
  eeGender: undefined,
//是否查询（1是）
  eeBirthday: undefined,
//是否查询（1是）
  eeWedlock: undefined,
//是否查询（1是）
  eeNationId: undefined,
//是否查询（1是）
  eeNativePlace: undefined,
//是否查询（1是）
  eeCountry: undefined,
//是否查询（1是）
  eeProvince: undefined,
//是否查询（1是）
  eeCity: undefined,
//是否查询（1是）
  eeCounty: undefined,
//是否查询（1是）
  eeHomeAddress: undefined,
//是否查询（1是）
  eeHouseholdType: undefined,
//是否查询（1是）
  eeStayAddress: undefined,
//是否查询（1是）
  eeDepartmentId: undefined,
//是否查询（1是）
  eeTitlesId: undefined,
//是否查询（1是）
  eePostId: undefined,
//是否查询（1是）
  eePostLevel: undefined,
//是否查询（1是）
  eeDutyName: undefined,
//是否查询（1是）
  eeRecruited: undefined,
//是否查询（1是）
  eeEngageForm: undefined,
//是否查询（1是）
  eeTiptopDegrEe: undefined,
//是否查询（1是）
  eeSpecialty: undefined,
//是否查询（1是）
  eeWorkID: undefined,
//是否查询（1是）
  eeBeginDate: undefined,
//是否查询（1是）
  eeWorkState: undefined,
//是否查询（1是）
  eeConversionTime: undefined,
//是否查询（1是）
  eeLeaveDate: undefined,
//是否查询（1是）
  eeBeginContract: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'eeSFID', label: 'SFID' },
  { visible: true, prop: 'eeName', label: '姓名' },
  { visible: true, prop: 'eeNameUsed', label: '曾用名' },
  { visible: true, prop: 'eeNickName', label: '昵称' },
  { visible: true, prop: 'eeEnglishName', label: '英文名' },
  { visible: true, prop: 'eeGender', label: '性别' },
  { visible: true, prop: 'eeBirthday', label: '出生日期' },
  { visible: true, prop: 'eeIdentityCard', label: '身份证号' },
  { visible: false, prop: 'eeWedlock', label: '婚姻状态' },
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
  { visible: false, prop: 'eeHouseholdType', label: '户口性质' },
  { visible: false, prop: 'eeStayAddress', label: '暂住地址' },
  { visible: false, prop: 'eeDepartmentId', label: '部门' },
  { visible: false, prop: 'eeTitlesId', label: '职称' },
  { visible: false, prop: 'eePostId', label: '职位' },
  { visible: false, prop: 'eePostLevel', label: '职级' },
  { visible: false, prop: 'eeDutyName', label: '职务' },
  { visible: false, prop: 'eeRecruited', label: '招聘来源' },
  { visible: false, prop: 'eeEngageForm', label: '聘用形式' },
  { visible: false, prop: 'eeTiptopDegrEe', label: '学历' },
  { visible: false, prop: 'eeSpecialty', label: '专业' },
  { visible: false, prop: 'eeSchool', label: '院校' },
  { visible: false, prop: 'eeWorkID', label: '工号' },
  { visible: false, prop: 'eeBeginDate', label: '入职日期' },
  { visible: false, prop: 'eeWorkState', label: '在职状态' },
  { visible: false, prop: 'eeProbation', label: '试用期' },
  { visible: false, prop: 'eeContractTerm', label: '合同期限' },
  { visible: false, prop: 'eeConversionTime', label: '转正日期' },
  { visible: false, prop: 'eeLeaveDate', label: '离职日期' },
  { visible: false, prop: 'eeBeginContract', label: '合同起始日' },
  { visible: false, prop: 'eeBndContract', label: '合同终止日' },
  { visible: false, prop: 'eeWorkAge', label: '工龄' },
  { visible: false, prop: 'eeAvatar', label: '头像' },
  { visible: false, prop: 'eeQualificationAnnex', label: '学历附件' },
  { visible: false, prop: 'eeTitleAnnex', label: '职称附件' },
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
// 出生日期时间范围
const dateRangeEeBirthday = ref([])
// 入职日期时间范围
const dateRangeEeBeginDate = ref([])
// 转正日期时间范围
const dateRangeEeConversionTime = ref([])
// 离职日期时间范围
const dateRangeEeLeaveDate = ref([])
// 合同起始日时间范围
const dateRangeEeBeginContract = ref([])

//字典参数
var dictParams = [
  { dictType: "sys_wedlock_state" },
  { dictType: "sys_nation_list" },
  { dictType: "sql_region_city" },
  { dictType: "sys_politic_list" },
  { dictType: "sys_country_list" },
  { dictType: "sql_region_province" },
  { dictType: "sql_region_county" },
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
  proxy.addDateRange(queryParams, dateRangeEeBeginDate.value, 'EeBeginDate');
  proxy.addDateRange(queryParams, dateRangeEeConversionTime.value, 'EeConversionTime');
  proxy.addDateRange(queryParams, dateRangeEeLeaveDate.value, 'EeLeaveDate');
  proxy.addDateRange(queryParams, dateRangeEeBeginContract.value, 'EeBeginContract');
  loading.value = true
  listEhrEmployee(queryParams).then(res => {
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
  dateRangeEeBeginDate.value = []
  // 转正日期时间范围
  dateRangeEeConversionTime.value = []
  // 离职日期时间范围
  dateRangeEeLeaveDate.value = []
  // 合同起始日时间范围
  dateRangeEeBeginContract.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.eeSFID);
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
    eeSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    eeName: [{ required: true, message: "姓名"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeGender: [{ required: true, message: "性别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    eeBirthday: [{ required: true, message: "出生日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeIdentityCard: [{ required: true, message: "身份证号"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeWedlock: [{ required: true, message: "婚姻状态"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeNationId: [{ required: true, message: "民族"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeNativePlace: [{ required: true, message: "籍贯"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eePoliticId: [{ required: true, message: "政治面貌"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeCountry: [{ required: true, message: "国家/地区"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    eeProvince: [{ required: true, message: "省区"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    eeCity: [{ required: true, message: "市区"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    eeCounty: [{ required: true, message: "县区"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    eeHomeAddress: [{ required: true, message: "家庭住址"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    eeDepartmentId: [{ required: true, message: "部门"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeTitlesId: [{ required: true, message: "职称"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eePostId: [{ required: true, message: "职位"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eePostLevel: [{ required: true, message: "职级"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeDutyName: [{ required: true, message: "职务"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    eeRecruited: [{ required: true, message: "招聘来源"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 性别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
eeGenderOptions: [],
    // 婚姻状态 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_wedlock_state: [],
    // 民族 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_nation_list: [],
    // 籍贯 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_region_city: [],
    // 政治面貌 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_politic_list: [],
    // 国家/地区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_country_list: [],
    // 省区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_region_province: [],
    // 县区 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sql_region_county: [],
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
    eeSFID: 0,
    eeName: null,
    eeNameUsed: null,
    eeNickName: null,
    eeEnglishName: null,
    eeGender: null,
    eeBirthday: null,
    eeIdentityCard: null,
    eeWedlock: 0,
    eeNationId: 0,
    eeNativePlace: 0,
    eePoliticId: 0,
    eeEmail: null,
    eePhone: null,
    eeCountry: null,
    eeProvince: null,
    eeCity: null,
    eeCounty: null,
    eeHomeAddress: null,
    eePostCode: null,
    eeHouseholdType: 0,
    eeStayAddress: null,
    eeDepartmentId: 0,
    eeTitlesId: 0,
    eePostId: 0,
    eePostLevel: 0,
    eeDutyName: 0,
    eeRecruited: 0,
    eeEngageForm: null,
    eeTiptopDegrEe: 0,
    eeSpecialty: 0,
    eeSchool: null,
    eeWorkID: null,
    eeBeginDate: null,
    eeWorkState: 0,
    eeProbation: 0,
    eeContractTerm: 0,
    eeConversionTime: null,
    eeLeaveDate: null,
    eeBeginContract: null,
    eeBndContract: null,
    eeWorkAge: 0,
    eeAvatar: null,
    eeQualificationAnnex: null,
    eeTitleAnnex: null,
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
  form.value.eeGender= []
  form.value.eeBirthday= new Date()
  form.value.eeWedlock= 0
  form.value.eeNationId= 0
  form.value.eeNativePlace= 0
  form.value.eePoliticId= 0
  form.value.eeCountry= []
  form.value.eeProvince= []
  form.value.eeCity= []
  form.value.eeCounty= []
  form.value.eeHouseholdType= 0
  form.value.eeDepartmentId= 0
  form.value.eeTitlesId= 0
  form.value.eePostId= 0
  form.value.eePostLevel= 0
  form.value.eeDutyName= 0
  form.value.eeRecruited= 0
  form.value.eeEngageForm= []
  form.value.eeTiptopDegrEe= 0
  form.value.eeSpecialty= 0
  form.value.eeBeginDate= new Date()
  form.value.eeWorkState= 0
  form.value.eeProbation= 0
  form.value.eeContractTerm= 0
  form.value.eeConversionTime= new Date()
  form.value.eeLeaveDate= new Date()
  form.value.eeBeginContract= new Date()
  form.value.eeBndContract= new Date()
  form.value.eeWorkAge= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.eeSFID || ids.value
  getEhrEmployee(id).then((res) => {
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

      if (form.value.eeSFID != undefined && opertype.value === 2) {
        updateEhrEmployee(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addEhrEmployee(form.value).then((res) => {
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
  const Ids = row.eeSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delEhrEmployee(Ids)
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
      await proxy.downFile('/Routine/EhrEmployee/export', { ...queryParams })
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