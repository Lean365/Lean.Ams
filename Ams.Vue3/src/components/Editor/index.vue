<template>
  <div style="border: 1px solid #ccc">
    <!-- 工具栏组件 -->
    <Toolbar style="border-bottom: 1px solid #ccc" :editor="editorRef" :defaultConfig="toolbarConfig" :mode="mode" />
    <!-- 富文本编辑器组件 -->
    <Editor style="height: 300px; overflow-y: hidden" v-model="valueHtml" :defaultConfig="editorConfig" :mode="mode"
      @onCreated="handleCreated" @onChange="handleChange" />
  </div>
</template>

<script setup>
  import '@wangeditor/editor/dist/css/style.css' // 引入 css
  import { ref, shallowRef, onBeforeUnmount, watch } from 'vue'
  import { Editor, Toolbar } from '@wangeditor/editor-for-vue'
  import { getToken } from '@/utils/auth'
  import useUserStore from '@/store/modules/user'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  // 定义组件的属性

  const props = defineProps({
    // placeholder: {
    //   type: String,
    //   default: '请输入内容'
    // },
    modelValue: String,
    toolbarConfig: {
      type: Object,
      default: () => ({})
    }
  })

  const emit = defineEmits(['update:modelValue'])

  const editorRef = shallowRef()
  const valueHtml = ref(props.modelValue)
  const editorConfig = {
    MENU_CONF: {},
    placeholder: proxy.$t('btn.enter') + proxy.$t('common.content')
  }

  // 配置上传图片
  editorConfig.MENU_CONF['uploadImage'] = {
    //服务器路径
    server: import.meta.env.VITE_APP_BASE_API + '/common/UploadFile',
    // form-data fieldName ，默认值 'wangeditor-uploaded-image'
    fieldName: 'file',
    // 单个文件的最大体积限制，默认为 2M
    maxFileSize: 1 * 1024 * 1024, // 1M
    // 最多可上传几个文件，默认为 100
    maxNumberOfFiles: 10,
    // 选择文件时的类型限制，默认为 ['image/*'] 。如不想限制，则设置为 []
    allowedFileTypes: ['image/*'],
    // 将 meta 拼接到 url 参数中，默认 false
    metaWithUrl: false,
    // 自定义增加 http  header
    headers: {
      Authorization: 'Bearer ' + getToken(),
      userid: useUserStore().userId
    },
    // 跨域是否传递 cookie ，默认为 false
    withCredentials: true,
    // 超时时间，默认为 10 秒
    timeout: 5 * 1000, // 5 seconds
    // 自定义插入图片
    customInsert(res, insertFn) {
      // 从 res 中找到 url alt href ，然后插图图片
      insertFn(res.data.url)
    }
  }

  // 配置上传视频
  editorConfig.MENU_CONF['uploadVideo'] = {
    server: import.meta.env.VITE_APP_BASE_API + '/common/UploadFile',
    // form-data fieldName ，默认值 'wangeditor-uploaded-video'
    fieldName: 'file',
    // 单个文件的最大体积限制，默认为 10M
    maxFileSize: 5 * 1024 * 1024, // 5M
    // 最多可上传几个文件，默认为 5
    maxNumberOfFiles: 3,
    // 选择文件时的类型限制，默认为 ['video/*'] 。如不想限制，则设置为 []
    allowedFileTypes: ['video/*'],
    // 将 meta 拼接到 url 参数中，默认 false
    metaWithUrl: false,
    // 自定义增加 http  header
    headers: {
      Authorization: 'Bearer ' + getToken(),
      userid: useUserStore().userId
    },
    // 跨域是否传递 cookie ，默认为 false
    withCredentials: true,
    // 超时时间，默认为 30 秒
    timeout: 15 * 1000, // 15 seconds
    customInsert(res, insertFn) {
      // 从 res 中找到 url alt href ，然后插图图片
      insertFn(res.data.url)
    }
  }

  // 组件卸载前销毁编辑器实例
  onBeforeUnmount(() => {
    const editor = editorRef.value
    if (editor) {
      editor.destroy()
    }
  })

  // 富文本编辑器创建完成回调
  const handleCreated = (editor) => {
    editorRef.value = editor
  }

  // 富文本编辑器内容变化回调
  const handleChange = (editor) => {
    emit('update:modelValue', editor.getHtml())
  }

  // 监听modelValue属性变化
  watch(() => props.modelValue, (value) => {
    const editor = editorRef.value
    if (value === undefined) {
      editor.clear()
      return
    }
    valueHtml.value = value
  })

</script>