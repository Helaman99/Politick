<template>
    <div class = 'chat-header'>
        <v-app-bar elevation = '3' height = '75' color = 'white'>
            <v-app-bar-title>
                <h1 id = 'countdown'>

                </h1>
            </v-app-bar-title>
        </v-app-bar>
    </div>
</template>

<script setup lang = 'ts'>
import { onMounted } from 'vue'
import { ref } from 'vue'
const emit = defineEmits(['timerEnd'])

const minutesLeft = ref<number>(0)
function startTimer(minutes: number) {
    const countdownElement = document.getElementById('countdown')
    if (countdownElement && minutes > 0) {
        let seconds = 59
        minutes--
        minutesLeft.value = minutes
        const countdown = setInterval(() => {
            if (minutes === 0 && seconds === -1) {
                clearInterval(countdown)
                emit('timerEnd')
            } 
            else if (seconds === -1) {
                minutes--
                minutesLeft.value = minutes
                seconds = 59
                countdownElement.textContent = minutes + ":" + seconds
                seconds--
            }
            else if (seconds < 10) {
                countdownElement.textContent = minutes + ":0" + seconds
                seconds--
            }
            else {
                countdownElement.textContent = minutes + ":" + seconds
                seconds--
            }
        }, 1000)
    }
}
onMounted( () => {
    startTimer(1)
})
defineExpose({ startTimer, minutesLeft })
</script>