using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading_Spinner
{
    internal class Validate
    {
        //static string input;
        //public class IsLetter/*: IsNull */{
            public static bool IsInputLetter(string input)
            {
                if (input.Any(c => char.IsLetter(c)))
                {
                    CustomWrite.WriteLine(DisplayMessage.Error.ValueCannotBeLetter);
                    return false;
                }

                return true;

            }
        //}
        
        //public class IsNull /*:ReadInput*/
        //{
        //    public static bool CheckForNull(string input)
        //    {
        //        if (input == "")
        //        {
        //            CustomWrite.WriteLine(ErrorMessage.ValueCannotBeEmpty);
        //            return false;
        //        }

        //        return true;
        //    }
        //}

        //public class ReadInput
        //{
        //    public string Read()
        //    {
        //        input = Console.ReadLine();
        //        return input;
        //    }

        //}

       

        
    }
}

            


            
