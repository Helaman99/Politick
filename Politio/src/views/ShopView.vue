<template>
    <div class = 'shop'>
        <h1>Shop</h1>
        <br>
        <Transition name = 'fade'>
            <RouterView />
        </Transition>
    </div>
</template>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 1.5s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>