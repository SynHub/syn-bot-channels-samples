using System;
using System.Web;
using Syn.Automation.Chat;

namespace Automated_Live_Chat_Demo
{
    public partial class ChatService : System.Web.UI.Page
    {

        private static readonly ChatAgent Agent;
        static ChatService()
        {
            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            Agent = new ChatAgent
            {
                ServiceUrl = websiteUrl + "/ChatService.aspx", 
                ResourceUrl = websiteUrl + "/Assistant", 
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