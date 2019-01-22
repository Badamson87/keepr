<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">You Keep What You Find</h1>

      </div>
    </div>

    <!-- Vaults here im thinking -->
    <div class="row">
      <div class="col">
        <div v-for="keep in keeps">
          <div class="card">
            <img class="" :src="keep.img">
            <p class="textSpace">{{keep.name}}</p>


          </div>

        </div>


      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
    }

  };
</script>