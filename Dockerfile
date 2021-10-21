FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY ["src/Ozon.MerchandiseService.Presenation/Ozon.MerchandiseService.Presenation.csproj","src/OzonEdu.Ozon.MerchandiseService.Presenation/"]

RUN dotnet restore "src/OzonEdu.Ozon.MerchandiseService.Presenation/Ozon.MerchandiseService.Presenation.csproj"

COPY . .

WORKDIR "/src/src/Ozon.MerchandiseService.Presenation"

RUN dotnet build "Ozon.MerchandiseService.Presenation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ozon.MerchandiseService.Presenation.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

EXPOSE 80
EXPOSE 443

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Ozon.MerchandiseService.Presenation.dll"]