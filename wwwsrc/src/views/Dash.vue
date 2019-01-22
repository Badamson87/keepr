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
        <h4 class="text-warning m-3">Your Treasures</h4>
        <img src="../assets/img/treasure2.jpg">
        <div>
          <button type="button" class="btn btn-outline-warning" @click="activeView">New Treasure</button>
        </div>
      </div>
      <div>

      </div>
      <div class="col-6">
        <h4 class="text-warning m-3">Your Vaults</h4>
        <img src="../assets/img/door1.jpg">
        <div>
          <button type="button" class="btn btn-outline-warning">New Vault</button>
        </div>
      </div>
    </div>

    <row>
      <div class="col-12">
        <!-- want the stuff to display here -->

      </div>
    </row>
  </div>
</template>

<script>
  export default {
    name: "dash",
    mounted() {
    },
  };
</script>