export default class Player {
    title: string = ''
    avatarPath: string = ''
    totalCoins: number = 0
    currentCoins: number = 0
    totalGames: number = 0
    totalWins: number = 0
    modeChoices: number[] = [0, 0, 0]
    standingChoices: number[] = [0, 0, 0, 0]
    unlockedTitleFirstWords: string[] = ['']
    unlockedTitleSecondWords: string[] = ['']
    unlockedAvatars: string[] = ['']

    constructor (title: string, avatarPath: string, totalCoins: number, currentCoins: number,
                totalGames: number, totalWins: number, modeChoices: number[], standingChoices: number[], 
                unlockedTitleFirstWords: string[], unlockedTitleSecondWords: string[], 
                unlockedAvatars: string[]) {
        this.title = title
        this.avatarPath = avatarPath
        this.totalCoins = totalCoins
        this.currentCoins = currentCoins
        this.totalGames = totalGames
        this.totalWins = totalWins
        this.modeChoices = modeChoices
        this.standingChoices = standingChoices
        this.unlockedTitleFirstWords = unlockedTitleFirstWords
        this.unlockedTitleSecondWords = unlockedTitleSecondWords
        this.unlockedAvatars = unlockedAvatars
    }

    /*
        standingChoices[0] = number of times an authoritarian standing was chosen
        standingChoices[1] = number of times a left standing was chosen
        standingChoices[2] = number of times a libertarian standing was chosen
        standingChoices[3] = number of times a right standing was chosen
    */
    get standingActual() {

        if (this.totalGames > 9) {
            if (this.standingChoices[1] > this.standingChoices[3]) {
                if (this.standingChoices[0] > this.standingChoices[2])
                    return "Left Authoritarian"
                if (this.standingChoices[2] > this.standingChoices[0])
                    return "Left Libertarian"
                return "Left"
            }
            else if (this.standingChoices[3] > this.standingChoices[1]) {
                if (this.standingChoices[0] > this.standingChoices[2])
                    return "Right Authoritarian"
                if (this.standingChoices[2] > this.standingChoices[0])
                    return "Right Libertarian"
                return "Right"
            }
            else if (this.standingChoices[0] > this.standingChoices[2])
                return "Authoritarian"
            else if (this.standingChoices[2] > this.standingChoices[0])
                return "Libertarian"
            return "Centrist"
        }
        return "Play more games first!"
    }
}