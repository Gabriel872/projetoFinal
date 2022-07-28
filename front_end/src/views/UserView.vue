<template>
  <div class="view">
    <section class="container"
      style="padding: 30px; background-color: #212529; margin-top: 10rem; margin-bottom: 2rem; height:600px; border-radius: 20px 20px 20px 20px; color: white;">
      <div class="row mb-2 mb-custom">
        <div class="flex flex-header">
          <div class="flex perfil">
            <svg xmlns="http://www.w3.org/2000/svg" size="48" width="48" height="48" fill="currentColor"
              class="bi bi-person-fill avatar" viewBox="0 0 16 16">
              <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
            </svg>
            <div class="">
              <h1 style="font-size: 25px; margin-bottom:0px;">{{user_name}}</h1>
              <p style="margin-bottom:0px;">{{user_role}}</p>
            </div>
          </div>
          <router-link class="btn btn-primary btn-style" style="margin-top: 1rem;" to="/">
            Go home page
          </router-link>
        </div>
      </div>
      <div class="row">
        <div class="col-2" style="padding-right:10px;">
          <div>
            <button v-on:click="option = 0" class="btn btn-primary btn-custom"
              style="display:block; width: 100%;">Dados</button>
            <button v-on:click="option = 1" class="btn btn-primary btn-custom"
              style="display:block; width: 100%;">Security</button>
            <hr>
            <button v-on:click="confirmDeleteAccount()" class="btn btn-danger btn-custom"
              style="display:block; width: 100%;">Delete account</button>
          </div>
        </div>
        <div class="col-10">
          <div v-if="option == 0" class="container-fluid" style="">
            <div class="row">
              <h1 class="title" style="font-size: 25px;">Dados</h1>
            </div>
            <hr>
            <div class="row">
              <div class="mb-3">
                <label for="nameFormControlInput1" class="form-label">Name</label>
                <input v-model="obj_user.user_name" type="text" class="form-control" id="nameFormControlInput1"
                  :placeholder="user_name">
              </div>
              <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Description</label>
                <textarea v-model="obj_user.user_description" class="form-control" id="exampleFormControlTextarea1"
                  rows="3" :placeholder="user_description"></textarea>
              </div>
            </div>
          </div>
          <div v-if="option == 1" class="container-fluid" style="">
            <div class="row">
              <h1 class="title" style="font-size: 25px;">Security</h1>
            </div>
            <hr>
            <div class="row">
              <div class="mb-3">
                <label for="passwordFormControlInput1" class="form-label">Password</label>
                <input v-model="obj_user.user_password" type="text" class="form-control"
                  id="passwordFormControlInput1" :placeholder="user_password">
              </div>
              <div class="mb-3">
                <label for="emailFormControlnput1" class="form-label">Email</label>
                <input v-model="obj_user.user_email" type="email" class="form-control" id="emailFormControlnput1"
                  :placeholder="user_email">
              </div>
            </div>
          </div>
          <div class="container-fluid">
            <div class="row">
              <div class="container-fluid flex" style="justify-content: center;">
                <button v-on:click="updateUser()" class="btn btn-primary" style="padding: 10px>">Save</button>
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
      option: 0,
      obj_user: {},
      id_user: localStorage.getItem("userId"),
      user_name: localStorage.getItem("userName"),
      user_email: localStorage.getItem("userEmail"),
      user_role: localStorage.getItem("userRole"),
      user_description: localStorage.getItem("userDescription"),
      user_password: localStorage.getItem("userPassword")
    }
  },
  methods: {
    confirmDeleteAccount() {
      var a = confirm("Deseja deletar a conta?");

      if (a) {
        this.deleteAccount();
      }

    },
    async deleteAccount() {
      await fetch(`https://localhost:7114/api/Users/${this.id_user}`, {
        method: "DELETE",
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        }
      });
    },
    async updateUser() {
      
      if(this.obj_user.user_password == undefined && this.obj_user.user_email == undefined){
        this.obj_user.user_password = this.user_password;
        this.obj_user.user_email = this.user_email;
      } 

      this.obj_user.id_user = this.id_user;
      
      await fetch("https://localhost:7114/api/UpdateUser", {
        method: "PUT",
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.obj_user)
      });
    }
  }
}
</script>

<style scouped>
.flex-header {
  justify-content: space-between;
}

.flex {
  display: flex;
}

.perfil {
  align-items: center;
}

.avatar {
  margin-right: 10px;
  display: inline-block;
  overflow: hidden;
  line-height: 1;
  vertical-align: middle;
  border-radius: 50%;
}

.btn-style{
  background-color: #35d3bc;
  border: none;
  padding-top: 8px;
  padding-bottom: 8px;
}

.btn-style:hover {
  background-color: #008a75;
}

.btn-style:focus{
  outline: none;
  box-shadow: none;
  border: none;
  background-color: #35d3bc;
}

.btn-style:active{
  outline: none;
  box-shadow: none;
  border: none;
  background-color: #35d3bc;
}

.btn-custom {
  display: block;
  width: 100%;
  background-color: transparent;
  border: none;
}

.btn-custom:hover {
  background-color: #008a75;
}

.btn-custom:focus {
  outline: none;
  box-shadow: none;
  border: none;
  background-color: #35d3bc;
}

.mb-custom {
  margin-bottom: 1.5rem !important;
}

.btn-danger {
  color: #dc3545;
}

.btn-danger:hover {
  color: white;
  background-color: #dc3545;
}

.btn-danger:focus {
  background-color: #dc3545;
}

.title {
  margin-bottom: 0px;
}

hr {
  margin: .5rem 0;
}
</style>