<template>
  <div class="topics">
    <div class="topic-cards">
      <v-card
        class="topic-card"
        v-for="(topic, index) in topics"
        :img="topic.image"
        v-bind:key="index"
        @click="selectTopic(index)"
        to="/dashboard/sides"
      >
        <v-card-title>{{ topic.title }}</v-card-title>
        <v-card-text>{{ topic.description }}</v-card-text>
      </v-card>
    </div>

    <div id="rooms-in-progress">{{ currDebates }} debates in progress</div>
  </div>
</template>

<script setup lang="ts">
import { topics, selectTopic } from '@/scripts/roomController'
import { ref } from 'vue'
import Axios from 'axios'

const currDebates = ref(0)
Axios.get('/Chat/DebatesInProgress')
  .then((response) => {
    currDebates.value = response.data
    console.log('Rooms: ' + currDebates.value)
  })
  .catch((error) => {
    console.log(error)
  })
</script>

<style scoped>
.topic-cards {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 2rem;
  margin-bottom: 2rem;
}
.topic-cards .topic-card {
  font-size: larger;
  height: 12rem;
}

@media (max-width: 740px) {
  .topic-cards {
    grid-template-columns: 1fr 1fr;
  }
}

@media (max-width: 500px) {
  .topic-cards {
    grid-template-columns: 1fr;
  }
}
</style>
