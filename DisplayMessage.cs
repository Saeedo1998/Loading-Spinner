using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading_Spinner
{
    public static class DisplayMessage
    {
        public static class Error
        {
            public static string valueCannotBeLetter = "Value cannot be a letter";
            public static string valueCannotBeEmpty = "Value cannot empty";
        }

        public static class Success
        {
            public static string finishedLoading = "Finished Loading";
        }

        public static class Quit
        {
            public static string promptPressAnyKey = "Press any key to exit..";
            public static string promptHeadsUp = "Are you sure you want to exit? ( Y / N )";

        }

    }
}

