using System;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private string userName;

        public void SetUserName(string name)
        {
            userName = name;
        }

        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "I didn't quite understand that. Could you rephrase?";
            }

            string input = userInput.ToLower().Trim();

            if (input.Contains("how are you"))
            {
                return $"I'm functioning well, {userName}! Thanks for asking. How can I help you stay safe online today?";
            }
            else if (input.Contains("purpose") || input.Contains("what can you do"))
            {
                return $"My purpose, {userName}, is to educate South African citizens about cybersecurity threats like phishing, weak passwords, and unsafe browsing.";
            }
            else if (input.Contains("what can i ask"))
            {
                return $"You can ask me about:{Environment.NewLine}- Password safety{Environment.NewLine}- Phishing scams{Environment.NewLine}- Safe browsing habits{Environment.NewLine}- Or just say 'How are you?' to chat!";
            }
            else if (input.Contains("password"))
            {
                return $"🔐 Password tip, {userName}: Use a mix of letters, numbers, and symbols. Never reuse passwords across sites!";
            }
            else if (input.Contains("phish"))
            {
                return $"🎣 Phishing warning, {userName}: Never click suspicious links in emails or SMS. Legit companies won't ask for your password via email.";
            }
            else if (input.Contains("brows") || input.Contains("safe"))
            {
                return $"🌐 Safe browsing tip, {userName}: Look for 'https://' and the padlock icon before entering personal info.";
            }
            else
            {
                return $"I didn't quite understand that, {userName}. Could you rephrase? Try asking about passwords, phishing, or safe browsing.";
            }
        }
    }
}