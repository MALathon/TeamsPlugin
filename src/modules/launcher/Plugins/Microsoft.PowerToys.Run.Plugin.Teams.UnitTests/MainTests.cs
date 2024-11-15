using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.PowerToys.Run.Plugin.Teams.UnitTests;

[TestClass]
public class MainTests
{
    private Main _plugin = null!;

    [TestInitialize]
    public void Setup()
    {
        _plugin = new Main();
    }

    [TestMethod]
    public void Query_EmptySearch_ReturnsEmptyResults()
    {
        // Arrange
        var query = new Query { Search = string.Empty };

        // Act
        var results = _plugin.Query(query);

        // Assert
        Assert.IsNotNull(results);
        Assert.AreEqual(0, results.Count);
    }

    [TestMethod]
    public void Query_NewMessage_ReturnsNewMessageResult()
    {
        // Arrange
        var query = new Query { Search = "n " };

        // Act
        var results = _plugin.Query(query);

        // Assert
        Assert.IsNotNull(results);
        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("New Teams Message", results[0].Title);
    }
} 