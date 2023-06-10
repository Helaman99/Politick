import { createApp, reactive } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'
import { SignInService } from '@/scripts/SignInService'
import './assets/css/main.css'
import '@mdi/font/css/materialdesignicons.css'
import Axios from 'axios'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

//Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'https://localhost:7053/'
} else {
  Axios.defaults.baseURL = 'https://wordle2023.azurewebsites.net/'
}

const vuetify = createVuetify({
  components,
  directives,
  icons: {
    defaultSet: 'mdi',
    sets: {
      mdi
    }
  }
})

const app = createApp(App)

// Create basic services
const signInService = reactive(SignInService.instance)
app.provide('SignInService', signInService)

app.use(router).use(vuetify).mount('#app')
