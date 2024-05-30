<template>
  <particles></particles>
  <LangSelect :title="$t('layout.headerMultiLanguage')" class="langSet" />
  <el-image :src='imgsrc' class="logoSet" />
  <el-text class="sloganSet">{{ $t('layout.slogan') }}</el-text>
  <div class="login-wrap-particles">
    <div class="login">
      <el-form ref="registerFormRef" :model="registerForm" :rules="registerRules" class="login-form">
        <h3 class="title">{{ title }}</h3>
        <el-form-item prop="username">
          <el-input v-model="registerForm.username" type="text" size="default" auto-complete="off"
            :placeholder="$t('plogin.account')" minlength="6" maxlength="20" show-word-limit>
            <template #prefix>
              <i class="fas fa-user fa-beat-fade"
                style="--fa-animation-duration: 3s;font-size: 1em; color: rgb(0,97,174);"></i>
            </template>
          </el-input>
        </el-form-item>
        <el-form-item prop="password">
          <el-input v-model="registerForm.password" type="password" size="default" auto-complete="off"
            :placeholder="$t('plogin.password')" @keyup.enter="handleRegister" minlength="6" maxlength="20"
            show-word-limit>
            <template #prefix>
              <i class="fas fa-key fa-beat-fade"
                style="--fa-animation-duration: 3s;font-size: 1em; color: rgb(245, 164, 6);"></i>
            </template>
          </el-input>
        </el-form-item>
        <el-form-item prop="confirmPassword">
          <el-input v-model="registerForm.confirmPassword" type="password" size="default" auto-complete="off"
            :placeholder="$t('plogin.confirmPassword')" @keyup.enter="handleRegister" minlength="6" maxlength="20"
            show-word-limit>
            <template #prefix>
              <i class="fas fa-key fa-beat-fade"
                style="--fa-animation-duration: 3s;font-size: 1em; color: rgb(230, 33, 41);"></i>
            </template>
          </el-input>
        </el-form-item>
        <el-form-item prop="code" v-if="captchaOnOff">
          <el-input v-model="registerForm.code" auto-complete="off" size="default" :placeholder="$t('plogin.captcha')"
            style="width: 63%" @keyup.enter="handleRegister">
            <template #prefix>
              <i class="fas fa-shield fa-beat-fade"
                style="--fa-animation-duration: 3s;font-size: 1em; color: rgb(0, 149, 99);"></i>
            </template>
          </el-input>
          <div class="register-code ml10">
            <img :src="codeUrl" @click="getCode" class="register-code-img" />
          </div>
        </el-form-item>
        <el-form-item style="width: 100%">
          <el-button :loading="loading" type="primary" size="default" round style="width: 100%"
            @click.prevent="handleRegister">
            <span v-if="!loading">{{ $t('plogin.register') }}</span>
            <span v-else>{{$t('plogin.underRegistration')}}</span>
          </el-button>
        </el-form-item>
        <div style="text-align: center">
          <router-link class="link-type" :to="'/login'">{{$t('plogin.existingUsers')}}</router-link>
        </div>
      </el-form>
      <oauthLogin></oauthLogin>
    </div>
    <!--  底部  -->
    <div class="el-register-footer">
      <div v-html="copyRight"></div>
    </div>
  </div>
</template>

<script setup name="register">
  import {
    verifyPasswordStrength,
  } from '@/utils/regular';
  import vanta from '@/views/components/backGround/vanta.vue'
  import particles from '@/views/components/backGround/particles.vue'
  import star from '@/views/components/backGround/star.vue'
  import waterfall from '@/views/components/backGround/waterfall.vue'
  import three from '@/views/components/backGround/three.vue'
  import LangSelect from '@/components/LocaleSelect/index.vue'
  import { getCodeImg, register } from '@/api/system/login'
  import defaultSettings from '@/settings'
  import { ElMessageBox } from 'element-plus'
  import oauthLogin from './components/Login/oauthLogin.vue'
  import '@fortawesome/fontawesome-free/css/all.min.css';
  const imgsrc = 'src/assets/logo/Agile_w.png'
  const { proxy } = getCurrentInstance()
  const router = useRouter()
  const codeUrl = ref('')
  const registerForm = reactive({
    username: '',
    password: '',
    confirmPassword: '',
    code: '',
    uuid: ''
  })

  const registerFormRef = ref(null)
  const loading = ref(false)
  const captchaOnOff = ref(true)
  const equalToPassword = (rule, value, callback) => {
    if (registerForm.password !== value) {
      callback(new Error(proxy.$t('plogin.IncPassword')))
    } else {
      callback()
    }
  }
  const registerRules = reactive({
    username: [
      { required: true, trigger: 'blur', message: proxy.$t('btn.enter') + ' ' + proxy.$t('plogin.account') },
      {
        pattern: /^[a-zA-Z]\w{4,20}$/,
        min: 4,
        max: 20,
        message: proxy.$t('plogin.lengthAccount'),
        trigger: 'blur'
      }
    ],
    password: [
      { required: true, trigger: 'blur', message: proxy.$t('btn.enter') + ' ' + proxy.$t('plogin.password') },
      {
        pattern: /^(?![a-zA-z]+$)(?!\d+$)(?![!@#$%^&\.*]+$)(?![a-zA-z\d]+$)(?![a-zA-z!@#$%^&\.*]+$)(?![\d!@#$%^&\.*]+$)[a-zA-Z\d!@#$%^&\.*]{8,20}$/,
        min: 8,
        max: 20,
        message: proxy.$t('plogin.lengthPassword'),
        trigger: 'blur',

      }
    ],
    confirmPassword: [
      { required: true, trigger: 'blur', message: proxy.$t('btn.enter') + ' ' + proxy.$t('plogin.confirmPassword') },
      { required: true, validator: equalToPassword, trigger: 'blur' }
    ],
    code: [{ required: true, trigger: 'change', message: proxy.$t('btn.enter') + ' ' + proxy.$t('plogin.captcha') }]
  })
  const copyRight = computed(() => {
    return defaultSettings.copyright
  })
  const title = computed(() => {
    return defaultSettings.title
  })

  function getCode() {
    getCodeImg().then((res) => {
      codeUrl.value = 'data:image/gif;base64,' + res.data.img
      registerForm.uuid = res.data.uuid
      // this.$forceUpdate()
    })
  }
  function handleRegister() {
    proxy.$refs['registerFormRef'].validate((valid) => {
      if (valid) {
        loading.value = true
        register(registerForm)
          .then((res) => {
            if (res.code == 200) {
              const username = registerForm.username
              ElMessageBox.alert("<font color='red'>" + proxy.$t('plogin.congratulationsAccount') + username + proxy.$t('plogin.successfulAccount') + ' </font>', proxy.$t('plogin.registerSuccess') + ' ' + proxy.$t('common.tip'), {
                dangerouslyUseHTMLString: true,
                type: 'success'
              })
                .then(() => {
                  router.push('/login')
                })
                .catch(() => { })
            }
          })
          .catch(() => {
            loading.value = false
            if (captchaOnOff.value) {
              getCode()
            }
          })
      }
    })
  }


  getCode()
</script>

<style rel="stylesheet/scss" lang="scss" scoped>
  @import '@/assets/styles/login.scss';

  .register {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    background-size: cover;
    flex-direction: column;
    background: radial-gradient(220% 105% at top center, #1b2947 10%, #4b76a7 40%, #81acae 65%, #f7f7b6);
  }

  .login-form {
    padding: 15px 25px 15px 25px;
    height: 480px;
    /* width: 100%; */
  }

  .title {
    margin: 0px auto 30px auto;
    text-align: center;
    // color: #fff;
  }

  .register-tip {
    font-size: 13px;
    text-align: center;
    color: #bfbfbf;
  }

  .register-code {
    width: 33%;
    height: 38px;
    float: right;

    img {
      cursor: pointer;
      vertical-align: middle;
    }
  }

  .el-register-footer {
    height: 40px;
    line-height: 40px;
    position: fixed;
    bottom: 0;
    width: 100%;
    text-align: center;
    color: #fff;
    font-family: Arial;
    font-size: 12px;
    letter-spacing: 1px;
  }

  .register-code-img {
    height: 38px;
  }

  .el-form-item {
    margin-bottom: 40px;
  }
</style>