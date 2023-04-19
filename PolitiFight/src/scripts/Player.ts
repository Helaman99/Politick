export class Player {
    title: string
    avatar: string
    totalCoins: number
    currentCoins: number
    totalGames: number
    totalWins: number
    modeChoices: number[]
    standingChoices: number[]
    unlockedTitleFirstWords: string[]
    unlockedTitleSecondWords: string[]
    unlockedAvatars: string[]
    strikes: number

    constructor (title: string, avatar: string, totalCoins: number, currentCoins: number,
                totalGames: number, totalWins: number, modeChoices: number[], standingChoices: number[], 
                unlockedTitleFirstWords: string[], unlockedTitleSecondWords: string[], 
                unlockedAvatars: string[], strikes: number) {
        this.title = title || ''
        this.avatar = avatar || ''
        this.totalCoins = totalCoins || 0
        this.currentCoins = currentCoins || 0
        this.totalGames = totalGames || 0
        this.totalWins = totalWins || 0
        this.modeChoices = modeChoices || [0, 0, 0]
        this.standingChoices = standingChoices || [0, 0, 0, 0]
        this.unlockedTitleFirstWords = unlockedTitleFirstWords || ['']
        this.unlockedTitleSecondWords = unlockedTitleSecondWords || ['']
        this.unlockedAvatars = unlockedAvatars || ['']
        this.strikes = strikes || 0
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

    /*
        modeChoices[0] = the number of times the player has played 'Battle Royal'
        modeChoices[1] = the number of times the player has played 'Debate'
        modeChoices[2] = the number of times the player has played 'Jury'
    */
    get favoriteMode () {
        if (this.totalGames == 0)
            return "Play a game first!"
        if (this.modeChoices[0] > this.modeChoices[1] &&
            this.modeChoices[0] > this.modeChoices[2])
            return "Battle Royal"
        else if (this.modeChoices[1] > this.modeChoices[0] && 
            this.modeChoices[1] > this.modeChoices[2])
            return "Debate"
        else
            return "Jury"
    }
}