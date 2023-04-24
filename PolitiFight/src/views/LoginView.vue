<template>
    <div class = "login">

      <img src = "../assets/logos/mainLogo.svg">
      <br><br><br>

      <v-text-field type = "email" id = "email" variant = "solo" placeholder = "Email" />
      <v-text-field type = "password" id = "password" variant = "solo" placeholder = "Password" />
      <v-btn>Login</v-btn>

      <br><br>
      <p>Don't have an account?</p>
      <router-link to = "/signup">Sign Up</router-link>

    </div>
</template>

<style scoped>

img {
  width: 100%;
  transform-origin: bottom;
  animation-name: bounce;
  animation-fill-mode: both;
  animation-duration: 1.2s;
}

.login {
    width: 60%;
}

.v-input {
    width: 60%;
}

@media (max-width: 1024px) {

    .login {
        width: 90%;
    }
    .v-input {
        width: 65%;
    }
}

@keyframes bounce {
  0% {
    opacity: 0;
    transform: translateY(-1000px);
  }
  40% {
    opacity: 1;
    transform: translateY(30px);
  }
  80% {
    transform: translateY(-10 px);
  }
  100% {
    transform: translateY(0);
  }
}

</style>