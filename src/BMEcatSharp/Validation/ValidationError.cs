namespace BMEcatSharp.Validation;

public class ValidationError
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected ValidationError()
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public ValidationError(string key, string message)
    {
        Key = key;
        Message = message;
    }

    public string Key { get; set; }
    public string Message { get; set; }
}
