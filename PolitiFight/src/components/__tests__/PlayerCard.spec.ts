import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import { playerCard, avatarsPath } from '../PlayerCard.vue'

describe('PlayerCard', () => {
  it('renders properly', () => {
    const wrapper = mount(playerCard, { props: { avatar: 'astronaut.jpg', title: 'Player Title', 
                                                 color: 'white' } })
    expect(wrapper.text()).toContain('Player Title')
  })
})