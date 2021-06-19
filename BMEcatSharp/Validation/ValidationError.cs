namespace BMEcatSharp.Validation
{
    public class ValidationError
    {
        public ValidationError()
        {
        }

        public ValidationError(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
