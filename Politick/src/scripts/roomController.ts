import { ref } from 'vue'
import Axios from 'axios'
import { player } from './playerController'
import router from '@/router'
import * as signalR from '@microsoft/signalr'

Axios.post("https://localhost:7060/Chat/DeleteRoom", {
    id: player.id,
})

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

const room = ref('')
const connectionRef = ref<signalR.HubConnection>()
export function startConnection(): boolean {
    connectionRef.value = new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:7060/ChatHub')
        .build()
  
    connectionRef.value.start()
        .then(() => {
            console.log("Topic: " + selectedTopic + " -- Side: " + selectedSide)
            Axios.post("https://localhost:7060/Chat/GetRoomId", {
                id: player.id,
                topic: selectedTopic,
                side: selectedSide
            })
            .then((response) => {
                room.value = response.data
                room.value = room.value.toString()
                console.log(room.value)
                if (connectionRef.value)
                    if (!connectionRef.value.invoke('JoinGroupAsync', room.value))
                        return false
            })
            .catch((error) => {
                console.log(error)
        })
        }).then(() => {
            connectionRef.value?.on('StartGame', () => {
                router.push("/chat")
            })
        })
    return true
}

export { topics, selectedTopic, selectedSide, connectionRef, room }