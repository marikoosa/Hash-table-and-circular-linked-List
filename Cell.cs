using System;
using System.Collections;
using System.Collections.Generic;

{
    class Cell

    {   //Declaring variables for Cell class
        public int CellId;
        public float Dimension = 10.0F;
        public int[] Position = new int[2]; //Initializing Position array with 2 elements (x,y)
        public ArrayList objs = new ArrayList();
        public bool visited = false;

        //A constructor for the Cell class
        public Cell(int Id, int x, int y)
        {
            this.CellId = Id;
            this.Position[0] = x;
            this.Position[1] = y;
        }

        // Get and Set accessors for CellId variable
        public void SetCellId(int IdVal)
        {
            this.CellId = IdVal;
        }

        public int GetCellId()
        {
            return this.CellId;
        }

        //Get accessor for position array
        public int[] GetCellPosition()
        {
            return Position;
        }

        // addObj method adds an object to a cell. Is used by Move() method
        public void addObj(MobileObject obj)
       
        {
            objs.Add(obj);
            objs.Sort();
        }

        //// removeObj method removes an object from a cell. Is used by Move() method
        public void removeObj(MobileObject obj)
        {
            // remove desired element from temp list
            objs.Remove(obj);
        }
        public object GetObj()
        {
            if (objs.Count > 0)
            {
                return objs[0];
            }
            else
            
            {
                return default;
            }

        }
    }
}
