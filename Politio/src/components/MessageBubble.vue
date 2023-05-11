<template>
    <v-card :class = class elevation = '0'>
        <v-card-title>{{ text }}</v-card-title>
    </v-card>
</template>

<script lang = 'ts'>
export default {
    props: ["class", "text"]
}
</script>

<style scoped>
.v-card {
    max-width: 49%;
    margin: 0.5rem;
}
.received-message {
    background-color: gainsboro;
    color: black;
    align-self: flex-start;
}
.sent-message {
    background-color: lightskyblue;
    color: black;
    align-self: flex-end;
}
</style>