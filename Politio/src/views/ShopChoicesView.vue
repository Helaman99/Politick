<template>
    <div class = 'choices'>
        <div class = 'shop-choices'>
            <v-card elevation = '3' class = 'shop-choice' to = 'avatars'>
                <v-card-title>Avatars</v-card-title>
            </v-card>
            <v-card elevation = '3' class = 'shop-choice' to = 'titles'>
                <v-card-title>Title Packs</v-card-title>
            </v-card>
            <v-card elevation = '3' class = 'shop-choice' to = 'mystery-boxes'>
                <v-card-title>Mystery Boxes</v-card-title>
            </v-card>
        </div>
    </div>
</template>

<style scoped>
.shop-choices {
    display: flex;
    justify-content: space-around;
}
.shop-choice {
    width: 30%;
    height: 500px;
}
</style>