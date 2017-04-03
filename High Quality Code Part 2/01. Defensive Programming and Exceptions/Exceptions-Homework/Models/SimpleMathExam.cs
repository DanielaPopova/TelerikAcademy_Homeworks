namespace Exceptions_Homework.Models
{
    using System;

    public class SimpleMathExam : Exam
    {
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Solved problems are between 0 and 10!");
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult CalculateResult()
        {
            if (this.ProblemsSolved >= 0 && this.ProblemsSolved <= 3)
            {
                return new ExamResult(2, 2, 6, "Bad result: almost none of the problems are solved.");
            }
            else if (this.ProblemsSolved >= 4 && this.ProblemsSolved <= 7)
            {
                return new ExamResult(4, 2, 6, "Average result: a part of the problems are solved.");
            }
            else
            {
                return new ExamResult(6, 2, 6, "Excellent result: almost all problems are solved.");
            }
        }
    }
}