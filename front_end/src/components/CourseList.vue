<template>
      <div class="col-10 pt-4 pb-4 ps-4 pe-0">
        <div class="container-fluid" style="display: flex; flex-wrap: wrap">
          <CardCarousel
            class="margin: 0px;"
            :visible="visibility"
            :card="card"
            v-for="card in cards"
            :key="card.id_course"
          />
        </div>
      </div>
</template>

<script>
import CardCarousel from "./CardCarousel.vue";

export default {
  name: "CourseList",
  components: {
    CardCarousel,
  },
  props: {
    cards: [],
    visibility: Boolean
  },
};
</script>

<style scoped>
.btn-custom {
  color: black;
}

.btn-custom:hover {
  color: white;
}
</style>