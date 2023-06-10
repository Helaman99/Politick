<template>
  <div class="dashboard">
    <headerBar />

    <div class="dashboard-content">
      <Transition name="fade">
        <RouterView />
      </Transition>
    </div>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  body {
    display: block;
    padding: 0.3rem 0;
  }
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 1.5s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>

<script setup lang="ts">
import headerBar from '@/components/HeaderBar.vue'
</script>
