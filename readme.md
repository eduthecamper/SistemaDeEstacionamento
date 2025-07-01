# 🚗 Sistema de Gerenciamento de Estacionamento

Sistema completo para controle de estacionamento, com backend em .NET 8 (API RESTful), frontend em React + Bootstrap 5 e banco de dados SQL Server Express.

---

## 📋 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (v16+)
- [npm](https://www.npmjs.com/)
- [SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio Code](https://code.visualstudio.com/) (opcional)

---

## 📦 Estrutura do Projeto


---

## ⚙️ Como rodar o backend (.NET)

1. **Acesse a pasta do backend:**
    ```
    cd EstacionamentoAPI
    ```

2. **Restaure as dependências:**
    ```
    dotnet restore
    ```

3. **Configure a string de conexão no `appsettings.json`:**
    ```
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=EstacionamentoDB;Trusted_Connection=True;TrustServerCertificate=True"
    }
    ```
    > Ajuste o nome do servidor conforme necessário.

4. **Crie o banco de dados:**
    ```
    dotnet ef database update
    ```

5. **(Opcional) Insira configuração de vagas no banco:**
    - No SQL Server Management Studio, execute:
      ```
      INSERT INTO Configuracao (QuantidadeMaximaVagas) VALUES (20);
      ```

6. **Inicie o backend:**
    ```
    dotnet run
    ```
    - A API estará disponível em `http://localhost:5207` (ou a porta exibida no terminal).
    - Teste no navegador: [http://localhost:5207/swagger](http://localhost:5207/swagger)

---

## 💻 Como rodar o frontend (React)

1. **Acesse a pasta do frontend:**
    ```
    cd estacionamento-frontend
    ```

2. **Instale as dependências:**
    ```
    npm install
    ```

3. **Configure o proxy no `package.json`:**
    ```
    "proxy": "http://localhost:5207"
    ```
    > Use a mesma porta do backend.

4. **Configure o .env no frontend:**
    ```
    "REACT_APP_API_URL=http://localhost:5207/api"
    ```
    > Use a mesma porta do backend.

5. **Inicie o frontend:**
    ```
    npm start
    ```
    - O navegador abrirá automaticamente em [http://localhost:3000](http://localhost:3000)

---


## 📝 Principais comandos

| Ação                         | Comando                                  |
|------------------------------|------------------------------------------|
| Instalar dependências .NET   | `dotnet restore`                         |
| Instalar dependências React  | `npm install`                            |
| Criar banco (migrations)     | `dotnet ef database update`              |
| Rodar backend                | `dotnet run`                             |
| Rodar frontend               | `npm start`                              |
| Swagger (API docs)           | `http://localhost:5207/swagger`          |
| App Web                      | `http://localhost:3000`                  |

---

## 🐞 Dicas de Solução de Problemas

- **Erro 404 nos endpoints:**  
  Verifique se os controladores `VeiculosController`, `HistoricoController` e `VagasController` existem e usam `[Route("api/xxx")]`.

- **Erro de CORS:**  
  No backend, adicione no `Program.cs`:

- **Banco não aparece:**  
Confirme a string de conexão e se o SQL Server está rodando.

- **Alterou o `package.json`?**  
Sempre reinicie o React (`Ctrl+C` e `npm start`).

---


