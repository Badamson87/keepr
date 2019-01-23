<template>
  <div class="home container-fluid">

    <!-- Welcome message -->

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">WELCOME TO YOUR USER DASH</h1>
      </div>
    </div>

    <!-- prime relestate -->

    <div class="row">
      <div class="col-6">
        <h4 class="text-warning m-3">Keeps</h4>
        <img @click="showData('keep'), getKeepsByUser()" src="../assets/img/treasure2.jpg">
        <div>
          <button type="button" class="btn btn-outline-warning" @click="showForm('keep')">New Keep</button>
        </div>
      </div>
      <div>
      </div>
      <div class="col-6">
        <h4 class="text-warning m-3">Vaults</h4>
        <img @click="showData('vault'), getVaultByUser()" src="../assets/img/door1.jpg">
        <div>
          <button type="button" class="btn btn-outline-warning" @click="showForm('vault')">New Vault</button>
        </div>
      </div>
    </div>


    <!-- forms for the new keep and vault -->

    <!-- form for keep -->
    <row>
      <div class="col">
        <div v-if="vaultForm" class="vaultform">
          <h3 class="text-warning">Build Your Vault</h3>
          <form>
            <div class="form-group">
              <input class="form-control" type="text" placeholder="Name" v-model="vaultFormData.name">
              <input class="form-control" type="text" placeholder="Description" v-model="vaultFormData.description">
              <button type="button" @click="createVault('vaultFormData')" class="btn btn-primary m-3">Create</button>
              <button type="button" @click="showForm()" class="btn btn-danger m-3">Close</button>
            </div>
          </form>
        </div>

        <!-- form for new vault -->

        <div v-if="keepForm" class="keepform">
          <h3 class="text-warning">Build Your Keep</h3>
          <form @submit.prevent="createKeep">
            <div class="form-group">
              <input class="form-control m-2" type="text" placeholder="Name" v-model="keepFormData.name">
              <input class="form-control m-2" type="text" placeholder="Description" v-model="keepFormData.description">
              <input class="form-control m-2" type="text" placeholder="Image Url" v-model="keepFormData.img">
              <input class="form-control m-2" type="checkbox" v-model="keepFormData.isPrivate">
              <p class="text-warning">Keep For Yourself</p>
              <button type="button" @click="createKeep('keepFormData')" class="btn btn-primary m-3">Create</button>
              <button type="button" @click="showForm()" class="btn btn-danger m-3">Close</button>
            </div>
          </form>
        </div>
      </div>
      <!-- the keeps or vaults you own -->
    </row>
    <div class="col">
      <div v-if="yourKeeps" class="yourKeeps">
        <div class="col allKeeps">
          <div v-for="keep in userKeeps">
            <div class="card m-2" style="width: 14rem;">
              <img class="card-img-top" :src="keep.img">
              <div class="card-body" @click="setActiveKeep(keep)">
                <router-link :to="{name: 'keep', params: {keepId: keep.id}}">
                  <p class="card-text">{{keep.name}}</p>
                </router-link>
                <i class="fas fa-eye icons"></i>: {{keep.views}}
                <i class="fas fa-share icons"></i>: {{keep.shares}}
                <i class="fas fa-dungeon icons"></i>: {{keep.keeps}}
              </div>
            </div>
          </div>
        </div>
      </div>
      <div v-if="yourVaults" class="yourVaults">
        <div class="col allKeeps">
          <div v-for="vault in userVaults">
            <div class="card m-3" style="width: 14rem;">
              <img src="../assets/img/stonedoor1.jpg" class="card-img-top">
              <div class="card-body">
                <h3 class="card-title">{{vault.name}}</h3>
                <p class="card-text">{{vault.description}}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import createKeep from '@/components/createKeep.vue'
  export default {
    name: "dash",
    data() {
      return {
        keepForm: false,
        vaultForm: false,
        yourKeeps: false,
        yourVaults: false,
        keepFormData: {},
        vaultFormData: {}
      }
    },
    computed: {
      userKeeps() {
        return this.$store.state.userKeeps
      },
      userVaults() {
        return this.$store.state.userVaults
      }
    },

    methods: {
      showForm(type) {
        if (type == "keep") {
          this.keepForm = true;
          this.vaultForm = false;
        } else if (type == "vault") {
          this.keepForm = false;
          this.vaultForm = true;
        } else {
          this.keepForm = false;
          this.vaultForm = false;
        }
      },
      showData(type) {
        if (type == "keep") {
          this.yourKeeps = true;
          this.yourVaults = false;
        } else if (type == "vault") {
          this.yourKeeps = false;
          this.yourVaults = true;
        } else {
          this.yourKeeps = false;
          this.yourVaults = false;
        }
      },

      getKeepsByUser() {
        this.$store.dispatch('getKeepsByUser')
      },
      getVaultByUser() {
        this.$store.dispatch('getVaultsByUser')
      },
      createKeep() {
        this.$store.dispatch('createKeep', this.keepFormData)
        this.keepFormData = {
          name: '',
          description: '',
          img: '',
          isPrivate: 0
        }
      },
      createVault() {
        this.$store.dispatch('createVault', this.vaultFormData)
        this.vaultFormData = {
          name: '',
          description: ''
        }
      }


    },
    components: {

    }
  };
</script>


<style>
  .card {
    color: gold;
    background-color: black;
  }
</style>