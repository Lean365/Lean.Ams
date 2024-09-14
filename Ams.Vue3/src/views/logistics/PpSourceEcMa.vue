<!--
 * @Descripttion: 主源设变/pp_source_ec_ma
 * @Version: 0.24.619.30682
 * @Author: Lean365(Davis.Ching)
 * @Date: 2024/9/10 17:09:51
 * @column：53
 * 日期显示格式：<template #default="scope"> {{ parseTime(scope.row.xxxDate, 'YYYY-MM-DD') }} </template>
-->
<template>
  <div>
    <!-- 查询区域 -->
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent label-width="auto">
      <el-row :gutter="10" class="mb8">
        <el-col :lg="24">
      <el-form-item label="设变No." prop="za002">
        <el-input v-model="queryParams.za002" :placeholder="$t('btn.enterSearchPrefix')+'设变No.'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="标题" prop="za004">
        <el-input v-model="queryParams.za004" :placeholder="$t('btn.enterSearchPrefix')+'标题'+$t('btn.enterSearchSuffix')" />
      </el-form-item>
      <el-form-item label="发行日">
        <el-date-picker
          v-model="dateRangeZa006" 
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
        <el-button class="btn-add" v-hasPermi="['pp:sourceecma:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-edit" :disabled="single" v-hasPermi="['pp:sourceecma:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button class="btn-deletebatch" :disabled="multiple" v-hasPermi="['pp:sourceecma:delete']" plain icon="delete" @click="handleDelete">
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
                <importData
                  templateUrl="Logistics/PpSourceEcMa/importTemplate"
                  importUrl="/Logistics/PpSourceEcMa/importData"
                  @success="handleFileSuccess"></importData>
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
      <el-table-column align="center" width="90">
        <template #default="scope">
          <el-button class="btn-view" plain  icon="view" size="small" @click="rowClick(scope.row)" :title=" $t('btn.details') "></el-button>
        </template>
      </el-table-column>
      <el-table-column prop="id" label="ID" align="center" v-if="columns.showColumn('id')"/>
      <el-table-column prop="za002" label="设变No." align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za002')"/>
      <el-table-column prop="za003" label="机种" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za003')"/>
      <el-table-column prop="za004" label="标题" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za004')"/>
      <el-table-column prop="za005" label="状态" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za005')"/>
      <el-table-column prop="za006" label="发行日" :show-overflow-tooltip="true"  v-if="columns.showColumn('za006')"/>
      <el-table-column prop="za007" label="担当" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za007')"/>
      <el-table-column prop="za008" label="依赖" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za008')"/>
      <el-table-column prop="za009" label="会议" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za009')"/>
      <el-table-column prop="za010" label="PP番号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za010')"/>
      <el-table-column prop="za011" label="联络书" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za011')"/>
      <el-table-column prop="za012" label="实施" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za012')"/>
      <el-table-column prop="za013" label="主理由" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za013')"/>
      <el-table-column prop="za014" label="次理由" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za014')"/>
      <el-table-column prop="za015" label="安规" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za015')"/>
      <el-table-column prop="za016" label="状况" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za016')"/>
      <el-table-column prop="za017" label="机番" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za017')"/>
      <el-table-column prop="za018" label="承认" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za018')"/>
      <el-table-column prop="za019" label="服务手册订正" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za019')"/>
      <el-table-column prop="za020" label="用户手册订正" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za020')"/>
      <el-table-column prop="za021" label="宣传手册订正" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za021')"/>
      <el-table-column prop="za022" label="SOP订正" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za022')"/>
      <el-table-column prop="za023" label="信息发行" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za023')"/>
      <el-table-column prop="za024" label="成本变动" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za024')"/>
      <el-table-column prop="za025" label="单位成本" align="center" v-if="columns.showColumn('za025')"/>
      <el-table-column prop="za026" label="模具改造费" align="center" v-if="columns.showColumn('za026')"/>
      <el-table-column prop="za027" label="图纸" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za027')"/>
      <el-table-column prop="za028" label="设变内容" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za028')"/>
      <el-table-column prop="za029" label="处理标记" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('za029')"/>
      <el-table-column prop="remark" label="备注说明" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operation')" width="160" align="center">
        <template #default="scope">
          <el-button-group>
          <el-button class="btn-edit" plain size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['pp:sourceecma:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button class="btn-delete" plain size="small" icon="delete" :title="$t('btn.delete')" v-hasPermi="['pp:sourceecma:delete']" @click="handleDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 一对一/一对多列表显示详情 -->
    <el-drawer v-model="drawer" size="65%" direction="rtl">
      <el-table :data="ppSourceEcSlvList" header-row-class-name="text-navy">
        <el-table-column :label="$t('layout.indexNo')" type="index" width="80" />
        <el-table-column prop="id" label="ID"/>
        <el-table-column prop="zb002" label="父ID"/>
        <el-table-column prop="zb003" label="设变No."/>
        <el-table-column prop="zb004" label="完成品"/>
        <el-table-column prop="zb005" label="上阶"/>
        <el-table-column prop="zb006" label="旧物料"/>
        <el-table-column prop="zb007" label="品名"/>
        <el-table-column prop="zb008" label="数量"/>
        <el-table-column prop="zb009" label="位置"/>
        <el-table-column prop="zb010" label="新物料"/>
        <el-table-column prop="zb011" label="品名"/>
        <el-table-column prop="zb012" label="数量"/>
        <el-table-column prop="zb013" label="位置"/>
        <el-table-column prop="zb014" label="BOM番号"/>
        <el-table-column prop="zb015" label="互换性"/>
        <el-table-column prop="zb016" label="区分"/>
        <el-table-column prop="zb017" label="安排指示"/>
        <el-table-column prop="zb018" label="旧品处理"/>
        <el-table-column prop="zb019" label="BOM生效"/>
        <el-table-column prop="zb020" label="处理标记"/>
        <el-table-column prop="remark" label="备注说明"/>
      </el-table>
    </el-drawer>
    <!-- 添加或修改主源设变对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" :fullscreen="fullScreen">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
        <el-row :gutter="20">

          <el-col :lg="12">
            <el-form-item label="设变No." prop="za002">
              <el-input   v-model="form.za002" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')"  show-word-limit   maxlength="6"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机种" prop="za003">
              <el-input   v-model="form.za003" :placeholder="$t('btn.enterPrefix')+'机种'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="标题" prop="za004">
              <el-input   v-model="form.za004" :placeholder="$t('btn.enterPrefix')+'标题'+$t('btn.enterSuffix')"  show-word-limit   maxlength="50"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状态" prop="za005">
              <el-input   v-model="form.za005" :placeholder="$t('btn.enterPrefix')+'状态'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="发行日" prop="za006">
              <el-date-picker v-model="form.za006" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="担当" prop="za007">
              <el-input   v-model="form.za007" :placeholder="$t('btn.enterPrefix')+'担当'+$t('btn.enterSuffix')"  show-word-limit   maxlength="100"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="依赖" prop="za008">
              <el-input   v-model="form.za008" :placeholder="$t('btn.enterPrefix')+'依赖'+$t('btn.enterSuffix')"  show-word-limit   maxlength="30"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="会议" prop="za009">
              <el-input   v-model="form.za009" :placeholder="$t('btn.enterPrefix')+'会议'+$t('btn.enterSuffix')"  show-word-limit   maxlength="20"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="PP番号" prop="za010">
              <el-input   v-model="form.za010" :placeholder="$t('btn.enterPrefix')+'PP番号'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="联络书" prop="za011">
              <el-input   v-model="form.za011" :placeholder="$t('btn.enterPrefix')+'联络书'+$t('btn.enterSuffix')"  show-word-limit   maxlength="10"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="实施" prop="za012">
              <el-input   v-model="form.za012" :placeholder="$t('btn.enterPrefix')+'实施'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="主理由" prop="za013">
              <el-input   v-model="form.za013" :placeholder="$t('btn.enterPrefix')+'主理由'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="次理由" prop="za014">
              <el-input   v-model="form.za014" :placeholder="$t('btn.enterPrefix')+'次理由'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="安规" prop="za015">
              <el-input   v-model="form.za015" :placeholder="$t('btn.enterPrefix')+'安规'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="状况" prop="za016">
              <el-input   v-model="form.za016" :placeholder="$t('btn.enterPrefix')+'状况'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="机番" prop="za017">
              <el-input   v-model="form.za017" :placeholder="$t('btn.enterPrefix')+'机番'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="承认" prop="za018">
              <el-input   v-model="form.za018" :placeholder="$t('btn.enterPrefix')+'承认'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="服务手册订正" prop="za019">
              <el-input   v-model="form.za019" :placeholder="$t('btn.enterPrefix')+'服务手册订正'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="用户手册订正" prop="za020">
              <el-input   v-model="form.za020" :placeholder="$t('btn.enterPrefix')+'用户手册订正'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="宣传手册订正" prop="za021">
              <el-input   v-model="form.za021" :placeholder="$t('btn.enterPrefix')+'宣传手册订正'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="SOP订正" prop="za022">
              <el-input   v-model="form.za022" :placeholder="$t('btn.enterPrefix')+'SOP订正'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="信息发行" prop="za023">
              <el-input   v-model="form.za023" :placeholder="$t('btn.enterPrefix')+'信息发行'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="成本变动" prop="za024">
              <el-input   v-model="form.za024" :placeholder="$t('btn.enterPrefix')+'成本变动'+$t('btn.enterSuffix')"  show-word-limit   maxlength="40"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="单位成本" prop="za025">
              <el-input-number v-model.number="form.za025" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'单位成本'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="模具改造费" prop="za026">
              <el-input-number v-model.number="form.za026" :controls="true" controls-position="right" :placeholder="$t('btn.enterPrefix')+'模具改造费'+$t('btn.enterSuffix')" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="图纸" prop="za027">
              <el-input   v-model="form.za027" :placeholder="$t('btn.enterPrefix')+'图纸'+$t('btn.enterSuffix')"  show-word-limit   maxlength="210"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="设变内容" prop="za028">
              <el-input  type="textarea"  v-model="form.za028" :placeholder="$t('btn.enterPrefix')+'设变内容'+$t('btn.enterSuffix')"  show-word-limit maxlength="8000" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="处理标记" prop="za029">
              <el-input   v-model="form.za029" :placeholder="$t('btn.enterPrefix')+'处理标记'+$t('btn.enterSuffix')"  show-word-limit   maxlength="3"/>
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


    <!-- 子表信息 -->
        <el-divider content-position="center">从源设变</el-divider>
        <el-row :gutter="10" class="mb8">
          <el-col :span="1.5">
            <el-button class="btn-add" icon="Plus" @click="handleAddPpSourceEcSlv">{{ $t('btn.add') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-delete" icon="Delete" @click="handleDeletePpSourceEcSlv">{{ $t('btn.delete') }}</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button class="btn-infos" icon="FullScreen" @click="fullScreen = !fullScreen">{{ fullScreen ?  $t('layout.headerExitfullscreen') 
              : $t('layout.headerFullscreen') }}</el-button>
          </el-col>
        </el-row>
        <el-table :data="ppSourceEcSlvList" :row-class-name="rowPpSourceEcSlvIndex" @selection-change="handlePpSourceEcSlvSelectionChange" ref="PpSourceEcSlvRef">
          <el-table-column type="selection" width="40" align="center" />
          <el-table-column :label="$t('layout.indexNo')" align="center" prop="index" width="50"/>
          <el-table-column label="设变No." align="center" prop="zb003">
            <template #default="scope">
              <el-input v-model="scope.row.zb003" :placeholder="$t('btn.enterPrefix')+'设变No.'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="完成品" align="center" prop="zb004">
            <template #default="scope">
              <el-input v-model="scope.row.zb004" :placeholder="$t('btn.enterPrefix')+'完成品'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="上阶" align="center" prop="zb005">
            <template #default="scope">
              <el-input v-model="scope.row.zb005" :placeholder="$t('btn.enterPrefix')+'上阶'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧物料" align="center" prop="zb006">
            <template #default="scope">
              <el-input v-model="scope.row.zb006" :placeholder="$t('btn.enterPrefix')+'旧物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="品名" align="center" prop="zb007">
            <template #default="scope">
              <el-input v-model="scope.row.zb007" :placeholder="$t('btn.enterPrefix')+'品名'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="数量" align="center" prop="zb008" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.zb008" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="zb009">
            <template #default="scope">
              <el-input v-model="scope.row.zb009" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="新物料" align="center" prop="zb010">
            <template #default="scope">
              <el-input v-model="scope.row.zb010" :placeholder="$t('btn.enterPrefix')+'新物料'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="品名" align="center" prop="zb011">
            <template #default="scope">
              <el-input v-model="scope.row.zb011" :placeholder="$t('btn.enterPrefix')+'品名'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="数量" align="center" prop="zb012" width="140">
            <template #default="scope">
              <el-input-number v-model="scope.row.zb012" controls-position="right" :placeholder="$t('btn.enterPrefix')+'数量'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="位置" align="center" prop="zb013">
            <template #default="scope">
              <el-input v-model="scope.row.zb013" :placeholder="$t('btn.enterPrefix')+'位置'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="BOM番号" align="center" prop="zb014">
            <template #default="scope">
              <el-input v-model="scope.row.zb014" :placeholder="$t('btn.enterPrefix')+'BOM番号'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="互换性" align="center" prop="zb015">
            <template #default="scope">
              <el-input v-model="scope.row.zb015" :placeholder="$t('btn.enterPrefix')+'互换性'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="区分" align="center" prop="zb016">
            <template #default="scope">
              <el-input v-model="scope.row.zb016" :placeholder="$t('btn.enterPrefix')+'区分'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="安排指示" align="center" prop="zb017">
            <template #default="scope">
              <el-input v-model="scope.row.zb017" :placeholder="$t('btn.enterPrefix')+'安排指示'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="旧品处理" align="center" prop="zb018">
            <template #default="scope">
              <el-input v-model="scope.row.zb018" :placeholder="$t('btn.enterPrefix')+'旧品处理'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="BOM生效" align="center" prop="zb019">
            <template #default="scope">
              <el-date-picker clearable v-model="scope.row.zb019" type="date" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </template>
          </el-table-column>
          <el-table-column label="处理标记" align="center" prop="zb020">
            <template #default="scope">
              <el-input v-model="scope.row.zb020" :placeholder="$t('btn.enterPrefix')+'处理标记'+$t('btn.enterSuffix')" />
            </template>
          </el-table-column>
          <el-table-column label="备注说明" align="center" prop="remark">
            <template #default="scope">
              <el-input v-model="scope.row.remark" :placeholder="$t('btn.enterPrefix')+'备注说明'+$t('btn.enterSuffix')" />
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
import { listPpSourceEcMa,
 addPpSourceEcMa, delPpSourceEcMa, 
 updatePpSourceEcMa,getPpSourceEcMa, 
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
  sort: 'Za002',
  sortType: 'asc',
  //是否查询（1是）
  za002: undefined,
  //是否查询（1是）
  za004: undefined,
  //是否查询（1是）
  za006: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'id', label: 'ID' },
  { visible: true, prop: 'za002', label: '设变No.' },
  { visible: true, prop: 'za003', label: '机种' },
  { visible: true, prop: 'za004', label: '标题' },
  { visible: true, prop: 'za005', label: '状态' },
  { visible: true, prop: 'za006', label: '发行日' },
  { visible: true, prop: 'za007', label: '担当' },
  { visible: true, prop: 'za008', label: '依赖' },
  { visible: false, prop: 'za009', label: '会议' },
  { visible: false, prop: 'za010', label: 'PP番号' },
  { visible: false, prop: 'za011', label: '联络书' },
  { visible: false, prop: 'za012', label: '实施' },
  { visible: false, prop: 'za013', label: '主理由' },
  { visible: false, prop: 'za014', label: '次理由' },
  { visible: false, prop: 'za015', label: '安规' },
  { visible: false, prop: 'za016', label: '状况' },
  { visible: false, prop: 'za017', label: '机番' },
  { visible: false, prop: 'za018', label: '承认' },
  { visible: false, prop: 'za019', label: '服务手册订正' },
  { visible: false, prop: 'za020', label: '用户手册订正' },
  { visible: false, prop: 'za021', label: '宣传手册订正' },
  { visible: false, prop: 'za022', label: 'SOP订正' },
  { visible: false, prop: 'za023', label: '信息发行' },
  { visible: false, prop: 'za024', label: '成本变动' },
  { visible: false, prop: 'za025', label: '单位成本' },
  { visible: false, prop: 'za026', label: '模具改造费' },
  { visible: false, prop: 'za027', label: '图纸' },
  { visible: false, prop: 'za028', label: '设变内容' },
  { visible: false, prop: 'za029', label: '处理标记' },
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
// 发行日时间范围
const dateRangeZa006 = ref([])

//字典参数
var dictParams = [
]

//API获取从主源设变/pp_source_ec_ma表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeZa006.value, 'Za006');
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
function resetQuery(){
  // 发行日时间范围
  dateRangeZa006.value = []
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
    id: [{ required: true, message: "ID"+proxy.$t('btn.isEmpty'), trigger: "blur" }],
    za002: [{ required: true, message: "设变No."+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    za025: [{ required: true, message: "单位成本"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    za026: [{ required: true, message: "模具改造费"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ref04: [{ required: true, message: "预留1"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ref05: [{ required: true, message: "预留2"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    ref06: [{ required: true, message: "预留3"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    udf51: [{ required: true, message: "自定义1"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    udf52: [{ required: true, message: "自定义2"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    udf53: [{ required: true, message: "自定义3"+proxy.$t('btn.isEmpty'), trigger: "blur"    , type: "number"  }],
    udf54: [{ required: true, message: "自定义4"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    udf55: [{ required: true, message: "自定义5"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
    udf56: [{ required: true, message: "自定义6"+proxy.$t('btn.isEmpty'), trigger: "blur"     }],
  },
//字典名称
  options: {
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
    za002: null,
    za003: null,
    za004: null,
    za005: null,
    za006: null,
    za007: null,
    za008: null,
    za009: null,
    za010: null,
    za011: null,
    za012: null,
    za013: null,
    za014: null,
    za015: null,
    za016: null,
    za017: null,
    za018: null,
    za019: null,
    za020: null,
    za021: null,
    za022: null,
    za023: null,
    za024: null,
    za025: 0,
    za026: 0,
    za027: null,
    za028: null,
    za029: null,
    remark: null,
  };
  ppSourceEcSlvList.value = []
  proxy.resetForm("formRef")
}


// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+" "+'主源设变'
  opertype.value = 1
  form.value.za006= new Date()
  form.value.za025= 0
  form.value.za026= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.id || ids.value
  getPpSourceEcMa(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+" "+ '主源设变'
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
      if (form.value.id != undefined && opertype.value === 2) {
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
  const Ids = row.id || ids.value

  proxy
    .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete')+' '+proxy.$t('common.tip'), {
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
    .$confirm(proxy.$t('common.tipConfirmExport')+"<主源设变.xlsx>", proxy.$t('btn.export')+' '+proxy.$t('common.tip'), {
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
  //obj.zb003 = null;
  //obj.zb004 = null;
  //obj.zb005 = null;
  //obj.zb006 = null;
  //obj.zb007 = null;
  //obj.zb008 = null;
  //obj.zb009 = null;
  //obj.zb010 = null;
  //obj.zb011 = null;
  //obj.zb012 = null;
  //obj.zb013 = null;
  //obj.zb014 = null;
  //obj.zb015 = null;
  //obj.zb016 = null;
  //obj.zb017 = null;
  //obj.zb018 = null;
  //obj.zb019 = null;
  //obj.zb020 = null;
  //obj.remark = null;
  ppSourceEcSlvList.value.push(obj);
}

/** 复选框选中数据 */
function handlePpSourceEcSlvSelectionChange(selection) {
  checkedPpSourceEcSlv.value = selection.map(item => item.index)
}

/** 从源设变删除按钮操作 */
function handleDeletePpSourceEcSlv() {
  if(checkedPpSourceEcSlv.value.length == 0){
    proxy.$modal.msgError('请先选择要删除的从源设变数据')
  } else {
    const PpSourceEcSlvs = ppSourceEcSlvList.value;
    const checkedPpSourceEcSlvs = checkedPpSourceEcSlv.value;
    ppSourceEcSlvList.value = PpSourceEcSlvs.filter(function(item) {
      return checkedPpSourceEcSlvs.indexOf(item.index) == -1
    });
  }
}

/** 从源设变详情 */
function rowClick(row) {
  const id = row.id || ids.value
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