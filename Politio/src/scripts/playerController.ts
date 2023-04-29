import type { Player } from './Player'
import Axios from 'axios'

// Code to retrieve player data from backend/database

// Create a player object with the player's data from the database
let player: Player;

function initializePlayer(id: number) {
    /*
    playerData = axios call to backend GetPlayerData method
    player = new Player (
        1,
        'Happy Banana',
        'astronaut.jpg',
        0,
        0,
        0,
        0,
        [0, 0, 0],
        [0, 0, 0, 0],
        ['Happy', 'Sad', 'Wrinkly', 'Bloated'],
        ['Helicopter', 'Banana', 'Sasquatch', 'Bunny', 'Marshmallow', 'Tank', 'Goldfish'],
        ['astronaut.jpg', 'astronaut-synthwave.jpg'],
        0,
        'light'
    )
    */
}

const pathToAvatars = '/src/assets/avatars/'

export { player, pathToAvatars }

export function login(email: string, password: string) {
    /* 
    result = axios call to backend login method
    if (result != -1)
        initializePlayer(result);
    return result;
    */
}

export function updateCard(newAvatar: string, newTitle: string) {
    console.log("Updating player data in the database...")
    player.avatar = newAvatar
    player.title = newTitle
    // Code to tell the back-end to overwrite the data for this user with new data
}

export function addCoins(coinCount: number) {
    player.addCoins(coinCount)
    // Code for backend
}

export function removeCoins(coinCount: number) {
    player.removeCoins(coinCount)
    // Code for backend
}

export function addTitleFirstWords(newWords: string[]) {
    player.addTitleFirstWords(newWords)
    // Code for backend
}

export function addTitleSecondWords(newWords: string[]) {
    player.addTitleSecondWords(newWords)
    // Code for backend
}

export function addAvatar(newAvatar: string) {
    player.addAvatar(newAvatar)
    // Code for backend
}