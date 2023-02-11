<template>
    <div class="card text-black bg-white" style="width: 20rem;">
        <img class="card-img-top rounded" src="../assets/img/timer.jpg" alt="" style="height: 250px;">
        <div class="card-body">
          <h5 class="card-title text-white bg-dark">Countdown</h5>
          <h6>Set your timer</h6>
          <form class="">
           <label for="" class="input-label">Year</label>
          <input type= "number" v-model= "input_year">
           <label for="" class="input-label">Month</label>
          <input type= "number" v-model= "input_month">
           <label for="" class="input-label">Day</label>
          <input type= "number" v-model= "input_day"><br><br>
          </form>
          <button id= "setTimer" class="btn btn-primary w-35" @click="showRemaining(true)">Set timer</button>
          <p>{{display_days}}d
          {{display_hours}}h
          {{display_minutes}}m
          {{display_seconds}}s</p>
          <i>{{status}}</i>
    </div>
    </div>
</template>

<script>
import { AddWidgetTimer, getWidgetdata } from '../service/WidgetService'
export default {
  name: 'Countdown',
  data () {
    return {
      display_days: 0,
      display_hours: 0,
      display_minutes: 0,
      display_seconds: 0,
      input_year: 2021,
      input_month: 12,
      input_day: 5,
      status: 'Alive'
    }
  },
  props: ['userEmail'],
  computed: {
    _seconds: () => 1000,
    _minutes () {
      return this._seconds * 60
    },
    _hours () {
      return this._minutes * 60
    },
    _days () {
      return this._hours * 24
    }
  },
  mounted () {
    const payload = {
      MyEmail: this.$props.userEmail
    }
    getWidgetdata(payload).then(res => {
      for (var i = 0; i < Object.keys(res).length; i++) {
        if (res[i].MyEmail === this.$props.userEmail) {
          const parsed = res[i].Timer.split('-')
          this.input_month = parsed[1]
          this.input_day = parsed[2]
          this.input_year = parsed[0]
          this.showRemaining()
        }
      }
    })
    this.showRemaining(false)
  },
  methods: {
    showRemaining (save) {
      const timer = setInterval(() => {
        const now = new Date()
        const end = new Date(this.input_year, this.input_month - 1, this.input_day, 10, 10, 10, 10)
        const distance = end.getTime() - now.getTime()
        if (distance < 0) {
          clearInterval(timer)
          this.display_minutes = 0
          this.display_seconds = 0
          this.display_hours = 0
          this.display_days = 0
          this.status = 'OVER!!'
          return
        } else {
          if (save === true) {
            this.savedate()
            save = false
          }
          this.status = 'Alive..You still have some time'
        }
        const days = Math.floor((distance / this._days))
        const hours = Math.floor((distance % this._days) / this._hours)
        const minutes = Math.floor((distance % this._hours) / this._minutes)
        const seconds = Math.floor((distance % this._minutes) / this._seconds)
        this.display_minutes = minutes < 10 ? '0' + minutes : minutes
        this.display_seconds = seconds < 10 ? '0' + seconds : seconds
        this.display_hours = hours < 10 ? '0' + hours : hours
        this.display_days = days < 10 ? '0' + days : days
      }, 1000)
    },
    savedate () {
      const payload = {
        Timer: this.input_year + '-' + this.input_month + '-' + this.input_day,
        MyEmail: this.$props.userEmail
      }
      AddWidgetTimer(payload)
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
