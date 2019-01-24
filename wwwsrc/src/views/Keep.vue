<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">The view for a single keep</h1>


      </div>
    </div>

    <!-- keep here im thinking -->
    <div class="row">
      <div class="col">
        <div>
          <img :src="activeKeep.img">
        </div>
        <div class="icons">
          <i class="fas fa-eye icons text-warning"></i>
          <p class="text-warning icons mr-5">: {{activeKeep.views}}</p>
          <i class="fas fa-share icons text-warning"></i>
          <p class="text-warning icons mr-5" @click="updateKeepShares()">: {{activeKeep.shares}}</p>
          <i class="fas fa-dungeon icons text-warning"></i>
          <p class="text-warning icons">: {{activeKeep.keeps}}</p>
        </div>
        <div class="dropdown">
          <button class="btn btn-sm dropdown-toggle icon" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false"> Keep It
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <p class="dropdown-item action" v-for="vault in vaults" @click="addToVault(vault.id)" v-bind:value="vaults.id">{{vault.name}}</p>
          </div>
        </div>
        <div>
          <h3 class="text-warning m-3">{{activeKeep.name}}</h3>
        </div>
        <div>
          <p class="text-warning">{{activeKeep.description}}</p>
        </div>

      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "keep",
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      vaults() {
        return this.$store.state.userVaults
      },
    },
    mounted() {
      this.$store.dispatch('getVaultsByUser')
      let payload = {
        keepId: this.$store.state.activeKeep.id,
        views: this.$store.state.activeKeep.views += 1,
        shares: this.$store.state.activeKeep.shares,
        keeps: this.$store.state.activeKeep.keeps

      }
      this.$store.dispatch('updateKeep', payload)
    },
    methods: {
      addToVault(vaultId) {
        let payload = {
          keepId: this.activeKeep.id,
          vaultId: vaultId,
        }
        this.$store.dispatch('addVaultKeep', payload)
      },
      updateKeepShares() {
        let payload = {
          keepId: this.$store.state.activeKeep.id,
          views: this.$store.state.activeKeep.views,
          shares: this.$store.state.activeKeep.shares += 1,
          keeps: this.$store.state.activeKeep.keeps
        }
        this.$store.dispatch('updateKeep', payload)
      }
    }

  };
</script>

<style>
  .activeKeep {
    justify-content: center
  }

  .icons {
    display: inline
  }
</style>