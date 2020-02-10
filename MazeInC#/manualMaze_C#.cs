using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        const int size = 25;
        static string[] temStringArr = new string[size];
        static int strArrNumber = -1;


        public static string temporary = null;

        static void Main(string[] args)
        {
            int[,] maze = new int[5, 5];

            maze[0, 0] = 2; maze[0, 1] = 0; maze[0, 2] = 0; maze[0, 3] = 0; maze[0, 4] = 0;
            maze[1, 0] = 1; maze[1, 1] = 1; maze[1, 2] = 1; maze[1, 3] = 1; maze[1, 4] = 1;
            maze[2, 0] = 0; maze[2, 1] = 0; maze[2, 2] = 0; maze[2, 3] = 0; maze[2, 4] = 1;
            maze[3, 0] = 0; maze[3, 1] = 0; maze[3, 2] = 0; maze[3, 3] = 0; maze[3, 4] = 1;
            maze[4, 0] = 0; maze[4, 1] = 0; maze[4, 2] = 0; maze[4, 3] = 0; maze[4, 4] = 1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine("");
            }

            ConsoleKeyInfo key;

            if (maze[3, 3] == 0 && maze[3, 4] == 0 && maze[4, 3] == 0)
            {
                Console.WriteLine("the end isnt reachable");
                goto yessir;
            }

            int ii = 0, jj = 0;
            Console.SetCursorPosition(ii, jj);

            while (maze[ii, jj] != maze[4, 4])
            {
                key = Console.ReadKey(true);

                if (key.Key.ToString() == "UpArrow")
                {
                    if (checkUp(ii - 1, jj, maze) == true)
                    {
                        string[] yo = new string[5];
                        int a = 0;
                        int c = 1;
                        ii = ii - 1;
                        maze = screenRefreshed(maze, ii, jj, c);

                        string str = mazeCheckerForCursor(maze);

                        for (int mak = 0; mak < yo.Length; mak++)
                        {
                            yo[mak] = null;
                        }

                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] != ',')
                            {
                                yo[a] = str[i].ToString();
                            }
                            else
                            {
                                a++;
                            }
                        }

                        ii = int.Parse(yo[0]);
                        jj = int.Parse(yo[1]);

                        Console.SetCursorPosition(jj, ii);
                    }
                }

                else if (key.Key.ToString() == "RightArrow")
                {
                    if (checkRight(ii, jj + 1, maze) == true)
                    {
                        string[] yo = new string[5];
                        int a = 0;
                        int c = 2;
                        jj = jj + 1;
                        maze = screenRefreshed(maze, ii, jj, c);


                        string str = mazeCheckerForCursor(maze);

                        for (int mak = 0; mak < yo.Length; mak++)
                        {
                            yo[mak] = null;
                        }

                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] != ',')
                            {
                                yo[a] = str[i].ToString();
                            }
                            else
                            {
                                a++;
                            }
                        }

                        ii = int.Parse(yo[0]);
                        jj = int.Parse(yo[1]);

                        Console.SetCursorPosition(jj, ii);
                    }
                }

                else if (key.Key.ToString() == "DownArrow")
                {
                    if (checkDown(ii + 1, jj, maze) == true)
                    {
                        string[] yo = new string[5];
                        int a = 0;
                        int c = 3;
                        ii = ii + 1;
                        maze = screenRefreshed(maze, ii, jj, c);


                        string str = mazeCheckerForCursor(maze);

                        for (int mak = 0; mak < yo.Length; mak++)
                        {
                            yo[mak] = null;
                        }

                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] != ',')
                            {
                                yo[a] = str[i].ToString();
                            }
                            else
                            {
                                a++;
                            }
                        }

                        ii = int.Parse(yo[0]);
                        jj = int.Parse(yo[1]);

                        Console.SetCursorPosition(jj, ii);
                    }
                }

                else if (key.Key.ToString() == "LeftArrow")
                {
                    if (checkLeft(ii, jj - 1, maze) == true)
                    {
                        string[] yo = new string[5];
                        int a = 0;
                        int c = 4;
                        jj = jj - 1;
                        maze = screenRefreshed(maze, ii, jj, c);

                        string str = mazeCheckerForCursor(maze);

                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] != ',')
                            {
                                yo[a] = str[i].ToString();
                            }
                            else
                            {
                                a++;
                            }
                        }

                        ii = int.Parse(yo[0]);
                        jj = int.Parse(yo[1]);

                        Console.SetCursorPosition(jj, ii);

                    }
                }
            }


            Console.WriteLine("");

            Console.WriteLine("congratulations!you hve reached the end");

        yessir:
            Console.ReadLine();
        }

        public static string mazeCheckerForCursor(int[,] maze)
        {
            string str = null;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (maze[i, j] == 2)
                    {
                        str = i.ToString() + ',' + j.ToString();
                        break;
                    }
                }
            }
            return str;
        }

        public static int[,] screenRefreshed(int[,] maze, int ii, int jj, int c)
        {
            Console.Clear();

            maze[0, 0] = 1; maze[0, 1] = 0; maze[0, 2] = 0; maze[0, 3] = 0; maze[0, 4] = 0;
            maze[1, 0] = 1; maze[1, 1] = 1; maze[1, 2] = 1; maze[1, 3] = 1; maze[1, 4] = 1;
            maze[2, 0] = 0; maze[2, 1] = 0; maze[2, 2] = 0; maze[2, 3] = 0; maze[2, 4] = 1;
            maze[3, 0] = 0; maze[3, 1] = 0; maze[3, 2] = 0; maze[3, 3] = 0; maze[3, 4] = 1;
            maze[4, 0] = 0; maze[4, 1] = 0; maze[4, 2] = 0; maze[4, 3] = 0; maze[4, 4] = 1;

            if (c == 1)
            {
                maze[ii + 1, jj] = 1;
            }
            else if (c == 2)
            {
                maze[ii, jj - 1] = 1;
            }
            else if (c == 3)
            {
                maze[ii - 1, jj] = 1;
            }
            else if (c == 4)
            {
                maze[ii, jj + 1] = 1;
            }

            maze[ii, jj] = 2;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine("");
            }

            return maze;
        }

        static public bool checkUp(int ii, int jj, int[,] maze)
        {
            if (ii >= 0 && ii < 5 & jj >= 0 & jj < 5 && maze[ii, jj] == 1)
            {
                string temp = null;
                temp = ii.ToString() + jj.ToString();
                //push(temp);
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool checkRight(int ii, int jj, int[,] maze)
        {
            if (ii >= 0 && ii < 5 & jj >= 0 & jj < 5 && maze[ii, jj] == 1)
            {
                string temp = null;
                temp = ii.ToString() + jj.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool checkDown(int ii, int jj, int[,] maze)
        {
            if (ii >= 0 && ii < 5 & jj >= 0 & jj < 5 && maze[ii, jj] == 1)
            {
                string temp = null;
                temp = ii.ToString() + jj.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool checkLeft(int ii, int jj, int[,] maze)
        {
            if (ii >= 0 && ii < 5 & jj >= 0 & jj < 5 && maze[ii, jj] == 1)
            {
                string temp = null;
                temp = ii.ToString() + jj.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void push(string temp)
        {
            strArrNumber++;
            temStringArr[strArrNumber] = temp;
        }

        public static bool backtracking()
        {
            return false;
        }
    }
}
