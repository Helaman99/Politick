import { ref } from 'vue'
import Axios from 'axios'
import { player } from './playerController'
import router from '@/router'
import * as signalR from '@microsoft/signalr'

const topics = ref()
Axios.get("https://localhost:7060/Topic/GetTopics")
    .then((response) => {
        topics.value = response.data
    })
    .catch((error) => {
        console.log(error)
    })

let selectedTopic = -1
let selectedSide = -1
let sideStanding = ""
export function selectTopic(index: number) {
    selectedTopic = index
    console.log(selectedTopic)
}
export function selectSide(index: number, standing: string) {
    selectedSide = index
    sideStanding = standing
    console.log(selectedSide)
}

if (selectedTopic == -1)
    router.push("/dashboard/topics")

interface Opponent {
    Id: number
    Avatar: string
    Title: string
    Topic: number
    Side: number
    ChatRoomId: string
}

const connectionRef = ref<signalR.HubConnection>()
const opponent = ref<Opponent>()
const thisPlayer = ref<Opponent>()
export function startConnection(): boolean {
    connectionRef.value = new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:7060/ChatHub')
        .build()
  
    connectionRef.value.start()
        .then(() => {
            thisPlayer.value = {
                Id: player.value.id,
                Avatar: player.value.avatar,
                Title: player.value.title,
                Topic: selectedTopic,
                Side: selectedSide,
                ChatRoomId: ""
            }
            Axios.post("https://localhost:7060/Chat/AssignRoomId", thisPlayer.value)
            .then((response) => {
                console.log(response.data)
                thisPlayer.value = response.data
                if (connectionRef.value)
                    if (!connectionRef.value.invoke('JoinGroupAsync', thisPlayer.value))
                        return false
            })
            .catch((error) => {
                console.log(error)
        })
        }).then(() => {
            connectionRef.value?.on('StartGame', () => {
                Axios.post("https://localhost:7060/Chat/GetOpponent", thisPlayer.value)
                .then((response) => {
                    opponent.value = {
                        Id: response.data.id,
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
                    router.push("/chat")
                })
            })
        })
    return true
}

export { topics, selectedTopic, selectedSide, connectionRef, thisPlayer, opponent }