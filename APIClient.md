# Generating C# Client using NSwag

The Web project does not access the DB directly but rather through the API. The client used by the Web project is
generated using NSwag. And every time changes are made to the API, the client needs to be generated.

This document helps do describe how to regenerate this C# client.

## Installation

The command line tool for NSwag is is distributed as a NPM package. Full details can be found
here: https://www.npmjs.com/package/nswag

To install globally, run the following NPM command:
`npm install nswag -g`

## Running the generator

This section will focus on the command-line utility so that the instructions are applicable to both Windows, Linux and
MacOS development environments.

1. Run the API and open the Swagger UI web interface so that you can download the OpenAPI JSON
   document (http://localhost:5093/swagger/v1/swagger.json)
1. Copy the content the ./src/swagger.json file

Execute the following command from the ./src directory

`nswag openapi2csclient /input:swagger.json \
                       /classname:Client \
                       /namespace:Numployable.APIClient.Client \
                       /output:./API/APIClient/Client/ServiceClient.cs \
                       /UseBaseUrl:false \
                       /GenerateExceptionClasses:true \
                       /GenerateClientClasses:true \
                       /GenerateBaseUrlProperty:true \
                       /InjectHttpClient:true \
                       /GenerateClientInterfaces:true \
                       /GenerateDtoTypes:true \
                       /WrapDtoExceptions:true`

## Reference

The following pages give full details using the tool:
https://github.com/RicoSuter/NSwag/wiki/CommandLine
https://github.com/RicoSuter/NSwag/wiki/CSharpClientGenerator

