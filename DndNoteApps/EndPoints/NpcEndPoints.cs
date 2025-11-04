using System;
using System.Threading.Tasks;
using DndNoteApps.Data;
using DndNoteApps.DTO;
using DndNoteApps.Entities;
using DndNoteApps.Mapping;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DndNoteApps.EndPoints;

public static class NpcEndPoints
{
    const string GetNpcEndpointName = "GetNpc";

    public static RouteGroupBuilder MapNpcEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/npcs");

        //GET /api/npcs
        group.MapGet("/", async (DndNoteContext dbContext) =>
        {
            await dbContext.Npcs
                .AsNoTracking()
                .ToListAsync();
        });

        //GET /api/npcs/{id}
        group.MapGet("/{id}", async (DndNoteContext dbContext, int id) =>
        {
            Npc? npc = await dbContext.Npcs.FindAsync(id);

            return npc is null ? Results.NotFound() : Results.Ok(npc);
        })
        .WithName(GetNpcEndpointName);

        //POST /api/npcs
        group.MapPost("/", async (CreateNpcDto newNpc, DndNoteContext dbContext) =>
        {
            Npc npcToAdd = newNpc.ToEntity();

            dbContext.Npcs.Add(npcToAdd);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetNpcEndpointName,
                new { id = npcToAdd.Id },
                npcToAdd
            );
        });

        //PUT /api/npcs/{id}
        group.MapPut("/{id}", async (UpdateNpcDto updateNpc, DndNoteContext dbContext, int id) =>
        {
            var existingNpc = await dbContext.Npcs.FindAsync(id);

            if (existingNpc is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingNpc).CurrentValues.SetValues(updateNpc.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /api/npcs/{id}
        group.MapDelete("/{id}", async (DndNoteContext dbContext, int id) =>
        {
            await dbContext.Npcs
                .Where(npc => npc.Id == id)
                .ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}
