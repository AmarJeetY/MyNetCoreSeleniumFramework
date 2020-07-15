FROM mcr.microsoft.com/dotnet/core/sdk
WORKDIR /app
COPY . ./
RUN dotnet restore 
RUN dotnet build -c Release
ENTRYPOINT ["dotnet", "test", "-c", "Release", "--verbosity", "normal"]