<template>
  <div class="view">
    <section class="container" style="
        padding: 30px;
        background-color: #1a1d1e;
        margin-top: 10rem;
        border-radius: 10px 10px 0px 0px;
      ">
      <div class="row">
        <div class="header-instructor">
          <h1>Instrutor</h1>
        </div>
      </div>
      <hr style="color: white" />
      <div class="row" style="padding-top: 1rem">
        <div class="col-2">
          <div class="container-fluid">
            <button class="btn btn-primary btn-custom" style="display: block" @click="changeView(0)">
              Cursos
            </button>
            <button class="btn btn-primary btn-custom" style="display: block" @click="changeView(1)">
              Criar curso
            </button>
          </div>
        </div>
        <div class="col-10">
          <div class="container-fluid" style="color: white; padding: 20px">
            <div class="row">
              <div v-show="!visible">
                <h2>Criar curso</h2>
              </div>
              <div v-show="visible">
                <h2>Cursos</h2>
              </div>
            </div>
            <hr />
            <div class="row" v-show="visible">
              <CourseList :cards="cards" />
            </div>
            <div class="row" v-show="!visible">
              <div class="container-fluid">
                <section class="container-fluid flex mt-3" style="justify-content: start">
                  <div class="mb-3 container-fluid" style="width: 35rem">
                    <label for="titleFormControlInput1" class="form-label">Título</label>
                    <input v-model="obj_course.course_name" type="text" class="form-control" id="titleFormControlInput1"
                      placeholder="" />
                  </div>
                  <div class="mb-3 container-fluid" style="width: 35rem">
                    <label for="subtitleFormControlInput1" class="form-label">Subtítulo</label>
                    <input v-model="obj_course.course_subtitle" type="text" class="form-control"
                      id="subtitleFormControlInput1" placeholder="" />
                  </div>
                </section>

                <section class="container-fluid mt-3">
                  <div class="mb-3 container-fluid">
                    <label for="exampleFormControlTextarea1" class="form-label">Descrição</label>
                    <textarea v-model="obj_course.course_description" class="form-control"
                      id="exampleFormControlTextarea1" rows="4" placeholder="Descrição do curso..."></textarea>
                  </div>
                  <div class="mb-3 container-fluid">
                    <label for="requirementsFormControlTextarea1" class="form-label">Requisitos</label>
                    <textarea v-model="obj_course.course_requirements" class="form-control"
                      id="requirementsFormControlTextarea1" rows="4" placeholder="Requisitos do curso..."></textarea>
                  </div>
                </section>

                <section class="container-fluid flex mt-3">
                  <div class="mb-3 container-fluid">
                    <label for="selectlanguage" class="form-label">Idioma</label>
                    <select v-model="obj_course.course_language" class="form-select" aria-label="Default select example"
                      id="selectlanguage">
                      <option selected>Escolha o idioma</option>
                      <option value="Portuguese">Português</option>
                      <option value="English">Inglês</option>
                      <option value="Spanish">Espanhol</option>
                    </select>
                  </div>
                  <div class="mb-3 container-fluid">
                    <label for="timeFormControlInput1" class="form-label">Tempo do curso</label>
                    <input min="0" v-model="obj_course.course_time" type="number" class="form-control"
                      id="timeFormControlInput1" placeholder="60h" />
                  </div>
                </section>

                <section class="container-fluid flex mt-3">
                  <div class="mb-3 container-fluid">
                    <label for="selectlanguage" class="form-label">Nível de conhecimento</label>
                    <select v-model="obj_course.course_knowledge_level" class="form-select"
                      aria-label="Default select example" id="selectlanguage">
                      <option selected>Escolha o nível de conhecimento</option>
                      <option value="Beginner">Iniciante</option>
                      <option value="Intermediary">Intermediário</option>
                      <option value="Advanced">Avançado</option>
                    </select>
                  </div>
                  <div class="mb-3 container-fluid">
                    <label for="categoryOptions" class="form-label">Categorias</label>
                    <select v-model="obj_course.id_category" class="form-select" aria-label="Default select example"
                      id="categoryOptions">
                      <option value="0" selected>Escolha categoria</option>
                      <option v-for="category in categoryList" v-bind:key="category.id_category"
                        :value="category.id_category">
                        {{ category.category_name }}
                      </option>
                    </select>
                  </div>
                  <div class="mb-3 container-fluid">
                    <label for="priceOptions" class="form-label">Preço</label>
                    <select v-model="obj_course.id_price_course" class="form-select" aria-label="Default select example"
                      id="priceOptions">
                      <option selected>Ecolha o preço</option>
                      <option v-for="price in priceList" v-bind:key="price.id_price_course"
                        :value="price.id_price_course">
                        {{ price.price_course_value }}
                      </option>
                    </select>
                  </div>
                </section>

                <section class="container-fluid mt-3">
                  <div class="mb-3 container-fluid">
                    <label for="linkFormControlInput1" class="form-label">Link do curso</label>
                    <input v-model="obj_course.course_link" type="url" class="form-control" id="linkFormControlInput1"
                      placeholder="" />
                  </div>
                  <div class="mb-3 container-fluid">
                    <label for="audienceFormControlInput1" class="form-label">Audiência</label>
                    <input v-model="obj_course.course_audience" type="text" class="form-control"
                      id="audienceFormControlInput1" placeholder="" />
                  </div>
                </section>
              </div>
            </div>
            <div v-show="!visible" class="row mt-3">
              <div class="flex" style="justify-content: center">
                <button v-on:click="createCourse()" class="btn btn-primary" style="width: 50rem">
                  Criar
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
import CourseList from "@/components/CourseList.vue";

export default {
  components: {
    CourseList,
  },
  data() {
    return {
      obj_course: {},
      id_user: localStorage.getItem("userId"),
      priceList: [],
      categoryList: [],
      cards: [],
      visible: true,
    };
  },
  beforeMount() {
    console.log(new Date().getDate())
    this.verifyLogin();
    this.getCourse();
    this.getPrices();
    this.getCategories();
  },
  methods: {
    async getCourse() {
      const request = await fetch(
        "https://localhost:7114/api/Request/cardCourse"
      );
      const request_return = await request.json();
      for (var i = 0; i < request_return.length; i++) {
        if (request_return[i].id_author == this.id_user) {
          this.cards.push(request_return[i]);
        }
      }
    },
    async createCourse() {

      var today = new Date();
      var date =
        today.getFullYear() +
        "-" +
        (today.getMonth() + 1) +
        "-" +
        today.getDate();

      this.obj_course.course_creation_date = date;
      this.obj_course.id_author = this.id_user;

      await fetch("https://localhost:7114/api/RegisterCourse", {
        method: "post",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.obj_course),
      });

      this.visible = true;
      alert("Curso criado.");
    },
    async getPrices() {
      const request = await fetch("https://localhost:7114/api/PriceCourse");
      const retorno = await request.json();
      this.priceList = retorno;
    },
    async getCategories() {
      const request = await fetch("https://localhost:7114/api/Category");
      const retorno = await request.json();
      this.categoryList = retorno;
    },
    verifyLogin() {
      if (
        !localStorage.getItem("login") ||
        localStorage.getItem("login") == null
      ) {
        this.$router.replace({ path: "/" });
      }
    },
    changeView(btn) {
      if (btn == 0) {
        this.visible = true;
      } else {
        this.visible = false;
      }
    },
  },
};
</script>

<style scouped>
.header-instructor {
  display: flex;
  color: white;
}

.btn-custom {
  background-color: transparent;
  border: none;
}

.btn-custom:hover {
  background-color: transparent;
  border: none;
  color: white;
}
</style>