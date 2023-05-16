<template>
    <v-app>
        <div class = 'chat'>

            <div class = "messages">
                <messageBubble v-for = "message in messages" :class = message.class :text = message.text />
            </div>

            <v-dialog id = 'disconnected-dialog' v-model = 'disconnected' transition = 'scale-transition'>
                <v-card class = 'disconnected-card'>
                    <v-card-title color = 'red'>Oh no! Someone disconnected!</v-card-title>
                    <v-card-text>
                        Don't worry, you won't be penalized for this and will still receive your coins.
                        Maybe the other person just had bad internet...
                    </v-card-text>
                    <v-btn @click = disconnect()>OK</v-btn>
                </v-card>
            </v-dialog>

            <chatFooter @send = SendMessage />
        </div>
    </v-app>
</template>

<script setup lang = 'ts'>
import messageBubble from '@/components/MessageBubble.vue'
import chatFooter from '@/components/ChatFooter.vue'
import { connectionRef, room } from '@/scripts/roomController'
import { ref } from 'vue'
import router from '@/router'

interface Message {
    class: string
    text: string
}
const messages = ref<Message[]>([])
const htmlElement = ref<HTMLElement | null>(document.querySelector("html"))
let justSent = ""

const connection = connectionRef.value
let disconnected = ref(false)

connection?.on('ReceiveMessage', (message: string) => {
    if (message != null && message != "" && message.trim() !== "") {
        console.log("Received message: " + message)

        if (message != justSent) {
            messages.value.push({ class: "received-message", text: message })
            
            if (htmlElement.value)
                htmlElement.value.scrollTop = htmlElement.value.scrollHeight
        }
    }
})

function SendMessage(message: any) {
    if (message != null && message != "" && message.trim() !== "") {
        connection?.invoke('SendMessageToGroup', room.value, message)
        console.log("Sent message: " + message)

        messages.value.push({ class: "sent-message", text: message })
        console.log(htmlElement.value)
        
        if (htmlElement.value) {
            htmlElement.value.scrollTop = (htmlElement.value.scrollHeight + 64)
            console.log(htmlElement.value.scrollTop)
        }

        justSent = message
    }
}

connectionRef.value?.on('PlayerDisconnected', () => {
    disconnected.value = true
})

function disconnect() {
    // Add coins to player
    router.push('/dashboard/topics')
}
</script>

<style>
body {
    display: block;
}
#app {
    width: 100%;
    padding: 0;
}
.messages {
    display: flex;
    flex-direction: column;
}
.v-dialog {
    width: 50%;
}
.disconnected-card {
    align-items: center;
    text-align: center;
    padding: 1rem;
}
</style>