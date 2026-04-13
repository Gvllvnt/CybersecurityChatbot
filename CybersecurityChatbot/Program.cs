//Cybersecurity Awareness Bot - Protecting South Africans Online
using System;
using System.Media;
using System.IO; 

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot - SA";
            Console.WindowWidth = 100;
            Console.WindowHeight = 35;
            Console.BufferHeight = 500;  
            Console.Clear();

            // Step 1: Play voice greeting
            PlayVoiceGreeting();

            // Step 2: Show ASCII art
            DisplayAsciiArt();

            // Step 3: Text greeting
            UIHelper.PrintHeader("WELCOME");

            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                UIHelper.WriteLineColor("Name cannot be empty. Please enter your name:", ConsoleColor.Red);
                name = Console.ReadLine();
            }

            Chatbot bot = new Chatbot();
            bot.SetUserName(name);

            UIHelper.TypeEffect($"\nHello, {name}! Welcome to the Cybersecurity Awareness Bot.", 40);
            UIHelper.WriteLineColor("I'm here to help you stay safe online in South Africa.\n", ConsoleColor.Green);

            // Step 4: Main conversation loop
            bool running = true;
            while (running)
            {
                UIHelper.PrintBorder();
                Console.Write($"{name}: ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    UIHelper.WriteLineColor("Please type something. Try asking about passwords, phishing, or safe browsing.", ConsoleColor.Yellow);
                    continue;
                }

                if (userInput.ToLower() == "exit" || userInput.ToLower() == "quit")
                {
                    UIHelper.WriteLineColor($"\nGoodbye, {name}! Stay safe online! 🔒", ConsoleColor.Cyan);
                    running = false;
                    continue;
                }

                string response = bot.GetResponse(userInput);
                UIHelper.WriteColor("Bot: ", ConsoleColor.Yellow);
                UIHelper.TypeEffect(response, 30);
                Console.WriteLine();

                // ADD THIS: Auto-scroll to bottom after each response
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        static void PlayVoiceGreeting()
        {
            if (BuildConfig.IsGitHubActions)
            {
                Console.WriteLine("(Running on GitHub Actions - voice greeting skipped)");
                return;
            }

            string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "Greeting.wav");
            if (File.Exists(audioPath))
            {
                try
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.PlaySync();
                    }
                }
                catch (Exception ex)
                {
                    UIHelper.WriteLineColor($"(Could not play voice greeting: {ex.Message})", ConsoleColor.DarkYellow);
                }
            }
            else
            {
                UIHelper.WriteLineColor("(Voice greeting file not found - continuing with text only)", ConsoleColor.DarkYellow);
            }
        }

        static string GetAsciiArt()
        {
            return @"
╔════════════════════════════════════════╗
║                                        ║
║    🔒 CYBERSECURITY AWARENESS BOT 🔒   ║
║    Protecting South Africans Online    ║
║                                        ║
╚════════════════════════════════════════╝";
        }

        static void DisplayAsciiArt()
        {
            string art = GetAsciiArt();
            UIHelper.WriteLineColor(art, ConsoleColor.Cyan);
        }
    }
}