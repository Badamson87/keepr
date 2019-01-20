<template>
  <div class="home container-fluid">

    <div class="row">
      <h1>Welcome Home</h1>

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