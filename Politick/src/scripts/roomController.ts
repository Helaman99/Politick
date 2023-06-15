import { ref } from 'vue'
import Axios from 'axios'
import { player, updateStandings } from './playerController'
import router from '@/router'
import * as signalR from '@microsoft/signalr'

const topics = ref()
Axios.get('/Topic/GetTopics')
  .then((response) => {
    topics.value = response.data
  })
  .catch((error) => {
    console.log(error)
  })

let selectedTopic = -1
let selectedSide = -1
let sideStandings = Array('')
export function selectTopic(index: number) {
  selectedTopic = index
  //console.log('Topic: ' + selectedTopic)
}
export function selectSide(index: number, standings: string[]) {
  selectedSide = index
  sideStandings = standings
  //console.log('Side: ' + selectedSide)
  //console.log('Standings: ' + sideStandings)
}

if (selectedTopic == -1) router.push('/dashboard/topics')

interface Opponent {
  Email: string
  Avatar: string
  Title: string
  Topic: number
  Side: number
  ChatRoomId: string
}

const connectionRef = ref<signalR.HubConnection>()
const opponent = ref<Opponent>()
const thisPlayer = ref<Opponent>()
const room = ref(0)
export function startConnection(): boolean {
  connectionRef.value = new signalR.HubConnectionBuilder()
    .withUrl(Axios.defaults.baseURL + '/ChatHub')
    .build()

  connectionRef.value
    .start()
    .then(() => {
      thisPlayer.value = {
        Email: '',
        Avatar: player.value?.avatar || '',
        Title: player.value?.title || '',
        Topic: selectedTopic,
        Side: selectedSide,
        ChatRoomId: ''
      }
      Axios.post('/Chat/AssignRoomId', thisPlayer.value)
        .then((response) => {
          //console.log('Room: ' + response.data.chatRoomId)
          room.value = response.data.chatRoomId
          thisPlayer.value = response.data
          if (connectionRef.value)
            if (!connectionRef.value.invoke('JoinGroupAsync', thisPlayer.value)) return false
        })
        .catch((error) => {
          console.log(error)
        })
    })
    .then(() => {
      connectionRef.value?.on('StartGame', () => {
        Axios.post('/Chat/GetOpponent', thisPlayer.value)
          .then((response) => {
            opponent.value = {
              Email: response.data.name,
              Avatar: response.data.avatar,
              Title: response.data.title,
              Topic: response.data.topic,
              Side: response.data.side,
              ChatRoomId: response.data.chatRoomId
            }
          })
          .catch((error) => {
            console.log(error)
          })
          .then(() => {
            updateStandings(sideStandings)
            router.push('/chat')
          })
      })
    })
  return true
}

export { topics, selectedTopic, selectedSide, connectionRef, thisPlayer, opponent, room }
