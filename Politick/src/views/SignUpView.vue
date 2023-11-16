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
    <label for="question">Security Question</label>
    <v-text-field
      v-model="question"
      type="text"
      id="question"
      variant="solo"
      placeholder="Put your question here"
    />
    <label for="answer">Answer</label>
    <v-text-field
      v-model="answer"
      type="text"
      id="question"
      variant="solo"
      placeholder="Put your answer here"
    />
    <p style="font-size: medium">
      Remember your security question and answer! They can be used if you forget your password.
    </p>
    <div class="agree">
      <input type="checkbox" id="checkbox" v-model="agreed" />
      <label for="checkbox" id="message">
        By clicking this checkbox, you agree to our
        <router-link to="/terms-of-service" target="_blank">Terms of Service</router-link>
        and
        <router-link to="/privacy-policy" target="_blank">Privacy Policy</router-link>.
        (Updated on 11/17/2023)
      </label>
    </div>
    <v-btn :loading="loading" @click="signUp()">Sign Up</v-btn>
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
const question = ref('')
const answer = ref('')
const agreed = ref(false)
const loading = ref(false)

async function signUp() {
  loading.value = true

  let error_div = document.getElementById('error-message') as HTMLElement
  if (email.value.trim().length === 0) error_div.innerHTML = '<p>Please enter your email</p>'
  else if (password.value.trim().length === 0)
    error_div.innerHTML = '<p>Please enter your password</p>'
  else if (password2.value.trim().length === 0)
    error_div.innerHTML = '<p>Please repeat your password</p>'
  else if (password.value !== password2.value) error_div.innerHTML = "<p>Passwords don't match</p>"
  else if (question.value.trim().length === 0)
    error_div.innerHTML = '<p>Please enter a security question</p>'
  else if (answer.value.trim().length === 0)
    error_div.innerHTML = '<p>Please enter the security question answer</p>'
  else if (!agreed.value)
    error_div.innerHTML = '<p>Please accept the terms of service and privacy policy</p>'
  else if (password.value === password2.value && agreed.value)
    await SignInService.instance.createAccount(
      email.value,
      password.value,
      question.value,
      answer.value
    )

  loading.value = false
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

label {
  font-size: medium;
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
