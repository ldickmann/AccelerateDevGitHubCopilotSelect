# Anotações de diversos Módulos

## Módulo: Desenvolver testes de unidade usando ferramentas do GitHub Copilot

- Sem anotações

---

## Módulo: Implementar melhorias de código usando ferramentas do GitHub Copilot

Os desenvolvedores devem considerar os seguintes fatores ao trabalhar em melhorias de qualidade de código

- **Legibilidade**: Melhorar ou aprimorar a legibilidade do código pode facilitar a compreensão dos desenvolvedores.
- **Complexidade**: Reduzir a complexidade do código torna o código mais fácil de entender, gerenciar e manter.
- **Modularidade e Reutilização**: Dividir o código em módulos ou componentes menores e reutilizáveis pode facilitar o gerenciamento e a manutenção do código.
- **Confiabilidade**: Melhorar a confiabilidade do código pode ajudá-lo a reduzir a probabilidade de bugs, erros e comportamentos inesperados.
- **Desempenho**: O GitHub Copilot Chat pode ajudá-lo a melhorar o desempenho do código fornecendo sugestões para otimizar algoritmos, reduzir cálculos desnecessários, usar programação multithreading e assíncrona e minimizar as operações de E/S.

### Dicas de solicitações (prompts) ao GitHub Copilot:

- Defina um contexto externo com escopo em um nível mais alto do que o código que você deseja atualizar. Por exemplo, se você quiser melhorar o desempenho ou a confiabilidade de um método, defina o contexto externo especificando a classe ou o arquivo que contém o método e qualquer código que interaja com ou dependa do método. Identifique o método como um contexto interno.
- Use participantes de chat e variáveis de chat para ajudar a especificar o contexto. Você pode usar o botão Anexar Contexto para adicionar arquivos ao contexto de Chat e a variável de chat `#selection` para identificar o código específico no qual você está focado. Você também pode incluir o workspace completo (`@workspace`) quando apropriado. Reforce o contexto especificado referindo-se à seleção ou arquivo na parte da linguagem natural do prompt.
- A intenção deve ser clara, concisa e específica. Sua solicitação deve especificar o tipo de melhoria que você deseja obter.

---

## Módulo: IA responsável com GitHub Copilot

O que é a IA responsável?

- A **IA responsável** é uma abordagem para desenvolver, avaliar e implantar sistemas de inteligência artificial de forma **segura, confiável e ética**. Ela orienta decisões desde a finalidade do sistema até a interação dos usuários, garantindo resultados **benéficos e equitativos**. O foco está nas pessoas, respeitando valores como **imparcialidade, confiabilidade e transparência**.

Os 6 princípios da IA responsável da Microsoft e do GitHub Copilot:

- **Imparcialidade**: os sistemas de IA devem tratar todas as pessoas de maneira imparcial.
  - Os sistemas de IA devem tratar todos de forma justa, evitando impactos diferenciados em grupos situados da mesma forma.
- **Confiabilidade e Segurança**: o desempenho dos sitemas de IA deve ser confiável e seguro.
  - Garantem que os sistemas operem de forma segura, consistente e resistente a falhas. Eles devem responder adequadamente a situações inesperadas e evitar manipulações prejudiciais. Segurança envolve minimizar danos físicos, emocionais e financeiros, enquanto confiabilidade significa desempenho estável e previsível. Sistemas robustos e precisos fortalecem a confiança na IA.
- **Privacidade e Segurança**: os sistemas de IA devem ser seguros e respeitar a privacidade.
  - Garantem a proteção dos dados e a confiança do usuário. A Microsoft e o GitHub adotam práticas responsáveis, como obter consentimento antes da coleta, limitar dados ao essencial, anonimizar informações pessoais e criptografar dados confidenciais. Além disso, implementam controles de acesso rigorosos, backup seguro e auditorias regulares para prevenir abusos e acessos não autorizados.
- **Inclusão**: os sistemas de IA devem capacitar a todos e engajar as pessoas.
  - Esta busca garantir que os sistemas sejam justos, acessíveis e abrangentes, beneficiando todas as pessoas, independentemente de origem, habilidades ou localização. A Microsoft defende que a IA deve funcionar para diversos usuários, evitar discriminação e permitir contribuições de diferentes comunidades. Exemplos incluem reconhecimento facial para todos os tons de pele, suporte a leitores de tela e tradução de dialetos regionais. Para isso, os sistemas devem oferecer opções de acessibilidade, adaptação cultural e operação em ambientes com conectividade limitada.
- **Transparência**: os sistemas de IA devem ser compreesíveis.
  - Torna os sistemas compreensíveis e interpretáveis, promovendo confiança e responsabilidade. Criadores de IA devem explicar seu funcionamento, justificar decisões de design e ser honestos sobre limitações. Isso envolve documentação clara, interfaces explicativas, ferramentas de depuração e auditorias, assegurando segurança, imparcialidade e inclusão.
- **Responsabilidade**: as pessoas devem ser responsáveis pelos sistemas de IA.
  - A responsabilidade na IA exige que criadores e empresas assumam o impacto de seus sistemas, monitorando seu desempenho e reduzindo riscos. Com o aumento de casos de preconceitos e abusos algorítmicos, a transparência e a prestação de contas se tornam essenciais. A Microsoft reforça que os sistemas devem ser supervisionados continuamente, garantindo um uso ético e seguro.
