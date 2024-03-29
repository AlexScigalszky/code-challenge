﻿using Xunit;

namespace CodeChallenge.Tests
{
    public class CompresserTryCompressTest : CompresserBaseTest
    {
        private bool _result;

        [Fact]
        public void Null()
        {
            GivenANullValue();
            WhenTryCompressIsCall();
            ThenOuputIsNull();
            ThenReturn(false);
        }

        [Fact]
        public void Empty()
        {
            GivenAEmptyString();
            WhenTryCompressIsCall();
            ThenOuputIsEmptyString();
            ThenReturn(false);
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
        public void Alphabetic(string input)
        {
            GivenAInput(input);
            WhenTryCompressIsCall();
            ThenReturnAValue();
            ThenReturn(true);
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
        [InlineData("A1")]
        [InlineData("1A")]
        [InlineData("A2B")]
        [InlineData("2B3")]
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
        public void NonAlphabetic(string input)
        {
            GivenAInput(input);
            WhenTryCompressIsCall();
            ThenReturn(false);
        }

        [Theory]
        [InlineData("aa", "a2")]
        [InlineData("aaa", "a3")]
        [InlineData("aaab", "a3b")]
        [InlineData("aaabb", "a3b2")]
        [InlineData("aaabbc", "a3b2c")]
        [InlineData("aaabcc", "a3bc2")]
        [InlineData("uuueeeenzzzzz", "u3e4nz5")]
        [InlineData("uuueeeennzzzzz", "u3e4n2z5")] 
        public void AlphabeticWithConsecutiveDuplicateLetters(string input, string output)
        {
            GivenAInput(input);
            WhenTryCompressIsCall();
            ThenTheResultIs(output);
            ThenReturn(true);
        }

        [Theory]
        [InlineData("ab", "ab")]
        [InlineData("abc", "abc")]
        [InlineData("askufdhsdiyhfvnel", "askufdhsdiyhfvnel")]
        public void AlphabeticWithNoConsecutiveDuplicateLetters(string input, string output)
        {
            GivenAInput(input);
            WhenTryCompressIsCall();
            ThenTheResultIs(output);
            ThenReturn(true);
        }

        private void WhenTryCompressIsCall()
        {
            _result = Compresser.TryCompress(_input, out _output);
        }

        private void ThenReturn(bool returnExpected)
        {
            Assert.Equal(returnExpected, _result);
        }
    }
}