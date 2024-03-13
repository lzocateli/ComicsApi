FROM lzocateli/dotnet-sdk:3.1.426-focal-amd64

ARG PathApp=/workspaces

RUN apt update -y && apt upgrade -y

ARG TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ >/etc/timezone

