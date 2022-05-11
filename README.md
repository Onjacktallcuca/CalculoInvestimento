# Calculo de Investimentos em CDB com taxas prefixadas

Projeto para calculo de CDB com Angular CLI consumindo uma API feita no VisualStudio.

Montando o ambiente
=======
Baixar ou clonar o repositório:
>git clone https://github.com/Onjacktallcuca/CalculoInvestimento.git 

Execução
=======
Após o repositorio do sistema corretamente baixado, abro o prompt de comando enavegue até a pasta raiz do sistema

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

Instale as dependencias do npm (esse processo é neceesário devido a lata demanda de arquivo gerados, não sendo possivel subi-los para o Git por conta do limite de tamanho de 25 megas. 
Para esse processo é necessário conexão com internet
>npm i

Após a importação de todas as bibliotecas, é hora de roda o frontend no browser:
>ng serve -o


