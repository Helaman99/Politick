<template>
    <v-app>
        <div class = 'chat'>
            <div class = "messages">
                <messageBubble v-for = "message in messages" :class = message.class :text = message.text />
            </div>
            <chatFooter @send = SendMessage />
        </div>
    </v-app>
</template>

<script setup lang = 'ts'>
import messageBubble from '@/components/MessageBubble.vue'
import chatFooter from '@/components/ChatFooter.vue'
import { connectionRef, room } from '@/scripts/roomController'
import { ref } from 'vue'

interface Message {
    class: string
    text: string
}
const messages = ref<Message[]>([])
const htmlElement = ref<HTMLElement | null>(document.querySelector("html"))
let justSent = ""

const connection = connectionRef.value

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
</style>