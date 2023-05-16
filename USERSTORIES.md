# Politick User Stories

1. A new player wants to create an account.
   * They navigate to the website, click "Sign Up", and create an account by entering a username, email, and password. A verification email is sent to them with a code that is required to gain access to the application. After entering this code into the verification page, the user is successfully verified and is given access to the application.
2. A player wants to play a game of 1v1 'Debate'.
   * The user naviagtes to a page that displays the current topics that can be debated. The user selects a topic, and is then presented with a number of game modes. The user selects the 'Debate' game mode, and is then presented with the sides that are available for this topic. After selecting their side, the user is presented with a choice of either a '1v1' match or a '2v2' match. The user selects '1v1', and is then put into a chatroom with another player that is on the opposite side.
3. A player wants to purchase an avatar.
   * The player goes to the shop view and selects "Avatars". They are presented with all of the available avatars. (Avatars that are already owned by the player are marked acordingly.) The player selects the avatar that they would like to purchase, which will open a dialog that presents a larger view of the avatar, with a prompt to either purchase the avatar or cancel. After selecting "Buy", they will recieve a confirmation message (probably a dialog), and the dialog will close and they will see the avatars page again.

### Error/Security Threat Cases:

1. A player selects their topic and side and enters the queue to join a game. While searching for another player, the person exits the page.

2. A player is in a chatroom, and then exits the page.

3. A player sends a request to the ChatHub to join a specified room that they are not supposed to join.

4. A player gets a hold of an existing room number and sends a message to the ChatHub with the specified room number.
