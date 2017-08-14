using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace MyAiVoice
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer Voice = new SpeechSynthesizer();
        Choices list = new Choices();
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();


            list.Add(new String[] { "hello", "who made you" });

            Grammar gr = new Grammar(new GrammarBuilder(list));



            try
            {

                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {

                throw;
            }


            Voice.SelectVoiceByHints(VoiceGender.Female);

            Voice.Speak("Hello Master, How can I help you");

            InitializeComponent();
        }

        public void say(String h)
        {
            Voice.Speak(h);
        }

        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            if (r == "hello")
            {
                say("Hello Master");
            }

            if (r == "who made you")
            {
                say("My beautifull master and amazing programmer, Levi");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
