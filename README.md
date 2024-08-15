**中文** | [English](./README.en.md)
<h2 align="center">💥Lean.Ams通用中小制造企业的生产看板💥</h2>
<h4 align="center">👉.Net7+Vue3.x+Element plus前后端分离的快速发开框架👈</h4>  
<div align=center>
<img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/logo/Jit.png" width=128" height="128" />
<img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/logo/Lean365.png" width=128" height="128" />
<img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/logo/Flexible.png" width=128" height="128" />
<img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/logo/Agile.png" width=128" height="128" />
</div>

<p align="center">
	<a href="https://github.com/Lean365/Lean.Ams"><img src="https://img.shields.io/github/stars/Lean365/Lean.Ams?style=flat-square&logo=github&color=red"></a>
	<a href="https://github.com/Lean365/Lean.Ams/blob/master/LICENSE"><img src="https://img.shields.io/github/license/Lean365/Lean.Ams?style=flat-square&logo=github&color=0000FF"></a>
  <a href="https://github.com/Lean365/Lean.Ams/watchers"><img src="https://img.shields.io/github/watchers/Lean365/Lean.Ams?style=flat-square&logo=github&color=616ae5"></a>
  <a href="https://github.com/Lean365/Lean.Ams/network/members"><img src="https://img.shields.io/github/forks/Lean365/Lean365.github.io.svg?style=flat-square&logo=github&color=00C78C"></a>
  
</p>

## 🍁 概述

- 侧重中小制造企业的生产看板。简单、灵活、实用(Easy,Flexible,Practical)
- 整合[ZR.Admin](https://gitee.com/izory)框架技术高效快速开发，前后端分离模式，开箱即用。
- 专注您的业务，轻松开发从现在开始！


## 📢 适合人群

- 熟悉中小制造企业的业务流程。
- 正在以及想使用 element-ui/element-plus 开发，前端开发经验 1 年+。
- 熟悉 Vue.js 技术栈，使用它开发过几个实际项目。
- 对原理技术感兴趣，想进阶和提升的同学。
- 零基础，请移步到izory：[ZR.Admin](https://gitee.com/izory)。



## 🌏 在线体验
- 😭计划中...



```
由于是个人项目，资金有限！！！
```
## 🧰 代码仓库

| 仓库        | Gitee                                             | Github                                         |
| ----------- | ------------------------------------------------- | ---------------------------------------------- |
| Laplace.Net | [下载](https://gitee.com/leansoft365/Lean.Ams)  | [下载](https://github.com/Lean365/Lean.Ams)  |
| Lean.Ams | [克隆](https://gitee.com/leansoft365/Lean.Ams) | [克隆](https://github.com/Lean365/Lean.Ams) |


## 🍅 前端
- 核心框架 ：vue3.x、vuex、vue-router 、vue-cli 、axios、 element-plus、echats、i18n国际化等，前端采用vscode工具开发

## 🍆 后端
- 核心框架：C#、Net7.0 、 Web API 、 sqlsugar 、 swagger 、 signalR 、 IpRateLimit 、 Quartz.net 、 Redis，后端采用vs2022工具开发

## 🐼 生产管理
1. 预算管理
   - 人员
   - 设备
   - 加班
2. 费用管理
   - 实际预算对比
3. 成本管理
   - 销售
   - BOM
   - 人工
   - 生产
4.  销售管理
    - 客诉
    - 序列号
5.  物料管理
    - MRP
    - FC
6.  生产管理
    - **设变**
    - **OPH(每小时产量)**
    - 不良
    - 工数
7.  品质管理
    - 成本(业务,返工,报废)
    - 来料
    - 成品

## 🐬 OA
- 计划中...

## 🐾 ChatGPT
- 计划中...


## 🔰项目结构
### Agile Manufacturing
```
├─Ams.Common                         ->[公共层类库]：包括数据、正则、字符串等的Helper
├─Ams.Generator                      ->[代码生成功能]：包含模板、方法、代码、下载
├─Ams.Infrastructure                 ->[基础层类库]：数据类型，I/O以及其他类库
├─Ams.Kernel                         ->[内置功能库]：系统管理相关
├─Ams.Model                          ->[实体层类库]：提供项目中的数据库表、数据传输对象
├─Ams.Repository                     ->[仓库层类库]：方便提供有执行存储过程的操作
├─Ams.Service                        ->[服务层类库]：提供WebApi接口调用
├─Ams.Tasks                          ->[定时任务类库]：提供项目定时任务实现功能
├─Ams.WebApi                         ->[webapi接口]：为Vue版或其他三方系统提供接口服务
├─Ams.Vue                            ->[前端UI]：vue2.0版本UI层(弃用)
├─Ams.Vue3                           ->[前端UI]：vue3.0版本UI层
```
### Flexible Manufacturing
```
├─Fms.Common                         ->[公共层类库]：包括数据、正则、字符串等的Helper
├─Fms.Generator                      ->[代码生成功能]：包含模板、方法、代码、下载
├─Fms.Infrastructure                 ->[基础层类库]：数据类型，I/O以及其他类库
├─Fms.Kernel                         ->[内置功能库]：系统管理相关
├─Fms.Model                          ->[实体层类库]：提供项目中的数据库表、数据传输对象
├─Fms.Repository                     ->[仓库层类库]：方便提供有执行存储过程的操作
├─Fms.Service                        ->[服务层类库]：提供WebApi接口调用
├─Fms.Tasks                          ->[定时任务类库]：提供项目定时任务实现功能
├─Fms.WebApi                         ->[webapi接口]：为Vue版或其他三方系统提供接口服务
├─Fms.Vue                            ->[前端UI]：vue2.0版本UI层(弃用)
├─Fms.Vue3                           ->[前端UI]：vue3.0版本UI层
```
### Jit Manufacturing
```
├─Jms.Common                         ->[公共层类库]：包括数据、正则、字符串等的Helper
├─Jms.Generator                      ->[代码生成功能]：包含模板、方法、代码、下载
├─Jms.Infrastructure                 ->[基础层类库]：数据类型，I/O以及其他类库
├─Jms.Kernel                         ->[内置功能库]：系统管理相关
├─Jms.Model                          ->[实体层类库]：提供项目中的数据库表、数据传输对象
├─Jms.Repository                     ->[仓库层类库]：方便提供有执行存储过程的操作
├─Jms.Service                        ->[服务层类库]：提供WebApi接口调用
├─Jms.Tasks                          ->[定时任务类库]：提供项目定时任务实现功能
├─Jms.WebApi                         ->[webapi接口]：为Vue版或其他三方系统提供接口服务
├─Jms.Vue                            ->[前端UI]：vue2.0版本UI层(弃用)
├─Jms.Vue3                           ->[前端UI]：vue3.0版本UI层
```
### Lean Manufacturing
```
├─La.Common                         ->[公共层类库]：包括数据、正则、字符串等的Helper
├─La.Generator                      ->[代码生成功能]：包含模板、方法、代码、下载
├─La.Infrastructure                 ->[基础层类库]：数据类型，I/O以及其他类库
├─La.Kernel                         ->[内置功能库]：系统管理相关
├─La.Model                          ->[实体层类库]：提供项目中的数据库表、数据传输对象
├─La.Repository                     ->[仓库层类库]：方便提供有执行存储过程的操作
├─La.Service                        ->[服务层类库]：提供WebApi接口调用
├─La.Tasks                          ->[定时任务类库]：提供项目定时任务实现功能
├─La.WebApi                         ->[webapi接口]：为Vue版或其他三方系统提供接口服务
├─La.Vue                            ->[前端UI]：vue2.0版本UI层(弃用)
├─La.Vue3                           ->[前端UI]：vue3.0版本UI层
```
### Lean Production
```
├─Lps.Common                         ->[公共层类库]：包括数据、正则、字符串等的Helper
├─Lps.Generator                      ->[代码生成功能]：包含模板、方法、代码、下载
├─Lps.Infrastructure                 ->[基础层类库]：数据类型，I/O以及其他类库
├─Lps.Kernel                         ->[内置功能库]：系统管理相关
├─Lps.Model                          ->[实体层类库]：提供项目中的数据库表、数据传输对象
├─Lps.Repository                     ->[仓库层类库]：方便提供有执行存储过程的操作
├─Lps.Service                        ->[服务层类库]：提供WebApi接口调用
├─Lps.Tasks                          ->[定时任务类库]：提供项目定时任务实现功能
├─Lps.WebApi                         ->[webapi接口]：为Vue版或其他三方系统提供接口服务
├─Lps.Vue                            ->[前端UI]：vue2.0版本UI层(弃用)
├─Lps.Vue3                           ->[前端UI]：vue3.0版本UI层
```
### 前端总体结构
```
├─bat			              	->命令行
├─dist			            	->项目打包
├─html			            	->
├─public			          	->与业务逻辑无关的静态资源
├─src			              	->应用程序的源代码
│   ├─api		              	->后台接口封装
│   ├─assets		          	->用于存放各种静态文件
│   ├─components		      	->公共组件
│   ├─directive		        	->自定义指令
│   ├─i18n		            	->国际化
│   ├─layout		          	->布局
│   ├─plugins		          	->插件
│   ├─router		          	->路由配置
│   ├─store		            	->vuex 状态管理工具
│   ├─utils		            	->全局公用方法
│   └─views		            	->页面
└─vite			            	->构建工具
```

## 🌻 演示图

<table>
    <tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/back1.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/front1.png"/></td>
    </tr>
    <tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/1.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/2.png"/></td>
    </tr>
    <tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/3.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/4.png"/></td>
    </tr>
    <tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/5.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/6.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/7.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/8.png"/></td>
    </tr>	
	<tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/9.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/10.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/11.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/12.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/13.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/14.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/15.png"/></td>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/16.png"/></td>
    </tr>
	<tr>
        <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/17.png"/></td>
		    <td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/18.png"/></td>
    </tr>
	<tr>
		<td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/19.png"/></td>
		<td><img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/20.png"/></td>
	</tr>
</table>

## 🎉优势

1. 前台系统不用编写登录、授权、认证模块；只负责编写业务模块即可
2. 后台系统无需任何二次开发，直接发布即可使用
3. 前台与后台系统分离，分别为不同的系统（域名可独立）
4. 全局异常统一处理
5. 自定义的代码生成功能

## 💐 特别鸣谢
- 👉Ruoyi.vue：[Ruoyi](http://www.ruoyi.vip/)
- 👉SqlSugar：[SqlSugar](https://www.donet5.com/Home/Doc)
- 👉element-plus：[element-plus](https://github.com/element-plus/element-plus)
- 👉kailong321200875:[vue-element-plus-admin](https://github.com/kailong321200875/vue-element-plus-admin)
- 👉GMingChen:[vue-element-plus-admin](https://github.com/GMingChen/vue3-element-plus-admin)
- 👉Meiam.System：[Meiam.System](https://github.com/91270/Meiam.System)
- 👉izory：[ZR.Admin](https://gitee.com/izory)
- 👉cq-panda：[Vue.NetCore](https://github.com/cq-panda/Vue.NetCore)
- 👉zuohuaijun：[Admin.NET](https://toscode.gitee.com/zuohuaijun/Admin.NET)

## 🎀捐赠
如果你觉得这个项目帮助到了你，你可以帮作者买一杯果汁表示鼓励 🍹 
<img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/logo/pay.jpg"/>


## 💡Browsers support

Modern browsers and Internet Explorer 10+.

| [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/edge/edge_48x48.png" alt="IE / Edge" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>IE / Edge | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/firefox/firefox_48x48.png" alt="Firefox" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Firefox | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/chrome/chrome_48x48.png" alt="Chrome" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Chrome | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/safari/safari_48x48.png" alt="Safari" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Safari |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IE10, IE11, Edge                                                                                                                                                                                                 | last 2 versions                                                                                                                                                                                                    | last 2 versions                                                                                                                                                                                                | last 2 versions                                                                                                                                                                                                |

## 🔧使用说明
如果部署iis访问不了情况可以有以下两种办法：
1. 后端打包：在VS2022菜单<生成>\<发布>
2. 直接打开La.WebApi.exe文件然后看控制台的错误日志
3. web.config里面有个false 改为 true，iis重启项目后运行网站后，跟目录下面 有个文件夹 log 里面有错误日志文件
4. 有环境的请使用Laplace_deb.sql,sql2019版本直接导入，没有环境的可以使用SQLite版本，laplace.net.db，并在<font color=#ff0000>appsettings.json</font>配置
5. 前端打包：npm run build:prod
 ```
✓ built in 2m 20s
```
### 🔧溢出解决方案
 ```
FATAL ERROR: Reached heap limit Allocation failed - JavaScript heap out of memory
```
   1. 删除命令
   ```
   rimraf node_modules
   ```
   2. 重新构建
   ```
   npm i
   ```
   3. 增加内存机制
   ```
   npm install -g increase-memory-limit
   ```
   4. 执行
   ```
    increase-memory-limit
   ```
   5. 修改node_modules\.bin\webpack.cmd文件，全局搜索 “%_prog%” 替换为 %_prog%即可
   6. 修改package.js
   ```
     "scripts": {
    "dev": "vite",
    "build:prod": "vite build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },
   ```
   改成
   ```
     "scripts": {
    "dev": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js",
    "build:prod": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },
   ```
   7. 重新打包
   ```
   npm run build:prod
   ```
6. IIS部署前端
   下载URL重写模块[urlrewrite](https://www.iis.net/downloads/microsoft/url-rewrite)
   下载代理模块[Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing)
   配置示例
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis1.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis2.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis3.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis4.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis5.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis6.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis7.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis8.png"/>
   <img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/iis9.png"/>

## 🔑License
[MIT](https://github.com/Lean365/Lean.Ams/blob/master/LICENSE)

