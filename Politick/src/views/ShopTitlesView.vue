<template>
    <div class = 'titles'>
        <router-link to = '/dashboard/shop/'>Back</router-link>
        Titles

        <div class = 'main-content'>

            <div class = 'left-side'>
                <v-btn @click = 'changePacks()'>{{ packsDisplay }}</v-btn>
                <div class = 'pack-buttons'>
                    <v-btn v-for = 'wordPack in selectedPackList'
                    @click = 'selectedPack = wordPack'
                    :disabled = '(player.unlockedTitleFirstWords.includes(wordPack.contents[0])
                                || player.unlockedTitleSecondWords.includes(wordPack.contents[0]))'>
                        {{ wordPack.name }} 
                    </v-btn>
                </div>
            </div>

            <div class = 'right-side'>
                <v-btn @click = 'buyPrompt = true'>Buy Pack</v-btn>
                <p v-if = 'selectedPack' v-for = 'word in selectedPack.contents'>
                    {{ word }}
                </p>
            </div>

            <v-dialog class = 'prompt' v-model = 'buyPrompt'>
                <v-card class = 'prompt-card'>
                    <div class = 'prompt-left'>
                        <h3>Words in this pack:</h3>
                        <p v-for = 'word in selectedPack.contents'>
                            {{ word }}
                        </p>
                    </div>
                    <div class = 'prompt-right'>
                        <p>
                            Are you sure you would like to buy the {{ selectedPack.name }} word 
                            pack for {{ selectedPack.price }} coins?</p>
                        <v-card-cations>
                            <v-btn @click = 'attemptPurchase()'>Yes</v-btn>
                            <v-btn @click = 'buyPrompt = false'>No</v-btn>
                        </v-card-cations>
                    </div>
                </v-card>
            </v-dialog>

            <v-dialog class = 'confirmation' v-model = 'success' width = 'fit-content'>
            <v-card>
                <v-card-title>Item purchased successfully!</v-card-title>
                <v-card-text>You can go to your Customization page and put it on your Player Card!</v-card-text>
            </v-card>
            </v-dialog>
            <v-dialog class = 'confirmation' v-model = 'failed' width = 'fit-content'>
                <v-card>
                    <v-card-title>Huh, something went wrong...</v-card-title>
                    <v-card-text>If this issue persists, please contact support.</v-card-text>
                </v-card>
            </v-dialog>

        </div>
    </div>
</template>

<script setup lang = 'ts'>
import { player } from '@/scripts/playerController'
import { ref } from 'vue'
import Axios from 'axios'
import { purchaseFirstWordPack, purchaseSecondWordPack } from '@/scripts/shopController'
                
const firstWordPacks = ref()
const secondWordPacks = ref()
const selectedPackList = ref()
const selectedPack = ref()
Axios.get("https://localhost:7060/Shop/FirstWordPacks")
    .then((response) => {
        firstWordPacks.value = response.data
        selectedPackList.value = firstWordPacks.value
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

const packsDisplay = ref('Title Packs - First Word')
let whichDisplay = 0
function changePacks() {
    if (whichDisplay == 0) {
        whichDisplay = 1
        packsDisplay.value = 'Title Packs - Second Word'
        selectedPackList.value = secondWordPacks.value
    }
    else {
        whichDisplay = 0
        packsDisplay.value = 'Title Packs - First Word'
        selectedPackList.value = firstWordPacks.value
    }
}

const buyPrompt = ref(false)
const success = ref(false)
const failed = ref(false)
function attemptPurchase() {
    switch (whichDisplay) {
        case 0: {
            if (purchaseFirstWordPack(selectedPack.value.contents, selectedPack.value.price)) {
                success.value = true
                buyPrompt.value = false
                setTimeout(() => { 
                    success.value = false 
                }, 3000)
            }
            else
                failed.value = true
        }
        case 1: {
            if (purchaseSecondWordPack(selectedPack.value.contents, selectedPack.value.price)) {
                success.value = true
                buyPrompt.value = false
                setTimeout(() => { 
                    success.value = false 
                }, 3000)
            }
            else
                failed.value = true
        }
    }
}
</script>

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

.prompt {
    width: 50%;
}
.prompt .prompt-card {
    display: flex;
    flex-direction: row;
    place-items: center;
    padding: 1rem;
}
.prompt-card .prompt-left {
    min-width: 50%;
    margin-right: 1rem;
    border-right: 1px solid lightgray;
    text-align: center;
    padding: 1rem;
}
.prompt-card .prompt-right {
    text-align: center;
    padding: 1rem;
}
.confirmation {
    text-align: center;
}
</style>