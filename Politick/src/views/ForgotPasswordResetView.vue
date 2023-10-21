<template>
  <div class="password-reset">
    <label for="password">Enter new password</label>
    <v-text-field
      v-model="password"
      type="password"
      id="password"
      variant="solo"
      placeholder="Password"
    />
    <label for="password">Repeat new password</label>
    <v-text-field
      v-model="password2"
      type="password"
      id="password2"
      variant="solo"
      placeholder="Repeat password"
    />
    <v-btn @click="resetPassword()">Submit</v-btn>
    <br /><br />
    <div id="error-message"></div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { ForgotPasswordService } from '@/scripts/ForgotPasswordService'

const password = ref('')
const password2 = ref('')

function resetPassword() {
  let error_div = document.getElementById('error-message') as HTMLElement
  if (password.value.trim().length === 0) {
    error_div.innerHTML = '<p>Please enter your new password</p>'
  } else if (password2.value.trim().length === 0) {
    error_div.innerHTML = '<p>Please repeat your new password</p>'
  } else if (password.value !== password2.value) {
    error_div.innerHTML = '<p>Passwords do not match</p>'
  } else {
    ForgotPasswordService.instance.resetPassword(password.value)
  }
}
</script>
