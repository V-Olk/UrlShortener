FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln ./
COPY */*.csproj ./
RUN find ./
RUN for file in $(ls *.csproj); do folder=${file%.*} && res_folder=${folder#"Volkin."} && mkdir -p ${res_folder} && mv $file ${res_folder}; done
RUN dotnet restore

# copy everything else and build app
COPY . ./aspnetapp
WORKDIR /app/aspnetapp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/aspnetapp/out ./
ENTRYPOINT ["dotnet", "Volkin.UrlGenerator.Webhost.dll"]