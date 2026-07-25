# TTS-Reader

> Leitor de texto para voz (Text-to-Speech) simples, elegante e focado em produtividade.

Descrição
---------
TTS-Reader é um aplicativo .NET que converte texto em fala de forma rápida e prática. Ideal para leitura de artigos, documentos ou para acessibilidade — com suporte a múltiplas vozes e configurações de velocidade e idioma.

Motivação e origem do projeto
-----------------------------
Este projeto nasceu como um estudo de caso em C# por alph4b3th ("alph4" para os íntimos). O autor estava estudando C# ao desenvolver uma simulação de corrida em Godot 4 e preferiu usar C# em vez de GDScript. Ao explorar o ecossistema da linguagem, ficou fascinado com a facilidade de integrar soluções de inteligência artificial e a variedade de bibliotecas e frameworks disponíveis.

O objetivo prático do projeto foi criar um leitor de artigos para uso cotidiano: algo rápido de desenvolver e funcional o bastante para ouvir textos enquanto realiza outras atividades. Como Python lidera em IA, a pesquisa foi feita em C# da mesma forma que seria em Python, e encontrou-se facilmente uma biblioteca compatível — kokoro-tts — que se mostrou eficiente para aplicações em tempo real e de baixo custo.

O fluxo do aplicativo é simples: recebe uma URL, extrai o texto da página e faz a leitura em voz alta. Para a extração de texto da web foi utilizada IA — uma decisão prática, motivada pela intenção de priorizar o desenvolvimento do TTS em vez de gastar tempo escrevendo um webscraper e tratando lixo de HTML manualmente. Com isso, o objetivo principal foi cumprido: um leitor funcional, prático e rápido de desenvolver.

Recursos
--------
- Leitura de texto em tempo real a partir da área de transferência, arquivos ou URL
- Suporte a múltiplas vozes e idiomas (dependendo do sistema)
- Controle de velocidade e volume
- Interface enxuta e fácil de usar
- Execução em Windows com .NET 10

Requisitos
----------
- .NET 10 SDK ou Visual Studio 2026 (ou superior)
- Windows 10/11 (recursos de TTS dependem das vozes instaladas no sistema)

Instalação e execução
---------------------
1. Clone o repositório:

   git clone https://github.com/alph4b3th/TTS-Reader.git

2. Abra a solução no Visual Studio ou use a CLI:

   dotnet build
   dotnet run --project src/TTS-Reader

Observação: ajuste o caminho do projeto conforme a estrutura da solução.

Uso
---
- Abra o aplicativo e cole ou carregue o texto que deseja ouvir.
- Ajuste voz, velocidade e volume nas opções.
- Use teclas de atalho (se implementadas) para controlar a reprodução.

Contribuição
------------
Contribuições são bem-vindas. Abra issues para bugs ou sugestões e envie pull requests para melhorias. Siga as práticas do repositório e mantenha commits pequenos e claros.

Licença
-------
Adicione aqui a licença do projeto (ex.: MIT). Se preferir, podemos incluir um arquivo LICENSE separado.

Contato
-------
Para dúvidas ou colaboração, abra uma issue no repositório ou envie mensagens através do GitHub: https://github.com/alph4b3th

---
README ajustado com a motivação do autor para testar o Copilot no Visual Studio. Edite conforme desejar.
