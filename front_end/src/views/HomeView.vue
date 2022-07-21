<template>
  <div class="view">
    <section class="first">
      <div class="container">
        <div class="banner-teamplate">
          <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
              <div class="carousel-item active">
                <img src="" class="d-block w-100" style=" height: 100%;" alt="...">
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
          <Carousel :items-to-show="4.5" :wrap-around="true">
            <!-- Teste -->
            <Slide v-for="card in cards" :key="card.id_course">
              <div class="card ml_mr carousel__item bg-dark text-bg-dark">
                <router-link :to="{ name: 'CoursePage', params: { id: card.id_course } }">
                  <div class="card-body">
                    <img src="../img/perfil.png" class="img-fluid" alt="...">
                    <h5 class="card-title">{{ card.course_title }}</h5>
                    <p class="card-text">
                      {{ card.course_subtitle }}
                    </p>
                    <!-- Colocar rating aqui -->
                  </div>
                </router-link>
              </div>
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
            <div class="promotion-card">
              Aprenda as habilidades mais procuradas com mais de 185.000 cursos em vídeo
            </div>
          </div>
          <div class="col-4">
            <div class="promotion-card">
              Escolha cursos lecionados por especialistas reais
            </div>
          </div>
          <div class="col-4">
            <div class="promotion-card">
              Estude no seu ritmo, com acesso vitalício no dispositivo móvel e no computador
            </div>
          </div>
        </div>
      </div>
    </section>
    <section class="second">
      <div class="container">
        <div class="row">
          <Carousel :items-to-show="4.5" :wrap-around="true">
            <!-- Teste -->
            <Slide v-for="card in cards" :key="card.id_course">
              <div class="card ml_mr carousel__item bg-dark text-bg-dark">
                <div class="card-body">
                  <h5 class="card-title">{{ card.title }}</h5>
                  <p class="card-text">
                    Some quick example text to build on the card title and make up the bulk of the card'scontent.
                  </p>
                </div>
              </div>
            </Slide>

            <template #addons>
              <Navigation />
            </template>
          </Carousel>
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
import CardCarouselVue from '@/components/CardCarousel.vue';
import 'vue3-carousel/dist/carousel.css';


export default {
  name: 'HomeView',
  components: {
    CardCarouselVue,
    Carousel,
    Slide,
    Navigation,
  },
  beforeMount() {
    this.list();
  },
  data() {
    return {
      cards: []
    }
  },
  methods: {
    async list() {
      const request = await fetch("https://localhost:7114/api/Courses");
      const retorno = await request.json();
      this.cards = retorno;
    }
  }
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

.ml_mr {
  margin: 0px 8px 0px 8px;
}

.first {
  padding: 0px;
}

.third {
  background-color: lightgrey;
  padding: 0px;
}

.carousel {
  /* background-color: rgb(139, 139, 139); */
  border-radius: 10px;
  height: 100%;
}

.promotion-card {
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  vertical-align: middle;
  padding: 10px;
  height: 100px;
  margin: auto;
  text-align: start;
}

/* Test */

.banner-teamplate {
  border-radius: 0px 0px 10px 10px;
  width: 100%;
  height: 400px;
  background-color: lightskyblue;
}
</style>
