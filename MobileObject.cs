using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

{
    abstract class MobileObject : IComparable
    
    {   //Variable Declaration
        public string Name;
        public int Id;
        public Position Pos;
        public int PositionCell;

        //abstract setters and getters
        public abstract void SetName(string desiredname);
        public abstract string GetName();
        public abstract void SetId(int desiredid);
        public abstract int GetId();

        //The rest of the abstract methods 
        public abstract void Move(float dx, float dy, float dz);
        public abstract void SetPositionCell(int DesiredPositionCell);
        public abstract int GetPositionCell();
        public abstract int CompareTo(object obj);
        public abstract string Print();
    }

    //Inherits from MobileObject
    class Cat : MobileObject
    {
        
        public float LegLength;
        public float TorsoLength;
        public float HeadHeight;
        public float TailLength;
        public float Mass;

        //Constructor
        public Cat(string Name, int Id, Position Pos, float legLength, float torsoLength, float headHeight, float tailLength, float mass)

        {
            this.Name = Name;
            this.Id = Id;
            this.Pos = Pos;
            this.LegLength = legLength;
            this.TorsoLength = torsoLength;
            this.HeadHeight = headHeight;
            this.TailLength = tailLength;
            this.Mass = mass;
        }

        //__________Setters and getters________________


        public override void SetName(string desiredname)
        {
            Name = desiredname;
        }

        public override string GetName()
        {
            return Name;
        }

        public override void SetId(int desiredid)
        {
            Id = desiredid;
        }

        public override int GetId()
        {
            return Id;
        }

        public float getLegLength()
        {
            return LegLength;
        }
        //Setting the value to be greater than 0
        public void setLegLength(float value)
        {
            if (value > 0) LegLength = value;
        }

        public float getTorsoLength()
        {
            return TorsoLength;
        }
        //Setting the value to be greater than 0

        public void setTorsoLength(float value)
        {
            if (value > 0) TorsoLength = value;
        }

        public float getHeadHeight()
        {
            return HeadHeight;
        }

        //Setting the value to be greater than 0
        public void setHeadHeight(float value)
        {
            if (value > 0) HeadHeight = value;
        }

        public float getTailLength()
        {
            return TailLength;
        }

        //Setting the value to be greater than 0
        public void setTailLength(float value)
        {
            if (value > 0) TailLength = value;
        }

        public float getMass()
        {
            return Mass;
        }

        //Setting the value to be greater than 0
        public void setMass(float value)
        {
            if (value > 0) Mass = value;
        }

        /* Move() method is called by MoveObject(). MoveObject() asks the user
            which object they want to move and to which cell. Move() moves the object.*/

        public override void Move(float dx, float dy, float dz)
        {
            Pos.SetX(dx + Pos.GetX());
            Pos.SetY(dy + Pos.GetY());
            Pos.SetZ(dz + Pos.GetZ());
        }

        public override void SetPositionCell(int DesiredPositionCell)
        {
            this.PositionCell = DesiredPositionCell;
        }

        public override int GetPositionCell()
        {
            return PositionCell;
        }

        public override int CompareTo(object obj)
        {
            if (obj is MobileObject)
            {

                float selfdist = (float)Math.Sqrt(
                    Math.Pow(this.Pos.GetX(), 2) +
                    Math.Pow(this.Pos.GetY(), 2) +
                    Math.Pow(this.Pos.GetZ(), 2));

                float objdist = (float)Math.Sqrt(
                    Math.Pow((obj as MobileObject).Pos.GetX(), 2) +
                    Math.Pow((obj as MobileObject).Pos.GetY(), 2) +
                    Math.Pow((obj as MobileObject).Pos.GetZ(), 2));

                return Convert.ToInt32(selfdist >= objdist);

            }

            throw new ArgumentException("Object is not a MobileObject");
        }

        //Calculates total length
        //Returns an integer

        private float TotalLength()
        {
            return LegLength + TorsoLength + HeadHeight;
        }

        public override string Print()
        {
            return "Name: " + Name + " ID: " + Id + " Positions: " + Pos.GetX() + " "
                   + Pos.GetY() + " " + Pos.GetZ() + " Leg length: " + LegLength +
                   " Torso Height: " + TorsoLength + " Head Height: " + HeadHeight +
                   " Tail Length " + TailLength + " Mass " + Mass + " Total Height: " + TotalLength();
        }
    }

    //Inherites from MobileObject
    class Snake : MobileObject
    {
        //public  string Name;
        //public int Id;
        //public Position Pos;
        //public int PositionCell;
        float Length;
        float Radius;
        float Mass;
        int Vertebrae;

        //Constructors
        public Snake(string Name, int Id, Position Pos, float length, float radius, float mass, int vertebrae)

        {
            this.Name = Name;
            this.Id = Id;
            this.Pos = Pos;
            this.Length = length;
            this.Radius = radius;
            this.Mass = mass;
            this.Vertebrae = vertebrae;
          
        }

        public override void SetName(string desiredname)
        {
            Name = desiredname;
        }

        public override string GetName()
        {
            return Name;
        }

        public override void SetId(int desiredid)
        {
            Id = desiredid;
        }

        public override int GetId()
        {
            return Id;
        }

        public float getLength()
        {
            return Length;
        }

        //Setting the value to be greater than 0
        public void setLength(float value)
        {
            if (value > 0) Length = value;
        }

        public float getRadius()
        {
            return Radius;
        }

        //Setting the value to be greater than 0
        public void setRadius(float value)
        {
            if (value > 0) Radius = value;
        }

        public int getVertebrae()
        {
            return Vertebrae;
        }

        //Setting the range of the value
        public void setVertebrae(int value)

        {
            if (value >= 200 && value <= 300) Vertebrae = value;
        }

        public float getMass()
        {
            return Mass;
        }

        //Setting the value to be greater than 0
        public void setMass(float value)
        {
            if (value > 0) Mass = value;
        }

        public override void Move(float dx, float dy, float dz)
        {
            Pos.SetX(dx + Pos.GetX());
            Pos.SetY(dy + Pos.GetY());
            Pos.SetZ(dz + Pos.GetZ());
        }

        public override void SetPositionCell(int DesiredPositionCell)
        {
            this.PositionCell = DesiredPositionCell;
        }

        public override int GetPositionCell()
        {
            return PositionCell;
        }

        public override int CompareTo(object obj)
        {
            if (obj is MobileObject)
            {

                float selfdist = (float)Math.Sqrt(
                    Math.Pow(this.Pos.GetX(), 2) +
                    Math.Pow(this.Pos.GetY(), 2) +
                    Math.Pow(this.Pos.GetZ(), 2));

                float objdist = (float)Math.Sqrt(
                    Math.Pow((obj as MobileObject).Pos.GetX(), 2) +
                    Math.Pow((obj as MobileObject).Pos.GetY(), 2) +
                    Math.Pow((obj as MobileObject).Pos.GetZ(), 2));

                return Convert.ToInt32(selfdist >= objdist);

            }

            throw new ArgumentException("Object is not a MobileObject");
        }

        //Calculates the Volume
        private float BoundingVolume()
        {
            return (float)(Length * Math.Pow(Radius, 2) * Math.PI);
        }
        public override string Print()
        {
            return "Name: " + Name
                   + " ID: " + Id + " Positions: " + Pos.GetX() + " " + Pos.GetY() + " " + Pos.GetZ()
                   + " Length: " + Length + " Height: " + Radius + " Width: " + Vertebrae
                   + " Volume: " + BoundingVolume();
        }
    }
}
