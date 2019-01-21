<template>
  <div class="home container-fluid">

    <div class="row">
      <div class="col">
        <h1 Class="justify-content-center pt-3 text-warning">You Keep What You Find</h1>

      </div>
    </div>

    <!-- Vaults here im thinking -->
    <div class="row">


    </div>

  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }

      this.$store.dispatch("getAllKeeps")
    },
  };
</script>