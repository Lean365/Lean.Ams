<template>
  <div class="home">
    <!-- 用户信息 -->
    <el-row :gutter="15">
      <el-col :md="24" :lg="18" :xl="24" class="mb10">
        <el-card shadow="hover" style="height: 100%">
          <div class="user-item">
            <div class="user-item-left">
              <el-avatar :size="60" shape="circle" :src="userInfo.avatar">
              </el-avatar>
            </div>

            <div class="user-item-right">
              <el-row>
                <el-col :xs="24" :md="24" class="right-title mb20 one-text-overflow">
                  {{WelcomeMessage}} <strong>{{ userInfo.nickName }}</strong>
                  <p>{{randomWelcomeContent}}</p>
                </el-col>
              </el-row>
              <el-row>
                <el-button icon="edit">
                  <router-link to="/user/profile">{{ $t('layout.headerPersonalModify') }}</router-link>
                </el-button>
              </el-row>
            </div>
          </div>
        </el-card>
      </el-col>
      <el-col :lg="6" class="mb10">
        <el-card style="height: 100%">
          <div class="text-information mb10">{{ $t('layout.dateLocalTimeZone') }}:CST UTC+8({{timezone}})
          </div>
          <div class="text-warning mb10">{{ $t('layout.loginNowTime') }}:{{nowTime}}
          </div>
          <div class="text-information mb10">{{ $t('layout.loginLastTime') }}{{ userInfo.loginDate }}</div>
          <div class="text-danger mb10">{{ $t('layout.loginDuration') }}:{{ onlineInfo.todayOnlineTime }}</div>
          <div class="text-information mb10">{{ $t('layout.loginPlatform') }}:{{ onlineInfo.clientNum }}</div>

        </el-card>
      </el-col>
    </el-row>

    <el-row :gutter="15">
      <el-col :md="24" :lg="24" :xl="24" class="mb10">
        <el-card>
          <template #header>
            <div>
              <el-icon>
                <DArrowRight />
              </el-icon>
              <h8>{{ $t('layout.shortCut') }}</h8>
            </div>
          </template>

          <el-row :gutter="24" type="flex">
            <el-col v-for="(card, key) in toolCards" :key="key" :span="2" :xs="8" @click="toTarget(card.name)">
              <el-card shadow="hover" style="cursor:pointer;text-align: center;">
                <div style=" height: 100%;border-radius: 50%;">
                  <div @click="navigateToPage( card.url)" :style="{ backgroundColor: card.bg  }"
                    style="border-radius: 50%;">
                    <el-icon :style="{ backgroundColor: card.bg  }"
                      style="height: 64px; width: 64px;border-radius: 50%;">
                      <component :is="card.icon" :style="{ color: card.color }"
                        style="height: 32px; width: 32px;border-radius: 50%;" />
                    </el-icon>
                  </div>

                  <br>{{ card.label }}
                </div>
              </el-card>
            </el-col>

          </el-row>

        </el-card>

      </el-col>
    </el-row>
    <panel-group @handleSetLineChartData="handleSetLineChartData" />

    <el-row :gutter="32">
      <el-col :xs="24" :sm="24" :lg="24">
        <div class="chart-wrapper">
          <line-chart :chart-data="lineChartData" :key="dataType" />
        </div>
      </el-col>
    </el-row>

    <el-row :gutter="32">
      <el-col :xs="24" :sm="24" :lg="8">
        <div class="chart-wrapper">
          <raddar-chart />
        </div>
      </el-col>
      <el-col :xs="24" :sm="24" :lg="8">
        <div class="chart-wrapper">
          <pie-chart />
        </div>
      </el-col>
      <el-col :xs="24" :sm="24" :lg="8">
        <div class="chart-wrapper">
          <bar-chart />
        </div>
      </el-col>
    </el-row>
    <!-- <el-row :gutter="32">
      <el-col :xs="24" :sm="24" :lg="24">
        <div class="chart-wrapper">
          <WordCloudChat :data="data.wordCloud" />
        </div>
      </el-col>
    </el-row> -->
  </div>
</template>

<script setup name="index">
  import PanelGroup from './dashboard/PanelGroup'
  import LineChart from './dashboard/LineChart'
  import RaddarChart from './dashboard/RaddarChart'
  import PieChart from './dashboard/PieChart'
  import BarChart from './dashboard/BarChart'
  // import WordCloudChat from './dashboard/WordCloud.vue'
  import CommonMenu from './components/CommonMenu'
  import moment from 'moment'
  import zonetime from 'moment-timezone'
  import dayjs from 'dayjs'
  // 时间插件
  import duration from 'dayjs/plugin/duration'
  dayjs.extend(duration)
  import "moment/dist/locale/zh-cn"
  import 'moment/dist/locale/zh-tw'
  import 'moment/dist/locale/ja'
  import useAppStore from '@/store/modules/app'
  import useUserStore from '@/store/modules/user'
  import useSocketStore from '@/store/modules/socket'
  import { getWeek } from '@/utils/ruoyi'

  const showEdit = ref(false)
  const data = {
    newVisitis: {
      expectedData: [100, 120, 161, 134, 105, 160, 165],
      actualData: [120, 82, 91, 154, 162, 140, 145]
    },
    messages: {
      expectedData: [200, 192, 120, 144, 160, 130, 140],
      actualData: [180, 160, 151, 106, 145, 150, 130]
    },
    purchases: {
      expectedData: [80, 100, 121, 104, 105, 90, 100],
      actualData: [120, 90, 100, 138, 142, 130, 130]
    },
    shoppings: {
      expectedData: [130, 140, 141, 142, 145, 150, 160],
      actualData: [120, 82, 91, 154, 162, 140, 130]
    }
  }
  const { proxy } = getCurrentInstance()
  const userInfo = computed(() => {
    return useUserStore().userInfo
  })
  const { userId, userName, loginDate } = userInfo;
  const lang = computed(() => {
    return useAppStore().lang
  })
  const onlineInfo = computed(() => {
    return useSocketStore().onlineInfo
  })
  const currentTime = computed(() => {
    return proxy.parseTime(new Date(), 'YYYY-MM-DD')
  })
  function workTimeFormatter(val) {
    return dayjs.duration(val * 60, 'second').format('HH时mm分')
  }
  const weekName = getWeek()
  const timezone = moment.tz.guess()
  const langselect = lang
  const nowTime = ref('')
  const toolCards = ref([
    {
      label: proxy.$t('menu.systemUser'),
      icon: 'Avatar',
      name: 'user',
      color: '#8491c3',
      bg: 'rgba(65,105,225,.3)',//皇家蓝
      url: 'system/user'
    },
    {
      label: proxy.$t('menu.systemRole'),//'',
      icon: 'setting',
      name: 'authority',
      color: '#8491c3',
      bg: 'rgba(100,149,237,.3)',//矢车菊的蓝色
      url: 'system/role'
    },
    {
      label: proxy.$t('menu.systemMenu'),//'',
      icon: 'menu',
      name: 'menu',
      color: '#4d5aaf',
      bg: 'rgba(176,196,222,.3)',//淡钢蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.logisticsSales'),//'',
      icon: 'ShoppingCartFull',
      name: 'about',
      color: '#4d4398',
      bg: 'rgba(135,206,235,.3)',//天蓝色
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.logisticsMaterials'),//'',
      icon: 'aim',
      name: 'about',
      color: '#5654a2',
      bg: 'rgba(0,191,255,.3)',//深天蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.accounting'),//'',,menu.accounting
      icon: 'Money',
      name: 'about',
      color: '#706caa',
      bg: 'rgba(173,216,230,.3)',//淡蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.logisticsProductionLaborhours'),//'',menu.production
      icon: 'Wallet',
      name: 'about',
      color: '#68699b',
      bg: 'rgba(176,224,230,.3)',//火药蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.logisticsQuality'),//'', 
      icon: 'Magnet',
      name: 'about',
      color: '#4d5aaf',
      bg: 'rgba(132, 145, 195,.3)',//紅掛空色
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.logisticsProductionEc'),//'', menu.ec
      icon: 'Grid',
      name: 'about',
      color: '#867ba9',
      bg: 'rgba(160, 216, 239,.3)',//【空色
      url: 'pp/ec'
    },

    {
      label: proxy.$t('menu.logisticsProductionOutput'),//'',menu.production
      icon: 'TakeawayBox',
      name: 'about',
      color: '#a59aca',
      bg: 'rgba(220, 214, 217,.3)',//薄梅鼠
      url: 'production/pp/output/ppoutputmaster'
    },
    {
      label: proxy.$t('menu.logisticsProductionDefective'),//'',menu.production
      icon: 'Operation',
      name: 'about',
      color: '#7058a3',
      bg: 'rgba(214, 236, 240,.3)',//月白
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.about'),//'',menu.production
      icon: 'HelpFilled',
      name: 'about',
      color: '#674598',
      bg: 'rgba(211, 224, 243,.3)',//淡青
      url: 'about'
    },



  ])
  // 使用 useRouter 获取路由实例
  const router = useRouter();
  // 声明组件局部状态和方法
  const navigateToPage = (page) => {
    // 使用路由实例的 push 方法进行页面导航
    router.push(page);
  }
  if (langselect.value === ("en")) {
    moment.locale('en'); // default the locale to English
    var localLocale = moment();
    localLocale.locale("en"); // set this instance to use French
    nowTime.value = localLocale.format('LLLL') // set this instance to use French

  } else if (langselect.value === ("zh-tw")) {
    moment.locale('en'); // default the locale to English
    var localLocale = moment();
    localLocale.locale("zh-tw"); // set this instance to use French
    nowTime.value = localLocale.format('LLLL') // set this instance to use French
  } else if (langselect.value === ("zh-cn")) {
    moment.locale('en'); // default the locale to English
    var localLocale = moment();
    localLocale.locale("zh-cn"); // set this instance to use French
    nowTime.value = localLocale.format('LLLL') // set this instance to use French
  } else if (langselect.value === ("ja")) {
    moment.locale('en'); // default the locale to English
    var localLocale = moment();
    localLocale.locale("ja"); // set this instance to use French
    nowTime.value = localLocale.format('LLLL') // set this instance to use French
  } else {
    moment.locale('en'); // default the locale to English
    var localLocale = moment();
    localLocale.locale("en"); // set this instance to use French
    nowTime.value = localLocale.format('LLLL') // set this instance to use French
  }

  const currentTimes = ref(new Date());

  onMounted(() => {

    setInterval(() => {
      currentTimes.value = new Date();
    }, 1000);
  });

  const WelcomeMessage = computed(() => {
    const hours = currentTimes.value.getHours();
    if (hours >= 0 && hours <= 10) {
      return '🌞 ' + proxy.$t('WelcomeMessage.Morning');
    } else if (hours > 10 && hours <= 11) {
      return '🌞 ' + proxy.$t('WelcomeMessage.Forenoon');
    } else if (hours > 11 && hours <= 13) {
      return '🌼 ' + proxy.$t('WelcomeMessage.Noon');
    } else if (hours > 13 && hours <= 18) {
      return '🌼 ' + proxy.$t('WelcomeMessage.Afternoon');
    } else if (hours > 18 && hours <= 24) {
      return '😴 ' + proxy.$t('WelcomeMessage.Night');
    }
  });

  const WelcomeContent = [
    proxy.$t('WelcomeContent.ContentA'),
    proxy.$t('WelcomeContent.ContentB'),
    proxy.$t('WelcomeContent.ContentC'),
    proxy.$t('WelcomeContent.ContentD'),
    proxy.$t('WelcomeContent.ContentE'),
    proxy.$t('WelcomeContent.ContentF'),
    proxy.$t('WelcomeContent.ContentG'),
    proxy.$t('WelcomeContent.ContentH'),
    proxy.$t('WelcomeContent.ContentI'),
    proxy.$t('WelcomeContent.ContentJ'),
    proxy.$t('WelcomeContent.ContentK'),
    proxy.$t('WelcomeContent.ContentL'),
    proxy.$t('WelcomeContent.ContentM'),
    proxy.$t('WelcomeContent.ContentN'),
    proxy.$t('WelcomeContent.ContentO'),
    proxy.$t('WelcomeContent.ContentP'),
    proxy.$t('WelcomeContent.ContentQ'),
    proxy.$t('WelcomeContent.ContentR'),
    proxy.$t('WelcomeContent.ContentS'),
    proxy.$t('WelcomeContent.ContentT'),
    proxy.$t('WelcomeContent.ContentU'),
    proxy.$t('WelcomeContent.ContentV'),
    proxy.$t('WelcomeContent.ContentW'),
    proxy.$t('WelcomeContent.ContentX'),
    proxy.$t('WelcomeContent.ContentY'),
    proxy.$t('WelcomeContent.ContentZ'),

  ];

  const randomIndex = ref(Math.floor(Math.random() * WelcomeContent.length));

  const randomWelcomeContent = computed(() => WelcomeContent[randomIndex.value]);
  let lineChartData = reactive([])
  const dataType = ref(null)
  function handleSetLineChartData(type) {
    dataType.value = type
    lineChartData = data[type]
  }
  handleSetLineChartData('newVisitis')

  function handleAdd() {
    proxy.$modal.msg('请通过搜索添加')
  }
  //getTimeState()
</script>

<style lang="scss" scoped>
  .home {
    .home-card-more {
      float: right;
      padding: 3px 0;
      font-size: 13px;
    }

    .user-item {
      // height: 198px;
      display: flex;
      align-items: center;

      .user-item-left {
        width: 60px;
        height: 60px;
        overflow: hidden;
        margin-right: 10px;
      }

      .user-item-right {
        flex: 1;

        .right-title {
          font-size: 20px;
        }
      }
    }

    .info {
      height: 200px;
      // overflow-y: scroll;
    }
  }

  .chart-wrapper {
    background: var(--base-bg-main);
    padding: 16px 16px 0;
    margin-bottom: 32px;
  }

  @media (max-width: 1024px) {
    .chart-wrapper {
      padding: 8px;
    }
  }
</style>