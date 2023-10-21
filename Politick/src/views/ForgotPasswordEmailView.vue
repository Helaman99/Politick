<template>
    <div class = "email">
        <label for="email">Please enter your email:</label>
        <v-text-field 
        v-model="email" 
        type="email" 
        id="email" 
        variant="solo" 
        placeholder="Email"
        />
        <v-btn @click="submitEmail()">Next</v-btn>
        <br><br>
        <div id="error-message"></div>
    </div>
</template>

<script setup lang = 'ts'>
import { ref } from 'vue'
import { ForgotPasswordService } from '@/scripts/ForgotPasswordService'

const email = ref('')

function submitEmail() {
    let error_div = document.getElementById('error-message') as HTMLElement
    if (email.value.trim().length === 0) {
        error_div.innerHTML = "<p>Please enter your email</p>"
    }
    else {
        ForgotPasswordService.instance.getQuestion(email.value)
    }
}
</script>