<!--
 * @Descripttion: (固定资产/fico_asset)
 * @Author: (Lean365)
 * @Date: (2024-06-21)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['ficoasset:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table
      :data="dataList"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      >
      <el-table-column prop="faSFID" label="SFID" align="center" v-if="columns.showColumn('faSFID')"/>
      <el-table-column prop="faCorp" label="公司" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faCorp')"/>
      <el-table-column prop="faDept" label="使用部门" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faDept')"/>
      <el-table-column prop="faClassCode" label="资产类别" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faClassCode')"/>
      <el-table-column prop="faAssetNo" label="资产编码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetNo')"/>
      <el-table-column prop="faCostCenter" label="成本中心" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faCostCenter')"/>
      <el-table-column prop="faAssetShortName" label="资产简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetShortName')"/>
      <el-table-column prop="faAssetFullName" label="资产全称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetFullName')"/>
      <el-table-column prop="faAssetUnit" label="单位" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetUnit')"/>
      <el-table-column prop="faAssetQty" label="数量" align="center" v-if="columns.showColumn('faAssetQty')"/>
      <el-table-column prop="faAssetMana" label="管理区分" align="center" v-if="columns.showColumn('faAssetMana')"/>
      <el-table-column prop="faAssetCcy" label="币种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetCcy')"/>
      <el-table-column prop="faAcquisitionPrice" label="购买价格" align="center" v-if="columns.showColumn('faAcquisitionPrice')"/>
      <el-table-column prop="faCapitalizedDate" label="资本化日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faCapitalizedDate')"/>
      <el-table-column prop="faDepreciationValue" label="折旧价值" align="center" v-if="columns.showColumn('faDepreciationValue')"/>
      <el-table-column prop="faScrapDate" label="报废日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faScrapDate')"/>
      <el-table-column prop="faScrapValue" label="报废价值" align="center" v-if="columns.showColumn('faScrapValue')"/>
      <el-table-column prop="faLocale" label="存放位置" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faLocale')"/>
      <el-table-column prop="faAssetUsed" label="使用年限" align="center" v-if="columns.showColumn('faAssetUsed')"/>
      <el-table-column prop="faAssetStop" label="是否停用" align="center" v-if="columns.showColumn('faAssetStop')"/>
      <el-table-column prop="faAssetVender" label="供应商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetVender')"/>
      <el-table-column prop="faAssetManufacturer" label="制造商" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetManufacturer')"/>
      <el-table-column prop="faAssetVenderItem" label="供应商物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetVenderItem')"/>
      <el-table-column prop="faAssetManufacturerItem" label="制造商物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faAssetManufacturerItem')"/>
      <el-table-column prop="faEntity" label="资产形态" align="center" v-if="columns.showColumn('faEntity')"/>
      <el-table-column prop="faHaveorNot" label="资产存在否" align="center" v-if="columns.showColumn('faHaveorNot')"/>
      <el-table-column prop="faCheckedby" label="盘点人员" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('faCheckedby')"/>
      <el-table-column prop="faCheckedDate" label="盘点日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('faCheckedDate')"/>
      <el-table-column prop="uDF01" label="自定义A" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF01')"/>
      <el-table-column prop="uDF02" label="自定义B" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF02')"/>
      <el-table-column prop="uDF03" label="自定义C" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF03')"/>
      <el-table-column prop="uDF04" label="自定义D" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF04')"/>
      <el-table-column prop="uDF05" label="自定义E" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF05')"/>
      <el-table-column prop="uDF06" label="自定义F" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('uDF06')"/>
      <el-table-column prop="uDF51" label="自定义1" align="center" v-if="columns.showColumn('uDF51')"/>
      <el-table-column prop="uDF52" label="自定义2" align="center" v-if="columns.showColumn('uDF52')"/>
      <el-table-column prop="uDF53" label="自定义3" align="center" v-if="columns.showColumn('uDF53')"/>
      <el-table-column prop="uDF54" label="自定义4" align="center" v-if="columns.showColumn('uDF54')"/>
      <el-table-column prop="uDF55" label="自定义5" align="center" v-if="columns.showColumn('uDF55')"/>
      <el-table-column prop="uDF56" label="自定义6" align="center" v-if="columns.showColumn('uDF56')"/>
      <el-table-column prop="remark" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column prop="isDeleted" label="软删除" align="center" v-if="columns.showColumn('isDeleted')">
        <template #default="scope">
          <dict-tag :options=" options.isDeletedOptions" :value="scope.row.isDeleted"  />
        </template>
      </el-table-column>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column prop="updateBy" label="更新者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('updateBy')"/>
      <el-table-column prop="updateTime" label="更新时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('updateTime')"/>
      <el-table-column label="操作" width="160">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" title="编辑" v-hasPermi="['ficoasset:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" icon="delete" title="删除" v-hasPermi="['ficoasset:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
            
          <el-col :lg="12" v-if="opertype != 1">
            <el-form-item label="SFID" prop="faSFID">
              <el-input-number v-model.number="form.faSFID" controls-position="right" placeholder="请输入SFID" :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="公司" prop="faCorp">
              <el-input v-model="form.faCorp" placeholder="请输入公司" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="使用部门" prop="faDept">
              <el-input v-model="form.faDept" placeholder="请输入使用部门" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资产类别" prop="faClassCode">
              <el-input v-model="form.faClassCode" placeholder="请输入资产类别" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资产编码" prop="faAssetNo">
              <el-input v-model="form.faAssetNo" placeholder="请输入资产编码" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本中心" prop="faCostCenter">
              <el-input v-model="form.faCostCenter" placeholder="请输入成本中心" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资产简称" prop="faAssetShortName">
              <el-input v-model="form.faAssetShortName" placeholder="请输入资产简称" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资产全称" prop="faAssetFullName">
              <el-input v-model="form.faAssetFullName" placeholder="请输入资产全称" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位" prop="faAssetUnit">
              <el-input v-model="form.faAssetUnit" placeholder="请输入单位" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="数量" prop="faAssetQty">
              <el-input v-model.number="form.faAssetQty" placeholder="请输入数量" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="管理区分" prop="faAssetMana">
              <el-input v-model.number="form.faAssetMana" placeholder="请输入管理区分" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="币种" prop="faAssetCcy">
              <el-input v-model="form.faAssetCcy" placeholder="请输入币种" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="购买价格" prop="faAcquisitionPrice">
              <el-input v-model="form.faAcquisitionPrice" placeholder="请输入购买价格" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="资本化日期" prop="faCapitalizedDate">
              <el-date-picker
                v-model="form.faCapitalizedDate"
                type="datetime"
                placeholder="选择日期时间"
                value-format="YYYY-MM-DD HH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="折旧价值" prop="faDepreciationValue">
              <el-input v-model="form.faDepreciationValue" placeholder="请输入折旧价值" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="报废日期" prop="faScrapDate">
              <el-date-picker
                v-model="form.faScrapDate"
                type="datetime"
                placeholder="选择日期时间"
                value-format="YYYY-MM-DD HH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="报废价值" prop="faScrapValue">
              <el-input v-model="form.faScrapValue" placeholder="请输入报废价值" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="存放位置" prop="faLocale">
              <el-input v-model="form.faLocale" placeholder="请输入存放位置" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="使用年限" prop="faAssetUsed">
              <el-input v-model="form.faAssetUsed" placeholder="请输入使用年限" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="是否停用" prop="faAssetStop">
              <el-input v-model.number="form.faAssetStop" placeholder="请输入是否停用" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商" prop="faAssetVender">
              <el-input v-model="form.faAssetVender" placeholder="请输入供应商" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商" prop="faAssetManufacturer">
              <el-input v-model="form.faAssetManufacturer" placeholder="请输入制造商" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="供应商物料" prop="faAssetVenderItem">
              <el-input v-model="form.faAssetVenderItem" placeholder="请输入供应商物料" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="制造商物料" prop="faAssetManufacturerItem">
              <el-input v-model="form.faAssetManufacturerItem" placeholder="请输入制造商物料" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="资产形态" prop="faEntity">
              <el-input v-model.number="form.faEntity" placeholder="请输入资产形态" />
            </el-form-item>
          </el-col>
            
          <el-col :lg="12">
            <el-form-item label="资产存在否" prop="faHaveorNot">
              <el-input v-model.number="form.faHaveorNot" placeholder="请输入资产存在否" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="盘点人员" prop="faCheckedby">
              <el-input v-model="form.faCheckedby" placeholder="请输入盘点人员" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="盘点日期" prop="faCheckedDate">
              <el-date-picker
                v-model="form.faCheckedDate"
                type="datetime"
                placeholder="选择日期时间"
                value-format="YYYY-MM-DD HH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义A" prop="uDF01">
              <el-input v-model="form.uDF01" placeholder="请输入自定义A" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义B" prop="uDF02">
              <el-input v-model="form.uDF02" placeholder="请输入自定义B" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义C" prop="uDF03">
              <el-input v-model="form.uDF03" placeholder="请输入自定义C" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义D" prop="uDF04">
              <el-input v-model="form.uDF04" placeholder="请输入自定义D" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义E" prop="uDF05">
              <el-input v-model="form.uDF05" placeholder="请输入自定义E" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义F" prop="uDF06">
              <el-input v-model="form.uDF06" placeholder="请输入自定义F" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义1" prop="uDF51">
              <el-input v-model="form.uDF51" placeholder="请输入自定义1" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义2" prop="uDF52">
              <el-input v-model="form.uDF52" placeholder="请输入自定义2" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义3" prop="uDF53">
              <el-input v-model="form.uDF53" placeholder="请输入自定义3" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义4" prop="uDF54">
              <el-input v-model="form.uDF54" placeholder="请输入自定义4" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义5" prop="uDF55">
              <el-input v-model="form.uDF55" placeholder="请输入自定义5" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="自定义6" prop="uDF56">
              <el-input v-model="form.uDF56" placeholder="请输入自定义6" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
            <el-form-item label="备注" prop="remark">
              <el-input type="textarea" v-model="form.remark" placeholder="请输入备注"/>
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
              <el-input v-model="form.createBy" placeholder="请输入创建者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="创建时间" prop="createTime">
              <el-date-picker
                v-model="form.createTime"
                type="datetime"
                placeholder="选择日期时间"
                value-format="YYYY-MM-DD HH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新者" prop="updateBy">
              <el-input v-model="form.updateBy" placeholder="请输入更新者" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="更新时间" prop="updateTime">
              <el-date-picker
                v-model="form.updateTime"
                type="datetime"
                placeholder="选择日期时间"
                value-format="YYYY-MM-DD HH:mm:ss">
              </el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="ficoasset">
import { listFicoAsset,
 addFicoAsset, delFicoAsset, 
 updateFicoAsset,getFicoAsset, 
 } 
from '@/api/accounting/ficoasset.js'
const { proxy } = getCurrentInstance()
const ids = ref([])
const loading = ref(false)
const showSearch = ref(true)
const queryParams = reactive({
  pageNum: 1,
  pageSize: 10,
  sort: '',
  sortType: 'asc',
})
const columns = ref([
  { visible: true, align: 'center', type: '', prop: 'faSFID', label: 'SFID'   },
  { visible: true, align: 'center', type: '', prop: 'faCorp', label: '公司'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'faDept', label: '使用部门'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'faClassCode', label: '资产类别'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'faAssetNo', label: '资产编码'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'faCostCenter', label: '成本中心'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'faAssetShortName', label: '资产简称'  ,showOverflowTooltip: true  },
  { visible: true, align: 'center', type: '', prop: 'faAssetFullName', label: '资产全称'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faAssetUnit', label: '单位'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faAssetQty', label: '数量'   },
  { visible: false, align: 'center', type: '', prop: 'faAssetMana', label: '管理区分'   },
  { visible: false, align: 'center', type: '', prop: 'faAssetCcy', label: '币种'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faAcquisitionPrice', label: '购买价格'   },
  { visible: false, align: 'center', type: '', prop: 'faCapitalizedDate', label: '资本化日期'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faDepreciationValue', label: '折旧价值'   },
  { visible: false, align: 'center', type: '', prop: 'faScrapDate', label: '报废日期'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faScrapValue', label: '报废价值'   },
  { visible: false, align: 'center', type: '', prop: 'faLocale', label: '存放位置'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faAssetUsed', label: '使用年限'   },
  { visible: false, align: 'center', type: '', prop: 'faAssetStop', label: '是否停用'   },
  { visible: false, align: 'center', type: '', prop: 'faAssetVender', label: '供应商'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faAssetManufacturer', label: '制造商'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faAssetVenderItem', label: '供应商物料'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faAssetManufacturerItem', label: '制造商物料'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faEntity', label: '资产形态'   },
  { visible: false, align: 'center', type: '', prop: 'faHaveorNot', label: '资产存在否'   },
  { visible: false, align: 'center', type: '', prop: 'faCheckedby', label: '盘点人员'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'faCheckedDate', label: '盘点日期'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'uDF01', label: '自定义A'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'uDF02', label: '自定义B'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'uDF03', label: '自定义C'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'uDF04', label: '自定义D'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'uDF05', label: '自定义E'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'uDF06', label: '自定义F'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'uDF51', label: '自定义1'   },
  { visible: false, align: 'center', type: '', prop: 'uDF52', label: '自定义2'   },
  { visible: false, align: 'center', type: '', prop: 'uDF53', label: '自定义3'   },
  { visible: false, align: 'center', type: '', prop: 'uDF54', label: '自定义4'   },
  { visible: false, align: 'center', type: '', prop: 'uDF55', label: '自定义5'   },
  { visible: false, align: 'center', type: '', prop: 'uDF56', label: '自定义6'   },
  { visible: false, align: 'center', type: '', prop: 'remark', label: '备注'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: 'dict', prop: 'isDeleted', label: '软删除'   },
  { visible: false, align: 'center', type: '', prop: 'createBy', label: '创建者'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'createTime', label: '创建时间'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'updateBy', label: '更新者'  ,showOverflowTooltip: true  },
  { visible: false, align: 'center', type: '', prop: 'updateTime', label: '更新时间'  ,showOverflowTooltip: true  },
  //{ visible: false, prop: 'actions', label: '操作', type: 'slot', width: '160' }
])
const total = ref(0)
const dataList = ref([])
const queryRef = ref()
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
]


function getList(){
  loading.value = true
  listFicoAsset(queryParams).then(res => {
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
const formRef = ref()
const title = ref('')
// 操作类型 1、add 2、edit 3、view
const opertype = ref(0)
const open = ref(false)
const state = reactive({
  single: true,
  multiple: true,
  form: {},
  rules: {
    faSFID: [{ required: true, message: "SFID不能为空", trigger: "blur" }],
    faCorp: [{ required: true, message: "公司不能为空", trigger: "blur"     }],
    faDept: [{ required: true, message: "使用部门不能为空", trigger: "blur"     }],
    faClassCode: [{ required: true, message: "资产类别不能为空", trigger: "blur"     }],
    faAssetNo: [{ required: true, message: "资产编码不能为空", trigger: "blur"     }],
    faCostCenter: [{ required: true, message: "成本中心不能为空", trigger: "blur"     }],
    faAssetShortName: [{ required: true, message: "资产简称不能为空", trigger: "blur"     }],
    faAssetFullName: [{ required: true, message: "资产全称不能为空", trigger: "blur"     }],
    faAssetUnit: [{ required: true, message: "单位不能为空", trigger: "blur"     }],
    faAssetQty: [{ required: true, message: "数量不能为空", trigger: "blur"    , type: "number"  }],
    faAssetMana: [{ required: true, message: "管理区分不能为空", trigger: "blur"    , type: "number"  }],
    faAssetCcy: [{ required: true, message: "币种不能为空", trigger: "blur"     }],
    faAcquisitionPrice: [{ required: true, message: "购买价格不能为空", trigger: "blur"     }],
    faCapitalizedDate: [{ required: true, message: "资本化日期不能为空", trigger: "blur"     }],
    faDepreciationValue: [{ required: true, message: "折旧价值不能为空", trigger: "blur"     }],
    faLocale: [{ required: true, message: "存放位置不能为空", trigger: "blur"     }],
    faAssetUsed: [{ required: true, message: "使用年限不能为空", trigger: "blur"     }],
    faAssetStop: [{ required: true, message: "是否停用不能为空", trigger: "blur"    , type: "number"  }],
    faEntity: [{ required: true, message: "资产形态不能为空", trigger: "blur"    , type: "number"  }],
    faHaveorNot: [{ required: true, message: "资产存在否不能为空", trigger: "blur"    , type: "number"  }],
    faCheckedby: [{ required: true, message: "盘点人员不能为空", trigger: "blur"     }],
    faCheckedDate: [{ required: true, message: "盘点日期不能为空", trigger: "blur"     }],
    uDF51: [{ required: true, message: "自定义1不能为空", trigger: "blur"     }],
    uDF52: [{ required: true, message: "自定义2不能为空", trigger: "blur"     }],
    uDF53: [{ required: true, message: "自定义3不能为空", trigger: "blur"     }],
    uDF54: [{ required: true, message: "自定义4不能为空", trigger: "blur"     }],
    uDF55: [{ required: true, message: "自定义5不能为空", trigger: "blur"     }],
    uDF56: [{ required: true, message: "自定义6不能为空", trigger: "blur"     }],
    isDeleted: [{ required: true, message: "软删除不能为空", trigger: "blur"    , type: "number"  }],
  },
  options: {
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
isDeletedOptions: [],
  }
})

const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    faSFID: null,
    faCorp: null,
    faDept: null,
    faClassCode: null,
    faAssetNo: null,
    faCostCenter: null,
    faAssetShortName: null,
    faAssetFullName: null,
    faAssetUnit: null,
    faAssetQty: null,
    faAssetMana: null,
    faAssetCcy: null,
    faAcquisitionPrice: null,
    faCapitalizedDate: null,
    faDepreciationValue: null,
    faScrapDate: null,
    faScrapValue: null,
    faLocale: null,
    faAssetUsed: null,
    faAssetStop: null,
    faAssetVender: null,
    faAssetManufacturer: null,
    faAssetVenderItem: null,
    faAssetManufacturerItem: null,
    faEntity: null,
    faHaveorNot: null,
    faCheckedby: null,
    faCheckedDate: null,
    uDF01: null,
    uDF02: null,
    uDF03: null,
    uDF04: null,
    uDF05: null,
    uDF06: null,
    uDF51: null,
    uDF52: null,
    uDF53: null,
    uDF54: null,
    uDF55: null,
    uDF56: null,
    remark: null,
    isDeleted: null,
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
  title.value = '添加固定资产'
  opertype.value = 1
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.faSFID || ids.value
  getFicoAsset(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = '修改固定资产'
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

      if (form.value.faSFID != undefined && opertype.value === 2) {
        updateFicoAsset(form.value).then((res) => {
          proxy.$modal.msgSuccess("修改成功")
          open.value = false
          getList()
        })
      } else {
        addFicoAsset(form.value).then((res) => {
            proxy.$modal.msgSuccess("新增成功")
            open.value = false
            getList()
          })
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.faSFID || ids.value

  proxy
    .$confirm('是否确认删除参数编号为"' + Ids + '"的数据项？', "警告", {
      confirmButtonText: proxy.$t('common.ok'),
      cancelButtonText: proxy.$t('common.cancel'),
      type: "warning",
    })
    .then(function () {
      return delFicoAsset(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess("删除成功")
    })
}




handleQuery()
</script>