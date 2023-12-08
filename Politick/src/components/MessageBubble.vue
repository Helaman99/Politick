<template>
  <v-card :class="messageClass" elevation="0">
    <v-card-text>{{ text }}</v-card-text>
  </v-card>
</template>

<script lang="ts">
export default {
  props: ['messageClass', 'text']
}
</script>

<style scoped>
.v-card {
  max-width: 49%;
  margin: 0.5rem;
}
.v-card-text {
  font-size: large;
  white-space: pre-wrap;
}
.received-message {
  background-color: gainsboro;
  color: black;
  align-self: flex-start;
  text-align: start;
}
.sent-message {
  background-color: lightskyblue;
  color: black;
  align-self: flex-end;
  text-align: start;
}

@media (max-width: 870px) {
  .v-card {
    max-width: 80%;
  }
}
</style>
