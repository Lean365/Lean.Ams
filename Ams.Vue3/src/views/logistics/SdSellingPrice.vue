<!--
 * @Descripttion: 销售价格/sd_selling_price
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/26 10:59:46
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="工厂" prop="sspPlnt">
            <el-select filterable clearable v-model="queryParams.sspPlnt"
              :placeholder="$t('btn.selectSearchPrefix')+'工厂'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="期间" prop="sspFy">
            <el-select filterable clearable v-model="queryParams.sspFy"
              :placeholder="$t('btn.selectSearchPrefix')+'期间'+$t('btn.selectSearchSuffix')" @change="handleFyChange">
              <el-option v-for="item in   options.sql_fy_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="年月" prop="sspYm">
            <el-select filterable clearable v-model="queryParams.sspYm"
              :placeholder="$t('btn.selectSearchPrefix')+'年月'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   cascadeFm " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="物料" prop="sspItem">
            <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
              :loading="loading " v-model="queryParams.sspItem"
              :placeholder="$t('btn.selectSearchPrefix')+'物料'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   remotequery_sql_mats_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="原币种" prop="sspOriginalccy">
            <el-select filterable clearable v-model="queryParams.sspOriginalccy"
              :placeholder="$t('btn.selectSearchPrefix')+'原币种'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sys_ccy_type " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="原币利润中心" prop="sspOriginalprctr">
            <el-select filterable clearable v-model="queryParams.sspOriginalprctr"
              :placeholder="$t('btn.selectSearchPrefix')+'原币利润中心'+$t('btn.selectSearchSuffix')">
              <el-option v-for="item in   options.sql_prctr_list " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue">
                <span class="fl">{{ item.dictLabel }}</span>
                <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="失效日期">
            <el-date-picker v-model="dateRangeSspExpdate" type="datetimerange" :start-placeholder="$t('btn.dateStart')"
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
        <el-button class="btn-add" v-hasPermi="['sd:sellingprice:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sd:sellingprice:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sd:sellingprice:delete']" plain
          icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sd:sellingprice:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Logistics/SdSellingPrice/importTemplate"
                  importUrl="/Logistics/SdSellingPrice/importData" @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport"
          v-hasPermi="['sd:sellingprice:export']">
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
      <el-table-column prop="sspSfid" label="SFID" align="center" v-if="columns.showColumn('sspSfid')" />
      <el-table-column prop="sspPlnt" label="工厂" align="center" v-if="columns.showColumn('sspPlnt')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.sspPlnt" />
        </template>
      </el-table-column>
      <el-table-column prop="sspFy" label="期间" align="center" v-if="columns.showColumn('sspFy')">
        <template #default="scope">
          <dict-tag :options=" options.sql_fy_list " :value="scope.row.sspFy" />
        </template>
      </el-table-column>
      <el-table-column prop="sspYm" label="年月" align="center" v-if="columns.showColumn('sspYm')">
        <template #default="scope">
          <dict-tag :options=" options.sql_ym_list " :value="scope.row.sspYm" />
        </template>
      </el-table-column>
      <el-table-column prop="sspItem" label="物料" align="center" v-if="columns.showColumn('sspItem')">
        <template #default="scope">
          <dict-tag :options=" options.sql_mats_list " :value="scope.row.sspItem" />
        </template>
      </el-table-column>
      <el-table-column prop="sspItemtext" label="物料文本" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sspItemtext')" />
      <el-table-column prop="sspOriginalfob" label="原币价格" align="center" v-if="columns.showColumn('sspOriginalfob')" />
      <el-table-column prop="sspOriginalccy" label="原币种" align="center" v-if="columns.showColumn('sspOriginalccy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.sspOriginalccy" />
        </template>
      </el-table-column>
      <el-table-column prop="sspOriginalperunit" label="原币Per单位" align="center"
        v-if="columns.showColumn('sspOriginalperunit')" />
      <el-table-column prop="sspOriginalprctr" label="原币利润中心" align="center"
        v-if="columns.showColumn('sspOriginalprctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.sspOriginalprctr" />
        </template>
      </el-table-column>
      <el-table-column prop="sspLocalfob" label="本币价格" align="center" v-if="columns.showColumn('sspLocalfob')" />
      <el-table-column prop="sspLocalccy" label="本币种" align="center" v-if="columns.showColumn('sspLocalccy')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ccy_type " :value="scope.row.sspLocalccy" />
        </template>
      </el-table-column>
      <el-table-column prop="sspLocalperunit" label="本币Per单位" align="center"
        v-if="columns.showColumn('sspLocalperunit')" />
      <el-table-column prop="sspLocalprctr" label="本币利润中心" align="center" v-if="columns.showColumn('sspLocalprctr')">
        <template #default="scope">
          <dict-tag :options=" options.sql_prctr_list " :value="scope.row.sspLocalprctr" />
        </template>
      </el-table-column>
      <el-table-column prop="sspEffdate" label="生效日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sspEffdate')" />
      <el-table-column prop="sspExpdate" label="失效日期" :show-overflow-tooltip="true"
        v-if="columns.showColumn('sspExpdate')" />
      <el-table-column prop="remark" label="说明" align="center" :show-overflow-tooltip="true"
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
              v-hasPermi="['sd:sellingprice:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['sd:sellingprice:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改销售价格对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="SFID" prop="sspSfid">
                  <el-input v-model.number="form.sspSfid"
                    :placeholder="$t('btn.enterPrefix')+'SFID'+$t('btn.enterSuffix')" :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="工厂" prop="sspPlnt">
                  <el-select filterable clearable v-model="form.sspPlnt"
                    :placeholder="$t('btn.selectPrefix')+'工厂'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_plant_list" :key="item.dictValue" :label="item.dictLabel"
                      :year="item.dictYear" :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="期间" prop="sspFy">
                  <el-select filterable clearable v-model="form.sspFy"
                    :placeholder="$t('btn.selectPrefix')+'期间'+$t('btn.selectSuffix')" @change="handleFyChange">
                    <el-option v-for="item in  options.sql_fy_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="年月" prop="sspYm">
                  <el-select filterable clearable v-model="form.sspYm"
                    :placeholder="$t('btn.selectPrefix')+'年月'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_ym_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料" prop="sspItem">
                  <el-select filterable clearable remote remote-show-suffix :remote-method="remoteMethod_sql_mats_list"
                    :loading="loading " v-model="form.sspItem"
                    :placeholder="$t('btn.selectPrefix')+'物料'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  remotequery_sql_mats_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="物料文本" prop="sspItemtext">
                  <el-input v-model="form.sspItemtext"
                    :placeholder="$t('btn.enterPrefix')+'物料文本'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="原币价格" prop="sspOriginalfob">
                  <el-input-number v-model.number="form.sspOriginalfob" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'原币价格'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="原币种" prop="sspOriginalccy">
                  <el-select filterable clearable v-model="form.sspOriginalccy"
                    :placeholder="$t('btn.selectPrefix')+'原币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="原币Per单位" prop="sspOriginalperunit">
                  <el-input-number v-model.number="form.sspOriginalperunit" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'原币Per单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="原币利润中心" prop="sspOriginalprctr">
                  <el-select filterable clearable v-model="form.sspOriginalprctr"
                    :placeholder="$t('btn.selectPrefix')+'原币利润中心'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_prctr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="本币价格" prop="sspLocalfob">
                  <el-input-number v-model.number="form.sspLocalfob" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'本币价格'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="本币种" prop="sspLocalccy">
                  <el-select filterable clearable v-model="form.sspLocalccy"
                    :placeholder="$t('btn.selectPrefix')+'本币种'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sys_ccy_type" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="本币Per单位" prop="sspLocalperunit">
                  <el-input-number v-model.number="form.sspLocalperunit" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'本币Per单位'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="本币利润中心" prop="sspLocalprctr">
                  <el-select filterable clearable v-model="form.sspLocalprctr"
                    :placeholder="$t('btn.selectPrefix')+'本币利润中心'+$t('btn.selectSuffix')">
                    <el-option v-for="item in  options.sql_prctr_list" :key="item.dictValue" :label="item.dictLabel"
                      :value="item.dictValue"></el-option>
                  </el-select>
                </el-form-item>
              </el-col>


              <el-col :lg="12">
                <el-form-item label="生效日期" prop="sspEffdate">
                  <el-date-picker v-model="form.sspEffdate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="失效日期" prop="sspExpdate">
                  <el-date-picker v-model="form.sspExpdate" type="datetime" :teleported="false"
                    :placeholder="$t('btn.dateselect')"></el-date-picker>
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

              <el-col :lg="12">
                <el-form-item label="说明" prop="remark">
                  <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'说明'+$t('btn.enterSuffix')" />
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

<script setup name="sdsellingprice">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listSdSellingPrice,
    addSdSellingPrice, delSdSellingPrice,
    updateSdSellingPrice, getSdSellingPrice,
  }
    from '@/api/logistics/sdsellingprice.js'
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
    sort: 'SspYm',
    sortType: 'desc',
    //是否查询（1是）
    sspPlnt: undefined,
    //是否查询（1是）
    sspFy: undefined,
    //是否查询（1是）
    sspYm: undefined,
    //是否查询（1是）
    sspItem: undefined,
    //是否查询（1是）
    sspOriginalccy: undefined,
    //是否查询（1是）
    sspOriginalprctr: undefined,
    //是否查询（1是）
    sspExpdate: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'sspSfid', label: 'SFID' },
    { visible: true, prop: 'sspPlnt', label: '工厂' },
    { visible: true, prop: 'sspFy', label: '期间' },
    { visible: true, prop: 'sspYm', label: '年月' },
    { visible: true, prop: 'sspItem', label: '物料' },
    { visible: true, prop: 'sspItemtext', label: '物料文本' },
    { visible: true, prop: 'sspOriginalfob', label: '原币价格' },
    { visible: true, prop: 'sspOriginalccy', label: '原币种' },
    { visible: false, prop: 'sspOriginalperunit', label: '原币Per单位' },
    { visible: false, prop: 'sspOriginalprctr', label: '原币利润中心' },
    { visible: false, prop: 'sspLocalfob', label: '本币价格' },
    { visible: false, prop: 'sspLocalccy', label: '本币种' },
    { visible: false, prop: 'sspLocalperunit', label: '本币Per单位' },
    { visible: false, prop: 'sspLocalprctr', label: '本币利润中心' },
    { visible: false, prop: 'sspEffdate', label: '生效日期' },
    { visible: false, prop: 'sspExpdate', label: '失效日期' },
    { visible: false, prop: 'remark', label: '说明' },
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
  //定义远程搜索变量
  const remotequeryList_sql_mats_list = ref([])
  //定义远程搜索变量
  const remotequery_sql_mats_list = ref([])
  //远程字典参数
  var remotedictParams_sql_mats_list = [
    { dictType: "sql_mats_list" },
  ]
  //远程搜索组件实例
  onMounted(() => {
    proxy.getDicts(remotedictParams_sql_mats_list).then((response) => {
      response.data.forEach((element) => {
        remotequeryList_sql_mats_list.value = element.list
      })
      //console.log(remotequeryList_sql_mats_list)
    })
  })
  //远程搜索
  const remoteMethod_sql_mats_list = debounce((query) => {
    if (query) {
      loading.value = true
      setTimeout(() => {
        loading.value = false
        // remotequery_sql_mats_list.value = remotequeryList_sql_mats_list.value.filter((item) => {
        //   return item.dictValue.toLowerCase().includes(query.toLowerCase())
        // })
        filterMethod_sql_mats_list(query)
      }, 2000)
    } else {
      //默认显示前15条记录
      remotequery_sql_mats_list.value.slice(0, 15)
    }
  }, 300)
  // 筛选方法
  const filterMethod_sql_mats_list = debounce((query) => {
    let arr = remotequeryList_sql_mats_list.value.filter((item) => {
      return item.dictValue.toLowerCase().includes(query) || item.dictLabel.toLowerCase().includes(query);
    })
    if (arr.length > 5) {
      remotequery_sql_mats_list.value = arr.slice(0, 5)
      addFilterOptions_sql_mats_list(query)
    } else {
      remotequery_sql_mats_list.value = arr
    }
  }, 300)
  // 精准筛选方法
  const addFilterOptions_sql_mats_list = debounce((dictValue) => {
    let target = remotequeryList_sql_mats_list.value.find((item) => {
      return item.dictValue === dictValue
    })
    if (target) {
      if (remotequery_sql_mats_list.value.toLowerCase().every(item => item.dictValue !== target.dictValue)) {
        remotequery_sql_mats_list.value.toLowerCase().unshift(target)
      }
    }
  }, 300)
  // 失效日期时间范围
  const dateRangeSspExpdate = ref([])

  //字典参数
  var dictParams = [
    { dictType: "sys_plant_list" },
    { dictType: "sql_fy_list" },
    { dictType: "sql_ym_list" },
    { dictType: "sys_ccy_type" },
    { dictType: "sql_prctr_list" },
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从销售价格/sd_selling_price表记录数据
  function getList() {
    proxy.addDateRange(queryParams, dateRangeSspExpdate.value, 'SspExpdate');
    loading.value = true
    listSdSellingPrice(queryParams).then(res => {
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
    // 失效日期时间范围
    dateRangeSspExpdate.value = []
    proxy.resetForm("queryRef")
    handleQuery()
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    ids.value = selection.map((item) => item.sspSfid);
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
      sspSfid: [{ required: true, message: "SFID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      sspPlnt: [{ required: true, message: "工厂" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sspFy: [{ required: true, message: "期间" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sspYm: [{ required: true, message: "年月" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sspItem: [{ required: true, message: "物料" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      sspItemtext: [{ required: true, message: "物料文本" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      sspOriginalfob: [{ required: true, message: "原币价格" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      sspOriginalccy: [{ required: true, message: "原币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sspOriginalperunit: [{ required: true, message: "原币Per单位" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      sspOriginalprctr: [{ required: true, message: "原币利润中心" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sspLocalfob: [{ required: true, message: "本币价格" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      sspLocalccy: [{ required: true, message: "本币种" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sspLocalperunit: [{ required: true, message: "本币Per单位" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
      sspLocalprctr: [{ required: true, message: "本币利润中心" + proxy.$t('btn.isEmpty'), trigger: "change" }],
      sspEffdate: [{ required: true, message: "生效日期" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      sspExpdate: [{ required: true, message: "失效日期" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      isDeleted: [{ required: true, message: "软删除" + proxy.$t('btn.isEmpty'), trigger: "blur", type: "number" }],
    },
    options: {
      // 工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_plant_list: [],
      // 期间 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_fy_list: [],
      // 年月 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_ym_list: [],
      // 原币种 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sys_ccy_type: [],
      // 原币利润中心 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_prctr_list: [],
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

  const cascadeFm = ref()


  const handleFyChange = (event) => {
    form.value.sspYm = null
    queryParams.sspYm = null
    //ffy.value = event
    // console.log(ffy.value)
    // 这里可以添加其他逻辑，比如触发父组件的方法

    cascadeFm.value = state.options.sql_ym_list.filter(item => item.label.includes((event)))
    //form.sspYm.value = []
    //return selectedCountry.value ? cities[selectedCountry.value] : []


  }





  // 重置表单
  function reset() {
    form.value = {
      sspSfid: 0,
      sspPlnt: null,
      sspFy: null,
      sspYm: null,
      sspItemChecked: [],
      sspItemtext: null,
      sspOriginalfob: 0,
      sspOriginalccy: null,
      sspOriginalperunit: 0,
      sspOriginalprctr: null,
      sspLocalfob: 0,
      sspLocalccy: null,
      sspLocalperunit: 0,
      sspLocalprctr: null,
      sspEffdate: null,
      sspExpdate: null,
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
    title.value = proxy.$t('btn.add') + " " + '销售价格'
    opertype.value = 1
    form.value.sspPlnt = []
    form.value.sspFy = []
    form.value.sspYm = []
    form.value.sspOriginalfob = 0
    form.value.sspOriginalccy = []
    form.value.sspOriginalperunit = 0
    form.value.sspOriginalprctr = []
    form.value.sspLocalfob = 0
    form.value.sspLocalccy = []
    form.value.sspLocalperunit = 0
    form.value.sspLocalprctr = []
    form.value.sspEffdate = new Date()
    form.value.sspExpdate = new Date()
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.sspSfid || ids.value
    getSdSellingPrice(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '销售价格'
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

        if (form.value.sspSfid != undefined && opertype.value === 2) {
          updateSdSellingPrice(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addSdSellingPrice(form.value).then((res) => {
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
    const Ids = row.sspSfid || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delSdSellingPrice(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<销售价格.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Logistics/SdSellingPrice/export', { ...queryParams })
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