FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS builder
WORKDIR /source
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -r linux-musl-x64 -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=builder /app .
COPY --from=node /app/build ./wwwroot
CMD ASPNETCORE_URLS=http://*:$PORT ./AspNetCoreDemoApp
