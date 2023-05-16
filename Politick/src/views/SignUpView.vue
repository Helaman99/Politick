<template>
    <div class = "signup">

        <img src = "@/assets/logos/politick.svg">
        <br><br><br>

        <label for = "email">Email</label>
        <v-text-field v-model = 'email' type = "email" id = "email" variant = "solo" placeholder = "Email" />
        <label for = "password">Password</label>
        <v-text-field v-model = 'password' type = "password" id = "password" variant = "solo" placeholder = "Password" />
        <label for = "password2">Repeat Password</label>
        <v-text-field type = "password" id = "password2" variant = "solo" placeholder = "Repeat Password" />
        <v-btn @click = 'checkCreds()'>Sign Up</v-btn>

        <br><br>
        <p>Already have an account?</p>
        <router-link to = "/">Login</router-link>
    </div>
</template>

<script setup lang = 'ts'>
import { ref } from 'vue'
import { signUp } from '@/scripts/playerController'

const email = ref('')
const password = ref('')

function checkCreds() {
    signUp(email.value, password.value)
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