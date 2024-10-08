using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Match3
{
    public class Grid
    {
        private int size = 3;
        private int values = 3;

        private int[,] grid = new int[0,0];
        private int[,] matches = new int[0,0];

        Random rand = new Random();

        public void ParseCommand(string cmd)
        {
            string[] parts = cmd.Split(':');
            if (parts.Length < 2) return;

            string key = parts[0];
            string value = parts[1];
            
            int s = 3;
            int v = 3;

            switch (key)
            {
                case "s":

                    int.TryParse(value, out s);
                    SetSize(s);
                    
                    break;
                case "v":

                    int.TryParse(value, out v); 
                    SetUniqueValueCount(v);

                    break;
            }
        }

        public void Build()
        {
            grid = new int[size,size];
            matches = new int[size,size];

            Refill();            
        }

        public void CheckGridMatches(out bool found)
        {
            found = false;

            for (int row = 0; row < size; row++)
            {
                //for every cell
                for (int col = 0; col < size; col++)
                {
                    //check for 3 in a row left/right up/down
                    int val = grid[row,col];
                    int horizontalStreak = 1;
                    int verticalStreak = 1;

                    //check left
                    for (int _col = col-1; _col >= 0; _col--)
                    {
                        if (grid[row, _col] != val) break;
                        horizontalStreak++;
                    }

                    //check right
                    for (int _col = col + 1; _col < size; _col++)
                    {
                        if (grid[row, _col] != val) break;
                        horizontalStreak++;
                    }

                    //mark horizontal matches
                    if(horizontalStreak >= 3)
                    {
                        matches[row, col] = 1;

                        //mark left
                        for (int _col = col - 1; _col >= 0; _col--)
                        {
                            if (grid[row, _col] != val) break;
                            matches[row, _col] = 1;
                        }

                        //mark right
                        for (int _col = col + 1; _col < size; _col++)
                        {
                            if (grid[row, _col] != val) break;
                            matches[row, _col] = 1;
                        }

                        found = true;
                    }

                    //check up
                    for (int _row= row - 1; _row >= 0; _row--)
                    {
                        if (grid[_row, col] != val) break;
                        verticalStreak++;
                    }

                    //check right
                    for (int _row = row + 1; _row < size; _row++)
                    {
                        if (grid[_row, col] != val) break;
                        verticalStreak++;
                    }

                    //mark horizontal matches
                    if (verticalStreak >= 3)
                    {
                        matches[row, col] = 1;

                        //mark up
                        for (int _row = row - 1; _row >= 0; _row--)
                        {
                            if (grid[_row, col] != val) break;
                            matches[_row, col] = 1;
                        }

                        //mark down
                        for (int _row = row + 1; _row < size; _row++)
                        {
                            if (grid[_row, col] != val) break;
                            matches[_row, col] = 1;
                        }

                        found = true;
                    }

                }
            }
        }

        public void ProcessMatches()
        {
            //go column by colum and removed matches, drop remaining, fill column
            for (int col = 0; col < size; col++)
            {
                int nProcessed = 0;

                for (int row = 0; row < size; row++)
                {
                    if (matches[row, col] == 1)
                    {
                        matches[row, col] = 0;
                        grid[row, col] = -1;
                        nProcessed++;
                    }
                }                
            }

            
        }

        //TODO
        //CheckCellMatches Function

        void CheckForMatchesHelper(int row, int column, int val, int xDir, int yDir)
        {

        }

        void DropColumn(int col) 
        {
                    
        }

        public void Fill()
        {

        }

        void FillColumn(int col, int amt)
        {

        }

        public void Refill()
        {
            for(int row = 0; row < size; row++)
            {
                for(int col = 0; col < size; col++)
                {
                    grid[row, col] = GetRandomValue();
                }
            }
        }

        public void Display()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(grid[row, col]);
                }

                Console.Write('\n');
            }
        }

        private int GetRandomValue()
        {
            return rand.Next(values);
        }

        private void SetSize(int n)
        {
            size = n;
        }

        private void SetUniqueValueCount(int n)
        {
            values = n;
        }
    }
}
