using System;

namespace ConsoleApp2
{
    public class XO
    {
        string[] pole = { "-", "-", "-", "-", "-", "-", "-", "-", "-" };
        private class Player
        {
            public string Name = string.Empty;
            public string A = string.Empty;
        }

        Player player1 = new Player();
        Player player2 = new Player();

        public void Print()
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
                Console.Write(pole[i]);
            }
            Console.WriteLine();
        }
        private void Players()
        {
            player1.A = "X";
            player1.Name = "Игрок 1";
            player2.A = "O";
            player2.Name = "Игрок 2";
        }
        private void Game1()
        {
            Console.WriteLine($"Ход первого игрока, введите номер ячейки:");
            bool b = int.TryParse(Console.ReadLine(), out int a);
            if ((b & (a < 10 && a > 0)) && pole[a - 1] == "-")
            {
                pole[a - 1] = player1.A;
            }
            else
            {
                Console.WriteLine("Неверно");
                Game1();
            }
        }
        private void Game2()
        {
            Console.WriteLine($"Ход второго игрока, введите номер ячейки:");
            bool b = int.TryParse(Console.ReadLine(), out int a);
            if ((b & (a < 10 && a > 0))&& pole[a-1] == "-")
            {
                pole[a - 1] = player2.A;
            }
            else
            {
                Console.WriteLine("Неверно");
                Game2();
            }
        }
        private bool VictoryComb(string[] comb)
        {
            int[] a = {1,2,3, 1,4,7, 1,5,9, 2,5,8, 4,5,6, 3,5,7, 3,6,9, 7,8,9};
            bool final = true;
            for (int i = 0; i < a.Length; i += 3)
            {
                if ((pole[a[i]-1] == pole[a[i+1] - 1] && pole[a[i+1] - 1] == pole[a[i+2] - 1]) && pole[a[i] - 1] != "-")
                {
                    Console.WriteLine("Victory");
                    if (pole[a[i] - 1] == "X")
                    {
                        Console.WriteLine("Победил первый игрок!!");
                    }
                    else Console.WriteLine("Победил второй игрок!!");
                    final = false;
                    break;
                }
            }
            return final;

        }
        public void Game()
        {
            Print();
            while (VictoryComb(pole))
            {
                Game1();
                Print();
                if (VictoryComb(pole) == false) break;
                Game2();
                Print();
            }
        }
        public XO()
        {
            Players();
        }
    }
}
