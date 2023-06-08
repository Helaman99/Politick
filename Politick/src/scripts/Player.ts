export class Player {

    private _title: string
    private _avatar: string
    private _coinsTotal: number
    private _kudosTotal: number
    private _gamesTotal: number
    private _kudosOverall: number
    private _authoritarian: number
    private _left: number
    private _libertarian: number
    private _right: number
    private _unlockedTitleFirstWords: string[]
    private _unlockedTitleSecondWords: string[]
    private _unlockedAvatars: string[]
    private _strikes: number
    theme: string

    constructor (title: string, avatar: string, coinsTotal: number, kudosTotal: number,
                gamesTotal: number, kudosOverall: number, authoritarian: number,
                left: number, libertarian: number, right: number, unlockedTitleFirstWords: string[], 
                unlockedTitleSecondWords: string[], unlockedAvatars: string[], strikes: number, 
                theme: string) {
        this._title = title || ''
        this._avatar = avatar || ''
        this._coinsTotal = coinsTotal || 0
        this._kudosTotal = kudosTotal || 0
        this._gamesTotal = gamesTotal || 0
        this._kudosOverall = kudosOverall || 0
        this._authoritarian = authoritarian || 0
        this._left = left || 0
        this._libertarian = libertarian || 0
        this._right = right || 0
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

        let x = this._left / this._right;
        let y = this._authoritarian / this._libertarian;
        let standing = "";

        if (x > 1.3 || (this._left != 0 && this._right == 0))
            standing += "Left "
        else if (x < 0.7 || (this._right != 0 && this._left == 0))
            standing += "Right "
        else
            standing = "Center "
        if (y > 1.3 || (this._authoritarian != 0 && this._libertarian == 0))
            standing += "Authoritarian"
        else if (y < 0.7 || (this._libertarian != 0 && this._authoritarian == 0))
            standing += "Libertarian"
        else if (standing != "Center ")
            standing = "Center " + standing
        
        return standing;
    }

    incAuthoritarian() { this._authoritarian++ }
    incLeft() { this._left++ }
    incLibertarian() { this._libertarian++ }
    incRight() { this._right++ }

    addGame() {
        this._gamesTotal++;
    }

    addTitleFirstWords(newWords: string[]) {
        if (newWords.length != 0)
            for (let i = 0; i < newWords.length; i++)
                this._unlockedTitleFirstWords.push(newWords[i])
    }

    addTitleSecondWords(newWords: string[]) {
        if (newWords.length != 0)
            for (let i = 0; i < newWords.length; i++)
                this._unlockedTitleSecondWords.push(newWords[i])
    }

    addAvatar(newAvatar: string) {
        if (newAvatar != null && newAvatar != '')
            this._unlockedAvatars.push(newAvatar)
    }

    addCoins(coinCount: number) {
        this._coinsTotal += coinCount
    }

    removeCoins(coinCount: number): boolean {
        if (this._coinsTotal >= coinCount) {
            this._coinsTotal -= coinCount
            return true
        }
        return false
    }

    get avatar() { return this._avatar }

    get title() { return this._title }

    get coins() { return this._coinsTotal }

    get kudos() { return this._kudosTotal }

    get lifetimeGames() { return this._gamesTotal }

    get lifetimeKudos() { return this._kudosOverall }

    get unlockedTitleFirstWords() { return this._unlockedTitleFirstWords }

    get unlockedTitleSecondWords() { return this._unlockedTitleSecondWords }

    get unlockedAvatars() { return this._unlockedAvatars }

    get strikes() { return this._strikes }

    set avatar(newAvatar: string) {
        if (newAvatar != null && newAvatar != '')
            this._avatar = newAvatar
    }

    set title(newTitle: string) {
        if (newTitle != null && newTitle != '')
            this._title = newTitle
    }

    addStrike() {
        this._strikes++;
    }
}