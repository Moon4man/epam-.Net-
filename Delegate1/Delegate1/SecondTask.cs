using System;

namespace Delegate1
{
    class SecondTask
    {
        static event Action<string> Notify;

        class Ping
        {
            public static void ReceivePong(int i)
            {
                Notify?.Invoke(i + ". Ping received Pong");

                if (i < 5)
                {
                    i++;
                    Pong.ReceivePing(i);
                }
            }
        }

        class Pong
        {
            public static void ReceivePing(int i)
            {
                Notify?.Invoke(i + ". Pong received Ping");

                if (i < 5)
                {
                    i++;
                    Ping.ReceivePong(i);
                }
            }
        }

        public static void Run()
        {
            Console.WriteLine("\ntask 2:");

            Notify = DisplayMessage;

            Ping.ReceivePong(1);
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}