FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /source
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -r linux-musl-x64 -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=builder /app .
COPY --from=node /app/build ./wwwroot
CMD ASPNETCORE_URLS=http://*:$PORT ./BNPKataApi
