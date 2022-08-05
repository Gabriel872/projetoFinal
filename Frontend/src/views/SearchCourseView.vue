<template>
  <div class="view">
    <section>
      <div
        class="container-fluid"
        style="
          margin: 10rem auto;
          width: 116rem;
          border-radius: 10px 10px 0px 0px;
          border: 1px solid lightgray;
        "
      >
        <div class="row"></div>
        <div class="row">
          <CourseList :cards="cards" :visibility="true" />
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import CourseList from "@/components/CourseList.vue";

export default {
  name: "SearchCouseView",
  data() {
    return {
      cards: [],
      term: "",
    };
  },
  components: {
    CourseList,
  },
  beforeMount() {
    this.cards = [];
    this.term = this.$route.params.term;
    this.getCourses();
  },
  beforeRouteUpdate(to, from, next) {
    this.cards = [];
    this.term = to.params.term;
    this.getCourses();
    next();
  },
  methods: {
    async getCourses() {
      const request = await fetch(
        `https://localhost:7114/api/Request/search/${this.term}`
      );
      const requestCourses = await request.json();
      this.cards = requestCourses;

      const requestByCategory = await fetch(
        `https://localhost:7114/api/Request/search/category/${this.term}`
      );
      const requestCoursesByCategory = await requestByCategory.json();

      for (var i = 0; i < requestCoursesByCategory.length; i++) {
        this.cards.push(requestCoursesByCategory[i]);
      }
    },
  },
};
</script>