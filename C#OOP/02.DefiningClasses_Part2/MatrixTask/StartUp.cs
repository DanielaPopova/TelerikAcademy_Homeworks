namespace MatrixTask
{
    using System;
    using AttributeTask;

    [Version(1, 3)]
    public class StartUp
    {
        public static void Main()
        {
            var firstMatrix = new Matrix<int>(2, 3);
            firstMatrix.FillMatrix();
            Console.WriteLine(firstMatrix);

            var secondMatrix = new Matrix<int>(2, 3);
            secondMatrix.FillMatrix();
            Console.WriteLine(secondMatrix);

            var thirdMatrix = new Matrix<int>(3, 2);
            thirdMatrix.FillMatrix();
            Console.WriteLine(thirdMatrix);

            var resultAdd = firstMatrix + secondMatrix;
            Console.WriteLine("Addition:\n{0}", resultAdd);

            var resultSub = firstMatrix - secondMatrix;
            Console.WriteLine("Substraction:\n{0}", resultSub);

            var resultMultiply = firstMatrix * thirdMatrix;
            Console.WriteLine("Multiplication:\n{0}", resultMultiply);

            var isTrue = firstMatrix ? "true" : "false";
            Console.WriteLine(isTrue);

            var forthMatrix = new Matrix<int>(2, 2);
            forthMatrix[0, 0] = 0;
            forthMatrix[0, 1] = 1;
            forthMatrix[1, 0] = 2;
            forthMatrix[1, 1] = 3;

            isTrue = forthMatrix ? "true" : "false";
            Console.WriteLine(isTrue);

            var attributeTypes = typeof(StartUp).GetCustomAttributes(false);

            foreach (var attribute in attributeTypes)
            {
                Console.WriteLine(attribute);
            }
        }
    }
}
