# AllHailTheProject
This repo is for everyone collaborating on the game "All Hail the Button" made during Global Game Jam 2016 @ AIE Seattle campus.

Giving Credit where Credit is Due:
	- Art Stuff
		= Kenny for his Asset packs
			-> http://kenney.nl/assets?q=2d
		= Johnthan for the Cellphone base
			-> https://pixabay.com/en/cell-phone-mobile-phone-android-718902/
			
##Note About Game:  
We were not able to successfully get the game running as we wanted to but we were able to make a demo of how we wanted it to look/ behave.  

##Overview:  
Out team took the theme of "Ritual" and thought of the adjective definition of ritual as in "(of an action) arising from convention or habit".
 with that definition in mind, we created a game that would make the player fall into a daily 'Ritualistic' habit. Which would be opening up
 the app on their phone to access the game and pressing a button. In addition to this, in order to spread this habit to as many users as we could,
 we added a social interaction aspect to the game. Which would cause not only the game to spread, but also a motivation to the user to see their 
 teams name being broadcast across Twitter.  


##The Goal of the Game:  
There are two teams, Red and Blue. Each side has a goal of how many users have to press the button in a cycle and each player can press the button
 only once during that cycle. Every button press (from either side) adds points towards a "jackpot" that the winning side will get.A winning team 
 is decided after one side is not able to get enough users to press the button. What keeps players coming back is the fact that the amount of button 
 presses required will scale after each cycle but the user won't be able to tell how many that is. They will get an alert at the end of each cycle 
 informing them if their team got enough button presses and if not how much (in percentage) their team was off by. After a winner is decided, the 
 jackpot is awarded to the winning teams score, an announcement is made from the official twitter account (@HailButton) of who won the cycle and 
 how many points each side has, and the cycle resets.  


##How the Game Works:  
When a player launches the game for the first time, they will be prompted to sign in to their Twitter account. Once they have, the game will pull
the users twitter handle (ie @exampleUser) and use that as their Login. Then they are assigned to either the Red or Blue team (based on which side
has less players). After all that, the app informs a server of the new user so the server can add them to the list of players and run it's calculations
properly. The player will then get alerts every cycle informing them that it's time to press (or what we call it "Hailing/ praising") the button and 
whether or not their team is still in the running/ if their team has won.  


##More About the Game:  
Going more in depth into 'All Hail the Button', while the game is not a very visually driven game, the social aspect of it on Twitter will drive the
user to want to keep repeating the task of pressing the button everyday causing them to fall into the "ritualistic" daily habit that we are trying to
form in them. The official Twitter page will have a bot that announces which team has won and point scores. Players will also be able to associate 
themselves to those scores/ teams by making tweets with the hashtag 'HailRed' or 'HailBlue' respectively.  