using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool? process = true;
            while(process == true)
            {
                Console.WriteLine("Binary Value: ");
                string binValue = Console.ReadLine();
                binValue = binValue.TrimStart('0');
                //TODO: reverse binValue

                if(!ValidateInput(binValue))
                    Console.WriteLine("Invalid input value");

                Result<int> result = ConvertToDecimalInteger(binValue);
                Console.WriteLine(GetResultString(result));

            validation:
                Console.WriteLine("Continue? y - n");
                string validation = Console.ReadLine();
                process = ProcessContinue(validation);
                if(process == null)
                {
                    Console.WriteLine("invalid input");
                    goto validation;
                }
            }

            Console.ReadLine();
        }

        private static bool ValidateInput(string input)
        {
            if(input.Contains('2')
                || input.Contains('3')
                || input.Contains('4')
                || input.Contains('5')
                || input.Contains('6')
                || input.Contains('7')
                || input.Contains('8')
                || input.Contains('9'))
            {
                return false;
            }

            return true;
        }

        private static Result<int> ConvertToDecimalInteger(string binValue)
        {
            int result = 1;
            for(int i = 1; i < binValue.Length; i++)
            {
                int temp = 0;
                bool parseResult = Int32.TryParse(binValue.ElementAt(i).ToString(), out temp);
                if(parseResult == false)
                {
                    return new Result<int>(-1, "error occured", false);
                }

                if(temp == 1)
                {
                    result += (int)Math.Pow(2, i);
                }
            }
            return new Result<int>(result, "", true);
        }

        private static string GetResultString(Result<int> result)
        {
            if(result.IsSuccess)
                return result.Value.ToString();

            return result.Message;
        }

        private static bool? ProcessContinue(string validation)
        {
            switch(validation)
            {
                case "y":
                    return true;

                case "n":
                    return false;

                default:
                    return null;
            }
        }
    }
}