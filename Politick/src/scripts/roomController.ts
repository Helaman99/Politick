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
    avatar: string,
    title: string,
    color:string
}

const room = ref('')
const connectionRef = ref<signalR.HubConnection>()
const opponent = ref<Opponent>()
export function startConnection(): boolean {
    connectionRef.value = new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:7060/ChatHub')
        .build()
  
    connectionRef.value.start()
        .then(() => {
            Axios.post("https://localhost:7060/Chat/GetRoom", {
                // id: player.value.id,
                avatar: "avatar",
                // title: player.value.title,
                // topic: selectedTopic,
                // side: selectedSide
            })
            .then((response) => {
                console.log(response.data)
                // room.value = response.data
                // room.value = room.value.toString()
                // console.log(room.value)
                // if (connectionRef.value)
                //     if (!connectionRef.value.invoke('JoinGroupAsync', room.value))
                //         return false
            })
            .catch((error) => {
                console.log(error)
        })
        }).then(() => {
            connectionRef.value?.on('StartGame', () => {
                Axios.post("localhost:7060/Chat/GetOpponent", {
                    chatRoomId: room.value,
                    id: player.value.id
                })
                .then((response) => {
                    opponent.value = {
                        avatar: response.data.avatar,
                        title: response.data.title,
                        color: response.data.color
                    }
                    router.push("/chat")
                })
                .catch((error) => {
                    console.log(error)
                })
            })
        })
    return true
}

export { topics, selectedTopic, selectedSide, connectionRef, room, opponent }