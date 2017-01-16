namespace Dealership.Models
{
    using System;
    using System.Text;

    using Dealership.Common;
    using Dealership.Contracts;

    public class Comment : IComment
    {
        private const string CommentHeader = "    ----------";
        private const string ContentProperty = "Content";

        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                Validator.ValidateNull(value, string.Format(Constants.StringCannotBeNull, ContentProperty));
                Validator.ValidateIntRange(value.Length, Constants.MinCommentLength, Constants.MaxCommentLength, string.Format(Constants.StringMustBeBetweenMinAndMax, ContentProperty, Constants.MinCommentLength, Constants.MaxCommentLength));
                this.content = value;
            }
        }

        public string Author { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(CommentHeader);
            result.AppendLine(string.Format("    {0}", this.Content));
            result.AppendLine(string.Format("      User: {0}", this.Author));
            result.AppendLine(CommentHeader);

            return result.ToString().Trim();
        }
    }
}
