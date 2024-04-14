<template>
  <div class="view">
    <section class="container container-fluid">
      <div class="row">
        <div style="margin-top: 7rem;">
          <h1><b>Meus cursos</b></h1>
        </div>
      </div>
    </section>
    <section>
      <div
        class="container container-fluid"
        style="
          margin: 0.5rem auto 10rem auto;
          border-radius: 10px 10px 0px 0px;
          border: 1px solid lightgray;
          padding: 1%;
        "
      >
        <CourseList :cards="cards" :visibility="false" />
      </div>
    </section>
  </div>
</template>

<script>
import CourseList from "@/components/CourseList.vue";

export default {
  name: "MyCoursePage",
  components: {
    CourseList,
  },
  data() {
    return {
      id_user: localStorage.getItem("userId"),
      cards: [],
    };
  },
  beforeMount() {
    this.id_user = localStorage.getItem("userId");
    this.verifyLogin();
    this.getCourses();
  },
  methods: {
    async getCourses() {
      const request = await fetch(
        `https://localhost:7114/api/UserCourse/${this.id_user}`
      );
      const retorno = await request.json();
      this.cards = retorno;
    },
    verifyLogin() {
      if (
        !localStorage.getItem("login") ||
        localStorage.getItem("login") == null
      ) {
        this.$router.replace({ path: "/" });
      }
    },
  },
};
</script>