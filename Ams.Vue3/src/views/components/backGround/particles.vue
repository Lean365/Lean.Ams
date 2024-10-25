<template>

  <!-- <vue-particles id="tsparticles" :particlesInit="particlesInit" :particlesLoaded="particlesLoaded"
    :options="particlesConfig"></vue-particles> -->
  <vue-particles id="tsparticles" :particlesInit="particlesInit" :options="options" />

</template>

<script setup name="particles">
  //粒子背景动画
  //import { loadFull } from "tsparticles"
  import { tsParticles } from "@tsparticles/engine";
  import { loadFireworksPreset } from "@tsparticles/preset-fireworks"
  import { loadBubblesPreset } from "@tsparticles/preset-bubbles"
  import { loadFountainPreset } from "@tsparticles/preset-fountain"
  const particlesInit = (async () => {
    await loadFountainPreset(tsParticles);

    await tsParticles.load({
      id: "tsparticles",
      options: {
        preset: "fountain",
      },
    })
  })()
</script>

<style scoped>

</style>