<template>
  <section class="container-fluid">
    <div class="row justify-content-center">
        <div class="col-lg-4">
          <div class="login-panel bg-white text-left">
              <h1 class="display-3 font-weight-bold">Login</h1>
              <p class="font-weight-bold">Welcome back</p><br>
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
                  <button id ="btn-login" class="btn btn-primary w-25">Login</button>
                </div><br>
                <h6><i>{{status}}</i></h6><br>
                 <div class="form-group d-flex justify-content-center">
                  <button id ="btn-signup" class="btn btn-primary w-35" @click="signup">Sign Up</button>
                </div>
              </form>
          </div>
        </div>
    </div>
  </section>
</template>

<script>
import Home from './Home.vue'
import { checkUserExist } from '../service/UserService'
export default {
  name: 'Login',
  data () {
    return {
      email: '',
      password: '',
      status: ''
    }
  },
  component: {
    Home
  },
  props: {
    deezerData: {
      type: Object
    }
  },
  methods: {
    handleSubmit () {
      const payload = {
        myEmail: this.email,
        myPass: this.password
      }
      checkUserExist(payload).then(res => {
        console.log('check user', res)
        for (var i = 0; i < Object.keys(res).length; i++) {
          if (res[i].MyEmail === this.email && res[i].MyPass === this.password) {
            console.log('YESS')
            this.clearForm()
            // this.$router.push({ path: `/home/${res[i].MyEmail}` })
            const email = res[i].MyEmail
            this.$router.replace({ name: 'Home', params: { email } })
          }
        }
        this.status = 'Account does not exist, please click on SignUp to create an account'
      })
    },
    clearForm () {
      this.email = ''
      this.password = ''
    },
    signup () {
      this.$router.push({ name: 'Signup' })
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
