<template>
    <div class = 'topics'>
        <div class = 'topicButtons'>
            <v-btn to = 'gameModes'>First Topic</v-btn>
            <v-btn to = 'gameModes'>Second Topic</v-btn>
            <v-btn to = 'gameModes'>Third Topic</v-btn>
            <v-btn to = 'gameModes'>Fourth Topic</v-btn>
            <v-btn to = 'gameModes'>Fifth Topic</v-btn>
        </div>
    </div>
</template>

<style scoped>

.topicButtons {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    gap: 2rem;
    margin-bottom: 2rem;
}
.topicButtons .v-btn {
    font-size: larger;
    height: 8rem;
}

@media (max-width: 740px) {
    .topicButtons {
        grid-template-columns: 1fr 1fr;
    }
}

@media (max-width: 500px) {
    .topicButtons {
        grid-template-columns: 1fr;
    }
}

</style>