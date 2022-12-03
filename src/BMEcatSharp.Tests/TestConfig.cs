using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OpenTransSharp.Tests")]

namespace BMEcatSharp.Tests
{
    internal class TestConfig
    {
        public TestConfig()
        {
            BMEcats = new BMEcatTestConfig(this);
        }
        public BMEcatTestConfig BMEcats { get; }
    }
}
