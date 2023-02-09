# SnakeGame
The above code is a program written in C# that implements a snake game. It makes use of the System and System.Collections.Generic namespaces. The program defines a class named "Program" and implements a Main method, which serves as the entry point for the program.

The first part of the Main method sets the height and width of the console window, as well as its buffer height and width, to 30 and 50 respectively. Then, some initial values for the game are set, such as the game speed, direction, score, and a random number generator.

Next, two lists are created to store the x and y positions of the body of the snake. These lists are then initialized with an initial value of 25 for the x position and 15 for the y position.

The program then generates a random location for the food in the console window by using the random number generator.

A while loop is used to implement the game loop. Inside the loop, the console is cleared and the food and snake are drawn on the screen. The program checks for user input to determine the direction in which the snake should move, and the snake's position is updated accordingly. The program also checks for a collision between the snake's head and the food, and updates the score and game speed if a collision is detected.

Finally, the program waits for a short period of time (determined by the game speed) before repeating the game loop. This creates the illusion of motion in the game.
