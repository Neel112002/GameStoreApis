# Game Store API

## Starting SQL Server 
```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name sqlpreview --hostname sqlpreview -v sqlvolume:/var/opt/mssql -d --rm mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```

## Setting The connection String to secret manager 
```powershell
$sa_password="[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=Gamestore; User Id=sa; Password=$sa_password; TrustServercertificate=True"
```