#### Run the app with Docker


```bash
$ docker network create dininghall # creating a docker network to connect the containers 
$ docker build -t dining-hall-image -f ./DiningHallServer/Dockerfile . # create docker image for dining hall
$ docker run --net dininghall -d -p 5000:5000 --name dininghall-cont dining-hall-image # run container on port 5000
```
