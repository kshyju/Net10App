### Linux Deployment

##### Build linux output

Start docker.
Open a terminal in the app src root and run the below commands.
```bash
docker build -t dotnet_10p4_publish_container -f ./publish.Dockerfile .
docker run --rm -v "$(pwd)/publish_output_from_container:/app/publish" dotnet_10p4_publish_container
```

Publish output will be in `publish_output_from_container` directory. You can zip it and delpoy.

##### Deploy published output.

```bash
az login
az account set --subscription "Private Test Sub shkr"
az functionapp deployment source config-zip -g perfapps-easia-rg -n linux-cons-net9-perfapp-queandblob-eas-4 --src "D:\src\PerfMonitoringApp\src\publish_output_from_container\App_0515_1145PST.zip"
```
