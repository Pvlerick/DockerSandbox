FROM microsoft/dotnet:1.1-runtime-nanoserver

WORKDIR /app
COPY /bin/Debug/netcoreapp1.1/publish/ .

ENTRYPOINT ["dotnet", "DockerDotNetCoreApp.dll"]