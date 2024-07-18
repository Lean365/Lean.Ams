<!--
 * @Descripttion: 机构信息/inst_info
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/17 9:51:09
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="类别" prop="iiCategory">
        <el-select filterable clearable   v-model="queryParams.iiCategory" :placeholder="$t('btn.selectSearchPrefix')+'类别'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="编号" prop="iiInstCode">
        <el-input v-model="queryParams.iiInstCode" :placeholder="$t('btn.enterSearchPrefix')+'编号'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="简称" prop="iiShortName">
        <el-input v-model="queryParams.iiShortName" :placeholder="$t('btn.enterSearchPrefix')+'简称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="全称" prop="iiFullName">
        <el-input v-model="queryParams.iiFullName" :placeholder="$t('btn.enterSearchPrefix')+'全称'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="性质" prop="iiNature">
        <el-select filterable clearable   v-model="queryParams.iiNature" :placeholder="$t('btn.selectSearchPrefix')+'性质'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_nature_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="成立日期">
        <el-date-picker
          v-model="dateRangeIiFoundedTime" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item label="启用" prop="iiisEnabled">
        <el-select filterable clearable   v-model="queryParams.iiisEnabled" :placeholder="$t('btn.selectSearchPrefix')+'启用'+$t('btn.selectSearchSuffix')">
          <el-option v-for="item in   options.sys_normal_whether " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
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
        <el-button class="btn-add" v-hasPermi="['inst:info:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['inst:info:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['inst:info:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['inst:info:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="Routine/InstInfo/importTemplate"
                  importUrl="/Routine/InstInfo/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['inst:info:export']">
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
      <el-table-column prop="iiSFID" label="SFID" align="center" v-if="columns.showColumn('iiSFID')"/>
      <el-table-column prop="iiLangkey" label="语言" align="center" v-if="columns.showColumn('iiLangkey')">
        <template #default="scope">
          <dict-tag :options=" options.sys_lang_type " :value="scope.row.iiLangkey"  />
        </template>
      </el-table-column>
      <el-table-column prop="iiCategory" label="类别" align="center" v-if="columns.showColumn('iiCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.iiCategory"  />
        </template>
      </el-table-column>
      <el-table-column prop="iiInstCode" label="编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiInstCode')"/>
      <el-table-column prop="iiShortName" label="简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiShortName')"/>
      <el-table-column prop="iiFullName" label="全称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiFullName')"/>
      <el-table-column prop="iiNature" label="性质" align="center" v-if="columns.showColumn('iiNature')">
        <template #default="scope">
          <dict-tag :options=" options.sys_nature_list " :value="scope.row.iiNature"  />
        </template>
      </el-table-column>
      <el-table-column prop="iiOuterPhone" label="外线" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiOuterPhone')"/>
      <el-table-column prop="iiInnerPhone" label="内线" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiInnerPhone')"/>
      <el-table-column prop="iiFax" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiFax')"/>
      <el-table-column prop="iiPostalcode" label="邮编" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiPostalcode')"/>
      <el-table-column prop="iiEmail" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiEmail')"/>
      <el-table-column prop="iiOrgCode" label="组织代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiOrgCode')"/>
      <el-table-column prop="iiCorporate" label="法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiCorporate')"/>
      <el-table-column prop="iiRegionId" label="地区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiRegionId')"/>
      <el-table-column prop="iiProvinceId" label="省" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiProvinceId')"/>
      <el-table-column prop="iiCityId" label="市" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiCityId')"/>
      <el-table-column prop="iiCountyId" label="县/区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiCountyId')"/>
      <el-table-column prop="iiTownId" label="镇" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiTownId')"/>
      <el-table-column prop="iiVillageId" label="村" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiVillageId')"/>
      <el-table-column prop="iiAddress" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiAddress')"/>
      <el-table-column prop="iiEnAddress" label="英文地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiEnAddress')"/>
      <el-table-column prop="iiWebSite" label="网址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiWebSite')"/>
      <el-table-column prop="iiFoundedTime" label="成立日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('iiFoundedTime')"/>
      <el-table-column prop="iiBusinessScope" label="经营范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiBusinessScope')"/>
      <el-table-column prop="iiParentCorp" label="母公司" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiParentCorp')"/>
      <el-table-column prop="iiSortCode" label="排序" align="center" v-if="columns.showColumn('iiSortCode')"/>
      <el-table-column prop="iiisEnabled" label="启用" align="center" v-if="columns.showColumn('iiisEnabled')">
        <template #default="scope">
          <dict-tag :options=" options.sys_normal_whether " :value="scope.row.iiisEnabled"  />
        </template>
      </el-table-column>
      <el-table-column prop="iiSlogan" label="企业口号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiSlogan')"/>
      <el-table-column prop="iiLicenseAnnex" label="营业执照附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiLicenseAnnex')"/>
      <el-table-column prop="iiOtherAnnex" label="其它附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiOtherAnnex')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['inst:info:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['inst:info:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改机构信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">
            
          <el-col :lg="12">
            <el-form-item label="SFID" prop="iiSFID">
              <el-input v-model.number="form.iiSFID" :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="语言" prop="iiLangkey">
              <el-select filterable clearable   v-model="form.iiLangkey"  :placeholder="$t('btn.selectPrefix')+'语言'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_lang_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="类别" prop="iiCategory">
              <el-select filterable clearable   v-model="form.iiCategory"  :placeholder="$t('btn.selectPrefix')+'类别'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="编号" prop="iiInstCode">
              <el-input v-model="form.iiInstCode" :placeholder="$t('btn.enterPrefix')+'编号'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="简称" prop="iiShortName">
              <el-input v-model="form.iiShortName" :placeholder="$t('btn.enterPrefix')+'简称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="全称" prop="iiFullName">
              <el-input v-model="form.iiFullName" :placeholder="$t('btn.enterPrefix')+'全称'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="性质" prop="iiNature">
              <el-select filterable clearable   v-model="form.iiNature"  :placeholder="$t('btn.selectPrefix')+'性质'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_nature_list" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="外线" prop="iiOuterPhone">
              <el-input v-model="form.iiOuterPhone" :placeholder="$t('btn.enterPrefix')+'外线'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内线" prop="iiInnerPhone">
              <el-input v-model="form.iiInnerPhone" :placeholder="$t('btn.enterPrefix')+'内线'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="iiFax">
              <el-input v-model="form.iiFax" :placeholder="$t('btn.enterPrefix')+'传真'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮编" prop="iiPostalcode">
              <el-input v-model="form.iiPostalcode" :placeholder="$t('btn.enterPrefix')+'邮编'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮件" prop="iiEmail">
              <el-input v-model="form.iiEmail" :placeholder="$t('btn.enterPrefix')+'邮件'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组织代码" prop="iiOrgCode">
              <el-input v-model="form.iiOrgCode" :placeholder="$t('btn.enterPrefix')+'组织代码'+$t('btn.enterSuffix')" :disabled="opertype != 1"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="法人" prop="iiCorporate">
              <el-input v-model="form.iiCorporate" :placeholder="$t('btn.enterPrefix')+'法人'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地区" prop="iiRegionId">
              <el-input v-model="form.iiRegionId" :placeholder="$t('btn.enterPrefix')+'地区'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="省" prop="iiProvinceId">
              <el-input v-model="form.iiProvinceId" :placeholder="$t('btn.enterPrefix')+'省'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="市" prop="iiCityId">
              <el-input v-model="form.iiCityId" :placeholder="$t('btn.enterPrefix')+'市'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="县/区" prop="iiCountyId">
              <el-input v-model="form.iiCountyId" :placeholder="$t('btn.enterPrefix')+'县/区'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="镇" prop="iiTownId">
              <el-input v-model="form.iiTownId" :placeholder="$t('btn.enterPrefix')+'镇'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="村" prop="iiVillageId">
              <el-input v-model="form.iiVillageId" :placeholder="$t('btn.enterPrefix')+'村'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="iiAddress">
              <el-input v-model="form.iiAddress" :placeholder="$t('btn.enterPrefix')+'地址'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="英文地址" prop="iiEnAddress">
              <el-input v-model="form.iiEnAddress" :placeholder="$t('btn.enterPrefix')+'英文地址'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="网址" prop="iiWebSite">
              <el-input v-model="form.iiWebSite" :placeholder="$t('btn.enterPrefix')+'网址'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成立日期" prop="iiFoundedTime">
              <el-date-picker v-model="form.iiFoundedTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="经营范围" prop="iiBusinessScope">
              <el-input v-model="form.iiBusinessScope" :placeholder="$t('btn.enterPrefix')+'经营范围'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="母公司" prop="iiParentCorp">
              <el-input v-model="form.iiParentCorp" :placeholder="$t('btn.enterPrefix')+'母公司'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="排序" prop="iiSortCode">
              <el-input-number v-model.number="form.iiSortCode" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'排序'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="启用" prop="iiisEnabled">
              <el-select filterable clearable   v-model="form.iiisEnabled"  :placeholder="$t('btn.selectPrefix')+'启用'+$t('btn.selectSuffix')">
                <el-option
                  v-for="item in  options.sys_normal_whether" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="parseInt(item.dictValue)"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="企业口号" prop="iiSlogan">
              <el-input v-model="form.iiSlogan" :placeholder="$t('btn.enterPrefix')+'企业口号'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="营业执照附件" prop="iiLicenseAnnex">
              <UploadFile v-model="form.iiLicenseAnnex" :data="{ uploadType: 1 }" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="其它附件" prop="iiOtherAnnex">
              <UploadFile v-model="form.iiOtherAnnex" :data="{ uploadType: 1 }" />
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
              <el-input v-model="form.uDF51" :placeholder="$t('btn.enterPrefix')+'自定义1'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input v-model="form.uDF52" :placeholder="$t('btn.enterPrefix')+'自定义2'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input v-model="form.uDF53" :placeholder="$t('btn.enterPrefix')+'自定义3'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input v-model="form.uDF54" :placeholder="$t('btn.enterPrefix')+'自定义4'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input v-model="form.uDF55" :placeholder="$t('btn.enterPrefix')+'自定义5'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input v-model="form.uDF56" :placeholder="$t('btn.enterPrefix')+'自定义6'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注'+$t('btn.enterSuffix')"/>
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDeleted">
              <el-radio-group v-model="form.isDeleted">
                <el-radio v-for="item in options.isDeletedOptions" :key="item.dictValue" :value="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
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

<script setup name="instinfo">
  import '@/assets/styles/btn-custom.scss'
//后台操作函数
import { listInstInfo,
 addInstInfo, delInstInfo, 
 updateInstInfo,getInstInfo, 
 } 
from '@/api/routine/instinfo.js'
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
  iiCategory: undefined,
//是否查询（1是）
  iiInstCode: undefined,
//是否查询（1是）
  iiShortName: undefined,
//是否查询（1是）
  iiFullName: undefined,
//是否查询（1是）
  iiNature: undefined,
//是否查询（1是）
  iiFoundedTime: undefined,
//是否查询（1是）
  iiisEnabled: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'iiSFID', label: 'SFID' },
  { visible: true, prop: 'iiLangkey', label: '语言' },
  { visible: true, prop: 'iiCategory', label: '类别' },
  { visible: true, prop: 'iiInstCode', label: '编号' },
  { visible: true, prop: 'iiShortName', label: '简称' },
  { visible: true, prop: 'iiFullName', label: '全称' },
  { visible: true, prop: 'iiNature', label: '性质' },
  { visible: true, prop: 'iiOuterPhone', label: '外线' },
  { visible: false, prop: 'iiInnerPhone', label: '内线' },
  { visible: false, prop: 'iiFax', label: '传真' },
  { visible: false, prop: 'iiPostalcode', label: '邮编' },
  { visible: false, prop: 'iiEmail', label: '邮件' },
  { visible: false, prop: 'iiOrgCode', label: '组织代码' },
  { visible: false, prop: 'iiCorporate', label: '法人' },
  { visible: false, prop: 'iiRegionId', label: '地区' },
  { visible: false, prop: 'iiProvinceId', label: '省' },
  { visible: false, prop: 'iiCityId', label: '市' },
  { visible: false, prop: 'iiCountyId', label: '县/区' },
  { visible: false, prop: 'iiTownId', label: '镇' },
  { visible: false, prop: 'iiVillageId', label: '村' },
  { visible: false, prop: 'iiAddress', label: '地址' },
  { visible: false, prop: 'iiEnAddress', label: '英文地址' },
  { visible: false, prop: 'iiWebSite', label: '网址' },
  { visible: false, prop: 'iiFoundedTime', label: '成立日期' },
  { visible: false, prop: 'iiBusinessScope', label: '经营范围' },
  { visible: false, prop: 'iiParentCorp', label: '母公司' },
  { visible: false, prop: 'iiSortCode', label: '排序' },
  { visible: false, prop: 'iiisEnabled', label: '启用' },
  { visible: false, prop: 'iiSlogan', label: '企业口号' },
  { visible: false, prop: 'iiLicenseAnnex', label: '营业执照附件' },
  { visible: false, prop: 'iiOtherAnnex', label: '其它附件' },
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

























// 成立日期时间范围
const dateRangeIiFoundedTime = ref([])



























//字典参数
var dictParams = [
  { dictType: "sys_lang_type" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_nature_list" },
  { dictType: "sys_normal_whether" },
]

//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//API获取从机构信息/inst_info表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeIiFoundedTime.value, 'IiFoundedTime');
  loading.value = true
  listInstInfo(queryParams).then(res => {
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
  // 成立日期时间范围
  dateRangeIiFoundedTime.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.iiSFID);
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
    iiSFID: [{ required: true, message: "SFID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    iiLangkey: [{ required: true, message: "语言"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    iiCategory: [{ required: true, message: "类别"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    iiInstCode: [{ required: true, message: "编号"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    iiShortName: [{ required: true, message: "简称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiFullName: [{ required: true, message: "全称"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiNature: [{ required: true, message: "性质"+proxy.$t('btn.isEmpty'), trigger: "change"     }],
    iiOuterPhone: [{ required: true, message: "外线"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiInnerPhone: [{ required: true, message: "内线"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiFax: [{ required: true, message: "传真"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiOrgCode: [{ required: true, message: "组织代码"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    iiCorporate: [{ required: true, message: "法人"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiRegionId: [{ required: true, message: "地区"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiProvinceId: [{ required: true, message: "省"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiCityId: [{ required: true, message: "市"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiCountyId: [{ required: true, message: "县/区"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiAddress: [{ required: true, message: "地址"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiEnAddress: [{ required: true, message: "英文地址"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiFoundedTime: [{ required: true, message: "成立日期"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiBusinessScope: [{ required: true, message: "经营范围"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    iiSortCode: [{ required: true, message: "排序"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    iiisEnabled: [{ required: true, message: "启用"+proxy.$t('btn.isEmpty'), trigger: "change"    , type: "number"  }],
    uDF51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 语言 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_lang_type: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_ind_type: [],
    // 性质 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_nature_list: [],
    // 启用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
sys_normal_whether: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
isDeletedOptions: [],
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
    iiSFID: 0,
    iiLangkey: null,
    iiCategory: null,
    iiInstCode: null,
    iiShortName: null,
    iiFullName: null,
    iiNature: null,
    iiOuterPhone: null,
    iiInnerPhone: null,
    iiFax: null,
    iiPostalcode: null,
    iiEmail: null,
    iiOrgCode: null,
    iiCorporate: null,
    iiRegionId: null,
    iiProvinceId: null,
    iiCityId: null,
    iiCountyId: null,
    iiTownId: null,
    iiVillageId: null,
    iiAddress: null,
    iiEnAddress: null,
    iiWebSite: null,
    iiFoundedTime: null,
    iiBusinessScope: null,
    iiParentCorp: null,
    iiSortCode: 0,
    iiisEnabled: 0,
    iiSlogan: null,
    iiLicenseAnnex: null,
    iiOtherAnnex: null,
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
    remark: null,
    isDeleted: 0,
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
  title.value = proxy.$t('btn.add')+" "+'机构信息'
  opertype.value = 1
  form.value.iiLangkey= []
  form.value.iiCategory= []
  form.value.iiNature= []
  form.value.iiFoundedTime= new Date()
  form.value.iiSortCode= 0
  form.value.iiisEnabled= 0
  form.value.createTime= new Date()
  form.value.updateTime= new Date()
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.iiSFID || ids.value
  getInstInfo(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '机构信息'
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

      if (form.value.iiSFID != undefined && opertype.value === 2) {
        updateInstInfo(form.value).then((res) => {
         proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
          open.value = false
          getList()
        })
      } else {
        addInstInfo(form.value).then((res) => {
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
  const Ids = row.iiSFID || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(function () {
      return delInstInfo(Ids)
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<机构信息.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/Routine/InstInfo/export', { ...queryParams })
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