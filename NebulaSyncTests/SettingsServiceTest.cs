using Microsoft.VisualStudio.TestTools.UnitTesting;
using NebulaSync.Services;

namespace NebulaSyncTests
{
    [TestClass]
    public class SettingsServiceTest
    {
        [TestMethod]
        public void IsSettingsOk()
        {
            var service = new SettingsService();
            Assert.IsNotNull(service.Host);
            Assert.IsFalse(string.IsNullOrEmpty(service.Host.ToString()));
            Assert.IsNotNull(service.SyncDishUri);
            Assert.IsFalse(string.IsNullOrEmpty(service.SyncDishUri.ToString()));
            Assert.IsFalse(string.IsNullOrEmpty(service.Token));
        }
    }
}
