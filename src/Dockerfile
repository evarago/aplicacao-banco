FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
#
#
FROM microsoft/dotnet:2.1-sdk AS builder
WORKDIR /src
COPY . .
WORKDIR /src/AplicacaoBancoExtrato.Infrastructure
RUN dotnet build -c Release
WORKDIR /src/AplicacaoBancoExtrato.WebApi
RUN dotnet build -c Release -o /app
#
#
FROM builder AS publish
RUN dotnet publish -c Release -o /app
#
#
FROM base AS production
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AplicacaoBancoExtrato.WebApi.dll"]