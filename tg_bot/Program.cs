using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using AIMLbot;
using System.Linq;
using System.IO;
using System.Net;

namespace Awesome
{
    class Program
    {
        static ITelegramBotClient botClient;
        static readonly Bot AI = new Bot(); // This defines the object "AI" To hold the bot's infomation
        static User myUser;

        static bool silenced = false;
        static bool read_everything = false;

        static void Main()
        {
            AI.loadSettings(); // This loads the settings from the config folder
            AI.loadAIMLFromFiles(); // This loads the AIML files from the aiml folder
            AI.isAcceptingUserInput = false; // This swithes off the bot to stop the user entering input while the bot is loading
            myUser = new User("Username", AI); // This creates a new User called "Username", using the object "AI"'s information.
            AI.isAcceptingUserInput = true; // This swithces the user input back on

            WebProxy myproxy = new WebProxy("189.90.248.75", 8080);
            botClient = new TelegramBotClient("779688868:AAE1pk1LpLttyj9Mmn2WV5Sn-VJfoAr_7Lw", myproxy);

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                bool mention = e.Message.EntityValues != null && e.Message.EntityValues.Contains("@team99_bot");
                bool reply = e.Message.ReplyToMessage != null && e.Message.ReplyToMessage.From.Username == "team99_bot";

                var input = e.Message.Text;
                if (!silenced && mention && input.StartsWith("SILENCE") || !silenced && input.StartsWith("SILENCE_ALL"))
                {
                    silenced = true;
                    Console.WriteLine($"Silenced in chat {e.Message.Chat.Id} at {e.Message.Date}.");
                    return;
                }
                if (silenced && mention && input.StartsWith("UNSILENCE") || silenced && input.StartsWith("UNSILENCE_ALL"))
                {
                    silenced = false;
                    Console.WriteLine($"Unsilenced in chat {e.Message.Chat.Id} at {e.Message.Date}.");
                    return;
                }
                if (!silenced && mention && input.StartsWith("REPORT") || !silenced && input.StartsWith("REPORT_ALL"))
                {
                    await botClient.SendTextMessageAsync(
                        replyToMessageId: e.Message.MessageId,
                        chatId: e.Message.Chat,
                        text: "Я жив. А ты?"
                        );
                    Console.WriteLine($"Reported in chat {e.Message.Chat.Id} at {e.Message.Date}.");
                    return;
                }
                if (mention && input.StartsWith("BLABER_ON") || input.StartsWith("BLABER_ON_ALL"))
                {
                    read_everything = true;
                    Console.WriteLine($"BLABER_ON in chat {e.Message.Chat.Id} at {e.Message.Date}.");
                    return;
                }
                if (mention && input.StartsWith("BLABER_OFF") || input.StartsWith("BLABER_OFF_ALL"))
                {
                    read_everything = false;
                    Console.WriteLine($"BLABER_OFF in chat {e.Message.Chat.Id} at {e.Message.Date}.");
                    return;
                }

                if (!mention && !reply && !read_everything || silenced)
                    return;

                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} at {e.Message.Date}.");

                using (StreamWriter sw = File.AppendText("../../../log.txt"))
                {
                    sw.WriteLine(e.Message.Date);
                    sw.WriteLine(e.Message.From.Username + ": " + input);
                }
                if (mention)
                    input = input.Replace("@team99_bot", ""); // remove mention
                Request r = new Request(input, myUser, AI); // This generates a request using text from message, the user and the AI object's.
                Result res = AI.Chat(r); // This sends the request off to the object AI to get a reply back based of the AIML file's.

                await botClient.SendTextMessageAsync(
                    replyToMessageId: e.Message.MessageId,
                    chatId: e.Message.Chat,
                    text: res.Output == "" ? "Я не понял!!!!!!!" : res.Output
                    );

                using (StreamWriter sw = File.AppendText("../../../log.txt"))
                {
                    sw.WriteLine(res.Output == "" ? "Я не понял!!!!!!!" : res.Output);
                    sw.WriteLine();
                }
            }
        }
    }
}
