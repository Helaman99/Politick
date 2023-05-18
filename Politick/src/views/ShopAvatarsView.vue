<template>
    <div class = 'avatars'>
        <h2>Avatars</h2>
        <router-link to = '/dashboard/shop/'>Back</router-link>

        <h4>Basic Avatars</h4>
        <div class = 'Options'>
            <div class = "Option" v-for = 'avatar in basicAvatarFileNames' @click = selectBasicAvatar(avatar)>
                <img :src = '"https://localhost:7060/Shop/Avatar/Basic/" + avatar' />
            </div>
        </div>
        <br><br>
        <h4>Premium Avatars</h4>
        <div class = 'Options'>
            <div class = "Option" v-for = 'avatar in premiumAvatarFileNames' @click = selectPremiumAvatar(avatar)>
                <img :src = '"https://localhost:7060/Shop/Avatar/Premium/" + avatar' />
            </div>
        </div>
        <!-- <div class = 'Options'>
            <div class = 'Option' v-for = 'box in mysteryBoxes'>
                <img :src = 'pathToMysteryBoxes.concat(box.name) + ".jpg"' />
                <h3>{{ box.name }}</h3>
            </div>
        </div> -->
        <v-dialog v-model = 'basicPrompt' class = 'prompt'>
            <v-card class = 'prompt-card'>
                <div class = 'prompt-left'>
                    <img :src = '"https://localhost:7060/Shop/Avatar/Basic/" + selectedAvatar' />
                </div>
                <div class = 'prompt-right'>
                    <p>Are you sure you wish to buy this avatar?</p>
                    <v-card-actions>
                        <v-btn>Yes</v-btn><v-btn @click = 'basicPrompt = !basicPrompt'>No</v-btn>
                    </v-card-actions>
                </div>
            </v-card>
        </v-dialog>
        <v-dialog v-model = 'premiumPrompt' class = 'prompt'>
            <v-card class = 'prompt-card'>
                <div class = 'prompt-left'>
                    <img :src = '"https://localhost:7060/Shop/Avatar/Premium/" + selectedAvatar' />
                </div>
                <div class = 'prompt-right'>
                    <p>Are you sure you wish to buy this premium avatar?</p>
                    <v-card-actions>
                        <v-btn>Yes</v-btn><v-btn @click = 'premiumPrompt = !premiumPrompt'>No</v-btn>
                    </v-card-actions>
                </div>
            </v-card>
        </v-dialog>
    </div>
</template>

<script setup lang = 'ts'>
import Axios from 'axios'
import { ref, onMounted } from 'vue'
import { pathToAvatars } from '@/scripts/playerController'
import { basicAvatarFileNames, premiumAvatarFileNames } from '@/scripts/shopController'

const mysteryBoxes = ref()
const basicPrompt = ref(false)
const premiumPrompt = ref(false)
const selectedAvatar = ref('')

function selectBasicAvatar(avatar: string) {
    selectedAvatar.value = avatar
    basicPrompt.value = true
}
function selectPremiumAvatar(avatar: string) {
    selectedAvatar.value = avatar
    premiumPrompt.value = true
}
    
</script>

<style scoped>
.Options {
    width: 75%;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    place-items: center;
}
.Options .Option {
    width: 80%;
    padding: 3%;
    transition-duration: 0.25s;
}
.Options .Option:hover {
    padding: 0;
}
.Options .Option:active {
    padding: 3%;
}
.Options .Option img {
    width: 100%;
    border-radius: 5%;
    display: block;
    transition-duration: 0.25s;
}
.Options .Option img:hover {
    box-shadow: 1px 1px 5px black;
}

.prompt {
    width: 50%;
}
.prompt .prompt-card {
    display: flex;
    flex-direction: row;
    place-items: center;
    padding: 2rem;
}
.prompt-card .prompt-left {
    width: 50%;
    margin-right: 1rem;
}
.prompt-card .prompt-left img {
    width: 100%;
    border-radius: 5%;
}
.prompt-card .prompt-right {
    display: flex;
    flex-direction: column;
    text-align: center;
    place-items: center;
}

@media (max-width: 940px) {
    .Options {
        width: 90%;
        grid-template-columns: 1fr 1fr 1fr;
    }
    .prompt {
        width: 75%;
    }
}
@media (max-width: 500px) {
    .Options {
        width: 100%;
        grid-template-columns: 1fr 1fr;
    }
    .prompt .prompt-card {
        flex-direction: column;
    }
    .prompt .prompt-card .prompt-left {
        margin: 0;
        width: 90%;
    }
}
</style>