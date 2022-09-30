using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_1_solution_Shortest
{
    /*
 You have a text that some of the words in reverse order.
 The text also contains some words in the correct order, and they are wrapped in parenthesis.
 Write a function fixes all of the words and,
 remove the parenthesis that is used for marking the correct words.

 Your function should return the same text defined in the constant correctAnswer, please keep in mind
 that shortest way possible will get you extra points.
 */

    internal class Program
    {

        private static void Main(string[] args)
        {
            /*
             1: Make a string array from inputText on every space between words including word after last space.
             2: Reverse everty index of the string array that does not contain both "(" and ")" and return new list
             3: Remove parantheses from every list index contain both "(" open and ")" close Parentheses and return new list
             4: return answer
            */

            var inputText = "nhoJ (Griffith) nodnoL saw (an) (American) ,tsilevon ,tsilanruoj (and) laicos .tsivitca ((A) reenoip (of) laicremmoc noitcif (and) naciremA ,senizagam (he) saw eno (of) (the) tsrif (American) srohtua (to) emoceb (an) lanoitanretni ytirbelec (and) nrae a egral enutrof (from) ).gnitirw";
            var correctAnswer = "John Griffith London was an American novelist, journalist, and social activist. (A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.)";




            string ReverseText(string input)
            {
                string answer = "";

                var inputArray = inputText.Split(' ');  //Make a string array from inputText on every space between words including word after last space.
                var reverseInput = ReverseWordsInInput(inputArray);
                var removePrentheses = RemoveParentheses(reverseInput);
                removePrentheses.ForEach(x => answer += x);

                return answer;
            }

            // Reverse everty index of the string list that does not contain both "(" and ")"
            List<string> ReverseWordsInInput(string[] inStringList)
            {
                var newList = new List<string>();

                foreach (var word in inStringList)
                {
                    if (!word.StartsWith("(") && !word.EndsWith(")"))
                    {
                        char[] charArray = word.ToCharArray();
                        Array.Reverse(charArray);
                        string newWord = new string(charArray);
                        newList.Add(newWord);
                    }
                    else
                    {
                        newList.Add(word);
                    }
                }
                return newList;
            }

            // Remove parantheses from every index contain both "(" open and ")" close Parentheses
            List<string> RemoveParentheses(List<string> reverseInput)
            {
                var finalList = new List<string>();
                foreach (var word in reverseInput)
                {
                    if (word.StartsWith("(") && word.EndsWith(")"))
                    {
                        string newWord = word.Remove(word.Length - 1, 1).Remove(0, 1);
                        // Check if we are adding space to last index of the list
                        if (reverseInput.Count - 1 == finalList.Count)
                            finalList.Add(newWord);
                        else finalList.Add(newWord + " ");
                    }
                    else
                    {
                        // Check if we are adding space to last index of the list
                        if (reverseInput.Count - 1 == finalList.Count)
                            finalList.Add(word);
                        else finalList.Add(word + " ");
                    }
                }
                return finalList;
            }

            Console.WriteLine(ReverseText(inputText) == correctAnswer ? "Correct !!!" : "Wrong answer...!");
            Console.WriteLine("########## With* Builtin Methods ############");
            Console.WriteLine(ReverseText(inputText));
            Console.ReadLine();
        }

    }

}
