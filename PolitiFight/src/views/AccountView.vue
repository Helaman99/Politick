<template>
    <div class = 'account'>
        
        <div class = 'details'>
            <div class = 'avatar'>
                <v-card class = 'avatarCard' elevation = '5'>
                    <img src = '../assets/avatars/purple_dragon.jpeg' alt = 'avatar' />
                    <v-card-title>Fluffy Helicopter</v-card-title>
                </v-card>
                <br>
                <v-btn>Customize Card</v-btn>
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

img {
    width: 75%;
    border-radius: 2%;
    box-shadow: 2px 2px 5px grey;
}

table {
    font-size: x-large;
    border-spacing: 1rem;
}
td {
    padding-right: 2rem;
}

.avatarCard {
    width: fit-content;
    padding: 1rem 0;
    color: #0099ff;
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
}

.avatarCard {
    width: 50%;
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
    .avatarCard {
        width: auto;
    }
    .accountStats {
        width: 100%;
    }
}

</style>