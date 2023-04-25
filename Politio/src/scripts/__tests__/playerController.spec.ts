import { describe, it, expect } from 'vitest'

import { player, pathToAvatars } from '../playerController'

describe('playerController', () => {
    it('player is not null', () => {
        expect(player).not.toBeNull()
    })
})

describe('pathToAvatars', () => {
    it('is a valid path', () => {
        expect(pathToAvatars).not.toBeNull()
    })
})