using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Syn.Bot.Channels.Web;
using Syn.Bot.Oscova;
using Syn.Bot.Siml;
using WidgetChannelSample.OscovaDialogs;

namespace WidgetChannelSample
{
    public partial class BotService : Page
    {
        private static WidgetChannel<SimlBot> _simlBotChannel;
        private static WidgetChannel<OscovaBot> _oscovaBotChannel;

        static BotService()
        {
            //LaunchSimlBot();
            LaunchOscovaBot();
        }

        private static void LaunchSimlBot()
        {
            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            var simlBot = new SimlBot();

            _simlBotChannel = new WidgetChannel<SimlBot>(simlBot)
            {
                ServiceUrl = websiteUrl + "/BotService.aspx",
                ResourceUrl = websiteUrl + "/BotResource",
            };

            using (var webClient = new WebClient())
            {
                var result = webClient.DownloadString(_simlBotChannel.ResourceUrl + "//package.txt");
                simlBot.PackageManager.LoadFromString(result);
            }
        }

        private static void LaunchOscovaBot()
        {
            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            var oscovaBot = new OscovaBot();
            oscovaBot.Dialogs.Add(new HelloBotDialog());
            oscovaBot.CreateRecognizer("start", new Regex(@"(?<!/)(/(?:start))(?(?<=\w)\b)", RegexOptions.IgnoreCase));
            oscovaBot.Trainer.StartTraining();

            _oscovaBotChannel = new WidgetChannel<OscovaBot>(oscovaBot)
            {
                ServiceUrl = websiteUrl + "/BotService.aspx",
                ResourceUrl = websiteUrl + "/BotResource",
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // _simlBot?.Process(Request, Response);
            _oscovaBotChannel?.Process(Request, Response);
        }
    }
}