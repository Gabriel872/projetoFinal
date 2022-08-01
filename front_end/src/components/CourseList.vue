<template>
  <div
    class="container-fluid"
    style="
      margin: 10rem auto;
      width: 110rem;
      border-radius: 10px 10px 0px 0px;
      border: 1px solid lightgray;
    "
  >
    <div class="row"></div>
    <div class="row">
      <div class="col-2">
        <div
          class="container-fluid p-4"
          style="display: flex; justify-content: center; height: 100%"
        >
          <div class="container mt-2">
            <button class="btn btn-primary btn-custom" style="width: 100%">
              <b>Teste</b>
            </button>
            <label for="customRange3" class="form-label">Example range</label>
            <input
              type="range"
              class="form-range"
              :min="0"
              :max="100"
              :step="10"
              id="customRange3"
            />
          </div>
        </div>
      </div>
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