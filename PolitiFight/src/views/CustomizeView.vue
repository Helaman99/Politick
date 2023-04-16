<template>
    <div class = 'customize'>
        
        <div class = 'content'>
        
            <div class = 'cardPreview'>
                <playerCard title = 'Fluffy Helicopter' color = 'white' 
                avatar = '/src/assets/avatars/astronaut.jpg' />
                <br>
                <v-btn>Save Changes</v-btn>
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

    </div>
</template>

<style scoped>

.content {
    display: flex;
}
.cardPreview {
    width: 60%;
}
.customizeOptions {
    display: flex;
    width: 100%;
}

.avatarOptions {
    width: 50%;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
}
.avatarOptions .avatarImage {
    width: 50%;
}
.avatarOptions .avatarImage img {
    width: 100%;
}

.titleOptions {
    width: 50%;
    display: flex;
    align-items: center;
}
.titleOptions .v-select {
    height: fit-content;
    width: 50%;
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
