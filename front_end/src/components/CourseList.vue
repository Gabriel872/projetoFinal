<template>
      <div class="col-10 pt-4 pb-4 ps-4 pe-0">
        <div class="container-fluid" style="display: flex; flex-wrap: wrap">
          <CardCarousel
            class="margin: 0px;"
            :card="card"
            v-for="card in cards"
            :key="card.ID_COURSE"
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