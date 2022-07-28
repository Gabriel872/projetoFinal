<template>
  <div class="view">
    <section class="first" style="margin-top: 5rem;">
      <div class="container">

        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner" style="border-radius: 10px; overflow:hidden;">
            <div class="carousel-item active">
              <img src="../img/banner2.png" class="d-block w-100 img-fluid" style="" alt="...">
            </div>
            <div class="carousel-item">
              <img src="../img/banner2.png" class="d-block w-100 img-fluid" style="" alt="...">
            </div>
            <div class="carousel-item">
              <img src="../img/banner2.png" class="d-block w-100 img-fluid" style="" alt="...">
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
    <section class="second">
      <div class="container">
        <div class="row">
          <Carousel :items-to-show="4.5" :wrap-around="true">
            <!-- Teste -->
            <Slide v-for="card in cards" :key="card.id_course">
              <router-link style="text-decoration: none; color:white;"
                :to="{ name: 'CoursePage', params: { id: card.id_course } }">
                <div class="card ml_mr carousel__item bg-dark text-bg-dark"
                  style="width: 240px; border: none; border-radius: 10px;">

                  <div class="flex" style="width:fit-content; overflow: hidden; border-radius: 10px  10px 0px 0px;">
                    <div
                      style="display: flex; align-items: center; justify-content: center; width:240px; height: 130px; background-color: rgb(54, 60, 66);">
                      <h1>"<b>Olá</b>"</h1>
                    </div>
                  </div>
                  <div class="card-body pt-2 pb-2" style="text-align: initial; height: 126px;">
                    <h1 class="card-title mb-2" style="font-size: 20px;"><b>{{ card.course_name }}</b></h1>
                    <h2 class="card-text mb-2" style="font-size: 14px;">autor {{ card.course_author }}</h2>
                    <div class="flex" style="justify-content: space-between;">
                      <div class="flex" style="color: #ffbc00;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                          class="bi bi-star-fill" viewBox="0 0 16 16">
                          <path
                            d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" />
                        </svg>
                        <h2 class="card-text mb-2 ms-1" style="font-size: 16px; color: #ff8d00;"><b>5</b></h2>
                      </div>

                      <h2 class="card-text mb-0" style="font-size: 16px;"><b>R$ 49,99</b></h2>
                    </div>
                  </div>

                </div>
              </router-link>
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
        <div class="row flex" style="justify-content:space-evenly ;">
          <div class="col-4">
            <div class="promotion-card painels" style="justify-content: center;">
              <div class="ps-2">
                <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="currentColor"
                  class="bi bi-star-fill" viewBox="0 0 16 16">
                  <path
                    d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" />
                </svg>
              </div>
              <div class="ms-4">
                Aprenda as habilidades mais procuradas com mais de 185.000 cursos em vídeo
              </div>
            </div>
          </div>
          <div class="col-4">
            <div class="promotion-card painels">
              <div class="ps-2">
                <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="currentColor"
                  class="bi bi-patch-check-fill" viewBox="0 0 16 16">
                  <path
                    d="M10.067.87a2.89 2.89 0 0 0-4.134 0l-.622.638-.89-.011a2.89 2.89 0 0 0-2.924 2.924l.01.89-.636.622a2.89 2.89 0 0 0 0 4.134l.637.622-.011.89a2.89 2.89 0 0 0 2.924 2.924l.89-.01.622.636a2.89 2.89 0 0 0 4.134 0l.622-.637.89.011a2.89 2.89 0 0 0 2.924-2.924l-.01-.89.636-.622a2.89 2.89 0 0 0 0-4.134l-.637-.622.011-.89a2.89 2.89 0 0 0-2.924-2.924l-.89.01-.622-.636zm.287 5.984-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 1 1 .708-.708L7 8.793l2.646-2.647a.5.5 0 0 1 .708.708z" />
                </svg>
              </div>
              <div class="ms-4" style="font-size: 16px;">
                Escolha cursos lecionados por especialistas reais
              </div>
            </div>
          </div>
          <div class="col-4">
            <div class="promotion-card painels">
              <div class="ps-2">
                <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="currentColor"
                  class="bi bi-clock-fill" viewBox="0 0 16 16">
                  <path
                    d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8 3.5a.5.5 0 0 0-1 0V9a.5.5 0 0 0 .252.434l3.5 2a.5.5 0 0 0 .496-.868L8 8.71V3.5z" />
                </svg>
              </div>
              <div class="ms-4">
                Estude no seu ritmo, com acesso vitalício no dispositivo móvel e no computador
              </div>
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
              <router-link style="text-decoration: none; color:white;"
                :to="{ name: 'CoursePage', params: { id: card.id_course } }">
                <div class="card ml_mr carousel__item bg-dark text-bg-dark"
                  style="width: 240px; border: none; border-radius: 10px;">

                  <div class="flex" style="width:fit-content; overflow: hidden; border-radius: 10px  10px 0px 0px;">
                    <div
                      style="display: flex; align-items: center; justify-content: center; width:240px; height: 130px; background-color: rgb(54, 60, 66);">
                      <h1>"<b>Olá</b>"</h1>
                    </div>
                  </div>
                  <div class="card-body pt-2 pb-2" style="text-align: initial; height: 126px;">
                    <h1 class="card-title mb-2" style="font-size: 20px;"><b>{{ card.course_name }}</b></h1>
                    <h2 class="card-text mb-2" style="font-size: 14px;">autor {{ getCourseAuthor(card.id_author) }}</h2>
                    <div class="flex" style="justify-content: space-between;">
                      <div class="flex" style="color: #ffbc00;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                          class="bi bi-star-fill" viewBox="0 0 16 16">
                          <path
                            d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" />
                        </svg>
                        <h2 class="card-text mb-2 ms-1" style="font-size: 16px; color: #ff8d00;"><b>5</b></h2>
                      </div>

                      <h2 class="card-text mb-0" style="font-size: 16px;">
                        <b>R${{ getCoursePrice(card.id_price_course) }}</b>
                      </h2>
                    </div>
                  </div>

                </div>
              </router-link>
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
      cards: [],
    }
  },
  methods: {
    async list() {
      const request = await fetch("https://localhost:7114/api/Courses");
      const retorno = await request.json();
      this.cards = retorno;
    },
    async getCourseAuthor(id_user) {
      const request = await fetch(`https://localhost:7114/api/Users/${id_user}`);
      const retorno = await request.json();
      return retorno.user_name; // se for proxy pegar pela posição
    },
    async getCoursePrice(id_price) {
      const request = await fetch(`https://localhost:7114/api/PriceCourses/${id_price}`);
      const retorno = await request.json();
      console.log(retorno[0].price_course_value);
      return retorno[0].price_course_value;
    }
  }
}
</script>

<style scoped>
section {
  padding: 10px;
  margin: 0px auto 10px auto;
}

.banner {
  overflow: hidden;
  border-radius: 10px;
}

.painels {
  background-color: #c1fff6;
  border-radius: 20px;
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
  padding: 0px;
}

.carousel {
  /* background-color: rgb(139, 139, 139); */
  border-radius: 10px;
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
</style>