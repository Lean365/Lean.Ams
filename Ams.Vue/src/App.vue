<template>
  <el-config-provider :locale="locale" :size="size">
    <router-view />
  </el-config-provider>
</template>
<script setup>
  import useUserStore from './store/modules/user'
  import useAppStore from './store/modules/app'
  import { ElConfigProvider } from 'element-plus'
  import zhCn from 'element-plus/dist/locale/zh-cn' // 简体
  import zhTw from 'element-plus/dist/locale/zh-tw' //繁體
  import en from 'element-plus/dist/locale/en' // English
  import ja from 'element-plus/dist/locale/ja' // 日本語



  import defaultSettings from '@/settings'
  const { proxy } = getCurrentInstance()

  const token = computed(() => {
    return useUserStore().userId
  })

  const lang = computed(() => {
    return useAppStore().lang
  })
  const locale = ref(zhCn)
  const size = ref(defaultSettings.defaultSize)

  size.value = useAppStore().size
  watch(
    token,
    (val) => {
      if (val) {
        proxy.signalr.start().then(async (res) => {
          if (res) {
            await proxy.signalr.SR.invoke('logOut')
          }
        })
      }
    },
    {
      immediate: true,
      deep: true
    }
  )
  watch(
    lang,
    (val) => {
      if (val == 'zh-cn') {
        locale.value = zhCn

      } else if (val == 'zh-tw') {
        locale.value = zhTw

      } else if (val == 'ja') {
        locale.value = ja

      } else if (val == 'en') {
        locale.value = en

      } else {
        locale.value = zhCn

      }
    },
    {
      immediate: true
    }
  )
  console.log('ℹ️源码地址: https://github.com/Lean365/Lean.Ams')
  console.log('📚官方文档: https://leansoft365.github.io/')
  console.log('🎁打赏作者: https://leansoft365.github.io/docs/others/donate.html')
  console.log('🏠公司网站: https://lean365.github.io/')
</script>