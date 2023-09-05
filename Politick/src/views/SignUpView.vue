<template>
  <div class="signup">
    <img src="@/assets/logos/politick.svg" />
    <br /><br /><br />

    <label for="email">Email</label>
    <v-text-field v-model="email" type="email" id="email" variant="solo" placeholder="Email" />
    <label for="password">Password</label>
    <v-text-field
      v-model="password"
      type="password"
      id="password"
      variant="solo"
      placeholder="Password"
    />
    <label for="password2">Repeat Password</label>
    <v-text-field
      v-model="password2"
      type="password"
      id="password2"
      variant="solo"
      placeholder="Repeat Password"
    />
    <div class="agree">
      <input type="checkbox" id="checkbox" v-model="agreed" />
      <label for="checkbox" id="message">
        By clicking this checkbox, you agree to our
        <router-link to="/terms-of-service" target="_blank">Terms of Service</router-link>
        and
        <router-link to="/privacy-policy" target="_blank">Privacy Policy</router-link>.
      </label>
    </div>
    <v-btn @click="signUp()">Sign Up</v-btn>
    <br /><br />
    <div id="error-message"></div>

    <br />
    <p>Already have an account?</p>
    <router-link to="/login">Login</router-link>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { SignInService } from '@/scripts/SignInService'

const email = ref('')
const password = ref('')
const password2 = ref('')
const agreed = ref(false)

function signUp() {
  let error_div = document.getElementById('error-message') as HTMLElement
  if (password.value === password2.value && agreed.value)
    SignInService.instance.createAccount(email.value, password.value)
  else if (!agreed.value)
    error_div.innerHTML = '<p>Please accept the terms of service and privacy policy.</p>'
  else if (password.value !== password2.value) error_div.innerHTML = "<p>Passwords don't match</p>"
}
</script>

<style scoped>
.signup {
  width: 50%;
}
.v-input {
  width: 60%;
}
.agree {
  width: 50%;
  display: flex;
  margin: 1rem;
  font-size: 20px;
}
.agree #checkbox {
  width: 4rem;
}
.agree #message {
  padding: 1rem;
}

#error-message {
  font-size: large;
  color: red;
}

@media (max-width: 1024px) {
  .signup {
    width: 100%;
  }
  .v-input {
    width: 75%;
  }
}
</style>
