import { Player } from './Player'

// Code to retrieve player data from backend/database

// Create a player object with the player's data from the database
let player: Player = new Player (
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
)
const pathToAvatars = '/src/assets/avatars/'

export { player, pathToAvatars }
export function updatePlayer(newAvatar: string, newTitle: string) {
    console.log("Updating player data in the database...")
    player.avatar = newAvatar
    player.title = newTitle
    // Code to tell the back-end to overwrite the data for this user with new data
}