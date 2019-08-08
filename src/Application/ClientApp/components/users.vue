<template>
  <div class="col-12">
    <div class="card bg-light">
      <div class="card-header">
        <ul class="nav nav-pills card-header-pills">
          <li class="nav-item mr-auto">
            <h3>Usuários</h3>
          </li>
          <li class="nav-item">
            <router-link to="/new" class="nav-link active bg-success" href="#"><icon icon="address-book"></icon> Novo</router-link>
          </li>
        </ul>
      </div>
      <table class="table card-body">
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          <tr v-if="loading && !hasError">
            <td colspan="3">
              <icon icon="spinner" spin></icon> Carregando...
            </td>
          </tr>
          <tr v-for="user in users" v-if="hasUsers && !loading">
            <td>
              <router-link :to="{'name':'user', 'params':{id:user.id}}" class="btn btn-link">
                {{user.id}}
              </router-link>
            </td>
            <td>{{user.fullName}}</td>
            <td>{{user.email}}</td>
          </tr>
          <tr v-if="!loading && !hasUsers && !hasError">
            <td colspan="3">
              <icon icon="ban"></icon> Nenhum usuário encontrado.
            </td>
          </tr>
          <tr v-if="hasError">
            <td colspan="3">
              <icon icon="ban"></icon> Ocorreu um erro ao processar sua solicitação!
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
  export default {
    data() {
      return {
        users: [],
        loading: true,
        hasError: false
      }
    },
    computed: {
      hasUsers() { return this.users && this.users.length },

    },
    mounted() {
      this.$http.get(`api/users/`).then(response => {
        this.users = response.data;
        this.loading = false;
      }).catch(e => {
        if (e.response.status !== 404)
          this.hasError = true;
        else {
          this.loading = false;
          this.$swal('Erro ao carregar usuários', `Ocorreu um erro ao carregar os usuários :/\r\n${e.response.data}`, 'warning');
        }
      });
    }
  }</script>
<style>

</style>
