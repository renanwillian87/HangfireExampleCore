FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["HangfireExampleCore/HangfireExampleCore.csproj", "HangfireExampleCore/"]
RUN dotnet restore "HangfireExampleCore/HangfireExampleCore.csproj"
COPY . .
WORKDIR "/src/HangfireExampleCore"
RUN dotnet build "HangfireExampleCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HangfireExampleCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HangfireExampleCore.dll"]