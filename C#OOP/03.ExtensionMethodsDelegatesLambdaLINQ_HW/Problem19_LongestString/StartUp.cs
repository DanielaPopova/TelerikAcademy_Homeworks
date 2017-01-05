namespace Problem17_LongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] aliceWorld = new string[] { "Alice in Wonderland", "Mad Hatter", "Jabberwock", "White Rabbit", "Queen of Hearts", "Caterpillar", "Dormouse" };           

            string longestWord = aliceWorld
                .FirstOrDefault(word => word.Length == aliceWorld.Max(str => str.Length));

            Console.WriteLine(longestWord);

            // LINQ keywords
            var sortedWords =
                from words in aliceWorld
                orderby words.Length descending
                select words;

            string longest = sortedWords.First();
            Console.WriteLine(longest);
        }
    }
}