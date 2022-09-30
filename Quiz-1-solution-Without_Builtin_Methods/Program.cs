using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_1_solution_Without_Builtin_Methods
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
             1: Make a string list from inputText on every space between words including word after last space.
             2: Reverse everty index of the string list that does not contain both "(" and ")"
             3: Remove parantheses from every index contain both "(" open and ")" close Parentheses
             4: Print answer
           */

            var inputText = "nhoJ (Griffith) nodnoL saw (an) (American) ,tsilevon ,tsilanruoj (and) laicos .tsivitca ((A) reenoip (of) laicremmoc noitcif (and) naciremA ,senizagam (he) saw eno (of) (the) tsrif (American) srohtua (to) emoceb (an) lanoitanretni ytirbelec (and) nrae a egral enutrof (from) ).gnitirw";
            var correctAnswer = "John Griffith London was an American novelist, journalist, and social activist. (A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.)";

            List<string> StringList = new List<string>();

            string ReverseText(string inputStr)
            {
                var list = MakeListFromInput(inputStr);
                var reversedList = ReverseWordsInInput(list);
                var removeParanteses = RemoveParentheses(reversedList);
                string myAnswer = PrintAnswer(removeParanteses);

                return myAnswer;
            }


            //Make a string list from inputText on every space between words including word after last space.
            List<string> MakeListFromInput(string inputStr)
            {
                string inputWords = "";
                for (int i = 0; i < inputStr.Length; i++)
                {
                    inputWords += inputStr[i];
                    if (inputStr[i].ToString() == " ")
                    {
                        StringList.Add(inputWords);
                        inputWords = "";
                        continue;
                    }
                    if (i == inputStr.Length - 1)
                    {
                        StringList.Add(inputWords);
                    }

                }
                return StringList;
            }


            // Reverse everty index of the string list that does not contain both "(" and ")"
            List<string> ReverseWordsInInput(List<string> inStringList)
            {
                List<string> reversedStringList = new List<string>();

                foreach (var word in inStringList)
                {

                    if (word[0].ToString() != "(" && word[word.Length - 1].ToString() != ")")
                    {
                        string reversed = "";
                        for (int i = word.Length - 1; i >= 0; i--)
                        {
                            if (word[i].ToString() == " ")
                            {
                                continue;
                            }
                            reversed += word[i].ToString();
                        }
                        reversedStringList.Add(reversed);
                    }
                    else reversedStringList.Add(word);

                }
                return reversedStringList;
            }


            // Remove parantheses from every index contain both "(" open and ")" close Parentheses
            List<string> RemoveParentheses(List<string> reversedList)
            {
                List<string> RemovedParenthesesStringList = new List<string>();
                foreach (var word in reversedList)
                {
                    if (word[0].ToString() == "(" && word[word.Length - 2].ToString() == ")")
                    {
                        string parenthesesGone = "";
                        for (int i = 1; i <= word.Length - 3; i++)
                        {
                            parenthesesGone += word[i].ToString();
                        }
                        // Check if we are adding space to last index of the list
                        if (reversedList.Count - 1 == RemovedParenthesesStringList.Count)
                            RemovedParenthesesStringList.Add(parenthesesGone);

                        else RemovedParenthesesStringList.Add(parenthesesGone + " ");
                    }
                    else
                    {

                        if (reversedList.Count - 1 == RemovedParenthesesStringList.Count)
                            RemovedParenthesesStringList.Add(word);

                        else RemovedParenthesesStringList.Add(word + " ");
                    }
                }
                return RemovedParenthesesStringList;
                // Check if we are adding space to last index of the list
            }

            //Print answer
            string PrintAnswer(List<string> removedParantesesList)
            {
                string Answer = "";
                foreach (var item in removedParantesesList)
                {
                    Answer += item;
                }
                return Answer;
            }


            Console.WriteLine(ReverseText(inputText) == correctAnswer ? "Correct !!!" : "Wrong answer...!");
            Console.WriteLine("########## Without Builtin Methods ############");
            Console.WriteLine(ReverseText(inputText));
            Console.Read();

        }

    }
}
