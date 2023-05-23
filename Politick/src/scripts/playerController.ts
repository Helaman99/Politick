import { Player } from './Player'
import { ref } from 'vue'
import Axios from 'axios'

// Code to retrieve player data from backend/database

// Create a player object with the player's data from the database

const player = ref<Player>(new Player(
    1,
    'Happy Banana',
    '/Premium/astronaut.jpg',
    100,
    0,
    0,
    0,
    [0, 0, 0],
    0,
    0,
    0,
    0,
    ['Happy', 'Sad', 'Wrinkly', 'Bloated'],
    ['Helicopter', 'Banana', 'Sasquatch', 'Bunny', 'Marshmallow', 'Tank', 'Goldfish'],
    ['/Premium/astronaut.jpg'],
    0,
    'light'
    )
)

function initializePlayer(id: number) {
    /*
    let playerData = ref()
    Axios.get("https://localhost:7060/Player/GetPlayerData", {
        id: id,
    })
    .then((response) => {
        playerData.value = response.data
    })
    .catch((error) => {
        console.log(error)
    })

    player = new Player (
        playerData.id,
        playerData.title,
        playerData.avatar,
        playerData.coinsTotal,
        playerData.kudosTotal,
        playerData.gamesTotal,
        playerData.kudosOverall,
        playerData.modeChoices,
        playerData.standingChoices,
        playerData.unlockedTitleFirstWords,
        playerData.unlockedTitleSecondWords,
        playerData.unlockedAvatars,
        playerData.strikes,
        playerData.theme
    )
    */
}

const pathToAvatars = '/src/assets/avatars/'

export { player, pathToAvatars }

export function login(email: string, password: string) {
    /* 
    let result: number
    Axios.post("https://localhost:7060/Player/SignUp", {
        email: email,
        password: password
    })
    .then((response) => {
        result = response.data
    })
    .catch((error) => {
        console.log(error)
    })

    if (result != -1)
        initializePlayer(result)
    */
}

export function signUp(email: string, password: string) {
    /*
    let result: number
    Axios.post("https://localhost:7060/Player/SignUp", {
        email: email,
        password: password
    })
    .then((response) => {
        result = response.data
    })
    .catch((error) => {
        console.log(error)
    })

    if (result != -1)
        initializePlayer(result)
    */
}

export function updateCard(newAvatar: string, newTitle: string) {
    player.value.avatar = newAvatar
    player.value.title = newTitle
    // Axios.post("https://localhost:7060/Player/UpdateCard", {
    //     id: player.id,
    //     avatar: newAvatar,
    //     title: newTitle
    // })
    // .catch((error) => {
    //     console.log(error)
    // })
}

export function addCoins(coinCount: number) {
    player.value.addCoins(coinCount)
    // Axios.post("https://localhost:7060/Player/AddCoins", {
    //     id: player.id,
    //     amount: coinCount
    // })
    // .catch((error) => {
    //     console.log(error)
    // })
}

export function removeCoins(coinCount: number): boolean {
    if (player.value.removeCoins(coinCount)) {
        // Axios.post("https://localhost:7060/Player/RemoveCoins", {
        //     id: player.id,
        //     amount: coinCount
        // })
        // .catch((error) => {
        //     console.log(error)
        // })
        return true
    }
    return false
}

export function updateStanding(standing: string) {
    switch (standing.toLowerCase()) {
        case "authoritarian": {
            player.value.incAuthoritarian()
            break
        }
        case "left": {
            player.value.incLeft()
            break
        }
        case "libertarian": {
            player.value.incLibertarian()
            break
        }
        case "right": {
            player.value.incRight()
            break
        }
    }
    // Axios.post("https://localhost:7060/Player/UpdateStanding", {
    //         id: player.id,
    //         newStanding: standing
    //     })
    //     .catch((error) => {
    //         console.log(error)
    //     })
}

export function addTitleFirstWords(newWords: string[]) {
    player.value.addTitleFirstWords(newWords)
    // Axios.post("https://localhost:7060/Player/AddTitleFirstWords", {
    //     id: player.id,
    //     newWords: newWords
    //     })
    //     .catch((error) => {
    //         console.log(error)
    //     })
}

export function addTitleSecondWords(newWords: string[]) {
    player.value.addTitleSecondWords(newWords)
    // Axios.post("https://localhost:7060/Player/AddTitleSecondWords", {
    //     id: player.id,
    //     newWords: newWords
    //     })
    //     .catch((error) => {
    //         console.log(error)
    //     })
}

export function addAvatar(newAvatar: string) {
    player.value.addAvatar(newAvatar)
    // Axios.post("https://localhost:7060/Player/AddAvatar", {
    //     id: player.id,
    //     newAvatar: newAvatar
    // })
    // .catch((error) => {
    //     console.log(error)
    // })
}