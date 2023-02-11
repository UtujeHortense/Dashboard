<template>
   <section class="container-fluid">
    <div class="row justify-content-center">
        <div class="col-lg-4">
          <div class="login-panel bg-white text-left">
              <h1 class="display-3 font-weight-bold">Sign Up</h1>
              <p class="font-weight-bold">Welcome rookie</p><br>
              <form action="" @submit.prevent="handleSubmit">
                <div class="form-group" >
                  <label for="email" class="input-label">Email</label>
                  <input v-model= "email" type="email" class="form-control" placeholder="Email">
                </div>
                <div class="form-group">
                  <label for="password" class="input-label">Password</label>
                  <input v-model= "password" type="password" class="form-control" placeholder="Password">
                </div><br>
                <div class="form-group d-flex justify-content-center">
                  <button id ="btn-login" class="btn btn-primary w-25">Sign up</button>
                </div><br>
              </form>
          </div>
        </div>
    </div>
  </section>
</template>

<script>
import { createUser } from '../service/UserService'
export default {
  name: 'Signup',
  data () {
    return {
      email: '',
      password: ''
    }
  },
  methods: {
    handleSubmit () {
      const payload = {
        myEmail: this.email,
        myPass: this.password
      }
      createUser(payload).then(res => {
        console.log('register', res)
      })
      this.$router.push({ name: 'Login' })
    }
  }
}
</script>

<style lang="scss" scoped>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
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

.login-panel{
  padding: 200px 0;
  position: relative;
}

#btn-login {
  background: #e7db28;
}

#btn-signup {
  background: black;
}
</style>
