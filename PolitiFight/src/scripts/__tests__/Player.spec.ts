import { describe, it, expect } from 'vitest'

import { Player } from '../Player'

let player = new Player (
    '',
    '',
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
)

describe('Player', () => {
    it('is not null', () => {
        expect(player).not.toBeNull()
        expect(player).toBeInstanceOf(Player)
    })
})

describe('Player title', () => {
    it('can be changed', () => {
        let titleExpected = "New Title"
        player.title = titleExpected
        expect(player.title).toEqual(titleExpected)
    })
})