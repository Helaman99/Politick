<template>
    <v-app>
        <div class = 'chat'>

            <div class = "messages">
                <messageBubble v-for = "message in messages" :class = message.class :text = message.text />
            </div>

            <v-dialog class = 'versus-dialog' v-model = 'versus' persistent fullscreen 
                transition = 'dialog-top-transition'>
                <v-card class = 'versus-card'>
                    <div>
                        <PlayerCard :avatar-path = player.avatar :title = player.title color = 'white' />
                        <h3>You</h3>
                    </div>
                    <h1>VS</h1>
                    <div>
                        <PlayerCard :avatar-path = opponent?.Avatar :title = opponent?.Title color = 'white' />
                        <h3>Opponent</h3>
                    </div>
                </v-card>
            </v-dialog>

            <v-dialog class = 'disconnected-dialog' v-model = 'disconnected' transition = 'scale-transition'>
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
import { connectionRef, thisPlayer, opponent } from '@/scripts/roomController'
import { player } from '@/scripts/playerController'
import PlayerCard from '@/components/PlayerCard.vue'
import { ref } from 'vue'
import router from '@/router'

const versus = ref(true)
setTimeout(() => {
    versus.value = false
}, 4000)

interface Message {
    class: string
    text: string
}
const messages = ref<Message[]>([])
const htmlElement = ref<HTMLElement | null>(document.querySelector("html"))
let justSent = ""

const connection = connectionRef.value
let disconnected = ref(false)
const thisRoomId = thisPlayer.value?.ChatRoomId

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
        connection?.invoke('SendMessageToGroup', thisRoomId, message)
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
.versus-dialog {
    width: 100%;
}
.versus-card {
    display: flex;
    padding: 5rem;
    place-items: center;
}
.versus-card div {
    width: 20rem;
    display: flex;
    flex-direction: column;
    place-items: center;
}
.versus-card h1 {
    margin: 5rem;
}

@media (max-width: 870px) {
    .versus-card {
        flex-direction: column;
    }
    .versus-card h1 {
        margin: 2rem;
    }
}
</style>