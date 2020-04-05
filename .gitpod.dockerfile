FROM gitpod/workspace-postgres

RUN sudo apt-get update \
    && sudo apt-get install -y \
    nodejs npm 

ENV ASPNETCORE_ENVIRONMENT=Development