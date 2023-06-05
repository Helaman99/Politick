import { Player } from './Player'
import { ref } from 'vue'
import Axios from 'axios'
import { SignInService } from './SignInService'
import router from '@/router'

// Eventually I want to replace this with a service, similar to the `SignInService`

interface PlayerCard {
    Avatar: string
    Title: string
}

const player = ref<Player>()

export function initializePlayer() {
    if (SignInService.instance.isSignedIn) {
        Axios.get("https://localhost:7060/Player/GetPlayer")
            .then((response) => {
                player.value = new Player (
                    response.data.title,
                    response.data.avatar,
                    response.data.coinsTotal,
                    response.data.kudosTotal,
                    response.data.gamesTotal,
                    response.data.kudosOverall,
                    response.data.authoritarian,
                    response.data.left,
                    response.data.libertarian,
                    response.data.right,
                    response.data.unlockedTitleFirstWords.split("+"),
                    response.data.unlockedTitleSecondWords.split("+"),
                    response.data.unlockedAvatars.split("+"),
                    response.data.strikes,
                    response.data.theme
                )
                console.log("Player: " + player.value.avatar)
                router.push('/dashboard')
            })
            .catch((error) => {
                console.log(error)
            })
    }
}

export { player }

export function updateCard(newAvatar: string, newTitle: string) {
    if (player.value) {
        player.value.avatar = newAvatar
        player.value.title = newTitle
        Axios.post("https://localhost:7060/Player/UpdateCard", { Avatar: newAvatar, Title: newTitle } as PlayerCard)
            .catch((error) => {
                console.log(error)
            })
    }
    
}

export function addCoins(coinCount: number) {
    if (player.value) {
        player.value.addCoins(coinCount)
        Axios.post(`https://localhost:7060/Player/AddCoins?amount=${coinCount}`)
            .catch((error) => {
                console.log(error)
            })
    }
}

export function removeCoins(coinCount: number) {
    if (player.value) {
        if (player.value.removeCoins(coinCount)) {
            Axios.post(`https://localhost:7060/Player/RemoveCoins?amount=${coinCount}`)
                .catch((error) => {
                    console.log(error)
                })
            return true
        }
        return false
    }
}

export function updateStanding(standing: string) {
    if (player.value && standing != "" && standing != null) {
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
        Axios.post(`https://localhost:7060/Player/UpdateStanding?newStanding=${standing}`)
            .catch((error) => {
                console.log(error)
            })
    }
    
}

export function addTitleFirstWords(newWords: string[]) {
    if (player.value) {
        player.value.addTitleFirstWords(newWords)
        Axios.post('https://localhost:7060/Player/AddTitleFirstWords', 
            newWords
            )
            .catch((error) => {
                console.log(error)
            })
    }
    
}

export function addTitleSecondWords(newWords: string[]) {
    if (player.value) {
        player.value.addTitleSecondWords(newWords)
        Axios.post('https://localhost:7060/Player/AddTitleSecondWords', 
            newWords
            )
            .catch((error) => {
                console.log(error)
            })
    }
    
}

export function addAvatar(newAvatar: string) {
    if (player.value) {
        player.value.addAvatar(newAvatar)
        Axios.post(`https://localhost:7060/Player/AddAvatar?newAvatar=${newAvatar}`)
        .catch((error) => {
            console.log(error)
        })
    } 
}

export function addGame() {
    player.value?.addGame()
    Axios.post("https://localhost:7060/Player/AddGame").catch((error) => { console.log(error) })
}

export function changeTheme(newTheme: string) {
    if (player.value) {
        player.value.theme = newTheme
        Axios.post(`https://localhost:7060/Player/ChangeTheme?newTheme=${newTheme}`)
        .catch((error) => {
            console.log(error)
        })
    }
}