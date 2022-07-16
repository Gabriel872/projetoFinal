<template>
  <div>
    <nav class="navbar navbar-expand-lg bg-dark navbar-dark fixed-top">
      <div class="container-fluid">
        <router-link class="navbar-brand" to="/">Navbar</router-link>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse collapse show" id="navbarSupportedContent">
          <ul class="navbar-nav mb-2 mb-lg-0">
            <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown"
                aria-expanded="false">
                Categorias
              </a>
              <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                <li>
                  <router-link class="dropdown-item" to="/">Action</router-link>
                </li>
                <li>
                  <router-link class="dropdown-item" to="/">Another action</router-link>
                </li>
                <li>
                  <hr class="dropdown-divider">
                </li>
                <li>
                  <router-link class="dropdown-item" to="/">Something else here</router-link>
                </li>
              </ul>
            </li>
          </ul>
          <div class="d-flex container-fluid">
            <div class="container-fluid">
              <form role="search">
                <input class="form-control me-2 search-bar" type="search" placeholder="Pesquisar curso"
                  aria-label="Search">
              </form>
            </div>
            <button v-on:click="searchCourse()" class="btn btn-primary btn-search">
              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search"
                viewBox="0 0 16 16">
                <path
                  d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
              </svg>
            </button>
          </div>
          <ul class="navbar-nav mb-2 mb-lg-0">
            <!-- TESTE V-IF-->
            <li v-if="1 == 0" class="nav-item">
              <a class="nav-link" href="" role="button" aria-expanded="false">
                My courses
              </a>
            </li>
            <!-- TESTE V-IF-->
            <li v-if="1 == 0" class="nav-item">
              <router-link class="nav-link" to="/instructor" role="button" aria-expanded="false">
                Instructor
              </router-link>
            </li>
          </ul>
          <div class="d-flex jf_center">
            <!-- TESTE V-IF-->
            <button v-on:click="signUp()" class="btn btn-primary signin" style="margin-right: 8px;"
              type="submit"><b>Sign
                up</b></button>
            <!-- TESTE V-IF-->
            <button v-on:click="logIn()" class="btn btn-primary btn-login" type="submit"><b>Log in</b></button>
            <!-- TESTE V-IF-->
            <button v-if="1 == 0" v-on:click="userView()" class="btn btn-user">
              <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor"
                class="bi bi-person-fill" viewBox="0 0 16 16">
                <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
              </svg>
            </button>
          </div>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
export default {
  name: 'NavBar',
  data() {
    return {

    }
  },
  methods: {
    logIn() {
      this.$router.replace({ path: '/login' })
    },
    signUp() {
      this.$router.replace({ path: '/signup' })
    },
    searchCourse() {
      this.$router.replace({ path: '/searchCourse' })
    },
    userView() {
      this.$router.replace({ path: '/user' })
    },
    instructorView() {
      this.$router.replace({ path: '/instructor' })
    }
  },
  props: {
    msg: String
  }
}

</script>

<style scoped>
.navbar-brand {
  color: white;
}

.navbar-brand:hover {
  color: #35d3bc;
}

button {
  white-space: nowrap;
}

.jf_center {
  justify-content: center;
}

.nav-item {
  white-space: nowrap !important;
}

.search-bar {
  border: none;
  padding-top: 8px;
  padding-bottom: 8px;
}

.search-bar:focus {
  box-shadow: none;
  border: none;
}

.btn-search {
  background-color: #35d3bc;
  border: none;
  padding-top: 8px;
  padding-bottom: 8px;
}

.btn-search:hover {
  background-color: #008a75;
}


.btn:focus {
  outline: none;
  box-shadow: none;
}

.btn-user {
  color: white;
}

.nav-item {
  margin-right: 8px;
}

.navbar-expand-lg {
  padding-top: 15px;
  padding-bottom: 15px;
}

.signin {
  background-color: transparent;
  border-radius: 10px;
  border-color: #35d3bc;
  border-width: 2px;
}

.signin:hover {
  background-color: #35d3bc;
}

.btn-login {
  background-color: #35d3bc;
  border: none;
}

.btn-login:hover {
  background-color: #008a75;
  border: none;
}

.nav-link,
.dropdown-toggle {
  color: white;
}

.dropdown-toggle:hover {
  color: rgb(138, 138, 138);
}
</style>
