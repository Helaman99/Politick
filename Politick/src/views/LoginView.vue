<template>
    <div class = "login">

      <img src = "@/assets/logos/politick.svg" />
      <br><br><br>

      <v-text-field v-model = 'email' type = "email" id = "email" variant = "solo" placeholder = "Email" />
      <v-text-field v-model = 'password' type = "password" id = "password" variant = "solo" placeholder = "Password" />
      <v-btn @click = checkCreds>Login</v-btn>

      <br><br>
      <p>Don't have an account?</p>
      <router-link to = "/signup">Sign Up</router-link>

    </div>
</template>

<script setup lang = 'ts'>
import { ref } from 'vue'
import { login } from '@/scripts/playerController'

const email = ref('')
const password = ref('')

function checkCreds() {
    login(email.value, password.value)
}
</script>

<style scoped>
.login {
  margin-top: 5rem;
  width: 50%;
}
img {
  transform-origin: bottom;
  animation-name: bounce;
  animation-fill-mode: both;
  animation-duration: 1.2s;
}
.v-input {
    width: 60%;
}

@media (max-width: 1024px) {

    .login {
        width: 100%;
    }
    .v-input {
        width: 75%;
    }
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

</style>