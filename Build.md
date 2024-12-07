# Docker Builds

## Starting Docker BuildKit

Before creating any containers, ensure that the container is running:

`docker run -d --name buildkitd --privileged moby/buildkit:latest`

Force build command line utility (buildctl) is using the docker container:

`export BUILDKIT_HOST=docker-container://buildkitd`


## Creating the individual containers:

### API:

`buildctl build --frontend=dockerfile.v0 --local context=.  --local dockerfile=. --opt filename=./API/API/Dockerfile`

### Web

`buildctl build --frontend=dockerfile.v0 --local context=.  --local dockerfile=. --opt filename=./UI/Web/Dockerfile`
