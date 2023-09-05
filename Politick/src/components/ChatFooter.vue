<template>
  <v-footer app>
    <v-textarea
      v-model="message"
      placeholder="Message"
      auto-grow
      autocomplete
      rows="1"
      variant="outlined"
      @keydown.enter.exact.prevent="sendMessage"
      @keydown.enter.shift.exact.prevent="message += '\n'"
    >
      <template v-slot:append>
        <v-btn @click="sendMessage">Send</v-btn>
      </template>
    </v-textarea>
  </v-footer>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const message = ref('')
const emit = defineEmits(['send'])

const sendMessage = () => {
  emit('send', message.value)
  message.value = ''
}
</script>
