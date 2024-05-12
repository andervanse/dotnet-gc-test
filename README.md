# dotnet-gc-test

First build the image ```docker build -t gc-test -f Dockerfile .```

Check the image using ```docker images```

Run iteratively ```docker run --name gc-test -it --memory="100m" --entrypoint "bash" gc-test```

Enter in the running container ```docker exec -it gc-test bash```

Monitor Container ```docker stats```