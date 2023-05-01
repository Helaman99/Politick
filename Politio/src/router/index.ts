import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'login',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/signup',
      name: 'signup',
      component: () => import('../views/SignUpView.vue')
    },
    {
      path: '/home',
      name: 'home',
      component: HomeView
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
      path: '/chat',
      name: 'chat',
      component: () => import('../views/ChatView.vue')
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
      path: '/dashboard',
      name: 'dashboard',
      component: () => import('../views/DashboardView.vue'),
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
              path: 'mystery-boxes',
              name: 'mystery-boxes',
              component: () => import('../views/MysteryBoxesView.vue')
            }
          ]
        }
      ]
    }
  ]
})

export default router
