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
                                <h1>{{ test.name }}</h1>
                                <h1>{{ test.second }}</h1>
                            </div>
                        </div>
                    </section>

                    <div class="container-fluid flex">
                        <div class="container-fluid custom-container" style="background-color: blue;">
                            <div class="row">
                                <div class="container-fluid flex">
                                    <h1>Descriçao</h1>
                                </div>
                            </div>
                            <div class="row">
                                <div class="container-fluid flex">
                                    <h1>Requisitos</h1>
                                </div>
                            </div>
                            <div class="row">
                                <div class="container-fluid flex">
                                    <h1>Comentarios</h1>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-2" style="background-color: white;">
                    <div class="container-fluid" style="color:  #212529;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="1rem" height="1rem" fill="currentColor"
                            class="bi bi-cash img-fluid" viewBox="0 0 16 16">
                            <path d="M8 10a2 2 0 1 0 0-4 2 2 0 0 0 0 4z" />
                            <path
                                d="M0 4a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H1a1 1 0 0 1-1-1V4zm3 0a2 2 0 0 1-2 2v4a2 2 0 0 1 2 2h10a2 2 0 0 1 2-2V6a2 2 0 0 1-2-2H3z" />
                        </svg>
                        <div class="container-fluid">
                            <h1 style="margin-bottom: 0px;">{{ test.name }}</h1>
                            <div class="container-fluid flex">
                                <h2 style="white-space: nowrap;">R$ {{test.price}}</h2>
                            </div>
                            <button class="btn btn-primary">Comprar</button>
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
            obj_id: 1,
            test: { id: '1', name: 'Ola', second: 'hello' , price: '29,99'}
        }
    }
}

</script>

<style scoped>
@media (min-width: 300px) {

    .bi
    .bi-journal , .bi-cash{
        width: 3rem;
    }
}

@media (min-width: 576px) {

    .bi
    .bi-journal,  .bi-cash{
        width: 4rem;
    }
}

@media (min-width: 768px) {

    .bi
    .bi-journal, .bi-cash {
        width: 5rem;
    }
}

@media (min-width: 992px) {

    .bi
    .bi-journal, .bi-cash {
        width: 8rem;
    }
}

@media (min-width: 1200px) {

    .bi
    .bi-journal, .bi-cash {
        width: 9rem;
    }
}

@media (min-width: 1400px) {

    .bi
    .bi-journal, .bi-cash {
        width: 10rem;
    }
}

.custom-container {
    margin-top: auto;
}
</style>