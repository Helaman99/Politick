<template>
    <div class = 'gameModes'>
        <div class = 'buttons'>
            <v-btn>Battle Royal</v-btn>
            <v-btn>Debate</v-btn>
            <v-btn>Jury</v-btn>
        </div>
        <router-link to = 'topics'>Back to Topics</router-link>
    </div>
</template>

<style scoped>

.buttons {
    display: flex;
    justify-content: space-around;
    margin-bottom: 4rem;
}

.v-btn {
    font-size: larger;
    width: 25%;
    height: 8rem;
}

</style>