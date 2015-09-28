using System;
using System.IO;
/*
 * The nth term of the sequence of triangle numbers is given by, 
 * tn = ½n(n+1); so the first ten triangle numbers are:
 * 
 * 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
 * 
 * By converting each letter in a word to a number corresponding to 
 * its alphabetical position and adding these values we form a word value. 
 * For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. 
 * If the word value is a triangle number then we shall call the word a triangle word.
 * 
 * Using words.txt (right click and 'Save Link/Target As...'), 
 * a 16K text file containing nearly two-thousand common English words, 
 * how many are triangle words?
 */
namespace PEProblem042
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartTime = DateTime.Now;

            StreamReader streamReader = new StreamReader("p042_words.txt");
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            char[] separators = { '"', ',' };
            string[][] textArray = new string[2][];
            textArray[0] = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            textArray[1] = new string[textArray[0].Length];

            string tmpString = "";
            int tmpInt = 0;
            for (int i = 0; i < textArray[0].Length; i++)
            {
                tmpInt = 0;
                tmpString = textArray[0][i];
                for (int j = 0; j < tmpString.Length; j++)
                {
                    tmpInt += (int)tmpString[j] - 64;
                }
                textArray[1][i] = tmpInt.ToString();
            }

            int[] triangle = new int[21];
            triangle[0] = 0;
            for (int i = 1; i < triangle.Length; i++)
            {
                triangle[i] = triangle[i - 1] + i;
            }

            int result = 0;
            for (int i = 0; i < textArray[1].Length; i++)
            {
                tmpString = textArray[0][i];
                for (int j = 1; j < triangle.Length; j++)
                {
                    if (triangle[j].ToString() == textArray[1][i])
                    {
                        result++;
                    }
                }
            }

            TimeSpan elapsedTime = DateTime.Now - StartTime;

            Console.WriteLine("result: " + result.ToString());
            Console.WriteLine("elapsed time: " + elapsedTime.ToString("mm':'ss':'fff") + " mm:ss:fff");
            Console.ReadLine();
        }
    }
}