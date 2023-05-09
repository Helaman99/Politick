# Backlog

* Ask professors for Player data solution... if we should request a person's data constantly or not

* Better sign-up experience, where you are presented with
  
  * a page to choose your avatar
  
  * a page to choose your title
  
  with explanations for each before you're sent to the dashboard.

* An about page

* a dark theme

* Card backgrounds (could just be colors for now)

* An item store

* The chatting engine/functionality

* Database for players' accounts

* set the theme of the app to the player's preference when they login

* Queue logic for teams and chat
  
  * In the backend there can be a `Topic` object for each topic. Each topic will also have multiple `Side` properties. Each `Side` will have it's own queue, as well as a pointer to it's parent `Topic`.
  
  * When a player chooses a topic and a side, that data is sent to the backend. The player's `Id` will be entered into the queue for the selected `Side`.
  
  * The `Topic` object will contsantly grab the next person out of two random `Side`'s queues and then send a call to someplace with those player `Id`s to put them into a chatroom together.
