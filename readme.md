# run
# Run without docker
````
dotnet build
dotnet run
````
Endpoint : https://localhost:5001/api/PrinterPRNT
method: POST


# Run with docker

docker build -t printerptnt .
docker run -p 8080:80 printerptnt

Endpoint : https://localhost:8080/api/PrinterPRNT
method: POST
