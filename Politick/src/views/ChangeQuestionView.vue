<template>
    <div id = "change-security-question">
        Change your security question
        <br /><br />
        <label for="question">New Security Question</label>
        <v-text-field 
        v-model="question" 
        type="text" 
        id="question" 
        variant="solo" 
        />
        <label for="answer">New Answer (case sensitive!)</label>
        <v-text-field 
        v-model="answer" 
        type="text" 
        id="answer" 
        variant="solo" 
        />
        <v-btn @click="changeQuestion()">Change Security Question</v-btn>
        <div id="error-message"></div>
    </div>
</template>

<script setup lang = 'ts'>
import { ForgotPasswordService } from '@/scripts/ForgotPasswordService'
import { ref } from 'vue'

const question = ref("")
const answer = ref("")

function changeQuestion() {
    let error_div = document.getElementById('error-message') as HTMLElement
    if (question.value.trim().length === 0) {
        error_div.innerHTML = "<p>Please enter your new question</p>"
    }
    else if (answer.value.trim().length === 0) {
        error_div.innerHTML = "<p>Please repeat your new answer</p>"
    }
    else {
        ForgotPasswordService.instance.changeQuestion(question.value, answer.value)
    }
}
</script>

<style scoped>
#change-security-question {
    padding: 0 20rem;
}

@media (max-width: 1200px) {
    #change-security-question {
        padding: 0 10rem;
    }
}

@media (max-width: 740px) {
    #change-security-question {
        padding: 0 5rem;
    }
}

@media (max-width: 588px) {
    #change-security-question {
        padding: 0 0rem;
    }
}
</style>