<template>
  <div class="view" style="background-color: lightgray">
    <section class="container">
      <div class="row pt-5 pb-5">
        <div class="col-9 pt-4 pb-4" style="
            background-color: #212529;
            color: white;
            border-radius: 20px 0px 0px 20px;
          ">
          <section class="mb-5">
            <div class="container-fluid flex">
              <svg xmlns="http://www.w3.org/2000/svg" width="12rem" height="12rem" fill="currentColor"
                class="bi bi-journal img-fluid" viewBox="0 0 16 16">
                <path
                  d="M3 0h10a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-1h1v1a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v1H1V2a2 2 0 0 1 2-2z" />
                <path
                  d="M1 5v-.5a.5.5 0 0 1 1 0V5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1zm0 3v-.5a.5.5 0 0 1 1 0V8h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1zm0 3v-.5a.5.5 0 0 1 1 0v.5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1z" />
              </svg>
              <div class="container-fluid">
                <h1>
                  <b>{{ obj_course.course_name }}</b>
                </h1>
                <h2 style="font-size: 20px">
                  {{ obj_course.course_subtitle }}
                </h2>
                <div class="rating mb-2 flex">
                  <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="gold" class="bi bi-star-fill"
                    viewBox="0 0 16 16">
                    <path
                      d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" />
                  </svg>
                  <h3 style="margin-left: 0.5rem; font-size: 20px">
                    {{ obj_course.course_rating }}
                  </h3>
                </div>
                <div class="flex">
                  <h3 style="font-size: 16px; color: #35d3bc; margin-bottom: 0px">
                    Autor:<span style="margin-left: 0.2rem; color: white">{{
                      obj_course.user_name
                    }}</span>
                  </h3>
                  <p style="
                      margin-left: 0.5rem;
                      font-size: 16px;
                      margin-bottom: 0px;
                    ">
                    Data de criação: {{ obj_course.course_creation_date }}
                  </p>
                </div>
                <div>
                  <p style="font-size: 16px; margin-bottom: 0px">
                    {{ obj_course.course_language }}
                  </p>
                </div>
              </div>
            </div>
          </section>

          <div class="container-fluid flex">
            <div class="container-fluid custom-container">
              <div class="row">
                <div class="container mb-4">
                  <div class="card" style="background-color: #363c42; border: none">
                    <div class="card-header" style="border-color: #808080">
                      Descrição
                    </div>
                    <div class="card-body">
                      <p class="card-text">
                        {{ obj_course.course_description }}
                      </p>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="container mb-4">
                  <div class="card" style="background-color: #363c42; border: none">
                    <div class="card-header" style="border-color: #808080">
                      Requisitos
                    </div>
                    <div class="card-body">
                      <p class="card-text">
                        {{ obj_course.course_requirements }}
                      </p>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="container mb-4">
                  <div class="card" style="background-color: #363c42; border: none">
                    <div class="card-header" style="border-color: #808080">
                      Nível de conhcimento
                    </div>
                    <div class="card-body">
                      <p class="card-text">
                        {{ obj_course.course_knowledge_level }}
                      </p>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="container mb-4">
                  <div class="card" style="background-color: #363c42; border: none">
                    <div class="card-header" style="border-color: #808080">
                      O que você aprenderá
                    </div>
                    <div class="card-body">
                      <p class="card-text">{{ obj_course.course_learnings }}</p>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="container mb-4">
                  <div class="card" style="background-color: #363c42; border: none">
                    <div class="card-header" style="border-color: #808080">
                      Comentários
                    </div>
                    <div class="card-body">
                      <p class="card-text"></p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-3 pt-3" style="background-color: #363c42; border-radius: 0px 20px 20px 0px">
          <div class="container-fluid flex-grid" style="color: #212529">
            <div class="container-fluid" style="color: lightgray">
              <div class="flex">
                <h1 style="">R$ {{ obj_course.price_course_value }}</h1>
              </div>
              <div class="flex">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                  class="bi bi-trophy-fill" viewBox="0 0 16 16">
                  <path
                    d="M2.5.5A.5.5 0 0 1 3 0h10a.5.5 0 0 1 .5.5c0 .538-.012 1.05-.034 1.536a3 3 0 1 1-1.133 5.89c-.79 1.865-1.878 2.777-2.833 3.011v2.173l1.425.356c.194.048.377.135.537.255L13.3 15.1a.5.5 0 0 1-.3.9H3a.5.5 0 0 1-.3-.9l1.838-1.379c.16-.12.343-.207.537-.255L6.5 13.11v-2.173c-.955-.234-2.043-1.146-2.833-3.012a3 3 0 1 1-1.132-5.89A33.076 33.076 0 0 1 2.5.5zm.099 2.54a2 2 0 0 0 .72 3.935c-.333-1.05-.588-2.346-.72-3.935zm10.083 3.935a2 2 0 0 0 .72-3.935c-.133 1.59-.388 2.885-.72 3.935z" />
                </svg>
                <p class="ms-1" style="margin-bottom: 0px">Certificado</p>
              </div>
              <div class="row mt-5">
                <button @click="verifyLogin()" v-show="id_user != obj_course.id_author"
                  class="btn btn-primary btn-default" style="font-size: 30px">
                  <b>Comprar</b>
                </button>
                <button v-show="id_user == obj_course.id_author" class="btn btn-primary btn-default"
                  style="font-size: 20px">
                  <b>Editar</b>
                </button>
                <button @click="deleteCourse()" v-show="id_user == obj_course.id_author" class="btn btn-danger mt-2"
                  style="color: white; font-size: 20px">
                  <b>Deletar</b>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  data() {
    return {
      obj_id: 0,
      obj_course: {},
      obj_users_courses: {},
      id_user: localStorage.getItem("userId"),
    };
  },
  beforeMount() {
    this.getId();
    this.getCourse();
  },
  methods: {
    getId() {
      this.obj_id = this.$route.params.id;
    },
    async getCourse() {
      const request = await fetch(
        `https://localhost:7114/api/Request/cardCourseById/${this.obj_id}`
      );
      const course_request = await request.json();
      this.obj_course = await course_request[0];
    },
    async purchaseCourse() {
      this.obj_users_courses.id_user = localStorage.getItem("userId");
      this.obj_users_courses.id_course = this.obj_id;
      await fetch(`https://localhost:7114/api/UserCourse`, {
        method: "post",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.obj_users_courses),
      });
    },
    async deleteCourse() { },
    verifyLogin() {
      if (
        !localStorage.getItem("login") ||
        localStorage.getItem("login") == null
      ) {
        this.$router.replace({ path: "/login" });
      } else {
        this.purchaseCourse();
      }
    },
  },
};
</script>

<style scoped>
@media (min-width: 300px) {

  .bi .bi-journal,
  .bi-cash {
    width: 3rem;
  }
}

@media (min-width: 576px) {

  .bi .bi-journal,
  .bi-cash {
    width: 4rem;
  }
}

@media (min-width: 768px) {

  .bi .bi-journal,
  .bi-cash {
    width: 5rem;
  }
}

@media (min-width: 992px) {

  .bi .bi-journal,
  .bi-cash {
    width: 8rem;
  }
}

@media (min-width: 1200px) {

  .bi .bi-journal,
  .bi-cash {
    width: 9rem;
  }
}

@media (min-width: 1400px) {

  .bi .bi-journal,
  .bi-cash {
    width: 10rem;
  }
}

.btn-default {
  background-color: #35d3bc;
  border: none;
  outline: none;
  box-shadow: none;
}

.btn-default:hover {
  background-color: #008a75;
  border: none;
  outline: none;
  box-shadow: none;
}

.custom-container {
  margin-top: auto;
}
</style>