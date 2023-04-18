import { Player } from './Player'

// Code to retrieve player data from backend/database

// Create a player object with the player's data from the database
let player = new Player (
    '',
    '',
    0,
    0,
    0,
    0,
    [0, 0, 0],
    [0, 0, 0, 0],
    [],
    [],
    [],
    0,
)

export { player }
export function updatePlayer() {
    // Code to tell the back-end to overwrite the data for this user with new data
}