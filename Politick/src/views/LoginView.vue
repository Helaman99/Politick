<template>
    <div class = "login">

      <img src = "@/assets/logos/politick.svg" />
      <br><br><br>

      <v-text-field v-model = 'email' type = "email" id = "email" variant = "solo" placeholder = "Email" />
      <v-text-field v-model = 'password' type = "password" id = "password" variant = "solo" placeholder = "Password" />
      <v-btn @click = login()>Login</v-btn>

      <br><br>
      <p>Don't have an account?</p>
      <router-link to = "/signup">Sign Up</router-link>

    </div>
</template>

<script setup lang = 'ts'>
import { ref } from 'vue'
import { SignInService } from '@/scripts/SignInService'
import router from '@/router'

const email = ref('')
const password = ref('')

function login() {
    SignInService.instance.signIn(email.value, password.value)
}
</script>

<style scoped>
.login {
  margin-top: 5rem;
  width: 50%;
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
</style>