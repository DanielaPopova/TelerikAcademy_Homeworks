namespace RefactorIfStatements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main()
        {
            // Potato task
            Potato potato = new Potato();

            if (potato == null)
            {
                throw new ArgumentNullException("Potato cannot be null!");
            }

            potato.IsPeeled = true;
            Cook(potato);

            // Matrix task 
            Console.WriteLine("Enter value for current row:"); 
            int currentRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value for current column:");
            int currentCol = int.Parse(Console.ReadLine());

            bool[,] matrix = new bool[,]
            {
                { true, true, false },
                { false, true, true },
                { true, false, false }
            };

            bool isInRange = IsWithinMatrixBorders(currentRow, currentCol, matrix);
            bool isVisited = matrix[currentRow, currentCol];     

            if (isInRange && !isVisited)
            {
                VisitCell(currentRow, currentCol, matrix);
            }
            else
            {
                Console.WriteLine("Cannot step on [{0} {1}]!", currentRow, currentCol);
            }
        }
        
        public static void Cook(Potato potato)
        {           
            if (!potato.IsPeeled)
            {
                throw new ArgumentException("Peel the potato first!");
            }

            if (potato.IsRotten)
            {
                throw new ArgumentException("You cannot cook rotten potatos!");
            }

            Console.WriteLine("Cooking the potato like a sir.");
        }

        public static bool IsWithinMatrixBorders(int currRow, int currCol, bool[,] matrix)
        {
            if (currRow < 0 || currRow >= matrix.GetLength(0) ||
                currCol < 0 || currCol >= matrix.GetLength(1))
            {
                throw new IndexOutOfRangeException("Index is outside of the matrix bounds!");
            }

            return true;
        }

        public static void VisitCell(int currRow, int currCol, bool[,] matrix)
        {
            matrix[currRow, currCol] = true;
            Console.WriteLine("You\'ve just visited [{0} {1}]!", currRow, currCol);
        }
    }
}
