import { defineConfig, loadEnv } from 'vite'
import path from 'path'
import pkg from './package.json'
import dayjs from 'dayjs'
import createVitePlugins from './vite/plugins'
//import { lazyImport, VxeResolver } from 'vite-plugin-lazy-import'
const { dependencies, devDependencies, name, version } = pkg
const __APP_INFO__ = {
  pkg: { dependencies, devDependencies, name, version },
  lastBuildTime: dayjs().format('YYYY-MM-DD HH:mm:ss')
}
// https://vitejs.dev/config/
export default defineConfig(({ mode, command }) => {
  const env = loadEnv(mode, process.cwd())

  const alias = {
    // 设置路径
    '~': path.resolve(__dirname, './'),
    // 设置别名
    '@': path.resolve(__dirname, './src')
  }
  if (command === 'serve') {
    // 解决警告You are running the esm-bundler build of vue-i18n.
    alias['vue-i18n'] = 'vue-i18n/dist/vue-i18n.cjs.js'
  }
  return {
    define: {
      __APP_INFO__: JSON.stringify(__APP_INFO__)
    },
    plugins: [
      createVitePlugins(env, command === 'build')
      // ...,
      // lazyImport({
      //   resolvers: [
      //     VxeResolver({
      //       libraryName: 'vxe-table'
      //     }),
      //     VxeResolver({
      //       libraryName: 'vxe-pc-ui'
      //     })
      //   ]
      // })
      // ...
    ],
    //plugins: createVitePlugins(env, command === 'build'),
    resolve: {
      // https://cn.vitejs.dev/config/#resolve-alias
      alias: alias,
      // 导入时想要省略的扩展名列表
      // https://cn.vitejs.dev/config/#resolve-extensions
      extensions: ['.mjs', '.js', '.ts', '.jsx', '.tsx', '.json', '.vue']
    },
    css: {
      // preprocessorOptions: {
      //   scss: {
      //     api: 'modern-compiler'
      //   }
      // },
      devSourcemap: true //开发模式时启用
    },
    base: env.VITE_APP_ROUTER_PREFIX,
    // 打包配置
    build: {
      sourcemap: command === 'build' ? false : 'inline',
      outDir: 'dist', //指定输出目录
      assetsDir: 'assets', //指定静态资源存储目录(相对于outDir)
      chunkSizeWarningLimit: 2000, //Adjust the limit to your desired value in KB
      // 将js、css文件分离到单独文件夹
      rollupOptions: {
        output: {
          chunkFileNames: 'static/js/[name]-[hash].js',
          entryFileNames: 'static/js/[name]-[hash].js',
          assetFileNames: 'static/[ext]/[name]-[hash].[ext]'
        }
      }
    },
    // vite 相关配置
    server: {
      port: 8887,
      host: true,
      open: false,
      proxy: {
        // https://cn.vitejs.dev/config/#server-proxy
        '/dev-api': {
          target: env.VITE_APP_API_HOST,
          ws: true,
          changeOrigin: true,
          headers: { 'Access-Control-Allow-Origin': '*' },
          rewrite: (path) => path.replace(/^\/dev-api/, '')
        },
        '/msghub': {
          target: env.VITE_APP_API_HOST,
          ws: true,
          changeOrigin: true,
          headers: { 'Access-Control-Allow-Origin': '*' },
          rewrite: (path) => path.replace(/^\/msgHub/, '')
        }
      }
    }
  }
})
