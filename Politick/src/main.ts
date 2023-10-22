import { createApp, reactive } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'
import { SignInService } from '@/scripts/SignInService'
import './assets/css/main.css'
import '@mdi/font/css/materialdesignicons.css'
import Axios from 'axios'
import VueMeta from 'vue-meta'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

//Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'https://localhost:7060'
} else {
  Axios.defaults.baseURL = 'https://politick-api.azurewebsites.net'
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

app.use(router).use(vuetify).use(VueMeta)

app.mount('#app')

// Add Google AdSense script to the head of your site
app.component('App', {
  metaInfo: {
    script: [
      {
        src: 'https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-3282272675447500',
        async: true,
        crossorigin: 'anonymous'
      }
    ]
  }
})
