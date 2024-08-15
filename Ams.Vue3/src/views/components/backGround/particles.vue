<template>
  <!-- <vue-particles id="tsparticles" :particlesInit="particlesInit" :particlesLoaded="particlesLoaded"
    :options="particlesConfig"></vue-particles> -->
  <vue-particles id="tsparticles" :particlesInit="particlesInit" :options="options" />
</template>

<script setup name="particles">
  //背景动画
  import { loadFull } from "tsparticles"
  import { loadFireworksPreset } from "@tsparticles/preset-fireworks"

  //import particlesConfig from "@/views/components/particles-bkg.json"
  //import particlesConfig from "@/views/components/particles-nasa.json"
  //import particlesConfig from "@/views/components/particles-star.json"
  // const particlesOptions = {
  //   preset: "fire",
  // }
  // const particlesOptions = {
  //   preset: "fireworks",
  // }
  // const particlesOptions = {
  //   preset: "bigCircles",
  // }
  // const particlesOptions = {
  //   preset: "triangles",
  // }

  const options = {
    preset: "fireworks",
  }
  const particlesInit = async engine => {
    await loadFireworksPreset(engine);
  }




  // const particlesLoaded = async container => {
  //   console.log("Particles container loaded", container);
  // }
</script>

<style scoped lang="scss">

</style>