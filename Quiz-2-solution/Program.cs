using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_2_solution
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*

            Problem:
            t and z are strings consist of lowercase English letters.

            Find all substrings for t, and return the maximum value of [ len(substring) x [how many times the substring occurs in z] ]

            Example:
            t = acldm1labcdhsnd
            z = shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa

            Solution:
            abcd is a substring of t, and it occurs 5 times in Z, abcd.Length x 5 = 20 is the solution

            */



            var t = "acldm1labcdhsnd";
            var z = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";
            string newString = "";

            var longestSubstr = FindLongestSubstring(t);
            foreach (var item in longestSubstr.Keys)
            {
                newString += item;
            }

            int occurance = FindOccurance(z, newString);
            Console.WriteLine("Substring Occurance: " + occurance);
            Console.WriteLine("Final Calc: " + occurance * longestSubstr.Count);

            Console.Read();



            Dictionary<char, int> FindLongestSubstring(string subString)
            {
                Dictionary<char, int> map = new Dictionary<char, int>();
                int ipoint = 0;
                int jpoint = 0;
                int subLength = subString.Length;


                while (jpoint < subLength)
                {

                    if (map.ContainsKey(subString[jpoint]))
                    {
                        map.Remove(subString[ipoint]);
                        ipoint++;
                    }
                    else
                    {
                        map.Add(subString[jpoint], jpoint);
                        jpoint++;

                    }
                }

                return map;

            }

            int FindOccurance(string substring, string mainstring)
            {

                int subString = substring.Length;
                int mainString = mainstring.Length;
                int counter = 0;


                for (int i = 0; i <= mainString - subString; i++)
                {
                    int j;

                    for (j = 0; j < subString; j++)
                        if (mainstring[i + j] != substring[j])
                            break;

                    if (j == subString)
                        counter++;
                }

                return counter;
            }
        }
    }
}
