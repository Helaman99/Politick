<template>
    <div class = "signup">

        <img src = "../assets/mainLogo.svg">
        <br><br><br>

        <label for = "email">Email</label>
        <v-text-field type = "email" id = "email" variant = "solo" placeholder = "Email" />
        <label for = "password">Password</label>
        <v-text-field type = "password" id = "password" variant = "solo" placeholder = "Password" />
        <label for = "password2">Repeat Password</label>
        <v-text-field type = "password" id = "password2" variant = "solo" placeholder = "Repeat Password" />
        <v-btn>Sign Up</v-btn>

        <br><br>
        <p>Already have an account?</p>
        <router-link to = "/">Login</router-link>
    </div>
</template>

<style scoped>

img {
  width: 100%;
}

.signup {
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

</style>