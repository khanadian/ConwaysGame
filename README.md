# ConwaysGame
A simulation of Conway's game of life.

Rules:
the game is made up of NxN cells. each cell is either dead or alive. Each cell has eight neighbors found adjacent vertically, horizontally, and diagonally

Every iteration, the cells will change based on the following criteria:
1. Living cells will die of underpopulation if less than two neighbors are alive
2. Living cells will die of overpopulation if more than three neighbors are alive
3. Dead cells will be reproduced if exactly three neighbors are alive
