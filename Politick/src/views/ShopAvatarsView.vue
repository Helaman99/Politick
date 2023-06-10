<template>
  <div class="avatars">
    <h2>Avatars</h2>

    <h4>Basic Avatars</h4>
    <v-divider />
    <div class="Options">
      <v-btn
        class="Option"
        v-for="avatar in basicAvatarFileNames"
        v-bind:key="avatar"
        @click="selectBasicAvatar(avatar)"
        :disabled="player?.unlockedAvatars.includes(avatar)"
      >
        <img
          :src="'https://localhost:7060/Shop/Avatar' + avatar"
          :style="{ opacity: player?.unlockedAvatars.includes(avatar) ? 0.35 : 1 }"
        />
      </v-btn>
    </div>
    <br /><br />
    <h4>Premium Avatars</h4>
    <v-divider />
    <div class="Options">
      <v-btn
        class="Option"
        v-for="avatar in premiumAvatarFileNames"
        v-bind:key="avatar"
        @click="selectPremiumAvatar(avatar)"
        :disabled="player?.unlockedAvatars.includes(avatar)"
        :style="{ 'background-color': avatar === 'certainValue' ? 'green' : '' }"
      >
        <img
          :src="'https://localhost:7060/Shop/Avatar' + avatar"
          :style="{ opacity: player?.unlockedAvatars.includes(avatar) ? 0.35 : 1 }"
        />
      </v-btn>
    </div>

    <v-dialog v-model="basicPrompt" class="prompt">
      <v-card class="prompt-card">
        <div class="prompt-left">
          <img :src="'https://localhost:7060/Shop/Avatar' + selectedAvatar" />
        </div>
        <div class="prompt-right">
          <p>Are you sure you wish to buy this avatar for 10 coins?</p>
          <v-card-actions>
            <v-btn @click="attemptPurchase(10)">Yes</v-btn>
            <v-btn @click="basicPrompt = !basicPrompt">No</v-btn>
          </v-card-actions>
        </div>
      </v-card>
    </v-dialog>
    <v-dialog v-model="premiumPrompt" class="prompt">
      <v-card class="prompt-card">
        <div class="prompt-left">
          <img :src="'https://localhost:7060/Shop/Avatar' + selectedAvatar" />
        </div>
        <div class="prompt-right">
          <p>Are you sure you wish to buy this premium avatar for 20 coins?</p>
          <v-card-actions>
            <v-btn @click="attemptPurchase(20)">Yes</v-btn>
            <v-btn @click="premiumPrompt = !premiumPrompt">No</v-btn>
          </v-card-actions>
        </div>
      </v-card>
    </v-dialog>

    <v-dialog class="confirmation" v-model="success" width="fit-content">
      <v-card>
        <v-card-title>Item purchased successfully!</v-card-title>
        <v-card-text
          >You can go to your Customization page and put it on your Player Card!</v-card-text
        >
      </v-card>
    </v-dialog>
    <v-dialog class="confirmation" v-model="failed" width="fit-content">
      <v-card>
        <v-card-title>Huh, something went wrong...</v-card-title>
        <v-card-text>If this issue persists, please contact support.</v-card-text>
      </v-card>
    </v-dialog>

    <br />
    <router-link to="/dashboard/shop/">Back</router-link>
  </div>
</template>

<script setup lang="ts">
import { player } from '@/scripts/playerController'
import { ref } from 'vue'
import {
  basicAvatarFileNames,
  premiumAvatarFileNames,
  purchaseAvatar
} from '@/scripts/shopController'

const basicPrompt = ref(false)
const premiumPrompt = ref(false)
const success = ref(false)
const failed = ref(false)
const selectedAvatar = ref('')

function selectBasicAvatar(avatar: string) {
  selectedAvatar.value = avatar
  basicPrompt.value = true
}
function selectPremiumAvatar(avatar: string) {
  selectedAvatar.value = avatar
  premiumPrompt.value = true
}
function attemptPurchase(amount: number) {
  if (purchaseAvatar(selectedAvatar.value, amount)) {
    success.value = true
    basicPrompt.value = false
    premiumPrompt.value = false
    setTimeout(() => {
      success.value = false
    }, 3000)
  } else failed.value = true
}
</script>

<style scoped>
.Options {
  width: 75%;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  place-items: center;
  gap: 1rem;
}
.Options .Option {
  width: 80%;
  height: fit-content;
  padding: 0;
  border-radius: 5%;
}
.Options .Option img {
  width: 100%;
  border-radius: 5%;
}

.v-divider {
  margin-bottom: 0.5rem;
}

.prompt {
  width: 50%;
}
.prompt .prompt-card {
  display: flex;
  flex-direction: row;
  place-items: center;
  padding: 2rem;
}
.prompt-card .prompt-left {
  width: 50%;
  margin-right: 1rem;
}
.prompt-card .prompt-left img {
  width: 100%;
  border-radius: 5%;
}
.prompt-card .prompt-right {
  display: flex;
  flex-direction: column;
  text-align: center;
  place-items: center;
}

.confirmation {
  text-align: center;
}

@media (max-width: 940px) {
  .Options {
    width: 90%;
    grid-template-columns: 1fr 1fr 1fr;
  }
  .prompt {
    width: 75%;
  }
}
@media (max-width: 500px) {
  .Options {
    width: 100%;
    grid-template-columns: 1fr 1fr;
  }
  .prompt .prompt-card {
    flex-direction: column;
  }
  .prompt .prompt-card .prompt-left {
    margin: 0;
    width: 90%;
  }
}
</style>
