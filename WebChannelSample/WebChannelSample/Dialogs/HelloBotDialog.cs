using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;

namespace WebChannelSample.Dialogs
{
    public class HelloBotDialog : Dialog
    {
        [Expression("Hello Bot")]
        public void HelloIntent(Result result)
        {
            result.SendResponse("Hello there! I am Oscova.");
        }
    }
}