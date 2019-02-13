using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Steeltoe.Extensions.Configuration.Placeholder;
using Xunit;

namespace ClientConfigServerTest
{
    public class Tests
    {
                
        [Theory]
        [InlineData("sampleclient1","profile1")]
        [InlineData("sampleclient1","profile2")]
        [InlineData("sampleclient2","profile1")]
        [InlineData("sampleclient2","profile2")]
        public void TestPlaceholderResolving(string applicationName, string environment)
        {
            var settings = new ConfigServerClientSettings()
            {
                Uri = "http://localhost:8888",
                Environment = environment,
                Name = applicationName
            };
            var builder = new ConfigurationBuilder().AddConfigServer(settings);
            var config = builder.Build().AddPlaceholderResolver();
            Assert.Equal($"foo_bar_{environment}", config["title"]);
        }
    }
}