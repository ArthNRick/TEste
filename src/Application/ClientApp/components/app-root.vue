<template>
  <div id="app" class="container-fluid">
    <div class="row">
      <nav-menu params="route: route"></nav-menu>
      <router-view style="margin-top:60px;"></router-view>
    </div>
  </div>
</template>
<script>
  import NavMenu from './nav-menu'

  export default {
    components: {
      'nav-menu': NavMenu
    },

    data() {
      return {}
    }
  }
</script>
<style>

</style>
