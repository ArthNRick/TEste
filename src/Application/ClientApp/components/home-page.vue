<template>
  <div class="col-12">
    <div class="row">
      <div class="container-fluid">
        <div class="jumbotron">
          <h1 class="display-4">Olá, mundo!</h1>
          <p class="lead">Este é uma aplicação com um simples teste de CRUD, desenvolvida em <a href="https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.2" target="_blank">ASP.NET Core</a> <a href="https://dotnet.microsoft.com/download/dotnet-core/2.1" target="_blank">2.1</a> e <a href="https://vuejs.org/" target="_blank">VueJS</a><p>
            <hr class="my-4">
          <p>
            Ela usa <a href="https://bootstrap-vue.js.org/" target="_blank">bootstrap4</a> para os estilos, <a href="https://sweetalert2.github.io/" target="_blank">sweetalert2</a> para envios de alertas no client, <a href="https://github.com/axios/axios" target="_blank">axios</a> para requisições HTTP e <a href="https://docs.microsoft.com/pt-br/ef/core/" target="_blank">Entity Framework Core</a> na persistência dos dados
          </p>
          <router-link class="btn btn-primary btn-lg" to="/users" role="button">Ver o cadastro de pessoas!</router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
  export default {
    data() {
      return {}
    }
  }
</script>
<style>
</style>
