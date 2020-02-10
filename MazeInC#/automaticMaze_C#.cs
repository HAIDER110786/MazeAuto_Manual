using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        const int size = 25;
        static public string[] visit = new string[size];
        static public int top = -1;

        const int size1 = 25;
        static public string[] deadend = new string[size1];
        static public int top1 = -1;

        static void Main(string[] args)
        {
            int[,] maze = new int[5, 5];
            int[] COlandROWseparater = new int[2];

            maze[0, 0] = 1; maze[0, 1] = 0; maze[0, 2] = 0; maze[0, 3] = 0; maze[0, 4] = 1;
            maze[1, 0] = 1; maze[1, 1] = 1; maze[1, 2] = 1; maze[1, 3] = 1; maze[1, 4] = 1;
            maze[2, 0] = 1; maze[2, 1] = 1; maze[2, 2] = 0; maze[2, 3] = 0; maze[2, 4] = 1;
            maze[3, 0] = 1; maze[3, 1] = 0; maze[3, 2] = 0; maze[3, 3] = 0; maze[3, 4] = 0;
            maze[4, 0] = 1; maze[4, 1] = 1; maze[4, 2] = 1; maze[4, 3] = 1; maze[4, 4] = 1;



            Console.WriteLine("The original maze is:");

            Console.WriteLine("");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine("");
            }

            int row = 0, col = 0;

            while (checkMazePaths(col, row, maze) == true)
            {
                //up
                if (col - 1 >= 0 && col - 1 < 5 && row >= 0 && row < 5 && maze[col - 1, row] == 1 && isVisited(col-1, row) == false && isDead(col-1, row) == false)
                {
                    //Console.WriteLine("getting here in the up");
                    push(col, row);
                    col = col - 1;
                }
                //right
                else if (row + 1 >= 0 && row + 1 < 5 && col >= 0 && col < 5 && maze[col, row + 1] == 1 && isVisited(col, row + 1) == false && isDead(col, row + 1) == false)
                {
                    //Console.WriteLine("getting here in the right");
                    push(col, row);
                    row = row + 1;
                }
                //down
                else if (col + 1 >= 0 && col + 1 < 5 && row >= 0 && row < 5 && maze[col + 1, row] == 1 && isVisited(col + 1, row) == false && isDead(col + 1,row) == false)
                {
                    //Console.WriteLine("getting here in the down");
                    push(col, row);
                    col = col + 1;
                }
                //left
                else if (row - 1 >= 0 && row - 1 < 5 && col >= 0 && col < 5 && maze[col, row - 1] == 1 && isVisited(col, row - 1) == false && isDead(col, row - 1) == false)
                {
                    //Console.WriteLine("getting here in the left");
                    push(col, row);
                    row = row - 1;
                }
                else
                {
                    if(checkforDEADEND(col,row,maze)==true)
                    {
                        pushintodeadend(col,row);
                    }

                    COlandROWseparater = RCseperator(pop());

                    col = COlandROWseparater[0];
                    row = COlandROWseparater[1];
                }



                if (col == 4 && row == 4)
                {
                    push(col, row);
                    break; 
                }
            }

            //if (checkMazePaths(col, row, maze) == false)
            //{
            //    if (checkForDeadEnd(col,row,maze) == true)
            //    {
            //        COlandROWseparater = RCseperator(pop());

            //        col = COlandROWseparater[0];
            //        row = COlandROWseparater[1];
            //        goto yo3;
            //    }

            //    else if (checkinbetweenDeadendandVisited(col, row, maze) == true)
            //    {

            //        COlandROWseparater= RCseperator(pop());
              
            //        col = COlandROWseparater[0];
            //        row = COlandROWseparater[1];
            //        goto yo3;
            //    }
            //    else if (checkinbetweentheDead(col, row, maze) == true)
            //    {

            //        COlandROWseparater = RCseperator(pop());

            //        col = COlandROWseparater[0];
            //        row = COlandROWseparater[1];
            //        goto yo3;
            //    }
            //    else if (checkinbetweentheVisited(col, row, maze) == true)
            //    {

            //        COlandROWseparater = RCseperator(pop());

            //        col = COlandROWseparater[0];
            //        row = COlandROWseparater[1];
            //        goto yo3;
            //    }
            //    else if (checkinbetweenDeadendandVisited(col, row, maze) == true)
            //    {

            //        COlandROWseparater = RCseperator(pop());

            //        col = COlandROWseparater[0];
            //        row = COlandROWseparater[1];
            //        goto yo3;
            //    }

            //}

        //while(top>=0)
        //{
        //    Console.WriteLine(pop());
        //}

            Console.WriteLine("");
            Console.WriteLine("The solved maze is:");
            Console.WriteLine("");


            while(top>=0)
            {
                COlandROWseparater=RCseperator(pop());

                col = COlandROWseparater[0];
                row = COlandROWseparater[1];

                maze[col, row] = 2;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }


        


        public static bool stuckshortcut(int col,int row)
        {
            if (isVisited(col-1, row) == false)
            {
                return false;
            }
            else if (isVisited(col, row+1) == false)
            {
                return false;
            }
            else if (isVisited(col+1, row) == false)
            {
                return false;
            }
            else if (isVisited(col, row-1) == false)
            {
                return false;
            }
            else if (isVisited(col-1, row) == false)
            {
                return false;
            }
            else if (isVisited(col, row+1) == false)
            {
                return false;
            }
            else if (isVisited(col+1, row) == false)
            {
                return false;
            }
            else if (isVisited(col, row-1) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool checkForDeadEnd(int col, int row, int[,] maze)
        {

            if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == false && isDead(col + 1, row) == false && maze[col+1,row]==1 && isWall(col, row - 1) == true) 
            {
                return false;
            }


            if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }



            else if (isWall(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }




            else if (isWall(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && isVisited(col, row - 1) == true)
            {
                return true;
            }




            else if(isVisited(col - 1, row) == true && row+1<5 && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && row-1>=0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }



            else if (isWall(col - 1, row) == true && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }



            else if (isWall(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isWall(col, row + 1) == true && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }







            else if (maze[col - 1, row] == 0 && isWall(col, row + 1) == true && isWall(col + 1, row) == true && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row)== true && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }




            else if (isVisited(col - 1, row) == true && isWall(col, row + 1)== true && maze[col + 1, row] == 0 && isWall(col, row - 1)== true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col, row + 1) == true && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && isWall(col + 1, row)== true && isWall(col, row - 1) == true)
            {
                return true;
            }



            else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && isWall(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col, row + 1) == true && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }



            else if (maze[col - 1, row] == 0 && isWall(col, row + 1) == true && isVisited(col + 1, row) == true && isWall(col, row - 1)== true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isWall(col, row + 1) == true && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }




            else
            {
                return false;
            }


        }



        public static bool checkforDEADEND(int col,int row,int[,]maze)
        {
            if (row + 1 < 5 && col + 1 < 5 && isWall(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (col - 1 >= 0 && col + 1 < 5 && maze[col - 1, row] == 0 && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (row + 1 < 5 && col - 1 >= 0 && maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && isVisited(col, row - 1) == true)
            {
                return true;
            }




            else if (row + 1 < 5 && row - 1 >= 0 && isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (row + 1 < 5 && col + 1 < 5 && isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (col + 1 < 5 && row - 1 >= 0 && isVisited(col - 1, row) == true && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }



            else if (col + 1 < 5 && row - 1 >= 0 && isWall(col - 1, row) == true && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (col - 1 >= 0 && col + 1 < 5 && maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (col - 1 >= 0 && row - 1 >= 0 && maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }



            else if (row + 1 < 5 && row - 1 >= 0 && isWall(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (col - 1 >= 0 && row + 1 < 5 && maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (col - 1 >= 0 && row + 1 < 5 && maze[col - 1, row] == 0 && isWall(col, row + 1) == true && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }







            else if (col - 1 >= 0 && maze[col - 1, row] == 0 && isWall(col, row + 1) == true && isWall(col + 1, row) == true && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (row + 1 < 5 && isWall(col - 1, row) == true && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (col + 1 < 5 && isWall(col - 1, row) == true && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }




            else if (col + 1 < 5 && isVisited(col - 1, row) == true && isWall(col, row + 1) == true && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (row - 1 >= 0 && isVisited(col - 1, row) == true && isWall(col, row + 1) == true && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (row + 1 < 5 && isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && isWall(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }



            else if (col - 1 >= 0 && maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && isWall(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (row - 1 >= 0 && isWall(col - 1, row) == true && isVisited(col, row + 1) == true && isWall(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (col + 1 < 5 && isWall(col - 1, row) == true && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && isWall(col, row - 1) == true)
            {
                return true;
            }



            else if (col - 1 >= 0 && maze[col - 1, row] == 0 && isWall(col, row + 1) == true && isVisited(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }
            else if (row - 1 >= 0 && isWall(col - 1, row) == true && isWall(col, row + 1) == true && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (row + 1 < 5 && isWall(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && isWall(col, row - 1) == true)
            {
                return true;
            }




            else
            {
                return false;
            }

        }

        public static bool stuck(int col,int row,int[,]maze)
        {
            if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }




            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }



            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }




            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }



            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }


            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }



            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }
            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }



            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }
            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }




            else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
            {
                return true;
            }



            else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
            {
                return true;
            }



            else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }




            else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true )
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
            {
                return true;
            }
            else if (isVisited(col - 1, row) == true && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
            {
                return true;
            }



            else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == false && isDead(col + 1, row) == false && maze[col + 1, row] == 1 && isWall(col, row - 1) == true)
            {
                return false;
            }


            else
            {
                return false;
            }

        }

        public static int[] RCseperator(string popString)
        {
            string[] COlandROWseparater = new string[2];
            int[] COlandROWstorer = new int[2];

            int num2 = 0;
            string tempo = popString;
            int col=0, row=0;
            for (int i = 0; i < tempo.Length; i++)
            {
                if (tempo[i] != ',')
                {
                    COlandROWseparater[num2] += tempo[i];
                }
                else
                {
                    num2++;
                }
            }
            col = int.Parse(COlandROWseparater[0].ToString());
            row = int.Parse(COlandROWseparater[1].ToString());

            COlandROWstorer[0] = col;
            COlandROWstorer[1] = row;

            return COlandROWstorer;
        }

        //public static bool deadendANDvisitedANDwall(int col, int row)
        //{





        //    if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }




        //    else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }



        //    else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isWall(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }
        //    else if (isWall(col - 1, row) == true && isDead(col - 1, row) == true && isVisited(col - 1, row) == true && isDead(col - 1, row) == true)
        //    {
        //        return true;
        //    }



        //    else
        //    {
        //        return false;
        //    }




        //}

        public static bool isWall(int col, int row)
        {
            if (col + 1 > 4)
            {
                return true;
            }
            else if (col - 1 < 0)
            {
                return true;
            }
            else if (row + 1 > 4)
            {
                return true;
            }
            else if (row - 1 < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool checkinbetweenDeadendandVisited(int col, int row, int[,] maze)
        //{




        //    if (isVisited(col - 1, row) == true && isDead(col, row + 1) == true && isDead(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isVisited(col, row + 1) == true && isDead(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isDead(col, row + 1) == true && isVisited(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isDead(col, row + 1) == true && isDead(col + 1, row) == true && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }


        //    else if (isDead(col - 1, row) == true && isVisited(col, row + 1) == true && isVisited(col + 1, row) == true && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col, row + 1) == true && isVisited(col + 1, row) == true && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isVisited(col, row + 1) == true && isDead(col + 1, row) == true && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isVisited(col, row + 1) == true && isVisited(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }


        //    else if (isVisited(col - 1, row) == true && isVisited(col, row + 1) == true && isDead(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col, row + 1) == true && isVisited(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col, row + 1) == true && isDead(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col, row + 1) == true && isDead(col + 1, row) == true && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && isDead(col, row + 1) == true && isVisited(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && isVisited(col, row + 1) == true && isDead(col + 1, row) == true && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }



        //    else
        //    {
        //        return false;
        //    }




        //}

        //public static bool checkinbetweentheVisited(int col, int row, int[,] maze)
        //{



        //    if (isVisited(col - 1, row) == true && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
        //    {
        //        return true;
        //    }
        //    else if (isVisited(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }



        //    else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && isVisited(col + 1, row) == true && maze[col, row - 1] == 0)
        //    {
        //        return true;
        //    }
        //    else if (maze[col - 1, row] == 0 && isVisited(col, row + 1) == true && maze[col + 1, row] == 0 && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }



        //    else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isVisited(col + 1, row) == true && isVisited(col, row - 1) == true)
        //    {
        //        return true;
        //    }

        //    else
        //    {
        //        return false;
        //    }
        //}

        //public static bool checkinbetweentheDead(int col, int row, int[,] maze)
        //{



        //    if (isDead(col - 1, row) == true && isDead(col, row + 1) == true && maze[col + 1, row] == 0 && maze[col, row - 1] == 0)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && maze[col, row + 1] == 0 && isDead(col + 1, row) == true && maze[col, row - 1] == 0)
        //    {
        //        return true;
        //    }
        //    else if (isDead(col - 1, row) == true && maze[col, row + 1] == 0 && maze[col + 1, row] == 0 && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }



        //    else if (maze[col - 1, row] == 0 && isDead(col, row + 1) == true && isDead(col + 1, row) == true && maze[col, row - 1] == 0)
        //    {
        //        return true;
        //    }
        //    else if (maze[col - 1, row] == 0 && isDead(col, row + 1) == true && maze[col + 1, row] == 0 && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }



        //    else if (maze[col - 1, row] == 0 && maze[col, row + 1] == 0 && isDead(col + 1, row) == true && isDead(col, row - 1) == true)
        //    {
        //        return true;
        //    }



        //    else
        //    {
        //        return false;
        //    }
        //}


        public static bool isDead(int col, int row)
        {
            string temp = null;
            temp = col.ToString() + "," + row.ToString();
            for (int i = 0; i < deadend.Length; i++)
            {
                if (deadend[i] != null)
                {
                    if (deadend[i] == temp)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool isVisited(int col, int row)
        {
            string temp = null;
            temp = col.ToString() + "," + row.ToString();
            for (int i = 0; i < visit.Length; i++)
            {
                if (visit[i] != null)
                {
                    if (visit[i] == temp)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        public static bool checkMazePaths(int col, int row, int[,] maze)
        {
            //if((( row+1>=0 && row+1<5 && col>=0 && col<5) && maze[col, row+1] != 1) && ((row - 1 >= 0 && row - 1 < 5 && col >= 0 && col < 5) && maze[col, row - 1] != 1) && ((col + 1 >= 0 && col + 1 < 5 && row >= 0 && row < 5) && maze[col+1, row] != 1) && ((col - 1 >= 0 && col - 1 < 5 && row >= 0 && row < 5) && maze[col-1, row] != 1))
            if ((col - 1 >= 0 && col - 1 < 5 && row >= 0 && row < 5 && maze[col - 1, row] != 1) && (row + 1 >= 0 && row + 1 < 5 && col >= 0 && col < 5 && maze[col, row + 1] != 1) && (col + 1 >= 0 && col + 1 < 5 && row >= 0 && row < 5 && maze[col + 1, row] != 1) && (row - 1 >= 0 && row - 1 < 5 && col >= 0 && col < 5 && maze[col, row - 1] != 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void pushintodeadend(int col, int row)
        {
            string temp1 = null;
            temp1 = col.ToString() + "," + row.ToString();
            top1++;
            deadend[top1] = temp1;
        }

        public static void push(int col, int row)
        {
            string temp = null;
            temp = col.ToString() + "," + row.ToString();
            top++;
            visit[top] = temp;
        }
        public static string pop()
        {
            string temp = null;
            temp = visit[top];
            top--;
            return temp;
        }
        public static string popfromdeadend()
        {
            string temp1 = null;
            temp1 = deadend[top1];
            top1--;
            return temp1;
        }
    }
}