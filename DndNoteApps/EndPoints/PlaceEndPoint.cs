using System;
using System.Data;
using DndNoteApps.Data;
using DndNoteApps.DTO;
using DndNoteApps.Entities;
using DndNoteApps.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DndNoteApps.EndPoints;

public static class PlaceEndPoint
{
    const string GetPlaceEndpointName = "GetPlace";
    
    public static RouteGroupBuilder MapPlaceEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("api/places");

        //GET /api/places
        group.MapGet("/", async (DndNoteContext dbContext) =>
        {
            await dbContext.Places
                .AsNoTracking()
                .ToListAsync();
        });

        //GET /api/places/{id}
        group.MapGet("/{id}", async (DndNoteContext dbContext, int id) =>
        {
            Place? place = await dbContext.Places.FindAsync(id);

            return place is null ? Results.NotFound() : Results.Ok(place);
        })
        .WithName(GetPlaceEndpointName);

        //POST /api/places
        group.MapPost("/", async (CreatePlaceDto newPlace, DndNoteContext dbContext) =>
        {
            Place placeToAdd = newPlace.ToEntity();

            dbContext.Places.Add(placeToAdd);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetPlaceEndpointName,
                new { id = placeToAdd.Id },
                placeToAdd
            );
        });

        //PUT /api/places/{id}
        group.MapPut("/{id}", async (UpdatePlaceDto updatePlace, DndNoteContext dbContext, int id) =>
        {
            var existingPlace = await dbContext.Places.FindAsync(id);

            if (existingPlace is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingPlace).CurrentValues.SetValues(updatePlace.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /api/places/{id}
        group.MapDelete("/{id}", async (DndNoteContext dbContext, int id) =>
        {
            await dbContext.Places
                .Where(palce => palce.Id == id)
                .ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}
