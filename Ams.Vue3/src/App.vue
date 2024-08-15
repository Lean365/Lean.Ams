<template>
  <el-config-provider :locale="locale" :size="size">
    <router-view />
  </el-config-provider>
</template>
<script setup>
  import useUserStore from './store/modules/user'
  import useAppStore from './store/modules/app'
  import { ElConfigProvider } from 'element-plus'
  import zhCn from 'element-plus/dist/locale/zh-cn' // 中文语言
  import thTw from 'element-plus/dist/locale/zh-tw' //繁体
  import ja from 'element-plus/dist/locale/ja' //日语
  import ko from 'element-plus/dist/locale/ko' //韩语
  import ar from 'element-plus/dist/locale/ar' // 阿拉伯语
  import ru from 'element-plus/dist/locale/ru' //俄语
  import es from 'element-plus/dist/locale/es' //西班牙语
  import fr from 'element-plus/dist/locale/fr' //法语
  import de from 'element-plus/dist/locale/de' //德语
  import en from 'element-plus/dist/locale/en' // 英文语言

  // import vzhCN from 'vxe-pc-ui/lib/language/zh-CN'
  // import vzhTw from 'vxe-pc-ui/lib/language/zh-TW'
  // import vJa from 'vxe-pc-ui/lib/language/ja-JP'
  // import vEn from 'vxe-pc-ui/lib/language/en-US'
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
      if (val == 'en') {
        locale.value = en
      } else if (val == 'zh-tw') {
        locale.value = thTw
      } else if (val == 'ja') {
        locale.value = ja
      } else if (val == 'ko') {
        locale.value = ko
      } else if (val == 'ar') {
        locale.value = ar
      } else if (val == 'ru') {
        locale.value = ru
      } else if (val == 'es') {
        locale.value = es
      } else if (val == 'fr') {
        locale.value = fr
      } else if (val == 'de') {
        locale.value = de
      } else {
        locale.value = zhCn
      }
    },
    {
      immediate: true
    }
  )
  console.log('🎉源码地址: https://github.com/Lean365/Lean.Ams')
  console.log('📖官方文档：https://leansoft365.github.io/')
  console.log('💰打赏作者：https://leansoft365.github.io/docs/others/donate.html')
  console.log('🎉公众号：lean365')
</script>