
 using System;              // Core namespace for console input/output
 using System.Media;        // For SoundPlayer (optional audio)
using System.Collections.Generic; // For lists and dictionaries
using System.Linq;          // For LINQ operations
 
 namespace ConsoleApp1
 {
     class Program
     {
        // Dictionary to hold cybersecurity topics and their responses
        private static readonly Dictionary<string, string> Topics = new Dictionary<string, string>
        {
            { "phishing", "Phishing is a cyber attack where attackers trick you into revealing sensitive information like passwords or credit card details by posing as trustworthy entities via email, phone, or fake websites. Always verify the sender and avoid clicking suspicious links." },
            { "passwords", "Strong passwords should be long (at least 12 characters), unique, and include a mix of uppercase, lowercase, numbers, and symbols. Use a password manager and enable two-factor authentication (2FA) wherever possible." },
            { "malware", "Malware includes viruses, ransomware, spyware, and trojans. Protect yourself by keeping antivirus software updated, avoiding suspicious downloads, and not opening unknown email attachments." },
            { "wifi", "Secure your Wi-Fi network with WPA3 encryption and a strong, unique password. Avoid public Wi-Fi for sensitive activities, and consider using a VPN for added protection." },
            { "updates", "Regularly update your operating system, software, and apps to patch known security vulnerabilities. Enable automatic updates to stay protected against emerging threats." },
            { "social engineering", "Social engineering manipulates people into divulging confidential information. Be wary of unsolicited requests for information, even from seemingly trusted sources." },
            { "encryption", "Encryption protects data by converting it into a coded format. Use encrypted connections (HTTPS), full-disk encryption, and secure messaging apps to safeguard your information." },
            { "backups", "Regularly back up your data to external drives or cloud services. Use the 3-2-1 rule: 3 copies, 2 different media types, 1 offsite. Test backups periodically." },
            { "ransomware", "Ransomware encrypts your files and demands payment. Prevent it by avoiding suspicious links, keeping software updated, and having secure backups ready." },
            { "two-factor authentication", "2FA adds an extra layer of security by requiring a second form of verification beyond your password, such as a code sent to your phone." }
        };

         static void Main(string[] args)
         {
             // Step 1: Play a greeting sound (optional)
             PlayVoiceGreeting();
 
             // Step 2: Show ASCII art logo
             ShowAsciiArtLogo();
 
             // Step 3: Print welcome message
             Console.WriteLine("Hey there! I'm Mr, your Cybersecurity Awareness Bot.");
            Console.WriteLine("I can help you learn about various cybersecurity topics.");
            Console.WriteLine("Type 'help' for a list of topics, 'quiz' for a quick quiz, or 'exit' to quit.");
 
             // Step 4: Chat loop
             while (true)
             {
                 Console.Write("\nYou: ");
                string? userInput = Console.ReadLine()?.Trim().ToLower();
 
                 if (string.IsNullOrWhiteSpace(userInput))
                     continue;
 
                if (userInput == "exit" || userInput == "quit")
                 {
                    ShowFarewellMessage();
                     break;
                 }
 
                HandleUserInput(userInput);
             }
         }
 
         // Method to play a greeting sound
         static void PlayVoiceGreeting()
         {
             try
             {
#if WINDOWS
                 SoundPlayer player = new SoundPlayer("greeting.wav"); // Place a .wav file in project folder
                 player.Play();
#endif
             }
             catch
             {
                // Silently skip if sound file is not found
             }
         }
 
         // Method to show ASCII art logo
         static void ShowAsciiArtLogo()
         {
             Console.ForegroundColor = ConsoleColor.Cyan;
             Console.WriteLine(@"
    __  ___       _        _        _   
   /  |/  /__ ___| |__ ___| |_ __ _| |_ 
  / /|_/ / -_|_-< / /(_-<  _/ _` |  _|
 /_/  /_/\__/__/ \__/__/ \__\__,_|\__|
 ");
             Console.ResetColor();
            Console.WriteLine("Welcome to Mr. AutoBot - Cybersecurity Awareness Assistant");
            Console.WriteLine(new string('=', 60));
         }
 
        // Method to handle user input
        static void HandleUserInput(string input)
         {
            if (input == "help" || input == "topics")
            {
                ShowHelp();
            }
            else if (input == "quiz")
             {
                StartQuiz();
            }
            else
            {
                RespondToTopic(input);
            }
        }

        // Method to show help/topics
        static void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAvailable Topics:");
            Console.ResetColor();
            foreach (var topic in Topics.Keys.OrderBy(t => t))
            {
                Console.WriteLine($"- {topic}");
            }
            Console.WriteLine("\nCommands:");
            Console.WriteLine("- 'help' or 'topics': Show this list");
            Console.WriteLine("- 'quiz': Take a quick cybersecurity quiz");
            Console.WriteLine("- 'exit' or 'quit': Exit the application");
        }

        // Method to respond to topic queries
        static void RespondToTopic(string input)
        {
            var matchingTopic = Topics.Keys.FirstOrDefault(topic => input.Contains(topic));
            if (matchingTopic != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nTopic: {matchingTopic.ToUpper()}");
                Console.ResetColor();
                Console.WriteLine(Topics[matchingTopic]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSorry, I don't have information on that topic.");
                Console.ResetColor();
                Console.WriteLine("Type 'help' to see available topics or try rephrasing your question.");
            }
        }

        // Method to start a simple quiz
        static void StartQuiz()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n🛡️ Cybersecurity Quiz 🛡️");
            Console.ResetColor();
            Console.WriteLine("Answer the following questions (type your answer or 'skip' to move on):");

            var questions = new List<(string Question, string Answer)>
            {
                ("What does 'phishing' refer to?", "a cyber attack where attackers trick people into revealing sensitive information"),
                ("Why is two-factor authentication important?", "it adds an extra layer of security beyond just a password"),
                ("What should you do if you receive a suspicious email?", "do not click links or open attachments, report it"),
                ("What type of password is most secure?", "long, unique, with mixed characters"),
                ("What does encryption do?", "converts data into a coded format to protect it")
            };

            int score = 0;
            foreach (var (question, answer) in questions)
            {
                Console.WriteLine($"\n{question}");
                Console.Write("Your answer: ");
                string? userAnswer = Console.ReadLine()?.Trim().ToLower();
                if (userAnswer == "skip")
                {
                    Console.WriteLine("Skipped.");
                    continue;
                }
                if (!string.IsNullOrEmpty(userAnswer) && (userAnswer.Contains(answer.ToLower()) || answer.ToLower().Contains(userAnswer)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect. The answer is: {answer}");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nQuiz complete! Your score: {score}/{questions.Count}");
            Console.ResetColor();
            if (score == questions.Count)
            {
                Console.WriteLine("Excellent! You're a cybersecurity pro!");
            }
            else if (score >= questions.Count / 2)
            {
                Console.WriteLine("Good job! Keep learning about cybersecurity.");
            }
            else
            {
                Console.WriteLine("Don't worry, cybersecurity is important. Keep educating yourself!");
            }
        }

        // Method to show farewell message
        static void ShowFarewellMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThank you for chatting with Mr. AutoBot!");
            Console.WriteLine("Remember these key cybersecurity tips:");
            Console.ResetColor();
            Console.WriteLine("• Keep your software updated");
            Console.WriteLine("• Use strong, unique passwords");
            Console.WriteLine("• Be cautious with emails and links");
            Console.WriteLine("• Enable two-factor authentication");
            Console.WriteLine("• Back up your data regularly");
            Console.WriteLine("\nStay safe online! Goodbye.");
         }
     }
 }
