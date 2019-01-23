<template>
  <div class="containere-fluid">
    <div class="row">

      <div class="col">
        <h1>Keep Comming Back</h1>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "logout",

    mounted() {
      this.$store.dispatch('logout')
    }

  };
</script>