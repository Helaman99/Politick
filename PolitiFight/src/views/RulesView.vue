<template>
    <div class = "rules">
        
        <h3>Welcome to</h3>
        <img src = "../assets/logos/mainLogo.svg" />
        <br><br>

        <p>
            This is a place for <b>debate</b>, and not just arguing... well, maybe a little
            bit of arguing. In any case, this game was built to encourage people of all
            kinds to come together to <i>discuss</i> and <i>share</i> their ideas and standings.
        </p>
        <p>
            Before you delve into the <strike>hectic</strike> wonderful world of PolitiFight,
            there are some things you should know about how this all works.
        </p>

        <h2>Rules</h2>
        <p>
            There are some rules to this, although there aren't many. However, if you break these
            rules, <i>you will be penalized</i> (more on this later).
        </p>
        <div class = "ruleList">
            <ul>
                <li>No profanity or other offensive language</li>
                <li>Do not send links (I know, but this makes things safer for everyone)</li>
            </ul>
        </div>

        <p>
            If you do not break any of the rules, you will leave every match with 5 additional coins
            that you can spend on in-game items. However, if you do break the rules, you will lose 
            one coin <i>per infraction</i>. If you lose all of your coins, <b>you will be kicked out 
            of the chatroom</b>, and if you were playing the Jury game mode the win will be given to 
            your opponent.
        </p>
        <p>
            If you are kicked out of too many chat rooms, <b>your account will be suspended.</b>
        </p>

        <p>
            Other than that, all I ask is that you show respect to the other person in the chat room.
            Everyone you come across is real, with actual emotions, and are just as dynamic, vibrant,
            and flawed as you. Please show the <i>respect</i> that you wish to be treated with.
        </p>

        <br>
        <v-btn to = 'topics'>Begin</v-btn>

    </div>
</template>

<style scoped>

img {
    width: 90%;
}

p {
    margin-bottom: 1rem;
}

.rules {
    width: 60%;
}

.ruleList {
    text-align: left;
    padding: 1rem 2rem;
    margin-bottom: 1rem;
}

@media (max-width: 600px) {
    .rules {
        width: 85%;
    }
}
</style>