using System;
using Syn.Bot.Channels.Web;
using Syn.Bot.Oscova;
using WebApiChannelSample.BotData;

namespace WebApiChannelSample
{
    internal class Program
    {
        private static void Main()
        {
            var bot = new OscovaBot();
            bot.Dialogs.Add(new TestDialog());
            bot.Trainer.StartTraining();

            var botServer = new WebApiChannel<OscovaBot>(bot,"http://localhost:8086/bot");

            //In case the server generates a log, write it to console.
            botServer.Logger.LogReceived += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.Log);
            };

            botServer.Start();

            //Once the server is started you can call API url using the below format.
            //http://localhost:8086/bot?userid={USER-ID}&query={USER-MESSAGE}

            //Example: http://localhost:8086/bot?userid=12345&query=test

            Console.WriteLine($"Bot Server is online at '{botServer.Url}'. Press any key to stop server.");
            Console.ReadLine();
            botServer.Stop();
        }
    }
}