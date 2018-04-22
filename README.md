# Simplexity

## Who did this project?

* __Inês Gonçalves__
    * a21702076

* __Inês Nunes__
    * a21702520

* __João Duarte__
    * a21702097

## Git repository

We worked in a private repository that will be available in this
[link](https://github.com/JoaoAlexandreDuarte/1-Projeto-LP) after the deadline.

## Information about who made what // Who did what?

Everyone contributed and helped with the project, both in person and online,
but below, there's a summary of each individual's contributions:

* __Inês Gonçalves__
    * Enumerations : Color and Shape;
    * Class: Piece;
    * Made the diagram and fluxogram;
    * Made and fixed comments;
    * Helped with the report.

* __Inês Nunes__
    * Enumerations: PlayerNumber;
    * Class: Player, Interface, GameLoop;
    * Added and fixed comments;
    * Helped with the fluxogram and diagram;
    * Made the report.

* __João Duarte__
    * Class: Board, GameLoop, Checker;
    * Improved the other classes;
    * Made comments;
    * Helped with the report;
    * Helped with the diagram;
    * Coordinated the overall project and assisted the fellow colleagues.

## Our solution

### Architecture

The program was organized using _classes_ and _enumerations_ for easier
understanding and to keep the code cleaner.

At launching, the game creates the players and an instance of the given pieces,
that will be copied and saved after being played on the board, so that it can
avoid creating 42 pieces. This way, we only create 4 pieces that will copied.
The _GameLoop_ will manage everything, by calling the corresponding _methods_
according to necessary.

For example, the _GameLoop_ will ask the player for a piece to be played, and
will get the piece from the _Player_ and place it on the _Board_ in the
corresponding column.

About the algorithms, the verification of the winning situation was made in the
following way:

It searches vertically, horizontally, diagonally in an upward and downward way,
starting at the beginning of the _array_, first by searching for shape, 
and then by color, so that it follows the game's rules.
By finding 4 followed pieces of the same shape or color, it stops verifying the
other conditions, and takes care of checking which player has won.

### UML Diagram

![UML Diagram](https://i.imgur.com/ldm1VDp.png)

### Fluxogram

<p align="center">
  <img src="https://i.imgur.com/APlLnv6.png" alt="Fluxogram"/>
</p>

## Conclusions

With this project, we learned 

## References

* <a name="ref1">[1]</a> Whitaker, R. B. (2016). The C# Player's Guide
  (3rd Edition). Starbound Software.
* <a name="ref2">[2]</a> Brain Bender Games (2009). Simplexity Game Rules.
  Discovery Bay Games.
* <a name="ref3">[3]</a> Simplexity. (2009) Retrieved from
  https://boardgamegeek.com/boardgame/55810/simplexity

