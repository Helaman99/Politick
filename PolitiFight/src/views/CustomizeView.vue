<template>
    <div class = 'customize'>
        
        <div class = 'content'>
        
            <div class = 'cardPreview'>
                <playerCard :title = 'titleSplit.join(" ")' color = 'white' 
                    :avatarPath = pathToAvatars.concat(currAvatar) />
            </div>

            <div class = 'customizeOptions'>

                <div class = 'avatarOptions'>
                    <div v-for = 'imageName in player.unlockedAvatars' class = 'avatarImage'>
                        <img :src = pathToAvatars.concat(imageName) @click = 'currAvatar = imageName' />
                    </div>
                </div>

                <div class = 'titleOptions'>
                    <v-select id = 'first-word' :items = player.unlockedTitleFirstWords 
                        :value = 'player.title.split(" ")[0]'></v-select>
                    <v-select id = 'second-word' :items = player.unlockedTitleSecondWords 
                        :value = 'player.title.split(" ")[1]'></v-select>
                </div>
            </div>

        </div>

        <v-btn @click = 'save()'>Save Changes</v-btn>

    </div>
</template>

<style scoped>

.content {
    display: flex;
    padding-bottom: 3rem;
}
.cardPreview {
    width: 50%;
    padding-right: 3rem;
    padding-left: 3rem;
}
.customizeOptions {
    display: flex;
    width: 100%;
}

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

.titleOptions {
    width: 50%;
    display: flex;
    align-items: center;
    padding: 5%;
}
.titleOptions .v-select {
    height: fit-content;
    width: 50%;
}

@media (max-width: 1024px) {
    .cardPreview {
        width: 100%;
    }
    .customizeOptions {
        flex-direction: column;
    }
    .avatarOptions {
        width: 100%;
        margin-bottom: 3rem;
    }
    .titleOptions {
        width: 100%;
    }
}

@media (max-width: 740px) {
    .content {
        flex-direction: column;
    }
    .cardPreview {
        margin-bottom: 3rem;
    }
}

</style>
<script lang = 'ts'>
import playerCard from '../components/PlayerCard.vue'
import { player, updatePlayer, pathToAvatars } from '../scripts/playerController'

let titleSplit = player.title.split(" ")
let currAvatar = player.avatar

export default {
    components: {
        playerCard
    },
    methods: {
        save() {
            console.log("Saving new player data...")
            updatePlayer(currAvatar, titleSplit.join(" "))
        }
    },
    data() {
        return {
            player,
            pathToAvatars,
            titleSplit,
            currAvatar
        }
    }
}
</script>
