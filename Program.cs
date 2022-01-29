using System.Diagnostics;

namespace Loading_Spinner
{
    class Program
    {
        public static Stopwatch stopwatch = new();

        public static int loadingFramesDuration = 75; // (MilliSeconds)
        public static float s_loadingDurationInMilliSeconds;
        static async Task Main(string[] args)
        {
            Console.CursorVisible = true;

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ShowElapsedTime();
            }).Start();

            Console.SetCursorPosition(CustomWrite.primaryCursPosLeft, CustomWrite.primaryCursPosTop);
            Console.WriteLine("Load for (seconds):");
            Console.SetCursorPosition(CustomWrite.primaryCursPosLeft, Console.CursorTop + 1);


            s_loadingDurationInMilliSeconds = GetUserInput() * 1000;

            Console.CursorVisible = false;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                ControlStopWatch();
            }).Start();
            
            await ControlLoadingSpinner();

            //WriteLine("Loading");
            CustomWrite.WriteLine(DisplayMessage.Success.finishedLoading);
            Console.CursorVisible = true;
            CustomWrite.WriteLine(DisplayMessage.Quit.promptPressAnyKey);

            Console.ReadKey();

        }

        

        static float GetUserInput()
        {
            float num;
            do
            {
                var input = Console.ReadLine();
                if (Validate.IsInputLetter(input))
                {
                    num = float.Parse(input);
                    return num;
                }
            } while (true);
        }

        static async Task ControlLoadingSpinner()
        {
            //float segmentedLoadingDuration = loadingDurationInMilliSeconds / 600;
            //var t = Task.Run(() => ShowElapsedTime());
            //t.Wait();
            //ShowElapsedTime();
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    /* run your code here */

            //}).Start();

            //if enough time has passed as per user input
            
            do
            {
                if (stopwatch.IsRunning)
                {
                    CustomWrite.WriteLine(" / Loading \\ ");
                    //System.Threading.Thread.Sleep(150);
                    await Task.Delay(loadingFramesDuration);
                    //Console.Clear();
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);
                    CustomWrite.WriteLine(" - Loading | ");
                    await Task.Delay(loadingFramesDuration);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);
                    CustomWrite.WriteLine(" \\ Loading / ");
                    await Task.Delay(loadingFramesDuration);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);
                    CustomWrite.WriteLine(" | Loading - ");
                    await Task.Delay(loadingFramesDuration);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 3);
                }
                else
                {
                    break;
                }

            } while (true);
        }

        static async Task ShowElapsedTime()
        {
            do
            {
                if (stopwatch.IsRunning)
                {
                    Console.Title = "Time elapsed: " + stopwatch.Elapsed.Seconds.ToString() + "user specified time: " + s_loadingDurationInMilliSeconds;
                    //return Task.FromResult(Console.Title = "Time elapsed: " + stopwatch.Elapsed.Seconds.ToString());
                }
            }
            while (true);


        }

        static async Task ControlStopWatch()
        {
            stopwatch.Start();

            do
            {
                if (stopwatch.ElapsedMilliseconds >= s_loadingDurationInMilliSeconds)
                {
                    stopwatch.Stop();
                }
            } while (true);
        }


    }
}
