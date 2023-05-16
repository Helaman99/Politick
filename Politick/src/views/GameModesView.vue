<template>
    <div class = 'gameModes'>
        <div class = 'modeButtons'>
            <v-btn to = 'sides'>Battle Royal</v-btn>
            <v-btn to = 'sides'>Debate</v-btn>
            <v-btn to = 'sides'>Jury</v-btn>
        </div>
        <router-link to = 'topics'>Back</router-link>
    </div>
</template>

<style scoped>

.modeButtons {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    gap: 2rem;
    margin-bottom: 2rem;
}
.modeButtons .v-btn {
    font-size: larger;
    height: 8rem;
}

@media (max-width: 740px) {
    .modeButtons {
        grid-template-columns: 1fr 1fr;
    }
}

@media (max-width: 500px) {
    .modeButtons {
        grid-template-columns: 1fr;
    }
}

</style>