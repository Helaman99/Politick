<template>
  <main>
    <img src="@/assets/logos/politick.svg" />

    <div class="nav-options">
      <router-link to="/login">Login</router-link>
      <router-link to="/signup">Sign Up</router-link>
      <router-link to="/about">What is Politick?</router-link>
    </div>
  </main>
</template>

<script setup lang="ts"></script>

<style scoped>
main {
  width: 50%;
  margin-top: 10rem;
}
img {
  transform-origin: bottom;
  animation-name: bounce;
  animation-fill-mode: both;
  animation-duration: 1.2s;
}
.nav-options {
  display: flex;
  flex-direction: column;
}

@keyframes bounce {
  0% {
    opacity: 0;
    transform: translateY(-1000px);
  }
  40% {
    opacity: 1;
    transform: translateY(30px);
  }
  80% {
    transform: translateY(-10 px);
  }
  100% {
    transform: translateY(0);
  }
}

@media (max-width: 1024px) {
  main {
    width: 70%;
  }
}
@media (max-width: 580px) {
  main {
    width: 100%;
  }
}
</style>
