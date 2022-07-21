<template>
    <div class="view" style="background-color:lightgray;">
        <section class="container" style="background-color:#212529; color: white;">
            <div class="row">
                <div class="col-10">
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
                                <h1>Titulo{{ obj_course.course_name }}</h1>
                                <h1>Subtitulo{{ obj_course.course_subtitle }}</h1>
                                <div class="rating mb-2 flex">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="gold"
                                        class="bi bi-star-fill" viewBox="0 0 16 16">
                                        <path
                                            d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" />
                                    </svg>
                                    <h3 style="margin-left: .5rem; font-size: 20px;">5</h3>
                                </div>
                                <div class="flex">
                                    <h3 style="font-size: 16px; color: #35d3bc; margin-bottom: 0px;">
                                        Author:<span style="margin-left: 0.2rem; color:white; ">{{ course_author
                                        }}</span>
                                    </h3>
                                    <p style="margin-left: 0.5rem; font-size: 16px; margin-bottom: 0px;">Creation date:
                                        00/00/0000{{ obj_course.course_time }} </p>
                                </div>
                                <div>
                                    <p style="font-size: 16px; margin-bottom: 0px;">Language:
                                        {{ obj_course.course_language }}</p>
                                </div>
                            </div>
                        </div>
                    </section>

                    <div class="container-fluid flex">
                        <div class="container-fluid custom-container">
                            <div class="row">
                                <div class="container mb-4">
                                    <div class="card" style="background-color: #363c42; border: none;">
                                        <div class="card-header" style="border-color: #808080;">
                                            Description
                                        </div>
                                        <div class="card-body">
                                            <p class="card-text">{{ obj_course.course_description }}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="container mb-4">
                                    <div class="card" style="background-color: #363c42; border: none;">
                                        <div class="card-header" style="border-color: #808080;">
                                            Requiriments
                                        </div>
                                        <div class="card-body">
                                            <p class="card-text">{{ obj_course.course_requirements }}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="container mb-4">
                                    <div class="card" style="background-color: #363c42; border: none;">
                                        <div class="card-header" style="border-color: #808080;">
                                            Knowledge level
                                        </div>
                                        <div class="card-body">
                                            <p class="card-text">{{ course_knowledge_level }}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="container mb-4">
                                    <div class="card" style="background-color: #363c42; border: none;">
                                        <div class="card-header" style="border-color: #808080;">
                                            Comments
                                        </div>
                                        <div class="card-body">
                                            <p class="card-text">With supporting text below as a natural lead-in to
                                                additional content.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-2" style="background-color: white;">
                    <div class="container-fluid flex-grid" style="color:  #212529;">
                        <div style="display:flex; justify-content:center;">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-cash img-fluid"
                                viewBox="0 0 16 16">
                                <path d="M8 10a2 2 0 1 0 0-4 2 2 0 0 0 0 4z" />
                                <path
                                    d="M0 4a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H1a1 1 0 0 1-1-1V4zm3 0a2 2 0 0 1-2 2v4a2 2 0 0 1 2 2h10a2 2 0 0 1 2-2V6a2 2 0 0 1-2-2H3z" />
                            </svg>
                        </div>

                        <div class="container-fluid">
                            <h1 style="margin-bottom: 0px;">{{ obj_course.course_name }}</h1>
                            <div class="container-fluid flex">
                                <h2 style="white-space: nowrap;">R$ {{ course_price }}</h2>
                            </div>
                            <div class="row">
                                <button class="btn btn-primary btn-default">Buy</button>
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
            array_prices: [],
            course_price: 0,
            course_knowledge_level: 0,
        }
    },
    beforeMount() {
        this.obj_id = this.$router.params.id_course;
        this.getCourse();
    },
    methods: {
        async getCourse() {
            const object = await fetch("");
            const course_json = await object.json();
            this.obj_course = course_json;
        },
        async getPrice() {
            var id = this.obj_course.id_price_course;

            const prices = await fetch("");
            const prices_json = prices.json();
            this.array_prices = prices_json;

            for(var i = 0; i < this.array_prices.length; i++){
                if(this.obj_id == this.array_prices[i].id){
                    
                }
            }
        }
    }
}

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