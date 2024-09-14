<template>
  <el-row :gutter="40" class="panel-group">
    <!-- <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('newVisitis')">
        <div class="card-panel-icon-wrapper icon-users">
          <i class="fas fa-users fa-beat-fade"
            style="--fa-animation-duration: 3s;font-size: 3em; color: rgb(245, 164, 6);"></i>
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.loginOnlineUsers') }}</div>
          <div id="onlineNum" class="card-panel-num">{{ state.onlineUserNum }}</div>
        </div>
      </div>
    </el-col> -->
    <el-col :xs="12" :sm="12" :lg="8" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('stockAmount')">
        <div class="card-panel-icon-wrapper icon-money">
          <i class="fas fa-warehouse fa-beat"
            style="--fa-animation-duration: 3s;font-size: 3em; color: rgb(23, 2, 82);"></i>
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.echartCostTotal') }}</div>
          <div id="costTotal" class="card-panel-num">{{ state.costTotal }}</div>
          <el-statistic :value="monthlyProductionCostValue" />


        </div>

        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.echartStockAmount') }}</div>
          <!-- <div class="card-panel-num" id="stockAmount">{{ state.stockAmount }}</div> -->
          <el-statistic :value="monthlyInventoryAmountValue" />


        </div>
      </div>
    </el-col>
    <el-col :xs="12" :sm="12" :lg="8" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('salesAmount')">
        <div class="card-panel-icon-wrapper icon-shipment">
          <i class="fas fa-shop fa-flip"
            style="--fa-animation-duration: 3s;font-size: 3em; color: rgb(129, 6, 245);"></i>
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.echartShipment') }}</div>
          <!-- <div id="Shipment" class="card-panel-num">{{ state.shipment }}</div> -->
          <el-statistic :value="monthlySalesQtyValue" />

        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.echartSalesAmount') }}</div>
          <!-- <div class="card-panel-num" id="salesAmount">{{ state.salesAmount }}</div> -->
          <el-statistic :value="monthlySalesAmountalue" />

        </div>
      </div>
    </el-col>
    <el-col :xs="12" :sm="12" :lg="8" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('production')">
        <div class="card-panel-icon-wrapper icon-cubes">
          <i class="fas fa-microchip fa-bounce"
            style="--fa-animation-duration: 3s;font-size: 3em; color: rgb(2, 65, 23);"></i>
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.echartPoorProduction') }}</div>
          <!-- <div id="PoorProduction" class="card-panel-num">{{ state.poorProduction }}</div> -->
          <el-statistic :value="monthlyproductionQtyValue" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.echartProduction') }}</div>
          <!-- <div id="production" class="card-panel-num">{{ state.production }}</div> -->
          <el-statistic :value="monthlyproductionQtyValue" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.echartEcCount') }}</div>
          <!-- <div id="ecCount" class="card-panel-num">{{ state.ecCount }}</div> -->
          <el-statistic :value="EcCountValue" />

          <!-- <ICountUp :delay="1000" :endVal="EcCountValue" /> -->

        </div>
      </div>
    </el-col>


  </el-row>

</template>

<script setup>
  import { CountUp } from 'countup.js'
  import ICountUp from 'vue-countup-v3';
  import useSocketStore from '@/store/modules/socket';
  import '@fortawesome/fontawesome-free/css/all.min.css';
  //后台操作函数
  import {
    getEcCount,
  }
    from '@/api/statistics/ppecstati.js'
  import {
    getMonthlyOutputQty,
  }
    from '@/api/statistics/ppoutputstati.js'
  import {
    getMonthlySalesQty,
    getMonthlySalesAmount,
  }
    from '@/api/statistics/sdsalesstati.js'
  import {
    getMonthlyInventoryAmount,
  }
    from '@/api/statistics/ficoinventorystati.js'
  import {
    getMonthlyProdCost,
  }
    from '@/api/statistics/ficocomparisonstati.js'
  import { useTransition } from '@vueuse/core'
  const emit = defineEmits()
  const { proxy } = getCurrentInstance()
  onMounted(() => {
    getTotalEc()
    getTotalMonthlyOutputQty()
    getTotalMonthlySalesQty()
    getTotalMonthlySalesAmount()
    getTotalMonthlyInventoryAmount()
    getTotalMonthlyProdCost()
  })
  //ec点数统计
  const ecCount = ref(0)
  // const monthlyproductionQtyValue = useTransition(monthlyproductionQty, {
  //   duration: 1500,
  // })
  const EcCountValue = useTransition(ecCount, {
    duration: 1500,
  })
  // const monthQty = ref(0);
  function getTotalEc() {
    return new Promise((resolve, reject) => {
      getEcCount()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {
            console.log('EC数据:', data)
            ecCount.value = data
            //monthlyproductionQty.value = data
            //state.production = res.data

            resolve(res)
          }
        })
    })
  }
  //月度OPH统计
  const monthlyproductionQty = ref(0)

  const monthlyproductionQtyValue = useTransition(monthlyproductionQty, {
    duration: 1500,
  })
  function getTotalMonthlyOutputQty() {
    return new Promise((resolve, reject) => {
      getMonthlyOutputQty()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {
            console.log('Output数据:', data)
            monthlyproductionQty.value = data
            //monthlyproductionQty.value = data
            //state.production = res.data

            resolve(res)
          }
        })
    })
  }
  //月度销量统计
  const monthlySalesQty = ref(0)
  //console.log('月度销量', monthlySalesQty.value)
  const monthlySalesQtyValue = useTransition(monthlySalesQty, {
    duration: 1500,
  })
  function getTotalMonthlySalesQty() {
    return new Promise((resolve, reject) => {
      getMonthlySalesQty()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {
            console.log('月度销量:', data)
            monthlySalesQty.value = data
            //monthlyproductionQty.value = data
            //state.production = res.data

            resolve(res)
          }
        })
    })
  }
  const monthlySalesAmount = ref(0)
  //console.log('月度销售', monthlySalesAmount.value)
  const monthlySalesAmountalue = useTransition(monthlySalesAmount, {
    duration: 1500,
  })
  function getTotalMonthlySalesAmount() {
    return new Promise((resolve, reject) => {
      getMonthlySalesAmount()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {
            console.log('月度销售:', data)
            monthlySalesAmount.value = data
            //monthlyproductionQty.value = data
            //state.production = res.data

            resolve(res)
          }
        })
    })
  }
  //月度存货统计
  const monthlyInventoryAmount = ref(0)
  console.log('月度存货', monthlySalesQty.value)
  const monthlyInventoryAmountValue = useTransition(monthlyInventoryAmount, {
    duration: 1500,
  })
  function getTotalMonthlyInventoryAmount() {
    return new Promise((resolve, reject) => {
      getMonthlyInventoryAmount()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {
            console.log('月度存货:', data)
            monthlyInventoryAmount.value = data
            //monthlyproductionQty.value = data
            //state.production = res.data

            resolve(res)
          }
        })
    })
  }
  //月度成本统计
  const monthlyProductionCost = ref(0)
  //console.log('月度存货', monthlySalesQty.value)
  const monthlyProductionCostValue = useTransition(monthlyProductionCost, {
    duration: 1500,
  })
  function getTotalMonthlyProdCost() {
    return new Promise((resolve, reject) => {
      getMonthlyProdCost()
        .then((res) => {
          //
          const { code, data } = res
          if (code == 200) {
            console.log('月度生产成本:', data)
            monthlyProductionCost.value = data
            //monthlyproductionQty.value = data
            //state.production = res.data

            resolve(res)
          }
        })
    })
  }
  const state = reactive({
    onlineNum: computed(() => {
      return useSocketStore().onlineNum
    }),

    //stockAmount: ecCounts,
    //shipment: ecCounts,
    //ecCount: ecCounts,
    //production: ecCounts,
    //salesAmount: ecCounts,
    //poorProduction: ecCounts,
    //costTotal: ecCounts,
  })


  onMounted(() => {
    //getEcTotalCount(),
    // new CountUp('stockAmount', state.stockAmount).start(),
    new CountUp('onlineNum', state.onlineNum).start()
    // new CountUp('Shipment', state.Shipment).start(),
    // //new CountUp('ecCount', ecCounts.value).start(),
    // //new CountUp('production', state.production).start(),
    // new CountUp('salesAmount', state.salesAmount).start(),
    // new CountUp('PoorProduction', state.PoorProduction).start(),
    // new CountUp('costTotal', state.costTotal).start()
  })
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
      box-shadow: 4px 4px 40px rgba(0, 0, 0, 0.05);
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
          color: var(--base-color-white);
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