# Chess Game

# UNOFFICIAL FORK!
# FIND THE ORIGINAL PROJECT HERE:

#[Chess](https://github.com/ThiagoServulo/Chess)
#[@thiagoservulo](https://github.com/ThiagoServulo)

## Chess 960
Chess 960 is a variant on the game of chess wherein all of the back-row pieces are shuffled.

There are two specific requirements of the shuffled rows:
1. Each bishop must occupy a separate color.
2. The king must occupy a space between the two rooks.

## Changelog

List of Changes (Since I Forgot to Add The Project to Github First)

Added Startup.cs:
+ I set the application to open the Startup form instead of the Board form.
+ The Startup form contains two buttons. One button opens the Board set to play regular chess, and the second button opens to board to play Chess960.

In Board.cs:
+ Added public enumeration Mode, with values Chess and Chess960.
+ Added a mode parameter to the constructor, which defaults to Mode.Chess.
+ Add member variable \_mode, which is set in the constructor.

+ Added a switch function at the end of the InitializeNewGame() method, calling either InitializeBoard() or Initialize960Board().
+ Added the Initialize960Board() method, which first places all of the pawns and then calls SetPieces960() for each end of the board.
+ Added the SetPieces960() method, which fills a single row of the chessboard with pieces according to the Fischer random chess requirements.
	- The algorithm sets the two Bishops first, using a modulo to differentiate between the colored spaces.
	- The algorithm then sets the Queen and Knights arbitrarily.
	- After that, the algorithm scans through the row and places the last three pieces in the order of available space: Rook - King - Rook.

In King.cs:
+ Because of an issue with the game's algorithm for checking whether or not the King may move to spaces, I had to modify this script.
+ To briefly explain, I had to prevent the algorithm from trying to check coordinates that didn't exist in the board array.
+ While I could have used ternery operations or if/else statements, I found those to be repetative and icky, so I wrote a method that performs the operations without looking as nasty: TryOffsetPositionWithinBounds().
+ This method is likely applicable elsewhere in the application.

Unit Testing:
+ I created a Visual Studio Unit Test Project. Because this Chess application is built in .NET 3.1, I cannot actually add the project as a dependency in the test project; test projects do not support .NET 3.1 at all.
+ I also struggled to figure out what to test, since I really didn't write that many methods.
+ I chose to test each step of the SetPieces960 method individually, checking for:
	- if the bishops were placed on different colors
	- if the queen and knights were placed
	- if the king and rooks were arranged correctly
	- if the king and rooks were placed
+ I also tested several use cases for the TryOffsetPositionWithinBounds() method:
	- Checked for successfully updated offset positions in the positive and negative x directions.
	- Checked for unchanged (offset was outside of the bounds) positions in the positive and negative x directions.