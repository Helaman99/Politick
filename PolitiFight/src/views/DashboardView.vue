<template>
    <div class = "dashboard">

        <header>
            <h1>Welcome back user!</h1>
            <div id = "userStats">
                <p>Total Coins</p><p>Total Wins</p><p>Typical Standing</p>
                <h1>{{ player.totalCoins }}</h1><h1>{{ player.totalWins }}</h1>
                <div id = "standing">
                    {{ player.standingActual }}
                </div>
            </div>
        </header>
        
        <Transition name = "fade">
            <RouterView />
        </Transition>
    </div>
</template>

<style>
@media (min-width: 1024px) {
    body {
        display: block;
        padding: 0.3rem 0;
    }
}

header {
    margin-bottom: 4rem;
}

#userStats {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
}
#standing {
    margin-top: 1rem;
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
import { player } from '../scripts/playerController'
export default {
    data() {
        return {
            player
        }
    }
}
</script>