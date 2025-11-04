using System;
using DndNoteApps.Data;
using Microsoft.EntityFrameworkCore;

namespace DndNoteApps.EndPoints;

public abstract class EndPointBase<T> where T : class
{
    protected const string GetEndpointName = "Get{0}";

    protected static RouteGroupBuilder MapBaseEndPoints(WebApplication app, string groupPrefix, DbSet<T> dbSet)
    {
        var group = app.MapGroup(groupPrefix);

        //GET all
        group.MapGet("/", async (DndNoteContext dbContext) =>
        {
            await dbSet
                .AsNoTracking()
                .ToListAsync();
        });

        //GET by id 
        group.MapGet("/{id}", async (int id, DndNoteContext dbContext) =>
        {
            var entity = await dbSet.FindAsync(id);
            return entity is null ? Results.NotFound() : Results.Ok(entity);
        })
        .WithName(string.Format(GetEndpointName, typeof(T).Name));

        group.MapDelete("/{id}", async (int id, DndNoteContext dbContext) =>
        {
            await dbSet
                .Where(e => EF.Property<int>(e, "Id") == id)
                .ExecuteDeleteAsync();
            return Results.NoContent;
        });
        return group;
    }
}
