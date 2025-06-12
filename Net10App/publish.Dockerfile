# Update this image to match the .NET version/tags used in our images.
FROM mcr.microsoft.com/dotnet/sdk:10.0.100-preview.4-trixie-slim

# Set the working directory inside the container
WORKDIR /app

# Copy everything from the same directory where the Dockerfile is located to the /app directory inside the container
COPY . .

# The container will start by running the dotnet publish command at runtime
CMD ["dotnet", "publish", "-c", "Release", "-r", "linux-x64", "--no-self-contained", "-p:DebugSymbols=false", "-p:DebugType=None", "-o", "/app/publish"]
