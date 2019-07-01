#!/bin/bash

# current Git branch
branch=$(git rev-list HEAD | head -n 1)

# file in which to update version number
versionFile=".\SimpleDreamerVS19\Show_SimpleDreamer_API_Servers.Server\StaticInformation\swVersion.cs"
 
# find version number assignment ("= v1.5.5" for example)
# and replace it with newly specified version number
sed -i -E "s/\= \"git-[0-9a-z.]+\"/\= \"git-$(git rev-list HEAD | head -n 1)\"/" $versionFile $versionFile

#while :
#do
    # TASK 1
    #read -t 1 -n 1 key

    #if [[ $key ]]
    #then
        #break
    #fi
#done