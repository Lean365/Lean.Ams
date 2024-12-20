**English** | [中文](./README.md)

<h2 align="center">🏬Laplace.NET General management platform🏬</h2>
<h4 align="center">👉.Net7+Vue3.x+Element plus Fast development framework with front and rear separation👈</h4>  
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

## 🎉Overview

- Production Kanban focusing on small and medium-sized manufacturing companies.(Easy,Flexible,Practical)
- Integration of [ZR.Admin](https://gitee.com/izory) framework technology efficient and rapid development.
- Focus on your business, easy development starts now!

## 💚 Crowd

- Familiar with the business processes of a manufacturing company.
- Being and wanting to develop with element-ui/element-plus with 1+ years of front-end development experience.
- Familiar with the Vue.js technology stack and have developed several real-world projects using it.
- Students who want to advance and improve.
- Zero-based, please move to izory: [ZR.Admin](https://gitee.com/izory).

## 🌐Online

- 😭pending...

```
Due to being a personal project, funds are limited!!!
```

## 💎Repositories

| Repositories | Gitee | Github                                                                         |
| ------------ | ----- | ------------------------------------------------------------------------------ |
| Vue3         |       | [Clone/Download already included in Net7](https://github.com/Lean365/Lean.Ams) |
| Net7         |       | [Clone/Download](https://github.com/Lean365/Lean.Ams)                          |

## 🍅Front-end

- Core:vue3.x、vite、vuex、vue-router 、vue-cli 、axios、 element-plus、echats、i18n etc,using vscode tools.

## 🍆Back-end

- Core:C#、.Net7.0、Web API、sqlsugar、swagger、signalR、IpRateLimit、Quartz.net、Redis,using vs2022 tools.

## ✨ Manufacturing Management

1. Budget management
   - Personnel
   - Equipment
   - Overtime
2. Expense management
   - Actual budget comparison
3. Cost Management
   - sales
   - BOM
   - labor
   - production
4. Sales Management
   - Customer Complaints
   - Serial number
5. Material Management
   - MRP
   - FC
6. Production Management
   - **EC**
   - **OPH(Output per hour)**
   - Defects
   - Manhour
7. Quality Control
   - Cost
   - Incoming material
   - finished product

## 🐬 OA

- pending...

## 🐾 ChatGPT

- pending...

## 🔰Project Structure

### Agile Manufacturing

```
├─Ams.Common                         ->[public layer class library]: Helper including data, regular, strings, etc;
├─Ams.Generator                      ->[code generation function]: contains templates, methods, code, downloads.
├─Ams.Infrastructure                 ->[base layer class library]: data types, I/O and other class libraries;
├─Ams.Kernel                         ->[Built-in Function Library]: System administration-related
├─Ams.Model                          ->[entity layer class library]: provides database tables, data transfer objects in the project;
├─Ams.Repository                     ->[Repository layer class library]: facilitates the provision of operations with executing stored procedures;
├─Ams.Service                        ->[service layer class library]: provides WebApi interface calls;
├─Ams.Tasks                          ->[Timed Tasks library]: provide project timed tasks to achieve functionality
├─Ams.WebApi                         ->[webapi interface]: provides interface services for Vue version or other three-party systems.
├─Ams.Vue                            ->[front-end UI]: vue2.0 version UI layer
├─Ams.Vue3                           ->[front-end UI]: vue3.0 version UI layer
```

### Flexible Manufacturing

```
├─Fms.Common                         ->[public layer class library]: Helper including data, regular, strings, etc;
├─Fms.Generator                      ->[code generation function]: contains templates, methods, code, downloads.
├─Fms.Infrastructure                 ->[base layer class library]: data types, I/O and other class libraries;
├─Fms.Kernel                         ->[Built-in Function Library]: System administration-related
├─Fms.Model                          ->[entity layer class library]: provides database tables, data transfer objects in the project;
├─Fms.Repository                     ->[Repository layer class library]: facilitates the provision of operations with executing stored procedures;
├─Fms.Service                        ->[service layer class library]: provides WebApi interface calls;
├─Fms.Tasks                          ->[Timed Tasks library]: provide project timed tasks to achieve functionality
├─Fms.WebApi                         ->[webapi interface]: provides interface services for Vue version or other three-party systems.
├─Fms.Vue                            ->[front-end UI]: vue2.0 version UI layer(Disposal)
├─Fms.Vue3                           ->[front-end UI]: vue3.0 version UI layer
```

### Jit Manufacturing

```
├─Jms.Common                         ->[public layer class library]: Helper including data, regular, strings, etc;
├─Jms.Generator                      ->[code generation function]: contains templates, methods, code, downloads.
├─Jms.Infrastructure                 ->[base layer class library]: data types, I/O and other class libraries;
├─Jms.Kernel                         ->[Built-in Function Library]: System administration-related
├─Jms.Model                          ->[entity layer class library]: provides database tables, data transfer objects in the project;
├─Jms.Repository                     ->[Repository layer class library]: facilitates the provision of operations with executing stored procedures;
├─Jms.Service                        ->[service layer class library]: provides WebApi interface calls;
├─Jms.Tasks                          ->[Timed Tasks library]: provide project timed tasks to achieve functionality
├─Jms.WebApi                         ->[webapi interface]: provides interface services for Vue version or other three-party systems.
├─Jms.Vue                            ->[front-end UI]: vue2.0 version UI layer(Disposal)
├─Jms.Vue3                           ->[front-end UI]: vue3.0 version UI layer
```

### Lean Manufacturing

```
├─La.Common                         ->[public layer class library]: Helper including data, regular, strings, etc;
├─La.Generator                      ->[code generation function]: contains templates, methods, code, downloads.
├─La.Infrastructure                 ->[base layer class library]: data types, I/O and other class libraries;
├─La.Kernel                         ->[Built-in Function Library]: System administration-related
├─La.Model                          ->[entity layer class library]: provides database tables, data transfer objects in the project;
├─La.Repository                     ->[Repository layer class library]: facilitates the provision of operations with executing stored procedures;
├─La.Service                        ->[service layer class library]: provides WebApi interface calls;
├─La.Tasks                          ->[Timed Tasks library]: provide project timed tasks to achieve functionality
├─La.WebApi                         ->[webapi interface]: provides interface services for Vue version or other three-party systems.
├─La.Vue                            ->[front-end UI]: vue2.0 version UI layer(Disposal)
├─La.Vue3                           ->[front-end UI]: vue3.0 version UI layer
```

### Lean Production

```
├─Lps.Common                         ->[public layer class library]: Helper including data, regular, strings, etc;
├─Lps.Generator                      ->[code generation function]: contains templates, methods, code, downloads.
├─Lps.Infrastructure                 ->[base layer class library]: data types, I/O and other class libraries;
├─Lps.Kernel                         ->[Built-in Function Library]: System administration-related
├─Lps.Model                          ->[entity layer class library]: provides database tables, data transfer objects in the project;
├─Lps.Repository                     ->[Repository layer class library]: facilitates the provision of operations with executing stored procedures;
├─Lps.Service                        ->[service layer class library]: provides WebApi interface calls;
├─Lps.Tasks                          ->[Timed Tasks library]: provide project timed tasks to achieve functionality
├─Lps.WebApi                         ->[webapi interface]: provides interface services for Vue version or other three-party systems.
├─Lps.Vue                            ->[front-end UI]: vue2.0 version UI layer(Disposal)
├─Lps.Vue3                           ->[front-end UI]: vue3.0 version UI layer
```

### front-end overall structure

```
├-bat           -> Command line
├-dist          ->Project Packaging
├─html          ->
├-public        -> Static resources independent of business logic
├-src           -> Source code for applications
│ ├-api         ->Background interface package
│ ├-assets      -> for storing various static files
│ ├-components ->Common components
│ ├-directive ->Custom Instructions
│ ├-i18n      ->Internationalization
│ ├-layout    ->Layout
│ ├-plugins   ->Plugins
│ ├-router    -> Routing Configuration
│ ├-store     ->vuex Status Management Tool
│ ├-utils     -> Global Common Methods
│ └-views     ->Page
└-vite        ->Building Tools
```

## 📌Demo Images

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

## 🎉Advantages

1. The front-end system does not need to write login, authorization and authentication modules; it is only responsible for writing business modules
2. the backend system does not need any secondary development, direct release can be used
3. front and back-end systems are separated, respectively, for different systems (domain names can be independent)
4. unified global exception handling
5. custom code generation function

## 💐 Special Acknowledgements

- 👉Ruoyi.vue：[Ruoyi](http://www.ruoyi.vip/)
- 👉SqlSugar：[SqlSugar](https://www.donet5.com/Home/Doc)
- 👉element-plus：[element-plus](https://github.com/element-plus/element-plus)
- 👉kailong321200875:[vue-element-plus-admin](https://github.com/kailong321200875/vue-element-plus-admin)
- 👉GMingChen:[vue-element-plus-admin](https://github.com/GMingChen/vue3-element-plus-admin)
- 👉Meiam.System：[Meiam.System](https://github.com/91270/Meiam.System)
- 👉izory：[ZR.Admin](https://gitee.com/izory)
- 👉cq-panda：[Vue.NetCore](https://github.com/cq-panda/Vue.NetCore)
- 👉zuohuaijun：[Admin.NET](https://toscode.gitee.com/zuohuaijun/Admin.NET)

## 🎀Donate

If you think this project has helped you, you can help the author buy a glass of juice to show your encouragement 🍹
<img src="https://github.com/Lean365/Lean.Ams/blob/master/Ams.Document/images/pay.jpg"/>

## 💡Browsers support

Modern browsers and Internet Explorer 10+.

| [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/edge/edge_48x48.png" alt="IE / Edge" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>IE / Edge | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/firefox/firefox_48x48.png" alt="Firefox" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Firefox | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/chrome/chrome_48x48.png" alt="Chrome" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Chrome | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/safari/safari_48x48.png" alt="Safari" width="24px" height="24px" />](https://godban.github.io/browsers-support-badges/)</br>Safari |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IE10, IE11, Edge                                                                                                                                                                                                 | last 2 versions                                                                                                                                                                                                    | last 2 versions                                                                                                                                                                                                | last 2 versions                                                                                                                                                                                                |

## 🔧 Instructions for use

If the deployment of iis cannot access the situation, there are two methods:

1. Backend packaging: In the VS2022 menu<Generate><Publish>
2. Open the La.WebApi.exe file directly and check the error log on the console
3. Change false to true in webconfig. After restarting the project and running the website, there is an error log file in the folder log under the directory
4. If there is an environment, please use Laplace\_ Deb.sql, sql2019 version can be directly imported. If there is no environment, SQLite version, place.net.db can be used, and configured in<font color=# ff0000>appsettings. json</font>
5. Front end packaging: npm run build: prod

```
✓ build in 2m 20s
```

### 🔧 Overflow Solution

```
FATAL ERROR: Reached heap limit Allocation failed - JavaScript heap out of memory
```

1. Delete Command

```
   rimraf node_modules
```

2. Reinstall

```
   npm i
```

3. Increase memory mechanism

```
   npm install -g increase-memory-limit
```

4. Execution

```
    increase-memory-limit
```

5. Modify node_modules\.bin\webpack.cmd, "%\_prog%" replace % \_prog%
6. Modify package.js

```
     "scripts": {
    "dev": "vite",
    "build:prod": "vite build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },

```

Change to

```
     "scripts": {
    "dev": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js",
    "build:prod": "node.exe --max-old-space-size=10240 node_modules/vite/bin/vite.js build",
    "build:stage": "vite build --mode staging",
    "preview": "vite preview"
  },
```

7. Rebuild

```
   npm run build:prod

```

6. IIS Deployment Vue
   Download[urlrewrite](https://www.iis.net/downloads/microsoft/url-rewrite)
   Download[Application Request Routing](https://www.iis.net/downloads/microsoft/application-request-routing)
   Configuration Example
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
