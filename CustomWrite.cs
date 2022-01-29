using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading_Spinner
{
    internal class CustomWrite
    {
        public static int primaryCursPosLeft = 50;
        public static int primaryCursPosTop = 9;

        public static void WriteLine(string text)
        {
            Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);
            Console.WriteLine(text);
            Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);
        }
    }
}
