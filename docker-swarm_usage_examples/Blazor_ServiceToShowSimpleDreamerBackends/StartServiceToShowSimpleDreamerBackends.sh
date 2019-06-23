#!/bin/bash
docker build --tag simpledreamer_sb_blazor:v0.1 -f ./../../SimpleDreamerVS19/Blazor_Dockerfile ./../../SimpleDreamerVS19
docker tag simpledreamer_sb_blazor:v0.1 127.0.0.1:5000/simpledreamer_sb_blazor:v0.1
docker push 127.0.0.1:5000/simpledreamer_sb_blazor:v0.1
docker stack deploy --compose-file=ShowSimpleDreamerBackendsService.yml SimpleDreamer_SB
