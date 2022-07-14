<template>
  <div class="home">
    <section class="first">

    </section>
    <section class="second carrousel">
      <div class="container">
        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner" style="background-color: blue;">
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
    <section class="third">

    </section>
    <section class="first">

    </section>
  </div>
</template>

<script>

export default {
  name: 'HomeView',
}
</script>

<style>

section{
  padding: 10px;
}

.first {
  width: 1340px;
  height: 400px;
  background-color: rgb(223, 191, 191);
  margin: auto;
}

.second {
  width: 1340px;
  background-color: rgb(139, 139, 139);
  margin: auto;
}

.third {
  height: 100px;
  background-color: lightgrey;
  margin: auto;
}

.container {
  
  height: 100%;
}
</style>
