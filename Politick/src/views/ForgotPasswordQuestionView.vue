<template>
  <div class="question">
    <label for="answer">{{ ForgotPasswordService.instance.question }}</label>
    <v-text-field v-model="answer" type="text" id="answer" variant="solo" placeholder="Answer" />
    <p style="font-size: medium">(Answers are case sensitive)</p>
    <v-btn @click="submitAnswer()">Next</v-btn>
    <br /><br />
    <div id="error-message"></div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { ForgotPasswordService } from '@/scripts/ForgotPasswordService'

const answer = ref('')

function submitAnswer() {
  let error_div = document.getElementById('error-message') as HTMLElement
  if (answer.value.trim().length === 0) {
    error_div.innerHTML = '<p>Please enter your answer</p>'
  } else {
    ForgotPasswordService.instance.verifyAnswer(answer.value)
  }
}
</script>
