<template>
    <div class = 'titles'>
        <h2>Titles</h2>

        <div class = 'main-content'>

            <div class = 'side' id = 'left'>
                <div class = 'top'>
                    <v-btn @click = 'changePacks(0)' :variant = 'whichDisplay == 0 ? "outlined" : "text"'>
                        Title Packs - First Word
                    </v-btn>
                    <v-btn @click = 'changePacks(1)' :variant = 'whichDisplay == 1 ? "outlined" : "text"'>
                        Title Packs - Second Word
                    </v-btn>
                </div>
                <div class = 'pack-buttons'>
                    <v-btn v-for = 'wordPack in selectedPackList' v-bind:key = "wordPack"
                    @click = 'selectedPack = wordPack'
                    :disabled = '(player?.unlockedTitleFirstWords.includes(wordPack.contents[0])
                                || player?.unlockedTitleSecondWords.includes(wordPack.contents[0]))'>
                        {{ wordPack.name }} 
                    </v-btn>
                </div>
            </div>

            <v-divider vertical />

            <div class = 'side' id = 'right'>
                <div class = 'top'>
                    <p v-if = 'selectedPack'>"{{ selectedPack.name }}" Word Pack</p>
                </div>
                <div v-if = 'selectedPack'>
                    <p v-for = 'word in selectedPack.contents' v-bind:key = 'word'>
                        {{ word }}
                    </p>
                </div> 
                <div class = 'bottom'>
                    <v-btn :disabled = '!selectedPack' @click = 'buyPrompt = true'>Buy Pack</v-btn>
                </div>
            </div>

            <v-dialog class = 'prompt' v-model = 'buyPrompt'>
                <v-card class = 'prompt-card'>
                    <div class = 'prompt-left'>
                        <h3>Words in this pack:</h3>
                        <p v-for = 'word in selectedPack.contents' v-bind:key = 'word'>
                            {{ word }}
                        </p>
                    </div>
                    <v-divider vertical />
                    <div class = 'prompt-right'>
                        <p>
                            Are you sure you would like to buy the "{{ selectedPack.name }}" word 
                            pack for {{ selectedPack.price }} coins?</p>
                        <v-card-actions>
                            <v-btn @click = 'attemptPurchase()'>Yes</v-btn>
                            <v-btn @click = 'buyPrompt = false'>No</v-btn>
                        </v-card-actions>
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

        <router-link to = '/dashboard/shop/'>Back</router-link>
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

const whichDisplay = ref(0)
function changePacks(value: number) {
    if (value == 0) {
        whichDisplay.value = 0
        selectedPackList.value = firstWordPacks.value
    }
    else {
        whichDisplay.value = 1
        selectedPackList.value = secondWordPacks.value
    }
}

const buyPrompt = ref(false)
const success = ref(false)
const failed = ref(false)
function attemptPurchase() {
    switch (whichDisplay.value) {
        case 0: {
            if (purchaseFirstWordPack(selectedPack.value.contents, selectedPack.value.price)) {
                success.value = true
                buyPrompt.value = false
                setTimeout(() => { 
                    success.value = false 
                }, 3000)
                break
            }
            else {
                failed.value = true
                break
            }
        }
        case 1: {
            if (purchaseSecondWordPack(selectedPack.value.contents, selectedPack.value.price)) {
                success.value = true
                buyPrompt.value = false
                setTimeout(() => { 
                    success.value = false 
                }, 3000)
                break
            }
            else {
                failed.value = true
                break
            }
        }
    }
}
</script>

<style scoped>
.main-content{
    display: flex;
    place-content: center;
    margin: 2rem 0;
}
.side {
    display: flex;
    flex-direction: column;
    width: 50%;
}
.side .top {
    margin-bottom: 1rem;
}
.side .bottom {
    margin-top: 2rem;
}
#left .pack-buttons {
    display: grid;
    justify-content: space-around;
    grid-template-columns: 1fr 1fr 1fr;
    gap: 1rem;
}
.v-divider {
    margin: 0 1rem;
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
    text-align: center;
    padding: 1rem;
}
.prompt-card .prompt-right {
    display: flex;
    flex-direction: column;
    text-align: center;
    place-items: center;
    padding: 1rem;
}
.confirmation {
    text-align: center;
}

@media (max-width: 920px) {
    #left .pack-buttons {
        grid-template-columns: 1fr 1fr;
    }
    .prompt {
        width: 75%;
    }
}
@media (max-width: 615px) {
    .main-content {
        flex-direction: column;
    }
    .side {
        width: auto;
        margin-top: 2rem;
    }
    .prompt .prompt-card {
        flex-direction: column;
    }
}
</style>