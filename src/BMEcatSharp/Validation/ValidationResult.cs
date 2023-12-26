using System;
using System.Collections.Generic;

namespace BMEcatSharp.Validation;

public class ValidationResult
{
    public bool IsValid => Errors.Keys.Count == 0;
    public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
