# Resolução dos exercícios | Aluno e Dev: [Lucas E. Dickmann]

## Exercício 1

Explicação do `ConsoleApp.cs` gerada pelo Github Copilot:

```csharp
Collecting workspace informationA `ConsoleApp` é a classe principal da interface de linha de comando do sistema de biblioteca. Suas principais características são:

### Estado e Dependências
- Mantém estado através de:
  - `_currentState`: Estado atual do fluxo da aplicação
  - `matchingPatrons`: Lista de usuários encontrados na busca
  - `selectedPatronDetails`: Detalhes do usuário selecionado
  - `selectedLoanDetails`: Detalhes do empréstimo selecionado

- Injeção de dependências via construtor:
  - `IPatronRepository`: Acesso aos dados de usuários
  - `ILoanRepository`: Acesso aos dados de empréstimos
  - `ILoanService`: Serviços relacionados a empréstimos
  - `IPatronService`: Serviços relacionados a usuários

### Funcionalidades Principais
1. `PatronSearch()`: Busca de usuários por nome
2. `PatronDetails()`: Exibe detalhes do usuário selecionado
3. `LoanDetails()`: Exibe detalhes do empréstimo selecionado
4. `Run()`: Loop principal que gerencia os estados da aplicação

### Fluxo de Estados
- PatronSearch -> PatronSearchResults -> PatronDetails -> LoanDetails
- Permite navegação entre estados e ações como:
  - Renovar empréstimos
  - Devolver livros
  - Renovar associação de usuário
  - Nova busca
  - Sair do sistema

É uma implementação do padrão State Machine para controlar o fluxo da aplicação console.
```

## Exercício 2

Explicação do `Program.cs` gerada pelo Github Copilot:

Collecting workspace informationO arquivo `Program.cs` é o ponto de entrada da aplicação console do sistema de biblioteca. Principais aspectos:

### Configuração de Dependências

```csharp
var services = new ServiceCollection();
```

- Configura o contêiner de injeção de dependências usando `Microsoft.Extensions.DependencyInjection`

### Configuração do Aplicativo

```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json")
    .Build();
```

- Carrega configurações do arquivo `appSettings.json`

### Registro de Serviços

```csharp
services.AddScoped<IPatronRepository, JsonPatronRepository>();
services.AddScoped<ILoanRepository, JsonLoanRepository>();
services.AddScoped<ILoanService, LoanService>();
services.AddScoped<IPatronService, PatronService>();
```

- Registra as implementações concretas para as interfaces do sistema
- Usa `AddScoped` para escopo por requisição
- Usa `AddSingleton` para instâncias únicas

### Inicialização

```csharp
var servicesProvider = services.BuildServiceProvider();
var consoleApp = servicesProvider.GetRequiredService<ConsoleApp>();
consoleApp.Run().Wait();
```

- Constrói o provedor de serviços
- Obtém uma instância de `ConsoleApp`
- Inicia a execução do aplicativo de forma assíncrona

O arquivo demonstra o uso de boas práticas como injeção de dependência e configuração externa.

## Exercício 3

# Classes de Acesso a Dados

O projeto implementa persistência usando arquivos JSON através de 3 classes principais:

### 1. `JsonData`

A classe central que gerencia os dados em memória e operações de arquivo:

```csharp
public class JsonData
{
    public List<Author>? Authors { get; set; }
    public List<Book>? Books { get; set; }
    public List<BookItem>? BookItems { get; set; }
    public List<Patron>? Patrons { get; set; }
    public List<Loan>? Loans { get; set; }
```

Principais responsabilidades:

- Carrega dados dos arquivos JSON
- Mantém os dados em memória
- Gerencia relacionamentos entre entidades
- Salva alterações nos arquivos
- Oferece métodos `GetPopulated*` para carregar objetos com suas relações

### 2. `JsonPatronRepository`

Implementa `IPatronRepository` para acesso a dados de usuários:

```csharp
public class JsonPatronRepository : IPatronRepository
{
    private readonly JsonData _jsonData;

    // Métodos principais:
    public async Task<List<Patron>> SearchPatrons(string searchInput)
    public async Task<Patron?> GetPatron(int id)
    public async Task UpdatePatron(Patron patron)
```

### 3. `JsonLoanRepository`

Implementa `ILoanRepository` para acesso a dados de empréstimos:

```csharp
public class JsonLoanRepository : ILoanRepository
{
    private readonly JsonData _jsonData;

    // Métodos principais:
    public async Task<Loan?> GetLoan(int id)
    public async Task UpdateLoan(Loan loan)
```

### Fluxo de Dados

1. `JsonData` carrega todos os arquivos JSON na inicialização
2. Repositórios usam `JsonData` para:
   - Buscar dados
   - Atualizar registros
   - Manter relacionamentos entre entidades
3. Alterações são salvas de volta nos arquivos JSON

### Características

- Uso de operações assíncronas
- Lazy loading com `EnsureDataLoaded()`
- Gerenciamento de relacionamentos entre entidades
- Configuração via `appSettings.json`
- Repository pattern para abstração do acesso a dados

### Arquivos JSON

```plaintext
Json/
  ├── Authors.json
  ├── Books.json
  ├── BookItems.json
  ├── Patrons.json
  └── Loans.json
```

## Exercício 4 | Explicação do arquivo de testes gerado pelo Github Copilot:

Collecting workspace informationA abordagem de testes unitários implementada neste workspace segue boas práticas de desenvolvimento de software, utilizando o framework de testes xUnit e a biblioteca de mocks NSubstitute. Aqui estão os principais pontos da abordagem:

1. **Uso de Fábricas (Factories)**:

   - As classes `PatronFactory` e `LoanFactory` são usadas para criar instâncias de objetos `Patron` e `Loan` com diferentes estados (por exemplo, empréstimos atuais, empréstimos expirados, membros com associação expirada). Isso facilita a criação de cenários de teste consistentes e reutilizáveis.

2. **Mocks e Stubs**:

   - A biblioteca NSubstitute é usada para criar mocks das interfaces `IPatronRepository` e `ILoanRepository`. Isso permite simular o comportamento dos repositórios sem depender de implementações reais ou de acesso a dados persistentes.

3. **Testes de Unidade**:

   - Os testes são organizados em classes de teste específicas para cada serviço (`PatronService` e `LoanService`).
   - Cada método de teste é decorado com o atributo `[Fact]` do xUnit e possui um nome descritivo que indica o comportamento esperado.
   - Os testes verificam diferentes cenários, incluindo casos de sucesso e falha, garantindo que os serviços se comportem corretamente em várias situações.

4. **Estrutura dos Testes**:
   - **Arrange**: Configura o cenário de teste, criando instâncias de objetos e configurando mocks.
   - **Act**: Executa a ação a ser testada.
   - **Assert**: Verifica se o resultado da ação é o esperado, utilizando asserções para comparar valores.

### Exemplos de Testes

- **Teste de Renovação de Associação**:

  - Verifica se a associação é renovada corretamente para um membro sem empréstimos.
  - Verifica se a associação é renovada corretamente para um membro com associação expirada.
  - Verifica se a renovação falha quando o membro tem empréstimos vencidos.

- **Teste de Devolução de Empréstimo**:

  - Verifica se a devolução de um empréstimo é registrada corretamente.
  - Verifica se a devolução falha quando o empréstimo já foi devolvido.
  - Verifica se a devolução falha quando o empréstimo não é encontrado.

- **Teste de Extensão de Empréstimo**:
  - Verifica se a extensão de um empréstimo é registrada corretamente.
  - Verifica se a extensão falha quando o empréstimo já foi devolvido.
  - Verifica se a extensão falha quando a associação do membro está expirada.

### Benefícios da Abordagem

- **Isolamento**: Os testes são isolados das dependências externas, como bancos de dados, utilizando mocks.
- **Reutilização**: As fábricas permitem a criação fácil de objetos de teste reutilizáveis.
- **Cobertura**: A abordagem cobre uma ampla gama de cenários, garantindo que os serviços se comportem corretamente em diferentes situações.
- **Manutenibilidade**: Os testes são organizados e nomeados de forma clara, facilitando a manutenção e a compreensão do código de teste.

Essa abordagem garante que os serviços da aplicação sejam testados de forma abrangente e confiável, ajudando a identificar e corrigir problemas antes que eles cheguem ao ambiente de produção.

---

### Explicação que identifica uma lista de beneficios gerado com a prompt: `@workspace What are the benefits of this approach to unit testing?`

Collecting workspace informationOs benefícios dessa abordagem de testes unitários incluem:

1. **Isolamento**:

   - Os testes são isolados das dependências externas, como bancos de dados, utilizando mocks. Isso garante que os testes sejam rápidos e não dependam de recursos externos, tornando-os mais confiáveis e fáceis de executar em qualquer ambiente.

2. **Reutilização**:

   - As fábricas (`PatronFactory` e `LoanFactory`) permitem a criação fácil de objetos de teste reutilizáveis. Isso facilita a configuração de cenários de teste consistentes e reduz a duplicação de código.

3. **Cobertura**:

   - A abordagem cobre uma ampla gama de cenários, garantindo que os serviços se comportem corretamente em diferentes situações. Isso inclui casos de sucesso e falha, aumentando a confiança na robustez do código.

4. **Manutenibilidade**:

   - Os testes são organizados e nomeados de forma clara, facilitando a manutenção e a compreensão do código de teste. Métodos de teste bem nomeados indicam claramente o comportamento esperado, tornando mais fácil identificar e corrigir problemas.

5. **Detecção Precoce de Erros**:

   - Testes unitários ajudam a identificar e corrigir problemas antes que eles cheguem ao ambiente de produção. Isso reduz o custo e o esforço necessários para corrigir bugs em estágios posteriores do desenvolvimento.

6. **Facilidade de Refatoração**:

   - Com uma boa cobertura de testes unitários, é mais seguro refatorar o código, pois os testes garantem que as mudanças não introduzam novos bugs. Isso promove a melhoria contínua do código.

7. **Documentação**:

   - Os testes unitários servem como uma forma de documentação viva do comportamento esperado do sistema. Eles mostram como os diferentes componentes devem interagir e quais são os resultados esperados em diferentes cenários.

8. **Automatização**:
   - A abordagem permite a integração fácil com pipelines de CI/CD, como o configurado no arquivo build-test.yml. Isso garante que os testes sejam executados automaticamente em cada commit ou pull request, mantendo a qualidade do código.

Esses benefícios combinados garantem que os serviços da aplicação sejam testados de forma abrangente e confiável, ajudando a manter a qualidade e a estabilidade do software ao longo do tempo.

### Solicitação para que o GitHub Copilot forneça uma visão geral do processo para estender o projeto `UnitTests` para começar a testar métodos no projeto `Library.Infrastructure`.

- Gerada pela prompt: `@workspace How can I extend the UnitTests project to begin testing methods in the Library.Infrastructure project? Provide a process overview.`

Collecting workspace informationPara estender o projeto `UnitTests` e começar a testar métodos no projeto `Library.Infrastructure`, você pode seguir este processo:

1. **Adicionar Referência ao Projeto `Library.Infrastructure`**:

   - Abra o arquivo de projeto UnitTests.csproj e adicione uma referência ao projeto `Library.Infrastructure`.

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <TargetFramework>net8.0</TargetFramework>
       <ImplicitUsings>enable</ImplicitUsings>
       <Nullable>enable</Nullable>
       <IsPackable>false</IsPackable>
       <IsTestProject>true</IsTestProject>
     </PropertyGroup>

     <ItemGroup>
       <PackageReference Include="coverlet.collector" Version="6.0.0" />
       <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
       <PackageReference Include="NSubstitute" Version="5.1.0" />
       <PackageReference Include="xunit" Version="2.5.3" />
       <PackageReference Include="xunit.runner.visualstudio" Version="2.5.3" />
     </ItemGroup>

     <ItemGroup>
       <Using Include="Xunit" />
     </ItemGroup>

     <ItemGroup>
       <ProjectReference Include="..\..\src\Library.ApplicationCore\Library.ApplicationCore.csproj" />
       <ProjectReference Include="..\..\src\Library.Infrastructure\Library.Infrastructure.csproj" />
     </ItemGroup>

   </Project>
   ```

2. **Criar Classes de Teste para `Library.Infrastructure`**:

   - Crie uma nova pasta dentro de `UnitTests` para organizar os testes do projeto `Library.Infrastructure`. Por exemplo, `UnitTests/Infrastructure`.

3. **Escrever Testes Unitários**:

   - Crie classes de teste para as classes que você deseja testar no projeto `Library.Infrastructure`. Por exemplo, se você quiser testar a classe `JsonPatronRepository`, crie um arquivo `JsonPatronRepositoryTests.cs` dentro da pasta `UnitTests/Infrastructure`.

   ```csharp
   // filepath: /c:/Users/ldick/GitHubCopilotBootcamp/GuidedProjectApp/AccelerateDevGitHubCopilot/tests/UnitTests/Infrastructure/JsonPatronRepositoryTests.cs
   using Library.ApplicationCore.Entities;
   using Library.Infrastructure.Data;
   using Microsoft.Extensions.Configuration;
   using NSubstitute;
   using Xunit;

   public class JsonPatronRepositoryTests
   {
       private readonly JsonPatronRepository _repository;
       private readonly JsonData _mockJsonData;

       public JsonPatronRepositoryTests()
       {
           _mockJsonData = Substitute.For<JsonData>(Substitute.For<IConfiguration>());
           _repository = new JsonPatronRepository(_mockJsonData);
       }

       [Fact(DisplayName = "JsonPatronRepository.GetPatron: Returns null if patron is not found")]
       public async Task GetPatron_ReturnsNullIfNotFound()
       {
           // Arrange
           _mockJsonData.Patrons = new List<Patron>();

           // Act
           var result = await _repository.GetPatron(1);

           // Assert
           Assert.Null(result);
       }

       [Fact(DisplayName = "JsonPatronRepository.GetPatron: Returns patron if found")]
       public async Task GetPatron_ReturnsPatronIfFound()
       {
           // Arrange
           var patron = new Patron { Id = 1, Name = "John Doe" };
           _mockJsonData.Patrons = new List<Patron> { patron };

           // Act
           var result = await _repository.GetPatron(1);

           // Assert
           Assert.NotNull(result);
           Assert.Equal(patron.Id, result.Id);
           Assert.Equal(patron.Name, result.Name);
       }

       // Adicione mais testes conforme necessário
   }
   ```

4. **Executar os Testes**:

   - Execute os testes para garantir que tudo esteja funcionando corretamente. Você pode fazer isso usando o comando `dotnet test` no terminal.

   ```sh
   dotnet test
   ```

### Resumo do Processo

1. Adicione uma referência ao projeto `Library.Infrastructure` no arquivo UnitTests.csproj.
2. Crie uma nova pasta para organizar os testes do projeto `Library.Infrastructure`.
3. Escreva classes de teste para as classes que você deseja testar no projeto `Library.Infrastructure`.
4. Execute os testes para garantir que tudo esteja funcionando corretamente.

Seguindo esses passos, você poderá estender o projeto `UnitTests` para incluir testes para o projeto `Library.Infrastructure`.
