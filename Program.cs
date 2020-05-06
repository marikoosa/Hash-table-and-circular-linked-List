using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

{
    class Program
    {
        static void Main(string[] args)
        {
            /* Questions can be called separately
             Options are Q4, Q5, Q6*/

            Q6();
            //Q4();
            //Q5();  
        }

        //Comparing performance of a circular linked list and circular array 
        static void Q4() 
        {
            void mainloop(object circ)
            {
                void addElement(MobileObject t)
                {
                    // if the dataype is circular array, enqueue otherwise addback
                    if (circ is DLinkedList)
                        (circ as DLinkedList).enqueue(t);
                    else if (circ is CircularArray<MobileObject>)
                        (circ as CircularArray<MobileObject>).AddBack(t);
                }
                Random random = new Random();

                MobileObject temp;

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {

                        if (i == 0)
                        {

                            /*adding mobile objects to a linked list and
                               determinig the the value range of cat attributes*/
     
                            temp = new Cat("CatName",
                                           j + i * 25,
                                           new Position(100),
                                           /*To make Cat attribute values a float I used (float)
                                              keyword, devided the values by 2 and added a floating point number.*/
                                           (float)((random.NextDouble() / 2) + 0.5), //Leglength
                                           (float)((random.NextDouble() / 2) + 0.5), //Torsoheight
                                           (float)((random.NextDouble() / 2) + 0.5),//HeadLength
                                           (float)((random.NextDouble() / 2) + 0.5),//Taillength
                                           (float)((random.NextDouble() / 2) + 0.5));//Mass
                        }

                        else

                        { /*adding mobile objects to a linked list and
                                determinig the the value range of snake attributes*/
                          //Console.WriteLine("Adding Snake");
                            temp = new Snake("SnakeName",
                                             j + i * 25,
                                             new Position(100),
                                             /*To make length and radius values a float I used (float)
                                                keyword, devided the values by 2 and added a floating point number.*/
                                             (float)((random.NextDouble() / 2) + 0.5), //Length
                                             (float)((random.NextDouble() / 10) + 0.05), //Radius
                                             (float)((random.NextDouble() * 100) + 1),//Mass in kg
                                             random.Next(200, 301));//Vertabrae
                        }
                        // dynamic add element depending on inputted datatype
                        addElement(temp);
                    }
                }
            }

            Stopwatch stopWatch;

            // initialize arrays holding loop information
            string[] types = new string[] { "CircularLinkedList", "CircularArray" };
            int[] times = new int[] { 1, 5, 10 }; //for 1, 5, and 10 seconds

            // Run loop once for each datatype
            foreach (string type in types)
            {
                Console.WriteLine("Testing: {0}", type);
                // Run loop for each of the 3 times (1, 5, 10 seconds)
                foreach (int time in times)
                {
                    // Start new stopWatch
                    stopWatch = Stopwatch.StartNew();

                    // Initialize loop counter
                    int count = 0;

                    // Loop while stopwatch is less than time (in milliseconds for accuracy)
                    while (stopWatch.ElapsedMilliseconds < time * 1000)
                    {
                        if (type == "CircularLinkedList")
                            mainloop(new DLinkedList());
                        else if (type == "CircularArray")
                            mainloop(new CircularArray<MobileObject>(50));

                        count++;
                    }
                    Console.WriteLine("Time: {0}s\t|   Loop(s): {1}", time, count);
                }
                Console.WriteLine("");
            }
        }

        static void Q5()
        {
            Random random = new Random();
            // r.Next(start, end)
            Cell t;
            MobileObject m;
            int row = 0;
            int col = 0;
            int size;
            int count;
            Stack<Cell> s = new Stack<Cell>();
            Queue<Cell> q = new Queue<Cell>();
            string[] snakenames = File.ReadAllLines(@"Assignment 1 snakenames.txt");
            string[] objtypes = { "Stack", "Queue" };


            // 4x4
            for (int objtype = 0; objtype < 2; objtype++)
            { 

                Console.WriteLine(string.Format("Object Type: {0}", objtypes[objtype]));
                for (size = 4; size <= 8; size += 4)
                {
                    row = 0;
                    col = 0;
                    Console.WriteLine(string.Format("Grid size: {0}x{0}", size));
                    Console.WriteLine("=======================================");

                    //create grid of either 4x4 or 8x8
                    Grid grid = new Grid(size);

                    // randomly generate ((size/2) * size) mobile objects and put into grid
                    for (int i = 0; i < (size / 2) * size; i++)
                    {
                        grid.cells[random.Next(0, size), random.Next(0, size)].addObj(
                                new Snake(snakenames[random.Next(0, snakenames.Length)],
                                          i,
                                          new Position(100),
                                          /*To make length and radius values a float I used (float)
                                             keyword, devided the values by 2 and added a floating point number.*/
                                          (float)((random.NextDouble() / 2) + 0.5), //Length
                                          (float)((random.NextDouble() / 10) + 0.05), //Radius
                                          (float)((random.NextDouble() * 100) + 1),//Mass in kg
                                          random.Next(200, 301)));//Vertabrae

                    }

                    t = grid.cells[row, col];
                    if (objtype == 0) { s.Push(t); } // if obj type is Stack
                    else { q.Enqueue(t); } // if obj type is queue

                    if (objtype == 0) { t = s.Pop(); } // if obj type is Stack
                    else { t = q.Dequeue(); } // if obj type is queue

                    // mark the cell as visited, so that it can't be accessed again
                    t.visited = true;

                    Console.Write(string.Format("Cell Position: ({0},{1}) | ", row, col));
                    // if object in cell, print it
                    if (t.GetObj() != default)
                    {
                        m = (t.GetObj() as MobileObject);
                        Console.WriteLine(m.Print());
                    }

                    // loop through the possible directions (right, down, left, up)
                    // then pop/dequeue, print, and set current pos as pos of object
                    // that was just popped/dequeued
                    do
                    {
                        // check if right is in the grid
                        if (col + 1 < size)
                        {
                            t = grid.cells[row, col + 1];
                            if (!t.visited)
                            {
                                if (objtype == 0) { s.Push(t); } // if obj type is Stack
                                else { q.Enqueue(t); } // if obj type is queue
                                t.visited = true;
                            }
                        }
                        // check if down is in the grid
                        if (row + 1 < size)
                        {
                            t = grid.cells[row + 1, col];
                            if (!t.visited)
                            {
                                if (objtype == 0) { s.Push(t); } // if obj type is Stack
                                else { q.Enqueue(t); } // if obj type is queue
                                t.visited = true;
                            }
                        }
                        // check if left is in the Grid
                        if (col - 1 >= 0)
                        {
                            t = grid.cells[row, col - 1];
                            if (!t.visited)
                            {
                                if (objtype == 0) { s.Push(t); } // if obj type is Stack
                                else { q.Enqueue(t); } // if obj type is queue
                                t.visited = true;
                            }
                        }
                        // check if up is in the grid
                        if (row - 1 >= 0)
                        {
                            t = grid.cells[row - 1, col];
                            if (!t.visited)
                            {
                                if (objtype == 0) { s.Push(t); } // if obj type is Stack
                                else { q.Enqueue(t); } // if obj type is queue
                                t.visited = true;
                            }
                        }
                        // pop/dequeue, set the coordinates to the new coordinates
                        // of the popped/dequeued cell, then print the cell contents
                        // if there is any.
                        if (objtype == 0) { t = s.Pop(); } // if obj type is Stack
                        else { t = q.Dequeue(); } // if obj type is queue
                        row = t.Position[0];
                        col = t.Position[1];
                        Console.Write(string.Format("Cell Position: ({0},{1}) | ", row, col));
                        if (t.GetObj() != default)
                        {
                            m = (t.GetObj() as MobileObject);
                            Console.WriteLine(m.Print());
                        }
                        else
                        {
                            Console.WriteLine("No object found");
                        }
                        if (objtype == 0) { count = s.Count; } // if obj type is Stack
                        else { count = q.Count; } // if obj type is queue
                    } while (count > 0);
                    Console.WriteLine("\n\n");
                }
                Console.WriteLine("\n\n\n\n");
            }

        }
        static void Q6()
        {
            int Hash(string val)
            {
                return val.Length;
            }
            //Declare string array value
            string[] names = File.ReadAllLines(@"names.txt");

            // create instance of hashtable class
            HashTable hash = new HashTable();

            foreach (string name in names)

            {
                hash.quadraticHashInsert(Hash(name), name);
            }

            Console.WriteLine("String Values inputted: ");
            hash.print(); // Retrieve all records
            Console.WriteLine("===============================================================================");
            // For searching a string value
            Console.WriteLine("Enter one of the string values inputted : ");
            string a = Convert.ToString(Console.ReadLine());
            Console.WriteLine("===============================================================================");
            Console.WriteLine("String value data :");
            hash.findValue(Hash(a), a);
            Console.ReadLine();

        }
    }
}

