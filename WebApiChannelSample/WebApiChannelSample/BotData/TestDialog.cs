using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;

namespace WebApiChannelSample.BotData
{
    internal class TestDialog : Dialog
    {
        [Expression("Test")]
        [Expression("Hello bot")]
        public void TestIntent(Context context, Result result)
        {
            result.SendResponse("Hello Developer!");
        }
    }
}