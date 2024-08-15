<template>
  <div class="login" ref="Area">
  </div>
</template>
<script setup>
  import { onMounted, onUnmounted } from "vue";
  import * as THREE from "three";
  import Cells from 'vanta/src/vanta.cells'
  import BIRDS from 'vanta/src/vanta.birds'
  import Clouds from 'vanta/src/vanta.clouds'
  import Clouds2 from 'vanta/src/vanta.clouds2'
  import Fog from 'vanta/src/vanta.fog'
  import Globe from 'vanta/src/vanta.globe'
  import Halo from 'vanta/src/vanta.halo'
  import Net from 'vanta/src/vanta.net'
  import Rings from 'vanta/src/vanta.rings'
  import Ripple from 'vanta/src/vanta.ripple'
  import Waves from 'vanta/src/vanta.waves'
  const Area = ref(null);
  let vantaEffect = ref(null);


  onMounted(() => {
    vantaEffect = BIRDS({
      el: Area.value,
      THREE: THREE,
      mouseControls: true,
      touchControls: true,
      gyroControls: false,
      minHeight: 200.00,
      minWidth: 200.00,
      scale: 1.00,
      scaleMobile: 1.00,
      birdSize: 1.0,
      wingSpan: 20.0,
      speedLimit: 4.0,
      separation: 20.0,
      alignment: 20.0,
      cohesion: 20.0,
      quantity: 3.0
    });
  });

  onUnmounted(() => {
    if (vantaEffect) {
      vantaEffect.destroy();
    }
  });


</script>


<style scoped lang="scss">
  .login {
    width: 100%;
    height: 100vh;
  }
</style>