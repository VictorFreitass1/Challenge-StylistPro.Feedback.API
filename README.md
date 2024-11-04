# StylistPro.Feedback.API

## Integrantes
- RM98695  - Breno Giacoppini Câmara   
- RM551744 - Jaqueline Martins dos Santos   
- RM97510  - Mariana Bastos Esteves   
- RM551155 - Matheus Oliveira Macedo   
- RM99982  - Victor Freitas Silva   

## Visão Geral
Esta API foi desenvolvida utilizando uma arquitetura de microservices, seguindo princípios de escalabilidade e modularidade. As principais funcionalidades incluem operações CRUD (Create, Read, Update e Delete) para gerenciar feedbacks dos usuários, com banco de dados ORACLE e documentação configurada via OpenAPI. O padrão Singleton foi implementado para gerenciar instâncias específicas durante a execução.

## Estrutura de Camadas

- **Presentation Layer (Camada de Apresentação)**: Responsável pela comunicação entre o cliente e a aplicação. Utiliza o framework ASP.NET Core para gerenciar os endpoints da API.
- **Application Layer (Camada de Aplicação)**: Contém a lógica de negócios de alto nível, coordenando operações entre a camada de domínio e a camada de apresentação.
- **Domain Layer (Camada de Domínio)**: Define as entidades de domínio e as regras de negócios centrais.
- **Infrastructure Layer (Camada de Infraestrutura)**: Lida com tecnologias externas, como o acesso ao banco de dados.
- **Test Layer (Camada de Testes)**: Inclui testes unitários e de integração utilizando xUnit para garantir o comportamento correto da aplicação

## Funcionalidades

### ObterTodos: Retorna todos os feedbacks do banco de dados.
- **Entrada**: Requisição para listar feedbacks.
- **Processo**: Recuperação dos feedbacks armazenados no banco de dados.
- **Saída**: Lista de feedbacks com detalhes.

### ObterPorId: Retorna um feedback específico com base no Id fornecido.
- **Entrada**: Id do feedback a ser listado.
- **Processo**: Recuperação do feedback pelo Id.
- **Saída**: Detalhes do feedback localizado.

### SalvarDados: Insere um novo feedback no banco de dados.
- **Entrada**: Dados do feedback, incluindo a mensagem e o usuário.
- **Processo**: Validação e armazenamento do feedback no banco de dados.
- **Saída**: Confirmação da criação do feedback.

### EditarDados: Atualiza um feedback existente.
- **Entrada**: Id do feedback e dados atualizados.
- **Processo**: Validação e atualização do feedback no banco de dados.
- **Saída**: Confirmação da atualização.

### DeletarDados: Remove um feedback com base no Id.
- **Entrada**: Id do feedback a ser excluído.
- **Processo**: Remoção do feedback no banco de dados.
- **Saída**: Confirmação da exclusão.

## Design Patterns Utilizados

### 1. Singleton
O padrão Singleton foi utilizado para garantir uma única instância de classes críticas durante a execução da aplicação, promovendo eficiência de recursos. Aplicado, por exemplo, no gerenciamento de conexões com o banco de dados.

- **Uma única instância**: A classe Singleton cria apenas uma instância de si mesma.
- **Construtor privado**: Impede que outras classes criem novas instâncias.
- **Ponto de acesso global**: Através de um método estático que retorna a única instância criada.

### 2. Microservices
A API segue a **arquitetura de microservices**, permitindo que cada serviço funcione de forma autônoma e escalável, oferecendo vantagens como:
- **Escalabilidade**
- **Modularidade**
- **Resiliência**
- **Facilidade de Manutenção e Atualização**
- **Agilidade**

## Arquitetura

A arquitetura **StylistPro** adota os princípios da **Onion Architecture** para uma alta desacoplagem entre camadas.

### 1. **Mobile Client**
   - Ponto de entrada do sistema, representando o cliente móvel que acessa o serviço **StylistPro**.

### 2. **API Gateway**
   - Centraliza a entrada de requisições, direcionando-as para as APIs correspondentes de **Compra**, **Feedback** ou **Produto**.

### 3. **APIs (Compra, Feedback, Produto)**
   - APIs com funcionalidades específicas de cada domínio, promovendo a separação de responsabilidades.

### 4. **Banco de Dados (Oracle)**
   - Cada API possui um banco de dados Oracle dedicado para armazenar os dados.

### 5. **Onion Architecture**
   - Promove a separação em camadas e o princípio da inversão de dependências.

## Práticas de Clean Code e SOLID
- **Clean Code** foi aplicado para clareza, simplicidade e manutenção. Princípios **SOLID** foram seguidos para um código modular e coeso:
  - **SRP (Single Responsibility Principle)**: Cada classe tem uma única responsabilidade.
  - **OCP (Open/Closed Principle)**: Módulos são abertos para extensão e fechados para modificação.
  - **LSP (Liskov Substitution Principle)** e **ISP (Interface Segregation Principle)**: Classes e interfaces específicas para casos de uso.
  - **DIP (Dependency Inversion Principle)**: Inversão de dependências torna o sistema mais modular.
 
## Testes Unitários
- Testes unitários foram implementados nas camadas `ApplicationService` e `Repository` para verificar o funcionamento correto e a integridade dos dados, aumentando a robustez e confiabilidade da API.

## Tecnologias Utilizadas
- **Oracle Database**: Utilizado para operações CRUD.
- **ASP.NET Core**: Framework para desenvolvimento da API.
- **OpenAPI/Swagger**: Documentação interativa da API.
- **xUnit**: para testes automatizados

## Requisitos
- **.NET SDK 8.0**
- **Visual Studio 2022 ou Visual Studio Code**
- **Oracle Database (com conexão configurada)**

## Instruções para Executar a API

### 1. Clone o repositório:
```
git clone <link-do-repositorio>
```

### 2. Navegue até a pasta do projeto:
```
cd StylistPro.Feedback.API
```

### 3. Restaure os pacotes NuGet:
```
dotnet restore
```

### 4. Configure a string de conexão com o banco de dados ORACLE no arquivo appsettings.json:
```
"ConnectionStrings": {
  "Oracle": "Data Source=<oracle-db-url>;User Id=<username>;Password=<password>;"
}
```

### 5. Execute a aplicação:
```
dotnet run
```

### 6. Acesse a documentação da API gerada pelo Swagger:
```
Após executar a API, navegue até http://localhost:<porta>/swagger para visualizar e interagir com a documentação.
```

### 7. No caso de erro no banco de dados: Se houver inconsistências entre o código e o banco de dados, você pode gerar e aplicar migrations para corrigir a estrutura do banco.
```
Remove-Migration
```
```
Add-Migration <nome-da-migração>
```
```
Update-Database
```

## Testando a API
A **StylistPro** utiliza o Swagger para expor os endpoints de forma interativa. Abra a URL fornecida após executar a API e você verá a documentação da API com opções para testar cada endpoint.

## Contato
Para qualquer dúvida ou sugestão, entre em contato com victor.fsilva45@gmail.com
