namespace Day02
{
    [Serializable]
    internal class ParsingException : Exception
    {
        public ParsingException()
        {
        }

        public ParsingException(string? message) : base(message)
        {
        }

        public ParsingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}