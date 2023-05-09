<template>
    <div class = 'chat'>
        Chat view.
        <div class = "messages"></div>
        <input v-model = 'message' placeholder = "Message" />
        <v-btn @click = "SendMessage()">Send</v-btn>
    </div>
</template>

<script setup lang = 'ts'>
import * as signalR from '@microsoft/signalr';

let group = "Group1"
let message: string
const messagesElement = document.getElementsByClassName("messages")[0]

const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7060/ChatHub')
    .build()

connection.start().then(() => {
    connection.invoke('JoinGroup', group)
})

connection.on('ReceiveMessage', (message: string) => {
    console.log("Received message: " + message)

    const messageCard = document.createElement('v-card')
    messageCard.classList.add('received-message')

    const cardText = document.createElement('v-card-text')
    cardText.textContent = message
    messageCard.appendChild(cardText)
})

function SendMessage() {
    connection.invoke('SendMessageToGroup', group, message)
    console.log("Sent message: " + message)

    const messageCard = document.createElement('v-card')
    messageCard.classList.add('sent-message')

    const cardText = document.createElement('v-card-text')
    cardText.textContent = message
    messageCard.appendChild(cardText)
}
</script>

<style scoped>
.received-message {
    background-color: gainsboro;
    color: black;
}
.sent-message {
    background-color: lightskyblue;
    color: black;
}
</style>