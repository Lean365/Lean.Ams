<template>
  <div class="app-container">
    <el-form :model="queryParams" ref="queryRef" :inline="true">
      <el-form-item>
        <el-button plain type="primary" @click="onLockAll()" icon="lock"
          v-hasPermi="['monitor:online:forceLogout']">{{$t('btn.accountForcedAll')}}</el-button>
      </el-form-item>
      <el-form-item>
        <el-radio-group v-model="viewSwitch" fill="#e16c96">
          <el-radio-button value="1">{{$t('btn.grid')}}</el-radio-button>
          <el-radio-button value="2">{{$t('btn.card')}}</el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="Search" @click="handleQuery">{{$t('btn.refresh')}}</el-button>
      </el-form-item>
    </el-form>
    <el-table :data="onlineUsers" v-loading="loading" ref="tableRef" border highlight-current-row
      v-if="viewSwitch == 1">
      <el-table-column label="No" type="index" width="50" align="center">
        <template #default="scope">
          <span>{{ (queryParams.pageNum - 1) * queryParams.pageSize + scope.$index + 1 }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="name" :label="$t('ploginlog.userName')" align="center" />
      <el-table-column :label="$t('psms.location')" prop="location" align="center"> </el-table-column>
      <el-table-column :label="$t('ploginlog.ipaddr')" prop="userIP" align="center"></el-table-column>
      <el-table-column prop="browser" :label="$t('ploginlog.browser')" width="210"></el-table-column>
      <el-table-column prop="platform" :label="$t('ploginlog.platform')" align="center"></el-table-column>
      <el-table-column prop="loginTime" :label="$t('ploginlog.loginTime')" witdh="280px">
        <template #default="scope">
          {{ dayjs(scope.row.loginTime).format('MM/DD日HH:mm:ss') }}
          <div>{{$t('ploginlog.duration')}}{{ scope.row.onlineTime }}{{$t('ploginlog.minutes')}}</div>
        </template>
      </el-table-column>
      <el-table-column :label="$t('btn.operation')" align="center" width="160">
        <template #default="scope">
          <el-button plain size="small" type="primary" @click="onChat(scope.row)" icon="ChatDotRound"
            v-hasRole="['admin']" :title="$t('btn.privateChat')"></el-button>
          <el-button plain size="small" type="warning" @click="onLock(scope.row)" icon="lock"
            v-hasPermi="['monitor:online:forceLogout']" :title="$t('btn.accountForced')"></el-button>
        </template>
      </el-table-column>
    </el-table>

    <el-row :gutter="20" v-if="viewSwitch == 2">
      <el-col v-for="item in onlineUsers" :lg="4" :span="24">
        <el-card :body-style="{ padding: '15px 15px 0' }">
          <el-descriptions :column="1" :title="item.name">
            <el-descriptions-item :label="$t('ploginlog.platform')">{{ item.platform }}</el-descriptions-item>
            <el-descriptions-item :label="$t('psms.location')">{{ item.location }}</el-descriptions-item>
            <el-descriptions-item :label="$t('ploginlog.duration')" :span="2">
              <el-tag type="success">{{ item.onlineTime }}{{$t('ploginlog.minutes')}}</el-tag>
            </el-descriptions-item>
          </el-descriptions>
          <el-text truncated>{{ item.browser }}</el-text>
          <div>
            <el-button @click="onChat(item)" plain size="small" icon="ChatDotRound" :title="$t('btn.privateChat')"
              v-hasRole="['admin']"></el-button>
            <el-button @click="onLock(item)" plain size="small" icon="lock" :title="$t('btn.accountForced')"
              v-hasPermi="['monitor:online:forceLogout']"></el-button>
          </div>
        </el-card>
      </el-col>

      <el-empty v-show="total == 0" description="no data" />
    </el-row>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize"
      @pagination="getList" />
  </div>
</template>

<script setup name="onlineuser">
  import { listOnline, forceLogout, forceLogoutAll } from '@/api/monitor/online'
  import dayjs from 'dayjs'
  import useSocketStore from '@/store/modules/socket'
  const { proxy } = getCurrentInstance()
  const queryRef = ref(null)
  const queryParams = reactive({
    pageNum: 1,
    pageSize: 10
  })

  const onlineNum = computed(() => {
    return useSocketStore().onlineNum
  })
  const viewSwitch = ref(1)
  const loading = ref(false)
  const onlineUsers = ref([])
  const total = ref(0)
  function handleQuery() {
    queryParams.pageNum = 1
    getList()
  }
  function getList() {
    loading.value = true
    listOnline(queryParams).then((res) => {
      if (res.code == 200) {
        total.value = res.data.totalNum
        onlineUsers.value = res.data.result
        setTimeout(() => {
          loading.value = false
        }, 200)
      }
    })
  }
  getList()

  function onChat(item) {
    proxy
      .$prompt(proxy.$t('ploginlog.messageContent'), proxy.$t('layout.message') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.sendMessage'),
        cancelButtonText: proxy.$t('btn.cancel'),
        inputPattern: /\S/,
        inputErrorMessage: proxy.$t('ploginlog.messageCcontentNotempty'),
        type: "success",
      })
      .then(({ value }) => {
        proxy.signalr.SR.invoke('sendMessage', item.userid, value).catch(function (err) {
          console.error(err.toString())
        })
      })
      .catch(() => { })
  }
  function onLock(row) {
    proxy
      .$prompt(proxy.$t('common.tipForcedReasons'), proxy.$t('btn.exit') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.sendMessage'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then((val) => {
        forceLogout({ ...row, time: 10, reason: val.value, clientId: row.clientId }).then(() => {
          proxy.$modal.msgSuccess(proxy.$t('btn.successfulForced'))
        })
      })
  }

  // 批量强退
  function onLockAll() {
    proxy
      .$prompt(proxy.$t('common.tipForcedReasons'), proxy.$t('btn.exit') + ' ' + proxy.$t('common.tip'), {
        confirmButtonText: proxy.$t('btn.sendMessage'),
        cancelButtonText: proxy.$t('btn.cancel'),
        type: "warning",
      })
      .then((val) => {
        forceLogoutAll({ time: 10, reason: val.value }).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('btn.successfulForced'))
        })
      })
  }
  watch(
    onlineNum,
    () => {
      handleQuery()
    },
    {
      immediate: true
    }
  )
</script>
<style>
  .el-col {
    margin-bottom: 10px;
  }
</style>