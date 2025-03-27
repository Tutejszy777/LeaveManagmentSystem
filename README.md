# to run 
docker build -t leave-system-web .
docker run -it --rm -p <custom_port>:8080 --name web-project leave-system-web