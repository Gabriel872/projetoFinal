<template>
    <div class="view">
        <section class="container" style="height: 60rem; background-color:lightgray; padding: 20px;">
            <svg xmlns="http://www.w3.org/2000/svg" width="20%" height="20%" fill="currentColor"
                class="bi bi-journal" style="position:absolute; left" viewBox="0 0 16 16">
                <path
                    d="M3 0h10a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-1h1v1a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v1H1V2a2 2 0 0 1 2-2z" />
                <path
                    d="M1 5v-.5a.5.5 0 0 1 1 0V5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1zm0 3v-.5a.5.5 0 0 1 1 0V8h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1zm0 3v-.5a.5.5 0 0 1 1 0v.5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1z" />
            </svg>
            <div class="container-fluid flex" style="height: 100%;">
                <div class="container-fluid flex custom-container" style="background-color: blue; height: 55rem;">

                </div>
            </div>
        </section>
    </div>
</template>

<script>

export default {
    data() {
        return {

        }
    }
}

</script>

<style scoped>

@media (min-width: 300px) {
    .bi ,.bi-journal{
        width: 12%;
    }
 }

@media (min-width: 576px) {
    .bi ,.bi-journal{
        width: 12%;
    }
 }

@media (min-width: 768px) {
    .bi ,.bi-journal{
        width: 14%;
    }
 }

@media (min-width: 992px) {
    .bi ,.bi-journal{
        width: 16%;
    }
 }

@media (min-width: 1200px) {
    .bi ,.bi-journal{
        width: 18%;
    }
 }

@media (min-width: 1400px) { 
    .bi ,.bi-journal{
        width: 20%;
    }
}

.custom-container{
    margin-top: auto;
}

</style>