<template>
    <div class = 'sides'>
        <div class = 'sidesButtons'>
            <v-btn>Authoritarian</v-btn>
            <v-btn>Left</v-btn>
            <v-btn>Libertarian</v-btn>
            <v-btn>Right</v-btn>
        </div>
        <router-link to = 'gameModes'>Back</router-link>
    </div>
</template>

<style scoped>

.sidesButtons {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    gap: 2rem;
    margin-bottom: 2rem;
}
.sidesButtons .v-btn {
    font-size: larger;
    height: 8rem;
}

@media (max-width: 870px) {
    .sidesButtons {
        grid-template-columns: 1fr 1fr;
    }
}

@media (max-width: 500px) {
    .sidesButtons {
        grid-template-columns: 1fr;
    }
}

</style>