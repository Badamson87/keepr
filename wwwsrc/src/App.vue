<template>
  <div id="app">





    <!-- navbar -->


    <div>
      <nav class="navbar navbar-expand-lg navbar-light bg-warning">
        <a class="navbar-brand" href="/">Keepr</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText"
          aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarText">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item">
              <a class="nav-link" href="#/dash">DashBoard</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#/login" v-if="!active">login</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" @click="logout" href="/logout" v-if="active">logout</a>
            </li>
          </ul>

        </div>
      </nav>
    </div>
    <router-view />
  </div>
</template>

<script>
  export default {
    name: "app",

    computed: {
      active() {
        return this.$store.state.user.active

      }
    },

    methods: {
      logout() {
        this.$store.dispatch("logout")
      }
    }
  }

</script>



<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }


  body {
    background-image: fixed;
    background-size: 100vw;
    background-image: url("assets/img/water1.jpg")
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .bkImg {
    position: fixed;
    height: 100vh;


  }
</style>