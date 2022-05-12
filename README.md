
# Cálculo de Investimentos em CDB com taxas prefixadas

Projeto para cálculo de CDB com Angular 8 CLI consumindo uma API feita no VisualStudio (Sdk="Microsoft.NET.Sdk.Web", TargetFramework>netcoreapp3.1., LangVersion 10).

Montando o ambiente
=======
Baixar ou clonar o repositório:
>git clone https://github.com/Onjacktallcuca/CalculoInvestimento.git 

Execução
=======
Após o repositorio do sistema corretamente baixado, abra o prompt de comando e navegue até a pasta raíz do repositorio.

Backend
-----------
Certifique-se que as porta locais https://localhost:5001 e https://localhost:5000 estejam desocupadas.

Navegue até a pasta do servidor da API

>cd CalculoInvestimento/Server/CalculoInvestimento

Execute o servidor para subir para o host local
>dotnet run

O sistema deverá subir a API para o ambiente local de host no seguinte endereço: https://localhost:5001/api/CalculoInvestimento


Frontend
-----------
Abra um novo prompt de comando e navegue até a pasta raiz do repositório.
Navegue até a pasta do servidor client da aplicação
>cd CalculoInvestimento/Client/ 

Instale as dependências do npm (esse processo é necessário devido a alta demanda de arquivos gerados no node_modules, não sendo possivel commit para o Git devido o limite de tamanho de 25 megas.) 
Para esse processo é necessário conexão com internet.
>npm i

Após a importação de todas as bibliotecas, é hora de finalmente rodar o frontend no browser:
>ng serve -o

Obs: O sistema será iniciado através do browser default da máquina, caso queira testar com outro browser, o endereço do aplicativo é: http://localhost:4200/


Testes do backend
-----------
Os projetos de teste do backend estão na pasta Server/Tests e finalizam com "Test". 
Voce pode executar o teste através do visual studio clicando na solution com o botão direito e selecionando "Run Test" ou navegando até a raiz de cada solutio e executando o comando 
>dotnet test 



