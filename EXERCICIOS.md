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
