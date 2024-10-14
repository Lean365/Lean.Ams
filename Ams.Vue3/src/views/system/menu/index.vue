<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryRef" :inline="true" v-show="showSearch">
      <el-row :gutter="20">
        <el-col :lg="24">
          <el-form-item :label="$t('pmenu.parentMenu')" prop="parentId">
            <el-cascader class="w100" :options="menuQueryOptions"
              :props="{ checkStrictly: true, value: 'menuId', label: 'menuName', emitPath: false }"
              :placeholder="$t('btn.selectSearchPrefix')+$t('pmenu.parentMenu')+$t('btn.selectSearchSuffix')" clearable
              v-model="queryParams.parentId">
              <template #default="{ node, data }">
                <span>{{ data.menuName }}</span>
                <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
              </template>
            </el-cascader>
          </el-form-item>
          <el-form-item :label="$t('pmenu.menuName')" prop="menuName">
            <el-input v-model="queryParams.menuName"
              :placeholder="$t('btn.enterSearchPrefix')+$t('pmenu.menuName')+$t('btn.enterSearchSuffix')" clearable
              @keyup.enter="handleQuery" />
          </el-form-item>
          <el-form-item :label="$t('common.tipIsStated')" prop="isStatus">
            <el-radio-group v-model="queryParams.isStatus">
              <!-- <el-radio :value="-1">{{$t('common.all')}}</el-radio> -->
              <el-radio v-for="dict in options.sys_normal_disable" :key="dict.dictValue"
                :value="parseInt(dict.dictValue)">{{
                dict.dictLabel }}</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item :label="$t('pmenu.isShow')" prop="visible">
            <el-radio-group v-model="queryParams.visible">
              <!-- <el-radio :value="-1">{{$t('common.all')}}</el-radio> -->
              <el-radio v-for="dict in options.sys_menu_show" :key="dict.dictValue" :value="dict.dictValue">{{
                dict.dictLabel }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24" :offset="12">
          <el-form-item>
            <el-button type="primary" icon="Search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
            <el-button icon="Refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
          </el-form-item>
        </el-col>

      </el-row>
    </el-form>

    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button class="btn-add" plain icon="Plus" @click="handleAdd" v-hasPermi="['system:menu:add']">{{
          $t('btn.add')
          }}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="info" plain icon="Sort" @click="toggleExpandAll">{{ $t('btn.expand') }}/{{ $t('btn.collapse')
          }}</el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <vxe-table :height="tableHeight" show-overflow ref="listRef" size="small" :loading="loading"
      :column-config="{ resizable: true }" :tree-config="{
        parentField: 'parentId',
        reserve: true
      }" :row-config="{
        keyField: 'menuId'
      }" :border="true" :scroll-y="{ enabled: true, gt: 20 }" :data="menuList">
      <vxe-column field="menuName" :title="$t('pmenu.menuName')" tree-node width="160"> </vxe-column>
      <vxe-column field="menuId" title="Id" width="90"></vxe-column>
      <vxe-column field="icon" :title="$t('pmenu.icon')" align="center" width="80">
        <template #default="{ row }">
          <svg-icon :name="row.icon"></svg-icon>
        </template>
      </vxe-column>
      <vxe-column field="menuType" :title="$t('pmenu.menuType')" align="center" width="120">
        <template #default="scope">
          <el-tag :disable-transitions="true" type="danger"
            v-if="scope.row.menuType == 'M' && scope.row.isFrame == 1">{{ $t('pmenu.link') }}</el-tag>
          <el-tag :disable-transitions="true" v-else-if="scope.row.menuType == 'C'">{{ $t('pmenu.menu') }}</el-tag>
          <el-tag :disable-transitions="true" type="success" v-else-if="scope.row.menuType == 'M'">{{
            $t('pmenu.directory')
            }}</el-tag>
          <el-tag :disable-transitions="true" type="warning" v-else-if="scope.row.menuType == 'F'">{{ $t('pmenu.button')
            }}</el-tag>
        </template>
      </vxe-column>
      <vxe-column field="sortingNum" :title="$t('pmenu.sort')" width="110" sortable align="center"
        v-if="columns.showColumn('sortingNum')">
        <template #default="scope">
          <span v-show="editIndex != scope.row.menuId" @click="editCurrRow(scope.row.menuId)">{{ scope.row.sortingNum
            }}</span>
          <el-input :ref="setColumnsRef" v-show="editIndex == scope.row.menuId" v-model="scope.row.sortingNum"
            @blur="handleChangeSort(scope.row)"></el-input>
        </template>
      </vxe-column>
      <vxe-column field="perms" :title="$t('pmenu.authorityID')" show-overflow="title"></vxe-column>
      <vxe-column field="component" :title="$t('pmenu.componentPath')" show-overflow></vxe-column>
      <vxe-column field="visible" :title="$t('pmenu.isShow')" width="90" align="center">
        <template #default="scope">
          <dict-tag :options="options.sys_menu_show" :value="scope.row.visible" />
        </template>
      </vxe-column>
      <vxe-column field="isStatus" :title="$t('common.tipIsStated')" width="120" align="center">
        <template #default="scope">
          <dict-tag :options="options.sys_normal_disable" :value="scope.row.isStatus" />
        </template>
      </vxe-column>
      <vxe-column :title="$t('common.tipCreateTime')" align="center" field="createTime" show-overflow
        v-if="columns.showColumn('createTime')">
        <template #default="scope">
          <span>{{ parseTime(scope.row.createTime) }}</span>
        </template>
      </vxe-column>
      <vxe-column :title="$t('btn.operation')" align="center" width="140">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-add" plain size="small" icon="Plus" @click="handleAdd(scope.row)"
              v-hasPermi="['system:menu:add']"></el-button>
            <el-button class="btn-edit" plain size="small" icon="Edit" @click="handleUpdate(scope.row)"
              v-hasPermi="['system:menu:edit']"></el-button>
            <el-dropdown>
              <el-button size="small" class="btn-more">
                <el-icon class="el-icon--right">
                  <arrow-down />
                </el-icon>
              </el-button>

              <template #dropdown>
                <el-dropdown-menu>
                  <div v-hasPermi="['system:menu:remove']">
                    <el-dropdown-item>
                      <el-button class="btn-delete" plain size="small" icon="Delete" @click="handleDelete(scope.row)"
                        :title="$t('btn.delete')"></el-button>
                    </el-dropdown-item>
                  </div>
                  <div v-hasPermi="['system:menu:remove']" class="mt10">
                    <el-dropdown-item>
                      <el-button class="btn-deletebatch" plain size="small" icon="DeleteFilled" type="danger"
                        @click="handleDeleteAll(scope.row)" :title="$t('btn.delete')+$t('common.all')"> </el-button>
                    </el-dropdown-item>
                  </div>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
          </el-button-group>
        </template>
      </vxe-column>
    </vxe-table>

    <menuForm ref="menuFormRef" :options="options" :menuOptions="menuOptions" @success="refreshMenu"></menuForm>
  </div>
</template>

<script setup name="sysmenu">
  import { delMenu, listMenu, changeMenuSort as changeSort, delAllMenu } from '@/api/system/menu'
  import menuForm from '@/views/components/form/menuForm.vue'
  import '@/assets/styles/btn-custom.scss'
  //VxeTable.setTheme('dark')
  const { proxy } = getCurrentInstance()

  var dictParams = [{ dictType: 'sys_menu_show' }, { dictType: 'sys_normal_disable' }]
  const menuList = ref([])

  const loading = ref(true)
  const showSearch = ref(true)

  const menuOptions = ref([])
  const menuQueryOptions = ref([])
  const isExpandAll = ref(false)

  const listRef = ref(null)
  const state = reactive({
    form: {},
    queryParams: {
      menuName: undefined,
      visible: undefined,
      isStatus: undefined,
      menuTypeIds: 'M,C',
      parentId: undefined
    },
    options: {
      sys_menu_show: [],
      sys_normal_disable: []
    }
  })
  const { queryParams, options } = toRefs(state)

  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })
  // 列显隐信息
  const columns = ref([
    { label: proxy.$t('common.tipCreateTime'), visible: false, prop: 'createTime' },
    { label: proxy.$t('pmenu.sort'), visible: true, prop: 'sortingNum' }
  ])

  const tableHeight = ref(document.documentElement.scrollHeight - 245 + 'px')

  /** 查询菜单列表 */
  function getList(type) {
    loading.value = true
    if (queryParams.value.parentId != undefined || queryParams.value.menuName != undefined) {
      queryParams.value.menuTypeIds = ''
    } else {
      queryParams.value.menuTypeIds = 'M,C,F'
    }
    listMenu(queryParams.value).then((response) => {
      menuList.value = response.data

      if (type == 1) {
        menuQueryOptions.value = response.data


      }
      loading.value = false
    })
  }
  /** 查询菜单下拉树结构 */
  function getTreeselect() {
    listMenu({ menuTypeIds: 'M,C,F' }).then((response) => {
      menuOptions.value = response.data
    })
  }
  getTreeselect()
  /** 搜索按钮操作 */
  function handleQuery() {
    getList()
  }
  /** 重置按钮操作 */
  function resetQuery() {
    proxy.resetForm('queryRef')
    handleQuery()
  }
  /** 新增按钮操作 */
  function handleAdd(row) {
    proxy.$refs.menuFormRef.handleAdd(row)
  }
  /** 展开/折叠操作 */
  function toggleExpandAll() {
    // refreshTable.value = false
    isExpandAll.value = !isExpandAll.value
    // nextTick(() => {
    //   refreshTable.value = true
    // })
    const $table = listRef.value
    if ($table) {
      if (isExpandAll.value) {
        $table.setAllTreeExpand(true)
      } else {
        $table.clearTreeExpand()
      }
    }
  }

  /** 修改按钮操作 */
  function handleUpdate(row) {
    proxy.$refs.menuFormRef.handleUpdate(row)
  }

  /** 删除按钮操作 */
  function handleDelete(row) {
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + row.menuName + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })

      .then(() => {
        // getList()
        refreshMenu(row.parentId)
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }
  /** 删除按钮操作 */
  function handleDeleteAll(row) {
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + row.menuName + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(function () {
        return delAllMenu(row.menuId)
      })
      .then(() => {
        // getList()
        refreshMenu(row.parentId)
        proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))
      })
  }
  // ******************自定义编辑 start **********************
  // 动态ref设置值
  const columnRefs = ref([])
  const setColumnsRef = (el) => {
    if (el) {
      columnRefs.value.push(el)
    }
  }
  const editIndex = ref(-1)
  // 显示编辑排序
  function editCurrRow(rowId) {
    editIndex.value = rowId

    setTimeout(() => {
      columnRefs.value[rowId].focus()
    }, 100)
  }
  // 保存排序
  function handleChangeSort(info) {
    editIndex.value = -1
    proxy
      .$confirm(proxy.$t('common.tipConfirmSave'))
      .then(function () {
        return changeSort({ value: info.sortingNum, id: info.menuId })
      })
      .then(() => {
        handleQuery()
        refreshMenu(info.parentId)
        proxy.$modal.msgSuccess(proxy.$t('common.tipUpdateSucceed'))
      })
      .catch(() => {
        handleQuery()
      })
  }
  // ******************自定义编辑 end **********************
  // 刷新懒加载后的数据
  function refreshMenu(pid) {
    loading.value = true

    getList()
  }

  listMenu({ menuTypeIds: 'M,C' }).then((response) => {
    menuQueryOptions.value = response.data
  })

  // 首次列表加载（只加载一层）
  // getList(1)
  handleQuery()
</script>
<style scoped>
  /*修改表头背景色*/
  .vxe-table--header-wrapper,
  .vxe-header--row,
  .vxe-table--header {
    background-color: #f0081b;
  }


  /*调整表格行高*/
  .vxe-table .vxe-body--column:not(.col--ellipsis),
  .vxe-table .vxe-footer--column:not(.col--ellipsis),
  .vxe-table .vxe-header--column:not(.col--ellipsis) {
    padding: 5px 0;
  }

  /*调整表格 单元格背景颜色*/
  .vxe-table .vxe-table--body-wrapper,
  .vxe-table .vxe-table--footer-wrapper {
    background-color: #1B2838;
  }

  /*调整表格文字及位置*/
  .vxe-table .vxe-body--column,
  .vxe-table .vxe-footer--column,
  .vxe-table .vxe-header--column {
    position: relative;
    line-height: 24px;
    text-align: center;
    color: #ffffff;
  }

  /*调整表头首行  line 的颜色*/
  .vxe-table .vxe-table--header-wrapper .vxe-table--header-border-line {
    position: absolute;
    left: 0;
    bottom: 0;
    height: 0;
    border-bottom: 1px solid #e8eaec;
  }

  .vxe-body--row.row--hover {
    background-color: rgba(255, 255, 255, 0.3) !important;
  }


  /*表格滚动条样式*/
  .vxe-table--body-wrapper::-webkit-scrollbar {
    width: 8px;
  }

  .vxe-table--body-wrapper::-webkit-scrollbar-thumb {
    border-radius: 5px;
    height: 50px;
    background-color: #5C6974 !important;
    border-radius: 30px !important;
  }

  .vxe-table--body-wrapper::-webkit-scrollbar-track {
    box-shadow: inset 0 0 5px rgba(0, 0, 0, 0.2);
    border-radius: 2px;
    background: rgba(0, 0, 0, 0.4);
  }


  .vxe-table.border--default .vxe-table--header-wrapper,
  .vxe-table.border--full .vxe-table--header-wrapper,
  .vxe-table.border--outer .vxe-table--header-wrapper {
    background-color: #113238;

  }

  /*有垂直 垂直下拉时  右上角处多出块状 背景色调整*/
  .vxe-table--header-wrapper {
    background-color: transparent !important;
  }
</style>