<template>
  <div>
    <svg-icon name="m-github" @click="goto" />
  </div>
</template>
<script>
  export default {
    setup() {
      const url = ref("https://github.com/Lean365/Lean.Ams");

      function goto() {
        window.open(url.value);
      }

      return {
        goto,
      };
    },
  };
</script>