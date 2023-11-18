<template>
  <v-app>
    <div class="chat">
      <ChatHeader @timerEnd="endGame()" ref="chatHeader" @quit="quit = true" />

      <div class="messages">
        <messageBubble
          v-for="message in messages"
          v-bind:key="message.messageClass"
          :class="message.messageClass"
          :text="message.text"
        />
      </div>

      <v-dialog
        class="versus-dialog"
        v-model="versus"
        persistent
        fullscreen
        transition="dialog-top-transition"
      >
        <v-card id="versus-card">
          <div>
            <h3>You:</h3>
            <PlayerCard :avatar-path="player?.avatar" :title="player?.title" color="white" />
          </div>
          <h1>VS</h1>
          <div>
            <h3>Opponent:</h3>
            <PlayerCard :avatar-path="opponent?.Avatar" :title="opponent?.Title" color="white" />
          </div>
        </v-card>
      </v-dialog>

      <v-dialog
        class="game-over-dialog"
        v-model="gameOver"
        transition="scale-transition"
        persistent
      >
        <v-card class="game-over-card">
          <v-card-text>
            You're all out of time! Would you like to spend 1 coin to gain another 2 minutes?
          </v-card-text>
          <v-card-actions>
            <v-btn @click="extendTime()">Yes</v-btn>
            <v-btn @click="leave()">No</v-btn>
            <v-btn @click="saveChatAsImage()">Save Chat</v-btn>
          </v-card-actions>
          <v-card-text id="failed"> </v-card-text>
        </v-card>
      </v-dialog>

      <v-dialog
        class="opponent-left"
        v-model="opponentLeft"
        transition="scale-transition"
        persistent
      >
        <v-card class="opponent-left">
          <v-card-title>The other player left the chat room.</v-card-title>
          <v-card-text> Time to find another opponent! </v-card-text>
          <v-card-actions>
            <v-btn @click="leave()">OK</v-btn>
            <v-btn @click="saveChatAsImage()">Save Chat</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <v-dialog class="time-added-dialog" v-model="timeAdded">
        <v-card id="time-added-card">
          <v-card-text> {{ playerAddedTime }} added 2 minutes to the time! </v-card-text>
        </v-card>
      </v-dialog>

      <v-dialog
        class="disconnected-dialog"
        v-model="disconnected"
        transition="scale-transition"
        persistent
      >
        <v-card class="disconnected-card">
          <v-card-title color="red">Oh no! Someone disconnected!</v-card-title>
          <v-card-text>
            Don't worry, you won't be penalized for this and will still receive your coins. Maybe
            the other person just had a bad internet connection...
          </v-card-text>
          <v-card-actions>
            <v-btn @click="leave()">OK</v-btn>
            <v-btn @click="saveChatAsImage()">Save Chat</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <v-dialog class="kicked-dialog" v-model="kicked" persistent>
        <v-card id="kicked-card">
          <v-card-text> You are getting kicked for bad behavior. </v-card-text>
        </v-card>
      </v-dialog>

      <v-dialog class="game-over-dialog" v-model="quit" transition="scale-transition" persistent>
        <v-card class="quit-card">
          <v-card-text>
            Are you sure you would like to quit? You will not receive any coins!
          </v-card-text>
          <v-card-actions>
            <v-btn @click="leave()">Yes</v-btn>
            <v-btn @click="quit = false">No</v-btn>
            <v-btn @click="saveChatAsImage()">Save Chat</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <ChatFooter @send="SendMessage" />
    </div>
  </v-app>
</template>

<script setup lang="ts">
import messageBubble from '@/components/MessageBubble.vue'
import ChatFooter from '@/components/ChatFooter.vue'
import ChatHeader from '@/components/ChatHeader.vue'
import { connectionRef, thisPlayer, opponent, room } from '@/scripts/roomController'
import { player, removeCoins, addCoins, addGame, addStrike } from '@/scripts/playerController'
import PlayerCard from '@/components/PlayerCard.vue'
import { ref } from 'vue'
import router from '@/router'
import { FilterService } from '@/scripts/FilterService'
import type { FilteredMessage } from '@/scripts/FilterService'
import html2canvas from 'html2canvas'

const versus = ref(true)
setTimeout(() => {
  versus.value = false
}, 4000)

interface Message {
  messageClass: string
  text: string
}
const messages = ref<Message[]>([])
const htmlElement = ref<HTMLElement | null>(document.querySelector('html'))
let justSent = ''

const connection = connectionRef.value
let disconnected = ref(false)

console.log('You: ' + thisPlayer.value?.ChatRoomId)
console.log('Opponent: ' + thisPlayer.value?.ChatRoomId)

connection?.on('ReceiveMessage', (message: string) => {
  if (message != null && message != '' && message.trim() !== '') {
    if (message != justSent) {
      messages.value.push({ messageClass: 'received-message', text: message })

      if (htmlElement.value) htmlElement.value.scrollTop = htmlElement.value.scrollHeight + 64
    }
  }
})

let totalDetections = 0
const kicked = ref(false)
function SendMessage(message: any) {
  if (message != null && message != '' && message.trim() !== '') {
    let filteredMessage: FilteredMessage = FilterService.filterMessage(message)
    totalDetections += filteredMessage.detections
    console.log(totalDetections)

    if (totalDetections <= 4) {
      connection?.invoke('SendMessageToGroup', room.value, filteredMessage.message)
      console.log(filteredMessage.detections)

      messages.value.push({ messageClass: 'sent-message', text: filteredMessage.message })

      if (htmlElement.value) {
        htmlElement.value.scrollTop = htmlElement.value.scrollHeight + 64
      }

      justSent = filteredMessage.message
    } else {
      addStrike()
      kicked.value = true
      setTimeout(() => {
        kicked.value = false
        totalDetections = 0
        connectionRef.value?.stop()
        router.push('/dashboard')
      }, 4000)
    }
  }
}

connectionRef.value?.on('PlayerDisconnected', () => {
  disconnected.value = true
})

const gameOver = ref(false)
const chatHeader = ref()
let fullTimeUsed = false
function endGame() {
  fullTimeUsed = true
  gameOver.value = true
  addGame()
}
function extendTime() {
  if (removeCoins(1)) {
    connection?.invoke('AddTime', room.value, player.value?.title)
  } else {
    let failed = document.getElementById('failed')
    if (failed) failed.innerHTML = "<p style='color:red;'>Not enough coins!</p>"
  }
}

const timeAdded = ref(false)
let playerAddedTime = ''
connectionRef.value?.on('AddTime', (playerTitle) => {
  playerAddedTime = playerTitle
  timeAdded.value = true
  setTimeout(() => {
    timeAdded.value = false
  }, 3000)
  gameOver.value = false
  chatHeader.value.startTimer(2)
})

const quit = ref(false)
function leave() {
  if (!quit.value) {
    if (fullTimeUsed) {
      addCoins(5 - totalDetections)
    } else {
      addCoins(5 - chatHeader.value.minutesLeft - totalDetections)
    }
  }
  connectionRef.value?.invoke('LeaveRoom', room.value)
  connectionRef.value?.stop()
  router.push('/dashboard/topics')
}
const opponentLeft = ref(false)
connectionRef.value?.on('OpponentLeft', () => {
  gameOver.value = false
  opponentLeft.value = true
})

function saveChatAsImage() {
  const chatElement = document.querySelector('.messages') as HTMLElement
  html2canvas(chatElement).then((canvas) => {
    const link = document.createElement('a')
    link.download = 'chat.png'
    link.href = canvas.toDataURL()
    link.click()
  })
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
.chat {
  padding-top: 6rem;
  padding-bottom: 10rem;
}
.messages {
  display: flex;
  flex-direction: column;
}
.v-dialog {
  width: 50%;
}
.v-dialog .v-card {
  align-items: center;
  text-align: center;
  padding: 1rem;
}
.versus-dialog {
  width: 100%;
}
#versus-card {
  display: flex;
  flex-direction: row;
  padding: 5rem;
  justify-content: center;
}
#versus-card div {
  width: 20rem;
  display: flex;
  flex-direction: column;
  place-items: center;
}
#versus-card h1 {
  margin: 5rem;
}

@media (max-width: 870px) {
  #versus-card {
    flex-direction: column;
  }
  #versus-card h1 {
    margin: 2rem;
  }
}
@media (max-width: 620px) {
  .v-dialog {
    width: 80%;
  }
}
@media (max-width: 360px) {
  .v-dialog {
    width: 90%;
  }
}
</style>
