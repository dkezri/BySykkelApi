#remove all docker images
#docker rmi $(docker images -q)
#remove all docker containers
#docker rm $(docker ps -aq)

docker build -f OsloBySykkelApi\Dockerfile . -t oslobysykkelapi
docker run --rm -d -e ASPNETCORE_ENVIRONMENT=Development -p 5000:80 oslobysykkelapi
