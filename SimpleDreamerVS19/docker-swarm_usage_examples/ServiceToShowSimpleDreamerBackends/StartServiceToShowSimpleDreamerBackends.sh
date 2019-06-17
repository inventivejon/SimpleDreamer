#!/bin/bash
docker build --tag simpledreamer_sb_backend:v0.1 ./../../Backend_To_Show_SimpleDreamerBackends
docker tag simpledreamer_sb_backend:v0.1 localhost:5000/simpledreamer_sb_backend:v0.1
docker push localhost:5000/simpledreamer_sb_backend:v0.1
docker build --tag simpledreamer_sb_frontend:v0.1 ./../../Frontend_To_Show_SimpleDreamerBackends
docker tag simpledreamer_sb_frontend:v0.1 localhost:5000/simpledreamer_sb_frontend:v0.1
docker push localhost:5000/simpledreamer_sb_frontend:v0.1
docker stack deploy --compose-file=ShowSimpleDreamerBackendsService.yml SimpleDreamer_SB
