import Axios from 'axios'
import { ref } from 'vue'

let pathToMysteryBoxes = "/src/assets/mystery_boxes/"

export { pathToMysteryBoxes }

let avatarFileNames: Array<string>
Axios.get("https://localhost:7060/Shop/Avatars")
    .then((response) => {
        console.log(response)
        avatarFileNames = response.data
    })
    .catch((error) => {
        console.log(error)
    })

export { avatarFileNames }