<template>
    <div class = 'headerBar'>

        <v-card>
            <v-layout>
                <v-app-bar elevation = '3' density = 'prominent' color = 'white'>
                    
                    <template v-slot:prepend>
                        <v-app-bar-nav-icon @click.stop="drawer = !drawer" elevation = '2'>
                            <img class = 'menu-icon' :src = avatarPath>
                        </v-app-bar-nav-icon>
                    </template>

                </v-app-bar>

                <v-navigation-drawer style = "padding-top:0.5rem;" v-model="drawer" elevation = '1'>
                    <v-list-item-group>
                        <v-list-item>
                            <router-link to = 'account' @click = 'drawer = false'>Account</router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = 'topics' @click = 'drawer = false'>Play</router-link>
                        </v-list-item>
                        <v-list-item>
                            <router-link to = 'customize' @click = 'drawer = false'>Customize Player Card</router-link>
                        </v-list-item>
                    </v-list-item-group>
                </v-navigation-drawer>
            </v-layout>
        </v-card>

        <div id = "user-stats">
            <p>Total Coins</p><p>Total Wins</p><p>Typical Standing</p>
            <h1>{{ totalCoins }}</h1><h1>{{ totalWins }}</h1>
            <div id = "standing">
                {{ standingActual }}
            </div>
        </div>
    </div>
</template>
<style scoped>
.headerBar {
    margin-bottom: 4rem;
    z-index: 1;
}
.v-app-bar-nav-icon {
    margin: 2.5rem;
}

.menu-icon {
    width: 100%;
    border-radius: 50%;
}

#user-stats {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    position: fixed;
    width: 80%;
}
#standing {
    margin-top: 1rem;
}

@media (max-width: 1280px) {
    #user-stats {
        left: 50%;
        transform: translateX(-50%);
    }
}
</style>
<script lang = 'ts'>
export default {
    props: ['totalCoins', 'totalWins', 'standingActual', 'avatarPath'],
    data: () => ({
        drawer: false
    })
}
</script>