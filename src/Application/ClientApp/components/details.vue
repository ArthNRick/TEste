<template>

  <div class="card">
    <div class="card-header">
      <ul class="nav nav-pills card-header-pills">
        <li class="nav-item mr-auto">
          <h3>Detalhes do usuário #{{userId}}</h3>
        </li>
        <li class="nav-item" style="padding:5px;">
          <router-link :to="{name: 'new-detail', params: { userId } } " class="nav-link active bg-success" href="#"><icon icon="address-card"></icon> Novo</router-link>
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
        <tr v-for="detail in details" v-if="hasDetails">

          <td>{{detail.typeText}}</td>
          <td>{{detail.value}}</td>
          <td>
            <btn class="btn btn-danger" @click="apagar(detail.id)">
              <icon icon="trash"></icon> Apagar
            </btn>
          </td>
        </tr>
        <tr v-if="!hasDetails && loaded">
          <td colspan="3">
            <icon icon="ban"></icon> Nenhum detalhe do usuário encontrado.
          </td>
        </tr>
        <tr v-if="!loaded">
          <td colspan="3">
            <icon icon="spinner" spin></icon> Aguarde...
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
        details: [],
        loaded: false
      }
    },
    computed: {
      hasDetails() { return this.details && this.details.length },

    },
    methods: {
      apagar(detailId) {
        this.$swal({
          title: 'Tem certeza?',
          text: "Tem certeza que deseja deletar esse detalhe?!",
          type: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Sim, apague isso!',
          cancelButtonText: 'Não, cancelar!'
        }).then(result => {
          if (result.value)
            this.$http.delete(`/api/details/${detailId}`).then(response => {
              this.$swal('Apagar detalahe', 'Usuário deletado', 'warning').then(x => {
                this.details = this.details.filter(detail => detail.id != detailId);
              })
            });
        });
      }
    },
    mounted() {
      this.$http.get(`/api/details/${this.userId}`).then(response => {
        this.details = response.data;
        this.loaded = true;
      }).catch(e => {
        this.loaded = true;
        if (e.response.status !== 404)
          this.$swal('Carregar detalhes', 'Ocorreu um erro ao carregar os detalhes do usuário :/' + `\r\n${e.response.data}`, 'warning');
      });
    },
    watch: {

    }
  }</script>
<style>
</style>
