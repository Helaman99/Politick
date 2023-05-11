<template>
    <div class = 'topics'>
        <div class = 'topic-cards'>
            <v-card class = 'topic-card' v-for = 'topic in topics' :img = topic.image
                @click = selectTopic(topic) to = 'sides'>
                <v-card-title>{{ topic.title }}</v-card-title>
            </v-card>
        </div>
    </div>
</template>

<script setup lang = 'ts'>
import { topics } from '@/scripts/chatController'
import { selectTopic } from '@/scripts/chatController'
</script>

<style scoped>
.topic-cards {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    gap: 2rem;
    margin-bottom: 2rem;
}
.topic-cards .topic-card {
    font-size: larger;
    height: 12rem;
}

@media (max-width: 740px) {
    .topic-cards {
        grid-template-columns: 1fr 1fr;
    }
}

@media (max-width: 500px) {
    .topic-cards {
        grid-template-columns: 1fr;
    }
}
</style>