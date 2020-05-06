using System;
using System.Collections;
using System.Collections.Generic;

{
   class Grid

    {
        // Variable declaration for the Grid class
        public int size; //The grid will be Size by Size (ex 10x10)
        public const int cell_size = 10;
        public const int BAD_ID = -1;
        public Cell[,] cells; // creating 2D array of cells

        public Grid(int size = 16)
        {
            this.size = size;
            cells = new Cell[size, size];
            CreateGrid();
        }

        //GenerateID() method generates and returns cell id
        public int GenerateID(int x, int y)
        {
            return (x + y * size + 1000);
        }

        //CreateGrid() method creates grid using the 2 Dimensional array of cells.
        public void CreateGrid()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int Id = GenerateID(i, j);
                    int x = i;
                    int y = j;
                    cells[i, j] = new Cell(Id, x, y);
                }
            }
        }

        //Finds maximum value so cells stay within the grid
        public int GetMaxVal()
        {
            return (size * cell_size - 1);
        }

        public int GetCellID(Position position) // calling GetCellID method and passing position to it.

        {   // Negative numbers are not useful.
            if (position.x < 0 || position.y < 0)
            {
                return BAD_ID;
            }

            int max_val = GetMaxVal();

            // Numbers greater than max_val are not useful.
            if (position.x > max_val || position.y > max_val)
            {
                return BAD_ID;
            }
            int x = (int)position.x / cell_size;
            int y = (int)position.y / cell_size;

            return GenerateID(x, y);
        }

        //Method that prints the grid.
        public void Print(LinkedList<MobileObject> mobile)
        {
            Console.WriteLine("Grid:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[j, i].objs.Count > 0)
                    {
                        //Printing the cells that hold mobile objects.
                        Console.Write(String.Format("[{0,2}]\t", (cells[j, i].objs[0] as MobileObject).GetId()));
                    }
                    else
                     {   
                         //if the cell does not contain an object it print an empty cell [ ], no id"
                        Console.Write("[  ]\t");
                     }
                }
                 // Printing values 10 to 160 across X and Y "axis"
                 Console.WriteLine(cell_size * (i + 1));
            }

            for (int j = 0; j < size; j++)
              {
                Console.Write((j + 1) * cell_size + "\t");
              }
            Console.WriteLine("");

            //Printing which object is in which cell on the grid
            foreach (MobileObject mob in mobile)
             {
                Console.WriteLine(mob.GetName() + " is in cell with id: " + mob.GetPositionCell());
             }
        }
    }
}
