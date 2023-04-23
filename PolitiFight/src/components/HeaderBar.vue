<template>
    <div class = 'headerBar'>

        <v-card>
            <v-layout>
                <v-app-bar elevation = '3' height = '75' color = 'white'>
                    
                    <template v-slot:prepend>
                        <v-app-bar-nav-icon @click.stop="navigation = !navigation" elevation = '2'>
                            <img class = 'menu-icon' :src = avatarPath>
                        </v-app-bar-nav-icon>
                        <div id = "user-stats">
                            <p>Coins: {{ coinsTotal }}</p>
                            <p>Kudos: {{ kudosTotal }}</p>
                        </div>
                    </template>

                    

                    <template v-slot:append>
                        <v-app-bar-nav-icon @click.stop="settings = !settings">
                            <v-icon size = 'x-large'>mdi-cog-outline</v-icon>
                        </v-app-bar-nav-icon>
                    </template>

                </v-app-bar>

                <v-navigation-drawer style = "padding-top:0.5rem;" v-model="navigation" elevation = '1'>
                    <v-list-item-group>
                        <v-list-item>
                            <router-link to = 'account' @click = 'navigation = false'>Account</router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = 'topics' @click = 'navigation = false'>Play</router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = 'customize' @click = 'navigation = false'>Customize Player Card</router-link>
                        </v-list-item>
                    </v-list-item-group>
                </v-navigation-drawer>

                <v-navigation-drawer location = 'right' style = "padding-top:0.5rem;" v-model="settings" elevation = '1'>
                    <v-list-item-group>
                        <v-list-item>
                            <v-list-item-title>Theme</v-list-item-title>
                            <div class = 'two-choices'>
                                <v-btn color = 'white'>Light</v-btn>
                                <v-btn color = 'black'>Dark</v-btn>
                            </div>
                        </v-list-item>
                    </v-list-item-group>
                </v-navigation-drawer>
            </v-layout>
        </v-card>
        
    </div>
</template>
<style scoped>
.headerBar {
    margin-bottom: 5rem;
    z-index: 1;
}
.v-app-bar-nav-icon {
    margin: 2.5rem;
}

.menu-icon {
    width: 100%;
    border-radius: 50%;
}
.two-choices {
    display: flex;
    justify-content: space-around;
    padding: 1rem;
}

#standing {
    margin-top: 1rem;
}
</style>
<script lang = 'ts'>
export default {
    props: ['coinsTotal', 'kudosTotal', 'standingActual', 'avatarPath'],
    data: () => ({
        navigation: false,
        settings: false
    })
}
</script>