# "PolitiFight" Project

A place where people from different sides of the isle can come together and debate their sides.

## Requirements

* There will be a way to create an account .

* Accounts will require verification to prevent fake account creation.

* An account is required to play.

* There will be multiple different topics to discuss, each with different sides that can be joined.

* There will be multiple game modes, and every topic will be able to be discussed in these modes.

* Every game mode will be, at its core, a basic chat room between two or more people.

* There will be a currency type.
  
  * The currency will be used to customize a person's profile, send emojis in the chat, extend a matches time limit, amongst other things.
  * The currency can be obtained by playing the game
  * The currency will also be obtainable by spending real money
  * A maximum currency amount will be awarded at the end of every match, but will decrease if insults, language, or other illegal behaviour is detected.

* There will be an automated Referee
  
  * This Referee will scan every message for illegal behaviour such as insults, slander, language, or other indescent behaviour.
  * If an offense is detected, then the person will be penalized by not recieving the max amount of currency at the end of the match.
  * No URLs will be allowed either.
  * Repeated offences can lead to an account being banned. The email associated with the banned acount will be kept in the database to prevent use by future accounts.

* There will be profile statistics that could include
  
  * A person's most played game mode
  
  * A person's typical political standing (left, right, center, etc.)
  
  * A person's total number of wins in the 'Jury' mode
  
  * Total credits earned since account creation

## Game Modes

Most Game Modes will be refereed by the Referee, and each game mode will have a 1v1 and a 2v2 variation. While playing, no person's username will be visible. The only aspects of a person's account that will be visible to other players will be their avatar and background.

**Required Game Modes**:

* 'Battle Royal'
  
  * A basic chatroom with no turns and a timer.

* 'Debate'
  
  * A chatroom where each participant will take turns sending a message to the other. There will be a time limit on how long the person has to create his or her message.
  
  * There will be a timer.

* 'Jury'
  
  * A 'Debate' style chatroom that is spectated by other players, and a winner is selected by those spectators at the end of the match. The winner gains extra currency and the win is recorded in the person's profile statistics.
  
  * The spectaters will be an even mix between those of different sides.

**Potential Game Modes**

* 'Fight Room'
  
  * A chat room where there will be no time limit, no turns, no referee, and no reward at the end.
  
  * Player's will be given a warning/disclaimer before entering this game mode.
  
  * Player's will still select a topic and side before entering this mode. In other words, this isn't just a basic chatroom for people to chill-out in.

## Game Currency

"Coins" will be the currency of the game, and will be able to be obtained via playing the game or by purchasing them with real money.

**Getting Coins**

Players can get coins by

* playing games --> 5 coins per match

* referring other players --> 15 coins per referral

* purchasing with real money --> Coins will only be buyable in certain amounts, but their worth will be 10 cents per coin i.e. \$2 for 20 coins, \$5 for 50 coins, and so on.

**Using Coins**

Players will be able to spend their coins on

* avatars (scaling in price)

* avatar items (like backgrounds, also scale in price)

* mystery boxes for avatars and other items that are not directly purchasable
  
  * There will be a rarity tier system, and the more rare mystery box you choose to open, the more expensive it is but you can get more rare items.

* sending an emoji in the chat --> 1 coin per emoji

* purchasing emoji packs

**Coin Penalties**

Coins will also be one of the ways that players are penalized for bad behavior. Every rule infraction will result in a penalty, with different penalties for different offenses.

* Profanity --> -2 coins

* Other words that are not allowed --> -1 coin

* Sending links --> -1 coin

All offenses will be astericked out in the message, and a message will be sent into the chat notifying the players of which player lost some of their coins.

If a player loses all of their coins, they are kicked out of the chat room and the win is given to the other player. If a player is out kicked of chat rooms 5 times within the last 3 months, then their account will be suspended for a week. After their account is reinstated, a player may play the game as usual, but if they are kicked out of chat rooms 5 times again, then their account will be permanently disabled. The email used to create that account will also be kept in the database to prevent it from being used again.

## Future/Desired Features

- 3v3 variation for game modes

- Seasonal challenges

- "Topic of the Week" that is based on recent events in the news.

- A PolitiFight blog
