<template>
    <div class = "signup">

        <img src = "@/assets/logos/politick.svg">
        <br><br><br>

        <label for = "email">Email</label>
        <v-text-field v-model = 'email' type = "email" id = "email" variant = "solo" placeholder = "Email" />
        <label for = "password">Password</label>
        <v-text-field v-model = 'password' type = "password" id = "password" variant = "solo" placeholder = "Password" />
        <label for = "password2">Repeat Password</label>
        <v-text-field v-model = 'password2' type = "password" id = "password2" variant = "solo" placeholder = "Repeat Password" />
        <v-btn @click = 'signUp()'>Sign Up</v-btn>

        <br><br>
        <p>Already have an account?</p>
        <router-link to = "/login">Login</router-link>
    </div>
</template>

<script setup lang = 'ts'>
import { ref } from 'vue'
import { SignInService } from '@/scripts/SignInService'
import router from '@/router'

const email = ref('')
const password = ref('')
const password2 = ref('')

function signUp() {
    if (password.value === password2.value)
        SignInService.instance.createAccount(email.value, password.value)
    else
        console.log("Passwords don't match")
}
</script>

<style scoped>
.signup {
    width: 50%;
}
.v-input {
    width: 60%;
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