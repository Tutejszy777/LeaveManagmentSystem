# to run 
docker build -t aspnetapp .
docker run -it --rm -p <custom_port>:8080 --name aspnetcore_sample aspnetapp