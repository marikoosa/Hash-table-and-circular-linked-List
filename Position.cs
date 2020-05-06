using System;

{
    class Position
    {
        //Variable declaration for Position class.
        public float x, y, z;

        //Constructor for Position class that takes 3 arguments
        public Position(float x, float y, float z)

        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Constructor for position class that only takes one argument. 
        public Position(int maxsize)
        {
            Random random = new Random();
            this.x = random.Next(0, maxsize);
            this.y = random.Next(0, maxsize);
            this.z = 0;
        }

        // Gettters and Setters for Position class.
        public void SetX(float valX)
        {
            this.x = valX;
        }

        public float GetX()
        {
            return this.x;
        }

        public void SetY(float valY)
        {
            this.y = valY;
        }

        public float GetY()
        {
            return this.y;
        }

        public void SetZ(float valZ)
        {
            this.z = valZ;
        }

        public float GetZ()
        {
            return this.z;
        }
    }
}
