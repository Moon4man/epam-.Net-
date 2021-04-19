using System;

namespace Delegate1
{
    class ThirdTask
    {
        static Action<string, DateTime, int, int> TicketInfo;

        public static void Run()
        {
            Console.WriteLine("\ntask 3:");

            TicketInfo = DisplayInfo;

            Random random = new Random();
            TicketInfo?.Invoke("20th Century Limited", DateTime.Now, random.Next(1, 20), random.Next(1, 50));
            TicketInfo?.Invoke("Trans-Siberian Express", DateTime.Now, random.Next(1, 20), random.Next(1, 50));
            TicketInfo?.Invoke("Orient Express", DateTime.Now, random.Next(1, 20), random.Next(1, 50));
            Console.ReadKey();
        }

        public static void DisplayInfo(string trainName, DateTime arriveTime, int coachNumber, int seatNumber)
        {
            Console.WriteLine(
                $"ticket info:\n" +
                $"train name: {trainName}\n" +
                $"arrive time: {arriveTime}\n" +
                $"coach number: {coachNumber}\n" +
                $"seat number: {seatNumber}\n");
        }
    }
}