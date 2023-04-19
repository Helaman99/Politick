<template>
    <v-card class = 'playerCard' elevation = '5' :color = color>
        <img :src = avatarPath alt = 'avatar' />
        <v-card-title>{{ title }}</v-card-title>
    </v-card>
</template>

<style scoped>

img {
    width: 75%;
    border-radius: 2%;
    box-shadow: 2px 2px 10px black;
}

.playerCard {
    padding: 1rem 0;
}

</style>
<script lang = 'ts'>
export default {
    props: ['avatarPath', 'title', 'color']
}
</script>