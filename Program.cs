using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OymakGroupCase
{
    public class Program
    {
        static void Main(string[] args)
        {
            int Width;
            int Height;
            int LowerBound = 10;
            int UpperBound = 100;
            int Count;
            List<Rover> Rovers = new List<Rover>();

            Console.Write("Please enter a width value for the land: ");
            Width = Convert.ToInt16(Console.ReadLine()); //Values greater than 100 won't be allowed!

            if (Width > UpperBound)
            {
                Console.Write(Width + " is greater than " + UpperBound + ". So, please enter a width value for the land: ");
            }
            else if (Width < LowerBound)
            {
                Console.Write(Width + " is smaller than " + LowerBound + ". So, please enter a width value for the land: ");
            }
            else
            {
                Console.WriteLine("Please enter a height value for the land: ");
                Height = Convert.ToInt16(Console.ReadLine()); //Values greater than 100 won't be allowed!

                if (Height > UpperBound)
                {
                    Console.Write(Height + " is greater than " + UpperBound + ". So, please enter a width value for the land: ");
                }
                else if (Height < LowerBound)
                {
                    Console.Write(Height + " is smaller than " + LowerBound + ". So, please enter a width value for the land: ");
                }
                else
                {
                    Console.WriteLine("A new land with the width: " + Width + " and the height " + Height + " is being initialized...");
                    Land land = new Land(new Size(Width, Height));

                    Console.Write("Please enter a rover count for the land: ");
                    Count = Convert.ToInt32(Console.ReadLine()); //Values greater than the area of the land won't be allowed!

                    if (Count > Width * Height)
                    {
                        Console.Write(Count + " is a greater value than the area so is not allowed! Please try again: ");
                    }
                    else if (Count < 1)
                    {
                        Console.Write(Count + " values less than 1 are not allowed to initialize a new land! Please try again: ");
                    }
                    else
                    {
                        for (var c = 0; c < Count; c++)
                        {
                            int RandomX = new Random().Next(0, Width);
                            int RandomY = new Random().Next(0, Height);
                            int[] Routes = { 0, 90, 180, 270 };
                            int RandomRoute = new Random().Next(0, Routes.Length);
                            Rover R = new Rover(new Point(RandomX, RandomY), Routes[RandomRoute], c, false, false);
                            Rovers.Add(R);
                        }

                        if (land.Size != null)
                        {
                            Rover rover = new Rover(new Point(0, 0), 0, 0, false, false);

                            for (var r = 0; r < Rovers.Count; r++)
                            {
                                if (r == 0)
                                {
                                    rover.WaitForCommand(Rovers[r]);
                                }
                                else if (0 < r && r <= Rovers.Count - 1)
                                {
                                    if (Rovers[r - 1].Get_IsMoveCompleted == true && Rovers[r - 1].Get_Turn == true)
                                    {
                                        rover.WaitForCommand(Rovers[r]);
                                        Rovers[r - 1].Get_Turn = false;
                                    }
                                }
                            }
                            if (Rovers[Rovers.Count - 1].Get_IsMoveCompleted == true)
                            {
                                Rovers[Rovers.Count - 1].Get_IsMoveCompleted = false;
                                Rovers.ForEach(r => { 
                                    if(r.Get_Index != 0)
                                    {
                                        r.Get_Turn = false;
                                    }
                                });

                                Console.WriteLine("All the rovers have completed their roam on the Mars surface. Please press any key to exit.");
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }
        }
    }
}
