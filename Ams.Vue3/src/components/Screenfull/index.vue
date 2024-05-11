<template>
  <div>
    <svg-icon v-if="isFullscreen" name="m-min" @click="toggle" />
    <svg-icon v-else name="m-max" @click="toggle" />
  </div>
</template>

<script setup>
  import { useFullscreen } from '@vueuse/core'

  const { isFullscreen, enter, exit, toggle } = useFullscreen()
</script>