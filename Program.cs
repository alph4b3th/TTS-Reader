using TTS_Reader.Services;
//using TTS_Reader.;

namespace TTS_Reader

{
    internal class Program
    {
        static async Task<string> ExtractText(string url)
        {
            var extractor = new WebTextExtractorService();
            string text = await extractor.ExtractTextAsync(url);

            return text;
        }

        static async Task Main(string[] args)
        {
            var tts = new KokoroService();
          
            while (true)
            {
                Console.WriteLine("URL>>> OR exit");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }

                string extracted = await ExtractText(input);
                tts.Speak(extracted);   
            }
            
            
        }
    }
}
