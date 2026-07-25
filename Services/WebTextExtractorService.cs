using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace TTS_Reader.Services
{
    internal class WebTextExtractorService
    {
        private readonly HttpClient _httpClient;

        public WebTextExtractorService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
                "(KHTML, like Gecko) Chrome/120.0 Safari/537.36"
            );
        }

        public async Task<string> ExtractTextAsync(string url)
        {
            string html = await _httpClient.GetStringAsync(url);

            var document = new HtmlDocument();
            document.LoadHtml(html);

            // Remove elementos que normalmente não fazem parte do conteúdo
            RemoveNodes(document, @"
                //script |
                //style |
                //nav |
                //footer |
                //header |
                //aside |
                //form |
                //button |
                //input |
                //textarea |
                //select |
                //noscript |
                //svg |
                //iframe |
                //table |
                //figure |
                //figcaption |
                //sup |
                //img
            ");

            // Tenta encontrar o conteúdo principal
            var content = document.DocumentNode.SelectSingleNode(
                "//article"
                + " | //main"
                + " | //*[@role='main']"
                + " | //*[@id='mw-content-text']"
                + " | //*[@class='mw-parser-output']"
            );

            // Se encontrou conteúdo principal, usa ele.
            // Caso contrário, usa o body.
            var root = content
                ?? document.DocumentNode.SelectSingleNode("//body")
                ?? document.DocumentNode;

            string text = root.InnerText;

            // Decodifica entidades HTML
            text = WebUtility.HtmlDecode(text);

            // Remove referências no formato [1], [2], [23] etc.
            text = Regex.Replace(
                text,
                @"\[\d+\]",
                ""
            );

            // Remove alguns textos comuns de navegação
            text = Regex.Replace(
                text,
                @"\[editar\]|\[editar código\]",
                "",
                RegexOptions.IgnoreCase
            );

            // Normaliza espaços
            text = Regex.Replace(
                text,
                @"\s+",
                " "
            );

            return text.Trim();
        }

        private static void RemoveNodes(
            HtmlDocument document,
            string xpath
        )
        {
            var nodes = document.DocumentNode.SelectNodes(xpath);

            if (nodes == null)
                return;

            foreach (var node in nodes)
            {
                node.Remove();
            }
        }
    }
}