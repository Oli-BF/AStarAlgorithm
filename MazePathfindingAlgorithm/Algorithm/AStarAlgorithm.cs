using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace MazePathfindingAlgorithm.Algorithm
{
    /// <summary>
    /// @author Oliver Basey-Fisher
    ///
    /// This class contains the main functionality of the A* Algorithm. The details of
    /// each method will be discussed below.
    /// </summary>
    public class AStarAlgorithm
    {
        /// <summary>
        /// This is the key method and houses the key parts of the algorithm. Initially,
        /// checks are made to the maze parameter that has been inputted from the 'Start'
        /// class. These either fail and return the relevant error message or pass and 
        /// the process begins. The details of each part will be discussed in their 
        /// relevant sections.
        /// </summary>
        /// <param name="maze"> </param>
        /// <returns> 
        /// A string.
        /// If the maze parameter is valid, the maze directions. 
        /// If not, an error message, the type of which depends on the maze parameter.
        /// </returns>
        public static string AStarSearch(List<String> maze)
        {
            // Checks if maze is empty.
            if (maze.Count == 0)
            {
                return "\nThe maze provided is empty, please input a valid Maze.\n";
            }

            /* 
             * Nested foreach loops, the first converts each string (line) to a char 
             * array, allowing the second to go through each character and check if
             * the correct characters for this maze type are within (in this case; 
             * A, B, x and .). 
             */
            var isAInMaze = false;
            var isBInMaze = false;
            var isXInMaze = false;
            var isDotInMaze = false;
            foreach (var line in maze)
            {
                var ca = line.ToCharArray();
                foreach (var c in ca)
                {
                    if (c.Equals('A'))
                    {
                        isAInMaze = true;
                    }
                    if (c.Equals('B'))
                    {
                        isBInMaze = true;
                    }
                    if (c.Equals('x'))
                    {
                        isXInMaze = true;
                    }
                    if (c.Equals('.'))
                    {
                        isDotInMaze = true;
                    }
                }
            }

            // Checks if the maze is in invalid.
            if (isAInMaze == false | isBInMaze == false | isXInMaze == false | isDotInMaze == false)
            {
                return "\nThe maze provided is not valid, please input a valid Maze.\n";
            }

            /* 
             * Creates a new Node object called start and assigns it's Y value to
             * the index value of that which contains 'A' - the start point. This
             * process takes advantage of the C# LINQ framework (although the use
             * of LINQ is minimised as much possible for efficiency purposes). The 
             * X value is then assigned using the value of Y as a reference point. 
             */
            var start = new Node
            {
                Y = maze.FindIndex(s => s.Contains("A"))
            };
            start.X = maze[start.Y].IndexOf("A");

            // This process is identical to the above.
            var end = new Node
            {
                Y = maze.FindIndex(s => s.Contains("B"))
            };
            end.X = maze[end.Y].IndexOf("B");

            /* 
             * Here we create two queues, one called openPriorityQueue which is a
             * SimplePriorityQueue (this is a third-party data structure, designed 
             * for pathfinding use cases - the reference of which can be found in
             * the ReadMe) and is used for queuing the nodes that may be visited.
             * This queue has a priority level for each node enqueued and it is
             * this priority level which is used to dictate which nodes shall be
             * visited at any given time.
             * 
             * The second queue is called the ClosedQueue and it is a HashSet. This
             * queue is used to store all the previously visited nodes, and as 
             * such grows rapidly in size in relation to maze complexity. A HashSet
             * was therefore chosen for its performance, and from testing the 
             * difference between implementing it as a HashSet rather than a 
             * SimplePriorityQueue was around 2-3x faster.
             */
            var openPriorityQueue = new SimplePriorityQueue<Node>();
            var closedQueue = new HashSet<Node>();

            // Adds the start node to the openPriorityQueue.
            openPriorityQueue.Enqueue(start, 0);

            // Initialises an int called gCost.
            var gCost = 0;

            // The start of the main loop.
            while (openPriorityQueue.Count > 0)
            {
                /*
                 * This assigns the node current to the value of the node at the top
                 * of the queue, which should have the lowest fCost.
                 */
                var current = openPriorityQueue.First;

                /*
                 * If the final node has been reached, assign the string variable to
                 * the result of the PrintDirections method. This will contain the
                 * NSEW directions and then return them. 
                 */
                if (current.X == end.X && current.Y == end.Y)
                {
                    var mazeDirections = PrintDirections(current);
                    return mazeDirections;
                }

                // Adds the current node to the closed queue (visited).
                closedQueue.Add(current); 

                // Removes the head of the queue from the open queue.
                openPriorityQueue.Dequeue();

                /*
                 * If the destination is within the closed list, then the Path has
                 * been found, and the while loop is broken.
                 */
                //var endFound = false;
                foreach (var node in closedQueue)
                {
                    if ((node.X == end.X) && (node.Y == end.Y))
                    {
                        var mazeDirections = PrintDirections(current);
                        return mazeDirections;
                    }
                }

                /*
                 * Assign the HashSet neighbours to the value of the GetNeighbours
                 * method, which will contain 0-4 of the surrounding nodes.
                 */
                var neighbours = GetNeighbours(maze, current);

                // Increment the gCost.
                gCost = current.gCost + 1;

                /*
                 * A foreach loop is used to iterate through the neighbours to find 
                 * the best path moving forward.
                 */
                foreach (var neighbour in neighbours)
                {
                    // If the neighbour is already in the closed queue, it's ignored.
                    var neighbourInClosedQueue = false;
                    foreach (var node in closedQueue)
                    {
                        if ((node.X == neighbour.X) && (node.Y == neighbour.Y))
                        {
                            neighbourInClosedQueue = true;
                            break;
                        }
                    }
                    if (neighbourInClosedQueue == true)
                    {
                        continue;
                    }

                    /*
                     * If the neighbour is not within the open queue, then CalculateNodeCost
                     * is called, which generates the costs of the node. The parent of the
                     * neighbour is set as the current node being dealt with. Following this
                     * a foreach loop is used to sort through the nodes of the open queue and
                     * if the neighbour fCost is lower, then it's assigned a higher priority
                     * (lower priority number), if the fCost is equal, it remains at the same
                     * priority, and if the fCost is higher, it's assigned a lower priority
                     * (high priority number). The initial if statement uses LINQ, as it was
                     * the only appropriate way to check if a node within the open queue is
                     * equal to neighbour's X and Y value.
                     */
                    if (openPriorityQueue.FirstOrDefault(node => node.X == neighbour.X && node.Y == neighbour.Y) == null)
                    {
                        CalculateNodeCost(gCost, end, neighbour);

                        neighbour.parent = current;

                        openPriorityQueue.Enqueue(neighbour, 1);

                        foreach (var node in openPriorityQueue)
                        {
                            if (node.fCost < neighbour.fCost)
                            {
                                openPriorityQueue.UpdatePriority(node, 0);
                            }
                            else if (node.fCost > neighbour.fCost)
                            {
                                openPriorityQueue.UpdatePriority(node, 2);
                            }
                        }
                    }
                }
            }
            // If the maze cannot be solved, a message is returned saying so.
            return "\nThis maze cannot be escaped from...\n";
        }

        /// <summary>
        /// The method GetNeighbours creates a new HashSet called neighbours, and
        /// then assigns two variables mazeXLimit and mazeYLimit to the values of
        /// the maximum value of each axis of the maze. These values, along with
        /// '>= 0' are used to prevent a neighbour being added that is 
        /// outside the bounds of the maze. If passed though, a char variable is 
        /// assigned to the value of the current nodes axis +/- 1. This char 
        /// variable is used within an if statement to see if the value is either
        /// an '.' or 'B', if it is then the neighbour is added to the neighbours
        /// HashSet.
        /// 
        /// This process is separated into four different if statements which 
        /// represent the four possible neighbours to the NSEW.
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="current"></param>
        /// <returns> HashSet called neighbours, containing the 0-4 possible 
        /// neighbours to explore. </returns>
        public static HashSet<Node> GetNeighbours(List<string> maze, Node current)
        {
            var neighbours = new HashSet<Node>();

            // Maze X axis maximum limit.
            var mazeXLimit = maze.First().Length;

            // Maze Y axis maximum limit.
            var mazeYLimit = maze.Count;

            // Y - 1.
            if ((current.Y - 1 >= 0) && (current.Y - 1 < mazeYLimit))
            {
                var mazeCharYMinus = maze[current.Y - 1][current.X];
                if ((mazeCharYMinus == '.') || (mazeCharYMinus == 'B'))
                {
                    neighbours.Add(new Node { X = current.X, Y = current.Y - 1 }); 
                }
            }
            // Y + 1.
            if ((current.Y + 1 >= 0) && (current.Y - 1 < mazeYLimit))
            {
                var mazeCharYPlus = maze[current.Y + 1][current.X];
                if ((mazeCharYPlus == '.') || (mazeCharYPlus == 'B'))
                {
                    neighbours.Add(new Node { X = current.X, Y = current.Y + 1 }); 
                }
            }
            // X - 1.
            if ((current.X - 1 >= 0) && (current.Y - 1 < mazeXLimit))
            {
                var mazeCharXMinus = maze[current.Y][current.X - 1];
                if ((mazeCharXMinus == '.') || (mazeCharXMinus == 'B'))
                {
                    neighbours.Add(new Node { X = current.X - 1, Y = current.Y }); 
                }
            }
            // X + 1.
            if ((current.X + 1 >= 0) && (current.Y - 1 < mazeXLimit))
            {
                var mazeCharXPlus = maze[current.Y][current.X + 1];
                if ((mazeCharXPlus == '.') || (mazeCharXPlus == 'B'))
                {
                    neighbours.Add(new Node { X = current.X + 1, Y = current.Y }); 
                }
            }

            return neighbours;
        }

        /// <summary>
        /// This method is used to calculate the three costs of a neighbour node.
        /// The gCost is assigned the value of the correct gCost.
        /// The hCost is determined via the Manhattan Distance Heuristic (see method).
        /// The fCost is the sum of the gCost and the fCost.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="end"></param>
        /// <param name="neighbour"></param>
        public static void CalculateNodeCost(int gCost, Node end, Node neighbour)
        {
            neighbour.gCost = gCost;
            neighbour.hCost = ManhattanDistanceHeuristic(end, neighbour);
            neighbour.fCost = neighbour.gCost + neighbour.hCost;
        }

        /// <summary>
        /// As we need to calculate the distance between two data points in a grid 
        /// type path, the Manhattan Distance Heuristic has been chosen as it is 
        /// best heuristic for when movements are limited to only four directions,
        /// i.e. NSEW in this case.
        /// </summary>
        /// <param name="end"></param>
        /// <param name="neighbour"></param>
        public static int ManhattanDistanceHeuristic(Node end, Node neighbour)
        {
            return Math.Abs(end.X - neighbour.X) + Math.Abs(end.Y - neighbour.Y);
        }

        /// <summary>
        /// PrintDirections is used to return the maze directions using the NSEW
        /// format. When the final node has been found, this method is called 
        /// and it reverses through the current node until the current node 
        /// equals null, essentially tracing the shortest path from end to start.
        /// As the directions need to be from start to end, the north and south
        /// have swapped as well the east and west, and the List of type string 
        /// called mazeDirections is reversed before being returned as a string.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static string PrintDirections(Node current)
        {
            var currentX = current.X;
            var currentY = current.Y;
            List<string> mazeDirections = new List<string>();
            while (current != null)
            {
                if (current.X == currentX - 1)
                {
                    currentX--;
                    mazeDirections.Add("E");
                }
                if (current.X == currentX + 1)
                {
                    currentX++;
                    mazeDirections.Add("W");
                }
                if (current.Y == currentY - 1)
                {
                    currentY--;
                    mazeDirections.Add("S");
                }
                if (current.Y == currentY + 1)
                {
                    currentY++;
                    mazeDirections.Add("N");
                }
                current = current.parent;
            }
            mazeDirections.Reverse();
            string combindedString = string.Join("", mazeDirections);
            return "Maze Directions from Start(A) to End(B): " + combindedString;
        }
    }
}