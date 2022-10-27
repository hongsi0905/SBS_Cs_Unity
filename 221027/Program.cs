using System;

namespace _221027
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int[,] arr = new int[3, 2]
            {
                { 1 ,2 },
                { 3 ,4 },
                { 5 ,6 },
            };

            Console.WriteLine($"2차원 배열 행(Y) : {arr.GetLength(0)}");
            Console.WriteLine($"2차원 배열 열(X) : {arr.GetLength(1)}");
            Console.WriteLine($"2차원 배열 개수 : {arr.GetLength(0) * arr.GetLength(1)}");

            arr[0, 0] = 1;
            arr[1, 0] = 2;
            arr[1, 0] = 3;
            arr[1, 1] = 4;
            arr[2, 0] = 5;
            arr[2, 1] = 6;*/


            // Game loop
           
                GameManager gameManager = new GameManager();
                gameManager.GameStart();
            

        }
    }
}
