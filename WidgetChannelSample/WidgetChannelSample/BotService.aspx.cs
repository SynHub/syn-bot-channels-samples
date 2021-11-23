using System;
using System.Web;
using System.Web.UI;
using Syn.Bot.Channels.Testing;
using Syn.Bot.Channels.Widget;
using Syn.Bot.Oscova;

namespace WidgetChannelSite
{
    public partial class ChatService : Page
    {
        private static WidgetChannel WidgetChannel { get;  }
        static ChatService()
        {
            var bot = new OscovaBot();
            WidgetChannel = new WidgetChannel(bot);

            //Add the pre-built channel test dialog.
            bot.Dialogs.Add(new ChannelTestDialog(bot));
            bot.Trainer.StartTraining();

            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            WidgetChannel.ServiceUrl = websiteUrl + "/BotService.aspx";
            WidgetChannel.ResourceUrl = websiteUrl + "/BotResources";

            //WidgetChannel.ExportResources(@"D:\WidgetResources");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WidgetChannel.Process(Request, Response);
        }
    }
}