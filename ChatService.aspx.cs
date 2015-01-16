using System;
using Syn.Automation.Chat;

namespace Automated_Live_Chat_Demo
{
    public partial class ChatService : System.Web.UI.Page
    {

        private static readonly ChatAgent Agent;
        static ChatService()
        {
            Agent = new ChatAgent
            {
                ServiceUrl = "http://localhost:50977/ChatService.aspx", //Change localhost:50977 to your Website URL
                ResourceUrl = "http://localhost:50977/Assistant", //Change localhost:50977 to your Website URL
                Name = "Maya",
                Title = "Syn Web Assistant",
                Intro = "Hi I am Maya, I am here to help you with your questions.",
                InputText = "What can I help you with?",
                Footer = "Syn",
                FooterLink = "http://www.syn.co.in",
                RestartId = "restart",
                PackageFileName = "Package.txt"
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Agent.Process(Request, Response);
        }
    }
}