<template>
  <div class="coins">
    Coins
    <br />
    <p id="thank-you-note">
      Hey! I just want to say thank you for considering purchasing some coins. I really appreciate
      the support!
    </p>
    <br /><br />

    <div id="coin-buttons">
      <v-btn
        class="coin-button"
        v-for="coinPack in coinPacks"
        v-bind:key="coinPack.coinCount"
        @click="buyCoins(coinPack)"
      >
        Buy {{ coinPack.coinCount }} Coins for ${{ coinPack.price }}
      </v-btn>
    </div>

    <!-- <v-text-field v-model="ID"></v-text-field> -->

    <div id="paypal-container">
      <div id="paypal-buttons"></div>
    </div>

    <p style="font-size: medium">
      We use PayPal (cuz security). By paying with your card, you acknowledge that your data will be
      processed by PayPal subject to the PayPal Privacy Statement available at PayPal.com.
    </p>
    <br />
    <router-link to="/dashboard/shop/">Back</router-link>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { coinPacks, verifyPackAsync } from '@/scripts/shopController'
import { addCoins } from '@/scripts/playerController'
import type { CoinPack } from '@/scripts/shopController'
import { loadScript } from '@paypal/paypal-js'

let paypal: any

const ID = ref('ARxpPnUd2JuVWgDpMn9mRj5-OgA_x6ftNn4SDj9_RirVF6MVWsDWGqRYHOJii7fF6rvwc-hv2Z2VNPCy')
const coins = ref(0)
const price = ref(0)

async function buyCoins(coinPack: CoinPack) {
  coins.value = coinPack.coinCount
  price.value = coinPack.price

  // Load PayPal script
  if (await verifyPackAsync(coinPack)) {
    console.log('Verified coin pack.')
    let paypalContainer = document.getElementById('paypal-button-container')
    if (paypalContainer != null) paypalContainer.innerHTML = ''

    try {
      paypal = await loadScript({ clientId: ID.value })

      // Render PayPal button
      if (paypal) {
        paypal
          .Buttons({
            createOrder: function (data: any, actions: any) {
              // Set up the transaction
              return actions.order.create({
                purchase_units: [
                  {
                    amount: {
                      value: price.value
                    }
                  }
                ]
              })
            },
            onApprove: function (data: any, actions: any) {
              // Capture the funds from the transaction
              return actions.order.capture().then(function () {
                alert('Transaction complete! Thank you 💙')
                addCoins(coins.value)
              })
            }
          })
          .render('#paypal-buttons')
      }
    } catch (error) {
      console.error(error)
    }
  }
}
</script>

<style scoped>
.coins {
  text-align: center;
}
#thank-you-note {
  font-size: medium;
}
#thank-you-note::after {
  content: '🥰';
}
#coin-buttons {
  display: flex;
  justify-content: space-around;
}
.coin-button {
  font-size: large;
  background-color: gold;
  color: white;
  width: 30%;
  height: 250px;
}
#paypal-container {
  display: flex;
  justify-content: center;
  margin: 2rem 0;
}
#paypal-buttons {
  width: 60%;
}
</style>
