<template>
<div class="card text-black bg-white" style="width: 20rem;">
    <img class="card-img-top rounded" :src="display_image" alt="">
    <h6>{{title}}</h6>
        <div class="card-body">
          <h5 class="card-title text-white bg-dark">APOD- NASA</h5>
          <h6>Set your date</h6>
          <Datepicker v-model="mydate" :minDate="new Date(1995,5,19)" :maxDate="new Date()" dark ></Datepicker><br>
          <button id= "setTimer" class="btn btn-primary w-35" @click="showImage()">Set date</button>
          <button id= "setTimer" class="btn btn-primary w-35" @click="showExplanation()">See Explanation</button>
          <i v-if="showEx == true">{{explanation}}</i>
        </div>
      </div>
</template>

<script>
import Datepicker from 'vue3-date-time-picker'
import 'vue3-date-time-picker/dist/main.css'
import { AddWidgetApod, getWidgetdata } from '../service/WidgetService'

export default {
  name: 'Apod',
  data () {
    return {
      display_image: '',
      title: '',
      explanation: '',
      access_key: 'kQq6z4kGT17hHX3HwxEawWbetbUgw2aI2uJ5pyBh',
      mydate: new Date(),
      showEx: false
    }
  },
  props: ['userEmail'],
  components: {
    Datepicker
  },
  mounted () {
    const payload = {
      MyEmail: this.$props.userEmail
    }
    getWidgetdata(payload).then(res => {
      console.log('check user date', res)
      for (var i = 0; i < Object.keys(res).length; i++) {
        if (res[i].MyEmail === this.$props.userEmail) {
          console.log('date apod', res[i].Apod)
          const parsed = res[i].Apod.split('-')
          const mymonth = parsed[1] - 1
          const myday = parsed[2].split('T')
          this.mydate = new Date(parsed[0], mymonth, myday[0])
          this.showImage()
        }
      }
    })
    this.showImage()
  },
  methods: {
    async showImage () {
      this.savedate()
      const adate = this.mydate
      const month = adate.getMonth() + 1
      const myrequest = 'https://api.nasa.gov/planetary/apod?api_key=kQq6z4kGT17hHX3HwxEawWbetbUgw2aI2uJ5pyBh&date=' + adate.getFullYear() + '-' + month + '-' + adate.getDate()
      const inforRes = await fetch(myrequest, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
      }).then(response => response.json())
        .then(data => {
          return data
        })
      console.log(inforRes)
      this.display_image = inforRes.url
      this.title = inforRes.title
      this.explanation = inforRes.explanation
    },
    showExplanation () {
      this.showEx = !this.showEx
    },
    savedate () {
      const adate = this.mydate
      const month = adate.getMonth() + 1
      const payload = {
        Apod: adate.getFullYear() + '-' + month + '-' + adate.getDate(),
        MyEmail: this.$props.userEmail
      }
      AddWidgetApod(payload)
    }
  }
}
</script>

<style scoped>
p {
  text-align: center;
  font-size: 25px;
  margin-top: 0px;
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

</style>
