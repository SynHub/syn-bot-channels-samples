using System;
using System.IO;
using Syn.Bot.Channels.Common;
using Syn.Bot.Channels.Discord;
using Syn.Bot.Oscova;

namespace DiscordChannelSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var oscovaBot = new OscovaBot();

            //Channel Tester provides OscovaTestDialog.
            var tester = new ChannelTester(Directory.GetCurrentDirectory());
            
            oscovaBot.Dialogs.Add(tester.OscovaTestDialog);
            oscovaBot.Trainer.StartTraining();

            var discordChannel = new DiscordChannel<OscovaBot>(oscovaBot,"DISCORD_BOT_USER_TOKEN");
            discordChannel.Start().Wait();
           
            Console.WriteLine("Your Oscova Bot is now hosted as a Discord Bot. Press any key to exit.");
            Console.ReadKey();

            discordChannel.Stop().Wait();
        }
    }
}