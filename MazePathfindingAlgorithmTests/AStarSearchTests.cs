using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MazePathfindingAlgorithm.Algorithm;

namespace MazePathfindingAlgorithmTests
{
    /// <summary>
    /// @author Oliver Basey-Fisher
    /// 
    /// This class contains all the tests for the 'MazePathFindingAlgorithm' project and focuses
    /// on the output of the 'AStarSearch' method. The tests are split up into two groups;
    /// Incorrect Mazes and Custom Mazes. The incorrect mazes group tests to make sure the 
    /// correct message is shown when the inputted maze is incorrect in some form. The custom 
    /// mazes group tests three mazes of increasing size that I randomly generated. Once again, 
    /// the tests check to see if the correct NSEW directions are given. The increased size of
    /// the custom mazes allowed me to see whether my algorithm could still find the correct 
    /// path through much more complex mazes as well as if it could do it in a reasonable time.
    /// 
    /// Note: Two extra custom mazes are included in the 'Mazes' folder within this project. 
    ///       They were used for my preliminary testing as well to see how efficient my 
    ///       algorithm was. Both of them are much larger than the largest custom maze I've
    ///       included in here. 
    /// </summary>
    [TestClass]
    public class AStarSearchTests
    {
        // Incorrect Mazes

        /// <summary>
        /// Tests to see that an empty maze is correctly handled, and that the relevant message
        /// is displayed.
        /// </summary>
        [TestMethod]
        public void EmptyMaze()
        {
            // Arrange
            var maze = new List<string>();
            var expected = "\nThe maze provided is empty, please input a valid Maze.\n";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests to see that an incorrect maze is correctly handled, and that the relevant 
        /// message is displayed.
        /// </summary>
        [TestMethod]
        public void IncorrectMaze()
        {
            // Arrange
            var maze = new List<string>() { "fffff",
                                            "x...x",
                                            "--A--" };
            var expected = "\nThe maze provided is not valid, please input a valid Maze.\n";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests to see that a maze with no starting point is correctly handled, and that 
        /// the relevant message is displayed.
        /// </summary>
        [TestMethod]
        public void NoStartPointMaze()
        {
            // Arrange
            var maze = new List<string>() { "xxxxxxx",
                                            "x....Bx",
                                            "xxxxxxx" };
            var expected = "\nThe maze provided is not valid, please input a valid Maze.\n";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests to see that a maze with no ending point is correctly handled, and that 
        /// the relevant message is displayed.
        /// </summary>
        [TestMethod]
        public void MazeNoEndPointMaze()
        {
            // Arrange
            var maze = new List<string>() { "xxxxxxx",
                                            "xA....x",
                                            "xxxxxxx" };
            var expected = "\nThe maze provided is not valid, please input a valid Maze.\n";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }

        /// Tests to see that a maze that is not solvable is correctly handled, and that 
        /// the relevant message is displayed.
        [TestMethod]
        public void ImpossibleMaze()
        {
            // Arrange
            var maze = new List<string>() { "xxxxxxx",
                                            "xA.x.Bx",
                                            "xxxxxxx" };
            var expected = "\nThis maze cannot be escaped from...\n";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }



        // Custom Mazes

        /// <summary>
        /// This test checks to see that the maze correctly handles the smallest custom 
        /// maze and displays the correct NSEW directions.
        /// </summary>
        [TestMethod]
        public void CustomMaze1()
        {
            // Arrange
            var maze = new List<string>() { "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                            "A.....x........x..............x",
                                            "x..x..x..xxxx..x..xxxxxxx..xxxx",
                                            "x..x..x.....x..x.....x........x",
                                            "x..x..xxxxxxx..xxxxxxx..xxxx..x",
                                            "x..x..x.....x..x.....x.....x..x",
                                            "x..x..x..x..x..x..x..xxxxxxx..x",
                                            "x..x..x..x..x.....x...........x",
                                            "x..x..x..x..x..xxxxxxxxxx..xxxx",
                                            "x..x..x..x.....x..............x",
                                            "x..x..x..xxxxxxxxxxxxxxxx..x..x",
                                            "x..x.....x........x..x.....x..x",
                                            "x..xxxxxxx..xxxx..x..x..xxxx..x",
                                            "x.....x.....x.....x.....x.....x",
                                            "xxxx..xxxx..xxxxxxxxxxxxx..x..x",
                                            "x..x.....x........x..x.....x..x",
                                            "x..xxxx..xxxxxxx..x..x..xxxx..x",
                                            "x..x.....x........x.....x.....x",
                                            "x..x..x..x..xxxxxxxxxxxxx..xxxx",
                                            "x.....x.................x.....B",
                                            "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" };
            var expected = "Maze Directions from Start(A) to End(B): EEEESSSSSSSSSSEEEENNNNNNEESSSSEEEENNEEENNEESSEEEEEESSEEESSSSSSSSWWSSEEEE";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test checks to see that the maze correctly handles the medium custom 
        /// maze and displays the correct NSEW directions.
        /// </summary>
        [TestMethod]
        public void CustomMaze2()
        {
            // Arrange
            var maze = new List<string>() { "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                            "A..x.....x.....x...........x........x..x.....x.....x...........x...........x",
                                            "x..x..x..x..x..x..xxxxxxx..x..xxxx..x..x..x..x..x..xxxxxxxxxx..x..xxxxxxx..x",
                                            "x.....x.....x..x........x..x.....x..x..x..x.....x...........x..x..x..x.....x",
                                            "xxxxxxx..xxxx..xxxxxxx..x..x..x..x..x..x..xxxxxxxxxx..xxxx..x..x..x..x..xxxx",
                                            "x...........x.....x.....x..x..x..x..x.....x........x.....x..x..x..x.....x..x",
                                            "x..xxxxxxxxxxxxxxxx..xxxx..xxxx..x..xxxxxxxxxx..x..xxxx..xxxx..x..xxxx..x..x",
                                            "x........x........x.....x........x........x.....x.....x..x.....x..x.....x..x",
                                            "xxxxxxx..x..xxxx..xxxx..x..xxxxxxx..xxxx..x..xxxxxxx..x..x..xxxx..x..xxxx..x",
                                            "x........x..x..x.....x..x..x.....x.....x..x.....x.....x........x..x..x.....x",
                                            "x..xxxxxxx..x..xxxx..x..x..x..xxxxxxx..xxxxxxx..x..xxxxxxxxxx..x..xxxx..xxxx",
                                            "x........x..x........x..x..x..x..............x..x.....x........x.....x..x..x",
                                            "x..xxxxxxx..xxxxxxxxxxxxx..x..x..xxxx..xxxx..xxxx..x..x..xxxxxxxxxx..x..x..x",
                                            "x...........x.....x.....x..x.....x..x..x..x..x.....x..x.....x........x.....x",
                                            "xxxxxxxxxx..xxxx..x..x..x..xxxxxxx..x..x..x..x..xxxx..x..x..x..xxxxxxx..xxxx",
                                            "x..x.....x........x..x..x..x.....x.....x..x.....x..x.....x.....x.....x..x..x",
                                            "x..x..x..xxxx..xxxx..x..x..x..x..x..x..x..xxxxxxx..xxxxxxxxxxxxx..x..x..x..x",
                                            "x.....x.....x..x..x..x.....x..x..x..x.....x.....x..x.....x.....x..x........x",
                                            "xxxx..x..xxxx..x..x..x..xxxx..x..xxxxxxxxxx..x..x..x..xxxx..x..x..xxxx..xxxx",
                                            "x.....x........x..x..x..x.....x..x...........x.....x.....x..x.....x..x.....x",
                                            "x..xxxxxxxxxxxxx..x..x..x..xxxx..x..xxxxxxxxxx..xxxx..x..x..xxxxxxx..xxxx..x",
                                            "x........x........x..x..x..x.....x..x.....x.....x..x..x..x........x........x",
                                            "xxxxxxx..x..x..xxxx..x..x..xxxxxxx..x..x..x..xxxx..x..x..xxxx..x..xxxxxxxxxx",
                                            "x.....x..x..x........x..x.....x.....x..x..x........x..x........x..x..x.....x",
                                            "x..x..x..x..xxxx..xxxx..xxxx..x..xxxx..xxxx..xxxx..x..xxxxxxxxxx..x..x..x..x",
                                            "x..x..x........x..x.....x.....x.....x..x........x..x.....x........x.....x..x",
                                            "x..xxxxxxx..x..xxxx..xxxx..xxxx..x..x..x..xxxxxxx..xxxx..x..xxxxxxxxxxxxx..x",
                                            "x........x..x..x.....x........x..x..x..x........x.....x..x..x.....x........x",
                                            "xxxxxxx..x..x..x..xxxxxxxxxx..x..x..x..xxxxxxx..xxxx..x..x..x..x..x..xxxx..x",
                                            "x.....x.....x..x..x...........x..x..x.....x.....x..x..x..x..x..x.....x.....x",
                                            "x..x..x..xxxx..x..x..xxxxxxxxxxxxx..xxxx..x..xxxx..x..x..x..xxxxxxxxxx..xxxx",
                                            "x..x..x..x.....x..x..x........x........x.....x.....x.....x.....x...........x",
                                            "xxxx..xxxx..xxxx..x..xxxxxxx..x..xxxxxxxxxxxxx..xxxxxxxxxx..x..xxxx..x..x..x",
                                            "x.....x.....x.....x..x.....x..x........x........x........x..x........x..x..x",
                                            "x..xxxx..xxxx..xxxx..x..x..x..xxxxxxx..x..xxxxxxx..xxxx..xxxxxxxxxxxxxxxx..x",
                                            "x..x..x..x...........x..x...........x..x..x...........x..x..............x..x",
                                            "x..x..x..xxxx..xxxxxxx..xxxxxxxxxxxxx..x..x..xxxxxxx..xxxx..xxxxxxxxxx..x..x",
                                            "x...........x.......................x.....x..x........x.....x..............x",
                                            "xxxxxxxxxx..xxxxxxxxxx..xxxxxxxxxx..x..xxxxxxx..xxxxxxx..xxxx..xxxxxxx..xxxx",
                                            "x...........x..............x........x..x........x.....x..x..x.....x.....x..x",
                                            "x..xxxx..xxxxxxx..xxxxxxx..x..xxxxxxx..xxxx..xxxx..x..x..x..xxxx..x..xxxx..x",
                                            "x.....x..x.....x..x.....x..x..x...........x..x.....x..x..x........x..x.....x",
                                            "xxxx..x..xxxx..x..x..x..x..x..x..xxxxxxx..x..xxxx..xxxx..x..xxxxxxx..x..xxxx",
                                            "x.....x........x..x..x..x..x........x.....x..............x..x...........x..x",
                                            "x..xxxxxxxxxxxxx..x..x..xxxxxxxxxx..x..xxxxxxxxxxxxxxxxxxxxxx..xxxx..xxxx..x",
                                            "x..x...........x.....x.....x........x..x.....x........x.....x..x.....x..x..x",
                                            "x..x..xxxxxxxxxxxxxxxxxxx..x..xxxxxxx..x..x..x..xxxx..x..x..x..x..xxxx..x..x",
                                            "x........x..x........x.....x........x..x..x..x.....x.....x..x..x..x.....x..x",
                                            "xxxxxxx..x..x..xxxxxxx..xxxxxxxxxx..x..xxxx..xxxx..xxxxxxx..x..x..xxxx..x..x",
                                            "x........x..............x...........x...........x........x.....x...........B",
                                            "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" };
            var expected = "Maze Directions from Start(A) to End(B): ESSEEEENNEESSSSWWWWWSSEEEEESSWWWWWSSSSEEEEEEEESSEEESSSSWWWWWNNNNWWWSSSSWWWSSEEEEESSSSEEEENNNNEESSEEEEEEENNNNNNNNNNEESSSSSSSSSSSSWWSSWWWSSSSSSWWWSSSSEEEEEEEEEEEEEEEEEEEESSWWWWWSSSSEEENNEEEEENNNNNNNNWWWWWNNEENNNNNNWWNNEEENNNNEEEEEEEEENNEESSSSWWSSEEEEESSSSEEESSSSEEENNNNNNWWNNNNNNEESSSSEEEEEEENNEESSSSWWWWWSSSSSSEESSEEEEEEENNEEEEESSSSSSWWSSWWWSSSSSSWWWSSSSEEEEEEEEEE";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test checks to see that the maze correctly handles the largest custom 
        /// maze and displays the correct NSEW directions.
        /// </summary>
        [TestMethod]
        public void CustomMaze3()
        {
            // Arrange
            var maze = new List<string>() { "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                            "A....................x.....x.................x.................x.....x........x........x..x.....x.....x...........x..x.....x...........x.....x........x",
                                            "x..xxxxxxxxxx..xxxx..x..x..xxxxxxxxxx..xxxx..xxxxxxx..xxxxxxx..x..x..xxxxxxx..x..xxxx..x..x..x..x..x..x..xxxxxxx..x..x..x..x..xxxx..x..x..x..x..xxxx..x",
                                            "x.....x........x.....x..x........x.....x..x...........x........x..x........x..x..x.....x.....x..x..x.....x..x.....x.....x.....x..x..x..x..x..x..x.....x",
                                            "xxxxxxx..xxxxxxx..xxxx..xxxxxxx..xxxxxxx..xxxxxxxxxxxxx..xxxxxxxxxxxxxxxx..x..x..x..xxxxxxxxxx..x..xxxxxxx..x..xxxx..xxxxxxx..x..x..x..x..x..x..x..xxxx",
                                            "x.....x..x.....x..x.....x.....x........x...........x....................x..x.....x..x........x..x........x.....x.....x........x.....x..x..x.....x.....x",
                                            "x..x..x..x..x..x..x..xxxx..xxxxxxxxxx..xxxxxxxxxx..x..x..xxxxxxxxxx..xxxx..x..xxxx..xxxxxxx..x..x..xxxxxxxxxxxxx..xxxx..xxxxxxxxxxxxx..x..xxxxxxx..xxxx",
                                            "x..x..x..x..x.....x.....x........x.....x.....x........x.....x..............x..x.....x...........x..x...........x..x..x..x.....x...........x.....x.....x",
                                            "x..x..x..xxxxxxxxxxxxx..xxxxxxx..x..xxxx..x..xxxx..xxxxxxx..x..xxxx..xxxxxxx..x..xxxx..xxxx..xxxx..x..xxxxxxx..x..x..x..xxxx..x..xxxxxxxxxx..x..xxxx..x",
                                            "x..x..x........x........x.....x...........x..x.....x.....x..x..x.....x.....x..x.....x..x.....x.....x.....x.....x..x..x.....x..x.....x........x.....x..x",
                                            "x..x..xxxxxxx..xxxxxxxxxxxxx..x..x..xxxxxxx..x..xxxxxxx..x..x..x..xxxx..x..x..xxxx..x..xxxxxxx..xxxxxxx..x..xxxx..x..xxxx..x..xxxx..xxxxxxxxxxxxx..xxxx",
                                            "x..x..x.....x........x........x..x..x........x..x..x.....x..x..x........x.....x.....x........x..x.....x..x........x........x.....x.....x........x.....x",
                                            "x..x..x..x..x..x..x..x..xxxxxxxxxx..x..xxxxxxx..x..x..x..x..x..xxxxxxxxxxxxxxxx..xxxx..xxxx..x..x..x..x..xxxxxxxxxxxxx..xxxxxxx..x..x..x..xxxx..xxxx..x",
                                            "x..x.....x.....x..x.....x.....x.....x..x.....x..x.....x.....x........x........x..x..x.....x.....x..x.....x...........x..x........x..x..x.....x........x",
                                            "x..xxxxxxxxxxxxx..xxxxxxx..x..x..xxxx..x..x..x..xxxxxxxxxxxxxxxxxxx..xxxxxxx..x..x..xxxxxxx..xxxx..xxxxxxx..xxxxxxx..x..x..xxxxxxxxxx..x..xxxxxxxxxxxxx",
                                            "x...........x.....x.....x..x..x.....x.....x.....x...........x.....x..x..............x........x..............x.....x..x.....x...........x..x........x..x",
                                            "xxxxxxxxxx..x..xxxxxxx..x..xxxxxxx..xxxxxxxxxxxxx..xxxxxxx..x..xxxx..x..xxxxxxxxxxxxx..x..x..x..xxxxxxxxxxxxx..x..x..xxxxxxx..xxxxxxxxxx..x..x..x..x..x",
                                            "x..x.....x..x........x.....x.....x.....x.....x..x..x.....x..x..x.....x.....x...........x..x.....x.....x.....x..x...........x..x...........x..x..x.....x",
                                            "x..x..xxxx..xxxxxxx..x..x..x..x..xxxx..x..x..x..x..xxxx..x..x..x..xxxxxxx..x..xxxxxxxxxx..xxxxxxx..x..xxxx..x..xxxxxxxxxx..x..xxxx..xxxxxxxxxx..xxxx..x",
                                            "x..x.....x.....x..x.....x.....x........x..x.....x.....x.....x.....x.....x........x.....x........x..x...........x..x........x.....x.....x........x.....x",
                                            "x..xxxx..x..x..x..xxxxxxxxxxxxxxxxxxxxxx..xxxx..xxxx..xxxx..xxxxxxx..x..xxxxxxx..x..x..xxxxxxx..x..xxxxxxx..x..x..x..xxxxxxxxxx..x..xxxx..xxxxxxxxxxxxx",
                                            "x..x..x..x..x..x........x...........x.....x.....x.....x.....x........x...........x..x..x........x..x.....x..x..x..x..x..x........x........x...........x",
                                            "x..x..x..x..x..x..xxxx..x..xxxxxxx..x..xxxx..xxxx..xxxx..x..x..xxxxxxxxxxxxxxxxxxx..xxxx..x..xxxx..xxxx..x..xxxx..x..x..x..x..xxxx..x..xxxx..xxxxxxx..x",
                                            "x..x..x.....x..x..x.....x........x.....x..x.....x.....x..x..x..x.....x...........x..x.....x..x.....x.....x.....x.....x.....x..x.....x.....x........x..x",
                                            "x..x..xxxxxxx..xxxx..xxxxxxx..xxxxxxxxxx..xxxx..xxxxxxx..xxxx..x..x..xxxxxxxxxx..x..x..x..x..x..xxxx..xxxxxxx..xxxxxxx..x..x..x..xxxxxxxxxxxxxxxxxxx..x",
                                            "x.....x.................x.....x.....x...........x.....x.....x..x..x.....x.....x..x.....x..x..x.....x..x.....x..x..x.....x..x.....x.....x.....x........x",
                                            "x..xxxx..x..xxxxxxxxxx..xxxx..x..x..xxxxxxxxxxxxx..x..xxxx..x..x..xxxx..x..xxxx..xxxxxxx..x..xxxx..x..xxxx..x..x..x..xxxx..xxxxxxxxxx..x..x..x..xxxx..x",
                                            "x........x..x.....x.....x.....x..x.....x.....x.....x.....x..x.....x..x..x..x.....x.....x..x.....x.....x.....x..x.....x.....x..x...........x.....x.....x",
                                            "xxxx..xxxx..x..x..x..xxxx..xxxx..xxxx..x..x..x..xxxxxxx..x..xxxxxxx..x..x..x..xxxxxxx..xxxxxxx..xxxxxxx..xxxx..x..xxxxxxx..x..x..xxxx..xxxxxxxxxxxxx..x",
                                            "x.....x.....x..x..x..x........x.....x..x..x..x.....x.....x........x..x........x........x.....x..x.....x........x.....x.....x..x..x.....x...........x..x",
                                            "x..xxxxxxxxxx..x..x..xxxx..x..xxxx..x..x..x..xxxxxxx..xxxxxxx..x..x..xxxx..xxxx..xxxxxxx..x..x..x..x..xxxxxxxxxxxxx..x..xxxx..x..x..xxxx..xxxxxxx..x..x",
                                            "x..x.....x.....x.....x.....x........x.....x........x..x........x..x..x.....x.....x........x..x..x..x.................x.....x..x..x........x........x..x",
                                            "x..xxxx..x..xxxxxxx..x..xxxxxxxxxxxxxxxxxxxxxxxxx..x..x..xxxxxxx..x..x..xxxx..xxxx..xxxxxxx..x..x..xxxxxxxxxxxxxxxxxxxxxx..x..x..xxxxxxxxxx..xxxxxxxxxx",
                                            "x.....x..x..x.....x..x..x.......................x........x.....x.....x..x.....x..x..x.....x.....x..x........x.....x...........x..x.....x.....x..x.....x",
                                            "xxxx..x..x..xxxx..x..x..x..xxxxxxxxxxxxxxxxxxx..xxxx..xxxx..x..xxxxxxx..x..xxxx..x..xxxx..xxxxxxx..x..xxxx..x..x..x..xxxxxxxxxx..x..x..x..x..x..x..x..x",
                                            "x.....x..x........x..x..x........x...........x..x.....x.....x........x..x..x.....x.....x..x.....x..x..x.....x..x..x..............x..x.....x..x.....x..x",
                                            "x..xxxx..xxxxxxxxxx..x..xxxxxxx..x..xxxxxxx..x..x..xxxx..xxxxxxxxxx..x..x..x..xxxxxxx..x..x..x..x..x..xxxxxxx..x..xxxxxxxxxxxxxxxx..xxxxxxx..xxxxxxx..x",
                                            "x........x........x..x..x........x..x........x.....x..x..x...........x..x..x.....x..x.....x..x..x..x..x........x..x..............x........x..x........x",
                                            "xxxx..x..x..xxxx..xxxx..x..x..x..xxxx..x..xxxxxxxxxx..x..xxxx..xxxxxxx..x..xxxx..x..xxxxxxx..xxxx..x..x..xxxxxxx..x..xxxxxxxxxx..x..xxxx..x..xxxxxxx..x",
                                            "x.....x..x.....x........x..x..x........x.....x.....x.....x.....x.....x..x..x..x..x.....x...........x..x..x.....x..x........x.....x..x.....x..x.....x..x",
                                            "xxxxxxx..xxxx..xxxxxxxxxx..x..xxxxxxxxxx..x..x..x..x..xxxx..xxxx..x..x..x..x..x..xxxx..xxxxxxxxxxxxx..x..x..x..x..xxxxxxxxxx..xxxxxxx..xxxxxxx..x..x..x",
                                            "x........x.....x........x..x..x.....x.....x.....x..x..x.....x.....x..x..x..x.....x..............x.....x..x..x.....x.....x.....x........x........x..x..x",
                                            "x..xxxxxxxxxx..x..x..x..x..x..xxxx..x..xxxxxxxxxx..x..xxxxxxx..xxxx..x..x..xxxx..x..xxxxxxxxxx..x..xxxx..x..xxxxxxx..x..x..xxxx..xxxxxxx..xxxx..x..x..x",
                                            "x...........x..x..x..x.....x........x..x.....x..x..x.....x..x.....x..x.....x.....x.....x.....x.....x.....x..x.....x..x..x.....x........x..x.....x..x..x",
                                            "xxxxxxxxxx..x..x..x..xxxxxxxxxxxxxxxx..xxxx..x..x..xxxx..x..xxxx..x..xxxxxxx..xxxxxxx..x..x..x..xxxxxxx..x..x..x..x..x..xxxx..xxxxxxx..x..x..x..x..x..x",
                                            "x........x..x..x..x..x...........x.....x.....x..x.....x..x.....x..x.....x..x...........x..x.....x.....x..x.....x..x..x.....x...........x..x..x..x..x..x",
                                            "xxxxxxx..x..x..x..x..x..xxxxxxx..x..xxxx..xxxx..xxxx..x..x..x..x..xxxx..x..xxxxxxxxxxxxx..x..xxxx..x..x..xxxxxxx..xxxxxxx..xxxxxxxxxxxxx..xxxx..x..x..x",
                                            "x...........x..x..x.....x........x..x..x.....x.....x.....x..x.....x.....x........x.....x..x..x.....x..x..x.....x...........x...........x..x.....x.....x",
                                            "x..xxxxxxxxxx..x..xxxxxxx..xxxxxxx..x..xxxx..xxxx..xxxxxxx..xxxxxxxxxx..x..xxxx..x..xxxx..x..x..xxxx..x..x..x..xxxxxxxxxxxxx..xxxxxxx..x..x..xxxxxxxxxx",
                                            "x.....x........x..x........x.....x.....x.....x........x...........x.....x..x........x.....x..x..x........x..x..x........x.....x.....x.....x..x........x",
                                            "xxxx..x..xxxxxxx..x..x..xxxx..x..x..xxxx..xxxx..x..x..x..xxxxxxx..x..x..x..x..xxxxxxx..xxxx..x..x..x..x..x..x..x..xxxx..x..x..x..x..xxxxxxx..x..xxxx..x",
                                            "x.....x.....x.....x..x..x.....x..x........x.....x..x.....x........x..x.....x..x........x..x.....x..x..x..x..x..x.....x..x..x..x..x..x..x.....x..x.....x",
                                            "x..xxxxxxx..x..xxxx..x..x..xxxx..x..xxxxxxx..xxxx..xxxxxxx..xxxxxxxxxxxxxxxx..x..xxxxxxx..xxxxxxx..x..xxxx..x..xxxxxxx..x..xxxx..x..x..x..xxxx..x..xxxx",
                                            "x.....x..x..x..x..x..x..x..x.....x.....x.....x.....x.....x..x........x..x.....x..x........x........x........x........x..x.....x..x.....x.....x..x.....x",
                                            "xxxx..x..x..x..x..x..x..x..xxxxxxxxxx..x..xxxxxxxxxx..x..x..xxxxxxx..x..x..xxxxxxx..x..x..x..xxxxxxx..xxxxxxxxxxxxx..x..xxxx..x..xxxx..xxxx..x..xxxx..x",
                                            "x.....x..x..x..x..x..x..x.....x.....x.....x...........x..x..x........x..x..x........x..x...........x..x..............x........x.....x..x..x.....x.....x",
                                            "x..xxxx..x..x..x..x..x..xxxx..x..x..x..xxxxxxxxxxxxxxxx..x..x..xxxxxxx..x..x..xxxxxxxxxxxxxxxxxxxxxx..x..xxxx..xxxxxxx..x..xxxxxxx..x..x..xxxxxxx..xxxx",
                                            "x...........x..x.....x........x..x..x..x........x.....x........x.....x.....x..x.................x.....x.....x...........x..x........x..x..x........x..x",
                                            "xxxxxxxxxxxxx..xxxxxxxxxx..xxxx..x..x..xxxxxxx..x..xxxxxxx..xxxx..x..x..xxxx..xxxxxxxxxxxxxxxx..x..xxxxxxxxxxxxxxxxxxxxxx..x..xxxxxxx..x..x..xxxxxxx..x",
                                            "x.....x.....x..x.....x..x..x.....x..x...........x.....x..x..x.....x..x.....x.................x..x..x.....x...........x.....x..x........x.....x.....x..x",
                                            "x..xxxx..xxxx..xxxx..x..x..x..xxxx..xxxxxxxxxxxxxxxx..x..x..x..xxxx..xxxxxxxxxx..x..xxxxxxx..x..x..x..x..x..xxxxxxx..x..xxxx..x..xxxxxxxxxxxxxxxx..x..x",
                                            "x.....x.....x.....x..x..x..x.....x..x..x..............x..x.....x..x........x.....x.....x.....x..x.....x..x..x........x.....x..x........x...........x..x",
                                            "xxxx..xxxx..xxxx..x..x..x..xxxx..x..x..x..xxxxxxxxxxxxx..xxxx..x..x..xxxx..x..xxxxxxxxxx..xxxx..xxxxxxx..x..x..xxxxxxxxxxxxx..xxxxxxx..x..xxxxxxxxxx..x",
                                            "x........x.....x..x........x.....x.....x..x.....x...........x..x........x........x........x.....x.....x..x..x........x........x.....x..x..............x",
                                            "x..xxxx..x..xxxx..xxxxxxxxxxxxxxxxxxx..x..x..xxxx..xxxxxxx..xxxxxxxxxxxxxxxx..x..x..xxxxxxx..xxxx..xxxx..x..xxxxxxx..x..xxxxxxx..x..x..x..xxxxxxxxxxxxx",
                                            "x.....x...........x..............x.....x..x........x..........................x..x........x..x..x.....x.....x.....x..x..x........x.....x........x.....x",
                                            "xxxx..xxxx..xxxxxxx..xxxxxxxxxx..x..xxxx..xxxxxxxxxxxxxxxx..xxxxxxxxxx..xxxxxxx..xxxxxxx..x..x..xxxx..xxxxxxx..x..x..x..x..xxxxxxxxxx..xxxxxxx..x..x..x",
                                            "x.....x..x.....x.....x........x.....x........x.....x...........x.....x.....x.....x.....x.....x..x..............x..x.....x...........x........x..x..x..x",
                                            "x..xxxx..xxxx..x..xxxxxxxxxx..x..xxxx..x..x..x..xxxx..xxxxxxxxxx..x..xxxxxxx..xxxx..xxxxxxxxxx..x..x..xxxxxxxxxx..x..xxxxxxxxxxxxx..xxxxxxx..x..x..xxxx",
                                            "x.....x..x.....x..x.....x.....x..x.....x..x..x........x...........x...........x..x...........x.....x..x........x..x..x.....x.....x........x..x........x",
                                            "xxxx..x..x..xxxx..x..x..x..xxxx..xxxxxxx..xxxx..xxxxxxx..xxxxxxx..xxxxxxxxxxxxx..xxxxxxxxxx..xxxxxxx..x..xxxx..x..x..x..xxxx..x..x..xxxx..x..xxxxxxx..x",
                                            "x.....x..x........x..x..x.....x........x.....x..x........x.....x..x.....x..x.....x........x........x..x..x..x........x.....x..x..x.....x..x..x........x",
                                            "x..xxxx..xxxxxxxxxx..x..x..x..xxxxxxx..xxxx..x..x..xxxxxxx..x..xxxx..x..x..x..xxxx..xxxx..x..x..x..xxxx..x..xxxx..xxxx..x..x..x..xxxx..x..x..x..x..xxxx",
                                            "x.....x..x...........x..x..x..x.....x..x..x.....x........x..x........x.....x...........x..x..x..x.....x.....x........x..x..x..x........x..x..x..x.....x",
                                            "x..x..x..x..xxxxxxxxxx..xxxx..xxxx..x..x..xxxxxxxxxxxxx..xxxx..xxxxxxxxxx..xxxxxxx..x..x..xxxx..xxxx..xxxxxxxxxx..x..xxxx..x..xxxxxxxxxx..x..x..x..x..x",
                                            "x..x.....x........x........x.....x.....x..x....................x........x..x.....x..x..x........x..x...........x..x..x.....x........x..x..x..x..x..x..x",
                                            "x..xxxxxxxxxxxxx..xxxx..x..xxxx..xxxxxxx..xxxx..xxxxxxx..xxxxxxxxxx..x..x..xxxx..x..xxxxxxxxxxxxx..xxxx..xxxx..xxxx..x..xxxxxxxxxx..x..x..xxxx..xxxx..x",
                                            "x..x...........x.....x..x.....x.....x........x..x.....x........x.....x..x..x.....x.....x.................x...........x..x...........x..x..x.....x.....x",
                                            "x..x..xxxxxxx..xxxx..x..xxxx..xxxx..xxxxxxx..x..xxxx..x..xxxx..x..xxxxxxx..x..xxxxxxx..x..xxxxxxxxxxxxxxxx..xxxxxxxxxx..x..x..xxxxxxx..x..x..xxxx..xxxx",
                                            "x.....x.....x..x.....x.....x........x.....x........x.....x..x..x..x.....x.....x........x...........x.....x........x........x.....x.....x.....x.....x..x",
                                            "x..xxxxxxx..x..x..xxxxxxx..xxxxxxxxxx..x..xxxxxxx..xxxxxxx..x..x..xxxx..xxxxxxx..xxxxxxxxxxxxxxxx..x..x..xxxxxxx..x..xxxxxxxxxx..x..xxxxxxxxxx..x..x..x",
                                            "x...........x.....x..............x.....x...........x.....x........x.....x..............x........x.....x........x..x..x.....x........x..x........x..x..x",
                                            "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx..x..xxxx..xxxx..xxxx..x..xxxxxxxxxx..xxxxxxx..xxxxxxx..x..xxxx..xxxxxxxxxxxxx..x..x..xxxx..x..xxxxxxx..x..xxxxxxx..x..x",
                                            "x..x..........................x..x..x.....x...........x..x...........x..x.....x.....x..x..x..x...........x.....x..x........x........x..x..x.....x.....x",
                                            "x..x..xxxxxxxxxxxxxxxxxxxxxx..x..x..x..xxxxxxx..xxxxxxx..x..x..xxxxxxx..x..xxxx..x..x..x..x..xxxxxxxxxx..x..xxxxxxxxxxxxxxxxxxxxxxxxx..x..xxxx..xxxxxxx",
                                            "x..x........x..x...........x.....x..x........x..x.....x.....x..x...........x..x..x.....x.....x...........x..x...........x...........x........x..x.....x",
                                            "x..xxxxxxx..x..x..xxxxxxx..xxxxxxx..xxxx..x..xxxx..xxxxxxxxxxxxx..xxxx..xxxx..x..xxxxxxxxxxxxxxxxxxx..xxxx..x..xxxxxxx..x..xxxxxxx..xxxx..x..x..x..x..x",
                                            "x.....x........x..x.....x..x........x.....x........x........x.....x.....x..x..x..x...........x........x.....x..x........x........x..x.....x........x..x",
                                            "x..x..x..x..xxxx..x..xxxx..x..xxxxxxx..xxxxxxxxxxxxx..xxxx..x..x..x..xxxx..x..x..x..xxxxxxxxxx..xxxxxxx..xxxx..x..xxxxxxxxxxxxx..x..x..xxxxxxx..xxxx..x",
                                            "x..x.....x..x.....x........x.....x.....x.....x.....x..x..x..x..x..x..x.....x.....x.....x..x.....x.....x.....x..x.....x...........x.....x........x.....x",
                                            "xxxxxxxxxx..xxxx..xxxxxxxxxxxxx..x..xxxxxxx..x..xxxx..x..x..x..xxxx..x..xxxxxxxxxxxxx..x..x..xxxx..xxxxxxx..x..xxxx..x..x..xxxxxxxxxxxxxxxxxxxxxx..xxxx",
                                            "x...........x.....x..x........x..x...........x...........x.....x.....x...........x........x.....x.....x..x.....x.....x..x..x.....x........x..x.....x..x",
                                            "x..xxxxxxxxxx..xxxx..x..xxxx..x..xxxxxxx..xxxxxxxxxxxxxxxxxxxxxx..xxxxxxx..xxxx..xxxx..xxxxxxx..x..x..x..xxxxxxx..xxxx..xxxx..x..xxxxxxx..x..x..xxxx..x",
                                            "x..............x.....x..x.....x..x..x.....x.....x.....x........x........x.....x........x.....x..x..x.....x........x........x..x...........x...........x",
                                            "xxxxxxxxxxxxxxxx..xxxx..x..xxxx..x..x..xxxxxxx..x..x..xxxxxxx..xxxxxxx..xxxx..xxxxxxxxxx..x..x..x..x..x..x..xxxxxxxxxxxxx..x..xxxx..xxxxxxxxxx..xxxx..x",
                                            "x.....x........x........x........x.....x.....x.....x..x........x........x.....x...........x.....x..x..x..x...........x.....x..x..x........x.....x.....x",
                                            "x..x..x..xxxx..xxxx..xxxxxxxxxxxxx..xxxx..x..xxxx..x..x..x..xxxx..xxxxxxx..xxxxxxxxxx..x..xxxxxxx..x..x..xxxxxxxxxx..x..xxxx..x..xxxxxxx..x..xxxxxxxxxx",
                                            "x..x..x.....x........x...........x..x..x..x..x.....x.....x..x.....x.....x..x..x.....x..x.....x.....x..x..x........x..x.....x..x...........x...........x",
                                            "x..xxxxxxx..xxxxxxxxxx..xxxxxxx..x..x..x..x..x..xxxxxxxxxx..x..x..x..x..x..x..x..x..xxxxxxx..xxxxxxx..xxxx..x..xxxx..xxxx..x..xxxxxxxxxxxxxxxxxxxxxx..x",
                                            "x.......................x........x........x.....x...........x..x.....x.....x.....x..........................x........x........x.......................B",
                                            "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" };
            var expected = "Maze Directions from Start(A) to End(B): EEEEEEEEEEEEESSWWWWWSSSSSSEEEEESSSSWWNNWWWSSWWWNNNNNNNNWWWSSSSSSSSSSEEEEEEEESSSSEEESSSSSSWWWWWSSWWWSSWWWSSSSEESSWWSSEEEEESSSSWWWWWSSEEEEEEEESSSSWWWWWWWWSSEESSWWSSEESSWWSSEEEEEEEENNNNNNWWNNEEEEENNNNNNNNNNWWNNEEEEESSEEEEEEENNNNNNNNEEENNEESSEEEEEENNWWNNNNEESSEEESSSSEEEENNNNEESSSSEEEEEESSEEESSWWSSWWWNNNNWWWWWWWWWWWWWWWWWWWWWSSEEEEESSSSEEEEEEENNEESSSSWWSSSSWWWSSSSSSSSEESSEEEENNEEENNEEENNEEEEESSEEEENNEEEEEEEESSWWWWWSSSSSSSSSSEEENNEEENNEESSSSEEEEEESSEEEENNEENNWWNNNNEEEEEENNEEEEESSEEEENNEEEEEENNNNEESSSSSSSSWWSSSSEEENNEESSSSSSEEEENNNNNNEEEEEEEESSWWWWWSSEEEEESSSSEEEENNNNEEEEEENNNNNNEEEEENNWWNNNNNNEESSSSEEESSSSSSWWWWWSSEEEEESSSSWWNNWWWSSWWWWWWSSEEEEEEEESSEEEEEESSSSSSSSSSEEEENNEEENNNNNNEESSEEESSSSWWSSWWWSSWWWWWWSSSSEESSEEEEEEENNEESSSSWWSSWWWSSSSWWWSSEEEEEEEESSEE";

            // Assert
            var actual = AStarAlgorithm.AStarSearch(maze);
            Assert.AreEqual(expected, actual);
        }
    }
}