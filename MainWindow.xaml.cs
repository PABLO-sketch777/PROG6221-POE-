using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Windows;

namespace ConsoleApp1
{
    public partial class MainWindow : Window
    {
        SpeechSynthesizer speaker = new SpeechSynthesizer();

        Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>()
        {
            { "phishing", new List<string>
                {
                    "Phishing is when attackers trick you into giving sensitive information through fake emails or websites.",
                    "Always verify links and never share personal details through suspicious messages."
                }
            },
            { "password", new List<string>
                {
                    "Use strong passwords with uppercase, lowercase, numbers, and symbols.",
                    "Avoid reusing passwords and consider using a password manager."
                }
            },
            { "malware", new List<string>
                {
                    "Malware is harmful software that damages or steals data.",
                    "Install antivirus software and avoid downloading unknown files."
                }
            }
        };

        public MainWindow()
        {
            InitializeComponent();
            GreetUser();
        }

        private void GreetUser()
        {
            string greeting = "Welcome to CyberSafe! Stay alert and protect your digital life.";
            ChatBox.Items.Add("Bot: " + greeting);
            speaker.SpeakAsync(greeting);
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.ToLower();
            ChatBox.Items.Add("You: " + UserInput.Text);

            bool found = false;

            foreach (var key in responses.Keys)
            {
                if (input.Contains(key))
                {
                    foreach (var reply in responses[key])
                    {
                        ChatBox.Items.Add("Bot: " + reply);
                        speaker.SpeakAsync(reply);
                    }
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                string defaultMsg = "Ask me about phishing, passwords, or malware.";
                ChatBox.Items.Add("Bot: " + defaultMsg);
                speaker.SpeakAsync(defaultMsg);
            }

            UserInput.Text = "";
        }
    }
}
