
# Gerenciador de Produtos

Esse projeto tem como objetivo simular o processo de gerenciamento de produtos. Para isso ele conta com a possibilidade de busca, filtro por disponibilidade, atualização e exclusão de produtos. Também conta com processo de autenticação, fazendo que com determinados ENDPOINTS só sejam acessados por alguns cargos, trazendo segurança. 
Outro ponto é a possibilidade da adição, atualização e exclusão de perfis, nesse caso, os perfis são GERENTE e o perfil VENDEDOR, assim, existe a possibilidade de mudanças no mesmo. 


## Pré-Requisitos
1. **Visual Studio 2022**
   - Recomendado para desenvolvimento e execução do projeto.
2. **SQL Server Management Studio**
   - Utilizado para gerenciar o banco de dados SQL Server.
3. **Postman**
   - Ferramenta para testar as requisições da API.

### Linguagem e Framework:
- **.NET 8.0**
  - Certifique-se de que o SDK do .NET 8.0 está instalado na sua máquina. Você pode baixá-lo em [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

### Dependências (NuGet Packages):
Todas as dependências foram instaladas usando o **NuGet**. Abaixo estão as bibliotecas utilizadas no projeto:

- `Microsoft.AspNetCore.Authentication.JwtBearer` (v8.0.11)  
  Para autenticação e autorização usando JWT.  
- `Microsoft.EntityFrameworkCore` (v9.0.0)  
  Para mapeamento objeto-relacional (ORM).  
- `Microsoft.EntityFrameworkCore.Design` (v9.0.0)  
  Necessário para ferramentas de design e migrações.  
- `Microsoft.EntityFrameworkCore.SqlServer` (v9.0.0)  
  Provedor para interação com o banco de dados SQL Server.  
- `Microsoft.EntityFrameworkCore.Tools` (v9.0.0)  
  Ferramentas para execução de comandos do Entity Framework.  
- `Microsoft.VisualStudio.Web.CodeGeneration.Design` (v8.0.7)  
  Suporte a scaffolding no Visual Studio.  
- `Swashbuckle.AspNetCore` (v6.6.2)  
  Para documentação e testes de API com Swagger.  
- `System.IdentityModel.Tokens.Jwt` (v8.3.0)  
  Para manipulação de tokens JWT.

### Banco de Dados:
- **SQL Server**  
  - Certifique-se de que o SQL Server está instalado e configurado.
  - Crie o banco de dados necessário (ou utilize os scripts SQL fornecidos no projeto).

---

## Instalação do .NET
Passo 1: Baixe o instalador do .NET
Acesse a página oficial de download do .NET:
https://dotnet.microsoft.com/download
(Até a data de lançamento desse projeto a última versão de longo suporte era o .NET 8.0)
Siga o passo a passo da ferramenta de instalação. Após instalação abra o terminal e digite o comando: 
dotnet --version
Se estiver tudo certo, deverá receber um 8.x ou equivalente a sua escolha.
## Instalação do Visual Studio
Passo 1: Baixe o instalador
Acesse a página oficial do Visual Studio:
https://visualstudio.microsoft.com/pt-br/
Execute o instalador e siga os passos. 
Na janela de instalação deverá aparecer a opção de "Desenvolvimento ASP.NET e web" certifique-se que marcou essa opção. 
## Instalação do SQL Server
Passo 1: Baixar o SQL Server
Acesse a página oficial de download do SQL Server: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
Passo 2: Selecione a opção "EXPRESS"
Siga o passo a passo e termine a instalação
Passo 3: Baixe o Managment Studio SQL Server no link:
https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
## Instalação do POSTMAN
Passo 1: Baixar o instalador
Acesse o site oficial do Postman:
https://www.postman.com/downloads/
Siga as instruções necessárias para o seu sistema operacional.
## Funcionamento
Visão Geral
O Gerenciador de Produtos permite realizar o controle de um catálogo de produtos com os seguintes papéis de usuários:

Gerente: Tem acesso total ao sistema, podendo criar, atualizar e excluir produtos e perfis de usuários.
Vendedor: Possui acesso limitado, não podendo excluir produtos e também não possui acesso ao controller dos colaboradores. 

##Funcionalidades

Autenticação e Autorização:

Utiliza JWT (JSON Web Token) para autenticar usuários.
Permite que apenas usuários autorizados acessem determinados endpoints.

Gerenciamento de Produtos:
Adicionar, listar, atualizar e excluir produtos.

Gerenciamento de Usuários: Criar e gerenciar perfis de Gerente e Vendedor.

Documentação de API:
Swagger UI integrada para explorar os endpoints.

##Fluxo: ProdutoController

Primeiro o usuário se autentica utlizando o método post de TokenController. Esse método espera um json no seguinte formato: 

    {    
    "Nome": "string",
    "Email": "string",
    "Password": "string",
    "Cargo": "string"
    }

Dentro da lógica já foi incluso um usuário com a função de gerente dentro do context, portando para acessar essas funções do ProdutoController ou ColaboradorController, use o seguinte JSON:

    {
        "Nome": "felepe",
        "Email": "felepe@gmail.com",
        "Password": "12345",
        "Cargo": "gerente"
    }
Após pegar permissão você pode incluir seus próprios perfis e realizar a exclusão deste.

Após isso irá receber uma resposta que irá conter o nome, o cargo e o token. Esse token que deverá ser utilizado para realizar a autenticação. No postman, o prrenchimento ficará assim:

        Inserir imagem do postman

Após a validação, os ENDPOINTS ficarão acessíveis de acordo com a autenticação. Dentro do ProdutoController, as autorizações estão distribuídas da seguinte forma:

        Inserir imagem da tabela

Para o método POST no ProdutoController temos o seguinte json que deverá ser enviado:

    {
        "Nome": "string",
        "Descricao": "string",
        "StatusProduto": "EmEstoque",
        "Preco": 0,
        "QuantidadeEstoque": 0
    }
Nesse método temos a propriedade "StatusProduto", que é um ENUM com os seguinte valores: "EmEstoque" ou "Indisponivel".

O método PUT do ProdutoController deverá receber um ID na URL e no body o seguinte JSON:

    {        
        "StatusProduto": "EmEstoque",
        "QuantidadeEstoque": 0
    }

## Fluxo: ColaboradorController
Esse controlador possui 3 métodos: POST, PUT e DELETE

POST: Adiciona um novo perfil ao banco de dados através do seguinte JSON:

    {
    "Nome": "string",
    "Email": "string",
    "Password": "string",
    "Cargo": "string"
    }

Aqui os cargos que foram definidos dentro do sistema são os de gerente e vendedor. Sendo assim, escolha entre a opção que deseja. 

PUT: Atualiza um colaborador. Necessário repassar o ID na Url e o seguinte JSON no body:

    {
    "Nome": "string",
    "Email": "string",
    "Password": "string",
    "Cargo": "string"
    }

DELETE: Operação que será realiza somente repassando o ID na URL.
## Autores
Felepe Santos Paiva, um professor em processo de transiçaõ de carreira para a área de tecnologia e apaixonado por cuscuz e café. 

##Contato

Email: felipe.geo.uece@gmail.com
Telefone: (85) 981640222

##Redes Sociais

Linkedin: https://www.linkedin.com/in/felepe-paiva/