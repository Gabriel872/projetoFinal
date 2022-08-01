<template>
  <router-link
    style="text-decoration: none; color: white"
    :to="{ name: 'CoursePage', params: { id: card.ID_COURSE } }"
  >
    <div
      class="card ml_mr carousel__item bg-dark text-bg-dark"
      style="width: 240px; border: none; border-radius: 10px"
    >
      <div
        class="flex"
        style="
          width: fit-content;
          overflow: hidden;
          border-radius: 10px 10px 0px 0px;
        "
      >
        <div
          style="
            display: flex;
            align-items: center;
            justify-content: center;
            width: 240px;
            height: 130px;
            background-color: rgb(54, 60, 66);
          "
        >
          <h1>"<b>Olá</b>"</h1>
        </div>
      </div>
      <div
        class="card-body pt-2 pb-2"
        style="text-align: initial; height: 126px"
      >
        <h1 class="card-title mb-2" style="font-size: 20px">
          <b>{{ card.COURSE_NAME }}</b>
        </h1>
        <h2 class="card-text mb-2" style="font-size: 14px">
          author {{ card.USER_NAME }}
        </h2>
        <div class="flex" style="justify-content: space-between">
          <div class="flex" style="color: #ffbc00">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="16"
              height="16"
              fill="currentColor"
              class="bi bi-star-fill"
              viewBox="0 0 16 16"
            >
              <path
                d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"
              />
            </svg>
            <h2
              class="card-text mb-2 ms-1"
              style="font-size: 16px; color: #ff8d00"
            >
              <b>5</b>
            </h2>
          </div>
          <h2 class="card-text mb-0" style="font-size: 16px">
            <b>R$ {{ card.PRICE_COURSE_VALUE }}</b>
          </h2>
        </div>
      </div>
    </div>
  </router-link>
</template>

<script>

export default {
    name: 'CardCarousel',
    props: {
        card: Object,
    },
};
</script>



<style scoped>

.card{
    margin: 6px 6px;
}

</style>