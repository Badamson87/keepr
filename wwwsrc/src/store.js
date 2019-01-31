import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

var production = !window.location.host.includes('localhost');
var baseUrl = production ? 'https://findandkeep.herokuapp.com/' : '//localhost:5000/';


let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    userKeeps: [],
    userVaults: [],
    activeKeep: {},
    activeVault: {},
    vaultKeeps: []
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
    },
    setActiveVault(state, vault) {
      state.activeVault = vault
    },
    setVaultKeeps(state, keeps) {
      state.vaultKeeps = keeps
    },
    logout(state) {
      state.user = {}
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
    logout({ commit, dispatch }) {
      auth.delete('/logout')
        .then(res => {
          commit('setUser', {})
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
      api.get('keeps/' + keep.id)
        .then(res => {
          commit('setActiveKeep', res.data)
          router.push("keep/")
        })
        .catch(e => console.error(e))
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
          dispatch('getKeepsByUser')
        })
        .catch(e => console.error(e))
    },
    updateKeep({ commit, dispatch }, payload) {
      api.put('keeps/' + payload.keepId, payload)
        .then(res => {
          console.log(res)
        })
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
          commit('setVaults', res.data)
          dispatch('getVaultsByUser')
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getVaultsByUser')
        })
        .catch(e => console.error(e))
    },
    setActiveVault({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          commit('setActiveVault', res.data)
          router.push("vault")
        })
        .catch(e => console.error(e))
    },




    // vault keep routes




    getVaultKeep({ commit, dispatch }, id) {
      api.get('vaultKeeps/' + id)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
        .catch(e => console.error(e))
    },
    addVaultKeep({ commit, dispatch }, payload) {
      api.post('vaultKeeps', payload)
        .then(res => {
        })
        .catch(e => console.error(e))
    },
    removeVaultKeep({ commit, dispatch }, payload) {
      api.put('vaultkeeps/', payload)
        .then(res => {
          dispatch('getVaultKeep', payload.vaultId)
        })
        .catch(e => console.error(e))
    }








  }
})