# Sistema Prefeitura

Esse repositório foi criado para o desafio do processo seletivo da Eleva

## Pré requisitos:

Para executar o sistema, é necessário ter algumas ferramentas instaladas. 
Garanta que estas ferramentas estão presentes, e na versão correta:

	- .Net Core SDK 3.1
	- .Net Core Runtime 3.1
	- Angular CLI 9.1	

## Iniciando a  aplicação

### Backend: 
#### GUI
- Abra o projeto no Visual Studio
- Ajuste a connection string do banco de dados no arquivo appsettings.json (```SistemaPrefeitura.App```)
- Com o console do gerenciador de pacotes, selecione o projeto  ```SistemaPrefeitura.Domain.SQL```
- Execute o comando ```update-database```
- Inicie a aplicação

#### CLI
- Ajuste a connection string
- Navegue até a pasta ```SistemaPrefeitura.Domain.SQL```
- Execute o comando ```dotnet ef update database```
- Navegue até o projeto ```SistemaPrefeitura.App```
- Execute o comando ```dotnet run```


### Frontend

#### CLI
- Navegue até a pasta ```frontent/sistemaPrefeitura```
- Execute o comando ```npm install```
- Execute o comando ```ng serve```

##  Utilizando o sistema:
- A documentação da api pode ser encontrada no endpoint /swagger/index.html
- Ao executar o painel, será necessário criar uma conta no provedor de identidade da aplicação, basta se registrar com um email e criar uma senha. Você deverá ser redirecionado para a pagina de escolas.
- Para executar as chamadas de api no swagger é necessário ter um token. Esse token pode ser gerado com algum cliente REST ( como o [Insomnia](https://insomnia.rest/), [Postman](https://www.postman.com/) e [Postwoman](https://postwoman.io/) ).
