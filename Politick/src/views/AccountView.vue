<template>
    <div class = 'account'>
        
        <div class = 'details'>
            <div class = 'avatar'>
                <playerCard :title = player?.title color = 'white' 
                    :avatarPath = player?.avatar />
                <br>
                <v-btn to = 'customize'>Customize Card</v-btn>
            </div>

            <div class = 'accountStats'>
                <table>
                    <tr>
                        <td>Total Games Played:</td><td>{{ player?.lifetimeGames }}</td>
                    </tr>
                    <tr>
                        <td>Typical Standing:</td><td>{{ player?.standingActual }}</td>
                    </tr>
                    <tr>
                        <td>Lifetime Kudos Earned:</td><td>{{ player?.lifetimeKudos }}</td>
                    </tr>
                    <tr>
                        <td>Account Strikes:</td><td>{{ player?.strikes }}</td>
                    </tr>
                </table>
            </div>
        </div>

        <br>
        <v-btn color = 'red'>Delete Account</v-btn>

    </div>
</template>

<script setup lang = 'ts'>
import playerCard from '@/components/PlayerCard.vue'
import { player } from '@/scripts/playerController'
</script>

<style scoped>

table {
    font-size: x-large;
    border-spacing: 1rem;
}
td {
    padding-right: 2rem;
}

.details {
    display: flex;
    align-items: center;
}

.accountStats {
    width: 50%;
}

.avatar {
    width: 50%;
    padding-right: 12%;
    padding-left: 12%;
}

@media (max-width: 760px) {
    .details {
        flex-direction: column;
        padding: none;
    }
    .avatar {
        width: 100%;
        margin-bottom: 2rem;
    }
    .playerCard {
        width: auto;
    }
    .accountStats {
        width: 100%;
    }
}

</style>