<template>
  <div class="login">
    <img src="@/assets/logos/politick.svg" />
    <br /><br /><br />

    <v-text-field v-model="email" type="email" id="email" variant="solo" placeholder="Email" />
    <v-text-field
      v-model="password"
      type="password"
      id="password"
      variant="solo"
      placeholder="Password"
    />
    <v-btn :loading="loading" @click="login()">Login</v-btn>
    <br /><br />
    <div id="error-message"></div>
    <br />
    <router-link to="/forgot-password">Forgot Password?</router-link>

    <br /><br />
    <p>Don't have an account?</p>
    <router-link to="/signup">Sign Up</router-link>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { SignInService } from '@/scripts/SignInService'

const email = ref('')
const password = ref('')
const loading = ref(false)

async function login() {
  loading.value = true

  let response = null
  let error_div = document.getElementById('error-message') as HTMLElement
  if (email.value.trim().length === 0) {
    error_div.innerHTML = '<p>Please enter your email</p>'
  }
  else if (password.value.trim().length === 0) {
    error_div.innerHTML = '<p>Please enter your password</p>'
  }
  else {
    response = SignInService.instance.signIn(email.value, password.value)
  }
  if (response != null || 
      (response == null && error_div.innerHTML != '')) {
    loading.value = false
  }
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

#error-message {
  font-size: large;
  color: red;
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
