<template>
  <el-dialog :title="title" v-model="open" width="720px" append-to-body>
    <el-form ref="menuRef" :model="form" :rules="rules" label-width="auto">
      <el-row>
        <el-col :lg="24">
          <el-form-item :label="$t('pmenu.parentMenu')">
            <el-cascader class="w100" :options="menuOptions"
              :props="{ checkStrictly: true, value: 'menuId', label: 'menuName', emitPath: false }"
              :placeholder="$t('btn.selectPrefix')+$t('pmenu.parentMenu')+$t('btn.selectSuffix')" clearable
              v-model="form.parentId">
              <template #default="{ node, data }">
                <span>{{ data.menuName }}</span>
                <span v-if="!node.isLeaf"> ({{ data.children.length }}) </span>
              </template>
            </el-cascader>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pmenu.menuType')" prop="menuType">
            <el-radio-group v-model="form.menuType">
              <el-radio-button value="M">{{ $t('pmenu.directory') }}M</el-radio-button>
              <el-radio-button value="C">{{ $t('pmenu.menu') }}C</el-radio-button>
              <el-radio-button value="F">{{ $t('pmenu.button') }}F</el-radio-button>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pmenu.menuName')" prop="menuName">
            <el-input v-model="form.menuName"
              :placeholder="$t('btn.enterPrefix')+$t('pmenu.menuName')+$t('btn.enterSuffix')" />
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pmenu.menuNameKey')" prop="menuNameKey">
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.menuNameKeymemo')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('pmenu.menuNameKey') }}
              </span>
            </template>
            <el-input v-model="form.menuNameKey"
              :placeholder="$t('btn.enterPrefix')+$t('pmenu.menuName')+$t('btn.enterSuffix')">
              <template #prepend>
                <span style="width: 30px">menu.</span>
              </template>
            </el-input>
          </el-form-item>
        </el-col>
        <el-col :lg="24" v-if="form.menuType != 'F'">
          <el-form-item :label="$t('pmenu.icon')" prop="icon">
            <el-popover placement="bottom-start" :width="540" trigger="click">
              <template #reference>
                <el-input v-model="form.icon"
                  :placeholder="$t('btn.selectPrefix')+$t('pmenu.icon')+$t('btn.selectSuffix')" readonly>
                  <template #prefix>
                    <svg-icon v-if="form.icon" :name="form.icon" />
                    <el-icon v-else>
                      <search />
                    </el-icon>
                  </template>
                </el-input>
              </template>
              <icon-select ref="iconSelectRef" @selected="selected" />
            </el-popover>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item :label="$t('pmenu.sort')" prop="sortingNum">
            <el-input-number v-model="form.sortingNum" controls-position="right" :min="0" />
          </el-form-item>
        </el-col>
        <el-col :lg="24" v-if="form.menuType != 'F'">
          <el-form-item prop="path">
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.routePathmemo')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('pmenu.routePath') }}
              </span>
            </template>
            <el-input v-model="form.path"
              :placeholder="$t('btn.enterPrefix')+$t('pmenu.routePath')+$t('btn.enterSuffix')" />
          </el-form-item>
        </el-col>
        <el-col :lg="24" v-if="form.menuType != 'F'">
          <el-form-item prop="component">
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.componentPathmemo')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('pmenu.componentPath') }}
              </span>
            </template>
            <el-input v-model="form.component"
              :placeholder="$t('btn.enterPrefix')+$t('pmenu.componentPath')+$t('btn.enterSuffix')">
              <template #prepend>
                <span style="width: 50px">src/views/</span>
              </template>
            </el-input>
          </el-form-item>
        </el-col>
        <el-col :lg="24">
          <el-form-item>
            <el-input v-model="form.perms"
              :placeholder="$t('btn.enterPrefix')+$t('pmenu.permissionStr')+$t('btn.enterSuffix')" maxlength="100" />
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.permissionStrmemo')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('pmenu.permissionStr') }}
              </span>
            </template>
          </el-form-item>
        </el-col>
        <!-- <el-col :lg="12" v-if="form.menuType == 'C'">
            <el-form-item>
              <el-input v-model="form.query" placeholder="请输入路由参数" maxlength="255" />
              <template #label>
                <el-tooltip content='访问路由的默认传递参数，如：`{"id": 1, "name": "ry"}`' placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                路由参数
              </template>
            </el-form-item>
          </el-col> -->

        <el-col :lg="24" v-if="form.menuType != 'F'">
          <el-form-item>
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.linkMemo')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('pmenu.isFrame') }}
              </span>
            </template>
            <el-radio-group v-model="form.isFrame">
              <el-radio value="0">{{ $t('common.no') }}</el-radio>
              <el-radio value="1">{{ $t('common.yes') }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24" v-if="form.menuType == 'C'">
          <el-form-item prop="isCache">
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.isCachememo')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('pmenu.isCache') }}
              </span>
            </template>
            <!-- <el-radio-group v-model="form.isCache">
                <el-radio value="0">{{ $t('common.yes') }}</el-radio>
                <el-radio value="1">{{ $t('common.no') }}</el-radio>
              </el-radio-group> -->
            <el-switch v-model="form.isCache" active-value="0" inactive-value="1"></el-switch>
          </el-form-item>
        </el-col>
        <el-col :lg="24" v-if="form.menuType != 'F'">
          <el-form-item prop="visible">
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.isShowmemo')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('pmenu.isShow') }}
              </span>
            </template>
            <el-radio-group v-model="form.visible">
              <el-radio v-for="dict in options.sys_menu_show" :key="dict.dictValue" :value="dict.dictValue">{{
                dict.dictLabel }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :lg="24" v-if="form.menuType != 'F'">
          <el-form-item>
            <template #label>
              <span>
                <el-tooltip :content="$t('pmenu.menuIsStatedTip')" placement="top">
                  <el-icon :size="15">
                    <questionFilled />
                  </el-icon>
                </el-tooltip>
                {{ $t('common.tipIsStated') }}
              </span>
            </template>
            <el-radio-group v-model="form.isStatus">
              <el-radio v-for="dict in options.sys_normal_disable" :key="dict.dictValue"
                :value="parseInt(dict.dictValue)">{{ dict.dictLabel }}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <template #footer>
      <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
      <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
    </template>
  </el-dialog>
</template>
<script setup>
  import { addMenu, getMenu, updateMenu } from '@/api/system/menu'
  import IconSelect from '@/components/IconSelect'
  const { proxy } = getCurrentInstance()
  const emit = defineEmits()
  const iconSelectRef = ref(null)
  const open = ref(false)
  const title = ref('')
  const menuRef = ref(null)

  const props = defineProps({
    options: {},
    menuOptions: {}
  })
  const state = reactive({
    form: {},
    rules: {
      menuName: [{ required: true, message: proxy.$t('pmenu.menuName') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      menuNameKey: [{ pattern: /^[A-Za-z].+$/, message: proxy.$t('common.tipInputLangKeyError'), trigger: 'blur' }],
      sortingNum: [{ required: true, message: proxy.$t('pmenu.sort') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
      path: [
        { required: false, message: proxy.$t('pmenu.routePath') + proxy.$t('btn.isEmpty'), trigger: 'blur' },
        { pattern: /^[/A-Za-z].+$/, message: proxy.$t('common.tipInputLetterStart'), trigger: 'blur' }
      ],
      visible: [{ required: true, message: proxy.$t('pmenu.isShow') + proxy.$t('btn.isEmpty'), trigger: 'blur' }]
    },
    sys_menu_show: [],
    sys_normal_disable: []
  })
  const { form, rules } = toRefs(state)

  /** 取消按钮 */
  function cancel() {
    open.value = false
    reset()
  }
  /** 表单重置 */
  function reset() {
    form.value = {
      menuId: undefined,
      parentId: 0,
      menuName: undefined,
      icon: undefined,
      menuType: 'M',
      sortingNum: 999,
      isFrame: '0',
      isCache: '0',
      visible: '0',
      isStatus: 0
    }
    proxy.resetForm('menuRef')
  }

  /** 选择图标 */
  function selected(name) {
    form.value.icon = name
  }
  /** 新增按钮操作 */
  function handleAdd(row) {
    reset()
    if (row != null && row.menuId != undefined) {
      form.value.parentId = row.menuId
    } else {
      form.value.parentId = 0
    }
    open.value = true
    title.value = proxy.$t('btn.add')
  }
  /** 修改按钮操作 */
  async function handleUpdate(row) {
    reset()
    getMenu(row.menuId).then((response) => {
      form.value = response.data
      open.value = true
      title.value = proxy.$t('btn.edit')
    })
  }
  /** 提交按钮 */
  function submitForm() {
    proxy.$refs['menuRef'].validate((valid) => {
      if (valid) {
        if (form.value.menuId != undefined) {
          updateMenu(form.value).then(() => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipEditSucceed'))
            open.value = false

            emit('success', form.value.parentId)
            // refreshMenu(form.value.parentId)
          })
        } else {
          addMenu(form.value).then(() => {
            proxy.$modal.msgSuccess(proxy.$t('common.tipAddSucceed'))
            open.value = false
            // refreshMenu(form.value.parentId)
            emit('success', form.value.parentId)
          })
        }
      }
    })
  }

  defineExpose({
    handleAdd,
    handleUpdate
  })
</script>