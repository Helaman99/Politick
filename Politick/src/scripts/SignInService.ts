import Axios from 'axios'
import { initializePlayer } from './playerController'

class PolitickToken {
  random: string = ''
  userId: string = ''
  email: string = ''
  aud: string = ''
  exp: number = 0
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': string[] = []
  iss: string = ''
  jti: string = ''
  sub: string = ''
  get roles(): string[] {
    return this['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
  }
}

export class SignInService {
  private _rawToken: string | null = null
  private _token: PolitickToken = new PolitickToken()
  private _isSignedIn: boolean = false
  private static _instance = new SignInService()

  private constructor() {}

  public async signIn(email: string, password: string) {
    Axios.post('/Token/GetToken', {
      email: email,
      password: password
    })
      .then((response) => {
        this.setToken(response.data.token)
        console.log(this.token)
        console.log(this.token.roles)
        this._isSignedIn = true
        initializePlayer()
      })
      .catch((error) => {
        console.log(`Login failed: ${error.response.data}`)
        let error_div = document.getElementById('error-message')
        if (error_div) {
          error_div.innerHTML = '<p>' + error.response.data + '</p>'
        }
        this.signOut()
        return error
      })
      .finally(() => {
        console.log(`Player logged in: ${this.isSignedIn}`)
      })
  }

  public async createAccount(email: string, password: string) {
    Axios.post('/Token/CreatePlayer', {
      email: email,
      password: password
    })
      .then(() => {
        this.signIn(email, password)
      })
      .catch((error) => {
        console.log(`Sign up failed: ${error.response.data}`)
        let error_div = document.getElementById('error-message')
        let messages = ''
        if (error_div) {
          for (let err of error.response.data) {
            messages += err.description + '<br>'
          }
          error_div.innerHTML = '<p>' + messages + '</p>'
        }
        this.signOut()
        return error
      })
      .finally(() => {
        console.log(`Player signed up: ${this.isSignedIn}`)
      })
  }

  public signOut() {
    this._token = new PolitickToken()
    this._isSignedIn = false
    this._rawToken = ''
    console.log(`Player signed out: ${!this._isSignedIn}`)
  }

  public get isSignedIn() {
    return this._isSignedIn
  }

  private setToken(token: string) {
    this._rawToken = token
    Axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    const parts = token.split('.')
    const payload = JSON.parse(window.atob(parts[1]))
    this._token = Object.assign(new PolitickToken(), payload)
  }

  public get rawToken(): string | null {
    return this._rawToken
  }

  public get token(): PolitickToken {
    return this._token
  }

  public static get instance(): SignInService {
    return SignInService._instance
  }
}
