<template>
    <div class="forgot-password">
        <img src="@/assets/logos/politick.svg" />
        <br /><br /><br />
        
        <p>Forgot Password</p>
        <RouterView />

        <router-link to="/">Home</router-link>

    </div>
</template>

<style>
#error-message {
  font-size: large;
  color: red;
}
.forgot-password {
  width: 50%;
}
.v-input {
  width: 60%;
}
label {
  font-size: medium;
}

@media (max-width: 1024px) {
  .forgot-password {
    width: 100%;
  }
  .v-input {
    width: 80%;
  }
}
</style>