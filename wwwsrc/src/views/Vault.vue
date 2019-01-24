<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">A view for all the keeps within a single vault</h1>

      </div>
    </div>

    <!-- Vaults here im thinking -->
    <div class="row">


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
        debugger
        return this.$store.state.vaultKeeps
      },
      methods: {
        // getVaultKeep() {
        //   debugger
        //   this.$store.dispatch('getVaultKeeps', id)
        // }



      }


    }
  };
</script>