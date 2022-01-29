using System.Diagnostics;

namespace Loading_Spinner
{
    class Program
    {
        public static Stopwatch stopwatch = new();
        public static int primaryCursPosLeft = 50;
        public static int primaryCursPosTop = 9;
        public static int loadingFramesDuration = 75; // (MilliSeconds)
        static async Task Main(string[] args)
        {
            Console.CursorVisible = true;


            Console.SetCursorPosition(primaryCursPosLeft, primaryCursPosTop);
            Console.WriteLine("Load for (seconds):");
            Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);
            float userNum = 1; // 1 as default
            do
            {
                var input = Console.ReadLine();
                if (input.Any(c => char.IsLetter(c)))
                {
                    Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);
                    Console.WriteLine("Value cannot be a letter");
                    Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);

                }
                else
                {
                    userNum = float.Parse(input);
                    break;
                }
            } while (true);
            float milliSeconds = userNum * 1000;

            Console.CursorVisible = false;
            await ShowLoading(milliSeconds);

            //WriteLine("Loading");
            WriteLine("Finished Loading");
            Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);
            Console.CursorVisible = true;
            Console.WriteLine("Press any key to exit..");
            Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);

            Console.ReadKey();

        }

        static void WriteLine(string text)
        {
            Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);
            Console.WriteLine(text);
            Console.SetCursorPosition(primaryCursPosLeft, Console.CursorTop + 1);


        }

        static async Task ShowLoading(float loadingDurationInMilliSeconds)
        {
            float segmentedLoadingDuration = loadingDurationInMilliSeconds / 600;

            stopwatch.Start();
            //var t = Task.Run(() => ShowElapsedTime());
            //t.Wait();
            //ShowElapsedTime();

            for (float i = 0; i < segmentedLoadingDuration; i++)
            {


                WriteLine(" / Loading \\ ");
                //System.Threading.Thread.Sleep(150);
                await Task.Delay(loadingFramesDuration);
                //Console.Clear();
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);
                WriteLine(" - Loading | ");
                await Task.Delay(loadingFramesDuration);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);
                WriteLine(" \\ Loading / ");
                await Task.Delay(loadingFramesDuration);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);
                WriteLine(" | Loading - ");
                await Task.Delay(loadingFramesDuration);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);

            }


        }

        public static Task<string> ShowElapsedTime()
        {
            do
            {
                return Task.FromResult(Console.Title = "Time elapsed: " + stopwatch.Elapsed.Seconds.ToString());
            }
            while (true);


        }


    }
}
