import type { Topic } from './Topic'

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