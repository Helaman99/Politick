<template>
    <div class = "dashboard">

        <header>
            <h1>Welcome back user!</h1>
            <div id = "userStats">
                <p>Total Credits</p><p>Total Wins</p><p>Typical Standing</p>
                <h1>56</h1><h1>3</h1>
                <div id = "standing">
                    <v-slider id = "standingSlider" v-model = "standing" :color = "color"
                        step = "1" max = "4" ticks = "true">
                        <template v-slot:prepend>
                            <h3 style = "color:#2196F3;">Left</h3>
                        </template>
                        <template v-slot:append>
                            <h3 style = "color:#F44336;">Right</h3>
                        </template>
                    </v-slider>
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
        padding: 2rem 0;
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

<script>
export default {
    data: () => ({
      standing: 0,
    }),
    computed: {
      color () {
        if (this.standing == 0) return '#2196F3'
        if (this.standing == 1) return '#536DFE'
        if (this.standing == 2) return '#9C27B0'
        if (this.standing == 3) return '#FF4081'
        return '#F44336'
      }
    }
}
</script>