using System;
using System.Threading;

class Snake
{
    //ancho y alto del tablero
    static int width = 20;
    static int height = 20;
    //puntaje
    static int score = 0;
    //fin del juego
    static bool gameOver = false;
    //que la fruta se posicione aleatoriamente
    static Random random= new Random();

    //posicion de la serpiente y la fruta
    static int snakeX;
    static int snakeY;
    static int frutaX;
    static int frutaY;

    //tamaño de la cola
    static int[] tailX = new int[100];
    static int[] tailY = new int[100];

    static int tailLength = 0;

    static int speed = 10;
    static int direccion = 0;
    static public void Main()
    {
        Console.Title = "Snake game 1.0";
        Console.CursorVisible = false;

        InitializeGame();

        while(!gameOver)
        {
            if(Console.KeyAvailable)
            {
                HandleKeypress(Console.ReadKey(true).key);
            }
            moveSnake();

            if (CheckCollision())
            {
                gameOver= true;
            }
            Draw();
            Thread.Sleep(1000/speed);
        }

        Console.SetCursorPosition(width / 2 - 5, height / 2);
        Console.WriteLine($"Puntuación final: {score}");
    }

    static void InitializeGame()
    {
        snakeX= width/2;
        snakeY= height/2;

        frutaX= random.Next(1,width-1);
        frutaY= random.Next(1,height-1);

        score = 0;
        direccion=0;
    }

    static void Draw()
    {
        Console.Clear();

        for(int i =0; i<width+1; i++)
        {
            Console.Write("#");
        }
        Console.WriteLine();

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j == 0)
                {
                    Console.Write("#");
                }else if(j == width-1) {
                    Console.Write("#");
                }else if (i==snakeY&&j==snakeX)
                {
                    Console.Write("0");
                }
                else if (i == frutaY && j == frutaX)
                {
                    Console.Write("X");
                }
                else
                {
                    bool tailBit = false;
                    for (int k = 0; k < tailLength; k++)
                    {
                        if (tailX[k] == j && tailY[k] == i)
                        {
                            tailBit = true;
                            break;
                        }

                    }
                    if(tailBit)
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"score: {score}");
            }
        }
    }

    static void HandleKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                if (direccion != 2)
                {
                    direccion = 0;
                }
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                if (direccion != 3)
                {
                    direccion = 1;
                }
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                if (direccion != 0)
                {
                    direccion = 2;
                }
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                if (direccion != 1)
                {
                    direccion = 3;
                }
                break;
            case ConsoleKey.Escape:
                gameOver= true;
                break;
        }
    }

    static void MoveSnake()
    {
        int prevX = tailX[0], prevY= tailY[0], prev2X, prev2Y;

        tailX[0] = snakeX;
        tailY[0] = snakeY;

        for (int i = 0; i < tailLength; i++)
        {

        }
    }
}