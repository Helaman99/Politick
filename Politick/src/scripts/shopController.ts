import Axios from 'axios'
import { ref } from 'vue'
import { removeCoins, addAvatar, } from '@/scripts/playerController'

let pathToMysteryBoxes = "/src/assets/mystery_boxes/"

export { pathToMysteryBoxes }

const basicAvatarFileNames = ref([''])
const premiumAvatarFileNames = ref([''])
Axios.get("https://localhost:7060/Shop/BasicAvatars")
    .then((response) => {
        console.log(response)
        basicAvatarFileNames.value = response.data
    })
    .catch((error) => {
        console.log(error)
    })
Axios.get("https://localhost:7060/Shop/PremiumAvatars")
    .then((response) => {
        console.log(response)
        premiumAvatarFileNames.value = response.data
    })
    .catch((error) => {
        console.log(error)
    })

export function purchaseAvatar(avatar: string, amount: number) {
    // addAvatar(avatar)
    // removeCoins(amount)
}

export { basicAvatarFileNames, premiumAvatarFileNames }