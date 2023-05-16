<template>
    <div class = 'shop'>
        <div class = 'shop-header'>
          <h1>Shop</h1>
        </div>
        <Transition name = 'fade'>
            <RouterView />
        </Transition>
    </div>
</template>

<style scoped>
.shop-header {
  margin-top: -2.5rem;
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