namespace MazePathfindingAlgorithm.Algorithm
{
    /// <summary>
    /// @author Oliver Basey-Fisher
    /// 
    /// This class represents a Node object. It contains field variables
    /// called X and Y, which represent the coordinates on the grid. 
    /// It also contains variables for the fCost (the sum of gCost and
    /// hCost), gCost and hCost, all of which are used to store 
    /// calculated values, which enables a hierarchy of nodes. It also
    /// contains a field variable of type Node called parent, so each
    /// Node can set a parent node. These variables will be discussed 
    /// in more detail in the 'AStarAlgorithm' class.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Initialise variables.
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }
        public int fCost { get; set; }
        public int gCost { get; set; }
        public int hCost { get; set; }
        public Node parent { get; set; }
    }
}