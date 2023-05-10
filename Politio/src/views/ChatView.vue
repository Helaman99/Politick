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
import * as signalR from '@microsoft/signalr'
import messageBubble from '@/components/MessageBubble.vue'
import chatFooter from '@/components/ChatFooter.vue'
import { ref } from 'vue'

let group = "Group1"

interface Message {
    class: string
    text: string
}
const messages = ref<Message[]>([])

const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7060/ChatHub')
    .build()

connection.start().then(() => {
    connection.invoke('JoinGroup', group)
})

connection.on('ReceiveMessage', (message: string) => {
    console.log("Received message: " + message)

    messages.value.push({ class: "received-message", text: message })
})

function SendMessage(message: string) {
    connection.invoke('SendMessageToGroup', group, message)
    console.log("Sent message: " + message)

    messages.value.push({ class: "sent-message", text: message })

    message = ""
}
</script>

<style scoped>
.messages {
    display: flex;
    flex-direction: column;
}
</style>