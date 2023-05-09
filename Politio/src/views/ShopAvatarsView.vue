<template>
    <div class = 'avatars'>
        <h2>Avatars</h2>
        <router-link to = '/dashboard/shop/'>Back</router-link>

        <div class = 'Options'>
            <div class = "Option" v-for = 'name in avatarList'>
                <img :src = pathToAvatars.concat(name) />
            </div>
        </div>
        <div class = 'Options'>
            <div class = 'Option' v-for = 'box in mysteryBoxes'>
                <img :src = 'pathToMysteryBoxes.concat(box.name) + ".jpg"' />
                <h3>{{ box.name }}</h3>
            </div>
        </div>
    </div>
</template>

<script setup lang = 'ts'>
//import shop from '@/scripts/shopController'
import Axios from 'axios'
import { ref } from 'vue'
import { pathToAvatars } from '@/scripts/playerController'
import { pathToMysteryBoxes } from '@/scripts/shopController'

const avatarList = ref<string[]>([])
const mysteryBoxes = ref()

Axios.get('https://localhost:7060/Shop/Avatars')
                    .then((response) => {
                        avatarList.value = response.data
                        console.log(response.data)
                    })
                    .catch((err) => {
                        console.log(err)
                    })
Axios.get('https://localhost:7060/Shop/AvatarMysteryBoxes')
                    .then((response) => {
                        mysteryBoxes.value = response.data
                        console.log(response.data)
                    })
                    .catch((err) => {
                        console.log(err)
                    })
</script>

<style scoped>
.Options {
    width: 50%;
    height: 50%;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    justify-items: center;
    align-items: center;
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
</style>