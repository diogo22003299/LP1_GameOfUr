# Royal Game of Ur

## Authorship

---

Diogo Freire, 22003299
Luminita Postoronca, 22002335

## Who did what?

---

Diogo Freire -> Coded, did the report(markdown) and the UML diagram.
Luminita Postoronca -> Coded, made de documentation(Doxygen) and the commentaries in the code.

---

## Project architecture
The game we decided to create was the **Royal Game of Ur** where the players roll 4 triangular dices and try to reach the end of the board with all the pieces.

About each file:
`Program` Starts the program, initializing the menu by drawing it.
`Menu` Draws the menu and allows the player to choose between quitting the game or playing it.
`Game` Allows for the game to start, to move the pieces, and to give the players the decisions in the game.
`Dice` rolls the dice and returns the number
`Piece` Gives the pieces IDs
`Player` Determines who's the player one and player two and the number of pieces they have.
`Renderer` renders the board, the choices, the winner and the roll value
`Tile` a stuct that holds some variables needed for the tiles of the board

---

## UML Diagram

---

## References
[LP1 Aulas](https://github.com/VideojogosLusofona/lp1_2020_aulas): For stuff learned in class
[W3Schools](https://www.w3schools.com/cs/default.asp): For some other basic info
