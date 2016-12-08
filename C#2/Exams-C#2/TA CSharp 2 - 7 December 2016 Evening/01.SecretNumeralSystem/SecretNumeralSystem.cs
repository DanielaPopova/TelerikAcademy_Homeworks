using System;
using System.Numerics;

    class SecretNumeralsystem
    {
        static string[] words = { "hristo", "tosho", "pesho", "hristofor", "vlad", "haralampi", "zoro", "vladimir" };
        
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            BigInteger product = 1;

            for (int i = 0; i < input.Length; i++)
            {
                string currSecretNumber = input[i];
                string digit = string.Empty;
                string convertedSecretNum = string.Empty;
                int startIndex = 0;

                while (startIndex < currSecretNumber.Length)
                {
                    char currSymbol = currSecretNumber[startIndex];

                    if (currSymbol == 't')
                    {
                        digit = "1";
                        startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("tosho"), 5)).Length;
                    }
                    else if (currSymbol == 'p')
                    {
                        digit = "2";
                        startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("pesho"), 5)).Length;
                    }
                    else if (currSymbol == 'z')
                    {
                        digit = "6";
                        startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("zoro"), 4)).Length;
                    }
                    else if (currSymbol == 'v')
                    {
                        if ((startIndex + 4) < currSecretNumber.Length && currSecretNumber[startIndex + 4] == 'i')
                        {
                            digit = "7";
                            startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("vladimir"), 8)).Length;
                        }
                        else
                        {
                            digit = "4";
                            startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("vlad"), 4)).Length;
                        }
                    }
                    else if (currSymbol == 'h')
                    {
                        if (currSecretNumber[startIndex + 1] == 'a')
                        {
                            digit = "5";
                            startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("haralampi"), 9)).Length;
                        }
                        else if (startIndex + 6 < currSecretNumber.Length && currSecretNumber[startIndex + 6] == 'f')
                        {
                            digit = "3";
                            startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("hristofor"), 9)).Length;
                        }
                        else
                        {
                            digit = "0";
                            startIndex = startIndex + (currSecretNumber.Substring(currSecretNumber.IndexOf("hristo"), 6)).Length;
                        }
                    }

                    convertedSecretNum += digit;
                }

                BigInteger decRep = ConvertToDec(convertedSecretNum);
                
                product *= decRep;
            }

            Console.WriteLine(product);
        }     

        static BigInteger ConvertToDec(string base7)
        {
            BigInteger decResult = 0;

            for (int i = 0; i < base7.Length; i++)
            {
                decResult = int.Parse(base7[i].ToString()) + decResult * 8;
            }

            return decResult;
        }
    }
// Yask00
/*
using System;
using System.Linq;
using System.Numerics;
using System.Text;
 
namespace EXAM
{
    class Program
    {
        static string[] crazyNumbers = { "hristo", "tosho", "pesho", "hristofor", "vlad", "haralampi", "zoro", "vladimir" };
 
        static void Main()
        {
            char[] splitsymbols = { ',', ' ' };
 
            string[] input = Console.ReadLine().Split(splitsymbols, StringSplitOptions.RemoveEmptyEntries); 
 
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace("hristofor", "3")
                                    .Replace("hristo", "0")
                                    .Replace("tosho", "1")
                                    .Replace("pesho", "2")
                                    .Replace("vladimir", "7")
                                    .Replace("vlad", "4")
                                    .Replace("haralampi", "5")
                                    .Replace("zoro", "6");
            }
 
            BigInteger result = 1;
 
            for (int i = 0; i < input.Length; i++)
            {
                result *= (Convert.ToInt64(input[i], 8));
            }
 
            Console.WriteLine(result); 
        } 
    }
}
*/