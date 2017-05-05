namespace SchoolSystem.Models
{
    using System;

    using Contracts;
    using Enums;

    public class Mark : IMark
    {
        private const float MinValue = 2f;
        private const float MaxValue = 6f;

        private float value;

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public Subject Subject { get; private set; }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException($"Value must be between {MinValue} and {MaxValue}!");
                }

                this.value = value;
            }
        }
    }
}
