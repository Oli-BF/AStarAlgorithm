# A Star Algorithm
---
## Assumptions
* Throughout my implementation I tried to use the most efficient means possible; to improve the performance of the algorithm. Although LINQ is used a couple of times, its use was not preferred, as although it can improve code readability, it is often at the sacrifice of performance. A SimplePriorityQueue (third party data structure - see references) was used for the Open Queue to improve performance and a HashSet was implemented for the Close Queue, which vastly improves the performance, especially when larger mazes are attempted.
---
## Algorithm Summary
* For full details please see code comments
1. Start Node and End Node are created.
2. Start Node's and End Node's X and Y values are assigned to the indexes which contain 'A' and 'B' respectively.
3. A Priority Queue called openPriorityQueue and a HashSet called closedQueue are created.
4. Start Node added to openPriorityQueue.
5. While openPriorityQueue is not empty {
6. Node current is assigned the value of the head of the openPriorityQueue.
7. If final node has been reached, call PrintDirections method: return string mazeDirections.
8. Add current Node to closedQueue.
9. Dequeue openPriorityQueue.
10. If final node is within closedQueue: return MazeDirections.
11. GetNeighbours of current node.
12. Increment the gCost.
13. foreach neighbour {
14. If the neighbour is already in the closedQueue: ignore.
15. If the neighbour is not in the openPriorityQueue { 
16. Calculate Node Costs, set parent to current Node, Enqueue neighbour.
17. foreach node in openPriorityQueue{ Increase priority if node.fCost < neighbour.fCost / Decrease priority if node.fCost > neighbour.fCost.
---
## Testing
* There are 8 tests split up into two groups; Incorrect Mazes and Custom Mazes. The incorrect mazes group tests to make sure the correct message is shown when the inputted maze is incorrect in some form. The custom mazes group tests three mazes of increasing size that I randomly generated. Once again, the tests check to see if the correct NSEW directions are given. The increased size of the custom mazes allowed me to see whether my algorithm could still find the correct path through much more complex mazes as well as if it could complete it in a reasonable time.
---
## How to Run and Test
* Clone 'AStarAlgorithm' into preferred location.
* Open terminal within the 'MazePathfindingAlgorithm' folder.
* Run the command 'dotnet run' followed by the location of the .txt maze file you would like to run i.e. 'dotnet run Mazes/custom_maze_1.txt'.
* Testing: Open terminal within the 'MazePathfindingAlgorithmTests' folder and run 'dotnet test'.
* If you wish to create your own mazes, please look at how the provided mazes are set out.
---
## References
* Data Structure Library - https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp
* https://en.wikipedia.org/wiki/A*_search_algorithm
* https://dotnetcoretutorials.com/2020/07/25/a-search-pathfinding-algorithm-in-c/
* https://gigi.nullneuron.net/gigilabs/a-pathfinding-example-in-c/
* https://web.archive.org/web/20120622023747/http://blogs.msdn.com/b/ericlippert/archive/2007/10/02/path-finding-using-a-in-c-3-0.aspx
