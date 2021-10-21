using System;
using System.Drawing;

namespace OymakGroupCase
{
    public class Rover
    {
        Point Location;
        int Route; //0: N, 90: E, 180: S, 270: W
        int Index;
        bool Turn;
        bool IsMoveCompleted;

        string[] Routes = { "N", "E", "S", "W" };

        public Rover(Point Loc, int R, int index, bool turn, bool isMoveCompleted)
        {
            Location = Loc;
            Route = R;
            Index = index;
            Turn = turn;
            IsMoveCompleted = isMoveCompleted;
        }

        public Point Get_Location
        {
            get { return Location; }
        }

        public int Get_Route
        {
            get { return Route; }
            set { Route = value; }
        }

        public int Get_Index
        {
            get { return Index; }
        }

        public bool Get_Turn
        {
            get { return Turn; }
            set { Turn = value; }
        }

        public bool Get_IsMoveCompleted
        {
            get { return IsMoveCompleted; }
            set { IsMoveCompleted = value; }
        }

        public void TurnLeft(Rover rover)
        {
            if (rover.Route == 0)
            {
                rover.Route = 270;
            }
            else if (rover.Route > 0)
            {
                rover.Route -= 90;
            }
        }

        public void TurnRight(Rover rover)
        {
            rover.Route = (rover.Route + 90) % 360;
        }

        public void Move(Rover rover)
        {
            double Cos = Math.Cos(rover.Route);
            double Sin = Math.Sin(rover.Route);

            rover.Location.X += Convert.ToInt16(Cos);
            rover.Location.Y += Convert.ToInt16(Sin);

            Console.WriteLine("New location and route for the rover with index " + (1 + rover.Index) + " is (" + rover.Location.X + ", " + rover.Location.Y + ", " + Routes[(rover.Route) / 90] + ")");

            if (rover.IsMoveCompleted == false)
            {
                rover.IsMoveCompleted = true;
            }
        }

        public void WaitForCommand(Rover rover)
        {
            rover.Turn = true;
            string Command;

            Console.Write("Rover with index " + (rover.Index + 1) + " is waiting for command to move: ");
            Command = Console.ReadLine();

            Console.WriteLine("For rover with index " + (rover.Index + 1) + ", moving from (" + rover.Location.X + ", " + rover.Location.Y + ", " + Routes[(rover.Route) / 90] + ") to the new location...");

            for (var c = 0; c < Command.Length; c++)
            {
                if (Command[c].ToString().ToLower() == "l")
                {
                    TurnLeft(rover);
                }
                if (Command[c].ToString().ToLower() == "r")
                {
                    TurnRight(rover);
                }
                if (Command[c].ToString().ToLower() == "m")
                {
                    Move(rover);
                }
            }
        }
    }
}
