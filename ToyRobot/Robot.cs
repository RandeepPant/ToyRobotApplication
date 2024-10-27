using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Robot
    {
        public int X { get; private set; } = -1; // Initial X position
        public int Y { get; private set; } = -1; // Initial Y position
        public string Direction { get; private set; } = ""; // Initial direction
        public bool IsPlaced => X != -1 && Y != -1; // Check if the robot is placed

        public void Place(string parameters, int tableSize)
        {
            //since PLACE would follow with X,Y,F the parameter should be 3
            var parts = parameters.Split(",");

            if (parts.Length == 3 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
            {
                string direction = parts[2].Trim().ToUpper();

                if (x >= 0 && x < tableSize && y >= 0 && y < tableSize && IsValidDirection(direction))
                {
                    X = x;
                    Y = y;
                    Direction = direction;
                }
                else
                {
                    Console.WriteLine("Invalid placement. Ensure X and Y are within the table bounds and direction is valid.");
                }
            }
            else
            {
                Console.WriteLine("Invalid PLACE command format. Use: PLACE X,Y,F");
            }
        }

        public void Move(int tableSize)
        {
            if (!IsPlaced)
            {
                Console.WriteLine("Robot not placed on the table. Use PLACE command first.");
                return;
            }

            (int newX, int newY) = GetNewPosition();
            if (newX >= 0 && newX < tableSize && newY >= 0 && newY < tableSize)
            {
                X = newX;
                Y = newY;   
            }
            else
            {
                Console.WriteLine("Move ignored. Robot cannot move outside the table.");
            }
        }

        private (int, int) GetNewPosition()
        {
            return Direction switch
            {
                "NORTH" => (X, Y + 1),
                "EAST" => (X + 1, Y),
                "SOUTH" => (X, Y - 1),
                "WEST" => (X - 1, Y),
                _ => (X, Y) 
            };
        }

        public void TurnLeft()
        {
            if (!IsPlaced)
            {
                Console.WriteLine("Robot not placed on the table. Use PLACE command first.");
                return;
            }

            Direction = Direction switch
            {
                "NORTH" => "WEST",
                "WEST" => "SOUTH",
                "SOUTH" => "EAST",
                "EAST" => "NORTH",
                _ => Direction
            };
        }

        public void TurnRight()
        {
            if (!IsPlaced)
            {
                Console.WriteLine("Robot not placed on the table. Use PLACE command first.");
                return;
            }

            Direction = Direction switch
            {
                "NORTH" => "EAST",
                "EAST" => "SOUTH",
                "SOUTH" => "WEST",
                "WEST" => "NORTH",
                _ => Direction
            };
        }

        public void ReportPosition()
        {
            if (!IsPlaced)
            {
                Console.WriteLine("Robot not placed on the table.");
            }
            else
            {
                Console.WriteLine($"Robot is at {X},{Y} facing {Direction}.");
            }
        }

        private bool IsValidDirection(string direction)
        {
            return direction == "NORTH" || direction == "EAST" || direction == "SOUTH" || direction == "WEST";
        }
    }
}
