import type { Side } from './Side'
export type Topic = {
    readonly title: string
    readonly description: string
    readonly image: string
    readonly sides: Side[]
}