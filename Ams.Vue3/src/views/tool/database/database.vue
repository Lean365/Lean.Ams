<template>
  <div>
    <!-- 添加或修改银行对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open">
      <el-form ref="formRef" :model="form" :rules="rules" label-width="auto">
        <el-steps :active="activeStep">
          <el-step title="第一步"></el-step>
          <el-step title="第二步"></el-step>
        </el-steps>
        <div v-if="activeStep === 0">
          <el-col :lg="12">
            <el-form-item :label="$t('gencode.dbName')" prop="dbName">
              <el-select filterable clearable v-model="dbName"
                :placeholder="$t('btn.selectPrefix')+$t('gencode.dbName')+$t('btn.selectSuffix')">
                <el-option v-for="item in dbList" :key="item" :label="item" :value="item" />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="表名" prop="tableName">
              <el-input v-model="tableName" :placeholder="$t('btn.enterPrefix')+'表名'+$t('btn.enterSuffix')"
                show-word-limit maxlength="40" @input="validateStep" />
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="描述" prop="tableText">
              <el-input v-model="tableText" :placeholder="$t('btn.enterPrefix')+'描述'+$t('btn.enterSuffix')"
                show-word-limit maxlength="40" @input="validateStep" />
            </el-form-item>
          </el-col>

        </div>

        <div v-if="activeStep === 1">
          <el-table :data="tableData">
            <el-table-column prop="name" label="名称"></el-table-column>
            <el-table-column prop="age" label="年龄"></el-table-column>
          </el-table>
        </div>

        <el-button :disabled="!isStepValid" @click="nextStep">下一步</el-button>



      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" :disabled="!isStepValid" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="newtable">
  import '@/assets/styles/btn-custom.scss'
  //后台操作函数
  import { listDbTable, codeGetDBList, importTable } from '@/api/tool/gen'


  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  const activeStep = ref(0);
  const dbName = ref('');
  const tableName = ref('2');
  const tableText = ref('3');
  const tableData = ref([{ name: '张三', age: 25 }, { name: '李四', age: 30 }]);

  const isStepValid = computed(() => {
    return dbName.value && tableText.value && tableText.value;
  });

  function validateStep() {
    // 这里可以添加更多的验证逻辑
  }

  function nextStep() {
    if (isStepValid.value) {
      activeStep.value++;
    }
  }
  /** 查询表数据 */
  function getDbList() {
    codeGetDBList().then((res) => {
      dbList.value = res.data.dbList
      console.log(dbList.value)
    })

  }
  function handleTableQuery() {
    getTableList()
  }
  function getTableList() {
    if (queryParams.dbName !== '') {
      listDbTable(queryParams).then((res) => {
        dbTableList.value = res.data.result.map(item => ({ dictLabel: item.description, dictValue: item.name }))
        console.log(dbTableList.value)
      })
    }
  }

  /** 打开导入表弹窗 */

</script>