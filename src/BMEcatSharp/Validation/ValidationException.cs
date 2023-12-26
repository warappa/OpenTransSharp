using System;
using System.Collections.Generic;

namespace BMEcatSharp.Validation;

public class ValidationException : Exception
{
    public ValidationException(Dictionary<string, string[]> errors)
    {
        Errors = errors;
    }

    public Dictionary<string, string[]> Errors { get; }
}
