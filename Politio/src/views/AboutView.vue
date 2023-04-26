<template>
  <div class="about">
    <h1>Politio</h1>
    <h4>A place for <strike>arguing</strike> discussion.</h4>
    <!-- 
      A cool animation simulating a chatroom, where two people debate
      about what PolitiFight is.
     -->
  </div>
</template>

<script lang = 'ts'>
import Axios from 'axios'
import type { WeatherData } from '@/types/WeatherData'

Axios.get('https://localhost:7060/WeatherForecast')
  .then((response) => {
    console.log(response.data)
  })
  .catch((err) => {
    console.log(err)
  })
</script>

<style>
.about {
  display: flex;
  flex-direction: column;
}
</style>
