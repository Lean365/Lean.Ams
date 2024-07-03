<template>
  <el-form ref="basicInfoForm" :model="info" :rules="rules" label-width="100px">
    <el-row>
      <el-col :lg="6">
        <el-form-item :label="$t('gencode.tableName')" prop="tableName">
          <el-input :placeholder="$t('btn.enterPrefix')+$t('gencode.tableName')+$t('btn.enterSuffix')"
            v-model="info.tableName" />
        </el-form-item>
      </el-col>
      <el-col :lg="6">
        <el-form-item :label="$t('gencode.tableComment')" prop="tableComment">
          <el-input :placeholder="$t('btn.enterPrefix')+$t('gencode.tableComment')+$t('btn.enterSuffix')"
            v-model="info.tableComment" />
        </el-form-item>
      </el-col>

      <el-col :lg="6">
        <el-form-item :label="$t('gencode.className')" prop="className">
          <el-input :placeholder="$t('btn.enterPrefix')+$t('gencode.className')+$t('btn.enterSuffix')"
            v-model="info.className" />
        </el-form-item>
      </el-col>
      <el-col :lg="6">
        <el-form-item :label="$t('gencode.functionAuthor')" prop="functionAuthor">
          <el-input :placeholder="$t('btn.enterPrefix')+$t('gencode.functionAuthor')+$t('btn.enterSuffix')"
            v-model="info.functionAuthor" />
        </el-form-item>
      </el-col>
      <el-col :lg="24">
        <el-form-item :label="$t('common.tipRemarks')" prop="remark">
          <el-input type="textarea" :rows="3" v-model="info.remark"></el-input>
        </el-form-item>
      </el-col>
    </el-row>
  </el-form>
</template>
<script setup name="BasicInfoForm">
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  const props = defineProps({
    info: {
      type: Object,
      default: null,
    },
  })
  const rules = reactive({
    tableName: [{ required: true, message: proxy.$t('gencode.tableName') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
    tableComment: [{ required: true, message: proxy.$t('gencode.tableComment') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
    className: [{ required: true, message: proxy.$t('gencode.className') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
    functionAuthor: [{ required: true, message: proxy.$t('gencode.functionAuthor') + proxy.$t('btn.isEmpty'), trigger: 'blur' }],
  })
</script>