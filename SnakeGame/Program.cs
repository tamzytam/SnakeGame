using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 50;
            Console.BufferHeight = 30;
            Console.BufferWidth = 50;

            // Set initial values for the game
            int gameSpeed = 100;
            int direction = 0;
            int score = 0;
            Random randomNumber = new Random();

            // Create a list to store the body of the snake
            List<int> xPositions = new List<int>();
            List<int> yPositions = new List<int>();
            xPositions.Add(25);
            yPositions.Add(15);

            // Generate a random location for the food
            int foodX = randomNumber.Next(0, Console.WindowWidth);
            int foodY = randomNumber.Next(0, Console.WindowHeight);

            // Start the game loop
            while (true)
            {
                // Clear the console
                Console.Clear();

                // Draw the food
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(foodX, foodY);
                Console.Write("O");

                // Draw the snake
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < xPositions.Count; i++)
                {
                    Console.SetCursorPosition(xPositions[i], yPositions[i]);
                    Console.Write("*");
                }

                // Check for user input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        direction = 1;
                    }
                    else if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        direction = 2;
                    }
                    else if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        direction = 3;
                    }
                    else if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        direction = 4;
                    }
                }

                // Move the snake
                for (int i = xPositions.Count - 1; i > 0; i--)
                {
                    xPositions[i] = xPositions[i - 1];
                    yPositions[i] = yPositions[i - 1];
                }

                if (direction == 1)
                {
                    xPositions[0]--;
                }
                else if (direction == 2)
                {
                    xPositions[0]++;
                }
                else if (direction == 3)
                {
                    yPositions[0]--;
                }
                else if (direction == 4)
                {
                    yPositions[0]++;
                }

                // Check for collision with the food
                if (xPositions[0] == foodX && yPositions[0] == foodY)
                {
                    score++;
                    gameSpeed--;
                    xPositions.Add(xPositions[xPositions.Count - 1]);
                    yPositions.Add(yPositions[yPositions.Count - 1]);
                    foodX = randomNumber.Next(0, Console.WindowWidth);
                    foodY = randomNumber.Next(0, Console.WindowHeight);
                }
                // Check for collision with the walls
                if (xPositions[0] < 0 || xPositions[0] >= Console.WindowWidth ||
                    yPositions[0] < 0 || yPositions[0] >= Console.WindowHeight)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, Console.WindowHeight / 2);
                    Console.WriteLine("Game Over! Final Score: " + score);
                    Console.ReadLine();
                    return;
                }

                // Check for collision with the body of the snake
                for (int i = 1; i < xPositions.Count; i++)
                {
                    if (xPositions[0] == xPositions[i] && yPositions[0] == yPositions[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0, Console.WindowHeight / 2);
                        Console.WriteLine("Game Over! Final Score: " + score);
                        Console.ReadLine();
                        return;
                    }
                }

                // Update the score
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Score: " + score);

                // Slow down the game
                System.Threading.Thread.Sleep(gameSpeed);
            }
        }
    }
}
