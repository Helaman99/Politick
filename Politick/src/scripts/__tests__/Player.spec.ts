import { describe, it, expect } from 'vitest'

import { Player } from '../Player'

const player = new Player (
    'avatarPath',
    'title',
    0,
    0,
    0,
    0,
    [0, 0, 0],
    [0, 0, 0, 0],
    [],
    [],
    [],
    0,
    'light'
)

describe('Player', () => {
    it('is not null', () => {
        expect(player).not.toBeNull()
        expect(player).toBeInstanceOf(Player)
    })
})

describe('Player title', () => {
    it('can be changed', () => {
        const titleExpected = "New Title"
        player.title = titleExpected
        expect(player.title).toEqual(titleExpected)
    })
})

describe('Player title', () => {
    it('cant be empty', () => {
        const titleExpected = ""
        player.title = titleExpected
        expect(player.title).toEqual('New Title')
    })
})