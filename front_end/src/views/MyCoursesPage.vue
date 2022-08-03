<template>
    <div class="view">
    <section>
      <div
        class="container-fluid"
        style="
          margin: 10rem auto;
          width: 110rem;
          border-radius: 10px 10px 0px 0px;
          border: 1px solid lightgray;
        "
      >
        <div class="row">
          <CourseList :cards="cards" />
        </div>
      </div>
    </section>
  </div>
</template>

<script>

import CourseList from "@/components/CourseList.vue"

export default{
    name: "MyCoursePage",
    components:{
        CourseList,
    },
    data(){
        return{
            id_user: localStorage.getItem("userId"),
            cards: [],
        }
    },
    beforeMount(){
        this.id_user = localStorage.getItem("userId");
        this.verifyLogin();
        this.getCourses();
    },
    methods:{
        async getCourses(){
            const request = await fetch(`https://localhost:7114/api/UsersCourses/${this.id_user}`);
            const retorno = await request.json();
            this.cards = retorno;
        },
        verifyLogin(){
        if(!localStorage.getItem("login") || localStorage.getItem("login") == null){
           this.$router.replace({ path: '/' });
        }
    }
    }
}

</script>