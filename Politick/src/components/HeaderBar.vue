<template>
    <div class = 'headerBar'>

        <v-card>
            <v-layout>
                <v-app-bar elevation = '3' height = '75' color = 'white'>
                    
                    <template v-slot:prepend>
                        <v-app-bar-nav-icon @click.stop="navigation = !navigation" elevation = '2'>
                            <img class = 'menu-icon' :src = '"https://localhost:7060/Shop/Avatar" + player.avatar'>
                        </v-app-bar-nav-icon>
                        <div id = "user-stats">
                            <p>Coins: {{ player.coins }}</p>
                            <p>Kudos: {{ player.kudos }}</p>
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
                            <router-link to = '/dashboard/account' @click = 'navigation = false'>
                                Account
                            </router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = '/dashboard/topics/' @click = 'navigation = false'>
                                Play
                            </router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = '/dashboard/customize' @click = 'navigation = false'>
                                Customize Player Card
                            </router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = '/dashboard/shop/' @click = 'navigation = false'>
                                Shop
                            </router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = '../privacy-policy' @click = 'navigation = false' target = '_blank'>
                                Privacy Policy
                            </router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = '../terms-of-service' @click = 'navigation = false' target = '_blank'>
                                Terms of Service
                            </router-link>
                        </v-list-item>
                        <v-list-item>
                            <v-btn @click = 'logOut()' variant = 'text'>
                                Log Out
                            </v-btn>
                        </v-list-item>
                    </v-list-item-group>
                </v-navigation-drawer>

                <v-navigation-drawer location = 'right' style = "padding-top:0.5rem;" v-model="settings" elevation = '1'>
                    <v-list-item-group>
                        <v-list-item>
                            <v-list-item-title>Theme</v-list-item-title>
                            <div class = 'two-choices'>
                                <v-btn color = 'white' @click = 'setLight'>Light</v-btn>
                                <v-btn color = 'black' @click = 'setDark'>Dark</v-btn>
                            </div>
                        </v-list-item>
                    </v-list-item-group>
                </v-navigation-drawer>

            </v-layout>
        </v-card>
        
    </div>
</template>

<script setup lang = 'ts'>
import { SignInService } from '@/scripts/SignInService'
import { player } from '../scripts/playerController'
import { ref } from 'vue'
import router from '@/router'

const navigation = ref(false)
const settings = ref(false)

function logOut() {
    SignInService.instance.signOut()
    router.push('/login')
}

function setLight() {
    // Set the theme to light
    player.value.theme = 'light'
}
function setDark() {
    // Set the theme to dark
    player.value.theme = 'dark'
}
</script>

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
