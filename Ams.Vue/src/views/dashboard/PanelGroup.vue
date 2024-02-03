<template>

  <el-row :gutter="5" class="panel-group">
    <el-col :xs="1" :sm="1" :lg="4" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('newVisitis')">
        <div class="card-panel-icon-wrapper icon-users">
          <svg-icon name="user-group" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.onlineUsers') }}</div>
          <div class="card-panel-num">
            <count-up :start-val="1" :loop="false" :end-val="state.onlineUserNum">
              <template #prefix>
                <svg-icon name="user" />
              </template></count-up>
          </div>
        </div>

      </div>
    </el-col>
    <el-col :xs="1" :sm="1" :lg="6" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('stockAmount')">
        <div class="card-panel-icon-wrapper icon-money">
          <svg-icon name="warehouse" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.costTotal') }}</div>
          <div class="card-panel-num">
            <count-up :start-val="1" :loop="false" :end-val="monthlycostTotalValue">
              <template #prefix>
                <svg-icon name="m-financial" />
              </template></count-up>
          </div>
          <el-statistic :value-style="{ color: 'red' }" :value="monthlycostTotalValue">
            <template #prefix>
              <svg-icon name="m-financial" />
            </template>
          </el-statistic>
        </div>

        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.stockAmount') }}</div>
          <el-statistic class="card-panel-num" :value="monthlystockAmountValue" />
        </div>
      </div>
    </el-col>
    <el-col :xs="1" :sm="1" :lg="6" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('Shipment')">
        <div class="card-panel-icon-wrapper icon-shipment">
          <svg-icon name="tags" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.Shipment') }}</div>
          <div class="card-panel-num">
            <count-up :start-val="100" :loop="false" :end-val="monthlyShipmentQty">
              <svg-icon name="cubes-stacked" class-name="card-panel-icon" /> <template #prefix>
                <el-icon style="vertical-align: -0.125em">
                  <svg-icon name="m-oph" />
                </el-icon>
              </template></count-up>
          </div>
        </div>

        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.salesAmount') }}</div>
          <div class="card-panel-num">
            <count-up :start-val="100" :loop="false" :end-val="monthlySalesAmount">
              <template #prefix>
                <el-icon style="vertical-align: -0.125em">
                  <svg-icon name="m-financial" />
                </el-icon>
              </template></count-up>
          </div>
        </div>
      </div>
    </el-col>
    <el-col :xs="1" :sm="1" :lg="8" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('production')">
        <div class="card-panel-icon-wrapper icon-cubes">
          <svg-icon name="cubes-stacked" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.PoorProduction') }}</div>
          <el-statistic class="card-panel-num" :value="monthlyPoorProductionQtyValue" />


        </div>
        <div class="card-panel-description">

          <div class="card-panel-text" v-waves>{{ $t('layout.production') }}</div>
          <el-statistic :value-style="{ color: 'red' }" :value="monthlyproductionQtyValue">
            <template #prefix>
              <el-icon style="vertical-align: -0.125em">
                <House />
              </el-icon>
            </template>

          </el-statistic>
          <div class="card-panel-num">
            <count-up :start-val="100" :loop="false" :end-val="monthlyproductionQtyValue"><svg-icon name="cubes-stacked"
                class-name="card-panel-icon" /> <template #prefix>
                <el-icon style="vertical-align: -0.125em">
                  <House />
                </el-icon>
              </template></count-up>

          </div>

        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.ecCount') }}</div>
          <div id="ecCount" class="card-panel-num">{{ state.ecCount }}</div>
          <el-statistic class="card-panel-num" :value="monthlyecCountQtyValue" />
        </div>
      </div>
    </el-col>

  </el-row>
</template>
<script setup>
  import { useTransition } from '@vueuse/core'
  import CountUp from 'vue-countup-v3'
  import useSocketStore from '@/store/modules/socket';
  import {
    GetMonthlyProductionQty
  }
    from '@/api/statistics/output.js'

  import {
    getCurrentMonthlySales
  }
    from '@/api/statistics/sales.js'
  const emit = defineEmits()
  const { proxy } = getCurrentInstance()

  const state = reactive({
    onlineNum: computed(() => {
      return useSocketStore().onlineNum
    }),
  })
  onMounted(() => {
    getMonthlyProductionQtyList()
    getCurrentMonthlySalesList()
  })
  // onMounted(() => {
  //   new CountUp('onlineNum', state.onlineNum).start()
  // })
  //当月生产台数
  const monthlyproductionQty = ref(0)
  // const monthlyproductionQtyValue = useTransition(monthlyproductionQty, {
  //   duration: 1500,
  // })
  getMonthlyProductionQtyList()
  const monthQty = ref(0);
  function getMonthlyProductionQtyList() {
    return new Promise((resolve, reject) => {
      GetMonthlyProductionQty()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {
            console.log('生产', data)
            monthQty.value = data
            monthlyproductionQty.value = data
            //state.production = res.data

            resolve(res)
          }
        })
    })
  }

  //当月销售额
  const monthlySalesAmount = ref(0)


  function getCurrentMonthlySalesList() {
    return new Promise((resolve, reject) => {
      getCurrentMonthlySales()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {

            //monthQty.value = data
            const arr = data.split(",");
            monthlySalesAmount.value = (parseFloat(arr[1]) / 10000).toFixed(0)

            monthlyShipmentQty.value = (parseFloat(arr[0])).toFixed(0)
            //state.production = res.data
            console.log('数组销售：', arr[0], '销售：', monthlySalesAmount.value)
            resolve(res)
          }
        })
    })
  }

  //当月销售额
  const monthlyShipmentQty = ref(0)



  //当月不良件数
  const monthlyPoorProductionQty = ref(0)

  monthlyPoorProductionQty.value = 139
  //当月设变件数
  const monthlyecCountQty = ref(0)

  monthlyecCountQty.value = 69

  //当月在库金额
  const monthlystockAmount = ref(0)

  monthlystockAmount.value = 5612

  //当月成本金额
  const monthlycostTotal = ref(0)
  // const monthlycostTotalValue = useTransition(monthlycostTotal, {
  //   duration: 1000,
  // })
  monthlycostTotal.value = 235

  function handleSetLineChartData(type) {
    emit('handleSetLineChartData', type)
  }

</script>

<style lang="scss" scoped>
  .panel-group {
    margin-top: 18px;

    .card-panel-col {
      margin-bottom: 32px;
    }

    .card-panel {
      height: 108px;
      cursor: pointer;
      font-size: 12px;
      position: relative;
      overflow: hidden;
      color: #666;
      background: var(--base-bg-main);
      box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.05);
      border-color: rgba(0, 0, 0, 0.05);

      &:hover {
        .card-panel-icon-wrapper {
          color: #fff;
        }

        .icon-users {
          background: #33cc99;
        }

        .icon-shipment {
          background: #339933;
        }

        .icon-money {
          background: #f4516c;
        }

        .icon-cubes {
          background: #003366;
        }
      }

      .icon-users {
        color: #33cc99;
      }

      .icon-shipment {
        color: #339933;
      }

      .icon-money {
        color: #f4516c;
      }

      .icon-cubes {
        color: #003366;
      }



      .card-panel-icon-wrapper {
        float: left;
        margin: 14px 0 0 14px;
        padding: 16px;
        transition: all 0.38s ease-out;
        border-radius: 6px;
      }

      .card-panel-icon {
        float: left;
        font-size: 48px;
      }

      .card-panel-description {
        float: right;
        font-weight: bold;
        margin: 26px;
        margin-left: 0px;

        .card-panel-text {
          line-height: 18px;
          color: var(--base-color-white);
          font-size: 16px;
          margin-bottom: 12px;
        }

        .card-panel-num {
          font-size: 20px;
          /* color: #00e4ff(--base-color-white); */
          color: #003366;
        }
      }
    }
  }

  @media (max-width: 550px) {
    .card-panel-description {
      display: none;
    }

    .card-panel-icon-wrapper {
      float: none !important;
      width: 100%;
      height: 100%;
      margin: 0 !important;

      .svg-icon {
        display: block;
        margin: 14px auto !important;
        float: none !important;
      }
    }
  }
</style>