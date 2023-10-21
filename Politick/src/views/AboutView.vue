<template>
  <div class="about">
    <router-link to="/" style="place-self: start">Back</router-link>
    <img src="@/assets/logos/politick.svg" />
    <h4>A place for <strike>arguing</strike> discussion.</h4>
    <br />
    <hr />
    <br />
    <div id="messages">
      <v-card
        v-for="message in displayMessages"
        v-bind:key="message.messageClass"
        :class="message.messageClass"
        :text="message.text"
        elevation="0"
      />
    </div>
    <router-link id="playnow" to="/signup">Play Now!</router-link>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'

interface Message {
  messageClass: string
  text: string
}

const messages = ref<string[]>([
  '"Politick" is all about talking to other people about your political standings and opinions. Its a great way to get to know what other people think, and it encourages listening and the free exchange of ideas.',
  "Umm, no. Politick is where I get to tell people why they're wrong. Why do it on social media in the comments section when I can do it in real-time?",
  "There is definitely a lot of debating that will take place, but you need to remember that it isn't necessarily about proving that you're right; it's about discussion. If all you do is try to convince people that they're wrong, then nobody will ever actually listen to you.",
  "But that's what 'politicking' is all about -- arguing your side! People need to know the truth.",
  'Agreed, but the way you present it matters. If you want to be listened to, then you need to listen first.',
  "That's ____.",
  "Hah! You can't use that word XD",
  'Seriously?',
  "Yup. Politick filters every word you send to ensure people are respectful. Use too many bad words, and you'll be kicked out of the chat room and a strike will be added to your account. Get too many strikes however, and...",
  'Oh boy. So I guess I HAVE to be somewhat respectful.',
  "Well, I for one would like that. Wouldn't you?",
  'Sure, but that makes it less fun.',
  "Well... I guess I'll give that one to ya.",
  'So I win!',
  'No! We werent talking about whether or not language can make a chat more exciting (even though it could), this is about the purpose of the game "Politick"',
  'Right, right.',
  'Alright, as I was saying, Politick is all about getting people who disagree to actually talk to eachother and maybe even get to know eachother a bit better.',
  'Yeah, you choose a political topic that you want to discuss (like abortion, gun rights, climate change, etc.), choose what side you are the closest to, and then you are matched up with one other person that chose the same topic but a different side.',
  "Thats right! No matter what topic you choose, you'll always get to talk to someone that DOES NOT agree with you. You are also given a time limit as well (which can be extended).",
  "Not only that, but you wont know what side they're on!",
  "Yup! Each topic is very different from the others, with it's own unique sides and opinions. And no, it's not as simple as 'left' or 'right', or 'republican' or 'democrat'.",
  "And if you don't quite fit one of listed sides, then you can always choose 'other' :)",
  'Uh huh! So what are you waiting for? Go ahead and give it a shot!',
  'Wait, who are you talking to? I am playing the game with you right now.',
  'Sorry, I was talking to the person reading this chat.',
  'Wait, you can spectate chats??',
  "Not yet, but that's coming soon ;)",
  "Ooh, that'll be good!"
])
const displayMessages = ref<Message[]>([])
let left = true

onMounted(() => {
  const messageDisplay = document.getElementById('messages')
  if (messageDisplay !== null) {
    let i = 0
    function displayNextMessage() {
      if (i < messages.value.length) {
        let message = messages.value[i]
        if (left) {
          displayMessages.value.push({ messageClass: 'message-left', text: message })
        } else {
          displayMessages.value.push({ messageClass: 'message-right', text: message })
        }
        left = !left
        i++
        setTimeout(displayNextMessage, 5000)
      } else {
        let playNowButton = document.getElementById('playnow')
        if (playNowButton !== null) playNowButton.style.opacity = '1'
      }
    }
    displayNextMessage()
  } else console.log('it was nulll')
})
</script>

<style scoped>
.about {
  display: flex;
  flex-direction: column;
}

img {
  width: 30%;
  place-self: center;
}

#messages {
  display: flex;
  flex-direction: column;
}

:deep(.v-card) {
  width: fit-content;
  max-width: 35%;
  margin: 0.5rem;
  background-color: gainsboro;
  color: black;
}
:deep(.v-card-text) {
  font-size: large;
  white-space: pre-wrap;
}
.message-left {
  align-self: flex-start;
  text-align: start;
}
.message-right {
  align-self: flex-end;
  text-align: end;
}

#playnow {
  opacity: 0;
}

@media (max-width: 870px) {
  img {
    width: 50%;
  }
  :deep(.v-card) {
    max-width: 60%;
  }
}

@media (max-width: 620px) {
  img {
    width: 80%;
  }
  :deep(.v-card) {
    max-width: 80%;
  }
}
</style>
