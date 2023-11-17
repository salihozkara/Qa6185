#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 5d6f06fe-5d51-4d70-b85c-17bf95c98167 -t
    fi
    cd ../
fi

docker-compose up -d
