import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { SignInService } from '@/scripts/SignInService'
import { ForgotPasswordService } from '@/scripts/ForgotPasswordService'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/signup',
      name: 'signup',
      component: () => import('../views/SignUpView.vue')
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    },
    {
      path: '/special-thanks',
      name: 'special thanks',
      component: () => import('../views/SpecialThanksView.vue')
    },
    {
      path: '/chat',
      name: 'chat',
      component: () => import('../views/ChatView.vue'),
      beforeEnter: (to, from, next) => {
        //return SignInService.instance._isSignedIn
        if (SignInService.instance.isSignedIn) next()
        else next({ name: 'login' })
      }
    },
    {
      path: '/terms-of-service',
      name: 'terms of service',
      component: () => import('../views/TermsOfServiceView.vue')
    },
    {
      path: '/privacy-policy',
      name: 'privacy policy',
      component: () => import('../views/PrivacyPolicyView.vue')
    },
    {
      path: '/forgot-password',
      name: 'forgot password',
      component: () => import('../views/ForgotPasswordView.vue'),
      children: [
        {
          path: '',
          name: 'email',
          component: () => import('../views/ForgotPasswordEmailView.vue')
        },
        {
          path: 'question',
          name: 'question',
          component: () => import('../views/ForgotPasswordQuestionView.vue'),
          beforeEnter: (to, from, next) => {
            if (ForgotPasswordService.instance.hasEmail) next()
            else next({ name: 'forgot password' })
          },
        },
        {
          path: 'reset-password',
          name: 'reset password',
          component: () => import('../views/ForgotPasswordResetView.vue'),
          beforeEnter: (to, from, next) => {
            if (ForgotPasswordService.instance.hasEmail) next()
            else next({ name: 'forgot password' })
          },
        },
      ]
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: () => import('../views/DashboardView.vue'),
      beforeEnter: (to, from, next) => {
        //return SignInService.instance._isSignedIn
        if (SignInService.instance.isSignedIn) next()
        else next({ name: 'login' })
      },
      children: [
        {
          path: '',
          name: 'rules',
          component: () => import('../views/RulesView.vue')
        },
        {
          path: 'account',
          name: 'account',
          component: () => import('../views/AccountView.vue')
        },
        {
          path: 'customize',
          name: 'customize',
          component: () => import('../views/CustomizeView.vue')
        },
        {
          path: 'topics',
          name: 'topics',
          component: () => import('../views/TopicsView.vue')
        },
        {
          path: 'sides',
          name: 'sides',
          component: () => import('../views/SidesView.vue')
        },
        {
          path: 'shop',
          name: 'shop',
          component: () => import('../views/ShopView.vue'),
          children: [
            {
              path: '',
              name: 'choices',
              component: () => import('../views/ShopChoicesView.vue')
            },
            {
              path: 'avatars',
              name: 'avatars',
              component: () => import('../views/ShopAvatarsView.vue')
            },
            {
              path: 'titles',
              name: 'titles',
              component: () => import('../views/ShopTitlesView.vue')
            },
            {
              path: 'coins',
              name: 'coins',
              component: () => import('../views/ShopCoinsView.vue')
            }
          ]
        }
      ]
    }
  ]
})

export default router
