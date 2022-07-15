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
        <Carousel :items-to-show="2.5" :wrap-around="true">
          <Slide v-for="slide in 10" :key="slide">
            <div class="carousel__item">{{ slide }}</div>
          </Slide>

          <template #addons>
            <Navigation />
          </template>
        </Carousel>
      </div>
    </section>
    <section class="third ">
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

.carousel-inner {
  padding: 10px;
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
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  vertical-align: middle;
  padding: 10px;
  width: 300px;
  height: 150px;
  margin: auto;
}

/* Test */

.banner-teamplate {
  border-radius: 0px 0px 10px 10px;
  width: 1340px;
  height: 400px;
  background-color: lightskyblue;
}
</style>
