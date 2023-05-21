import Axios from 'axios'
import { ref } from 'vue'
import { removeCoins, addAvatar, } from '@/scripts/playerController'

// ---------- Avatar Shop Stuff ---------- \\

const basicAvatarFileNames = ref([''])
const premiumAvatarFileNames = ref([''])
Axios.get("https://localhost:7060/Shop/BasicAvatars")
    .then((response) => {
        basicAvatarFileNames.value = response.data
    })
    .catch((error) => {
        console.log(error)
    })
Axios.get("https://localhost:7060/Shop/PremiumAvatars")
    .then((response) => {
        premiumAvatarFileNames.value = response.data
    })
    .catch((error) => {
        console.log(error)
    })

export function purchaseAvatar(avatar: string, amount: number): boolean {
    if (removeCoins(amount)) {
        addAvatar(avatar)
        return true
    }
    return false
}

export { basicAvatarFileNames, premiumAvatarFileNames }