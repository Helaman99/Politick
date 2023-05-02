<template>
    <div class = 'avatars'>
        <h2>Avatars</h2>
        <router-link to = '/dashboard/shop/'>Back</router-link>

        <div class = 'avatars'>
            <p v-for = 'name in shopController.avatarsList'>{{ name }}</p>
        </div>
    </div>
</template>

<script setup lang = 'ts'>
import shopController from '@/scripts/shopController'
</script>