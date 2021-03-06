﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace recognitionTest
{
    class Program
    {
        static SpeechSynthesizer voice = new SpeechSynthesizer();
        static void Main(string[] args)
        {
            

            voice.Speak("Hello Master, how can i help you?");

            // Create an in-process speech recognizer for the en-US locale.
            using (
            SpeechRecognitionEngine recognizer =
              new SpeechRecognitionEngine(
                new System.Globalization.CultureInfo("en-US")))
            {

                // Create and load a dictation grammar.
                recognizer.LoadGrammar(new DictationGrammar());

                // Add a handler for the speech recognized event.
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer.
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open.
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        static void say(String h)
        {
            voice.Speak(h);
        }

        
        // Handle the SpeechRecognized event.
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            Console.WriteLine("Recognized text: " + e.Result.Text);

            if (r == "hello")
            {
                say("hi");
            }

            if (r == "shutdown" || r == "Shutdown" )
            {
                say("Goodbye Master");
                Console.Clear();
                Environment.Exit(0);
                
                
            }
            if (r == "who do I love")
            {
                say("My master is in love with gittah!");
            }

            if (r == "show my channel" || r == "Show my channel" )
            {
                say("Yes master");
                Process.Start("chrome.exe", "https://www.youtube.com/channel/UC5kYaT5QtOaN2ScPyXT7Pdg");
            }
            if (r == "lock computer" || r == "lock PC" || r == "Lock computer" || r == "locke computer" || r == "Locke computer" )
            {
                say("Locking computer now");
                System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
            }
            if (r == "PC shutdown" || r == "BC shutdown")
            {
                say("Self Destruct!");
                System.Diagnostics.Process.Start("shutdown", "/s /t 0");
            }
            if (r == "Kenley" || r == "canny" || r == "Kenny")
            {
                say("Kenley happy birthday");
            }
        }
    }
}

