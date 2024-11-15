using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wox.Plugin;

namespace Microsoft.PowerToys.Run.Plugin.Teams.UnitTests
{
    [TestClass]
    public class TeamsPluginTests
    {
        private Main _plugin;

        [TestInitialize]
        public void Setup()
        {
            _plugin = new Main();
            _plugin.Init(new PluginInitContext());
        }

        [TestMethod]
        public void Query_NewMessage_ReturnsResult()
        {
            // Arrange
            var query = new Query("n");

            // Act
            var results = _plugin.Query(query);

            // Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.AreEqual("New Teams Message", results[0].Title);
            Assert.AreEqual("Open new message window in Teams", results[0].SubTitle);
        }

        [TestMethod]
        public void Query_NewMessageWithRecipient_ReturnsResult()
        {
            // Arrange
            var query = new Query("n testuser@domain.com");

            // Act
            var results = _plugin.Query(query);

            // Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.AreEqual("Message testuser@domain.com", results[0].Title);
            Assert.AreEqual("Start new Teams chat with testuser@domain.com", results[0].SubTitle);
        }

        [TestMethod]
        public void Query_EmptyString_ReturnsEmptyList()
        {
            // Arrange
            var query = new Query(string.Empty);

            // Act
            var results = _plugin.Query(query);

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Plugin_HasCorrectMetadata()
        {
            // Assert
            Assert.AreEqual("Teams", _plugin.Name);
            Assert.AreEqual("Quick access to Microsoft Teams functions", _plugin.Description);
            Assert.AreEqual("6A122269-8B3F-4324-85F5-165A870F5D9C", Main.PluginID);
        }
    }
} 