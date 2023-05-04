<template>
    <div class = 'avatars'>
        <h2>Avatars</h2>
        <router-link to = '/dashboard/shop/'>Back</router-link>

        <div class = 'avatarOptions'>
            <div class = "avatarImage" v-for = 'name in avatarList'>
                <img :src = pathToAvatars.concat(name)>
            </div>
        </div>
    </div>
</template>

<script setup lang = 'ts'>
//import shop from '@/scripts/shopController'
import Axios from 'axios'
import { ref } from 'vue'
import { pathToAvatars } from '@/scripts/playerController'

const avatarList = ref<string[]>([])

Axios.get('https://localhost:7060/Shop/GetAvatars')
                    .then((response) => {
                        avatarList.value = response.data
                        console.log(response.data)
                    })
                    .catch((err) => {
                        console.log(err)
                    })
</script>

<style scoped>
.avatarOptions {
    width: 50%;
    height: 50%;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    justify-items: center;
    align-items: center;
}
.avatarOptions .avatarImage {
    width: 80%;
    padding: 3%;
    transition-duration: 0.25s;
}
.avatarOptions .avatarImage:hover {
    padding: 0;
}
.avatarOptions .avatarImage:active {
    padding: 3%;
}
.avatarOptions .avatarImage img {
    width: 100%;
    border-radius: 5%;
    display: block;
    transition-duration: 0.25s;
}
.avatarOptions .avatarImage img:hover {
    box-shadow: 1px 1px 5px black;
}
</style>