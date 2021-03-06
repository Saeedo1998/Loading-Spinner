using System.Diagnostics;
using System.Reflection;

namespace Loading_Spinner
{
    class Program
    {
        public static Stopwatch stopwatch = new();

        public static int loadingFramesDuration = 75; // (MilliSeconds)
        public static float f_loadingDurationInMilliSeconds;

        public static string s_AppName;
        static async Task Main(string[] args)
        {
            //Initialize program
            var myType = typeof(Program);
            s_AppName = myType.Namespace;
            Console.Title = s_AppName;

            Console.CursorVisible = true;

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ShowElapsedTime();
            }).Start();

            CustomWrite.WriteFirstLine("Load for (seconds):");

            f_loadingDurationInMilliSeconds = GetUserInput() * 1000;

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
            //CustomWrite.WriteLine(DisplayMessage.Quit.promptPressAnyKey);
            CustomWrite.WriteLine(DisplayMessage.Program.promptRestart);

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                RestartProgram();
                //CustomWrite.WriteLine(Assembly.GetExecutingAssembly().Location);
            }

            //else 

            //exit program


        }
        public string GetThisNamespace()
        {
            return GetType().Namespace;
        }

        static void RestartProgram()
        {
            //incompatible for some reason
            // Starts a new instance of the program itself
            //System.Diagnostics.Process.Start(Application.ExecutablePath);

            // Closes the current process
            //Environment.Exit(0);



            //throws error
            //var fileName = Assembly.GetExecutingAssembly().Location;
            //Process.Start(fileName);


            Console.Clear();
            Console.Title = s_AppName;

            //Start process, friendly name is something like MyApp.exe (from current bin directory)
            Process.Start(AppDomain.CurrentDomain.FriendlyName);

            //Close the current process
            Environment.Exit(0);
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
                    Console.Title = s_AppName +
                        " - Time elapsed: " + stopwatch.Elapsed.Seconds.ToString();/* + "user specified time: " + s_loadingDurationInMilliSeconds;*/
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
                if (stopwatch.ElapsedMilliseconds >= f_loadingDurationInMilliSeconds)
                {
                    stopwatch.Stop();
                }
            } while (true);
        }


    }
}
