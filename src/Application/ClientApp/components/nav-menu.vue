<template>
  <nav class="navbar fixed-top navbar-expand-sm navbar-dark bg-dark">
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#nav-content" aria-controls="nav-content" aria-expanded="false">
      <span class="navbar-toggler-icon"></span>
    </button>

    <!-- Brand -->
    <router-link class="navbar-brand" to="/">
      <icon :icon="['fab', 'microsoft']" /> AHC crud-test
    </router-link>

    <!-- Links -->
    <div class="collapse navbar-collapse" id="nav-content">
      <ul class="navbar-nav mr-auto"></ul>
      <ul class="navbar-nav">
        <li v-for="(route, index) in routes" v-if="!route.hidde" :key="index" :class="{ 'nav-item' : true, active : route.path === $route.path}">
          <router-link :to="route.path" class="nav-link">
            <icon :icon="route.icon" class="mr-2" /><span>{{ route.display }}</span>
          </router-link>
        </li>
      </ul>
    </div>
  </nav>
</template>
<script>
  import { routes } from '../router/routes'

  export default {
    data() {
      return {
        routes
      }
    },
    methods: {

    }
  }
</script>
<style scoped>

  li.nav-item {
    margin: 0 5px;
  }
</style>
