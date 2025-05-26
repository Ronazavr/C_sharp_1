namespace lab1
{
    public class StackException : System.Exception
    {
        public StackException() { }
        public StackException(string message) : base(message) { }
    }
}