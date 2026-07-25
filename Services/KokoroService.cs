using KokoroSharp;
using KokoroSharp.Core;



namespace TTS_Reader.Services
{
    internal class KokoroService
    {
        private readonly KokoroTTS _tts;
        private readonly KokoroVoice _voice;

     

        public KokoroService()
        {
            _tts = KokoroTTS.LoadModel();
            _voice = KokoroVoiceManager.GetVoice("pf_dora");
            //KokoroVoiceManager.Voices.ForEach(v => Console.WriteLine($"Voice: {v.Name}"));

        }

        public void Speak(string text)
        {
            //_tts.Speak(text, _voice);
            _tts.SpeakFast(text, _voice);


        }

        

            
    }
}
