using DSALeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsaTest;

[TestClass]
public class Search2DMatrixTest
{
    [TestMethod]
    public void TestSolution()
    {
        // Arrange
        var matrix = new[]
        {
            new[] { 10, 20, 30, 40 },
            new[] { 15, 25, 35, 45 },
            new[] { 27, 29, 37, 48 },
            new[] { 32, 33, 39, 50 },
        };
        const int target = 29;
        // Act
        var value = Search2DMatrix.Solution(matrix, target);

        // Assert
        const bool expectation = true;
        Assert.AreEqual(expectation, value);
    }
}