<template>
    <div class="forgot-password">
        <img src="@/assets/logos/politick.svg" />
        <br /><br /><br />
        
        <p>Forgot Password</p>
        <RouterView />

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
  .signup {
    width: 100%;
  }
  .v-input {
    width: 75%;
  }
}
</style>