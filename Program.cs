using GameStore.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepsoitories(builder.Configuration);


var app = builder.Build();

await app.Services.InitializedDbAsync(); //after making DataExtensions.cs file 

//or use the following code to apply migrations without changing the entities

//using (var scope = app.Services.CreateScope())
//{
//  var dbContext = scope.ServiceProvider.GetRequiredService<GamestoreContext>();
//  dbContext.Database.Migrate(); //used to apply migrations without changing the entities 
//}

//define route group for endpoints
GameStore.Api.Endpoints.GameEndpoints.MapGameEndpoints(app);


app.Run();
