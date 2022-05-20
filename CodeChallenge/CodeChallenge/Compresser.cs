namespace CodeChallenge
{
    public class Compresser
    {

        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var isOnlyAlphanumeric = input.Any(x => char.IsLetterOrDigit(x));
            if (!isOnlyAlphanumeric)
            {
                throw new Exception("Only Alphabetic characters are available");
            }
            return input;
        }
    }
}