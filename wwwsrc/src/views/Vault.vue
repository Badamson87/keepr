<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">A view for all the keeps within a single vault</h1>

      </div>
    </div>

    <!-- Vaults here im thinking -->

    <div class="row">
      <div class="col allKeeps">
        <div v-for="keep in vaultKeeps">
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
            <div>
              <i class="fas fa-bomb" @click="removeKeepFromVault(keep.id)"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: "vault",
    mounted() {
      this.$store.dispatch('getVaultKeep', this.$store.state.activeVault.id)
    },
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      },



    },
    methods: {
      getVaultKeep() {
        this.$store.dispatch('getVaultKeeps', id)
      },
      removeKeepFromVault(keepId) {
        let payload = {
          keepId: keepId,
          vaultId: this.$store.state.activeVault.id
        }
        this.$store.dispatch('removeVaultKeep', payload)
      },
      setActiveKeep(keep) {
        this.$store.commit('setActiveKeep', keep)
      }



    }
  };
</script>