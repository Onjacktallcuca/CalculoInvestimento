# Cálculo de Investimentos em CDB com taxas prefixadas

Projeto para cálculo de CDB com Angular CLI consumindo uma API feita no VisualStudio (Sdk="Microsoft.NET.Sdk.Web", TargetFramework>netcoreapp3.1., LangVersion 10).

Montando o ambiente
=======
Baixar ou clonar o repositório:
>git clone https://github.com/Onjacktallcuca/CalculoInvestimento.git 

Execução
=======
Após o repositorio do sistema corretamente baixado, abro o prompt de comando e navegue até a pasta raíz do repositoróio.

Backend
-----------
Certifique-se que as porta locais https://localhost:5001 e https://localhost:5000 estejam desocupadas.

Navegue até a pasta do servidor da API
>cd CalculoInvestimento/Server/CalculoInvestimento
Execute o servidor para subir para o host local
>dotnet run

O sistema deverá subir a PAPI para o ambiente local de host (localhost) no seguinte endereço: https://localhost:5001/api/CalculoInvestimento


Frontend
-----------
Abra um novo prompt de comando enavegue até a pasta raiz do sistema
Navegue até a pasta do servidor client da aplicação
>cd CalculoInvestimento/Client/ 

Instale as dependencias do npm (esse processo é necessário devido a alta demanda de arquivo gerados no node_modules, não sendo possivel subi-los para o Git por conta do limite de tamanho de 25 megas.) Para esse processo é necessário conexão com internet
>npm i

Após a importação de todas as bibliotecas, é hora de finalmente roda o frontend no browser:
>ng serve -o

Obs: O sistema será iniciado através do browser default da máquina, caso queira testar com outro browser, o endereço do aplicativo é: http://localhost:4200/


Testes
-----------
Testes do backend
Os projeto de teste do bakend estão na pasta Server/Tests e finalizam com "Test". 
Voce pode executar o teste através do visual studio clicando na solution com o botão direito e selecionando "Run Test" ou navegando até a raiz de cada solution e executando o comando 
>dotnet test 



