# Web Api for OnlineShop
- Connect your database in OnlineShop.API -> appsettings.json
  
- For add migration use
```
 dotnet ef migrations add InitialCreate --project OnlineShop.DAL --startup-project OnlineShop.API
```
   
- For migration use
```
 dotnet ef database update
```
