using System;
using System.Linq;
namespace Conway
{
    public class Game
    {
        int[,] cells;

        public Game(int size)
        {
            cells = new int[size,size];
        }

        public void run()
        {
            init();
            Console.Write("init" + Environment.NewLine);
            printCells();
            Console.Write("update" + Environment.NewLine);
            bool flag = true;
            while(flag)
            {
                flag = update();
            }

            Console.ReadLine();
        }

        private void init()
        {
            cells[0, 0] = 1;
            cells[0, 1] = 1;
            cells[1, 0] = 1;
        }

        private bool update()
        {
            int size = cells.GetLength(0);
            int[,] temp = (int[,])cells.Clone();

            int liveNeighbors;
            for(int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    liveNeighbors = checkNeighbors(row, column);
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                        temp[row, column] = 0;
                    else if (liveNeighbors == 3)
                        temp[row, column] = 1;
                }
            }

            String cellString = "";
            foreach (var s in cells.Cast<int>())
                cellString = cellString + s;

            String tempString = "";
            foreach (var s in temp.Cast<int>())
                tempString = tempString + s;

            if (string.Compare(cellString, tempString) == 0)
                return false;

            cells = temp;
            printCells();
            return true;
        }

        private int checkNeighbors(int r, int c)
        {
            int length = cells.GetLength(0);
            int counter = 0;
            int row;
            int column;
            for (int i = -1; i < 2; i++)
            {
                row = r + i;
                for (int j = -1; j < 2; j++)
                {
                    column = c + j;
                    //Console.Write(row + " " + column);// + Environment.NewLine);

                    if (row < 0 || column < 0 || (i == 0 && j == 0) || row > length - 1 || column > length - 1)
                    {
                        //do nothing, skip
                    }
                    else
                    {
                        //Console.Write(Environment.NewLine);
                        counter = counter + cells[row, column];
                    }
                }
            }

            return counter;
        }

        private void printCells()
        {
            int size = cells.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(string.Format("{0} ", cells[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
