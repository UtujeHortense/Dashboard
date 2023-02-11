<template>
   <header class="top-bar spread">
    <nav class="top-bar-nav">
      <router-link to="/" class="top-bar-link">
        <i class="icofont"></i>
        <span>Login </span>
      </router-link>
      <router-link to="/about.json" class="top-bar-link">
        <span>About </span>
      </router-link>
      <router-link to="/" class="top-bar-link">
        <span>Logout </span>
      </router-link>
    </nav>
  </header>
  <div>
    <h1 class="display-3 font-weight-bold">DASHBOARD</h1>
  </div>
  <router-view/>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #000000;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
