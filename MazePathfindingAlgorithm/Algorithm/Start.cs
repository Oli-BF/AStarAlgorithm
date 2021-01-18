using System;
using System.IO;
using System.Linq;

namespace MazePathfindingAlgorithm.Algorithm
{
    /// <summary>
    /// @author Oliver Basey-Fisher
    /// 
    /// This class is the 'main' class in that it houses the main method for the project.
    /// If no command line arguments are given, it will prompt the user on what is 
    /// required and in what format. Otherwise, it will attempt to read the inputted 
    /// file and convert it into a List of type string. This List, called 'maze' is used
    /// as a parameter for the AStarSearch method within the 'AStarAlgorithm' class. The
    /// AStarSearch method will then return either the maze directions in NSEW format or
    /// an error message, the type of which will depend on the values within the maze 
    /// List.
    /// </summary>
    public class Start
    {
        // Main Method
        public static void Main(string[] args)
        {
            // Prompts the user if a command line argument is not passed.
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please pass a .txt file containing a valid Maze as a command line argument.\n\n" +
                                  "'X' = Wall/Obstacle\n" +
                                  "'.' = Empty Space/Valid Path\n" +
                                  "'A' = Start of the Maze\n" +
                                  "'B' = End of the Maze\n\n" +
                                  "Example Maze:\n" +
                                  "xxxxxxx\n" +
                                  "xA...Bx\n" +
                                  "xxxxxxx\n");
                return;
            }
            try
            {
                if (args.Length > 0)
                {
                    // Parse's a .txt file and creates a List<string> called 'maze' from the files contents.
                    var maze = File.ReadAllLines(args[0]).ToList();

                    // Prints the output of the AStarSearch Method.
                    Console.WriteLine("\n" + AStarAlgorithm.AStarSearch(maze) + "\n");
                }
            }
            catch
            {
                // The user will be made aware if the file cannot be found or the file type is not supported
                Console.WriteLine("\nCould not find the provided file, or the file type is not supported (.txt only).\n");
            }
        }
    }
}