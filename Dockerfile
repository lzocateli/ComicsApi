## IBM DB2 IN CONTAINER:
# https://community.ibm.com/community/user/hybriddatamanagement/blogs/vishwa-hs1/2020/07/24/creating-docker-on-linux-hosted-db2-net-applicati
# https://stackoverflow.com/questions/47657658/unable-to-load-dll-libdb2-so-when-establishing-a-db2-connection-with-net-core

FROM lzocateli/dotnet-sdk:8.0.202-jammy-amd64 AS build

WORKDIR /buildapp

COPY src /buildapp/src
COPY NuGet.Config /buildapp
COPY *.sln /buildapp

RUN dotnet restore --configfile NuGet.Config
RUN dotnet publish -c release -o /tmp/outapp --self-contained false --no-restore


FROM lzocateli/dotnet-aspnet:8.0.3-jammy-amd64
RUN apt update -y && apt upgrade -y && apt install -y libxml2-dev


ARG TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ >/etc/timezone

ARG UserApp=nonroot
RUN useradd -ms /bin/bash $UserApp 
USER $UserApp

WORKDIR /home/$UserApp/app
COPY --from=build --chown=$UserApp:users /tmp/outapp ./

ARG Env_Dotnet
ARG AppPort=8080

HEALTHCHECK --interval=60s --timeout=5s CMD curl -f http://localhost:5000/docs/ || exit 1

RUN echo "Dotnet Environment: $Env_Dotnet"

ENV DOTNET_ENVIRONMENT=$Env_Dotnet

ENV ASPNETCORE_URLS=http://*:$AppPort;http://*:5000
EXPOSE $AppPort 5000

ENV LD_LIBRARY_PATH=/home/$UserApp/app/clidriver/lib:/home/$UserApp/app/clidriver/lib/libdb2.so \
    PATH=$PATH:/home/$UserApp/app/clidriver/bin:/home/$UserApp/app/clidriver/lib

ENTRYPOINT ["dotnet", "NUV.Comics.Api.dll"]
