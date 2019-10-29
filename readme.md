Clean Architecture - Web Api

Aplicação simples utilizando princípios de Clean Architecture.

## Executando a partir de uma imagem Docker

```sh
docker run -e ASPNETCORE_ENVIRONMENT="Development" -p 5500:80 evertonvarago/clean-architecture-webapi-ef-core
```

### Configurar o SQL Server no Docker

```sh
#!/bin/bash
sudo docker pull mcr.microsoft.com/mssql/server:2017-latest
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest
sudo docker exec -it sql1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<YourStrong!Passw0rd>' -Q 'ALTER LOGIN SA WITH PASSWORD="<YourNewStrong!Passw0rd>"'
```

## Requisitos

Desenvolvido e testado usando:

* MacOS Sierra
* VSCode :heart:
* [.NET SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2).
* Docker :whale:
* SQL Server via Docker container.
