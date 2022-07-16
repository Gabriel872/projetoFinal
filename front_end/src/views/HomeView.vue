<template>
  <div class="view">
    <section class="first">
      <div class="container">
        <div class="banner-teamplate">
          <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
              <div class="carousel-item active">
                <img src="" class="d-block w-100" style="background-color: blue;" alt="...">
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
      </div>
    </section>
    <section class="second">
      <div class="container">
        <div class="row">
          <Carousel :items-to-show="2.5" :wrap-around="true">
            <Slide v-for="slide in 10" :key="slide">
              <div class="carousel__item">{{ slide }}</div>
            </Slide>

            <template #addons>
              <Navigation />
            </template>
          </Carousel>
        </div>
      </div>

    </section>
    <section class="third">
      <div class="container">
        <div class="row">
          <div class="col-4">
            <div class="text-card">
              Teste de texto
            </div>
          </div>
          <div class="col-4">
            <div class="text-card">
              Teste de texto
            </div>
          </div>
          <div class="col-4">
            <div class="text-card">
              Teste de texto
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

import { defineComponent } from 'vue';
import { Carousel, Navigation, Slide } from 'vue3-carousel';

import 'vue3-carousel/dist/carousel.css';

export default {
  name: 'HomeView',
  components: {
    Carousel,
    Slide,
    Navigation,
  },
}
</script>

<style scoped>
section {
  padding: 10px;
  margin: 0px auto 10px auto;
}

.carousel__prev {
  background-color: black !important;
}

.first {
  padding: 0px;
}

.third {
  background-color: lightgrey;
  padding: 0px;
}

.carousel {
  background-color: rgb(139, 139, 139);
  border-radius: 10px;
  height: 100%;
}

.carousel-item{
}

.text-card {
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  vertical-align: middle;
  padding: 10px;
  height: 150px;
  margin: auto;
}

/* Test */

.banner-teamplate {
  border-radius: 0px 0px 10px 10px;
  width: 100%;
  height: 400px;
  background-color: lightskyblue;
}
</style>
