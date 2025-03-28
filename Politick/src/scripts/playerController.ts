import { Player } from './Player'
import { ref } from 'vue'
import Axios from 'axios'
import { SignInService } from './SignInService'
import router from '@/router'

interface PlayerCard {
  Avatar: string
  Title: string
}

const player = ref<Player>()

export function initializePlayer() {
  if (SignInService.instance.isSignedIn) {
    Axios.get('/Player/GetPlayer')
      .then((response) => {
        player.value = new Player(
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
          response.data.unlockedTitleFirstWords.split('+'),
          response.data.unlockedTitleSecondWords.split('+'),
          response.data.unlockedAvatars.split('+'),
          response.data.strikes,
          response.data.theme
        )
        console.log('Player: ' + player.value.avatar)
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
    Axios.post('/Player/UpdateCard', {
      Avatar: newAvatar,
      Title: newTitle
    } as PlayerCard).catch((error) => {
      console.log(error)
    })
  }
}

export function addCoins(coinCount: number) {
  if (player.value && coinCount > 0) {
    player.value.addCoins(coinCount)
    Axios.post(`/Player/AddCoins?amount=${coinCount}`).catch((error) => {
      console.log(error)
    })
  }
}

export function removeCoins(coinCount: number) {
  if (player.value && coinCount >= 0) {
    if (player.value.removeCoins(coinCount)) {
      Axios.post(`/Player/RemoveCoins?amount=${coinCount}`).catch((error) => {
        console.log(error)
      })
      return true
    }
    return false
  }
}

export function updateStandings(standings: string[]) {
  if (player.value && standings != null && standings.length != 0) {
    for (const standing in standings) {
      switch (standing.toLowerCase()) {
        case 'authoritarian': {
          player.value.incAuthoritarian()
          break
        }
        case 'left': {
          player.value.incLeft()
          break
        }
        case 'libertarian': {
          player.value.incLibertarian()
          break
        }
        case 'right': {
          player.value.incRight()
          break
        }
      }
    }
    Axios.post('/Player/UpdateStandings', standings).catch((error) => {
      console.log(error)
    })
  }
}

export function addTitleFirstWords(newWords: string[]) {
  if (player.value) {
    player.value.addTitleFirstWords(newWords)
    Axios.post('/Player/AddTitleFirstWords', newWords).catch((error) => {
      console.log(error)
    })
  }
}

export function addTitleSecondWords(newWords: string[]) {
  if (player.value) {
    player.value.addTitleSecondWords(newWords)
    Axios.post('/Player/AddTitleSecondWords', newWords).catch((error) => {
      console.log(error)
    })
  }
}

export function addAvatar(newAvatar: string) {
  if (player.value) {
    player.value.addAvatar(newAvatar)
    Axios.post(`/Player/AddAvatar?newAvatar=${newAvatar}`).catch((error) => {
      console.log(error)
    })
  }
}

export function addGame() {
  player.value?.addGame()
  Axios.post('/Player/AddGame').catch((error) => {
    console.log(error)
  })
}

export function changeTheme(newTheme: string) {
  if (player.value) {
    player.value.theme = newTheme
    Axios.post(`/Player/ChangeTheme?newTheme=${newTheme}`).catch((error) => {
      console.log(error)
    })
  }
}

export function addStrike() {
  player.value?.addStrike()
  Axios.post('/Player/AddStrike').catch((error) => {
    console.log(error)
  })
  if (player.value?.strikes == 3) SignInService.instance.signOut()
}
