import Axios from 'axios'
import { SignInService } from './SignInService'
import router from '@/router'

export class ForgotPasswordService {
    private _hasEmail: boolean = false
    private _email: string = ''
    private _question: string = ''
    private _givenAnswer: string = ''
    private static _instance = new ForgotPasswordService()
    private _answeredCorrectly: boolean = false
  
    private constructor() {}
  
    public async getQuestion(email: string) {
        this._hasEmail = true
        this._email = email
        Axios.post(`/Token/GetQuestion?email=${email}`)
            .then((response) => {
                if (response.status === 200) {
                    this._question = response.data
                    router.push("/forgot-password/question")
                }
            })
            .catch((error) => { 
                console.log(error) 
                let error_div = document.getElementById('error-message')
                if (error_div) {
                    error_div.innerHTML = '<p>' + error.response.data + '</p>'
                }
            })
    }

    public async verifyAnswer(answer: string) {
        this._givenAnswer = answer
        let emailAndAnswer = [this._email, this._givenAnswer]
        Axios.post("/Token/ValidateAnswer", emailAndAnswer)
            .then((response) => {
                if (response.status === 200) {
                    this._answeredCorrectly = true 
                    router.push("/forgot-password/reset-password")
                }
            })
            .catch((error) => {
                console.log(error)
                let error_div = document.getElementById('error-message')
                if (error_div) {
                    error_div.innerHTML = '<p>' + error.response.data + '</p>'
                } 
            })
    }

    public async resetPassword(newPassword: string) {
        let args = [this._email, this._givenAnswer, newPassword]
        Axios.post("/Token/UpdatePassword", args)
            .then((response) => {
                if (response.status === 200) {
                    SignInService.instance.signIn(this._email, newPassword)
                }
            })
            .catch((error) => {
                console.log(error)
                let error_div = document.getElementById('error-message') as HTMLElement
                let messages = ''
                for (let err of error.response.data) {
                       messages += err.description + '<br>'
                }
                error_div.innerHTML = '<p>' + messages + '</p>'
            })
    }

    public async changeQuestion(newQuestion:string, newAnswer:string) {
        let error_div = document.getElementById('error-message') as HTMLElement
        Axios.post("/Token/ChangeSecurityQuestion", { Question: newQuestion, Answer: newAnswer })
            .then((response) => {
                if (response.status === 200) {
                    error_div.innerHTML = '<p color="green">Question and answer has been changed!</p>'
                }
            })
            .catch((error) => {
                console.log(error)
                let messages = ''
                for (let err of error.response.data) {
                       messages += err.description + '<br>'
                }
                error_div.innerHTML = '<p>' + messages + '</p>'
            })
    }
  
    public get hasEmail(): boolean {
        return this._hasEmail
    }
    
    public get question(): string {
        return this._question
    }
    
    public static get instance(): ForgotPasswordService {
      return ForgotPasswordService._instance
    }
}