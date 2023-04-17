export default class Player {
    title: string = ''
    avatarPath: string = ''
    totalCoins: number = 0
    currentCoins: number = 0
    totalWins: number = 0
    modeChoices: number[] = [0, 0, 0]
    standingChoices: number[] = [0, 0, 0, 0]
    unlockedTitleFirstWords: string[] = ['']
    unlockedTitleSecondWords: string[] = ['']
    unlockedAvatars: string[] = ['']

    constructor (title: string, avatarPath: string, totalCoins: number, currentCoins: number,
                totalWins: number, modeChoices: number[], standingChoices: number[], 
                unlockedTitleFirstWords: string[], unlockedTitleSecondWords: string[], 
                unlockedAvatars: string[]) {
        this.title = title
        this.avatarPath = avatarPath
        this.totalCoins = totalCoins
        this.currentCoins = currentCoins
        this.totalWins = totalWins
        this.modeChoices = modeChoices
        this.standingChoices = standingChoices
        this.unlockedTitleFirstWords = unlockedTitleFirstWords
        this.unlockedTitleSecondWords = unlockedTitleSecondWords
        this.unlockedAvatars = unlockedAvatars
    }
}