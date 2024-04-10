

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS builder

COPY . .

WORKDIR /src

RUN dotnet restore

RUN dotnet publish Jenkins-pipeline/Jenkins-pipeline.csproj -c Release -o /app

RUN dotnet test --logger "trx;LogFileName=./Jenkins-pipeline.trx"

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine

COPY --from=builder /app .

ENTRYPOINT ["dotnet", "Jenkins-pipeline.dll"]
