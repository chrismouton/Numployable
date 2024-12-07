# Some commands to run containers in Podman

## Running PostgreSQL in Podman

## Install Podman Compose

Ensure PIP is running latest version
`python3 -m pip install --upgrade pip`

Install podman-compose
`python3 -m pip install podman-compose`

## Starting PostgreSQL in Podman
`podman-compose -f podman-compose.yml up`