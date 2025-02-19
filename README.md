# GitHub Copilot Bootcamp | Created by Microsoft

### Aluno e Desenvolvedor: Lucas E. Dickmann

Collecting workspace information# Library App

## Description

Library App é um sistema de gerenciamento de biblioteca que permite a busca de usuários, renovação de empréstimos, devolução de livros e renovação de associação de usuários. O projeto é implementado em C# e utiliza arquivos JSON para persistência de dados.

## Project Structure

- `src/`
  - `Library.ApplicationCore/`
    - `Entities/`
      - Author.cs
      - Book.cs
      - BookItem.cs
      - Loan.cs
      - Patron.cs
    - `Enums/`
      - EnumHelper.cs
      - LoanExtensionStatus.cs
      - LoanReturnStatus.cs
      - MembershipRenewalStatus.cs
    - `Interfaces/`
      - ILoanRepository.cs
      - ILoanService.cs
      - IPatronRepository.cs
      - IPatronService.cs
    - `Services/`
      - LoanService.cs
      - PatronService.cs
    - Library.ApplicationCore.csproj
  - `Library.Console/`
    - appSettings.json
    - CommonActions.cs
    - ConsoleApp.cs
    - ConsoleState.cs
    - `Json/`
      - Authors.json
      - Books.json
      - BookItems.json
      - Loans.json
      - Patrons.json
    - Library.Console.csproj
    - Program.cs
  - `Library.Infrastructure/`
    - `Data/`
      - JsonData.cs
      - JsonLoanRepository.cs
      - JsonPatronRepository.cs
    - Library.Infrastructure.csproj
- `tests/`
  - `UnitTests/`
    - `ApplicationCore/`
      - `LoanService/`
        - ExtendLoan.cs
        - ReturnLoan.cs
      - `PatronService/`
        - RenewMembership.cs
    - LoanFactory.cs
    - PatronFactory.cs
    - UnitTests.csproj
- EXERCICIOS.md
- GuidedProjectApp.sln
- README.md

## Key Classes and Interfaces

### Entities

- `Author`
- `Book`
- `BookItem`
- `Loan`
- `Patron`

### Enums

- `EnumHelper`
- `LoanExtensionStatus`
- `LoanReturnStatus`
- `MembershipRenewalStatus`

### Interfaces

- `ILoanRepository`
- `ILoanService`
- `IPatronRepository`
- `IPatronService`

### Services

- `LoanService`
- `PatronService`

### Console

- `ConsoleApp`
- `ConsoleState`
- `CommonActions`

### Infrastructure

- `JsonData`
- `JsonLoanRepository`
- `JsonPatronRepository`

## Usage

1. Clone o repositório.
2. Navegue até o diretório do projeto.
3. Restaure as dependências do projeto:
   ```sh
   dotnet restore
   ```
4. Compile o projeto:
   ```sh
   dotnet build
   ```
5. Execute o aplicativo console:
   ```sh
   dotnet run --project src/Library.Console/Library.Console.csproj
   ```

## License

Este projeto está licenciado sob os termos da licença MIT.
