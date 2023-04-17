<template>
    <div class = 'customize'>
        
        <div class = 'content'>
        
            <div class = 'cardPreview'>
                <playerCard title = 'Fluffy Helicopter' color = 'white' 
                avatar = '/src/assets/avatars/astronaut.jpg' />
            </div>

            <div class = 'customizeOptions'>

                <div class = 'avatarOptions'>
                    <div v-for = 'imageName in avatars' class = 'avatarImage'>
                        <img :src = '"/src/assets/avatars/" + imageName' />
                    </div>
                </div>

                <div class = 'titleOptions'>
                    <v-select :items = firstWords value = 'Fluffy'></v-select>
                    <v-select :items = secondWords value = 'Helicopter'></v-select>
                </div>

            </div>

        </div>

        <v-btn>Save Changes</v-btn>

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
<script>
import playerCard from '../components/PlayerCard.vue'

export default {
    components: {
        playerCard
    },
    data: () => ({
        firstWords: ['Fluffy', 'Bright', 'Inquiring', 'Hopeful'],
        secondWords: ['Helicopter', 'Bunny', 'Battleship', 'Platypus'],
        avatars: ['astronaut.jpg', 'astronaut copy.jpg', 'astronaut copy 2.jpg', 
                    'astronaut copy 3.jpg', 'astronaut copy 4.jpg']
    })
}
</script>
