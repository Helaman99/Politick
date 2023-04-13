<template>
    <div class = 'roomSize'>
        <div class = 'roomButtons'>
            <v-btn>1v1</v-btn>
            <v-btn>2v2</v-btn>
        </div>
        <router-link to = 'sides'>Back</router-link>
    </div>
</template>

<style scoped>

.roomButtons {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 2rem;
    margin-bottom: 2rem;
}
.roomButtons .v-btn {
    font-size: larger;
    height: 8rem;
}

@media (max-width: 740px) {
    .roomButtons {
        grid-template-columns: 1fr 1fr;
    }
}

@media (max-width: 500px) {
    .roomButtons {
        grid-template-columns: 1fr;
    }
}

</style>