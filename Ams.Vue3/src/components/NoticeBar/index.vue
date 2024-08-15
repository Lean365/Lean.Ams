<template>
  <div class="notic-bar" v-bind:style="cssVars">
    <slot name="icon">
      <!-- //缩放图标fa-beat
      //渐变动画效果fa-beat-fade
      //前后摇晃fa-shake -->
      <i class="fas fa-volume-high fa-beat-fade" style="font-size: 1em; color: rgb(255, 0, 0);"></i>
    </slot>

    <div class="notice-bar-container">
      <div class="notice-bar__wrap">
        <div v-for="(item, index) in dataList" :key="index" class="notice-bar__wrap_text">
          {{ item }}
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
  import '@fortawesome/fontawesome-free/css/all.min.css';
  const props = defineProps({
    dataList: {
      type: Array,
      default: []
    },
    style: {
      type: Object,
      default: {
        time: '8s',
        bgColor: '#67c23a'
      }
    }
  })
  const cssVars = computed(() => {
    return {
      '--notice-time': props.style.time,
      '--notice-bg': props.style.bgColor
    }
  })
</script>

<style lang="scss" scoped>
  .notic-bar {
    display: flex;
    align-items: center;
    background: var(--notice-bg);
    margin: 5px;
    border-radius: 5px;
    padding: 2px 5px;
  }

  .notice-bar-container {
    display: flex;
    width: calc(100% - 30px);
    height: 20px;
    overflow: hidden;
    margin-left: 5px;
  }

  .notice-img {
    width: 20px;
    height: 20px;
  }

  .notice-bar__wrap {
    margin-left: 10px;
    display: flex;
    animation: move var(--notice-time) linear infinite;
    line-height: 20px;
    color: #f5f6f7;

    .notice-bar__wrap_text {
      width: max-content;
      // min-width: 100px;
      margin-right: 20px;
      cursor: pointer;
    }

    .notice-bar__wrap_text:last-child {
      margin-right: unset;
    }
  }

  @keyframes move {
    0% {
      transform: translateX(100%);
    }

    100% {
      transform: translateX(-100%);
    }
  }
</style>