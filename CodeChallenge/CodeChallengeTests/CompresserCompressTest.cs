using Xunit;

namespace CodeChallenge.Tests
{
    public class CompresserCompressTest
    {
        private string _input;
        private string _output;

        [Fact]
        public void Null()
        {
            GivenANullValue();
            WhenCompress();
            ThenOuputIsNull();
        }

        [Fact]
        public void Empty()
        {
            GivenAEmptyString();
            WhenCompress();
            ThenOuputIsEmptyString();
        }

        private void ThenOuputIsEmptyString()
        {
            Assert.Empty(_output);
        }

        private void GivenAEmptyString()
        {
            _input = string.Empty;
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