<template>
  <div class="col-12">

    <div class="card bg-light">
      <div class="card-header">
        <ul class="nav nav-pills card-header-pills">
          <li class="nav-item mr-auto">
            <h3>Dados do usuário #{{userId}}</h3>
          </li>
          <li class="nav-item">
            <btn class="btn nav-link active bg-danger" @click="apagar()"><icon icon="trash"></icon> Apagar</btn>
          </li>
        </ul>
      </div>
      <div class="card-body">
        <div class="form-group">
          <label for="name-input">Nome</label>
          <input type="text" class="form-control" id="name-input" aria-describedby="name-help" placeholder="Digite o nome" v-model="name">
          <small id="name-help" class="form-text text-muted">O primeiro nome do usuário.</small>
        </div>
        <div class="form-group">
          <label for="lastName-input">Sobrenome</label>
          <input type="text" class="form-control" id="lastName-input" aria-describedby="lastName-help" placeholder="Digite o sobrenome" v-model="lastName">
          <small id="lastName-help" class="form-text text-muted">O sobrenome do usuário.</small>
        </div>
        <div class="form-group">
          <label for="email-input">Email</label>
          <input type="email" class="form-control" id="email-input" aria-describedby="email-help" placeholder="Digite o email" v-model="email">
          <small id="email-help" class="form-text text-muted">O e-mail do usuário.</small>
        </div>



      </div>
      <div class="card-footer">
        <button type="button" class="btn btn-lg btn-primary" @click="salvar()"><icon icon="save"></icon> Salvar</button>
      </div>

    </div>

    <hr />
    <user-details v-if="userId" :userId="userId"></user-details>

  </div>
</template>
<script>
  import Details from './details'
  export default {
    components: {
      'user-details': Details
    },
    data() {
      return {

        "userId": 0,
        "name": "",
        "lastName": "",
        "fullName": "",
        "email": ""
      }

    },
    methods: {
      salvar() {

        let user = {
          id: this.userId,
          name: this.name,
          lastName: this.lastName,
          email: this.email
        }

        if (this.userId) {
          this.$http.put(`/api/users/${this.userId}`, user).then(response => {
            this.$swal('Salvar alterações', 'Alterações salvas com sucesso!', 'success');
          });
        }
        else {
          this.$http.post('/api/users', user).then(response => {
            this.$swal('Novo usário', 'Usuário cadastrado com sucesso', 'success').then(x => this.$router.push(`/user/${response.data.id}`));
          });
        }
      }
      , apagar() {
        this.$swal({
          title: 'Tem certeza?',
          text: "Tem certeza que deseja deletar esse usuário?!",
          type: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Sim, apague isso!',
          cancelButtonText: 'Não, cancelar!'
        }).then(result => {
          if (result.value) {
            this.$http.delete(`/api/users/${this.$route.params.id}`).then(response => {
              this.$swal('Apagar usuário', 'Usuário deletado', 'warning').then(x => {
                this.$router.push('/users');
              });
            });
          }
        });
      }
    },
    mounted() {
      if (this.$route.params && this.$route.params.id && this.$route.params.id > 0)
        this.$http.get(`/api/users/${this.$route.params.id}`).then(response => {
          this.name = response.data.name;
          this.lastName = response.data.lastName;
          this.email = response.data.email;
          this.userId = response.data.id;
        }).catch(e => {
          console.log(e.response);
        });

    }
  }</script>
<style>
</style>
