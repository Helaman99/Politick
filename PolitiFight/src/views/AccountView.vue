<template>
    <div class = 'account'>
        
        <div class = 'details'>
            <div class = 'avatar'>
                <playerCard title = 'Fluffy Helicopter' color = 'white' 
                    avatar = '/src/assets/avatars/astronaut.jpg' />
                <br>
                <v-btn to = 'customize'>Customize Card</v-btn>
            </div>

            <div class = 'accountStats'>
                <table>
                    <tr>
                        <td>Total Games Played:</td><td>17</td>
                    </tr>
                    <tr>
                        <td>Favorite Game Mode:</td><td>Battle Royal</td>
                    </tr>
                    <tr>
                        <td>Total Coins Earned:</td><td>230</td>
                    </tr>
                    <tr>
                        <td>Account Strikes:</td><td>0</td>
                    </tr>
                </table>
            </div>
        </div>

        <br>
        <v-btn color = 'red'>Delete Account</v-btn>

    </div>
</template>

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
<script>
import playerCard from '../components/PlayerCard.vue'

export default {
    components: {
        playerCard
    }
}
</script>