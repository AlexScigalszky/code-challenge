﻿using Xunit;

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

        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        [InlineData("c")]
        [InlineData("d")]
        [InlineData("e")]
        [InlineData("f")]
        [InlineData("g")]
        [InlineData("h")]
        [InlineData("i")]
        [InlineData("j")]
        [InlineData("k")]
        [InlineData("l")]
        [InlineData("m")]
        [InlineData("n")]
        [InlineData("o")]
        [InlineData("p")]
        [InlineData("q")]
        [InlineData("r")]
        [InlineData("s")]
        [InlineData("t")]
        [InlineData("u")]
        [InlineData("v")]
        [InlineData("w")]
        [InlineData("x")]
        [InlineData("y")]
        [InlineData("z")]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("7")]
        [InlineData("8")]
        [InlineData("9")]
        [InlineData("0")]
        [InlineData("a1")]
        [InlineData("1a")]
        [InlineData("a2b")]
        [InlineData("2b3")]
        [InlineData("A")]
        [InlineData("B")]
        [InlineData("C")]
        [InlineData("D")]
        [InlineData("E")]
        [InlineData("F")]
        [InlineData("G")]
        [InlineData("H")]
        [InlineData("I")]
        [InlineData("J")]
        [InlineData("K")]
        [InlineData("L")]
        [InlineData("M")]
        [InlineData("N")]
        [InlineData("O")]
        [InlineData("P")]
        [InlineData("Q")]
        [InlineData("R")]
        [InlineData("S")]
        [InlineData("T")]
        [InlineData("U")]
        [InlineData("V")]
        [InlineData("W")]
        [InlineData("X")]
        [InlineData("Y")]
        [InlineData("Z")]
        [InlineData("A1")]
        [InlineData("1A")]
        [InlineData("A2B")]
        [InlineData("2B3")]
        public void Alphanumeric(string input)
        {
            GivenAInput(input);
            WhenCompress();
            ThenReturnAValue();
        }

        [Theory]
        [InlineData("_")]
        [InlineData("?")]
        [InlineData("$")]
        [InlineData("!")]
        [InlineData("@")]
        [InlineData("\"")]
        [InlineData("/")]
        [InlineData("{")]
        [InlineData("}")]
        [InlineData("[")]
        [InlineData("]")]
        [InlineData("¿")]
        [InlineData("=")]
        [InlineData("&")]
        [InlineData("%")]
        public void NonAlphanumeric(string input)
        {
            GivenAInput(input);
            var act = WhenCompressAsync();
            ThenThrowAnException(act);
        }

        [Theory]
        [InlineData("aa", "a2")]
        public void AlphanumericWithConsecutiveDuplicateLetters(string input, string output)
        {
            GivenAInput(input);
            WhenCompress();
            ThenTheResultIs(output);
        }

        private void ThenTheResultIs(string output)
        {
            Assert.Equal(output, _output);
        }

        private void ThenThrowAnException(Action act)
        {
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Only Alphabetic characters are available", exception.Message);
        }

        private Action WhenCompressAsync()
        {
            return () => _output = Compresser.Compress(_input); 
        }

        private void ThenReturnAValue()
        {
            Assert.NotNull(_output);
            Assert.NotEmpty(_output);
        }

        private void GivenAInput(string input)
        {
            _input = input;
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