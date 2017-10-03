using System;
using System.IO;
using Syn.Bot.Channels.Telegram;
using Syn.Bot.Oscova;
using Syn.Bot.Siml;
using TelegramChannelSample.Dialogs;

namespace TelegramChannelSample
{
    internal class Program
    {
        private const string TelegramAccessToken = "YOUR_TELEGRAM_API_ACCESS_TOKEN";

        private static void Main(string[] args)
        {
            //Uncomment any ONE of the following to test response.

            //LaunchSimlBot();
            //LaunchOscovaBot();
        }

        private static void LaunchSimlBot()
        {

            var telegramChannel = new TelegramChannel<SimlBot>(TelegramAccessToken, new SimlBot());
            const string kbFilePath = "SimlKB.simlpk";
            telegramChannel.Bot.PackageManager.LoadFromString(File.ReadAllText(kbFilePath));

            telegramChannel.Client.StartReceiving();
            SimlBot.Logger.LogReceived += (sender, args) =>
            {
                Console.WriteLine(args);
            };
            Console.WriteLine("SIML Bot is now Online.");
            Console.ReadLine();
            telegramChannel.Client.StopReceiving();
        }

        private static void LaunchOscovaBot()
        {
            var telegramChannel = new TelegramChannel<OscovaBot>(TelegramAccessToken, new OscovaBot());
            telegramChannel.Bot.Dialogs.Add(new HelloBotDialog());
            telegramChannel.Bot.Trainer.StartTraining();
            telegramChannel.Client.StartReceiving();
            OscovaBot.Logger.LogReceived += (sender, args) =>
            {
                Console.WriteLine(args);
            };
            Console.WriteLine("OSCOVA Bot is now Online.");
            Console.WriteLine("Type \"Hello Bot\" in your Telegram client to check response.");
            Console.ReadLine();
            telegramChannel.Client.StopReceiving();
        }
    }
}