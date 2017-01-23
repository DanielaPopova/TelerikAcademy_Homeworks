namespace SchoolSystem.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckUIntRange(uint value, int min, int max, string message = null)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
