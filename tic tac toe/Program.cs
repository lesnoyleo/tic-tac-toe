using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    class Program
    {


        static void Main(string[] args)
        {
            bool isWin = true;
            bool mbLoose = false;
            bool mbWin = false;
            int[,] pole = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //1 - its point player, 5 - pc;
            Console.WriteLine("Привет");

            while (isWin)
            {
                PrintPole(pole);
                Console.WriteLine("-----------------");
                PlayersMove(pole);
                isWin = CheckWin(pole);
                PrintPole(pole);
                Console.WriteLine("Move turn PC");
                Console.WriteLine("-----------------");
                mbLoose = CheckNextMoveMaybeLoseForPc(pole);
                mbWin = CheckNextMoveMaybeWinForPc(pole);
                if (mbWin)
                {
                    MovePcIfMbWin(pole);
                }
                else if (mbLoose && (mbWin == false))
                {
                    MovePcIfMbLoose(pole);
                }
                else if ((mbLoose == false) &&(mbWin==false))
                {
                    PcMove(pole);
                }
                isWin = CheckWin(pole);
            }
            PrintPole(pole);
            Console.WriteLine("End!");


            Console.ReadKey();
        }

        public static void PrintPole(int[,] pole)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(pole[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }

        public static int[,] PlayersMove(int[,] pole)
        {
            int i, j;
            Console.WriteLine("Input i,j coordinates for you move");
            i = int.Parse(Console.ReadLine());
            j = int.Parse(Console.ReadLine());

            pole[i, j] = 1;
            return pole;
        }

        public static int[,] PcMove(int[,] pole)
        {
            bool firstMove = false;
            int firstMoveCheck = 0;
            Random x = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pole[i, j] == 1)
                    {
                        firstMoveCheck++;
                    }
                }
            }

            if (firstMoveCheck == 1)
            {
                firstMove = true;
            }

            if (firstMove)
            {
                if (pole[1, 1] == 1)
                {
                    int move = x.Next(0, 3);
                    switch (move)
                    {
                        case 0:
                            pole[0, 0] = 5;
                            break;
                        case 1:
                            pole[0, 2] = 5;
                            break;
                        case 2:
                            pole[2, 0] = 5;
                            break;
                        case 3:
                            pole[2, 2] = 5;
                            break;
                    }

                }
                else
                {
                    pole[1, 1] = 5;
                }
            }
            else
            {
                if (pole[0, 0] == 0)
                {
                    pole[0, 0] = 5;
                }
                else if (pole[0, 2] == 0)
                {
                    pole[0, 2] = 5;
                }
                else if (pole[2, 0] == 0)
                {
                    pole[2, 0] = 5;
                }
                else if (pole[2, 2] == 0)
                {
                    pole[2, 2] = 5;
                }

            }


            return pole;
        }

        public static bool CheckWin(int[,] pole)
        {
            //horizontal condition
            if (((pole[0, 0] + pole[0, 1] + pole[0, 2]) == 3) || ((pole[0, 0] + pole[0, 1] + pole[0, 2]) == 15))
            {
                return false;
            }
            if (((pole[1, 0] + pole[1, 1] + pole[1, 2]) == 3) || ((pole[1, 0] + pole[1, 1] + pole[1, 2]) == 15))
            {
                return false;
            }
            if (((pole[2, 0] + pole[2, 1] + pole[2, 2]) == 3) || ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == 15))
            {
                return false;
            }
            //vertical condition
            if (((pole[0, 0] + pole[1, 0] + pole[2, 0]) == 3) || ((pole[0, 0] + pole[1, 0] + pole[2, 0]) == 15))
            {
                return false;
            }
            if (((pole[0, 1] + pole[1, 1] + pole[2, 1]) == 3) || ((pole[0, 1] + pole[1, 1] + pole[2, 2]) == 15))
            {
                return false;
            }
            if (((pole[0, 2] + pole[1, 2] + pole[2, 2]) == 3) || ((pole[0, 2] + pole[1, 2] + pole[2, 2]) == 15))
            {
                return false;
            }
            //on the side 2 condition
            if (((pole[0, 0] + pole[1, 1] + pole[2, 2]) == 3) || ((pole[0, 0] + pole[1, 1] + pole[2, 2]) == 15))
            {
                return false;
            }
            if (((pole[0, 2] + pole[1, 1] + pole[2, 0]) == 3) || ((pole[0, 2] + pole[1, 1] + pole[2, 0]) == 15))
            {
                return false;
            }
            return true;
        }

        public static bool CheckNextMoveMaybeLoseForPc(int[,] pole)
        {
            //horizontal condition
            if ((pole[0, 0] + pole[0, 1] + pole[0, 2]) == 2)
            {
                return true;
            }
            if ((pole[1, 0] + pole[1, 1] + pole[1, 2]) == 2)
            {
                return true;
            }
            if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == 2)
            {
                return true;
            }
            //vertical condition
            if ((pole[0, 0] + pole[1, 0] + pole[2, 0]) == 2)
            {
                return true;
            }
            if ((pole[0, 1] + pole[1, 1] + pole[2, 1]) == 2)
            {
                return true;
            }
            if ((pole[0, 2] + pole[1, 2] + pole[2, 2]) == 2)
            {
                return true;
            }
            //on the side 2 condition
            if ((pole[0, 0] + pole[1, 1] + pole[2, 2]) == 2)
            {
                return true;
            }
            if ((pole[0, 2] + pole[1, 1] + pole[2, 0]) == 2)
            {
                return true;
            }
            return false;
        }

        public static void MovePcIfMbLoose(int[,] pole)
        {
            //horizontal condition
            if ((pole[0, 0] + pole[0, 1] + pole[0, 2]) == 2)
            {
                if (pole[0, 0] == 0)
                {
                    pole[0, 0] = 5;
                }
                else if (pole[0, 1] == 0)
                {
                    pole[0, 1] = 5;
                }
                else if (pole[0, 2] == 0)
                {
                    pole[0, 2] = 5;
                }
            }
            if ((pole[1, 0] + pole[1, 1] + pole[1, 2]) == 2)
            {
                if (pole[1, 0] == 0)
                {
                    pole[1, 0] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[1, 2] == 0)
                {
                    pole[1, 2] = 5;
                }
            }
            if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == 2)
            {
                if (pole[2, 0] == 0)
                {
                    pole[2, 0] = 5;
                }
                else if (pole[2, 1] == 0)
                {
                    pole[2, 1] = 5;
                }
                else if (pole[2, 2] == 0)
                {
                    pole[2, 2] = 5;
                }
            }
            //vertical condition
            if ((pole[0, 0] + pole[1, 0] + pole[2, 0]) == 2)
            {
                if (pole[0, 0] == 0)
                {
                    pole[0, 0] = 5;
                }
                else if (pole[1, 0] == 0)
                {
                    pole[1, 0] = 5;
                }
                else if (pole[2, 0] == 0)
                {
                    pole[2, 0] = 5;
                }
            }
            if ((pole[0, 1] + pole[1, 1] + pole[2, 1]) == 2)
            {
                if (pole[0, 1] == 0)
                {
                    pole[0, 1] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[2, 1] == 0)
                {
                    pole[2, 1] = 5;
                }
            }
            if ((pole[0, 2] + pole[1, 2] + pole[2, 2]) == 2)
            {
                if (pole[0, 2] == 0)
                {
                    pole[0, 2] = 5;
                }
                else if (pole[1, 2] == 0)
                {
                    pole[1, 2] = 5;
                }
                else if (pole[2, 2] == 0)
                {
                    pole[2, 2] = 5;
                }
            }
            //on the side 2 condition
            if ((pole[0, 0] + pole[1, 1] + pole[2, 2]) == 2)
            {
                if (pole[0, 0] == 0)
                {
                    pole[0, 0] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[2, 2] == 0)
                {
                    pole[2, 2] = 5;
                }
            }
            if ((pole[0, 2] + pole[1, 1] + pole[2, 0]) == 2)
            {
                if (pole[0, 2] == 0)
                {
                    pole[0, 2] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[2, 0] == 0)
                {
                    pole[2, 0] = 5;
                }
            }
        }

        public static bool CheckNextMoveMaybeWinForPc(int[,] pole)
        {
            //horizontal condition
            if ((pole[0, 0] + pole[0, 1] + pole[0, 2]) == 10)
            {
                return true;
            }
            if ((pole[1, 0] + pole[1, 1] + pole[1, 2]) == 10)
            {
                return true;
            }
            if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == 10)
            {
                return true;
            }
            //vertical condition
            if ((pole[0, 0] + pole[1, 0] + pole[2, 0]) == 10)
            {
                return true;
            }
            if ((pole[0, 1] + pole[1, 1] + pole[2, 1]) == 10)
            {
                return true;
            }
            if ((pole[0, 2] + pole[1, 2] + pole[2, 2]) == 10)
            {
                return true;
            }
            //on the side 2 condition
            if ((pole[0, 0] + pole[1, 1] + pole[2, 2]) == 10)
            {
                return true;
            }
            if ((pole[0, 2] + pole[1, 1] + pole[2, 0]) == 10)
            {
                return true;
            }
            return false;
        }

        public static void MovePcIfMbWin(int[,] pole)
        {
            //horizontal condition
            if ((pole[0, 0] + pole[0, 1] + pole[0, 2]) == 10)
            {
                if (pole[0, 0] == 0)
                {
                    pole[0, 0] = 5;
                }
                else if (pole[0, 1] == 0)
                {
                    pole[0, 1] = 5;
                }
                else if (pole[0, 2] == 0)
                {
                    pole[0, 2] = 5;
                }
            }
            if ((pole[1, 0] + pole[1, 1] + pole[1, 2]) == 10)
            {
                if (pole[1, 0] == 0)
                {
                    pole[1, 0] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[1, 2] == 0)
                {
                    pole[1, 2] = 5;
                }
            }
            if ((pole[2, 0] + pole[2, 1] + pole[2, 2]) == 10)
            {
                if (pole[2, 0] == 0)
                {
                    pole[2, 0] = 5;
                }
                else if (pole[2, 1] == 0)
                {
                    pole[2, 1] = 5;
                }
                else if (pole[2, 2] == 0)
                {
                    pole[2, 2] = 5;
                }
            }
            //vertical condition
            if ((pole[0, 0] + pole[1, 0] + pole[2, 0]) == 10)
            {
                if (pole[0, 0] == 0)
                {
                    pole[0, 0] = 5;
                }
                else if (pole[1, 0] == 0)
                {
                    pole[1, 0] = 5;
                }
                else if (pole[2, 0] == 0)
                {
                    pole[2, 0] = 5;
                }
            }
            if ((pole[0, 1] + pole[1, 1] + pole[2, 1]) == 10)
            {
                if (pole[0, 1] == 0)
                {
                    pole[0, 1] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[2, 1] == 0)
                {
                    pole[2, 1] = 5;
                }
            }
            if ((pole[0, 2] + pole[1, 2] + pole[2, 2]) == 10)
            {
                if (pole[0, 2] == 0)
                {
                    pole[0, 2] = 5;
                }
                else if (pole[1, 2] == 0)
                {
                    pole[1, 2] = 5;
                }
                else if (pole[2, 2] == 0)
                {
                    pole[2, 2] = 5;
                }
            }
            //on the side 2 condition
            if ((pole[0, 0] + pole[1, 1] + pole[2, 2]) == 10)
            {
                if (pole[0, 0] == 0)
                {
                    pole[0, 0] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[2, 2] == 0)
                {
                    pole[2, 2] = 5;
                }
            }
            if ((pole[0, 2] + pole[1, 1] + pole[2, 0]) == 10)
            {
                if (pole[0, 2] == 0)
                {
                    pole[0, 2] = 5;
                }
                else if (pole[1, 1] == 0)
                {
                    pole[1, 1] = 5;
                }
                else if (pole[2, 0] == 0)
                {
                    pole[2, 0] = 5;
                }
            }
        }

    }
}
