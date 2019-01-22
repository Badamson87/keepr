<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">WELCOME TO YOUR USER DASH</h1>
      </div>
    </div>

    <!-- Vaults here im thinking -->
    <div class="row">
      <div class="col-6">
        <h4 class="text-warning m-3">Your Keeps</h4>
        <img @click="showData('keep'), getKeepsByUser()" src="../assets/img/treasure2.jpg">
        <div>
          <button type="button" class="btn btn-outline-warning" @click="showForm('keep')">New Keep</button>
        </div>
      </div>
      <div>

      </div>
      <div class="col-6">
        <h4 class="text-warning m-3">Your Vaults</h4>
        <img @click="showData('vault')" src="../assets/img/door1.jpg">
        <div>
          <button type="button" class="btn btn-outline-warning" @click="showForm('vault')">New Vault</button>
        </div>
      </div>
    </div>
    <row>
      <div class="col">
        <!-- forums for the new items -->
        <div v-if="vaultForm" class="vaultform">
          VAULT FORM
        </div>
        <div v-if="keepForm" class="keepform">
          KEEP FORM
        </div>
      </div>
    </row>
    <div class="col">
      <!-- the keeps or vaults you own -->
      <div v-if="yourKeeps" class="yourKeeps">
        your keeps
      </div>
      <div v-if="yourVaults" class="yourVaults">
        your vaults
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
        yourVaults: false
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
          getVaultsByUser()
        } else {
          this.yourKeeps = false;
          this.yourVaults = false;
        }
      },

      getKeepsByUser() {
        this.$store.dispatch('getKeepsByUser')
      }


    },

    components: {

    }
  };
</script>