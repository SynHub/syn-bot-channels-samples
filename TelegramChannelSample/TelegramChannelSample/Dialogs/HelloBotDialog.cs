using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;

namespace TelegramChannelSample.Dialogs
{
    class HelloBotDialog : Dialog
    {
        [Expression("Hello Bot")]
        public void Hello(Context context, Result result)
        {
            result.SendResponse("Hello there! I am Oscova.");
        }
    }
}