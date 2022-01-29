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
            public static string ValueCannotBeLetter = "Value cannot be a letter";
            public static string ValueCannotBeEmpty = "Value cannot empty";
        }

        public static class Success
        {
            public static string FinishedLoading = "Finished Loading";
        }

        public static class Quit
        {
            public static string PromptPressAnyKey = "Press any key to exit..";
            public static string PromptHeadsUp = "Are you sure you want to exit? ( Y / N )";

        }

    }
}

