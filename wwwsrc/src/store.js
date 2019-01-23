import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    userKeeps: [],
    userVaults: [],
    activeKeep: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep
    },
    setUserKeeps(state, keeps) {
      state.userKeeps = keeps
    },
    setUserVaults(state, vaults) {
      state.userVaults = vaults
    }

  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },



    // keep routes

    getAllKeeps({ commit, dispatch }) {
      api.get('keeps/')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getKeepById({ commit, dispatch }, keep) {
      debugger
      api.get('keeps/' + keep.id)
        .then(res => {
          commit('setKeep', res.data)
        })
    },
    getKeepsByUser({ commit, dispatch }) {
      api.get("keeps/all")
        .then(res => {
          commit('setUserKeeps', res.data)
        })
        .catch(e => console.error(e))
    },
    createKeep({ commit, dispatch }, formData) {
      api.post('Keeps', formData)
        .then(res => {
          commit("setKeep", res.data)
          dispatch('getKeepsByUser')
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          console.log(res)
          dispatch('getKeepsByUser')
        })
        .catch(e => console.error(e))
    },






    // Vault routes


    getVaultsByUser({ commit, dispatch }, id) {

      api.get("vaults")
        .then(res => {
          commit('setUserVaults', res.data)
        })
        .catch(e => console.error(e))
    },
    createVault({ commit, dispatch }, formData) {
      api.post('vaults', formData)
        .then(res => {
          console.log(res.data)
          commit('setVaults', res.data)
          dispatch('getVaultsByUser')
        })
    }








  }






})