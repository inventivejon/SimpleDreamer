# SimpleDreamer
Creates continuous stream of simple line drawings merging into other drawings based on random google picture or customized folder or raw line data.
Can be used as background banner on websites with customized dimensions or more.

The application is developed in C# for ASP.NET Core 2.2 with Visual Studio 2019 Colab

You can get the latest version of the applications for docker here:
- https://cloud.docker.com/repository/docker/inventivejon/simpledreamer_backend
- https://cloud.docker.com/repository/docker/inventivejon/simpledreamer_sb_frontend
- https://cloud.docker.com/repository/docker/inventivejon/simpledreamer_sb_backend

You can get the latest code here:
- https://github.com/inventivejon/SimpleDreamer

All APIs that will be developed in the project use OpenAPI 3.0 language for description https://swagger.io/specification/

Using OpenSwagger Editor to define APIs:
https://github.com/swagger-api/swagger-editor/releases/tag/v3.6.30

Using Postman for API Testing:
For testing on lapop: https://www.getpostman.com/
For final automated testing on docker hub: https://hub.docker.com/r/postman/newman

# First steps
After checkout call the bash file Install_Git_Hooks.sh to get automatic git revision update in swVersion files.
