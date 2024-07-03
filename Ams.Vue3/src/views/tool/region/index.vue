<template>
  <div class="sys-region-container">
    <regionCnData>
    </regionCnData>
    <regionHmtData>
    </regionHmtData>
    <regionjaData></regionjaData>
    <regionWorldData></regionWorldData>
  </div>
</template>

<script setup name="region">
  import regionCnData from '@/components/RegionSelect/cn.vue'
  import regionHmtData from '@/components/RegionSelect/hkmotw.vue'
  import regionjaData from '@/components/RegionSelect/ja.vue'
  import regionWorldData from '@/components/RegionSelect/world.vue'
</script>