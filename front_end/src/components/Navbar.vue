<template>
  <div>
    <nav class="navbar navbar-expand-lg bg-dark navbar-dark fixed-top">
      <div class="container-fluid">
        <a class="navbar-brand" href="">Navbar</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav  mb-2 mb-lg-0">
            <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown"
                aria-expanded="false">
                Categorias
              </a>
              <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                <li><a class="dropdown-item" href="">Action</a></li>
                <li><a class="dropdown-item" href="">Another action</a></li>
                <li>
                  <hr class="dropdown-divider">
                </li>
                <li><a class="dropdown-item" href="">Something else here</a></li>
              </ul>
            </li>
          </ul>
          <div class="d-flex">
            <form class="d-flex search-form" role="search">
              <input class="form-control me-2 search-bar" type="search" placeholder="Pesquisar curso"
                aria-label="Search">

            </form>
            <button class="btn btn-primary">
              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search"
                viewBox="0 0 16 16">
                <path
                  d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
              </svg>
            </button>
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <a class="nav-link" href="">Meus cursos</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="">Instrutor</a>
              </li>
            </ul>
          </div>
          <div class="d-flex">

            <button class="btn btn-primary signin" style="margin-right: 8px;" type="submit"><b>Cadastrar</b></button>
            <button class="btn btn-primary btn-login" type="submit"><b>Entrar</b></button>
            <button class="btn btn-user">
              <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
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
  props: {
    msg: String
  }
}
</script>

<style scoped>
.btn:focus {
  outline: none;
  box-shadow: none;
}

.btn-user {
  color: white;
  margin-left: 8px;
}

.navbar-collapse {
  justify-content: space-between;
}

.nav-item {
  margin-right: 8px;
}

.navbar-expand-lg {
  height: 70px;
}

.search-form {

  width: 800px;
}

.search-bar {
  margin-left: 8px;
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
</style>
