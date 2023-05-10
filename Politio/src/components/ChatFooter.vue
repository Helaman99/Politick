<template>
    <v-card>
        <v-layout>
            <v-footer>
                <v-textarea v-model = 'message' placeholder = "Message" auto-grow 
                    autocomplete />
                <v-btn @click = "$emit('send', message)">Send</v-btn>
            </v-footer>
        </v-layout>
    </v-card>
</template>

<script setup lang = 'ts'>
import { ref } from 'vue'
const message = ref('')
</script>