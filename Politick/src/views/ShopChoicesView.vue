<template>
  <div class="choices">
    <div class="shop-choices">
      <v-card elevation="3" class="shop-choice" to="/dashboard/shop/avatars">
        <v-card-title>Avatars</v-card-title>
      </v-card>
      <v-card elevation="3" class="shop-choice" to="/dashboard/shop/titles">
        <v-card-title>Title Packs</v-card-title>
      </v-card>
      <v-card elevation="3" class="shop-choice" to="/dashboard/shop/coins">
        <v-card-title>Coins</v-card-title>
      </v-card>
    </div>
  </div>
</template>

<style scoped>
.shop-choices {
  display: flex;
  justify-content: space-around;
}
.shop-choice {
  width: 30%;
  height: 500px;
}

@media (max-width: 870px) {
  .shop-choices {
    flex-direction: column;
    place-items: center;
  }
  .shop-choice {
    width: 80%;
    height: 7.5rem;
    margin-top: 1rem;
  }
}
</style>
