using Xunit;

namespace CodeChallenge.Tests
{
    public class CompresserTests
    {
        private string _input;
        private string _output;

        [Fact]
        public void CompressTest()
        {
            GivenANullValue();
            WhenCompress();
            ThenOuputIsNull();
        }

        private void ThenOuputIsNull()
        {
            Assert.Null(_output);
        }

        private void WhenCompress()
        {
            _output = Compresser.Compress(_input);
        }

        private void GivenANullValue()
        {
            _input = null;
        }
    }
}