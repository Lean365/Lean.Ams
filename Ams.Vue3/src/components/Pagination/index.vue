<template>
  <div :class="{ hidden: hidden }" class="pagination-container">
    <el-pagination size="small" background v-model:current-page="currentPage" v-model:page-size="pageSize"
      :layout="layout" :page-sizes="pageSizes" :pager-count="pagerCount" :total="total" @size-change="handleSizeChange"
      @current-change="handleCurrentChange" />
  </div>
</template>

<script setup>
  import { computed } from 'vue'
  import { defineProps, defineEmits } from 'vue'

  const props = defineProps({
    total: {
      required: true,
      type: Number
    },
    page: {
      type: Number,
      default: 1
    },
    limit: {
      type: Number,
      default: 20
    },
    pageSizes: {
      type: Array,
      default: () => [14, 28, 56, 112, 224, 448, 896]
    },
    pagerCount: {
      type: Number,
      default: document.body.clientWidth < 992 ? 5 : 7
    },
    layout: {
      type: String,
      default: 'total, sizes, prev, pager, next, jumper'
    },
    background: {
      type: Boolean,
      default: true
    },
    autoScroll: {
      type: Boolean,
      default: true
    },
    hidden: {
      type: Boolean,
      default: false
    }
  })

  const emit = defineEmits(['update:page', 'update:limit', 'pagination'])

  const currentPage = computed({
    get() {
      return props.page
    },
    set(val) {
      emit('update:page', val)
    }
  })

  const pageSize = computed({
    get() {
      return props.limit
    },
    set(val) {
      emit('update:limit', val)
    }
  })

  function handleSizeChange(val) {
    emit('pagination', { page: currentPage.value, limit: val })
    if (props.autoScroll) {
      // scrollTo(0, 800);
    }
  }

  function handleCurrentChange(val) {
    emit('pagination', { page: val, limit: pageSize.value })
    if (props.autoScroll) {
      // scrollTo(0, 800);
    }
  }
</script>

<style scoped>
  .pagination-container {
    padding: 20px 16px 0;
    display: flex;
    justify-content: flex-end;
  }

  .pagination-container.hidden {
    display: none;
  }
</style>