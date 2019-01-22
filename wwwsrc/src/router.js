import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dash from './views/Dash.vue'
// @ts-ignore
import Keep from './views/Keep.vue'
// @ts-ignore
import Vault from './views/Vault.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      props: true
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/dash',
      name: 'dash',
      component: Dash
    },
    {
      path: '/keep',
      name: 'keep',
      component: Keep,
      props: true
    },
    {
      path: '/vault',
      name: 'vault',
      component: Vault
    },
  ]
})
