using System;
{
    public class CircularArray<T>
    {
        //Variable declaration 
        public T[] array;
        public int queueFront;
        public int queueRear;

        // Basic Constructor. Creates an array and initializes the front and rear
        // O(1) in time O (N) in size
        public CircularArray(int size)
        {
            array = new T[size + 1];//ask Sri
            queueFront = 0;
            queueRear = 0; 
        }

        //Checking if the circluar array is full
        public bool IsFull()
        {
            if (queueFront == (queueRear + 1) % array.Length)
            {
                return true;
            }
            else

            {
                return false;
            }

        }

        //Checking if the circular array is empty 
        public bool IsEmpty()
        {
            if (queueRear == queueFront)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // NYI fully.
        public void AddBack(T value)  //addBack is enqueue
        {
            //If the array is full we call grow method
            if (IsFull() == true)
            {
                Grow(array.Length * 2);
            }

            array[queueRear] = value;
            int index = queueRear;
            while (index != queueFront && (array[index] as MobileObject).CompareTo(array[index - 1]) > 0)
            {
                T temp = array[index];
                array[index] = array[index - 1];
                array[index - 1] = temp;
                index--;
            }
            queueRear = (queueRear + 1) % array.Length;
        }

        public T RemoveFront() 
        {
            //Checking if the queue is empty 
            if (IsEmpty() == true)
            {
                Console.WriteLine("The Queue is Empty");
                return default;
            }
            else

            {
                T temp = array[queueFront];
                array[queueFront] = default;
                queueFront = (queueFront + 1) % array.Length;
                return temp;
            }
        }


        // Just returns the front element O(1)
        public T GetFront()
        {
            if (IsEmpty() == true)
            {
                Console.WriteLine("The circular array is empty");
                return default;
            }
            else
            {
                return array[queueFront];
            }
        }
        // Same old Grow, bit hard to know where to use it if at all though...
        // O(N)
        public void Grow(int newsize)
        {
            CircularArray<T> array2 = new CircularArray<T>(newsize);

            while (!IsEmpty())
            {
                array2.AddBack(this.RemoveFront());

            }

            array = array2.array;
            queueFront = array2.queueFront;
            queueRear = array2.queueRear;
        }

    }


}
