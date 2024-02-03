import { createApp } from 'vue'
// import Cookies from 'js-cookie'

import ElementPlus from 'element-plus'
import VForm3 from 'vform3-builds'  //引入VForm 3库
import 'vform3-builds/dist/designer.style.css'  //引入VForm3样式
import 'dayjs/locale/zh-cn'
import '@/assets/styles/index.scss' // global css
import CountUp from 'vue-countup-v3'
import App from './App'
import router from './router'
import directive from './directive' // directive
import vxetb from './vxe-tb'
// 注册指令
import plugins from './plugins' // plugins
import { downFile } from '@/utils/request'
import signalR from '@/signalr/signalr'
import vueI18n from './i18n/index'
import pinia from '@/store/index'

// svg图标
import '@/assets/iconfont/iconfont.js' //iconfont
import 'virtual:svg-icons-register'
import SvgIcon from '@/components/SvgIcon/index.vue'
import elementIcons from '@/components/SvgIcon/svgicon'
//转拼音
//import pinyin from "js-pinyin";

import './permission' // permission control

import { getConfigKey } from '@/api/system/config'
import { getDicts } from '@/api/system/dict/data'
import { parseTime, resetForm, addDateRange, handleTree, selectDictLabel, download, parseStrEmpty, strIsNullOrEmpty } from '@/utils/ruoyi'

// 分页组件
import Pagination from '@/components/Pagination'
// 自定义表格工具组件
import RightToolbar from '@/components/RightToolbar'
// 文件上传组件
import FileUpload from '@/components/FileUpload'
// 图片上传组件
import ImageUpload from '@/components/ImageUpload'
// 图片预览组件
import ImagePreview from '@/components/ImagePreview'
// 字典标签组件
import DictTag from '@/components/DictTag'
// el-date-picker 快捷选项
import dateOptions from '@/utils/dateOptions'
// Dialog组件
import Dialog from '@/components/Dialog'

const app = createApp(App)
signalR.init(import.meta.env.VITE_APP_SOCKET_API)
app.config.globalProperties.signalr = signalR
// 全局方法挂载
app.config.globalProperties.getConfigKey = getConfigKey//配置文件
app.config.globalProperties.getDicts = getDicts//字典数据
app.config.globalProperties.download = download// 通用下载方法
app.config.globalProperties.downFile = downFile//通用下载方法
app.config.globalProperties.parseTime = parseTime//日期格式化
app.config.globalProperties.resetForm = resetForm// 表单重置
app.config.globalProperties.handleTree = handleTree//构造树型结构数据
app.config.globalProperties.addDateRange = addDateRange// 添加日期范围
app.config.globalProperties.selectDictLabel = selectDictLabel// 回显数据字典
app.config.globalProperties.dateOptions = dateOptions//日期选项
app.config.globalProperties.parseStrEmpty = parseStrEmpty//转换字符串，undefined,null等转化为""
app.config.globalProperties.strIsNullOrEmpty = strIsNullOrEmpty//字符串是否为空


// 全局组件挂载
app.component('DictTag', DictTag)
app.component('Pagination', Pagination)
app.component('UploadFile', FileUpload)
app.component('UploadImage', ImageUpload)
app.component('ImagePreview', ImagePreview)
app.component('RightToolbar', RightToolbar)
app.component('svg-icon', SvgIcon)
app.component('ZrDialog', Dialog)

directive(app)
vxetb(app)
app.use(pinia)
  .use(router)
  .use(plugins)
  .use(CountUp)
  //.use(pinyin.setOptions({ checkPolyphone: false, charCase: 0 }))
  .use(ElementPlus, {})
  .use(VForm3)  //全局注册VForm3(同时注册了v-form-designe、v-form-render等组件)
  .use(elementIcons)
  .use(vueI18n)
  .mount('#app')
