using DndNoteApps.Data;
using DndNoteApps.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DndNoteApp");
builder.Services.AddSqlite<DndNoteContext>(connString);


var app = builder.Build();

app.MapCampaignEndPoints();




app.Run();
