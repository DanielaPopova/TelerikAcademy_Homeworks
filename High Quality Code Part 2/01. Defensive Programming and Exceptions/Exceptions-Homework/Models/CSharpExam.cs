namespace Exceptions_Homework.Models
{
    using System;

    public class CSharpExam : Exam
    {
        private const int MinGrade = 0;
        private const int MaxGrade = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < MinGrade || value > MaxGrade)
                {
                    throw new ArgumentException("Score is a value between 0 and 100!");
                }

                this.score = value;
            }
        }

        public override ExamResult CalculateResult()
        {
            return new ExamResult(this.Score, MinGrade, MaxGrade, "Exam results calculated by score.");
        }
    }
}
