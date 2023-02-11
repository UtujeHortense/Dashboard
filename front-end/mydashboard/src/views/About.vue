<template>
   <section class="container-fluid">
    <div class="justify-content-center">
        <div class="col-lg-9 text">
          <pre>{{users}}</pre>
        </div>
    </div>
   </section>
</template>

<script>
import usersData from '../../../about.json'
export default {
  name: 'About',
  data () {
    return {
      users: usersData
    }
  },
  methods: {
    goHome () {
      this.$router.push({ name: 'Home' })
    },
    handleClick () {
      console.log('Clicked')
    }
  }
}
</script>

<style scoped>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
button {
  background: #e7db28;
  margin-left: 10px;
  margin-right: 10px;
  color: white;
}
button:hover {
  background-color: black;
}
.text {
  text-align: left !important;
  font-size: 15px !important;
}
</style>
