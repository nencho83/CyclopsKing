The Cube
====================
### I.Brief description of the game

The game represents labyrinth in 3D. The Player is placed in the middle of the Cube and his task is to find a way out. In the beginning of the game he chooses category of questions:
*	IT quiz
*	Movie quiz
*	Science quiz

Questions in each category are separated in three severities. The Player has 30 seconds to
answer the question. If he answers before the time has elapsed the remaining time is added to the time
of his next question.

Player moves through the playfield and gives a direction by pressing the arrow keys. When he
enters a room he has to answer a question from the chosen category in order to move in the next room.
When he gives wrong answer his credits decreased he stays in the same room and new question is given.
If the Player runs out of credits the game is over his score is recorded if it is among the Top 10 scores.

If the Player gives the correct answer he chooses his next direction. The closer he gets to the wall of the room, 
which is the exit of The Cube, the harder the question gets. 
When he successfully answers the last question he sees his current score and the rank list.

### II.Technical implementation of the game

1. Main Menu - the method CallMenu() visualizes in the console 4 options. The Menu is implemented using
1 one-dimensional array that lists the main functionality of the game. The player can navigate and
choose options from the Menu.

2. Cube generation - The Cube is built using 1 three-dimensional array with size 3x3x3. A random generator creates a
path with exit, and when the game starts the player is positioned in the middle of the cube.

3. Player - The Player class handles information about: Player, Coordinates, Category, Score.

This class has 8 methods:

* Player() – initializes a player
* Coordinates() – keeps the current position of the player
* ChooseCategory() – in the beginning of the game the player chooses a category
* Credits() –  the remaining moves of the player to exit The Cube
* BonusScore() – formed from the remaining time which is added to the next question time for answering
* ChooseDirection() – after giving an answer the player chooses his next direction
* CheckForWall() – checks if the chosen direction is a wall
* AddPassedMoves() – records Player’s passed moves 

 4.Challenge

This class has 2 methods:

* TakeParts() – read text file from CSV
* DisplayChallenge() – display questions and answers

 5.Scores

This class has 2 methods:

* SortScores() – sorts the Top 10 scores in descending order
* CalculateScore() – calculates the score. Result is formed by the credits multiplied by the remaining time.

 6.Utility Class

This class has 3 methods:

* GenerateLabyrinth()
* WriteToCSV() 
* ReadFromCSV()