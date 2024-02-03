import XEUtils from 'xe-utils'
import {
  // 全局对象
  VXETable,
  Icon,
  Column,
  // 表格
  Tooltip,
  Table
} from 'vxe-table'
//import zhCN from 'vxe-table/lib/locale/lang/zh-CN'
import 'vxe-table/styles/cssvar.scss'
// 按需加载的方式默认是不带国际化的，自定义国际化需要自行解析占位符 '{0}'，例如：

VXETable.config({
  // 可选，对参数中的列头、校验提示..等进行自动翻译（只对支持国际化的有效）
  translate(key, args) {
    // 例如，只翻译 "app." 开头的键值
    if (key && key.indexOf('app.') > -1) {
      return i18n.global.t(key, args)
    }
    return key
  }
})
// VXETable.config({
//   i18n: (key, args) => XEUtils.toFormatString(XEUtils.get(zhCN, key), args)
// })
export default function useTable(app) {
  // 表格功能
  // app.use(Filter)
  // .use(Edit)
  // .use(Menu)
  // .use(Export)
  // .use(Keyboard)
  // .use(Validator)

  // 可选组件
  app
    .use(Column)
    // .use(Colgroup)
    // .use(Grid)
    .use(Tooltip)
    // .use(Toolbar)
    // .use(Pager)
    // .use(Form)
    // .use(FormItem)
    // .use(FormGather)
    // .use(Checkbox)
    // .use(CheckboxGroup)
    // .use(Radio)
    // .use(RadioGroup)
    // .use(RadioButton)
    // .use(Switch)
    // .use(Input)
    // .use(Select)
    // .use(Optgroup)
    // .use(Option)
    // .use(Textarea)
    // .use(Button)
    // .use(Modal)
    // .use(List)
    // .use(Pulldown)

    // 安装表格
    .use(Table)
}
