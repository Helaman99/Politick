<template>
    <div class = 'sides'>
        <div class = 'sidesButtons'>
            <v-card v-for = 'side in selectedTopic.sides'>
                <v-card-title>{{ side.title }}</v-card-title>
                <v-card-text>{{ side.description }}</v-card-text>
            </v-card>
        </div>
        <router-link to = 'topics'>Back</router-link>
    </div>
</template>

<script lang = 'ts'>
import { selectedTopic } from '@/scripts/topicsController'

export default {
  data: () => {
    return {
        selectedTopic
    }
  }
}
</script>

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