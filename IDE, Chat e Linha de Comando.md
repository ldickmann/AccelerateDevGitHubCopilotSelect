# Módulo: GitHub Copilot entre ambientes: Técnicas de IDE, chat e linha de comando

### Painel de várias sugestões:

- Quando você está trabalhando em um bloco de código e o GitHub Copilot oferece uma sugestão, você verá um trecho de código esmaecido. Para explorar mais opções, passe o mouse sobre a sugestão para revelar o painel de controle do GitHub Copilot.
  No painel de controle, você pode clicar nos botões de seta para frente ou para trás para ver as próximas ou anteriores sugestões. Existem também atalhos de teclado para facilitar essa navegação:
  - **Windows ou Linux:** Alt + seta (frente ou trás), Alt+

### Como melhorar as respostas do Chat do GitHub Copilot:

#### Referenciamento de escopo:

- Para melhorar a precisão das respostas fornecidas é importante definir corretamente o escopo das perguntas, usando referências:
  - Referência de arquivo: `# File: file_name`: Para especificar um arquivo.
  - Referência de ambiente: Isso permite que o Chat do Copilot leve em conta o contexto mais amplo dos projetos e configurações abertos no Visual Studio IDE. Ao perguntar `@workspace` onde está a função de cálculo?", o Copilot analisará toda a solução para encontrar as informações mais relevantes.

#### Comandos de barra "/":

- Estes comandos permitem especificar rapidamente a intenção da consulta.

  - `/doc`: Insere anotações no código selecionado ou especificado. Por exemplo, digite /doc seguido pelo código que você deseja documentar e o Copilot criará comentários adequados.
  - `/explain`: Oferece descrições para o código selecionado. Isso é especialmente útil quando se precisa compreender o funcionamento de um código específico. Por exemplo, `/explain the #file: file_name` gerará uma explicação detalhada do arquivo selecionado.
  - `/fix`: Sugeri soluções para erros no código selecionado.
  - `/generate`: Facilita a criação de novo código conforme suas necessidades. Por exemplo, ao usar `/generate code to find the root of a number in file_name`, uma função será gerada para realizar essa tarefa.
  - `/optimize`: Examina e propõe aperfeiçoamentos para o tempo de execução ou a eficiência do código selecionado. Por exemplo, `/optimize the calcular method in file_name` focará em melhorar o desempenho desse método específico.
