namespace encoder_decoder.Classes
{
    public static class MessageReverser
    {
        public static string Reverse(string message)
        {
            char[] characters = message.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }
    }
}