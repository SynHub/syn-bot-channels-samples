using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using Syn.Bot.Oscova.Entities;

namespace WidgetChannelSample.OscovaDialogs
{
    public class HelloBotDialog : Dialog
    {
        [Expression("@start")]
        public void HelloIntent(Context context, Result result)
        {
            result.SendResponse("Hello there! I am Oscova.");
            context.Add("all-user-message", 100);
        }

        [Expression("@sys.text")]
        [Context("all-user-message")]
        public void RepeatUserMessage(Result result)
        {
            result.SendResponse($"You typed: {result.Entities.OfType<TextEntity>()}");
        }
    }
}