FROM mcr.microsoft.com/devcontainers/dotnet:0-7.0

RUN apt update \
    && apt install curl \
    && curl -sL https://deb.nodesource.com/setup_18.x | bash - \
    && apt install -y nodejs \
    && npm install -g vue@3.3 \
    && rm -rf /var/lib/apt/lists/*∏