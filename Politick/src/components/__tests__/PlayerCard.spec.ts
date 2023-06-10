import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import PlayerCard from '../PlayerCard.vue'

describe('PlayerCard', () => {
  it('renders properly', () => {
    const wrapper = mount(PlayerCard, {
      props: {
        avatarPath: '/src/assets/avatars/astronaut.jpg',
        title: 'Player Title',
        color: 'white'
      }
    })
    expect(wrapper.text()).toContain('Player Title')
  })
})
