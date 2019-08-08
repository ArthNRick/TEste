<template>

  <div class="card">
    <div class="card-header">
      <ul class="nav nav-pills card-header-pills">
        <li class="nav-item mr-auto">
          <h3>Detalhes do usuário #{{userId}}</h3>
        </li>
        <li class="nav-item" style="padding:5px;">
          <router-link to="/new" class="nav-link active bg-success" href="#"><icon icon="address-card"></icon> Novo</router-link>
        </li>
        <!--<li class="nav-item" style="padding:5px;">
          <router-link to="/new" class="nav-link active bg-danger" href="#"><icon icon="trash-alt"></icon> Apagar tudo</router-link>
        </li>-->
      </ul>
    </div>
    <table class="table card-body">
      <thead>
        <tr>
          <th>Tipo</th>
          <th>Valor</th>
          <th>Apagar</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="detail in user.details" v-if="hasDetails">

          <td>{{detail.typeText}}</td>
          <td>{{detail.value}}</td>
          <td>
            <btn class="btn btn-danger" @click="apagar(detail.id)">
              <icon icon="trash"></icon> Apagar
            </btn>
          </td>
        </tr>
        <tr v-if="!hasDetails">
          <td colspan="3">
            <icon icon="ban"></icon> Nenhum detalhe do usuário encontrado.
          </td>
        </tr>
      </tbody>
    </table>
  </div>

</template>
<script>
  export default {
    props: ['userId'],
    data() {
      return {
        details: []
      }
    },
    computed: {
      hasDetails() { return this.details && this.details.length },

    },
    methods: {
      apagar(detailId) {
        this.$http.delete(`api/details/${detailId}`).then(response => {
          this.details = this.details.filter(detail => detail.id != detailId);
        });
      }
    },
    mounted() {
      this.$http.get(`/api/details/${this.userId}`).then(response => {
        this.details = response.data;
      });
    },
    watch: {
     
    }
  }</script>
<style>
</style>
