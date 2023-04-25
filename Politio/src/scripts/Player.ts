export class Player {
    private _title: string
    private _avatar: string
    private _coinsTotal: number
    private _kudosTotal: number
    private _gamesTotal: number
    private _kudosOverall: number
    private _modeChoices: number[]
    private _standingChoices: number[]
    private _unlockedTitleFirstWords: string[]
    private _unlockedTitleSecondWords: string[]
    private _unlockedAvatars: string[]
    private _strikes: number
    theme: string

    constructor (title: string, avatar: string, coinsTotal: number, kudosTotal: number,
                gamesTotal: number, kudosOverall: number, modeChoices: number[], standingChoices: number[], 
                unlockedTitleFirstWords: string[], unlockedTitleSecondWords: string[], 
                unlockedAvatars: string[], strikes: number, theme: string) {
        this._title = title || ''
        this._avatar = avatar || ''
        this._coinsTotal = coinsTotal || 0
        this._kudosTotal = kudosTotal || 0
        this._gamesTotal = gamesTotal || 0
        this._kudosOverall = kudosOverall || 0
        this._modeChoices = modeChoices || [0, 0, 0]
        this._standingChoices = standingChoices || [0, 0, 0, 0]
        this._unlockedTitleFirstWords = unlockedTitleFirstWords || ['']
        this._unlockedTitleSecondWords = unlockedTitleSecondWords || ['']
        this._unlockedAvatars = unlockedAvatars || ['']
        this._strikes = strikes || 0
        this.theme = theme || 'light'
    }

    /*
        standingChoices[0] = number of times an authoritarian standing was chosen
        standingChoices[1] = number of times a left standing was chosen
        standingChoices[2] = number of times a libertarian standing was chosen
        standingChoices[3] = number of times a right standing was chosen
    */
    get standingActual() {

        if (this._gamesTotal > 9) {
            if (this._standingChoices[1] > this._standingChoices[3]) {
                if (this._standingChoices[0] > this._standingChoices[2])
                    return "Left Authoritarian"
                if (this._standingChoices[2] > this._standingChoices[0])
                    return "Left Libertarian"
                return "Left"
            }
            else if (this._standingChoices[3] > this._standingChoices[1]) {
                if (this._standingChoices[0] > this._standingChoices[2])
                    return "Right Authoritarian"
                if (this._standingChoices[2] > this._standingChoices[0])
                    return "Right Libertarian"
                return "Right"
            }
            else if (this._standingChoices[0] > this._standingChoices[2])
                return "Authoritarian"
            else if (this._standingChoices[2] > this._standingChoices[0])
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
        if (this._gamesTotal == 0)
            return "Play a game first!"
        if (this._modeChoices[0] > this._modeChoices[1] &&
            this._modeChoices[0] > this._modeChoices[2])
            return "Battle Royal"
        else if (this._modeChoices[1] > this._modeChoices[0] && 
            this._modeChoices[1] > this._modeChoices[2])
            return "Debate"
        else
            return "Jury"
    }

    addTitleFirstWords(newWords: string[]) {
        if (newWords.length != 0)
            for (let word in newWords)
                this._unlockedTitleFirstWords.push(word)
    }

    addTitleSecondWords(newWords: string[]) {
        if (newWords.length != 0)
            for (let word in newWords)
                this._unlockedTitleSecondWords.push(word)
    }

    addAvatar(newAvatar: string) {
        if (newAvatar != null && newAvatar != '')
            this._unlockedAvatars.push(newAvatar)
    }

    get avatar() {
        return this._avatar
    }

    get title() {
        return this._title
    }

    get coins() {
        return this._coinsTotal
    }

    get kudos() {
        return this._kudosTotal
    }

    get lifetimeGames() {
        return this._gamesTotal
    }

    get lifetimeKudos() {
        return this._kudosOverall
    }

    get unlockedTitleFirstWords() {
        return this._unlockedTitleFirstWords
    }

    get unlockedTitleSecondWords() {
        return this._unlockedTitleSecondWords
    }

    get unlockedAvatars() {
        return this._unlockedAvatars
    }

    get strikes() {
        return this._strikes
    }

    set avatar(newAvatar: string) {
        if (newAvatar != null && newAvatar != '')
            this._avatar = newAvatar
    }

    set title(newTitle: string) {
        if (newTitle != null && newTitle != '')
            this._title = newTitle
    }
}