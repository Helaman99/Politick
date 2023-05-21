<script setup lang = 'ts'>
import { player } from '@/scripts/playerController'
import { ref } from 'vue'
import Axios from 'axios'
                
const firstWordPacks = ref()
const secondWordPacks = ref()
const selectedPack = ref()
Axios.get("https://localhost:7060/Shop/FirstWordPacks")
    .then((response) => {
        firstWordPacks.value = response.data
        selectedPack.value = response.data[0]
    })
    .catch((error) => {
        console.log(error)
    })
Axios.get("https://localhost:7060/Shop/SecondWordPacks")
    .then((response) => {
        secondWordPacks.value = response.data
    })
    .catch((error) => {
        console.log(error)
    })
</script>

<template>
    <div class = 'titles'>
        <router-link to = '/dashboard/shop/'>Back</router-link>
        Titles

        <div class = 'main-content'>

            <div class = 'left-side'>
                <v-btn v-for = 'wordPack in firstWordPacks'
                    @click = 'console.log(wordPack);selectedPack.value = wordPack'
                    :disabled = '(player.unlockedTitleFirstWords.includes(wordPack.contents[0])
                                || player.unlockedTitleSecondWords.includes(wordPack.contents[0]))'>
                    {{ wordPack.name }}
                </v-btn>
            </div>

            <div class = 'right-side' v-if = 'selectedPack'>
                <p v-for = 'word in selectedPack.contents'>
                    {{ word }}
                </p>
            </div>

        </div>
    </div>
</template>


<style scoped>
.main-content{
    display: flex;
    place-content: center;
}
.left-side {
    width: 50%;
}
.right-side {
    width: 50%;
}
</style>