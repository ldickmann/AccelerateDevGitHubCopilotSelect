## Módulo: Introdução à engenharia de prompts com o GitHub Copilot

### Princípios da engenharia de Prompt - Os 4 S's:

- **Único**: Sempre foque seu prompt em uma tarefa ou pergunta única e bem definida. Essa clareza é fundamental para obter respostas precisas e úteis do Copilot.
- **Específico**: Certifique-se de que suas instruções sejam explícitas e detalhadas. A especificidade leva para sugestões de código mais aplicáveis e precisas.
- **Curto**: Ao ser específico, mantenha os prompts concisos e diretos. Esse equilíbrio garante clareza sem sobrecarregar o Copilot ou complicar a interação.
- **Contextual**: Utilize nomes de arquivos com descrição e mantenha os arquivos relacionados abertos. Isso fornece ao Copilot um contexto avançado, levando para sugestões de código mais personalizadas.

### Como o Copilot aprende com seus Prompts:

- **Aprendizado Zero-Shot**: Aqui é gerado código sem exemplos específicos, usando apenas seu treinamento básico. Por exemplo, ao criar uma função para converter temperaturas, basta escrever um comentário descrevendo o que deseja e o Copilot gerará o código, baseado em seu treinamento anterior, sem a necessidade de mais exemplos.
- **Aprendizado One-Shot**: Neste aprendizado, um único exemplo é fornecido para ajudar o modelo a gerar respostas mais contextuais. Este exemplo inicial ajuda a estabelecer um padrão ou contexto que o modelo pode seguir e expandir. Dessa forma, o GitHub Copilot consegue compreender melhor a tarefa desejada e gerar um código mais adequado, mesmo com apenas um exemplo fornecido.
- **Aprendizado Few-Shot**: GitHub Copilot é alimentado com vários exemplos para encontrar um equilíbrio entre a imprevisibilidade do zero-shot e a precisão do ajuste fino. Por exemplo, quando você deseja criar um código para enviar uma saudação personalizada conforme o horário do dia, o Copilot recebe múltiplos exemplos para aprimorar sua compreensão da tarefa.
  A utilização de vários exemplos permite que o modelo reconheça padrões e nuances, proporcionando respostas mais precisas e adequadas. Essa abordagem é particularmente útil em contextos onde a tarefa requer uma compreensão mais detalhada e refinada, garantindo que o código gerado seja de alta qualidade e atenda às expectativas do usuário.
