<template>
  <div>
     <form action="" @submit.prevent="loginwithdeezer">
        <div class="form-group d-flex justify-content-center">
              <button class="btn btn-primary w-35">Add Deezer</button>
        </div> <br>
      </form>
  </div>
</template>

<script>
export default {
  name: 'myDeezer',
  data () {
    return {
      appId: '514722',
      myUrl: 'http://localhost:8080/home',
      secret: '6574af285f38e565bf4db89bfd24b001',
      accessToken: ''
    }
  },
  methods: {

    loginwithdeezer () {
      this.authenticateUser(this.appId, this.myUrl)
    },
    authenticateUser (appId, myUrl) {
      console.log(this.appId)
      const authReq = 'https://connect.deezer.com/oauth/auth.php?app_id=' + appId + '&redirect_uri=' + myUrl + '&perms=basic_access,email,offline_access,manage_library,manage_community,delete_library,listening_history'
      window.location.href = authReq
    },
    async getaccesstoken (codeDeezer) {
      this.appId = '514722'
      this.secret = '6574af285f38e565bf4db89bfd24b001'
      const accesReq = 'auth/oauth/access_token.php?app_id=' + this.appId + '&secret=' + this.secret + '&code=' + codeDeezer
      const response = await fetch(accesReq, {
        headers: {
          'Access-Control-Allow-Headers': '*',
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Methods': 'GET,POST,PUT,DELETE'
        }
      }).then(response => response.text())
        .then(data => {
          const words = data.split('=')
          const token = words[1].split('&')[0]
          return token
        })
      console.log(response)
      this.accessToken = response
      return response
    }
  }
}
</script>

<style scoped>
#profilePic {
  width:50px;
  float: left;
  margin-left: 16px;
}
button {
  background: #e7db28;
}
button:hover {
  background-color: black;
}

form {
 padding-top: 10px;
 padding-bottom: 10px;
}
</style>
