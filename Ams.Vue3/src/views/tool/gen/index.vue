<template>
  <div class="app-container">
    <el-form ref="codeform" inline :model="queryParams">
      <el-form-item :label="$t('gencode.tableName')" prop="tableName">
        <el-input v-model="queryParams.tableName" style="width: 200px" clearable
          :placeholder="$t('btn.enterPrefix')+$t('gencode.tableName')+$t('btn.enterSuffix')" />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="search" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{$t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>

    <el-row :gutter="10" class="mb10">
      <el-col :span="1.5">
        <el-button class="btn-import" plain icon="upload" @click="openImportTable"
          v-hasPermi="['tool:gen:import']">{{$t('btn.import')}}</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" plain icon="delete" @click="handleDelete"
          v-hasPermi="['tool:gen:remove']"> {{$t('btn.delete')}}</el-button>
      </el-col>
    </el-row>
    <el-table ref="gridtable" v-loading="tableloading" :data="tableList" border
      @selection-change="handleSelectionChange" highlight-current-row height="650px">
      <el-table-column type="selection" align="center" width="55"></el-table-column>
      <el-table-column prop="tableId" label="Id" width="80" sortable />
      <el-table-column prop="dbName" :label="$t('gencode.dbName')" width="90" :show-overflow-tooltip="true" />
      <el-table-column prop="tplCategory" :label="$t('gencode.tplCategory')" width="120" sortable />
      <el-table-column prop="tableName" :label="$t('gencode.tableName')" width="200" :show-overflow-tooltip="true" />
      <el-table-column prop="tableComment" :label="$t('gencode.tableComment')" :show-overflow-tooltip="true" />
      <el-table-column prop="className" :label="$t('gencode.className')" :show-overflow-tooltip="true" />
      <el-table-column prop="createTime" :label="$t('common.tipCreateTime')" sortable width="150">
        <template #default="scope"> {{ parseTime(scope.row.createTime, 'YYYY-MM-DD') }} </template>
      </el-table-column>
      <el-table-column prop="updateTime" :label="$t('common.tipUpdateTime')" sortable width="150">
        <template #default="scope"> {{ parseTime(scope.row.updateTime, 'YYYY-MM-DD') }} </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" width="200">
        <template #default="scope">
          <el-button-group>
            <el-button class="btn-view" size="small" plain icon="view" @click="handlePreview(scope.row)"
              v-hasPermi="['tool:gen:preview']" :title="$t('btn.view')">
            </el-button>
            <el-button type="success" size="small" plain icon="edit" @click="handleEditTable(scope.row)"
              v-hasPermi="['tool:gen:edit']" :title="$t('btn.edit')">
            </el-button>

            <el-dropdown @command="handleCommand($event, scope.row)">
              <el-button size="small" class="btn-more">
                <el-icon class="el-icon--right">
                  <arrow-down />
                </el-icon>
              </el-button>

              <template #dropdown>
                <el-dropdown-menu>
                  <div v-hasPermi="['tool:gen:code']">
                    <el-dropdown-item command="generate">
                      <el-button class="btn-generator" plain size="small" :title="$t('btn.generator')">
                        <svg-icon name="m-btn-code" />
                      </el-button>
                    </el-dropdown-item>
                  </div>
                  <div v-hasPermi="['tool:gen:edit']">
                    <el-dropdown-item command="sync">
                      <el-button class="btn-start" plain size="small" :title="$t('btn.synchronize')">
                        <svg-icon name="m-btn-sync" />
                      </el-button>
                    </el-dropdown-item>
                  </div>
                  <div v-hasPermi="['tool:gen:remove']">
                    <el-dropdown-item command="delete">
                      <el-button type="danger" plain size="small" :title="$t('btn.delete')"> <svg-icon
                          name="m-btn-trash" /></el-button>
                    </el-dropdown-item>
                  </div>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <pagination v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" v-model:total="total"
      @pagination="getList" />

    <!-- 预览界面 -->
    <zr-dialog v-model="preview.open" width="80%" top="5vh" append-to-body>
      <el-tabs v-model="preview.activeName">
        <el-tab-pane v-for="(item, key) in preview.data" :label="item.title" :id="key" :name="key.toString()"
          :key="key">
          {{ item.path }}
          <el-link :underline="false" icon="DocumentCopy" @click="onCopy(item.content)" class="btn-copy">复制 </el-link>
          <pre><code class="hljs" v-html="highlightedCode(item.content)"></code></pre>
        </el-tab-pane>
      </el-tabs>
    </zr-dialog>
    <import-table ref="importRef" @ok="getList" />
  </div>
</template>

<script setup name="gen">
  import '@/assets/styles/btn-custom.scss';
  import { codeGenerator, listTable, delTable, previewTable, synchDb } from '@/api/tool/gen'
  import { useRouter } from 'vue-router'
  import importTable from './importTable'
  import hljs from 'highlight.js'
  import 'highlight.js/styles/dark.css' // 这里有多个样式，自己可以根据需要切换
  import { useClipboard } from '@vueuse/core'
  const route = useRoute()
  const router = useRouter()
  const { proxy } = getCurrentInstance()

  const tableList = ref([])
  const tableloading = ref(true)
  const tableIds = ref([])
  const single = ref(true)
  const multiple = ref(true)
  const total = ref(0)
  const dateRange = ref([])
  const showGenerate = ref(false)
  // 选中行的表
  const currentSelected = ref({})

  const data = reactive({
    queryParams: {
      pageNum: 1,
      pageSize: 50,
      tableName: undefined,
      t: 0
    },
    preview: {
      open: false,
      title: proxy.$t('btn.view'),
      data: {},
      activeName: '0'
    }
  })

  const { queryParams, preview } = toRefs(data)
  watch(
    route,
    (val) => {
      if (val) {
        getList()
      }
    },
    {
      immediate: true
    }
  )
  /** 查询表集合 */
  function getList() {
    tableloading.value = true
    listTable(proxy.addDateRange(queryParams.value, dateRange.value)).then((response) => {
      tableList.value = response.data.result
      total.value = response.data.totalNum
      tableloading.value = false
    })
  }
  /** 搜索按钮操作 */
  function handleQuery() {
    queryParams.value.pageNum = 1
    getList()
  }
  /** 生成代码操作 */
  function handleGenTable(row) {
    currentSelected.value = row
    if (!currentSelected.value) {
      proxy.$modal.msgError(proxy.$t('gen.selecttable'))
      return false
    }
    proxy.$refs['codeform'].validate((valid) => {
      if (valid) {
        proxy.$modal.loading(proxy.$t('gen.Generatingcode'))

        codeGenerator({
          tableId: currentSelected.value.tableId,
          tableName: currentSelected.value.name,
          VueVersion: 3
        })
          .then(async (res) => {
            const { data } = res
            showGenerate.value = false
            if (row.genType === '1') {
              proxy.$modal.msgSuccess(proxy.$t('gen.Customizedpath'))
            } else {
              proxy.$modal.msgSuccess(proxy.$t('gen.Codegenerationcompleted'))
              // proxy.download(data.path)
              await proxy.downFile('/common/downloadFile', { path: data.path })
            }
          })
          .finally(() => {
            proxy.$modal.closeLoading()
          })
      } else {
        return false
      }
    })
  }
  /** 同步数据库操作 */
  function handleSynchDb(row) {
    const tableName = row.tableName
    proxy
      .$confirm(proxy.$t('gen.ForcedSync') + tableName + proxy.$t('gen.TableStructure'))
      .then(function () {
        return synchDb(row.tableId, { tableName, dbName: row.dbName })
      })
      .then(() => {
        proxy.$modal.msgSuccess(proxy.$t('common.tipSyncSucceed'))
      })
      .catch(() => { })
  }
  /** 打开导入表弹窗 */
  function openImportTable() {
    proxy.$refs['importRef'].show()
  }
  /** 预览按钮 */
  function handlePreview(row) {
    proxy.$refs['codeform'].validate((valid) => {
      if (!valid) {
        proxy.$modal.msgError(proxy.$t('gen.completetable'))
        return
      }
      proxy.$modal.loading(proxy.$t('common.tipWaitingfor'))
      previewTable(row.tableId, { VueVersion: 3 })
        .then((res) => {
          if (res.code === 200) {
            showGenerate.value = false
            preview.value.open = true
            preview.value.data = res.data
          }
        })
        .finally(() => {
          proxy.$modal.closeLoading()
        })
    })
  }
  // 多选框选中数据
  function handleSelectionChange(selection) {
    tableIds.value = selection.map((item) => item.tableId)
    multiple.value = !selection.length
  }
  /** 编辑表格 */
  function handleEditTable(row) {
    queryParams.value.tableName = row.tableName
    getList()

    router.push({
      path: '/gen/editTable',
      query: { tableId: row.tableId }
    })
  }
  /** 删除按钮操作 */
  function handleDelete(row) {
    const Ids = row.tableId || tableIds.value
    proxy
      .$confirm(proxy.$t('common.tipConfirmDel') + Ids + proxy.$t('common.tipConfirmDelDataitems'), proxy.$t('btn.delete') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.submit'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then(() => {
        delTable(Ids.toString()).then((res) => {
          if (res.code == 200) {
            proxy.$modal.msgSuccess(proxy.$t('common.tipDeleteSucceed'))

            handleQuery()
          }
        })
      })
      .catch(() => {
        proxy.$message({
          type: 'info',
          message: proxy.$t('common.tipCancelSucceed') + '<' + proxy.$t('btn.delete') + ' ' + proxy.$t('btn.operation') + '>'
        })
      })
  }
  /** 高亮显示 */
  function highlightedCode(code) {
    const result = hljs.highlightAuto(code || '')
    return result.value || '&nbsp;'
  }

  const { copy, isSupported } = useClipboard()
  function onCopy(input) {
    if (isSupported) {
      copy(input)
      proxy.$modal.msgSuccess(proxy.$t('common.tipCopySucceed'))
    } else {
      proxy.$modal.msgError(proxy.$t('layout.mybrowserNg'))
    }
  }
  function handleCommand(command, row) {
    switch (command) {
      case 'generate':
        handleGenTable(row)
        break
      case 'delete':
        handleDelete(row)
        break
      case 'sync':
        handleSynchDb(row)
        break
    }
  }
  function resetQuery() {
    proxy.resetForm('codeform')
    handleQuery()
  }
  getList()
</script>
<style>
  .btn-copy {
    position: absolute;
    right: 0;
    top: -5px;
  }

  .el-dropdown {
    vertical-align: middle;
  }
</style>