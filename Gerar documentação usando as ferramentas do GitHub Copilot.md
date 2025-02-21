# Gerar documentação usando as ferramentas do GitHub Copilot

## Dicas para digitar perguntas ou prompts no GitHub Copilot Chat

Ao escrever perguntas ou prompts para o GitHub Copilot Chat, considere as seguintes dicas:

- **Participantes do chat**: Use @workspace ou @terminal para ajudar o GitHub Copilot Chat a entender o contexto maior da sua pergunta.
- **Comandos de barra**: Use /explain para ajudar o GitHub Copilot Chat a entender a intenção da sua pergunta.
- **Variáveis de chat**: Use #file, #editor ou #selection para ajudar o GitHub Copilot Chat a encontrar informações específicas relacionadas à sua pergunta.

O GitHub Copilot Chat tem um desempenho melhor quando você usa uma combinação apropriada de participantes de chat, comandos de barra e variáveis de chat em suas perguntas. Por exemplo, você pode usar @workspace para indicar que o contexto são seus arquivos de workspace, /explain para indicar que você deseja uma explicação e #file, #editor ou #selection para fornecer uma área específica de interesse. Nem todas as perguntas exigem uma combinação desses descritores, mas usá-los adequadamente pode ajudar o GitHub Copilot Chat a gerar a resposta pretendida.

---

## Anotações do Curso | Aluno: Lucas E. Dickmann

- `/explain` digitado no chat do GitHub copilot depois de selecionar o código gera uma explicação daquele trecho.
- `/explain` adiciona `workspace` antes de enviar, ou seja é referente aos códigos abertos no editor.

---

## Prompts

### Gerar README

- Frase para o GitHub Copilot gerar o README do sistema em codificação:
  ```markdown
  @workspace Generate a readme markdown document that can be used as a repo description
  ```
- Para gerar um documento README formatado com markdown, utilizar a seguinte prompt:
  ```markdown
  generate readme project documentation formatted using a raw markdown format
  ```
