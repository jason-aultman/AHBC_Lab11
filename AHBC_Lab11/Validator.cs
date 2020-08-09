using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace AHBC_Lab11
{
    static class Validator
    {
        public static bool ValidateIsNumberWithinRange(int min, int max, int number)
        {
            if (number>=min && number <=max)
            {
                return true;
            }
            return false;
        }
        public static bool ValidateIsParsibleAsAnInt(string word)
        {
            var isParsable=int.TryParse(word, out int result);
            return isParsable;
        }
        public static int ValidateAndReturnValidInt(int min, int max, string word)
        {
            if (ValidateIsParsibleAsAnInt(word))
            {
                var inputAsInt = int.Parse(word);
                var isWithinRange = ValidateIsNumberWithinRange(min, max, inputAsInt);
                if (isWithinRange) return inputAsInt;

            }
            else if (ValidateInputAsString(word) != -1)
            {
                return ValidateInputAsString(word);
            }
            Console.WriteLine("Input is invalid");
            return -1;
         }

        public static bool ValidateYesOrNo(string userInput)
        {
            if (userInput.ToLower().StartsWith("yes") || userInput.ToLower().StartsWith("no"))
            {
                return true;
            }
            else return false;
        }

        public static int ValidateInputAsString(string word)
        {
            if (word == "animated")
            {
                return (int)Catagory.animated;
            }
            else if (word == "drama")
            {
                return (int)Catagory.drama;
            }
            else if (word == "horror")
            {
                return (int)Catagory.horror;
            }
            else if (word == "scifi")
            {
                return (int)Catagory.scifi;
            }
            else return -1;
        }
        
    }
}
