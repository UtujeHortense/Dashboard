<template>
  <section class="container-fluid">
    <div class="row justify-content-center">
        <div id= "addbuttons" class="col-lg-4">
          <myDeezer/><br>
        </div>
    </div>
    <div id= "otherWidgets" class="card-deck">
      <div class="card text-black bg-white" style="width: 20rem;">
        <img class="card-img-top rounded" src="../assets/img/weather.png" alt="">
        <div class="card-body">
          <h5 class="card-title text-white bg-dark">Weather</h5>
          <label for="password" class="input-label">City</label>
          <input v-model= "weatherData.city">
          <button class="btn btn-primary w-35" @click="getweatherInfo()">Get data</button>
          <h6><b>Location</b> <i v-if="weatherData.query != '' ">{{weatherData.query}}</i></h6>
          <h6><b>Temperature</b> <i v-if="weatherData.temperature != 0 ">{{weatherData.temperature}}℃</i></h6>
          <h6><b>Description</b> <i v-if="weatherData.description != '' ">{{weatherData.description}}</i></h6>
        </div>
      </div>
      <Countdown :userEmail="userData.userEmail"></Countdown>
      <Apod :userEmail="userData.userEmail"></Apod>
    </div>
    <div id="services">
         <div v-if="deezerData.isDeezerConnect == true" id="cardDeezer" class="card text-white bg-dark mb-3" style="width:40rem">
          <img id="profilePic" :src="deezerData.userImage" class="card-img-top" alt="Profile picture">
          <h6>{{deezerData.userName}}</h6>
          <div class="card-body">
            <h5 id = "deezerTitle" class="card-title">Deezer</h5>
            <div id= "widgetsDeezer">
              <div class="card text-black bg-white" style="width: 20rem;">
                <!-- <img class="card-img-top" src="..." alt="Card image cap">-->
                <div class="card-body">
                  <h6 class="card-title text-white bg-dark">Your Artist's Stats</h6>
                   <form action="" @submit.prevent="searchArtist">
                      <select v-model="deezerData.selectedArtist" @click="saveArtistId()">
                          <option v-for="(name, i) in deezerData.allArtists" :key="i" :value="i">{{name.name}}</option>
                      </select>
                      <h6><b>Number of album</b> <i v-if="deezerData.allArtists.length > 0" >{{deezerData.allArtists[deezerData.selectedArtist].nb_album}}</i></h6>
                      <h6><b>Number of fans</b> <i v-if="deezerData.allArtists.length > 0" >{{deezerData.allArtists[deezerData.selectedArtist].nb_fan}}</i></h6>
                   </form>
                </div>
              </div>
            </div>
            <div id = 'btnServiceDeezer'>
              <form action="" @submit.prevent="playAlbum(0)">
              <div class="form-group d-flex justify-content-center">
                      <button class="btn btn-primary w-35">Show Playlist</button>
                </div><br>
              </form>
              <form action="" @submit.prevent="shuffleAlbum">
              <div class="form-group d-flex justify-content-center">
                      <button class="btn btn-primary w-35">Shuffle Album</button>
                </div><br>
              </form>
              <form action="" @submit.prevent="playTrack(0)">
              <div class="form-group d-flex justify-content-center">
                      <button class="btn btn-primary w-35">Recommended Tracks</button>
                </div><br>
              </form>
            </div><br>
            <p><span v-html="deezerData.playlist"></span></p>
            <p><span v-html="deezerData.singletrack"></span><br>
                <button class="btn btn-primary w-20" @click="nextTrack">Next</button>
            </p>
       </div>
     </div>
      <myPinterest/>
      <myTeams/>
    </div>
   </section>
</template>
<script>
import myDeezer from '@/components/DeezerAPI.vue'
import myPinterest from '@/components/PinterestAPI.vue'
import myTeams from '@/components/TeamsAPI.vue'
import Countdown from '@/components/ClockWidget.vue'
import Apod from '@/components/ApodWidget.vue'
import { AddWidgetCity, getWidgetdata, AddWidgetArtist } from '../service/WidgetService'
import { AddDeezerToken } from '../service/DeezerService'
export default {
  data () {
    return {
      userData: {
        userEmail: ''
      },
      deezerData: {
        isDeezerConnect: false,
        deezerToken: '',
        userImage: '',
        userId: '',
        userName: '',
        playlist: '',
        singletrack: '',
        albumIds: [],
        trackIds: [],
        allArtists: [],
        currentAlbumID: 0,
        currentTrackID: 0,
        selectedArtist: 0
      },
      weatherData: {
        accessKey: '00fbfe84d89b24a097b363c3f1909314',
        timeStamp: 0,
        city: 'Rennes',
        query: '',
        temperature: 0,
        description: '',
        timer: 0
      }
    }
  },
  components: {
    myDeezer,
    myPinterest,
    myTeams,
    Countdown,
    Apod
  },
  methods: {
    async userinfo (accessToken) {
      this.deezerData.deezerToken = accessToken
      const myrequest = 'api/user/me?access_token=' + accessToken
      console.log('my request is' + myrequest)
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      console.log(inforRes)
      this.deezerData.userImage = inforRes.picture_small
      this.deezerData.userId = inforRes.id
      this.deezerData.userName = inforRes.name
      console.log(this.deezerData.isDeezerConnect)
      this.persist()
      this.getAlbumId()
      this.getTrackIds()
      this.getAllArtists()
      this.getDataBack(true)
    },
    async playAlbum (albumId) {
      const test = '&url=https://www.deezer.com/album/' + this.deezerData.albumIds[albumId].id + '&maxwidth=500&maxheight=300&tracklist=true&format=json'
      const myrequest = 'api/oembed?access_token=' + this.deezerData.deezerToken + test
      console.log('my request is ' + myrequest)
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      console.log(inforRes)
      this.deezerData.playlist = inforRes.html
    },
    shuffleAlbum () {
      if (Object.keys(this.deezerData.albumIds).length - 1 > this.deezerData.currentAlbumID) {
        this.deezerData.currentAlbumID += 1
      } else {
        this.deezerData.currentAlbumID = 0
      }
      this.playAlbum(this.deezerData.currentAlbumID)
    },
    nextTrack () {
      if (Object.keys(this.deezerData.trackIds).length - 1 > this.deezerData.currentTrackID) {
        this.deezerData.currentTrackID += 1
      } else {
        this.deezerData.currentTrackID = 0
      }
      this.playTrack(this.deezerData.currentTrackID)
    },
    async getAlbumId () {
      console.log('Gteing albummmm')
      const myrequest = 'api/user/' + this.deezerData.userId + '/albums?access_token=' + this.deezerData.deezerToken
      console.log('my request is' + myrequest)
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      console.log(inforRes)
      this.deezerData.albumIds = inforRes.data
    },
    async getTrackIds () {
      const myrequest = 'api/user/' + this.deezerData.userId + '/recommendations/tracks?access_token=' + this.deezerData.deezerToken
      console.log('my request is' + myrequest)
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      console.log(inforRes)
      this.deezerData.trackIds = inforRes.data
    },
    async playTrack (trackID) {
      const test = '&url=https://www.deezer.com/track/' + this.deezerData.trackIds[trackID].id + '&maxwidth=500&maxheight=300&tracklist=true&format=json'
      const myrequest = 'api/oembed?access_token=' + this.deezerData.deezerToken + test
      console.log('my request is ' + myrequest)
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      console.log(inforRes)
      this.deezerData.singletrack = inforRes.html
    },
    async getAllArtists () {
      const myrequest = 'api/user/' + this.deezerData.userId + '/artists?access_token=' + this.deezerData.deezerToken
      console.log('my request is' + myrequest)
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      console.log('all artists', inforRes)
      this.deezerData.allArtists = inforRes.data
    },
    async getweatherInfo () {
      this.saveCity()
      const myrequest = 'weather/current?access_key=' + this.weatherData.accessKey + '&query=' + this.weatherData.city
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      if (!inforRes.success) {
        console.log('Bad request')
      }
      this.weatherData.timeStamp = inforRes.current.observation_time
      this.weatherData.query = inforRes.request.query
      this.weatherData.temperature = inforRes.current.temperature
      this.weatherData.description = inforRes.current.weather_descriptions
    },
    saveCity () {
      const payload = {
        City: this.weatherData.city,
        MyEmail: this.userData.userEmail
      }
      AddWidgetCity(payload)
    },
    saveArtistId () {
      const payload = {
        ArtistId: this.deezerData.selectedArtist,
        MyEmail: this.userData.userEmail
      }
      console.log('save artist', payload)
      AddWidgetArtist(payload)
    },
    saveDeezerToken () {
      const payload = {
        DeezerToken: this.deezerData.deezerToken,
        MyEmail: this.userData.userEmail
      }
      AddDeezerToken(payload)
    },
    checkDeezerToken () {
      const payload = {
        MyEmail: this.userData.userEmail
      }
      getWidgetdata(payload).then(res => {
        for (var i = 0; i < Object.keys(res).length; i++) {
          if (res[i].MyEmail === this.userData.userEmail) {
            if (res[i].DeezerToken) {
              console.log('found token', res[i].DeezerToken)
              this.deezerData.deezerToken = res[i].DeezerToken
              this.deezerData.isDeezerConnect = true
              this.userinfo(res[i].DeezerToken)
            }
            console.log('or not')
          }
        }
      })
    },
    getDataBack (getartist) {
      const payload = {
        MyEmail: this.userData.userEmail
      }
      console.log('Getting al data that is saved')
      getWidgetdata(payload).then(res => {
        for (var i = 0; i < Object.keys(res).length; i++) {
          console.log('compare emails', res[i].MyEmail, this.userData.userEmail)
          if (res[i].MyEmail === this.userData.userEmail) {
            this.weatherData.city = res[i].City
            console.log('city is', res[i].City)
            if (getartist === true) {
              this.deezerData.selectedArtist = res[i].ArtistId
            }
          }
        }
      })
    },
    persist () {
      localStorage.deezerToken = this.deezerData.deezerToken
      localStorage.isDeezerConnect = this.deezerData.isDeezerConnect
      localStorage.userId = this.deezerData.userId
      localStorage.Waccesskey = this.weatherData.accessKey
      localStorage.city = this.weatherData.city
      if (this.$route.params.email !== undefined && this.$route.params.email !== '') {
        localStorage.myemail = this.userData.userEmail
      }
    },
    persistOnmount () {
      if (localStorage.deezerToken) {
        this.deezerData.deezerToken = localStorage.deezerToken
      }
      if (localStorage.isDeezerConnect) {
        this.deezerData.isDeezerConnect = localStorage.isDeezerConnect
      }
      if (localStorage.userId) {
        this.deezerData.userId = localStorage.userId
      }
      if (localStorage.Waccesskey) {
        this.weatherData.accessKey = localStorage.Waccesskey
      }
      if (localStorage.city) {
        this.weatherData.city = localStorage.city
      }
      if (localStorage.myemail) {
        this.userData.userEmail = localStorage.myemail
      }
      if (this.deezerData.isDeezerConnect && this.deezerData.deezerToken !== '') {
        this.userinfo(this.deezerData.deezerToken)
      }
    }
  },
  mounted () {
    if (this.$route.params.email !== undefined && this.$route.params.email !== '') {
      this.userData.userEmail = this.$route.params.email
    }
    var codeDeezer = this.$route.query.code
    this.getDataBack(false)
    this.persist()
    this.persistOnmount()
    this.checkDeezerToken()
    if (codeDeezer != null) {
      this.deezerData.isDeezerConnect = true
      this.$router.push('home')
      this.deezerData.deezerToken = myDeezer.methods.getaccesstoken(codeDeezer)
      this.deezerData.deezerToken.then(result => {
        this.userinfo(result)
        this.saveDeezerToken()
      })
    }
  }
}
</script>

<style lang="scss" scoped>
button {
  background: #e7db28;
  margin-left: 10px;
  margin-right: 10px;
  color: white;
}
button:hover {
  background-color: black;
}

form {
 padding-top: 10px;
 padding-bottom: 10px;
}

#services {
  display: flex;
  justify-content: center;
}

#profilePic {
  width:50px;
  float: left;
  margin-left: 16px;
}

#deezerTitle {
  background: #e7db28;
}
#btnServiceDeezer {
  display: flex;
  justify-content: center;
}

label {
    float: left;
    clear: none;
    display: block;
    padding: 0px 1em 0px 8px;
  }
#otherWidgets {
  .card {
  margin-right: 20px;
  }
}

</style>
