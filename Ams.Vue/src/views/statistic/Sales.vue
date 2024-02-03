<!--
 * @Descripttion: (oph主表/pp_output_master)
 * @Author: (Lean365)
 * @Date: (2024/1/6 10:53:01)
-->
<template>
  <div>
    <el-tabs v-model="activeName" @tab-click="handleClick">
      <el-tab-pane label="月度OPH" name="first" :lazy="true">
        <monthoutput />
        <!-- <monthoutputbar /> -->

      </el-tab-pane>
      <el-tab-pane label="月度OPH-班组" name="second" :lazy="true">
        <monthlineoutput />
        <!-- //<monthoutputlinebar /> -->
      </el-tab-pane>
      <el-tab-pane label="月度OPH-机种" name="third" :lazy="true">
        <monthmodeloutput />
      </el-tab-pane>
      <el-tab-pane label="年度OPH" name="fourth" :lazy="true">
        <yearoutput />
      </el-tab-pane>
      <el-tab-pane label="年度OPH-班组" name="fifthly" :lazy="true">
        <yearlineoutput />
      </el-tab-pane>
      <el-tab-pane label="年度OPH-机种" name="sixth" :lazy="true">
        <yearmodeloutput />
      </el-tab-pane>

    </el-tabs>

  </div>
</template>

<script setup name="Production">
  import statisticsec from './Ec.vue'
  import monthoutput from './MonthOutput.vue'
  import monthlineoutput from './MonthLineOutput.vue'
  import monthmodeloutput from './MonthModelOutput.vue'
  import yearoutput from './YearOutput.vue'
  import yearlineoutput from './YearLineOutput.vue'
  import yearmodeloutput from './YearModelOutput.vue'
  import monthlab from './Laborhours.vue'
  import monthdef from './Defective.vue'
  //import monthoutputbar from '/src/views/dashboard/OutputChat.vue'
  //import monthoutputlinebar from '/src/views/dashboard/OutputLineChat.vue'
  const { proxy } = getCurrentInstance()
  const activeName = ref('first')

  const handleClick = (tab, event) => {
    console.log(tab, event)
  }




</script>
<style>
  .card-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .text {
    font-size: 14px;
  }

  .item {
    margin-bottom: 18px;
  }

  .box-card {
    width: 480px;
  }
</style>