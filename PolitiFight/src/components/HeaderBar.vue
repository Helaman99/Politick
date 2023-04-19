<template>
    <div class = 'headerBar'>
        <h1>Welcome back user!</h1>
        <div id = "userStats">
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
}

#userStats {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
}
#standing {
    margin-top: 1rem;
}
</style>
<script lang = 'ts'>
export default {
    props: ['totalCoins', 'totalWins', 'standingActual']
}
</script>