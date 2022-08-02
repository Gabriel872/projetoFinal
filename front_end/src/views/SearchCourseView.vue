<template>
  <div class="view">
    <section>
      <CourseList :cards="cards" />
    </section>
  </div>
</template>

<script>
import CourseList from "@/components/CourseList.vue";

export default {
  name: "SearchCouseView",
  data() {
    return {
      cards:[],
      term: ""
    };
  },
  components: {
    CourseList,
  },
  beforeMount() {
    this.getCourses();
  },
  methods: {
    async getCourses() {
      const request = await fetch(`https://localhost:7114/api/Requests/searchTerm/${this.$route.params.term}`);
      const requestCourses = await request.json();
      this.cards = requestCourses;
    },
  },
};
</script>

<style scouped>



</style>