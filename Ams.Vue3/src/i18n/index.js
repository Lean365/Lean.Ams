import { createI18n } from 'vue-i18n'
// import useAppStore from '@/store/modules/app'
import { listLangByLocale } from '@/api/system/locale.js'
import defaultSettings from '@/settings'
import cache from '@/plugins/cache'
const language = computed(() => {
  // return useAppStore().lang
  return cache.local.get('lang') || defaultSettings.defaultLang
})

import Cn from './lang/zh-cn.json'
import Tw from './lang/zh-tw.json'
import Ja from './lang/ja.json'
import fr from './lang/fr.json'
import En from './lang/en.json'
//vue-table
import vxeTableCn from 'vxe-table/lib/locale/lang/zh-CN'
import vxeTableTw from 'vxe-table/lib/locale/lang/zh-TW'
import vxeTableJa from 'vxe-table/lib/locale/lang/ja-JP'
import vxeTableEn from 'vxe-table/lib/locale/lang/en-US'
//内容
import pageArticleCn from './pages/article/zh-cn.json'
import pageArticleTw from './pages/article/zh-tw.json'
import pageArticleJa from './pages/article/ja.json'
import pageArticleEn from './pages/article/en.json'

//编辑组件

//组件
import pageComponentsCn from './pages/components/zh-cn.json'
import pageComponentsTw from './pages/components/zh-tw.json'
import pageComponentsJa from './pages/components/ja.json'
import pageComponentsEn from './pages/components/en.json'
//工具栏
import pageRightbarCn from './pages/rightbar/zh-cn.json'
import pageRightbarTw from './pages/rightbar/zh-tw.json'
import pageRightbarJa from './pages/rightbar/ja.json'
import pageRightbarEn from './pages/rightbar/en.json'
//登录页面
import pageAboutCn from './pages/about/zh-cn.json'
import pageAboutTw from './pages/about/zh-tw.json'
import pageAboutJa from './pages/about/ja.json'
import pageAboutEn from './pages/about/en.json'
//参数配置
import pageConfigCn from './pages/config/zh-cn.json'
import pageConfigTw from './pages/config/zh-tw.json'
import pageConfigJa from './pages/config/ja.json'
import pageConfigEn from './pages/config/en.json'
//部门页面
import pageDeptCn from './pages/dept/zh-cn.json'
import pageDeptTw from './pages/dept/zh-tw.json'
import pageDeptJa from './pages/dept/ja.json'
import pageDeptEn from './pages/dept/en.json'
//系统字典
import pageDictCn from './pages/dict/zh-cn.json'
import pageDictTw from './pages/dict/zh-tw.json'
import pageDictJa from './pages/dict/ja.json'
import pageDictEn from './pages/dict/en.json'

//系统字典
import pageErrorCn from './pages/error/zh-cn.json'
import pageErrorTw from './pages/error/zh-tw.json'
import pageErrorJa from './pages/error/ja.json'
import pageErrorEn from './pages/error/en.json'
//代码生成页面
import pageGenCn from './pages/gen/zh-cn.json'
import pageGenTw from './pages/gen/zh-tw.json'
import pageGenJa from './pages/gen/ja.json'
import pageGenEn from './pages/gen/en.json'
//任务页面
import pageTaskCn from './pages/task/zh-cn.json'
import pageTaskTw from './pages/task/zh-tw.json'
import pageTaskJa from './pages/task/ja.json'
import pageTaskEn from './pages/task/en.json'
//语言页面
import pageLangCn from './pages/lang/zh-cn.json'
import pageLangTw from './pages/lang/zh-tw.json'
import pageLangJa from './pages/lang/ja.json'
import pageLangEn from './pages/lang/en.json'

//日志页面
import pageLogCn from './pages/log/zh-cn.json'
import pageLogTw from './pages/log/zh-tw.json'
import pageLogJa from './pages/log/ja.json'
import pageLogEn from './pages/log/en.json'

//登录页面
import pageLoginCn from './pages/login/zh-cn.json'
import pageLoginTw from './pages/login/zh-tw.json'
import pageLoginJa from './pages/login/ja.json'
import pageLoginEn from './pages/login/en.json'

// 邮件菜单页面
import pageMailCn from './pages/mail/zh-cn.json'
import pageMailTw from './pages/mail/zh-tw.json'
import pageMailJa from './pages/mail/ja.json'
import pageMailEn from './pages/mail/en.json'

// 菜单页面
import pageMenuCn from './pages/menu/zh-cn.json'
import pageMenuTw from './pages/menu/zh-tw.json'
import pageMenuJa from './pages/menu/ja.json'
import pageMenuEn from './pages/menu/en.json'
// 通知页面
import pageNoticeCn from './pages/notice/zh-cn.json'
import pageNoticeTw from './pages/notice/zh-tw.json'
import pageNoticeJa from './pages/notice/ja.json'
import pageNoticeEn from './pages/notice/en.json'
// 岗位页面
import pagePostCn from './pages/post/zh-cn.json'
import pagePostTw from './pages/post/zh-tw.json'
import pagePostJa from './pages/post/ja.json'
import pagePostEn from './pages/post/en.json'
//在线页面
import pageOnlineCn from './pages/online/zh-cn.json'
import pageOnlineTw from './pages/online/zh-tw.json'
import pageOnlineJa from './pages/online/ja.json'
import pageOnlineEn from './pages/online/en.json'
//角色页面
import pageRoleCn from './pages/role/zh-cn.json'
import pageRoleTw from './pages/role/zh-tw.json'
import pageRoleJa from './pages/role/ja.json'
import pageRoleEn from './pages/role/en.json'

//统计页面
import pageStatCn from './pages/stat/zh-cn.json'
import pageStatTw from './pages/stat/zh-tw.json'
import pageStatJa from './pages/stat/ja.json'
import pageStatEn from './pages/stat/en.json'
//Tabs标签页面
import pageTabsCn from './pages/tabs/zh-cn.json'
import pageTabsTw from './pages/tabs/zh-tw.json'
import pageTabsJa from './pages/tabs/ja.json'
import pageTabsEn from './pages/tabs/en.json'
//上传页面
import pageUploadCn from './pages/upload/zh-cn.json'
import pageUploadTw from './pages/upload/zh-tw.json'
import pageUploadJa from './pages/upload/ja.json'
import pageUploadEn from './pages/upload/en.json'
//用户页面
import pageUserCn from './pages/user/zh-cn.json'
import pageUserTw from './pages/user/zh-tw.json'
import pageUserJa from './pages/user/ja.json'
import pageUserEn from './pages/user/en.json'
//欢迎页面
import pageWelcomeCn from './pages/welcome/zh-cn.json'
import pageWelcomeTw from './pages/welcome/zh-tw.json'
import pageWelcomeJa from './pages/welcome/ja.json'
import pageWelcomeEn from './pages/welcome/en.json'
import pageWelcomeFr from './pages/welcome/fr.json'

const i18n = createI18n({
  // 全局注入 $t 函数
  globalInjection: true,
  fallbackLocale: 'zh-cn',
  locale: language.value, //默认选择的语言
  legacy: false, // 使用 Composition API 模式，则需要将其设置为false
  messages: {
    'zh-cn': {
      ...Cn,
      ...vxeTableCn,
      ...pageArticleCn,
      ...pageComponentsCn,
      ...pageAboutCn,
      ...pageConfigCn,
      ...pageDeptCn,
      ...pageDictCn,
      ...pageErrorCn,
      ...pageGenCn,
      ...pageTaskCn,
      ...pageLangCn,
      ...pageLogCn,
      ...pageLoginCn,
      ...pageMailCn,
      ...pageMenuCn,
      ...pageNoticeCn,
      ...pageOnlineCn,
      ...pagePostCn,
      ...pageRightbarCn,
      ...pageRoleCn,
      ...pageStatCn,
      ...pageTabsCn,
      ...pageUploadCn,
      ...pageUserCn,
      ...pageWelcomeCn,

    },
    'zh-tw': {
      ...Tw,
      ...vxeTableTw,
      ...pageArticleTw,
      ...pageComponentsTw,
      ...pageAboutTw,
      ...pageConfigTw,
      ...pageDeptTw,
      ...pageDictTw,
      ...pageErrorTw,
      ...pageGenTw,
      ...pageTaskTw,
      ...pageLangTw,
      ...pageLogTw,
      ...pageLoginTw,
      ...pageMailTw,
      ...pageMenuTw,
      ...pageNoticeTw,
      ...pageOnlineTw,
      ...pagePostTw,
      ...pageRightbarTw,
      ...pageRoleTw,
      ...pageStatTw,
      ...pageTabsTw,
      ...pageUploadTw,
      ...pageUserTw,
      ...pageWelcomeTw,
    },
    'ja': {
      ...Ja,
      ...vxeTableJa,
      ...pageArticleJa,
      ...pageComponentsJa,
      ...pageAboutJa,
      ...pageConfigJa,
      ...pageDeptJa,
      ...pageDictJa,
      ...pageErrorJa,
      ...pageTaskJa,
      ...pageGenJa,
      ...pageLangJa,
      ...pageLogJa,
      ...pageLoginJa,
      ...pageMailJa,
      ...pageMenuJa,
      ...pageNoticeJa,
      ...pageOnlineJa,
      ...pagePostJa,
      ...pageRightbarJa,
      ...pageRoleJa,
      ...pageStatJa,
      ...pageTabsJa,
      ...pageUploadJa,
      ...pageUserJa,
      ...pageWelcomeJa,
    },
    en: {
      ...En,
      ...vxeTableEn,
      ...pageArticleEn,
      ...pageComponentsEn,
      ...pageAboutEn,
      ...pageConfigEn,
      ...pageDeptEn,
      ...pageDictEn,
      ...pageTaskEn,
      ...pageErrorEn,
      ...pageGenEn,
      ...pageLangEn,
      ...pageLogEn,
      ...pageLoginEn,
      ...pageMailEn,
      ...pageMenuEn,
      ...pageNoticeEn,
      ...pageOnlineEn,
      ...pagePostEn,
      ...pageRightbarEn,
      ...pageRoleEn,
      ...pageStatEn,
      ...pageTabsEn,
      ...pageUploadEn,
      ...pageUserEn,
      ...pageWelcomeEn,
    },
    fr: {
      ...fr,
      ...vxeTableEn,
      ...pageArticleEn,
      ...pageComponentsEn,
      ...pageAboutEn,
      ...pageConfigEn,
      ...pageDeptEn,
      ...pageDictEn,
      ...pageTaskEn,
      ...pageErrorEn,
      ...pageGenEn,
      ...pageLangEn,
      ...pageLogEn,
      ...pageLoginEn,
      ...pageMailEn,
      ...pageMenuEn,
      ...pageNoticeEn,
      ...pageOnlineEn,
      ...pagePostEn,
      ...pageRightbarEn,
      ...pageRoleEn,
      ...pageStatEn,
      ...pageTabsEn,
      ...pageUploadEn,
      ...pageUserEn,
      ...pageWelcomeFr,
    }
    //... 在这里添加其他语言支持
  }
})

const loadLocale = () => {
  listLangByLocale(language.value).then((res) => {
    const { code, data } = res
    if (code == 200) {
      //console.log(language.value, data)
      i18n.global.mergeLocaleMessage(language.value, data)
    }
  })
}
loadLocale()
export default i18n
