using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Steeltoe.Extensions.Configuration.Placeholder;
using Xunit;

namespace ClientConfigServerTest
{
    public class Tests
    {
                
        [Theory]
        [InlineData("sampleclient","profile1")]
        [InlineData("sampleclient","profile2")]
        [InlineData("sampleclient","profile3")]
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
            Assert.Equal("foo_bar", config["title"]);
        }
    }
}