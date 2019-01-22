<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">The view for a single keep</h1>


      </div>
    </div>

    <!-- Vaults here im thinking -->
    <div class="row">
      <div class="col">
        <div>
          <img :src="activeKeep.img">
        </div>
        <div class="icons">
          <i class="fas fa-eye icons"></i>: <p class="text-warning icons mr-5">{{activeKeep.views}}</p>
          <i class="fas fa-share icons"></i>: <p class="text-warning icons mr-5">{{activeKeep.shares}}</p>
          <i class="fas fa-dungeon icons"></i>: <p class="text-warning icons">{{activeKeep.keeps}}</p>
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
    // props: { activeKeep },
    // data() {
    //   return {
    //     activeKeep: {}
    //   }
    // },

    mounted() {
      return this.$store.state.activeKeep || {}

      // this.$store.dispatch("getVaults")



    },
    watch: {
      // keep() {
      //   debugger
      //   this.$store.dispatch('getKeepById', this.keepId)
      // }
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep

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