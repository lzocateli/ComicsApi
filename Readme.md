## Build Status

| Branch   | Build |
| -------- | ----- |
| `qas`    |  |
| `main`   |  |

----

## Infraestrutura da aplicação

- `Tipo da aplicação: "Api"`
- `Linux Container:`

- Exemplo para criar uma imagem da aplicação:

```bash
podman build -t lzocateli/nome-da-aplicacao:9.9.9 -f .
```

```bash
#Excluir todas as imagens e containers
 docker rmi (docker images -q) -f
```
- Comando para executar o container no servidor:

```bash
# Com usuario brazildevops logado
sudo su -

podman run -d \
	-e DOTNET_ENVIRONMENT=Production \
	--env-file /userapps/tmp/CepApi/env.prd \
	--network=lzo \
	--network-alias=CepApi \
	--name CepApi \
	lzocateli/nuv.cep.api:9.9.9
```

Para executar um container já existente alterando o entrypoint para o prompt /bin/bash  
**Note que sera necessario o arquivo com as variaveis de ambiente da aplicação**
```bash
# Com usuario brazildevops logado
sudo su -

podman exec -it --env-file /userapps/tmp/CepApi/env.prd CepApi ls -la /app
```

----

- `Instalação:` 
    - Automatizado via CI/CD DevOps

| Servidor | Ambiente | Container Name | Container Image | Dns        |
| ---      | ---      | ---            | ---             | ---        |
| `seuservidor.com` | Qualidade | CepApi | lzocateli/NUV.Cep.api:9.9.9-preview.22031603 | cep-api.zocate.li |
| `seuservidor.com` | Produção  | CepApi | lzocateli/NUV.Cep.api:9.9.9 | cep-api.zocate.li |


## EF - Entity Framework [Tutorial database first](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx) e [Documentação oficial](https://docs.microsoft.com/en-us/ef/).

***(Executar na pasta da solution)***

- Instale o EF Core caso ainda não tenha:
    - Onde version é a versão do EF que sua aplicação esta utilizando.
    - Caso já possua o arquivo de manifesto (.config), basta executar: dotnet tool restore
```bash
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 3.1.26
```

- Para gerar as classes baseado nas tabelas (Execute esses comandos na pasta onde esta a solution):: use o caractere ` antes de $ caso sua senha possua esse caractere

```bash
dotnet ef dbcontext scaffold "Server=serverdb2.com:3700;Database=Z1P3;UID=XXXXXX;PWD=XXXXXXX;Connect Timeout=30;ConcurrentAccessResolution=SkipLockedData;IsolationLevel=ReadUncommitted" IBM.EntityFrameworkCore -s .\src\NUV.Cep.Api\NUV.Cep.Api.csproj -p .\src\NUV.Cep.Infra.Data\NUV.Cep.Infra.Data.csproj -c AppDbContext -v --schema "cadastro$" -t CEP --use-database-names --context-dir Data -o Models
```

- Para gerar as classes de migrations e o script (Execute esses comandos na pasta onde esta a solution):

```bash
dotnet ef migrations add CriacaoInicial -s .\src\NUV.Cep.Api\NUV.Cep.Api.csproj -p .\src\NUV.Cep.Infra.Data\NUV.Cep.Infra.Data.csproj -c AppDbContext -v
```
- Após executar o comando acima, onde sera criada a classe "CriacaoInicial", inclua o metodo abaixo no final do metodo Up gerado pela migration, bem como CustomViewMigration, caso tenha esses objtos no seu projeto:   
CustomFunctionMigration.UpFunctions(migrationBuilder);   

```bash
dotnet ef migrations script -s .\src\NUV.Cep.Api\NUV.Cep.Api.csproj -p .\src\NUV.Cep.Infra.Data\NUV.Cep.Infra.Data.csproj -c AppDbContext -o .\src\NUV.Cep.Infra.Data\Migrations\Script\script.sql
```
----

## Application Insights
[Documentação Oficial](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)

- Para Aspnet Core:
    - https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core
    - https://docs.microsoft.com/en-us/azure/azure-monitor/app/sdk-connection-string?tabs=net
- Enable client-side telemetry for web applications
[Procure por: Enable client-side telemetry for web applications](https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core)

----

## Usando User Secrets para ambiente de desenvolvimento
[Documentação Oficial](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows)

- Criando um storage local com secredos que irão substituir/adicionar chaves em appsettings.Development.json apenas em tempo de execução.

```bash
dotnet user-secrets init --id Global -p .\src\NUV.Cep.Api\NUV.Cep.Api.csproj
```` 
- Local onde é criado o arquivo no windows (no linux é igual, dentro da $HOME)  
C:\Users\lzob8c1\AppData\Roaming\Microsoft\UserSecrets\Cep\secrets.json

- Copie ou crie sua ConnectionStrings ou qualquer outra chave, dentro do arquivo criado, ele ira substituir as chaves existentes no appsettings.Development.json ou incluir caso não exista, apenas em tempo de execução.  

**Caso não queira usar o arquivo secrets.json, renomeie para __secrets.json**

----

## Dicas e truques
- Criando uma Solution e incluindo ou removendo projetos nela
```bash
dotnet new sln -n SuaSolution (sem extenção)
dotnet sln SuaSolution.sln remove (ls ./src/*/*.csproj)
dotnet sln SuaSolution.sln add (ls ./src/*/*.csproj)
```
----