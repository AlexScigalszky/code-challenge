﻿using Xunit;

namespace CodeChallenge.Tests
{
    public class CompresserCompressTest : CompresserBaseTest
    {
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
            var act = WhenCompressAsync();
            ThenThrowAnException(act, "Only Alphabetic characters are available");
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
            WhenCompress();
            ThenTheResultIs(output);
        }

        [Theory]
        [InlineData("ab", "ab")]
        [InlineData("abc", "abc")]
        [InlineData("askufdhsdiyhfvnel", "askufdhsdiyhfvnel")]
        public void AlphabeticWithNoConsecutiveDuplicateLetters(string input, string output)
        {
            GivenAInput(input);
            WhenCompress();
            ThenTheResultIs(output);
        }

        private Action WhenCompressAsync()
        {
            return () => _output = Compresser.Compress(_input); 
        }

        private void WhenCompress()
        {
            _output = Compresser.Compress(_input);
        }
    }
}