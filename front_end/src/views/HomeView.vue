<template>
  <div class="home" style="margin-top: 70px;">
    <section class="first">
      <div class="container">
        <div class="banner-teamplate">

        </div>
      </div>
    </section>
    <section class="second carrousel">
      <div class="container">
        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner">
            <div class="carousel-item active">
              <img src="" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="" class="d-block w-100" alt="...">
            </div>
          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls"
            data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls"
            data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div>
      </div>
    </section>
    <section class="third ">
      <div class="container">
        <div class="row">
          <div class="col-4">
            <div class="text-card">
              <h3>Teste de texto</h3>
            </div>
          </div>
          <div class="col-4">
            <div class="text-card">

            </div>
          </div>
          <div class="col-4">
            <div class="text-card">

            </div>
          </div>
        </div>
      </div>
    </section>
    <section class="first">
      <div class="container">
        <div class="banner-teamplate">

        </div>
      </div>
    </section>
  </div>
</template>

<script>

export default {
  name: 'HomeView',
}
</script>

<style scoped>
section {
  padding: 10px;
  margin: 0px auto 10px auto;
}

.first {
  padding: 0px;
}

.second {
  width: 1340px;
}

.third {
  background-color: lightgrey;
  padding: 0px;
}

.container {
  height: 100%;
}

.carousel {
  background-color: rgb(139, 139, 139);
  border-radius: 10px;
}

.text-card {
  text-align: center;
  vertical-align: middle;
  width: 300px;
  height: 150px;
  margin: auto;
}

/* Test */

.banner-teamplate {
  width: 1340px;
  height: 400px;
  background-color: lightskyblue;
}
</style>
