<template>
  <div class="col-12">

    <div class="card bg-light">
      <div class="card-header">
        <ul class="nav nav-pills card-header-pills">
          <li class="nav-item mr-auto">
            <h3>Detalhe <span v-if="detailId">#{{detailId}}</span> do usuário #{{userId}}</h3>
          </li>
          <li class="nav-item">
            <button class="btn nav-link active bg-danger" v-if="detailId" @click="apagar()"><icon icon="trash"></icon> Apagar</button>
          </li>
        </ul>
      </div>
      <div class="card-body">
        <div class="form-group">
          <label for="type-select"></label>
          <select class="form-control" id="type-select" name="type-select" aria-describedby="type-help" v-model="type">
            <option value="1">Telefone</option>
            <option value="2">Email</option>
            <option value="3">Endereço</option>
          </select>
          <small id="type-help" class="form-text text-muted">Tipo do detalhe.</small>
        </div>
        <div class="form-group">
          <label for="value-input">Valor</label>
          <input type="text" class="form-control" name="value-input" id="value-input" aria-describedby="value-help" placeholder="Digite o valor do detalhe" v-model="value">
          <small id="value-help" class="form-text text-muted">O valor do detalhe.</small>
        </div>




      </div>
      <div class="card-footer">
        <button type="button" class="btn btn-lg btn-primary" @click="salvar()"><icon icon="save"></icon> Salvar</button>
      </div>

    </div>

    <hr />
    <detail :userId="userId"></detail>

  </div>
</template>
<script>
  export default {
    props: ['userId'],
    data() {
      return {

        "detailId": 0,
        "type": 0,
        "value": "",
      }

    },
    methods: {
      salvar() {

        let detail = {
          id: this.detailId,
          userId: this.userId,
          type: this.type,
          value: this.value
        }

        if (this.detailId) {
          this.$http.put(`/api/details/${this.detailId}`, detail).then(response => {
            this.$swal('Salvar alterações', 'Alterações salvas com sucesso!', 'success');
          });
        }
        else {
          this.$http.post('/api/details', detail).then(response => {
            this.$swal('Novo detalhe', 'Detalhe cadastrado com sucesso', 'success').then(x => this.$router.push(`/user/${response.data.userId}`));
          });
        }
      }
      , apagar() {
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
          if (result.value) {
            this.$http.delete(`/api/details/${this.detailId}`).then(response => {
              this.$swal('Apagar detalahe', 'Usuário deletado', 'warning').then(x => {
                this.$router.push(`/user/${this.userId}`);
              });
            });
          }
        });
      }
    },
    mounted() {
      if (this.$route.params && this.$route.params.id && this.$route.params.id > 0)
        this.$http.get(`/api/details/${this.$route.params.id}`).then(response => {
          this.type = response.data.type;
          this.value = response.data.value;
          this.userId = response.data.userId;
        }).catch(e => {
         this.$swal('Carregar detalahe', 'Impossível carregar os dados deste detalhe :/' + `\r\n${e.response.data}`, 'warning').then(x => {
                this.$router.push(`/user/${this.userId}`);
              });
        });

    }
  }
</script>
<style>
</style>
