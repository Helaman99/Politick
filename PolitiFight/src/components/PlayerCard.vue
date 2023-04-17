<template>
    <v-card class = 'playerCard' elevation = '5' :color = color>
        <img :src = avatar alt = 'avatar' />
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
<script>
export default {
    props: ['avatar', 'title', 'color']
}
</script>