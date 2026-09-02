FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY RazorpaySampleApp.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish RazorpaySampleApp.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "RazorpaySampleApp.dll"]