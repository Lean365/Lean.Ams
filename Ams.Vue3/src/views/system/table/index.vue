<!--
 * @Descripttion: 表名称/sys_table
 * @Version: 1.0.0.0
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/7/31 10:27:13
 * @column：40
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent
      label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
          <el-form-item label="表名 " prop="tb001">
            <el-input v-model="queryParams.tb001"
              :placeholder="$t('btn.enterSearchPrefix')+'表名 '+$t('btn.enterSearchSuffix')" />
          </el-form-item>
          <el-form-item label="表描述" prop="tb002">
            <el-input v-model="queryParams.tb002"
              :placeholder="$t('btn.enterSearchPrefix')+'表描述'+$t('btn.enterSearchSuffix')" />
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
        <el-button class="btn-add" v-hasPermi="['sys:table:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['sys:table:edit']" plain icon="edit"
          @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['sys:table:delete']" plain icon="delete"
          @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['sys:table:import']">
          <el-button class="btn-import" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData templateUrl="Kernel/SysTable/importTemplate" importUrl="/Kernel/SysTable/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-export" plain icon="download" @click="handleExport" v-hasPermi="['sys:table:export']">
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
      <el-table-column prop="tbId" label="ID" align="center" v-if="columns.showColumn('tbId')" />
      <el-table-column prop="tb001" label="表名 " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb001')" />
      <el-table-column prop="tb002" label="表描述" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb002')" />
      <el-table-column prop="tb003" label="序号 " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb003')" />
      <el-table-column prop="tb004" label="简称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb004')" />
      <el-table-column prop="tb005" label="缩写" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb005')" />
      <el-table-column prop="tb006" label="表名称" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb006')" />
      <el-table-column prop="tb007" label="字段名称(tw) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb007')" />
      <el-table-column prop="tb008" label="字段名称(ja) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb008')" />
      <el-table-column prop="tb009" label="字段名称(ko) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb009')" />
      <el-table-column prop="tb010" label="字段名称(ar) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb010')" />
      <el-table-column prop="tb011" label="字段名称(ru) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb011')" />
      <el-table-column prop="tb012" label="字段名称(es) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb012')" />
      <el-table-column prop="tb013" label="字段名称(fr) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb013')" />
      <el-table-column prop="tb014" label="字段名称(de) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb014')" />
      <el-table-column prop="tb015" label="字段名称(en) " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('tb015')" />
      <el-table-column prop="rEF01" label="预留A " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF01')" />
      <el-table-column prop="rEF02" label="预留B " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF02')" />
      <el-table-column prop="rEF03" label="预留C " align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('rEF03')" />
      <el-table-column prop="rEF04" label="预留1 " align="center" v-if="columns.showColumn('rEF04')" />
      <el-table-column prop="rEF05" label="预留2 " align="center" v-if="columns.showColumn('rEF05')" />
      <el-table-column prop="rEF06" label="预留3" align="center" v-if="columns.showColumn('rEF06')" />
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('remark')" />
      <el-table-column prop="createBy" label="创建人员" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createBy')" />
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('createTime')" />
      <el-table-column prop="updateBy" label="更新人员" align="center" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateBy')" />
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"
        v-if="columns.showColumn('updateTime')" />
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')"
              v-hasPermi="['sys:table:edit']" @click="handleUpdate(scope.row)"></el-button>
            <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')"
              v-hasPermi="['sys:table:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />

    <!-- 添加或修改表名称对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">

              <el-col :lg="12">
                <el-form-item label="ID" prop="tbId">
                  <el-input v-model.number="form.tbId" :placeholder="$t('btn.enterPrefix')+'ID'+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="表名 " prop="tb001">
                  <el-input v-model="form.tb001" :placeholder="$t('btn.enterPrefix')+'表名 '+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="表描述" prop="tb002">
                  <el-input v-model="form.tb002" :placeholder="$t('btn.enterPrefix')+'表描述'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="序号 " prop="tb003">
                  <el-input v-model="form.tb003" :placeholder="$t('btn.enterPrefix')+'序号 '+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="简称" prop="tb004">
                  <el-input v-model="form.tb004" :placeholder="$t('btn.enterPrefix')+'简称'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="缩写" prop="tb005">
                  <el-input v-model="form.tb005" :placeholder="$t('btn.enterPrefix')+'缩写'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="表名称" prop="tb006">
                  <el-input v-model="form.tb006" :placeholder="$t('btn.enterPrefix')+'表名称'+$t('btn.enterSuffix')"
                    :disabled="opertype != 1" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(tw) " prop="tb007">
                  <el-input v-model="form.tb007"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(tw) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(ja) " prop="tb008">
                  <el-input v-model="form.tb008"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(ja) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(ko) " prop="tb009">
                  <el-input v-model="form.tb009"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(ko) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(ar) " prop="tb010">
                  <el-input v-model="form.tb010"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(ar) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(ru) " prop="tb011">
                  <el-input v-model="form.tb011"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(ru) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(es) " prop="tb012">
                  <el-input v-model="form.tb012"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(es) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(fr) " prop="tb013">
                  <el-input v-model="form.tb013"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(fr) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(de) " prop="tb014">
                  <el-input v-model="form.tb014"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(de) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="字段名称(en) " prop="tb015">
                  <el-input v-model="form.tb015"
                    :placeholder="$t('btn.enterPrefix')+'字段名称(en) '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留A " prop="rEF01">
                  <el-input v-model="form.rEF01" :placeholder="$t('btn.enterPrefix')+'预留A '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留B " prop="rEF02">
                  <el-input v-model="form.rEF02" :placeholder="$t('btn.enterPrefix')+'预留B '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留C " prop="rEF03">
                  <el-input v-model="form.rEF03" :placeholder="$t('btn.enterPrefix')+'预留C '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留1 " prop="rEF04">
                  <el-input-number v-model.number="form.rEF04" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留1 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留2 " prop="rEF05">
                  <el-input-number v-model.number="form.rEF05" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留2 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="预留3" prop="rEF06">
                  <el-input-number v-model.number="form.rEF06" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'预留3'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义A " prop="uDF01">
                  <el-input v-model="form.uDF01" :placeholder="$t('btn.enterPrefix')+'自定义A '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义B " prop="uDF02">
                  <el-input v-model="form.uDF02" :placeholder="$t('btn.enterPrefix')+'自定义B '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义C " prop="uDF03">
                  <el-input v-model="form.uDF03" :placeholder="$t('btn.enterPrefix')+'自定义C '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义D " prop="uDF04">
                  <el-input v-model="form.uDF04" :placeholder="$t('btn.enterPrefix')+'自定义D '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义E " prop="uDF05">
                  <el-input v-model="form.uDF05" :placeholder="$t('btn.enterPrefix')+'自定义E '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义F " prop="uDF06">
                  <el-input v-model="form.uDF06" :placeholder="$t('btn.enterPrefix')+'自定义F '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义1 " prop="uDF51">
                  <el-input-number v-model.number="form.uDF51" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义1 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义2 " prop="uDF52">
                  <el-input-number v-model.number="form.uDF52" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义2 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义3 " prop="uDF53">
                  <el-input-number v-model.number="form.uDF53" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义3 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义4 " prop="uDF54">
                  <el-input-number v-model.number="form.uDF54" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义4 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义5 " prop="uDF55">
                  <el-input-number v-model.number="form.uDF55" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义5 '+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="自定义6 " prop="uDF56">
                  <el-input-number v-model.number="form.uDF56" :controls="true" controls-position="right"
                    :placeholder="$t('btn.enterPrefix')+'自定义6 '+$t('btn.enterSuffix')" />
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
                <el-form-item label="备注说明" prop="remark">
                  <el-input v-model="form.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
                </el-form-item>
              </el-col>

              <el-col :lg="12">
                <el-form-item label="创建人员" prop="createBy">
                  <el-input v-model="form.createBy" :placeholder="$t('btn.enterPrefix')+'创建人员'+$t('btn.enterSuffix')" />
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
                  <el-input v-model="form.updateBy" :placeholder="$t('btn.enterPrefix')+'更新人员'+$t('btn.enterSuffix')" />
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

<script setup name="systable">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import {
    listSysTable,
    addSysTable, delSysTable,
    updateSysTable, getSysTable,
  }
    from '@/api/system/table.js'
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
    tb001: undefined,
    //是否查询（1是）
    tb002: undefined,
  })
  //字段显示控制
  const columns = ref([
    { visible: true, prop: 'tbId', label: 'ID' },
    { visible: true, prop: 'tb001', label: '表名 ' },
    { visible: true, prop: 'tb002', label: '表描述' },
    { visible: true, prop: 'tb003', label: '序号 ' },
    { visible: true, prop: 'tb004', label: '简称' },
    { visible: true, prop: 'tb005', label: '缩写' },
    { visible: true, prop: 'tb006', label: '表名称' },
    { visible: true, prop: 'tb007', label: '字段名称(tw) ' },
    { visible: false, prop: 'tb008', label: '字段名称(ja) ' },
    { visible: false, prop: 'tb009', label: '字段名称(ko) ' },
    { visible: false, prop: 'tb010', label: '字段名称(ar) ' },
    { visible: false, prop: 'tb011', label: '字段名称(ru) ' },
    { visible: false, prop: 'tb012', label: '字段名称(es) ' },
    { visible: false, prop: 'tb013', label: '字段名称(fr) ' },
    { visible: false, prop: 'tb014', label: '字段名称(de) ' },
    { visible: false, prop: 'tb015', label: '字段名称(en) ' },
    { visible: false, prop: 'rEF01', label: '预留A ' },
    { visible: false, prop: 'rEF02', label: '预留B ' },
    { visible: false, prop: 'rEF03', label: '预留C ' },
    { visible: false, prop: 'rEF04', label: '预留1 ' },
    { visible: false, prop: 'rEF05', label: '预留2 ' },
    { visible: false, prop: 'rEF06', label: '预留3' },
    { visible: false, prop: 'remark', label: '备注说明' },
    { visible: false, prop: 'createBy', label: '创建人员' },
    { visible: false, prop: 'createTime', label: '创建时间' },
    { visible: false, prop: 'updateBy', label: '更新人员' },
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
    { dictType: "sys_is_deleted" },
  ]

  //字典加载
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  //API获取从表名称/sys_table表记录数据
  function getList() {
    loading.value = true
    listSysTable(queryParams).then(res => {
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
    ids.value = selection.map((item) => item.tbId);
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
      tbId: [{ required: true, message: "ID" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      tb001: [{ required: true, message: "表名 " + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      tb003: [{ required: true, message: "序号 " + proxy.$t('btn.isEmpty'), trigger: "blur" }],
      tb006: [{ required: true, message: "表名称" + proxy.$t('btn.isEmpty'), trigger: "blur" }],
    },
    options: {
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
      tbId: 0,
      tb001: null,
      tb002: null,
      tb003: null,
      tb004: null,
      tb005: null,
      tb006: null,
      tb007: null,
      tb008: null,
      tb009: null,
      tb010: null,
      tb011: null,
      tb012: null,
      tb013: null,
      tb014: null,
      tb015: null,
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
    title.value = proxy.$t('btn.add') + " " + '表名称'
    opertype.value = 1
    form.value.rEF04 = 0
    form.value.rEF05 = 0
    form.value.rEF06 = 0
    form.value.createTime = new Date()
    form.value.updateTime = new Date()
  }
  // 修改按钮操作
  function handleUpdate(row) {
    reset()
    const id = row.tbId || ids.value
    getSysTable(id).then((res) => {
      const { code, data } = res
      if (code == 200) {
        open.value = true
        title.value = proxy.$t('btn.edit') + " " + '表名称'
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

        if (form.value.tbId != undefined && opertype.value === 2) {
          updateSysTable(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false
            getList()
          })
        } else {
          addSysTable(form.value).then((res) => {
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
    const Ids = row.tbId || ids.value

    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delSysTable(Ids)
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
      .$confirm(proxy.$t('common.tipConfirmExport') + "<表名称.xlsx>", proxy.$t('btn.export') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(async () => {
        await proxy.downFile('/Kernel/SysTable/export', { ...queryParams })
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