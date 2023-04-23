<template>
    <div class = "dashboard">

        <headerBar :coinsTotal = player.coinsTotal :kudosTotal = player.kudosTotal
            :standingActual = player.standingActual :avatarPath = pathToAvatars.concat(player.avatar) />
        
        <div class = "dashboard-content">
            <Transition name = "fade">
                <RouterView />
            </Transition>
        </div>
    </div>
</template>

<style>

@media (min-width: 1024px) {
    body {
        display: block;
        padding: 0.3rem 0;
    }
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 1.5s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>

<script lang = 'ts'>
import { player, pathToAvatars } from '../scripts/playerController'
import headerBar from '../components/HeaderBar.vue'

export default {
    components: {
        headerBar
    },
    data() {
        return {
            player,
            pathToAvatars
        }
    }
}
</script>