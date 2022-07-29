<style>
.router-link-exact-active {
  color: black;
}

.router-link-exact-active:hover {
  color: black;
}
</style>
<template>
  <Navbar />
  <router-view />
  <Footer />
</template>

<script>
import Navbar from './components/Navbar.vue';
import Footer from './components/Footer.vue';

export default {
  data() {
    return {
      login: false,
    }
  },
  components: {
    Navbar,
    Footer
  },
  beforeMount() {

  }
};

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

.carousel__prev,
.carousel__next {
  background-color: black !important;
  border: 5px solid white !important;
  box-sizing: content-box !important;
}

.view {
  margin-top: 70px;
}
</style>
