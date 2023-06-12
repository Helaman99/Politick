<template>
  <v-card class="playerCard" elevation="5" :color="color">
    <img :src="Axios.defaults.baseURL + '/Shop/Avatar' + avatarPath" alt="avatar" />
    <v-card-title>{{ title }}</v-card-title>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios'
defineProps(['avatarPath', 'title', 'color'])
</script>

<style scoped>
img {
  width: 75%;
  border-radius: 2%;
  box-shadow: 1px 1px 4px gray;
}

.playerCard {
  padding: 1rem 0;
}
</style>
