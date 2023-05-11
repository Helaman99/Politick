import type { Topic } from './Topic'
import type { Side } from './Side'
import Axios from 'axios'

Axios.get("https://localhost:7060/Topic/GetTopics")
    .then((response) => {
        const getTopics = response
        console.log(getTopics)
    })
    .catch((error) => {
        console.log(error)
    })

export const topics: Topic[] = [
    { title: 'Topic 1', description: 'Description 1', image: '/src/assets/topic_images/astronaut-synthwave.jpg',
        sides: [
            { title: 'Side 1 Topic 1', description: 'Description 1 Side 1'},
            { title: 'Side 2 Topic 1', description: 'Description 2 Side 2'}
        ] },
    { title: 'Topic 2', description: 'Description 2', image: '/src/assets/topic_images/astronaut-synthwave.jpg',
        sides: [
            { title: 'Side 1 Topic 2', description: 'Description 1 Side 1'},
            { title: 'Side 2 Topic 2', description: 'Description 2 Side 2'}
        ] },
    { title: 'Topic 3', description: 'Description 3', image: '/src/assets/topic_images/astronaut-synthwave.jpg',
        sides: [
            { title: 'Side 1 Topic 3', description: 'Description 1 Side 1'},
            { title: 'Side 2 Topic 3', description: 'Description 2 Side 2'}
        ] }
]

let selectedTopic: Topic
let selectedSide: Side
function selectTopic(topic: Topic) {
    selectedTopic = topic
    console.log(selectedTopic)
}
function selectSide(side: Side) {
    selectedSide = side
    console.log(selectedSide)
}

export { selectedTopic, selectTopic, selectedSide, selectSide }