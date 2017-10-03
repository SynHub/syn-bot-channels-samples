using System;
using System.Net;
using System.Web;
using Syn.Bot.Channels.Web;
using Syn.Bot.Oscova;
using Syn.Bot.Siml;
using WebChannelSample.Dialogs;

namespace WebChannelSample
{
    public partial class ChatService : System.Web.UI.Page
    {
        private static WebChannel<SimlBot> _simlBot;
        private static WebChannel<OscovaBot> _oscovaBot;

        static ChatService()
        {
            //Uncomment any "ONE" of the following to use desired architecture.

            //LaunchSimlBot();
            //LaunchOscovaBot();
        }

        private static void LaunchSimlBot()
        {
            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            var simlBot = new SimlBot();

            _simlBot = new WebChannel<SimlBot>(simlBot)
            {
                ServiceUrl = websiteUrl + "/ChatService.aspx",
                ResourceUrl = websiteUrl + "/Assistant",
                Name = "Maya",
                Title = "Syn Web Assistant",
                Intro = "Hi I am Maya, I am here to help you with your questions.",
                InputText = "What can I help you with?",
                Footer = "Syn",
                FooterLink = "http://www.syn.co.in",
            };

            using (var webClient = new WebClient())
            {
                var result = webClient.DownloadString(_simlBot.ResourceUrl + "//package.txt");
                simlBot.PackageManager.LoadFromString(result);
            }
        }

        private static void LaunchOscovaBot()
        {
            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            var oscovaBot = new OscovaBot();
            oscovaBot.Dialogs.Add(new HelloBotDialog());
            oscovaBot.Trainer.StartTraining();

            _oscovaBot = new WebChannel<OscovaBot>(oscovaBot)
            {
                ServiceUrl = websiteUrl + "/ChatService.aspx",
                ResourceUrl = websiteUrl + "/Assistant",
                Name = "Maya",
                Title = "Syn Web Assistant",
                Intro = "Hi I am Maya, I am here to help you with your questions.",
                InputText = "What can I help you with?",
                Footer = "Syn",
                FooterLink = "http://www.syn.co.in",
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _simlBot?.Process(Request, Response);
            _oscovaBot?.Process(Request, Response);
        }
    }
}