using TTS_Reader.Services;
//using TTS_Reader.;

namespace TTS_Reader

{
    internal class Program
    {
        static async Task<string> ExtractText(string url)
        {
            var extractor = new WebTextExtractorService();
            string text = await extractor.ExtractTextAsync(url) ?? string.Empty;

            return text;
        }

        static async Task Main(string[] args)
        {
            var tts = new KokoroService();
          
            while (true)
            {
                Console.WriteLine("Insira um artigo web (URL) ou exit para encerrar:");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Escreva algo válido!");
                    continue;
                }

                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                string extracted = await ExtractText(input);
                tts.Speak(extracted);   
            }
            
            
        }
    }
}
