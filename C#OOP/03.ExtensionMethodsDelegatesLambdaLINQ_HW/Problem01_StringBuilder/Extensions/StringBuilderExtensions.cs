namespace Problem1_StringBuilder.Extensions
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            if (index < 0 || index >= input.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }

            if (length < 0 || length > input.Length - index)
            {
                throw new ArgumentOutOfRangeException("Invalid length!");
            }

            StringBuilder output = new StringBuilder();

            for (int i = index; i < index + length; i++)
            {
                output.Append(input[i]);
            }

            return output;
        }

        // overload
        public static StringBuilder Substring(this StringBuilder input, int index)
        {
            StringBuilder output = new StringBuilder(input.ToString().Substring(index));
            return output;
        }
    }
}
