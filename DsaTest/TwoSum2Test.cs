using System.Text.Json;
using DSALeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsaTest;

[TestClass]
public class TwoSum2Test
{
    [TestMethod]
    public void TestSolution()
    {
        // Arrange
        var array = new[] { 1, 2, 3, 4, 4, 9, 56, 90 };
        const int target = 8;

        // Act
        var returned = TwoSum2.Solution(array, target);

        // Assert
        var expectation = new[] { 4, 5 };
        CollectionAssert.AreEqual(expectation, returned);
    }

    [TestMethod]
    public void TestBinarySearchLeftMost()
    {
        // Arrange
        var array = new[] { 2, 7, 7, 7, 11, 15 };
        const int target = 7;

        // Act
        var returned = TwoSum2.BinarySearchLeftMost(array, 0, target);

        // Assert
        const int expectation = 1;
        Assert.AreEqual(expectation, returned);
    }
}