using System;
using Microsoft.EntityFrameworkCore;

namespace DndNoteApps.Data;

public static class DataExtansion
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<DndNoteContext>();
        await dbcontext.Database.MigrateAsync();
    }
}
