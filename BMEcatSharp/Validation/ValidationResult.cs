using System;

namespace BMEcatSharp.Validation
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Length == 0;
        public string[] Errors { get; set; } = Array.Empty<string>();
    }
}
