<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col-12">
        <h1 Class="justify-content-center p-3 text-warning">You Keep What You Find</h1>

      </div>
    </div>

    <!-- Vaults here im thinking -->
    <div class="row">
      <div class="col allKeeps">
        <div v-for="keep in keeps">
          <div class="card m-2" style="width: 14rem;">
            <img src="keep.img" class="card-img-top">
            <div class="card-body" @click="setActiveKeep(keep)">
              <router-link :to="{name: 'keep', params: {keepId: keep._id, keep: keep}}">
                <p class="card-text">{{keep.name}}</p>
              </router-link>
              <p class="card-text">{{keep.description}}</p>
            </div>
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
    },
    methods: {
      setActiveKeep(keep) {
        this.$store.commit('setKeep', keep)
      }
    }

  };
</script>

<style>
  .allKeeps {
    display: flex;
    flex-wrap: wrap;
    justify-content: center
  }

  .card {
    flex-direction: column;
    column-count: 4
  }
</style>