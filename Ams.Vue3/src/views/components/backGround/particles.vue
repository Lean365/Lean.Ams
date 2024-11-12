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
        background: {
          color: {
            value: '#000'
          }
        },
        particles: {
          number: {
            density: {
              enable: true,
            },
            value: 5
          },
          shape: {
            type: "circle", // starting from v2, this require the square shape script
          },
          size: {
            value: { min: 1, max: 5 }
          }
        },
        preset: "fountain",
      },
    });
  })();


</script>

<style lang="scss" scoped>

</style>