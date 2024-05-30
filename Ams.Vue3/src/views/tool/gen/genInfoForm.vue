<template>
  <el-form ref="genInfoForm" :model="info" :rules="rules" label-width="auto">
    <el-row>
      <el-col :lg="12">
        <el-form-item prop="tplCategory">
          <template #label>{{$t('gencode.tplCategory')}}</template>
          <el-select v-model="info.tplCategory" @change="tplSelectChange">
            <el-option :label="$t('gencode.crud')" value="crud" />
            <!-- <el-option label="单表查询" value="select" /> -->
            <el-option :label="$t('gencode.tree')" value="tree" />
            <!-- <el-option label="导航查询(1对1)" value="subNav"></el-option>
            <el-option label="导航查询(1对多)" value="subNavMore"></el-option> -->
            <el-option :label="$t('gencode.subNavMore')" value="subNavMore" />
          </el-select>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="frontTpl">
          <template #label>{{$t('gencode.frontTpl')}}</template>
          <el-select v-model="info.frontTpl">
            <el-option label="Vue2 element ui" :value="1" />
            <el-option label="Vue3 element plus" :value="2" />
            <el-option label="Ant design" :value="3" />
          </el-select>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="baseNameSpace">
          <template #label>
            {{$t('gencode.baseNameSpace')}}
            <span>
              <el-tooltip :content="$t('gencode.baseNameSpaceMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.baseNameSpace" />
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="moduleName">
          <template #label>
            {{$t('gencode.moduleName')}}
            <span>
              <el-tooltip :content="$t('gencode.moduleNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.moduleName" auto-complete="" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="businessName">
          <template #label>
            {{$t('gencode.businessName')}}
            <span>
              <el-tooltip :content="$t('gencode.businessNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.businessName" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="functionName">
          <template #label>
            {{$t('gencode.functionName')}}
            <span>
              <el-tooltip :content="$t('gencode.functionNameMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.functionName" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item>
          <template #label>
            {{$t('gencode.Parentmenu')}}
            <span>
              <el-tooltip :content="$t('gencode.ParentmenuMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-cascader class="w100" :options="menuOptions"
            :props="{ checkStrictly: true, value: 'menuId', label: 'menuName', emitPath: false }"
            :placeholder="$t('btn.select')" clearable @change="clearParentMent($event)" v-model="info.parentMenuId">
            <template #default="{ node, data }">
              <span>{{ data.menuName }}</span>
              <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
            </template>
          </el-cascader>
        </el-form-item>
      </el-col>
      <el-col :lg="24">
        <el-form-item :label="$t('gencode.sortField')">
          <el-select v-model="info.sortField" :placeholder="$t('btn.select')" class="mr10" clearable="">
            <el-option v-for="item in columns" :key="item.columnId" :label="item.csharpField" :value="item.csharpField">
            </el-option>
          </el-select>

          <el-radio v-model="info.sortType" label="asc">{{$t('gencode.sortAsc')}}</el-radio>
          <el-radio v-model="info.sortType" label="desc">{{$t('gencode.sortDesc')}}</el-radio>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="useSnowflakeId">
          <template #label>
            {{$t('gencode.useSnowflakeId')}}
            <span>
              <el-tooltip :content="$t('gencode.useSnowflakeIdMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-radio-group :disabled="info.tplCategory != 'crud'" v-model="info.useSnowflakeId">
            <el-radio :label="true">{{$t('gencode.Repyes')}}</el-radio>
            <el-radio :label="false">{{$t('gencode.Repno')}}</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="permissionPrefix">
          <template #label>
            {{$t('gencode.permissionPrefix')}}
            <span>
              <el-tooltip :content="$t('gencode.permissionPrefixMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.permissionPrefix" :placeholder="$t('btn.enter')"></el-input>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="genType">
          <template #label>
            {{$t('gencode.genType')}}
            <span>
              <el-tooltip :content="$t('gencode.defCustomPath')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-radio v-model="info.genType" label="0">{{$t('gencode.Zip')}}</el-radio>
          <el-radio v-model="info.genType" label="1">{{$t('gencode.defCustomPath')}}</el-radio>
        </el-form-item>
      </el-col>

      <el-col :lg="12" v-if="info.genType == '1'">
        <el-form-item prop="genPath">
          <template #label>
            {{$t('gencode.defCustomPath')}}
            <span>
              <el-tooltip :content="$t('gencode.CustomPathMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-input v-model="info.genPath" :placeholder="$t('gencode.genPath')"></el-input>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item :label="$t('gencode.isRepository')">
          <template #label>
            {{$t('gencode.isRepository')}}
            <span>
              <el-tooltip :content="$t('gencode.isRepositoryMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-radio-group v-model="info.generateRepo">
            <el-radio :label="1">{{$t('gencode.Repyes')}}</el-radio>
            <el-radio :label="0">{{$t('gencode.Repno')}}</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-col>

      <el-col :lg="12" v-if="info.genType == '1'">
        <el-form-item prop="generateMenu" :label="$t('gencode.isMenu')">
          <template #label>
            {{$t('gencode.isMenu')}}
            <span>
              <el-tooltip :content="$t('gencode.isMenuMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-switch v-model="info.generateMenu" class="ml-2" />
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="colNum" :label="$t('gencode.oneRowDisp')">
          <template #label>
            {{$t('gencode.oneRowDisp')}}
            <span>
              <el-tooltip :content="$t('gencode.oneRowDispMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-radio v-model="info.colNum" :label="12">{{$t('gencode.col2')}}</el-radio>
          <el-radio v-model="info.colNum" :label="24">{{$t('gencode.col1')}}</el-radio>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="operBtnStyle" :label="$t('gencode.buttonStyle')">
          <el-radio v-model="info.operBtnStyle" :label="1">{{$t('gencode.styleBase')}}</el-radio>
          <el-radio v-model="info.operBtnStyle" :label="2">{{$t('gencode.styleText')}}</el-radio>
        </el-form-item>
      </el-col>
      <el-col :lg="24" v-show="info.tplCategory != 'select'">
        <el-form-item :label="$t('gencode.Buildfunction')">
          <el-checkbox-group v-model="info.checkedBtn" @change="checkedBtnSelect">
            <el-checkbox :label="1">
              <el-tag type="add">{{$t('gencode.funadd')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="2">
              <el-tag type="edit">{{$t('gencode.funedit')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="3">
              <el-tag type="delete">{{$t('gencode.fundelete')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="4">
              <el-tag type="deletebatch">{{$t('gencode.fundelmutil')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="5">
              <el-tag type="import">{{$t('gencode.funimport')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="6">
              <el-tag type="export">{{$t('gencode.funexport')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="7">
              <el-tag type="view">{{$t('gencode.funview')}}</el-tag>
            </el-checkbox>
            <el-checkbox :label="8">
              <el-tag type="empty">{{$t('gencode.funempty')}}</el-tag>
            </el-checkbox>


          </el-checkbox-group>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item>
          <template #label>
            {{$t('gencode.enableDiffLog')}}
            <span>
              <el-tooltip :content="$t('gencode.enableDiffLogMemo')" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-radio-group v-model="info.enableLog">
            <el-radio :label="true">{{$t('gencode.Repyes')}}</el-radio>
            <el-radio :label="false">{{$t('gencode.Repno')}}</el-radio>
          </el-radio-group>
        </el-form-item>
      </el-col>
    </el-row>

    <!-- 树表配置 -->
    <el-row v-if="info.tplCategory == 'tree'">
      <el-col :lg="24">
        <h4 class="form-header">树表信息</h4>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="treeCode">
          <template #label>
            树编码字段
            <span>
              <el-tooltip content="树显示的编码字段名， 如：dept_id" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.treeCode" placeholder="请选择树编码字段">
            <el-option v-for="(column, index) in columns" :key="index" :label="column.columnComment"
              :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="treeName">
          <template #label>
            树名称字段
            <span>
              <el-tooltip content="树节点的显示名称字段名， 如：dept_name" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.treeName" placeholder="请选择树名称字段">
            <el-option v-for="(column, index) in columns" :key="index" :label="column.csharpField"
              :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
      <el-col :lg="24">
        <el-form-item prop="treeParentCode">
          <template #label>
            树父编码字段
            <span>
              <el-tooltip content="树显示的父编码字段名， 如：parent_Id" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.treeParentCode" placeholder="请选择树父编码字段">
            <el-option v-for="(column, index) in columns" :key="index"
              :label="column.csharpField + '：' + column.columnComment" :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
    </el-row>

    <!-- 主子表配置 -->
    <el-row v-if="info.tplCategory == 'sub' || info.tplCategory == 'subNav' || info.tplCategory == 'subNavMore'">
      <el-col :lg="24">
        <h4 class="form-header">关联信息</h4>
      </el-col>

      <el-col :lg="12">
        <el-form-item prop="subTableName">
          <template #label>
            关联子表的表名
            <span>
              <el-tooltip content="关联子表的表名， 如：sys_user" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.subTableName" filterable placeholder="请选择" @change="subSelectChange(this)">
            <el-option v-for="(table, index) in tables" :disabled="table.tableName == info.tableName" :key="index"
              :label="table.tableName + '：' + table.tableComment" :value="table.tableName">
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
      <el-col :lg="12">
        <el-form-item prop="subTableFkName">
          <template #label>
            子表关联的外键名
            <span>
              <el-tooltip content="子表关联的外键名， 如：user_id" placement="top">
                <el-icon>
                  <question-filled />
                </el-icon>
              </el-tooltip>
            </span>
          </template>
          <el-select v-model="info.subTableFkName">
            <el-option v-for="(column, index) in subColumns" :key="index" :label="column.csharpField"
              :value="column.csharpField">
              <span style="float: left">{{ column.csharpField }}</span>
              <span style="float: right">{{ column.columnComment }}</span>
            </el-option>
          </el-select>
        </el-form-item>
      </el-col>
    </el-row>
  </el-form>
</template>

<script setup name="genInfoForm">
  import { listMenu } from '@/api/system/menu'
  import { queryColumnInfo } from '@/api/tool/gen'

  const subColumns = ref([])
  const menuOptions = ref([])

  const props = defineProps({
    info: {
      type: Object,
      default: null
    },
    // 字表
    tables: {
      type: Array,
      default: null
    },
    // 列
    columns: {
      type: Array,
      default: []
    }
  })
  // 表单校验
  const rules = ref({
    tplCategory: [{ required: true, message: '请选择生成模板', trigger: 'blur' }],
    moduleName: [
      {
        required: true,
        message: '请输入生成模块名',
        trigger: 'blur',
        pattern: /^[A-Za-z]+$/
      }
    ],
    businessName: [
      {
        required: true,
        message: '请输入生成业务名',
        trigger: 'blur',
        pattern: /^[A-Za-z]+$/
      }
    ],
    functionName: [{ required: true, message: '请输入生成功能名', trigger: 'blur' }],
    permissionPrefix: {
      required: true,
      message: '请输入权限前缀',
      trigger: 'blur'
    },
    genType: [{ required: true, message: '请选择代码生成方式', trigger: 'blur' }],
    treeCode: [{ required: true, message: '请选择树编码字段', trigger: 'blur' }],
    treeParentCode: [{ required: true, message: '请选择树父编码字段', trigger: 'blur' }],
    subTableName: [{ required: true, message: '请选择关联的子表表名', trigger: 'blur' }],
    subTableFkName: [{ required: true, message: '请选择子表关联的外键名', trigger: 'blur' }]
  })
  function subSelectChange(value) {
    props.info.subTableFkName = ''
  }
  function tplSelectChange(value) {
    if (value !== 'sub') {
      props.info.subTableName = ''
      props.info.subTableFkName = ''
    }
  }
  function clearParentMent(e) {
    if (e == null) {
      props.info.parentMenuId = 0
    }
  }
  function setSubTableColumns(value) {
    if (value == null || value == undefined || value == '') {
      return
    }
    for (var item in props.tables) {
      const obj = props.tables[item]
      if (value === obj.tableName) {
        queryColumnInfo(obj.tableId).then((res) => {
          if (res.code == 200) {
            subColumns.value = res.data.columns
          }
        })
        break
      }
    }
  }
  /** 查询菜单下拉树结构 */
  function getMenuTreeselect() {
    /** 查询菜单下拉列表 */
    listMenu({ menuTypeIds: 'M,C' }).then((response) => {
      menuOptions.value = response.data
    })
  }
  function checkedBtnSelect(value) {
    console.log(value)
  }
  watch(
    () => props.info.subTableName,
    (val) => {
      setSubTableColumns(val)
    }
  )

  getMenuTreeselect()
</script>