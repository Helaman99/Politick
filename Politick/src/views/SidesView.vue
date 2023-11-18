<template>
  <div class="sides">
    <div class="sidesButtons">
      <v-card
        v-for="(side, index) in topics[selectedTopic].sides"
        v-bind:key="index"
        @click="chooseSide(index, side.standings)"
      >
        <v-card-title no-wrap>{{ side.title }}</v-card-title>
        <v-card-text>{{ side.description }}</v-card-text>
      </v-card>
    </div>
    <router-link to="topics">Back</router-link>

    <v-dialog v-model="disclaimer" persistent transition="scale-transition">
      <v-card class="disclaimer-card">
        <v-card-title><h2 style="color: red">DISCLAIMER!!</h2></v-card-title>
        <v-card-text>
          Interactions in these chatrooms may not be appropriate for all ages. We do everything we
          can to filter out inappropriate or offensive language. However, we are not perfect and
          can't catch everything. By participating in this game, you may encounter things that are
          offensive. If this happens,
          <i>please</i> let us know at politickgame@protonmail.com.
        </v-card-text>
        <v-card-actions>
          <v-btn elevation="1" @click="FindRoom()">I Understand</v-btn>
          <v-btn elevation="1" @click="disclaimer = false">Go Back</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-dialog id="loading-dialog" v-model="loading" persistent transition="scale-transition">
      <v-card class="loading-card">
        <v-card-title>Finding opponent...</v-card-title>
        <v-btn variant="text" loading />
        <v-btn variant="text" @click="back()">Back</v-btn>
      </v-card>
    </v-dialog>

    <v-dialog id="failed-dialog" v-model="failed" transition="scale-transition">
      <v-card class="failed-card">
        <v-card-title color="red">Huh, something went wrong!</v-card-title>
        <v-card-text>
          Sorry about that, but there was a problem with joining a chat room. If this error
          persists, please contact support.
        </v-card-text>
        <v-btn @click="failed = false">OK</v-btn>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup lang="ts">
import {
  topics,
  selectedTopic,
  selectSide,
  startConnection,
  room,
  connectionRef
} from '@/scripts/roomController'
import { ref } from 'vue'

let disclaimer = ref(false)
let loading = ref(false)
let failed = ref(false)

function chooseSide(index: number, sides: string[]) {
  disclaimer.value = true
  selectSide(index, sides)
}

function FindRoom() {
  disclaimer.value = false
  loading.value = true
  if (!startConnection()) failed.value = true
}

function back() {
  connectionRef.value?.invoke('LeaveRoom', room.value).then(() => {
    connectionRef.value?.stop()
    loading.value = false
  })
}
</script>

<style scoped>
.sidesButtons {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  gap: 2rem;
  margin-bottom: 2rem;
}
.sidesButtons .v-card .v-card-title {
  white-space: pre-wrap;
}
.sidesButtons .v-btn {
  font-size: larger;
  height: 8rem;
}
.disclaimer-card {
  align-items: center;
  text-align: center;
  padding: 1rem;
}
.v-dialog {
  width: 50%;
}
#loading-dialog {
  width: 25%;
  align-items: center;
  text-align: center;
}
#failed-dialog {
  text-align: center;
}

@media (max-width: 870px) {
  .sidesButtons {
    grid-template-columns: 1fr 1fr;
  }
  .v-dialog {
    width: 65%;
  }
}

@media (max-width: 500px) {
  .sidesButtons {
    grid-template-columns: 1fr;
  }
  .v-dialog {
    width: 95%;
  }
}
</style>
