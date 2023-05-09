# Sudoku Master

Sudoku Master is a classic Sudoku game that runs in mobile devices, under Android and iOS platforms. 

This project was developed for the HOMA Games recruiting process and its purpose is to showcase my Unity3D developer skills, creativity and UI sensitivity.

The project´s repository can be found at GitHub: https://github.com/fpistasoli/Sudoku/tree/develop


## Installation

1. Clone the repository´s develop branch (https://github.com/fpistasoli/Sudoku.git) to your local machine. You can use a Git client to do this, for instance Sourcetree or GitHub Desktop.

2. Open Unity Hub and add the Sudoku Master project. Then open it with the editor version 2020.3.27f1.

3. Once the project is open in Unity, click on File -> Build Settings. 

4. Select the platform on which you would like to use to install the game (Android / iOS) and click on "Switch platform".

5. Edit your "Player Settings". Make sure to choose a Portrait default orientation for the game in "Resolution and Presentation" tab, as the game is aimed to be played this way.

6. To make an Android build, make sure to your phone is plugged to the machine via USB and enable Developer Mode. Also make sure USB debugging is on and the option "File transfer via USB" is enabled too.

7. Click on "Build and Run". You can create a folder called "Builds" and save the generated build here.

8. Once this process is done, you will be able to run the app on your device.

   
## Gameplay and mechanics

This is a classic 9x9 Sudoku game. The aim of the game is to fill the 9x9 square with numbers from 1-9 with no repeated numbers in each row and column. Additionally, there are nine 3x3 squares marked out in the grid, and each of these squares can´t have any repeated numbers either.

The game starts with a Main Menu (Main Scene), where you can select the level (difficulty) you would like to play: easy or hard. This selection will impact on the number of clues provided in the grid. In order for the game to have a unique solution, it must feature at least 17 clues. In this version, Easy level provides between 32 and 35 clues, while Hard level provides between 25 and 28 clues.

After choosing the level, you go onto the Game Scene. Here is where the actual game is played. The scene is divided in three sections: the HUD on top, the Sudoku grid in the centre and buttons at the bottom.

The HUD shows the chosen level and the number of mistakes made throughout the game. In order to fill the grid, you first select a cell and then choose a number from the list of number buttons. If the answer is incorrect, the number will be shown in red in the cell, otherwise it will be blue and display a prompt on top of the board among these: OK!, GOOD!, COOL! If the answer is incorrect, a mistake is counted and can be erased with the Eraser button. If the answer is correct or you the selected cell is a clue, then it cannot be erased.

When the grid is fully complete with correct answers, you are sent to the Game Win Scene, where you can see a "LEVEL COMPLETE" message with an character animation, the total number of mistakes made throughout the game, and a "BACK" button that appears after some time. This button enables you to go back to the main menu and play the game again (ensuring a looping game).


## Code reusability

The project uses SOLID principles, some design/architectural patterns to ensure code scalability and reusability.

In particular, there are some parts of the code that could be implemented as independent modules to allow faster development of similar games in the future:

- ICell.cs
This interface provides methods that can be used for other games, such as crosswords. In this case, we could segregate this interface into two interfaces, such as ICellNumber and ICellLetter and then create a model "CellLetter" that implements ICellLetter, that uses some of the methods in ICell. For example, IsSelected() could be used for both games but HideCellNumberIfZero() only makes sense in ICellNumber, as it is needed for the backtracking algorithm to properly populate the Sudoku grid.

- Board.cs and IBoard.cs
The method GridGenerator() uses backtracking to populate the Sudoku grid. This DFS algorithm is also used in games that need a maze to be generated. Also it can be reused in a chess game to decide the steps needed to do checkmate.

The method could be moved to an interface to allow for reusability in future similar games that use backtracking to find solutions. 

Also the IBoard interface could be used for a crossword game, because it exposes two methods, one to get the cells of the grid and another to decide whether a given cell is valid. For a crossword game, a CrosswordBoard class could be created that implements IBoard and its methods. 

If the implementation for both methods in both games is similar, alternatively a Board abstract class could be created and then two concrete classes (namely SudokuBoard and CrosswordBoard) would inherit from this abstract class and override these methods.

- MainMenu.cs and MainScene
The main scene could be reused for other simple games where we have two possible levels of difficulty. The script that manages the scene is fairly simple as well and could be reused or adjusted to the new game.

I use the MVP pattern, for instance, to manage the Game Scene. We can see an interaction among the BoardPresenter class, Board and the View provided by the Unity Game Scene.

I also use the Singleton pattern to create a single-instance GameManager that persists all throughout the game and records the number of mistakes made. Also I use the Observer pattern in event handling, where the subjects are the models and the presenters are listening for events and handles them appropriately.


## Unity Version

This game was made with the Unity 2020.3.27f1 version.
