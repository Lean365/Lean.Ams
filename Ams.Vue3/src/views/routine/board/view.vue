<template>
  <div style="position: absolute;top:0;left:0;width:100%;height:100%;background-color: rgb(11, 0, 0); ">
    <el-container style="height: 90%;">
      <el-header>
        <el-text class="el-header-title">熱烈歡迎</el-text>
        <el-image class="el-header-image" :src="url" :fit="fit" />

      </el-header>
      <el-main>
        <div class="el-main-corp">{{ mb004 }}</div>
        <el-form draggable="true">
          <el-form-item>
            <pre class="el-main-guest">{{ mb005 }}</pre>
          </el-form-item>
        </el-form>
      </el-main>
      <el-footer>
        <marquee>蒞臨指導 </marquee>
      </el-footer>
    </el-container>
  </div>
</template>

<script setup>
  import { useRouter } from 'vue-router';
  import draggable from 'vuedraggable'
  const router = useRouter();
  const mb004 = ref()
  const mb005 = ref()
  onMounted(() => {
    const urlParams = new URLSearchParams(window.location.search);
    //const param = decodeURIComponent(urlParams.get('mb004'));
    mb004.value = decodeURIComponent(urlParams.get('mb004'));
    mb005.value = decodeURIComponent(urlParams.get('mb005').split(',').join(' \n'));
    console.log(mb004, mb005);
    // 使用param进行后续操作
  });
  const url =
    'src/assets/logo/Agile_w.png'
</script>
<style scoped>
  .el-header-title {
    position: absolute;
    left: 400px;
    top: 10px;
    /* background-color: #B3C0D1; */
    color: #ffd504;
    text-align: center;
    line-height: 80px;
    font-size: 80px;
    font-weight: bold;
    letter-spacing: 80px;
  }

  .el-header-image {
    position: absolute;
    right: 10px;
    top: 10px;
    width: 40px;
    height: 40px;
  }

  /* background-color: #B3C0D1; */
  /* color: #ffd504;
    text-align: center;
    line-height: 80px;
    font-size: 80px;
    font-weight: bold;
    letter-spacing: 80px; */


  .el-footer {
    /* background-color: #B3C0D1; */
    color: #ffd504;
    text-align: center;
    line-height: 80px;
    font-size: 80px;
    font-weight: bold;
    letter-spacing: 80px;
  }

  .el-main-corp {
    position: absolute;
    left: 110px;
    top: 90px;
    /* text-align: center; */
    /* background-color: #E9EEF3; */
    font-family: 'Microsoft YaHei', '微软雅黑', sans-serif;
    font-weight: bold;
    color: #ffd504;
    font-size: 80px;

  }

  .el-main-guest {
    position: absolute;
    top: 100px;
    left: 160px;
    font-family: 'Microsoft YaHei', '微软雅黑', sans-serif;
    /* background-color: #E9EEF3; */
    font-weight: bold;
    color: #ffd504;
    line-height: 70px;
    letter-spacing: 5px;
    font-size: 60px;
    display: flex;
    flex-wrap: wrap;
  }
</style>