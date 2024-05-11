# dotnet-gc-test

First build the image
```docker build -t gc-test -f Dockerfile .```

Check the image using ```docker images```

Creating a container
```docker create --memory="100m" --name gc-test gc-test```

Start the container
```docker start gc-test```

Run iteratively
```docker run -it --entrypoint "bash" gc-test```

Enter in the running container 
```docker exec -it gc-test bash```

Monitor Container
```docker stats```