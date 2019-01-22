<template>
  <form @submit.prevent="createKeep" class="keepForm">


    <div class="form-group">
      <input class="form-control" type="text" placeholder="Name" v-model="formData.Name">
      <input class="form-control" type="text" placeholder="Description" v-model="formData.Description">
      <input class="form-control" type="text" placeholder="Image" v-model="formData.Img">
      <input class="form-control" type="checkbox" v-model="formData.isPrivate">

    </div>
  </form>
</template>

<script>
  export default {
    name: 'createKeep',
    data() {
      return {
        newKeep: {

        }
      }
    },
    computed: {
      user() {
        this.$store.state.user
      }
    },
    methods: {
      createKeep() {
        this.formData.title = this.title
      }
    }
  }

</script>