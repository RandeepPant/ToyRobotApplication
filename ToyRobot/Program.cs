using System;
using ToyRobot;

class Program
{
    static string[] validParameters = { "PLACE", "MOVE", "LEFT", "RIGHT", "REPORT" }; // Valid commands
    static Robot robot = new Robot(); 
    const int tableSize = 5; // 5x5 table

    static void Main()
    {
        // display the available command 
        DisplayHelp();

        while (true)
        {
            Console.Write("Enter command: ");
            var userInput = Console.ReadLine();

            // Exit case
            if (userInput!.Equals("x", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            string[] extractParameters = userInput.Split(' ', 2);

            if (extractParameters.Length > 0)
            {
                string command = extractParameters[0].Trim().ToUpper();
                string parameters = extractParameters.Length > 1 ? extractParameters[1].Trim() : "";

                // Check if the first command is PLACE if the robot hasn't been placed yet
                if (!robot.IsPlaced && command != "PLACE")
                {
                    Console.WriteLine("The first command must be PLACE.");
                    continue; 
                }

                // Validate commands
                if (!ValidateCommand(command))
                {
                    Console.WriteLine("Invalid command.");
                }
                else
                {
                    ExecuteCommand(command, parameters);
                }
            }
            else
            {
                Console.WriteLine("Invalid command format.");
            }
        }
    }

    static void ExecuteCommand(string command, string parameters)
    {
        switch (command)
        {
            case "PLACE":
                robot.Place(parameters, tableSize);
                break;

            case "MOVE":
                robot.Move(tableSize);
                break;

            case "LEFT":
                robot.TurnLeft();
                break;

            case "RIGHT":
                robot.TurnRight();
                break;

            case "REPORT":
                robot.ReportPosition();
                break;

            default:
                Console.WriteLine($"{command} is not a recognized command.");
                break;
        }
    }

    static bool ValidateCommand(string command)
    {
        return Array.IndexOf(validParameters, command) != -1; // Check if command is valid
    }

    static void DisplayHelp()
    {
        Console.WriteLine("\nValid Commands:\n");
        Console.WriteLine("X            - Exit");
        Console.WriteLine("PLACE X,Y,F  - Place the Toy Robot on the table at position X,Y and facing direction F (NORTH, EAST, SOUTH, or WEST).");
        Console.WriteLine("MOVE         - Move the Toy Robot one unit forward in the direction it is currently facing.");
        Console.WriteLine("LEFT         - Rotate the Toy Robot 90 degrees left (anti-clockwise/counter-clockwise).");
        Console.WriteLine("RIGHT        - Rotate the Toy Robot 90 degrees right (clockwise).");
        Console.WriteLine("REPORT       - Announce the X,Y,F of the Toy Robot.\n");
    }
}


