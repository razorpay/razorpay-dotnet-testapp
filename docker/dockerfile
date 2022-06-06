FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
COPY ["Razorpay-dotner-test-app/RazorpaySampleApp45.csproj","Razorpay-dotnet-test-app/"]
RUN dotnet restore "Razorpay-dotner-test-app/RazorpaySampleApp45.csproj"
COPY . .
WORKDIR "/Razorpay-dotnet-test-app/RazorpaySampleApp45.csproj"
RUN dotnet build "RazorpaySampleApp45.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazorpaySampleApp45.csproj" -c Release -o /app/publish

FROM base AS final
COPY --from=publish /app/publish
ENTRYPOINT ["dotnet","RazorpaySampleApp45.dll"]
