FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
EXPOSE 5000
EXPOSE 5001

WORKDIR /src
COPY ["./app.csproj", "."]
RUN dotnet restore "app.csproj"
COPY . .
ENTRYPOINT dotnet watch run app.csproj --urls https://0.0.0.0:5000
