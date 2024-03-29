﻿
using Xunit;

namespace CodeChallenge.Tests
{
    public class CompresserCompressWithNumbersTests : CompresserBaseTest
    {
        [Fact]
        public void Null()
        {
            GivenANullValue();
            CompressWithNumbers();
            ThenOuputIsNull();
        }

        [Fact]
        public void Empty()
        {
            GivenAEmptyString();
            CompressWithNumbers();
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
        public void Alphanumeric(string input)
        {
            GivenAInput(input);
            CompressWithNumbers();
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
            var act = CompressWithNumbersAsync();
            ThenThrowAnException(act, "Only Alphanumeric characters are available");
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
            CompressWithNumbers();
            ThenTheResultIs(output);
        }

        [Theory]
        [InlineData("ab", "ab")]
        [InlineData("abc", "abc")]
        [InlineData("askufdhsdiyhfvnel", "askufdhsdiyhfvnel")]
        public void AlphabeticWithNoConsecutiveDuplicateLetters(string input, string output)
        {
            GivenAInput(input);
            CompressWithNumbers();
            ThenTheResultIs(output);
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
        [InlineData("aa1", "a21")]
        [InlineData("aaa1", "a31")]
        [InlineData("aaab1", "a3b1")]
        [InlineData("aaabb1", "a3b21")]
        [InlineData("aaabbc1", "a3b2c1")]
        [InlineData("aaabcc1", "a3bc21")]
        [InlineData("uuueeeenzzzzz1", "u3e4nz51")]
        [InlineData("uuueeeennzzzzz1", "u3e4n2z51")]
        public void AlphabeticWithConsecutiveDuplicateLettersAndNumbers(string input, string output)
        {
            GivenAInput(input);
            CompressWithNumbers();
            ThenTheResultIs(output);
        }

        private Action CompressWithNumbersAsync()
        {
            return () => _output = Compresser.CompressWithNumbers(_input);
        }

        private void CompressWithNumbers()
        {
            _output = Compresser.CompressWithNumbers(_input);
        }

    }
}