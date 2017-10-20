# Prism Coding Challenge

### Board Game

Develop a game engine using these conditions:

* M x N dimensions board
* 2 players represented by Xs and Os
* Players move in alternating turns

|  |  |  |  |  |  |  |
|---|---|---|---|---|---|---|
|:white_large_square:|:white_large_square:|:white_large_square:|:white_large_square:|:white_large_square:|:white_large_square:|:white_large_square:|
|:white_large_square:|:x:|:o:|:white_large_square:|:white_large_square:|:white_large_square:|:white_large_square:|
|:white_large_square:|:x:|:white_large_square:|:o:|:white_large_square:|:white_large_square:|:white_large_square:|
|:white_large_square:|:x:|:white_large_square:|:white_large_square:|:o:|:white_large_square:|:white_large_square:|
|:white_large_square:|:x:|:white_large_square:|:white_large_square:|:white_large_square:|:o:|:white_large_square:|
|:white_large_square:|:x:|:white_large_square:|:white_large_square:|:white_large_square:|:white_large_square:|:white_large_square:|

Given the coordinates(x, y) of the last move, determine if the last move was a winning move

Winning condition is 5 adjacent Xs or Os (row, column, or diagonal)