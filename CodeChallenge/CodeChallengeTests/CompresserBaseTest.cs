using Xunit;

namespace CodeChallenge.Tests
{
    public partial class CompresserBaseTest
    {
        protected string _input;
        protected string _output;

        protected void GivenANullValue()
        {
            _input = null;
        }

        protected void ThenReturnAValue()
        {
            Assert.NotNull(_output);
            Assert.NotEmpty(_output);
        }

        protected void GivenAInput(string input)
        {
            _input = input;
        }

        protected void ThenOuputIsEmptyString()
        {
            Assert.Empty(_output);
        }

        protected void GivenAEmptyString()
        {
            _input = string.Empty;
        }

        protected void ThenOuputIsNull()
        {
            Assert.Null(_output);
        }

        protected void ThenTheResultIs(string output)
        {
            Assert.Equal(output, _output);
        }

        protected void ThenThrowAnException(Action act, string message)
        {
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal(message, exception.Message);
        }
    }
}
