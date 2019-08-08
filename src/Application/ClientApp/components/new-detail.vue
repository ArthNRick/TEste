<template>
  <newdetail :userId="userId"></newdetail>
</template>
<script>
  import Detail from './detail'
  export default {
    components: {
      'newdetail': Detail
    },
    data() {
      return {
        userId: 0
      }
    },
    mounted() {
      if (this.$route.params && this.$route.params.userId && this.$route.params.userId > 0)
        this.userId = this.$route.params.userId;
    }
  }</script>
<style>
</style>
