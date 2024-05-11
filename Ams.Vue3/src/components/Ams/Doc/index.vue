<template>
  <div>
    <svg-icon name="m-help" @click="goto" />
  </div>
</template>
<script setup>
  const url = ref('http://leansoft365.github.io');

  function goto() {
    window.open(url.value)
  }
</script>