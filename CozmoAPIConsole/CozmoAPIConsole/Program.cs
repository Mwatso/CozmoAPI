using cozmoapi;
using cozmoapi.Actions;
using cozmoapi.Enums;
using System;
using System.Threading;

namespace CozmoAPIConsole
{
    class Program
    {
        private string[] commands = { "quit" };

        public const string _adbPath = "C:\\Users\\mwats\\Android\\platform-tools_r28.0.1-windows\\platform-tools\\adb.exe";
        public const string _targetIP = "127.0.0.1";
        public const int _targetPort = 5106;

        private bool _running = true;
        public bool isRunning
        {
            get
            {
                return _running;
            }
            set
            {
                _running = value;
            }
        }

        private Anki.Cozmo.SdkConnection _connection;

        public void Execute()
        {
            _connection = new Anki.Cozmo.SdkConnection(_adbPath, _targetIP, _targetPort);
            while (isRunning)
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1);
                }
                // prompt for input
                Console.Write("> ");
                // get input {BLOCKING}
                string input = Console.ReadLine();
                // process input
                input = input.ToLower();
                switch (input)
                {
                    case "connect":
                        _connection.Connect();
                        break;

                    case "disconnect":
                        _connection.Disconnect();
                        break;

                    case "set":

                        movement.SetLiftHeight(_connection, 100f);

                        break;

                    case "quit":
                        _connection.Disconnect();
                        isRunning = false;
                        break;

                    case "help":
                        Console.WriteLine("Cozmo Commands:");
                        ActionEnums[] actions = utilities.GetEnumValues<ActionEnums>();
                        foreach (ActionEnums action in actions)
                        {
                            Console.WriteLine(" - {0}", action);
                        }
                        Console.WriteLine("Console Commands:");
                        foreach(string command in commands)
                        {
                            Console.WriteLine(" - {0}", command);
                        }
                        break;

                    default:
                        Console.WriteLine(string.Format("'{0}' not recognized, type 'help' for a list of known commands", input));
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Cozmo API Console";
            Program app = new Program();
            app.Execute();
        }
    }
}
